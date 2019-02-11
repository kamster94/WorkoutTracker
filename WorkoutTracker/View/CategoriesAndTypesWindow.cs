using System;
using System.Windows.Forms;

namespace WorkoutTracker.View
{
    public partial class CategoriesAndTypesWindow : Form
    {
        private readonly Controller _controller;

        public CategoriesAndTypesWindow(object categories)
        {
            InitializeComponent();
            _controller = new Controller(this, categories);
            _controller.RefreshCategoriesAndTypes();
        }

        private void ComboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
