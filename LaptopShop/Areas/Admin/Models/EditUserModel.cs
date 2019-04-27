using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopShop.Areas.Admin.Models
{
    public class EditUserModel
    {
        public long id { get; set; }
        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string RePassword { get; set; }


    }
}