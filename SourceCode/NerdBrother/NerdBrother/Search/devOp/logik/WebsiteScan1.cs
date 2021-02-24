using NerdBrother.Search.devOp.logik;
using Suche;
using System;
using System.Windows.Forms;

internal class WebsiteScan
{


    public static void hinzu(String URL)
    {
        Console.WriteLine("Der Link zu dem gesucht wird: " + URL);
        DevForm DevFormm = new DevForm();



        DevForm f1 = (DevForm)Application.OpenForms["DevForm"];
        TextBox tb = (TextBox)f1.Controls["TextBox1"];
        tb.Text = "Value";
        String Tags = Meta.GetTags(URL);

        Console.WriteLine(Tags);
        string[] TagsEinzeln = Tags.Split(',');
        int AnzahlTags = TagsEinzeln.Length + 1;
    
        Console.WriteLine("Tags gefunden:  " + AnzahlTags.ToString());
        String TitleWeb = "HUHU Test1";

        URL = URL.Replace("https", "http");

        if (URL.Equals("#") && URL.Equals("http://#"))
        {
            if (AnzahlTags >= 0)
            {
                if (Meta.GetTitle(URL) != null)
                {
                    TitleWeb = Meta.GetTitle(URL);
                    String BobMarley = neuWebsite.SeiteBezAdd(URL, Tags, TitleWeb);
                }
            }
            else
            {
                Console.WriteLine("Gab eh keine Tags LOOOL");
            }

        }
    }
}