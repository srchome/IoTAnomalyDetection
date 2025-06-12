using BackendAPI.Data;
using BackendAPI.Hubs;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shared;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly AnomalyDetector _detector;
        private readonly IHubContext<SensorHub> _hub;

        public SensorController(AppDbContext db, AnomalyDetector detector, IHubContext<SensorHub> hub)
        {
            _db = db;
            _detector = detector;
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SensorData data)
        {
            data.IsAnomaly = _detector.Predict(data.Value);

            _db.SensorData.Add(data);
            //await _db.SaveChangesAsync(); //TODO remove to add to db

            await _hub.Clients.All.SendAsync("ReceiveSensorData", data);

            return Ok(data);
        }

        //[HttpGet("test-broadcast")]
        //public async Task<IActionResult> TestBroadcast()
        //{
        //    var data = new SensorData
        //    {
        //        Id = 12,
        //        Value = 123,
        //        IsAnomaly = false,
        //        Timestamp = DateTime.UtcNow
        //    };

        //    await _hub.Clients.All.SendAsync("ReceiveSensorData", data);
        //    return Ok(data);
        //}

    }
}
