<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnSendCircle2.ascx.vb"
    Inherits="UserControls_Button_btnSendCircle2"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtbox" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc1" %>

<asp:Button ID="btnButton1" runat="server" Text="       ส่งหนังสือเวียน " CssClass="btnSendCircle" />
<asp:Button ID="Button1" runat="server" CssClass="zHidden" Text="Button" 
    Width="0px" />
<asp:Button ID="Button4" runat="server" CssClass="zHidden" Text="Button" 
    Width="0px" />
<asp:Panel ID="Panel1" runat="server" Width="600">
    <table runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998">
                เลือกหน่วยงานส่ง
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                &nbsp;
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" 
                    ImageUrl="../../Images/closewindows.png" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl">
                กลุ่มหน่วยงาน
                <uc1:cmbComboBox ID="cmbComboBox1" runat="server" Width="300" />
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl" valign="top" width="45%">
                หน่วยงาน&nbsp;</td>
            <td align="center">
                &nbsp;</td>
            <td align="left" class="Csslbl" valign="top" width="45%">
                หน่วยงานที่รับหนังสือ</td>
        </tr>
        <tr>
            <td class="Csslbl" valign="top" width="45%">
                <asp:GridView ID="gvSendList" runat="server" AutoGenerateColumns="False" 
                    CssClass="GridViewStyle" Width="100%">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="cb1" runat="server" />
                            </HeaderTemplate>
                            <ItemStyle Width="5px" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cb2" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrgNameReceive" HeaderText="หน่วยงาน" 
                            SortExpression="OrgNameReceive">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
            <td align="center">
                <asp:Button ID="Button7" runat="server" CssClass="CssBtn" Text="&lt;&lt;" 
                    Width="30px" />
                <asp:Button ID="Button6" runat="server" CssClass="CssBtn" Text="&gt;&gt;" 
                    Width="30px" />
            </td>
            <td class="Csslbl" valign="top" width="45%">
                <asp:GridView ID="gvSelect" runat="server" AutoGenerateColumns="False" 
                    CssClass="GridViewStyle" Width="100%">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="cb3" runat="server" />
                            </HeaderTemplate>
                            <ItemStyle Width="5px" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cb4" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrgNameReceive" HeaderText="หน่วยงาน" 
                            SortExpression="OrgNameReceive">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="Csslbl">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="Csslbl" colspan="2">
                &nbsp;
            </td>
            <td align="right" class="Csslbl">
                <asp:Button ID="Button3" runat="server" CssClass="CssBtn" Text="ส่ง" 
                    Width="80" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="CssBtn" Text="ยกเลิก" 
                    Width="80" />
            </td>
        </tr>
        <tr>
            <td class="Csslbl">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
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
            <td align="left" bgcolor="#3B5998">
                ส่งหนังสือเรียบร้อยแล้ว
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="../../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl">
                ส่งหนังสือเวียนเรียบร้อยแล้ว หนังสือต้นฉบับเลขที่
                <asp:Label ID="lblno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Csslbl" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="GridViewStyle" Width="100%">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField DataField="OrgNameReceive" HeaderText="เลขที่หนังสือเวียน" 
                            SortExpression="OrgNameReceive">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StaffNameReceive" HeaderText="หน่วยงาน" 
                            SortExpression="StaffNameReceive">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="Csslbl">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="Csslbl" colspan="2">
                <asp:Button ID="Button5" runat="server" CssClass="CssBtn" Text="ตกลง" 
                    Width="80" />
            </td>
        </tr>
        <tr>
            <td class="Csslbl">
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

