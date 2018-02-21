using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiExpress.Models
{
    public class RenderedCartItem
    {
        public string ImageUrl { get; set; }
        public string ComputerIdType { get; set; }
        public string ComputerName { get; set; }
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
        public string Part4 { get; set; }
        public string Part5 { get; set; }
        public int Price { get; set; }
    }
}