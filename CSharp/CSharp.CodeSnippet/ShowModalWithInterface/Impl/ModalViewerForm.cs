using ShowModalWithInterface.Abstracts;
using System;
using System.Windows.Forms;

namespace ShowModalWithInterface.Impl
{
    public partial class ModalViewerForm : Form, IModalViewer
    {
        private bool _alreadyInitialized = false;

        public ModalViewerForm()
        {
            InitializeComponent();
        }

        #region IModalViewer Implementations

        public void View(string key, string description)
        {
            try
            {
                this.Show();

                // this.Visible = false;
                this.txtKeyText.Text = key;
                this.txtDescText.Text = description;

                throw new Exception("테스트 Exception");
            }
            catch(Exception ex)
            {
                this.toolStriplblStatusBar.Text = ex.Message;
            }
            finally
            {
                Application.DoEvents();

                this._alreadyInitialized = true;
                this.ShowDialog();
            }
        }

        #endregion

        private void ModalViewerForm_Load(object sender, System.EventArgs e)
        {
            if (this._alreadyInitialized)
                MessageBox.Show("ModalViewerForm_Load(), this._alreadyInitialized");
        }

        private void ModalViewerForm_Shown(object sender, System.EventArgs e)
        {
            if (!this._alreadyInitialized)
                this.Visible = false;
            else
                MessageBox.Show("ModalViewerForm_Shown(), this._alreadyInitialized");

            // this._alreadyInitialized = true;
        }

        private void ModalViewerForm_Deactivate(object sender, System.EventArgs e)
        {
            // MessageBox.Show("ModalViewerForm_Deactivate()");
        }

        private void ModalViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("ModalViewerForm_FormClosing()");
        }

        private void ModalViewerForm_Activated(object sender, System.EventArgs e)
        {
            // MessageBox.Show("ModalViewerForm_Activated()");
        }

        private void ModalViewerForm_VisibleChanged(object sender, System.EventArgs e)
        {
            // MessageBox.Show("ModalViewerForm_VisibleChanged()");
        }
    }
}
