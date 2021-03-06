﻿using js_kieunt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace js_kieunt.DataAccess
{
    public class DataAccessLayer
    {
        #region Selectalldata
        /// <summary>
        /// Lay toan bo blog
        /// </summary>
        /// <returns value="List<Blog>" name="listBlog"></returns>
        public List<Blog> Selectalldata()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            List<Blog> listBlog = null;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogManager"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BlogID", null);
            cmd.Parameters.AddWithValue("@BlogName", null);
            cmd.Parameters.AddWithValue("@BlogType", null);
            cmd.Parameters.AddWithValue("@BlogStatus", null);
            cmd.Parameters.AddWithValue("@BlogAddress", null);
            cmd.Parameters.AddWithValue("@BlogPostedDate", null);
            cmd.Parameters.AddWithValue("@BlogShortDetail", null);
            cmd.Parameters.AddWithValue("@BlogDetail", null);
            cmd.Parameters.AddWithValue("@BlogPhoto", null);
            cmd.Parameters.AddWithValue("@Query", 4);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            listBlog = new List<Blog>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Blog cobj = new Blog();
                cobj.BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString());
                cobj.BlogName = ds.Tables[0].Rows[i]["BlogName"].ToString();
                cobj.BlogType = ds.Tables[0].Rows[i]["BlogType"].ToString();
                cobj.BlogStatus = ds.Tables[0].Rows[i]["BlogStatus"].ToString();
                cobj.BlogAddress = ds.Tables[0].Rows[i]["BlogAddress"].ToString();
                cobj.BlogPostedDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["BlogPostedDate"].ToString());
                listBlog.Add(cobj);
            }

            return listBlog;
        }
        #endregion Selectalldata

        #region InsertData
        /// <summary>
        /// Them vao 1 blog
        /// </summary>
        /// <param name="BlogObj" value="Blog"></param>
        /// <returns name="result" value="string"></returns>
        public string Insertdata (Blog BlogObj)
        {
            SqlConnection conn = null;
            String result = "";

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogManager"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogID", null);
                cmd.Parameters.AddWithValue("@BlogName", BlogObj.BlogName);
                cmd.Parameters.AddWithValue("@BlogType", BlogObj.BlogType);
                cmd.Parameters.AddWithValue("@BlogStatus", BlogObj.BlogStatus);
                cmd.Parameters.AddWithValue("@BlogAddress", BlogObj.BlogAddress);
                cmd.Parameters.AddWithValue("@BlogPostedDate", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@BlogShortDetail", BlogObj.BlogShortDetail);
                cmd.Parameters.AddWithValue("@BlogDetail", BlogObj.BlogDetail);
                cmd.Parameters.AddWithValue("@BlogPhoto", BlogObj.BlogPhoto);
                cmd.Parameters.AddWithValue("@Query", 1);
                conn.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {

                return result = null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion InsertData

        #region Updatedata
        /// <summary>
        /// Cap nhat du lieu 1 blog
        /// </summary>
        /// <param name="BlogObj" value="Blog"></param>
        /// <returns name="result" value="string"></returns>
        public string Updatedata (Blog BlogObj)
        {
            SqlConnection conn = null;
            String result = "";

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogManager"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogID", BlogObj.BlogID);
                cmd.Parameters.AddWithValue("@BlogName", BlogObj.BlogName);
                cmd.Parameters.AddWithValue("@BlogType", BlogObj.BlogType);
                cmd.Parameters.AddWithValue("@BlogStatus", BlogObj.BlogStatus);
                cmd.Parameters.AddWithValue("@BlogAddress", BlogObj.BlogAddress);
                cmd.Parameters.AddWithValue("@BlogPostedDate", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@BlogShortDetail", BlogObj.BlogShortDetail);
                cmd.Parameters.AddWithValue("@BlogDetail", BlogObj.BlogDetail);
                cmd.Parameters.AddWithValue("@BlogPhoto", BlogObj.BlogPhoto);
                cmd.Parameters.AddWithValue("@Query", 2);
                conn.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {

                return result = null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion Updatedata

        #region SelectDataById
        /// <summary>
        /// Lay ra 1 blog
        /// </summary>
        /// <param name="BlogId" value="string"></param>
        /// <returns name="foundBlog" value="Blog"></returns>
        public Blog SelectDataById (string BlogId)
        {
            SqlConnection conn = null;
            Blog foundBlog = null;
            DataSet ds = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogManager"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogID", BlogId);
                cmd.Parameters.AddWithValue("@BlogName", null);
                cmd.Parameters.AddWithValue("@BlogType", null);
                cmd.Parameters.AddWithValue("@BlogStatus", null);
                cmd.Parameters.AddWithValue("@BlogAddress", null);
                cmd.Parameters.AddWithValue("@BlogPostedDate", null);
                cmd.Parameters.AddWithValue("@BlogShortDetail", null);
                cmd.Parameters.AddWithValue("@BlogDetail", null);
                cmd.Parameters.AddWithValue("@BlogPhoto", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foundBlog = new Blog();
                    foundBlog.BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString());
                    foundBlog.BlogName = ds.Tables[0].Rows[i]["BlogName"].ToString();
                    foundBlog.BlogType = ds.Tables[0].Rows[i]["BlogType"].ToString();
                    foundBlog.BlogStatus = ds.Tables[0].Rows[i]["BlogStatus"].ToString();
                    foundBlog.BlogAddress = ds.Tables[0].Rows[i]["BlogAddress"].ToString();
                    foundBlog.BlogPostedDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["BlogPostedDate"].ToString());
                    foundBlog.BlogShortDetail = ds.Tables[0].Rows[i]["BlogShortDetail"].ToString();
                    foundBlog.BlogDetail = ds.Tables[0].Rows[i]["BlogDetail"].ToString();
                    foundBlog.BlogPhoto = ds.Tables[0].Rows[i]["BlogPhoto"].ToString();
                }

                return foundBlog;
            }
            catch (Exception)
            {

                return foundBlog;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion SelectDataById

        #region SearchDataByName
        /// <summary>
        /// Tim blog theo ten
        /// </summary>
        /// <param name="BlogName" value="string"></param>
        /// <returns name="listFoundBlog" value="List<Blog>"></returns>
        public List<Blog> SearchDataByName (string BlogName)
        {
            SqlConnection conn = null;
            DataSet ds = null;
            Blog foundBlog = null;
            List<Blog> listFoundBlog = new List<Blog>() ;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogManager"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogID", null);
                cmd.Parameters.AddWithValue("@BlogName", BlogName);
                cmd.Parameters.AddWithValue("@BlogType", null);
                cmd.Parameters.AddWithValue("@BlogStatus", null);
                cmd.Parameters.AddWithValue("@BlogAddress", null);
                cmd.Parameters.AddWithValue("@BlogPostedDate", null);
                cmd.Parameters.AddWithValue("@BlogShortDetail", null);
                cmd.Parameters.AddWithValue("@BlogDetail", null);
                cmd.Parameters.AddWithValue("@BlogPhoto", null);
                cmd.Parameters.AddWithValue("@Query", 6);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foundBlog = new Blog();
                    foundBlog.BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString());
                    foundBlog.BlogName = ds.Tables[0].Rows[i]["BlogName"].ToString();
                    foundBlog.BlogType = ds.Tables[0].Rows[i]["BlogType"].ToString();
                    foundBlog.BlogStatus = ds.Tables[0].Rows[i]["BlogStatus"].ToString();
                    foundBlog.BlogAddress = ds.Tables[0].Rows[i]["BlogAddress"].ToString();
                    foundBlog.BlogPostedDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["BlogPostedDate"].ToString());
                    foundBlog.BlogShortDetail = ds.Tables[0].Rows[i]["BlogShortDetail"].ToString();
                    foundBlog.BlogDetail = ds.Tables[0].Rows[i]["BlogDetail"].ToString();
                    foundBlog.BlogPhoto = ds.Tables[0].Rows[i]["BlogPhoto"].ToString();
                    listFoundBlog.Add(foundBlog);        
                }

                return listFoundBlog;
            }
            catch (Exception)
            {

                return listFoundBlog = null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion SearchDataByName

        #region DeleteData
        /// <summary>
        /// Xoa 1 blog
        /// </summary>
        /// <param name="ID" value="string"></param>
        /// <returns name="result" value="int"></returns>
        public int DeleteData (String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogManager"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogID", ID);
                cmd.Parameters.AddWithValue("@BlogName", null);
                cmd.Parameters.AddWithValue("@BlogType", null);
                cmd.Parameters.AddWithValue("@BlogStatus", null);
                cmd.Parameters.AddWithValue("@BlogAddress", null);
                cmd.Parameters.AddWithValue("@BlogPostedDate", null);
                cmd.Parameters.AddWithValue("@BlogShortDetail", null);
                cmd.Parameters.AddWithValue("@BlogDetail", null);
                cmd.Parameters.AddWithValue("@BlogPhoto", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch
            {

                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion DeleteData
    }
}