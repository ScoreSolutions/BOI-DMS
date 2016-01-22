<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDocMenuSelect.aspx.vb" Inherits="WebApp_frmDocMenuSelect" %>


<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            color: #3b5998;
            text-decoration: none;
            vertical-align: middle;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 25px;
            line-height: normal;
            font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
            width: 253px;
        }
        
        .style4
        {
            color: #3b5998;
            text-decoration: none;
            vertical-align: middle;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 25px;
            line-height: normal;
            font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
        }
        
        .style_menu
        {
            color: #000000;
            text-decoration: none;
            vertical-align: middle;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 22px;
            line-height: normal;
            font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
        }
        
        .style9
        {
            width: 112px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" border="0" cellpadding="2" cellspacing="0" >
    <tr>
        <td class="style3" align="left" >&nbsp;&nbsp;&nbsp;&nbsp; แบบฟอร์มเอกสารอิเล็กทรอนิกส์</td>
    </tr>
    <tr>
        <td class="style3" >&nbsp;</td>
    </tr>
    <tr class="CssSubHead">
    <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; แบบฟอร์มเอกสารอิเล็กทรอนิกส์</td>
    </tr>
    <tr><td>
        <table style="width:100%;">
            <tr>
                <td align=left class="style9"  >
                    &nbsp;</td>
                <td align=left class="style4">
                    กรุณาเลือกแบบฟอร์มเอกสารอิเล็กทรอนิกส์</td>
            </tr>
            <tr>
                <td align=left class="style9"  >
                    &nbsp;</td>
                <td align=left class="style_menu" >
            <asp:Menu ID="Menu1" runat="server" Font-Underline="False" ForeColor="Black" 
                Width="500px" Font-Size="X-Large">
                <StaticHoverStyle Font-Underline="True" />
                <Items>
                    <asp:MenuItem Text="หนังสือภายนอก" Value="หนังสือภายนอก" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=1"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือภายใน" Value="หนังสือภายใน" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=2"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือประทับตรา" Value="หนังสือประทับตรา"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=3"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือสั่งการ คำสั่ง" Value="หนังสือสั่งการ คำสั่ง"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=4"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือสั่งการระเบียบ" Value="หนังสือสั่งการระเบียบ"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=5"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือสั่งการ ข้อบังคับ" Value="หนังสือสั่งการ ข้อบังคับ"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=6"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือประชาสัมพันธ์ ประกาศ"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=7"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือประชาสัมพันธ์ แถลงการณ์"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=8"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือประชาสัมพันธ์ ข่าว" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=9"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือที่เจ้าหน้าที่ทำขึ้นหรือรับไว้เป็นหลักฐาน หนังสือรับรอง" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=10"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือที่เจ้าหน้าที่ทำขึ้นหรือรับไว้เป็นหลักฐาน รายงานการประชุม" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=11"></asp:MenuItem>
                    <asp:MenuItem Text="หนังสือที่เจ้าหน้าที่ทำขึ้นหรือรับไว้เป็นหลักฐาน บันทึก" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=12"></asp:MenuItem>
                </Items>
            </asp:Menu>
                </td>
            </tr>
        </table>
        </td></tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
