<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Changepassword.aspx.cs" Inherits="Changepassword" %>

<%@ Register src="Modules/UC/ucChangePassword.ascx" tagname="ucChangePassword" tagprefix="uc10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style5 {
            width: 1000px;
            text-align: left;
            vertical-align:top;
        }
        .auto-style6 {
            width: 267px;
            text-align: left;
        }
        .auto-style7 {
            width: 917px;
            text-align: left;
            vertical-align:top;
        }
        .auto-style13 {
            height: 23px;
        }
        .auto-style15 {
            width: 100px;
            height: 77px;
        }
        .auto-style16 {
            height: 77px;
        }
        #yui_3_18_1_9_1423512017250_123 {}
        </style>
</head>

    

<body>
   
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%; height:630px">
            <tr >
                <td class="auto-style15">
                    </td>
                <td style="vertical-align:top" class="auto-style16">
                    <table style="width:100%; background-color: #FFFFFF; text-align-last:right">
                        <tr>
                            <td class="auto-style6">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/CSSstyleTheme/Images/UserLogo.jpg" Height="41px" Width="91px" />
                            </td>
                            <td class="auto-style7"></td>
                            <td class="auto-style5">
                            </td>
                            <td style="text-align: right">
                                &nbsp;</td>
                        </tr>
                        </table>
                </td>
                <td class="auto-style15">
                    </td>
            </tr>
          
            <tr >
                <td style="width:100px">
                    &nbsp;</td>
                <td style="vertical-align:top">
                    
                    <table style="width:100%; background-color: #FFFFFF;">
                        <tr>
                            <td class="auto-style5" style="text-align:left">
                                <span id="Label10" style="color:#666666;font-family:Lao UI;font-size:9pt;font-weight: 700">Help on signing in.</span>
                                <br />
                                <li>
                                    <h3 style="font-family: 'Lao UI'; font-size: small; color: #808080">Concerned about password security?</h3>
                                    <cite style="font-family: 'Lao UI'; font-size: small; font-style: normal; color: #808080">Submit your ID and password using SSL, which provides a level of security when transmitting data. </cite> </li>
                                
                                <li>
                                    <h3 style="font-family: 'Lao UI'; font-size: small; color: #808080">What if I forgot my ID or password?</h3>
                                </li>
                                <li>
                                    <h3 style="font-family: 'Lao UI'; font-size: small; color: #808080">Having problems logging in?</h3>
                                    <cite style="font-family: 'Lao UI'; font-size: small; color: #808080; font-style: normal">Please contact with administrator of your login related problem.</cite> </li>
                            </td>
                            <td style="text-align:center; vertical-align:top ">
                                <uc10:ucChangePassword ID="ucChangePassword1" runat="server" />
                            </td>
                        </tr>
                        </table>
                    
                </td>
                <td style="width:100px">
                    &nbsp;</td>
            </tr>
          
            <tr>
                <td class="auto-style13">
                    </td>
                <td >
                    &nbsp;</td>
                <td style="text-align:center" class="auto-style13">
                    </td>
            </tr>
          
            </table>
    </div>

    </form>
    
</body>
</html>
  