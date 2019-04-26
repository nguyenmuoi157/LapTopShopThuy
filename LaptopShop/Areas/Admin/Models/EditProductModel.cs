using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Areas.Admin.Models
{
    public class EditProductModel
    {
        public product Product { get; set; }
        public List<type_products> ListCategory { get; set; }
    }
}