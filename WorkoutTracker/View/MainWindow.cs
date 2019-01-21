using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkoutTracker.DataAccess;
using WorkoutTracker.DataTransfer;

namespace WorkoutTracker.View
{
    public partial class MainWindow : Form
    {
        public List<CategoryDto> Categories;

        public List<TypeDto> Types;

        public List<WorkoutDto> Workouts;

        public List<DateDto> Dates;

        private BindingSource _bindingSource;

        private WorkoutDataTable _dataTable;

        public MainWindow()
        {
            InitializeComponent();
            TestSetup();
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
            var _dataTable = new WorkoutDataTable();
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

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDao xmlDao = new XmlDao();
            xmlDao.SerializeToFile("test.xml", Dates);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDao xmlDao = new XmlDao();
            var result = xmlDao.DeserializeToObject<List<DateDto>>("test.xml");

            SetupDataGridViewTable(result);
        }
    }
}
