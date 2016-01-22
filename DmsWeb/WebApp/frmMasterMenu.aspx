<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmMasterMenu.aspx.vb" Inherits="WebApp_frmMasterMenu" %>

<%@ Register Src="../UserControls/PageControl.ascx" TagName="pagecontrol" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtbox" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td class="CssHead">
                        เมนูการใช้งาน
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
                        <uc1:txtbox ID="txtID" runat="server" Text="0" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" width="20%">
                        รหัสเมนู :
                    </td>
                    <td width="80%">
                        <uc1:txtbox ID="txtCode" runat="server" IsNotNull="true" MaxLength="4" Width="50"
                            TextKey="TextDouble" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" width="20%">
                        ลำดับที่ : 
                    </td>
                    <td width="80%">
                        <uc1:txtbox ID="txtOrder" runat="server" IsNotNull="true" MaxLength="2" 
                            TextKey="TextDouble" Width="50" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        โมดูล :
                    </td>
                    <td>
                        <uc2:cmbComboBox ID="cmbModule" runat="server" Width="300"  />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        ชื่อเมนู :
                    </td>
                    <td>
                        <uc1:txtbox ID="txtName" runat="server" IsNotNull="true" Width="300" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        รายละเอียด :
                    </td>
                    <td>
                        <uc1:txtbox ID="txtDescription" runat="server" IsNotNull="true" Width="500" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        คำอธิบาย :
                    </td>
                    <td>
                        <uc1:txtbox ID="txtTooltip" runat="server" IsNotNull="true" Width="500" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        Url :
                    </td>
                    <td>
                        <uc1:txtbox ID="txtUrl" runat="server" IsNotNull="true" Width="500" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        ไอคอน :
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="500px" CssClass="CssFileUpload" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                    </td>
                    <td>
                        <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <uc3:pagecontrol ID="pcTop" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="menu_code" HeaderText="รหัส" SortExpression="menu_code">
                                    <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                 <asp:BoundField DataField="module_name" HeaderText="โมดูล">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_name" HeaderText="เมนู">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_desc" HeaderText="รายละเอียด">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_toolstip" HeaderText="คำอธิบาย">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="menu_url" HeaderText="Url">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="order_seq" HeaderText="ลำดับ">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="ไอคอน" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#ConfigurationManager.AppSettings("UploadURL").ToString() & Eval("menu_icon").ToString() %>' />
                                    </ItemTemplate>
                                    
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="active" HeaderText="การใช้งาน" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
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
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
