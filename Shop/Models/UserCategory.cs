using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class UserCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Discount Discount { get; set; }
        public int DiscountID { get; set; }
    }
}
