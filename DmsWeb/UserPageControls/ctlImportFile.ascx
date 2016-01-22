<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlImportFile.ascx.vb" Inherits="UserPageControls_ctlImportFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../UserControls/ctlUploadFile.ascx" TagName="ctlUploadFile" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/ctlBrowseFile.ascx" TagName="ctlBrowseFile" TagPrefix="uc3" %>
<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc4" %>


<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Button ID="bImport" runat="server" Text="นำเข้าเอกสาร" />
<asp:Panel ID="Panel1" runat="server" Width="600">
      <table width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
    <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998">
                นำเข้าเอกสาร
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td class="Csslbl">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                    AutoPostBack="True">
                    <asp:ListItem Value="0" Selected="True">นำเข้าจากเครื่องคอมพิวเตอร์</asp:ListItem>
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
                                <td class="Csslbl" align="right" width="15%">
                                    ไฟล์ :
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" Height="22px" Width="500px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Csslbl" align="right">
                                    รายละเอียด :
                                </td>
                                <td>
                                    <uc4:txtBox ID="txtBox1" runat="server" Width="500" IsNotNull="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" CssClass="CssBtn" Text="Upload" Width="80px" />
                                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="CssBtn" Text="Cancel" Width="80px" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table width ="100%" >
                            <tr>
                                <td class="Csslbl">
                                    <asp:Button ID="Button4" runat="server" CssClass="CssBtn" Text="Prev" Width="80px" />
                                    <uc4:txtBox ID="txtBox2" runat="server" IsNotNull="False" Height="22" TextAlign="AlignCenter" />
                                    <asp:Button ID="Button5" runat="server" CssClass="CssBtn" Text="Next" Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button6" runat="server" CssClass="CssBtn" Text="Scan Page" Width="100px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Csslbl">
                                    รายละเอียด :
                                    <uc4:txtBox ID="txtBox3" runat="server" Width ="400" IsNotNull="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" Width="50%" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                 
                  
                  
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                          CssClass="GridViewStyle" Width="100%">
                          <RowStyle CssClass="RowStyle" />
                          <Columns>
                              <asp:BoundField DataField="id" HeaderText="ลำดับ" ItemStyle-Width="5%" />
                              <asp:BoundField DataField="detail" HeaderText="รายละเอียด" 
                                  ItemStyle-Width="95%" />
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


