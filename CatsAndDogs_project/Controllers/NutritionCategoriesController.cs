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
    public class NutritionCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public NutritionCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: NutritionCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.NutritionCategory.ToListAsync());
        }

        // GET: NutritionCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutritionCategory = await _context.NutritionCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nutritionCategory == null)
            {
                return NotFound();
            }

            return View(nutritionCategory);
        }

        // GET: NutritionCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NutritionCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] NutritionCategory nutritionCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nutritionCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nutritionCategory);
        }

        // GET: NutritionCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutritionCategory = await _context.NutritionCategory.FindAsync(id);
            if (nutritionCategory == null)
            {
                return NotFound();
            }
            return View(nutritionCategory);
        }

        // POST: NutritionCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] NutritionCategory nutritionCategory)
        {
            if (id != nutritionCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutritionCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutritionCategoryExists(nutritionCategory.Id))
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
            return View(nutritionCategory);
        }

        // GET: NutritionCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutritionCategory = await _context.NutritionCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nutritionCategory == null)
            {
                return NotFound();
            }

            return View(nutritionCategory);
        }

        // POST: NutritionCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nutritionCategory = await _context.NutritionCategory.FindAsync(id);
            _context.NutritionCategory.Remove(nutritionCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutritionCategoryExists(int id)
        {
            return _context.NutritionCategory.Any(e => e.Id == id);
        }
    }
}
