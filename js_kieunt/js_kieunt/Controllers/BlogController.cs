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

        [HttpGet]
        public ActionResult SearchDataByName(string name)
        {
            DataAccessLayer dal = new DataAccessLayer();
            Blog Blogobj = new Blog();
            Blogobj.ListBlogs = dal.SearchDataByName(name);
            return View(Blogobj);
        }
        [HttpGet]
        public ActionResult InsertBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertBlog(Blog newBlogObj)
        {
            newBlogObj.BlogPostedDate = Convert.ToDateTime(DateTime.Now.ToString());
            if (ModelState.IsValid)
            {
                DataAccessLayer dal = new DataAccessLayer();
                string result = dal.Insertdata(newBlogObj);
                TempData["InsertResult"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllBlogs");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data to table");
                return View();
            }
        }
        [HttpGet]
        public ActionResult Details(string ID)
        {
            Blog BlogObj = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            return View(dal.SelectDataById(ID));
        }

        [HttpGet]
        public ActionResult EditBlog(string ID)
        {
            Blog BlogObj = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            return View(dal.SelectDataById(ID));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            int result = dal.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowAllBlogs");
        }
        [HttpPost]
        public ActionResult EditBlog(Blog blobj)
        {
            blobj.BlogPostedDate = Convert.ToDateTime(blobj.BlogPostedDate.ToString());
            if (ModelState.IsValid)
            {
                DataAccessLayer dal = new DataAccessLayer();
                string result = dal.Updatedata(blobj);
                TempData["UpdateResult"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllBlogs");
            }
            else
            {
                ModelState.AddModelError("","Error in updating data");
                return View();
            }
        }
    }
}