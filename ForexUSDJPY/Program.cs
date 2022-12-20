using RestSharp;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public static class ForexClient
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        
        public class ForexData
        {
            public string? close { get; set; }
        }

        public static string ForexDataClient()
        {
            XElement configXML = XElement.Load(@"./Config.xml");
            var rapidapikey = configXML.Elements("General").Elements("X-RapidAPI-Key");

            var client = new RestClient("https://webull.p.rapidapi.com/stock/get-realtime-quote");
            var request = new RestRequest();
            request.AddParameter("tickerId", "913344317");
            request.AddHeader("X-RapidAPI-Key", "6f08843f16mshaf45b1699c913c6p17be52jsn2e29e2aaed78");
            request.AddHeader("X-RapidAPI-Host", "webull.p.rapidapi.com");

            var price = client.Get<ForexData>(request).close;

            return price;
        }

       public static void parseConfigXML()
        {

        }
    }


}