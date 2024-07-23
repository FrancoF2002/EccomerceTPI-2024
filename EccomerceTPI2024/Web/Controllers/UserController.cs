using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public ActionResult<User?> GetByName(string name)
        {
            return Ok(_userService.GetByName(name));
        }

        [HttpPost]
         public IActionResult Add([FromBody]UserForAddRequest request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.ToList());
                }
                return Ok(_userService.AddUser(request));
            }
    }
}
