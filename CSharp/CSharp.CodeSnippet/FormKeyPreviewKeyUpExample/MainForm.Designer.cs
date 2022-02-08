namespace FormKeyPreviewKeyUpExample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSimpleClick = new System.Windows.Forms.Button();
            this.btnClick = new FormKeyPreviewKeyUpExample.Controls.MyMnemonicButton();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.txtBox2 = new System.Windows.Forms.TextBox();
            this.btnSetTextBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(203, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(297, 246);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(5, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 148);
            this.listBox1.TabIndex = 2;
            // 
            // btnSimpleClick
            // 
            this.btnSimpleClick.Location = new System.Drawing.Point(91, 188);
            this.btnSimpleClick.Name = "btnSimpleClick";
            this.btnSimpleClick.Size = new System.Drawing.Size(112, 23);
            this.btnSimpleClick.TabIndex = 5;
            this.btnSimpleClick.Text = "&Simple Click";
            this.btnSimpleClick.UseVisualStyleBackColor = true;
            this.btnSimpleClick.Click += new System.EventHandler(this.btnSimpleClick_Click);
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(91, 159);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(75, 23);
            this.btnClick.TabIndex = 6;
            this.btnClick.Text = "&Click";
            this.btnClick.UseVisualStyleBackColor = true;
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(177, 21);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.ReadOnly = true;
            this.txtBox1.Size = new System.Drawing.Size(195, 21);
            this.txtBox1.TabIndex = 7;
            // 
            // txtBox2
            // 
            this.txtBox2.Location = new System.Drawing.Point(177, 64);
            this.txtBox2.Name = "txtBox2";
            this.txtBox2.ReadOnly = true;
            this.txtBox2.Size = new System.Drawing.Size(195, 21);
            this.txtBox2.TabIndex = 8;
            // 
            // btnSetTextBox
            // 
            this.btnSetTextBox.Location = new System.Drawing.Point(260, 159);
            this.btnSetTextBox.Name = "btnSetTextBox";
            this.btnSetTextBox.Size = new System.Drawing.Size(112, 23);
            this.btnSetTextBox.TabIndex = 9;
            this.btnSetTextBox.Text = "Set Text Data";
            this.btnSetTextBox.UseVisualStyleBackColor = true;
            this.btnSetTextBox.Click += new System.EventHandler(this.btnSetTextBox_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.btnSetTextBox);
            this.Controls.Add(this.txtBox2);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.btnSimpleClick);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "::: Form KeyUp Example";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSimpleClick;
        private Controls.MyMnemonicButton btnClick;
        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.TextBox txtBox2;
        private System.Windows.Forms.Button btnSetTextBox;
    }
}

