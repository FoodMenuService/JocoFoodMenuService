using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JocoFoodMenuService.Data;
using JocoFoodMenuService.Models;
using System.IO;
using System.Net.Http.Headers;

namespace JocoFoodMenuService.Controllers
{
    public class BeveragesController : Controller
    {
        private readonly JocoFoodMenuServiceContext _context;

        public BeveragesController(JocoFoodMenuServiceContext context)
        {
            _context = context;
        }

        // GET: Beverages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beverage.ToListAsync());
        }

        // GET: Beverages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _context.Beverage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }

        // GET: Beverages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beverages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UploadedImage,ImageUrl")] Beverage beverage)
        {
            var webRoot = Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\Uploads\\";

            if (beverage.UploadedImage == null)
            {
                return View(beverage);
            }

            var filename = ContentDispositionHeaderValue
                                    .Parse(beverage.UploadedImage.ContentDisposition)
                                    .FileName
                                    .Trim('"');
            filename = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Uploads\\" + filename);
            if (Directory.Exists(webRoot))
            {
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    beverage.UploadedImage.CopyTo(fs);
                    fs.Flush();
                }
            }
            beverage.ImageUrl = "~/Images/Uploads/" + beverage.UploadedImage.FileName;

            if (ModelState.IsValid)
            {
                _context.Add(beverage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: Beverages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _context.Beverage.FindAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        // POST: Beverages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Beverage beverage)
        {
            if (id != beverage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beverage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeverageExists(beverage.Id))
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
            return View(beverage);
        }

        // GET: Beverages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _context.Beverage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }

        // POST: Beverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beverage = await _context.Beverage.FindAsync(id);
            _context.Beverage.Remove(beverage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeverageExists(int id)
        {
            return _context.Beverage.Any(e => e.Id == id);
        }
    }
}
