﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        [Key] // Hace que la id sea la clave principal dentro de la BD
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public bool OrderState { get; set; }
        [Required]
        public double OrderPrice { get; set; }
        public ICollection<Product> Product { get; set; }
        public User ClientUser { get; set; }
    }
}
