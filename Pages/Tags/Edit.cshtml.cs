using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog_System.AppData;
using Blog_System.Models;

namespace Blog_System.Pages.Tags
{
    public class EditModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;

        public EditModel(Blog_System.AppData.ApplicationDbContext context)
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

            var tags =  await _context.Tags.FirstOrDefaultAsync(m => m.Id == id);
            if (tags == null)
            {
                return NotFound();
            }
            Tags = tags;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagsExists(Tags.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TagsExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}
