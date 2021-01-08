using js_kieunt.DataAccess;
using js_kieunt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace js_kieunt.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        public ActionResult ShowAllBlogs()
        {
            Blog objBlog = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            objBlog.ListBlogs = dal.Selectalldata();
            return View(objBlog);
        }

        public ActionResult AddNewBlog()
        {
            return View();
        }
        public ActionResult SearchBlog()
        {
            return View();
        }
        public ActionResult EditBlog()
        {
            return View();
        }
    }
}