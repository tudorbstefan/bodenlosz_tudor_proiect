using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicBookStoreProject.Data;
using ComicBookStoreProject.Models;

namespace ComicBookStoreProject.Controllers
{
    public class ComicbooksController : Controller
    {
        private readonly ComicBookStoreProjectContext _context;

        public ComicbooksController(ComicBookStoreProjectContext context)
        {
            _context = context;
        }

        // GET: Comicbooks
        public async Task<IActionResult> Index()
        {
            var comicBookStoreProjectContext = _context.Comicbook.Include(c => c.Dimension).Include(c => c.Publisher);
            return View(await comicBookStoreProjectContext.ToListAsync());
        }

        // GET: Comicbooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicbook = await _context.Comicbook
                .Include(c => c.Dimension)
                .Include(c => c.Publisher)
                .FirstOrDefaultAsync(m => m.ISSN == id);
            if (comicbook == null)
            {
                return NotFound();
            }

            return View(comicbook);
        }

        // GET: Comicbooks/Create
        public IActionResult Create()
        {
            ViewData["DimensionID"] = new SelectList(_context.Dimension, "ID", "Size");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "Country");
            return View();
        }

        // POST: Comicbooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISSN,Title,PublisherID,Weight,DimensionID,Pages,Age,Price,PublishingDate")] Comicbook comicbook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comicbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DimensionID"] = new SelectList(_context.Dimension, "ID", "Size", comicbook.DimensionID);
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "Country", comicbook.PublisherID);
            return View(comicbook);
        }

        // GET: Comicbooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicbook = await _context.Comicbook.FindAsync(id);
            if (comicbook == null)
            {
                return NotFound();
            }
            ViewData["DimensionID"] = new SelectList(_context.Dimension, "ID", "Size", comicbook.DimensionID);
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "Country", comicbook.PublisherID);
            return View(comicbook);
        }

        // POST: Comicbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISSN,Title,PublisherID,Weight,DimensionID,Pages,Age,Price,PublishingDate")] Comicbook comicbook)
        {
            if (id != comicbook.ISSN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comicbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicbookExists(comicbook.ISSN))
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
            ViewData["DimensionID"] = new SelectList(_context.Dimension, "ID", "Size", comicbook.DimensionID);
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "Country", comicbook.PublisherID);
            return View(comicbook);
        }

        // GET: Comicbooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicbook = await _context.Comicbook
                .Include(c => c.Dimension)
                .Include(c => c.Publisher)
                .FirstOrDefaultAsync(m => m.ISSN == id);
            if (comicbook == null)
            {
                return NotFound();
            }

            return View(comicbook);
        }

        // POST: Comicbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comicbook = await _context.Comicbook.FindAsync(id);
            _context.Comicbook.Remove(comicbook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicbookExists(int id)
        {
            return _context.Comicbook.Any(e => e.ISSN == id);
        }
    }
}
