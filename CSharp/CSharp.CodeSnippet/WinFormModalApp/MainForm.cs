using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormModalApp.Forms;

namespace WinFormModalApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start Subform With Modaless");

            new SubForm().Show();

            MessageBox.Show("End Subform With Modaless");
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start Subform With Modal");

            new SubForm().ShowDialog();

            MessageBox.Show("End Subform With Modal");
        }
    }
}
