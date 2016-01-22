<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incBookIn.ascx.vb" Inherits="UserPageControls_incBookIn" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ctlGroupTitle.ascx" TagName="ctlGroupTitle" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/ctlRichTextBox.ascx" TagName="ctlRichTextBox" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/cmbCombobox.ascx" TagName="cmbCombobox" TagPrefix="uc8" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
    .style3
    {
        color: #000000;
        text-decoration: none;
        vertical-align: top;
        padding: 1px;
        font-style: normal;
        font-variant: normal;
        font-size: 20px;
        line-height: normal;
        font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
        }
    .style4
    {
        color: #000000;
        text-decoration: none;
        vertical-align: top;
        padding: 1px;
        font-style: normal;
        font-variant: normal;
        font-size: 20px;
        line-height: normal;
        font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
        text-align: right;
        width: 430px;
    }
    .style5
    {
        width: 112px;
    }
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
    .style7
    {
        width: 216px;
    }
    .style9
    {
        color: #000000;
        text-decoration: none;
        vertical-align: top;
        padding: 1px;
        font-style: normal;
        font-variant: normal;
        font-size: 20px;
        line-height: normal;
        font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
        width: 45px;
    }
</style>

<script language="javascript">
    function MyApp(sender) {
        document.getElementById('<%=cmbSecret1.ClientID %>').value = sender.value;
    }
</script>

         <td colspan="4">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" 
    align="center" class="Csslbl">
     <tr>
                        <td align="center">
                            <asp:DropDownList ID="cmbSecretID" runat="server" CssClass="TextBox" 
                                Height="24px" Width="200px" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                         <tr>
                        <td align="center">
                           <asp:Label ID="Label2" runat="server" CssClass="CssHeadBook" Text="บันทึกข้อความ"></asp:Label>
                        </td>
                    </tr>
            </table>
<table width="100%">
    <tr>
                <td class="style5">
                  
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/crudSmall.png" />
                    <asp:Label ID="Label3" runat="server" Width="30px"></asp:Label>
                </td>
                <td align="left" valign="bottom" class="style6">
                  
                    <uc8:cmbCombobox ID="cmbSpeenID" runat="server" DefaultDisplay="ชั้นความเร็ว(ถ้ามี)" Width="200px" />
                </td>
            </tr>
            
            <tr>
                <td align="left" class="style6">
                  
        ส่วนราชการ :
                </td>
                <td align="left" valign="bottom" class="style6">
                  
        <uc2:txtBox ID="txtOrgBookOwner" runat="server" Width="650" Text="สำนักงานคณะกรรมการส่งเสริมการลงทุน"
            TextType="TextView" />
                </td>
            </tr>
            
            <tr>
                <td align="left" class="style6">
                  
                    ที่ :</td>
                <td align="left" valign="bottom" class="style3">
                  
                            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td class="style7">
                  
                                        <uc2:txtbox ID="txtBookNo" runat="server"  Width="200" IsNotNull="False" />
                                    </td>
                                    <td class="style9">
                                        วันที่&nbsp;
                                    </td>
                                    <td class="style6">
                    <uc3:txtDate ID="txtDate1" runat="server" IsNotNull="false" />
                                    </td>
                                </tr>
                            </table>
                </td>
            </tr>
            
<tr>
    <td align="left" class="style6">
        เรื่อง :
    </td>
    <td align="left" class="style6" >
                                        <uc2:txtbox ID="txtTitle" runat="server"  Width="650" IsNotNull="True" />
    </td>
</tr>
            
<tr>
    <td align="left" class="style6">
        เรียน :</td>
    <td align="left" class="style6" >
                                        <uc2:txtbox ID="txtLean" runat="server"  Width="650" IsNotNull="True" />
    </td>
</tr>
            
<tr>
    <td align="left" class="style6" valign="top">
        เนื้อความ :
    </td>
    <td align="left" class="style6" >
        <uc1:ctlRichTextBox ID="ctlDetail" runat="server" Width="650" 
            Height="250" IsNotNull="False" />
    </td>
</tr>
</table>
<table width="100%">

<tr>
    <td align="left" valign="top" class="style3" width="200">
        &nbsp;</td>
    <td colspan="2" align="left" >
        &nbsp;</td>
</tr>
</table>

        <table width="100%" id="tbOfficerSign" runat="server" visible="false" >
             <tr>
                <td class="style4">ลงชื่อ :</td>
                <td class="style6" align="left">
                    <uc2:txtBox ID="txtOfficerSign" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td class="style4">ตำแหน่ง :</td>
                <td class="style6" align="left">
                    <uc2:txtBox ID="txtPositionSign" runat="server" Width="300px"  />
                </td>
            </tr>
        </table>

        <table width="100%">
            <tr>
                <td align="center" class="style6" valign="top" >
                    <asp:DropDownList ID="cmbSecret1" name="cmbSecret1" runat="server" CssClass="TextBox" 
                        Enabled="False" Height="24px" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            
        </table>
    </td>
</tr>

