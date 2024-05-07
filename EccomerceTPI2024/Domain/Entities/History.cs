using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class History
    {
        public Product ProductName { get; set; }
        public DateTime DateBuy { get; set; }
        public double ProductPrice { get; set; }

    }
}
