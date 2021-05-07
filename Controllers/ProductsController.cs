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
    public class ProductsController : ApiControllerBase
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] Product product)
        {
            var addedProduct = _productService.Insert(product);
            return CreatedAtAction("Get", addedProduct);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            return CreatedAtAction("Get", result);
        }


        [HttpPut("")]
        public IActionResult Put([FromBody] Product product)
        {
            var updatedProduct = _productService.Update(product);

            return CreatedAtAction("Get", updatedProduct);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch( int id, [FromBody] Product product)
        {
            var updatedProduct = _productService.UpdateProductPrice(id, product.UnitPrice);

            return CreatedAtAction("Get", updatedProduct);
        }
    }
}
