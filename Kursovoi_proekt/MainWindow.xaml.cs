//using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;
using System.Collections;
//using Microsoft.Office.Interop.Word;
//using 

namespace Kursovoi_proekt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Shifr_Vizh.InitAlfavit();
            Check0.IsChecked = true;
            TrueCezar.IsChecked = true;

        }

         
        public static string filename;
        public static string document;
        public static string key;
        public static bool IsCheck = false;
        public static bool CesarIsCheck = true;
        public static string result = "";
        public static string DownResult = "";
       

      

        public void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            
            try
            {
                OpenFileDialog OPF = new OpenFileDialog();
                OPF.Filter = "Текстовые файлы(*.txt)|*.txt";
                OPF.CheckFileExists = true;
                if (OPF.ShowDialog() == true)
                {
                    /// OPF.Multiselect = false;
                    // OPF.ShowDialog();
                    // ;
                    filename = OPF.FileName;
                    MessageBox.Show("Файл "+OPF.FileName+" был открыт","Текстовый файл", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    using (FileStream f = new FileStream(filename, FileMode.Open))
                    {
                        StreamReader RF1 = new StreamReader(f);
                        document = RF1.ReadLine();
                        Textbox.Text = document;
                        f.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Вы отменили процедуру открытия файла!", "Отмена", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           


        }
        public void Button_Click_Key(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Tabl_Shifra.GetKey_Standart().ToLower()+" - отгадка данной загадки задания\nПоскольку в древности, мыслители и учёные умы ещё не знали обо всех физических законах, а могли только догадываться о них, то основными ответами на вопросы мировоздания являлись божество и различные магические закономерности. Одна из такой закономерностей, сохранившейся и до наших дней, является вера во взаимосвязи макромира - мира космического, и микромира - в данном случае, мира (среды) обитания человека.\nСогласно данной теории, считается, что положение звёзд на небе - не случайно. В последствии, наиболее крупные звёзды (многие из которых, возможно, уже погасли) начали объединять в созведия, а само небо делить на определённые участки - эклиптику.","Загадка",MessageBoxButton.OK ,MessageBoxImage.Information);
           // return "СКОРПИОН";
        }
        public void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog SPF = new SaveFileDialog();
                SPF.Filter = "Текстовые файлы(*.txt)|*.txt";
                //SPF.CheckFileExists = true;
                // SPF.DefaultExt = "txt";
                //  SPF.AddExtension = false;
                // SPF.CreatePrompt = false;
                // SPF.OverwritePrompt = false;
                //SPF.InitialDirectory
                if (SPF.ShowDialog() == true)
                {
                    try
                    {
                        string filename = SPF.FileName;
                        
                        System.IO.File.WriteAllText(filename, Textbox.Text);
                        MessageBox.Show("Файл успешно сохранён!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Вы отменили процедуру сохранения файла!", "Отмена операции", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Button_Click_GetKey(object sender, RoutedEventArgs e)
        {
            try
            {
                key = "";
                key = Get_key.Text;
                if (String.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Мне бы ключик для шифра");
                }
                else
                {
                    for (int i = 0; i < key.Length; i++)
                    {
                        if (!((key[i] >= 'а' && key[i] <= 'я') || key[i] == 'ё' || (key[i] >= 'А' && key[i] <= 'Я') || key[i] == 'Ё' || key[i] == ' '))
                        {
                            MessageBox.Show("На данном этапе я могу работать только с ключём из русских букв","Определение ключа", MessageBoxButton.OK, MessageBoxImage.Error);
                            Get_key.Text = "";
                            throw new ArgumentException();
                        }

                    }

                    Tabl_Shifra.GetKeyShifr(key);
                    MessageBox.Show("Ключ принят!\nЕсли его длина была больше 33, то я для шифра \"Простой замены\" я его обрежу чётенько - ибо шифру просой замены большего и не нужно","", MessageBoxButton.OK, MessageBoxImage.Error);
                    // key = "";
                    Get_key.Text = "";
                }
            }
            catch (ArgumentException a)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
            
        }
        public void Button_Click_Shifr(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Textbox.Text))
            {
                MessageBox.Show("Мне не с чем работать!\nНеобходимо ввести данные или определить их при помощи стандартного функционала", "Неверно задан ключ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Textbox.Text = Tabl_Shifra.Shifr(Textbox.Text);
                MessageBox.Show("Зашифровано!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
        public void Button_Click_Deshifr(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Textbox.Text))
            {
                MessageBox.Show("Мне не с чем работать!\nНеобходимо ввести данные или определить их при помощи стандартного функционала", "Неверно задан ключ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Textbox.Text = Tabl_Shifra.Deshifr(Textbox.Text);
                MessageBox.Show("Расшифровано!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
        public void Button_Click_OpenWord(object sender, RoutedEventArgs e)
        {
            string text = "";
            try
            {
                OpenFileDialog OPF = new OpenFileDialog();
                OPF.Filter = "Документ Word(*.docx)|*.docx|Документ Word 97-03(*.doc)|*.doc";
                OPF.CheckFileExists = true;
                if (OPF.ShowDialog() == true)
                {
                    OPF.Multiselect = false;
                    
                    Object filename = OPF.FileName;
                    MessageBox.Show("Файл "+OPF.FileName+" сейчас будет открыт", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    Word.Application app = new Word.Application();
                    // app.Documents.AsParallel();
                    app.Documents.OpenNoRepairDialog(filename, ReadOnly: true);
                    Word.Document doc = app.ActiveDocument;
                    try
                      {
                        for (int i = 1; i <= doc.Paragraphs.Count; i++)
                        {
                            text += doc.Paragraphs[i].Range.Text;
                        }

                        Textbox.Text = text;

                        MessageBox.Show("Информация успешно выведена на Экран!","Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        doc.Close();
                        app.Quit();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + "Что-то не так с Word и процессом его работы", "Это всё Word!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    finally
                    {
                        doc.Close();
                        app.Quit();
                    }
                }
                else
                {
                    MessageBox.Show("Вы отменили процедуру открытия файла!", "Отмена процедуры", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вероятнее всего, на компьютере нет Microsoft Office Word\nЕсли он есть, то он не указан как\"Приложение по-умолчанию\" для даного типа файлов\nСейчас выйдет инфо об ошибке, поискав информацию о которой в Google, вы сможете понять, что нужно предпринять", "Просто информируем", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show(ex.Message);
                
            }
        }
        public void Button_Click_SaveWord(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SPF = new SaveFileDialog();
            SPF.Filter = "Документ Word(*.docx)|*.docx|Документ Word 97-03(*.doc)|*.doc";

            //  App = new Word.Application();
            //SPF.CheckFileExists = true;
            // SPF.DefaultExt = "txt";
            //  SPF.AddExtension = false;
            // SPF.CreatePrompt = false;
            // SPF.OverwritePrompt = false;
            //SPF.InitialDirectory
            try
            {
                if (SPF.ShowDialog() == true)
            {
                /// OPF.Multiselect = false;
                // OPF.ShowDialog();
                // ;
                MessageBox.Show(SPF.FileName);
               // MessageBox.Show("Сейчас выведеться окошко для сохранения из приложения Word");
                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Add(Visible: false);
                Word.Range r = doc.Range();
                r.Text = Textbox.Text;
                doc.SaveAs(SPF.FileName);
                doc.Close();
                app.Quit();
                MessageBox.Show("Всё сохранил!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Вы отменили процедуру сохранения файла!", "Отмена процедуры", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
                
            }
                catch (Exception ex)
                {
                     MessageBox.Show("Скорее всего, на компьютере не установлен Microsoft Office Word\nЕсли он установлен, то он не указан как\"Приложение по-умолчанию\" для даного типа файлов", "Что-то странное с Word", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    // MessageBox.Show(ex.Message);
                
                }


            }
        public void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            //Textbox.Text = Shifr_Vizh.InitAlfavit();
            Textbox.Text = "Ключ простой замены:\n"+Tabl_Shifra.GetKeyShifr(key) +"\nКлюч Виженера:\n" + Shifr_Vizh.InitAlfavit();
        }
        public void Button_Click_ShifrVizh(object sender, RoutedEventArgs e)
        {
           // DownResult = Textbox.Text;
            Textbox.Text = Shifr_Vizh.Shifr(Textbox.Text, key, IsCheck);
           // result = Textbox.Text;
        }
        public void Check_Checked_0(object sender, RoutedEventArgs e)
        {
           
            IsCheck = false;
            Check1.IsChecked = false;

        }
        public void Button_Click_DeshifrVizh(object sender, RoutedEventArgs e)
        {
           
            Textbox.Text = Shifr_Vizh.DeShifr(Textbox.Text, key, IsCheck);
        }
        public void Button_Click_StandartVizh(object sender, RoutedEventArgs e)
        {
            Textbox.Text = Shifr_Vizh.DeShifr(Textbox.Text, "скорпион", false);
        }
        public void Check_Checked_1(object sender, RoutedEventArgs e)
        {
            
            IsCheck = true;
            Check0.IsChecked = false;
        }
        public void Button_Click_StandartKey(object sender, RoutedEventArgs e)
        {
            key = "скорпион";
            Tabl_Shifra.GetKeyShifr("скорпион");
            MessageBox.Show("Стандартный ключ успешно установлен!\nЧтобы его узнать - необходимо нажать \"Узнать стандартный ключ\"", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        public void Button_Click_ShifrCez(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(CezarKey.Text);
            try
            {
                string s = Textbox.Text;
                string k = CezarKey.Text;
                for (int i=0;i<k.Length;i++)
                    if (!(Char.IsDigit(k[i])))
                    {
                        MessageBox.Show(k);
                        throw new ArgumentException();
                    }
                   
                        int kk = Convert.ToInt32(k);
                        kk = Math.Abs(kk);
                       // MessageBox.Show(kk.ToString());
                        Textbox.Text = Shifr_Cezar.Shifr(Textbox.Text, kk, CesarIsCheck);
                      //  CezarKey.Text = "";
                       
                    
               
            }
            catch(ArgumentException a)
            {
                MessageBox.Show("Ключ не может содержать ничего, кроме цифр","Неверный формат ключа", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Button_Click_DeshifrC(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = Textbox.Text;
                string k = CezarKey.Text;
                for (int i = 0; i < k.Length; i++)
                    if (!(Char.IsDigit(k[i])))
                    {
                        MessageBox.Show(k);
                        throw new ArgumentException();
                    }

                int kk = Convert.ToInt32(k);
                kk = Math.Abs(kk);
                // MessageBox.Show(kk.ToString());
                Textbox.Text = Shifr_Cezar.Deshifr(Textbox.Text, kk, CesarIsCheck);
               // CezarKey.Text = "";



            }
            catch (ArgumentException a)
            {
                MessageBox.Show("Ключ не может содержать ничего, кроме цифр", "Неверный формат ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Button_Click_AtbashKey(object sender, RoutedEventArgs e)
        {
            key = "яюэьыъщшчцхфутсрпонмлкйизжёедгвба";
            Tabl_Shifra.GetKeyShifr("яюэьыъщшчцхфутсрпонмлкйизжёедгвба");
            MessageBox.Show("Ключ для шифра Атбаш установлен!\nДанный ключ используется для русского алфавита","Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        public void CheckBox_Checked_TrueCezar(object sender, RoutedEventArgs e)
        {
            CesarIsCheck = true;
            FalseCezar.IsChecked = false;
        }
        public void CheckBox_Checked_FalseCezar(object sender, RoutedEventArgs e)
        {
            CesarIsCheck = false;
            TrueCezar.IsChecked = false;
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AllRadio.IsChecked == true)
            {
                Textbox.Text = "";
                CezarKey.Text = "";
                Get_key.Text = "";
                key = "";
                filename="";
                document="";
                IsCheck = false;
                CesarIsCheck = true;
                Check0.IsChecked = true;
                TrueCezar.IsChecked = true;
                AllRadio.IsChecked = false;
                MessageBox.Show("Все настройки сброшены в начальное состояние.\nКлючи не установлены","По-умолчанию", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                Textbox.Text = "";
            }
            
        }
        public void AllRadio_Checked(object sender, RoutedEventArgs e)
        {
  
        }
    }
    } 



