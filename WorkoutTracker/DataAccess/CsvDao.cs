using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkoutTracker.DataAccess
{
    class CsvDao : IBaseDao
    {
        public T DeserializeToObject<T>(string path)
        {
            throw new NotImplementedException();
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
