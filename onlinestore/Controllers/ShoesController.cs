using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace onlinestore.Controllers
{
    [Route("api/v1/shoes")]
    public class ShoesController : Controller
    {
        private readonly IShoeService shoeService;
        public ShoesController(IShoeService shoeService)
        {
            this.shoeService = shoeService;
        }

        //GET api/v1/shoes
        [HttpGet]
        public IActionResult getShoes()
        {
            var shoes = shoeService.GetShoes();

            if (shoes == null) return BadRequest();

            return Ok(shoes);
        }

        //POST api/v1/shoes
        [HttpPost]
        public IActionResult AddShoe(Shoe shoeModel)
        {
            if (shoeModel == null) return BadRequest(shoeModel);
            shoeService.AddShoe(shoeModel);
            shoeService.Save();

            return Ok(shoeModel);
        }   

        //PUT api/v1/shoes
        [HttpPut]
        public IActionResult UpdateShoe(Shoe shoe)
        {
            if (shoe == null) return NotFound(shoe);
            shoeService.UpdateShoe(shoe);
            shoeService.Save();
            return NoContent();
        }
        //DELETE api/v1/shoes/{shoe_id}
        [HttpDelete]
        public IActionResult DeleteShoe(int shoeId)
        {
            var shoe = shoeService.GetShoe(shoeId);
            if (shoe == null) return BadRequest();
            shoeService.DeleteShoe(shoe);
            shoeService.Save();
            return Ok();
        }


    }
}
