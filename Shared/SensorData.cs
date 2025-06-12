namespace Shared
{
    public class SensorData
    {
        public int Id { get; set; }
        public string SensorId { get; set; } = string.Empty;
        public float Value { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsAnomaly { get; set; }
    }
}
