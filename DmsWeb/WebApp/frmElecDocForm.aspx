<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmElecDocForm.aspx.vb" Inherits="WebApp_frmElecDocForm" title="เอกสารอิเล็กทรอนิกส์" %>

<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
<%@ Register src="~/UserControls/ctlCompany.ascx" tagname="ctlCompany" tagprefix="uc6" %>
<%@ Register src="~/UserControls/ctlGroupTitle.ascx" tagname="ctlGroupTitle" tagprefix="uc4" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc7" %>
<%@ Register src="~/UserControls/ctlRichTextBox.ascx" tagname="ctlRichTextBox" tagprefix="uc1" %>
<%@ Register src="~/UserPageControls/incBookOut.ascx" tagname="incBookOut" tagprefix="uc5" %>
<%@ Register src="~/UserPageControls/incBookIn.ascx" tagname="incBookIn" tagprefix="uc9" %>
<%@ Register src="~/UserPageControls/incBookSeal.ascx" tagname="incBookSeal" tagprefix="uc8" %>
<%@ Register src="~/UserPageControls/incBookCommand.ascx" tagname="incBookCommand" tagprefix="uc10" %>
<%@ Register src="~/UserPageControls/incBookPublicRelation.ascx" tagname="incBookPublicRelation" tagprefix="uc11" %>
<%@ Register src="~/UserPageControls/incBookEvidence.ascx" tagname="incBookEvidence" tagprefix="uc12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" >
        <tr>
            <td class="CssHead" colspan="4" >เอกสารอิเล็กทรอนิกส์</td> 
        </tr>
        <tr >
            <td align="right" width="17%">&nbsp;</td>
            <td width="33%">&nbsp;</td>
            <td align="right" width="15%">&nbsp;</td>
            <td width="35%">&nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >ลำดับที่ : </td>
            <td class="Csslbl">
                <uc2:txtbox ID="txtID" runat="server" Visible="false" />
                <uc2:txtbox ID="txtBookNo" runat="server" TextType="TextView" Width="50" />&nbsp;&nbsp;&nbsp;
                เวอร์ชั่นที่ : <uc2:txtbox ID="txtVersionNo" runat="server" TextType="TextView" Width="50" />
            </td>
            <td align="right" class="Csslbl" >วันที่สร้าง : </td>
            <td>
                <uc3:txtDate ID="txtCreateDate" runat="server" DefaultCurrentDate="true" VisibleImg="false" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">ชนิดหนังสือ : </td>
            <td><uc7:cmbCombobox ID="cmbDocCategoryID" runat="server" Width="300px" AutoPosBack="true" IsDefaultValue="false" /></td>
            <td align="right" class="Csslbl">ชนิด :</td>
            <td><uc7:cmbCombobox ID="cmbDocSubCategoryID" runat="server" Width="300px" AutoPosBack="true" IsDefaultValue="false" /></td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr >
            <td colspan="4" align="center" >
                <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderWidth="1px" BorderStyle="Ridge" Width="90%" >
                    <asp:Panel ID="pnlBody" runat="server"  Width="800px" >
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                            <tr >
                                <td width="17%">&nbsp;</td>
                                <td width="33%">&nbsp;</td>
                                <td width="15%">&nbsp;</td>
                                <td width="35%">&nbsp;</td>
                            </tr>
                            <uc5:incBookOut ID="incBookOut1" runat="server" />
                            <uc9:incBookIn ID="incBookIn1" runat="server" Visible="false" />
                            <uc8:incBookSeal ID="incBookSeal1" runat="server" Visible="false" />
                            <uc10:incBookCommand ID="incBookCommand1" runat="server" Visible="false" />
                            <uc11:incBookPublicRelation ID="incBookPublicRelation1" runat="server" Visible="false" />
                            <uc12:incBookEvidence ID="incBookEvidence1" runat="server" Visible="false" />
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr><td colspan="4">
            &nbsp;
            
            </td></tr>
        <tr>
            <td colspan="4" align="right">
                <asp:Button ID="btnSave" runat="server" CssClass="CssBtn" Text="บันทึก" Width="60px" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="CssBtn" Text="ยกเลิก" Width="60px" />&nbsp;
                <asp:Button ID="btnPrint" runat="server" CssClass="CssBtn" Text="พิมพ์" Width="60px" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSaveSend" runat="server" CssClass="CssBtn" Text="บันทึกพร้อมส่ง" Width="100px" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnApprove" runat="server" CssClass="CssBtn" Text="อนุมัติ" Width="100px" />&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

