<%@ Application Language="C#" %>

<script runat="server">
    string eventLogName = "WebApplicationError";
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        TalkToUsers.LastException = Server.GetLastError().GetBaseException();

        string message = "Error Caught in Application_Error event\n" +

                "Error in: " + Request.Url.ToString() +

                "\nError Message:" + TalkToUsers.LastException.Message.ToString() +

                "\nStack Trace:" + TalkToUsers.LastException.StackTrace.ToString();

       

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
