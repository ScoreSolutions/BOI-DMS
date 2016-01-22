<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmMasterSubCategory.aspx.vb" Inherits="WebApp_frmMasterSubCategory" %>

<%@ Register Src="../UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="CssHead" align="left" >
                ประเภทย่อยหนังสือ
            </td>
            <td align="right" class="Csslbl">
                ค้นหา :
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                ประเภทหนังสือ :
            </td>
            <td width="80%"  align="left" >
                <uc2:cmbComboBox ID="cmbCategory" runat="server" Width="305" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                รหัสประเภทย่อย :&nbsp;
            </td>
            <td width="80%"  align="left" >
                <uc1:txtBox ID="txtCode" runat="server" IsNotNull="true" MaxLength="4" Width="50"
                    TextKey="TextDouble" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                ชื่อประเภทย่อย :
            </td>
            <td  align="left" >
                <uc1:txtBox ID="txtName" runat="server" IsNotNull="true" Width="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                &nbsp;
            </td>
            <td  align="left" >
                <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td  align="left" >
                <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px"
                    TabIndex="6" />
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
                        <asp:BoundField DataField="id" HeaderText="id" >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SubCategory_code" HeaderText="รหัส">
                            <ItemStyle Width="60px" HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="category_name" HeaderText="ประเภท">
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="subcategory_name" HeaderText="ประเภทย่อย">
                            <HeaderStyle Width="250px" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="การใช้งาน" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="15px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" >
                            <ItemStyle Width="15px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="~/Images/Delete.png" Text="Delete" OnClientClick="return confirm('ยืนยันการลบข้อมูล?')" ToolTip="ลบ" />
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
</asp:Content>
