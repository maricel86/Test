using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Complex32;

namespace GitProjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var matrix = DenseMatrix.Identity(4);
                Console.WriteLine(matrix.ToString());
                Console.ReadKey();
            }
        }
    }
}
