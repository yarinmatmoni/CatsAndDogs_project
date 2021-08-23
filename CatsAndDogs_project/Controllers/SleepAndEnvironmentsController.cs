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
    public class SleepAndEnvironmentsController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public SleepAndEnvironmentsController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: SleepAndEnvironments
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.SleepAndEnvironment.Include(s => s.Category);
            return View(await catsAndDogs_projectContext.ToListAsync());
        }

        // GET: SleepAndEnvironments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepAndEnvironment = await _context.SleepAndEnvironment
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepAndEnvironment == null)
            {
                return NotFound();
            }

            return View(sleepAndEnvironment);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: SleepAndEnvironments/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<SleepAndEnvironmentCategory>(), nameof(SleepAndEnvironmentCategory.Id), nameof(SleepAndEnvironmentCategory.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: SleepAndEnvironments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Recommendation,Price,Image,Type,CategoryId")] SleepAndEnvironment sleepAndEnvironment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sleepAndEnvironment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<SleepAndEnvironmentCategory>(), "Id", "Name", sleepAndEnvironment.CategoryId);
            return View(sleepAndEnvironment);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: SleepAndEnvironments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepAndEnvironment = await _context.SleepAndEnvironment.FindAsync(id);
            if (sleepAndEnvironment == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<SleepAndEnvironmentCategory>(), "Id", "Name", sleepAndEnvironment.CategoryId);
            return View(sleepAndEnvironment);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: SleepAndEnvironments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Recommendation,Price,Image,Type,CategoryId")] SleepAndEnvironment sleepAndEnvironment)
        {
            if (id != sleepAndEnvironment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sleepAndEnvironment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SleepAndEnvironmentExists(sleepAndEnvironment.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<SleepAndEnvironmentCategory>(), "Id", "Name", sleepAndEnvironment.CategoryId);
            return View(sleepAndEnvironment);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: SleepAndEnvironments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepAndEnvironment = await _context.SleepAndEnvironment
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepAndEnvironment == null)
            {
                return NotFound();
            }

            return View(sleepAndEnvironment);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: SleepAndEnvironments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sleepAndEnvironment = await _context.SleepAndEnvironment.FindAsync(id);
            _context.SleepAndEnvironment.Remove(sleepAndEnvironment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SleepAndEnvironmentExists(int id)
        {
            return _context.SleepAndEnvironment.Any(e => e.Id == id);
        }
    }
}
