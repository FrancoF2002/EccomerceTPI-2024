﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductDTO
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }

        public string ProductPrice { get; set; }
    }
}
