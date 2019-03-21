using EplanService.SimpleClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EplanService.SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:28080/";

            using (HttpClient client = GetHttpClient(baseAddress))
            {
                EplanServiceRequest request = new EplanServiceRequest
                {
                    Action = "Test Action",
                    ProjectName = "Test Project",
                    Parameters = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("TagId", "Tag-Simple"),
                        new KeyValuePair<string, string>("PortNumber", "Port-Simple")
                    }
                };

                Task<HttpResponseMessage> serviceResponse = client.PostAsJsonAsync("api/EplanService/SearchProject", request);
                serviceResponse.Wait();
                HttpResponseMessage response = serviceResponse.Result;

                if (!response.IsSuccessStatusCode) {
                    Console.WriteLine(string.Format("Error with [{0}]", response.ReasonPhrase));

                    return;
                }

                Console.WriteLine("Successfully executed with EplanServiceRequest = [{0}]", request);

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }

        private static HttpClient GetHttpClient(string baseAddress)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
