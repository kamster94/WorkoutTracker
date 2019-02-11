namespace WorkoutTracker.View
{
    partial class CategoriesAndTypesWindow
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
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.groupBoxCategory = new System.Windows.Forms.GroupBox();
            this.buttonCategoryDelete = new System.Windows.Forms.Button();
            this.buttonCategoryEdit = new System.Windows.Forms.Button();
            this.buttonCategoryAdd = new System.Windows.Forms.Button();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.buttonTypeDelete = new System.Windows.Forms.Button();
            this.buttonTypeEdit = new System.Windows.Forms.Button();
            this.buttonTypeAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxCategory.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(6, 19);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(175, 21);
            this.comboBoxCategories.TabIndex = 0;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategories_SelectedIndexChanged);
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(6, 19);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(175, 21);
            this.comboBoxTypes.TabIndex = 1;
            // 
            // groupBoxCategory
            // 
            this.groupBoxCategory.Controls.Add(this.buttonCategoryDelete);
            this.groupBoxCategory.Controls.Add(this.buttonCategoryEdit);
            this.groupBoxCategory.Controls.Add(this.buttonCategoryAdd);
            this.groupBoxCategory.Controls.Add(this.comboBoxCategories);
            this.groupBoxCategory.Location = new System.Drawing.Point(13, 13);
            this.groupBoxCategory.Name = "groupBoxCategory";
            this.groupBoxCategory.Size = new System.Drawing.Size(429, 53);
            this.groupBoxCategory.TabIndex = 2;
            this.groupBoxCategory.TabStop = false;
            this.groupBoxCategory.Text = "Category";
            // 
            // buttonCategoryDelete
            // 
            this.buttonCategoryDelete.Location = new System.Drawing.Point(349, 19);
            this.buttonCategoryDelete.Name = "buttonCategoryDelete";
            this.buttonCategoryDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonCategoryDelete.TabIndex = 3;
            this.buttonCategoryDelete.Text = "Delete";
            this.buttonCategoryDelete.UseVisualStyleBackColor = true;
            this.buttonCategoryDelete.Click += new System.EventHandler(this.buttonCategoryDelete_Click);
            // 
            // buttonCategoryEdit
            // 
            this.buttonCategoryEdit.Location = new System.Drawing.Point(268, 19);
            this.buttonCategoryEdit.Name = "buttonCategoryEdit";
            this.buttonCategoryEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonCategoryEdit.TabIndex = 2;
            this.buttonCategoryEdit.Text = "Edit";
            this.buttonCategoryEdit.UseVisualStyleBackColor = true;
            this.buttonCategoryEdit.Click += new System.EventHandler(this.buttonCategoryEdit_Click);
            // 
            // buttonCategoryAdd
            // 
            this.buttonCategoryAdd.Location = new System.Drawing.Point(187, 19);
            this.buttonCategoryAdd.Name = "buttonCategoryAdd";
            this.buttonCategoryAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonCategoryAdd.TabIndex = 1;
            this.buttonCategoryAdd.Text = "Add";
            this.buttonCategoryAdd.UseVisualStyleBackColor = true;
            this.buttonCategoryAdd.Click += new System.EventHandler(this.buttonCategoryAdd_Click);
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.buttonTypeDelete);
            this.groupBoxType.Controls.Add(this.comboBoxTypes);
            this.groupBoxType.Controls.Add(this.buttonTypeEdit);
            this.groupBoxType.Controls.Add(this.buttonTypeAdd);
            this.groupBoxType.Location = new System.Drawing.Point(13, 72);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(429, 53);
            this.groupBoxType.TabIndex = 4;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            // 
            // buttonTypeDelete
            // 
            this.buttonTypeDelete.Location = new System.Drawing.Point(349, 19);
            this.buttonTypeDelete.Name = "buttonTypeDelete";
            this.buttonTypeDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonTypeDelete.TabIndex = 3;
            this.buttonTypeDelete.Text = "Delete";
            this.buttonTypeDelete.UseVisualStyleBackColor = true;
            this.buttonTypeDelete.Click += new System.EventHandler(this.buttonTypeDelete_Click);
            // 
            // buttonTypeEdit
            // 
            this.buttonTypeEdit.Location = new System.Drawing.Point(268, 19);
            this.buttonTypeEdit.Name = "buttonTypeEdit";
            this.buttonTypeEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonTypeEdit.TabIndex = 2;
            this.buttonTypeEdit.Text = "Edit";
            this.buttonTypeEdit.UseVisualStyleBackColor = true;
            this.buttonTypeEdit.Click += new System.EventHandler(this.buttonTypeEdit_Click);
            // 
            // buttonTypeAdd
            // 
            this.buttonTypeAdd.Location = new System.Drawing.Point(187, 19);
            this.buttonTypeAdd.Name = "buttonTypeAdd";
            this.buttonTypeAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonTypeAdd.TabIndex = 1;
            this.buttonTypeAdd.Text = "Add";
            this.buttonTypeAdd.UseVisualStyleBackColor = true;
            this.buttonTypeAdd.Click += new System.EventHandler(this.buttonTypeAdd_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(362, 131);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CategoriesAndTypesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 163);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.groupBoxCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CategoriesAndTypesWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBoxCategory.ResumeLayout(false);
            this.groupBoxType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.GroupBox groupBoxCategory;
        private System.Windows.Forms.Button buttonCategoryDelete;
        private System.Windows.Forms.Button buttonCategoryEdit;
        private System.Windows.Forms.Button buttonCategoryAdd;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.Button buttonTypeDelete;
        private System.Windows.Forms.Button buttonTypeEdit;
        private System.Windows.Forms.Button buttonTypeAdd;
        private System.Windows.Forms.Button buttonClose;
    }
}