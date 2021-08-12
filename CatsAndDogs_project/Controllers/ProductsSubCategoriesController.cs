using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatsAndDogs_project.Data;
using CatsAndDogs_project.Models;
using CatsAndDogs.Models;

namespace CatsAndDogs_project.Controllers
{
    public class ProductsSubCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public ProductsSubCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: ProductsSubCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductsSubCategory.ToListAsync());
        }

        // GET: ProductsSubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsSubCategory = await _context.ProductsSubCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsSubCategory == null)
            {
                return NotFound();
            }

            return View(productsSubCategory);
        }

        // GET: ProductsSubCategories/Create
        public IActionResult Create()
        {
            ViewData["products"] = new SelectList(_context.Products.Where(x => x.CategoryId == null), nameof(Products.Id), nameof(Products.Name));
            return View();
        }

        // POST: ProductsSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId")] ProductsSubCategory productsSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsSubCategory);
        }

        // GET: ProductsSubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsSubCategory = await _context.ProductsSubCategory.FindAsync(id);
            if (productsSubCategory == null)
            {
                return NotFound();
            }
            return View(productsSubCategory);
        }

        // POST: ProductsSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductsSubCategory productsSubCategory)
        {
            if (id != productsSubCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsSubCategoryExists(productsSubCategory.Id))
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
            return View(productsSubCategory);
        }

        // GET: ProductsSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsSubCategory = await _context.ProductsSubCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsSubCategory == null)
            {
                return NotFound();
            }

            return View(productsSubCategory);
        }

        // POST: ProductsSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsSubCategory = await _context.ProductsSubCategory.FindAsync(id);
            _context.ProductsSubCategory.Remove(productsSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsSubCategoryExists(int id)
        {
            return _context.ProductsSubCategory.Any(e => e.Id == id);
        }
    }
}
