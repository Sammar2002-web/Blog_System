namespace Blog_System.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;  
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
