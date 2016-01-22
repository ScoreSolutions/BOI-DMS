<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="frmDocInsideSend.aspx.vb" Inherits="WebApp_frmDocInsideSend"  %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc3" %> 
<%@ Register Src="../UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc6" %>
<%@ Register Src="../UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc7" %>
<%@ Register Src="~/UserControlsButton/btnSendInside.ascx" TagName="btnSendInside" TagPrefix="bt1" %>
<%@ Register Src="~/UserControlsButton/btnSendCircle.ascx" TagName="btnSendCircle" TagPrefix="bt2" %>
<%@ Register Src="~/UserControlsButton/btnCloseJob.ascx" TagName="btnCloseJob" TagPrefix="bt3" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register src="~/UserControlsButton/popSendInside.ascx" tagname="popSendInside" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ส่งภายในสำนักงาน
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
        <tr class="CssSubHead">
            <td colspan="4"  align="left" >
                รายการหนังสือ
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4"  align="left" >
                <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            เลขที่หนังสือ :
                        </td>
                        <td width="35%">
                            <uc6:txtAutoComplete ID="txtBookno" runat="server" Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            วันที่ลงทะเบียน :
                        </td>
                        <td>
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
                        <td align="right" class="Csslbl">
                            เลขที่คำขอ :
                        </td>
                        <td>
                            <uc6:txtAutoComplete ID="txtReqNo" runat="server"  Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อเรื่อง :
                        </td>
                        <td class="Csslbl">
                            <uc6:txtAutoComplete ID="txtTitleName" runat="server" FieldName="title_name" TableName="GROUP_TITLE" Width="240" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            เลขที่เอกสาร :
                        </td>
                        <td class="Csslbl">
                            <uc6:txtAutoComplete ID="txtCompanyDocNo" runat="server" Width="240" />
                        </td>
                        <td align="right" class="Csslbl">
                            ชื่อองค์กร :
                        </td>
                        <td class="Csslbl">
                            <uc6:txtAutoComplete ID="txtCompanyName" runat="server" Width="240" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl">
                            &nbsp;
                        </td>
                        <td class="Csslbl">
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
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:PageControl ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr style="height: 25px">
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                    Width="100%" DataKeyNames="id" AllowPaging="true" AllowSorting="true" >
                    <RowStyle CssClass="RowStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <PagerSettings Visible="false" />
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
                        <asp:TemplateField HeaderText="เลขที่หนังสือ" SortExpression="book_no" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate> 
                                <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                                <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("book_no") %>'
                                    CommandArgument='<%# Bind("id") %>' ToolTip="เลือก" CssClass="zHidden" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" SortExpression="book_title" >
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle  HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน"
                            HtmlEncode="False" SortExpression="date_register" />
                        <asp:BoundField DataField="company_name" HeaderText="ชื่อองค์กร" SortExpression="company_name" >
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle  HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="company_doc_no" HeaderText="เลขที่หนังสือองค์กร" SortExpression="company_doc_no" />
                        <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" SortExpression="user_send" />
                        <asp:BoundField DataField="folder_name" HeaderText="โฟล์เดอร์"  >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="document_int_receiver_id" HeaderText="document_int_receiver_id" >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="count_file" >
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
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                <bt1:btnSendInside ID="btnSendInside" runat="server"  />
                <uc4:popSendInside ID="popSendInside1" runat="server" />
                
                <bt2:btnSendCircle ID="btnSendCircle1" runat="server"  />
            </td>
        </tr>
    </table>

</asp:Content>
