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
        public int ProdId { get; set; }
        [Required]
        public string? ProdName { get; set; }
        [Required]
        public string? ProdDescription { get; set; }
        [Required]
        public decimal? ProdPrice { get; set; }
        [Required]     
        public int ProdStock { get; set; }
        [Required]
        public bool ProdState { get; set; } = false;

        public static ProductDTO ToDTO(Product entity) {
            ProductDTO dto = new ProductDTO();

            //dto.ProdId = entity.ProdId;
            dto.ProdName = entity.ProdName;
            dto.ProdDescription = entity.ProdDescription;
            dto.ProdPrice = entity.ProdPrice;
            dto.ProdStock = entity.ProdStock;
            dto.ProdState = entity.ProdState;
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

            dto.ProdName = entity.ProdName;
            dto.ProdPrice = entity.ProdPrice;
            dto.ProdStock = entity.ProdStock;
            dto.ProdState = entity.ProdState;
            return dto;
        }


    }
}
