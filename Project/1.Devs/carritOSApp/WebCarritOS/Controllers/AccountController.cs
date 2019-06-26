using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using carritOSCore.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCarritOS.API;
using WebCarritOS.Models;

/**
 * --
 * @author Dash Tennynson
 * @email rojas71421@gmail.com
 * Referencia de los otros Controladores
 */

namespace WebCarritOS.Controllers
{
    public class AccountController : Controller
    {
        carritOSAPI _api = new carritOSAPI();

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult LoginApp() {
            ViewBag.Title = "Login Page";
            return View();
        }

        [HttpPost]
        public IActionResult LoginApp(UserInfo userInfo)
        {
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<UserInfo>("api/Account/Login", userInfo);
            
            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "BusinessOwner");
            }
            return View(userInfo);

        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Register Page";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserInfo userInfo)
        {
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<UserInfo>("api/Account/Create", userInfo);
            postTask.Wait();
            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return View();
        }
    }
}