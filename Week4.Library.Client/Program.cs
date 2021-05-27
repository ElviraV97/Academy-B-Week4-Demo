using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Week4.Library.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Books HttpClient Sample ===");

            HttpClient client = new();

            #region GET REQUEST

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44304/book")
            };

            HttpResponseMessage response = client.SendAsync(httpRequest).Result;

            //(response.StatusCode == System.Net.HttpStatusCode.OK)
            if (response.IsSuccessStatusCode)
            {
                // mi occupo di leggere i dati dal body
                string jsonData = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<BookContract>>(jsonData);

                foreach (var item in result)
                    Console.WriteLine($"[{item.ISBN}] {item.Title}");

            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // non trovato ...
            }
            else
            {
                // altri casi di non successo ...
            }

            #endregion

            #region POST REQUEST

            HttpRequestMessage httpPostRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44304/book")
            };

            BookContract payload = new BookContract 
            { 
                ISBN = "2021-090807-111",
                Title = "Il Ritorno del Re",
                Author = "Sempre Lui",
                Summary = "Il solito"
            };
            string json = JsonConvert.SerializeObject(payload);
            httpPostRequest.Content = new StringContent(json,
                Encoding.UTF8, "application/json");

            HttpResponseMessage postResponse = client.SendAsync(httpPostRequest).Result;

            if (postResponse.IsSuccessStatusCode)
            {
                // mi occupo di leggere i dati dal body
                string jsonData = postResponse.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<BookContract>(jsonData);
                Console.WriteLine();
                Console.WriteLine($"[{result.ISBN}] {result.Title} - SAVED!");
            }

            #endregion
        }
    }
}
