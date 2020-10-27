using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HomePage : System.Web.UI.Page
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           dropdownCompany(ddlCompanyName);
        }
    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        pnlLogin.Visible = true;
        lblCompanyName.Visible = false;
       
    }

    public static void dropdownCompany(DropDownList ddl)
    {
        SqlConnection sqlConn = dbConnector.GetConnection();
        sqlConn.Open();
        SqlCommand myCommand = sqlConn.CreateCommand();
        myCommand.Connection = sqlConn;
        string qr = string.Empty;
        qr = @"SELECT distinct SerialNo,NameOfCompany FROM suCompanySetup inner join uCompanyWiseUserList on suCompanySetup.MainCompanyID = uCompanyWiseUserList.CompanyID  order by NameOfCompany asc";
        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }

        LoadDataInDropDown(ref ddl, qr, myCommand);

    }

    public static void LoadDataInDropDown(ref DropDownList dpl,string QueryStr,SqlCommand myCommand)
    {
        string selectQuery = QueryStr;
        DataTable dataTableObj = new DataTable();
        try
        {
            myCommand.CommandText = selectQuery;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter();
            sqlDataAdapterObj.SelectCommand = myCommand;
            sqlDataAdapterObj.Fill(dataTableObj);

            ListItem List;

            dpl.Items.Clear();
            foreach (DataRow dr in dataTableObj.Rows)
            {
                List = new ListItem();
                List.Value = dr[0].ToString();
                List.Text = dr[1].ToString();
                dpl.Items.Add(List);
            }

        }
        catch (Exception ex)
        {
            
            throw ex;
        }       
    }



    private bool UserLoginCheck(string company, string branch, string username, string password)
    {
        DataTable dt = new DataTable();
        string encpassword = "";

        string sql = "select a.UserName,b.FirstName+SPACE(1)+b.MiddleName+SPACE(1)+b.LastName as displayname,[Password] from [uUserList] a "
                   + " inner join [uUserProfile] b on a.UserProfileID=b.UserProfileID "
                   + " inner join [uCompanyWiseUserList] c on c.UserID=a.UserID "
                   + " where a.UserName='" + username + "' and c.CompanyID='" + company + "' and c.BranchID='" + branch + "'";


        dt = DataManipulation.GetData(dbConnector.ConnectionString(), sql);

        if (dt.Rows.Count == 0)
        {
            return false;
        }
        else
        {
            encpassword = dt.Rows[0]["Password"].ToString();

            if (password == encpassword)
            {
                Response.Cookies["AIBPUID"]["UserID"] = getid(company, branch, username, password);
                Response.Cookies["AIBPUID"]["UserName"] = Session["username"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    private string getid(string company, string branch, string username, string password)
    {
        DataTable dt = new DataTable();
        string uid = string.Empty;

        string sql = "select a.UserID as cookie from [uUserList] a inner join [uUserProfile] b on a.UserProfileID=b.UserProfileID  inner join [uCompanyWiseUserList] c on c.UserID=a.UserID "
                   + "where a.UserName='" + username + "' and c.CompanyID='" + company + "' and c.BranchID='" + branch + "'";


        dt = DataManipulation.GetData(dbConnector.ConnectionString(), sql);

        if (dt.Rows.Count == 0)
        {
            uid = "Anonymous";
            return uid;
        }
        else
        {
            uid = dt.Rows[0]["cookie"].ToString();
            return uid;
        }        
    }

    protected void btnSignin_Click(object sender, EventArgs e)
    {
        Session["company"] = ddlCompanyName.SelectedItem.Value;
        Session["branch"] = "0";
        Session["username"] = txtusername.Text;
        Session["CompanyName"] = ddlCompanyName.SelectedItem.Text;

        PasswordEncryptProcess objpass = new PasswordEncryptProcess();

        string passkey = objpass.EncodePassword(txtpassword.Text.Trim());


        if (UserLoginCheck(Session["company"].ToString(), Session["branch"].ToString(), Session["username"].ToString(), passkey.ToString()) == false)
        {
            lblmsg.Text = "Invalid userid or password.";
            return;
        }

        Response.Redirect("~/Container.aspx");
        
    }



}