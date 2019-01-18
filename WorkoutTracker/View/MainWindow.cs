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

            //var _dataTable = new WorkoutDataTable();
            //_dataTable.SetUsingDto(Dates, Types);

            //_bindingSource = new BindingSource();

            //dataGridView.DataSource = _bindingSource.DataSource = _dataTable;

            //dataGridView.RowHeadersVisible = true;
            //dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            //foreach (DataGridViewRow row in dataGridView.Rows)
            //{
            //    if (row.IsNewRow) continue;
            //    row.HeaderCell.Value = Dates[row.Index].Date.ToShortDateString();
            //}
        }

        private void TestSetup()
        {
            Categories = new List<CategoryDto>
            {
                new CategoryDto{ Id = 1, Name = "Squats"},
                new CategoryDto{ Id = 2, Name = "Pushups"},
                new CategoryDto{ Id = 3, Name = "Bridges"}
            };

            Types = new List<TypeDto>
            {
                new TypeDto{ Id = 1, Category = Categories.Find(x => x.Name == "Squats"), Name = "Half-squats" },
                new TypeDto{ Id = 2, Category = Categories.Find(x => x.Name == "Squats"), Name = "Full-squats" },
                new TypeDto{ Id = 1, Category = Categories.Find(x => x.Name == "Pushups"), Name = "Normal Pushups" },
                new TypeDto{ Id = 1, Category = Categories.Find(x => x.Name == "Bridges"), Name = "Normal Bridges" }
            };

            Workouts = new List<WorkoutDto>
            {
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Half-squats").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Half-squats").Id, Count = 4 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Full-squats").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Full-squats").Id, Count = 2 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Pushups").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Normal Pushups").Id, Count = 0 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Bridges").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Normal Bridges").Id, Count = 0 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Half-squats").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Half-squats").Id, Count = 10 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Full-squats").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Full-squats").Id, Count = 2 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Pushups").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Normal Pushups").Id, Count = 0 },
                new WorkoutDto{ CategoryId = Types.Find(x => x.Name == "Normal Bridges").Category.Id,
                    TypeId = Types.Find(x => x.Name == "Normal Bridges").Id, Count = 6 } 
            };

            Dates = new List<DateDto>
            {
                new DateDto{ Workouts = Workouts.GetRange(0,4), Date = DateTime.Today},
                new DateDto{ Workouts = Workouts.GetRange(4,4), Date = DateTime.Today.AddDays(-2)}
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDao xmlDao = new XmlDao();
            xmlDao.SerializeToFile<List<DateDto>>("tezd.xml", Dates);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDao xmlDao = new XmlDao();
            var result = xmlDao.DeserializeToObject<List<DateDto>>("tezd.xml");

            var _dataTable = new WorkoutDataTable();
            _dataTable.SetUsingDto(result, Types);

            _bindingSource = new BindingSource();

            dataGridView.DataSource = _bindingSource.DataSource = _dataTable;
        }
    }
}
