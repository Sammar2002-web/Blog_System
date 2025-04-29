using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog_System.AppData;
using Blog_System.Models;

namespace Blog_System.Pages.Tags
{
    public class CreateModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;

        public CreateModel(Blog_System.AppData.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Blog_System.Models.Tags Tags { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tags.Add(Tags);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
