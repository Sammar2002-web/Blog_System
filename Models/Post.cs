namespace Blog_System.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public int LikesCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public string Auther { get; set; }
        public List<Comment> Comment { get; set; } = new List<Comment>();
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<PostTag> PostTag { get; set; } = new List<PostTag>();
        public List<PostLike> PostLikes { get; set; } = new List<PostLike>();

    }
}
