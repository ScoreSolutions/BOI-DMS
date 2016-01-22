<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incBookEvidence.ascx.vb"
    Inherits="UserPageControls_incBookEvidence" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ctlGroupTitle.ascx" TagName="ctlGroupTitle" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/ctlRichTextBox.ascx" TagName="ctlRichTextBox" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/txtTime.ascx" TagName="txtTime" TagPrefix="uc5" %>
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

<tbody id="BookAssure" runat="server" visible="false">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                <tr>
                    <td width="100%"  colspan="3" align="center">
                        <img src="../Images/crud.JPG" width="105px" height="114px" alt="" />
                    </td>
                </tr>
                </table>
                
                <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                <tr>
                    <td align="center" class="style6">
                        <asp:TextBox ID="txtTitleOwner1" runat="server" Width="400px" />
                        <cc1:TextBoxWatermarkExtender ID="textboxwatermarkextenderOwner" TargetControlID="txtTitleOwner1"
                            runat="server" WatermarkText="ส่วนราชการเจ้าของหนังสือ">
                        </cc1:TextBoxWatermarkExtender>
                    </td>
                </tr>
                </table>
                
                <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                <tr>
                    <td class="style6" align="left">
                        &nbsp;</td>
                </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                <tr align="justify">
                    <td class="style6" width="120">
                        เลขที่ :</td>
                    <td align="left" class="style6">
                        <asp:TextBox ID="txtBookNo1" runat="server" Width="50px" />
                    </td>
                </tr>
                
                <tr align="justify">
                    <td class="style6" valign="top">
                        เนื้อความ :
                    </td>
                    <td align="left" class="style6">
                        <uc1:ctlRichTextBox ID="CtlDetail1" runat="server" Width="630" 
                            Height="250" IsNotNull="False" />
                    </td>
                </tr>
                
                </table>
                
                <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                <tr align="justify">
                    <td class="style6" width="120">
                        &nbsp;</td>
                    <td align="left" class="style6" width="80">
                        ให้ไว้ ณ วันที่ :</td>
                    <td align="left" class="style6">
                        <uc3:txtDate ID="txtDate11" runat="server" IsNotNull="True" />
                    </td>
                </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmbOfficeSignID1" />
                                </Triggers>

                                <ContentTemplate>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                <tr >
                    <td align="right" class="style6" width="450">
                        <asp:Label ID="Label2" runat="server" Text="ลงชื่อ :" Width="420px"></asp:Label>
                    </td>
                    <td align="left" class="style6">
                        <uc7:cmbAutoComplete ID="cmbOfficeSignID1" runat="server" 
                            Width="300px" AutoPosBack="True" />
                    </td>
                </tr>
                <tr >
                    <td align="right" class="style6" width="450">
                        <asp:Label ID="Label3" runat="server" Text="ตำแหน่ง :" Width="420px"></asp:Label>
                    </td>
                    <td align="left" class="style6">
                        <uc2:txtBox ID="txtPositionSign1" runat="server" Width="300px" 
                            TextType="TextView" />
                    </td>
                </tr>
                </table>
                </ContentTemplate>
                            </asp:UpdatePanel>
        </td>
    </tr>
</tbody>
<tbody id="BookMinutes" runat="server" visible="false">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr>
                <td align="center"  >
                    <img src="../Images/crud.JPG" width="105px" height="114px" alt="" />
                </td>
            </tr>
            </table>
            
            <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr>
                <td  align="left" class="style6" width="120">
                    <asp:Label ID="Label1" runat="server" Text="รายงานการประชุม" ForeColor="Black" 
                        Width="100px"></asp:Label>
                        </td>
                <td align="left"  class="style6">
                <uc2:txtBox ID="txtTitle2" runat="server" Width="400px" IsNotNull="True" />
                </td>
            </tr>
                    <tr>
                <td align="left" class="style6">
                    ครั้งที่ :</td>
                <td align="left"  class="style6">
                        <uc2:txtBox ID="txtBookNo2" runat="server" IsNotNull="True" />
                </td>
            </tr>
                    <tr>
                <td align="left" class="style6">
                    เมื่อ :</td>
                <td align="left"  class="style6">
                        <uc2:txtBox ID="txtwhen2" runat="server" Width="400px" IsNotNull="True" />
                </td>
            </tr>
                    <tr>
                <td align="left" class="style6">
                    ณ :
                </td>
                <td align="left"  class="style6">
                        <uc2:txtBox ID="txtat2" runat="server" Width="400px" IsNotNull="True" />
                </td>
            </tr>
                    <tr>
                <td align="left" class="style6">
                        ผู้มาประชุม :
                    </td>
                <td align="left"  class="style6">
                        <uc2:txtBox ID="txtregis2" runat="server" Height="60" TextMode="MultiLine" 
                            Width="630" IsNotNull="False" />
                </td>
            </tr>
                    <tr>
                <td align="left" class="style6">
                        ผู้ไม่มาประชุม :</td>
                <td align="left"  class="style6">
                        <uc2:txtBox ID="txtnomeet2" runat="server" Height="60" TextMode="MultiLine" 
                            Width="630" IsNotNull="False" />
                </td>
            </tr>
                    <tr>
                <td align="left" class="style6">
                        ผู้เข้าร่วมประชุม :</td>
                <td align="left"  class="style6">
                        <uc2:txtBox ID="txtmeet2" runat="server" Height="60" TextMode="MultiLine" 
                            Width="630" IsNotNull="False" />
                </td>
            </tr>
            </table>
            
            <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr>
                <td align="left" class="style6" width="120">
                    เริ่มประชุมเวลา :</td>
                <td align="left"  class="style6" width="120">
                        <uc3:txtDate ID="txtDate12" runat="server" IsNotNull="True" />
                </td>
                <td align="left"  class="style6">
                        <uc5:txtTime ID="txtTime12" runat="server" IsNotNull="True" />
                </td>
            </tr>
            </table>
            
            <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr>
                <td align="left" class="style6" width="120" valign="top">
                    เนื้อความ :</td>
                <td align="left" class="style6">
                        <uc1:ctlRichTextBox ID="CtlDetail2" runat="server" Width="630px" 
                            Height="250" IsNotNull="False" />
                </td>
            </tr>
            </table>
            
            <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr>
                <td align="left" class="style6" width="120">
                    เลิกประชุมเวลา :</td>
                <td align="left" class="style32" width="120">
                        <uc3:txtDate ID="txtDate22" runat="server" IsNotNull="True" />
                </td>
                <td align="left" class="style6">
                        <uc5:txtTime ID="txtTime22" runat="server" IsNotNull="True" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <tr>
                <td align="center"  class="style6">
                        <asp:TextBox ID="cmbOfficeSignID2" runat="server" Width="400px" />
                        <cc1:TextBoxWatermarkExtender ID="cmbOfficeSignID2_TextBoxWatermarkExtender" TargetControlID="cmbOfficeSignID2"
                            runat="server" WatermarkText="ผู้จดรายงานการประชุม">
                        </cc1:TextBoxWatermarkExtender>
                </td>
            </tr>
           </table>
        </td>
    </tr>
</tbody>
<tbody id="BookNote" runat="server" visible="false">
<tr>
        <td>
<table width="100%" border="0" cellpadding="0" cellspacing="1" >
 <tr>
        <td align="left" class="style6" >บันทึกถึง :</td>
        <td colspan="3" align="left" class="style6" >
            <uc2:txtbox ID="txtLean3" runat="server" 
    Width="630px" IsNotNull="True" /></td>
    </tr>
    <tr >
        <td align="left" class="style6"  >กลุ่มเรื่อง : </td>
        <td colspan="3" align="left" class="style6">
            <uc4:ctlgrouptitle ID="ctlTitleGroup3" runat="server" 
    Width="520" IsNotNull="True" />
        </td>
    </tr>
    <tr >
        <td align="left" class="style6" >
            ชื่อเรื่อง : </td>
        <td colspan="3" align="left" class="style6">
            <uc2:txtbox ID="txtTitle3" runat="server"  Width="630px" 
    IsNotNull ="true"  />
        </td>
    </tr>
    <tr >
        <td align="left" valign="top" class="style6" >สาระสำคัญ :</td>
        <td colspan="3" align="left" class="style6" >
            <uc1:ctlRichTextBox ID="CtlDetail3" runat="server" Width="630px" 
    Height="250" IsNotNull="False" />
        </td>
    </tr>
    <tr >
        <td align="left" valign="top" class="style6" width="120" >วันที่บันทึก :</td>
        <td colspan="3" align="left" class="style6"  >
            <uc3:txtDate ID="txtDate13" runat="server" IsNotNull="True" />
        </td>
    </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmbOfficeSignID3" />
                                </Triggers>

                                <ContentTemplate>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" >
    <tr>
        <td align="left" class="style6" width="120" >ผู้บันทึก :</td>
        <td class="style6" align="left">
                        <uc7:cmbAutoComplete ID="cmbOfficeSignID3" runat="server" 
                            Width="300px" AutoPosBack="True" />
                    </td>
    </tr>
    <tr>
        <td align="left" class="style6" >ตำแหน่ง :</td>
        <td class="style6" align="left"><uc2:txtbox ID="txtPositionSign3" runat="server"  Width="300px"     TextType="TextView" /></td>
    </tr>
    </table>
    </ContentTemplate>
                            </asp:UpdatePanel>
    </td>
    </tr>
</tbody>
