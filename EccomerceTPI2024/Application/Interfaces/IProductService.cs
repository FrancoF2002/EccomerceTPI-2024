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
    public interface IProductService
    {
        List<ProductDTO> GetAll();
        ProductDTO? GetProductByName(string name);
        void AddProduct(AddProductRequest request);
        void UpdateProduct(string name, UpdateProductRequest product);
        bool DeleteProduct(string name);

    }
}
