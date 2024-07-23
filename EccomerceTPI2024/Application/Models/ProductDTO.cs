using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]     
        public int Stock { get; set; }
        [Required]
        public bool State { get; set; } = false;

        public static ProductDTO ToDTO(Product entity) {
            ProductDTO dto = new ProductDTO();

            dto.Id = entity.Id;
            dto.Name = entity.ProdName;
            dto.Description = entity.ProdDescription;
            dto.Price = entity.ProdPrice;
            dto.Stock = entity.ProdStock;
            dto.State = entity.ProdState;
            return dto;
        }

        public static List<ProductDTO> ToDTO(List<Product> entities)
        {
            List<ProductDTO> listProductDTO = new List<ProductDTO>();
         

                foreach (var item in entities)
                {
                    listProductDTO.Add(ToDTO(item));
                }

                return listProductDTO;
            
        }

        public static ProductDTO ToUpdateDTO(Product entity)
        {
            ProductDTO dto = new ProductDTO();

            dto.Id = entity.Id;
            dto.Name = entity.ProdName;
            dto.Description = entity.ProdDescription;
            dto.Price = entity.ProdPrice;
            dto.Stock = entity.ProdStock;
            dto.State = entity.ProdState;
            return dto;

        }

    }
}
