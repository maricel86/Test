using System;
using ILNumerics;


namespace GitProjectTest
{
    class Program
    {

        static void Main(string[] args)
        {
            //var identityMatrix = ILMath.eye(5, 5);
            //Console.WriteLine("Identity Matrix for 5 is :");
            //Console.WriteLine(identityMatrix);


            ILArray<double> matrix;
            using (var matRead = new ILMatFile(@"Data\data.mat"))
            {
                matrix = matRead.GetArray<double>(0);
            }

            //var form = new DisplayForm();
            //form.SetData(matrix.Concat(ILMath.zeros(matrix.Size[0], 1), 1).T,
            //             "Population of City in 10,000s",
            //             "Profit in $10,000s");


            //Application.Run(form);

            var m = matrix.Size[0];
            var x = ILMath.ones(m, 1).Concat(matrix[ILMath.full, 0], 1);
            var y = matrix[ILMath.full, 1];
            var theta = ILMath.zeros(2, 1);


            var hypothesis = ILMath.multiply(x, theta);
            var error = hypothesis - y;
            var squareError = ILMath.pow(error, ILMath.array((double)2));
            var cost = (1.0 / (2.0 * m)) * ILMath.sum(squareError);

            Console.WriteLine(cost);


            Console.ReadKey();

        }


    }
}
