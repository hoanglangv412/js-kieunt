using js_kieunt.DataAccess;
using js_kieunt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace js_kieunt.Controllers
{
    public class BlogController : Controller
    {
        //hien thi toan bo blog
        [HttpGet]
        public ActionResult ShowAllBlogs()
        {
            Blog objBlog = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            objBlog.ListBlogs = dal.Selectalldata();
            return View(objBlog);
        }

        //hien thi man hinh tim kiem
        [HttpGet]
        public ActionResult SearchScreen()
        {
            Blog objBlog = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            objBlog.ListBlogs = dal.Selectalldata();
            return View(objBlog);
        }

        //hien thi man hinh tim kiem blog theo ten
        [HttpGet]
        public ActionResult SearchDataByName(string ID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            Blog objBlog = new Blog();
            objBlog.ListBlogs = dal.SearchDataByName(ID);
            return View(objBlog);
        }

        //hien thi man them blog
        [HttpGet]
        public ActionResult InsertBlog()
        {
            return View();
        }

        //chuc nang them blog
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

        //hien thi man hinh sua blog
        [HttpGet]
        public ActionResult EditBlog(string ID)
        {
            Blog BlogObj = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            return View(dal.SelectDataById(ID));
        }

        //chuc nang xoa blog
        [HttpGet]
        public ActionResult Delete(string id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            int result = dal.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowAllBlogs");
        }

        //chuc nang sua blog
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