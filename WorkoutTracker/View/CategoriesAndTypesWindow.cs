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
            var textBoxDialog = new TextBoxDialog(false);
            textBoxDialog.ShowDialog();
            var name = textBoxDialog.textBox.Text;
            textBoxDialog.Dispose();

            _categories.Add(new CategoryDto
            {
                Id = _categories.Count + 1,
                Name = name,
                Types = new List<TypeDto>()
            });

            RefreshCategoriesAndTypes();
        }

        private void buttonCategoryEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxCategories.SelectedItem != null)
            {
                var textBoxDialog = new TextBoxDialog(true, _categories[comboBoxCategories.SelectedIndex].Id, _categories[comboBoxCategories.SelectedIndex].Name);
                textBoxDialog.numericId.Maximum = _categories.Count;
                textBoxDialog.ShowDialog();
                _categories[comboBoxCategories.SelectedIndex].Name = textBoxDialog.textBox.Text;
                var id = (int)textBoxDialog.numericId.Value;
                textBoxDialog.Dispose();

                if (id > _categories[comboBoxCategories.SelectedIndex].Id)
                {
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Id - 1; i <= id - 1; i++)
                    {
                        _categories[i].Id--;
                    }
                }

                else if (id < _categories[comboBoxCategories.SelectedIndex].Id)
                {
                    for (int i = id - 1; i < _categories[comboBoxCategories.SelectedIndex].Id - 1; i++)
                    {
                        _categories[i].Id++;
                    }
                }

                _categories[comboBoxCategories.SelectedIndex].Id = id;

                _categories = _categories.OrderBy(x => x.Id).ToList();
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
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Id - 1; i < _categories.Count; i++)
                    {
                        _categories[i].Id--;
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
                var typeId = category.Types.Count + 1;
                category.Types.Add(new TypeDto
                {
                    CategoryId = category.Id,
                    Id = typeId,
                    Name = name
                });
                RefreshCategoriesAndTypes();
            }
        }

        private void buttonTypeEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedItem != null)
            {
                var textBoxDialog = new TextBoxDialog(true, _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Id, _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Name);
                textBoxDialog.numericId.Maximum = _categories[comboBoxCategories.SelectedIndex].Types.Count;
                textBoxDialog.ShowDialog();
                _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Name = textBoxDialog.textBox.Text;
                var id = (int)textBoxDialog.numericId.Value;
                textBoxDialog.Dispose();

                if (id > _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Id)
                {
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Id - 1; i <= id - 1; i++)
                    {
                        _categories[comboBoxCategories.SelectedIndex].Types[i].Id--;
                    }
                }

                else if (id < _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Id)
                {
                    for (int i = id - 1; i < _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Id - 1; i++)
                    {
                        _categories[comboBoxCategories.SelectedIndex].Types[i].Id++;
                    }
                }

                _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Id = id;

                _categories[comboBoxCategories.SelectedIndex].Types = _categories[comboBoxCategories.SelectedIndex].Types.OrderBy(x => x.Id).ToList();
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
                    for (int i = _categories[comboBoxCategories.SelectedIndex].Types[comboBoxTypes.SelectedIndex].Id - 1; i < _categories[comboBoxCategories.SelectedIndex].Types.Count; i++)
                    {
                        _categories[i].Id--;
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
