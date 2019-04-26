using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    [Serializable]
    public class CartItem
    {        
        public product Product { get; set; }
        public int Quantity { get; set; }
    }
}