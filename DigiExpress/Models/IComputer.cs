using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiExpress.Models
{
    public interface IComputer
    {
        string ComputerType { get; set; }
        int Id { get; set; }
        int UserId { get; set; }
        string UserName { get; set; }
        string Part1 { get; set; }
        string Part2 { get; set; }
        string Part3 { get; set; }
        string Part4 { get; set; }
        string Part5 { get; set; }
    }
}