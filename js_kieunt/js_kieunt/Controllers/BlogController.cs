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
        #region ShowAllBlogs
        /// <summary>
        /// Hien thi toan bo blog
        /// </summary>
        /// <returns value="ActionResult">View()</returns>
        [HttpGet]
        public ActionResult ShowAllBlogs()
        {
            Blog objBlog = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            objBlog.ListBlogs = dal.Selectalldata();

            return View(objBlog);
        }
        #endregion ShowAllBlogs

        #region SearchScreen
        /// <summary>
        /// hien thi man hinh tim kiem
        /// </summary>
        /// <returns value="ActionResult">View()</returns>
        [HttpGet]
        public ActionResult SearchScreen()
        {
            Blog objBlog = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            objBlog.ListBlogs = dal.Selectalldata();

            return View(objBlog);
        }
        #endregion SearchScreen

        #region SearchDataByName
        /// <summary>
        /// hien thi man hinh ket qua tim kiem blog theo ten
        /// </summary>
        /// <param name="ID" value="string"></param>
        /// <returns value="ActionResult">View()</returns>
        [HttpGet]
        public ActionResult SearchDataByName(string ID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            Blog objBlog = new Blog();
            objBlog.ListBlogs = dal.SearchDataByName(ID);

            return View(objBlog);
        }
        #endregion SearchDataByName

        #region Delete
        /// <summary>
        /// Chuc nang xoa blog
        /// </summary>
        /// <param name="id" value="ActionResult"></param>
        /// <returns value="ActionResult">Quay ve man hinh ShowAllBlogs</returns>
        [HttpGet]
        public ActionResult Delete(string id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            int result = dal.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();

            return RedirectToAction("ShowAllBlogs");
        }
        #endregion Delete

        #region createEditBlog
        /// <summary>
        /// hien thi man hinh them sua blog
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns>hien thi man hinh them,sua blog</returns>
        [HttpGet]
        public ActionResult createEditBlog(string id)
        {
            if(id != null)
            {
                DataAccessLayer dal = new DataAccessLayer();

                return View(dal.SelectDataById(id));
            }
            else
            {
                Blog blogObj = new Blog();
                blogObj.BlogID = 0;

                return View(blogObj);
            }
        }
        #endregion createEditBlog

        #region createEditBlog
        /// <summary>
        ///     chuc nang them hoac sua blog dua tren id
        /// </summary>
        /// <param name="blobj" value="blobj"></param>
        /// <returns>Quay ve man hinh hien thi toan bo blog</returns>
        [HttpPost]
        public ActionResult createEditBlog(Blog blobj, FormCollection form)
        {
            if (blobj.BlogID > 0)
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
                    ModelState.AddModelError("", "Error in updating data");

                    return View();
                }
            }
            else
            {
                blobj.BlogPostedDate = Convert.ToDateTime(DateTime.Now.ToString());
                if (ModelState.IsValid)
                {
                    DataAccessLayer dal = new DataAccessLayer();
                    string result = dal.Insertdata(blobj);
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
            #endregion createEditBlog

        }
    }
}