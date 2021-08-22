using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlindDating.Models;

namespace BlindDating.Controllers
{
    public class MailMessagesController : Controller
    {
        private readonly BlindDatingContext _context;

        public MailMessagesController(BlindDatingContext context)
        {
            _context = context;
        }

        // GET: MailMessages
        public async Task<IActionResult> Index()
        {
            var blindDatingContext = _context.MailMessage.Include(m => m.FromProfile).Include(m => m.ToProfile);
            return View(await blindDatingContext.ToListAsync());
        }

        // GET: MailMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailMessage = await _context.MailMessage
                .Include(m => m.FromProfile)
                .Include(m => m.ToProfile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mailMessage == null)
            {
                return NotFound();
            }

            return View(mailMessage);
        }

        // GET: MailMessages/Create
        public IActionResult Create()
        {
            ViewData["FromProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id");
            ViewData["ToProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id");
            return View();
        }

        // POST: MailMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FromProfileId,ToProfileId,MessageTitle,MessageText,IsRead")] MailMessage mailMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mailMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id", mailMessage.FromProfileId);
            ViewData["ToProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id", mailMessage.ToProfileId);
            return View(mailMessage);
        }

        // GET: MailMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailMessage = await _context.MailMessage.FindAsync(id);
            if (mailMessage == null)
            {
                return NotFound();
            }
            ViewData["FromProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id", mailMessage.FromProfileId);
            ViewData["ToProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id", mailMessage.ToProfileId);
            return View(mailMessage);
        }

        // POST: MailMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FromProfileId,ToProfileId,MessageTitle,MessageText,IsRead")] MailMessage mailMessage)
        {
            if (id != mailMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mailMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MailMessageExists(mailMessage.Id))
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
            ViewData["FromProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id", mailMessage.FromProfileId);
            ViewData["ToProfileId"] = new SelectList(_context.DatingProfile, "Id", "Id", mailMessage.ToProfileId);
            return View(mailMessage);
        }

        // GET: MailMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailMessage = await _context.MailMessage
                .Include(m => m.FromProfile)
                .Include(m => m.ToProfile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mailMessage == null)
            {
                return NotFound();
            }

            return View(mailMessage);
        }

        // POST: MailMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mailMessage = await _context.MailMessage.FindAsync(id);
            _context.MailMessage.Remove(mailMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MailMessageExists(int id)
        {
            return _context.MailMessage.Any(e => e.Id == id);
        }
    }
}
