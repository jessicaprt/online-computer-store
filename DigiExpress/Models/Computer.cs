using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiExpress.Models
{
    public class Computer
    {
        public string ComputerType { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
        public string Part4 { get; set; }
        public string Part5 { get; set; }
    }
}