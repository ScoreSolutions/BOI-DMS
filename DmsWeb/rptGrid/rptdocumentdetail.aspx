<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false" CodeFile="rptdocumentdetail.aspx.vb" Inherits="rptGrid_rptdocumentdetail" %>


<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width:80px;">
                &nbsp;</td>
            <td style="width:400px; height:35px; vertical-align:middle; padding-left:80px;" class="CssHead"  >
                รายละเอียดหนังสือ</td>
            <td style="width:120px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:80px;">
                &nbsp;</td>
            <td style="width:800px; padding-left:50px;">
                <table style="width:100%;" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td class="tabellabel">
                        
                            &nbsp;</td>
                        <td class="tabellabelinfo">
                            &nbsp;</td>
                        <td class="tabellabel">
                            &nbsp;</td>
                        <td class="tabellabelinfo">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                        
                            เลขที่หนังสือ :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_book_no" runat="server"></asp:Label>
                            </td>
                        <td class="tabellabel">
                            วันที่ลงทะเบียน :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_register_date" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                            คำขอ :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_request_no" runat="server"></asp:Label>
                            </td>
                        <td class="tabellabel" >
                             เลขที่หนังสือองค์กร :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_company_doc_no" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                            ลงวันที :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_company_doc_date" runat="server"></asp:Label>
                            </td>
                        <td class="tabellabel">
                            อ้างถึง :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_company" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                กลุ่มเรื่อง:</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_group_title_name" runat="server"></asp:Label>
                            </td>
                        <td class="tabellabel">
                            ประเภทกิจการ :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_business_type" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                เรื่อง :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_title_name" runat="server"></asp:Label>
                        </td>
                        <td class="tabellabel">
                            หน่วยงาน :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_organization_name" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                            ผู้ลงนาม :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_company_sign" runat="server"></asp:Label>
                            </td>
                        <td class="tabellabel">
                            หมายเหตุ :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_remarks" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                กองเจ้าของเรื่อง :
            </td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_organization_appname" runat="server"></asp:Label>
                        </td>
                        <td class="tabellabel">
                            เจ้าหน้าที่ผู้พิจารณา :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_officer_name" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                เลขที่หนังสือส่งออก :</td>
                        <td colspan="3" class="tabellabelinfo">
                            <asp:Label ID="lbl_book_no6" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                            กำหนดออก : </td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_expect_finish_date" runat="server"></asp:Label>
                           </td>
                        <td class="tabellabel">
                            วันที่ปิดงาน :</td>
                        <td class="tabellabelinfo">
                            <asp:Label ID="lbl_close_date" runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="tabellabel">
                            สถานะหนังสือ</td>
                        <td class="tabellabelinfo"> 
                            <asp:Label ID="lbl_doc_status_name" runat="server"></asp:Label>
                            </td>
                        <td class="tabellabel">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td style="width:120px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:120px;">
                &nbsp;</td>
            <td style="width:400px;">
                <asp:Label ID="lbl_result" CssClass="celllabel" runat="server"></asp:Label>
            </td>
            <td style="width:120px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:120px;">
                &nbsp;</td>
            <td style="width:400px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <Saifi:MyDg ID="dgvdetail" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" ImageFirst="/imgs/nav_left.gif" 
                            ImageLast="/imgs/nav_right.gif" ImageNext="/imgs/bulletr.gif" 
                            ImagePrevious="/imgs/bulletl.gif" ShowFirstAndLastImage="False" 
                            ShowPreviousAndNextImage="False" Width="800px">
                            <PagerStyle Mode="NumericPages" />
                            <HeaderStyle BackColor="#6699FF" HorizontalAlign="Center" Font-Size="14px" Height="30px"
                                BorderColor="#91a7b4" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BackColor="#ffffff" Font-Size="12px" Height="25px" BorderColor="#91a7b4"
                                BorderStyle="Solid" BorderWidth="1px" />
                            <AlternatingItemStyle BackColor="#ffffff" Font-Size="12px" Height="25px" BorderColor="#91a7b4"
                                BorderStyle="Solid" BorderWidth="1px" />
                            <FooterStyle BackColor="#ffffff" Font-Size="12px" Height="25px" BorderColor="#91a7b4"
                                BorderStyle="Solid" BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateColumn  HeaderText="ที่"  >
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id" runat="server" Width="30px" style="text-align:center;" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"id") %>' ></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="เจ้าหน้าที่รับ" >
                                    <ItemTemplate >
                                        <asp:Label ID="lbl_receiver_officer_fullname" style="text-align:left; padding-left:5px;"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"receiver_officer_fullname") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate >
                                    
                                    <FooterTemplate>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12px" 
                                            Font-Underline="False" ForeColor="Red" Text="Data not found"></asp:Label>
                                    </FooterTemplate>
                                    
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="กองรับ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_organization_name_receive"  style="text-align:left; padding-left:5px;"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"organization_name_receive") %>'
                                                        Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="วันที่รับ"> 
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_receive_date"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"receive_date","{0:dd/MM/yyyy}") %>'
                                                        Width="100px" style="text-align:center;" ></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="จนท.ส่ง">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sender_officer_fullname"  style="text-align:left; padding-left:5px;"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"sender_officer_fullname") %>'
                                                        Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="กองส่ง">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_organization_name_send"  style="text-align:left; padding-left:5px;"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"organization_name_send") %>'
                                                        Width="150px"></asp:Label>
                                    </ItemTemplate>
                                  
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="วันที่ส่ง">
                                    <ItemTemplate>
                                       <asp:Label ID="lbl_send_date"  style="text-align:center;"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"send_date","{0:dd/MM/yyyy}") %>'
                                                        Width="100px"></asp:Label>
                                    </ItemTemplate>
                                   
                                </asp:TemplateColumn>
                                <asp:TemplateColumn  HeaderText="หมายเหตุ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_remarks"  style="text-align:left; padding-left:5px;"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"remarks") %>'
                                                        Width="150px"></asp:Label>
                                    </ItemTemplate>
                                   
                                </asp:TemplateColumn>
                            </Columns>
                        </Saifi:MyDg>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width:120px;">
                &nbsp;</td>
        </tr>
    </table>
   
    
</asp:Content>










