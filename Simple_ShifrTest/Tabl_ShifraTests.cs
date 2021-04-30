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
    public class Tabl_ShifraTests
    {
        [TestMethod()]
        public void GetKey_ShifrTest_Null()
        {
            string expected = "[а, а] [б, б] [в, в] [г, г] [д, д] [е, е] [ё, ё] [ж, ж] [з, з] [и, и] [й, й] [к, к] [л, л] [м, м] [н, н] [о, о] [п, п] [р, р] [с, с] [т, т] [у, у] [ф, ф] [х, х] [ц, ц] [ч, ч] [ш, ш] [щ, щ] [ъ, ъ] [ы, ы] [ь, ь] [э, э] [ю, ю] [я, я]";
            string actual = Tabl_Shifra.GetKeyShifr("");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetKey_ShifrTest_Key()
        {
            string expected = "[а, с] [б, к] [в, о] [г, р] [д, п] [е, и] [ё, н] [ж, а] [з, б] [и, в] [й, г] [к, д] [л, е] [м, ё] [н, ж] [о, з] [п, й] [р, л] [с, м] [т, т] [у, у] [ф, ф] [х, х] [ц, ц] [ч, ч] [ш, ш] [щ, щ] [ъ, ъ] [ы, ы] [ь, ь] [э, э] [ю, ю] [я, я]";
            string actual = Tabl_Shifra.GetKeyShifr("скорпион");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetKey_ShifrTest_Atbash()
        {
            string expected = "[а, я] [б, ю] [в, э] [г, ь] [д, ы] [е, ъ] [ё, щ] [ж, ш] [з, ч] [и, ц] [й, х] [к, ф] [л, у] [м, т] [н, с] [о, р] [п, п] [р, о] [с, н] [т, м] [у, л] [ф, к] [х, й] [ц, и] [ч, з] [ш, ж] [щ, ё] [ъ, е] [ы, д] [ь, г] [э, в] [ю, б] [я, а]";
            string actual = Tabl_Shifra.GetKeyShifr("яюэьыъщшчцхфутсрпонмлкйизжёедгвба");

            Assert.AreEqual(expected, actual);
        }

        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DataSimpleShifr.xml", "info", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void ShifrTest()
        {
            Tabl_Shifra.GetKeyShifr(Convert.ToString(TestContext.DataRow["dataK"]));
            string s = Convert.ToString(TestContext.DataRow["data"]);

            string expected = Convert.ToString(TestContext.DataRow["expected"]);

            string actual = Tabl_Shifra.Shifr(s);

            Assert.AreEqual(expected, actual);

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DataSimpleShifr.xml", "info", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void DeshifrTest()
        {
            Tabl_Shifra.GetKeyShifr(Convert.ToString(TestContext.DataRow["dataK"]));
            string s = Convert.ToString(TestContext.DataRow["expected"]);

            string expected = Convert.ToString(TestContext.DataRow["data"]);

            string actual = Tabl_Shifra.Deshifr(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShifrTest_NULLkey()
        {
            Tabl_Shifra.GetKeyShifr("");
 
            string actual1 = Tabl_Shifra.Shifr("");
            string actual2 = Tabl_Shifra.Shifr("скорпион");

            Assert.AreEqual(actual1,"");
            Assert.AreNotEqual(actual1,"скорпион");

        }

        [TestMethod()]
        public void ShifrTest_EnglishKey()
        {
            Tabl_Shifra.GetKeyShifr("english");

            string actual1 = Tabl_Shifra.Shifr("абвгдеёжзи");
            string actual2 = Tabl_Shifra.Shifr("abcdefghij");

            Assert.AreNotEqual(actual1, "englishжзи");
            Assert.AreNotEqual(actual2, "englishhij");

        }

        [TestMethod()]
        public void DeShifrTest_NULLkey()
        {
            Tabl_Shifra.GetKeyShifr("");

            string actual1 = Tabl_Shifra.Deshifr("");
            string actual2 = Tabl_Shifra.Deshifr("скорпион");

            Assert.AreEqual(actual1, "");
            Assert.AreNotEqual(actual1, "скорпион");

        }

        [TestMethod()]
        public void DeShifrTest_EnglishKey()
        {
            Tabl_Shifra.GetKeyShifr("english");

            string actual1 = Tabl_Shifra.Deshifr("englishжзи"); 
            string actual2 = Tabl_Shifra.Deshifr("englishhij"); 

            Assert.AreNotEqual(actual1, "абвгдеёжзи");
            Assert.AreNotEqual(actual2, "abcdefghij");

        }
    }
}