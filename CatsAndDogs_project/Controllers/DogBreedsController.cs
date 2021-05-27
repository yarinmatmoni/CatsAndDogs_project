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
            return View(await _context.DogBreed.ToListAsync());
        }

        // GET: DogBreeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreed = await _context.DogBreed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogBreed == null)
            {
                return NotFound();
            }

            return View(dogBreed);
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
        public async Task<IActionResult> Create([Bind("Id,Name")] DogBreed dogBreed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogBreed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogBreed);
        }

        // GET: DogBreeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreed = await _context.DogBreed.FindAsync(id);
            if (dogBreed == null)
            {
                return NotFound();
            }
            return View(dogBreed);
        }

        // POST: DogBreeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DogBreed dogBreed)
        {
            if (id != dogBreed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogBreed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogBreedExists(dogBreed.Id))
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
            return View(dogBreed);
        }

        // GET: DogBreeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreed = await _context.DogBreed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogBreed == null)
            {
                return NotFound();
            }

            return View(dogBreed);
        }

        // POST: DogBreeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogBreed = await _context.DogBreed.FindAsync(id);
            _context.DogBreed.Remove(dogBreed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogBreedExists(int id)
        {
            return _context.DogBreed.Any(e => e.Id == id);
        }
    }
}
