using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kursovoi_proekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DataShifr.xml;

namespace Kursovoi_proekt.Tests
{
    [TestClass()]
    public class Shifr_VizhTests
    {


        [TestMethod()]
        public void InitAlfavitTest()
        {
            string exspected = "[а, 0] [б, 1] [в, 2] [г, 3] [д, 4] [е, 5] [ё, 6] [ж, 7] [з, 8] [и, 9] [й, 10] [к, 11] [л, 12] [м, 13] [н, 14] [о, 15] [п, 16] [р, 17] [с, 18] [т, 19] [у, 20] [ф, 21] [х, 22] [ц, 23] [ч, 24] [ш, 25] [щ, 26] [ъ, 27] [ы, 28] [ь, 29] [э, 30] [ю, 31] [я, 32] [а, 1] [б, 2] [в, 3] [г, 4] [д, 5] [е, 6] [ё, 7] [ж, 8] [з, 9] [и, 10] [й, 11] [к, 12] [л, 13] [м, 14] [н, 15] [о, 16] [п, 17] [р, 18] [с, 19] [т, 20] [у, 21] [ф, 22] [х, 23] [ц, 24] [ч, 25] [ш, 26] [щ, 27] [ъ, 28] [ы, 29] [ь, 30] [э, 31] [ю, 32] [я, 33] ";
            string actual = Shifr_Vizh.InitAlfavit();

            Assert.AreEqual(exspected, actual);
        }

        public TestContext TestContext { get; set; }
        
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DataShifr.xml", "info", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void ShifrTest()
        {
            Shifr_Vizh.InitAlfavit();

            string s = Convert.ToString(TestContext.DataRow["dataS"]);
            string k = Convert.ToString(TestContext.DataRow["dataK"]);
            bool b = Convert.ToBoolean(TestContext.DataRow["dataB"]);

            string expected = Convert.ToString(TestContext.DataRow["expected"]);

            string actual = Shifr_Vizh.Shifr(s, k, b);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ShifrTestExceptions()
        {
            Shifr_Vizh.InitAlfavit();
            string actual1 = Shifr_Vizh.Shifr("подарок", "", true);
            string actual2 = Shifr_Vizh.Shifr("", "подарок", false);
            Assert.AreNotEqual(actual1,"подарок");
            Assert.AreNotEqual(actual2,""); 

        }

        [TestMethod()]
        public void DeShifrTestExceptions()
        {
            Shifr_Vizh.InitAlfavit();
            string actual1 = Shifr_Vizh.Shifr("рсиитвы", "", true);
            Assert.AreNotEqual(actual1, "рсиитвы");
            string actual = Shifr_Vizh.Shifr("", "скорпион", false);
            Assert.AreNotEqual(actual, "скорпион");

        }

        [TestMethod()]
        public void DeShifrTestExceptionsHHH()
        {
            Shifr_Vizh.InitAlfavit();
            string actual1 = Shifr_Vizh.DeShifr("рсиитвы", "qwerty", true);
            string actual2 = Shifr_Vizh.DeShifr("qwerty", "скорпион", false);
            Assert.AreNotEqual(actual1, "подарок");
            Assert.AreEqual(actual2, "qwerty");

        }

        [TestMethod()]
        public void ShifrTestExceptionsHHH()
        {
            Shifr_Vizh.InitAlfavit();
            string actual1 = Shifr_Vizh.Shifr("подарок", "qwerty", true);
            string actual2 = Shifr_Vizh.Shifr("qwerty", "подарок", false);
            Assert.AreNotEqual(actual1, "подарок");
            Assert.AreEqual(actual2, "qwerty");

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DataShifr.xml", "info", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void DeShifrTest()
        {
            Shifr_Vizh.InitAlfavit();

            string s = Convert.ToString(TestContext.DataRow["expected"]);
            string k = Convert.ToString(TestContext.DataRow["dataK"]);
            bool b = Convert.ToBoolean(TestContext.DataRow["dataB"]);

            string expected = Convert.ToString(TestContext.DataRow["dataS"]);

            string actual = Shifr_Vizh.DeShifr(s, k, b);

            Assert.AreEqual(expected, actual);
        }
    }
}