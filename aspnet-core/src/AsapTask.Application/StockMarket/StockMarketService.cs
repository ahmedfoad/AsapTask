using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using AsapTask.Models;
using AsapTask.Polygon;
using AsapTask.Polygon.Dto;
using Volo.Abp.Emailing;

namespace AsapTask.StockMarket
{
    public class StockMarketService : IStockMarketService
    {
        public IPolygonService _polygonService;
        private readonly IEmailSender _emailSender;
      
        public StockMarketService(IPolygonService polygonService, IEmailSender emailSender)
        {
            _polygonService = polygonService;
            _emailSender = emailSender;
        }
        public async Task FetchMarketStockData()
        {
            // Replace 'your-api-key' with your actual API key from Polygon.io
            string apiKey = "wr63AcU4dmhdZhYTyyyu_tnjKlWIOIqA";
            string ticker = "AAPL"; // The stock symbol you want to fetch data for
            string baseUrl = "https://api.polygon.io/v1/open-close";

            // Construct the URL with parameters
            string url = $"https://api.polygon.io/v1/open-close/{ticker}/2023-01-09?adjusted=true&apiKey={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);

                        // Deserialize JSON data into StockData object
                        PolygonDataDto polygonDataDto = JsonConvert.DeserializeObject<PolygonDataDto>(responseBody);

                        // Print properties of the StockData object
                        Console.WriteLine($"Status: {polygonDataDto.Status}");
                        Console.WriteLine($"From: {polygonDataDto.From}");
                        Console.WriteLine($"Symbol: {polygonDataDto.Symbol}");
                        Console.WriteLine($"Open: {polygonDataDto.Open}");
                        Console.WriteLine($"High: {polygonDataDto.High}");
                        Console.WriteLine($"Low: {polygonDataDto.Low}");
                        Console.WriteLine($"Close: {polygonDataDto.Close}");
                        Console.WriteLine($"Volume: {polygonDataDto.Volume}");
                        Console.WriteLine($"After Hours: {polygonDataDto.AfterHours}");
                        Console.WriteLine($"Pre Market: {polygonDataDto.PreMarket}");

                        // Saving Polygo data into database
                        await _polygonService.CreateAsync(polygonDataDto);


                        await _emailSender.SendAsync(
                            "target@domain.com",     // target email address
                            "Email subject : Summary Result every 6 hours",         // subject
                            "This is email body..." + responseBody // email body
                        );

                    }
                    else
                    {
                        Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}

