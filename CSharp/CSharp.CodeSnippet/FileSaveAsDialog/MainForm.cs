using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSaveAsDialog
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Title = "고객 파일 선택";
            this.openFileDialog.InitialDirectory = "E:\\Temp";
            this.openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel Files with macro (*.xlsm)|*.xlsm|All files (*.*)|*.*";
            this.openFileDialog.FilterIndex = 1;
            this.openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == this.openFileDialog.ShowDialog())
                this.textFileSelect.Text = this.openFileDialog.FileName;
        }

        private void btnFileSaveAs_Click(object sender, EventArgs e)
        {
            // this.saveFileDialog.CreatePrompt = true;
            this.saveFileDialog.OverwritePrompt = true;
            this.saveFileDialog.SupportMultiDottedExtensions = true;

            this.saveFileDialog.Title = "프로젝트 파일 저장";
            this.saveFileDialog.DefaultExt = "xlsx";
            this.saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel Files with macro (*.xlsm)|*.xlsm|All files (*.*)|*.*";

            if(DialogResult.OK == this.saveFileDialog.ShowDialog())
                this.textFileSaved.Text = this.saveFileDialog.FileName;
        }
    }
}
