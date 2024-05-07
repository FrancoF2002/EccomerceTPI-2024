using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class ShoppingCart
    {
        [Required] 
        public int IdProduct { get; set; }
        [Required]
        public int priceProduct { get; set; }
        [Required]
        public int totalPrice { get; set; }

        public ICollection<Product> Products { get; set; }
        
    }
}
