using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Client : User
    {
       public ICollection<Product> Products { get; set; }
       public ICollection<ShoppingCart> ShoppingCart { get; set; }




    }
}
