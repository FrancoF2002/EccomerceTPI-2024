
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        //getAllProduct
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        //getProductByName
        public Product? GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.ProdName == name);
        }

        //getProductById
        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProdId == id);
        }

        //createProduct
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        //updateProduct
        public void UpdateProduct(Product product)
        {
           _context.Products.Update(product);
            _context.SaveChanges();
        }

        //deleteProduct
         public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        //public void DeleteAll() { }


        public void SaveChanges() 
        {
            _context.SaveChanges();
        }


    }
}
