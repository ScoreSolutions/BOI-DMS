<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmMasterPermission.aspx.vb" Inherits="WebApp_frmMasterPermission" %>

<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="CssHead" colspan="2" align="left" >กำหนดสิทธิ์การใช้งาน :&nbsp;
                <asp:Label ID="lblText" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="CssHead">
                &nbsp;
            </td>
            <td>
                &nbsp;
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
                <asp:Label ID="lblIdModule" runat="server"></asp:Label>
                <asp:Label ID="lblSelectModule" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" width="45%" class="Csslbl">เมนูที่ไม่มีสิทธิ์&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td align="left" valign="top" width="45%" class="Csslbl">เมนูที่มีสิทธิ์</td>
        </tr>
        <tr>
            <td width="45%" valign="top">
                <div style="overflow:scroll;height:400px;overflow-x:hidden;"  >
                    <asp:GridView ID="GridView1" runat="server" 
                        AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%"  >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cbAll" runat="server" OnCheckedChanged="cbAll_OnCheckedChanged" AutoPostBack="true" />
                                </HeaderTemplate>
                                <ItemStyle Width="5px" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="module_name" HeaderText="Module" >
                                <HeaderStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="menu_name" HeaderText="Menu" >
                                <HeaderStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id"  >
                                <HeaderStyle  CssClass="zHidden" />
                                <ItemStyle  CssClass="zHidden" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#edeff4" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </td>
            <td align="center">
                <asp:Button ID="btnSelect" runat="server" CssClass="CssBtn" Text="&gt;&gt;" Width="30px" />
                <br /><br /><br />
                <asp:Button ID="btnNoSelect" runat="server" CssClass="CssBtn" Text="&lt;&lt;" Width="30px" />
            </td>
            <td valign="top" width="45%">
                <div style="overflow:scroll;height:400px;overflow-x:hidden;"  >
                    <asp:GridView ID="GridView2" runat="server" 
                        AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cbAll" runat="server" OnCheckedChanged="cbAll_OnCheckedChanged" AutoPostBack="true" />
                                </HeaderTemplate>
                                <ItemStyle Width="5px" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="module_name" HeaderText="Module" >
                                <HeaderStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="menu_name" HeaderText="Menu" >
                                <HeaderStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id"  >
                                <HeaderStyle  CssClass="zHidden" />
                                <ItemStyle  CssClass="zHidden" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#edeff4" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
                
            </td>
        </tr>
    </table>
</asp:Content>
