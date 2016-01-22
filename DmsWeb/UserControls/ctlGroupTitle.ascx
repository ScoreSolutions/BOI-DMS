<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlGroupTitle.ascx.vb" Inherits="UserControls_ctlGroupTitle" %>
<%@ Register Src="txtAutoComplete.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="PageControl.ascx" tagname="pagecontrol" tagprefix="uc1" %>
<uc1:txtBox ID="txtGroupTitleCode" runat="server" AutoPosBack="True" TableName="GROUP_TITLE" FieldName="group_title_code"  Width="80" CssClass="Csslbl" />

<asp:ImageButton ID="ImageSearch" runat="server" ImageUrl="~/Images/search.png" 
    ImageAlign="AbsMiddle" style="height: 16px; width: 16px" />
<asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
<uc1:txtBox ID="txtGroupTitleName" runat="server" IsNotNull="false" TextType="TextView" Width="200px" CssClass="fontonlabel" />
<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" ></asp:Label>


<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" Width="600">
    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 20px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="cssHead" >กลุ่มเรื่อง</td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                ชื่อกลุ่มเรื่อง :
            </td>
            <td width="80%">
                <uc1:txtBox ID="txtsGroupTitleName" runat="server" IsNotNull="false" Width="300" />
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
            <td colspan="2" >
                <uc1:PageControl ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" CssClass="GridViewStyle"
                    AutoGenerateColumns="False"  DataKeyNames="id" PageSize="10" Width="100%" >
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                        <asp:TemplateField ShowHeader="True" HeaderText="กลุ่มเรื่อง" SortExpression="group_title_name" >
                            <HeaderStyle Width="450px" />
                            <ItemStyle HorizontalAlign="Left" Width="450px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likGroupTitleName" runat="server" OnClick="likGroupTitleName_Click"  Text='<%# Bind("group_title_name") %>' CommandArgument='<%# Bind("id") %>' ToolTip="เลือก" ></asp:LinkButton>
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
