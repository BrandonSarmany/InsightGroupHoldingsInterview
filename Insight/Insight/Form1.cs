using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Insight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ChartLoad();
        }

        void ChartLoad()
        {
            var chart = chart1.ChartAreas[0];

            chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisX.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = -100;
            chart.AxisY.Minimum = -100;

            chart.AxisX.Maximum = 500;
            chart.AxisY.Maximum = 500;

            chart.AxisX.Interval = 50;
            chart.AxisY.Interval = 50;

            label1.Text = "Enter X Coordiante";
            label2.Text = "Enter Y Coordiante";
           

            





            Random R = new Random();  

            List<PointF> points = new List<PointF>();  


            int customerpointCount = 20;
            int lineCount = 20;
            int numberOfSupplyPoints = 5;

            List<int> lines = new List<int>();

            string[] supplyPointNames = new string[] { "Line1", "Line2", "Line3", "Line4", "Line5" };
            Color[] supplyPointColours = new Color[] { Color.Red, Color.Blue, Color.Purple, Color.Yellow, Color.Green };
            List<PointF> supplyPoints = new List<PointF>();
            supplyPoints.Add(new Point(40, 200));
            supplyPoints.Add(new Point(90, 250));
            supplyPoints.Add(new Point(325, 345));
            supplyPoints.Add(new Point(450, 50));
            supplyPoints.Add(new Point(460, 410));
            chart1.Series["Series1"].MarkerSize = 4;
            chart1.Series["Series1"].MarkerColor = Color.Blue;
            chart1.Series["Series1"].Color = Color.Blue;




            double x1;
            double y1;
            double x2;
            double y2;
            for (int j = 0; j < numberOfSupplyPoints; j++)
            {

                chart1.Series.Add(supplyPointNames[j]);
                Console.WriteLine(supplyPointNames[j]);
                chart1.Series[supplyPointNames[j]].ChartType = SeriesChartType.Line;
                chart1.Series["Series1"].Color = Color.Red;


                for (int i = 0; i < customerpointCount; i++)
                {
                    points.Add(new PointF(R.Next(-100, 500), R.Next(-100, 500)));

                }

                for (int i = 0; i < lineCount; i++)
                {
                    lines.Add(i);
                }
               


                foreach (int ln in lines)
                {
                    
                    chart1.Series[supplyPointNames[j]].Points.AddXY(supplyPoints[j].X, supplyPoints[j].Y);
                    chart1.Series[supplyPointNames[j]].Points.AddXY(points[ln].X, points[ln].Y);
                    Console.WriteLine("Connected Point: " + points[ln]);
                    Console.WriteLine("Supply Points X " + supplyPoints[j].X + " Supply Points Y " + supplyPoints[j].Y);
                    chart1.Series[supplyPointNames[j]].Color = supplyPointColours[j];


                     x1 = points[ln].X;
                     y1 = points[ln].Y;
                     x2 = supplyPoints[j].X;
                     y2 = supplyPoints[j].Y;
   
                    // I am stuck after this point. This is only calculating the distance from the specific supply point that its attached to,
                    // I am not sure how to get the distance from that point and all the other supply points to compare them, possibly another 
                    // for loop which will have the above code in it.
                    var distance = DistanceCalc(x1, y1, x2, y2);
                    Console.WriteLine("Distance = " + distance);

                   

                }

                points = new List<PointF>();  
                lines = new List<int>();
            }
            
        }
        /*This is the function that i believe works in order to get the distance from one point to its supply point */
        private static double DistanceCalc(double x1, double y1, double x2, double y2)
        {
            var temp = Math.Pow((x2 - x1), 2);
            var temp2 = Math.Pow((y2 - y1), 2);
            var distance = Math.Sqrt(temp + temp2);

            return distance;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        /*I got the button to take the values from the text box and turn it into a point on the graph, 
         * but I was unable to figure out how to implement this into the main method to draw a line to a supply point */ 
        public void button1_Click(object sender, EventArgs e)
        {
          
            double x;
            double y;

            bool xval = double.TryParse(textBox1.Text, out x);
            bool yval = double.TryParse(textBox2.Text, out y);

            if (xval && yval)
                chart1.Series["Series1"].Points.AddXY(x, y);
            else 

                MessageBox.Show("Input not accepted, Please Enter a number");
        }
       
    }
}