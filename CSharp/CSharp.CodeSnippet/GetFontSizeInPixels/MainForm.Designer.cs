namespace GetFontSizeInPixels
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
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelLower = new System.Windows.Forms.Panel();
            this.picBoxFont = new System.Windows.Forms.PictureBox();
            this.panelUpper = new System.Windows.Forms.Panel();
            this.lblDisplayText = new System.Windows.Forms.Label();
            this.tableLayoutMain.SuspendLayout();
            this.panelLower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFont)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Controls.Add(this.panelLower, 0, 1);
            this.tableLayoutMain.Controls.Add(this.panelUpper, 0, 0);
            this.tableLayoutMain.Controls.Add(this.lblDisplayText, 0, 2);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutMain.Size = new System.Drawing.Size(537, 339);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // panelLower
            // 
            this.tableLayoutMain.SetColumnSpan(this.panelLower, 2);
            this.panelLower.Controls.Add(this.picBoxFont);
            this.panelLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLower.Location = new System.Drawing.Point(3, 153);
            this.panelLower.Name = "panelLower";
            this.panelLower.Size = new System.Drawing.Size(531, 107);
            this.panelLower.TabIndex = 1;
            // 
            // picBoxFont
            // 
            this.picBoxFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxFont.Location = new System.Drawing.Point(0, 0);
            this.picBoxFont.Name = "picBoxFont";
            this.picBoxFont.Size = new System.Drawing.Size(531, 107);
            this.picBoxFont.TabIndex = 0;
            this.picBoxFont.TabStop = false;
            // 
            // panelUpper
            // 
            this.tableLayoutMain.SetColumnSpan(this.panelUpper, 2);
            this.panelUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUpper.Location = new System.Drawing.Point(3, 3);
            this.panelUpper.Name = "panelUpper";
            this.panelUpper.Size = new System.Drawing.Size(531, 144);
            this.panelUpper.TabIndex = 0;
            this.panelUpper.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUpper_Paint);
            // 
            // lblDisplayText
            // 
            this.lblDisplayText.AutoSize = true;
            this.tableLayoutMain.SetColumnSpan(this.lblDisplayText, 2);
            this.lblDisplayText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplayText.Location = new System.Drawing.Point(5, 268);
            this.lblDisplayText.Margin = new System.Windows.Forms.Padding(5);
            this.lblDisplayText.Name = "lblDisplayText";
            this.lblDisplayText.Size = new System.Drawing.Size(527, 66);
            this.lblDisplayText.TabIndex = 2;
            this.lblDisplayText.Text = "Display Text";
            this.lblDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDisplayText.Paint += new System.Windows.Forms.PaintEventHandler(this.lblDisplayText_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 339);
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "MainForm";
            this.Text = "::: Get Font Size In Pixels";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.panelLower.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFont)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelLower;
        private System.Windows.Forms.Panel panelUpper;
        private System.Windows.Forms.PictureBox picBoxFont;
        private System.Windows.Forms.Label lblDisplayText;
    }
}

