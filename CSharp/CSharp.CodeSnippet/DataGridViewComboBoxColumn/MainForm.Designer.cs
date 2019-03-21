namespace DataGridViewComboBoxColumn
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
            this.tableLayoutDataGridView = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewComboBoxColumn = new System.Windows.Forms.DataGridView();
            this.btnTest = new System.Windows.Forms.Button();
            this.tableLayoutDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComboBoxColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutDataGridView
            // 
            this.tableLayoutDataGridView.ColumnCount = 3;
            this.tableLayoutDataGridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDataGridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutDataGridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutDataGridView.Controls.Add(this.dataGridViewComboBoxColumn, 0, 0);
            this.tableLayoutDataGridView.Controls.Add(this.btnTest, 2, 1);
            this.tableLayoutDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutDataGridView.Name = "tableLayoutDataGridView";
            this.tableLayoutDataGridView.RowCount = 2;
            this.tableLayoutDataGridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDataGridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutDataGridView.Size = new System.Drawing.Size(624, 441);
            this.tableLayoutDataGridView.TabIndex = 0;
            // 
            // dataGridViewComboBoxColumn
            // 
            this.dataGridViewComboBoxColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutDataGridView.SetColumnSpan(this.dataGridViewComboBoxColumn, 3);
            this.dataGridViewComboBoxColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewComboBoxColumn.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewComboBoxColumn.Name = "dataGridViewComboBoxColumn";
            this.dataGridViewComboBoxColumn.RowTemplate.Height = 23;
            this.dataGridViewComboBoxColumn.Size = new System.Drawing.Size(618, 395);
            this.dataGridViewComboBoxColumn.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTest.Location = new System.Drawing.Point(484, 408);
            this.btnTest.Margin = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(130, 26);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "테스트";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tableLayoutDataGridView);
            this.Name = "MainForm";
            this.Text = "::: DataGridView ComboBox Column Test";
            this.tableLayoutDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComboBoxColumn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutDataGridView;
        private System.Windows.Forms.DataGridView dataGridViewComboBoxColumn;
        private System.Windows.Forms.Button btnTest;
    }
}

