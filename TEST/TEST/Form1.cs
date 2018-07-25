using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = "COM4";
            chart1.ChartAreas[0].AxisY.Maximum = 200;
            chart1.ChartAreas[0].AxisY.Minimum = 60;
        }
        int num = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddY(num);
            num++;
            serialPort1.Open();
            timer1.Start();
        }
        int data = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            string inputs = serialPort1.ReadLine();
            label1.Text = inputs;
            try
            {
                data = Convert.ToInt32(inputs);
            }
            catch
            {
                data = 0;
            }
            
            chart1.Series[0].Points.AddY(data);
            if(chart1.Series[0].Points.Count > 500)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = chart1.Series[0].Points.Count - 500;
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 500;
            }
        }
    }
}
