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

            chart1.Series[0].IsVisibleInLegend = false;





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





            for (int j = 0; j < numberOfSupplyPoints; j++)
            {

                chart1.Series.Add(supplyPointNames[j]);
                Console.WriteLine(supplyPointNames[j]);
                chart1.Series[supplyPointNames[j]].ChartType = SeriesChartType.Line;
                

                for (int i = 0; i < customerpointCount; i++)
                {
                    points.Add(new PointF(R.Next(-100, 500), R.Next(-100, 500)));

                }

                for (int i = 0; i < lineCount; i++)
                {
                    lines.Add(i);
                }
                Console.WriteLine(supplyPoints[j].X);


                foreach (int ln in lines)
                {
                    chart1.Series[supplyPointNames[j]].Points.AddXY(supplyPoints[j].X, supplyPoints[j].Y);
                    chart1.Series[supplyPointNames[j]].Points.AddXY(points[ln].X, points[ln].Y);
                    Console.WriteLine("Connected Point:" + points[ln]);
                    //chart1.Series[supplyPointNames[j]].Color = Color.Transparent;
                    chart1.Series[supplyPointNames[j]].Color = supplyPointColours[j];
             
                }

                points = new List<PointF>();  
                lines = new List<int>();

            }
        }
    }
}