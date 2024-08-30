<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128625117/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2793)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WinForms Data Grid - How to display a custom button within a column header

This example demonstrates how to "create" and display a custom button within a column header.

The [CustomDrawColumnHeader](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomDrawColumnHeader) event is handled to draw a clickable region within the column header. 

```cs
void OnCustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e) {
    if(e.Column == null) return;
    DefaultDrawColumnHeader(e);
    DrawCustomButton(e);
    e.Handled = true;
}
```

<!-- default file list -->
## Files to Review

* [ColumnHeaderExtender.cs](./CS/WindowsApplication3/ColumnHeaderExtender.cs) (VB: [ColumnHeaderExtender.vb](./VB/WindowsApplication3/ColumnHeaderExtender.vb))

<!-- default file list end -->


## Documentation 
- [CustomDrawColumnHeader](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomDrawColumnHeader)
- [Tutorial: Custom Drawing](https://docs.devexpress.com/WindowsForms/114616/controls-and-libraries/data-grid/getting-started/walkthroughs/appearance-and-conditional-formatting/tutorial-custom-drawing)
- [Custom Draw Templates](https://docs.devexpress.com/WindowsForms/404153/common-features/html-css-based-desktop-ui/custom-draw-with-html-templates)
- [HTML and CSS Support](https://docs.devexpress.com/WindowsForms/403397/common-features/html-css-based-desktop-ui)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-custom-button-in-column-header&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-custom-button-in-column-header&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
