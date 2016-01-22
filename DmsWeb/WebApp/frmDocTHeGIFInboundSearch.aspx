<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDocTHeGIFInboundSearch.aspx.vb" Inherits="WebApp_frmDocTHeGIFInboundSearch" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ค้นหาหนังสือจาก TH-eGIF
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
                                <uc1:txtAutoComplete ID="txtBookID" runat="server"  Width="240" />
                            </td>
                            <td align="right" class="Csslbl">เลขที่รับหนังสือ :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtReqNo" runat="server" Width="240" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">ลงวันที่ :</td>
                            <td class="Csslbl" align="left" >
                                <table border="0" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td><uc2:txtDate ID="txtCorrDateFrom" runat="server" /></td>
                                        <td>&nbsp;ถึง&nbsp;</td>
                                        <td><uc2:txtDate ID="txtCorrDateTo" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" class="Csslbl">วันที่รับ :</td>
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
                            <td align="right" class="Csslbl">ชื่อเรื่อง :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtTitleName" runat="server" Width="240" FieldName="body_subject" TableName="TH_EGIF_DOC_INBOUND"  />
                            </td>
                            <td align="right" class="Csslbl">หน่วยงานที่ส่ง :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtOrganizationName" runat="server" Width="240" />
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
                        <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" >
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("body_id") %>'
                                    CommandArgument='<%# Bind("id") %>' CommandName="ShowDetail" ToolTip="เลือก"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="correspondence_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="ลงวันที่" HtmlEncode="False" HeaderStyle-Width="80px" />
                        <asp:BoundField DataField="body_subject" HeaderText="ชื่อเรื่อง"  />
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
    </table>
</asp:Content>

