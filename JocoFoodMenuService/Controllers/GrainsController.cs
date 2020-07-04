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
    public class GrainsController : Controller
    {
        private readonly JocoFoodMenuServiceContext _context;

        public GrainsController(JocoFoodMenuServiceContext context)
        {
            _context = context;
        }

        // GET: Grains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grain.ToListAsync());
        }

        // GET: Grains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // GET: Grains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UploadedImage,ImageUrl")] Grain grain)
        {
            var webRoot = Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\Uploads\\";

            if (grain.UploadedImage == null)
            {
                return View(grain);
            }

            var filename = ContentDispositionHeaderValue
                                    .Parse(grain.UploadedImage.ContentDisposition)
                                    .FileName
                                    .Trim('"');
            filename = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Uploads\\" + filename);
            if (Directory.Exists(webRoot))
            {
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    grain.UploadedImage.CopyTo(fs);
                    fs.Flush();
                }
            }
            grain.ImageUrl = "~/Images/Uploads/" + grain.UploadedImage.FileName;

            if (ModelState.IsValid)
            {
                _context.Add(grain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grain);
        }

        // GET: Grains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain.FindAsync(id);
            if (grain == null)
            {
                return NotFound();
            }
            return View(grain);
        }

        // POST: Grains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Grain grain)
        {
            if (id != grain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrainExists(grain.Id))
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
            return View(grain);
        }

        // GET: Grains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // POST: Grains/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grain = await _context.Grain.FindAsync(id);
            _context.Grain.Remove(grain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrainExists(int id)
        {
            return _context.Grain.Any(e => e.Id == id);
        }
    }
}
