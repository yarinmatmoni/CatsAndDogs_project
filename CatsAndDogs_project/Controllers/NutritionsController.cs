﻿using System;
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
    public class NutritionsController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public NutritionsController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: Nutritions
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.Nutrition.Include(n => n.Category);
            return View(await catsAndDogs_projectContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string query)
        {
            var q = from a in _context.Nutrition.Include(b => b.Category)
                    where ((a.Type.Contains(query)) || a.Name.Contains(query) ||
                    a.Advantages.Contains(query) || a.Description.Contains(query) ||
                    a.Category.Name.Contains(query)) || a.matching.Contains(query)
                    select a;

            if (query == null)
            {
                q = from a in _context.Nutrition.Include(b => b.Category)
                    select a;
            }

            return View("Index", await q.ToListAsync());

            //var catsAndDogs_projectContext = _context.Nutrition.Include(n => n.Category);
            //return View(await catsAndDogs_projectContext.ToListAsync());
        }



        // GET: Nutritions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutrition
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Nutritions/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<NutritionCategory>(), nameof(NutritionCategory.Id),nameof(NutritionCategory.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Nutritions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Advantages,matching,Price,Image,Type,CategoryId")] Nutrition nutrition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nutrition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<NutritionCategory>(), "Id", "Name", nutrition.CategoryId);
            return View(nutrition);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Nutritions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutrition.FindAsync(id);
            if (nutrition == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<NutritionCategory>(), "Id", "Name", nutrition.CategoryId);
            return View(nutrition);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Nutritions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Advantages,matching,Price,Image,Type,CategoryId")] Nutrition nutrition)
        {
            if (id != nutrition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutrition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutritionExists(nutrition.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<NutritionCategory>(), "Id", "Name", nutrition.CategoryId);
            return View(nutrition);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Nutritions/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutrition
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Nutritions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nutrition = await _context.Nutrition.FindAsync(id);
            _context.Nutrition.Remove(nutrition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutritionExists(int id)
        {
            return _context.Nutrition.Any(e => e.Id == id);
        }
    }
}
