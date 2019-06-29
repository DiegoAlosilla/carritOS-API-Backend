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
    [Route("api/Review")]
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext context;
        private IReviewService service;
        public ReviewController(ApplicationDbContext context)
        {
            this.context = context;
            service = new ReviewServiceImpl(context);
        }

        [HttpGet]

        public IEnumerable<Review> Get()
        {
            var Review = service.FindAll();
            return Review.ToList();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {

            var Review = service.FindById(id);

            if (Review == null)
            {
                return NotFound();
            }

            return Ok(Review);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] Review Review)
        {
            if (ModelState.IsValid)
            {
                service.Save(Review);
                return Ok(new CreatedAtRouteResult("create Review", new { Id = Review.Id }, Review));
            }
            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Put([FromBody] Review Review, int id)
        {
            if (Review.Id != id)
            {
                return BadRequest();
            }

            service.Update(Review);
            return Ok();
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteReview(int id)
        {
            var Review = service.FindById(id);

            if (Review == null)
            {
                return NotFound();
            }

            service.Delete(Review);
            return Ok();
        }
    }
}