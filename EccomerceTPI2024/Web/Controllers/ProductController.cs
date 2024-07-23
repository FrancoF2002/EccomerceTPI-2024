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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _prodService;

        public ProductController(IProductService prodService)
        {
            _prodService = prodService;
        }
        
        [HttpGet]
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

        [HttpGet("{name}")]
        public ActionResult GetByName(string name)
        {
            return Ok(_prodService.GetProductByName(name));
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult AddProduct(AddProductRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToList());
            }
            _prodService.AddProduct(request);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public ActionResult UpdateProduct(string name, UpdateProductRequest request) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToList());
            }
            _prodService.UpdateProduct(name, request);
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteProduct(string name)
        {
            _prodService.DeleteProduct(name);
            return NoContent();
        }
    }
}
