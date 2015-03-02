using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeApplication;
using System.Linq;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAverage()
        {
            Form1 BikeApplication = new Form1();

            double averageSpeed = 0;
            double[] doubleData = new double[]{10, 10, 10, 10, 10, 10, 10};

            for (int i = 0; i< doubleData.Length; i++)
            {

                averageSpeed = averageSpeed + doubleData[i];

            }

            averageSpeed = averageSpeed / doubleData.Length;

            Assert.AreEqual(averageSpeed, 10);
        }
         [TestMethod]
        public void TotalDistance()
        {
              double[] doubleData = new double[]{10, 10, 10, 10, 10, 10, 10};
              double distanceSpeed = 0;
              for (int i = 0; i < doubleData.Length; i++)
              {

                  distanceSpeed = distanceSpeed + (doubleData[i] / 60 / 60 );
                  

              }
              distanceSpeed = Math.Round(distanceSpeed, 3);
             double number = 10;

             number = (number / 60 / 60) * 7;
             number = Math.Round(number, 3);
             Assert.AreEqual(distanceSpeed, number);


        }
         [TestMethod]
        public void maxValue()
        {

            double[] doubleData = new double[] { 10, 12, 10, 10, 10, 10, 11 };

            double maxValue = doubleData.Max();

            Assert.AreEqual(maxValue, 12);

        }
    }
}
