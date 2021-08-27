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
    public class Breed_2Controller : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public Breed_2Controller(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: Breed_2
        public async Task<IActionResult> Index()
        {
            var q = from b in _context.Breed_2.OrderBy(x => x.Name)
                    select b;
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Search(string queryName)  // add search 
        {
            var q = from b in _context.Breed_2
                    where (b.Name.Contains(queryName)) || (queryName == null)
                    orderby b.Name
                    select b;

            return View("Index", await q.ToListAsync());
        }

        // GET: Breed_2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed_2 = await _context.Breed_2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breed_2 == null)
            {
                return NotFound();
            }

            return View(breed_2);
        }

        // GET: Breed_2/Create
        public IActionResult Create()
        {
           // ViewData["ListDog"] = new SelectList(_context.Dog_2, nameof(Dog_2.Id), nameof(Dog_2.Name));
            return View();
        }

        // POST: Breed_2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Breed_2 breed_2) //,int[] ListDog)
        {
           // breed_2.ListDog = new List<Dog_2>();
           // breed_2.ListDog.AddRange(_context.Dog_2.Where(x => ListDog.Contains(x.Id)));

            if (ModelState.IsValid)
            {
                _context.Add(breed_2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breed_2);
        }

        // GET: Breed_2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed_2 = await _context.Breed_2.FindAsync(id);
            if (breed_2 == null)
            {
                return NotFound();
            }
            return View(breed_2);
        }

        // POST: Breed_2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Breed_2 breed_2)
        {
            if (id != breed_2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breed_2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Breed_2Exists(breed_2.Id))
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
            return View(breed_2);
        }

        // GET: Breed_2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed_2 = await _context.Breed_2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breed_2 == null)
            {
                return NotFound();
            }

            return View(breed_2);
        }

        // POST: Breed_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breed_2 = await _context.Breed_2.FindAsync(id);
            _context.Breed_2.Remove(breed_2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Breed_2Exists(int id)
        {
            return _context.Breed_2.Any(e => e.Id == id);
        }
    }
}
