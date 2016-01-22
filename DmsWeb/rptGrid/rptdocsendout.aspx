<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptdocsendout.aspx.vb" Inherits="rptGrid_rptdocsendout" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                เรื่องออก
                <asp:Label ID="lbl_organizename" runat="server"></asp:Label>
                        </td>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="padding-left:100px; height:30px;" class="celllabel">
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
                            ImagePrevious="/imgs/bulletl.gif" onitemcreated="dgvdetail_ItemCreated" 
                            ShowFirstAndLastImage="False" ShowPreviousAndNextImage="False" Width="100%">
                            <PagerStyle Mode="NumericPages" />
                            <ItemStyle CssClass="grid_Item" />
                            <AlternatingItemStyle CssClass="grid_AlternatingItem" />
                            <HeaderStyle CssClass="grid_Header" />
                            <Columns>
                                <asp:TemplateColumn HeaderText="ที่">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_no" runat="server" style="text-align:center;" Width="40px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="เลขที่หนังสือ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"book_no") %>' Width="100px" ForeColor="Blue"  ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="เรื่อง">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_title_name" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"title_name") %>' Width="300px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="หน่วยงาน">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_org_name" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"company_name") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="เลขที่หนังสือองค์กร ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_company_doc_no" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"company_doc_no") %>' 
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="กองเจ้าของเรื่อง">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_organization_appname" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"organization_name") %>' 
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="วันที่ลงทะเบียน">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_register_date" runat="server" style="text-align:center;" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"register_date","{0:dd/MM/yyyy}") %>' 
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="สถานะ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_doc_status_name" runat="server" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"doc_status_name") %>' 
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="วันที่ครบกำหนด">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_expect_finish_dateo" runat="server" 
                                            style="text-align:center" 
                                            Text='<%# DataBinder.Eval(Container.DataItem,"expect_finish_date","{0:dd/MM/yyyy}") %>' 
                                            Width="100px"></asp:Label>
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

