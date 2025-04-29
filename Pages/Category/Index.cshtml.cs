using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog_System.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;

        public IndexModel(Blog_System.AppData.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Blog_System.Models.Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
