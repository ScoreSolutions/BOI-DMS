<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnSendInside.ascx.vb"
    Inherits="UserControls_Button_btnSendInside"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtbox" TagPrefix="uc4" %>

<asp:Button ID="btnButton1" runat="server" Text="ส่งภายในสำนักงาน" CssClass="CssBtn" />
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<asp:Button ID="Button4" runat="server" Text="Button" Width="0px" CssClass="zHidden" />

<asp:Panel ID="Panel1" runat="server" Width="600">
    <table runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="cssHead">
                ยืนยันการส่งหนังสือภายในสำนักงาน
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" 
                    ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="left" >&nbsp;</td>
        </tr>
        <tr>
            <td align="left" class="Csslbl">
                ต้องการส่งหนังสือเจ้าหน้าที่ภายในสำนักงานซึ่งมีรายละเอียดดังนี้ใช่หรือไม่?
                <asp:TextBox ID="txtNewID" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Csslbl" colspan="2">
                <asp:GridView ID="gvComfirmSendList" runat="server" AutoGenerateColumns="False" 
                    Width="100%" CssClass="GridViewStyle" >
                    <RowStyle CssClass="RowStyle"  />
                    <Columns>
                        <asp:BoundField DataField="OrgNameReceive" HeaderText="หน่วยงานรับ" >
                            <HeaderStyle  />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StaffNameReceive" HeaderText="เจ้าหน้าที่รับ" >
                            <HeaderStyle Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="purpose" HeaderText="วัตถุประสงค์" >
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle"  />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" />
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
                <asp:Button ID="btnYes" runat="server" CssClass="CssBtn" Text="ใช่" Width="80" />
                &nbsp;<asp:Button ID="btnNo" runat="server" CssClass="CssBtn" Text="ไม่ใช่" Width="80" />
            </td>
        </tr>
        <tr>
            <td class="Csslbl">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<cc1:ModalPopupExtender ID="zPopConfirm" runat="server" 
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
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" >
                ส่งหนังสือเรียบร้อยแล้ว ได้เลขที่หนังสือ
                <asp:Label ID="lblBookNo" runat="server" ></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lblRequestNo" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvConfirmList" runat="server" AutoGenerateColumns="False" 
                    Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="GridViewStyle" >
                    <RowStyle CssClass="RowStyle" BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                        <asp:BoundField DataField="book_no" HeaderText="เลขที่หนังสือ" >
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StaffNameReceive" HeaderText="เจ้าหน้าที่รับ" 
                            SortExpression="StaffNameReceive">
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="purpose" HeaderText="วัตถุประสงค์" 
                            SortExpression="purpose">
                            <HeaderStyle  />
                            <ItemStyle HorizontalAlign="Left"  />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle CssClass="PagerStyle" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle CssClass="HeaderStyle" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle CssClass="AltRowStyle" BackColor="White" />
                </asp:GridView>
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
            <td  align="left" colspan="2">คุณต้องการที่จะเคลียร์หน้าจอหรือไม่ ?
            </td>
        </tr>
        <tr>
            <td align="center"  colspan="2">
                <asp:Button ID="btnYesClear" runat="server" CssClass="CssBtn" Text="ใช่" Width="80" />
                &nbsp;<asp:Button ID="btnNoClear" runat="server" CssClass="CssBtn" Text="ไม่ใช่" Width="80" />
             </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<cc1:ModalPopupExtender ID="zPopConfirmClear" runat="server" 
    BackgroundCssClass="modalBackground"   DropShadow="true" PopupControlID="Panel2" 
    TargetControlID="Button4">
</cc1:ModalPopupExtender>




