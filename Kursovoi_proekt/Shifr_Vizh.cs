using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovoi_proekt
{
    public class Shifr_Vizh
    {
        private static Dictionary<char, int> alfavit0 = new Dictionary<char, int>();
        private static Dictionary<int, char> alfavit0_1 = new Dictionary<int, char>();
        private static Dictionary<char, int> alfavit1 = new Dictionary<char, int>();
        private static Dictionary<int, char> alfavit1_1 = new Dictionary<int, char>();

        public static string InitAlfavit()
        {
            alfavit0 = new Dictionary<char, int>();
            alfavit0_1 = new Dictionary<int, char>();
            alfavit1 = new Dictionary<char, int>();
            alfavit1_1 = new Dictionary<int, char>();
            int y = 0;
            for (char i = 'а'; i <= 'я'; i++)
            {
                if (i == 'ж')
                {
                    alfavit0.Add('ё',y);
                    alfavit0_1.Add(y,'ё');
                    alfavit1.Add('ё',y+1);
                    alfavit1_1.Add(y + 1,'ё');
                    y++;
                    alfavit0.Add(i,y);
                    alfavit0_1.Add(y,i);
                    alfavit1.Add(i,y+1);
                    alfavit1_1.Add(y+1,i);
                    y++;
                }
                else
                {
                    alfavit0.Add(i,y);
                    alfavit0_1.Add(y,i);
                    alfavit1.Add(i, y+1);
                    alfavit1_1.Add(y+1,i);
                    y++;
                }
            }

            string ss = "";
            foreach (var item in alfavit0)
            {
                ss += item + " ";
            }

            string ss1 = "";
            foreach (var item in alfavit1)
            {
                ss1 += item + " ";
            }

            // return $"{ss}\n{ss1}";
            return ss + ss1;
        }
        
        public static string Shifr(string s, string k, bool b)
        {
            Dictionary<char, int> alfavit = new Dictionary<char, int>();
            Dictionary<int, char> alfavit_1 = new Dictionary<int, char>();
            try
            {
                if (string.IsNullOrWhiteSpace(s)||string.IsNullOrWhiteSpace(k)||s==null||k==null)
                {
                    throw new ArgumentNullException();
                }
                
                k = k.ToLower();

                for (int i = 0; i < k.Length; i++)
                {
                    if(!((k[i] >= 'а' && k[i] <= 'я') || k[i] == 'ё'))
                    {
                        throw new ArgumentException();  
                    }
                }
                //Dictionary<int, int> dic = new Dictionary<int, int>();
                if (!b)
                {
                    alfavit = alfavit0;
                    alfavit_1 = alfavit0_1;
                 }
                else
                {
                    alfavit = alfavit1;
                    alfavit_1 = alfavit1_1;
                }
               
                string ss = "";
           
                int u = 0;
                for (int i = 0; i < s.Length; i++)
                {
                   if ((s[i]>='а'&& s[i] <= 'я') || s[i] == 'ё'|| s[i] == 'Ё' || (s[i] >= 'А' && s[i] <= 'Я'))
                    {
                        if(char.IsUpper(s[i]))
                        {
                            alfavit.TryGetValue(Convert.ToChar(s[i].ToString().ToLower()), out int value);
                            alfavit.TryGetValue(k[u % k.Length], out int value2);
                            int y = (value + value2) % 33;
                            if (y == 0 && b == true)
                            {
                                y = 33;
                            }
                            alfavit_1.TryGetValue(y, out char value3);
                            ss += value3.ToString().ToUpper();
                            u++;
                        }
                        else
                        {
                            alfavit.TryGetValue(s[i], out int value);
                            alfavit.TryGetValue(k[u % k.Length], out int value2);
                            int y = (value + value2) % 33;
                            if (y == 0&&b==true)
                            {
                                y = 33;
                            }
                            alfavit_1.TryGetValue(y, out char value3);
                            ss += value3;
                            u++;
                        }
                      
                    }
                    else
                    {
                        ss += s[i];
                    }
                   
                }
                MessageBox.Show("Зашифровано!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return ss;
            }
            catch (ArgumentNullException o)
            {
                /*if ((s.Length == 0||s==null) && (k.Length == 0||k==null))
                {
                    MessageBox.Show("И ключ, и поле текста - пустые.\nИх необходимо задать");
                }
                
                else if (s.Length == 0|| s==null)
                {
                    MessageBox.Show("Мне нечего шифровать (поля текста - пустое)");
                }
                else if (k.Length == 0 || k ==null)
                {
                    MessageBox.Show("Мне нечем шифровать (не введён ключ - необходимо его переопределить)");

                }
                else
                {
                    MessageBox.Show(o.Message);
                }*/
                MessageBox.Show("Необходимо ввести данные или определить их при помощи стандартного функционала", "Неверно задан ключ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return null;
            }

            catch(ArgumentException y)
            {
                MessageBox.Show("Для данного шифра ключ, содержащий в себе символы, не относящиеся к русским буквам - недопустимы.\nПереопредели, пожалуйста, ключ!", "Неверно задан ключ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return null;
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static string DeShifr(string s, string k, bool b)
        {
            Dictionary<char, int> alfavit = new Dictionary<char, int>();
            Dictionary<int, char> alfavit_1 = new Dictionary<int, char>();
            try
            {
                if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(k))
                {
                    throw new ArgumentNullException();
                }

                k = k.ToLower();

                for (int i = 0; i < k.Length; i++)
                {
                    if (!((k[i] >= 'а' && k[i] <= 'я') || k[i] == 'ё'))
                    {
                        throw new ArgumentException();
                    }
                }
                if (!b)
                {
                    alfavit = alfavit0;
                    alfavit_1 = alfavit0_1;
                }
                else
                {
                    alfavit = alfavit1;
                    alfavit_1 = alfavit1_1;
                }
                string ss = "";

                int u = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] >= 'а' && s[i] <= 'я') || s[i] == 'ё' || s[i] == 'Ё' || (s[i] >= 'А' && s[i] <= 'Я'))
                    {
                        if (char.IsUpper(s[i]))
                        {
                            alfavit.TryGetValue(Convert.ToChar(s[i].ToString().ToLower()), out int value);
                            /*if (s[i] == 'я')
                            {
                                value = 33;
                                
                            }*/
                            alfavit.TryGetValue(k[u % k.Length], out int value2);
                            int y = (value + 33 - value2) % 33;
                            if (y == 0 && b == true)
                            {
                                y = 33;
                            }
                            alfavit_1.TryGetValue(y, out char value3);
                            ss += value3.ToString().ToUpper();
                            u++;
                        }
                        else
                        {
                            alfavit.TryGetValue(s[i], out int value);
                           /* if (s[i] == 'я')
                            {
                                value = 33;
                            }*/
                            alfavit.TryGetValue(k[u % k.Length], out int value2);
                            
                            int y = (value + 33 - value2) % 33;
                            if (y == 0 && b == true)
                            {
                                y = 33;
                            }
                            alfavit_1.TryGetValue(y, out char value3);
                            ss += value3;
                            u++;
                        }

                    }
                    else
                    {
                        ss += s[i];
                    }

                }
                MessageBox.Show("Расшифровано!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                return ss;
            }
            catch (ArgumentNullException o)
            {
                /* if (s.Length == 0 && k.Length == 0)
                 {
                     MessageBox.Show("И ключ, и поле текста - пустые.\nИх необходимо задать");
                 }

                 else if (s.Length == 0)
                 {
                     MessageBox.Show("Мне нечего шифровать (поля текста - пустое)");
                 }
                 else if (k.Length == 0)
                 {
                     MessageBox.Show("Мне нечем шифровать (не введён ключ - необходимо его переопределить)");

                 }
                 else
                 {
                     MessageBox.Show(o.Message);
                 }*/
                MessageBox.Show("Необходимо ввести данные или определить их при помощи стандартного функционала","Неверно задан ключ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return null;
            }

            catch (ArgumentException y)
            {
                MessageBox.Show("Для данного шифра ключ, содержащий в себе символы, не относящиеся к русским буквам - недопустимы.\nПереопредели, пожалуйста, ключ!", "Неверно задан ключ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Исключение", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
