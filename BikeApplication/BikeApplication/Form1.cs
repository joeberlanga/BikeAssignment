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
            dt.Columns.Add("speed", typeof(int));
            dt.Columns.Add("cadence", typeof(int));
            dt.Columns.Add("altitude", typeof(int));
            dt.Columns.Add("power", typeof(int));
            dt.Columns.Add("power Left/Right Ballance", typeof(int));
            

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
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToAddRows = false;
                   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
    }
}
