using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key] // Hace que la id sea la clave principal dentro de la BD
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProdName { get; set; }
        [Required]
        public string ProdDescription { get; set; }
        [Required]
        public decimal ProdPrice { get; set; }
        [Required]
        public int ProdStock { get; set; }

        [Required]
        public bool ProdState { get; set; } = false;
        public ICollection<Order> Order { get; set; } 
    }
}
