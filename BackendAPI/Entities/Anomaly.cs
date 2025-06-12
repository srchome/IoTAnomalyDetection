namespace BackendAPI.Entities
{
    public class Anomaly
    {
        public int Id { get; set; }
        public string SensorId { get; set; }
        public float Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
