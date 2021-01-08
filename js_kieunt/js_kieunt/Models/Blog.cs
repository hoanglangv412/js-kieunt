using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace js_kieunt.Models
{
    public class Blog
    {
        public Blog(int blogID, string blogName, string blogType, string blogStatus, string blogAddress, DateTime blogPostedDate, string blogShortDetail, string blogDetail, string blogPhoto, List<Blog> listBlogs)
        {
            BlogID = blogID;
            BlogName = blogName;
            BlogType = blogType;
            BlogStatus = blogStatus;
            BlogAddress = blogAddress;
            BlogPostedDate = blogPostedDate;
            BlogShortDetail = blogShortDetail;
            BlogDetail = blogDetail;
            BlogPhoto = blogPhoto;
            ListBlogs = listBlogs;
        }
        public Blog()
        {
        }

        public int BlogID { get; set; }
        public string BlogName { get; set; }
        public string BlogType { get; set; }
        public string BlogStatus { get; set; }
        public string BlogAddress { get; set; }
        public DateTime BlogPostedDate { get; set; }
        public string BlogShortDetail { get; set; }
        public string BlogDetail { get; set; }
        public string BlogPhoto { get; set; }
        public List<Blog> ListBlogs { get; set; }
    }
}