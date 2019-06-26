using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
/**
* https://www.youtube.com/watch?v=KcVVvU6bqt0
* https://www.youtube.com/watch?v=_RfkR8RNMP4
* @author Juan Diego Alosilla
* @email diegoalosillagmail.com
*/
namespace NUnit.TestsSelenium.Data
{
    public class Excel
    {
        public static DataTable excelToDataTable(string filename)
        {

            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //excelDataReader.IsFirstRowAsColumnNames = true;

             DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table["MyTable"];
            
            return resultTable;
        }

        public class dataCollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        static List<dataCollection> dataCol = new List<dataCollection>();

        static int totalRowCount = 0;
        public static int getTotalRowCount() { return totalRowCount; }

        public static void populateInCollection(string filename)
        {
            DataTable table = excelToDataTable(filename);
            totalRowCount = table.Rows.Count;
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count;col++)
                {
                    dataCollection dtTable = new dataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch(Exception e)
            {
                return null;
            }
        }



    }
}
