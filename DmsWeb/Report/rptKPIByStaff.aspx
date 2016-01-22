<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="rptKPIByStaff.aspx.vb" Inherits="Report_rptKPI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="left" class="CssHead" colspan="2">KPI รายบุคคล</td>
        </tr>
        <tr>
            <td class="CssHead" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" width="15%" valign="top" class="Csslbl">
                สำนัก :
            </td>
            <td align="left" width="85%">
                <asp:DropDownList ID="cmbOwnerOrgID" runat="server" CssClass="zComboBox" Width="300px" >
                </asp:DropDownList>
                <font color="red">*</font>
                <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmbOwnerOrgID" PromptText=""
                    PromptCssClass="zHidden" PromptPosition="Bottom" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                
                <cc1:CascadingDropDown ID="cdlOwnerOrgID" runat="server" TargetControlID="cmbOwnerOrgID"
                    Category="OrgOwner" PromptText="เลือก" 
                    ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetOrgIDForDDL" />
            </td>
        </tr>
        <tr style="height:25px">
            <td align="right" class="Csslbl" >เจ้าหน้าที่ : </td>
            <td valign="top" align="left" >
                <asp:DropDownList ID="cmbOwnerStaffID" runat="server" CssClass="zComboBox"  Width="300px" >
                </asp:DropDownList>
                <font color="red">*</font>
                <cc1:CascadingDropDown ID="cdlOwnerStaffID" runat="server" TargetControlID="cmbOwnerStaffID"
                    Category="StaffOwner" PromptText="เลือก" LoadingText="กรุณารอสักครู่"
                    ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetStaffByOrgID"
                    ParentControlID="cmbOwnerOrgID"  />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                ณ วันที่ :
            </td>
            <td align="left" class="Csslbl" width="85%">
                <table>
                    <tr>
                        <td align="left"><uc2:txtDate ID="txtDate1" runat="server" /></td>
                        <td>&nbsp;ถึง</td>
                        <td align="left"><uc2:txtDate ID="txtDate2" runat="server" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >&nbsp;</td>
            <td class="Csslbl" align="left" ><asp:CheckBox ID="chkIsExpectedFinishDate" runat="server" Text="เฉพาะที่มีระบุระยะเวลาแล้วเสร็จ" /></td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td align="left" class="Csslbl" width="85%">
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="ดูรายงาน" 
                    Width="100px" 
                    />
                <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" 
                    Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>

