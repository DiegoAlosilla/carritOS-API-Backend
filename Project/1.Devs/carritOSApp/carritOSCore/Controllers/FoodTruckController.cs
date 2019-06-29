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
    [Route("api/FoodTruck")]
    public class FoodTruckController : Controller
    {
        private readonly ApplicationDbContext context;
        private IFoodTruckService service;
        public FoodTruckController(ApplicationDbContext context)
        {
            this.context = context;
            service = new FoodTruckServiceImpl(context);
        }

        [HttpGet]

        public IEnumerable<FoodTruck> Get()
        {
            var FoodTruck = service.FindAll();
            return FoodTruck.ToList();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {

            var FoodTruck = service.FindById(id);

            if (FoodTruck == null)
            {
                return NotFound();
            }

            return Ok(FoodTruck);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] FoodTruck FoodTruck)
        {
            if (ModelState.IsValid)
            {
                service.Save(FoodTruck);
                return Ok(new CreatedAtRouteResult("create FoodTruck", new { Id = FoodTruck.Id }, FoodTruck));
            }
            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Put([FromBody] FoodTruck FoodTruck, int id)
        {
            if (FoodTruck.Id != id)
            {
                return BadRequest();
            }

            service.Update(FoodTruck);
            return Ok();
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteFoodTruck(int id)
        {
            var FoodTruck = service.FindById(id);

            if (FoodTruck == null)
            {
                return NotFound();
            }

            service.Delete(FoodTruck);
            return Ok();
        }
    }
}