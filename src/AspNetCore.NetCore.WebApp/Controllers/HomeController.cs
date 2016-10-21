using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.NetCore.WebApp.Areas.Administration.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AspNetCore.NetCore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "AspNetCore.NetCore.WebApp";
            SeedDataModel model = new SeedDataModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SeedDataModel vm)
        {
            if (ModelState.IsValid)
            {
                string url = "http://localhost:60213/administration/api/SeedData/get/" + vm.Password;
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        SeedDataModel model = JsonConvert.DeserializeObject<SeedDataModel>(responseData);
                        return View(model);
                    }
                }
            }
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Sample ASP.NET Core MVC Application";
            ViewData["Message"] = "This sample application is a proof of concept project for migrating legacy .NET 4.x code to an ASP.NET Core MVC Application. This application utilizes Autofac and AutoMapper.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
