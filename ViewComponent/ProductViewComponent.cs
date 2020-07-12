using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.ViewComponents
{
    public class ProductComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;
        public ProductComponent(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = await context.Categories.ToListAsync();
            return View(product);
        }
    }
}
