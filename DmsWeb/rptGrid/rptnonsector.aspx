<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptnonsector.aspx.vb" Inherits="rptGrid_rptnonsector" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                รายงานงานค้าง (Non Sector) </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organizename" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                ณ วันที่ 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="celllabel" align="center" >
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataList ID="DataList1" runat="server" Width="1078px" >
                            <ItemTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td class="celllabel" style="background-color:#FFFBD6;">
                                            <asp:Label ID="lbl_group_title_name" runat="server" 
                                                Text='<%# Bind("group_title_name") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <Saifi:MyDg ID="dgvdetail" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" ImageFirst="/imgs/nav_left.gif" 
                                        ImageLast="/imgs/nav_right.gif" ImageNext="/imgs/bulletr.gif" 
                                        ImagePrevious="/imgs/bulletl.gif" ShowFirstAndLastImage="False" 
                                        ShowPreviousAndNextImage="False" Width="890px" 
                                                onitemcreated="dgvdetail_ItemCreated" OnItemDataBound="dgvdetail_ItemDataBound" >
                                                <PagerStyle Mode="NumericPages" />
                                                <ItemStyle CssClass="grid_Item" />
                                                <AlternatingItemStyle  CssClass="grid_AlternatingItem" />
                                                <HeaderStyle CssClass="grid_Header" />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="ลำดับ" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_no" runat="server" Width="40px" style="text-align:center;" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ทะเบียน">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBookNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"book_no") %>' Width="100px"  ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="วันที่ลงทะเบียน">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_register_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"register_date","{0:dd/MM/yyyy}") %>'
                                                        Width="100px" style="text-align:center"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ครบกำหนด">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_expect_finish_dateo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"due_date","{0:dd/MM/yyyy}") %>'
                                                        Width="100px" style="text-align:center"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="บริษัท">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_company_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"company_name") %>'
                                                        Width="120px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="เรื่อง">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_title_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"title_name") %>'
                                                        Width="300px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="กอง ถือครอง">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_organization_appname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"organization_abbname_process") %>'
                                                        Width="120px" style="text-align:center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="จนท.ถือครอง">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_officer_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"officer_name_possess") %>'
                                                        Width="120px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="เกินกำหนด">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_over_date" runat="server" 
                                                        Width="70px" style="text-align:center; padding-right:5px;"></asp:Label>
                                                        </ItemTemplate >
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ผู้พิจารณา">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_officer_app_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"officer_name") %>'
                                                        Width="120px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="หมายเหตุ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_remark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"remarks") %>'
                                                        Width="120px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="document_register_id">
                                                        <FooterStyle CssClass="zHidden" />
                                                        <HeaderStyle CssClass="zHidden />
                                                        <ItemStyle CssClass="zHidden" />
                                                    </asp:BoundColumn>
                                                </Columns>
                                            </Saifi:MyDg>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
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

