using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Order
    {
        public int OrderId { get; set; }
        public string OrderState { get; set; }
        public double OrderPrice { get; set; }
    }
}
