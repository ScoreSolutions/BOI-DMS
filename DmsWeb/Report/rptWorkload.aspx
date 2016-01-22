<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="rptWorkload.aspx.vb" Inherits="Report_rptWorkload" %>

<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc7" %>
<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
        <td></td>
            <td align="left"  class="CssHead" colspan="2">
                รายงาน Workload</td>
        </tr>
        <tr>
            <td class="CssHead" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">&nbsp;</td>
            <td align="left" class="Csslbl" width="85%">
                <asp:RadioButtonList ID="rdiRepType" runat="server" Height="20px" RepeatColumns="3" Width="426px">
                    <asp:ListItem Value="0" Selected>เรื่องเข้า</asp:ListItem>
                    <asp:ListItem Value="1">เรื่องออก</asp:ListItem>
                    <asp:ListItem Value="2">เรื่องถือครองในช่วงเวลาที่เลือก</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">กอง&nbsp; :
            </td>
            <td align="left" class="Csslbl" width="85%">
                <uc7:cmbAutoComplete ID="cmbOrg" runat="server" Width="250" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                ณ วันที่ :
            </td>
            <td align="left" class="Csslbl" width="85%">
               <table border="0" >
                    <tr>
                        <td><uc2:txtDate ID="txtDate1" runat="server" /></td>
                        <td>&nbsp;ถึง</td>
                        <td><uc2:txtDate ID="txtDate2" runat="server" /></td>
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
                    Width="100px" />
                <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" 
                    Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>

