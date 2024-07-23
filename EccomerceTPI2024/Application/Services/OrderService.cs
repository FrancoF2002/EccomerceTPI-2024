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
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
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
            var products = _productRepository.GetProductsByIds(orders.ProductsId);
            var user = _userRepository.GetByName(orders.Username);
            var obj = new Order()
            {
                OrderState = orders.OrderState,
                OrderPrice = orders.OrderPrice,
                ClientUser = user,
                Products = products.ToList(),
            };

            _orderRepository.CreateOrder(obj);
            _orderRepository.SaveChanges();
        }

        public void UpdateOrder(UpdateOrderRequest order)
        {
            var products = _productRepository.GetProductsByIds(order.ProductsId);
            var orderentity = _orderRepository.GetOrderById(order.Id);
            orderentity.OrderState = order.OrderState;
            orderentity.OrderPrice = order.OrderPrice;
            orderentity.Products = products.ToList();

            _orderRepository.UpdateOrder(orderentity);
            _orderRepository.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
    }
}
