<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"    CodeFile="frmMasterCompanyType.aspx.vb" Inherits="WebApp_frmMasterCompanyType" %>

<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>    
    
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc2" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <table style="width: 100%">
        <tr>
            <td class="CssHead">
                <span lang="TH">�����Ż������Ԩ���</span></td>
            <td align="right" class="Csslbl">
                ���� :
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <uc1:txtBox ID="txtID" runat="server" Visible="False" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">
                ����<span lang="TH">�������Ԩ���</span> :
            </td>
            <td align="left" width="80%" class="Csslbl">
                <uc1:txtBox ID="txtCode" runat="server" IsNotNull="true" MaxLength="3" 
                    Width ="50" TextKey="TextDouble" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                ����<span lang="TH">�������Ԩ���</span> :
            </td>
            <td align="left" class="Csslbl">
                <uc1:txtBox ID="txtName" runat="server" IsNotNull="true" Width ="300" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">
                &nbsp;
            </td>
            <td align="left" class="Csslbl">
                <asp:CheckBox ID="chkActive" runat="server" Text="��ҹ" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="left" class="Csslbl">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="�ѹ�֡" CssClass="CssBtn" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="¡��ԡ" CssClass="CssBtn" Width="60px" />
            </td>
        </tr>
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
                                    ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="���" />
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
                        <asp:BoundField DataField="business_type_code" HeaderText="����">
                            <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="business_type_name" HeaderText="����" 
                            SortExpression="company_type_name" >
                            <HeaderStyle Width="450px" CssClass="t_headsort" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="��ҹ"  >
                            <HeaderStyle Width="50px" CssClass="t_headsort" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="pgr"></PagerStyle>
                    <EmptyDataTemplate>
                        <table width="100%" border="1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***��辺������***"></asp:Label>
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
                        <b><span lang="TH">&nbsp; �׹�ѹ���ź</span></b></td>
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
                        <span>��ͧ���ź ��������� ? </span></td>
                </tr>
                <tr>
                    <td align="center" class="style6" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnYes1" runat="server" CssClass="CssBtn" Text="��" 
                            Width="80" />
                        &nbsp;
                        <asp:Button ID="btnNo1" runat="server" CssClass="CssBtn" Text="�����" 
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
                        <asp:Button ID="btnYes3" runat="server" CssClass="CssBtn" Text="�Դ" 
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
