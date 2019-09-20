using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rezokoKanriApp.Models;

namespace rezokoKanriApp.Controllers
{
    public class StoredItemsClassesController : Controller
    {
        private readonly rezokoKanriAppContext _context;

        public StoredItemsClassesController(rezokoKanriAppContext context)
        {
            _context = context;
        }

        // GET: StoredItemsClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoredItemsClass.ToListAsync());
        }

        // GET: StoredItemsClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storedItemsClass = await _context.StoredItemsClass
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (storedItemsClass == null)
            {
                return NotFound();
            }

            return View(storedItemsClass);
        }

        // GET: StoredItemsClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoredItemsClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,LocationName,ExpireDate")] StoredItemsClass storedItemsClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storedItemsClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storedItemsClass);
        }

        // GET: StoredItemsClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storedItemsClass = await _context.StoredItemsClass.FindAsync(id);
            if (storedItemsClass == null)
            {
                return NotFound();
            }
            return View(storedItemsClass);
        }

        // POST: StoredItemsClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,LocationName,ExpireDate")] StoredItemsClass storedItemsClass)
        {
            if (id != storedItemsClass.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storedItemsClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoredItemsClassExists(storedItemsClass.ItemId))
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
            return View(storedItemsClass);
        }

        // GET: StoredItemsClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storedItemsClass = await _context.StoredItemsClass
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (storedItemsClass == null)
            {
                return NotFound();
            }

            return View(storedItemsClass);
        }

        // POST: StoredItemsClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storedItemsClass = await _context.StoredItemsClass.FindAsync(id);
            _context.StoredItemsClass.Remove(storedItemsClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoredItemsClassExists(int id)
        {
            return _context.StoredItemsClass.Any(e => e.ItemId == id);
        }
    }
}
