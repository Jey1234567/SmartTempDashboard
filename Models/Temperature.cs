using System.ComponentModel.DataAnnotations;

namespace SmartTempDashboard.Models
{
    public class Temperature
    {
        [Key]
        public int Id { get; set; }

        public float Temp { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
