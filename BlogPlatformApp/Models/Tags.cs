using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatformApp.Models
{
    public class Tags
    {
        [Key]
        public string TagId { get; set; }
        public List<BlogPostTags> BlogPostTags { get; set; }
        public Tags()
        {

        }
    }
}
