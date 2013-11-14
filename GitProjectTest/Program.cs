using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;
using MathNet.Numerics.LinearAlgebra.Double.IO;
using System.IO;
using MathNet.Numerics.LinearAlgebra.IO;
using DataAccess;


namespace GitProjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            {



                DataTable dt = DataTable.New.ReadCsv(@"ata.csv");

                var mat = new DenseMatrix(dt.Rows.Count(), dt.ColumnNames.Count());




                foreach (var item in dt.Rows)
                {
                    //var row = item.Values.ToArray<double>();
                }






                var matrix = DenseMatrix.Identity(4);
                Console.WriteLine(matrix);
                Console.ReadKey();
            }
        }
    }
}
