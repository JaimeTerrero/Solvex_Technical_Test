using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace solvex_technical_test.Controllers
{
    public class ProjectController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7025/api/v1");
        private readonly HttpClient _client;
        public ProjectController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProjectViewModel> projectList = new List<ProjectViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/project/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                projectList = JsonConvert.DeserializeObject<List<ProjectViewModel>>(data);
            }

            return View(projectList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(SaveProjectViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("CreateProject", vm);
            //}

            string json = System.Text.Json.JsonSerializer.Serialize(vm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/project/create", content);

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
        public IActionResult Edit(int id)
        {
            try
            {
                ProjectViewModel project = new ProjectViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/project/GetById?id=" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    project = JsonConvert.DeserializeObject<ProjectViewModel>(data);
                }

                return View(project);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(ProjectViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/project/Update?id=", content).Result;

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
                ProjectViewModel project = new ProjectViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/project/GetById/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    project = JsonConvert.DeserializeObject<ProjectViewModel>(data);
                }
                return View(project);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/project/Delete/" + id).Result;

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
    }
}
