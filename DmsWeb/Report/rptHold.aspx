<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="rptHold.aspx.vb" Inherits="Report_rptHold" %>

<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc7" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td>&nbsp;
            </td>
            <td  align="left" class="CssHead" colspan="2">
                รายงานงานถือครอง</td>
        </tr>
        <tr>
            <td class="CssHead" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                สำนัก :
            </td>
            <td align="left" class="Csslbl" width="85%">
                <uc7:cmbAutoComplete ID="cmbOrg" runat="server" Width="250" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td align="left" class="Csslbl" width="85%">
                <asp:CheckBox ID="CheckBox1" runat="server" 
                    Text="เฉพาะที่มีระบุระยะเวลาแล้วเสร็จ" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td class="Csslbl" width="85%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td align="left" class="Csslbl" width="85%">
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="ดูรายงาน" 
                    Width="100px" />
                <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" 
                    Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>

