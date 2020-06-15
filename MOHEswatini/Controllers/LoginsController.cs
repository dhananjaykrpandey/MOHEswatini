using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOHEswatini.Models;

namespace MOHEswatini.Controllers
{
    public class LoginsController : Controller
    {
        private readonly DbMOHEswatini _context;

        public LoginsController(DbMOHEswatini context)
        {
            _context = context;
        }

        // GET: mLogins
        public async Task<IActionResult> Index()
        {
            return View(await _context.MLogins.ToListAsync());
        }

        // GET: mLogins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLogin = await _context.MLogins
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (mLogin == null)
            {
                return NotFound();
            }

            return View(mLogin);
        }

        // GET: mLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Password,Name,Type,Phone,EmailID")] mLogin mLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mLogin);
        }

        // GET: mLogins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLogin = await _context.MLogins.FindAsync(id);
            if (mLogin == null)
            {
                return NotFound();
            }
            return View(mLogin);
        }

        // POST: mLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserID,Password,Name,Type,Phone,EmailID")] mLogin mLogin)
        {
            if (id != mLogin.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mLoginExists(mLogin.UserID))
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
            return View(mLogin);
        }

        // GET: mLogins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLogin = await _context.MLogins
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (mLogin == null)
            {
                return NotFound();
            }

            return View(mLogin);
        }

        // POST: mLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mLogin = await _context.MLogins.FindAsync(id);
            _context.MLogins.Remove(mLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mLoginExists(string id)
        {
            return _context.MLogins.Any(e => e.UserID == id);
        }
    }
}
