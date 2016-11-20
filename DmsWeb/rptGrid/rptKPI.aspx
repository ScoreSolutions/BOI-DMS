<%@ Page Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptKPI.aspx.vb" Inherits="rptGrid_rptKPI" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css"  />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organizename" runat="server" ></asp:Label>
                <asp:Label ID="lblOfficerID" runat="server" CssClass="zHidden" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                ระหว่าง วันที่ 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
            &nbsp;ถึง
                <asp:Label ID="lbl_todt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style=" height:30px;" class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    
    
        
    <table style='width:100%;' border='1' cellpadding='0' cellspacing='0'  >
        <tr class='grid_Header' >
            <td style='border-bottom:0px;' >เรื่อง</td>
            <td style='border-bottom:0px;background-color:#FFFBD6;' >เข้า</td>
            <td colspan='3' style='width:150px;'>ค้างสะสม</td>
            <td colspan='3' style='background-color:#FFFBD6;' >ออก</td>
            <td colspan='3' >ค้างคงเหลือ</td>
            <td colspan='4' style='background-color:#FFFBD6;' >KPI</td>
        </tr>
        <tr class='grid_Header' >
            <td style='border-top:0px;'>&nbsp;</td>
            <td style='width:50px;border-top:0px;background-color:#FFFBD6;'>&nbsp;</td>
            <td style='width:50px;'>เกิน</td>
            <td style='width:50px;'>ไม่เกิน</td>
            <td style='width:50px;'>รวม</td>
            <td style='background-color: #FFFBD6;'>เกิน</td>
            <td style='background-color: #FFFBD6;'>ไม่เกิน</td>
            <td style='background-color: #FFFBD6;'>รวม</td>
            <td style='width:50px;'>เกิน</td>
            <td style='width:50px;'>ไม่เกิน</td>
            <td style='width:50px;'>รวม</td> 
            <td style='background-color: #FFFBD6;width:50px; '>กำหนด</td>
            <td style='background-color: #FFFBD6;width:50px; '>AVG.</td>
            <td style='background-color: #FFFBD6;width:50px; '>MAX.</td>
            <td style='background-color: #FFFBD6;width:50px; '>MIN.</td>
        </tr>
        <asp:Repeater ID="rptDocCatType" runat="server">
            <ItemTemplate>
                <asp:Repeater ID="rptGroupTitle" runat="server" OnItemDataBound="rptGroupTitle_ItemDataBound" >
                    <ItemTemplate>
                        <tr id="rItem" runat="server" >
                            <td align='left'><asp:Label ID="lblGroupTitleName" runat="server"></asp:Label></td>
                            <td align='center' style='background-color: #FFFBD6;' ><asp:Label ID="lblIncome" runat="server"></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            
                <tr class='grid_Header' style='background-color:#B1B1B1;'>
                    <td align='center'>รวม</td>
                    <td align='center'><asp:Label ID="lblSumIncome" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblSumRemOver" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblSumRemNotOver" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblTotalRemain" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblSumOutOver" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblSumOutNotOver" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblTotalOut" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblSumRemTotOver" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblSumRemTotNotOver" runat="server"></asp:Label></td>
                    <td align='center'><asp:Label ID="lblTotalRemTot" runat="server"></asp:Label></td>
                    <td align='center'>&nbsp;</td>
                    <td align='center'>&nbsp;</td>
                    <td align='center'>&nbsp;</td>
                    <td align='center'>&nbsp;</td>
                </tr>
                
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

