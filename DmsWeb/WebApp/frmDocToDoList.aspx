<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDocToDoList.aspx.vb" Inherits="WebApp_frmToDoList" title="To Do List" %>
<%@ MasterType  virtualPath="~/Template/ContentMasterPage.master"%>

<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc7" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>
<%@ Register src="../UserControlsButton/btnReceiveInside.ascx" tagname="btnReceiveInside" tagprefix="uc3" %>
<%@ Register src="../UserControlsButton/btnCloseJob.ascx" tagname="btnCloseJob" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" border="0" cellpadding="2" cellspacing="0" >
    <tr>
        <td class="CssHead" >To do list</td>
        <td colspan="3"  >&nbsp;</td>
    </tr>
    <tr>
        <td align="right" width="15%">&nbsp;</td>
        <td width="35%">&nbsp;</td>
        <td align="right" width="15%">&nbsp;</td>
        <td width="35%">&nbsp;</td>
    </tr>
    <tr class="CssSubHead">
        <td>รายการหนังสือ</td>
        <td colspan="3" align="center">
            <table border="0" cellpadding="0" cellspacing="0" >
                <tr>
                    <td width="50px">งาน :&nbsp;</td>
                    <td width="200px" valign="top" ><uc7:cmbAutoComplete ID="cmbJobStatus" runat="server" Width="150px" IsDefaultValue="false" AutoPosBack="true" /></td>
                    <td><asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="80px" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr><td colspan="4"><uc1:PageControl ID="pcTop" runat="server" /></td></tr>
    <tr style="height:25px">
        <td colspan="4" >
            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="true"
            AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%">
                <RowStyle CssClass="RowStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <PagerSettings Visible="false" />
                <HeaderStyle CssClass="HeaderStyle" />
                <AlternatingRowStyle CssClass="AltRowStyle" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" >
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DOCUMENT_INT_RECEIVER_ID" HeaderText="DOCUMENT_INT_RECEIVER_ID" >
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                        <ItemStyle CssClass="zHidden" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="cb1" runat="server" OnCheckedChanged="cb1_OnCheckedChanged" AutoPostBack="true" />
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
                        <HeaderTemplate>
                            <asp:ImageButton ID="imgAttach" runat="server" ToolTip="เอกสารแนบ" ImageUrl="~/Images/attach.png" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAttach" runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" SortExpression="book_no" >
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                            <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("book_no") %>' CssClass="zHidden" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" SortExpression="book_title" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน" HtmlEncode="False" SortExpression="date_register" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="send_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ส่ง" HtmlEncode="False" SortExpression="send_date" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="organization_name_send" HeaderText="หน่วยงานผู้ส่ง" SortExpression="organization_name_send" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" SortExpression="user_send" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="user_receive" HeaderText="เจ้าหน้าที่รับ" SortExpression="user_receive" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc_status_name" HeaderText="งาน" SortExpression="doc_status_name" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="count_file"  >
                        <ItemStyle CssClass="zHidden" />
                        <ControlStyle CssClass="zHidden" />
                        <FooterStyle CssClass="zHidden" />
                        <HeaderStyle CssClass="zHidden" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px" ></asp:TextBox>
            <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px" Text="DESC" ></asp:TextBox>
        </td>
    </tr>
    <tr><td colspan="4">&nbsp;</td></tr>
    <tr>
        <td colspan="3">&nbsp;</td>
        <td align="right">
            <uc3:btnReceiveInside ID="btnReceiveInside1" runat="server" />
            <uc4:btnCloseJob ID="btnCloseJob1" runat="server" ButtonText="จบงาน" Visible="false" />            
        </td>
    </tr>
    <tr><td colspan="4">&nbsp;</td></tr>
    <tr><td colspan="4">&nbsp;</td></tr>
    <tbody id='Elec' style="display:none">
        <tr class="CssSubHead">
            <td colspan="4" align="left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;เอกสารอิเล็กทรอนิกส์ - รอลงทะเบียน</td>
        </tr>
        <tr><td colspan="4"><uc1:PageControl ID="pc2" runat="server" /></td></tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvElectronic" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    Width="100%" AllowPaging="True">
                    <PagerSettings Visible="False" />
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField DataField="doc_create_date" HeaderText="วันที่สร้าง" ItemStyle-Width="10%"
                            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="doc_title" HeaderText="ชื่อเรื่อง" >
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="process" HeaderText="สถานะ" ItemStyle-Width="25%">
                            <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btnRegister" runat="server" Text="ลงทะเบียน" CssClass="CssBtn" CommandArgument='<%# Bind("rowid") %>' CommandName="Register" Width="80px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr class="CssSubHead">
            <td colspan="4" align="left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;เอกสารจาก TH-eGIF - รอลงทะเบียน</td>
        </tr>
        <tr><td colspan="4"><uc1:PageControl ID="pc3" runat="server" /></td></tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvTHeGif" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                    Width="100%" AllowPaging="true" PageSize="20" AllowSorting="true">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("body_id") %>'
                                    CommandArgument='<%# Bind("id") %>' CommandName="ShowDetail" ToolTip="เลือก"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="correspondence_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="ลงวันที่" HtmlEncode="False" HeaderStyle-Width="80px" />
                        <asp:BoundField DataField="body_subject" HeaderText="ชื่อเรื่อง" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="sender_organization_name" HeaderText="ชื่อหน่วยงาน" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="doc_status_name" HeaderText="สถานะ" HeaderStyle-Width="80px" />
                        <asp:BoundField DataField="receive_notify_letterid" HeaderText="เลขที่รับหนังสือ" HeaderStyle-Width="100px"  />
                        <asp:TemplateField ShowHeader="false"  >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                            <ItemTemplate>
                                <asp:Button ID="btnRegister" runat="server" Text="ลงทะเบียน" CssClass="CssBtn" Width="80px" Visible='<%# Eval("receive_notify_letterid") = "" %>' CommandArgument='<%# Bind("id") %>' CommandName="Register" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <PagerSettings Visible="false" />
                </asp:GridView>
            </td>
        </tr>
    </tbody>
</table>
</asp:Content>

