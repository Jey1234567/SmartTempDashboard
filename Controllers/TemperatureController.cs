using Microsoft.AspNetCore.Mvc;
using SmartTempDashboard.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmartTempDashboard.Controllers.Api
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureDBContext _context;
        public TemperatureController(TemperatureDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> TemperaturePost(Temperature temp)
        {
            temp.Timestamp = DateTime.UtcNow;
            _context.Temperatures.Add(temp);
            await _context.SaveChangesAsync();

            //Returns the booking (as JSON) along with a 200 OK status code.
            return Ok();
        }
        [HttpGet]
        public IActionResult GetData()
        {
            var data =  _context.Temperatures.ToList(); 
            return Ok(data);
        }
       
    }
}
