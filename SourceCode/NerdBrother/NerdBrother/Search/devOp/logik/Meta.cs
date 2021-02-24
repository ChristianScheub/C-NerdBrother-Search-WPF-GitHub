using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Suche
{
    class Meta
    {
        #region UrlCHECKER
        public static string urlChecker(String URL3)
        {
            URL3 = URL3.Replace("https", "http");
            if (URL3.FirstOrDefault() != 'h')
            { //http fehlt
                if (URL3[1] == 'w' && URL3[2] == 'w' && URL3[3] == 'w' && URL3[4] == '.')
                {
                    //www. ist vermutlich dabei
                    URL3 = "http://" + URL3;
                }
                else
                {
                    //www. nicht dabei
                    URL3 = "http://www." + URL3;
                }
            }
            return URL3;
        }
        #endregion UrlCHECKER 

        #region Description

        static public String GetDescription(String url)
        {
            // Read in an HTML file.
            var html = "";
            WebClient webpage = new WebClient();
            //  html = webpage.DownloadString(url);
            if (webpage.DownloadString(url) == "")
            {
                html = "stream was empty.";
            }
            else
            {
                html = webpage.DownloadString(url);
            }
            HttpClient client = new HttpClient();

            // Get the title of the HTML.
            Console.WriteLine(GetDescription1(html));

            // End.
            Console.ReadLine();
            return (GetDescription1(html));
        }

        static string GetDescription1(string file)
        {
            Match m = Regex.Match(file, @"description\s*(.+?)\s*>");   // description
            Match p = Regex.Match(m.Groups[1].Value, @"content=\s*(.+?)\s*/");
            Console.WriteLine(p.Groups[1].Value);
            if(p.Groups[1].Value == "") //Wenn beschreibung schlecht gemacht wurde
            {
                Match m4 = Regex.Match(file, @"description\s*(.+?)\s*<");   
                Match p4 = Regex.Match(m4.Groups[1].Value, @"content=\s*(.+?)\s*>");
                Console.WriteLine(p.Groups[1].Value);
                //Sonderzeichen:
             String huu2 = p4.Groups[1].Value;


                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(huu2);
                huu2 = Encoding.UTF8.GetString(bytes);

                 
                
                    return huu2;
                
            }
            else
            {
                Console.WriteLine("HUHU_______________________________________________" + p.Groups[1].Value);
                //Sonderzeichen:
                String huu1 = p.Groups[1].Value;
                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(huu1);
                huu1 = Encoding.UTF8.GetString(bytes);
                return huu1;
                
            }
        }
        #endregion Description


        #region Tags
        static public String GetTags(String url)
        {
            // Read in an HTML file.
            var html = "";
            url = urlChecker(url);
            Console.WriteLine("Fangt an mit runterladen von:   " +  url);
            WebClient webpage = new WebClient();
            //  html = webpage.DownloadString(url);
            bool exception = false;
            try
            {
                webpage.DownloadString(url);
            }
            catch (Exception e)
            {
                exception = true;
            }
            finally
            {
                if (!exception)
                {
                    if (webpage.DownloadString(url) == "")
                    {
                        html = "stream was empty.";
                        Console.WriteLine("Download nicht erfolgreich");
                    }
                    else
                    {
                        html = webpage.DownloadString(url);
                        Console.WriteLine("Download erfolgreich");
                    }
                    HttpClient client = new HttpClient();
                    Console.WriteLine("Scan fängt nun an");
                }
            }

         
            // Get the title of the HTML.
         //   Console.WriteLine(GetTags1(html));

            // End.
            Console.ReadLine();
            return (GetTags1(html));
        }

        static string GetTags1(string file)
        {
            //Tags von News_Keywords
            Console.WriteLine("In Scan Funktion");
         //   Console.WriteLine("LOL IDK Hier Webseite: " + file);
            Match m1 = Regex.Match(file, @"news_keywords\s*(.+?)\s*>");
            Console.WriteLine("Kp halt m1 ausgabe" + m1.Groups[1]);
            Match p1 = Regex.Match(m1.Groups[1].Value, @"content=\s*(.+?)\s*/");
            String An = p1.Groups[1].Value;

            // String fin = "@" + An + "\s*(.+?)\s*/" + An;
            String An1 = An.Trim(new Char[] { ' ', '\"', '.' });

            //Anfuhrzeichen "\""
          //  return An1;

            
            //normale Tags nötig
            //Tags von News_Keywords
            Console.WriteLine("In Scan Funktion Tags Normal_______________________________");
            Match m2 = Regex.Match(file, @"keywords\s*(.+?)\s*>");
            Console.WriteLine("Kp halt mq ausgabe" + m1.Groups[1]);
            Match p2 = Regex.Match(m2.Groups[1].Value, @"content=\s*(.+?)\s*/");
            String An2 = p2.Groups[1].Value;

            // String fin = "@" + An + "\s*(.+?)\s*/" + An;
            String An3 = An2.Trim(new Char[] { ' ', '\"', '.' });


            //Normale Tags auch möglich ohne das Zeichen:  / muss enden!



            //Tags von Artikel
            Console.WriteLine("In Scan Funktion Tags Normal_______________________________");
            Match m3 = Regex.Match(file, @"article:tag\s*(.+?)\s*>");
            Console.WriteLine("Kp halt mq ausgabe" + m1.Groups[1]);
            Match p3 = Regex.Match(m3.Groups[1].Value, @"content=\s*(.+?)\s*/");
            String An4 = p3.Groups[1].Value;


            Console.WriteLine("In Scan Funktion Tags Normal_______________________________");
            Match m5 = Regex.Match(file, @"itemprop\s*(.+?)\s*>");
            Console.WriteLine("Kp halt mq ausgabe" + m1.Groups[1]);
            Match p5 = Regex.Match(m5.Groups[1].Value, @"content=\s*(.+?)\s*/");
            String An5 = p5.Groups[1].Value;

            // String fin = "@" + An + "\s*(.+?)\s*/" + An;
            An4 = An4.Trim(new Char[] { ' ', '\"', '.' });
            if(An1 != "" && An3 != "" && An4 != "")
            {
                String An_ALL = An1 + "," + An3 + "," + An4;
                return An_ALL;
            }
            else if( An1 != "" )
            {
                if(An3 != "")
                {
                    return An1 + "," + An3;
                }
                else if(An4 != "")
                {
                    return An1 + "," + An4;
                }
                else
                {
                    return An1;
                }
            }
            else if (An3 != "")
            {
                if (An1 != "")
                {
                    return An1 + "," + An3;
                }
                else if (An4 != "")
                {
                    return An4 + "," + An3;
                }
                else
                {
                    return An3;
                }
            }
            else if (An4 != "")
            {
                if (An3 != "")
                {
                    return An4 + "," + An3;
                }
                else if (An1 != "")
                {
                    return An4 + "," + An1;
                }
                else
                {
                    return An4;
                }
            }
            else
            {
                if(An5 != "")
                {
                    return An5;
                }
                Console.WriteLine("KEINE TAGS GEFUNDEN ____________________________________________________");
                return "";

            }
            // String An_ALL = An1 + "," + An3 + "," + An4;
            //Anfuhrzeichen "\""
            //     return An_ALL;
        }

        #endregion Tags

        #region Title
        static public String GetTitle(String url)
        {
            // Read in an HTML file.
            url = urlChecker(url);
            var html = "";
            WebClient webpage = new WebClient();
            //  html = webpage.DownloadString(url);
            url = url.Replace("https", "http");
            Console.WriteLine("Arbeite an dem Link:   " + url);
            HttpClient client = new HttpClient();
            bool exception = false;

            try
            {
                webpage.DownloadString(url);
            }
            catch (Exception e)
            {
                exception = true;
            }
            finally
            {
                if (!exception)
                {
                    if (webpage.DownloadString(url) == "")
                    {
                        html = "stream was empty.";
                        
                    }
                    else
                    {
                        html = webpage.DownloadString(url);
                    }
                }
            }
            String titl = GetTitle1(html);
            return titl;
        }

        static string GetTitle1(string file)
        {
            Match mTitle = Regex.Match(file, @"<title>\s*(.+?)\s*</title>");   // Klassische Art Titel zu speichern
            Console.WriteLine(mTitle.Groups[1].Value);
            if (mTitle.Groups[1].Value == "") //Wenn kein klassischer titel da ist
            {


                Match mTi1 = Regex.Match(file, @"og:title\s*(.+?)\s*<");
                Match mTi2 = Regex.Match(mTi1.Groups[1].Value, @"content=\s*(.+?)\s*>");
                Console.WriteLine(mTi1.Groups[1].Value);
                //Sonderzeichen:
                String Title2 = mTi2.Groups[1].Value;

                if (Title2 != "")
                {
                    byte[] bytes = Encoding.GetEncoding(1252).GetBytes(Title2);
                    Title2 = Encoding.UTF8.GetString(bytes);
                    return Title2;
                }
                else
                { //Nehme nun den Titel von Soziale Platformen
                    Match mTi3 = Regex.Match(file, @"og:site_name\s*(.+?)\s*<");
                    Match mTi4 = Regex.Match(mTi3.Groups[1].Value, @"content=\s*(.+?)\s*>");
                    Console.WriteLine(mTi4.Groups[1].Value);
                    String Title3 = mTi4.Groups[1].Value;
                    
                    
                    if(Title3 != "")
                    {
                        //Sonderzeichen:
                        byte[] bytes = Encoding.GetEncoding(1252).GetBytes(Title3);
                        Title3 = Encoding.UTF8.GetString(bytes);
                        return Title3;
                    }
                    else
                    {
                        return ""; //Kein Titel Gefunden
                    }
                }

            }
            else
            {
                Console.WriteLine("HUHU_______________________________________________" + mTitle.Groups[1].Value);
                //Sonderzeichen:
                String huuTitle = mTitle.Groups[1].Value;
                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(huuTitle);
                huuTitle = Encoding.UTF8.GetString(bytes);
                return huuTitle;

            }
        }
        #endregion Title


    }
}
