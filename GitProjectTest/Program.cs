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


namespace GitProjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                var mat = DenseMatrix.OfArray( CsvHelper.CsvToMatrix(@"Data\data.csv"));


                Console.WriteLine(mat.ToString(20,10));


                //var matrix = DenseMatrix.Identity(4);
                //Console.WriteLine(matrix);
                Console.ReadKey();
            }
        }

       
    }
}
