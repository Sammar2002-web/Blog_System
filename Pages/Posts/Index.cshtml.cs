using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blog_System.Models;
using Microsoft.AspNetCore.Identity;
using System.Web.Helpers;

namespace Blog_System.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Blog_System.AppData.ApplicationDbContext _context;
        private readonly UserManager<Users> _userManager;

        public IndexModel(Blog_System.AppData.ApplicationDbContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Post> Post { get; set; } = new List<Post>();

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.Include(p => p.Comment).Include(p => p.PostLikes).OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<IActionResult> OnPostAddCommentAsync(int postId, string commentContent)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(commentContent))
            {
                return Page();
            }

            var newComment = new Comment
            {
                Content = commentContent,
                Auther = User.Identity?.Name ?? "Anonymous",
                PostedAt = DateTime.Now,
                PostId = postId,
                LikeCount = 0
            };

            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();

            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                post.CommentsCount = await _context.Comments
                    .CountAsync(c => c.PostId == postId);
                await _context.SaveChangesAsync();
            }

            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> OnPostToggleLikeAsync(int postId)
        {
            var userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId)) return RedirectToPage();

            var post = await _context.Posts.Include(p => p.PostLikes).FirstOrDefaultAsync(p => p.Id == postId);
            if (post == null) return RedirectToPage();

            var userLike = post.PostLikes.FirstOrDefault(l => l.UserId == userId);

            if (userLike == null)
            {
                var newLike = new PostLike
                {
                    PostId = postId,
                    UserId = userId
                };
                post.LikesCount++;
                _context.PostLikes.Add(newLike);
            }
            else
            {
                post.LikesCount--;
                _context.PostLikes.Remove(userLike);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
