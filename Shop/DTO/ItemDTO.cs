using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
        public string BarCode { get; set; } 
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public int DiscountId { get; set; }


    }
}
