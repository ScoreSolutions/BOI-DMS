<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incBookPublicRelation.ascx.vb" Inherits="UserPageControls_incBookPublicRelation" %>
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
</style>

<tbody id="BookNotice" runat="server" visible="false" >
  <tr>
<td>
<table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td width="33%" class="Csslbl">
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
                <td align="center" width="33%" valign="bottom" class="style6">
                           <asp:Label ID="Label2" runat="server" CssClass="Csslbl" 
                        Text="ประกาศ " Font-Bold="True"></asp:Label>
                        <uc2:txtbox ID="txtTitleCommand1" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    เรื่อง
            <uc2:txtbox ID="txtTitle1" runat="server"  Width="650px" IsNotNull ="true"  />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr align="justify">
                <td class="style6" valign="top">
                    <asp:Label ID="Label8" runat="server" Text="เนื้อความ :" Width="59px"></asp:Label>
                </td>
                <td align="left" width="33%" class="style6">
            <uc1:ctlRichTextBox ID="ctlDetail1" runat="server" Width="720" Height="250" 
                        IsNotNull="False" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    </td>
                <td align="left" width="33%" class="Csslbl">
                    <table style="width:100%;">
                        <tr>
                            <td class="style6" nowrap="nowrap" width="100">
                    ประกาศ ณ วันที่ :</td>
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
                <td align="right" width="33%" class="Csslbl">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmbOfficeSignID1" />
                                </Triggers>

                                <ContentTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style6" align="right">
                                <asp:Label ID="Label4" runat="server" Text="ลงชื่อ : " Width="370px" 
                                    CssClass="style6"></asp:Label>
                            </td>
                            <td class="style6">
                                <uc7:cmbautocomplete ID="cmbOfficeSignID1" 
                        runat="server" Width="300px" AutoPosBack="True"  />
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" align="right">
                                <asp:Label ID="Label5" runat="server" Text="ตำแหน่ง : "></asp:Label>
                            </td>
                            <td class="style6">
                    <uc2:txtbox ID="txtPositionSign1" runat="server"  Width="300px"  />
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                            </asp:UpdatePanel>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" width="33%" class="Csslbl">
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

<tbody id="BookState" runat="server" visible="false" >
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
                <td align="center" width="33%" valign="bottom" class="style6">
                           <asp:Label ID="Label1" runat="server" CssClass="Csslbl" 
                        Text="แถลงการณ์ " Font-Bold="True"></asp:Label>
                        <uc2:txtbox ID="txtTitleCommand2" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    เรื่อง
            <uc2:txtbox ID="TxtTitle2" runat="server"  Width="650px" IsNotNull ="true"  />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    ฉบับที่ <asp:TextBox ID="txtBookNo2" runat="server" Width="50px" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr align="justify">
                <td width="33%" class="style6" valign="top">
                    <asp:Label ID="Label9" runat="server" Text="เนื้อความ :" Width="59px"></asp:Label>
                </td>
                <td align="left" width="33%" class="style6">
            <uc1:ctlRichTextBox ID="ctlDetail2" runat="server" Width="720" Height="250" 
                        IsNotNull="False" />
                </td>
                <td width="33%" class="style2">
                    </td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" width="33%" class="style6">
                    ส่วนราชการ : <uc2:txtbox ID="txtTitleOwner2" runat="server" Width="400px" 
                        IsNotNull="True" /></td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    </td>
                <td align="right" width="33%" class="Csslbl">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style6" align="right">
                                <asp:Label ID="Label6" runat="server" Text="วันที่ :" Width="590px"></asp:Label>
                            </td>
                            <td class="style6">
                                <uc3:txtDate ID="txtDate12" runat="server" IsNotNull="True" />
                            </td>
                        </tr>
                    </table>
&nbsp;</td>
                <td width="33%">
                    </td>
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
</tbody>


<tbody id="BookNews" runat="server" visible="false" >
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
                <td align="center" width="33%" valign="bottom" class="style6">
                           <asp:Label ID="Label3" runat="server" CssClass="Csslbl" 
                        Text="ข่าว " Font-Bold="True"></asp:Label>
                        <uc2:txtbox ID="txtTitleCommand3" runat="server" Width="400px" IsNotNull="True" />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    เรื่อง
            <uc2:txtbox ID="TxtTitle3" runat="server"  Width="650px" IsNotNull ="true"  />
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    ฉบับที่ <asp:TextBox ID="txtBookNo3" runat="server" Width="50px" />
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                        TargetControlID="txtBookNo2" runat="server"
                        WatermarkText="ฉบับที่">
                    </cc1:TextBoxWatermarkExtender>
                </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    &nbsp;</td>
                <td align="center" width="33%" class="style6">
                    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - </td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr align="justify">
                <td width="33%" class="style6" valign="top">
                    <asp:Label ID="Label10" runat="server" Text="เนื้อความ :" Width="59px"></asp:Label>
                </td>
                <td align="left" width="33%" class="style6">
            <uc1:ctlRichTextBox ID="ctlDetail3" runat="server" Width="720" Height="250" 
                        IsNotNull="False" />
                </td>
                <td width="33%" class="style2" align="center">
                    </td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    &nbsp;</td>
                <td align="right" width="33%" class="style6">
                    ส่วนราชการ : <uc2:txtbox ID="txtTitleOwner3" runat="server" Width="400px" 
                        IsNotNull="True" /></td>
                <td width="33%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="Csslbl">
                    </td>
                <td align="right" width="33%" class="Csslbl">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style6" align="right">
                                <asp:Label ID="Label7" runat="server" Text="วันที่ :" Width="590px"></asp:Label>
                            </td>
                            <td>
                                <uc3:txtDate ID="txtDate13" runat="server" IsNotNull="True" />
                            </td>
                        </tr>
                    </table>
&nbsp;</td>
                <td width="33%">
                    </td>
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
</tbody>