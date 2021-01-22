using InfoBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewMessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Default Message Box

        private void btnYesNoCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test Message, Test Message, Test Message, Test Message, Test Message", "Test", MessageBoxButtons.YesNoCancel);
        }

        private void btnOkCancelIgnore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test Message", "Test", MessageBoxButtons.AbortRetryIgnore);
        }

        private void btnOkOnly_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test Message", "Test", MessageBoxButtons.OKCancel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test Message", "Test", MessageBoxButtons.YesNo);
        }

        #endregion

        #region Info Box

        private void btnInfoBoxYesNoCancel_Click(object sender, EventArgs e)
        {
            InformationBox.Show("\nTest Message, Test Message, Test Message, Test Message, Test Message, Test Message, Test Message\n\n", "InformationBox Test", InformationBoxButtons.YesNoCancel, InformationBoxDefaultButton.Button1, InformationBoxButtonsLayout.GroupRight, InformationBoxIcon.Exclamation, InformationBoxTitleIconStyle.SameAsBox);
        }

        #endregion

        private void btnInfoBoxOkCancel_Click(object sender, EventArgs e)
        {
            InformationBox.Show("\nTest Message, Test Message, Test Message, Test Message, Test Message, Test Message, Test Message\n\n", "InformationBox Test", InformationBoxButtons.OKCancel, InformationBoxDefaultButton.Button1, InformationBoxButtonsLayout.GroupRight, InformationBoxIcon.Exclamation, InformationBoxTitleIconStyle.SameAsBox);
        }
    }
}
