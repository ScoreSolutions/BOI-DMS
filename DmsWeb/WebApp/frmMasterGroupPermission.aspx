<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master"  AutoEventWireup="false" CodeFile="frmMasterGroupPermission.aspx.vb" Inherits="WebApp_frmMMasterUserGroupPermission" %>

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
            padding: 1px;
        }
        .style4
    {
        width: 202px;
    }
    .style5
    {
        width: 142px;
        text-align: right;
    }
        .style6
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
        width: 202px;
    }
    
    .style_center
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
        text-align: center;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style2">
        <tr>
            <td class="CssHead">
                จัดการกลุ่มผู้ใช้งาน</td>
        </tr>
        <tr>
            <td align="center" class="style3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="4" cellspacing="4" class="style3" style="width:100%;">
                    <tr>
                        <td align="right" class="style4">
                            &nbsp;</td>
                        <td align="right" class="style5">
                            รหัสกลุ่มผู้ใช้งาน :</td>
                        <td>
                            <asp:TextBox ID="txtgroupID" runat="server" CssClass="style3"></asp:TextBox>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtgroupID" Display="Dynamic" ErrorMessage="*" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style5">
                            ชื่อกลุ่มผู้ใช้งาน :
                        </td>
                        <td>
                <asp:TextBox ID="TxtGroupName" runat="server" Width="445px" CssClass="style3"></asp:TextBox>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtGroupName" Display="Dynamic" ErrorMessage="*" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            &nbsp;</td>
                        <td align="right">
                            สถานะ :</td>
                        <td class="style3">
                            <asp:DropDownList ID="txtActive" runat="server" CssClass="style3">
                                <asp:ListItem Value="Y">ใช้งาน</asp:ListItem>
                                <asp:ListItem Value="N">ไม่ใช้งาน</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="rowid" runat="server" CssClass="style3" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style5">
                            เลือกกลุ่มของเมนู :</td>
                        <td>
                            <asp:DropDownList ID="MenuModule" runat="server" CssClass="style3" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    Width="450px">
                    <PagerSettings Visible="False" />
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_id" runat="server" Checked='<%# bind("active") %>' />
                                <asp:Label ID="txt_id" runat="server" Text='<%# Bind("rowid") %>' 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="txt_menu_code" runat="server" Text='<%# Bind("menu_code") %>' 
                                    Visible="False"></asp:Label>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chk_all" runat="server" onclick="SelectAll(this)" />
                            </HeaderTemplate>
                            <ItemStyle Width="16px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderImageUrl="~/Images/pencil_add.png" Visible="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_a" runat="server" Checked='<%# bind("active_a") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="16px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderImageUrl="~/Images/boi_icon/edit.png" Visible="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_e" runat="server" Checked='<%# bind("active_e") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="16px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderImageUrl="~/Images/cross.jpg" Visible="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_d" runat="server" Checked='<%# bind("active_d") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="16px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="menu_name" HeaderText="เมนู" ItemStyle-Width="5%" 
                            HtmlEncode="False" SortExpression="menu_name">
                            <ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="บันทึก" 
                    Width="120px" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="CssBtn" 
                    Text="ยกเลิก" Width="120px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">

    <asp:Panel ID="Panel8" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px">
        <asp:Panel ID="Panel9" runat="server" Width="600">
            <table id="Table5" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        &nbsp;</td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton4" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="style_center" colspan="2">
                        <asp:Label ID="msg_err" runat="server" Text="message" Width="550px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="style_center" colspan="2">
                        <asp:Button ID="btnYes2" runat="server" CssClass="CssBtn" Text="ตกลง" 
                            Width="80" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   

    <asp:Panel ID="Panel6" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px">
        <asp:Panel ID="Panel7" runat="server" Width="600">
            <table id="Table4" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        &nbsp;</td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="style_center">
                        บันทึกเสร็จเรียบร้อยแล้ว ต้องการกลับไปแก้ไขหรือไม่</td>
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
                    <td align="center" class="style_center" colspan="2">
                        <asp:Button ID="btnYes1" runat="server" CssClass="CssBtn" Text="ต้องการ" 
                        Width="80" />
                        &nbsp;
                        <asp:Button ID="btnYes3" runat="server" CssClass="CssBtn" Text="ไม่ต้องการ" 
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

            </td>
        </tr>
        <tr>
            <td align="center" class="Csslbl">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
                

                
            </td>
        </tr>
    </table>
    
    <asp:Button ID="Button6" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button7" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    
    <asp:ModalPopupExtender ID="popup1" runat="server" PopupControlID="Panel6" 
        TargetControlID="Button6" DropShadow="False" BehaviorID="popup1">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="popup2" runat="server" PopupControlID="Panel8" 
        TargetControlID="Button7" DropShadow="False" BehaviorID="popup2">
    </asp:ModalPopupExtender>
</asp:Content>
