<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDocTHeGIFOutboundSearch.aspx.vb" Inherits="WebApp_frmDocTHeGIFOutboundSearch" %>

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
                ค้นหาหนังสือส่งออกไปยัง TH-eGIF
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
                                <uc1:txtAutoComplete ID="txtBookNo" runat="server"  Width="240" />
                            </td>
                            <td align="right" class="Csslbl">เลขที่ส่งออก (อก) :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtBookoutNo" runat="server" Width="240" />
                            </td>
                        </tr>
                        <tr>
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
                            <td align="right" class="Csslbl">วันที่ส่งออก :</td>
                            <td class="Csslbl" align="left" >
                                <table border="0" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td><uc2:txtDate ID="txtSendDateFrom" runat="server" /></td>
                                        <td>&nbsp;ถึง&nbsp;</td>
                                        <td><uc2:txtDate ID="txtSendDateTo" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">ชื่อเรื่อง :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtTitleName" runat="server" Width="240" FieldName="title_name" TableName="DOCUMENT_REGISTER"  />
                            </td>
                            <td align="right" class="Csslbl">หน่วยงาน/องค์กร ที่รับ :</td>
                            <td class="Csslbl" align="left">
                                <uc1:txtAutoComplete ID="txtCompanyNameReceive" runat="server" Width="240" FieldName="company_name" TableName="DOCUMENT_REGISTER" />
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
                        <asp:BoundField DataField="id" >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("book_no") %>'
                                    CommandArgument='<%# Bind("id") %>' OnClick="likBookNo_Click" ToolTip="เลือก"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="register_date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ลงทะเบียน" HtmlEncode="False" HeaderStyle-Width="80px" />
                        <asp:BoundField DataField="title_name" HeaderText="ชื่อเรื่อง"  />
                        <asp:BoundField DataField="company_name_receive" HeaderText="ชื่อหน่วยงาน" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="doc_status_name" HeaderText="สถานะ" HeaderStyle-Width="80px" />
                        <asp:BoundField DataField="bookout_no" HeaderText="เลขที่หนังสือ<br />ส่งออก (อก)" HeaderStyle-Width="100px" HtmlEncode="false" />
                        <asp:TemplateField >
                            <ItemStyle Width="20px" HorizontalAlign="Center" ></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgSendToTHeGif" runat="server" Height="20px"  ImageUrl="~/Images/TH-eGif_Logo.png" Visible='<%# Eval("is_send_thegif") <> "Y" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="document_ext_receiver_id" >
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
                <script language="javascript" type="text/javascript">
                     function SendToTHeGif(vID, ctl) {
                         if (confirm("ยืนยันการส่งข้อมูล?")) {
                             var img = document.getElementById(ctl);
                             var UserName = '<%=Config.GetLogOnUser.UserName %>';
                             var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>'
                             $.ajax({
                                 type: "POST",
                                 url: pageUrl + "/SendLetterToTHeGif",
                                 data: "{'vDocExtID':'" + vID + "','LoginName':'" + UserName + "'}",
                                 contentType: "application/json; charset=utf-8",
                                 dataType: "json",
                                 success: function(msg) {
                                     if (msg.d == true) {
                                         alert("ส่งข้อมูลเรียบร้อย");
                                         img.style.display = "none";

                                         var bt = document.getElementById('<%=btnSearch.ClientID %>');
                                         if (bt) {
                                             bt.click();
                                             return false;
                                         }
                                     }
                                 }
                             });
                         }
                     }
                 </script>
            </td>
        </tr>
    </table>
</asp:Content>

