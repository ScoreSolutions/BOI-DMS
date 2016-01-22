<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnCloseJob.ascx.vb" Inherits="UserControls_Button_btnCloseJob"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/cmbCombobox.ascx" TagName="cmbCombobox" TagPrefix="uc2" %>

<asp:Button ID="btnButton1" runat="server" Text="ลงทะเบียนพร้อมจบงาน " CssClass="CssBtn" />

<asp:Panel ID="Panel1" runat="server" Width="850">
    <table id="Table1" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="850">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" >
                ยืนยันการการจบงาน
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" 
                    ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="left">&nbsp;</td>
        </tr>
        <tr>
            <td align="left">
                ต้องการจบงานซึ่งมีรายละเอียดดังนี้ใช่หรือไม่?
            </td>
        </tr>
        <tr>
            <td class="Csslbl" colspan="2">
                <div class="DivBoxRaius" style="width:95%;height:400px;overflow:scroll;overflow-x:hidden;"  >
                    <asp:TextBox ID="txtScanJobID" runat="server" CssClass="zHidden" Text="0" ></asp:TextBox>
                    <asp:TextBox ID="txtIsCloseSuccess" runat="server" CssClass="zHidden" Text="N" ></asp:TextBox>
                    <asp:GridView ID="gvConfirmCloseList" runat="server" AutoGenerateColumns="False" 
                         Width="100%"  CssClass="GridViewStyle" >
                        <RowStyle CssClass="RowStyle"  />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" >
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="book_no" HeaderText="เลขที่หนังสือ" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" >
                                <HeaderStyle Width="300px"  />
                                <ItemStyle HorizontalAlign="Left" Width="300px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="สถานที่จัดเก็บ" >
                                <ItemTemplate>
                                    <uc2:cmbCombobox ID="cmbOrgIDStorage" runat="server" Width ="180px" />
                                </ItemTemplate>
                                <HeaderStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อผู้พิจารณา" >
                                <ItemTemplate>
                                    <uc2:cmbCombobox ID="cmbOfficerIDClose" runat="server" Width ="180px" />
                                </ItemTemplate>
                                <HeaderStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หมายเหตุ" >
                                <ItemTemplate>
                                    <uc1:txtBox ID="txtRemarks" runat="server" Width="120" IsNotNull="false"  />
                                </ItemTemplate>
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle"  />
                        <HeaderStyle CssClass="HeaderStyle"  />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                 </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnYes" runat="server" CssClass="CssBtn" Text="ใช่" Width="80" />
                &nbsp;<asp:Button ID="btnNo" runat="server" CssClass="CssBtn" Text="ไม่ใช่" Width="80" />
            </td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden"  />
<cc1:ModalPopupExtender ID="zPopConfirmCloseJob" runat="server" 
    BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="Panel1" 
    TargetControlID="Button1">
</cc1:ModalPopupExtender>



<asp:Panel ID="Panel2" runat="server" Width="800">
    <table ID="Table2" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="800">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" >
                จบงานเรียบร้อยแล้ว
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td align="left" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="Csslbl" colspan="2" align="center" >
                <div class="DivBoxRaius" style="width:95%;height:400px;overflow:scroll;overflow-x:hidden;"  >
                    <asp:GridView ID="gvCloseList" runat="server" AutoGenerateColumns="False" 
                         Width="100%" CssClass="GridViewStyle" >
                        <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" >
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="book_no" HeaderText="เลขที่หนังสือ" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="book_title" HeaderText="ชื่อเรื่อง" >
                                <HeaderStyle  />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="close_by_name" HeaderText="จบงานโดย" >
                                <HeaderStyle Width="150px"  />
                                <ItemStyle HorizontalAlign="Left" Width="300px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle"  />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </div>
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
            <td align="center"  colspan="2">
                <asp:Button ID="btnOK" runat="server" CssClass="CssBtn" Text="ตกลง" Width="80" />
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
<asp:Button ID="Button4" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPopClosedJob" runat="server" 
    BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="Panel2" 
    TargetControlID="Button4">
</cc1:ModalPopupExtender>