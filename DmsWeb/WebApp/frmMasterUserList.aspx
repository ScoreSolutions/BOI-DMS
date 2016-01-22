<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterUserList.aspx.vb" Inherits="WebApp_frmMMasterUserGroup" %>

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
        
        .style7
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
            text-align : "center";
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style2">
        <tr>
            <td class="CssHead">
                จัดการผู้ใช้งาน</td>
        </tr>
        <tr>
            <td align="center" class="style3">
                &nbsp;รหัสผู้ใช้งาน :<asp:TextBox ID="txtUserID" runat="server" 
                    CssClass="style3"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                ชื่อผู้ใช้งาน :
                <asp:TextBox ID="TxtUserName" runat="server" Width="276px" CssClass="style3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="ค้นหา" 
                    Width="120px" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="CssBtn" 
                    Text="เพิ่มผู้ใช้งาน" Width="120px" />
            &nbsp;<asp:Button ID="Button7" runat="server" CssClass="CssBtn" 
                    Text="ลบผู้ใช้งาน" Width="120px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                <uc3:pagecontrol ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl" width="15%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    Width="100%" AllowPaging="True">
                    <PagerSettings Visible="False" />
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_id" runat="server" />
                                <asp:Label ID="txt_id" runat="server" Text='<%# Bind("login_username") %>' 
                                    Visible="False"></asp:Label>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chk_all" runat="server" onclick="SelectAll(this)" />
                            </HeaderTemplate>
                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="rownum" HeaderText="ลำดับ" ItemStyle-Width="5%">
                            <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="url_field" DataTextField="login_username" 
                            HeaderText="รหัสผู้ใช้งาน" SortExpression="login_username" 
                            Target="_parent">
                        <ItemStyle Font-Bold="True" Font-Underline="True" ForeColor="#0000CC" 
                            Width="100px" HorizontalAlign="Left" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="login_username" HeaderText="รหัสผู้ใช้งาน" 
                            SortExpression="login_username" Visible="False">
                        <ItemStyle Width="80px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="user_full_name" HeaderText="ชื่อผู้ใช้งาน" 
                            ItemStyle-Width="10%" HtmlEncode="False" SortExpression="user_full_name">
                            <ItemStyle Width="300px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="organization_name" HeaderText="หน่วยงาน" 
                            ItemStyle-Width="20%" SortExpression="organization_name">
                        <ItemStyle Width="300px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderImageUrl="~/Images/boi_icon/edit.png" Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="edit_link" runat="server" 
                                    ImageUrl='<%# "~/Images/boi_icon/edit.png" %>' 
                                    NavigateUrl='<%# bind("url_field") %>' Target="_parent">[edit_link]</asp:HyperLink>
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
            <td>
                &nbsp;
                
    <asp:Button ID="Button6" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button8" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                
    <asp:Panel ID="Panel4" runat="server" BorderColor="#3B5998" BorderStyle="Solid" 
        Width="600px">
        <asp:Panel ID="Panel5" runat="server" Width="600">
            <table id="Table3" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        <b><span lang="TH">&nbsp; ยืนยันการลบกลุ่มผู้ใช้</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
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
                    <td align="center" class="style7" colspan="2">
                        ต้องการลบผู้ใช้ใช่หรือไม่ ? </td>
                </tr>
                <tr>
                    <td align="center" class="style7" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="style7" colspan="2">
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
                    <td>
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
                        <b><span lang="TH">&nbsp; คำเตือน</span></b></td>
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
                    <td align="center" class="style7" colspan="2">
                        ยังไม่ได้เลือกรายการที่ต้องการลบ</td>
                </tr>
                <tr>
                    <td align="center" class="style7" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="style7" colspan="2">
                        <asp:Button ID="btnYes1" runat="server" CssClass="CssBtn" Text="ตกลง" 
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
    </table>
    
    
    <asp:ModalPopupExtender ID="popup1" runat="server" PopupControlID="Panel4" 
        TargetControlID="Button6" DropShadow="False" BehaviorID="popup1">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="popup2" runat="server" PopupControlID="Panel6" 
        TargetControlID="Button8" DropShadow="False" BehaviorID="popup2">
    </asp:ModalPopupExtender>
</asp:Content>
