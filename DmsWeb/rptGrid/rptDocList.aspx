<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptDocList.aspx.vb" Inherits="rptGrid_rptDocList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOI-DMS : ระบบสารบรรณอิเล็กทรอนิกส์</title>
    <link  href="../Template/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
            <tr>
                <td align="center" class="Csslbl" colspan="4">
                    <asp:Label ID="lblDetail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="Csslbl" colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" >
                        <RowStyle CssClass="RowStyle" />
                        <Columns>
                            <asp:BoundField DataField="no" HeaderText="ที่" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ShowHeader="True" HeaderText="เลขทะเบียน" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                                    <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("book_no") %>' CssClass="zHidden" ></asp:LinkButton>
                                    <asp:Label ID="lblRequestNo" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="title_name" HeaderText="ชื่อเรื่อง"  />
                            <asp:BoundField DataField="company_name" HeaderText="หน่วยงาน"  />
                            <asp:BoundField DataField="register_date" DataFormatString="{0:d MMM yy}" HeaderText="วันที่ลงทะเบียน" HtmlEncode="False" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="expect_finish_date" DataFormatString="{0:d MMM yy}" HeaderText="วันกำหนดเสร็จ" HtmlEncode="False" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="close_date" DataFormatString="{0:d MMM yy}" HeaderText="วันจบงาน" HtmlEncode="False" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="process_date_qty" HeaderText="ใช้เวลา" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"  />
                            <asp:BoundField DataField="officer_name_approve" HeaderText="จนท. ผู้พิจารณา" ItemStyle-Width="150px" />
                            <asp:BoundField DataField="doc_status_name" HeaderText="สถานะ" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:BoundField DataField="request_no" >
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id" HeaderText="id" >
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle" />
                        <HeaderStyle CssClass="HeaderStyleReports" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <PagerSettings Visible="false" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
