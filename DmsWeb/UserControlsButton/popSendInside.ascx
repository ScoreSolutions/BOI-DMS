<%@ Control Language="VB" AutoEventWireup="false" CodeFile="popSendInside.ascx.vb" Inherits="UserControls_Button_popSendInside"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc7" %>
<%@ Register Src="~/UserControlsButton/btnSendInside.ascx" TagName="btnSendInside" TagPrefix="bt1" %>
<%@ Register Src="~/UserControlsButton/btnSendCircle.ascx" TagName="btnSendCircle" TagPrefix="bt2" %>
<%@ Register Src="~/UserControlsButton/btnCloseJob.ascx" TagName="btnCloseJob" TagPrefix="bt3" %>
<%@ Register Src="~/UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/cmbComboBox.ascx" TagName="cmbComboBox" TagPrefix="uc4" %>


        <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
        <asp:Panel ID="Panel1" runat="server" Width="600" CssClass="modalPopupInsideCombo">
            <asp:UpdatePanel ID="pnlUpdatePanel1" runat="server">
                <ContentTemplate>
                    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                        style="border: solid 0px 0px 0px 0px #ff0000;" runat="server">
                        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                            <td align="left" bgcolor="#3B5998">
                                รายละเอียดผู้รับ
                            </td>
                            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/Images/closewindows.png" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="Csslbl">
                                เลขที่หนังสือที่เลือก :
                            </td>
                            <td align="left" >
                                <asp:Label ID="lblBookNo" runat="server"></asp:Label>
                                <asp:TextBox ID="txtDocRegisID" runat="server" CssClass="zHidden"  ></asp:TextBox>
                                <asp:TextBox ID="txtOnlyApproveID" runat="server" CssClass="zHidden" Text="0" ></asp:TextBox>
                                <asp:TextBox ID="txtOnlyOrgID" runat="server" CssClass="zHidden" Text="0" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td align="right" class="Csslbl" width="20%">
                                หน่วยงานผู้รับ :
                            </td>
                            <td class="Csslbl" width="80%" align="left" >
                                <uc4:cmbComboBox ID="cmbOrgReceiveID" runat="server" CssClass="zComboBox" Width="300px" AutoPosBack="true"  >
                                </uc4:cmbComboBox>
                                <font color="red">*</font>
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td align="right" class="Csslbl">
                                ชื่อผู้รับ :
                            </td>
                            <td align="left" >
                                <uc4:cmbComboBox ID="cmbStaffReceiveID" runat="server" CssClass="zComboBox" IsDefaultValue="true"  Width="300px" >
                                </uc4:cmbComboBox>
                                <font color="red">*</font>
                            </td>
                        </tr>
                        
                        <tr style="height: 25px">
                            <td align="right" class="Csslbl">
                                ชื่อผู้พิจารณา :
                            </td>
                            <td align="left" >
                                
                                <uc4:cmbComboBox ID="cmbStaffApproveID" runat="server" CssClass="zComboBox"  IsDefaultValue="true"  Width="300px" >
                                </uc4:cmbComboBox>
                                <font color="red">*</font>
                            </td>
                        </tr>
                        
                        <tr style="height: 25px">
                            <td align="right" class="Csslbl">
                                วัตถุประสงค์ :
                            </td>
                            <td align="left" >
                                <uc4:cmbComboBox ID="cmbPurpose" runat="server" Width="300px" />
                                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 25px">
                            <td align="right" class="Csslbl">
                                ข้อความ :
                            </td>
                            <td align="left" >
                                <uc2:txtBox ID="txtRemarks" runat="server" Width="300" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <bt1:btnSendInside ID="btnSendInside2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
            BackgroundCssClass="modalBackground" DropShadow="false">
        </cc1:ModalPopupExtender>

    
            <asp:Button ID="ButtonG1" runat="server" CssClass="zHidden" Text="Button" Width="0px" />
            <asp:Panel ID="Panel2" runat="server" Width="600">
                <table id="Table2" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0"
                    style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                    <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                        <td align="left" bgcolor="#3B5998">
                            เลือกหน่วยงานส่ง
                        </td>
                        <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                            &nbsp;
                        </td>
                        <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/closewindows.png" />
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
                            <uc4:cmbcombobox ID="cmbComboBox1" runat="server" Width="300" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="Csslbl" valign="top" width="45%">
                            หน่วยงาน&nbsp;
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left" class="Csslbl" valign="top" width="45%">
                            หน่วยงานที่รับหนังสือ
                        </td>
                    </tr>
                    <tr>
                        <td class="Csslbl" valign="top" width="45%">
                            <asp:GridView ID="gvSendList" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                Width="100%">
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
                                    <asp:BoundField DataField="OrgNameReceive" HeaderText="หน่วยงาน" SortExpression="OrgNameReceive">
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
                            <asp:Button ID="Button7" runat="server" CssClass="CssBtn" Text="&lt;&lt;" Width="30px" />
                            <asp:Button ID="Button6" runat="server" CssClass="CssBtn" Text="&gt;&gt;" Width="30px" />
                        </td>
                        <td class="Csslbl" valign="top" width="45%">
                            <asp:GridView ID="gvSelect" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                Width="100%">
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
                                    <asp:BoundField DataField="OrgNameReceive" HeaderText="หน่วยงาน" SortExpression="OrgNameReceive">
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
                            <asp:Button ID="btnSend" runat="server" CssClass="CssBtn" Text="ส่ง" Width="80" />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" CssClass="CssBtn" Text="ยกเลิก" Width="80" />
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
            <cc1:ModalPopupExtender ID="zPopG1" runat="server" BackgroundCssClass="modalBackground"
                DropShadow="false" PopupControlID="Panel2" TargetControlID="ButtonG1">
            </cc1:ModalPopupExtender>
            
        <asp:Panel ID="Panel3" runat="server" Width="600">
            <table ID="Table3" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
                cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                    <td align="left" bgcolor="#3B5998">
                        ส่งหนังสือเรียบร้อยแล้ว
                    </td>
                    <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="../Images/closewindows.png" />
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
                        <asp:Label ID="lblno" runat="server" Text="54-000421" ></asp:Label>
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
        <asp:Button ID="Button4" runat="server" CssClass="zHidden" Text="Button"  Width="0px" />
        <cc1:ModalPopupExtender ID="zPop2" runat="server" 
            BackgroundCssClass="modalBackground" DropShadow="true" PopupControlID="Panel3" 
            TargetControlID="Button4">
        </cc1:ModalPopupExtender>

    