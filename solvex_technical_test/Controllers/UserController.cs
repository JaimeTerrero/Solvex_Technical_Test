using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace solvex_technical_test.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        Uri baseAddress = new Uri("https://localhost:7025/api/v1");
        private readonly HttpClient _client;
        public UserController(IUserService userService)
        {
            _userService = userService;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = $"Home", action = "Index" });
        }

        public async Task<IActionResult> UserManagement()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/project/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ViewData["Projects"] = JsonConvert.DeserializeObject<List<ProjectViewModel>>(data);
            }



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProject(UserViewModel vm)
        {
            await _userService.ChangeProjectAsync(vm);

            return RedirectToAction("UserManagement");
        }
    }
}
