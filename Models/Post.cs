using System;

namespace BlogAPI.Models
{
    /// <summary>
    /// Represents a blog post.
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
