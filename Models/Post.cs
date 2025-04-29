namespace Blog_System.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<PostTag> PostTag { get; set; } = new List<PostTag>();

    }
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
