namespace WorkoutTracker.View
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonManageCategories = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 6);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(576, 355);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellClicked);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.Location = new System.Drawing.Point(588, 64);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveData.TabIndex = 1;
            this.buttonSaveData.Text = "Save data";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveNumericData_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(588, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "fill table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Location = new System.Drawing.Point(588, 93);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadData.TabIndex = 7;
            this.buttonLoadData.Text = "Load data";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(588, 338);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "tab2dto";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 393);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonManageCategories);
            this.tabPage1.Controls.Add(this.buttonDelete);
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.buttonSaveData);
            this.tabPage1.Controls.Add(this.buttonLoadData);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(669, 367);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonManageCategories
            // 
            this.buttonManageCategories.Location = new System.Drawing.Point(588, 6);
            this.buttonManageCategories.Name = "buttonManageCategories";
            this.buttonManageCategories.Size = new System.Drawing.Size(75, 52);
            this.buttonManageCategories.TabIndex = 10;
            this.buttonManageCategories.Text = "Manage categories and types";
            this.buttonManageCategories.UseVisualStyleBackColor = true;
            this.buttonManageCategories.Click += new System.EventHandler(this.buttonManageCategories_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(588, 223);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button6_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 417);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonManageCategories;
    }
}