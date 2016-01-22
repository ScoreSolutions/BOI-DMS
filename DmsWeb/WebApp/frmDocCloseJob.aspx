<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDocCloseJob.aspx.vb" Inherits="WebApp_frmDocCloseJob" title="จบงาน" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/cmbCombobox.ascx" TagName="cmbCombobox" TagPrefix="uc6" %>
<%@ Register src="~/UserControlsButton/btnCloseJob.ascx" tagname="btnCloseJob" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td class="CssHead" colspan="4" align="left" >จบงาน</td>
        </tr>
        <tr>
            <td align="right" width="15%">&nbsp;</td>
            <td width="35%">&nbsp;</td>
            <td align="right" width="15%">&nbsp;</td>
            <td width="35%">&nbsp;</td>
        </tr>
        <tr class="CssSubHead">
            <td colspan="4"  align="left">ค้นหาหนังสือ</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;
                <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            เลขที่หนังสือ :
                        </td>
                        <td width="35%" class="Csslbl" align="left" >
                            <uc1:txtAutoComplete ID="txtBookNo" runat="server"  Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            วันที่ลงทะเบียน :
                        </td>
                        <td class="Csslbl" align="left" >
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><uc2:txtDate ID="txtRegDateFrom" runat="server" /></td>
                                    <td>&nbsp;ถึง&nbsp;</td>
                                    <td><uc2:txtDate ID="txtRegDateTo" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            เลขที่คำขอ :
                        </td>
                        <td class="Csslbl" align="left" >
                            <uc1:txtAutoComplete ID="txtReqNo" runat="server" Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อเรื่อง :
                        </td>
                        <td class="Csslbl" align="left" >
                            <uc1:txtAutoComplete ID="txtTitleName" runat="server" FieldName="title_name" TableName="GROUP_TITLE" Width="240" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            เลขที่หนังสือองค์กร :
                        </td>
                        <td class="Csslbl" align="left" >
                            <uc1:txtAutoComplete ID="txtCompanyDocNo" runat="server" Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อองค์กร :
                        </td>
                        <td align="left" >
                            <uc1:txtAutoComplete ID="txtCompanyName" runat="server"  Width="240" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            &nbsp;
                        </td>
                        <td class="Csslbl" align="left" >
                            <asp:CheckBox ID="chkOutDirector" runat="server" Text=" ออกจากห้องผู้บริหาร/ผอ.สำนัก" />
                        </td>
                        <td>&nbsp;</td>
                        <td class="Csslbl" align="left" >
                            <asp:CheckBox ID="chkInDirector" runat="server" Text=" เสนอผู้บริหาร/ผอ.สำนัก" />
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
        <tr>
            <td align="left" class="Csslbl" colspan="4">
                <uc3:PageControl ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                    Width="100%" AllowPaging="true" AllowSorting="true"  >
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
                            <HeaderTemplate>
                                <asp:ImageButton ID="imgAttach" runat="server" ToolTip="เอกสารแนบ" ImageUrl="~/Images/attach.png" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAttach" runat="server" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" SortExpression="book_no">
                            <HeaderStyle Width="80px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                            <ItemTemplate>
                                <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน"
                            HtmlEncode="False" SortExpression="date_register" />
                        <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" SortExpression="book_title" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="company_name" HeaderText="ชื่อองค์กร" SortExpression="company_name" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" SortExpression="user_send" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="request_no" HeaderText="เลขที่คำขอ" SortExpression="request_no" >
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id" HeaderText="id" >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="document_int_receiver_id" HeaderText="document_int_receiver_id" >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="count_file"  >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerSettings Visible="false" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px" ></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px" Text="DESC" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                <uc7:btnCloseJob ID="btnCloseJob1" runat="server" ButtonText="จบงาน" />
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
    </table>
</asp:Content>