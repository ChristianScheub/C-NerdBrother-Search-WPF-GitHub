using NerdBrother;
using NerdBrother.Search.devOp.logik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suche
{
    public partial class DevForm : Form
    {

        public DevForm()
        {
            InitializeComponent();
        }
        private void button_Des_Click(object sender, EventArgs e)
        {
            Console.WriteLine("GEKLICCCCCCCCCCCCK BUTTON");

            /* Main Haupt = new Main();
            Haupt.DevBesch(); */
            Console.WriteLine("Der Link zu dem gesucht wird: " + textBox_url.Text);
            String BobMarley = "";

            String URL2 = textBox_url.Text;


                if ('h' == URL2.FirstOrDefault())
                {
                    Console.WriteLine(URL2);
                    //Habe neuer Link:
                    //      Match mLinks = Regex.Match(URL2, @"http://www.\s*(.+?)\s*/");
                    var item1 = URL2;
                    if ('/' == URL2.FirstOrDefault() && '/' == URL2[1])
                    {
                        item1 = item1.Remove(0, 1);
                    }
                    else if ('/' == URL2.FirstOrDefault())
                    {
                        item1 = item1.Remove(0, 1);
                    }
                    Console.WriteLine("Link der gerade gedownloaded wurde: " + item1);
                Console.WriteLine("Er war ohne http, es wurde manuel hinzugefügt! ");
                    Console.WriteLine(item1);
                    //Habe neuer Link:
                    //    Thread.Sleep(5000);
                    hinzu(item1);
                }
                else
                {
                    Console.WriteLine(URL2);
                    //Habe neuer Link:
                    var item1 = URL2;
                    if (URL2.Length > 1)
                    {


                        if ('/' == URL2.FirstOrDefault() && '/' == URL2[1])
                        {
                            item1 = item1.Remove(0, 2);
                        }
                        else if ('/' == URL2.FirstOrDefault())
                        {
                            item1 = item1.Remove(0, 1);
                        }
                        Match mLinks = Regex.Match(URL2, @"http://www.\s*(.+?)\s*/");
                        if (mLinks.Groups[1].Value.Equals(""))
                        {
                            mLinks = Regex.Match(URL2, @"https://www.\s*(.+?)\s*/");
                        }
                        item1 = "http://www." + mLinks.Groups[1].Value + '/' + item1;
                    Console.WriteLine("Link der gerade gedownloaded wurde: " + item1);
                    Console.WriteLine("Er war mit HTTP, normal gearbeitet");
                        Console.WriteLine(item1 + "___________________________________________________________________");
                        //Habe neuer Link:
                        //  Thread.Sleep(5000);  WEGEN ANZEIGE
                        hinzu(item1);
                    }
                }

                /*
            String Tags = Meta.GetTags(URL2);
            Console.WriteLine(Tags);


            string[] TagsEinzeln = Tags.Split(',');
            int AnzahlTags = TagsEinzeln.Length + 1;
            label5.Text = AnzahlTags.ToString();
            textBox1.Text = Tags;

    */

            if(checkBox_folgeLinks.Checked == true)
            {
                Log LogScreen = new Log();
                LogScreen.Show();
                LogScreen.Main2(URL2);
            }
                textBox1.Text = textBox1.Text + BobMarley;
               

            //Seite scannen nach Links
        }


        public void hinzu(String URL)
        {
            //  Log1.Show();
            Console.WriteLine("Der Link zu dem gesucht wird: " + URL);
            DevForm DevFormm = new DevForm();


            Console.WriteLine("________________________________________________________NEUE SEITE_________   ");
            Console.WriteLine("Der Link zu dem gesucht wird ist:   " + URL);

            String Tags = Meta.GetTags(URL);
            Console.WriteLine("Tags die gefunden wurden:   " + Tags + "   ");
            Console.WriteLine(Tags);
            string[] TagsEinzeln = Tags.Split(',');
            int AnzahlTags = TagsEinzeln.Length + 1;
            Console.WriteLine("Tags gefunden:  " + AnzahlTags.ToString());

            Console.WriteLine("Tags gefunden:  " + AnzahlTags.ToString());
            String TitleWeb = "HUHU Test1";

      //      String TitleWeb1 = TitleWeb.Replace(' ', ',');

            URL = URL.Replace("https", "http");

            if (!URL.Equals("#") && !URL.Equals("http://#"))
            {
                if (AnzahlTags > 2)
                {
                    if (Meta.GetTitle(URL) != null)
                    {
                        TitleWeb = Meta.GetTitle(URL);
                        Datenbank.DB_NewSite(URL, TitleWeb); //Fuege Webseite hinzu

                        String TitleWeb1 = TitleWeb.Replace(' ', ',');
                        Tags = Tags + ',' + TitleWeb1;
                        String BobMarley = neuWebsite.SeiteBezAdd(URL, Tags, TitleWeb);
                        MessageBox.Show("Link hinzugefügt!");
                    }
                    else
                    {
                        TitleWeb = textBox2.Text;
                        String TitleWeb1 = TitleWeb.Replace(' ', ',');
                        Tags = Tags + ',' + TitleWeb1;
                        Datenbank.DB_NewSite(URL, TitleWeb); //Fuege Webseite hinzu
                        String BobMarley = neuWebsite.SeiteBezAdd(URL, Tags, TitleWeb);
                        MessageBox.Show("Link hinzugefügt!");
                    }
                }
                else
                {
                    Console.WriteLine("Gab eh keine Tags LOOOL");
                    Console.WriteLine("Gab eh keine Tags LOOOL");
                    MessageBox.Show("NICHT HINZUUUGEFÜÜGT");
                }

            }
        }
        private void button_title_Click(object sender, EventArgs e)
        {
            textBox2.Text = Meta.GetTitle(textBox_url.Text);
        } //Button: Holt den Titel der Webseite
        private void button_Add_Click(object sender, EventArgs e)
        {
            Console.WriteLine("GEKLICCCCCCCCCCCCK BUTTON zum hinzufügen");
            Console.WriteLine("Der Link zu dem gesucht wird: " + textBox_url.Text);
            String BobMarley = "";
            String URL2 = textBox_url.Text;
            Console.WriteLine("Link ist in Variable; " +URL2);

            if ('h' == URL2.FirstOrDefault())
            {
                //Habe neuer Link:
                //      Match mLinks = Regex.Match(URL2, @"http://www.\s*(.+?)\s*/");
                var item1 = URL2;
                if ('/' == URL2.FirstOrDefault() && '/' == URL2[1])
                {
                    item1 = item1.Remove(0, 1);
                }
                else if ('/' == URL2.FirstOrDefault())
                {
                    item1 = item1.Remove(0, 1);
                }
                Console.WriteLine("Link der gerade gedownloaded wurde: " + item1);
                Console.WriteLine("Er war ohne http, es wurde manuel hinzugefügt! ");
                Console.WriteLine(item1);
                //Habe neuer Link:
                //    Thread.Sleep(5000);
                hinzu(item1);
            }
            else
            {
                //Habe neuer Link:
                var item1 = URL2;
                if (URL2.Length > 1)
                {


                    if ('/' == URL2.FirstOrDefault() && '/' == URL2[1])
                    {
                        item1 = item1.Remove(0, 2);
                    }
                    else if ('/' == URL2.FirstOrDefault())
                    {
                        item1 = item1.Remove(0, 1);
                    }
                    Match mLinks = Regex.Match(URL2, @"http://www.\s*(.+?)\s*/");
                    if (mLinks.Groups[1].Value.Equals(""))
                    {
                        mLinks = Regex.Match(URL2, @"https://www.\s*(.+?)\s*/");
                    }
                    item1 = "http://www." + mLinks.Groups[1].Value + '/' + item1;
                    Console.WriteLine("Link der gerade gedownloaded wurde: " + item1);
                    Console.WriteLine("Er war mit HTTP, normal gearbeitet");
                    Console.WriteLine(item1 + "___________________________________________________________________");
                    //Habe neuer Link:
                    //  Thread.Sleep(5000);  WEGEN ANZEIGE
                    hinzu(item1);
                }
            }

            /*
        String Tags = Meta.GetTags(URL2);
        Console.WriteLine(Tags);


        string[] TagsEinzeln = Tags.Split(',');
        int AnzahlTags = TagsEinzeln.Length + 1;
        label5.Text = AnzahlTags.ToString();
        textBox1.Text = Tags;

*/

            if (checkBox_folgeLinks.Checked == true) //Es wird auch nach FolgeLinks gesucht
            {
                Log LogScreen = new Log();
                LogScreen.Show();
                LogScreen.Main2(URL2);
            }
            textBox1.Text = textBox1.Text + BobMarley;


            //Seite scannen nach Links
        } //Button: diese Webseite hinzufügen; regelt auchd es mit HTTP dass alle Webseiten gehen
        private void textBox_url_DoubleClick(object sender, EventArgs e)
        {
            textBox_url.Text = "";
        } //Checkbox: Um die Link Box leer zu machen
    }
}
