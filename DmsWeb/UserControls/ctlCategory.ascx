<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCategory.ascx.vb"
    Inherits="UserControls_ctlCategory" %>
<%@ Register Src="txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<uc1:txtBox ID="txtBox1" runat="server" AutoPosBack="True" Width="50" CssClass="fontonlabel" />
<asp:ImageButton ID="ImageSearch" runat="server" ImageUrl="~/Images/search.png" 
    ImageAlign="AbsMiddle" />
<asp:Label ID="lblID" runat="server"></asp:Label>
<uc1:txtBox ID="txtBox2" runat="server" IsNotNull="false" TextType="TextView" Width="300px" CssClass="fontonlabel" />
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/ico_catalog_categories.gif"
    ImageAlign="AbsMiddle" />&nbsp;&nbsp;
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>

<!-- CSS by TonG-->
 <link href="../css/font.css" media="screen" rel="stylesheet" type="text/css" />
 <link href="../css/frm.css" media="screen" rel="stylesheet" type="text/css" />
 <link href="../css/input.css" media="screen" rel="stylesheet" type="text/css" />

<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="button" />
<asp:Label ID="lblCaption" runat="server" CssClass="fontonlabel" Text="ประเภทหนังสือ"></asp:Label>
<asp:Panel ID="Panel1" runat="server" Width="600">
    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server" class="fontonlabel">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class=fontonlabel>
                ประเภทหนังสือ
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td class="CssHead">
                &nbsp;
            </td>
            <td align="right" class="fontonlabel">
                ค้นหา :
                <asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" CssClass="fontonlabel"/>
            </td>
        </tr>
        <tr>
            <td align="right" class="fontonlabel" width="20%">
                รหัสประเภท :
            </td>
            <td width="80%" class="fontonlabel">
                <uc1:txtBox ID="txtCode" runat="server" IsNotNull="true" MaxLength="2" Width="50"
                    TextKey="TextDouble" />
            </td>
        </tr>
        <tr>
            <td align="right" class="fontonlabel">
                ชื่อประเภท :
            </td>
            <td class="fontonlabel">
                <uc1:txtBox ID="txtName" runat="server" IsNotNull="true" Width="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="fontonlabel">
                &nbsp;
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" CssClass="fontonlabel" Text="ใช้งาน" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="button" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="button" Width="60px" />
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
                    AutoGenerateColumns="False" PageSize="20" CssClass="fontonlabel" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" GridLines="None" Width="100%" 
                    DataKeyNames="id" CellPadding="4" ForeColor="#333333" >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="category_code" HeaderText="รหัส" SortExpression="category_code">
                            <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Underline="True"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="category_name" HeaderText="ชื่อ" SortExpression="category_name">
                            <HeaderStyle Width="450px" />
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
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="pgr" BackColor="#2461BF" ForeColor="White" 
                        HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <table width="100%" border="1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Visible="False" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle CssClass="alt" BackColor="White" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>
