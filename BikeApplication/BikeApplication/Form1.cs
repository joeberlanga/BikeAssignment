using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace BikeApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getData();
            sortData();
            displayData();
            
        }

        private string[] data;  
        private int arrayCount;
        List<double> heartRate = new List<double>();
        List<double> speed = new List<double>();
        List<double> cadence = new List<double>();
        List<double> altitude = new List<double>();
        List<double> power = new List<double>();
        List<double> powerLRBallance = new List<double>();
        double speedUnit = 1;
        string stringSpeedUnit = "KPH";

        public void getData()
        {
            string path = @"C:\Users\Joe\Documents\UNI\software\Bikeapplication data\BikeAssignment1\BikeAssignment\BikeApplication\ASDBExampleCycleComputerData.hrm";
            string line;
            StreamReader sr = new StreamReader(path);

            while ((line = sr.ReadLine()) != null)
            {
                if(line.StartsWith("Date"))
                {
                    string date = line.Substring(5);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(date);
                    sb.Insert(4, "-");
                    sb.Insert(7, "-");       
                    date = sb.ToString();
                    DateTime dt = Convert.ToDateTime(date);
                    label1.Text = date;
                }
                if (line.StartsWith("StartTime"))
                {
                    string startTime = line.Substring(10);

                    label2.Text = startTime;

                }
                if (line.StartsWith("Length"))
                {
                    string Length = line.Substring(7);

                    label3.Text = Length + (" (hh:mm:ss)");

                }
                if (line.StartsWith("MaxHR"))
                {
                    string maxHR = line.Substring(6);

                    label4.Text = maxHR + (" (BPM)");

                }
                if (line.StartsWith("RestHR"))
                {
                    string restHR = line.Substring(7);

                    label5.Text = restHR + (" (BPM)");

                }
                if (line.StartsWith("VO2max"))
                {
                    string VO2max = line.Substring(7);

                    label6.Text = VO2max + (" (ml/min/kg)");

                }
                if (line.StartsWith("Weight"))
                {
                    string weight = line.Substring(7);

                    label7.Text = weight + (" (kg)");

                }
                if(line.Contains("[HRData]"))
                {
                    data = sr.ReadToEnd().Split(new Char [] {'\t','\n'});
                    break;

                }                  

            }

        }
        public void sortData()
        {

            

            double[] doubleData = new double[data.Length];

            
            for (int x = 0; x < data.Length;x++ )
            {
               double.TryParse(data[x], out doubleData[x]);
               
            }

            arrayCount = data.Length;



            double heartRateAverage = 0;
            int count = 0;
            for (int i = 0; i < data.Length; i = i+6)
            {
                
                heartRate.Add(doubleData[i]);

                if (doubleData[i] != 0)
                {
                    heartRateAverage = heartRateAverage + doubleData[i];
                    count++;

                }

                
            }

            heartRateAverage = heartRateAverage / count;
            heartRateAverage = Math.Round(heartRateAverage, 2);
            label9.Text = heartRateAverage.ToString();

            double speedAverage = 0;
            count = 0;
            for (int i = 1; i < data.Length; i = i+6)
            {

                doubleData[i] = doubleData[i] / 10;
                

                doubleData[i] = doubleData[i] * speedUnit;

                
                speed.Add(doubleData[i]);

                if (doubleData[i] != 0)
                {
                    speedAverage = speedAverage + doubleData[i];
                    count++;

                }
                
            }


            speedAverage = speedAverage / count ;
           
            speedAverage = Math.Round(speedAverage, 2);     
            label11.Text = speedAverage.ToString();

            count = 0;
            double averageCadence = 0;
            for (int i = 2; i < data.Length; i = i + 6)
            {

                cadence.Add(doubleData[i]);

                if (doubleData[i] != 0)
                {
                    averageCadence = averageCadence + doubleData[i];
                    count++;
                }

            }

            averageCadence = averageCadence / count;
            averageCadence = Math.Round(averageCadence, 2);
            label13.Text = averageCadence.ToString();


            for (int i = 3; i < data.Length; i = i + 6)
            {

                altitude.Add(doubleData[i]);

            }

            count = 0;
            double averagePower = 0;

            for (int i = 4; i < data.Length; i = i + 6)
            {

                power.Add(doubleData[i]);
                if (doubleData[i] != 0)
                {

                    averagePower = averagePower + doubleData[i];
                    count++;

                }

            }

            averagePower = averagePower / count;
            averagePower = Math.Round(averagePower, 2);
            label22.Text = averagePower.ToString();

            for (int i = 5; i < data.Length; i = i + 6)
            {

                powerLRBallance.Add(doubleData[i]);

            }

               
            
        }
        
        
        public void displayData()
        {


                DataTable dt = new DataTable();
                double[] heartRateArray = heartRate.ToArray();

                dt.Columns.Add("Heart Rate (BPM)", typeof(int));
                dt.Columns.Add("Speed (" + stringSpeedUnit + ")", typeof(int));
                dt.Columns.Add("Cadence (RPM)", typeof(int));
                dt.Columns.Add("Altitude (ASL)", typeof(int));
                dt.Columns.Add("Power (watts)", typeof(int));
                dt.Columns.Add("Power Left/Right Balance", typeof(int));

                

                
                for (int i = 0; i < heartRateArray.Length - 1; i++)
                {
                   

                    dt.Rows.Add(heartRate[i], speed[i], cadence[i], altitude[i], power[i], powerLRBallance[i]);

                }

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
                dataGridView1.Columns[1].DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
                dataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
                dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
                dataGridView1.Columns[4].DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
                dataGridView1.Columns[5].DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 250;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 15, FontStyle.Regular);
                dataGridView1.ColumnHeadersHeight = 75;
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                speedUnit = 1;
                stringSpeedUnit = "KPH";

            }
            else
            {
                stringSpeedUnit = "MPH";
                speedUnit = 0.621371;

            }
            speed.Clear();
                     
            heartRate.Clear();
            cadence.Clear();
            power.Clear();
            powerLRBallance.Clear();
            altitude.Clear();
            sortData();
            displayData();
           

        }
      
    }
}
