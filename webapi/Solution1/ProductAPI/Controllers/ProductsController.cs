using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Models.dto;
using ProductAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper )
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var Products = productRepository.GetAllProducts();

           // return new RedirectResult("http://www.as.com");

            return Ok(mapper.Map<List<productDTO>>(Products));

        }

        [HttpGet("(id)",Name ="GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = productRepository.GetProduct(id);

            if (product == null) return NotFound();

            return Ok(mapper.Map<productDTO>(product));

        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] productDTO productdto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (productRepository.ProductExist (productdto.Name))
            {
                ModelState.AddModelError(string.Empty,$"ya existe un producto con este nombre: {productdto.Name}");
                return StatusCode(404, ModelState);
            }

            var product = mapper.Map<Product>(productdto);

            if (!productRepository.CreateProduct(product))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al agregar: {productdto.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product );

        }
           


    }
}
