using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _apiContext;

        public ProductsController(IValidator<Product> validator, ApiContext apiContext)
        {
            _validator = validator;
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _apiContext.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validaitonResult = _validator.Validate(product);
            if (!validaitonResult.IsValid)
            {
                return BadRequest(validaitonResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _apiContext.Products.Add(product);
                _apiContext.SaveChanges();
                return Ok(new { message = "Ürün ekleme işlemi başarılı", data = product });
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _apiContext.Products.Find(id);
            _apiContext.Products.Remove(values);
            _apiContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var result = _apiContext.Products.Find(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validaitonResult = _validator.Validate(product);
            if (!validaitonResult.IsValid)
            {
                return BadRequest(validaitonResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _apiContext.Products.Update(product);
                _apiContext.SaveChanges();
                return Ok(new { message = "Ürün güncelleme işlemi başarılı", data = product });
            }
        }
    }
}
