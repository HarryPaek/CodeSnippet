using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
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
            dialog.DefaultDirectory = KnownFolders.Downloads.Path;
            // dialog.InitialDirectory = KnownFolders.Downloads.Path;
            dialog.RestoreDirectory = true;
            dialog.IsFolderPicker = true;
            dialog.Title = "ABCD";  // string.Empty => 기본 Tilte ('폴더 선택')이 표시됨

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dialog.FileName);
            }
        }
    }
}
