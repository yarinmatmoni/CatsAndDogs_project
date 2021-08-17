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
    public class AccessoriesCategoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public AccessoriesCategoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: AccessoriesCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccessoriesCategory.ToListAsync());
        }

        // GET: AccessoriesCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoriesCategory = await _context.AccessoriesCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessoriesCategory == null)
            {
                return NotFound();
            }

            return View(accessoriesCategory);
        }

        // GET: AccessoriesCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccessoriesCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AccessoriesCategory accessoriesCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessoriesCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accessoriesCategory);
        }

        // GET: AccessoriesCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoriesCategory = await _context.AccessoriesCategory.FindAsync(id);
            if (accessoriesCategory == null)
            {
                return NotFound();
            }
            return View(accessoriesCategory);
        }

        // POST: AccessoriesCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AccessoriesCategory accessoriesCategory)
        {
            if (id != accessoriesCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessoriesCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessoriesCategoryExists(accessoriesCategory.Id))
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
            return View(accessoriesCategory);
        }

        // GET: AccessoriesCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessoriesCategory = await _context.AccessoriesCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessoriesCategory == null)
            {
                return NotFound();
            }

            return View(accessoriesCategory);
        }

        // POST: AccessoriesCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessoriesCategory = await _context.AccessoriesCategory.FindAsync(id);
            _context.AccessoriesCategory.Remove(accessoriesCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessoriesCategoryExists(int id)
        {
            return _context.AccessoriesCategory.Any(e => e.Id == id);
        }
    }
}
