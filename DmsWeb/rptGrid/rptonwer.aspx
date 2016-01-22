<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptonwer.aspx.vb" Inherits="rptGrid_rptonwer" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                งานที่ถือครองอยู่และยังไม่จบงาน ณ วันที่ 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label><br />
                <asp:Label ID="lblOrgName" runat="server"></asp:Label>
                <asp:Label ID="lblOrgID" runat="server" CssClass="zHidden" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <Saifi:MyDg ID="dgvdetail" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" ImageFirst="/imgs/nav_left.gif" 
                            ImageLast="/imgs/nav_right.gif" ImageNext="/imgs/bulletr.gif" 
                            ImagePrevious="/imgs/bulletl.gif" 
                            ShowFirstAndLastImage="False" ShowPreviousAndNextImage="False" 
                            Width="100%">
                            <PagerStyle Mode="NumericPages" />
                            <ItemStyle CssClass="grid_Item" />
                            <AlternatingItemStyle CssClass="grid_AlternatingItem" />
                            <HeaderStyle CssClass="grid_Header" />
                            <Columns>
                                <asp:TemplateColumn HeaderText="ชื่อเรื่อง">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_group_title_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"group_title_name") %>'
                                        Width="350px"></asp:Label>
                                        <asp:Label ID="lblGroupTitleID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"group_title_id") %>' CssClass="zHidden" ></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12px" 
                                            Font-Underline="False" ForeColor="Red" Text="Data not found"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </Saifi:MyDg>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

