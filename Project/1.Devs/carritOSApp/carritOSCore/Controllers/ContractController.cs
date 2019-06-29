using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Service;
using carritOSCore.Model.ServiceImpl;
using Microsoft.AspNetCore.Mvc;
/**
 * --
 * @author Juan Diego Alosilla
 * @email diegoalosillagmail.com
 */
namespace carritOSCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Contract")]
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext context;
        private IContractService service;
        public ContractController(ApplicationDbContext context)
        {
            this.context = context;
            service = new ContractServiceImpl(context);
        }

        [HttpGet]

        public IEnumerable<Contract> Get()
        {
            var Contract = service.FindAll();
            return Contract.ToList();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {

            var Contract = service.FindById(id);

            if (Contract == null)
            {
                return NotFound();
            }

            return Ok(Contract);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] Contract Contract)
        {
            if (ModelState.IsValid)
            {
                service.Save(Contract);
                return Ok(new CreatedAtRouteResult("create Contract", new { Id = Contract.id }, Contract));
            }
            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Put([FromBody] Contract Contract, int id)
        {
            if (Contract.id != id)
            {
                return BadRequest();
            }

            service.Update(Contract);
            return Ok();
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteContract(int id)
        {
            var Contract = service.FindById(id);

            if (Contract == null)
            {
                return NotFound();
            }

            service.Delete(Contract);
            return Ok();
        }
    }
}