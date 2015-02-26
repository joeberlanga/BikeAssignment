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
            
        }
        private string[] data;
        
        private int arrayCount;


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
            

            
            List<int> heartRate = new List<int>();
            for (int i = 0; i < data.Length; i = i+6)
            {
                
                heartRate.Add(intData[i]);
                
            }
           
            txtData.Text = String.Join(Environment.NewLine, heartRate);
            
        }

        public void displayText()
        {
            foreach (string myString in data)
            {
                txtData.Text = arrayCount.ToString();
            }


        }
      
    }
}
