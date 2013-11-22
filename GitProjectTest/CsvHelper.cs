using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitProjectTest
{
    public static class CsvHelper
    {
        public static double[,] CsvToMatrix(string fileName)
        {
            DataTable dt = DataTable.New.ReadCsv(fileName);

            int rows = dt.Rows.Count();
            int columns = dt.ColumnNames.Count();

            var matFlat = new double[rows * columns];

            var i = 0;
            foreach (var item in dt.Rows)
            {
                Array.ConvertAll(item.Values.ToArray(), double.Parse).CopyTo(matFlat, i * dt.ColumnNames.Count());
                i++;
            }

            double[,] ret = new double[rows, columns];
            Buffer.BlockCopy(matFlat, 0, ret, 0, matFlat.Length * sizeof(double));
            return ret;
        }
    }
}
