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
    public class BreedCat_2Controller : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public BreedCat_2Controller(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: BreedCat_2
        public async Task<IActionResult> Index()
        {
            var q = from b in _context.BreedCat_2.OrderBy(x => x.Name)
                    select b;

            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Search(string queryName)  // add search 
        {
            var q = from b in _context.BreedCat_2
                    where (b.Name.Contains(queryName)) || (queryName == null)
                    orderby b.Name
                    select b;

            return View("Index", await q.ToListAsync());
        }


        // GET: BreedCat_2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breedCat_2 = await _context.BreedCat_2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breedCat_2 == null)
            {
                return NotFound();
            }

            return View(breedCat_2);
        }

        // GET: BreedCat_2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BreedCat_2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BreedCat_2 breedCat_2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breedCat_2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breedCat_2);
        }

        // GET: BreedCat_2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breedCat_2 = await _context.BreedCat_2.FindAsync(id);
            if (breedCat_2 == null)
            {
                return NotFound();
            }
            return View(breedCat_2);
        }

        // POST: BreedCat_2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BreedCat_2 breedCat_2)
        {
            if (id != breedCat_2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breedCat_2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreedCat_2Exists(breedCat_2.Id))
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
            return View(breedCat_2);
        }

        // GET: BreedCat_2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breedCat_2 = await _context.BreedCat_2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breedCat_2 == null)
            {
                return NotFound();
            }

            return View(breedCat_2);
        }

        // POST: BreedCat_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breedCat_2 = await _context.BreedCat_2.FindAsync(id);
            _context.BreedCat_2.Remove(breedCat_2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreedCat_2Exists(int id)
        {
            return _context.BreedCat_2.Any(e => e.Id == id);
        }
    }
}
