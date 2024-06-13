using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<ProductDTO?> GetAll() 
        {
            return _repository.GetAll();
        }

        public ProductDTO? GetProductByName(string name)
        {
            return _repository.GetProductByName(name);
        }





    }
}
