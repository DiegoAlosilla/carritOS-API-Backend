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


    }
}