<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmReserveBookIn.aspx.vb" Inherits="WebApp_frmReserveBookIn" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtdate" tagprefix="uc5" %>
<%@ Register src="../UserControls/ctlCompany.ascx" tagname="ctlcompany" tagprefix="uc4" %>
<%@ Register src="../UserControls/txtBox.ascx" tagname="txtbox" tagprefix="uc1" %>
<%@ Register src="../UserControls/ctlGroupTitle.ascx" tagname="ctlGroupTitle" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
            <tr>
                <td align="left" class="CssHead" width="20%" colspan="2">
                    จองเลขหนังสือรับ</td>
            </tr>
            <tr>
                <td align="left" class="CssHead" width="20%" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="Csslbl" width="20%">
                    จำนวนเลขที่จอง :
                </td>
                <td class="Csslbl" width="80%">
                    <uc1:txtbox ID="txtCode" runat="server" IsNotNull="true" MaxLength="2" 
                        TextKey="TextInt" Width="50" />
                    
                </td>
            </tr>
            <tr>
                <td align="right" class="Csslbl">
                กลุ่มเรื่อง :
                </td>
                <td class="Csslbl">
                    <uc2:ctlGroupTitle ID="ctlGroupTitle1" runat="server" />
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
                    <uc5:txtDate ID="txtDate1" runat="server" VisibleImg="false" DefaultCurrentDate="true" />
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
 
</asp:Content>

