using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kursovoi_proekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovoi_proekt.Tests
{
    [TestClass()]
    public class Tabl_ShifraTests
    {
        [TestMethod()]
        public void GetKey_StandartTest()
        {
                string expected = "СКОРПИОН";

                string actual = Tabl_Shifra.GetKey_Standart();
                Assert.AreEqual(expected, actual);
        }
    }
}