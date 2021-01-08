using js_kieunt.Models;
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
    }
}