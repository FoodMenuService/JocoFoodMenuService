using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JocoFoodMenuService.Data;
using JocoFoodMenuService.Models;

namespace JocoFoodMenuService.Controllers
{
    public class MenuCreatorsController : Controller
    {
        private readonly JocoFoodMenuServiceContext _context;

        public MenuCreatorsController(JocoFoodMenuServiceContext context)
        {
            _context = context;
        }

        // GET: MenuCreators
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuCreator.ToListAsync());
        }

        // GET: MenuCreators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuCreator = await _context.MenuCreator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuCreator == null)
            {
                return NotFound();
            }

            return View(menuCreator);
        }

        // GET: MenuCreators/Create
        public IActionResult Create()
        {
            ViewBag.InventoryList = GetInventory();

            return View();
        }

        private MenuInventoryClassList GetInventory()
        {
            var rices = _context.Rice.ToList();
            var meats = _context.Meat.ToList();
            var complements = _context.Complement.ToList();
            var grains = _context.Grain.ToList();
            var beverages = _context.Beverage.ToList();

            MenuInventoryClassList list = new MenuInventoryClassList
            {
                Rice = rices,
                Meats = meats,
                Complements = complements,
                Grains = grains,
                Beverages = beverages
            };

            return list;

        }

        // POST: MenuCreators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuDaily,MenuDate")] MenuCreator menuCreator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuCreator);
        }

        // GET: MenuCreators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuCreator = await _context.MenuCreator.FindAsync(id);
            if (menuCreator == null)
            {
                return NotFound();
            }
            return View(menuCreator);
        }

        // POST: MenuCreators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MenuDaily,MenuDate")] MenuCreator menuCreator)
        {
            if (id != menuCreator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuCreator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuCreatorExists(menuCreator.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menuCreator);
        }

        // GET: MenuCreators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuCreator = await _context.MenuCreator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuCreator == null)
            {
                return NotFound();
            }

            return View(menuCreator);
        }

        // POST: MenuCreators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuCreator = await _context.MenuCreator.FindAsync(id);
            _context.MenuCreator.Remove(menuCreator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuCreatorExists(int id)
        {
            return _context.MenuCreator.Any(e => e.Id == id);
        }
    }
}
