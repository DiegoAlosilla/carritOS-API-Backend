using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carritOS_UI.Controllers
{
    public class BusinessOwnerController : Controller
    {
        // GET: BusinessOwner
        public ActionResult Index()
        {
            return View();
        }

        // GET: BusinessOwner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessOwner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessOwner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessOwner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessOwner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessOwner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessOwner/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}