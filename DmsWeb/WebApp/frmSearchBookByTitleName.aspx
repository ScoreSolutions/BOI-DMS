<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmSearchBookByTitleName.aspx.vb" Inherits="WebApp_frmSearchBookByTitleName" Title="ค้นหาหนังสือ" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ค้นหาจากชื่อเรื่อง
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
                        <td align="right" class="Csslbl" width="20%">ชื่อเรื่อง :</td>
                        <td align="left" class="Csslbl" width="80%">
                            <uc1:txtAutoComplete ID="txtTitleName" runat="server"  Width="240" IsNotNull="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            วันที่ลงทะเบียน :
                        </td>
                        <td class="Csslbl" width="85%" align="left">
                            <table border="0" >
                                <tr>
                                    <td><uc2:txtDate ID="txtRegisDateFrom" runat="server" /></td>
                                    <td>&nbsp;ถึง</td>
                                    <td><uc2:txtDate ID="txtRegisDateTo" runat="server" /></td>
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
                * สามารค้นหาโดยระบุช่วง วันที่ลงทะเบียนหนังสือ ของชื่อเรื่องที่ต้องการค้นหาได้ <br />
                หากไม่ระบุช่วงวันที่ ระบบจะทำการค้นหาเรื่องทั้งหมดที่ลงทะเบียนไว้ในระบบ ตามชื่อเรื่อง (ซึ่งจะใช้เวลาในการค้นหานานกว่าการระบุช่วงวันที่) ที่ระบุไว้ในช่อง ชื่อเรื่อง
            </td>
        </tr>
    </table>
</asp:Content>
