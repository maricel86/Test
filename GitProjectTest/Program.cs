using System;
using System.Windows.Forms;
using ILNumerics;


namespace GitProjectTest
{
    class Program
    {

        static void Main(string[] args)
        {
            // ==================== Part 1: Basic Function ====================
            Console.WriteLine("Running warmUpExercise ... ");
            Console.WriteLine("5x5 Identity Matrix: ");
            Console.WriteLine(WarmUpExercise());
            Console.WriteLine("Program paused. Press any key to continue.");
            Console.ReadKey();



            //======================= Part 2: Plotting =======================
            Console.WriteLine("Plotting Data ...");
            ILArray<double> matrix;
            using (var matRead = new ILMatFile(@"Data\data.mat"))
            {
                matrix = matRead.GetArray<double>(0);
            }

            Console.WriteLine("Program paused. close plot window to continue.");

            var x = matrix[ILMath.full, 0];
            var y = matrix[ILMath.full, 1];
            PlotData(x, y);


            //=================== Part 3: Gradient descent ===================
            Console.WriteLine("Running Gradient Descent ...");


            var m = matrix.Size[0];
            var theta = ILMath.zeros(2, 1);
            x = ILMath.ones(m, 1).Concat(matrix[ILMath.full, 0], 1);
            y = matrix[ILMath.full, 1];

            Console.WriteLine(ComputeCost(x, y, theta));

            double alpha = 0.01;
            int iterations = 1500;

            theta = ILMath.zeros(2, 1);
            x = ILMath.ones(m, 1).Concat(matrix[ILMath.full, 0], 1);
            y = matrix[ILMath.full, 1];
            theta = GradientDescent(x, y, theta, alpha, iterations);



            Console.WriteLine("Theta found by gradient descent: ");
            Console.WriteLine(string.Format("\n Theta(0)={0}, \n Theta(1)={1}", theta[0], theta[1]));


            x = ILMath.ones(m, 1).Concat(matrix[ILMath.full, 0], 1);
            y = ILMath.multiply(x, theta);

            //PlotData(matrix[ILMath.full, 0], y);

            Console.ReadKey();
        }



        public static ILArray<double> WarmUpExercise()
        {
            //============= YOUR CODE HERE ==============
            // Instructions: Return the 5x5 identity matrix 

            return ILMath.eye(5, 5);

            // ===========================================
        }


        public static void PlotData(ILArray<double> x, ILArray<double> y)
        {
            // ====================== YOUR CODE HERE ======================
            // Instructions: Plot the training to the screen.
            //               Set the axes labels. Assume the 
            //               population and revenue data have been passed in
            //               as the x and y arguments of this function.

            var count = x.Size[0];
            var vector = x.Concat(y, 1).Concat(ILMath.zeros(count, 1), 1);

            var form = new Display();
            form.SetData(vector.T, "Population of City in 10,000s", "Profit in $10,000s");
            Application.Run(form);
            // ===========================================
        }

        public static ILArray<double> ComputeCost(ILArray<double> x, ILArray<double> y, ILArray<double> theta)
        {
            //===================== YOUR CODE HERE ======================
            //Instructions: computes the cost using theta as the
            //              parameter for linear regression to fit the data points in x and y

            var count = x.Size[0];
            var hypothesis = ILMath.multiply(x, theta);
            var error = hypothesis - y;
            var squareError = ILMath.pow(error, ILMath.array((double)2));
            return (1.0 / (2.0 * count)) * ILMath.sum(squareError);

            // ===========================================
        }


        public static ILArray<double> GradientDescent(ILArray<double> x, ILArray<double> y, ILArray<double> theta, double alpha, int iterations)
        {
            // ====================== YOUR CODE HERE ======================
            // Instructions: Perform a single gradient step on the parameter vector
            //               theta. 
            //
            // Hint: While debugging, it can be useful to print out the values
            //       of the cost function (computeCost) and gradient here.
            //

            var count = x.Size[0];

            for (int i = 0; i < iterations; i++)
            {
                theta = theta - alpha * (1.0 / count) * (ILMath.multiply(x.T, (ILMath.multiply(x, theta) - y)));
            }

            return theta;

            //============================================================
        }
    }
}
