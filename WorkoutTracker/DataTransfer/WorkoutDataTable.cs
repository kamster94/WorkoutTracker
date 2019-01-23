using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkoutTracker.DataTransfer
{
    class WorkoutDataTable : DataTable
    {
        private readonly string _DateColumnName = "Date";

        public string DateColumnName
        {
            get
            {
                return _DateColumnName;
            }
        }

        public void FillWithDto(IList<DateDto> dates, IList<CategoryDto> categories)
        {
            this.Columns.Add(new DataColumn(_DateColumnName, typeof(string)));
            foreach (var category in categories)
            {
                foreach (var type in category.Types)
                {
                    this.Columns.Add(new DataColumn(type.Name, typeof(int)));
                }
            }
            
            foreach (var date in dates)
            {
                object[] values = new object[this.Columns.Count];
                values[0] = date.Date.ToShortDateString();
                for (int i = 1; i < this.Columns.Count; i++)
                {
                    values[i] = date.Workouts[i-1].Count;
                }

                this.Rows.Add(values);
            }
        }

        public IList<DateDto> RetrieveDto(DataGridViewRowCollection gridRows, IList<CategoryDto> categories)
        {
            var dates = new List<DateDto>();
            foreach (DataRow row in this.Rows)
            {
                var date = new DateDto();
                date.Date = DateTime.Parse(this.Rows[this.Rows.IndexOf(row)].Field<string>(this.Columns[0]));
                date.Workouts = new List<WorkoutDto>();
                foreach (DataColumn column in this.Columns)
                {
                    if (column.ColumnName == _DateColumnName) continue;
                    var workout = new WorkoutDto();
                    var count = this.Rows[this.Rows.IndexOf(row)].Field<int?>(this.Columns.IndexOf(column));
                    workout.Count = count != null ? (int) count : 0;
                    try
                    {
                        workout.CategoryId = categories.FirstOrDefault(x => x.Types.Any(a => a.Name == column.ColumnName)).Id;
                        workout.TypeId = categories.FirstOrDefault(x => x.Id == workout.CategoryId).Types
                            .FirstOrDefault(x => x.Name == column.ColumnName).Id;
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    date.Workouts.Add(workout);
                }
                dates.Add(date);
            }
            return dates;
        }
    }
}
