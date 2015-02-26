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
        List<int> heartRate = new List<int>();
        List<int> speed = new List<int>();
        List<int> cadence = new List<int>();
        List<int> altitude = new List<int>();
        List<int> power = new List<int>();
        List<int> powerLRBallance = new List<int>();

        public void getData()
        {
            string path = @"C:\Users\Joe\Documents\GitHub\BikeAssignment\BikeApplication\ASDBExampleCycleComputerData.hrm";
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

                    label3.Text = Length;

                }
                if (line.StartsWith("MaxHR"))
                {
                    string maxHR = line.Substring(6);

                    label4.Text = maxHR;

                }
                if (line.StartsWith("RestHR"))
                {
                    string restHR = line.Substring(7);

                    label5.Text = restHR;

                }
                if (line.StartsWith("VO2max"))
                {
                    string VO2max = line.Substring(7);

                    label6.Text = VO2max;

                }
                if (line.StartsWith("Weight"))
                {
                    string weight = line.Substring(7);

                    label7.Text = weight;

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

            

            int[] intData = new int[data.Length];

            
            for (int x = 0; x < data.Length;x++ )
            {
               Int32.TryParse(data[x], out intData[x]);
               
            }

            arrayCount = data.Length;
            

            
            
            for (int i = 0; i < data.Length; i = i+6)
            {
                
                heartRate.Add(intData[i]);
                
            }

            for (int i = 1; i < data.Length; i = i+6)
            {
                intData[i] = intData[i] / 10;
                speed.Add(intData[i]);
                
            }
            for (int i = 2; i < data.Length; i = i + 6)
            {

                cadence.Add(intData[i]);

            }
            for (int i = 3; i < data.Length; i = i + 6)
            {

                altitude.Add(intData[i]);

            }
            for (int i = 4; i < data.Length; i = i + 6)
            {

                power.Add(intData[i]);

            }
            for (int i = 5; i < data.Length; i = i + 6)
            {

                powerLRBallance.Add(intData[i]);

            }

               
            
        }
        
        public void displayData()
        {


            int[] heartRateArray = heartRate.ToArray();

            DataTable dt = new DataTable();

            dt.Columns.Add("Heart Rate", typeof(int));
            dt.Columns.Add("Speed", typeof(int));
            dt.Columns.Add("Cadence", typeof(int));
            dt.Columns.Add("Altitude", typeof(int));
            dt.Columns.Add("Power", typeof(int));
            dt.Columns.Add("Power Left/Right Balance", typeof(int));
            

            for (int i = 0; i < heartRateArray.Length - 1; i++ )
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
            dataGridView1.ColumnHeadersHeight = 50;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
    }
}
