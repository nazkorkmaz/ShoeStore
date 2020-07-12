using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoeStore.Data;
using ShoeStore.Models;
using ShoeStore.ViewModel;

namespace ShoeStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ActionResult> Search()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Search(SearchViewModel searchModel)
        {
            
            var shoes = _context.Shoes.AsQueryable();
            if(!String.IsNullOrWhiteSpace(searchModel.SearchText))
            {
                if(searchModel.SearchInDescription)
                {
                    shoes = shoes.Where(b => b.Name.Contains(searchModel.SearchText) || b.Description.Contains(searchModel.SearchText)); 
                }
                else
                {
                    shoes = shoes.Where(b => b.Name.Contains(searchModel.SearchText));

                }
               
            }
            if (searchModel.CategoryId.HasValue)
            {
                shoes = shoes.Where(b => b.CategoryId == searchModel.CategoryId.Value);
            }
            if (searchModel.BrandId.HasValue)
            {
                shoes = shoes.Where(b => b.BrandId == searchModel.BrandId.Value);
            }

            if(searchModel.MinPrice.HasValue)
            {
                shoes = shoes.Where(b => b.Price >= searchModel.MinPrice.Value);
            }
            if (searchModel.MaxPrice.HasValue)
            {
                shoes = shoes.Where(b => b.Price <= searchModel.MaxPrice.Value);
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", searchModel.CategoryId);
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name",searchModel.BrandId);
            searchModel.Results = await shoes.ToListAsync();
            return View(searchModel);

        }
    }
}
