<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <title></title>
    
    <link href="App_Themes/CSSstyleTheme/MasterPageCSS/bootstrap.css" rel="stylesheet" type="text/css"/>
    <link href="App_Themes/HomePage/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="App_Themes/HomePage/bootstrap-theme.css" rel="stylesheet" type="text/css"/>
    <link href="App_Themes/HomePage/bootstrap-theme.min.css" rel="stylesheet" type="text/css"/>
    <%-- <link href="App_Themes/CSSstyleTheme/ChildPageCSS/normalize.css" rel="stylesheet" type="text/css" />--%>
    <link href="App_Themes/CSSstyleTheme/MasterPageCSS/CssAddon.css" rel="stylesheet" type="text/css" />
   
     <script src="Scripts/js/jquery.min.js"></script>
    <script src="Scripts/js/bootstrap.min.js"></script>
    <script src="Scripts/js/bootstrap.js"></script>
    <script src="Scripts/js/npm.js"></script>
    
</head>
<body>

       <form id="form1" runat="server">
    <div class="container-fluid mpage">
        <div class="row">
        <div class="col-sm-9 col-md-7" style="padding:0px;margin:0px">
          <table style="background-color: #002D59;height:100vh">
              <tr style="height:300px">
                  <td style="width: 200px"></td>
                  <td style="width: 500px"></td>
              </tr>
              <tr>
                  <td style="width: 283px">                     
                  </td>
                  <td style="border-style:none;height:3px;background-color:#B5FF1C" class="panel panel-default">
                      
                  </td>
              </tr>
              <tr style="height:40px">
                  <td style="width: 283px">                      
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr style="height:150px">
                  <td style="width: 283px">               
                  </td>
                  <td style="background-color:#002448; border-style:none">
                     <asp:Panel ID="Panel1" runat="server">
                         <table style="width:100%">
                             <tr>
                                 <td style="text-align:center">
                                     <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/images.jpg" class="img-thumbnail"/>
                                 </td>
                                 <td style="text-align:center; border-right-style: solid; border-left-style: solid; border-right-width: 1px; border-left-width: 1px; border-right-color: #00468C; border-left-color: #00468C;">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/images.jpg" class="img-thumbnail"/>
                                 </td>
                                 <td style="text-align:center">
                                     <asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/images.jpg" class="img-thumbnail"/>
                                 </td>
                             </tr>
                               <tr>
                                 <td style="text-align:center">
                                     &nbsp;</td>
                                 <td style="text-align:center">
                                     &nbsp;</td>
                                 <td style="text-align:center">
                                     &nbsp;</td>
                             </tr>
                         </table>
                      </asp:Panel>
                  </td>
              </tr>
              <tr>
                  <td style="width: 283px">               
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
              </tr>
          </table>
        </div>
            <div class="col-sm-3 col-md-5" style="padding:0px">
                 <table class="DivHeight">
              <tr style="vertical-align:top;height:100px">
                  <td>
                      <asp:Panel runat="server" ID="pnlSocialButtonCompany">
                          <table style="width:100%">
                              <tr>
                                  <td style="width: 220px; text-align:right">
                                      <asp:Label ID="Label5" runat="server" CssClass="label" ForeColor="#999999" Text="Follow us :"></asp:Label>
                                  </td>
                                  <td style="width: 24px">
                                      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/twitter-16.png" />
                                  </td>
                                  <td style="width: 22px">
                                      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/facebook-16.png" />
                                  </td>
                                  <td style="width: 23px">
                                      <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/f-linkedin_256-16.png" />
                                  </td>
                                  <td style="width: 130px">
                                      <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/youtube.png" />
                                  </td>
                                  <td style="width: 100px">
                                      <asp:Button ID="btnLogIn" runat="server" Text="Log in" CssClass="btn btn-primary btn-xs NoRad"  OnClick="btnLogIn_Click"/>
                                  </td>
                                  <td>&nbsp;</td>
                              </tr>
                              
                          </table>

                      </asp:Panel>
                  </td>
                  
              </tr>
                     <tr>
                  <td>

                      <asp:Panel ID="lblCompanyName" runat="server">
                          <table style="width: 100%">
                              <tr>
                                  <td style="height: 80px; width: 108px">&nbsp;</td>
                                  <td style="width: 380px; text-align: right;font-family:Tahoma">
                                      &nbsp;</td>
                                  <td style="height: 34px">&nbsp;</td>
                              </tr>
                              
                              <tr>
                                  <td style="height: 34px; width: 108px">&nbsp;</td>
                                  <td style="width: 380px; text-align: right;font-family:Tahoma">&nbsp;</td>
                                  <td style="height: 34px">&nbsp;</td>
                              </tr>
                              <tr>
                                  <td style="width: 108px; height: 34px;"></td>
                                  <td style="width: 380px; text-align: right; font-family: Tahoma;">
                                      <asp:Label ID="Label6" runat="server" ForeColor="#919191" Text="MY COMPANY" CssClass="text-center" Font-Size="35pt"></asp:Label>
                                  </td>
                                  <td style="height: 34px"></td>
                              </tr>
                              <tr>
                                  <td style="width: 108px; height: 34px;">&nbsp;</td>
                                  <td style="width: 380px">
                                      <asp:Label ID="Label7" runat="server" ForeColor="#FF66FF" Text="Passion to serve and build, understanding of odds and best"></asp:Label>
                                  </td>
                                  <td style="height: 34px">&nbsp;</td>
                              </tr>
                          </table>
                      </asp:Panel>

                  </td>
                  
              </tr>
                     <tr>
                  <td>

                      <asp:Panel ID="pnlLogin" runat="server" Visible="False">
                          <table>
                             
                              <tr>
                                  <td style="height: 20px; width: 344px;">&nbsp;</td>
                                  <td colspan="2" style="height: 60px; ">
                                      <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#FF3300" CssClass="label"></asp:Label>
                                  </td>
                                  <td style="height: 20px">&nbsp;</td>
                              </tr>
                              <tr>
                                  <td style="height: 30px; width: 344px"></td>
                                  <td colspan="2" style="height: 20px; ">
                                      <asp:Label ID="Label8" runat="server" CssClass="label" Font-Size="Small" ForeColor="#818181" Text="ERP Login Account"></asp:Label>
                                  </td>
                                  <td style="height: 20px"></td>
                              </tr>
                              <tr>
                                  <td style="height: 20px; width: 344px">&nbsp;</td>
                                  <td colspan="2" style="height: 20px; padding-bottom: 2px;text-align:right">
                                      <asp:DropDownList ID="ddlCompanyName" runat="server" CssClass="dropdown" Height="32px" Width="100%">
                                      </asp:DropDownList>
                                  </td>
                                  <td style="height: 20px">&nbsp;</td>
                              </tr>
                              <tr>
                                  <td style="height: 20px; width: 344px">&nbsp;</td>
                                  <td colspan="2" style="height: 20px; padding-bottom: 2px; text-align: right;">
                                       <asp:TextBox ID="txtusername" runat="server" CssClass="form-control textboxcss" placeholder="User Name"></asp:TextBox>
                                  </td>
                                  <td style="height: 20px">&nbsp;</td>
                              </tr>
                              <tr>
                                  <td style="width: 344px; height: 20px;">&nbsp;</td>
                                  <td style="height: 20px; padding-bottom: 2px;" colspan="2">
                                      <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control textboxcss" placeholder="Password" TextMode="Password"></asp:TextBox>
                                  </td>
                                  <td style="height: 20px;">
                                      &nbsp;</td>
                              </tr>
                              <tr>
                                  <td style="width: 344px">&nbsp;</td>
                                  <td style="width: 132px">
                                      <asp:Button ID="btnSignin" runat="server" CssClass="btn btn-primary NoRad" OnClick="btnSignin_Click" Text="Sign in" />
                                  </td>
                                  <td style="width: 275px; text-align: right;">
                                      <asp:LinkButton ID="LinkButton1" runat="server">Can&#39;t access your account?</asp:LinkButton>
                                  </td>
                                  <td>&nbsp;</td>
                              </tr>
                              <tr style="height:160px">
                                  <td style="width: 344px;">
                                      &nbsp;</td>
                                  <td style="width: 132px; ">&nbsp;</td>
                                  <td style="width: 275px">&nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>
                              <tr style="height:1px">
                                  <td style="padding-left: 8px;" colspan="3">
                                      <div class="panel panel-default" style="border-style:none;background-color: #CCCCCC; height:1px">
                                      </div>
                                  </td>
                                  <td style="width: 182px; height: 1px;">
                                      &nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>
                              <tr>
                                  <td style="width: 344px">&nbsp;</td>
                                  <td colspan="2" style="text-align: right;font-family:Tahoma">
                                      <asp:Label ID="Label9" runat="server" CssClass="text-center" Font-Size="35pt" ForeColor="#919191" Text="MY COMPANY"></asp:Label>
                                  </td>
                                  <td>&nbsp;</td>
                              </tr>
                              <tr style="height:50px">
                                  <td style="width: 344px">&nbsp;</td>
                                  <td colspan="2" style="text-align: right;font-family:Tahoma">&nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>
                          </table>
                      </asp:Panel>

                  </td>
              </tr>
                     </table>
        </div>
            </div>
    </div>       
    </form>
</body>
</html>
