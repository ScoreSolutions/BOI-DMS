<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptjobsector.aspx.vb" Inherits="rptGrid_rptjobsector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">��§ҹ�ҹ��ҧ</td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organize" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                � �ѹ��� 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left:200px; " class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Repeater ID="Repeater1" runat="server" >
                    <HeaderTemplate>
                        <table style='width:100%;' border='0' cellpadding='0' cellspacing='0'  >
                        <tr class='grid_Header' >
                            <td  style='width:30px;' rowspan='2' >�ӴѺ</td>
                            <td  style='width:100px;' rowspan='2' >����¹</td>
                            <td  style='width:100px;' rowspan='2' >�ѹ���ŧ����¹</td>
                            <td  style='width:100px;' rowspan='2' >�ú��˹�<br />ʹ�.</td>
                            <td  rowspan='2' >����ѷ</td>
                            <td  style='width:100px;' rowspan='2' >�ѹ����Ѻ <%=lbl_organize.Text%></td>
                            <td  style='width:60px;' rowspan='2' >�ҡ</td>
                            <td  style='width:60px;' rowspan='2' >�ú��˹�  <%=lbl_organize.Text%></td>
                            <td  style='width:150px;' rowspan='2' >���Ԩ�ó�</td>
                            <td  style='width:60px;' rowspan='2' >�Թ��˹�<br />(�ѹ)</td>
                            <td  colspan='6' >���˵�</td>
                            <td  colspan='3' >��ûѭ��</td>
                            
                        </tr>
                        <tr class='grid_Header' >
                            <td style='width:50px' >�͢�����</td>
                            <td style='width:50px' >���ѧ��<br />�Ԩ�ó�</td>
                            <td style='width:50px' >��͹��ѵ�</td>
                            <td style='width:50px' >�ͻ�Ъ��</td>
                            <td style='width:50px' >�͹�º��</td>
                            <td style='width:50px' >����<br />(�к���������´)</td>
                            <td style='width:50px' >�͡˹ѧ���</td>
                            <td style='width:50px' >����Ҫ��ᨧ</td>
                            <td style='width:50px' >����<br />(�к���������´)</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td colspan="19" style='background-color: #FFFBD6;font-size:18px'>
                                <asp:Label ID="lblGroupTitleName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "group_title_name")%>' > </asp:Label>
                            </td>
                        </tr>
                        <asp:Label ID="lblDesc" runat="server" ></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

