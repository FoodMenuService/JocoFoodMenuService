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
    public class MeatsController : Controller
    {
        private readonly JocoFoodMenuServiceContext _context;

        public MeatsController(JocoFoodMenuServiceContext context)
        {
            _context = context;
        }

        // GET: Meats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meat.ToListAsync());
        }

        // GET: Meats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meat = await _context.Meat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meat == null)
            {
                return NotFound();
            }

            return View(meat);
        }

        // GET: Meats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Meat meat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meat);
        }

        // GET: Meats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meat = await _context.Meat.FindAsync(id);
            if (meat == null)
            {
                return NotFound();
            }
            return View(meat);
        }

        // POST: Meats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Meat meat)
        {
            if (id != meat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeatExists(meat.Id))
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
            return View(meat);
        }

        // GET: Meats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meat = await _context.Meat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meat == null)
            {
                return NotFound();
            }

            return View(meat);
        }

        // POST: Meats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meat = await _context.Meat.FindAsync(id);
            _context.Meat.Remove(meat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeatExists(int id)
        {
            return _context.Meat.Any(e => e.Id == id);
        }
    }
}
