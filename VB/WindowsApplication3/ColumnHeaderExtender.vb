Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils

Namespace DXSample
	Public Class ColumnHeaderExtender
		Private view As GridView
		Private customButtonPainter As SkinEditorButtonPainter
		Private args As EditorButtonObjectInfoArgs
		Private buttonSize As Size

		Public Sub New(ByVal view As GridView)
			Me.view = view
			buttonSize = New Size(14, 14)

		End Sub

		Public Sub AddCustomButton()
			CreateButtonPainter()
			CreateButtonInfoArgs()
			SubscribeToEvents()
		End Sub

		Private Sub CreateButtonInfoArgs()
			Dim btn As New EditorButton(ButtonPredefines.Glyph)
			args = New EditorButtonObjectInfoArgs(btn, New DevExpress.Utils.AppearanceObject())
		End Sub

		Private Sub CreateButtonPainter()
			customButtonPainter = New SkinEditorButtonPainter(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel)
		End Sub

		Private Sub SubscribeToEvents()
			AddHandler view.CustomDrawColumnHeader, AddressOf OnCustomDrawColumnHeader
			AddHandler view.MouseDown, AddressOf OnMouseDown
			AddHandler view.MouseUp, AddressOf OnMouseUp
			AddHandler view.MouseMove, AddressOf OnMouseMove
		End Sub

		Private Sub OnMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim hitInfo As GridHitInfo = view.CalcHitInfo(e.Location)
			If hitInfo.HitTest <> GridHitTest.Column Then
				Return
			End If
			Dim column As GridColumn = hitInfo.Column
			If IsButtonRect(e.Location, column) Then
				SetButtonState(column, ObjectState.Normal)
				XtraMessageBox.Show(String.Format("Custom Button in {0}", column.FieldName))
				' your code here
				DXMouseEventArgs.GetMouseArgs(e).Handled = True
			End If
		End Sub

		Private Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim hitInfo As GridHitInfo = view.CalcHitInfo(e.Location)
			If hitInfo.HitTest <> GridHitTest.Column Then
				Return
			End If
			Dim column As GridColumn = hitInfo.Column
			If IsButtonRect(e.Location, column) Then
				SetButtonState(column, ObjectState.Hot)
			Else
				SetButtonState(column, ObjectState.Normal)
			End If
		End Sub

		Private Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim hitInfo As GridHitInfo = view.CalcHitInfo(e.Location)
			If hitInfo.HitTest <> GridHitTest.Column Then
				Return
			End If
			Dim column As GridColumn = hitInfo.Column
			If IsButtonRect(e.Location, column) Then
				SetButtonState(column, ObjectState.Pressed)
				DXMouseEventArgs.GetMouseArgs(e).Handled = True
			End If
		End Sub

		Private Sub SetButtonState(ByVal column As GridColumn, ByVal state As ObjectState)
			column.Tag = state
			view.InvalidateColumnHeader(column)
		End Sub

		Private Function IsButtonRect(ByVal point As Point, ByVal column As GridColumn) As Boolean
			Dim info As New GraphicsInfo()
			info.AddGraphics(Nothing)
			Dim viewInfo As GridViewInfo = TryCast(view.GetViewInfo(), GridViewInfo)
			Dim columnArgs As GridColumnInfoArgs = viewInfo.ColumnsInfo(column)
			Dim buttonRect As Rectangle = CalcButtonRect(columnArgs, info.Graphics)
			info.ReleaseGraphics()
			Return buttonRect.Contains(point)
		End Function

		Private Function CalcButtonRect(ByVal columnArgs As GridColumnInfoArgs, ByVal gr As Graphics) As Rectangle
			Dim columnRect As Rectangle = columnArgs.Bounds
			Dim innerElementsWidth As Integer = CalcInnerElementsMinWidth(columnArgs, gr)
			Dim buttonRect As New Rectangle(columnRect.Right - innerElementsWidth - buttonSize.Width - 2, columnRect.Y + columnRect.Height \ 2 - buttonSize.Height \ 2, buttonSize.Width, buttonSize.Height)
			Return buttonRect
		End Function

		Private Function CalcInnerElementsMinWidth(ByVal columnArgs As GridColumnInfoArgs, ByVal gr As Graphics) As Integer
			Dim canDrawMode As Boolean = True
			Return columnArgs.InnerElements.CalcMinSize(gr, canDrawMode).Width
		End Function

		Private Sub OnCustomDrawColumnHeader(ByVal sender As Object, ByVal e As ColumnHeaderCustomDrawEventArgs)
			If e.Column Is Nothing Then
				Return
			End If
			DefaultDrawColumnHeader(e)
			DrawCustomButton(e)
			e.Handled = True
		End Sub

		Private Sub DrawCustomButton(ByVal e As ColumnHeaderCustomDrawEventArgs)
			SetUpButtonInfoArgs(e)
			customButtonPainter.DrawObject(args)
		End Sub

		Private Sub SetUpButtonInfoArgs(ByVal e As ColumnHeaderCustomDrawEventArgs)
			args.Cache = e.Cache
			args.Bounds = CalcButtonRect(e.Info, e.Cache.Graphics)
			Dim state As ObjectState = ObjectState.Normal
			If TypeOf e.Column.Tag Is ObjectState Then
				state = DirectCast(e.Column.Tag, ObjectState)
			End If
			args.State = state
		End Sub

		Private Shared Sub DefaultDrawColumnHeader(ByVal e As ColumnHeaderCustomDrawEventArgs)
			e.Painter.DrawObject(e.Info)
		End Sub

		Private Sub UnsubscribeFromEvents()
			RemoveHandler view.CustomDrawColumnHeader, AddressOf OnCustomDrawColumnHeader
			RemoveHandler view.MouseDown, AddressOf OnMouseDown
			RemoveHandler view.MouseUp, AddressOf OnMouseUp
			RemoveHandler view.MouseMove, AddressOf OnMouseMove
		End Sub

		Public Sub RemoveCustomButton()
			UnsubscribeFromEvents()

		End Sub
	End Class
End Namespace
