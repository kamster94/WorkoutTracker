using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkoutTracker.DataTransfer;

namespace WorkoutTracker.View
{
    public partial class CategoriesAndTypesWindow : Form
    {
        private Controller _controller;

        public CategoriesAndTypesWindow(List<CategoryDto> categories, MainWindow mainWindow)
        {
            InitializeComponent();
            _controller = new Controller(this, categories, mainWindow);
            _controller.RefreshCategoriesAndTypes();
        }

        private void ComboBoxCategories_SelectedIndexChanged(object sender,
            System.EventArgs e)
        {
            _controller.CategoriesIndexChanged();
        }

        private void buttonCategoryAdd_Click(object sender, EventArgs e)
        {
            _controller.AddCategory();
        }

        private void buttonCategoryEdit_Click(object sender, EventArgs e)
        {
            _controller.EditCategory();
        }

        private void buttonCategoryDelete_Click(object sender, EventArgs e)
        {
            _controller.DeleteCategory();
        }

        private void buttonTypeAdd_Click(object sender, EventArgs e)
        {
            _controller.AddType();
        }

        private void buttonTypeEdit_Click(object sender, EventArgs e)
        {
            _controller.EditType();
        }

        private void buttonTypeDelete_Click(object sender, EventArgs e)
        {
            _controller.DeleteType();
        }

        private void buttonSaveCategories_Click(object sender, EventArgs e)
        {
            _controller.SaveToFile();
        }

        private void buttonLoadCategories_Click(object sender, EventArgs e)
        {
            _controller.LoadFromFile();
            _controller.RefreshCategoriesAndTypes();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
