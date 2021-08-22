using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDailyArticle.Data;
using TheDailyArticle.Models;

namespace TheDailyArticle.Controllers
{
    public class EditorsController : Controller
    {
        private readonly TheDailyArticleContext _context;

        public EditorsController(TheDailyArticleContext context)
        {
            _context = context;
        }

        // GET: Editors
        public async Task<IActionResult> Index()
        {
            var theDailyArticleContext = _context.Editors.Include(e => e.Articles);
            return View(await theDailyArticleContext.ToListAsync());
        }

        // GET: Editors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editors = await _context.Editors
                .Include(e => e.Articles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editors == null)
            {
                return NotFound();
            }

            return View(editors);
        }

        // GET: Editors/Create
        public IActionResult Create()
        {
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id");
            return View();
        }

        // POST: Editors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,EmailAddress,ArticlesId")] Editors editors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id", editors.ArticlesId);
            return View(editors);
        }

        // GET: Editors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editors = await _context.Editors.FindAsync(id);
            if (editors == null)
            {
                return NotFound();
            }
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id", editors.ArticlesId);
            return View(editors);
        }

        // POST: Editors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,EmailAddress,ArticlesId")] Editors editors)
        {
            if (id != editors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorsExists(editors.Id))
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
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id", editors.ArticlesId);
            return View(editors);
        }

        // GET: Editors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editors = await _context.Editors
                .Include(e => e.Articles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editors == null)
            {
                return NotFound();
            }

            return View(editors);
        }

        // POST: Editors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editors = await _context.Editors.FindAsync(id);
            _context.Editors.Remove(editors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorsExists(int id)
        {
            return _context.Editors.Any(e => e.Id == id);
        }
    }
}
