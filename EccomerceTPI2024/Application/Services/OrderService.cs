using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderDTO> GetAll()
        {
            return OrderDTO.ToDTO(_orderRepository.GetAll());
        }

        public OrderDTO GetOrderById(int id)
        {
            return OrderDTO.ToDTO(_orderRepository.GetOrderById(id));
        }

        public void CreateOrder(AddOrderRequest orders)
        {
            var obj = new Order()
            {
                OrderState = orders.OrderState,
                OrderPrice = orders.OrderPrice,
                Product = orders.Product,
            };
            _orderRepository.CreateOrder(obj);
            _orderRepository.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
    }
}
