using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitProjectTest
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }


        public void SetData(ILArray<double> data, string xAxis = "", string yAxis = "")
        {
            var scene = new ILScene();


            var plotCube = scene.Add(new ILPlotCube
            {
                // configure Axes 
                Axes =
                {
                    XAxis =
                    {
                        Label = { Text = xAxis },
                        LabelPosition = new Vector3(1, 1, 0),
                        LabelAnchor = new PointF(1, 0)
                    },
                    YAxis =
                    {
                        Label = { Text = yAxis },
                        LabelPosition = new Vector3(1, 1, 0),
                        LabelAnchor = new PointF(1, 0)
                    },
                },
                ScaleModes = { YAxisScale = AxisScale.Linear },
                Children =  {
	                        new ILPoints {  Positions = ILMath.tosingle(data) }
                }

            });

            panel.Scene = scene;

        }
    }
}
