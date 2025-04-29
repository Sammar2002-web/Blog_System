using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blog_System.AppData;
using Blog_System.Models;

namespace Blog_System.Pages.Category
{
    public class DetailsModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;

        public DetailsModel(Blog_System.AppData.ApplicationDbContext context)
        {
            _context = context;
        }

        public Blog_System.Models.Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
