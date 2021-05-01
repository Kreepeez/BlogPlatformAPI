using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatformApp.Models
{
    public class Post
    {
        [JsonProperty("blogPost")]
        public BlogPost blogPost { get; set; }

        public BlogPost GetBlogPost()
        {
            return blogPost;
        }

        public void SetBlogPost(BlogPost value)
        {
            blogPost = value;
        }

        public List<BlogPost> BlogPosts;

        public List<BlogPost> GetBlogPosts()
        {
            return BlogPosts;
        }

        public void SetBlogPosts(List<BlogPost> value)
        {
            BlogPosts = value;
        }

        public int postsCount { get; set; }

        public Post()
        {

        }
    }
}
