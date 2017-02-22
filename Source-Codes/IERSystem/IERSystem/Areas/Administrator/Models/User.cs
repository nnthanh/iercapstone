using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class User
    {
        public int Id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String fullname { get; set; }

        public int roleId { get; set; }
    }
    
}