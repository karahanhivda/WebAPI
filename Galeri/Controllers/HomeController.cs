using Galeri.Data;
using Galeri.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace Galeri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync<List<Araba>>("http://localhost:5064/api/Araba/Arabalar"));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Araba araba)
        {

            return View(await _httpClient.PostAsJsonAsync("http://localhost:5064/api/Araba/Arabalar", araba));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            return View(await _httpClient.GetFromJsonAsync<Araba>("http://localhost:5064/api/Araba/IdIleGetir?Id=" + Id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Araba araba)
        {
            await _httpClient.DeleteAsync("http://localhost:5064/api/Araba/Sil?Id=" + araba.Id);
            return RedirectToAction("Index");    
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            return View(await _httpClient.GetFromJsonAsync<Araba>("http://localhost:5064/api/Araba/IdYeGoreGetir?Id=" + Id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Araba araba)
        {
            await _httpClient.PutAsJsonAsync<Araba>("http://localhost:5064/api/Araba/Guncelle?Id=" + araba.Id, araba);
            return RedirectToAction("Index");
        }
    }
}
