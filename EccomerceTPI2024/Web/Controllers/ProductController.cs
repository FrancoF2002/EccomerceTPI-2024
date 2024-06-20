using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _prodService;

        public ProductController(IProductService prodService)
        {
            _prodService = prodService;
        }

        [HttpGet("AllProducts")]
        public ActionResult<List<ProductDTO>> GetAll()
        {
            return Ok(_prodService.GetAll());
        }

        [HttpGet("ProductByName/{name}")]
        public ActionResult GetByName(string name)
        {
            return Ok(_prodService.GetProductByName(name));
        }

        [HttpPost("Create")]
        public void AddProduct(AddProductRequest request)
        {
            _prodService.AddProduct(request);
        }

        [HttpPut("Update")]
        public void UpdateProduct(string name, UpdateRequest request) 
        {
            _prodService.UpdateProduct(name, request);
        }

        [HttpDelete("Delete")]
        public void DeleteProduct(string name)
        {
            _prodService.DeleteProduct(name);
        }


    }
}
