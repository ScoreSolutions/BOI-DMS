<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master"
    AutoEventWireup="false" CodeFile="frmMasterHoliday.aspx.vb" Inherits="WebApp_frmMasterHoliday" %>
<%@ Register Src="../UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="CssHead" colspan="4" >วันหยุดราชการ</td>
        </tr>
        <tr>
            <td colspan="4" align="center" >
                <table border="0" cellpadding="0" cellspacing="0" width="60%" >
                    <tr>
                        <td width="40%" align="right" >วันหยุดราชการ :</td>
                        <td width="60%" align="left">
                            <uc1:txtDate ID="txtHoliday" runat="server" />
                            <uc3:txtAutoComplete ID="txtID" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >ความสำคัญ :</td>
                        <td align="left">
                            <uc3:txtAutoComplete ID="txtDescription" runat="server" FieldName="description" TableName="holiday" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSave" runat="server" CssClass="CssBtn" Text="บันทึก" Width="100px" />&nbsp;
                            <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="เคลียร์" Width="100px" />&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>                    
                </table>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4">
                <div align="center">
                    <table width="600px" class="mainTableFrame">
                        <tr>
                            <td class="subHeader" style="text-align: center">
                                <uc2:cmbComboBox ID="DDyear" AutoPosBack="true" runat="server" IsDefaultValue="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lnkCalendar" runat="server" Text="Generated Caslendar Holder"></asp:Label>
                            </td>
                        </tr>
                    </table> 
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
