<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incBookSeal.ascx.vb" Inherits="UserPageControls_incBookSeal" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ctlGroupTitle.ascx" TagName="ctlGroupTitle" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/ctlRichTextBox.ascx" TagName="ctlRichTextBox" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/cmbCombobox.ascx" TagName="cmbCombobox" TagPrefix="uc8" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .style6
    {
        color: #000000;
        text-decoration: none;
        padding: 1px;
        font-style: normal;
        font-variant: normal;
        font-size: 20px;
        line-height: normal;
        font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
    }
</style>

<script language="javascript">
    function MyApp(sender) {
        document.getElementById('<%=cmbSecret1.ClientID %>').value = sender.value;
    }
</script>

<tr>
    <td>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td  align="center">
                            <asp:DropDownList ID="cmbSecretID" runat="server" CssClass="TextBox" 
                                Height="24px" Width="200px" >
                            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <img src="../Images/crud.JPG" width="105px" height="114px" alt="" />
                </td>
            </tr>
            </table>
            
            <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td class="style6" ></td>
                <td colspan ="2" align="left" class="style6" >
                    <uc8:cmbCombobox ID="cmbSpeenID" runat="server" IsDefaultValue="false"
                        Width="150px" />
                </td>
               
            </tr>
            <tr>
                <td align="left" class="style6">
                    ที่ :
                </td>
                <td colspan ="3"  align="left" class="style6">
                    <asp:TextBox ID="txtBookNo" runat="server" Width="150px" />
                </td>
               
            </tr>
            <tr>
                <td align="left" class="style6">
                    ถึง :
                </td>
                <td class="style6" colspan="2" align="left">
                    <uc2:txtBox ID="txtLean" runat="server" Width="630" IsNotNull="True" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" class="style6">
                    เนื้อความ :
                </td>
                <td colspan="2" align="left" class="style6">
                    <uc1:ctlRichTextBox ID="ctlDetail" runat="server" Width="630" 
                        Height="250" IsNotNull="False" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style6">
                    ส่วนราชการ :
                </td>
                <td colspan="2" align="left" class="style6" >
                    <uc2:txtBox ID="txtOrgBookOwner" runat="server" Width="400px" Text="สำนักงานคณะกรรมการส่งเสริมการลงทุน"
                        TextType="TextView" IsNotNull="True" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style6">
                    ส่วนราชการเจ้าของเรื่อง :
                </td>
                <td colspan="2" align="left" class="style6" >
                    <uc2:txtBox ID="txtOrgTitleOwner" runat="server" Width="630" Text="" 
                        IsNotNull="True" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style6">
                    โทรศัพท์ :
                </td>
                <td align="left" colspan="2" class="style6" >
                    <uc2:txtBox ID="txtTel" runat="server" Width="100px" />
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="style6">
                    โทรสาร :
                </td>
                <td align="left" colspan="2"  class="style6">
                    <uc2:txtBox ID="txtFax" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style6" >
                    ที่ตั้ง :
                </td>
                <td align="left" colspan="2" class="style6" >
                    <uc2:txtBox ID="txtOfficeAddress" runat="server" Width="333px" />
                </td>
            </tr>
            </table>
            
            <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td align="center">
                            <asp:DropDownList ID="cmbSecret1" name="cmbSecret1" runat="server" CssClass="TextBox" 
                                Enabled="False" Height="24px" Width="200px">
                            </asp:DropDownList>
                </td>
            </tr>
        </table>
    </td>
</tr>
