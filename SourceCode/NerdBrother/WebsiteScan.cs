using System;

public class WebsiteScan
{
    public WebsiteScan()
    {
    }

    public static void hinzu(String URL)
    {
        // lol

        Console.WriteLine("Der Link zu dem gesucht wird: " + URL);
        String Tags = Meta.GetTags(URL);
        Console.WriteLine(Tags);
        string[] TagsEinzeln = Tags.Split(',');
        int AnzahlTags = TagsEinzeln.Length + 1;
        Console.WriteLine("Tags gefunden:  " + AnzahlTags.ToString());

        // String BobMarley = Main.SeiteBezAdd(URL2, Tags, TitleWeb);


    }
}
