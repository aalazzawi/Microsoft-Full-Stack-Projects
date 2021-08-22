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
    public class Inventories1Controller : Controller
    {
        private readonly SakilaContext _context;

        public Inventories1Controller(SakilaContext context)
        {
            _context = context;
        }

        // GET: Inventories1
        public async Task<IActionResult> Index()
        {
            var sakilaContext = _context.Inventory.Include(i => i.Film).Include(i => i.Store);
            return View(await sakilaContext.ToListAsync());
        }

        // GET: Inventories1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .Include(i => i.Film)
                .Include(i => i.Store)
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories1/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Film, "FilmId", "Title");
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId");
            return View();
        }

        // POST: Inventories1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryId,FilmId,StoreId,LastUpdate")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Film, "FilmId", "Title", inventory.FilmId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId", inventory.StoreId);
            return View(inventory);
        }

        // GET: Inventories1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Film, "FilmId", "Title", inventory.FilmId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId", inventory.StoreId);
            return View(inventory);
        }

        // POST: Inventories1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryId,FilmId,StoreId,LastUpdate")] Inventory inventory)
        {
            if (id != inventory.InventoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.InventoryId))
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
            ViewData["FilmId"] = new SelectList(_context.Film, "FilmId", "Title", inventory.FilmId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId", inventory.StoreId);
            return View(inventory);
        }

        // GET: Inventories1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .Include(i => i.Film)
                .Include(i => i.Store)
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.InventoryId == id);
        }
    }
}
