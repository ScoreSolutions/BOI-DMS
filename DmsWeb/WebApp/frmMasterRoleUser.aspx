<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterRoleUser.aspx.vb" Inherits="WebApp_frmMasterRoleUser" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" style="width: 100%">
        <tr>
            <td class="CssHead" colspan="3" align="left" >กำหนดผู้ใช้งาน :&nbsp;
                <asp:Label ID="lblRoleName" runat="server"></asp:Label>
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td class="CssHead">
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="10%" class="Csslbl" >&nbsp;&nbsp;หน่วยงาน :</td>
                        <td width="90%" align="left" >
                            <asp:DropDownList ID="cmbOrgID" runat="server" CssClass="zComboBox" Width="300px" AutoPostBack="true" >
                            </asp:DropDownList>
                            <font color="red">*</font>
                            <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmbOrgID" PromptText=""
                                PromptCssClass="zComboBox" PromptPosition="Top" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                            <cc1:CascadingDropDown ID="cdlOwnerOrgID" runat="server" TargetControlID="cmbOrgID"
                                Category="OrgOwner" PromptText="เลือก" 
                                ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetOrgIDForDDL" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" width="45%" class="Csslbl">เจ้าหน้าที่ทั้งหมด&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td align="left" valign="top" width="45%" class="Csslbl">เจ้าหน้าที่ที่มีสิทธิ์</td>
        </tr>
        <tr>
            <td  valign="top" width="45%" class="Csslbl">
                <div style="overflow:scroll;height:400px;overflow-x:hidden;"  >
                    <asp:GridView ID="gvNoSeleteList" runat="server" AutoGenerateColumns="False" Width="100%">
                        <RowStyle CssClass="RowStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cbAll" runat="server" OnCheckedChanged="cbAll_OnCheckedChanged" AutoPostBack="true" />
                                </HeaderTemplate>
                                <ItemStyle Width="5px" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="staff_name" HeaderText="ชื่อ-สกุล" >
                                <HeaderStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="username" >
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle HorizontalAlign="Left" CssClass="zHidden"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="org_name" HeaderText="หน่วยงาน" >
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                 </div>
            </td>
            <td align="center">
                <asp:Button ID="btnSelect" runat="server" CssClass="CssBtn" Text="&gt;&gt;" Width="30px" />
                <br /><br /><br />
                <asp:Button ID="btnNoSelect" runat="server" CssClass="CssBtn" Text="&lt;&lt;" Width="30px" />
            </td>
            <td class="Csslbl" valign="top" width="45%">
                <div style="overflow:scroll;height:400px;overflow-x:hidden;"  >
                    <asp:GridView ID="gvSelected" runat="server" AutoGenerateColumns="False" Width="100%">
                        <RowStyle CssClass="RowStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cbAll" runat="server" OnCheckedChanged="cbAll_OnCheckedChanged" AutoPostBack="true" />
                                </HeaderTemplate>
                                <ItemStyle Width="5px" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="staff_name" HeaderText="ชื่อ-สกุล" >
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="username" >
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle HorizontalAlign="Left" CssClass="zHidden"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="org_name" HeaderText="หน่วยงาน" >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left"  />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

