using Labb2RestaurantMVC.Models.Menu;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Labb2RestaurantMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7073/";
        public MenuController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Menu";
            ViewBag.PageTitle = "Menu List";

            var response = await _client.GetAsync($"{baseUri}api/Menu/GetAllAvailableFoodMenu");

            var json = await response.Content.ReadAsStringAsync();

            var menuList = JsonConvert.DeserializeObject<List<Menu>>(json);

            return View(menuList);
        }
    }
}
