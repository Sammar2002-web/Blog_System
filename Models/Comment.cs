namespace Blog_System.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Auther { get; set; }
        public int LikeCount { get; set; } = 0;
        public DateTime PostedAt { get; set; } = DateTime.Now;  
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
