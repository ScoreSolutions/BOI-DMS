<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="rptSendOutDP.aspx.vb" Inherits="Report_rptSendOutDP" %>


<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc3" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete"
    TagPrefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr><td></td>
            <td class="CssHead" colspan="2" align="left">
                รายงานสรุปเอกสารที่ส่งออกนอกสำนักงาน</td>
        </tr>
        <tr>
            <td class="CssHead" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                หน่วยงาน :
            </td>
            <td class="Csslbl" width="85%" align="left">
                <uc7:cmbAutoComplete ID="cmbOrg" runat="server" Width="250" ValidateText="*" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                เลขที่หนังสือส่งออก (อก) :
            </td>
            <td class="Csslbl" width="85%" align="left">
                <uc3:txtBox ID="txtBox1" runat="server" Width="100px" />
                ถึง&nbsp;
                <uc3:txtBox ID="txtBox2" runat="server" Width="100px" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="15%">
                วันที่ส่งออก :
            </td>
            <td class="Csslbl" width="85%" align="left">
                <table border="0" >
                    <tr>
                        <td><uc2:txtDate ID="txtDate1" runat="server" IsNotNull="true" /></td>
                        <td>&nbsp;ถึง</td>
                        <td><uc2:txtDate ID="txtDate2" runat="server" IsNotNull="true" /></td>
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
            <td class="Csslbl" width="85%" align="left">
                <asp:Button ID="Button1" runat="server" CssClass="CssBtn" Text="ดูรายงาน" 
                    Width="100px" />
                <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" 
                    Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>

