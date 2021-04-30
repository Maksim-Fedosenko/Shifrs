using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kursovoi_proekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi_proekt.Tests
{
    [TestClass()]
    public class Shifr_CezarTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DataCezar.xml", "info", DataAccessMethod.Sequential)]
        [TestMethod()]
        
        public void ShifrTest()
        {
            string s = Convert.ToString(TestContext.DataRow["data"]);
            int k = Convert.ToInt32(TestContext.DataRow["dataK"]);
            bool b = Convert.ToBoolean(TestContext.DataRow["dataB"]);

            string expected = Convert.ToString(TestContext.DataRow["expected"]);

            string actual = Shifr_Cezar.Shifr(s, k, b);
        }

      
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DataCezar.xml", "info", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void DeshifrTest()
        {
            string s = Convert.ToString(TestContext.DataRow["expected"]);
            int k = Convert.ToInt32(TestContext.DataRow["dataK"]);
            bool b = Convert.ToBoolean(TestContext.DataRow["dataB"]);

            string expected = Convert.ToString(TestContext.DataRow["data"]);

            string actual = Shifr_Cezar.Deshifr(s, k, b);
        }

      
    }
}