<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"    CodeFile="frmMasterOrganization.aspx.vb" Inherits="WebApp_frmMasterOrganization" %>

<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>    
    
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc4" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
        text-align: left;
    }
    
    .style7
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
        text-align: right;
    }
    .style9
    {
        width: 156px;
    }
</style>

    <table style="width: 100%">
        <tr>
            <td class="CssHead">
                &nbsp; หน่วยงาน</td>
            <td align="right" class="style7">
                ค้นหา :
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        </table>
        <table style="width:100%;">
                    <tr>
                        <td class="style7">
                            รหัสหน่วยงาน :
                        </td>
                        <td class="style6">
                <uc1:txtBox ID="org_code" runat="server" IsNotNull="false" 
                    Width ="200" />
                        </td>
                        <td class="style7">
                            &nbsp;</td>
                        <td class="style6">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            ชื่อหน่วยงาน :
                        </td>
                        <td class="style6">
                            <uc1:txtBox ID="org_name" runat="server" IsNotNull="false" Width ="300" />
                        </td>
                        <td class="style7">
                            ชนิดหน่วยงาน :</td>
                        <td class="style6">
                            <asp:DropDownList ID="type" runat="server" CssClass="style6" Width="150px" 
                                Height="24px" Font-Size="Large">
                                <asp:ListItem Value="0" Selected="True" >SECTOR</asp:ListItem>
                                <asp:ListItem Value="1">NON SECTOR</asp:ListItem>
                                <asp:ListItem Value="2">IC</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            ชื่อไทย :
                        </td>
                        <td class="style6">
                <uc1:txtBox ID="org_thai_name" runat="server" IsNotNull="false" Width ="300" />
                        </td>
                        <td class="style7">
                            ที่อยู่ภาษาไทย :</td>
                        <td class="style6">
                <uc1:txtBox ID="address_thai" runat="server" IsNotNull="false" Width ="300" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            ชื่ออังกฤษ :
                        </td>
                        <td class="style6">
                <uc1:txtBox ID="org_eng_name" runat="server" IsNotNull="false" Width ="300" />
                        </td>
                        <td class="style7">
                            ที่อยู่ภาษาอังกฤษ :</td>
                        <td class="style6">
                <uc1:txtBox ID="address_eng" runat="server" IsNotNull="false" Width ="300" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            ชื่อย่อ : </td>
                        <td class="style6">
                <uc1:txtBox ID="name_abb" runat="server" IsNotNull="false" Width ="200" />
                        </td>
                        <td class="style7">
                            เบอร์โทร :
                        </td>
                        <td class="style6">
                <uc1:txtBox ID="tel" runat="server" IsNotNull="false" Width ="200" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            กลุ่มหน่วยงาน : </td>
                        <td class="style6">
                            <uc2:cmbComboBox ID="organization_type_id" runat="server" />
                        </td>
                        <td class="style7">
                            เบอร์แฟกซ์ :
                        </td>
                        <td class="style6">
                <uc1:txtBox ID="fax" runat="server" IsNotNull="false" Width ="200" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            วันที่เริ่มใช้ :</td>
                        <td class="style6">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><uc3:txtDate ID="efdate" runat="server" /></td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;วันที่สิ้นสุด :&nbsp;</td>
                                    <td><uc3:txtDate ID="epdate" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                        <td class="style7">
                            อีเมล์ : 
                        </td>
                        <td class="style6">
                <uc1:txtBox ID="email" runat="server" IsNotNull="false" Width ="200" />
                        </td>
                    </tr>
                    <tr>
                        
                        <td class="style7">
                            รายละเอียด :
                        </td>
                        <td class="style6">
                            <uc1:txtBox ID="description" runat="server" IsNotNull="false" Width ="300" />
                        </td>
                        <td class="style7">ชื่อผู้บริหาร/ผอ. :</td>
                        <td class="style6"><uc4:cmbAutoComplete ID="cmbDirectorID" runat="server" Width="300" /> </td>
                    </tr>
                    <tr>
                        
                        <td class="style7">&nbsp;</td>
                        <td class="style6" colspan="3">
                            <asp:CheckBox ID="chkActive" runat="server" Checked="true" Text="ใช้งาน" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;</td>
                        <td class="style6">
                            &nbsp;</td>
                        <td class="style7">
                            &nbsp;</td>
                        <td class="style6">
                <uc1:txtBox ID="txtID" runat="server" Visible="False" Text="0" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
        <tr>
            <td class="style9">
                &nbsp;
            </td>
            <td class="style6">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px" />
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        </table>
        
        <table style="width: 100%">
        <tr>
            <td colspan="2">
                <uc1:PageControl ID="pcTop" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id">
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
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False">
                        <ItemStyle Width="0px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="org_code" HeaderText="รหัสหน่วยงาน" 
                            SortExpression="org_code" >
                        <ItemStyle HorizontalAlign="left" Width="150px" />
                        </asp:BoundField>
<asp:BoundField DataField="org_name" HeaderText="ชื่อ">
                        <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
                        <asp:BoundField DataField="name_abb" HeaderText="ชื่อย่อ">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"  ></HeaderStyle>
                        <HeaderStyle Font-Underline="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sector_type" HeaderText="ชนิดหน่วยงาน">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="email" HeaderText="E-mail">
                        <ItemStyle HorizontalAlign="Left" Width="150px" />
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
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                
      
    
            </td>
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
