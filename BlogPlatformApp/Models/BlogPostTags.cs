using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatformApp.Models
{
    public class BlogPostTags
    {
        [ForeignKey("BlogPost")]
        public int BlogId { get; set; }
        public string Slug { get; set; }
        public BlogPost BlogPost { get; set; }

        [ForeignKey("Tags")]
        public string TagId { get; set; }
        public Tags Tag { get; set; }
    }
}
