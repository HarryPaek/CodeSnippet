namespace WindowsFormsApplication
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnAutoCloseMessageBox = new System.Windows.Forms.Button();
            this.grboxApplication = new System.Windows.Forms.GroupBox();
            this.grboxCategory = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grboxFile = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCenterLabel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.grboxApplication.SuspendLayout();
            this.grboxCategory.SuspendLayout();
            this.grboxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAutoCloseMessageBox
            // 
            this.btnAutoCloseMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoCloseMessageBox.BackColor = System.Drawing.Color.White;
            this.btnAutoCloseMessageBox.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAutoCloseMessageBox.ForeColor = System.Drawing.Color.Black;
            this.btnAutoCloseMessageBox.Location = new System.Drawing.Point(23, 41);
            this.btnAutoCloseMessageBox.Name = "btnAutoCloseMessageBox";
            this.btnAutoCloseMessageBox.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAutoCloseMessageBox.Size = new System.Drawing.Size(325, 49);
            this.btnAutoCloseMessageBox.TabIndex = 0;
            this.btnAutoCloseMessageBox.Text = "MessageBox Auto Closing";
            this.btnAutoCloseMessageBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoCloseMessageBox.UseVisualStyleBackColor = false;
            this.btnAutoCloseMessageBox.Click += new System.EventHandler(this.btnAutoCloseMessageBox_Click);
            // 
            // grboxApplication
            // 
            this.grboxApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grboxApplication.BackColor = System.Drawing.Color.Transparent;
            this.grboxApplication.Controls.Add(this.btnAutoCloseMessageBox);
            this.grboxApplication.ForeColor = System.Drawing.Color.White;
            this.grboxApplication.Location = new System.Drawing.Point(12, 74);
            this.grboxApplication.Name = "grboxApplication";
            this.grboxApplication.Size = new System.Drawing.Size(379, 630);
            this.grboxApplication.TabIndex = 1;
            this.grboxApplication.TabStop = false;
            this.grboxApplication.Text = " EPLAN 응용프로그램 ";
            // 
            // grboxCategory
            // 
            this.grboxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grboxCategory.BackColor = System.Drawing.Color.Transparent;
            this.grboxCategory.Controls.Add(this.button1);
            this.grboxCategory.ForeColor = System.Drawing.Color.White;
            this.grboxCategory.Location = new System.Drawing.Point(402, 74);
            this.grboxCategory.Name = "grboxCategory";
            this.grboxCategory.Size = new System.Drawing.Size(379, 630);
            this.grboxCategory.TabIndex = 2;
            this.grboxCategory.TabStop = false;
            this.grboxCategory.Text = " 영역 구분 ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(23, 41);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(325, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "MessageBox Auto Closing";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // grboxFile
            // 
            this.grboxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grboxFile.BackColor = System.Drawing.Color.Transparent;
            this.grboxFile.Controls.Add(this.button2);
            this.grboxFile.ForeColor = System.Drawing.Color.White;
            this.grboxFile.Location = new System.Drawing.Point(792, 74);
            this.grboxFile.Name = "grboxFile";
            this.grboxFile.Size = new System.Drawing.Size(379, 630);
            this.grboxFile.TabIndex = 3;
            this.grboxFile.TabStop = false;
            this.grboxFile.Text = " 파일 ";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(23, 41);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(325, 49);
            this.button2.TabIndex = 0;
            this.button2.Text = "MessageBox Auto Closing";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCenterLabel
            // 
            this.btnCenterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCenterLabel.BackColor = System.Drawing.Color.Transparent;
            this.btnCenterLabel.Enabled = false;
            this.btnCenterLabel.Font = new System.Drawing.Font("Gulim", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCenterLabel.ForeColor = System.Drawing.Color.White;
            this.btnCenterLabel.Location = new System.Drawing.Point(12, 12);
            this.btnCenterLabel.Name = "btnCenterLabel";
            this.btnCenterLabel.Size = new System.Drawing.Size(1159, 49);
            this.btnCenterLabel.TabIndex = 1;
            this.btnCenterLabel.TabStop = false;
            this.btnCenterLabel.Text = "MessageBox Auto Closing";
            this.btnCenterLabel.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 729);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCenterLabel);
            this.Controls.Add(this.grboxFile);
            this.Controls.Add(this.grboxCategory);
            this.Controls.Add(this.grboxApplication);
            this.MinimumSize = new System.Drawing.Size(1200, 768);
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.grboxApplication.ResumeLayout(false);
            this.grboxCategory.ResumeLayout(false);
            this.grboxFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutoCloseMessageBox;
        private System.Windows.Forms.GroupBox grboxApplication;
        private System.Windows.Forms.GroupBox grboxCategory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grboxFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCenterLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

