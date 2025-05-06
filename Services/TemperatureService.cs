using Microsoft.AspNetCore.SignalR;
using SmartTempDashboard.SignalRHubs;
using SmartTempDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SmartTempDashboard.Services
{
    public class TemperatureService
    {
    private readonly TemperatureDBContext _context;
    private readonly IHubContext<ChartHub> _hubContext;

    public TemperatureService(TemperatureDBContext context, IHubContext<ChartHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;

    }
    public async Task<bool> SaveTemperatureAsync(Temperature temp)
    {
        if (temp == null)
            return false;
        if (temp.Timestamp == DateTime.MinValue)
        {
            temp.Timestamp = DateTime.UtcNow;
        }

        //Delete old data
        var DataOlderThan3Days = DateTime.UtcNow.AddDays(-3);
        var oldData = _context.Temperatures.Where(t => t.Timestamp < DataOlderThan3Days);
        _context.Temperatures.RemoveRange(oldData);
        _context.Temperatures.Add(temp);
        await _context.SaveChangesAsync();

        //Sending to SignalRClients
        await _hubContext.Clients.All.SendAsync("ReceiveTemperature", temp);

        return true;
    }
    public async Task<List<Temperature>> GetAllData()
    {
        return await _context.Temperatures.ToListAsync();
    }
    public async Task<List<object>> GetAverage3DaysAsync()
    {
            try
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
                    day = g.Key.ToString("dddd", language),
                    avgtemp = Math.Round(g.Average(t => t.Temp), 1)
                }).Cast<object>().ToList();


                return groupDays;
            }
            catch
            {
                throw;
            }
        }
    }
}
