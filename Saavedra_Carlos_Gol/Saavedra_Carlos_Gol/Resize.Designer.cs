namespace Saavedra_Carlos_Gol
{
    partial class Resize
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
            this.rowLabel = new System.Windows.Forms.Label();
            this.rowsNUD = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.columnsNUD = new System.Windows.Forms.NumericUpDown();
            this.columnLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(40, 23);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(47, 13);
            this.rowLabel.TabIndex = 0;
            this.rowLabel.Text = "Rows X:";
            // 
            // rowsNUD
            // 
            this.rowsNUD.Location = new System.Drawing.Point(93, 21);
            this.rowsNUD.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.rowsNUD.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.rowsNUD.Name = "rowsNUD";
            this.rowsNUD.Size = new System.Drawing.Size(66, 20);
            this.rowsNUD.TabIndex = 1;
            this.rowsNUD.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 88);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = " &Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 117);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(116, 117);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // columnsNUD
            // 
            this.columnsNUD.Location = new System.Drawing.Point(93, 47);
            this.columnsNUD.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.columnsNUD.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.columnsNUD.Name = "columnsNUD";
            this.columnsNUD.Size = new System.Drawing.Size(66, 20);
            this.columnsNUD.TabIndex = 6;
            this.columnsNUD.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(27, 49);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(60, 13);
            this.columnLabel.TabIndex = 5;
            this.columnLabel.Text = "Columns Y:";
            // 
            // Resize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 155);
            this.Controls.Add(this.columnsNUD);
            this.Controls.Add(this.columnLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.rowsNUD);
            this.Controls.Add(this.rowLabel);
            this.Name = "Resize";
            this.Text = "Resize Grid";
            ((System.ComponentModel.ISupportInitialize)(this.rowsNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.NumericUpDown rowsNUD;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown columnsNUD;
        private System.Windows.Forms.Label columnLabel;
    }
}