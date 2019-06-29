using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Service;
using carritOSCore.Model.ServiceImpl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carritOSCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Sale")]
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext context;
        private ISaleService service;
        public SaleController(ApplicationDbContext context)
        {
            this.context = context;
            service = new SaleServiceImpl(context);
        }

        [HttpGet]

        public IEnumerable<Sale> Get()
        {
            var Sale = service.FindAll();
            return Sale.ToList();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {

            var Sale = service.FindById(id);

            if (Sale == null)
            {
                return NotFound();
            }

            return Ok(Sale);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] Sale Sale)
        {
            if (ModelState.IsValid)
            {
                service.Save(Sale);
                return Ok(new CreatedAtRouteResult("create Sale", new { Id = Sale.id }, Sale));
            }
            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Put([FromBody] Sale Sale, int id)
        {
            if (Sale.id != id)
            {
                return BadRequest();
            }

            service.Update(Sale);
            return Ok();
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteSale(int id)
        {
            var Sale = service.FindById(id);

            if (Sale == null)
            {
                return NotFound();
            }

            service.Delete(Sale);
            return Ok();
        }
    }
}