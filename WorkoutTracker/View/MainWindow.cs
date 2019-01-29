using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.DataAccess;
using WorkoutTracker.DataTransfer;

namespace WorkoutTracker.View
{
    public partial class MainWindow : Form
    {
        public List<CategoryDto> Categories;

        public static List<TypeDto> Types;

        public List<WorkoutDto> Workouts;

        public List<DateDto> Dates;

        private BindingSource _bindingSource;

        private WorkoutDataTable _dataTable;

        public MainWindow()
        {
            InitializeComponent();
            //TestSetup();
            //Categories = new List<CategoryDto>();
            //Dates = new List<DateDto>();
        }

        private void TestSetup()
        {
            Categories = new List<CategoryDto>
            {
                new CategoryDto{ Id = 1, Name = "Squats",
                    Types = new List<TypeDto>{ new TypeDto{ Id = 1, CategoryId = 1, Name = "Half-squats" },
                        new TypeDto{ Id = 2, CategoryId = 1, Name = "Full-squats" } }},
                new CategoryDto{ Id = 2, Name = "Pushups",
                    Types = new List<TypeDto>{ new TypeDto{ Id = 1, CategoryId = 2, Name = "Normal Pushups" } }},
                new CategoryDto{ Id = 3, Name = "Bridges",
                    Types = new List<TypeDto>{ new TypeDto{ Id = 1, CategoryId = 3, Name = "Normal Bridges" } }}
            };

            Types = new List<TypeDto>
            {
                new TypeDto{ Id = 1, CategoryId = Categories.Find(x => x.Name == "Squats").Id, Name = "Half-squats" },
                new TypeDto{ Id = 2, CategoryId = Categories.Find(x => x.Name == "Squats").Id, Name = "Full-squats" },
                new TypeDto{ Id = 1, CategoryId = Categories.Find(x => x.Name == "Pushups").Id, Name = "Normal Pushups" },
                new TypeDto{ Id = 1, CategoryId = Categories.Find(x => x.Name == "Bridges").Id, Name = "Normal Bridges" }
            };

            Workouts = new List<WorkoutDto>
            {
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Half-squats").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Half-squats").Id, Count = 4 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Full-squats").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Full-squats").Id, Count = 2 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Pushups").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Normal Pushups").Id, Count = 0 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Bridges").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Normal Bridges").Id, Count = 0 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Half-squats").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Half-squats").Id, Count = 10 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Full-squats").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Full-squats").Id, Count = 2 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Pushups").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Normal Pushups").Id, Count = 0 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Bridges").CategoryId,
                    TypeId = Types.Find(x => x.Name == "Normal Bridges").Id, Count = 6 } 
            };

            Dates = new List<DateDto>
            {
                new DateDto{ Workouts = Workouts.GetRange(0,4), Date = DateTime.Today},
                new DateDto{ Workouts = Workouts.GetRange(4,4), Date = DateTime.Today.AddDays(-2)}
            };
        }

        public void SetupDataGridViewTable(List<DateDto> workoutDates)
        {
            ClearDataGridViewTable();
            foreach (var date in workoutDates)
            {
                date.Workouts = date.Workouts.OrderBy(x => x.CategoryId).ThenBy(x => x.TypeId).ToList();
            }
            _dataTable = new WorkoutDataTable();
            _dataTable.FillWithDto(workoutDates, Categories);

            _bindingSource = new BindingSource();

            dataGridView.DataSource = _bindingSource.DataSource = _dataTable;

            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersWidth = 100;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = row.Cells[0].Value;
            }

            dataGridView.Columns[0].Visible = false;
        }

        public void ClearDataGridViewTable()
        {
            dataGridView.DataSource = null;
            _dataTable = new WorkoutDataTable();
            _bindingSource = new BindingSource();
        }

        public void AddCategory(string name)
        {
            Categories.Add(new CategoryDto
            {
                Id = Categories.Count + 1,
                Name = name,
                Types = new List<TypeDto>()
            });
            Categories.OrderBy(x => x.Id);
        }

        public void AddType(string name, int categoryId)
        {
            var category = Categories.Find(x => x.Id == categoryId);
            var typeId = category.Types.Count + 1;
            category.Types.Add(new TypeDto
            {
                CategoryId = categoryId,
                Id = typeId,
                Name = name
            });
            foreach (var date in Dates)
            {
                date.Workouts.Add(new WorkoutDto
                {
                    CategoryId = categoryId,
                    TypeId = typeId,
                    Count = 0
                });
                date.Workouts = date.Workouts.OrderBy(x => x.CategoryId).ThenBy(x => x.TypeId).ToList();
            }

            foreach (var categoryScope in Categories)
            {
                categoryScope.Types.OrderBy(x => x.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDao xmlDao = new XmlDao();
            xmlDao.SerializeToFile("test45.xml", Dates);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDao xmlDao = new XmlDao();
            var result = Dates = xmlDao.DeserializeToObject<List<DateDto>>("test.xml");
            Categories = xmlDao.DeserializeToObject<List<CategoryDto>>("testcat.xml");
            SetupDataGridViewTable(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CsvDao csvDao = new CsvDao();
            csvDao.SerializeToFile("ttt.csv", _dataTable);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CsvDao csvDao = new CsvDao();
            _dataTable = new WorkoutDataTable();
            _dataTable = csvDao.DeserializeToObject<WorkoutDataTable>("ttt.csv");

            _bindingSource = new BindingSource();

            dataGridView.DataSource = _bindingSource.DataSource = _dataTable;

            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersWidth = 100;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dates = _dataTable.RetrieveDto(dataGridView.Rows, Categories).ToList();
        }

        private void dataGridView_CellClicked(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dataGridView.NewRowIndex)
            {
                var userEnteredDate = DateTime.MinValue;
                DatePickerDialog fmNewFormWithDateOnIt = new DatePickerDialog();
                fmNewFormWithDateOnIt.ShowDialog();
                userEnteredDate = fmNewFormWithDateOnIt.dateTimePicker.Value;
                dataGridView[0, e.RowIndex].Value = userEnteredDate.ToShortDateString();
                _bindingSource.EndEdit();
                dataGridView.NotifyCurrentCellDirty(true);
                dataGridView.EndEdit();
                dataGridView.NotifyCurrentCellDirty(false);
                dataGridView.CurrentRow.HeaderCell.Value = dataGridView[0, e.RowIndex].Value;
            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
            {
                if (oneCell.Selected)
                    dataGridView.Rows.RemoveAt(oneCell.RowIndex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var categoryWindow = new CategoriesAndTypesWindow(ref Categories);
            categoryWindow.ShowDialog();
        }
    }
}
