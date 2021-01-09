using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to 50 characters.")]
        public string BlogName { get; set; }
        [Required(ErrorMessage = "Choose the type")]
        public string BlogType { get; set; }
        [Required(ErrorMessage = "Choose the status")]
        public string BlogStatus { get; set; }
        [Required(ErrorMessage = "Choose the address")]
        public string BlogAddress { get; set; }
        public DateTime BlogPostedDate { get; set; }
        [Required(ErrorMessage = "Enter short detail")]
        public string BlogShortDetail { get; set; }
        [Required(ErrorMessage = "Enter detail")]
        public string BlogDetail { get; set; }
        [Required(ErrorMessage = "Choose photo")]
        public string BlogPhoto { get; set; }
        public List<Blog> ListBlogs { get; set; }
    }
}