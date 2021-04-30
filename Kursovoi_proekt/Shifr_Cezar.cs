using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovoi_proekt
{
    public class Shifr_Cezar
    {
        public static string Shifr(string s, int a, bool b)
        {
            List<string> LowerAlf = new List<string> { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            char[] UpperAlf = new char[33];
            string s_new = null;
            int aa = (int)a;
            if (b == true)
            {
                
                for (int i = 0; i < s.Length; i++)
                {
                  
                    if (s[i] >= 'А' && s[i] <= 'Я')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(Char.ToLower(s[i])));

                        try
                        {

                            s_new += LowerAlf[numberOfSymbol + aa].ToUpper();
                        }
                        catch
                        {
                            s_new += LowerAlf[(numberOfSymbol + aa) - 33].ToUpper();
                        }
                    }
                    else if (s[i] >= 'а' && s[i] <= 'я' || s[i] == 'ё')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(s[i]));

                        try
                        {
                            s_new += LowerAlf[numberOfSymbol + aa];
                        }
                        catch
                        {
                            s_new += LowerAlf[(numberOfSymbol + aa) - 33];
                        }
                    }
                    else
                    {
                        s_new += s[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {

                    if ((s[i] >= 'А' && s[i] <= 'Я') || s[i]=='Ё')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(Char.ToLower(s[i])));

                        try
                        {
                            if (s[i] == 'А')
                            {
                                s_new += LowerAlf[33 - aa].ToUpper();
                            }
                            else
                            {
                                s_new += LowerAlf[numberOfSymbol - aa].ToUpper();
                            }
                        }
                        catch
                        {
                            s_new += LowerAlf[33 - (aa - numberOfSymbol)].ToUpper();
                        }
                    }
                    else if (s[i] >= 'а' && s[i] <= 'я')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(s[i]));

                        try
                        {
                            if (s[i] == 'а')
                            {
                                s_new += LowerAlf[33 - aa];
                            }
                            else
                            {
                                s_new += LowerAlf[numberOfSymbol - aa];
                            }
                        }
                        catch
                        {
                            s_new += LowerAlf[33 - (aa - numberOfSymbol)];
                        }
                    }
                    else
                    {
                        s_new += s[i];
                    }
                }
            }

            MessageBox.Show("Зашифровано!","Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            return s_new;
        }

        public static string Deshifr(string s, int a, bool b)
        {
            List<string> LowerAlf = new List<string> { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            char[] UpperAlf = new char[33];
            string s_new = null;
            int aa = (int)a;
            if (b == false)
            {
              
                for (int i = 0; i < s.Length; i++)
                {
                  
                    if (s[i] >= 'А' && s[i] <= 'Я' || s[i] == 'Ё')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(Char.ToLower(s[i])));

                   
                        try
                        {

                            s_new += LowerAlf[numberOfSymbol + aa].ToUpper();
                        }
                        catch
                        {
                            s_new += LowerAlf[(numberOfSymbol + aa) - 33].ToUpper();
                        }
                    }
                    else if (s[i] >= 'а' && s[i] <= 'я' || s[i] == 'ё')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(s[i]));
  
                        try
                        {
                            s_new += LowerAlf[numberOfSymbol + aa];
                        }
                        catch
                        {
                            s_new += LowerAlf[(numberOfSymbol + aa) - 33];
                        }
                    }
                    else
                    {
                        s_new += s[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    
                    if (s[i] >= 'А' && s[i] <= 'Я' || s[i] == 'Ё')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(Char.ToLower(s[i])));

                      
                        try
                        {
                            s_new += LowerAlf[numberOfSymbol - aa].ToUpper();
                        }
                        catch
                        {
                            s_new += LowerAlf[33 - (aa - numberOfSymbol)].ToUpper();
                        }
                    }
                    else if (s[i] >= 'а' && s[i] <= 'я' || s[i] == 'ё')
                    {
                        int numberOfSymbol = LowerAlf.IndexOf(Convert.ToString(s[i]));

                        try
                        {
                       
                            s_new += LowerAlf[numberOfSymbol - aa];

                        }
                        catch
                        {
                            s_new += LowerAlf[33 - (aa - numberOfSymbol)];
                        }
                    }
                    else
                    {
                        s_new += s[i];
                    }
                }
            }
            MessageBox.Show("Расшифровано!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            return s_new;
        }
        }
}
