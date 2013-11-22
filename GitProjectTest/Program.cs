using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;


namespace GitProjectTest
{
    class Program
    {

        static void Main(string[] args)
        {
            var identityMatrix = ILMath.eye(5, 5);
            Console.WriteLine("Identity Matrix for 5 is :");
            Console.WriteLine(identityMatrix);
            

            ILArray<double> matrix;
            using (var matRead = new ILMatFile(@"Data\data.mat"))
            {
                matrix = matRead.GetArray<double>(0);
            }
            
            var form = new DisplayForm();
            form.SetData(matrix.Concat(ILMath.zeros(matrix.Size[0], 1), 1).T);
            
            Application.Run(form); 

            Console.ReadKey();

        }


    }
}
