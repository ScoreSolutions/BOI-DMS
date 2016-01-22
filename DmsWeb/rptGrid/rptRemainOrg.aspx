<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptRemainOrg.aspx.vb" Inherits="rptGrid_rptRemainOrg" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">รายงานสรุปงานค้าง</td>
        </tr>
        <tr>
            <td style="padding-left:200px; " class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
                <asp:Label ID="lbl_organize" runat="server" CssClass="zHidden" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Repeater ID="Repeater1" runat="server" >
                    <HeaderTemplate>
                        <table style='width:100%;' border='0' cellpadding='0' cellspacing='0'  >
                        <tr class='grid_Header' >
                            <td  colspan="2" ><%=lbl_organize.Text%></td>
                            <td  colspan="3" ><%=DateTime.Now.ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))%></td>
                        </tr>
                        <tr class='grid_Header' >
                            <td style='width:30px' >ลำดับ</td>
                            <td >งาน</td>
                            <td style='width:80px' >เกินกำหนด</td>
                            <td style='width:80px' >ไม่เกินกำหนด</td>
                            <td style='width:80px' >รวม</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style='background-color: #FFFBD6;font-size:18px'>
                                <asp:Label ID="lblGroupTitleTypeName" runat="server" CssClass="zHidden" Text='<%#DataBinder.Eval(Container.DataItem, "doc_cat_type_name")%>' > </asp:Label>
                                <asp:Label ID="lblGroupTitleTypeID" runat="server" CssClass="zHidden" Text='<%#DataBinder.Eval(Container.DataItem,"doc_cat_type_id") %>' ></asp:Label>
                            </td>
                        </tr>
                        <asp:Label ID="lblDesc" runat="server" ></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr class='grid_Header' >
                            <td  colspan="2" >รวม</td>
                            <td ><asp:Label ID="lblTotOverDue" runat="server" Text="0" ></asp:Label></td>
                            <td ><asp:Label ID="lblTotNotOverDue" runat="server" Text="0"></asp:Label></td>
                            <td ><asp:Label ID="lblTotTotal" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

