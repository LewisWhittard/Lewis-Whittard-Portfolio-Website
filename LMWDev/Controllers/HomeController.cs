using LMWDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using UIFactory.Strategy.Interface;

namespace LMWDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUIFactoryStrategy _uIFactoryStrategy;
        private readonly IHttpClientFactory _httpClientFactory;


        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            // Use UIavtoryAPIController defaulttest
            var client = _httpClientFactory.CreateClient();
            //getlocalURl


            HttpResponseMessage response = await client.GetAsync($"{Request.Scheme}://{Request.Host}/api/UIFactoryStrategyAPI/default/test");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody); // Should print "Test"
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return View(null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
