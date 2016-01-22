<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmSearchBookByCompanyBookNo.aspx.vb" Inherits="WebApp_frmSearchBookByCompanyBookNo" Title="ค้นหาหนังสือ" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ค้นหาจากเลขที่หนังสือองค์กร
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
                        <td align="right" class="Csslbl" width="20%">เลขที่หนังสือองค์กร :</td>
                        <td align="left" class="Csslbl" width="80%">
                            <uc1:txtAutoComplete ID="txtCompanyBookNo" runat="server"  Width="240" IsNotNull="true" />
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
                * สามารถค้นหาได้จากบางส่วนของเลขที่หนังสือองค์กร <br />
                เช่น <b>"SONY 05/255" จะได้ผลลัพธ์เป็น "SONY 05/255<font color="red">0</font>" ถึง 
                "SONY 05/255<font color="red">9</font>"</b>
            </td>
        </tr>
    </table>
</asp:Content>
