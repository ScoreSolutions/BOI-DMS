<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterGroupTitle.aspx.vb" Inherits="WebApp_frmMasterGroupTitle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register src="../UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>

<asp:Content ID="Head1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
    function LoadImage() {
        document.getElementById('<%=hdnCustValue.ClientID%>').value = '';
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundImage = 'url(../images/loading.gif)';
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundRepeat = 'no-repeat';
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundPosition = 'right';
    }
    function HideImage() {
        document.getElementById('<%=txtCustName.ClientID%>').style.backgroundImage = 'none';
    }
    function OnCustomerSelected(source, eventArgs) {
        document.getElementById('<%=hdnCustValue.ClientID%>').value = eventArgs.get_value();
    }
    function ClearTxtCustValue() {
        if (document.getElementById('<%=txtCustName.ClientID%>').value == "") {
            document.getElementById('<%=hdnCustValue.ClientID%>').value = "";
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="CssHead" colspan="4" align="left" >ข้อมูลพื้นฐานกลุ่มเรื่อง</td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" width="20%">รหัสกลุ่มเรื่อง :</td>
            <td width="30%" align="left" >
                <uc1:txtBox ID="txtCode" runat="server" IsNotNull="true" Width="50" TextKey="TextDouble" />
            </td>
            <td align="right" class="Csslbl" width="20%">ประเภทงาน :</td>
            <td width="30%" align="left" >
                <uc2:cmbAutoComplete ID="cmbGroupTitleTypeID" runat="server" Width="150px" ValidateText="*" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl">ชื่อกลุ่มเรื่อง :</td>
            <td align="left">
                <uc1:txtBox ID="txtName" runat="server" IsNotNull="true" Width="250px" />
            </td>
            <td align="right" class="Csslbl">ประเภทเรื่อง :</td>
            <td align="left">
                <uc2:cmbAutoComplete ID="cmbSubjectID" runat="server" Width="150px" DefaultValue="1" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >วันมาตรฐาน :</td>
            <td align="left" class="Csslbl"  >
                <uc1:txtBox ID="txtStdProcPerd" runat="server" Width="50px" /> วัน
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                วันกำหนดเสร็จ :
                <uc1:txtBox ID="txtMaxProcPerd" runat="server" Width="50px" /> วัน
            </td>
            <td>&nbsp;</td>
            <td align="left" class="Csslbl" >
                <asp:CheckBox ID="chkIsGenReqNo" runat="server" Text="Run เลขที่คำขอ" />&nbsp;&nbsp;
                <asp:CheckBox ID="chkActive" runat="server" Text="ใช้งาน" Checked="true" />
            </td>
        </tr>
        <tr>
            <td align="right" class="Csslbl" >&nbsp;</td>
            <td align="left" class="Csslbl" colspan="3"  >
                <asp:CheckBox ID="chkNoDefaultTitle" runat="server" Text="ไม่แสดงชื่อเรื่องเป็นค่าเริ่มต้นในหน้าลงทะเบียน" />
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" align="center" >
                 <asp:Panel ID="pnlOrg" runat="server" BorderWidth="1" Width="95%" >
                    <table border="0" cellpadding="0" cellspacing="0" width="98%" >
                        <tr>
                            <td class="Csslbl" align="left"  >กองงานรับผิดชอบ</td>
                            <td class="Csslbl" align="right"  >
                                <asp:Button ID="btnAddOrg" runat="server" CssClass="CssBtn" Width="50px" Text="เพิ่ม" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <asp:Panel ID="Panel1" runat="server" Width="600" >
                                    <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                                        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
                                        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                                            <td align="left" bgcolor="#3B5998" colspan="2" class="popHead" >กองงานรับผิดชอบ</td>
                                            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px" colspan="2" >
                                                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >&nbsp;
                                                <uc1:txtBox ID="txtGrpOrgID" runat="server" Visible="false" Text="0" />
                                                <uc1:txtBox ID="txtGrpOrgRowIndex" runat="server" Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="20%">กลุ่มหน่วยงาน :</td>
                                            <td width="45%"  align="left" >
                                                <uc3:cmbComboBox ID="cmbOrgTypeID" runat="server" Width="250px" ValidateText="*" DefaultValue="0" AutoPosBack="true" />
                                            </td>
                                            <td align="right" width="20%">วันมาตรฐาน :</td>
                                            <td width="15%" align="left" >
                                                <uc1:txtBox ID="txtStdPerd" runat="server"  Width="50" TextKey="TextInt" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >ชื่อหน่วยงาน :</td>
                                            <td  align="left" >
                                                <uc3:cmbComboBox ID="cmbOrgID" runat="server" Width="250px" ValidateText="*" />
                                            </td>
                                            <td align="right">วันกำหนดเสร็จ :</td>
                                            <td  align="left" >
                                                <uc1:txtBox ID="txtMaxPerd" runat="server" Width="50" TextKey="TextInt" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" >
                                                <asp:Button ID="btnSaveGrpOrg" runat="server" CssClass="CssBtn" Text="บันทึก" Width="60px" />&nbsp;
                                                <asp:Button ID="btnCancelGrpOrg" runat="server" CssClass="CssBtn" Text="ยกเลิก" Width="60px" />
                                            </td>
                                        </tr>
                                        <tr><td colspan="4">&nbsp;</td></tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Button ID="Button3" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                                <cc1:ModalPopupExtender ID="zPopOrg" runat="server" PopupControlID="Panel1" TargetControlID="Button3"
                                    BackgroundCssClass="modalBackground" DropShadow="true">
                                </cc1:ModalPopupExtender>
                            </td>
                        </tr>
                        <tr id="trOrgHeaderRow" runat="server" >
                            <td colspan="2">
                                <table width="95%" class="mGrid">
                                    <tr>
                                        <td width="150px" align="center" >กลุ่มหน่วยงาน</td>
                                        <td align="center" >ชื่อหน่วยงาน</td>
                                        <td width="100px" align="center" >วันมาตรฐาน(วัน)</td>
                                        <td width="100px" align="center" >กำหนดเสร็จ(วัน)</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" >
                                <asp:GridView ID="gvOrgList" runat="server" 
                                    AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id" >
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="org_group_name" HeaderText="กลุ่มหน่วยงาน">
                                            <ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
                                            <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="org_name" HeaderText="ชื่อหน่วยงาน">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="std_proc" HeaderText="วันมาตรฐาน(วัน)" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="max_proc" HeaderText="กำหนดเสร็จ(วัน)" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField  >
                                            <ItemStyle Width="60px" HorizontalAlign="Center" ></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" CommandName="Edit" CommandArgument='<%# Bind("id") %>' ImageUrl="~/Images/pencil_add.png" ToolTip="แก้ไข" />
                                                &nbsp;
                                                <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/Images/delete1.png" Width="16px" CommandName="Delete" CommandArgument='<%# Bind("id") %>' ToolTip="ลบ" OnClientClick="return confirm('ยืนยันการลบรายการ?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings Visible="False" />
                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                 </asp:Panel>
                 <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" Corners="All" Color="#CCCCCC" BorderColor="#CCCCCC" 
                  TargetControlID="pnlOrg" Radius="6"   >
                 </cc1:RoundedCornersExtender>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" align="center" >
                <asp:Panel ID="pnlCompany" runat="server" BorderWidth="1" Width="95%" >
                    <table border="0" cellpadding="0" cellspacing="0" width="98%" >
                        <tr>
                            <td class="Csslbl" align="left"  >องค์กรรับ</td>
                            <td class="Csslbl" align="right"  >
                                <asp:Button ID="btnAddCompany" runat="server" CssClass="CssBtn" Width="50px" Text="เพิ่ม" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Panel ID="Panel2" runat="server" Width="600" >
                                    <table id="Table2" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                                        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
                                        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                                            <td align="left" bgcolor="#3B5998" colspan="2" class="popHead" >องค์กรรับ</td>
                                            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px" colspan="2" >
                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../Images/closewindows.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >&nbsp;
                                                <uc1:txtBox ID="txtGrpCompanyID" runat="server" Visible="false" Text="0" />
                                                <uc1:txtBox ID="txtGrpComRowIndex" runat="server" Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="20%">ชื่อองค์กร :</td>
                                            <td width="80%"  align="left" >
                                                <asp:TextBox runat="server" ID="txtCustName" Width="200" CssClass="TextBox" autocomplete="off" onBlur="ClearTxtCustValue()" ></asp:TextBox>&nbsp;
                                                <font color="red">*</font>
                                                <cc1:AutoCompleteExtender
                                                    runat="server" 
                                                    ID="AutoCompleteExtender1" 
                                                    TargetControlID="txtCustName"
                                                    ServicePath="~/Template/AjaxScript.asmx"
                                                    ServiceMethod = "GetAllCompanyForDDL"
                                                    MinimumPrefixLength="1" 
                                                    CompletionInterval="500"
                                                    UseContextKey="true"
                                                    EnableCaching="true"
                                                    CompletionSetCount="50" FirstRowSelected="true"
                                                    CompletionListCssClass="autocomplete_completionListElement" 
                                                    CompletionListItemCssClass="autocomplete_listItem" 
                                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                    DelimiterCharacters="*" BehaviorID="AutoCompleteEx" 
                                                    ShowOnlyCurrentWordInCompletionListItem="true"
                                                    OnClientPopulating="LoadImage" OnClientPopulated="HideImage" OnClientItemSelected="OnCustomerSelected" >
                                                 
                                                    <Animations>
                                                        <OnShow>
                                                            <Sequence>
                                                                <OpacityAction Opacity="0" />
                                                                <HideAction Visible="true" />
                                                                <ScriptAction Script="
                                                                    // Cache the size and setup the initial size
                                                                    var behavior = $find('AutoCompleteEx');
                                                                    if (!behavior._height) {
                                                                        var target = behavior.get_completionList();
                                                                        behavior._height = target.offsetHeight - 2;
                                                                        target.style.height = '0px';
                                                                    }" />
                                                                <Parallel Duration=".4">
                                                                    <FadeIn />
                                                                    <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                                                                </Parallel>
                                                            </Sequence>
                                                        </OnShow>
                                                        <OnHide>
                                                            <Parallel Duration=".4">
                                                                <FadeOut />
                                                                <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                                                            </Parallel>
                                                        </OnHide>
                                                    </Animations>
                                                 </cc1:AutoCompleteExtender>
                                                 <asp:TextBox ID="hdnCustValue" runat="server" CssClass="zHidden"  ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >หมายเหตุ :</td>
                                            <td  align="left" >
                                                <uc1:txtBox ID="txtRemarks" runat="server" Width="480"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" >
                                                <asp:Button ID="btnSaveGrpCompany" runat="server" CssClass="CssBtn" Text="บันทึก" Width="60px" />&nbsp;
                                                <asp:Button ID="btnCancelGrpCompany" runat="server" CssClass="CssBtn" Text="ยกเลิก" Width="60px" />
                                            </td>
                                        </tr>
                                        <tr><td colspan="4">&nbsp;</td></tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Button ID="Button5" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                                <cc1:ModalPopupExtender ID="zPopCompany" runat="server" PopupControlID="Panel2" TargetControlID="Button5"
                                    BackgroundCssClass="modalBackground" DropShadow="true">
                                </cc1:ModalPopupExtender>
                            </td>
                        </tr>
                        <tr id="tr1" runat="server" >
                            <td colspan="2" >
                                <table width="95%" class="mGrid">
                                    <tr>
                                        <td align="center" >ชื่อองค์กร</td>
                                        <td width="200px" align="center" >หมายเหตุ</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvCompany" runat="server" 
                                    AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id" >
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="company_name" HeaderText="ชื่อองค์กร">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="remarks" HeaderText="หมายเหตุ" >
                                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                                        </asp:BoundField>
                                        <asp:TemplateField  >
                                            <ItemStyle Width="60px" HorizontalAlign="Center" ></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgcEdit" runat="server" CommandName="Edit" CommandArgument='<%# Bind("id") %>' ImageUrl="~/Images/pencil_add.png" ToolTip="แก้ไข" />
                                                &nbsp;
                                                <asp:ImageButton ID="imgcDel" runat="server" ImageUrl="~/Images/delete1.png" Width="16px" CommandName="Delete" CommandArgument='<%# Bind("id") %>' ToolTip="ลบ" OnClientClick="return confirm('ยืนยันการลบรายการ?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings Visible="False" />
                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" Corners="All" Color="#CCCCCC" BorderColor="#CCCCCC" 
                  TargetControlID="pnlCompany" Radius="6"   >
                 </cc1:RoundedCornersExtender>
            </td>
        </tr>
        <tr><td colspan="4" >&nbsp;</td></tr>
        <tr>
            <td colspan="4" align="center" >
                <asp:Button ID="btnSave" runat="server" Text="บันทึก" CssClass="CssBtn" Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="CssBtn" Width="60px"
                    TabIndex="6" />
            </td>
        </tr>
        
        <tr><td colspan="4" >&nbsp;</td></tr>
        <tr><td colspan="4" >&nbsp;</td></tr>
        <tr>
            <td colspan="4" align="right" class="Csslbl" >
                ค้นหา :
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Button" Style="display: none" />
            </td>
        </tr>
        <tr>
            <td colspan="4"><uc1:PageControl ID="pcTop" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvGroupTitle" runat="server" AllowSorting="True" AllowPaging="true"
                    AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" PageSize="50"
                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical" Width="100%" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="group_title_name" HeaderText="กลุ่มเรื่อง">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="group_title_type_name" HeaderText="ประเภทงาน">
                            <HeaderStyle HorizontalAlign="Center" Width="250px" />
                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="std_proc_period" HeaderText="วันมาตรฐาน(วัน)" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="max_proc_period" HeaderText="กำหนดเสร็จ(วัน)" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle Width="15px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgGEdit" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Bind("id") %>'
                                    ImageUrl="~/Images/pencil_add.png" Text="Edit" ToolTip="แก้ไข" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" Visible="false">
                            <ItemStyle Width="15px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgGDelete" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%# Bind("id") %>'
                                    ImageUrl="~/Images/Delete.png" Text="Delete" ToolTip="ลบ" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pgr"></PagerStyle>
                    <EmptyDataTemplate>
                        <table width="100%" border="1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Visible="False" />
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

