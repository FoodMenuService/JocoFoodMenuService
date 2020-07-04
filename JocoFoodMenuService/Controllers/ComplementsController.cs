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
    public class ComplementsController : Controller
    {
        private readonly JocoFoodMenuServiceContext _context;

        public ComplementsController(JocoFoodMenuServiceContext context)
        {
            _context = context;
        }

        // GET: Complements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Complement.ToListAsync());
        }

        // GET: Complements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complement = await _context.Complement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complement == null)
            {
                return NotFound();
            }

            return View(complement);
        }

        // GET: Complements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UploadedImage,ImageUrl")] Complement complement)
        {
            var webRoot = Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\Uploads\\";

            if (complement.UploadedImage == null)
            {
                return View(complement);
            }

            var filename = ContentDispositionHeaderValue
                                    .Parse(complement.UploadedImage.ContentDisposition)
                                    .FileName
                                    .Trim('"');
            filename = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Uploads\\" + filename);
            if (Directory.Exists(webRoot))
            {
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    complement.UploadedImage.CopyTo(fs);
                    fs.Flush();
                }
            }
            complement.ImageUrl = "~/Images/Uploads/" + complement.UploadedImage.FileName;

            if (ModelState.IsValid)
            {
                _context.Add(complement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complement);
        }

        // GET: Complements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complement = await _context.Complement.FindAsync(id);
            if (complement == null)
            {
                return NotFound();
            }
            return View(complement);
        }

        // POST: Complements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Complement complement)
        {
            if (id != complement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplementExists(complement.Id))
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
            return View(complement);
        }

        // GET: Complements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complement = await _context.Complement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complement == null)
            {
                return NotFound();
            }

            return View(complement);
        }

        // POST: Complements/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complement = await _context.Complement.FindAsync(id);
            _context.Complement.Remove(complement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplementExists(int id)
        {
            return _context.Complement.Any(e => e.Id == id);
        }
    }
}
