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
    public class ArticalsCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public ArticalsCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: ArticalsCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticalsCategory.ToListAsync());
        }

        // GET: ArticalsCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articalsCategory = await _context.ArticalsCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articalsCategory == null)
            {
                return NotFound();
            }

            return View(articalsCategory);
        }

        // GET: ArticalsCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticalsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ArticalsCategory articalsCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articalsCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articalsCategory);
        }

        // GET: ArticalsCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articalsCategory = await _context.ArticalsCategory.FindAsync(id);
            if (articalsCategory == null)
            {
                return NotFound();
            }
            return View(articalsCategory);
        }

        // POST: ArticalsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ArticalsCategory articalsCategory)
        {
            if (id != articalsCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articalsCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticalsCategoryExists(articalsCategory.Id))
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
            return View(articalsCategory);
        }

        // GET: ArticalsCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articalsCategory = await _context.ArticalsCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articalsCategory == null)
            {
                return NotFound();
            }

            return View(articalsCategory);
        }

        // POST: ArticalsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articalsCategory = await _context.ArticalsCategory.FindAsync(id);
            _context.ArticalsCategory.Remove(articalsCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticalsCategoryExists(int id)
        {
            return _context.ArticalsCategory.Any(e => e.Id == id);
        }
    }
}
