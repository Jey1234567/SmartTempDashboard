using Microsoft.AspNetCore.SignalR;
using SmartTempDashboard.Models;
namespace SmartTempDashboard.SignalRHubs
{
    public class ChartHub : Hub
    {
        public async Task UpdateData(Temperature temp)
        {
            await Clients.All.SendAsync("ReceiveTemperature", temp);
        }
    }
}