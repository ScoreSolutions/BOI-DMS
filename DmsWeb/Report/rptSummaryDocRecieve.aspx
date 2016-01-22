<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="rptSummaryDocRecieve.aspx.vb" Inherits="Report_rptSummaryDocRecieve" %>

<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register src="../UserControls/ctlCompany.ascx" tagname="ctlCompany" tagprefix="uc3" %>
<%@ Register Src="../UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="right" style="width: 100%">
        <tr>
        <td ></td>
            <td align="left" class="CssHead" colspan="2">
                รายงานสรุปเอกสารที่ลงรับ</td>
        </tr>
        <tr>
         <td class="CssHead" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" width="15%" valign="top" class="Csslbl">
                สำนัก :
            </td>
            <td width="85%" align="left">
                <uc7:cmbAutoComplete ID="cmbOrg" runat="server" Width="250" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                วันที่รับเข้าสำนัก :
            </td>
            <td align="left">
                <table border="0" >
                    <tr>
                        <td><uc2:txtDate ID="txtDate1" runat="server" /></td>
                        <td>&nbsp;ถึง</td>
                        <td><uc2:txtDate ID="txtDate2" runat="server" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" width="15%" valign="top" class="Csslbl">
                &nbsp;</td>
            <td width="85%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td align ="left">
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="ดูรายงาน" 
                    Width="100px" />&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" 
                    Width="100px" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

