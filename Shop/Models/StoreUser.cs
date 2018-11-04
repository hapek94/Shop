using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class StoreUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserCategory UserCategory { get; set; }
        public int UserCatergoryId { get; set; }

    }
}
