namespace WorkoutTracker.View
{
    partial class TextBoxDialog
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.groupBoxId = new System.Windows.Forms.GroupBox();
            this.numericId = new System.Windows.Forms.NumericUpDown();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBoxId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericId)).BeginInit();
            this.groupBoxName.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(6, 20);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(179, 20);
            this.textBox.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(200, 71);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // groupBoxId
            // 
            this.groupBoxId.Controls.Add(this.numericId);
            this.groupBoxId.Location = new System.Drawing.Point(6, 19);
            this.groupBoxId.Name = "groupBoxId";
            this.groupBoxId.Size = new System.Drawing.Size(78, 46);
            this.groupBoxId.TabIndex = 2;
            this.groupBoxId.TabStop = false;
            this.groupBoxId.Text = "Order";
            // 
            // numericId
            // 
            this.numericId.Location = new System.Drawing.Point(6, 19);
            this.numericId.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericId.Name = "numericId";
            this.numericId.ReadOnly = true;
            this.numericId.Size = new System.Drawing.Size(65, 20);
            this.numericId.TabIndex = 0;
            this.numericId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxName
            // 
            this.groupBoxName.Controls.Add(this.textBox);
            this.groupBoxName.Location = new System.Drawing.Point(90, 19);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Size = new System.Drawing.Size(191, 46);
            this.groupBoxName.TabIndex = 3;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupBoxId);
            this.groupBox.Controls.Add(this.buttonConfirm);
            this.groupBox.Controls.Add(this.groupBoxName);
            this.groupBox.Location = new System.Drawing.Point(3, -4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(289, 108);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // TextBoxDialog
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 106);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TextBoxDialog";
            this.ShowIcon = false;
            this.Text = "TextBoxDialog";
            this.groupBoxId.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericId)).EndInit();
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.GroupBox groupBoxId;
        private System.Windows.Forms.GroupBox groupBoxName;
        public System.Windows.Forms.NumericUpDown numericId;
        private System.Windows.Forms.GroupBox groupBox;
    }
}