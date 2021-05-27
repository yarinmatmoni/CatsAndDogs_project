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
    public class ProdectsSubCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public ProdectsSubCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: ProdectsSubCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProdectsSubCategory.ToListAsync());
        }

        // GET: ProdectsSubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodectsSubCategory = await _context.ProdectsSubCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodectsSubCategory == null)
            {
                return NotFound();
            }

            return View(prodectsSubCategory);
        }

        // GET: ProdectsSubCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdectsSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProdectsSubCategory prodectsSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodectsSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodectsSubCategory);
        }

        // GET: ProdectsSubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodectsSubCategory = await _context.ProdectsSubCategory.FindAsync(id);
            if (prodectsSubCategory == null)
            {
                return NotFound();
            }
            return View(prodectsSubCategory);
        }

        // POST: ProdectsSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProdectsSubCategory prodectsSubCategory)
        {
            if (id != prodectsSubCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodectsSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdectsSubCategoryExists(prodectsSubCategory.Id))
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
            return View(prodectsSubCategory);
        }

        // GET: ProdectsSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodectsSubCategory = await _context.ProdectsSubCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodectsSubCategory == null)
            {
                return NotFound();
            }

            return View(prodectsSubCategory);
        }

        // POST: ProdectsSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodectsSubCategory = await _context.ProdectsSubCategory.FindAsync(id);
            _context.ProdectsSubCategory.Remove(prodectsSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdectsSubCategoryExists(int id)
        {
            return _context.ProdectsSubCategory.Any(e => e.Id == id);
        }
    }
}
