using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using SmartTempDashboard.Models;
using Newtonsoft.Json;

namespace SmartTempDashboard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    Uri baseAddress = new Uri("http://192.168.xxx.xx:xxxx/api");
    private readonly HttpClient _client;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _client = new HttpClient();
        _client.BaseAddress = baseAddress;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Temperature> temp = new List<Temperature>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/temperature/getdata");
        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Data = "Failed to Catch data from API";
            return View();
        }
        var json = await response.Content.ReadAsStringAsync();
        temp = JsonConvert.DeserializeObject<List<Temperature>>(json);

        return View("Index", temp);
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
