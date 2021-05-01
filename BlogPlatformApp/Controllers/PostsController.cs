using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BlogPlatformApp.Data;
using BlogPlatformApp.Helpers;
using BlogPlatformApp.Models;
using BlogPlatformApp.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogPlatformApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly PostContext _context;
        private readonly IDataRepository<BlogPost> _repo;

        public PostsController(PostContext context, IDataRepository<BlogPost> repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostViewModel>>> GetPostsByTag(string tag)
        {
            var posts = await _repo.Search(tag);
            return Ok(new { blogPosts = posts, postsCount = posts.Count() });
        }


        [HttpGet("{slug}")]
        public async Task<ActionResult<BlogPostViewModel>> GetPost(string slug)
        {
            var post = await _repo.GetViewModel(slug);

            if (post == null)
                return NotFound();
            return Ok(new { blogPost = post });
        }


        [HttpPut("{slug}")]
        [Consumes("application/json")]
        public async Task<ActionResult<Post>> Update([FromRoute] string slug, [FromBody] Post newPost)
        {

            var existingPost = await _repo.GetBySlug(slug);

            if (existingPost == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var prop in newPost.GetBlogPost().GetType().GetProperties())
                {
                    if (prop.Name != "Id")
                    {
                        var propValue = prop.GetValue(newPost.GetBlogPost());

                        if (propValue != null)
                        {
                            existingPost.GetType().GetProperty(prop.Name).SetValue(existingPost, propValue);
                        }
                    }
                }

                existingPost.Slug = StringFormatter.Format(existingPost.Title);
                existingPost.UpdatedAt = DateTime.Now;
            }

            await _repo.Update(existingPost);

            return Ok(existingPost);
        }


        [HttpPost]
        public async Task<ActionResult<Post>> Create([FromBody] Post post)
        {
            string s = StringFormatter.Format(post.GetBlogPost().Title);
            post.GetBlogPost().Slug = s;
            var createdPost = await _repo.Create(post.GetBlogPost());
            return Ok(new { blogPost = createdPost });
        }


        [HttpDelete("{slug}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] string slug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = await _repo.GetBySlug(slug);
            if (blogPost == null)
            {
                return NotFound();
            }

            _repo.Delete(blogPost);
            _ = await _repo.SaveAsync(blogPost);

            return NoContent();
        }
    }
}
