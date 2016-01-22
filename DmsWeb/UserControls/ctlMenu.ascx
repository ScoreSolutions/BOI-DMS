<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMenu.ascx.vb" Inherits="UserControls_ctlMenu" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="PageControl.ascx" tagname="pagecontrol" tagprefix="uc1" %>
<%@ Register src="txtBox.ascx" tagname="txtbox" tagprefix="uc1" %>
<%@ Register Src="cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc2" %>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/menu.gif"
    ImageAlign="AbsMiddle" />
&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Label ID="lblCaption" runat="server" CssClass="CssHead" Text="เมนู"></asp:Label>
<asp:Panel ID="Panel1" runat="server" Width="850" Height ="500" ScrollBars ="Auto" >


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate >

    <table id="Table1" width="850" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998">
                เมนู
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td class="CssHead">
                &nbsp;
            </td>
            <td align="right" class="Csslbl">
                ค้นหา :
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
         <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtID" runat="server" Text="0" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" width="20%">
                        รหัสเมนู :
                    </td>
                    <td width="80%" class="Csslbl">
                        <uc1:txtbox ID="txtCode" runat="server" IsNotNull="true" MaxLength="4" Width="50"
                            TextKey="TextDouble" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" width="20%">
                        ลำดับที่ : 
                    </td>
                    <td width="80%" class="Csslbl">
                        <uc1:txtbox ID="txtOrder" runat="server" IsNotNull="true" MaxLength="2" 
                            TextKey="TextDouble" Width="50" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        เมนู :
                    </td>
                    <td class="Csslbl">
                        <uc2:cmbComboBox ID="cmbModule" runat="server" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        ชื่อเมนู :
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtName" runat="server" IsNotNull="true" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        รายละเอียด :
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtDescription" runat="server" IsNotNull="true" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        คำอธิบาย :
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtTooltip" runat="server" IsNotNull="true" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        Url :
                    </td>
                    <td class="Csslbl">
                        <uc1:txtbox ID="txtUrl" runat="server" IsNotNull="true" Width="400" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                        ไอคอน :
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" CssClass="CssFileUpload" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl">
                    </td>
                    <td class="Csslbl">
                        <asp:CheckBox ID="chkActive" runat="server" CssClass="Csslbl" Text="ใช้งาน" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="Csslbl">
                        <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <uc1:pagecontrol ID="pcTop" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" PageSize="20" CssClass="mGrid" PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="menu_code" HeaderText="รหัส" SortExpression="menu_code">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" ></ItemStyle>
                                    <HeaderStyle Width="30px" HorizontalAlign="Center" Font-Underline="True"></HeaderStyle>
                                </asp:BoundField>
                                 <asp:BoundField DataField="module_name" HeaderText="โมดูล" SortExpression="module_name">
                                    <HeaderStyle Width="100px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_name" HeaderText="เมนู" SortExpression="menu_name">
                                    <HeaderStyle Width="100px"  Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_desc" HeaderText="รายละเอียด" SortExpression="menu_desc">
                                    <HeaderStyle Width="100px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_toolstip" HeaderText="คำอธิบาย" SortExpression="menu_toolstip">
                                    <HeaderStyle Width="100px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="menu_url" HeaderText="Url" SortExpression="menu_url">
                                    <HeaderStyle Width="100px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="order_seq" HeaderText="ลำดับ" SortExpression="order_seq">
                                    <HeaderStyle Width="30px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="ไอคอน" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#ConfigurationManager.AppSettings("UploadURL").ToString() & Eval("menu_icon").ToString() %>' />
                                    </ItemTemplate>
                                    
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="active" HeaderText="การใช้งาน" ItemStyle-HorizontalAlign="Center" SortExpression="active">
                                    <HeaderStyle Width="50px" Font-Underline="True" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="15px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" Visible="false">
                                    <ItemStyle Width="15px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            ImageUrl="~/Images/Delete.png" Text="Delete" ToolTip="ลบ" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
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
                        </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
    </table>
    </ContentTemplate>
      <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
                </asp:UpdatePanel>
</asp:Panel>
