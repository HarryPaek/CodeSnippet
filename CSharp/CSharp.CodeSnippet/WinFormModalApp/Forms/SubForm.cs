using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormModalApp.Forms
{
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();
        }

        private void SubForm_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(10000);

            this.Close();
        }

        private void SubForm_Load(object sender, EventArgs e)
        {

        }
    }
}
