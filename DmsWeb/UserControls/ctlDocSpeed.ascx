<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDocSpeed.ascx.vb"
    Inherits="UserControls_ctlDocSpeed" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="PageControl.ascx" TagName="pagecontrol" TagPrefix="uc1" %>
<%@ Register Src="txtBox.ascx" TagName="txtbox" TagPrefix="uc1" %>
<uc1:txtbox ID="txtBox1" runat="server" AutoPosBack="True" Width="50" />
<asp:ImageButton ID="ImageSearch" runat="server" ImageUrl="~/Images/search.png" ImageAlign="AbsMiddle" />
<asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
<uc1:txtbox ID="txtBox2" runat="server" IsNotNull="false" TextType="TextView" Width="300px" />
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/old_clock.png"
    ImageAlign="AbsMiddle" />&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Label ID="lblCaption" runat="server" CssClass="CssHead" Text="ระดับชั้นความเร็ว"></asp:Label>
<asp:Panel ID="Panel1" runat="server" Width="600">
    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998">
                ระดับชั้นความเร็ว
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td class="CssHead">
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
            <td>
                <uc1:txtbox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                รหัสชั้นความเร็ว :
            </td>
            <td width="80%" class="Csslbl">
                <uc1:txtbox ID="txtCode" runat="server" IsNotNull="true" MaxLength="2" Width="50"
                    TextKey="TextDouble" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                ชื่อชั้นความเร็ว :
            </td>
            <td class="Csslbl">
                <uc1:txtbox ID="txtName" runat="server" IsNotNull="true" Width="300" />
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
                        <asp:BoundField DataField="speed_code" HeaderText="รหัส" SortExpression="speed_code">
                            <ItemStyle Width="60px" HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Underline="True"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Speed_name" HeaderText="ชื่อ" SortExpression="speed_name">
                            <HeaderStyle Width="450px" Font-Underline="True" />
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
