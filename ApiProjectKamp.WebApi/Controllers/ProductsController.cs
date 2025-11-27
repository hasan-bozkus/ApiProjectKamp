using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.ProductDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _apiContext;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext apiContext, IMapper mapper)
        {
            _validator = validator;
            _apiContext = apiContext;
            _mapper = mapper;
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

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var values = _apiContext.Products.Find(id);
            _apiContext.Products.Remove(values);
            _apiContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetProduct/{id}")]
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

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            var validaitonResult = _validator.Validate(value);
            if (!validaitonResult.IsValid)
            {
                return BadRequest(validaitonResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _apiContext.Products.Add(value);
                _apiContext.SaveChanges();
                return Ok(new { message = "Ürün ekleme işlemi başarılı", data = value });
            }
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _apiContext.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }
    }
}
