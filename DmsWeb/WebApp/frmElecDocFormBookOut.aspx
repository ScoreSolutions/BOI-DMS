<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" MaintainScrollPositionOnPostback="true" ValidateRequest="false" AutoEventWireup="false" CodeFile="frmElecDocFormBookOut.aspx.vb" EnableEventValidation="false" Inherits="WebApp_frmDocFormBookOut"%>
<%@ MasterType  virtualPath="~/Template/ContentMasterPage.master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc7" %>
<%@ Register src="~/UserControls/ctlRichTextBox.ascx" tagname="ctlRichTextBox" tagprefix="uc1" %>
<%@ Register src="~/UserPageControls/incBookOut.ascx" tagname="incBookOut" tagprefix="uc5" %>
<%@ Register src="~/UserPageControls/incBookIn.ascx" tagname="incBookIn" tagprefix="uc9" %>
<%@ Register src="~/UserPageControls/incBookSeal.ascx" tagname="incBookSeal" tagprefix="uc8" %>
<%@ Register src="~/UserPageControls/incBookCommand.ascx" tagname="incBookCommand" tagprefix="uc10" %>
<%@ Register src="~/UserPageControls/incBookPublicRelation.ascx" tagname="incBookPublicRelation" tagprefix="uc11" %>
<%@ Register src="~/UserPageControls/incBookEvidence.ascx" tagname="incBookEvidence" tagprefix="uc12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .CssBtnPad
        {
            font: bold 20px TH SarabunPSK,Tahoma;
            height: 26px;
            background-color: #779999;
            background-image: url(../Images/fBtn.png);
            border-style: solid;
            border-color: #DDDDDD;
            border-width: 1px;
            color : #FFFFFF;
            cursor: hand;
            cursor: pointer;
            
            padding-top: 0px;
            padding-right: 4px;
            padding-bottom: 0px;
            padding-left: 4px;
        }

        .CssBtnDisable
        {
            font: bold 20px TH SarabunPSK,Tahoma;
            height: 26px;
            background-color: #999999;
            
            border-style: solid;
            border-color: #999999;
            border-width: 1px;
            color: #999999;
            cursor: hand;
            cursor: pointer;
        }

        .style12
        {
            font-family: "TH SarabunPSK", Tahoma;
            font-size: x-large;
        }
        .style13
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
            text-align: left;
        }
        
        .style33
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
        
        .style14
        {
            width: 81px;
        }
        .style15
        {
            color: #FFFFFF;
            width: 957px;
        }
        .style16
        {
            width: 59px;
        }
        .style17
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
            text-align: left;
            width: 59px;
        }
        .style19
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
            text-align: left;
            width: 106px;
        }
        .style20
        {
            width: 106px;
        }
        .style40
        {
            width: 603px;
        }
        .style41
        {
            width: 601px;
        }
        .style42
        {
            width: 643px;
        }
        .style43
        {
            width: 658px;
        }
        </style>
        
        <script language="javascript" type="text/javascript">
            function PrintReport(ReportName, vID) {
                var curtime = new Date();
                var pStr = '../Report/frmReportsPreview.aspx?ReportName=' + ReportName +
                        '&id=' + vID +
                        '&rnd=' + curtime.getMilliseconds();

                window.open(pStr, '_blank', 'height=650,left=600,location=no,menubar=no,toolbar=no,status=yes,resizable=yes,scrollbars=yes', true);
            }
        </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="1" >
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="docname" runat="server" Text="ชื่อเอกสารที่เลือก"></asp:Label>
            </td> 
        </tr>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" >
        <tr >
            <td align="right" width="17%">
                <asp:TextBox ID="status_id" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td width="33%">&nbsp;</td>
            <td align="right" width="15%">&nbsp;</td>
            <td width="35%">&nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                <asp:TextBox ID="rowid" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtRefID" runat="server" CssClass="zHidden" ></asp:TextBox>
            </td>
            <td class="Csslbl">
                &nbsp;</td>
            <td align="right" class="style33" >วันที่สร้าง : </td>
            <td>
                <uc3:txtDate ID="txtCreateDate" runat="server" DefaultCurrentDate="true" VisibleImg="false" />
                <asp:TextBox ID="txtReportName" runat="server" CssClass="zHidden"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        </table>
        
        <table width="100%" border="0" cellpadding="0" cellspacing="1" >
        <tr >
            <td colspan="4" align="center" >
                <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderWidth="1px" BorderStyle="Ridge" Width="90%" >
                    <asp:Panel ID="pnlBody" runat="server" Width="800px" >
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" >
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
        <tr>
            <td colspan="4" align="right" >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="right" >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="right" >
                <asp:Button ID="btnSave" runat="server" CssClass="CssBtnPad" Text="บันทึก" Width="80px" />
                <asp:Button ID="btnCancel" runat="server" CssClass="CssBtnPad" Text="ยกเลิก" Width="80px" />
                <asp:Button ID="btnSaveSend" runat="server" CssClass="CssBtnPad" Text="บันทึกพร้อมส่ง" Width="110px" />
                
                <asp:Button ID="btnSend" runat="server" CssClass="CssBtnPad" Text="ส่งต่อ" Width="80px" Visible="False" />
                <asp:Button ID="btnSendBack" runat="server" CssClass="CssBtnPad" Text="ส่งกลับ" Width="80px" Visible="False" />
                
                <asp:Button ID="btnApprove" runat="server" CssClass="CssBtnPad" Text="อนุมัติ" Width="110px" />
                <asp:Button ID="btnNotApprove" runat="server" CssClass="CssBtnPad" Text="ไม่อนุมัติ" Width="110px" />
                
                <asp:Button ID="btnPrint" runat="server" CssClass="CssBtnPad" Text="พิมพ์" Width="80px" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right" >
            </td>
        </tr>
    </table>
    
    <br />
                
    <asp:Panel ID="Panel8" runat="server" BorderColor="#3B5998" BorderStyle="Solid" Width="850px">
        <table id="Table2" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="100%">
            <tr>
                <td align="left" bgcolor="#3B5998" class="style15">ส่งเอกสาร</td>
                <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px" width="30" >
                    <asp:ImageButton ID="ImageButton4" runat="server" 
                    ImageUrl="~/Images/closewindows.png" />
                </td>
            </tr>
            </table>

            <table id="Table5" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" class="style16">
                        &nbsp;</td>
                    <td align="left" class="style20">
                        &nbsp;</td>
                    <td align="left" class="style7" width="220">
                        &nbsp;</td>
                    <td align="left" class="style14">
                        &nbsp;</td>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="style17">
                        &nbsp;</td>
                    <td align="left" class="style19">
                        <asp:Label ID="Label3" runat="server" Text="หน่วยงานที่รับ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style7" width="220">
                        <asp:DropDownList ID="cmbTitleOwnerTo" runat="server" Width="200" CssClass="zComboBox"  />
                        <asp:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmbTitleOwnerTo" PromptText=""
                            PromptCssClass="zHidden" PromptPosition="Bottom" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                        
                        <asp:CascadingDropDown ID="cdlOwnerOrgID" runat="server" TargetControlID="cmbTitleOwnerTo"
                            Category="OrgOwner" PromptText="เลือก" 
                            ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetOrgIDForDDL" />
                    </td>
                    <td align="left" class="style13">
                        <asp:Label ID="Label1" runat="server" Text="เจ้าหน้าที่รับ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style13">
                        <asp:DropDownList ID="cmbOfficeSignID" runat="server" Width="200"  CssClass="zComboBox" />
                        <asp:CascadingDropDown ID="cdlOwnerStaffID" runat="server" TargetControlID="cmbOfficeSignID"
                            Category="StaffOwner" PromptText="เลือก" LoadingText="กรุณารอสักครู่"
                            ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetStaffByOrgID"
                            ParentControlID="cmbTitleOwnerTo"  />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style17">
                        &nbsp;</td>
                    <td align="left" class="style19">
                        <asp:Label ID="Label4" runat="server" Text="วัฒถุประสงค์ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style7" width="220">
                        <uc7:cmbComboBox ID="cmbObjTo" runat="server" Width="200" />
                    </td>
                    <td align="left" class="style13">
                        <asp:Label ID="Label2" runat="server" Text="ข้อความ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style13">
                        <uc2:txtBox ID="txttitleTo" runat="server" Width="200" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style17">
                        &nbsp;</td>
                    <td align="left" class="style19">
                        &nbsp;</td>
                    <td align="left" class="style7" width="220">
                        &nbsp;</td>
                    <td align="left" class="style14">
                        &nbsp;</td>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
            </table>
            
            <table id="Table1" runat="server" bgcolor="#ffffff" border="0" 
            cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="170">&nbsp;</td>
                    <td align="left">
                        <asp:Button ID="btnSendDoc" runat="server" CssClass="CssBtn" Text="ส่ง" Width="80" />
                    </td>
                </tr>
                <tr>
                    <td align="left" >&nbsp;</td>
                    <td align="left" >&nbsp;</td>
                </tr>
            </table>
    </asp:Panel>   

    <asp:Panel ID="Panel4" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px" BackColor="White">
        <asp:Panel ID="Panel5" runat="server" Width="600">
            <table id="Table3" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998" class="style43">
                        <b><span lang="TH">&nbsp; ยืนยันการส่งเอกสารอิเล็กทรอนิกส์</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="style12">
                        &nbsp;&nbsp; <span class="style12">ต้องการส่งหนังสือใช่หรือไม่ ? </span>
                    </td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnYes0" runat="server" CssClass="CssBtn" Text="ใช่" 
                        Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNo0" runat="server" CssClass="CssBtn" Text="ไม่ใช่" 
                            Width="80" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   

    <asp:Panel ID="Panel9" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px" BackColor="White">
        <asp:Panel ID="Panel10" runat="server" Width="600">
            <table id="Table7" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998" class="style42">
                        <b><span lang="TH">&nbsp;</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton5" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <td align="center" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="sys_msg" runat="server" Text="Label" Font-Names="TH SarabunPSK" 
                            Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnYes3" runat="server" CssClass="CssBtn" Text="ปิด" 
                            Width="80" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
    <asp:Panel ID="Panel11" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px" BackColor="White">
        <asp:Panel ID="Panel12" runat="server" Width="600">
            <table id="Table8" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998" class="style40">
                        <b><span lang="TH">&nbsp; ยืนยันการอนุมัติ</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton6" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="style12">
                        <span>ต้องการอนุมัติหนังสือหรือไม่? </span>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnYesApprove" runat="server" CssClass="CssBtn" Text="อนุมัติ" 
                            Width="80" />
                        &nbsp;
                        <asp:Button ID="btnCloseApprove" runat="server" CssClass="CssBtn" Text="ปิด" 
                            Width="80" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
    <asp:Panel ID="Panel6" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px" BackColor="White">
        <asp:Panel ID="Panel7" runat="server" Width="600">
            <table id="Table4" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998" class="style41">
                        <b><span lang="TH">&nbsp; ยืนยันการบันทึกพร้อมส่งเอกสารอิเล็กทรอนิกส์</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="style12">
                        &nbsp;&nbsp; <span>ต้องการบันทึกพร้อมส่งหนังสือใช่หรือไม่ ? </span>
                    </td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnYes1" runat="server" CssClass="CssBtn" Text="ใช่" 
                        Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNo1" runat="server" CssClass="CssBtn" Text="ไม่ใช่" 
                            Width="80" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
    <asp:Button ID="Button61" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button62" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button63" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button64" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button65" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    
    <asp:ModalPopupExtender ID="popup1" runat="server" PopupControlID="Panel8" 
        TargetControlID="Button61" DropShadow="False" BehaviorID="popup1">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="popup2" runat="server" PopupControlID="Panel4" 
        TargetControlID="Button62" DropShadow="False" BehaviorID="popup2">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="popup3" runat="server" PopupControlID="Panel6" 
        TargetControlID="Button63" DropShadow="False" BehaviorID="popup3">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="msg_pop" runat="server" PopupControlID="Panel9" 
        TargetControlID="Button64" DropShadow="False" BehaviorID="msg_pop">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="pop_app" runat="server" PopupControlID="Panel11" 
        TargetControlID="Button65" DropShadow="False" BehaviorID="pop_app">
    </asp:ModalPopupExtender>
    
    
    <asp:Panel ID="pnlSendBack" runat="server" BorderColor="#3B5998" BorderStyle="Solid" Width="850px">
        <table id="Table6" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="100%">
            <tr>
                <td align="left" bgcolor="#3B5998" class="style15">ยืนยันการส่งกลับเพื่อแก้ไข</td>
                <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px" width="30" >
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Images/closewindows.png" />
                </td>
            </tr>
            </table>

            <table id="Table9" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" class="style16">
                        &nbsp;</td>
                    <td align="left" class="style20">
                        &nbsp;</td>
                    <td align="left" class="style7" width="220">
                        &nbsp;</td>
                    <td align="left" class="style14">
                        &nbsp;</td>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="style17">
                        &nbsp;</td>
                    <td align="left" class="style19">
                        หมายเหตุ :
                    </td>
                    <td align="left" class="style7" colspan="3" >
                        <uc2:txtBox ID="txtSendBackRemarks" runat="server" TextMode="MultiLine" Width="450" Height="50" />
                    </td>
                </tr>
                <tr>
                    <td >&nbsp;</td>
                    <td >&nbsp;</td>
                    <td align="left" colspan="4" >
                        <asp:Button ID="btnSendBackNow" runat="server" CssClass="CssBtn" Text="ส่งกลับ" Width="80" />
                    </td>
                </tr>
                <tr><td colspan="6">&nbsp;</td></tr>
            </table>
    </asp:Panel>  
    <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:ModalPopupExtender ID="popSendBack" runat="server" PopupControlID="pnlSendBack" 
        TargetControlID="Button1" DropShadow="False" >
    </asp:ModalPopupExtender>
    
    
    <asp:Panel ID="pnlNoApprove" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px" BackColor="White">
        <asp:Panel ID="Panel3" runat="server" Width="600">
            <table id="Table10" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998" class="style40">
                        <b><span lang="TH">&nbsp; ยืนยันการไม่อนุมัติเอกสารอิเล็กทรอนิกส์</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton7" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="2" cellspacing="2" border="0">
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="style12">
                        <span>ยืนยันการไม่อนุมัติเอกสารอิเล็กทรอนิกส์? </span>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnNoApprove" runat="server" CssClass="CssBtn" Text="ไม่อนุมัติ" 
                            Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNoApproveClose" runat="server" CssClass="CssBtn" Text="ปิด" 
                            Width="80" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
    <asp:Button ID="Button2" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:ModalPopupExtender ID="popNoApprove" runat="server" PopupControlID="pnlNoApprove" 
        TargetControlID="Button2" DropShadow="False" >
    </asp:ModalPopupExtender>
</asp:Content>
