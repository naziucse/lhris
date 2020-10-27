using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dataaccess;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections;
using System.IO;
using System.Transactions;

public partial class Container : System.Web.UI.Page
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataReader dr;

    QrRoleTypeSetup qrRoleType = new QrRoleTypeSetup();
    QrRoleSetup qrRoleSetup = new QrRoleSetup();
    RoleTypeSetupProperty roleType = new RoleTypeSetupProperty();
    RoleSetupProperty rolesetup = new RoleSetupProperty();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["company"] ="1";
        //Session["branch"] = "0";
        //Session["username"] = "10001";
        //Session["CompanyName"] = "Link3 Technologies Ltd.";
    }
}