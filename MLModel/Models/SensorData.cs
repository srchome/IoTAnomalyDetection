namespace MLModel.Models;

public class SensorData
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public float Value { get; set; }
    public bool IsAnomaly { get; set; }
}