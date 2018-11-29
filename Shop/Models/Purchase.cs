using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public StoreUser StoreUser { get; set; }
        public Item Item { get; set; }
        public DateTime DateOfPurchase { get; set; }

    }
}
