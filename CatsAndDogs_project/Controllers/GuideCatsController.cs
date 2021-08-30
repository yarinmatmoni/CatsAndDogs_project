using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatsAndDogs_project.Data;
using CatsAndDogs_project.Models;

namespace CatsAndDogs_project.Controllers
{
    public class GuideCatsController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public GuideCatsController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: GuideCats
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.GuideCat.Include(g => g.BreedCat);
            return View(await catsAndDogs_projectContext.ToListAsync());
        }

        // GET: GuideCats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideCat = await _context.GuideCat
                .Include(g => g.BreedCat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guideCat == null)
            {
                return NotFound();
            }

            return View(guideCat);
        }

        // GET: GuideCats/Create
        public IActionResult Create()
        {
            ViewData["BreedCat_2Id"] = new SelectList(_context.BreedCat_2, "Id", "Name");
            return View();
        }

        // POST: GuideCats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageGuied,Image,BreedCat_2Id,Description,Characteristics,Health")] GuideCat guideCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guideCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedCat_2Id"] = new SelectList(_context.BreedCat_2, "Id", "Name", guideCat.BreedCat_2Id);
            return View(guideCat);
        }

        // GET: GuideCats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideCat = await _context.GuideCat.FindAsync(id);
            if (guideCat == null)
            {
                return NotFound();
            }
            ViewData["BreedCat_2Id"] = new SelectList(_context.BreedCat_2, "Id", "Name", guideCat.BreedCat_2Id);
            return View(guideCat);
        }

        // POST: GuideCats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageGuied,Image,BreedCat_2Id,Description,Characteristics,Health")] GuideCat guideCat)
        {
            if (id != guideCat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guideCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuideCatExists(guideCat.Id))
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
            ViewData["BreedCat_2Id"] = new SelectList(_context.BreedCat_2, "Id", "Name", guideCat.BreedCat_2Id);
            return View(guideCat);
        }

        // GET: GuideCats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideCat = await _context.GuideCat
                .Include(g => g.BreedCat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guideCat == null)
            {
                return NotFound();
            }

            return View(guideCat);
        }

        // POST: GuideCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guideCat = await _context.GuideCat.FindAsync(id);
            _context.GuideCat.Remove(guideCat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuideCatExists(int id)
        {
            return _context.GuideCat.Any(e => e.Id == id);
        }
    }
}
