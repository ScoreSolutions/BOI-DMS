<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmSearchBookCancelCloseJob.aspx.vb" Inherits="WebApp_frmSearchBookCancelCloseJob" Title="ค้นหาหนังสือเพื่อยกเลิกจบงาน" %>
<%@ MasterType  virtualPath="~/Template/ContentMasterPage.master"%>

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
            <td class="CssHead" colspan="4" align="left">
                ค้นหาหนังสือเพื่อยกเลิกจบงาน
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
                <td colspan="4">
                    <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                        <tr>
                            <td align="right" class="Csslbl" width="15%">เลขที่หนังสือ :</td>
                            <td class="Csslbl" width="35%" align="left" >
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
                    Width="100%" AllowPaging="true" PageSize="20" AllowSorting="true">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" SortExpression="book_no" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                            <ItemTemplate>
                                <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                                <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("book_no") %>'
                                    CommandArgument='<%# Bind("id") %>' CssClass="zHidden" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" SortExpression="date_register" HeaderText="วันที่ลงทะเบียน" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" SortExpression="book_title" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="company_name" HeaderText="ชื่อองค์กร" SortExpression="company_name" >
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="company_doc_no" HeaderText="เลขที่เอกสาร" SortExpression="company_doc_no" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="company_doc_date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="company_doc_date" HeaderText="วันที่เอกสาร" HtmlEncode="False" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" SortExpression="user_send" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="organization_name_send" HeaderText="หน่วยงานผู้ส่ง" SortExpression="organization_name_send" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="request_no" HeaderText="เลขที่คำขอ" SortExpression="request_no" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="True" HeaderText="" >
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:Button ID= "btnCancelCloseJob" runat="server"  Text="ยกเลิกจบงาน" CssClass="CssBtn" CommandName="CancelCloseJob" CommandArgument='<%# Bind("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id"  >
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
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
    <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Panel ID="Panel1" runat="server" Width="500">
        <table id="Table1" width="500" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
            style="border: solid 0px 0px 0px 0px #ff0000;" runat="server">
            <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                <td align="left" bgcolor="#3B5998" colspan="3">
                    <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                </td>
                <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/Images/closewindows.png" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="Csslbl" colspan="4">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="Csslbl" width="20%">
                    &nbsp;
                </td>
                <td class="Csslbl" width="30%" align="left">
                    &nbsp;
                </td>
                <td align="right" class="Csslbl" width="20%">
                    &nbsp;
                </td>
                <td width="30%" align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    เหตุผล :
                </td>
                <td colspan="3">
                    <uc1:txtAutoComplete ID="txtCancelReason" Width="250" runat="server" Text="ขอเอกสารเพิ่มเติม" IsNotNull="true" />
                    <uc1:txtAutoComplete ID="txtDocRegisID" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr style="height: 25px">
                <td align="center" colspan="4">
                    <asp:Button ID="btnYes" runat="server" CssClass="CssBtn" Text="ใช่" Width="50px" />
                    <asp:Button ID="btnNo" runat="server" CssClass="CssBtn" Text="ไม่ใช่" Width="50px" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
        BackgroundCssClass="modalBackground" DropShadow="true">
    </cc1:ModalPopupExtender>
</asp:Content>
