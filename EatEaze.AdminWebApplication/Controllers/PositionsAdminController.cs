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
    public class PositionsAdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly EatEazeDataContext _context;

        public PositionsAdminController(EatEazeDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: PositionsAdmin
        public async Task<IActionResult> Index()
        {
            var eatEazeDataContext = _context.Positions.Include(p => p.Category).Include(p => p.Restaraunt);
            return View(await eatEazeDataContext.ToListAsync());
        }

        // GET: PositionsAdmin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.Category)
                .Include(p => p.Restaraunt)
                .FirstOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: PositionsAdmin/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["RestarauntId"] = new SelectList(_context.Restaraunts, "RestarauntId", "RestarauntName");
            return View();
        }

        // POST: PositionsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionId,PositionName,RestarauntId,CategoryId,Count,Price,ImageURL")] PositionsViewModel position)
        {
            if (ModelState.IsValid)
            {
                position.PositionId = Guid.NewGuid();
                _context.Add(_mapper.Map<Position>(position));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", position.CategoryId);
            ViewData["RestarauntId"] = new SelectList(_context.Restaraunts, "RestarauntId", "RestarauntName", position.RestarauntId);
            return View(position);
        }

        // GET: PositionsAdmin/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", position.CategoryId);
            ViewData["RestarauntId"] = new SelectList(_context.Restaraunts, "RestarauntId", "RestarauntName", position.RestarauntId);
            return View(position);
        }

        // POST: PositionsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PositionId,PositionName,RestarauntId,CategoryId,Count,Price,ImageURL")] PositionsViewModel position)
        {
            if (id != position.PositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Position>(position));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.PositionId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", position.CategoryId);
            ViewData["RestarauntId"] = new SelectList(_context.Restaraunts, "RestarauntId", "RestarauntName", position.RestarauntId);
            return View(position);
        }

        // GET: PositionsAdmin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.Category)
                .Include(p => p.Restaraunt)
                .FirstOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: PositionsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Positions == null)
            {
                return Problem("Entity set 'EatEazeDataContext.Positions'  is null.");
            }
            var position = await _context.Positions.FindAsync(id);
            if (position != null)
            {
                _context.Positions.Remove(position);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(Guid id)
        {
          return (_context.Positions?.Any(e => e.PositionId == id)).GetValueOrDefault();
        }
    }
}
