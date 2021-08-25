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
    public class SleepAndEnvironmentCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public SleepAndEnvironmentCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: SleepAndEnvironmentCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SleepAndEnvironmentCategory.ToListAsync());
        }

        // GET: SleepAndEnvironmentCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepAndEnvironmentCategory = await _context.SleepAndEnvironmentCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepAndEnvironmentCategory == null)
            {
                return NotFound();
            }

            return View(sleepAndEnvironmentCategory);
        }

        // GET: SleepAndEnvironmentCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SleepAndEnvironmentCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SleepAndEnvironmentCategory sleepAndEnvironmentCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sleepAndEnvironmentCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sleepAndEnvironmentCategory);
        }

        // GET: SleepAndEnvironmentCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepAndEnvironmentCategory = await _context.SleepAndEnvironmentCategory.FindAsync(id);
            if (sleepAndEnvironmentCategory == null)
            {
                return NotFound();
            }
            return View(sleepAndEnvironmentCategory);
        }

        // POST: SleepAndEnvironmentCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SleepAndEnvironmentCategory sleepAndEnvironmentCategory)
        {
            if (id != sleepAndEnvironmentCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sleepAndEnvironmentCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SleepAndEnvironmentCategoryExists(sleepAndEnvironmentCategory.Id))
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
            return View(sleepAndEnvironmentCategory);
        }

        // GET: SleepAndEnvironmentCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepAndEnvironmentCategory = await _context.SleepAndEnvironmentCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepAndEnvironmentCategory == null)
            {
                return NotFound();
            }

            return View(sleepAndEnvironmentCategory);
        }

        // POST: SleepAndEnvironmentCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sleepAndEnvironmentCategory = await _context.SleepAndEnvironmentCategory.FindAsync(id);
            _context.SleepAndEnvironmentCategory.Remove(sleepAndEnvironmentCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SleepAndEnvironmentCategoryExists(int id)
        {
            return _context.SleepAndEnvironmentCategory.Any(e => e.Id == id);
        }
    }
}
