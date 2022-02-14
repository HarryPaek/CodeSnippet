using System;
using System.Windows.Forms;

namespace FormKeyPreviewKeyUpExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show(this, string.Format("KeyEventArgs.KeyCode=[{0}], KeyEventArgs.KeyData=[{1}]", e.KeyCode, e.KeyData), "::: MainForm_KeyUp");

            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.btnSimpleClick.PerformClick();
                    break;

                case Keys.F5:
                    int tabCount = this.tabControlMain.TabCount;

                    if (tabCount > 1) {
                        int newSelectedIndex = this.tabControlMain.SelectedIndex;
                        newSelectedIndex++;

                        if (newSelectedIndex >= tabCount)
                            newSelectedIndex = 0;

                        this.tabControlMain.SelectedIndex = newSelectedIndex;
                    }

                    break;

                default:
                    break;
            }

            //listBox1.Items.Add(e.KeyCode);

            //e.Handled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK Button Pressed");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exit Button Pressed");
        }

        private void btnSimpleClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SimpleClick Button Pressed");
        }

        private void btnSetTextBox_Click(object sender, EventArgs e)
        {
            this.txtBox1.Text = DateTime.Now.ToLongDateString();
            this.txtBox2.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
