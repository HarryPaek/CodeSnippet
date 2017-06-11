using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAutoCloseMessageBox_Click(object sender, EventArgs e)
        {
            AutoClosingMessageBox.Show("Auto Close in a Second!!!", "Message Box", 5000);

            MessageBox.Show(this, "MessageBox Closed Automatically!!!");
        }
    }
}
