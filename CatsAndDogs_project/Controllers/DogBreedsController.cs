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
    public class DogBreedsController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public DogBreedsController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: DogBreeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.DogBreeds.ToListAsync());
        }

        // GET: DogBreeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreeds = await _context.DogBreeds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogBreeds == null)
            {
                return NotFound();
            }

            return View(dogBreeds);
        }

        // GET: DogBreeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogBreeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DogBreeds dogBreeds)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogBreeds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogBreeds);
        }

        // GET: DogBreeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreeds = await _context.DogBreeds.FindAsync(id);
            if (dogBreeds == null)
            {
                return NotFound();
            }
            return View(dogBreeds);
        }

        // POST: DogBreeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DogBreeds dogBreeds)
        {
            if (id != dogBreeds.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogBreeds);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogBreedsExists(dogBreeds.Id))
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
            return View(dogBreeds);
        }

        // GET: DogBreeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreeds = await _context.DogBreeds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogBreeds == null)
            {
                return NotFound();
            }

            return View(dogBreeds);
        }

        // POST: DogBreeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogBreeds = await _context.DogBreeds.FindAsync(id);
            _context.DogBreeds.Remove(dogBreeds);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogBreedsExists(int id)
        {
            return _context.DogBreeds.Any(e => e.Id == id);
        }
    }
}
