using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimmWebsite.DataAccess.Utils
{
    public class DalUtil
    {
        public static List<string> GetColumns<T>(List<string> excludeColumns = null)
        {
            var columns = new List<string>();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                columns.Add(property.Name);
            }

            if (excludeColumns != null)
            {
                columns = columns.Except(excludeColumns).ToList();
            }

            return columns;
        }

        public static string GetSqlParameterString(List<string> columns)
        {
            string sqlParameterString = $"@{string.Join(", @", columns)}";
            return sqlParameterString;
        }

        public static string GetSqlParameterPairs(List<string> columns)
        {
            string sqlParameterPairs = $"@{string.Join(",", columns.Select(x => $"{x} = @{x}"))}";
            return sqlParameterPairs;
        }

        public static DataTable ConvertToDataTable<T>(List<T> listData)
        {
            var dataTable = new DataTable();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name);
            }

            foreach (var data in listData)
            {
                var dataRow = dataTable.NewRow();
                foreach(var property in properties)
                {
                    dataRow[property.Name] = data;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
