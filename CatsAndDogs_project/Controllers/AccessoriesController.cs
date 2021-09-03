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
    
    public class AccessoriesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public AccessoriesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Accessories
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.Accessories.Include(a => a.Category);
            return View(await catsAndDogs_projectContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string query)
        {
            var q = from a in _context.Accessories.Include(b => b.Category)
                    where ((a.Type.Contains(query)) || a.Name.Contains(query) ||
                    a.Description.Contains(query) || a.Category.Name.Contains(query)) ||
                    a.Recommendation.Contains(query)
                    select a;
            if(query == null)
            {
                q = from a in _context.Accessories.Include(b => b.Category)
                    select a;
            }
            return View("Index", await q.ToListAsync());
        }

        public IActionResult Statistics() // map of number of dogs that have the same breed
                                          // shows only the breeds out dogs have.
        {
            var products = _context.Accessories.Include(a => a.Category).ToList();
            var categories = _context.AccessoriesCategory.ToList();

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

            foreach(var c in categories)
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



        [Authorize]
        // GET: Accessories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessories = await _context.Accessories
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessories == null)
            {
                return NotFound();
            }

            return View(accessories);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Accessories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<AccessoriesCategory>(), nameof(AccessoriesCategory.Id), nameof(AccessoriesCategory.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Accessories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Recommendation,Price,Image,Type,CategoryId")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<AccessoriesCategory>(), "Id", "Name", accessories.CategoryId);
            return View(accessories);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Accessories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessories = await _context.Accessories.FindAsync(id);
            if (accessories == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<AccessoriesCategory>(), "Id", "Name", accessories.CategoryId);
            return View(accessories);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Accessories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Recommendation,Price,Image,Type,CategoryId")] Accessories accessories)
        {
            if (id != accessories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessoriesExists(accessories.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<AccessoriesCategory>(), "Id", "Name", accessories.CategoryId);
            return View(accessories);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Accessories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessories = await _context.Accessories
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessories == null)
            {
                return NotFound();
            }

            return View(accessories);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessories = await _context.Accessories.FindAsync(id);
            _context.Accessories.Remove(accessories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessoriesExists(int id)
        {
            return _context.Accessories.Any(e => e.Id == id);
        }
    }
}
