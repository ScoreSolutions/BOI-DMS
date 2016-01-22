<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptjobsector.aspx.vb" Inherits="rptGrid_rptjobsector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">รายงานงานค้าง</td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organize" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                ณ วันที่ 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left:200px; " class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Repeater ID="Repeater1" runat="server" >
                    <HeaderTemplate>
                        <table style='width:100%;' border='0' cellpadding='0' cellspacing='0'  >
                        <tr class='grid_Header' >
                            <td  style='width:30px;' rowspan='2' >ลำดับ</td>
                            <td  style='width:100px;' rowspan='2' >ทะเบียน</td>
                            <td  style='width:100px;' rowspan='2' >วันที่ลงทะเบียน</td>
                            <td  style='width:100px;' rowspan='2' >ครบกำหนด<br />สนง.</td>
                            <td  rowspan='2' >บริษัท</td>
                            <td  style='width:100px;' rowspan='2' >วันที่รับ <%=lbl_organize.Text%></td>
                            <td  style='width:60px;' rowspan='2' >จาก</td>
                            <td  style='width:60px;' rowspan='2' >ครบกำหนด  <%=lbl_organize.Text%></td>
                            <td  style='width:150px;' rowspan='2' >ผู้พิจารณา</td>
                            <td  style='width:60px;' rowspan='2' >เกินกำหนด<br />(วัน)</td>
                            <td  colspan='6' >สาเหตุ</td>
                            <td  colspan='3' >การปัญหา</td>
                            
                        </tr>
                        <tr class='grid_Header' >
                            <td style='width:50px' >รอข้อมูล</td>
                            <td style='width:50px' >กำลังรอ<br />พิจารณา</td>
                            <td style='width:50px' >รออนุมัติ</td>
                            <td style='width:50px' >รอประชุม</td>
                            <td style='width:50px' >รอนโยบาย</td>
                            <td style='width:50px' >อื่นๆ<br />(ระบุรายละเอียด)</td>
                            <td style='width:50px' >ออกหนังสือ</td>
                            <td style='width:50px' >ให้มาชี้แจง</td>
                            <td style='width:50px' >อื่นๆ<br />(ระบุรายละเอียด)</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td colspan="19" style='background-color: #FFFBD6;font-size:18px'>
                                <asp:Label ID="lblGroupTitleName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "group_title_name")%>' > </asp:Label>
                            </td>
                        </tr>
                        <asp:Label ID="lblDesc" runat="server" ></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
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

