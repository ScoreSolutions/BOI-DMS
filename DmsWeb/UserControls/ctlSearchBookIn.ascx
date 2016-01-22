<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlSearchBookIn.ascx.vb"
    Inherits="UserControls_ctlSearchBookIn" %>
<%@ Register Src="txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>
<%@ Register Src="txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControlsButton/btnReceiveInside.ascx" TagName="btnReceiveInside" TagPrefix="uc3" %>
<%@ Register Src="cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc4" %>
<%@ Register Src="cmbCombobox.ascx" TagName="cmbCombobox" TagPrefix="uc5" %>
<table width="100%" bgcolor="#ffffff">
    <tbody id="frmSearch" runat="server">
        <tr>
            <td colspan="4">
                <table border="0" cellpadding="0" cellspacing="0" align="center" width="70%">
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            รหัสหนังสือ :
                        </td>
                        <td width="35%" class="Csslbl">
                            <uc1:txtAutoComplete ID="txtAutoComplete1" runat="server" FieldName="bookno" TableName="T_SEARCH_BOOKIN"
                                Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            วันที่ลงทะเบียน :
                        </td>
                        <td class="Csslbl">
                            <uc2:txtDate ID="txtDate1" runat="server" />
                            &nbsp;ถึง
                            <uc2:txtDate ID="txtDate2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            เลขที่คำขอ :
                        </td>
                        <td class="Csslbl">
                            <uc1:txtAutoComplete ID="txtAutoComplete2" runat="server" FieldName="req_no" TableName="T_SEARCH_BOOKIN"
                                Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อเรื่อง :
                        </td>
                        <td class="Csslbl">
                            <uc1:txtAutoComplete ID="txtAutoComplete4" runat="server" FieldName="book_title"
                                TableName="T_SEARCH_BOOKIN" Width="240" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            เลขที่เอกสาร :
                        </td>
                        <td class="Csslbl">
                            <uc1:txtAutoComplete ID="txtAutoComplete3" runat="server" FieldName="doc_no" TableName="T_SEARCH_BOOKIN"
                                Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อองค์กร :
                        </td>
                        <td>
                            <uc1:txtAutoComplete ID="txtAutoComplete5" runat="server" FieldName="book_from" TableName="T_SEARCH_BOOKIN"
                                Width="240" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            โฟล์เดอร์ :
                        </td>
                        <td>
                            <uc5:cmbCombobox ID="cmbFolderID" runat="server" DefaultDisplay="ทั้งหมด" Width="240" />
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td colspan="4" align="center">
                            <asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="80px" />
                            &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" Width="80px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </tbody>
    <tr>
        <td align="left" class="Csslbl" colspan="4">
            <uc1:PageControl ID="pcTop" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="left" class="Csslbl" width="15%" colspan="4">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                Width="100%">
                <RowStyle CssClass="RowStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="cb1" runat="server" />
                        </HeaderTemplate>
                        <ItemStyle Width="5px"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemTemplate>
                            <asp:CheckBox ID="cb2" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="false">
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                        <ItemTemplate>
                            <asp:Image ID="imgAttach" runat="server" ImageUrl="~/Images/attach.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" SortExpression="bookno">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="likBookNo" runat="server" OnClick="likBookNo_Click" Text='<%# Bind("bookno") %>'
                                CommandArgument='<%# Bind("id") %>' ToolTip="เลือก"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="True" HeaderText="โฟล์เดอร์" SortExpression="folder_name">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                        <ItemTemplate>
                            <uc5:cmbCombobox ID="cmbFolderID" runat="server" DefaultValue="1" DefaultDisplay="Inbox"
                                Width="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน"
                        HtmlEncode="False" />
                    <asp:BoundField DataField="book_title" HeaderText="ชื่อหนังสือ" />
                    <asp:BoundField DataField="book_from" HeaderText="ชื่อองค์กร" />
                    <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" />
                    <asp:BoundField DataField="req_no" HeaderText="เลขที่คำขอ" />
                </Columns>
                <PagerStyle CssClass="PagerStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <AlternatingRowStyle CssClass="AltRowStyle" />
            </asp:GridView>
        </td>
    </tr>
</table>
