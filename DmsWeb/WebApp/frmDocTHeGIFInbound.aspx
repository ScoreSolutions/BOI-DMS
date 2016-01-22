<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDocTHeGIFInbound.aspx.vb" Inherits="WebApp_frmDocTHeGIFInbound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="CssHead" colspan="6" align="left" >
                รายละเอียดหนังสือจาก TH-eGIF
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                เลขที่หนังสือ :
            </td>
            <td class="Csslbl" width="30%" align="left" >
                <asp:Label ID="lblBookNo" runat="server" ForeColor="Blue"></asp:Label>
            </td>
            <td align="right" class="Csslbl" width="20%">
                ลงวันที่ :
            </td>
            <td class="Csslbl" width="30%" align="left">
                <asp:Label ID="lblCorrespondenceDate" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                ชั้นความลับ :
            </td>
            <td class="Csslbl" align="left">
                <asp:Label ID="lblSecret" runat="server" ForeColor="Blue"></asp:Label>
            </td>
            <td align="right" class="Csslbl" >
                ชั้นความเร็ว :
            </td>
            <td class="Csslbl" align="left">
                <asp:Label ID="lblSpeed" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                ผู้ส่ง :
            </td>
            <td class="Csslbl"  align="left">
                <asp:Label ID="lblSenderGivenName" runat="server" ForeColor="Blue"></asp:Label>
            </td>
            <td align="right" class="Csslbl" >
                ตำแหน่ง :
            </td>
            <td class="Csslbl" align="left">
                <asp:Label ID="lblSenderJobTitle" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                หน่วยงานผู้ส่ง :
            </td>
            <td class="Csslbl" align="left" colspan="3">
                <asp:Label ID="lblSenderOrganizationName" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                เรื่อง :
            </td>
            <td class="Csslbl" align="left" colspan="3" >
                <asp:Label ID="lblTitleName" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                ผู้ลงนาม :
            </td>
            <td class="Csslbl" align="left">
                <asp:Label ID="lblSignerGivenName" runat="server" ForeColor="Blue"></asp:Label>
            </td>
            <td align="right" class="Csslbl" >
                ตำแหน่ง :
            </td>
            <td class="Csslbl" align="left">
                <asp:Label ID="lblSignerPosition" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                หน่วยงานผู้ลงนาม :
            </td>
            <td class="Csslbl" align="left" colspan="3">
                <asp:Label ID="lblSignerOrganizationName" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                รายละเอียด :
            </td>
            <td class="Csslbl" align="left" colspan="3">
                <asp:Label ID="lblDescriptoin" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                หนังสือหลัก :
            </td>
            <td class="Csslbl" align="left" colspan="3">
                <asp:Label ID="lblMainLetterContentType" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >&nbsp;</td>
            <td class="Csslbl" align="left" colspan="3">
                <%--<asp:Label ID="lblMainLetterBinaryObject" runat="server" ForeColor="Blue"></asp:Label>--%>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                หนังสืออ้างอิง :
            </td>
            <td class="Csslbl" align="left" colspan="3">
                <asp:Label ID="lblReferenceCorrespondence" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >
                &nbsp;
            </td>
            <td class="Csslbl" style="color: #000080">
                &nbsp;
            </td>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;
            </td>
            <td class="Csslbl" style="color: #000080">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

