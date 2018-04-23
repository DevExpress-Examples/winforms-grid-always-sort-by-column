using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace WindowsApplication165
{
    public partial class Form1 : Form
    {
        private DataTable CreateTable(int RowCount)
        {
            Random r = new Random();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("EmployeeID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", r.Next(10)), r.Next(10), r.Next(5), DateTime.Now.AddDays(i) });
            return tbl;
        }
        

        public Form1()
        {
            InitializeComponent();


            gridControl1.DataSource = CreateTable(20);
            gridView1.StartSorting += new EventHandler(gridView1_StartSorting);
        }

        void gridView1_StartSorting(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn column = view.Columns["EmployeeID"];
            if (checkEdit1.Checked)
            {
                if (column.SortOrder != DevExpress.Data.ColumnSortOrder.Ascending || column.SortIndex != view.SortInfo.Count - 1)
                {
                    column.SortIndex = view.SortInfo.Count;
                    column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }
            }
            else
            {
                if (column.SortOrder != DevExpress.Data.ColumnSortOrder.Ascending || column.SortIndex != 0)
                {
                    view.SortInfo.Insert(0, new GridColumnSortInfo(column, DevExpress.Data.ColumnSortOrder.Ascending));
                }
            }
        }
    }
}