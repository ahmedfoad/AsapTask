using StockMarketService.Model;
using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace StockMarketService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StockMarketService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StockMarketService.svc or StockMarketService.svc.cs at the Solution Explorer and start debugging.
    public class StockMarketService : IStockMarketService
    {
        // Timer object to schedule the background process
        private Timer timer;


        // Constructor
        public StockMarketService()
        {
            // Call TimerCallbackAsync method immediately
            TimerCallbackAsync(null);

            // Initialize the timer with the desired interval (6 hours)
            TimeSpan interval = TimeSpan.FromHours(6);
            timer = new Timer(TimerCallbackAsync, null, TimeSpan.Zero, interval);
        }

        // Method to be executed by the timer at regular intervals
        private async void TimerCallbackAsync(object state)
        {
            // Call the method you want to run in the background
            var polygonDataDto = await FetchMarketStockDataAsync();

            // Check if result is not null
            if (polygonDataDto != null)
            {
                // Call Polygon API
                await CallPolygonApiAsync(polygonDataDto);
            }
        }

        public async Task CallPolygonApiAsync(PolygonDataDto data)
        {
            // API URL
            string apiUrl = "https://localhost:44360/api/app/polygon";

            // Serialize the data object to JSON
            string jsonData = JsonConvert.SerializeObject(data);

            // Create HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Create HttpContent for the JSON data
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Post data to the API
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Data posted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to post data. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while posting data: {ex.Message}");
                }
            }
        }

        public async Task<PolygonDataDto> FetchMarketStockDataAsync()
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

                        return polygonDataDto;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return null;
                }
            }
        }

    }
}
