using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog_System.AppData;
using Blog_System.Models;
using Blog_System.SignalRHub;
using Microsoft.AspNetCore.SignalR;

namespace Blog_System.Pages.Comments
{
    public class CreateModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;
        private readonly IHubContext<NotifyHub> _hubContext;

        public CreateModel(Blog_System.AppData.ApplicationDbContext context, IHubContext<NotifyHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();
            var user = User.Identity?.Name ?? "Anonymous";
            var message = "Comment posted!";

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", user, message);

            TempData["ShowToast"] = "true";
            TempData["ToastMessage"] = $"{user}: {message}";
            return RedirectToPage("./Index");
        }

    }
}
