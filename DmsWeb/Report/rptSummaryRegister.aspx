<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="rptSummaryRegister.aspx.vb" Inherits="Report_rptSummaryRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc7" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
        <td align="right"></td>
            <td align=left class="CssHead" colspan="2">
                รายงานสรุปเอกสารที่ลงทะเบียน</td>
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
            <td align="right" width="15%" valign="top" class="Csslbl">
                กลุ่มเรื่อง :
            </td>
            <td width="85%" align="left">
                <asp:DropDownList ID="cmbGroupTitle" runat="server" CssClass="zComboBox" Width="250px"  >
                </asp:DropDownList>
                <cc1:ListSearchExtender id="LSE" runat="server" TargetControlID="cmbGroupTitle" PromptText=""
                    PromptCssClass="zHidden" PromptPosition="Bottom" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
            </td>
        </tr>
        <tr>
            <td align="right" width="15%" valign="top" class="Csslbl">
                วันที่ลงทะเบียน :
            </td>
            <td width="85%" align="left">
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
            <td align="right" width="15%" valign="top" class="Csslbl">
                &nbsp;</td>
            <td align="left" width="85%">
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="ดูรายงาน" 
                    Width="100px" 
                    />
&nbsp;<asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>

