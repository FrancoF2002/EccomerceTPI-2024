using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class AddOrderRequest
    {
        [Required]
        public bool OrderState { get; set; } = false;
        [Required]
        public double OrderPrice { get; set; }
        public IList<int> ProductsId { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
