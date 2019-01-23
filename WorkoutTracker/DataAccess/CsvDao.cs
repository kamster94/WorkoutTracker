using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using WorkoutTracker.DataTransfer;

namespace WorkoutTracker.DataAccess
{
    class CsvDao : IBaseDao
    {
        public T DeserializeToObject<T>(string path)
        {
            var dataTable = new WorkoutDataTable();

            using (StreamReader streamReader = new StreamReader(path))
            {
                string[] headers = streamReader.ReadLine().Split(';');

                foreach (string header in headers)
                {
                    if (header == dataTable.DateColumnName) dataTable.Columns.Add(new DataColumn(header, typeof(string)));
                    else dataTable.Columns.Add(new DataColumn(header, typeof(int)));
                }

                while (!streamReader.EndOfStream)
                {
                    string[] rows = streamReader.ReadLine().Split(';');

                    DataRow row = dataTable.NewRow();

                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (i == 0) row[i] = rows[i];
                        else row[i] = int.Parse(rows[i]);
                    }

                    dataTable.Rows.Add(row);
                }
            }
            return (dynamic)dataTable;
        }

        public void SerializeToFile<T>(string path, T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable = obj as DataTable;

            IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().
                Select(column => column.ColumnName);
            stringBuilder.AppendLine(string.Join(";", columnNames));

            foreach (DataRow row in dataTable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                stringBuilder.AppendLine(string.Join(";", fields));
            }

            try
            {
                File.WriteAllText(path, stringBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
