<%@ WebHandler Language="C#" Class="FileCSbk" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public class FileCSbk : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request.QueryString["Id"]);
        byte[] bytes;
        string fileName, contentType;
        //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["AIBPConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Name, Data, ContentType FROM tblFiles WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
        }

        context.Response.Buffer = true;
        context.Response.Charset = "";
        if (context.Request.QueryString["download"] == "1")
        {
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        }
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.ContentType = "application/pdf";
        context.Response.BinaryWrite(bytes);
        context.Response.Flush();
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}