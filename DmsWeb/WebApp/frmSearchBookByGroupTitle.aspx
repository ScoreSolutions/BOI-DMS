<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="frmSearchBookByGroupTitle.aspx.vb" Inherits="WebApp_frmSearchBookByGroupTitle" Title="ค้นหาหนังสือ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ค้นหาจากชื่อกลุ่มเรื่อง
            </td>
        </tr>
        <tr>
            <td align="right" width="15%">
                &nbsp;
            </td>
            <td width="35%">
                &nbsp;
            </td>
            <td align="right" width="15%">
                &nbsp;
            </td>
            <td width="35%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" >
                <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                    <tr>
                        <td align="right" class="Csslbl" width="20%">กลุ่มเรื่อง :</td>
                        <td align="left" class="Csslbl" width="80%">
                            <asp:DropDownList ID="cmbGroupTitle" runat="server" CssClass="zComboBox" Width="300px"   >
                            </asp:DropDownList>
                            <font color="red">*</font>
                            <cc1:ListSearchExtender id="LSE" runat="server" TargetControlID="cmbGroupTitle" PromptText=""
                                PromptCssClass="zHidden" PromptPosition="Top" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl" >หน่วยงาน</td>
                        <td align="left" class="Csslbl">
                            <asp:DropDownList ID="cmbOrgID" runat="server" CssClass="zComboBox" Width="300px" >
                            </asp:DropDownList>
                            <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmbOrgID" PromptText=""
                                PromptCssClass="zHidden" PromptPosition="Bottom" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                            
                            <cc1:CascadingDropDown ID="cdlOwnerOrgID" runat="server" TargetControlID="cmbOrgID"
                                Category="OrgOwner" PromptText="เลือก" 
                                ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetOrgIDForDDL" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Csslbl" align="right" >สถานะหนังสือ</td>
                        <td align="left" class="Csslbl">
                            <uc3:cmbAutoComplete ID="cmbStatus" runat="server" Width="300px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="Csslbl" align="right" >&nbsp;</td>
                        <td align="left" class="Csslbl">
                            <asp:CheckBox ID="chkNoSlash" runat="server" />&nbsp;(คลิกเลือกรณีที่ไม่ต้องการเลขที่มี "/")
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            วันที่ลงทะเบียน :
                        </td>
                        <td class="Csslbl" align="left">
                            <table border="0" >
                                <tr>
                                    <td><uc2:txtDate ID="txtRegisDateFrom" runat="server" /></td>
                                    <td>&nbsp;ถึง</td>
                                    <td><uc2:txtDate ID="txtRegisDateTo" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            วันที่จบงาน :
                        </td>
                        <td class="Csslbl" align="left">
                            <table border="0" >
                                <tr>
                                    <td><uc2:txtDate ID="txtCloseDateFrom" runat="server" /></td>
                                    <td>&nbsp;ถึง</td>
                                    <td><uc2:txtDate ID="txtCloseDateTo" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td>&nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="80px" />
                            &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" Width="80px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" class="Csslbl" align="left">
                * สามารค้นหาโดยระบุช่วง วันที่ลงทะเบียนหนังสือ ของกลุ่มเรื่องที่ต้องการค้นหาได้ <br />
                หากไม่ระบุช่วงวันที่ ระบบจะทำการค้นหาเรื่องทั้งหมดที่ลงทะเบียนไว้ในระบบ ตามกลุ่มเรื่อง (ซึ่งจะใช้เวลาในการค้นหานานกว่าการระบุช่วงวันที่) ที่ระบุไว้ในช่อง กลุ่มเรื่อง
            </td>
        </tr>
    </table>
</asp:Content>
