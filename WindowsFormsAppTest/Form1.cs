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
using Models;
using Service;
using Repository;
using Castle.Windsor;
using Service.Interfaces;

namespace WindowsFormsAppTest
{
    public partial class Form1 : Form
    {
        WindsorContainer _container;
        IArduinoService _arduinoService;
        public Form1()
        {
            InitializeComponent();

            _container = Bootstrap.BuildContainer();
            IArduinoService _arduinoService;

            Arduino arduino = new Arduino();
            arduino.ID = Guid.NewGuid().ToString();
            arduino.CreationDate = DateTime.Now.ToString();
            arduino.ArduinoName = "ArduinoUno";
            arduino.ControllerFrequency = 8000000;

            // _arduinoService.Create(arduino);

            List<Arduino> arduinos = _arduinoService.GetAll().ToList();

            SerialPort serialPort1 = new SerialPort("COM8", 9600, Parity.None);
            serialPort1.Open();
            serialPort1.DataReceived += serialPort1_DataReceived;
            
            Console.ReadKey();
          
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           
            string vlag = ((SerialPort)sender).ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), vlag);
            
        }

        private void serialPort1_DataReceived1(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string temp = ((SerialPort)sender).ReadLine();
            this.BeginInvoke(new LineReceivedEvent1(LineReceived1), temp);
        }

       
        private delegate void LineReceivedEvent(string vlag);
        private void LineReceived(string vlag)
        {
            this.temp.Text = vlag;
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
            this.vlag.Text = temp.ToString();
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
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
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

                StreamReader streamReader = new StreamReader(OpenFileDialog.FileName);
                Chart.Series[0].Points.Clear();
                while (!streamReader.EndOfStream)
                {
                    string Y = streamReader.ReadLine();
                    string X = streamReader.ReadLine();

                    Chart.Series[0].Color = Color.Red;
                    Chart.Series[0].BorderWidth = 1;
                    Chart.Series[0].Points.AddXY(X, Y);
                }
                streamReader.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

 

