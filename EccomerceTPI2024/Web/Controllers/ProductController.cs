using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            //if (userRole == "0")
            //{
                return Ok(_prodService.GetAll());
            //}
            //else
            //{
              //  return Unauthorized();
            //}

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
