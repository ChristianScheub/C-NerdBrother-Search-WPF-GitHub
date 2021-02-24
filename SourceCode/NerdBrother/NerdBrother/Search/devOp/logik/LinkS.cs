using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using NerdBrother.Assi.Befehle.ExternalInfo;
using Suche;

public class LinkS
{
    public static List<String> GetLinksFromWebsite(string htmlSource)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(htmlSource);
        return doc
            .DocumentNode
            .SelectNodes("//a[@href]")
            .Select(node => node.Attributes["href"].Value)
            .ToList();
    }
    string GetLinks1(string file) //
    {
        //      Match mLinks1 = Regex.Match(file, (?<="href" =).*$  // erster Link

        Match mLinks = Regex.Match(file, @"href=\s*(.+?)\s*/>");   // erster Link
        Console.WriteLine(mLinks.Groups[0].Value);


        if (mLinks.Groups[1].Value == "") //Wenn kein klassischer titel da ist
        {
            Console.WriteLine("Keine Links gefunden!!");
            return "";
        }
        else
        {
            Console.WriteLine("LINKS ???_______________________________________________" + mLinks.Groups[1].Value);
            //Sonderzeichen:
            String huuTitle = mLinks.Groups[1].Value;
            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(huuTitle);
            huuTitle = Encoding.UTF8.GetString(bytes);
            return huuTitle;

        }
    }

    
}
