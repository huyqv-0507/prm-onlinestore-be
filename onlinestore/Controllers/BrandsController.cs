using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace onlinestore.Controllers
{
    [Route("api/v1/brands")]
    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        //GET api/v1/brands
        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = brandService.getBrands();
            if (brands == null) return NotFound();
            return Ok(brands);
        }
        //POST api/v1/brands
        [HttpPost]
        public IActionResult AddBrand(BrandModel brandModel)
        {
            if (brandModel == null) return BadRequest(brandModel);
            var brand = brandModel.Adapt<Brand>();
            if (brand == null) return BadRequest(brand);
            brandService.AddBrand(brand);
            brandService.Save();

            return Ok(brand);
        }

        //PUT api/v1/brands
        [HttpPut]
        public IActionResult UpdateBrand(BrandModel brandModel)
        {
            if (brandModel == null) return BadRequest(brandModel);
            if (!isExistedBrand(brandModel: brandModel)) return BadRequest(brandModel);
            var brand = brandModel.Adapt<Brand>();
            brandService.UpdateBrand(brand);
            return NoContent();
        }
        //DELETE api/v1/brands/{brand_id}
        [HttpDelete]
        public IActionResult DeleteBrand(int brandId)
        {
            var brand = brandService.GetBrand(brandId);
            if (brand == null) return NotFound(brandId);
            brandService.DeleteBrand(brand);
            brandService.Save();
            return Ok(brand);
        }


        //Addition
        private bool isExistedBrand(BrandModel brandModel)
        {
            var brand = brandService.GetBrand(brandModel.BrandId);
            if (brand != null) return true;
            return false;
        }
        
    }
}
