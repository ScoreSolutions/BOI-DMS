<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlCompany.ascx.vb" Inherits="UserControls_ctlCompany_ascx" %>
<%@ Register Src="txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="PageControl.ascx" tagname="pagecontrol" tagprefix="uc1" %>


<uc1:txtBox ID="txtBox1" runat="server" AutoPosBack="True" Width="80"  />
<asp:ImageButton ID="ImageSearch" runat="server" ImageUrl="~/Images/search.png" ImageAlign="AbsMiddle"
style="height: 16px; width: 16px" />
<asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
<uc1:txtBox ID="txtBox2" runat="server" IsNotNull="false" TextType="TextView" Width="200px" />
<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>


<asp:Panel ID="Panel1" runat="server" Width="600" >
    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" style="font-family: TH SarabunPSK; font-size:25px">บริษัท</td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td >
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                รหัส :
            </td>
            <td width="80%" class="Csslbl">
                <uc1:txtBox ID="txtCode" runat="server" IsNotNull="false" Width="100"
                    TextKey="TextInt"  />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                ชื่อไทย :
            </td>
            <td Class="Csslbl">
                <uc1:txtBox ID="txtName" runat="server" IsNotNull="false" Width="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                ชื่ออังกฤษ :
            </td>
            <td Class="Csslbl">
                <uc1:txtBox ID="txtEngName" runat="server" IsNotNull="false" Width="300" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="60px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:PageControl ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                    AutoGenerateColumns="False"  DataKeyNames="id" CssClass="GridViewStyle" 
                    GridLines="Horizontal" PageSize="20" Width="100%" >
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                        <asp:TemplateField ShowHeader="True" HeaderText="รหัส" SortExpression="comid" >
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Font-Underline="True" HorizontalAlign="Center" Width="60px" 
                                BackColor="#2987C8" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likComID" runat="server" OnClick="likThaiName_Click"  Text='<%# Bind("comid") %>' CommandArgument='<%# Bind("id") %>' ToolTip="เลือก" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="True" HeaderText="ชื่อไทย" SortExpression="thainame" >
                            <HeaderStyle Width="450px" BackColor="#2987C8" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likThaiName" runat="server" OnClick="likThaiName_Click"  Text='<%# Bind("thainame") %>' CommandArgument='<%# Bind("id") %>' ToolTip="เลือก" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="True" HeaderText="ชื่ออังกฤษ" SortExpression="engname" >
                            <HeaderStyle Width="450px" BackColor="#2987C8" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likEngName" runat="server" OnClick="likThaiName_Click"  Text='<%# Bind("engname") %>' CommandArgument='<%# Bind("id") %>' ToolTip="เลือก" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle CssClass="pgr" BackColor="#E7E7FF" ForeColor="#4A3C8C" 
                        HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        <table border="1" width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerSettings Visible="False" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
    </table>
</asp:Panel>
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
