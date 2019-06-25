using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using carritOSCore.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCarritOS.API;
using WebCarritOS.Models;

namespace WebCarritOS.Controllers
{
    public class BusinessOwnerController : Controller
    {
        carritOSAPI _api = new carritOSAPI();

        public async Task<IActionResult> Index()
        {
            List<BusinessOwner> businessOwners = new List<BusinessOwner>();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/BusinessOwner");


            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                businessOwners = JsonConvert.DeserializeObject<List<BusinessOwner>>(result);
            }
            return View(businessOwners);
        }


        public async Task<IActionResult> Details(int Id)
        {
            var businessOwner = new BusinessOwner();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/BusinessOwner/Get/{Id}");


            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                businessOwner = JsonConvert.DeserializeObject<BusinessOwner>(result);
            }
            return View(businessOwner);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusinessOwner businessOwner)
        {

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<BusinessOwner>("api/BusinessOwner/Create", businessOwner);
            postTask.Wait();
            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> Delete(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }

            var businessOwner = new BusinessOwner();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/BusinessOwner/Get/{Id}");


            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                businessOwner = JsonConvert.DeserializeObject<BusinessOwner>(result);
            }

            if (businessOwner == null)
            {
                return NotFound();
            }


            return View(businessOwner);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"api/BusinessOwner/delete/{Id}");

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }

            var businessOwner = new BusinessOwner();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/BusinessOwner/Get/{Id}");


            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                businessOwner = JsonConvert.DeserializeObject<BusinessOwner>(result);
            }

            if (businessOwner == null)
            {
                return NotFound();
            }


            return View(businessOwner);
        }

        [HttpPost]
        public IActionResult Edit(int Id, BusinessOwner businessOwner)
        {
            
            HttpClient client = _api.Initial();
                      
            var putTask = client.PutAsJsonAsync<BusinessOwner>($"api/BusinessOwner/update/{Id}", businessOwner);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}