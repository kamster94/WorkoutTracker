using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.DataTransfer;

namespace WorkoutTracker.View
{
    public partial class CategoriesAndTypesWindow : Form
    {
        private List<CategoryDto> _categories;

        public CategoriesAndTypesWindow(ref List<CategoryDto> categories)
        {
            InitializeComponent();
            _categories = categories;
            var dataBinding = new BindingSource();
            dataBinding.DataSource = _categories;
            comboBoxCategories.DataSource = dataBinding;
            comboBoxCategories.DisplayMember = "Name";
        }

        private void ComboBoxCategories_SelectedIndexChanged(object sender,
            System.EventArgs e)
        {
            var dataBinding = new BindingSource();
            dataBinding.DataSource = _categories[comboBoxCategories.SelectedIndex].Types;
            comboBoxTypes.DataSource = dataBinding;
            comboBoxTypes.DisplayMember = "Name";

        }

        private void buttonCategoryAdd_Click(object sender, EventArgs e)
        {
            var textBoxDialog = new TextBoxDialog();
            textBoxDialog.ShowDialog();
            var name = textBoxDialog.textBox.Text;
            _categories.Add(new CategoryDto
            {
                Id = _categories.Count + 1,
                Name = name,
                Types = new List<TypeDto>()
            });
            _categories.OrderBy(x => x.Id);
        }

        private void buttonCategoryEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxCategories.SelectedItem != null)
            {
            }
        }

        private void buttonCategoryDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxCategories.SelectedItem != null)
            {
            }
        }

        private void buttonTypeAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxCategories.SelectedItem != null)
            {
                var textBoxDialog = new TextBoxDialog();
                textBoxDialog.ShowDialog();
                var name = textBoxDialog.textBox.Text;
                var category = _categories[comboBoxCategories.SelectedIndex];
                var typeId = category.Types.Count + 1;
                category.Types.Add(new TypeDto
                {
                    CategoryId = category.Id,
                    Id = typeId,
                    Name = name
                });
            }
        }

        private void buttonTypeEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedItem != null)
            {
            }
        }

        private void buttonTypeDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedItem != null)
            {
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
