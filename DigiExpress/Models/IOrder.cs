using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiExpress.Models
{
    interface IOrder
    {
        string UserName { get; set; }
        string TypeName { get; set; }
        int ComputerId { get; set; }
        int Price { get; set; }
    }
}
