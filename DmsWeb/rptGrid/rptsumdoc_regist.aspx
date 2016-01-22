<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/Template/ReportMasterPage.master"  CodeFile="rptsumdoc_regist.aspx.vb" Inherits="rptGrid_rptsumdoc_regist" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="style1">
                ����ͧŧ����¹</td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organize" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                �����ҧ�ѹ��� 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
&nbsp;�֧
                <asp:Label ID="lbl_todt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left:100px;" class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <table style="width:100%;" border="1" cellpadding="0" cellspacing="0"  >
                    <tr>
                        <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                            ���</td>
                        <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; "  >
                            �Ţ���˹ѧ���</td>
                        <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                            ����ͧ</td>
                        <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                            ˹��§ҹ</td>
                        <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                            �Ţ���˹ѧ���ͧ���</td>
                         <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                             �ͧ��Ңͧ����ͧ</td>
                         <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                             �ѹ���ŧ����¹</td>
                         <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                             ʶҹ�</td>
                         <td class="grid_Header" style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " >
                             �ѹ���ú��˹�</td>
                    </tr>
                    <asp:Label ID="lblDesc" runat="server" ></asp:Label>
                </table>
                
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataList ID="DataList1" runat="server" Width="1078px">
                            <ItemTemplate>
                                <table border="0">
                                    <tr>
                                        <td class="celllabel" style="background-color:#FFFBD6;">
                                            <asp:Label ID="lbl_group_title_name" runat="server" Text='<%# Bind("group_title_name") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        <Saifi:MyDg ID="dgvdetail" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" ImageFirst="/imgs/nav_left.gif" 
                                        ImageLast="/imgs/nav_right.gif" ImageNext="/imgs/bulletr.gif" 
                                        ImagePrevious="/imgs/bulletl.gif" ShowFirstAndLastImage="False" 
                                        ShowPreviousAndNextImage="False" Width="890px" 
                                                onitemcreated="dgvdetail_ItemCreated" >

                                                <PagerStyle Mode="NumericPages" />
                                                <ItemStyle CssClass="grid_Item" />
                                                <AlternatingItemStyle  CssClass="grid_AlternatingItem" />
                                                <HeaderStyle CssClass="grid_Header" />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="���" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_no" runat="server" Width="40px" style="text-align:center;" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="�Ţ���˹ѧ���">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbl_book_no" runat="server"  
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"book_no") %>' Width="100px" 
                                                                ForeColor="Blue" Font-Underline="true" 
                                                                PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "document_register_id", "../WebApp/frmDocBookDetailShow.aspx?id={0}") %>' ></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="����ͧ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_title_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"title_name") %>'
                                                        Width="300px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="˹��§ҹ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_company_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"company_name") %>'
                                                        Width="150px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn HeaderText="�Ţ���˹ѧ���ͧ���" DataField="company_doc_no" HeaderStyle-Width="100px" >
                                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                        <ItemStyle  HorizontalAlign="Left" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="�ͧ��Ңͧ����ͧ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_organization_appname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"organization_name") %>'
                                                        Width="100px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="�ѹ���ŧ����¹">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_register_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"register_date","{0:dd/MM/yyyy}") %>'
                                                        Width="100px" style="text-align:center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ʶҹ�">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_doc_status_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"doc_status_name") %>'
                                                        Width="100px"></asp:Label>
                                                        </ItemTemplate>                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="�ѹ���ú��˹�">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_expect_finish_dateo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"expect_finish_date","{0:dd/MM/yyyy}") %>'
                                                        Width="100px" style="text-align:center"></asp:Label>
                                                        </ItemTemplate >
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </Saifi:MyDg>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </ContentTemplate>
                
                </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
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
            height: 32px;
        }
    </style>

</asp:Content>
