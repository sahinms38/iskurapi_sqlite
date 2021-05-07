using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskurNortwindApi.Business;
using IskurNortwindApi.Infrastructure;
using IskurNortwindApi.Models;

namespace IskurNortwindApi.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        //public IActionResult Get()
        //{
            //var categoryBusiness = new CategoryBusiness();
            //return Ok(categoryBusiness.GetAllCategories());
        //}

        //public ICategoryService _ICategoryService { get; set; }
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetById(id);
            if (category==null)
                return NotFound();

            return Ok(category);
        }


        [HttpPost("")]
        public IActionResult Post([FromBody] Category category)
        {
            var addedCategory = _categoryService.Insert(category);
            return CreatedAtAction("Get", addedCategory);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            return CreatedAtAction("Get", result);
        }


        [HttpPut("")]
        public IActionResult Put([FromBody] Category category)
        {
            var updatedCategory = _categoryService.Update(category);

            return CreatedAtAction("Get", updatedCategory);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Category category)
        {
            var updatedCategory = _categoryService.UpdateCategoryName(id, category.Name);

            return CreatedAtAction("Get", updatedCategory);
        }

    }
}
