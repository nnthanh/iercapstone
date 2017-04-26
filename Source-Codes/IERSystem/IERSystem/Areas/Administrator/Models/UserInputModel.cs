using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    [Serializable]
    public class UserInputModel
    {
        public String username {get; set;}
        public String password { get; set; }
        public String phone { get; set; }
        public String fullname { get; set; }
        public int rolemasterid { get; set; }
    }
}