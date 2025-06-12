// DeviceSimulator/Program.cs
using DeviceSimulator.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var apiUrl = "http://localhost:5023/api/sensor"; // Your API endpoint
        var sender = new SensorSender(apiUrl);

        var rand = new Random();

        while (true)
        {
            float value = (float)Math.Round(rand.NextDouble() * 100, 2);
            await sender.SendReadingAsync();

            await Task.Delay(2000); // Send every 2 seconds
        }
    }
}
