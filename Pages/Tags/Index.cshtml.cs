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
    public class IndexModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;

        public IndexModel(Blog_System.AppData.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Blog_System.Models.Tags> Tags { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tags = await _context.Tags.ToListAsync();
        }
    }
}
