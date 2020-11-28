using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;

namespace CommonSaveFileDialogSample
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            CommonSaveFileDialog saveFileDialog1 = new CommonSaveFileDialog();
            saveFileDialog1.Filters.Add(new CommonFileDialogFilter("Jpeg Image", "*.jpg") { ShowExtensions = true });
            saveFileDialog1.Filters.Add(new CommonFileDialogFilter("Bitmap Image", "*.bmp") { ShowExtensions = true });
            saveFileDialog1.Filters.Add(new CommonFileDialogFilter("Gif Image", "*.gif") { ShowExtensions = true });
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.IsExpandedMode = false;

            if (CommonFileDialogResult.Ok == saveFileDialog1.ShowDialog()) {
                MessageBox.Show(string.Format("saveFileDialog1.FileName = [{0}]", saveFileDialog1.FileName), "btnSaveImage_Click");
            }
        }
    }
}
