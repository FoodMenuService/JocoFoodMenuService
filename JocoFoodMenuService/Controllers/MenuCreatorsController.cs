﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JocoFoodMenuService.Data;
using JocoFoodMenuService.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            var inventory = GetInventory();

            return View(inventory);
        }

        private MenuInventoryClassList GetInventory()
        {
            var list = new MenuInventoryClassList
            {
                Rice = _context.Rice.ToList(),
                Meats = _context.Meat.ToList(),
                Complements = _context.Complement.ToList(),
                Grains = _context.Grain.ToList(),
                Beverages = _context.Beverage.ToList()
            };

            return list;

        }


        [HttpPost]
        public async Task<IActionResult> Create(string foodCategories)
        {
            var obj = JsonConvert.DeserializeObject<MenuDeserializeObj>(foodCategories);

            if (!string.IsNullOrEmpty(foodCategories))
            {
                var menuCreator = new MenuCreator()
                {
                    MenuDaily = foodCategories,
                    MenuDate = DateTime.Now
                };


                _context.Add(menuCreator);
                await _context.SaveChangesAsync();
                return Json(true);
            }

            return Json(false);
        }

        public IActionResult CreateWithoutJS()
        {
            var inventory = GetInventory();

            return View(inventory);
        }

        [HttpPost]
        public IActionResult CreateWithoutJS(MenuInJson menuInJson)
        {
            var json = menuInJson;

            return Json(true);
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