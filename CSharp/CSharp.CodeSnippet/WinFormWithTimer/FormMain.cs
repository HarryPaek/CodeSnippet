using System.Windows.Forms;

namespace WinFormWithTimer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void timerClosing_Tick(object sender, System.EventArgs e)
        {
            this.timerClosing.Stop();
            this.timerClosing.Enabled = false;

            this.Close();
        }

        private void FormMain_Shown(object sender, System.EventArgs e)
        {
            this.timerClosing.Enabled = true;
            this.timerClosing.Start();
        }
    }
}
