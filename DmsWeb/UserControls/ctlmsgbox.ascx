<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlmsgbox.ascx.vb" Inherits="UserControls_ctlmsgbox" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="PageControl.ascx" tagname="pagecontrol" tagprefix="uc1" %>
<%@ Register src="txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>
<asp:Panel ID="Panel1" runat="server" Width="468px">
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="width: 466px;" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 20px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="fontonlabel" >ข้อความ</td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="right" class="fontonlabel" width="20%">
                &nbsp;</td>
            <td class="fontonlabel" width="80%">
            </td>
        </tr>      
        <tr>
           
            <td colspan = "2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" 
                    Text="กรุณากรอกข้อมูลที่มีเครื่องหมาย * ให้ครบก่อนทำการบันทึก !!!"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="fontonlabel">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="ตกลง" />
                </td>
        </tr>
        <tr>
            <td colspan="2" class="fontonlabel">
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>