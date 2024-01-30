using Application.Interfaces;
using Application.ViewModels;
using Database.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace solvex_technical_test.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7025/api/v1");
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects.ToListAsync();

            var projectList = new List<SelectListItem>();

            foreach (var project in projects)
            {
                projectList.Add(new SelectListItem { Value = project.Id.ToString(), Text = project.Name });
            }

            ViewBag.Projects = projectList;

            List<UserViewModel> userList = new List<UserViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }

            return View(userList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var projects = await _context.Projects.ToListAsync();

            var projectList = new List<SelectListItem>();

            foreach (var project in projects)
            {
                projectList.Add(new SelectListItem { Value = project.Id.ToString(), Text = project.Name });
            }

            ViewBag.Projects = projectList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(SaveUserViewModel vm)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(vm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/user/create", content);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var projects = await _context.Projects.ToListAsync();

                var projectList = new List<SelectListItem>();

                foreach (var project in projects)
                {
                    projectList.Add(new SelectListItem { Value = project.Id.ToString(), Text = project.Name });
                }

                ViewBag.Projects = projectList;

                UserViewModel user = new UserViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/GetById?id=" + id).Result;
            
                if(response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<UserViewModel>(data);
                }

                return View(user);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/user/Update?id=", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                UserViewModel user = new UserViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/GetById/" + id).Result;
            
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<UserViewModel>(data);
                }
                return View(user);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/user/Delete/" + id).Result;
            
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                return View();
            }

            return View();
        }
    }
}
