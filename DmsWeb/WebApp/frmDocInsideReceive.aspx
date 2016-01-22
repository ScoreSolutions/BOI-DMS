<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="frmDocInsideReceive.aspx.vb" Inherits="WebApp_frmDocInsideReceive" %>
<%@ MasterType  virtualPath="~/Template/ContentMasterPage.master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControlsButton/btnReceiveInside.ascx" TagName="btnReceiveInside" TagPrefix="uc2" %>
<%@ Register Src="../UserControlsButton/btnRecieveAndSendIn.ascx" TagName="btnRecieveAndSendIn" TagPrefix="uc3" %>
<%@ Register src="~/UserControlsButton/btnSendOutside.ascx" tagname="btnSendOutside" tagprefix="uc1" %>
<%@ Register src="~/UserControlsButton/btnCloseJob.ascx" tagname="btnCloseJob" tagprefix="uc4" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/cmbCombobox.ascx" TagName="cmbCombobox" TagPrefix="uc9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0"  >
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ลงรับภายในสำนักงาน
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
        <tr class="CssSubHead" >
            <td colspan="4"  align="left" >
                เรื่องที่รอลงรับภายในสำนักงาน
            </td>
        </tr>
        <tr>
            <td colspan="4"  align="left" >
                <table width="100%" bgcolor="#ffffff">
                    <tr>
                        <td colspan="4">
                            <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                                <tr>
                                    <td align="right" class="Csslbl" width="20%">
                                        เลขที่หนังสือ :
                                    </td>
                                    <td width="25%"  align="left" >
                                        <uc6:txtAutoComplete ID="txtBookno" runat="server" Width="100" />
                                    </td>
                                    <td align="right" class="Csslbl" width="15%">
                                        วันที่ส่ง :
                                    </td>
                                    <td  align="left"  class="Csslbl" width="40%">
                                        <table border="0" cellpadding="0" cellspacing="0" >
                                            <tr>
                                                <td ><uc7:txtDate ID="txtSendDateFrom" runat="server" /></td>
                                                <td >&nbsp;ถึง&nbsp;</td>
                                                <td ><uc7:txtDate ID="txtSendDateTo" runat="server" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="Csslbl">
                                        เลขที่คำขอ :
                                    </td>
                                    <td  align="left" class="Csslbl">
                                        <uc6:txtAutoComplete ID="txtReqNo" runat="server" Width="100" />
                                    </td>
                                    <td align="right" class="Csslbl">
                                        วันที่ลงทะเบียน :
                                    </td>
                                    <td align="left"  class="Csslbl">
                                        <table border="0" cellpadding="0" cellspacing="0" >
                                            <tr>
                                                <td ><uc7:txtDate ID="txtRegDateFrom" runat="server" /></td>
                                                <td >&nbsp;ถึง&nbsp;</td>
                                                <td ><uc7:txtDate ID="txtRegDateTo" runat="server" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="Csslbl">
                                        เลขที่หนังสือองค์กร :
                                    </td>
                                    <td align="left"  class="Csslbl">
                                        <uc6:txtAutoComplete ID="txtCompanyDocNo" runat="server"  Width="100" />
                                    </td>
                                    <td align="right" class="Csslbl">
                                        ชื่อองค์กร :
                                    </td>
                                    <td align="left" >
                                        <uc6:txtAutoComplete ID="txtCompanyName" runat="server"  Width="240" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td align="right" class="Csslbl">
                                        ชื่อเรื่อง :
                                    </td>
                                    <td align="left" colspan="3"  class="Csslbl">
                                        <uc6:txtAutoComplete ID="txtTitleName" runat="server" Width="550" />
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
                            <uc8:PageControl ID="pcTop" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="Csslbl" width="15%" colspan="4">
                            <asp:GridView ID="gridcontrol" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                Width="100%" AllowPaging="true" AllowSorting="true" >
                                <RowStyle CssClass="RowStyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cb1" runat="server" autopostback ="true" 
                                                oncheckedchanged="cb1_OnCheckedChanged"/>
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
                                    <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" SortExpression="bookno">
                                        <HeaderStyle Width="120px" />
                                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("bookno") %>' ToolTip="เลือก" ></asp:Label>
                                            <asp:LinkButton ID="likBookNo" runat="server"  Text='<%# Bind("bookno") %>' CssClass="zHidden" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="True" HeaderText="โฟล์เดอร์" SortExpression="folder_name">
                                        <HeaderStyle Width="100px" CssClass="zHidden" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px"  CssClass="zHidden" />
                                        <ItemTemplate  >
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="date_register" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน"
                                        HtmlEncode="False" SortExpression="date_register" />
                                    <asp:BoundField DataField="book_title" HeaderText="ชื่อหนังสือ" SortExpression="book_title" />
                                    <asp:BoundField DataField="book_from" HeaderText="ชื่อองค์กร" SortExpression="book_from" />
                                    <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ผู้ส่ง" SortExpression="user_send" />
                                    <asp:BoundField DataField="date_send" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ส่ง"
                                        HtmlEncode="False" SortExpression="date_send" />
                                    <asp:BoundField DataField="id" ShowHeader="false" >
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="document_register_id" ShowHeader="false" >
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="count_file" ShowHeader="false" >
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
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                
                <uc2:btnReceiveInside ID="btnReceiveInside1" runat="server" />
                <uc3:btnRecieveAndSendIn ID="btnRecieveAndSendIn1" runat="server" />
                <uc4:btnCloseJob ID="btnCloseJob1" runat="server" ButtonText="ลงรับพร้อมจบงาน" />
                <uc1:btnSendOutside ID="btnRecieveAndSendOut1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;
            </td>
        </tr>
    </table>
   
</asp:Content>
 
