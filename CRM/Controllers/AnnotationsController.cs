using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Models;

namespace CRM.Controllers
{
    public class AnnotationsController : Controller
    {
        private readonly DatabaseContext _context;

        public AnnotationsController(DatabaseContext context)
        {
            _context = context;    
        }

        // GET: Annotations
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Annotations.Include(a => a.Contact);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Annotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annotations = await _context.Annotations
                .Include(a => a.Contact)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (annotations == null)
            {
                return NotFound();
            }

            return View(annotations);
        }

        // GET: Annotations/Create
        public IActionResult Create()
        {
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name");
            return View();
        }

        // POST: Annotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Description,ContactId")] Annotations annotations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(annotations);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name", annotations.ContactId);
            return View(annotations);
        }

        // GET: Annotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annotations = await _context.Annotations.SingleOrDefaultAsync(m => m.Id == id);
            if (annotations == null)
            {
                return NotFound();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name", annotations.ContactId);
            return View(annotations);
        }

        // POST: Annotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Description,ContactId")] Annotations annotations)
        {
            if (id != annotations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annotations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnotationsExists(annotations.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name", annotations.ContactId);
            return View(annotations);
        }

        // GET: Annotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annotations = await _context.Annotations
                .Include(a => a.Contact)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (annotations == null)
            {
                return NotFound();
            }

            return View(annotations);
        }

        // POST: Annotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var annotations = await _context.Annotations.SingleOrDefaultAsync(m => m.Id == id);
            _context.Annotations.Remove(annotations);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AnnotationsExists(int id)
        {
            return _context.Annotations.Any(e => e.Id == id);
        }
    }
}
