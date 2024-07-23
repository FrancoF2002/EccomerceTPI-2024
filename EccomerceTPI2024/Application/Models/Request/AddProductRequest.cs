using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class AddProductRequest
    {
        [Required]
        [MaxLength(15), MinLength(3)]
        public string ProdName { get; set; }
        [Required]
        [MaxLength(50), MinLength(10)]
        public string ProdDescription { get; set; }
        [Required]
        [Range(0, 1000000)]
        public decimal ProdPrice { get; set; }
        [Required]
        [Range(0, 2500)]
        public int ProdStock { get; set; }

        [Required]
        public bool ProdState { get; set; } = false;
    }
}
