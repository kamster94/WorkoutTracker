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
            RefreshCategoriesAndTypes();
        }

        private void RefreshCategoriesAndTypes()
        {
            _categories = _categories.OrderBy(x => x.Order).ToList();
            var dataBinding = new BindingSource();
            dataBinding.DataSource = _categories;
            comboBoxCategories.DataSource = dataBinding;
            comboBoxCategories.DisplayMember = "Name";
        }

        private void ComboBoxCategories_SelectedIndexChanged(object sender,
            System.EventArgs e)
        {
            _categories[comboBoxCategories.SelectedIndex].Types = _categories[comboBoxCategories.SelectedIndex].Types
                .OrderBy(x => x.Order).ToList();
            var dataBinding = new BindingSource();
            dataBinding.DataSource = _categories[comboBoxCategories.SelectedIndex].Types;
            comboBoxTypes.DataSource = dataBinding;
            comboBoxTypes.DisplayMember = "Name";
        }

        private void buttonCategoryAdd_Click(object sender, EventArgs e)
        {
            var textBoxDialog = new TextBoxDialog(false);
            textBoxDialog.ShowDialog();
            var name = textBoxDialog.textBox.Text;
            textBoxDialog.Dispose();

            _categories.Add(new CategoryDto
            {
                Id = _categories.Count > 0 ? _categories.Max(x => x.Id) + 1 : 1,
                Name = name,
                Order = _categories.Count > 0 ? _categories.Count + 1 : 1,
                Types = new List<TypeDto>()
            });

            RefreshCategoriesAndTypes();
        }

        private void buttonCategoryEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxCategories.SelectedItem != null)
            {
                var textBoxDialog = new TextBoxDialog(true, _categories[comboBoxCategories.SelectedIndex].Order, _categories[comboBoxCategories.SelectedIndex].Name);
                textBoxDialog.numericId.Maximum = _categories.Count;
                textBoxDialog.ShowDialog();
                _categories[comboBoxCategories.SelectedIndex].Name = textBoxDialog.textBox.Text;
                var order = (int)textBoxDialog.numericId.Value;
                textBoxDialog.Dispose();

                if (order > _categories[comboBoxCategories.SelectedIndex].Order)
                {
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Order - 1; i <= order - 1; i++)
                    {
                        _categories[i].Order--;
                    }
                }

                else if (order < _categories[comboBoxCategories.SelectedIndex].Order)
                {
                    for (int i = order - 1; i < _categories[comboBoxCategories.SelectedIndex].Order - 1; i++)
                    {
                        _categories[i].Order++;
                    }
                }

                _categories[comboBoxCategories.SelectedIndex].Order = order;

                _categories = _categories.OrderBy(x => x.Order).ToList();
                RefreshCategoriesAndTypes();
            }
        }

        private void buttonCategoryDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxCategories.SelectedItem != null)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete " + _categories[comboBoxCategories.SelectedIndex].Name + "?",
                    "Confirm",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Order - 1; i < _categories.Count; i++)
                    {
                        _categories[i].Order--;
                    }

                    _categories.Remove(_categories[comboBoxCategories.SelectedIndex]);
                    RefreshCategoriesAndTypes();
                }
            }
        }

        private void buttonTypeAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxCategories.SelectedItem != null)
            {
                var textBoxDialog = new TextBoxDialog(false);
                textBoxDialog.ShowDialog();
                var name = textBoxDialog.textBox.Text;
                textBoxDialog.Dispose();
                var category = _categories[comboBoxCategories.SelectedIndex];
                var typeId = category.Types.Count > 0 ? category.Types.Max(x => x.Id) + 1 : 1;
                category.Types.Add(new TypeDto
                {
                    CategoryId = category.Id,
                    Id = typeId,
                    Order = category.Types.Count > 0 ? category.Types.Count + 1 : 1,
                    Name = name
                });
                RefreshCategoriesAndTypes();
            }
        }

        private void buttonTypeEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedItem != null)
            {
                var textBoxDialog = new TextBoxDialog(true, _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Order, _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Name);
                textBoxDialog.numericId.Maximum = _categories[comboBoxCategories.SelectedIndex].Types.Count;
                textBoxDialog.ShowDialog();
                _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Name = textBoxDialog.textBox.Text;
                var order = (int)textBoxDialog.numericId.Value;
                textBoxDialog.Dispose();

                if (order > _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Order)
                {
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Order - 1; i <= order - 1; i++)
                    {
                        _categories[comboBoxCategories.SelectedIndex].Types[i].Order--;
                    }
                }

                else if (order < _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Order)
                {
                    for (int i = order - 1; i < _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Order - 1; i++)
                    {
                        _categories[comboBoxCategories.SelectedIndex].Types[i].Order++;
                    }
                }

                _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Order = order;

                _categories[comboBoxCategories.SelectedIndex].Types = _categories[comboBoxCategories.SelectedIndex].Types.OrderBy(x => x.Order).ToList();
                RefreshCategoriesAndTypes();
            }
        }

        private void buttonTypeDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedItem != null)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete " + _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Name + "?",
                    "Confirm",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Order - 1; i < _categories[comboBoxCategories.SelectedIndex].Types.Count; i++)
                    {
                        _categories[i].Order--;
                    }

                    _categories[comboBoxCategories.SelectedIndex].Types.Remove(_categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex]);
                    RefreshCategoriesAndTypes();
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
