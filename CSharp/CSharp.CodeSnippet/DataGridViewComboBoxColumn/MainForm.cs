using System;
using System.Windows.Forms;

namespace DataGridViewComboBoxColumn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.dataGridViewComboBoxColumn.ColumnCount = 3;
            dataGridViewComboBoxColumn.Columns[0].Name = "Product ID";
            dataGridViewComboBoxColumn.Columns[1].Name = "Product Name";
            dataGridViewComboBoxColumn.Columns[2].Name = "Product Price";

            string[] row = new string[] { "1", "Product 1", "1000" };
            dataGridViewComboBoxColumn.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            dataGridViewComboBoxColumn.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            dataGridViewComboBoxColumn.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            dataGridViewComboBoxColumn.Rows.Add(row);

            System.Windows.Forms.DataGridViewComboBoxColumn cmb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            cmb.HeaderText = "Select Data";
            cmb.Name = "cmb";
            cmb.MaxDropDownItems = 4;
            cmb.Items.Add("True");
            cmb.Items.Add("False");
            dataGridViewComboBoxColumn.Columns.Add(cmb);
        }
    }
}
