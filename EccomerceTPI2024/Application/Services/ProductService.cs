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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        //Metodo 1: Trae todos los productos
        public List<ProductDTO> GetAll() 
        {

            return ProductDTO.ToDTO(_repository.GetAll());
        }

        //Metodo 2: Trae todos los productos

        public ProductDTO? GetProductByName(string name)
        {
            
            return ProductDTO.ToDTO(_repository.GetProductByName(name));
        }

        //Metodo 3: Crea un producto

        public void AddProduct(AddProductRequest request)
        {
            var obj = new Product()
            {
                ProdName = request.ProdName,
                ProdDescription = request.ProdDescription,
                ProdPrice = request.ProdPrice,
                ProdStock = request.ProdStock,
                ProdState = request.ProdState
            };
            _repository.AddProduct(obj);

        }

        //Metodo 4: Actualiza un producto
        public void UpdateProduct(int id, UpdateRequest request)
        {
            var updateProductValidate = _repository.GetProductById(id);

            updateProductValidate.ProdName = request.Name;
            updateProductValidate.ProdPrice = request.Price;
            updateProductValidate.ProdStock = request.Stock;
            updateProductValidate.ProdState = request.State;

            _repository.UpdateProduct(updateProductValidate);

        }

        //Metodo 5: Elimina un producto
        public void DeleteProduct(int id)
        {
            var deleteProductValidate = _repository.GetProductById(id);
           _repository.DeleteProduct(deleteProductValidate);
            
        }




    }
}
