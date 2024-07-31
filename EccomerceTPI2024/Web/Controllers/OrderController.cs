using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<OrderDTO>> GetOrders()
        {
            return Ok(_orderService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetOrder(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult CreateOrder(AddOrderRequest orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToList());
            }

            var cre = _orderService.CreateOrder(orders);

            if (cre == false) return BadRequest();

            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, UpdateOrderRequest order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            
            var ord = _orderService.UpdateOrder(order);
            if (ord == false) return NotFound("Order not found");
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var del = _orderService.DeleteOrder(id);

            if (del == false) return NotFound();
            
            return NoContent();
        }
    }
}
