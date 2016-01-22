<%@ Page Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptkpibyemp.aspx.vb" Inherits="rptGrid_rptkpibyemp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css"  />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organizename" runat="server" ></asp:Label>
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
    
    
        
        <asp:Label ID="lblDesc" runat="server" ></asp:Label>
</asp:Content>

