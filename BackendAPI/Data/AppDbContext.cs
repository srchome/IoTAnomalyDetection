namespace BackendAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using Shared;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SensorData> SensorData { get; set; }
    }

}
