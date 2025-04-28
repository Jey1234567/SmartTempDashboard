using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SmartTempDashboard.Models;
using SmartTempDashboard.SignalRHubs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmartTempDashboard.Controllers.Api
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureDBContext _context;
        private readonly IHubContext<ChartHub> _hubContext;

        public TemperatureController(TemperatureDBContext context, IHubContext<ChartHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> TemperaturePost(Temperature temp)
        {
            temp.Timestamp = DateTime.Now;
            _context.Temperatures.Add(temp);
            await _context.SaveChangesAsync();

           
            // Send to SignalR clients
            await _hubContext.Clients.All.SendAsync("ReceiveTemperature", temp);

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
