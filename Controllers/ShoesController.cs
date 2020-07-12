
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Data;
using ShoeStore.Models;
using ShoeStore.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ShoeStore.Controllers
{
    public class ShoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public ShoesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: Shoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shoes.Include(s => s.Brand).Include(s => s.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> AdminIndex()
        {
            var applicationDbContext = _context.Shoes.Include(s => s.Brand).Include(s => s.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> UploadImage (ImageUploadViewModel uploadModel)
        {
            // string directory = @"C:\Users\nazko\source\repos\ShoeStore\wwwroot\UserImages\";
           string directory = Path.Combine(hostEnvironment.WebRootPath, "UserImages");
            string fileName = Guid.NewGuid().ToString() + "_" + uploadModel.ImageFile.FileName;

            string fullPath = Path.Combine(directory, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await uploadModel.ImageFile.CopyToAsync(fileStream);
            }

            ShoeImage bookImage = new ShoeImage();
            bookImage.ShoeId = uploadModel.ShoeId;
            bookImage.FileName = fileName;

            _context.ShoeImages.Add(bookImage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageImage), uploadModel.ShoeId);
        }
        public async Task<IActionResult> ManageImage(int? id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            var shoe = await _context.Shoes.Include(b => b.ShoeImages).FirstOrDefaultAsync(b => b.Id == id);
            if(shoe==null)
            {
                return NotFound();
            }
            return View(shoe);
        }
        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

      
        // GET: Shoes/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BrandId,Description,Size,Price,StockCount,CategoryId")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", shoe.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", shoe.CategoryId);
            return View(shoe);
        }

        // GET: Shoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", shoe.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", shoe.CategoryId);
            return View(shoe);
        }
       

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BrandId,Description,Size,Price,StockCount,CategoryId")] Shoe shoe)
        {
            if (id != shoe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeExists(shoe.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", shoe.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", shoe.CategoryId);
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            _context.Shoes.Remove(shoe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoes.Any(e => e.Id == id);
        }
    }
}
