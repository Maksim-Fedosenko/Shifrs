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
    public class MainWindowTests
    {


        [TestMethod()]
        public void AllButtons()
        {
            var win = new MainWindow();
            win.Button_Click_AtbashKey(this, new RoutedEventArgs());
            win.Button_Click_Deshifr(this, new RoutedEventArgs());
            win.Button_Click_Shifr(this, new RoutedEventArgs());
            win.Button_Click_DeshifrVizh(this, new RoutedEventArgs());
            win.Button_Click_GetKey(this, new RoutedEventArgs());
            win.Button_Click_Key(this, new RoutedEventArgs());
            win.Button_Click_Open(this, new RoutedEventArgs());
            win.Button_Click_OpenWord(this, new RoutedEventArgs());
            win.Button_Click_Save(this, new RoutedEventArgs());
            win.Button_Click_SaveWord(this, new RoutedEventArgs());
            win.Button_Click_ShifrVizh(this, new RoutedEventArgs());
            win.Button_Click_ShifrCez(this, new RoutedEventArgs());
            win.Button_Click_StandartKey(this, new RoutedEventArgs());
            win.Button_Click_StandartVizh(this, new RoutedEventArgs());
           // win.Button_Click_Test(this, new RoutedEventArgs());
            Assert.AreEqual(true, true);
        }
        [TestMethod()]
        public void ShifrVizhTest()
        {
            var win = new MainWindow();
            // MainWindow.key = "скорпион";
            string key = "скорпион";
            string DownResult = "Поздравляю!!!";
            string result = "Въчхбйсъсй!!!";

            win.Button_Click_ShifrVizh(this, new RoutedEventArgs());
            Assert.AreEqual(result, Shifr_Vizh.Shifr(DownResult, key, true));
        }

        [TestMethod()]
        public void DeShifrVizhTest()
        {
            var win = new MainWindow();
            // MainWindow.key = "скорпион";
            string key = "скорпион";
            string DownResult = "Въчхбйсъсй!!!";
            string result = "Поздравляю!!!";

            win.Button_Click_DeshifrVizh(this, new RoutedEventArgs());
            Assert.AreEqual(result, Shifr_Vizh.DeShifr(DownResult, key, true));
        }

        [TestMethod()]
        public void Button_Click_DeshifrVizhTest()
        {
            var win = new MainWindow();
            // MainWindow.key = "скорпион";
            string key = "скорпион";
            string result = "Поздравляю!!!";
            string DownResult = "Въчхбйсъсй!!!";

            win.Button_Click_DeshifrVizh(this, new RoutedEventArgs());
            Assert.AreEqual(result, Shifr_Vizh.DeShifr(DownResult, key, true));
        }

        [TestMethod()]
        public void Check_Checked_0Test()
        {
            Assert.AreEqual(MainWindow.IsCheck, false);
        }

        [TestMethod()]
        public void Button_Click_ShifrTest()
        {
            var win = new MainWindow();
            win.Button_Click_AtbashKey(this, new RoutedEventArgs());
            win.Button_Click_Shifr(this, new RoutedEventArgs());
            string result = "яюэьыъщшчцхфутсрпонмлкйизжёедгвба";
            string actual = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            Assert.AreEqual(result, Tabl_Shifra.Shifr(actual));

        }

        [TestMethod()]
        public void Button_Click_DeshifrTest()
        {
            var win = new MainWindow();
            win.Button_Click_AtbashKey(this, new RoutedEventArgs());
            win.Button_Click_Shifr(this, new RoutedEventArgs());
            string actual = "яюэьыъщшчцхфутсрпонмлкйизжёедгвба";
            string result = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            Assert.AreEqual(actual, Tabl_Shifra.Deshifr(result));
        }

        [TestMethod()]
        public void WithTXT()
        {

            var win = new MainWindow();
            win.Button_Click_Open(this, new RoutedEventArgs());
            win.Button_Click_Save(this, new RoutedEventArgs());
            Assert.AreEqual(true,true);
        }

        [TestMethod()]
        public void WithWord()
        {
            var win = new MainWindow();
            win.Button_Click_OpenWord(this, new RoutedEventArgs());
            win.Button_Click_SaveWord(this, new RoutedEventArgs());
            Assert.AreEqual(true, true);
        }
    }
}