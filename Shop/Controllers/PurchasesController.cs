using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class PurchasesController : Controller
    {
        public IActionResult ShopingCart()
        {
            return View("ShopingCart");
        }
    }
}