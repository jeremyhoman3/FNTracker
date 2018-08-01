using System;
//using static System.Object;
using System.Net.Http;
using System.IO;

namespace FNTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Epic Username");
            //request username 
            string username = Console.ReadLine();
            Console.write(username);
            GetData();
            Console.ReadLine();
            Console.ReadKey();
        }

        // https://api.fortnitetracker.com/v1/profile/{platform}/{epic-nickname}
        static async void GetData()
        {
            string baseUrl = "https://api.fortnitetracker.com/v1/profile/xbl/Grindelwald83/";
            HttpClient HttpClient = new HttpClient();

            // add api key to the header
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,baseUrl);
            request.Headers.Add("TRN-Api-Key", "7d243ebf-945c-4140-905a-58df3c8e56ba");

            //send and response
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            HttpContent content = response.Content;
            
            string data = await content.ReadAsStringAsync();
                   
                 if (data != null)
                {
                    Console.WriteLine(data);
                    // save to DB
                    // Look into deserialization

                    //write something to check file path, if file exists add
                    string path = @"C:\Users\jhoman\Documents\Code\FNStats\test.json";
                    File.WriteAllText(path,data);
                    Console.WriteLine("File saved correctly");

                }
        }
    }
}
