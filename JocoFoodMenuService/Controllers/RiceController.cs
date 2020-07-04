using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JocoFoodMenuService.Data;
using JocoFoodMenuService.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;

namespace JocoFoodMenuService.Controllers
{
    public class RiceController : Controller
    {
        private readonly JocoFoodMenuServiceContext _context;

        public RiceController(JocoFoodMenuServiceContext context)
        {
            _context = context;
        }

        // GET: Rice
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rice.ToListAsync());
        }

      

        // GET: Rice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UploadedImage,ImageUrl")] Rice rice)
        {
            var webRoot = Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\Uploads\\";

            if (rice.UploadedImage == null)
            {
                return View(rice);
            }

            var filename = ContentDispositionHeaderValue
                                    .Parse(rice.UploadedImage.ContentDisposition)
                                    .FileName
                                    .Trim('"');
            filename = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Uploads\\" + filename);
            if (Directory.Exists(webRoot))
            {
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    rice.UploadedImage.CopyTo(fs);
                    fs.Flush();
                }
            }
            rice.ImageUrl = "~/Images/Uploads/" + rice.UploadedImage.FileName;

            if (ModelState.IsValid)
            {
                _context.Add(rice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rice);
        }

        // GET: Rice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rice = await _context.Rice.FindAsync(id);
            if (rice == null)
            {
                return NotFound();
            }
            return View(rice);
        }

        // POST: Rice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Rice rice)
        {
            if (id != rice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiceExists(rice.Id))
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
            return View(rice);
        }

        // GET: Rice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rice = await _context.Rice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rice == null)
            {
                return NotFound();
            }

            return View(rice);
        }

        // POST: Rice/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rice = await _context.Rice.FindAsync(id);
            _context.Rice.Remove(rice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiceExists(int id)
        {
            return _context.Rice.Any(e => e.Id == id);
        }
    }
}
