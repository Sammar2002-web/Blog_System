using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog_System.AppData;
using Blog_System.Models;

namespace Blog_System.Pages.Posts
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
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
        ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                await _context.Posts.AddAsync(Post);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
