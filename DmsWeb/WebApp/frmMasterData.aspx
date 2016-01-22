<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmMasterData.aspx.vb" Inherits="Master_frmMasterData" %>

<%@ Register Src="../UserControls/ctlCategory.ascx" TagName="ctlCategory" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/ctlSubCategory.ascx" TagName="ctlSubCategory" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/ctlDocSpeed.ascx" TagName="ctlDocSpeed" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/ctlDocSecret.ascx" TagName="ctlDocSecret" TagPrefix="uc4" %>
<%@ Register Src="../UserControls/ctlModule.ascx" TagName="ctlModule" TagPrefix="uc5" %>
<%@ Register Src="../UserControls/ctlMenu.ascx" TagName="ctlMenu" TagPrefix="uc6" %>
<%@ Register Src="../UserControls/ctlCompany.ascx" TagName="ctlCompany" TagPrefix="uc7" %>
<%@ Register Src="../Template/cltRoles.ascx" TagName="ctlRoles" TagPrefix="uc8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="CssHead" width="50%">
                ข้อมูลระบบ
            </td>
            <td colspan="2" width="50%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:ctlCategory ID="ctlCategory1" runat="server" AddStatus="True" />
            </td>
            <td>
                <uc2:ctlSubCategory ID="ctlSubCategory1" runat="server" AddStatus="True" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc4:ctlDocSecret ID="ctlDocSecret1" runat="server" AddStatus="True" />
            </td>
            <td>
                <uc3:ctlDocSpeed ID="ctlDocSpeed1" runat="server" AddStatus="True" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc5:ctlModule ID="ctlModule1" runat="server" AddStatus="True" />
            </td>
            <td>
                <uc6:ctlMenu ID="ctlMenu1" runat="server" AddStatus="True" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc8:ctlRoles ID="ctlRoles1" runat="server" AddStatus="True" />
            </td>
            <td>
                <uc7:ctlCompany ID="ctlCompany1" runat="server" AddStatus="True" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
