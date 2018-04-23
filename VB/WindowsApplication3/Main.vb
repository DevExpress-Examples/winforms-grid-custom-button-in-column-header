Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub InitData()
			For i As Integer = 0 To 4
				dataSet11.Tables(0).Rows.Add(New Object() { i, String.Format("FirstName {0}", i), i})
			Next i
		End Sub
		Private extender As ColumnHeaderExtender
		Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			InitData()
			extender = New ColumnHeaderExtender(gridView1)
			extender.AddCustomButton()
		End Sub

		Private Sub OnFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			extender.RemoveCustomButton()
		End Sub

	End Class
End Namespace
