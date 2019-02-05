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

            internal Controller(MainWindow parent)
            {
                _parent = parent;
                _categories = new List<CategoryDto>();
                _dates = new List<DateDto>();
                _dataGridView = _parent.dataGridView;
                EraseDataTable();
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
                            FillDataTable();
                            break;

                        case 2:
                            dao = new CsvDao();
                            _dataTable = dao.DeserializeToObject<WorkoutDataTable>(openFileDialog.FileName);
                            _bindingSource = new BindingSource();

                            _parent.dataGridView.DataSource = _bindingSource.DataSource = _dataTable;

                            _dataGridView.RowHeadersVisible = true;
                            _dataGridView.RowHeadersWidth = 100;
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
                _dataGridView[0, e.RowIndex].Value = userEnteredDate.ToShortDateString();
                _bindingSource.EndEdit();
                _dataGridView.NotifyCurrentCellDirty(true);
                _dataGridView.EndEdit();
                _dataGridView.NotifyCurrentCellDirty(false);
                _dataGridView.CurrentRow.HeaderCell.Value = _dataGridView[0, e.RowIndex].Value;
            }

            internal void ShowCategoriesEditWindow()
            {
                var categoryWindow = new CategoriesAndTypesWindow(_categories, _parent);
                categoryWindow.ShowDialog();
                categoryWindow.Dispose();
                EraseDataTable();
                TryUpdateDates();
                FillDataTable();
            }

            internal void UpdateDatesFromDataTable()
            {
                _dates = _dataTable.RetrieveDto(_dataGridView.Rows, _categories).ToList();
            }

            internal void DoUpdateReferenes(object categories)
            {
                _categories = (List<CategoryDto>)categories;
            }
        }
    }
}
