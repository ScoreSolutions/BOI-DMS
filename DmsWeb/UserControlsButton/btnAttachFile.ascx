<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnAttachFile.ascx.vb" Inherits="UserControls_Button_btnAttachFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtbox" TagPrefix="uc4" %>



<asp:Button ID="btnButton1" runat="server" Text="เอกสารแนบ " 
    CssClass="CssBtn" />
<asp:Button ID="Button1" runat="server" CssClass="zHidden" Text="Button" 
    Width="0px" />

<cc1:ModalPopupExtender ID="zPop" runat="server" 
    BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="Panel1" 
    TargetControlID="Button1">
</cc1:ModalPopupExtender>

<asp:Panel ID="Panel1" runat="server" Width="600">
    <table ID="Table1" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
        cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" class="fontonlabel">
                เอกสารแนบ</td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" 
                    ImageUrl="~/Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td class="fontonlabel">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                    RepeatColumns="2" RepeatDirection="Horizontal" CssClass="fontonlabel">
                    <asp:ListItem Selected="True" Value="0">นำเข้าจากเครื่องคอมพิวเตอร์</asp:ListItem>
                    <asp:ListItem Value="1">นำเข้าจากเครื่องสแกนเนอร์</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table width="100%">
                            <tr>
                                <td align="right" class="fontonlabel" width="15%">
                                    ไฟล์ :
                                </td>
                                <td align="left" class="fontonlabel">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Height="30px" Width="500px" 
                                        CssClass="fontonlabel" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="fontonlabel">
                                    รายละเอียด :
                                </td>
                                <td align="left" class="fontonlabel">
                                    <uc4:txtBox ID="txtBox1" runat="server" IsNotNull="True" Width="400" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button2" runat="server" CssClass="button" Text="Upload" 
                                        Width="80px" />
                                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="button" Text="Cancel" 
                                        Width="80px" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="left" width="100%">
                            <tr>
                                <td align="left" class="fontonlabel">
                                    <asp:Button ID="Button4" runat="server" CssClass="button" Text="Prev" 
                                        Width="80px" />
                                    <uc4:txtBox ID="txtBox2" runat="server" Height="22" IsNotNull="False" 
                                        TextAlign="AlignCenter" />
                                    <asp:Button ID="Button5" runat="server" CssClass="button" Text="Next" 
                                        Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Button ID="Button6" runat="server" CssClass="button" Text="Scan Page" 
                                        Width="100px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="fontonlabel">
                                    รายละเอียด :
                                    <uc4:txtBox ID="txtBox3" runat="server" IsNotNull="True" Width="400" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Image ID="Image1" runat="server" Width="50%" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr class="fontonlabel">
            <td align="left" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="fontonlabel" Width="100%">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ลำดับ" ItemStyle-Width="5%" >
                            <ItemStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="detail" HeaderText="รายละเอียด" 
                            ItemStyle-Width="95%" >
                            <ItemStyle Width="95%" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="15px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" ImageUrl="~/Images/download.png" Text="Download" 
                                    ToolTip="ดาวน์โหลด" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                                    CommandName="Delete" ImageUrl="~/Images/delete_page.png" Text="Delete" 
                                    ToolTip="ลบ" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>









