using Daraz.Application.Common.Interfaces;
using Daraz.Application.Services.ProductServices;
using Daraz.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace Daraz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_product.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            return Ok(_product.GetItem(id));
        }
        [HttpPost("create")]
        public IActionResult AddProduct(ProductAddRequest product)
        {
            // check if logged in user is seller
            //Guid userId = Guid.Parse(User.FindFirst("User").Value);
            int userId = 0;

            // check validity
            int productId = _product.AddProduct(product.Name, product.Description, product.Price, product.Discount, userId);
            return CreatedAtAction("GetItem",new { Id = productId });
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct(ProductUpdateRequest product, int id)
        {
            if (id != product.Id)
                return BadRequest();
            // check if logged in user is seller
            // Guid userId = Guid.Parse(User.FindFirst("User").Value);
            int userId = 0;

            var result = _product.UpdateProduct(product.Id, product.Name, product.Description, product.Price, product.Discount, userId);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // check if logged in user is seller
            // Guid userId = Guid.Parse(User.FindFirst("User").Value);
            int userId = 0;

            var result = _product.DeleteProduct(id,userId);
            return Ok(result);
        }
    }
}
