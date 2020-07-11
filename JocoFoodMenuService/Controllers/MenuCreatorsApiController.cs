using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JocoFoodMenuService.Data;
using JocoFoodMenuService.Models;

namespace JocoFoodMenuService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCreatorsApiController : ControllerBase
    {
        private readonly JocoFoodMenuServiceContext _context;

        public MenuCreatorsApiController(JocoFoodMenuServiceContext context)
        {
            _context = context;
        }

        // GET: api/MenuCreatorsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuCreator>>> GetMenuCreator()
        {
            return await _context.MenuCreator.ToListAsync();
        }

        // GET: api/MenuCreatorsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuCreator>> GetMenuCreator(int id)
        {
            var menuCreator = await _context.MenuCreator.FindAsync(id);

            if (menuCreator == null)
            {
                return NotFound();
            }

            return menuCreator;
        }

        // PUT: api/MenuCreatorsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuCreator(int id, MenuCreator menuCreator)
        {
            if (id != menuCreator.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuCreator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuCreatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MenuCreatorsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MenuCreator>> PostMenuCreator(MenuCreator menuCreator)
        {
            _context.MenuCreator.Add(menuCreator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuCreator", new { id = menuCreator.Id }, menuCreator);
        }

        // DELETE: api/MenuCreatorsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuCreator>> DeleteMenuCreator(int id)
        {
            var menuCreator = await _context.MenuCreator.FindAsync(id);
            if (menuCreator == null)
            {
                return NotFound();
            }

            _context.MenuCreator.Remove(menuCreator);
            await _context.SaveChangesAsync();

            return menuCreator;
        }

        private bool MenuCreatorExists(int id)
        {
            return _context.MenuCreator.Any(e => e.Id == id);
        }
    }
}
