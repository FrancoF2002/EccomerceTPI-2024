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
            var orders = _orderRepository.GetAll();

            foreach(var item in orders)
            {
                item.OrderPrice = item.Products.Sum(p => p.ProdPrice);
            }

            return OrderDTO.ToDTO(orders);
        }

        public OrderDTO? GetOrderById(int id)
        {
            var ord = _orderRepository.GetOrderById(id);

            ord.OrderPrice = ord.Products.Sum(p => p.ProdPrice);

            if(ord != null) return OrderDTO.ToDTO(ord);

            return null;
        }

        public bool CreateOrder(AddOrderRequest orders)
        {
            var products = _productRepository.GetProductsByIds(orders.ProductsId);
            var user = _userRepository.GetByName(orders.Username);

            if (products.Count == 0) return false;
            var obj = new Order()
            {
                OrderState = orders.OrderState,
                ClientUser = user,
                Products = products.ToList(),
            };

            _orderRepository.CreateOrder(obj);
            _orderRepository.SaveChanges();
            return true;
        }

        public bool UpdateOrder(UpdateOrderRequest order)
        {
            var products = _productRepository.GetProductsByIds(order.ProductsId);
            var orderentity = _orderRepository.GetOrderById(order.Id);
            if(orderentity == null)
            {
                return false;
            }

            if(products.Count == 0) return false;

            orderentity.OrderState = order.OrderState;
            orderentity.Products = products.ToList();

            _orderRepository.UpdateOrder(orderentity);
            _orderRepository.SaveChanges();

            return true;
        }

        public bool DeleteOrder(int id)
        {
           return _orderRepository.DeleteOrder(id);
        }
    }
}
