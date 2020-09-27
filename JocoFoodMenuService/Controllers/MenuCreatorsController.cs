using System;
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
        public async Task<IActionResult> Index() => View(await _context.MenuCreator.ToListAsync());

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

            var menuToEdit = JsonConvert.DeserializeObject<MenuInventoryClassList>(menuCreator.MenuDaily);

            ViewBag.MenuEditId = menuCreator.Id;

            return View(menuToEdit);
        }

        // POST: MenuCreators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, string foodCategories)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var menuCreator = await _context.MenuCreator.FindAsync(id);

                    menuCreator.MenuDaily = foodCategories;

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
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: MenuCreators/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuCreator = await _context.MenuCreator.FindAsync(id);
            _context.MenuCreator.Remove(menuCreator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetFoodByCategory(string categoryNumber)
        {
            if (!string.IsNullOrEmpty(categoryNumber))
            {
                var categoryNumberInInt = int.Parse(categoryNumber);

                switch (categoryNumberInInt)
                {
                    case 1:
                        return Json(_context.Rice.Select(x => new { x.Name, x.ImageUrl }).ToList());
                    case 2:
                        return Json(_context.Meat.Select(x => new { x.Name, x.ImageUrl }).ToList());
                    case 3:
                        return Json(_context.Grain.Select(x => new { x.Name, x.ImageUrl }).ToList());
                    case 4:
                        return Json(_context.Complement.Select(x => new { x.Name, x.ImageUrl }).ToList());
                    case 5:
                        return Json(_context.Beverage.Select(x => new { x.Name, x.ImageUrl }).ToList());
                    default:
                        break;
                }
            }

            return Json("Error pasando el número de categoría");
        }

        private bool MenuCreatorExists(int id)
        {
            return _context.MenuCreator.Any(e => e.Id == id);
        }
    }
}