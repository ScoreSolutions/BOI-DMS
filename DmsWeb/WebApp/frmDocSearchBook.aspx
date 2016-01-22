<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmDocSearchBook.aspx.vb" Inherits="WebApp_frmDocSearchBook" Title="ค้นหาหนังสือ" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControlsButton/btnReceiveInside.ascx" TagName="btnReceiveInside"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc4" %>
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
                <td colspan="4"  align="left" >
                    <table border="0" cellpadding="0" cellspacing="0" align="center" width="70%">
                        <tr>
                            <td align="right" class="Csslbl" width="15%">
                                รหัสหนังสือ :
                            </td>
                            <td class="Csslbl" width="35%">
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
                                <uc1:txtAutoComplete ID="txtAutoComplete2" runat="server" Width="240" />
                            </td>
                            <td align="right" class="Csslbl">
                                ชื่อเรื่อง :
                            </td>
                            <td class="Csslbl">
                                <uc1:txtAutoComplete ID="txtAutoComplete4" runat="server"  Width="240" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">
                                เลขที่เอกสาร :
                            </td>
                            <td class="Csslbl">
                                <uc1:txtAutoComplete ID="txtAutoComplete3" runat="server" Width="240" />
                            </td>
                            <td align="right" class="Csslbl">
                                ชื่อองค์กร :
                            </td>
                            <td class="Csslbl">
                                <uc1:txtAutoComplete ID="txtAutoComplete5" runat="server"  Width="240" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">
                                โฟล์เดอร์ :
                            </td>
                            <td>
                                <uc4:cmbAutoComplete ID="cmbFolderID" runat="server" DefaultDisplay="ทั้งหมด" Width="240" />
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
        <tr style="height: 25px">
            <td colspan="4" valign="top">
                <uc4:cmbAutoComplete ID="cmbMoveTo" runat="server" Width="100" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRetrieve" runat="server" CssClass="CssBtn" Text="ดึงกลับ" Width="50px" />&nbsp;
                <asp:Button ID="btnSendBack" runat="server" CssClass="CssBtn" Text="ตีกลับ" Width="50px" />
                &nbsp;<asp:Button ID="btnCancelCloseJob" runat="server" CssClass="CssBtn" Text="ยกเลิกการจบงาน"
                    Width="120px" />
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
                        <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" SortExpression="bookno">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likBookNo" runat="server" OnClick="likBookNo_Click" Text='<%# Bind("bookno") %>'
                                    CommandArgument='<%# Bind("id") %>' ToolTip="เลือก"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน"
                            HtmlEncode="False" />
                        <asp:BoundField DataField="book_title" HeaderText="ชื่อหนังสือ" />
                        <asp:BoundField DataField="book_from" HeaderText="ชื่อองค์กร" />
                        <asp:BoundField DataField="doc_no" HeaderText="เลขที่เอกสาร" />
                        <asp:BoundField DataField="book_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่เอกสาร"
                            HtmlEncode="False" />
                        <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" />
                        <asp:BoundField DataField="dept" HeaderText="กองผู้ส่ง" />
                        <asp:BoundField DataField="req_no" HeaderText="เลขที่คำขอ" />
                        <asp:BoundField DataField="status_name" HeaderText="สถานะ" />
                        <asp:BoundField DataField="folder_name" HeaderText="โฟล์เดอร์" />
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
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
                    <uc1:txtAutoComplete ID="txtBackReason" Width="250" runat="server" Text="ส่งผิดสำนัก"
                        IsNotNull="true" />
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
