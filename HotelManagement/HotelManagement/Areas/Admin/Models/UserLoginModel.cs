using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models
{
    public class UserLoginModel
    {
        [Required]
        [EmailAddress]
        public string UEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UPass { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}
