using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatsAndDogs_project.Data;
using CatsAndDogs_project.Models;
using Microsoft.AspNetCore.Authorization;

namespace CatsAndDogs_project.Controllers
{
    [Authorize]
    public class CaresController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public CaresController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: Cares
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.Care.Include(c => c.Category);
            return View(await catsAndDogs_projectContext.ToListAsync());
        }

        // GET: Cares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var care = await _context.Care
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (care == null)
            {
                return NotFound();
            }

            return View(care);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Cares/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<CareCategory>(), nameof(CareCategory.Id), nameof(CareCategory.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Cares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Tip,Price,Image,Type,CategoryId")] Care care)
        {
            if (ModelState.IsValid)
            {
                _context.Add(care);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<CareCategory>(), "Id", "Name", care.CategoryId);
            return View(care);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Cares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var care = await _context.Care.FindAsync(id);
            if (care == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<CareCategory>(), "Id", "Name", care.CategoryId);
            return View(care);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Cares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Tip,Price,Image,Type,CategoryId")] Care care)
        {
            if (id != care.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(care);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareExists(care.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<CareCategory>(), "Id", "Name", care.CategoryId);
            return View(care);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Cares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var care = await _context.Care
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (care == null)
            {
                return NotFound();
            }

            return View(care);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Cares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var care = await _context.Care.FindAsync(id);
            _context.Care.Remove(care);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareExists(int id)
        {
            return _context.Care.Any(e => e.Id == id);
        }
    }
}
