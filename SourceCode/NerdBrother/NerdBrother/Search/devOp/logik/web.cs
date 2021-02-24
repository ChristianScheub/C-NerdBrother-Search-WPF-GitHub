using System;
using System.Net;

namespace NerdBrother.Assi.Befehle.ExternalInfo
{
    class web
    {
        public string html(string link)
        {
            var html = "";
            WebClient webpage = new WebClient();
            //  html = webpage.DownloadString(url);


            try
            {

                if (webpage.DownloadString(link) == "")
                {
                    html = "stream was empty.";
                }
                else
                {
                    html = webpage.DownloadString(link);
                }
                Console.WriteLine("Verusch 1: " + html);

            }
            catch (InvalidOperationException exception) { Console.WriteLine("ERROR 01: Netzwerkverbindung notwendig."); html = "ERROR 01: Netzwerkverbindung notwendig."; }
            return html;
        }
        
    }
}
