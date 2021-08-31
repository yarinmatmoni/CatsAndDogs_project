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
    public class GuideDogsController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public GuideDogsController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: GuideDogs
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.GuideDog.Include(g => g.BreedDog);
            return View(await catsAndDogs_projectContext.ToListAsync());


            //var allDogs = await _context.Dog_2.ToListAsync();
            //var allGuides = await _context.GuideDog.ToListAsync();

            //var output = from a in allDogs
            //             join b in allGuides
            //             on a.ListBreed.ElementAt(0) equals b.BreedDog
            //             select (b.BreedDog, a.Name, a.Age, b.AvgLife, a.Description, b.Description, b.Health, b.Training);



            //return View( output.ToList());

        }


        public async Task<IActionResult> Search( string queryBreed)
        {
            var q = from b in _context.GuideDog.Include(g => g.BreedDog)
            where (b.BreedDog.Name.Contains(queryBreed)) || (queryBreed == null)
                    orderby b.BreedDog.Name
                    select b;

            return View("Index", await q.ToListAsync());
            
        }


        // GET: GuideDogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideDog = await _context.GuideDog
                .Include(g => g.BreedDog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guideDog == null)
            {
                return NotFound();
            }

            return View(guideDog);
        }
        
        // GET: GuideDogs/Create
        public IActionResult Create()
        {
            ViewData["Breed_2Id"] = new SelectList(_context.Breed_2, nameof(Breed_2.Id), nameof(Breed_2.Name)); /////
            return View();
        }

        // POST: GuideDogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageGuied,Image,Breed_2Id,AvgLife,AvgWeight,AvgHeight,Description,Characteristics,Health,Training")] GuideDog guideDog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guideDog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Breed_2Id"] = new SelectList(_context.Breed_2, "Id", "Name", guideDog.Breed_2Id);
            return View(guideDog);
        }

        // GET: GuideDogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideDog = await _context.GuideDog.FindAsync(id);
            if (guideDog == null)
            {
                return NotFound();
            }
            ViewData["Breed_2Id"] = new SelectList(_context.Breed_2, "Id", "Name", guideDog.Breed_2Id);
            return View(guideDog);
        }

        // POST: GuideDogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageGuied,Image,Breed_2Id,AvgLife,AvgWeight,AvgHeight,Description,Characteristics,Health,Training")] GuideDog guideDog)
        {
            if (id != guideDog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guideDog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuideDogExists(guideDog.Id))
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
            ViewData["Breed_2Id"] = new SelectList(_context.Breed_2, "Id", "Name", guideDog.Breed_2Id);
            return View(guideDog);
        }

        // GET: GuideDogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guideDog = await _context.GuideDog
                .Include(g => g.BreedDog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guideDog == null)
            {
                return NotFound();
            }

            return View(guideDog);
        }

        // POST: GuideDogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guideDog = await _context.GuideDog.FindAsync(id);
            _context.GuideDog.Remove(guideDog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuideDogExists(int id)
        {
            return _context.GuideDog.Any(e => e.Id == id);
        }
    }
}
