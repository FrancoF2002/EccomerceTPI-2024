﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UpdateRequest
    {
        [Required]
        public string? ProdName { get; set; }
        [Required]
        public decimal? ProdPrice { get; set; }
        [Required]
        public int ProdStock { get; set; }
        [Required]
        public bool ProdState { get; set; } = false;
    }
}
