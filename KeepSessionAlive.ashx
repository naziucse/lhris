﻿<%@ WebHandler Language="C#" Class="KeepSessionAlive" %>

using System;
using System.Web;
using System.Web.SessionState;

public class KeepSessionAlive : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Session["KeepSessionAlive"] = DateTime.Now;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
