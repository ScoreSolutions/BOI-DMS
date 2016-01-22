<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLoginLDAP.aspx.vb" Inherits="frmLoginLDAP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BOI-DMS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="bg" style="background-image:url('Images/LoginPage.jpg');background-repeat:no-repeat;background-position:center;height:640px;" >
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr style="height:420px" ><td>&nbsp;</td></tr>

            <tr>
                <td>
                    <asp:Login ID="Login1" runat="server"  Width="100%" >
                        <LayoutTemplate>
                            <table width="310" cellpadding="0" cellspacing="0" 
                                style="background-color:#F3F3F3;" align="center">
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr><td colspan="2">&nbsp;</td></tr>
                                            <tr style="height:25px">
                                                <td style="width:100px" align=right>
                                                     <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">ชื่อเข้าระบบ :</asp:Label>
                                                </td>
                                                <td style="width:170px;padding: 3px 3px 3px 3px">
                                                                <asp:TextBox ID="UserName" runat="server" CssClass="zTextbox" Width="150px"></asp:TextBox>&nbsp;
                                                    <font style="color:red">*</font></td>
                                            </tr>
                                            <tr style="height:25px">
                                                <td align=right>
                                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" >รหัสผ่าน :</asp:Label>
                                                </td>
                                                <td style="padding: 3px 3px 3px 3px">
                                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="zTextbox" Width="150px"></asp:TextBox>&nbsp;
                                                    <font style="color:red">*</font></td>
                                            </tr>
                                            <tr style="height: 25px">
                                                <td align="right" style="width: 80px">
                                                </td>
                                                <td style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px; padding-top: 3px">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="ลงชื่อเข้าใช้" ValidationGroup="Login1" CssClass="zButton" Font-Bold="True" />
                                                </td>
                                            </tr>
                                            <tr style="height:30px" ><td colspan="2">&nbsp;</td></tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>            
                        </LayoutTemplate>
                    </asp:Login>
                </td>
            </tr>
        </table>
    </div>
    
    </form>
</body>
</html>
