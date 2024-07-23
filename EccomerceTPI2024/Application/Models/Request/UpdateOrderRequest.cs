using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UpdateOrderRequest
    {
        public int Id { get; set; }
        [Required]
        public bool OrderState { get; set; }
        [Required]
        [Range(0, 10000000)]
        public double OrderPrice { get; set; }
        public IList<int> ProductsId { get; set; }
    }
}
