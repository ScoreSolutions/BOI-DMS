<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master"
    AutoEventWireup="false" CodeFile="frmElecDocUserRegisList.aspx.vb" Inherits="WebApp_frmElecDocUserRegisList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc4" %>
<%@ Register Src="../UserControls/PageControl.ascx" TagName="pagecontrol" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<script type="text/javascript">
    function SelectAll(CheckBoxControl) {
        if (CheckBoxControl.checked == true) {
            var i;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox') &&
(document.forms[0].elements[i].name.indexOf('GridView1') > -1)) {
                    if (document.forms[0].elements[i].disabled) {
                        document.forms[0].elements[i].checked = false;
                    }
                    else {
                        document.forms[0].elements[i].checked = true;
                    }
                }
            }
        }
        else {
            var i;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox') &&
(document.forms[0].elements[i].name.indexOf('GridView1') > -1)) {
                    document.forms[0].elements[i].checked = false;
                }
            }
        }
    }
</script>

    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            color: #000000;
            text-decoration: none;
            vertical-align: top;
            font-style: normal;
            font-variant: normal;
            font-size: 20px;
            line-height: normal;
            font-family: "TH SarabunPSK", Arial, "Courier New", Courier, monospace;
            width: 600px;
            padding: 1px;
        }
        .style4
        {
            color: #000000;
            text-decoration: none;
            vertical-align: top;
            font-style: normal;
            font-variant: normal;
            font-size: 20px;
            line-height: normal;
            font-family: "TH SarabunPSK", Arial, "Courier New", Courier, monospace;
        }
        .style5
        {
            width: 18%;
            color: #FFFFFF;
        }
        .style10
        {
            color: #000000;
            text-decoration: none;
            vertical-align: top;
            font-style: normal;
            font-variant: normal;
            font-size: 20px;
            line-height: normal;
            font-family: "TH SarabunPSK", Arial, "Courier New", Courier, monospace;
            width: 52px;
            padding: 1px;
        }
        .style11
        {
            width: 56px;
        }
        .style12
        {
            color: #000000;
            text-decoration: none;
            vertical-align: top;
            font-style: normal;
            font-variant: normal;
            font-size: 20px;
            line-height: normal;
            font-family: "TH SarabunPSK", Arial, "Courier New", Courier, monospace;
            padding: 1px;
            width: 250px;
        }
        .style14
        {
            color: #000000;
            text-decoration: none;
            vertical-align: top;
            font-style: normal;
            font-variant: normal;
            font-size: 20px;
            line-height: normal;
            font-family: "TH SarabunPSK", Arial, "Courier New", Courier, monospace;
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style2">
        <tr>
            <td class="CssHead" colspan="2" align="left">
                &nbsp;&nbsp;
                ค้นหาเอกสารอิเล็กทรอนิกส์ที่รอลงทะเบียน
            </td>
        </tr>
        <tr>
            <td align="right" class="style12">
                วันที่สร้าง :
            </td>
            <td align="left" class="style3">
                <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100">
                <uc1:txtDate ID="txtDate1" runat="server" />
                        </td>
                        <td align="center" width="50">
                            ถึง</td>
                        <td>
                <uc1:txtDate ID="txtDate2" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" class="style12">
                ชื่อเรื่อง :
            </td>
            <td align="left">
                <uc2:txtBox ID="txttitle" runat="server" Width="400" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style12">
                &nbsp;
            </td>
            <td align="left" class="Csslbl" >
                <asp:CheckBox id="chkNoRead" runat="server" Text="แสดงเฉพาะเรื่องที่ยังไม่ได้เปิดอ่าน" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style12">
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="80px" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style12">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%" colspan="2">
                <uc3:pagecontrol ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl" width="15%" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    Width="100%" AllowPaging="True">
                    <PagerSettings Visible="False" />
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField DataField="rownum" HeaderText="ลำดับ" ItemStyle-Width="5%">
                            <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="doc_create_date" HeaderText="วันที่สร้าง" ItemStyle-Width="10%"
                            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="doc_title" HeaderText="ชื่อเรื่อง" >
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="process" HeaderText="สถานะ" ItemStyle-Width="25%">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btnRegister" runat="server" Text="ลงทะเบียน" CssClass="CssBtn" CommandArgument='<%# Bind("rowid") %>' CommandName="Register" Width="80px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="style12">
                &nbsp;
            </td>
            <td>
                &nbsp;
                
    
                
    <asp:Panel ID="Panel4" runat="server" BorderColor="#3B5998" BorderStyle="Solid" Width="850px">
        <table id="Table2" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="100%">
            <tr>
            <td align="left" bgcolor="#3B5998" class="style5">
                        <b><span lang="TH">&nbsp; ส่งเอกสาร</span></b>
            </td>
            <td bgcolor="#3B5998">
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px" width="30" >
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
            </tr>
            </table>
            
            <table id="Table3" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
                cellspacing="0" width="100%">
                <tr>
                    <td align="left" class="style10">
                        &nbsp;</td>
                    <td align="left" class="style14">
                        &nbsp;</td>
                    <td align="left" class="style4" width="220">
                        &nbsp;</td>
                    <td align="left" class="style4" width="120">
                        &nbsp;</td>
                    <td align="left" class="style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="style10">
                        &nbsp;</td>
                    <td align="left" class="style14">
                        <asp:Label ID="Label3" runat="server" Text="หน่วยงานที่รับ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style4" width="220">
                        <uc3:cmbComboBox ID="cmbTitleOwnerTo" runat="server" Width="200" 
                            AutoPosBack="True" />
                    </td>
                    <td align="left" class="style4" width="120">
                        <asp:Label ID="Label1" runat="server" Text="เจ้าหน้าที่รับ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style4">
                        <uc3:cmbComboBox ID="cmbOfficeSignID" runat="server" Width="200" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style10">
                        &nbsp;</td>
                    <td align="left" class="style14">
                        <asp:Label ID="Label4" runat="server" Text="วัตถุประสงค์ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style4" width="220">
                        <uc3:cmbComboBox ID="cmbObjTo" runat="server" Width="200" />
                    </td>
                    <td align="left" class="style4" width="120">
                        <asp:Label ID="Label2" runat="server" Text="ข้อความ :" Width="100px"></asp:Label>
                    </td>
                    <td align="left" class="style4">
                        <uc2:txtBox ID="txttitleTo" runat="server" Width="200" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style10">
                        &nbsp;</td>
                    <td align="left" class="style14">
                        &nbsp;</td>
                    <td align="left" class="style4" width="220">
                        &nbsp;</td>
                    <td align="left" class="style4" width="120">
                        &nbsp;</td>
                    <td align="left" class="style4">
                        &nbsp;</td>
                </tr>
            </table>
            
            <table id="Table1" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="100%">
            <tr>
            <td class="style11">
                &nbsp;</td>
                <td align="left">
                    <asp:Button ID="btnYes0" runat="server" CssClass="CssBtn" Text="เพิ่ม" 
                        Width="80" />
                    &nbsp;
                    <asp:Button ID="btnNo0" runat="server" CssClass="CssBtn" Text="ลบ" Width="80" />
                    &nbsp; <asp:Button ID="btnNo1" runat="server" CssClass="CssBtn" Text="ส่ง" 
                        Width="80" />
                </td>
            </tr>
            </table>
            <table id="Table4" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="100%">
            <tr>
            <td height="26" class="style4" align="center">
                
                <asp:Label ID="msg_send" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                
            </td>
            </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridviewSendList" runat="server" AutoGenerateColumns="False" 
                            CssClass="mGrid" DataKeyNames="id" GridLines="Vertical" PageSize="20" 
                            Width="100%">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk_id" runat="server" />
                                        <asp:Label ID="txt_id" runat="server" Text='<%# Bind("ID") %>' Visible="False"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="16px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ผู้อนุมัติ">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk_ap" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="16px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="send_Owner_Name" HeaderText="หน่วยงานรับ" 
                                    SortExpression="send_Owner_Name">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="send_to_name" HeaderText="เจ้าหน้าที่รับ" 
                                    SortExpression="send_to_name">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="send_obj_name" HeaderText="วัตถุประสงค์" 
                                    SortExpression="send_obj_name">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table border="1" width="100%">
                                    <tr>
                                        <td align="center">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td bgcolor="#3B5998" style="color: #FFFFFF; font-weight: bold;">
                                                        หน่วยงานที่รับ</td>
                                                    <td bgcolor="#3B5998" style="color: #FFFFFF; font-weight: bold;">
                                                        เจ้าหน้าที่รับ</td>
                                                    <td bgcolor="#3B5998" style="color: #FFFFFF; font-weight: bold;">
                                                        วัตถุประสงค์</td>
                                                </tr>
                                            </table>
                                            <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerSettings Visible="False" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
    </asp:Panel>   
         <asp:Panel ID="Panel9" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px">
        <asp:Panel ID="Panel10" runat="server" Width="600">
            <table id="Table7" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        <b><span lang="TH">&nbsp;</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton5" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="sys_msg" runat="server" Text="Label" Font-Names="TH SarabunPSK" 
                            Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnYes3" runat="server" CssClass="CssBtn" Text="ปิด" 
                            Width="80" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
                   <asp:Panel ID="Panel11" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px">
        <asp:Panel ID="Panel12" runat="server" Width="600">
            <table id="Table8" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        <b><span lang="TH">&nbsp; ยืนยันการอนุมัติ</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton6" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp; <span class="style12">ต้องการอนุมัติหนังสือหรือไม่? </span>
                    </td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnYes4" runat="server" CssClass="CssBtn" Text="อนุมัติ" 
                        Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNo4" runat="server" CssClass="CssBtn" Text="ไม่อนุมัติ" 
                            Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNo5" runat="server" CssClass="CssBtn" Text="ปิด" 
                            Width="80" />
                    </td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
                <br />
                  
            </td>
        </tr>
    </table>
    
    <asp:Button ID="Button6" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button3" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button65" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    
    <asp:ModalPopupExtender ID="popup1" runat="server" PopupControlID="Panel4" 
        TargetControlID="Button6" DropShadow="False" BehaviorID="popup1">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="msg_pop" runat="server" PopupControlID="Panel9" 
        TargetControlID="Button3" DropShadow="False" BehaviorID="msg_pop">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="pop_app" runat="server" PopupControlID="Panel11" 
        TargetControlID="Button65" DropShadow="False" BehaviorID="pop_app">
    </asp:ModalPopupExtender>
</asp:Content>
