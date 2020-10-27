using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string constr = System.Configuration.ConfigurationSettings.AppSettings["dbAIBPConnectionString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            CreateMenu(Session["username"].ToString(), Session["company"].ToString(), Session["branch"].ToString());
        }
        catch (Exception)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("~/HomePage.aspx");
            }

        }

        if (!Page.IsPostBack)
        {
                      

            DateTime dt = DateTime.Now;

            AssignCompanyInformation(Session["company"].ToString(), Session["branch"].ToString());

            lnkUserName.Text = UserName();
            lblDateTime.Text = dt.DayOfWeek.ToString() +", " + dt.ToString("dd") + " " + dt.ToString("MMMM") + ", " + dt.ToString("yyy");

            //CreateMenu(Session["username"].ToString(), Session["company"].ToString(), Session["branch"].ToString());
        }
    }

    private void AssignCompanyInformation(string compnyid, string branchid)
    {            
        DataTable dt = new DataTable();       
        dt = DataManipulation.GetData(constr, SQLGenerate.GetCompanyInformation(compnyid, branchid));
        if (dt.Rows.Count > 0)
        {
            lblCompanyName.Text = dt.Rows[0]["NameOfCompany"].ToString();
            lblCompanyAddress.Text = dt.Rows[0]["CompanyAddress1"].ToString() + ", " + dt.Rows[0]["CompanyAddress2"].ToString() + ", " + dt.Rows[0]["CompanyAddress3"].ToString();
            lblCompanyContact.Text = dt.Rows[0]["CompanyPhone"].ToString(); 
        }
    }

    private string UserName()
    {
        DataTable dt = new DataTable();
        string uName = string.Empty;

        string sql = "select a.UserName,b.FirstName+SPACE(1)+b.MiddleName+SPACE(1)+b.LastName as displayname,[Password] from uUserList a "
                   + " inner join [uUserProfile] b on a.UserProfileID=b.UserProfileID "
                   + " inner join [uCompanyWiseUserList] c on c.UserID=a.UserID "
                   + " where a.UserName='" + Session["username"] + "' and c.CompanyID='" + Session["company"] + "' and c.BranchID='" + Session["branch"] + "'";


        dt = DataManipulation.GetData(dbConnector.ConnectionString(), sql);

        if (dt.Rows.Count == 0)
        {
            uName=Session["username"].ToString();          
            return uName;
        }
        else
        {
            uName = dt.Rows[0]["displayname"].ToString();
            return uName;            
        }

    }

    private void TreeLoadAdvance(string username, string company, string branch)
    {
        DataSet ds = RunQuery("select a.ActivityID,a.ActivityName from [uNodePermissionSetup] a "
                            + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                            + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                            + " inner join uUserList d on d.UserID=c.UserId "
                            + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and NodeTypeID=1 and d.UserName='" + username + "' order by a.SeqNo");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TreeNode root = new TreeNode(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
            root.SelectAction = TreeNodeSelectAction.Expand;
            CreateNode(root, username, company, branch);
            //TreeView1.Nodes.Add(root);

        }
    }

    private void MenuLoadAdvance(string username, string company, string branch)
    {
        NavigationMenu.Items.Clear();

        DataSet ds = RunQuery("select a.ActivityID,a.ActivityName from [uNodePermissionSetup] a "
                            + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                            + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                            + " inner join uUserList d on d.UserID=c.UserId "
                            + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and NodeTypeID=2 and d.UserName='" + username + "' order by a.SeqNo");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            MenuItem mc;
            MenuItem mi = new System.Web.UI.WebControls.MenuItem();
            mi.Text = ds.Tables[0].Rows[i][1].ToString();
            mi.Value = ds.Tables[0].Rows[i][0].ToString();

            DataSet dsc = RunQuery("select a.ActivityID,a.ActivityName,a.NodeTypeID,a.FormDescription from [uNodePermissionSetup] a "
                             + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                             + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                             + " inner join uUserList d on d.UserID=c.UserId "
                             + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and d.UserName='" + username + "' and PNodeTypeID='" + mi.Value + "' order by a.SeqNo ");

            for (int j = 0; j < dsc.Tables[0].Rows.Count; j++)
            {
                mc = new System.Web.UI.WebControls.MenuItem();

                mc.Text = dsc.Tables[0].Rows[j][1].ToString();
                mc.Value = dsc.Tables[0].Rows[j][0].ToString();
                mc.NavigateUrl = dsc.Tables[0].Rows[j][3].ToString();

                mi.ChildItems.Add(mc);
            }

            NavigationMenu.Items.Add(mi);
        }


    }

    private void CreateNode(TreeNode node, string username, string company, string branch)
    {
        DataSet ds = RunQuery("select a.ActivityID,a.ActivityName,a.NodeTypeID,a.FormDescription from [uNodePermissionSetup] a "
                            + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                            + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                            + " inner join uUserList d on d.UserID=c.UserId "
                            + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and d.UserName='" + username + "' and PNodeTypeID='" + node.Value + "' order by a.SeqNo ");
        if (ds.Tables[0].Rows.Count == 0)
        {
            return;
        }
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            TreeNode tnode;
            tnode = new TreeNode(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());

            //tnode.SelectAction = TreeNodeSelectAction.Expand;

            if (ds.Tables[0].Rows[i][2].ToString() == "3")
            {
                node.ChildNodes.Add(new TreeNode(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString(), "", ds.Tables[0].Rows[i][3].ToString(), ""));
            }
            else
            {
                node.ChildNodes.Add(tnode);
            }

            CreateNode(tnode, username, company, branch);
        }

    }

    private void MenuLoad(string username, string company, string branch)
    {
        DataSet ds = RunQuery("select a.ActivityID,a.ActivityName from [uNodePermissionSetup] a "
                           + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                           + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                           + " inner join uUserList d on d.UserID=c.UserId "
                           + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and NodeTypeID=1 and d.UserName='" + username + "' order by a.SeqNo");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            MenuItem mi = new System.Web.UI.WebControls.MenuItem();

            mi.Value = ds.Tables[0].Rows[i][0].ToString();
            mi.Text = ds.Tables[0].Rows[i][1].ToString();
            //CreateMenu(mi, username, company, branch);         
        }
    }

    private void CreateMenu(string username, string company, string branch)
    {
        
        DataSet ds = RunQuery("select a.ActivityID,a.ActivityName from [uNodePermissionSetup] a "
                           + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                           + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                           + " inner join uUserList d on d.UserID=c.UserId "
                           + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and NodeTypeID=1 and d.UserName='" + username + "' order by a.SeqNo");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            MenuItem mi = new System.Web.UI.WebControls.MenuItem();

            mi.Value = ds.Tables[0].Rows[i][0].ToString();
            mi.Text = ds.Tables[0].Rows[i][1].ToString();
            //CreateMenu(mi, username, company, branch);        


            DataSet dss = RunQuery("select a.ActivityID,a.ActivityName,a.NodeTypeID,a.FormDescription from [uNodePermissionSetup] a "
                                + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                                + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                                + " inner join uUserList d on d.UserID=c.UserId "
                                + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and d.UserName='" + username + "' and PNodeTypeID='" + mi.Value + "' and NodeTypeID=2 order by a.SeqNo ");

            for (int ii = 0; ii < dss.Tables[0].Rows.Count; ii++)
            {
                MenuItem mc;
                mc = new System.Web.UI.WebControls.MenuItem();
                mc.Text = dss.Tables[0].Rows[ii][1].ToString();
                mc.Value = dss.Tables[0].Rows[ii][0].ToString();
                //mc.NavigateUrl = dss.Tables[0].Rows[ii][3].ToString();

                mi.ChildItems.Add(mc);

                DataSet dsc = RunQuery("select a.ActivityID,a.ActivityName,a.NodeTypeID,a.FormDescription from [uNodePermissionSetup] a "
                               + " inner join uRoleWiseActivities b on a.ActivityID=b.ActivityID and a.CompanyID=b.CompanyID and a.BranchID=b.BranchID"
                               + " inner join uUsersInRoles c on c.RoleID=b.RoleID and c.CompanyID=b.CompanyID and c.BranchID=b.BranchID"
                               + " inner join uUserList d on d.UserID=c.UserId "
                               + " where a.CompanyID='" + company + "' and a.BranchID='" + branch + "' and d.UserName='" + username + "' and PNodeTypeID='" + mc.Value + "' and NodeTypeID=3 order by a.SeqNo ");

                for (int iii = 0; iii < dsc.Tables[0].Rows.Count; iii++)
                {
                    MenuItem mcc;
                    mcc = new System.Web.UI.WebControls.MenuItem();
                    mcc.Text = dsc.Tables[0].Rows[iii][1].ToString();
                    mcc.Value = dsc.Tables[0].Rows[iii][0].ToString();
                    mcc.NavigateUrl = dsc.Tables[0].Rows[iii][3].ToString();
                    mc.ChildItems.Add(mcc);

                }
            }

            NavigationMenu.Items.Add(mi);
        }


    }



    DataSet RunQuery(String Query)
    {
        DataSet ds = new DataSet();        
        using (SqlConnection conn = new SqlConnection(constr))
        {
            SqlCommand objCommand = new SqlCommand(Query, conn);
            SqlDataAdapter da = new SqlDataAdapter(objCommand);
            da.Fill(ds);
            da.Dispose();
        }
        return ds;
    }


    protected void lnkLoginStatus_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Session.Abandon();
        if (Request.Cookies["AIBPUID"] != null)
        {
            HttpCookie myCookie = new HttpCookie("AIBPUID");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            Response.Redirect("~/HomePage.aspx");
        }
      
       
    }

    
}
