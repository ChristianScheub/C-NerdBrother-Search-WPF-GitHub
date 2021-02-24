using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;
using NerdBrother.Search.devOp.logik;
using Suche;

namespace NerdBrother
{
    public partial class Log : Form
    {
        int hu = 0;
        public Log(){InitializeComponent();}

        public void addText(String BobMarley){textBox1.Text = BobMarley + "  " + textBox1.Text;}
        public string urlChecker (String URL3)
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

        public void hinzu(String URL)
        {
          //  Log1.Show();
            Console.WriteLine("Der Link zu dem gesucht wird: " + URL);
            DevForm DevFormm = new DevForm();

            
            addText("________________________________________________________NEUE SEITE_________   ");
            addText("Der Link zu dem gesucht wird ist:   " + URL);
 
            String Tags = Meta.GetTags(URL);
            addText("Tags die gefunden wurden:   " + Tags + "   ");
            Console.WriteLine(Tags);
            string[] TagsEinzeln = Tags.Split(',');
            int AnzahlTags = TagsEinzeln.Length + 1;
            addText("Tags gefunden:  " + AnzahlTags.ToString());
           
            Console.WriteLine("Tags gefunden:  " + AnzahlTags.ToString());
            String TitleWeb = "HUHU Test1";

            URL = URL.Replace("https", "http");

            if (!URL.Equals("#") && !URL.Equals("http://#"))
            {
                if (AnzahlTags > 2)
                {
                    if (Meta.GetTitle(URL) != null)
                    {
                        TitleWeb = Meta.GetTitle(URL);
                        String TitleWeb2 = TitleWeb.Replace('.', ',');
                        String TitleWeb1 = TitleWeb.Replace(' ', ',');
                        Tags = Tags + ',' + TitleWeb1;
                        Datenbank.DB_NewSite(URL, TitleWeb); //Fuege Webseite hinzu
                        String BobMarley = neuWebsite.SeiteBezAdd(URL, Tags, TitleWeb);
                    }
                }
                else
                {
                    addText("Gab eh keine Tags LOOOL");
                    Console.WriteLine("Gab eh keine Tags LOOOL");
                }

            }
        }

        public void Main2(String URL2)
        {
            Log DevFormm = new Log();
            URL2 = urlChecker(URL2);
            using (var client = new WebClient())
            {
                addText("WebClient startet arbeit für:  " + URL2);
                var htmlSource = client.DownloadString(URL2);
                foreach (var item in GetLinksFromWebsite(htmlSource))
                {
                    // TODO: you could easily write a recursive function
                    // that will call itself here and retrieve the respective contents
                    // of the site ...
                    if (item != null)
                    {
                        if ('h' == item.FirstOrDefault())
                        {
                            Console.WriteLine(item);
                            //Habe neuer Link:
                            //      Match mLinks = Regex.Match(URL2, @"http://www.\s*(.+?)\s*/");
                            var item1 = item;
                            if ('/' == item.FirstOrDefault() && '/' == item[1])
                                {
                                item1 = item1.Remove(0, 1);
                            }
                            else if ('/' == item.FirstOrDefault())
                            {
                                item1 = item1.Remove(0, 1);
                            }
                            addText("Link der gerade gedownloaded wurde: " + item1);
                            addText("Er war ohne http, es wurde manuel hinzugefügt! ");
                            Console.WriteLine(item1);
                            //Habe neuer Link:
                        //    Thread.Sleep(5000);
                            hinzu(item1);
                        }
                        else
                        {
                            Console.WriteLine(item);
                            //Habe neuer Link:
                            var item1 = item;
                            if (item.Length > 1)
                            {


                                if ('/' == item.FirstOrDefault() && '/' == item[1])
                                {
                                    item1 = item1.Remove(0, 2);
                                }
                                else if('/' == item.FirstOrDefault())
                                {
                                    item1 = item1.Remove(0, 1);
                                }
                                Match mLinks = Regex.Match(URL2, @"http://www.\s*(.+?)\s*/");
                                if (mLinks.Groups[1].Value.Equals(""))
                                {
                                    mLinks = Regex.Match(URL2, @"https://www.\s*(.+?)\s*/");
                                }
                                item1 = "http://www." + mLinks.Groups[1].Value + '/' + item1;
                                addText("Link der gerade gedownloaded wurde: " + item1);
                                addText("Er war mit HTTP, normal gearbeitet");
                                Console.WriteLine(item1 + "___________________________________________________________________");
                                //Habe neuer Link:
                                //  Thread.Sleep(5000);  WEGEN ANZEIGE
                                hinzu(item1);
                            }
                        }
                    }

                }
            }
        }


        public static List<String> GetLinksFromWebsite(string htmlSource)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlSource);
            return doc
                .DocumentNode
                .SelectNodes("//a[@href]")
                .Select(node => node.Attributes["href"].Value)
                .ToList();
        }
    }
}
