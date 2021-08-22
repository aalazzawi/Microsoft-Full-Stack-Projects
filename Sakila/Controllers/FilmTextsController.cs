using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sakila.Models;

namespace sakila.Controllers
{
    public class FilmTextsController : Controller
    {
        private readonly SakilaContext _context;

        public FilmTextsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: FilmTexts
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmText.ToListAsync());
        }

        // GET: FilmTexts/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmText = await _context.FilmText
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (filmText == null)
            {
                return NotFound();
            }

            return View(filmText);
        }

        // GET: FilmTexts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmTexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmId,Title,Description")] FilmText filmText)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmText);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmText);
        }

        // GET: FilmTexts/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmText = await _context.FilmText.FindAsync(id);
            if (filmText == null)
            {
                return NotFound();
            }
            return View(filmText);
        }

        // POST: FilmTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("FilmId,Title,Description")] FilmText filmText)
        {
            if (id != filmText.FilmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmText);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmTextExists(filmText.FilmId))
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
            return View(filmText);
        }

        // GET: FilmTexts/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmText = await _context.FilmText
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (filmText == null)
            {
                return NotFound();
            }

            return View(filmText);
        }

        // POST: FilmTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var filmText = await _context.FilmText.FindAsync(id);
            _context.FilmText.Remove(filmText);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmTextExists(short id)
        {
            return _context.FilmText.Any(e => e.FilmId == id);
        }
    }
}
