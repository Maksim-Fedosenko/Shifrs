using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovoi_proekt
{
    public class Tabl_Shifra
    {
        
    
        static Dictionary<char, char> dic = new Dictionary<char, char>();
        static Dictionary<char, char> dic2 = new Dictionary<char, char>();

        public static string GetKeyShifr(string k)
        {
            
            try { 
                HashSet<char> alfavit = new HashSet<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

                dic = new Dictionary<char, char>();
                dic2 = new Dictionary<char, char>();

                HashSet<char> h = new HashSet<char>();

                List<char> Tabl_key = new List<char>();


                if (k.Length > 33)
                {
                    k = k.Substring(0, 33);
                }

                for (int i = 0; i < k.Length; i++)
                 {
                    if (!((k[i] >= 'а' && k[i] <= 'я') || k[i] == 'ё' || (k[i] >= 'А' && k[i] <= 'Я') || k[i] == 'Ё'|| k[i]==' '))
                        {
                            throw new ArgumentException();
                        }
      
                 }
                

                for (int i = 0; i < k.Length; i++)
                {
                    if (k[i] != ' ')
                    {
                        h.Add(Convert.ToChar(k[i].ToString().ToLower()));
                    }
                    else
                    {
                        continue;
                    }

                }
                HashSet<char> newAlfavit = alfavit;

                newAlfavit.ExceptWith(h);

                Tabl_key.AddRange(h);
                Tabl_key.AddRange(newAlfavit);

                // newAlfavit.UnionWith(h);

                    int y = 0;
                    for (char i = 'а'; i <= 'я'; i++)
                    {
                        if (i == 'ж')
                        {
                            dic.Add('ё', Tabl_key[y]);
                            dic2.Add(Tabl_key[y], 'ё');
                            y++;
                            dic.Add(i, Tabl_key[y]);
                            dic2.Add(Tabl_key[y], i);
                            y++;
                        }
                        else
                        {
                            dic.Add(i, Tabl_key[y]);
                            dic2.Add(Tabl_key[y], i);
                            y++;
                        }

                    }
                   

            }
                catch(ArgumentException a)
                {
                MessageBox.Show("Ключ должен содержать только буквы русского алфавита", "Неверно задан ключ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return null;
                 }
            
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Исключение", MessageBoxButton.OK, MessageBoxImage.Error);
                   
                    return null;
                }

                string ss = "";
                foreach (var item in dic)
                {
                    ss += item + " ";
                }

              /*  foreach (var item in dic)
                {
                    ss += item + " ";
                }*/

                return ss.Trim();
            }
           /*catch (ArgumentException ar)
            {
                MessageBox.Show("Неверный ключ.Ключ не должен содержать символы в верхнем регистре, а также символы не русских букв");
                return null;
            }
        }*/
        public static string Shifr(string s)
        {
            string ss = "";
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 'а' && s[i] <= 'я') || s[i] == 'ё' || (s[i] >= 'А' && s[i] <= 'Я') || s[i] == 'Ё')    //
                {
                    if (char.IsUpper(s[i]))
                    {
                        dic.TryGetValue(Convert.ToChar(s[i].ToString().ToLower()), out char value);
                        ss += Convert.ToChar(value.ToString().ToUpper());
                    }
                    else
                    {
                        dic.TryGetValue(s[i], out char value);
                        ss += value;
                    }
                }
                else
                {
                    ss += s[i];
                }
            }

            return ss;
        }
        public static string Deshifr(string s)
        {
            string ss = "";
            for (int i = 0; i < s.Length; i++)
            {
               if ((s[i] >= 'а' && s[i] <= 'я') || s[i] == 'ё' || (s[i] >= 'А' && s[i] <= 'Я') || s[i] == 'Ё')    //
              {
                   
                if (char.IsUpper(s[i]))
                    {
                        dic2.TryGetValue(Convert.ToChar(s[i].ToString().ToLower()), out char value);
                        ss += Convert.ToChar(value.ToString().ToUpper());
                    }
                    else
                    {
                        dic2.TryGetValue(s[i], out char value);
                        ss += value;
                    }
               }
              else
             {
                     ss += s[i];
                    //ss += " ";
               }
            }

            return ss;
            
        } 
        public static string GetKey_Standart()
        {
            return "Скорпион";
        }
    }
}
    
