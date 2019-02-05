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
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.buttonManageCategories = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 6);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(576, 355);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_CellClicked);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
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
            this.buttonSaveData.Click += new System.EventHandler(this.ButtonSaveNumericData_Click);
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Location = new System.Drawing.Point(588, 93);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadData.TabIndex = 7;
            this.buttonLoadData.Text = "Load data";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.ButtonLoadData_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTable);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(677, 393);
            this.tabControl.TabIndex = 9;
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.buttonManageCategories);
            this.tabPageTable.Controls.Add(this.buttonDelete);
            this.tabPageTable.Controls.Add(this.dataGridView);
            this.tabPageTable.Controls.Add(this.buttonSaveData);
            this.tabPageTable.Controls.Add(this.buttonLoadData);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(669, 367);
            this.tabPageTable.TabIndex = 2;
            this.tabPageTable.Text = "Data table";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // buttonManageCategories
            // 
            this.buttonManageCategories.Location = new System.Drawing.Point(588, 6);
            this.buttonManageCategories.Name = "buttonManageCategories";
            this.buttonManageCategories.Size = new System.Drawing.Size(75, 52);
            this.buttonManageCategories.TabIndex = 10;
            this.buttonManageCategories.Text = "Manage categories and types";
            this.buttonManageCategories.UseVisualStyleBackColor = true;
            this.buttonManageCategories.Click += new System.EventHandler(this.ButtonManageCategories_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(588, 309);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 52);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete selected rows";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 417);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWindow";
            this.Text = "Workout Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonManageCategories;
    }
}