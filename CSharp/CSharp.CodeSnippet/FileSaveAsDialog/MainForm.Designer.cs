namespace FileSaveAsDialog
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.labelFileSelect = new System.Windows.Forms.Label();
            this.textFileSelect = new System.Windows.Forms.TextBox();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFileSaveAs = new System.Windows.Forms.Button();
            this.labelFileSaved = new System.Windows.Forms.Label();
            this.textFileSaved = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelFileSelect
            // 
            this.labelFileSelect.AutoSize = true;
            this.labelFileSelect.Location = new System.Drawing.Point(20, 30);
            this.labelFileSelect.Name = "labelFileSelect";
            this.labelFileSelect.Size = new System.Drawing.Size(77, 12);
            this.labelFileSelect.TabIndex = 0;
            this.labelFileSelect.Text = "선택된 파일 :";
            // 
            // textFileSelect
            // 
            this.textFileSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFileSelect.Enabled = false;
            this.textFileSelect.Location = new System.Drawing.Point(110, 26);
            this.textFileSelect.Name = "textFileSelect";
            this.textFileSelect.Size = new System.Drawing.Size(530, 21);
            this.textFileSelect.TabIndex = 1;
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSelect.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFileSelect.Location = new System.Drawing.Point(650, 22);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(30, 25);
            this.btnFileSelect.TabIndex = 2;
            this.btnFileSelect.Text = "...";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(570, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnFileSaveAs
            // 
            this.btnFileSaveAs.Location = new System.Drawing.Point(450, 385);
            this.btnFileSaveAs.Name = "btnFileSaveAs";
            this.btnFileSaveAs.Size = new System.Drawing.Size(100, 25);
            this.btnFileSaveAs.TabIndex = 4;
            this.btnFileSaveAs.Text = "저장하기";
            this.btnFileSaveAs.UseVisualStyleBackColor = true;
            this.btnFileSaveAs.Click += new System.EventHandler(this.btnFileSaveAs_Click);
            // 
            // labelFileSaved
            // 
            this.labelFileSaved.AutoSize = true;
            this.labelFileSaved.Location = new System.Drawing.Point(20, 70);
            this.labelFileSaved.Name = "labelFileSaved";
            this.labelFileSaved.Size = new System.Drawing.Size(77, 12);
            this.labelFileSaved.TabIndex = 5;
            this.labelFileSaved.Text = "저장된 파일 :";
            // 
            // textFileSaved
            // 
            this.textFileSaved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFileSaved.Enabled = false;
            this.textFileSaved.Location = new System.Drawing.Point(110, 66);
            this.textFileSaved.Name = "textFileSaved";
            this.textFileSaved.Size = new System.Drawing.Size(530, 21);
            this.textFileSaved.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.textFileSaved);
            this.Controls.Add(this.labelFileSaved);
            this.Controls.Add(this.btnFileSaveAs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFileSelect);
            this.Controls.Add(this.textFileSelect);
            this.Controls.Add(this.labelFileSelect);
            this.Name = "MainForm";
            this.Text = "::: File Save As ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label labelFileSelect;
        private System.Windows.Forms.TextBox textFileSelect;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFileSaveAs;
        private System.Windows.Forms.Label labelFileSaved;
        private System.Windows.Forms.TextBox textFileSaved;
    }
}

