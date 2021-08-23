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
    public class AdoptionDaysController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public AdoptionDaysController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: AdoptionDays
        public async Task<IActionResult> Index()
        {
            var q = from d in _context.AdoptionDays.OrderBy(x => x.DateandTime)
                    where(d.DateandTime>DateTime.Today)
                    select d;
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Search(string queryDate, string queryLocation)  // add search 
        {
            var q = from d in _context.AdoptionDays
                    where ((d.DateandTime.Date.ToString().Contains(queryDate) && queryLocation == null) || (queryDate == null && queryLocation == null)
                    || d.Location.Contains(queryLocation)
                    || d.DateandTime.Date.ToString().Contains(queryDate) && d.Location.Contains(queryLocation)
                    || queryDate == null && d.Location.Contains(queryLocation))
                    orderby d.DateandTime
                    select d;

            return View("Index", await q.ToListAsync());
        }

        // GET: AdoptionDays/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adoptionDays = await _context.AdoptionDays
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (adoptionDays == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(adoptionDays);
        //}

        [Authorize(Roles = "Admin , Editor")]
        // GET: AdoptionDays/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: AdoptionDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateandTime,Location,Discription")] AdoptionDays adoptionDays)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptionDays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adoptionDays);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: AdoptionDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionDays = await _context.AdoptionDays.FindAsync(id);
            if (adoptionDays == null)
            {
                return NotFound();
            }
            return View(adoptionDays);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: AdoptionDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateandTime,Location,Discription")] AdoptionDays adoptionDays)
        {
            if (id != adoptionDays.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionDays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionDaysExists(adoptionDays.Id))
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
            return View(adoptionDays);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: AdoptionDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionDays = await _context.AdoptionDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionDays == null)
            {
                return NotFound();
            }

            return View(adoptionDays);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: AdoptionDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptionDays = await _context.AdoptionDays.FindAsync(id);
            _context.AdoptionDays.Remove(adoptionDays);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionDaysExists(int id)
        {
            return _context.AdoptionDays.Any(e => e.Id == id);
        }
    }
}
