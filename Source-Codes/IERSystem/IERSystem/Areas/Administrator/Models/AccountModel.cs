using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
﻿using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations; 
 
namespace IERSystem.Areas.Administrator.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    } 
}