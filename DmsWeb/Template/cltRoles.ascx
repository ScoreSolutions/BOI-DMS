<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cltRoles.ascx.vb" Inherits="Template_cltRoles" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="~/UserControls/PageControl.ascx" tagname="pagecontrol" tagprefix="uc1" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtbox" tagprefix="uc1" %>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/roles.gif" ImageAlign="AbsMiddle" />
&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Label ID="lblCaption" runat="server" CssClass="CssHead" Text="กลุ่มผู้ใช้งาน"></asp:Label>
<asp:Panel ID="Panel1" runat="server" Width="600">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        กลุ่มผู้ใช้งาน</td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;
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
            <td class="Csslbl">
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                รหัสกลุ่ม :
            </td>
            <td width="80%" class="Csslbl">
                <uc1:txtBox ID="txtCode" runat="server" IsNotNull="true" MaxLength="2" Width ="50" TextKey="TextDouble" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                ชื่อกลุ่ม :
            </td>
            <td class="Csslbl">
                <uc1:txtBox ID="txtName" runat="server" IsNotNull="true" Width ="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                &nbsp;
            </td>
            <td class="Csslbl">
                <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="Csslbl">
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
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
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
                        <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
