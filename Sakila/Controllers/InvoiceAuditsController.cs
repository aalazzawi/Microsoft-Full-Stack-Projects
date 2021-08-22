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
    public class InvoiceAuditsController : Controller
    {
        private readonly SakilaContext _context;

        public InvoiceAuditsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: InvoiceAudits
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoiceAudit.ToListAsync());
        }

        // GET: InvoiceAudits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceAudit = await _context.InvoiceAudit
                .FirstOrDefaultAsync(m => m.InvoiceAuditId == id);
            if (invoiceAudit == null)
            {
                return NotFound();
            }

            return View(invoiceAudit);
        }

        // GET: InvoiceAudits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceAudits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceAuditId,InvoiceId,Username,DateAdded")] InvoiceAudit invoiceAudit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceAudit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceAudit);
        }

        // GET: InvoiceAudits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceAudit = await _context.InvoiceAudit.FindAsync(id);
            if (invoiceAudit == null)
            {
                return NotFound();
            }
            return View(invoiceAudit);
        }

        // POST: InvoiceAudits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceAuditId,InvoiceId,Username,DateAdded")] InvoiceAudit invoiceAudit)
        {
            if (id != invoiceAudit.InvoiceAuditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceAudit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceAuditExists(invoiceAudit.InvoiceAuditId))
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
            return View(invoiceAudit);
        }

        // GET: InvoiceAudits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceAudit = await _context.InvoiceAudit
                .FirstOrDefaultAsync(m => m.InvoiceAuditId == id);
            if (invoiceAudit == null)
            {
                return NotFound();
            }

            return View(invoiceAudit);
        }

        // POST: InvoiceAudits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceAudit = await _context.InvoiceAudit.FindAsync(id);
            _context.InvoiceAudit.Remove(invoiceAudit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceAuditExists(int id)
        {
            return _context.InvoiceAudit.Any(e => e.InvoiceAuditId == id);
        }
    }
}
