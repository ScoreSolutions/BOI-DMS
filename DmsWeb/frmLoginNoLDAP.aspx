<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLoginNoLDAP.aspx.vb" Inherits="frmLoginNoLDAP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOI-DMS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login1" runat="server"  Width="100%" >
            <LayoutTemplate>
                <table width="380" cellpadding="0" cellspacing="0" 
                    style="border: 3px solid #C0C0C0; background-color:#ffffff; " align="center">
                    <tr>
                        <td style="width:100px; padding: 3px 3px 3px 3px;" align="center"><img src="Images/keys.png" alt="" /></td>
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="2" style="height:15px">&nbsp;
                                    </td>
                                </tr>
                                <tr style="height:25px">
                                    <td style="width:100px" align=right>
                                         <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">ชื่อเข้าระบบ :</asp:Label>
                                    </td>
                                    <td style="width:150px;padding: 3px 3px 3px 3px">
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="zTextbox" Width="130px"></asp:TextBox>&nbsp;
                                        <font style="color:red">*</font></td>
                                </tr>
                                <tr style="height:25px">
                                    <td align=right>
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">รหัสผ่าน :</asp:Label>
                                    </td>
                                    <td style="padding: 3px 3px 3px 3px">
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="zTextbox" Width="130px"></asp:TextBox>&nbsp;
                                        <font style="color:red">*</font></td>
                                </tr>
                                <tr style="height: 25px">
                                    <td align="right" style="width: 80px">
                                    </td>
                                    <td style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px; padding-top: 3px">
                                                    <asp:CheckBox ID="RememberMe" runat="server" Text="จดจำการเข้าระบบ" Visible="false" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:15px" align="center">
                            <hr size="1" style=" border-style:solid; border-width:1px; height:0px; color:#3399FF; width:95%;" />
                            <span style="color:red"><asp:Literal ID="FailureText" runat="server" EnableViewState="False" Visible="False"></asp:Literal></span>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="right">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="ลงชื่อเข้าใช้" ValidationGroup="Login1" CssClass="zButton" Font-Bold="True" />
                                                &nbsp;&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:15px">
                        
                        </td>
                    </tr>
                </table>            
            </LayoutTemplate>
        </asp:Login>
    </div>
    </form>
</body>
</html>
