using System;
using RestSharp;
using Newtonsoft.Json;

namespace RagatNepal
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        // public DateTime DateOfBirth { get; set; }
    }

    public class Data
    {
        public Person[] data { get; set; }
    }
    class Program
    {
        private static async void GetPersonsFromApiAsync(string apiUrl)
        {

            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var body = new { key = "5485FE5759545A4A", address = "Rupand", group = "B+" };
            request.AddJsonBody(body);
            RestResponse response = client.Post(request);
            // Console.WriteLine(response.Content.ToString());
            // var json = response.Content.ReadAsStringAsync<Data>().Result;

            var data = JsonConvert.DeserializeObject<Data>(response.Content);
            foreach (var item in data.data)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Blood Group: {item.BloodGroup}");
                Console.WriteLine($"Address: {item.Address}");
            }

        }
        public static void Main(String[] args)
        {
            string remoteUrl = string.Format("https://ragatnepal.com/api/donor.php");
            Console.WriteLine(@"
██████╗░░█████╗░░██████╗░░█████╗░████████╗  ███╗░░██╗███████╗██████╗░░█████╗░██╗░░░░░
██╔══██╗██╔══██╗██╔════╝░██╔══██╗╚══██╔══╝  ████╗░██║██╔════╝██╔══██╗██╔══██╗██║░░░░░
██████╔╝███████║██║░░██╗░███████║░░░██║░░░  ██╔██╗██║█████╗░░██████╔╝███████║██║░░░░░
██╔══██╗██╔══██║██║░░╚██╗██╔══██║░░░██║░░░  ██║╚████║██╔══╝░░██╔═══╝░██╔══██║██║░░░░░
██║░░██║██║░░██║╚██████╔╝██║░░██║░░░██║░░░  ██║░╚███║███████╗██║░░░░░██║░░██║███████╗
╚═╝░░╚═╝╚═╝░░╚═╝░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░  ╚═╝░░╚══╝╚══════╝╚═╝░░░░░╚═╝░░╚═╝╚══════╝

        ");
            GetPersonsFromApiAsync(remoteUrl);
        }
    }
}