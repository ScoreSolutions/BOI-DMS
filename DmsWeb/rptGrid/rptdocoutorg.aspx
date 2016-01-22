<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptdocoutorg.aspx.vb" Inherits="rptGrid_rptdocoutorg" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />

    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead" width="100%" >
                รายงานสรุปเอกสารที่ส่งออกนอกสำนักงาน</td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                ระหว่างวันที่ 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
&nbsp;ถึง
                <asp:Label ID="lbl_todt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Panel ID="Panel1" runat="server" >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <Saifi:MyDg ID="dgvdetail" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" ImageFirst="/imgs/nav_left.gif" 
                            ImageLast="/imgs/nav_right.gif" ImageNext="/imgs/bulletr.gif" 
                            ImagePrevious="/imgs/bulletl.gif" onitemcreated="dgvdetail_ItemCreated" 
                            ShowFirstAndLastImage="False" ShowPreviousAndNextImage="False" 
                            Width="100%">
                                <PagerStyle Mode="NumericPages" />
                                <ItemStyle CssClass="grid_Item" />
                                <AlternatingItemStyle CssClass="grid_AlternatingItem" />
                                <HeaderStyle CssClass="grid_Header" />
                                <Columns>
                                    <asp:TemplateColumn HeaderText="ที่">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_no" runat="server" style="text-align:center;" Width="20px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="เลขที่หนังสือ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_bookout_no" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"bookout_no") %>' 
                                            Width="90px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="วันที่หนังสือออก">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_send_date" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"send_date","{0:dd/MM/yyyy}") %>' 
                                            Width="90px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="บริษัท">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_company_name" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"company_name_receive") %>' Width="150px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="เรื่องที่ลงรับ ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_title_name" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"title_name") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="เลขที่<br />หนังสือรับ" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"book_no") %>' Width="60px"  ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="สถานะ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_doc_status_name" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"doc_status_name") %>' 
                                            Width="40px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="รายชื่อคนรับและวันที่รับเอกสาร">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_company_name_receive" runat="server" 
                                            style="text-align:center" 
                                            Text='' 
                                            Width="80px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="document_register_id">
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Saifi:MyDg>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
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
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

