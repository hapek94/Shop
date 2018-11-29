using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DTO
{
    public class PurchasesDTO
    {
        public int CustomerId { get; set; }
        public List<int> ItemsIds { get; set; }
    }
}
