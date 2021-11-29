namespace ShowModalWithInterface.Impl
{
    partial class ModalViewerForm
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
            this.txtKeyText = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescText = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStriplblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKeyText
            // 
            this.txtKeyText.Location = new System.Drawing.Point(42, 59);
            this.txtKeyText.Name = "txtKeyText";
            this.txtKeyText.ReadOnly = true;
            this.txtKeyText.Size = new System.Drawing.Size(209, 21);
            this.txtKeyText.TabIndex = 0;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(42, 41);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(27, 12);
            this.lblLabel.TabIndex = 1;
            this.lblLabel.Text = "Key";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(38, 111);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 12);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // txtDescText
            // 
            this.txtDescText.Location = new System.Drawing.Point(38, 129);
            this.txtDescText.Name = "txtDescText";
            this.txtDescText.ReadOnly = true;
            this.txtDescText.Size = new System.Drawing.Size(209, 21);
            this.txtDescText.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriplblStatusBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 239);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStriplblStatusBar
            // 
            this.toolStriplblStatusBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStriplblStatusBar.Name = "toolStriplblStatusBar";
            this.toolStriplblStatusBar.Size = new System.Drawing.Size(16, 17);
            this.toolStriplblStatusBar.Text = "...";
            this.toolStriplblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModalViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescText);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.txtKeyText);
            this.Name = "ModalViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModalViewerForm";
            this.Activated += new System.EventHandler(this.ModalViewerForm_Activated);
            this.Deactivate += new System.EventHandler(this.ModalViewerForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModalViewerForm_FormClosing);
            this.Load += new System.EventHandler(this.ModalViewerForm_Load);
            this.Shown += new System.EventHandler(this.ModalViewerForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.ModalViewerForm_VisibleChanged);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyText;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescText;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStriplblStatusBar;
    }
}