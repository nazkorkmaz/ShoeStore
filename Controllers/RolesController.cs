using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Data;
using ShoeStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ShoeStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoleManager<ShoeStoreRole> RoleManager { get; }

        public RolesController(ApplicationDbContext context, RoleManager<ShoeStoreRole> roleManager)
        {
            _context = context;
            RoleManager = roleManager;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeStoreRole = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (shoeStoreRole == null)
            {
                return NotFound();
            }

            return View(shoeStoreRole);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CanEnterComment,CanDeleteComment,Id,Name,NormalizedName,ConcurrencyStamp")] ShoeStoreRole shoeStoreRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoeStoreRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoeStoreRole);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeStoreRole = await _context.Roles.FindAsync(id);
            if (shoeStoreRole == null)
            {
                return NotFound();
            }
            return View(shoeStoreRole);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CanEnterComment,CanDeleteComment,Id,Name,NormalizedName,ConcurrencyStamp")] ShoeStoreRole shoeStoreRole)
        {
            if (id != shoeStoreRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoeStoreRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeStoreRoleExists(shoeStoreRole.Id))
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
            return View(shoeStoreRole);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeStoreRole = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (shoeStoreRole == null)
            {
                return NotFound();
            }

            return View(shoeStoreRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoeStoreRole = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(shoeStoreRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeStoreRoleExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id.ToString());
        }
    }
}