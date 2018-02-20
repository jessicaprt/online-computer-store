using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiExpress.Models
{
    public class CartItem
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string TypeName { get; set; }
        public int ComputerId { get; set; }
    }
}