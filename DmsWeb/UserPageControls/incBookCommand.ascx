<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incBookCommand.ascx.vb" Inherits="UserPageControls_incBookCommand" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
<%@ Register src="~/UserControls/ctlGroupTitle.ascx" tagname="ctlGroupTitle" tagprefix="uc4" %>
<%@ Register src="~/UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc7" %>
<%@ Register src="~/UserControls/ctlRichTextBox.ascx" tagname="ctlRichTextBox" tagprefix="uc1" %>
<%@ Register Src="~/UserControls/cmbCombobox.ascx" TagName="cmbCombobox" TagPrefix="uc8" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
    
    .style7
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
        text-align: center;
    }

    .style11
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
    }

</style>

<tbody id="BookCommand" runat="server" visible="false" >
<tr>
<td>
<table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td width="33%">
                    &nbsp;
                </td>
                <td align="center" width="33%">
                    <img src="../Images/crud.JPG" width="105px" height="114px" alt="" />
                </td>
                <td width="33%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" valign="bottom" class="style7">
                           <asp:Label ID="Label2" runat="server" CssClass="Csslbl" 
                        Text="คำสั่ง " Font-Bold="True" Width="60px"></asp:Label>
                        <uc2:txtbox ID="txtTitleCommand1" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style7">
                    &nbsp;<asp:TextBox ID="txtBookNo1" runat="server" Width="150px" />
                    <cc1:TextBoxWatermarkExtender ID="WtxtBookNo" TargetControlID="txtBookNo1" runat="server"
                        WatermarkText="ที่">
                    </cc1:TextBoxWatermarkExtender>
                &nbsp;/<asp:Label ID="Label3" runat="server" Text="๒๕๕๔"></asp:Label>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style7">
                    เรื่อง
            <uc2:txtbox ID="txtTitle1" runat="server"  Width="650px" IsNotNull ="true"  />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style7">
                    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr align="justify">
                <td width="33%" class="style6" valign="top">
                    <asp:Label ID="Label9" runat="server" Text="เนื้อความ :" Width="59px"></asp:Label>
                </td>
                <td align="left" width="33%" class="style6">
            <uc1:ctlRichTextBox ID="ctlDetail1" runat="server" Width="770px" Height="250" 
                        IsNotNull="False" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    </td>
                <td align="left" width="33%" class="style6">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style6" width="100">
                    ทั้งนี้ ตั้งแต่ :</td>
                            <td class="style6">
                                <uc3:txtDate ID="txtDate21" runat="server" IsNotNull="True" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="33%">
                    </td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    </td>
                <td align="left" width="33%" class="style6">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style6" width="100">
                    สั่ง ณ วันที่ :</td>
                            <td class="style6">
                                <uc3:txtDate ID="txtDate11" runat="server" IsNotNull="True" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="33%">
                    </td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" width="33%" class="style11">

                    <table style="width: 100%;">
                        <tr>
                            <td class="style11">
                                <asp:Label ID="Label12" runat="server" Text="ลงชื่อ : " Width="450px"></asp:Label>
                            </td>
                            <td class="style6">
                                <uc2:txtBox ID="txtOfficerSign1" runat="server" Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style11">
                    ตำแหน่ง :</td>
                            <td class="style6">
                    <uc2:txtbox ID="txtPositionSign1" runat="server"  Width="300px" 
                         />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" width="33%" class="style11">
                    &nbsp;</td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="3" align="left" >
                    &nbsp;</td>
               
            </tr>
            </table> 
</td>
</tr>
    <tr>
       
        <td align="right" > </td>
        <td colspan="3">
        </td>
    </tr>
    <tr >
        <td align="right" class="Csslbl" >
        <td></td>
    </tr>
</tbody>
<tbody id="BookRule" runat="server" visible="false" >
    <tr>
<td>
<table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td width="33%">
                    &nbsp;
                </td>
                <td align="center" width="33%">
                    <img src="../Images/crud.JPG" width="105px" height="114px" alt="" />
                </td>
                <td width="33%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" valign="bottom" class="style7">
                           <asp:Label ID="Label1" runat="server" CssClass="Csslbl" 
                        Text="ระเบียบ " Font-Bold="True" Width="60px"></asp:Label>
                        <uc2:txtbox ID="txtTitleCommand2" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" valign="bottom" class="style7">
                           <asp:Label ID="Label5" runat="server" CssClass="Csslbl" 
                        Text="ว่าด้วย " Font-Bold="True" Width="60px"></asp:Label>
                        <uc2:txtbox ID="TxtTitle2" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" valign="bottom" class="style7">
                           (ฉบับที่<asp:TextBox ID="txtBookNo2" runat="server"  Width="100px"  />)
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style7">
                    &nbsp;<asp:Label ID="Label4" runat="server" Text="พ.ศ. ๒๕๕๔"></asp:Label>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style7">
                    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr align="justify">
                <td width="33%" class="style6" valign="top">
                    <asp:Label ID="Label13" runat="server" Text="เนื้อความ :" Width="59px"></asp:Label>
                </td>
                <td align="left" width="33%" class="style6">
            <uc1:ctlRichTextBox ID="ctlDetail2" runat="server" Width="770px" Height="250" 
                        IsNotNull="False" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    </td>
                <td align="left" width="33%" class="style6">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style6" width="100">
                    ประกาศ ณ วันที่ :</td>
                            <td class="style6">
                                <uc3:txtDate ID="txtDate12" runat="server" IsNotNull="True" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="33%">
                    </td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" class="style11">

                    <table style="width: 100%;">
                        <tr>
                            <td class="style11">
                                <asp:Label ID="Label11" runat="server" Text="ลงชื่อ : " Width="450px"></asp:Label>
                            </td>
                            <td class="style6">
                                <uc2:txtBox ID="txtOfficerSign2" runat="server" Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style11">
                    ตำแหน่ง :</td>
                            <td class="style6">
                    <uc2:txtbox ID="txtPositionSign2" runat="server"  Width="300px" 
                         />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" width="33%" class="style11">
                    </td>
                <td width="33%" class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="3" align="left" >
                    &nbsp;</td>
               
            </tr>
            </table> 
</tbody>



<tbody id="BookRegulation" runat="server" visible="false" >
   <tr>
<td>
<table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td width="33%">
                    &nbsp;
                </td>
                <td align="center" width="33%">
                    <img src="../Images/crud.JPG" width="105px" height="114px" alt="" />
                </td>
                <td width="33%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" valign="bottom" class="style7">
                           <asp:Label ID="Label6" runat="server" CssClass="Csslbl" 
                        Text="ข้อบังคับ " Font-Bold="True" Width="60px"></asp:Label>
                        <uc2:txtbox ID="txtTitleCommand3" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" valign="bottom" class="style7">
                           <asp:Label ID="Label7" runat="server" CssClass="Csslbl" 
                        Text="ว่าด้วย " Font-Bold="True" Width="60px"></asp:Label>
                        <uc2:txtbox ID="TxtTitle3" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" valign="bottom" class="style7">
                           (ฉบับที่
                  
                            <asp:TextBox ID="txtBookNo3" runat="server"  Width="100px"  />
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                               TargetControlID="txtBookNo2" runat="server" WatermarkText="ฉบับที่"></cc1:TextBoxWatermarkExtender>
                           )</td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style7">
                    &nbsp;<asp:Label ID="Label8" runat="server" Text="พ.ศ. ๒๕๕๔"></asp:Label>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style7">
                    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr align="justify">
                <td width="33%" class="style6" valign="top">
                    <asp:Label ID="Label14" runat="server" Text="เนื้อความ :" Width="59px"></asp:Label>
                </td>
                <td align="left" width="33%" class="style6">
            <uc1:ctlRichTextBox ID="ctlDetail3" runat="server" Width="770px" Height="250" 
                        IsNotNull="False" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    </td>
                <td align="left" width="33%" class="style6">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style6" width="100">
                    ประกาศ ณ วันที่ :</td>
                            <td class="style6">
                                <uc3:txtDate ID="txtDate13" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="33%">
                    </td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" class="style11">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style11">
                                <asp:Label ID="Label10" runat="server" Text="ลงชื่อ : " Width="450px"></asp:Label>
                            </td>
                            <td class="style6">
                                <uc2:txtBox ID="txtOfficerSign3" runat="server" Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style11">
                    ตำแหน่ง :</td>
                            <td class="style6">
                    <uc2:txtbox ID="txtPositionSign3" runat="server"  Width="300px" 
                         />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" width="33%" class="style11">
                    &nbsp;</td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="3" align="left" >
                    &nbsp;</td>
               
            </tr>
            </table> 
</tbody>