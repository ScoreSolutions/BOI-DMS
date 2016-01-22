<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterModuleFolder.aspx.vb" Inherits="WebApp_frmMasterModuleFolder" %>

<%@ Register src="../UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>

<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc2" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .style6
    {
        color: #000000;
        text-decoration: none;
        vertical-align: top;
        padding: 1px;
        font-style: normal;
        font-variant: normal;
        font-size: 20px;
        line-height: normal;
        font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
    }
    
    </style>
    <table style="width: 100%" class="style6">
        <tr>
            <td class="CssHead">
                ประเภทย่อยหนังสือ
            </td>
            <td align="right" class="style6">
                ค้นหา :
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        <tr>
            <td align="Right" class="style6">
                &nbsp;
            </td>
            <td align="left">
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="Right" class="style6" width="20%">
                เจ้าหน้าที่ :</td>
            <td width="80%" class="style6" align="left">
                <uc2:cmbComboBox ID="officer_id_owner" runat="server" Width="300" />
            </td>
        </tr>
        <tr>
            <td align="Right" class="style6">
                ชื่อโฟล์เดอร์ :
            </td>
            <td class="style6" align="left">
                <uc1:txtBox ID="folder_name" runat="server" IsNotNull="true" Width="300" />
            </td>
        </tr>
        <tr>
                    <td align="Right" class="style6">
                        รายละเอียด :
                    </td>
                    <td class="style6" align="left">
                        <uc1:txtBox ID="folder_desc" runat="server" IsNotNull="False" Width="500" />
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="style6">
                        คำอธิบาย :
                    </td>
                    <td class="style6" align="left">
                        <uc1:txtBox ID="folder_toolstip" runat="server" IsNotNull="False" Width="500" />
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="style6">
                        โฟล์เดอร์ Url :</td>
                    <td class="style6" align="left">
                <uc1:txtBox ID="folder_url" runat="server" IsNotNull="true" Width="300" />
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="style6">
                        โฟล์เดอร์อ้างอิง :</td>
                    <td class="style6" align="left">
                <uc1:txtBox ID="folder_ref_id" runat="server" IsNotNull="true" Width="100" 
                            TextKey="TextInt" />
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="style6">
                        ลำดับ :</td>
                    <td class="style6" align="left">
                <uc1:txtBox ID="order_seq" runat="server" IsNotNull="true" Width="100" 
                            TextKey="TextInt" />
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="style6">
                        ไอคอน :
                    </td>
                    <td class="style6" align="left">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="500px" CssClass="CssFileUpload" />
                    </td>
                </tr>
        <tr>
            <td align="Right" class="style6">
                &nbsp;
            </td>
            <td class="style6" align="left">
                <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
            </td>
        </tr>
        <tr>
            <td align="Right" class="style6">
                &nbsp;
            </td>
            <td class="style6" align="left">
                        <asp:Button ID="btnSave0" runat="server" CssClass="CssBtn" Text="เพิ่ม" 
                            Width="60px" />
                        <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" 
                            Width="60px" />
                        <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" 
                            Width="60px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                        <uc1:PageControl ID="pcTop" runat="server" />
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" 
                            DataKeyNames="id">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="15px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.png" 
                                    ShowDeleteButton="True">
                                <ItemStyle Width="16px" />
                                </asp:CommandField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" runat="server" Text='<%# bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="username" HeaderText="เจ้าหน้าที่">
                                    <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="folder_name" HeaderText="ชื่อโฟล์เดอร์ ">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="folder_desc" HeaderText="รายละเอียด">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="folder_toolstip" HeaderText="คำอธิบาย">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="ไอคอน" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" 
                                            
                                            
                                            ImageUrl='<%# ConfigurationManager.AppSettings("UploadURL").ToString() & Eval("folder_icon").ToString() %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="active" HeaderText="การใช้งาน" 
                                    ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:BoundField>
                            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                            <EmptyDataTemplate>
                                <table width="100%" border="1">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Visible="False" />

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        </asp:GridView>
                                </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    
    <asp:Panel ID="Panel6" runat="server" BorderColor="#3B5998" BorderStyle="Solid" Width="600px">
        <asp:Panel ID="Panel7" runat="server" Width="600">
            <table id="Table4" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        <b><span lang="TH">&nbsp; ยืนยันการลบ</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="Csslbl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="Csslbl">
                        <span>ต้องการลบ ใช่หรือไม่ ? </span></td>
                </tr>
                <tr>
                    <td align="center" class="style6" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnYes1" runat="server" CssClass="CssBtn" Text="ใช่" 
                            Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNo1" runat="server" CssClass="CssBtn" Text="ไม่ใช่" 
                            Width="80" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>   
    
    <asp:Panel ID="Panel9" runat="server" BorderColor="#3B5998" BorderStyle="Solid" Width="600px">
        <asp:Panel ID="Panel10" runat="server" Width="600">
            <table id="Table7" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
            cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        <b><span lang="TH">&nbsp;</span></b></td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton5" runat="server" 
                        ImageUrl="~/Images/closewindows.png" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="Csslbl">
                        <asp:Label ID="sys_msg" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Csslbl" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnYes3" runat="server" CssClass="CssBtn" Text="ปิด" 
                            Width="80" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Csslbl">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel> 
    
    <asp:Button ID="Button61" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <asp:Button ID="Button62" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    
    <asp:ModalPopupExtender ID="popup1" runat="server" PopupControlID="Panel6" 
        TargetControlID="Button61" DropShadow="False" BehaviorID="popup1">
    </asp:ModalPopupExtender>
    
    <asp:ModalPopupExtender ID="popup2" runat="server" PopupControlID="Panel9" 
        TargetControlID="Button62" DropShadow="False" BehaviorID="popup2">
    </asp:ModalPopupExtender>
</asp:Content>

