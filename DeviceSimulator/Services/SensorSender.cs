using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeviceSimulator.Services
{
    public class SensorSender
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public SensorSender(string apiUrl)
        {
            _httpClient = new HttpClient();
            _apiUrl = apiUrl;
        }

        public async Task SendReadingAsync()
        {
            //var sensorIds = new[] { "sensor-A", "sensor-B", "sensor-C" };
            var sensorIds = new[] { "SensorA", "SensorB", "SensorC", "SensorD", "SensorE", "SensorF", "SensorG" };

            var rand = new Random();

            while (true)
            {
                foreach (var sensorId in sensorIds)
                {
                    var payload = new
                    {
                        Value = Math.Round(20 + rand.NextDouble() * 10, 2),
                        SensorId = sensorId
                    };

                    try
                    {
                        var response = await _httpClient.PostAsJsonAsync(_apiUrl, payload);
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"✅ Sent from {sensorId}: {payload.Value} → Response: {result}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error sending from {sensorId}: {ex.Message}");
                    }
                }

                await Task.Delay(2000); // 2-second pause between rounds
            }
        }
    }

}
