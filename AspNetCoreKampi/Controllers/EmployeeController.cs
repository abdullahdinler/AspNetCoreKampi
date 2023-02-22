using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using AspNetCoreKamp.Api;
using AspNetCoreKamp.Api.DataAccessLayer;

namespace AspNetCoreKampi.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient = new();
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:44330/api/Employee");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<EmployeeClass>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(EmployeeClass entity)
        {
            var jsonEmploye = JsonConvert.SerializeObject(entity);
            StringContent content = new(jsonEmploye, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:44330/api/Employee", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(entity);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditEmploye(int id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:44330/api/Employee/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EmployeeClass>(jsonEmployee);
                return View(values);
            }
            else
            {
                return RedirectToAction("Index", "Employee");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEmploye(EmployeeClass entity)
        {
            var jsonEmploye = JsonConvert.SerializeObject(entity);
            StringContent content = new(jsonEmploye, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:44330/api/Employee", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(entity);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            var responseMessage = await _httpClient.DeleteAsync("https://localhost:44330/api/Employee/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();

        }

    }


    public class EmployeeClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
