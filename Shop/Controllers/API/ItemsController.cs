using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ItemsController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/Items
        [HttpGet]
        public IActionResult GetItems()
        {
            var itemDtos = _context.Items.Include(d => d.Discount)
                .Where(m => m.Quantity > 0)
                .ToList()
                .Select(_mapper.Map<Item, ItemDTO>);

            return Ok(itemDtos);
            
        }

        // GET: api/Items/5
        [HttpGet("{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int id)
        {
            var items =await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if(items == null)
            {
                return null;
            }
           var itemDTO = _mapper.Map<Item, ItemDTO>(items);
            return Ok(itemDTO);
        }

        // POST: api/Items 
        [Authorize(Roles = RoleName.StoreManager)]
        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var item = _mapper.Map<ItemDTO, Item>(itemDTO);
            _context.Items.Add(item);
           await _context.SaveChangesAsync();
            itemDTO.Id = item.Id;
            return CreatedAtAction("GetItem",new { id = itemDTO.Id }, item);
        }

        // PUT: api/Items/5
        [Authorize(Roles = RoleName.StoreManager)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemDTO itemDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemInDB = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (itemInDB == null)
                return NotFound();

            _mapper.Map<ItemDTO, Item>(itemDTO, itemInDB);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = RoleName.StoreManager)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var itemInDb = await _context.Items.SingleOrDefaultAsync(i => i.Id == id);

            if (itemInDb == null)
                return NotFound();

            _context.Items.Remove(itemInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
