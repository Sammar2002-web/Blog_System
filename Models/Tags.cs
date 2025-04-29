namespace Blog_System.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostTag> PostTag { get; set; } = new List<PostTag>();
    }
}
