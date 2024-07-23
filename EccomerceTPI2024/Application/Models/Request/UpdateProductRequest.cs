using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UpdateProductRequest
    {
        [Required]
        [MaxLength(15), MinLength(3)]
        public string Name { get; set; }
        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 2500)]
        public int Stock { get; set; }
        [Required]
        public bool State { get; set; } = false;
    }
}
