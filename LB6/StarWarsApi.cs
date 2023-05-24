using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace LB6
{
    public class StarWarsApi
    {

        public void GetRandomSwCharacter()
        {
            string randomCharacterUrl = $"https://swapi.dev/api/people/{new Random().Next(1, 83)}";
            RequestData(randomCharacterUrl);
        }

        private async void RequestData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();
                        FileStream fs = File.Create("character.json");
                        byte[] responseBytes = Encoding.ASCII.GetBytes(responseJson);
                        await fs.WriteAsync(responseBytes, 0, responseJson.Length);
                        fs.Close();
                    }
                    else
                    {
                        throw new Exception("Request failed: Character not found");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}