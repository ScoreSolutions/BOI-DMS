<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptRepStorageReceive.aspx.vb" Inherits="rptGrid_rptRepStorageReceive" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                รายงานการรับหนังสือ<asp:Label ID="lblStorageOrgName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead" >
                <asp:Label ID="lblDateInterval" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <table border='0' cellpadding='0' cellspacing='0' align="center"  >
                    <tr class='grid_Header' >
                        <td style='width:80px' align="center" >สำนัก</td>
                        <td style='width:80px' align="center" >ตรวจสอบ</td>
                        <td style='width:80px' align="center" >เครื่องจักร</td>
                        <td style='width:80px' align="center" >วัตถุดิบ</td>
                        <td style='width:80px' align="center" >สูตร-สต็อค</td>
                        <td style='width:80px' align="center" >ที่ดิน</td>
                        <td style='width:80px' align="center" >รวม</td>
                    </tr>
                    <asp:Label ID="lblDesc" runat="server" ></asp:Label>
                </table>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

