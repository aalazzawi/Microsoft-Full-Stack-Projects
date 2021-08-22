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
    public class ArticlesTypesController : Controller
    {
        private readonly TheDailyArticleContext _context;

        public ArticlesTypesController(TheDailyArticleContext context)
        {
            _context = context;
        }

        // GET: ArticlesTypes
        public async Task<IActionResult> Index()
        {
            var theDailyArticleContext = _context.ArticlesType.Include(a => a.Articles);
            return View(await theDailyArticleContext.ToListAsync());
        }

        // GET: ArticlesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesType = await _context.ArticlesType
                .Include(a => a.Articles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articlesType == null)
            {
                return NotFound();
            }

            return View(articlesType);
        }

        // GET: ArticlesTypes/Create
        public IActionResult Create()
        {
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id");
            return View();
        }

        // POST: ArticlesTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArticleType,ArticlesId")] ArticlesType articlesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articlesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id", articlesType.ArticlesId);
            return View(articlesType);
        }

        // GET: ArticlesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesType = await _context.ArticlesType.FindAsync(id);
            if (articlesType == null)
            {
                return NotFound();
            }
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id", articlesType.ArticlesId);
            return View(articlesType);
        }

        // POST: ArticlesTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArticleType,ArticlesId")] ArticlesType articlesType)
        {
            if (id != articlesType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articlesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesTypeExists(articlesType.Id))
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
            ViewData["ArticlesId"] = new SelectList(_context.Articles, "Id", "Id", articlesType.ArticlesId);
            return View(articlesType);
        }

        // GET: ArticlesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesType = await _context.ArticlesType
                .Include(a => a.Articles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articlesType == null)
            {
                return NotFound();
            }

            return View(articlesType);
        }

        // POST: ArticlesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articlesType = await _context.ArticlesType.FindAsync(id);
            _context.ArticlesType.Remove(articlesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticlesTypeExists(int id)
        {
            return _context.ArticlesType.Any(e => e.Id == id);
        }
    }
}
