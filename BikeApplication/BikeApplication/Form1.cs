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
            displayText();
        }
        private string[] data;
        public void getData()
        {
            string path = @"C:\Users\Joe\Documents\UNI\software\BikeApplication\ASDBExampleCycleComputerData.hrm";
            string line;
            StreamReader sr = new StreamReader(path);

            while ((line = sr.ReadLine()) != null)
            {
          

                if(line.Contains("[HRData]"))
                {
                    data = sr.ReadToEnd().Split('\t');
                    break;

                }                  

            }


        }
        public void displayText()
        {
            foreach (string myString in data)
            {
                txtData.Text = data[1];
            }


        }
      
    }
}
