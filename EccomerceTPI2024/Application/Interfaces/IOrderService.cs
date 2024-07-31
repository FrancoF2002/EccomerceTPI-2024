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
        OrderDTO? GetOrderById(int id);
        bool UpdateOrder(UpdateOrderRequest order);
        bool DeleteOrder(int id);
        bool CreateOrder(AddOrderRequest orders);
    }
}
