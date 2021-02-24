using Suche;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdBrother.Search.devOp.logik
{
    class neuWebsite
    {
        public static string SeiteBezAdd(String URL2, String Tags, String TitleWebs)
        {

            //Alle Tags aufspalten:
            string[] TagsEinzeln = Tags.Split(',');

            int AnzahlTags = TagsEinzeln.Length + 1;

            if (Tags != "")
            {
                // Datenbank.DB_NewSite(URL2, TitleWebs); //Fuege Webseite hinzu
                for (int i = 0; i < AnzahlTags - 1; i++)
                {
                    //Passiert pro tAG
                    string b_Tag = TagsEinzeln[i];
                    string b_Tag1 = System.Text.RegularExpressions.Regex.Replace(b_Tag, @"\s", "");
                    b_Tag1 = b_Tag1.Replace("\"", string.Empty);
                    Console.WriteLine("Suche nach dem Tag: " + b_Tag + "   Anzahl im Array: " + i);
                    //  String tmp = "l";
                    String zeichen1 = "\"";
                    //SUCHE IN DB jetzt
                    int[] typID = Datenbank.TagID(b_Tag1);


                    if (typID[0] == 0)
                    {
                        Console.WriteLine("Typ ID ist: " + typID[1]);


                        int WebseiteID = Datenbank.DB_WebsiteID(URL2); //Bekomme ID der Webseite wg Beziehung
                                                                       //Beziehung erstellen
                        Datenbank.DB_Beziehung(typID[1], WebseiteID);

                        //Problem bei Webseite ID abrufen, rest funktioniert!!!!!!!!!

                    }
                    else
                    {
                        //Tag nicht gefunden
                        Datenbank.TagAdd(b_Tag1);
                    }

                }

                return "Alles gut gelaufen";
            }
            // Console.WriteLine("Done.");
            //  Console.WriteLine("WUHUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU:   " + hi);
            //  String query = "SELECT Art.TypName  Art.ID_Typ FROM Art WHERE Art.TypName =" + b_Tag + ";";

            else
            {
                // textBox1.Text = " KEINE TAGS GEFUNDEN!!!!!!!!";
                return "KEINE TAAAAGS GEFUNDEN!!!!!!";
            }
            // Wenn Fertig hinzufuegen, nach Urls suchen, dann den gleichen shiat machen
        }
    }
}
