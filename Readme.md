<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128630369/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E759)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Always sort data by values of a specific column

This example handles the [StartSorting]() event to sort data in ascending order first by values of the `EmployeeID` column and then by other columns:

```csharp
public Form1() {
    InitializeComponent();
    gridControl1.DataSource = CreateTable(20);
    gridView1.StartSorting += new EventHandler(gridView1_StartSorting);
}

void gridView1_StartSorting(object sender, EventArgs e) {
    GridView view = sender as GridView;
    GridColumn column = view.Columns["EmployeeID"];
    if (checkEdit1.Checked) {
        if (column.SortOrder != DevExpress.Data.ColumnSortOrder.Ascending || column.SortIndex != view.SortInfo.Count - 1) {
            column.SortIndex = view.SortInfo.Count;
            column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }
    }
    else {
        if (column.SortOrder != DevExpress.Data.ColumnSortOrder.Ascending || column.SortIndex != 0) {
            view.SortInfo.Insert(0, new GridColumnSortInfo(column, DevExpress.Data.ColumnSortOrder.Ascending));
        }
    }
}
```


## Files to Reivew

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Data Sorting - WinForms Data Grid](https://docs.devexpress.com/WindowsForms/3499/controls-and-libraries/data-grid/sorting)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-always-sort-by-column&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-always-sort-by-column&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
