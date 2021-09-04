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
    public class ArticlesController : Controller
    {
        private readonly CatsAndDogs_projectContext _context;

        public ArticlesController(CatsAndDogs_projectContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var catsAndDogs_projectContext = _context.Articles.Include(a => a.Category);
            return View(await catsAndDogs_projectContext.ToListAsync());
        }

        public async Task<IActionResult> NewPuppy()
        {
            return View(await _context.Articles.ToListAsync());
        }

        public async Task<IActionResult> ChooseName()
        {
            return View(await _context.Articles.ToListAsync());
        }

        public async Task<IActionResult> Search(string queryCategory)  // add search 
        {
            var q = from a in _context.Articles.Include(c => c.Category)
                    where ((a.Category.Name.Contains(queryCategory)) || (queryCategory == null))
                    select a;

            return View("Index", await q.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_context.Set<ArticalsCategory>(), nameof(ArticalsCategory.Id), nameof(ArticalsCategory.Name));
            return View();
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titel,Author,CreationDate,LastUpDate,Summary,Body,Img,categoryId")] Articles articles)
        {
            var date = DateTime.Now;
            var bol = false;
            if ((articles.CreationDate.Date < date.Date)  || articles.CreationDate.Date > date.Date)
            {
                bol = true;
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid && bol == false)
            {

                _context.Add(articles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["categoryId"] = new SelectList(_context.Set<ArticalsCategory>(), nameof(ArticalsCategory.Id), nameof(ArticalsCategory.Name), articles.categoryId);
            return View(articles);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }
            ViewData["categoryId"] = new SelectList(_context.Set<ArticalsCategory>(), nameof(ArticalsCategory.Id), nameof(ArticalsCategory.Name), articles.categoryId);
            return View(articles);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titel,Author,CreationDate,LastUpDate,Summary,Body,Img,categoryId")] Articles articles)
        {
            if (id != articles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesExists(articles.Id))
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
            ViewData["categoryId"] = new SelectList(_context.Set<ArticalsCategory>(), nameof(ArticalsCategory.Id), nameof(ArticalsCategory.Name), articles.categoryId);
            return View(articles);
        }

        [Authorize(Roles = "Admin , Editor")]
        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        [Authorize(Roles = "Admin , Editor")]
        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articles = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(articles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticlesExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
