using Blog_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_System.Pages
{
    [Authorize]
    public class UserModel : PageModel
    {
        private readonly UserManager<Users> _userManager;
        public Users UserData;

        public UserModel(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
            var task = _userManager.GetUserAsync(User);
            task.Wait();
            UserData = task.Result;
        }
    }
}
