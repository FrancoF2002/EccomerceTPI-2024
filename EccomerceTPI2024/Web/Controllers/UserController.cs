using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<User?> GetByName(string name)
        {
            return Ok(_userService.GetByName(name));
        }

        [HttpPost]
     public IActionResult Add([FromBody]UserForAddRequest request)
        {
            return Ok(_userService.AddUser(request));
        }
    }
}
