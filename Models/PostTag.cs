using Azure;

namespace Blog_System.Models
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tags Tag { get; set; }
    }
}
