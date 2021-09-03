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
using Newtonsoft.Json;

namespace CatsAndDogs_project.Controllers
{
    [Authorize]
    public class HealthsController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public HealthsController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: Healths
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.Health.Include(h => h.Category);
            return View(await catsAndDogs_projectContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string query)
        {
            var q = from a in _context.Health.Include(b => b.Category)
                    where ((a.Type.Contains(query)) || a.Name.Contains(query) ||
                    a.Description.Contains(query) || a.Category.Name.Contains(query))
                    
                    select a;
           
            if (query == null)
            {
                q = from a in _context.Health.Include(b => b.Category)
                    select a;
            }


            return View("Index", await q.ToListAsync());
        }

        public IActionResult Statistics() // map of number of dogs that have the same breed
                                          // shows only the breeds out dogs have.
        {
            var products = _context.Health.Include(a => a.Category).ToList();
            var categories = _context.HealthCategory.ToList();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var product in products)
            {
                string pname = product.Category.Name;
                if (dictionary.ContainsKey(pname))
                {
                    dictionary[pname]++;
                }
                else
                {
                    dictionary.Add(pname, 1);
                }
            }
            foreach (var c in categories)
            {
                var cname = c.Name;
                if (!(dictionary.ContainsKey(cname)))
                {
                    dictionary.Add(cname, 0);
                }
            }

            var productCategory = dictionary.Keys.ToList();

            var query = from db in productCategory select new { label = db, y = dictionary[db] };

            ViewData["Graph"] = JsonConvert.SerializeObject(query); // Serializes the specified object to a JSON string.

            return View();
        }


        // GET: Healths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var health = await _context.Health
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (health == null)
            {
                return NotFound();
            }

            return View(health);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Healths/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.HealthCategory, nameof(HealthCategory.Id), nameof(HealthCategory.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Healths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Image,Type,CategoryId")] Health health)
        {
            if (ModelState.IsValid)
            {
                _context.Add(health);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.HealthCategory, "Id", "Name", health.CategoryId);
            return View(health);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Healths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var health = await _context.Health.FindAsync(id);
            if (health == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.HealthCategory, "Id", "Name", health.CategoryId);
            return View(health);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Healths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Image,Type,CategoryId")] Health health)
        {
            if (id != health.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(health);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthExists(health.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.HealthCategory, "Id", "Name", health.CategoryId);
            return View(health);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Healths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var health = await _context.Health
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (health == null)
            {
                return NotFound();
            }

            return View(health);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Healths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var health = await _context.Health.FindAsync(id);
            _context.Health.Remove(health);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthExists(int id)
        {
            return _context.Health.Any(e => e.Id == id);
        }
    }
}
