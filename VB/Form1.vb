Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Namespace WindowsApplication165
	Partial Public Class Form1
		Inherits Form
		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim r As New Random()
			Dim tbl As New DataTable()
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("EmployeeID", GetType(Integer))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { String.Format("Name{0}", r.Next(10)), r.Next(10), r.Next(5), DateTime.Now.AddDays(i) })
			Next i
			Return tbl
		End Function


		Public Sub New()
			InitializeComponent()


			gridControl1.DataSource = CreateTable(20)
			AddHandler gridView1.StartSorting, AddressOf gridView1_StartSorting
		End Sub

		Private Sub gridView1_StartSorting(ByVal sender As Object, ByVal e As EventArgs)
			Dim view As GridView = TryCast(sender, GridView)
			Dim column As GridColumn = view.Columns("EmployeeID")
			If checkEdit1.Checked Then
				If column.SortOrder <> DevExpress.Data.ColumnSortOrder.Ascending OrElse column.SortIndex <> view.SortInfo.Count - 1 Then
					column.SortIndex = view.SortInfo.Count
					column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
				End If
			Else
				If column.SortOrder <> DevExpress.Data.ColumnSortOrder.Ascending OrElse column.SortIndex <> 0 Then
					view.SortInfo.Insert(0, New GridColumnSortInfo(column, DevExpress.Data.ColumnSortOrder.Ascending))
				End If
			End If
		End Sub
	End Class
End Namespace