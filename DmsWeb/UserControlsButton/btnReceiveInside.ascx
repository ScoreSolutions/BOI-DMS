<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnReceiveInside.ascx.vb" Inherits="UserControls_Button_btnReceiveInside"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Button ID="btnButton1" runat="server" Text=" ลงรับภายในสำนักงาน " CssClass="CssBtn" />
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />

<asp:Panel ID="Panel1" runat="server" Width="800">
    <table id="Table1" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="800">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="cssHead">
                ยืนยันการลงรับภายในสำนักงาน
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
                ต้องการลงรับภายในสำนักงานซึ่งมีรายละเอียดดังนี้ใช่หรือไม่?
                <asp:TextBox ID="txtNewID" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Csslbl" colspan="2">
                <asp:GridView ID="gvComfirmReceiveList" runat="server" AutoGenerateColumns="False" 
                    Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="GridViewStyle" >
                    <RowStyle CssClass="RowStyle" BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="bookno" HeaderText="เลขที่หนังสือ" >
                            <HeaderStyle  />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" >
                            <HeaderStyle  />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="organization_appname_send" HeaderText="หน่วยงานส่ง" >
                            <HeaderStyle  />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="user_send" HeaderText="เจ้าหน้าที่ส่ง" >
                            <HeaderStyle Width="120px" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="objective_name" HeaderText="วัตถุประสงค์" >
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
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


