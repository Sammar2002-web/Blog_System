using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blog_System.AppData;
using Blog_System.Models;

namespace Blog_System.Pages.Tags
{
    public class DeleteModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;

        public DeleteModel(Blog_System.AppData.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Blog_System.Models.Tags Tags { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags.FirstOrDefaultAsync(m => m.Id == id);

            if (tags == null)
            {
                return NotFound();
            }
            else
            {
                Tags = tags;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags.FindAsync(id);
            if (tags != null)
            {
                Tags = tags;
                _context.Tags.Remove(Tags);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
