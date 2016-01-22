<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlReserveBookIn.ascx.vb" Inherits="UserControls_ctlReserveBookIn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="PageControl.ascx" TagName="pagecontrol" TagPrefix="uc1" %>
<%@ Register Src="txtBox.ascx" TagName="txtbox" TagPrefix="uc1" %>
<%@ Register src="ctlSubCategory.ascx" tagname="ctlSubCategory" tagprefix="uc2" %>
<%@ Register src="ctlCategory.ascx" tagname="ctlCategory" tagprefix="uc3" %>
<%@ Register src="ctlCompany.ascx" tagname="ctlCompany" tagprefix="uc4" %>
<%@ Register src="txtDate.ascx" tagname="txtDate" tagprefix="uc5" %>
<asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/lock.png" ImageAlign="AbsMiddle" />&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Label ID="lblCaption" runat="server" CssClass="CssHead" 
    Text="จองเลขหนังสือรับ"></asp:Label>
<asp:Panel ID="Panel1" runat="server" Width="600">
    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998">
                จองเลขหนังสือรับ
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                จำนวนเลขที่จอง :
            </td>
            <td class="Csslbl" width="80%">
                <uc1:txtbox ID="txtCode" runat="server" IsNotNull="true" MaxLength="2" 
                    TextKey="TextDouble" Width="50" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                กลุ่มเรื่อง :
            </td>
            <td class="Csslbl">
                <uc3:ctlCategory ID="ctlCategory1" runat="server" SelectStatus="True" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                เรื่อง :
            </td>
            <td class="Csslbl">
                <uc1:txtbox ID="txtbox3" runat="server" Width ="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                วันที่เอกสาร :
            </td>
            <td class="Csslbl">
                <uc5:txtDate ID="txtDate1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                เรียน :
            </td>
            <td class="Csslbl">
                <uc1:txtbox ID="txtbox4" runat="server" Width ="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                จองให้กับหน่วยงาน</td>
            <td class="Csslbl">
                <uc4:ctlCompany ID="ctlCompany1" runat="server" SelectStatus="True" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="Csslbl">
                <asp:Button ID="btnSave" runat="server" Text="จองเลข" CssClass="CssBtn" 
                    Width="60px" />
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
 
