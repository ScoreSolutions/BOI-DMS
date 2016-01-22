<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master"
    AutoEventWireup="false" CodeFile="frmDocOutsideSend.aspx.vb" Inherits="WebApp_frmDocOutsideSend" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register src="../UserControlsButton/btnSendOutside.ascx" tagname="btnSendOutside" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0">
        <tr style="height: 35px">
            <td class="CssHead" align="left">
                ส่งออกนอกสำนักงาน
            </td>
        </tr>
        <tr class="CssSubHead" align="left">
            <td>
                รายการหนังสือ
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            เลขที่หนังสือ :
                        </td>
                        <td width="35%" align="left">
                            <uc6:txtAutoComplete ID="txtBookNo" runat="server" Width="240"  />
                        </td>
                        <td align="right" class="Csslbl">
                            วันที่ลงทะเบียน :
                        </td>
                        <td align="left">
                            <table border="0" cellpadding="0" cellspacing="0" >
                                <tr>
                                    <td><uc3:txtDate ID="txtRegDateFrom" runat="server" /></td>
                                    <td>&nbsp;ถึง&nbsp;</td>
                                    <td><uc3:txtDate ID="txtRegDateTo" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">เลขที่คำขอ :</td>
                        <td align="left">
                            <uc6:txtAutoComplete ID="txtReqNo" runat="server"  Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อเรื่อง :
                        </td>
                        <td class="Csslbl" align="left">
                            <uc6:txtAutoComplete ID="txtTitleName" runat="server" FieldName="title_name" TableName="GROUP_TITLE"  Width="240" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            เลขที่หนังสือองค์กร :
                        </td>
                        <td align="left">
                            <uc6:txtAutoComplete ID="txtCompanyDocNo" runat="server"  Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อองค์กร :
                        </td>
                        <td class="Csslbl" align="left">
                            <uc6:txtAutoComplete ID="txtCompanyName" runat="server" Width="240" />
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
                        <td class="Csslbl"  align="left">
                            <asp:CheckBox ID="chkInDirector" runat="server" Text=" เสนอผู้บริหาร/ผอ.สำนัก" />
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td colspan="4" align="center">
                            <asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="80px" />
                            &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" Width="80px" />
                        </td>
                    </tr>
                    <tr><td colspan="4">&nbsp;</td></tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:PageControl ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                    Width="100%" AllowPaging="true" AllowSorting="true" >
                    <RowStyle CssClass="RowStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <PagerSettings Visible="false" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemStyle Width="5px"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="cb1" runat="server" />
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
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" ItemStyle-HorizontalAlign="Left" SortExpression="book_title" />
                        <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน"
                            HtmlEncode="False" SortExpression="date_register" />
                        <asp:BoundField DataField="company_name" HeaderText="ชื่อองค์กร" ItemStyle-HorizontalAlign="Left" SortExpression="company_name" />
                        <asp:BoundField DataField="company_doc_no" HeaderText="เลขที่หนังสือองค์กร" SortExpression="company_doc_no" />
                        <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" SortExpression="user_send" />
                        <asp:BoundField DataField="folder_name" HeaderText="โฟลเดอร์" >
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
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px" ></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px" Text="DESC" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <uc4:btnSendOutside ID="btnSendOutside1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <%--<uc4:popSendOutside ID="popSendOutside1" runat="server" />--%>
            </td>
        </tr>
    </table>
</asp:Content>
