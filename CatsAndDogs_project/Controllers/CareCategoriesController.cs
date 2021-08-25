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
    [Authorize(Roles = "Admin , Editor")]
    public class CareCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public CareCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: CareCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.CareCategory.ToListAsync());
        }

        // GET: CareCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careCategory = await _context.CareCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careCategory == null)
            {
                return NotFound();
            }

            return View(careCategory);
        }

        // GET: CareCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CareCategory careCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careCategory);
        }

        // GET: CareCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careCategory = await _context.CareCategory.FindAsync(id);
            if (careCategory == null)
            {
                return NotFound();
            }
            return View(careCategory);
        }

        // POST: CareCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CareCategory careCategory)
        {
            if (id != careCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareCategoryExists(careCategory.Id))
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
            return View(careCategory);
        }

        // GET: CareCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careCategory = await _context.CareCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careCategory == null)
            {
                return NotFound();
            }

            return View(careCategory);
        }

        // POST: CareCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var careCategory = await _context.CareCategory.FindAsync(id);
            _context.CareCategory.Remove(careCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareCategoryExists(int id)
        {
            return _context.CareCategory.Any(e => e.Id == id);
        }
    }
}
