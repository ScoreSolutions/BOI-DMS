<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptjobsectorforgm.aspx.vb" Inherits="rptGrid_rptjobsectorforgm" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                รายงาน งานค้างเกินกำหนดเสนอผู้บริหาร 
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organizename" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                ณ วันที่ 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                        &nbsp;</td>
        </tr>
       
    </table>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    </asp:Content>


