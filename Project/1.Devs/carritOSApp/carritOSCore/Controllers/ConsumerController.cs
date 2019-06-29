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

/**
 * --
 * @author Juan Diego Alosilla
 * @email diegoalosillagmail.com
 */
namespace carritOSCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Consumer")]
    public class ConsumerController : Controller
    {
        private readonly ApplicationDbContext context;
        private IConsumerService service;
        public ConsumerController(ApplicationDbContext context)
        {
            this.context = context;
            service = new ConsumerServiceImpl(context);
        }

        [HttpGet]

        public IEnumerable<Consumer> Get()
        {
            var Consumer = service.FindAll();
            return Consumer.ToList();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {

            var Consumer = service.FindById(id);

            if (Consumer == null)
            {
                return NotFound();
            }

            return Ok(Consumer);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] Consumer Consumer)
        {
            if (ModelState.IsValid)
            {
                service.Save(Consumer);
                return Ok(new CreatedAtRouteResult("create Consumer", new { id = Consumer.Id }, Consumer));
            }
            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Put([FromBody] Consumer Consumer, int id)
        {
            if (Consumer.Id != id)
            {
                return BadRequest();
            }

            service.Update(Consumer);
            return Ok();
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteConsumer(int id)
        {
            var Consumer = service.FindById(id);

            if (Consumer == null)
            {
                return NotFound();
            }

            service.Delete(Consumer);
            return Ok();
        }
    }
}