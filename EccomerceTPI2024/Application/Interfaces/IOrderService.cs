using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        List<OrderDTO> GetAll();
        OrderDTO GetOrderById(int id);
        void UpdateOrder(UpdateOrderRequest order);
        void DeleteOrder(int id);
        void CreateOrder(AddOrderRequest orders);
    }
}
