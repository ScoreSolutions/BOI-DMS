﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="rptStorageReceive.aspx.vb" Inherits="Report_rptStorageReceive" %>

<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="left" class="CssHead" colspan="2">รายงานการรับหนังสือหน่วยจัดเก็บเอกสารกลาง</td>
        </tr>
        <tr>
            <td class="CssHead" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" width="15%" valign="top" class="Csslbl">
                หน่วยจัดเก็บ :
            </td>
            <td align="left" width="85%">
                <uc7:cmbAutoComplete ID="cmbOrg" runat="server" Width="250" IsDefaultValue="false" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                ระหว่างวันที่ :
            </td>
            <td align="left" class="Csslbl" width="85%">
                <table>
                    <tr>
                        <td align="left"><uc2:txtDate ID="txtDate1" runat="server" /></td>
                        <td>&nbsp;ถึง</td>
                        <td align="left"><uc2:txtDate ID="txtDate2" runat="server" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td class="Csslbl" width="85%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                &nbsp;</td>
            <td align="left" class="Csslbl" width="85%">
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="ดูรายงาน" 
                    Width="100px" 
                    />
                <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" 
                    Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>

