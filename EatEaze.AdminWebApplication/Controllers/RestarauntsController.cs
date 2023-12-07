using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using AutoMapper;
using EatEaze.AdminWebApplication.Models;

namespace EatEaze.AdminWebApplication.Controllers
{
    public class RestarauntsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly EatEazeDataContext _context;

        public RestarauntsController(EatEazeDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: Restaraunts
        public async Task<IActionResult> Index()
        {
            var eatEazeDataContext = _context.Restaraunts.Include(r => r.Category);
            return View(await eatEazeDataContext.ToListAsync());
        }

        // GET: Restaraunts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Restaraunts == null)
            {
                return NotFound();
            }

            var restaraunt = await _context.Restaraunts
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.RestarauntId == id);
            if (restaraunt == null)
            {
                return NotFound();
            }

            return View(restaraunt);
        }

        // GET: Restaraunts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Restaraunts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestarauntId,RestarauntName,ImageURL,CategoryId")] RestarauntsViewModel restaraunt)
        {
            if (ModelState.IsValid)
            {
                restaraunt.RestarauntId = Guid.NewGuid();
                _context.Add(_mapper.Map<Restaraunt>(restaraunt));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", restaraunt.CategoryId);
            return View(restaraunt);
        }

        // GET: Restaraunts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Restaraunts == null)
            {
                return NotFound();
            }

            var restaraunt = await _context.Restaraunts.FindAsync(id);
            if (restaraunt == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", restaraunt.CategoryId);
            return View(restaraunt);
        }

        // POST: Restaraunts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RestarauntId,RestarauntName,ImageURL,CategoryId")] RestarauntsViewModel restaraunt)
        {
            if (id != restaraunt.RestarauntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Restaraunt>(restaraunt));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestarauntExists(restaraunt.RestarauntId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", restaraunt.CategoryId);
            return View(restaraunt);
        }

        // GET: Restaraunts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Restaraunts == null)
            {
                return NotFound();
            }

            var restaraunt = await _context.Restaraunts
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.RestarauntId == id);
            if (restaraunt == null)
            {
                return NotFound();
            }

            return View(restaraunt);
        }

        // POST: Restaraunts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Restaraunts == null)
            {
                return Problem("Entity set 'EatEazeDataContext.Restaraunts'  is null.");
            }
            var restaraunt = await _context.Restaraunts.FindAsync(id);
            if (restaraunt != null)
            {
                _context.Restaraunts.Remove(restaraunt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestarauntExists(Guid id)
        {
          return (_context.Restaraunts?.Any(e => e.RestarauntId == id)).GetValueOrDefault();
        }
    }
}
