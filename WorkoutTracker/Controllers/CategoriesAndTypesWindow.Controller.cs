using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.DataAccess;
using WorkoutTracker.DataTransfer;

namespace WorkoutTracker.View
{
    public partial class CategoriesAndTypesWindow
    {
        internal class Controller
        {
            private readonly CategoriesAndTypesWindow _parent;

            private readonly ComboBox _comboBoxCategories;

            private readonly ComboBox _comboBoxTypes;

            private List<CategoryDto> _categories;

            private readonly MainWindow _mainWindow;

            internal Controller(CategoriesAndTypesWindow parent, object categories, MainWindow mainWindow)
            {
                _parent = parent;
                _mainWindow = mainWindow;
                _comboBoxCategories = _parent.comboBoxCategories;
                _comboBoxTypes = _parent.comboBoxTypes;
                _categories = (List<CategoryDto>)categories;
            }

            internal void RefreshCategoriesAndTypes()
            {
                _categories.Sort((x, y) => x.Order.CompareTo(y.Order));
                var dataBinding = new BindingSource();
                dataBinding.DataSource = _categories;
                _comboBoxCategories.DataSource = dataBinding;
                _comboBoxCategories.DisplayMember = "Name";
            }

            internal void CategoriesIndexChanged()
            {
                _categories[_comboBoxCategories.SelectedIndex].Types.Sort((x, y) => x.Order.CompareTo(y.Order));
                var dataBinding = new BindingSource();
                dataBinding.DataSource = _categories[_comboBoxCategories.SelectedIndex].Types;
                _comboBoxTypes.DataSource = dataBinding;
                _comboBoxTypes.DisplayMember = "Name";
            }

            internal void AddCategory()
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

            internal void EditCategory()
            {
                if (_comboBoxCategories.SelectedItem != null)
                {
                    var textBoxDialog = new TextBoxDialog(true, _categories[_comboBoxCategories.SelectedIndex].Order, _categories[_comboBoxCategories.SelectedIndex].Name);
                    textBoxDialog.numericId.Maximum = _categories.Count;
                    textBoxDialog.ShowDialog();
                    _categories[_comboBoxCategories.SelectedIndex].Name = textBoxDialog.textBox.Text;
                    var order = (int)textBoxDialog.numericId.Value;
                    textBoxDialog.Dispose();

                    if (order > _categories[_comboBoxCategories.SelectedIndex].Order)
                    {
                        for (int i = _categories[_comboBoxCategories.SelectedIndex].Order - 1; i <= order - 1; i++)
                        {
                            _categories[i].Order--;
                        }
                    }

                    else if (order < _categories[_comboBoxCategories.SelectedIndex].Order)
                    {
                        for (int i = order - 1; i < _categories[_comboBoxCategories.SelectedIndex].Order - 1; i++)
                        {
                            _categories[i].Order++;
                        }
                    }

                    _categories[_comboBoxCategories.SelectedIndex].Order = order;

                    RefreshCategoriesAndTypes();
                }
            }

            internal void DeleteCategory()
            {
                if (_comboBoxCategories.SelectedItem != null)
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to delete " + _categories[_comboBoxCategories.SelectedIndex].Name + "?",
                        "Confirm",
                        MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        for (int i = _categories[_comboBoxCategories.SelectedIndex].Order - 1; i < _categories.Count; i++)
                        {
                            _categories[i].Order--;
                        }

                        _categories.Remove(_categories[_comboBoxCategories.SelectedIndex]);

                        RefreshCategoriesAndTypes();
                    }
                }
            }

            internal void AddType()
            {
                if (_comboBoxCategories.SelectedItem != null)
                {
                    var textBoxDialog = new TextBoxDialog(false);
                    textBoxDialog.ShowDialog();
                    var name = textBoxDialog.textBox.Text;
                    textBoxDialog.Dispose();
                    var category = _categories[_comboBoxCategories.SelectedIndex];
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

            internal void EditType()
            {
                if (_comboBoxTypes.SelectedItem != null)
                {
                    var textBoxDialog = new TextBoxDialog(true, _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Order, _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Name);
                    textBoxDialog.numericId.Maximum = _categories[_comboBoxCategories.SelectedIndex].Types.Count;
                    textBoxDialog.ShowDialog();
                    _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Name = textBoxDialog.textBox.Text;
                    var order = (int)textBoxDialog.numericId.Value;
                    textBoxDialog.Dispose();

                    if (order > _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Order)
                    {
                        for (int i = _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Order - 1; i <= order - 1; i++)
                        {
                            _categories[_comboBoxCategories.SelectedIndex].Types[i].Order--;
                        }
                    }

                    else if (order < _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Order)
                    {
                        for (int i = order - 1; i < _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Order - 1; i++)
                        {
                            _categories[_comboBoxCategories.SelectedIndex].Types[i].Order++;
                        }
                    }

                    _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Order = order;

                    RefreshCategoriesAndTypes();
                }
            }

            internal void DeleteType()
            {
                if (_comboBoxTypes.SelectedItem != null)
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to delete " + _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Name + "?",
                        "Confirm",
                        MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        for (int i = _categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex].Order - 1; i < _categories[_comboBoxCategories.SelectedIndex].Types.Count - 1; i++)
                        {
                            _categories[i].Order--;
                        }

                        _categories[_comboBoxCategories.SelectedIndex].Types.Remove(_categories[_comboBoxCategories.SelectedIndex].Types[_comboBoxTypes.SelectedIndex]);

                        RefreshCategoriesAndTypes();
                    }
                }
            }

            internal void SaveToFile()
            {
                XmlDao dao = new XmlDao();
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "XML|*.xml",
                    Title = "Save categories and types"
                };
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    dao.SerializeToFile(saveFileDialog.FileName, _categories);
                }
            }

            internal void LoadFromFile()
            {
                XmlDao dao = new XmlDao();

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "XML|*.xml",
                    Title = "Select categories and types file"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _categories = dao.DeserializeToObject<List<CategoryDto>>(openFileDialog.FileName);
                    _mainWindow.UpdateCategoriesReference(_categories);
                }
            }
        }
    }
}
