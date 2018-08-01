using System;
using System.Net.Http;
using System.IO;

namespace FNTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Epic username for an Xbox user");
            string username = Console.ReadLine();
            GetData(username);
            Console.ReadLine();
            Console.ReadKey();
        }

        static async void GetData(string username)
        {
            // set the URL
            string baseUrl = "https://api.fortnitetracker.com/v1/profile/xbl/";
            string fullUrl = baseUrl + username;
            HttpClient HttpClient = new HttpClient();

            // add api key to the header
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,fullUrl);
            request.Headers.Add("TRN-Api-Key", "7d243ebf-945c-4140-905a-58df3c8e56ba");

            //send and capture response
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            HttpContent content = response.Content;
            
            string data = await content.ReadAsStringAsync();
                   
                 if (data != null)
                {
                // Console.WriteLine(data);

                //create file name based on timestamp
                DateTime date = DateTime.Now;
                string datestring = date.ToString("yyyymmddhhmmss");
                string path = @"C:\Users\jhoman\Documents\Code\FNStats\" + username + "-" + datestring + ".json";

                //write to path
                File.WriteAllText(path,data);
                Console.WriteLine("File saved correctly");

                }
        }
    }
}
