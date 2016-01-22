<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnSendCircle.ascx.vb"
    Inherits="UserControls_Button_btnSendCircle"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtbox" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc1" %>

<asp:Button ID="btnButton1" runat="server" Text="ส่งหนังสือเวียน " CssClass="CssBtn" />
<asp:Button ID="Button1" runat="server" CssClass="zHidden" Text="Button" Width="0px" />
<asp:Button ID="Button4" runat="server" CssClass="zHidden" Text="Button" Width="0px" />
    
    
<asp:Panel ID="Panel1" runat="server" Width="750" >
    <table runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="100%">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="cssHead">
                เลือกหน่วยงานส่ง
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                &nbsp;
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" 
                    ImageUrl="../Images/closewindows.png" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" >
                &nbsp;
            </td>
        </tr>
        <%--<tr >
            <td align="left" >
                กลุ่มหน่วยงาน
                <uc1:cmbComboBox ID="cmbOrgGroupID" runat="server" Width="300" AutoPosBack="true" />
            </td>
        </tr>--%>
        <tr>
            <td align="left" valign="top" width="45%">หน่วยงาน&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td align="left" valign="top" width="45%">หน่วยงานที่รับหนังสือ</td>
        </tr>
        <tr>
            <td  valign="top" width="45%">
                <div style="overflow:scroll;height:400px"  >
                    <asp:GridView ID="gvNoSeleteList" runat="server" AutoGenerateColumns="False" Width="100%">
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
                            <asp:BoundField DataField="org_name" HeaderText="หน่วยงาน" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id" >
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle HorizontalAlign="Left" CssClass="zHidden"/>
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
                <div style="overflow:scroll;height:400px"  >
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
                            <asp:BoundField DataField="org_name" HeaderText="หน่วยงาน" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id" >
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle HorizontalAlign="Left" CssClass="zHidden"/>
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;
            </td>
            <td align="right" >
                <asp:Button ID="btnSend" runat="server" CssClass="CssBtn" Text="ส่ง" Width="80" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="CssBtn" Text="ยกเลิก" Width="80" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<cc1:ModalPopupExtender ID="zPop" runat="server" 
    BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="Panel1" 
    TargetControlID="Button1">
</cc1:ModalPopupExtender>


<asp:Panel ID="Panel2" runat="server" Width="600">
    <table ID="Table1" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="cssHead">
                ส่งหนังสือเรียบร้อยแล้ว
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="left" >
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                ส่งหนังสือเวียนเรียบร้อยแล้ว หนังสือต้นฉบับเลขที่
                <asp:Label ID="lblBookNo" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <div style="overflow:scroll;height:400px"  >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                        <RowStyle CssClass="RowStyle" />
                        <Columns>
                            <asp:BoundField DataField="book_no" HeaderText="เลขที่หนังสือเวียน" HtmlEncode="false" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OrgNameReceive" HeaderText="หน่วยงาน" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                 </div>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnOK" runat="server" CssClass="CssBtn" Text="ตกลง" Width="80" />
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>
<cc1:ModalPopupExtender ID="zPop2" runat="server" 
    BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="Panel2" 
    TargetControlID="Button4">
</cc1:ModalPopupExtender>

