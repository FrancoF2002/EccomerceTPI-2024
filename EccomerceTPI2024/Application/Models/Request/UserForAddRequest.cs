using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UserForAddRequest
    {
        [MinLength(3), MaxLength(15)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8), MaxLength(16)]
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
