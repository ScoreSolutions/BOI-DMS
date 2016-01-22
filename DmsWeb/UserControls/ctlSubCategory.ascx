<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlSubCategory.ascx.vb"
    Inherits="UserControls_ctlSubCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="PageControl.ascx" TagName="pagecontrol" TagPrefix="uc1" %>
<%@ Register Src="txtBox.ascx" TagName="txtbox" TagPrefix="uc1" %>
<%@ Register Src="cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc2" %>
<style type="text/css">
    .style1
    {
        width: 26%;
    }
</style>
<uc1:txtbox ID="txtBox1" runat="server" AutoPosBack="True" Width="50" />
<asp:ImageButton ID="ImageSearch" runat="server" ImageUrl="~/Images/search.png" ImageAlign="AbsMiddle" />
<asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
<uc1:txtbox ID="txtBox2" runat="server" IsNotNull="false" TextType="TextView" Width="300px" />
&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/office_folders.png"
    ImageAlign="AbsMiddle" />
<asp:Label ID="lblCaption" runat="server" CssClass="CssHead" Text="ประเภทย่อยหนังสือ"></asp:Label>
<asp:Panel ID="Panel1" runat="server" Width="600">
    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="style1">
                ประเภทย่อยหนังสือ
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td align="right" class="Csslbl">
                ค้นหา :
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="Csslbl">
                <uc1:txtbox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                ประเภทหนังสือ :
            </td>
            <td width="80%" class="Csslbl">
                <uc2:cmbComboBox ID="cmbCategory" runat="server" Width="305" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                รหัสประเภทย่อย :&nbsp;
            </td>
            <td width="80%" class="Csslbl">
                <uc1:txtbox ID="txtCode" runat="server" IsNotNull="true" MaxLength="4" Width="50"
                    TextKey="TextDouble" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                ชื่อประเภทย่อย :
            </td>
            <td class="Csslbl">
                <uc1:txtbox ID="txtName" runat="server" IsNotNull="true" Width="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                &nbsp;
            </td>
            <td class="Csslbl">
                <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="Csslbl">
                <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px"
                    TabIndex="6" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:pagecontrol ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="SubCategory_code" HeaderText="รหัส" SortExpression="SubCategory_code">
                            <ItemStyle Width="60px" HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Underline="True"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="category_name" HeaderText="ประเภท" SortExpression="category_name">
                            <HeaderStyle Width="200px" Font-Underline="True" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="subcategory_name" HeaderText="ประเภทย่อย" SortExpression="subcategory_name"
                            ShowHeader="False">
                            <HeaderStyle Width="250px" Font-Underline="True" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="การใช้งาน" ItemStyle-HorizontalAlign="Center"
                            SortExpression="active">
                            <HeaderStyle Width="100px" Font-Underline="True" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="15px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" Visible="false">
                            <ItemStyle Width="15px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Images/Delete.png" Text="Delete" ToolTip="ลบ" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="15px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandName="Select"
                                    ImageUrl="~/Images/bt-select-active.gif" Text="Selete" ToolTip="เลือก" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
                    
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Visible="False" />
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>
