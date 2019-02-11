using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.DataAccess;
using WorkoutTracker.DataTransfer;

namespace WorkoutTracker.View
{
    public partial class MainWindow
    {
        internal class Controller
        {
            private readonly MainWindow _parent;

            private List<CategoryDto> _categories;

            private List<DateDto> _dates;

            private WorkoutDataTable _dataTable;

            private BindingSource _bindingSource;

            private DataGridView _dataGridView;

            private readonly DataGridViewColumnSelector _columnSelector;

            internal Controller(MainWindow parent)
            {
                _parent = parent;
                _categories = new List<CategoryDto>();
                _dates = new List<DateDto>();
                _dataGridView = _parent.dataGridView;
                _dataTable = new WorkoutDataTable();
                _columnSelector = new DataGridViewColumnSelector(_dataTable.DateColumnName, _parent.dataGridView);
                EraseDataTable();
                LoadCategoriesFromFile();
            }

            internal bool IsDataCorrect()
            {
                foreach (var date in _dates)
                {
                    foreach (var workout in date.Workouts)
                    {
                        try
                        {
                            _categories.Find(x => x.Id == workout.CategoryId).Types.Find(y => y.Id == workout.TypeId).ToString();
                        }
                        catch (NullReferenceException e)
                        {
                            MessageBox.Show($"Error, invalid category {workout.CategoryId} or type {workout.TypeId}");
                            _dates = new List<DateDto>();
                            return false;
                        }
                    }
                }
                return true;
            }

            internal void FillDataTable()
            {
                foreach (var date in _dates)
                {
                    date.Workouts = date.Workouts.OrderBy(x => _categories.Find(y => y.Id == x.CategoryId).Order)
                        .ThenBy(x => _categories.Find(y => y.Id == x.CategoryId).Types.Find(a => a.Id == x.TypeId).Order).ToList();
                }
                _dataTable = new WorkoutDataTable();
                _dataTable.FillWithDto(_dates, _categories);

                _bindingSource = new BindingSource();

                _dataGridView.DataSource = _bindingSource.DataSource = _dataTable;

                SetRowHeaders();
            }

            internal void SetRowHeaders()
            {
                _dataGridView.RowHeadersVisible = true;
                _dataGridView.RowHeadersWidth = 100;

                foreach (DataGridViewRow row in _dataGridView.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = row.Cells[0].Value;
                }

                _dataGridView.Columns[0].Visible = false;
            }

            internal void EraseDataTable()
            {
                _parent.dataGridView.DataSource = null;
                _dataTable = new WorkoutDataTable();
                _bindingSource = new BindingSource();
            }

            internal void TryUpdateDates()
            {
                foreach (var date in _dates)
                {
                    foreach (var category in _categories)
                    {
                        foreach (var type in category.Types)
                        {
                            var check = date.Workouts.Find(x => x.CategoryId == category.Id && x.TypeId == type.Id);
                            if (check == null)
                            {
                                date.Workouts.Add(new WorkoutDto
                                {
                                    CategoryId = category.Id,
                                    TypeId = type.Id,
                                    Count = 0
                                });
                            }
                        }
                    }

                    foreach (var workout in date.Workouts.ToList())
                    {
                        var check = _categories.Find(x => x.Id == workout.CategoryId);
                        if (check == null)
                        {
                            date.Workouts.Remove(workout);
                        }

                        foreach (var category in _categories)
                        {
                            var check2 = category.Types.Find(x => x.Id == workout.TypeId);
                            if (category.Id == workout.CategoryId && check2 == null)
                            {
                                date.Workouts.Remove(workout);
                            }
                        }
                    }
                }
            }

            internal void SaveDataToFile()
            {
                IBaseDao dao;
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "XML|*.xml|CSV|*.csv",
                    Title = "Save numeric data"
                };
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            dao = new XmlDao();
                            dao.SerializeToFile(saveFileDialog.FileName, _dates);
                            break;

                        case 2:
                            dao = new CsvDao();
                            dao.SerializeToFile(saveFileDialog.FileName, _dataTable);
                            break;
                    }
                }
            }

            internal void LoadDataFromFile()
            {
                IBaseDao dao;
                _dataTable = new WorkoutDataTable();

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "XML|*.xml|CSV|*.csv",
                    Title = "Select data file"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (openFileDialog.FilterIndex)
                    {
                        case 1:
                            dao = new XmlDao();
                            _dates = dao.DeserializeToObject<List<DateDto>>(openFileDialog.FileName);
                            EraseDataTable();
                            if (IsDataCorrect())
                            {
                                FillDataTable();
                            }
                            break;

                        case 2:
                            dao = new CsvDao();
                            _dataTable = dao.DeserializeToObject<WorkoutDataTable>(openFileDialog.FileName);
                            _bindingSource = new BindingSource();
                            _dates = new List<DateDto>();
                            UpdateDatesFromDataTable();
                            if (_dates.Count != 0)
                            {
                                _parent.dataGridView.DataSource = _bindingSource.DataSource = _dataTable;
                                _dataGridView.RowHeadersVisible = true;
                                _dataGridView.RowHeadersWidth = 100;
                            }
                            else _dates = new List<DateDto>();
                            
                            break;
                    }
                }
            }

            internal void AddNewRowInline(DataGridViewCellCancelEventArgs e)
            {
                var userEnteredDate = DateTime.MinValue;
                DatePickerDialog datePickerDialog = new DatePickerDialog();
                datePickerDialog.ShowDialog();
                userEnteredDate = datePickerDialog.dateTimePicker.Value;
                datePickerDialog.Dispose();
                for (int i= 0; i < _dataGridView.ColumnCount; i++)
                {
                    _dataGridView[i, e.RowIndex].Value = 0;
                }
                _dataGridView[0, e.RowIndex].Value = userEnteredDate.ToShortDateString();
                _bindingSource.EndEdit();
                _dataGridView.NotifyCurrentCellDirty(true);
                _dataGridView.EndEdit();
                _dataGridView.NotifyCurrentCellDirty(false);
                _dataGridView.CurrentRow.HeaderCell.Value = _dataGridView[0, e.RowIndex].Value;
            }

            internal void ShowCategoriesEditWindow()
            {
                var categoryWindow = new CategoriesAndTypesWindow(_categories);
                categoryWindow.ShowDialog();
                categoryWindow.Dispose();
                EraseDataTable();
                if (IsDataCorrect())
                {
                    TryUpdateDates();
                    FillDataTable();
                }
            }

            internal void UpdateDatesFromDataTable()
            {
                try
                {
                    _dates = _dataTable.RetrieveDto(_dataGridView.Rows, _categories).ToList();
                }
                catch (Exception e)
                {

                }
            }

            internal void SaveCategoriesToFile()
            {
                XmlDao dao = new XmlDao();
                dao.SerializeToFile("categories.xml", _categories);
            }

            internal void LoadCategoriesFromFile()
            {
                XmlDao dao = new XmlDao();
                _categories = dao.DeserializeToObject<List<CategoryDto>>("categories.xml");
                if (_categories != null) FillDataTable();
                else _categories = new List<CategoryDto>();
            }
        }
    }
}
