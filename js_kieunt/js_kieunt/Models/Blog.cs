using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace js_kieunt.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string BlogName { get; set; }
        public string BlogType { get; set; }
        public string BlogStatus { get; set; }
        public string BlogAddress { get; set; }
        public DateTime BlogPostedDate { get; set; }
        public List<Blog> ListBlogs { get; set; }
    }
}