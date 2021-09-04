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
    public class Cat_2Controller : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public Cat_2Controller(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: Cat_2
        public async Task<IActionResult> Index()
        {
            var CatsAndDogs_projectContext = _context.Cat_2.Include(b => b.BreedCatList);
            return View(await CatsAndDogs_projectContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string queryBreed, string queryGander)  // add search 
        {
            var q = from c in _context.Cat_2.Include(b => b.BreedCatList)
                    where ((c.Gender.Contains(queryGander) && queryBreed == null) || (queryGander == null && queryBreed == null)
                    || c.BreedCatList.Any(n => n.Name.Contains(queryBreed)
                    || c.Gender.Contains(queryGander) && c.BreedCatList.Any(n => n.Name.Contains(queryBreed)))
                    || queryGander == null && c.BreedCatList.Any(n => n.Name.Contains(queryBreed)))
                    select c;

            return View("Index", await q.ToListAsync());
        }

        // GET: Cat_2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_2 = await _context.Cat_2.Include(b=>b.BreedCatList).FirstOrDefaultAsync(m => m.Id == id);
            if (cat_2 == null)
            {
                return NotFound();
            }

            return View(cat_2);
        }

        public IActionResult Statistics() // map of number of dogs that have the same breed
                                          // shows only the breeds out dogs have.
        {
            var cats = _context.Cat_2.Include(d => d.BreedCatList).ToList();
            //var breeds = _context.BreedCat_2.ToList();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var cat in cats)
            {
                string cname = cat.BreedCatList.First().Name;
                if (dictionary.ContainsKey(cname))
                {
                    dictionary[cname]++;
                }
                else
                {
                    dictionary.Add(cname, 1);
                }
            }

            var catbreed = dictionary.Keys.ToList();

            var query = from db in catbreed select new { label = db, y = dictionary[db] };

            ViewData["Graph"] = JsonConvert.SerializeObject(query); // Serializes the specified object to a JSON string.

            return View();
        }



        public async Task<IActionResult> MoreDetails(int? id)
        {

            var cat = await _context.Cat_2.Include(b => b.BreedCatList).Where(b => b.Id == id).ToListAsync();
            var breed = await _context.BreedCat_2.ToListAsync();

            var output = from d in cat
                         join b in breed
                         on d.BreedCatList.First().Id equals b.Id into res
                         select res;

            var breedId = output.ElementAt(0).ElementAt(0).Id;

            var list = _context.GuideCat.ToList();

            var ok = false;
            foreach (var l in list)
            {

                if (l.BreedCat_2Id.Equals(breedId))
                {
                    ok = true;
                }
            }
            if (ok)
            {
                var guide = _context.GuideCat.Where(g => g.BreedCat_2Id == breedId).First();
                return RedirectToAction("Details", "GuideCats", new { id = guide.Id });
            }

            return RedirectToAction("Index", "GuideCats");
        }


        [Authorize(Roles = "Admin , Editor")]
        // GET: Cat_2/Create
        public IActionResult Create()
        {
            ViewData["BreedCatList"] = new SelectList(_context.BreedCat_2, nameof(BreedCat_2.Id), nameof(BreedCat_2.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Cat_2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Gender,Color,LifeExpectancy,Description,Image,BreedCatList")] Cat_2 cat_2, int[] BreedCatList)
        {
            cat_2.BreedCatList = new List<BreedCat_2>();
            cat_2.BreedCatList.AddRange(_context.BreedCat_2.Where(x => BreedCatList.Contains(x.Id)));

            if (ModelState.IsValid)
            {
                _context.Add(cat_2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BreedCatList"] = new SelectList(_context.Set<BreedCat_2>(), nameof(BreedCat_2.Id), nameof(BreedCat_2.Name), cat_2.BreedCatList);
            return View(cat_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Cat_2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_2 = await _context.Cat_2.FindAsync(id);
            if (cat_2 == null)
            {
                return NotFound();
            }
            ViewData["BreedCatList"] = new SelectList(_context.Set<BreedCat_2>(), nameof(BreedCat_2.Id), nameof(BreedCat_2.Name), cat_2.BreedCatList);
            return View(cat_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Cat_2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Gender,Color,LifeExpectancy,Description,Image,BreedCatList")] Cat_2 cat_2,int[] BreedCatList)
        {
            if (id != cat_2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat_2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cat_2Exists(cat_2.Id))
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
            ViewData["BreedCatList"] = new SelectList(_context.Set<BreedCat_2>(), nameof(BreedCat_2.Id), nameof(BreedCat_2.Name), cat_2.BreedCatList);
            return View(cat_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Cat_2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat_2 = await _context.Cat_2.Include(b=>b.BreedCatList).FirstOrDefaultAsync(m => m.Id == id);
            if (cat_2 == null)
            {
                return NotFound();
            }

            return View(cat_2);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Cat_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat_2 = await _context.Cat_2.FindAsync(id);
            _context.Cat_2.Remove(cat_2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cat_2Exists(int id)
        {
            return _context.Cat_2.Any(e => e.Id == id);
        }
    }
}
