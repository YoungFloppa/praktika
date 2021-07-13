
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;*/

namespace ConsoleAppTest
{
   public class Program
    {
        static void Main(string[] args)
        {
            

           
            SerialPort serialPort = new SerialPort("COM8", 9600, Parity.None);
            serialPort.Open();
            serialPort.DataReceived += serialPort_DataReceived;

            Console.ReadKey();

        }
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string vlag = SerialPort.ReadLine(sender);
            this.BeginInvoke(new LineReceivedEvent(LineReceived), vlag);
        }

        private void serialPort_DataReceived1(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string temp = SerialPort.ReadLine(sender);
            this.BeginInvoke(new LineReceivedEvent1(LineReceived1), temp);
        }

        //запись влажности
        private delegate void LineReceivedEvent(string vlag);
        private void LineReceived(string vlag)
        {
            textBox1.Text = vlag;
            string path = "График_влажности.txt";
            string date = DateTime.Now.ToString();
            // Создание файла и запись в него
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(vlag);
                sw.WriteLine(date);
            }
        }

        //запись температуры
        private delegate void LineReceivedEvent1(string temp);
        private void LineReceived1(string temp)
        {
            textBox2.Text = temp.ToString();
            string path = "График_температуры.txt";
            string date = DateTime.Now.ToString();
            // Создание файла и запись в него
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(temp);
                sw.WriteLine(date);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Chart.ChartAreas[0].AxisX.ScaleView.Zoom(0, 30);
                Chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                Chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                Chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                Chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

                //chart1.ChartAreas[0].AxisY.ScaleView.Zoom(0, 30);
                //chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
                //chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                //chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                chart1.Series[0].Points.Clear();
                while (!streamReader.EndOfStream)
                {
                    string Y = streamReader.ReadLine();
                    string X = streamReader.ReadLine();

                    chart1.Series[0].Color = Color.Red;
                    chart1.Series[0].BorderWidth = 1;
                    chart1.Series[0].Points.AddXY(X, Y);
                }
                streamReader.Close();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
        private static void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string vlag = SerialPort.ReadLine(sender);

            SerialPort serialPort = (SerialPort)sender;
            int count = serialPort.BytesToRead;

            if (count > 1)
            {
               
       
                byte[] data = new byte[count];
                serialPort.Read(data, 0, data.Length);
                Console.WriteLine((data[0] & 0XFF) | ((data[1] & 0XFF) << 8));
            }
            

        }
    
    }
}
