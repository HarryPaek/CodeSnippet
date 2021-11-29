using ShowModalWithInterface.Abstracts;
using ShowModalWithInterface.Impl;
using System;
using System.Windows.Forms;

namespace ShowModalWithInterface
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnShowModal_Click(object sender, EventArgs e)
        {
            using (IModalViewer viewer = new ModalViewerForm())
            {
                viewer.View(this.txtKey.Text, this.txtDescription.Text);
                // viewer.ShowDialog(this);
            }
        }
    }
}
