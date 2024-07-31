using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Order.Include(o => o.ClientUser).Include(o => o.Products).ToList();
        }

        public Order? GetOrderById(int id)
        {
            return _context.Order.Include(o => o.ClientUser).Include(o => o.Products).FirstOrDefault(p => p.Id == id);
        }

        public void CreateOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Order.Update(order);
            _context.SaveChanges();
        }

        public bool DeleteOrder(int id)
        {
            var order = _context.Order.Find(id);
            if (order != null)
            {
                _context.Order.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
