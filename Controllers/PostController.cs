using Microsoft.AspNetCore.Mvc;
using BlogAPI.Models;
using System;
using System.Collections.Generic;


namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        // Dummy list to store posts
        private static List<Post> _posts = new List<Post>
        {
            new Post { Id = 1, Title = "First Post", Content = "This is the content of the first post.", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Post { Id = 2, Title = "Second Post", Content = "This is the content of the second post.", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        };

        // GET: api/posts
        [HttpGet]
        public IActionResult GetPosts()
        {
            return Ok(_posts);
        }

        // GET: api/posts/{id}
        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _posts.Find(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST: api/posts
        [HttpPost]
        public IActionResult CreatePost([FromBody] Post post)
        {
            post.Id = _posts.Count + 1;
            post.CreatedAt = DateTime.Now;
            post.UpdatedAt = DateTime.Now;
            _posts.Add(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        // PUT: api/posts/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] Post post)
        {
            var existingPost = _posts.Find(p => p.Id == id);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UpdatedAt = DateTime.Now;

            return NoContent();
        }

        // DELETE: api/posts/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _posts.Find(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            _posts.Remove(post);
            return NoContent();
        }
    }
}
