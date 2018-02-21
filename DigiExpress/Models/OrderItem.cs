using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiExpress.Models
{
    public class OrderItem : IOrder
    {
        public string UserName { get; set; }
        public string TypeName { get; set; }
        public int ComputerId { get; set; }
        public int Price { get; set; }
    }
}