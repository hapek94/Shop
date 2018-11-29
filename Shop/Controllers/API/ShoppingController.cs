using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.DTO;
using Shop.Models;

namespace Shop.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        // POST: api/Shopping
        [HttpPost]
        public async Task<IActionResult> PostPurchase([FromBody] PurchasesDTO purchasesDTO)
        {
            var customer = await _context.StoreUsers.SingleOrDefaultAsync(c => c.Id == purchasesDTO.CustomerId);
            if (customer == null)
                return BadRequest("Invalid Customer Id");


            var items = _context.Items.Where(i => purchasesDTO.ItemsIds.Contains(i.Id)).ToList();
            if (items.Count != purchasesDTO.ItemsIds.Count)
                return BadRequest("One or more movieIds are invalid");

            foreach (var item in items)
            {
                if (item.Quantity == 0)
                    return BadRequest("Item is not ot available.");

                item.Quantity--;

                var purchase = new Purchase
                {
                    StoreUser = customer,
                    Item = item,
                    DateOfPurchase = DateTime.Now
                };

                _context.Add(purchase);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}