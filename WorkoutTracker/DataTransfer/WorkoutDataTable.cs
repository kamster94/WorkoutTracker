using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkoutTracker.DataTransfer
{
    class WorkoutDataTable : DataTable
    {
        public void SetUsingDto(IList<DateDto> dates, IList<TypeDto> types)
        {
            foreach (var type in types)
            {
                this.Columns.Add(new DataColumn(type.Name, typeof(int)));
            }

            foreach (var date in dates)
            {
                object[] values = new object[this.Columns.Count];
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    values[i] = date.Workouts[i].Count;
                }

                this.Rows.Add(values);
            }
        }

        public IList<DateDto> RetrieveDto(DataGridViewRowCollection gridRows, IList<TypeDto> types)
        {
            var dates = new List<DateDto>();
            foreach (DataRow row in this.Rows)
            {
                var date = new DateDto();
                date.Date = DateTime.Parse(gridRows[this.Rows.IndexOf(row)].HeaderCell.Value.ToString());
                date.Workouts = new List<WorkoutDto>();
                foreach (DataColumn column in this.Columns)
                {
                    var workout = new WorkoutDto();
                    workout.Count = this.Rows[this.Rows.IndexOf(row)].Field<int>(this.Columns.IndexOf(column));
                    try
                    {
                        workout.TypeId = types.FirstOrDefault(x => x.Name == column.ColumnName).Id;
                        workout.CategoryId = types.FirstOrDefault(x => x.Name == column.ColumnName).Category.Id;
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
