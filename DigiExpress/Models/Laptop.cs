using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiExpress.Models
{
    public class Laptop
    {
        public string ComputerType { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Screen { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string Ssd { get; set; }
        public string Os { get; set; }
    }
}