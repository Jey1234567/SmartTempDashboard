using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;
using SmartTempDashboard.Models;
using SmartTempDashboard.SignalRHubs;


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
        [HttpGet]
        public async Task<IActionResult> Average3Days()
        {
            //Change the date name from your language to english
            var language = new CultureInfo("en-EN");
            //Get Current Date Format : 5/3/2012 00:00.00000
            var today = DateTime.Today;
            //Get Date in the past 3 days
            var threeDaysAgo = today.AddDays(-3);

            var threeDaysTemp = _context.Temperatures.Where(t => t.Timestamp >= threeDaysAgo && t.Timestamp < today).ToList();

            //Group them based on Days
            var groupDays = threeDaysTemp.GroupBy(t => t.Timestamp.Date).Select(g => new
            {
                day = g.Key.ToString("dddd",language),
                avgtemp = Math.Round(g.Average(t => t.Temp), 1)
            }).ToList();
           

            return Ok(groupDays);
        }


    }
}
