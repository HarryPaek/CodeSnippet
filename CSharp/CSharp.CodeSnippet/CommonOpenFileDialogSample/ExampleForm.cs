using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;

namespace CommonOpenFileDialogSample
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "E:\\Temp";
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dialog.FileName);
            }
        }
    }
}
