<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlModule.ascx.vb" Inherits="UserControls_ctlModule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="PageControl.ascx" TagName="pagecontrol" TagPrefix="uc1" %>
<%@ Register Src="txtBox.ascx" TagName="txtbox" TagPrefix="uc1" %>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/inv1.jpg" ImageAlign="AbsMiddle" />
&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Label ID="lblCaption" runat="server" CssClass="CssHead" Text="โมดูล"></asp:Label>
<asp:Panel ID="Panel1" runat="server" Width="600">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        โมดูล
                    </td>
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
                        <uc1:txtbox ID="txtID" runat="server" Visible="false" Text="0" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" width="20%">
                        รหัสโมดูล :
                    </td>
                    <td width="80%" class="Csslbl">
                        <uc1:txtbox ID="txtCode" runat="server" IsNotNull="true" MaxLength="2" Width="50"
                            TextKey="TextDouble" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" width="20%">
                        ลำดับ :
                    </td>
                    <td width="80%" class="Csslbl">
                        <uc1:txtbox ID="txtOrder" runat="server" IsNotNull="true" MaxLength="2" TextKey="TextDouble"
                            Width="50" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        ชื่อโมดูล :
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtName" runat="server" IsNotNull="true" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        รายละเอียด :
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtDescription" runat="server" IsNotNull="true" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        คำอธิบาย :
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtTooltip" runat="server" IsNotNull="true" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        ไอคอน :
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" CssClass="CssFileUpload" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
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
                                <asp:BoundField DataField="module_code" HeaderText="รหัส" SortExpression="module_code">
                                    <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Underline="True"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="module_name" HeaderText="ชื่อ" SortExpression="module_name">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    <HeaderStyle Font-Underline="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="module_desc" HeaderText="รายละเอียด" SortExpression="module_desc">
                                    <HeaderStyle Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="module_toolstip" HeaderText="คำอธิบาย" SortExpression="module_toolstip">
                                    <HeaderStyle Width="100px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="order_seq" HeaderText="ลำดับ" SortExpression="order_seq">
                                    <HeaderStyle Width="50px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="ไอคอน" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#ConfigurationManager.AppSettings("UploadURL").ToString() & Eval("module_icon").ToString() %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="active" HeaderText="การใช้งาน" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="active">
                                    <HeaderStyle Width="70px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="15px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandName="Edit"
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
