<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Template/ReportMasterPage.master"  CodeFile="rptsector_by_emp.aspx.vb" Inherits="rptGrid_rptsector_by_emp" %>

<%@ Register assembly="MycustomDG" namespace="MycustomDG" tagprefix="Saifi" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                รายงานคงค้างรายบุคคล</td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                <asp:Label ID="lbl_organizename" runat="server" ></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td align="center" class="CssHead">
                เจ้าหน้าที่                 <asp:Label ID="lbl_officername" runat="server" ></asp:Label>
                        </td>
        </tr>
        
        <tr>
            <td align="center" class="CssHead">
                ณ วันที่ 
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style=" height:30px;" class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblDesc" runat="server"></asp:Label>
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:1200px;" border="0" cellpadding="0" cellspacing="0"  >
                            <tr>
                                <td  class="grid_Header" 
                                    style="width:30px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " 
                                    rowspan="2" >
                                    ลำดับ</td>
                                <td class="grid_Header" 
                                    style="width:100px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;" 
                                    rowspan="2" >
                                    ทะเบียน</td>
                                <td class="grid_Header" 
                                    
                                    style="width:100px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " 
                                    rowspan="2">
                                    วันที่ลงทะเบียน</td>
                                <td class="grid_Header" 
                                    
                                    style="width:100px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; " 
                                    rowspan="2" >
                                    ครบกำหนด
                                    <br />
                                    สนง.</td>
                                <td class="grid_Header" 
                                    
                                    style="width:150px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;" 
                                    rowspan="2">
                                    บริษัท</td>
                                <td class="grid_Header" 
                                    
                                    style="width:100px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;" 
                                    rowspan="2">
                                    วันที่รับ<br />
                                    <asp:Label ID="lblOrgAbb" runat="server"></asp:Label>
                                </td>
                                <td class="grid_Header" 
                                    
                                    style="width:150px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;" 
                                    rowspan="2">
                                    ผู้พิจารณา</td>
                                <td class="grid_Header" 
                                    
                                    style="width:100px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;" 
                                    rowspan="2">
                                    เกินกำหนด</td>
                                <td class="grid_Header"  colspan="6" 
                                    style="width:150px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    </td>
                                <td class="grid_Header" colspan="3" 
                                    style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; border-right: #91a7b4 1px solid;">
                                    </td>
                                <td class="grid_Header" 
                                    
                                    style="border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; border-right: #91a7b4 1px solid;" 
                                    rowspan="2">
                                    กำหนดวันแล้วเสร็จ</td>    
                                
                            </tr>
                            <tr>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    รอข้อมูล</td>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    กำลังรอพิจารณา</td>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    รออนุมัติ</td>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    รอประชุม</td>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    รอนโยบาย</td>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    อื่นๆ (ระบุ)</td>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; ">
                                    ออกหนังสือ</td>
                                <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; border-right: #91a7b4 1px solid; ">
                                    ให้มาชี้แจง</td>
                                    
                                    <td class="grid_Header" 
                                    style="width:50px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid; border-right: #91a7b4 1px solid; ">
                                    อื่นๆ ระบุ</td>
                            </tr>
                        </table>
                        <asp:DataList ID="DataList1" runat="server" Width="1206px">
                            <ItemTemplate>
                                <table style="width: 1200px;" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="celllabel" style="background-color: #FFFBD6;">
                                            <asp:Label ID="lbl_group_title_name" runat="server" Text='<%# Bind("group_title_name") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <Saifi:MyDg ID="dgvdetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                ImageFirst="/imgs/nav_left.gif" ImageLast="/imgs/nav_right.gif" ImageNext="/imgs/bulletr.gif"
                                                ImagePrevious="/imgs/bulletl.gif" ShowFirstAndLastImage="False" ShowPreviousAndNextImage="False"
                                                ShowHeader="False" onitemcreated="dgvdetail_ItemCreated" >
                                                <PagerStyle Mode="NumericPages" />
                                                <ItemStyle CssClass="grid_Item" />
                                                <AlternatingItemStyle CssClass="grid_AlternatingItem" />
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="ลำดับ" ItemStyle-Width="30px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_no" runat="server" Style="text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30px" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ทะเบียน" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                             <asp:LinkButton ID="lbl_book_no" runat="server"  
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"book_no") %>' 
                                                                ForeColor="Blue" Font-Underline="true" 
                                                                PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "document_register_id", "../WebApp/frmDocBookDetailShow.aspx?id={0}") %>' ></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="วันที่ลงทะเบียน" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_register_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"register_date","{0:dd/MM/yyyy}") %>'
                                                                Style="text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ครบกำหนด" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_expect_finish_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"expect_finish_date","{0:dd/MM/yyyy}") %>'
                                                                Style="text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="บริษัท" ItemStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_company_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"company_name") %>'
                                                                Style="text-align: left;"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="150px" />
                                                    </asp:TemplateColumn>
                                                     <asp:TemplateColumn HeaderText="วันที่รับ" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_close_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"close_date","{0:dd/MM/yyyy}") %>'
                                                                Style="text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                         <ItemStyle Width="100px" />
                                                    </asp:TemplateColumn>
                                                     <asp:TemplateColumn HeaderText="ผู้พิจารณา" ItemStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_officer_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"officer_name") %>'
                                                                Style="text-align: left;"></asp:Label>
                                                        </ItemTemplate>
                                                         <ItemStyle Width="150px" />
                                                    </asp:TemplateColumn>
                                                     <asp:TemplateColumn HeaderText="เกินกำหนด" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_overdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"overdue") %>'
                                                                Style="text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                         <ItemStyle Width="100px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    <asp:TemplateColumn HeaderText="รอข้อมูล" ItemStyle-Width="50px">
                                                              <ItemTemplate>
                                                            <asp:Label ID="aa" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    <asp:TemplateColumn HeaderText="กำลังพิจารณา" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="bb" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    <asp:TemplateColumn HeaderText="รออนุมัติ" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="cc" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    
                                                    
                                                    <asp:TemplateColumn HeaderText="รอประชุม" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="dd" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    
                                                    <asp:TemplateColumn HeaderText="รอนโยบาย" ItemStyle-Width="50px">
                                                       <ItemTemplate>
                                                            <asp:Label ID="ee" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    
                                                    <asp:TemplateColumn HeaderText="อื่นๆ ระบุ" ItemStyle-Width="50px">
                                                        
                                                        <ItemTemplate>
                                                            <asp:Label ID="ff" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    <asp:TemplateColumn HeaderText="แก้ไขได้เสร็จวันที่" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gg" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateColumn>
                                                    
                                                    
                                                    <asp:TemplateColumn HeaderText="กองแก้ไขไม่ได้" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="hh" runat="server" ></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
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

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    </asp:Content>


