using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;
using SmartTempDashboard.Models;
using SmartTempDashboard.SignalRHubs;
using SmartTempDashboard.Services;


namespace SmartTempDashboard.Controllers.Api
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureDBContext _context;
        private readonly IHubContext<ChartHub> _hubContext;
        private readonly TemperatureService _service;

        public TemperatureController(TemperatureService service, TemperatureDBContext context, IHubContext<ChartHub> hubContext)
        {
            _service = service;
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> TemperaturePost(Temperature temp)
        {

            try
            {
                bool successfull = await _service.SaveTemperatureAsync(temp);

                if (!successfull)
                    return BadRequest("Invalid JSON: 'temp' and 'humid' fields are required.");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "Server error while saving data.",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            try
            {
                var data = await _service.GetAllData();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "Failed to fetch temperature data",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Average3Days()
        {
            try
            {
                var groupDays = await _service.GetAverage3DaysAsync();
                return Ok(groupDays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "Failed to calculate 3-day average",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
        }


    }
}
