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
        <td class="style3" align="left" >&nbsp;&nbsp;&nbsp;&nbsp; Ẻ������͡�������硷�͹ԡ��</td>
    </tr>
    <tr>
        <td class="style3" >&nbsp;</td>
    </tr>
    <tr class="CssSubHead">
    <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ẻ������͡�������硷�͹ԡ��</td>
    </tr>
    <tr><td>
        <table style="width:100%;">
            <tr>
                <td align=left class="style9"  >
                    &nbsp;</td>
                <td align=left class="style4">
                    ��س����͡Ẻ������͡�������硷�͹ԡ��</td>
            </tr>
            <tr>
                <td align=left class="style9"  >
                    &nbsp;</td>
                <td align=left class="style_menu" >
            <asp:Menu ID="Menu1" runat="server" Font-Underline="False" ForeColor="Black" 
                Width="500px" Font-Size="X-Large">
                <StaticHoverStyle Font-Underline="True" />
                <Items>
                    <asp:MenuItem Text="˹ѧ�����¹͡" Value="˹ѧ�����¹͡" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=1"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ�������" Value="˹ѧ�������" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=2"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ��ͻ�зѺ���" Value="˹ѧ��ͻ�зѺ���"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=3"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ�����觡�� �����" Value="˹ѧ�����觡�� �����"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=4"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ�����觡������º" Value="˹ѧ�����觡������º"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=5"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ�����觡�� ��ͺѧ�Ѻ" Value="˹ѧ�����觡�� ��ͺѧ�Ѻ"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=6"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ��ͻ�Ъ�����ѹ�� ��С��"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=7"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ��ͻ�Ъ�����ѹ�� �ŧ��ó�"
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=8"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ��ͻ�Ъ�����ѹ�� ����" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=9"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ��ͷ�����˹�ҷ��Ӣ�������Ѻ�������ѡ�ҹ ˹ѧ����Ѻ�ͧ" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=10"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ��ͷ�����˹�ҷ��Ӣ�������Ѻ�������ѡ�ҹ ��§ҹ��û�Ъ��" 
                        NavigateUrl="~/WebApp/frmElecDocFormBookOut.aspx?docformid=11"></asp:MenuItem>
                    <asp:MenuItem Text="˹ѧ��ͷ�����˹�ҷ��Ӣ�������Ѻ�������ѡ�ҹ �ѹ�֡" 
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
