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
    public class Dog_2Controller : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public Dog_2Controller(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: Dog_2
        public async Task<IActionResult> Index()
        {
            var CatsAndDogs_projectContext = _context.Dog_2.Include(b => b.ListBreed);
            return View(await CatsAndDogs_projectContext.ToListAsync());

        }


        public async Task<IActionResult> Search(string queryBreed, string querySize)  // add search 
        {
            var q = from d in _context.Dog_2.Include(b => b.ListBreed)
                    where ((d.Size.Contains(querySize) && queryBreed==null) || (querySize==null && queryBreed==null)
                    || d.ListBreed.Any(n=>n.Name.Contains(queryBreed) 
                    || d.Size.Contains(querySize)&& d.ListBreed.Any(n => n.Name.Contains(queryBreed)))
                    || querySize== null && d.ListBreed.Any(n => n.Name.Contains(queryBreed)))
                    select d;
           
            return View("Index",await q.ToListAsync());
        }

        // GET: Dog_2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog_2 = await _context.Dog_2.Include(b=>b.ListBreed).FirstOrDefaultAsync(m => m.Id == id);
            if (dog_2 == null)
            {
                return NotFound();
            }

            return View(dog_2);
        }

        public async Task<IActionResult> MoreDetails(int? id)
        {
           
            var dog = await _context.Dog_2.Include(b => b.ListBreed).Where(b => b.Id == id).ToListAsync(); 
            var breed = await _context.Breed_2.ToListAsync();

            var output = from d in dog
                         join b in breed
                         on d.ListBreed.First().Id equals b.Id into res
                         select res;

            var breedName = output.ElementAt(0).ElementAt(0).Id;

            var guide = _context.GuideDog.Where(g => g.Breed_2Id == breedName).First();


            return RedirectToAction("Details", "GuideDogs", new { id = guide.Id });

        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Dog_2/Create
        public IActionResult Create()
        {
            ViewData["ListBreed"] = new SelectList(_context.Breed_2, nameof(Breed_2.Id), nameof(Breed_2.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Dog_2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Size,Gender,Color,LifeExpectancy,Match,Description,Image,ListBreed")] Dog_2 dog_2 ,int[] ListBreed) ////
        {
                dog_2.ListBreed = new List<Breed_2>();
                dog_2.ListBreed.AddRange(_context.Breed_2.Where(x => ListBreed.Contains(x.Id)));

            if (ModelState.IsValid)
            {

                _context.Add(dog_2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["ListBreed"] = new SelectList(_context.Set<Breed_2>(), nameof(Breed_2.Id), nameof(Breed_2.Name), dog_2.ListBreed);
            return View(dog_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Dog_2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog_2 = await _context.Dog_2.FindAsync(id);
            if (dog_2 == null)
            {
                return NotFound();
            }
            ViewData["ListBreed"] = new SelectList(_context.Set<Breed_2>(), nameof(Breed_2.Id), nameof(Breed_2.Name), dog_2.ListBreed);
            return View(dog_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Dog_2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Size,Gender,Color,LifeExpectancy,Match,Description,Image,ListBreed")] Dog_2 dog_2 , int[] ListBreed)
        {

            if (id != dog_2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //dog_2.ListBreed = new List<Breed_2>();
                //dog_2.ListBreed.AddRange(_context.Breed_2.Where(x => ListBreed.Contains(x.Id)));

                try
                {
                    _context.Update(dog_2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Dog_2Exists(dog_2.Id))
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
            ViewData["ListBreed"] = new SelectList(_context.Set<Breed_2>(), nameof(Breed_2.Id), nameof(Breed_2.Name), dog_2.ListBreed);
            return View(dog_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Dog_2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog_2 = await _context.Dog_2.Include(b=>b.ListBreed).FirstOrDefaultAsync(m => m.Id == id);
            if (dog_2 == null)
            {
                return NotFound();
            }

            return View(dog_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Dog_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dog_2 = await _context.Dog_2.FindAsync(id);
            _context.Dog_2.Remove(dog_2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Dog_2Exists(int id)
        {
            return _context.Dog_2.Any(e => e.Id == id);
        }
    }
}
