using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.DTO;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult getProducts()
        {
            return Ok(TempDb.Products);
        }

        [HttpGet]
        [Route("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var product = TempDb.Products.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound($"Product with id {id} does not exist");
            }

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            var product = TempDb.Products.SingleOrDefault(x => x.Id == id);

            if (product != null)
            {
                TempDb.Products.Remove(product);
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDTO productDTO)
        {
            int id = TempDb.Products.Max(x => x.Id) + 1;

            Product newProduct = new Product()
            {
                Id = id,
                Name = productDTO.Name,
                Price = productDTO.Price,
            };

            TempDb.Products.Add(newProduct);
            return CreatedAtRoute("GetProductById", new { id = id }, newProduct);
        }

        [HttpPut]
        [Route("api/products/{id}")]

        public IActionResult UpdateProduct(int id, ProductDTO productDTO)
        {
            var existingProduct = TempDb.Products.SingleOrDefault(x => x.Id == id);

            if (existingProduct == null)
            {
                return NotFound($"Product with id {id} does not exist");
            }

            existingProduct.Name = productDTO.Name;
            existingProduct.Price = productDTO.Price;
            existingProduct.SellerId = productDTO.SellerId;
            return Ok(existingProduct);
        }
    }
}
