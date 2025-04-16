using Microsoft.EntityFrameworkCore;
namespace SmartTempDashboard.Models
{
    public class TemperatureDBContext: DbContext
    {
        public DbSet<Temperature> Temperatures { get; set; }
        public TemperatureDBContext(DbContextOptions<TemperatureDBContext> options) : base(options)
        {

        }
    }
}
