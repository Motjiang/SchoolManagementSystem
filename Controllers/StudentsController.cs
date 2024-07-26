using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementSystem.Models;
using System.Net.Http.Headers;

namespace SchoolManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private string baseUrl = "https://localhost:7008/";

        public async Task<IActionResult> Index()
        {
            List<Student> lststudents = new List<Student>();
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseUrl + "api/Students");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await _httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    lststudents = JsonConvert.DeserializeObject<List<Student>>(result);
                }
                else
                {
                    return View("ErrorPage");
                }
            }
            return View();
        }
        //error page
        public IActionResult ErrorPage()
        {
            return View();
        }

    }
}
