using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_System.Pages
{
    [Authorize(Roles = "Visitor")]
    public class VisitorModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
