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
    [Route("api/Seller")]
    public class SellerController : Controller
    {
        private readonly ApplicationDbContext context;
        private ISellerService service;
        public SellerController(ApplicationDbContext context)
        {
            this.context = context;
            service = new SellerServiceImpl(context);
        }

        [HttpGet]

        public IEnumerable<Seller> Get()
        {
            var Seller = service.FindAll();
            return Seller.ToList();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {

            var Seller = service.FindById(id);

            if (Seller == null)
            {
                return NotFound();
            }

            return Ok(Seller);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] Seller Seller)
        {
            if (ModelState.IsValid)
            {
                service.Save(Seller);
                return Ok(new CreatedAtRouteResult("create Seller", new { Id = Seller.Id }, Seller));
            }
            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Put([FromBody] Seller Seller, int id)
        {
            if (Seller.Id != id)
            {
                return BadRequest();
            }

            service.Update(Seller);
            return Ok();
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteSeller(int id)
        {
            var Seller = service.FindById(id);

            if (Seller == null)
            {
                return NotFound();
            }

            service.Delete(Seller);
            return Ok();
        }
    }
}