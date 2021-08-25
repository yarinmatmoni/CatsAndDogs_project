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
    public class HealthCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public HealthCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: HealthCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.HealthCategory.ToListAsync());
        }

        // GET: HealthCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCategory = await _context.HealthCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCategory == null)
            {
                return NotFound();
            }

            return View(healthCategory);
        }

        // GET: HealthCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] HealthCategory healthCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthCategory);
        }

        // GET: HealthCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCategory = await _context.HealthCategory.FindAsync(id);
            if (healthCategory == null)
            {
                return NotFound();
            }
            return View(healthCategory);
        }

        // POST: HealthCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] HealthCategory healthCategory)
        {
            if (id != healthCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthCategoryExists(healthCategory.Id))
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
            return View(healthCategory);
        }

        // GET: HealthCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthCategory = await _context.HealthCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCategory == null)
            {
                return NotFound();
            }

            return View(healthCategory);
        }

        // POST: HealthCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthCategory = await _context.HealthCategory.FindAsync(id);
            _context.HealthCategory.Remove(healthCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthCategoryExists(int id)
        {
            return _context.HealthCategory.Any(e => e.Id == id);
        }
    }
}
