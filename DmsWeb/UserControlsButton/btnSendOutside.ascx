<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnSendOutside.ascx.vb" Inherits="UserControls_Button_btnSendOutside" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc6" %>
<%@ Register src="~/UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc7" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc4" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc1" %>
<%@ Register src="~/UserControls/ctlBrowseFile.ascx" tagname="ctlBrowseFile" tagprefix="uc5" %>
<%@ Register src="~/UserControls/PageControl.ascx" tagname="pagecontrol" tagprefix="uc6" %>

<script language="javascript" type="text/javascript">

    //สำหรับหน้าจอ Popup ส่งออกนอกสำนักงาน
    function OutLoadImage() {
        document.getElementById('<%=hdnCustValue.ClientID%>').value = '';
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundImage = 'url(../images/loading.gif)';
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundRepeat = 'no-repeat';
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundPosition = 'right';
    }
    function OutHideImage() {
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundImage = 'none';
    }
    function OutOnCustomerSelected(source, eventArgs) {
        var retVal = eventArgs.get_value().split("|");
        document.getElementById('<%=hdnCustValue.ClientID%>').value = retVal[0];
        document.getElementById('<%=hdnCompanyRegisNo.ClientID%>').value = retVal[1];
    }
    function OutClearTxtCustValue() {
        if (document.getElementById('<%=txtCustName.ClientID%>').value == "") {
            document.getElementById('<%=hdnCustValue.ClientID%>').value = "";
            document.getElementById('<%=hdnCompanyRegisNo.ClientID%>').value = "";
        }
    }
</script>

<asp:Button ID="btnButton1" runat="server" Text="ส่งออกนอกสำนักงาน " CssClass="CssBtn" />
<asp:TextBox ID="txtScanJobID" runat="server" CssClass="zHidden" Text="0" ></asp:TextBox>

<asp:Panel ID="Panel5" runat="server" Width="800"  >
    <table id="Table5" width="800" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000;" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998" colspan="2">ส่งหนังสือออกภายนอกสำนักงาน</td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvShowData" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" 
                    GridLines="Vertical" PageSize="20" Width="100%">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:BoundField DataField="id" ShowHeader="false" >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bookno" HeaderText="เลขที่หนังสือ" >
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="book_title" HeaderText="เรื่อง" 
                            SortExpression="book_title">
                            <HeaderStyle HorizontalAlign="Center" Width="250px" />
                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dates_app" HeaderText="วันที่อนุมัติ" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="จบงาน" >
                            <ItemStyle Width="50px" HorizontalAlign="Center" ></ItemStyle>
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkCloseJob" runat="server" Checked="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Visible="False" />
                    <PagerStyle CssClass="pgr" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3" >&nbsp;</td>
        </tr>
        <tr >
            <td colspan="3" align="center" >
                <table width="95%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="height:25px">
                        <td align="right" width="15%" class="Csslbl" >หน่วยงานที่รับ : </td>
                        <td width="45%" align="left" >
                            <asp:TextBox runat="server" ID="txtCustName" Width="300" CssClass="TextBox" autocomplete="off" onBlur="OutClearTxtCustValue()" ></asp:TextBox>&nbsp;
                            <cc1:AutoCompleteExtender
                                runat="server" 
                                ID="AutoCompleteExtender1" 
                                TargetControlID="txtCustName"
                                ServicePath="~/Template/AjaxScript.asmx"
                                ServiceMethod = "GetAllCompanyForDDL"
                                MinimumPrefixLength="3" 
                                CompletionInterval="1000"
                                UseContextKey="true"
                                EnableCaching="true"
                                CompletionSetCount="20" FirstRowSelected="true"
                                CompletionListCssClass="autocomplete_completionListElement" 
                                CompletionListItemCssClass="autocomplete_listItem" 
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                DelimiterCharacters="*" BehaviorID="OutAutoCompleteEx" 
                                ShowOnlyCurrentWordInCompletionListItem="true"
                                OnClientPopulating="OutLoadImage" OnClientPopulated="OutHideImage" OnClientItemSelected="OutOnCustomerSelected" >
                                <Animations>
                                    <OnShow>
                                        <Sequence>
                                            <OpacityAction Opacity="0" />
                                            <HideAction Visible="true" />
                                            <ScriptAction Script="
                                                // Cache the size and setup the initial size
                                                var behavior = $find('OutAutoCompleteEx');
                                                if (!behavior._height) {
                                                    var target = behavior.get_completionList();
                                                    behavior._height = target.offsetHeight - 2;
                                                    target.style.height = '0px';
                                                }" />
                                            <Parallel Duration=".4">
                                                <FadeIn />
                                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('OutAutoCompleteEx')._height" />
                                            </Parallel>
                                        </Sequence>
                                    </OnShow>
                                    <OnHide>
                                        <Parallel Duration=".4">
                                            <FadeOut />
                                            <Length PropertyKey="height" StartValueScript="$find('OutAutoCompleteEx')._height" EndValue="0" />
                                        </Parallel>
                                    </OnHide>
                                </Animations>
                             </cc1:AutoCompleteExtender>
                             <asp:TextBox ID="hdnCustValue" runat="server" CssClass="zHidden"  ></asp:TextBox>
                             <asp:TextBox ID="hdnCompanyRegisNo" runat="server" ></asp:TextBox>
                        </td>
                        <td align="right" width="10%" class="Csslbl">ผู้ลงนาม : </td>
                        <td width="30%" align="left" >
                            <uc4:cmbCombobox ID="cmbStaffSignID" runat="server" Width ="200px" />
                        </td>
                    </tr>
                    <tr style="height:25px">
                        <td align="right" class="Csslbl" >หมายเหตุ : </td>
                        <td align="left" >
                            <uc1:txtBox ID="txtRemarks" runat="server" Width ="300px" />
                        </td>
                        <td align="right" class="Csslbl" >ลำดับ : </td>
                        <td align="left" >
                            <uc1:txtBox ID="txtNo" runat="server" Width ="50px" TextAlign="AlignCenter" TextKey="TextInt" />
                            <asp:TextBox ID="txtRowID" runat="server" CssClass="zHidden" ></asp:TextBox>
                            <asp:TextBox ID="txtIsEdit" runat="server" Text="N" CssClass="zHidden"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">
                            &nbsp;</td>
                        <td align="left" width="35%">
                            <asp:Button ID="btnAdd" runat="server" CssClass="CssBtn" Text="บันทึก" 
                                Width="50px" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="CssBtn" Text="ลบ" 
                                Width="50px" />
                        </td>
                        <td align="left" width="15%">
                            &nbsp;</td>
                        <td width="35%">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr >
            <td colspan="3" align="center" >
                <div style="width:95%;height:250px;overflow:scroll;overflow-x:hidden;"  >
                    <table width="95%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right">
                                <asp:GridView ID="gvSendList" runat="server" 
                                    AutoGenerateColumns="False" CssClass="mGrid" 
                                    GridLines="Vertical" Width="100%">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                        <asp:BoundField DataField="no" HeaderText="ลำดับ" >
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CompanyNameReceive" HeaderText="ชื่อหน่วยงาน" >
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="remarks" HeaderText="หมายเหตุ" >
                                            <HeaderStyle Width="200px" />
                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="StaffNameSign" HeaderText="ผู้ลงนาม" >
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField  >
                                            <ItemStyle Width="30px" HorizontalAlign="Center" ></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/pencil_add.png" ToolTip="แก้ไข" CommandName="Edit"  />
                                                <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/Images/delete1.png" Width="16" OnClientClick="return confirm('ยืนยันการลบรายการ?');" CommandName="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="officer_id"  >
                                            <HeaderStyle CssClass="zHidden" />
                                            <ItemStyle CssClass="zHidden" />
                                            <ControlStyle CssClass="zHidden" />
                                            <FooterStyle CssClass="zHidden" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="company_id"  >
                                            <HeaderStyle CssClass="zHidden" />
                                            <ItemStyle CssClass="zHidden" />
                                            <ControlStyle CssClass="zHidden" />
                                            <FooterStyle CssClass="zHidden" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CompanySource"  >
                                            <HeaderStyle CssClass="zHidden" />
                                            <ItemStyle CssClass="zHidden" />
                                            <ControlStyle CssClass="zHidden" />
                                            <FooterStyle CssClass="zHidden" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CompanyRegisNo"  >
                                            <HeaderStyle CssClass="zHidden" />
                                            <ItemStyle CssClass="zHidden" />
                                            <ControlStyle CssClass="zHidden" />
                                            <FooterStyle CssClass="zHidden" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings Visible="False" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
                        </tr>
                     </table>
                 </div>
            </td>
        </tr>
        
        <tr style="height:25px" >
            <td >&nbsp;</td>
            <td align="right" class="Csslbl" >
                เลือกหน่วยงานจัดเก็บหนังสือ :
            </td>
            <td align="left">
                <uc4:cmbCombobox ID="cmbOrgKeepID" runat="server" Width="200px" />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" ></asp:Label>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                &nbsp;</td>
            <td align="right" class="Csslbl">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr style="height:25px" >
            <td align="right" class="Csslbl" colspan="3" >
                <asp:Button ID="btnExport" runat="server" Text=" ส่งออกนอกสำนักงาน " CssClass="CssBtn" />
                <asp:Button ID="btnCancel" runat="server" Text=" ยกเลิก " CssClass="CssBtn" />
            </td>
        </tr>
        
        <tr><td colspan="3">&nbsp;</td></tr>
    </table>
</asp:Panel>
<asp:Button ID="Button5" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPopShowData" runat="server" PopupControlID="Panel5" TargetControlID="Button5"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>



<asp:Panel ID="Panel6" runat="server" Width="800"  >
    <table id="Table6" width="800" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000;" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998">ส่งหนังสือเรียบร้อยแล้ว</td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgSendCompleteClose" runat="server" ImageUrl="~/Images/closewindows.png" />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td align="left" class="Csslbl" colspan="2">
                เลขที่หนังสือ
                <asp:Label ID="lblCompleteBookNo" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="Csslbl" colspan="2">
                ส่งหนังสืออกนอกสำนักงาน  <asp:Label ID="txtBookQty" runat="server" Text="1" ></asp:Label> รายละเอียดดังนี้
            </td>
        </tr>
        <tr >
            <td colspan="2" >
                <div class="DivBoxRaius" style="width:95%;height:400px;overflow:scroll;overflow-x:hidden;"  >
                    <asp:GridView ID="gvSendComplete" runat="server" AutoGenerateColumns="False" CssClass="mGrid" 
                        GridLines="Vertical" PageSize="20" Width="100%">
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:BoundField DataField="bookout_no" HeaderText="เลขที่หนังสือส่งออก" >
                                <HeaderStyle Width="120px" />
                                <ItemStyle HorizontalAlign="Center" Width="120px" Font-Bold="true" ForeColor="Navy" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CompanyNameReceive" HeaderText="ชื่อหน่วยงาน" >
                                <HeaderStyle  />
                                <ItemStyle HorizontalAlign="Left"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="StaffNameSign" HeaderText="ผู้ลงนาม" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField >
                                <ItemStyle Width="20px" HorizontalAlign="Center" ></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSendToTHeGif" runat="server" Height="20px"  ImageUrl="~/Images/TH-eGif_Logo.png" Visible='<%# Eval("th_egif_org_code") <> "" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="document_ext_receiver_id" >
                                <ControlStyle CssClass="zHidden" />
                                <FooterStyle CssClass="zHidden" />
                                <HeaderStyle CssClass="zHidden" />
                                <ItemStyle CssClass="zHidden" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Visible="False" />
                        <PagerStyle CssClass="pgr" />
                     </asp:GridView>
                     <script language="javascript" type="text/javascript">
                         function SendToTHeGif(vID, ctl) {
                             if (confirm("ยืนยันการส่งข้อมูล?")) {
                                 var img = document.getElementById(ctl);
                                 var UserName = '<%=Config.GetLogOnUser.UserName %>';
                                 var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>'
                                 $.ajax({
                                     type: "POST",
                                     url: pageUrl + "/SendLetterToTHeGif",
                                     data: "{'vDocExtID':'" + vID + "','LoginName':'" + UserName + "'}",
                                     contentType: "application/json; charset=utf-8",
                                     dataType: "json",
                                     success: function(msg) {
                                         if (msg.d == true) {
                                             alert("ส่งข้อมูลเรียบร้อย");
                                             img.style.display = "none";
                                         }
                                     }
                                 });
                             }
                         }
                     </script>
                 </div>
            </td>
        </tr>
        
        <tr style="height:25px" >
            <td align="left" colspan="2" class="Csslbl" >
                สำเนาหนังสือจัดเก็บที่ <asp:Label ID="lblOrgKeep" runat="server" ></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lblKeepBookNo" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnOK" runat="server" CssClass="CssBtn" Text="ตกลง" Width="50px" />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
    </table>
</asp:Panel>
<asp:Button ID="Button6" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPopSendComplete" runat="server" PopupControlID="Panel6" TargetControlID="Button6"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>

