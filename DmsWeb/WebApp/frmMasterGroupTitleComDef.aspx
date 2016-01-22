<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmMasterGroupTitleComDef.aspx.vb" Inherits="WebApp_frmMasterGroupTitleComDef" %>

<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>    
    
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<style type="text/css">
    .style6
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
        text-align: right;
    }
    .style8
    {
        color: #3b5998;
        text-decoration: none;
        vertical-align: middle;
        font-style: normal;
        font-variant: normal;
        font-weight: bold;
        font-size: 25px;
        line-height: normal;
        font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
        text-align: left;
        width: 24%;
    }
    .style9
    {
        width: 24%;
    }
    .style10
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
        width: 24%;
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
        text-align: center;
        width: 24%;
    }
</style>

    <table style="width: 100%">
        <tr>
            <td class="style8">
                กลุ่มเรื่องสำหรับบริษัท</td>
            <td align="right" class="style7">
                <uc1:txtBox ID="group_title_id" runat="server" Visible="False" Text="0" />
                <uc1:txtBox ID="txtID" runat="server" Visible="False" Text="0" />
            &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style10">
                กลุ่มเรื่อง :</td>
            <td width="80%" class="style6">
                <uc1:txtBox ID="group_title_code" runat="server" Enabled="False" Width="100" />
                <asp:Label ID="Label11" runat="server" Width="16px"></asp:Label>
                <uc1:txtBox ID="group_title_name" runat="server" Enabled="False" Width="400" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style10">
                รหัสบริษัท :</td>
            <td class="style6">
                <uc1:txtBox ID="company_id" runat="server" IsNotNull="False" 
                    Width ="100" Enabled="False" />
                <asp:ImageButton ID="ImageButton12" runat="server" 
                    ImageUrl="~/Images/searchx.png" />
                <uc1:txtBox ID="company_name" runat="server" IsNotNull="True" 
                    Width ="400" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style10">
                เจ้าหน้าที่ :</td>
            <td class="style6">
                <uc1:txtBox ID="officer_sign_name" runat="server" IsNotNull="False" 
                    Width ="400" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style10">
                หมายเหตุ :</td>
            <td class="style6">
                <uc1:txtBox ID="remarks" runat="server" IsNotNull="False" 
                    Width ="400" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style11">
                &nbsp;
            </td>
            <td class="style6">
                <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;
            </td>
            <td class="style6">
                <asp:Button ID="btnSave0" runat="server" Text="เพิ่ม" CssClass="CssBtn" 
                    Width="60px" />
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px" />
                <asp:Button ID="btnCancel0" runat="server" Text="ย้อนกลับ" CssClass="CssBtn" 
                    Width="60px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:PageControl ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="20px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.png" 
                            ShowDeleteButton="True">
                        <ItemStyle Width="20px" />
                        </asp:CommandField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# bind("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False">
                        <ItemStyle Width="0px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="company_id" HeaderText="รหัส">
                            <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="thainame" HeaderText="ชื่อบริษัท" >
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="officer_sign_name" HeaderText="เจ้าหน้าที่">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="remarks" HeaderText="หมายเหตุ">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="ใช้งาน">
                        <ItemStyle Width="50px" />
                        </asp:BoundField>
                    </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    <EmptyDataTemplate>
                        <table width="100%" border="1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Visible="False" />

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                
      
    
            </td>
        </tr>
    </table>
    

    <asp:Panel ID="Panel6" runat="server" BorderColor="#3B5998" BorderStyle="Solid" Width="600px">
        <asp:Panel ID="Panel7" runat="server" Width="600">
            <table id="Table4" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        <b><span lang="TH">&nbsp; ยืนยันการลบ</span></b></td>
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
                    <td align="center" colspan="2" class="Csslbl">
                        <span>ต้องการลบ ใช่หรือไม่ ? </span></td>
                </tr>
                <tr>
                    <td align="center" class="style6" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnYes1" runat="server" CssClass="CssBtn" Text="ใช่" 
                            Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNo1" runat="server" CssClass="CssBtn" Text="ไม่ใช่" 
                            Width="80" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
    <asp:Panel ID="Panel9" runat="server" BorderColor="#3B5998" BorderStyle="Solid" Width="600px">
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
                    <td align="center" colspan="2" class="Csslbl">
                        <asp:Label ID="sys_msg" runat="server" Text="Label"></asp:Label>
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
    
    <asp:Panel ID="Panel15" runat="server" BorderColor="#3B5998" 
        BorderStyle="Solid" Width="500px" BorderWidth="8px">
        <asp:Panel ID="Panel16" runat="server" Width="100%">
            <table ID="Table10" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
                cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="100%">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton11" runat="server" 
                            ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="style6">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <uc1:txtBox ID="company_find" runat="server" Height="24" IsNotNull="False" 
                            Width="300" />
                        <asp:Button ID="btnYes14" runat="server" CssClass="CssBtn" Text="ค้นหา" 
                            Width="80" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style6">
                        <uc1:PageControl ID="pcTop0" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl">
                        <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt" 
                            AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="id" 
                            GridLines="Vertical" PagerStyle-CssClass="pgr" PageSize="5" Width="100%">
                            <PagerSettings Visible="False" />
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="รหัส">
                                    <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:ButtonField CommandName="comname" DataTextField="thainame" 
                                    HeaderText="ชื่อบริษัท" Text="Button">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:ButtonField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="comid" runat="server" Text='<%# bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="prg" />
                            <EmptyDataTemplate>
                                <table border="1" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel> 
    
    <asp:Button ID="Button61" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button62" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button63" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    
    <asp:ModalPopupExtender ID="popup1" runat="server" PopupControlID="Panel6" 
        TargetControlID="Button61" DropShadow="False" BehaviorID="popup1">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="popup2" runat="server" PopupControlID="Panel9" 
        TargetControlID="Button62" DropShadow="False" BehaviorID="popup2">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="popup3" runat="server" PopupControlID="Panel15" 
        TargetControlID="Button63" DropShadow="False" BehaviorID="popup3">
    </asp:ModalPopupExtender>
</asp:Content>
