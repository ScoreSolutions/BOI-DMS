<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmSearchBook.aspx.vb" Inherits="WebApp_frmSearchBook" Title="ค้นหาหนังสือ" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControlsButton/btnReceiveInside.ascx" TagName="btnReceiveInside" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ค้นหาหนังสือ
            </td>
        </tr>
        <tr>
            <td align="right" width="15%">
                &nbsp;
            </td>
            <td width="35%">
                &nbsp;
            </td>
            <td align="right" width="15%">
                &nbsp;
            </td>
            <td width="35%">
                &nbsp;
            </td>
        </tr>
        <tbody id="frmSearch" runat="server">
            <tr>
                <td colspan="4" align="left" >
                    <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                        <tr>
                            <td align="right" class="Csslbl" width="15%">เลขที่หนังสือ :</td>
                            <td class="Csslbl" width="35%">
                                <uc1:txtAutoComplete ID="txtBookno" runat="server"  Width="240" />
                            </td>
                            <td align="right" class="Csslbl">วันที่ลงทะเบียน :</td>
                            <td class="Csslbl" align="left" >
                                <table border="0" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td><uc2:txtDate ID="txtRegisDateFrom" runat="server" /></td>
                                        <td>&nbsp;ถึง&nbsp;</td>
                                        <td><uc2:txtDate ID="txtRegisDateTo" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">เลขที่คำขอ :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtReqNo" runat="server" Width="240" />
                            </td>
                            <td align="right" class="Csslbl">ชื่อเรื่อง :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtTitleName" runat="server" Width="240" FieldName="title_name" TableName="GROUP_TITLE"  />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">เลขที่เอกสาร :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtCompanyDocNo" runat="server" Width="240" />
                            </td>
                            <td align="right" class="Csslbl">ชื่อองค์กร :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtCompanyName" runat="server" Width="240" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                            <td align="right" class="Csslbl">สถานะ :</td>
                            <td align="left">
                                <uc4:cmbAutoComplete ID="cmbStatus" runat="server" DefaultDisplay="ทั้งหมด" Width="240" />
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
            <td align="left" class="Csslbl" colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                    Width="100%" AllowPaging="true" PageSize="20" AllowSorting="true">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" SortExpression="book_no" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                            <ItemTemplate>
                                <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                                <asp:LinkButton ID="likBookNo" runat="server" CssClass="zHidden" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" SortExpression="date_register HeaderText="วันที่ลงทะเบียน" HtmlEncode="False"  />
                        <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" SortExpression="book_title"  />
                        <asp:BoundField DataField="company_name" HeaderText="ชื่อองค์กร" SortExpression="company_name" />
                        <asp:BoundField DataField="company_doc_no" HeaderText="เลขที่เอกสาร" SortExpression="company_doc_no"  />
                        <asp:BoundField DataField="company_doc_date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="company_doc_date" HeaderText="วันที่เอกสาร" HtmlEncode="False"  />
                        <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" SortExpression="user_send"  />
                        <asp:BoundField DataField="organization_name_send" HeaderText="หน่วยงานผู้ส่ง" SortExpression="organization_name_send"  />
                        <asp:BoundField DataField="request_no" HeaderText="เลขที่คำขอ" SortExpression="request_no" />
                        <asp:BoundField DataField="doc_status_name" HeaderText="สถานะ" SortExpression="doc_status_name" />
                        <asp:BoundField DataField="bookout_no" HeaderText="เลขหนังสือออก" SortExpression="bookout_no" />
                        <asp:BoundField DataField="folder_name" HeaderText="โฟล์เดอร์"  >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id"  >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <PagerSettings Visible="false" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px" ></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px" Text="DESC" ></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
