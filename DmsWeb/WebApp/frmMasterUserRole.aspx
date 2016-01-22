<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterUserRole.aspx.vb" Inherits="WebApp_frmMasterUserRole" %>

<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="CssHead" colspan="2" align="left" >กลุ่มผู้ใช้งาน</td>
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
            <td align="right" class="Csslbl" width="20%">รหัสกลุ่ม :</td>
            <td width="80%" align="left" >
                <uc1:txtBox ID="txtCode" runat="server" IsNotNull="true" MaxLength="2" Width ="50" TextKey="TextDouble" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">ชื่อกลุ่ม :</td>
            <td  align="left" >
                <uc1:txtBox ID="txtName" runat="server" IsNotNull="true" Width ="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                &nbsp;
            </td>
            <td align="left">
                <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px" />
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
                        <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="role_code" HeaderText="รหัสกลุ่ม">
                        <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                        <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="role_name" HeaderText="ชื่อกลุ่ม">
                        <HeaderStyle Width="450px" />
                        <ItemStyle HorizontalAlign="Left" Width="450px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="การใช้งาน" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="15px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Bind("id") %>'
                                    ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgUser" runat="server" CausesValidation="False" CommandName="RoleUser" CommandArgument='<%# Bind("id") %>'
                                    ImageUrl="~/Images/UserGroup.gif" ToolTip="กำหนดผู้ใช้งาน" />&nbsp;
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="RoleMenu" CommandArgument='<%# Bind("id") %>'
                                    ImageUrl="~/Images/security.gif" ToolTip="กำหนดสิทธิ์การใช้งาน" Width="16" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table width="100%" border="1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#edeff4" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

