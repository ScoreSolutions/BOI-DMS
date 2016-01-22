<%@ Page Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptkpibyorg.aspx.vb" Inherits="rptGrid_rptkpibyorg" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="right" class="Csslbl" >
                ณ วันที่ <%=DateTime.Now.ToString("d MMM yy HH:mm:ss", New Globalization.CultureInfo("th-TH")) %>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                สรุปผลการดำเนินงานสะสมของสำนักบริหารการลงทุน 1-4
            </td>
        </tr>
        <tr>
            <td class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblDesc" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td ><hr /></td>
        </tr>
        
        <tr>
            <td class="Csslbl" ><u>หมายเหตุ</u></td>
        </tr>
        <tr>
            <td class="Csslbl" >1. % งานที่ใช้เวลาเกินกำหนด = (100/งานเข้า+ค้างสะสมรวม) * (งานออกเกิน + งานค้างคงเหลือเกิน)</td>
        </tr>
        <tr>
            <td class="Csslbl" >2. กลุ่มเรื่องคำขอรับการส่งเสริมที่นำมาคำนวณ</td>
        </tr>
        <tr>
            <td class="Csslbl" >
                <asp:Label ID="lblGroupTitleRequest" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>


