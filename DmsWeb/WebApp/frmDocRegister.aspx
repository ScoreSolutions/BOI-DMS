<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="frmDocRegister.aspx.vb" Inherits="WebApp_frmDocRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
<%@ Register src="~/UserControls/ctlCompany.ascx" tagname="ctlCompany" tagprefix="uc6" %>
<%@ Register src="~/UserControls/ctlUploadFile.ascx" tagname="ctlUploadFile" tagprefix="uc5" %>
<%@ Register src="~/UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc7" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc8" %>
<%@ Register Src="~/UserControlsButton/btnSendInside.ascx" TagName="btnSendInside" TagPrefix="bt1" %>
<%@ Register Src="~/UserControlsButton/btnSendCircle.ascx" TagName="btnSendCircle" TagPrefix="bt2" %>
<%@ Register src="../UserControlsButton/btnCloseJob.ascx" tagname="btnCloseJob" tagprefix="uc1" %>
<%@ Register src="../UserControlsButton/btnSendOutside.ascx" tagname="btnSendOutside" tagprefix="uc9" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
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
            var retVal = eventArgs.get_value().split("|");
            var custVal = retVal[0];
            document.getElementById('<%=hdnCustValue.ClientID%>').value = custVal;
            document.getElementById('<%=txtCompanyID.ClientID%>').value = retVal[1];
            document.getElementById('<%=txtCompanyIDCardNo.ClientID%>').value = retVal[2];
            document.getElementById('<%=txtCompanyPassportNo.ClientID%>').value = retVal[3];

            var chk = document.getElementById("<%=chkCertNo.ClientID %>");
            if (chk != null)
                chk.style.display = 'none';

            var retMsg = "N";
            var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
            //เลขที่บัตรส่งเสริม
            $.ajax({
                type: "POST",
                url: pageUrl + "/GetCertificate",
                data: "{'vCompanyID':'" + custVal + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d == "Y") {
                        var bt = document.getElementById('<%=btnSetCert.ClientID%>');
                        if (bt) {
                            retMsg = "Y";
                            bt.click();
                            return false;
                        }
                    }
                }
            });


            //เลขที่หนังสือแจ้งมติ
            var cmb = document.getElementById("<%=cmbResolutionsNo.ClientID %>");
            $.ajax({
                type: "POST",
                url: pageUrl + "/GetNotification",
                data: "{'vCompanyID':'" + custVal + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d == "Y" && retMsg=="N") {
                        var bt = document.getElementById('<%=btnSetCert.ClientID%>');
                        if (bt) {
                            bt.click();
                            return false;
                        }
                    }
                }
            });
        }
        
        function ClearTxtCustValue() {
            if (document.getElementById('<%=txtCustName.ClientID%>').value == "") {
                document.getElementById('<%=hdnCustValue.ClientID%>').value = "";
                document.getElementById('<%=txtCompanyID.ClientID%>').value = "";
            }
        }

        function OpenCompanyPopup(url, width, height) {
            var RndNum = 1 + Math.floor(Math.random() * 6);
            var WinSettings = "center:yes;resizable:no;dialogWidth:" + width + "px;dialogHeight:" + height + "px;scrollbars:yes";
            var MyArgs = window.showModalDialog(url + "&rnd=" + RndNum, null, WinSettings);

            if (MyArgs != null) {
                document.getElementById('<%=hdnCustValue.ClientID%>').value = MyArgs[0];
                document.getElementById('<%=txtCustName.ClientID%>').value = MyArgs[1];
                document.getElementById('<%=txtCompanyID.ClientID%>').value = MyArgs[2];
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td class="CssHead" colspan="4" align="left" >ลงทะเบียน</td>
        </tr>
        <tr>
            <td colspan="4" align="left" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr style="height:5px" >
                        <td align="right" width="15%">&nbsp;</td>
                        <td width="35%">&nbsp;</td>
                        <td align="right" width="15%">&nbsp;</td>
                        <td width="35%">&nbsp;</td>
                    </tr>
                    <tr style="height:25px">
                        <td align="right" class="Csslbl" >
                            เลขที่หนังสือ : </td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server" Text="0" CssClass="zHidden" ></asp:TextBox>
                            <asp:TextBox ID="txtDocRefID" runat="server" Text="0" CssClass="zHidden"></asp:TextBox>
                            <asp:TextBox ID="txtTHeGIFDocID" runat="server" Text="0" CssClass="zHidden"></asp:TextBox>
                            <uc2:txtBox ID="txtBookNo" runat="server" TextType="TextView" />
                            <img src="../Images/barcode.jpg" width="24px" title="พิมพ์บาร์โค้ด" class="zHidden" />
                        </td>
                        <td align="right" class="Csslbl" >เลขที่คำขอ : </td>
                        <td>
                            <uc2:txtBox ID="txtRequestNo" runat="server" TextType="TextView" />
                            <img src="../Images/print.png" title="พิมพ์ใบตอบรับคำขอ" class="zHidden"  />
                        </td>
                    </tr>
                    <tr style="height:25px">
                      <td align="right" class="Csslbl"  >
                            กลุ่มเรื่อง : </td>
                        <td colspan="3" valign="buttom" >
                            <asp:DropDownList ID="cmbGroupTitle" runat="server" CssClass="zComboBox" Width="770px" onchange="BindGroupTitleChange();"  >
                            </asp:DropDownList>
                            <font color="red">*</font>
                            <cc1:ListSearchExtender id="LSE" runat="server" TargetControlID="cmbGroupTitle" PromptText=""
                                PromptCssClass="zHidden" PromptPosition="Top" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                        </td>
                    </tr>
                    <tr style="height:25px">
                        <td align="right" class="Csslbl" >
                            ชื่อเรื่อง : </td>
                        <td colspan="3">
                            <uc2:txtBox ID="txtTitle" runat="server"  Width="770px" IsNotNull ="true" MaxLength="500"  />
                        </td>
                    </tr>
                    <tr style="height:25px" id="trDateRow" runat="server">
                        <td align="right" class="Csslbl">วันที่รับ :</td>
                        <td colspan="3" >
                            <table border="0" cellpadding="0" cellspacing="0" width="90%">
                                <tr>
                                    <td align="left" width="15%">
                                        <uc3:txtDate ID="txtReceiveDate" runat="server" IsNotNull="false" DefaultCurrentDate="true" VisibleImg="false" />
                                    </td>
                                    <td align="right" width="15%" class="Csslbl">กำหนดออก : </td>
                                    <td align="left" ><uc3:txtDate ID="txtExpectDate" runat="server" /></td>
                                    <td align="right" width="15%" class="Csslbl">ชั้นความลับ : </td>
                                    <td align="left" width="15%" valign="top" ><uc7:cmbAutoComplete ID="cmbDocSecretID" runat="server" Width="80px" IsDefaultValue="false" /></td>
                                    <td align="right" width="15%" class="Csslbl">ชั้นความเร็ว : </td>
                                    <td align="left" width="10%" valign="top"><uc7:cmbAutoComplete ID="cmbDocSpeedID" runat="server" Width="100px" IsDefaultValue="false" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height:25px">
                        <td align="right" class="Csslbl" >
                            หน่วยงานเจ้าของเรื่อง : </td>
                        <td  valign="top">
                            <asp:DropDownList ID="cmbOwnerOrgID" runat="server" CssClass="zComboBox" Width="300px" >
                            </asp:DropDownList>
                            <font color="red">*</font>
                            <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmbOwnerOrgID" PromptText=""
                                PromptCssClass="zHidden" PromptPosition="Bottom" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                            
                            <cc1:CascadingDropDown ID="cdlOwnerOrgID" runat="server" TargetControlID="cmbOwnerOrgID"
                                Category="OrgOwner" PromptText="เลือก" 
                                ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetOrgIDForDDL" />
                        </td>
                        <td align="right" class="Csslbl" >ผู้พิจารณา : </td>
                        <td valign="top">
                            <asp:DropDownList ID="cmbOwnerStaffID" runat="server" CssClass="zComboBox"  Width="250px" >
                            </asp:DropDownList>
                            <font color="red">*</font>
                            <cc1:CascadingDropDown ID="cdlOwnerStaffID" runat="server" TargetControlID="cmbOwnerStaffID"
                                Category="StaffOwner" PromptText="เลือก" LoadingText="กรุณารอสักครู่"
                                ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetStaffByOrgID"
                                ParentControlID="cmbOwnerOrgID"  />
                        </td>
                    </tr>
                    <tr >
                        <td align="right" class="Csslbl" >หมายเหตุ : </td>
                        <td colspan="3" >
                            <uc2:txtBox ID="txtRemarks" runat="server" Width ="770" MaxLength="500"  />
                        </td>
                    </tr>
                    <tr>
                        <td >&nbsp;</td>
                        <td colspan="3" class="Csslbl" >
                            <asp:RadioButtonList ID="rdiReceiveType" runat="server" RepeatDirection="Horizontal"  >
                                <asp:ListItem Value="0" Text="ลงทะเบียนรับจากภายนอก" Selected="True" onClick="ReceiveTypeChange('0');"  ></asp:ListItem>
                                <asp:ListItem Value="1" Text="ลงทะเบียนรับจากภายใน" onClick="ReceiveTypeChange('1');"  ></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlCompany" runat="server" BorderWidth="1" Width="95%" >
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        
                                            <tr style="height:25px">
                                                <td align="right" class="Csslbl" >เลขทะเบียนบริษัท : </td>
                                                <td align="left" class="Csslbl" >
                                                     <asp:TextBox ID="txtCompanyID" runat="server" CssClass="TextBox" AutoComplete="false" Width="300px"  MaxLength="13" />
                                                     <cc1:AutoCompleteExtender
                                                        runat="server" 
                                                        ID="companyIDAutocomplete" 
                                                        TargetControlID="txtCompanyID"
                                                        ServicePath="~/Template/AjaxScript.asmx"
                                                        ServiceMethod = "GetAutoCompleteCompanyID"
                                                        MinimumPrefixLength="1" 
                                                        CompletionInterval="500"
                                                        UseContextKey="true"
                                                        EnableCaching="true"
                                                        CompletionSetCount="10" FirstRowSelected="true"
                                                        CompletionListCssClass="autocomplete_completionListElement" 
                                                        CompletionListItemCssClass="autocomplete_listItem" 
                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                        ShowOnlyCurrentWordInCompletionListItem="true" 
                                                        OnClientItemSelected="SetCompanyByRegisNo" >
                                                     </cc1:AutoCompleteExtender>
                                                </td>
                                                <td align="right" class="Csslbl"></td>
                                                <td align="left" >
                                                   
                                                </td>
                                            </tr>
                                        
                                            <tr style="height:25px">
                                                <td align="right" class="Csslbl" style="width:20%" >เลขบัตรประชาชน : </td>
                                                <td align="left" class="Csslbl"  style="width:30%" >
                                                     <asp:TextBox ID="txtCompanyIDCardNo" runat="server" CssClass="TextBox" AutoComplete="false" Width="300px"  MaxLength="13" />
                                                     <cc1:AutoCompleteExtender
                                                        runat="server" 
                                                        ID="AutoCompleteExtender2" 
                                                        TargetControlID="txtCompanyIDCardNo"
                                                        ServicePath="~/Template/AjaxScript.asmx"
                                                        ServiceMethod = "GetAutoCompleteCompanyIDCardNo"
                                                        MinimumPrefixLength="1" 
                                                        CompletionInterval="500"
                                                        UseContextKey="true"
                                                        EnableCaching="true"
                                                        CompletionSetCount="10" FirstRowSelected="true"
                                                        CompletionListCssClass="autocomplete_completionListElement" 
                                                        CompletionListItemCssClass="autocomplete_listItem" 
                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                        ShowOnlyCurrentWordInCompletionListItem="true" 
                                                        OnClientItemSelected="SetCompanyByIDCardNo" >
                                                     </cc1:AutoCompleteExtender>
                                                </td>
                                                <td align="right" class="Csslbl" style="width:15%">เลขPassport : </td>
                                                <td align="left" style="width:35%">
                                                    <asp:TextBox ID="txtCompanyPassportNo" runat="server" CssClass="TextBox" AutoComplete="false" Width="260px"  MaxLength="50" />
                                                     <cc1:AutoCompleteExtender
                                                        runat="server" 
                                                        ID="AutoCompleteExtender3" 
                                                        TargetControlID="txtCompanyPassportNo"
                                                        ServicePath="~/Template/AjaxScript.asmx"
                                                        ServiceMethod = "GetAutoCompleteCompanyPassportNo"
                                                        MinimumPrefixLength="1" 
                                                        CompletionInterval="500"
                                                        UseContextKey="true"
                                                        EnableCaching="true"
                                                        CompletionSetCount="10" FirstRowSelected="true"
                                                        CompletionListCssClass="autocomplete_completionListElement" 
                                                        CompletionListItemCssClass="autocomplete_listItem" 
                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                        ShowOnlyCurrentWordInCompletionListItem="true" 
                                                        OnClientItemSelected="SetCompanyByPassportNo" >
                                                     </cc1:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                        
                                        
                                        
                                        
                                            <tr style="height:25px">
                                                <td align="right" class="Csslbl" >ชื่อองค์กร : </td>
                                                <td colspan="3" align="left">
                                                    <asp:TextBox runat="server" ID="txtCustName" Width="700" CssClass="TextBox" autocomplete="off" onBlur="ClearTxtCustValue()" ></asp:TextBox>&nbsp;
                                                    <cc1:AutoCompleteExtender
                                                        runat="server" ID="AutoCompleteExtender1" 
                                                        TargetControlID="txtCustName" ServicePath="~/Template/AjaxScript.asmx" ServiceMethod = "GetAllCompanyForDDL"
                                                        MinimumPrefixLength="3" CompletionInterval="200" UseContextKey="true" EnableCaching="true"
                                                        CompletionSetCount="20" FirstRowSelected="true" 
                                                        CompletionListCssClass="autocomplete_completionListElement" 
                                                        CompletionListItemCssClass="autocomplete_listItem" 
                                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                        DelimiterCharacters="*" BehaviorID="AutoCompleteEx" 
                                                        ShowOnlyCurrentWordInCompletionListItem="true"
                                                        OnClientPopulating="LoadImage" OnClientPopulated="HideImage" OnClientItemSelected="OnCustomerSelected"  >
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
                                                     <asp:TextBox ID="hdnCustValue" runat="server" CssClass="zHidden" ></asp:TextBox>
                                                     <asp:Button ID="btnSetCert" runat="server" CssClass="zHidden" />
                                                     <asp:Button ID="btnAddCustomer" runat="server" Text="เพิ่ม" Width="40px" CssClass="CssBtn" OnClientClick="OpenCompanyPopup('../WebApp/popAddCompany.aspx?rnd=<%=DateTime.Now.Millisecond %>',600,400); return false;" />
                                                </td>
                                            </tr>
                                            <tr style="height:25px">
                                                <td align="right" class="Csslbl" >เลขที่หนังสือองค์กร : </td>
                                                <td align="left" class="Csslbl" >
                                                    <table border="0" cellpadding="0" cellspacing="0" >
                                                        <tr>
                                                            <td>
                                                                <uc2:txtBox ID="txtCompanyDocNo" runat="server" Width="150px" MaxLength="100" />
                                                            </td>
                                                            <td width="80px" align="right">ลงวันที่ :&nbsp;</td>
                                                            <td width="150px">
                                                                <uc3:txtDate ID="txtCompanyDocDate" runat="server" IsNotNull="true" DefaultCurrentDate="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="right" class="Csslbl">ผู้ลงนาม : </td>
                                                <td align="left" >
                                                    <uc2:txtBox ID="txtCompanySignatureName" runat="server"  Width="260px"  />
                                                </td>
                                            </tr>
                                            <tr style="height:25px">
                                                <td align="right" class="Csslbl" >&nbsp;</td>
                                                <td colspan="3" >
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr valign="top">
                                                            <td width="15%" class="Csslbl" align="left" >
                                                                <script >
                                                                    function SupportCardNoClick() {
                                                                        document.getElementById("<%=cmbResolutionsNo.ClientID %>").disabled = true;

                                                                        var chk = document.getElementById("<%=chkCertNo.ClientID %>");
                                                                        if (chk != null)
                                                                            chk.disabled = false;
                                                                            
                                                                        return true;
                                                                    }
                                                                </script>
                                                                <asp:RadioButton ID="rdiSupportCardNo" runat="server" GroupName="CardNoType" onClick="return SupportCardNoClick();" Checked="true" Text="เลขที่บัตรส่งเสริม" />
                                                            </td>
                                                            <td width="35%" class="Csslbl" align="left" valign="top">
                                                                <%--<uc7:cmbAutoComplete ID="cmbPromoteNo" runat="server" Width="270px"  />--%>
                                                                <asp:CheckBoxList ID="chkCertNo" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" >
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td width="16%" class="Csslbl" align="left" >
                                                                <asp:RadioButton ID="rdiResolutionBookNo" runat="server" GroupName="CardNoType" onClick="return ResolutionBookNoClick();" Text="เลขที่หนังสือแจ้งมติ" />
                                                                <script >
                                                                    function ResolutionBookNoClick() {
                                                                        document.getElementById("<%=cmbResolutionsNo.ClientID %>").disabled = false;
                                                                        var chk = document.getElementById("<%=chkCertNo.ClientID %>");
                                                                        if (chk != null)
                                                                            chk.disabled = true;
                                                                            
                                                                        return true;
                                                                    }
                                                                </script>
                                                            </td>
                                                            <td width="34%" align="left"  valign="top" >
                                                                <uc7:cmbAutoComplete ID="cmbResolutionsNo" runat="server" Width="225px" DefaultDisplay="เลือก" Enabled="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height:25px">
                                                <td align="right" class="Csslbl" >ประเภทกิจการ : </td>
                                                <td align="left" colspan="3"  valign="top">
                                                    <uc7:cmbAutoComplete ID="cmbBusinessTypeID" runat="server" Width="743px"  />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" Corners="All" Color="#CCCCCC" BorderColor="#CCCCCC" 
                                     TargetControlID="pnlCompany" Radius="6"  >
                                    </cc1:RoundedCornersExtender>
                               </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr><td colspan="4">&nbsp;</td></tr>
                    <tr >
                        <td colspan="4" align="center" >
                            <asp:Panel ID="pnlOrg" runat="server" BorderWidth="1" Width="95%" >
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr style="height:30px">
                                        <td align="right" width="10%" class="Csslbl" >หน่วยงานที่รับ : </td>
                                        <td width="35%"  align="left"  valign="top">
                                            <asp:DropDownList ID="cmbReceiveOrgID" runat="server" CssClass="zComboBox" Width="300px"  >
                                            </asp:DropDownList>
                                            <cc1:ListSearchExtender id="ListSearchExtender2" runat="server" TargetControlID="cmbReceiveOrgID" PromptText=""
                                                PromptCssClass="zHidden" PromptPosition="Bottom" QueryTimeout="0" QueryPattern="Contains" IsSorted="true"   />
                                            <cc1:CascadingDropDown ID="cdlReceiveOrgID" runat="server" TargetControlID="cmbReceiveOrgID"
                                                Category="ReceiveOrg" PromptText="เลือก" 
                                                ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetOrgIDForDDL" />
                                        </td>
                                        <td align="right" width="15%" class="Csslbl">เจ้าหน้าที่รับ : </td>
                                        <td width="40%" align="left" valign="top" >
                                            <asp:DropDownList ID="cmbReceiveStaffID" runat="server" CssClass="zComboBox" Width="300px" >
                                            </asp:DropDownList>
                                            <cc1:CascadingDropDown ID="cdlReceiveStaffID" runat="server" TargetControlID="cmbReceiveStaffID"
                                                Category="ReceiveStaff" PromptText="เลือก" LoadingText="กรุณารอสักครู่"
                                                ServicePath="~/Template/AjaxScript.asmx" ServiceMethod="GetStaffByOrgID"
                                                ParentControlID="cmbReceiveOrgID" PromptValue="0"  />
                                        </td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" class="Csslbl">วัตถุประสงค์ : </td>
                                        <td  align="left"  valign="top">
                                            <uc7:cmbAutoComplete ID="cmbPurpose" runat="server" Width="300px"  />
                                        </td>
                                        <td align="right" valign="top" class="Csslbl">ข้อความ : </td>
                                        <td  align="left" rowspan="2" valign="top" >
                                            <uc2:txtBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="50px" Width ="300px" />
                                        </td>
                                    </tr>
                                    <tr style="height:30px">
                                        <td align="right" class="Csslbl" >&nbsp;</td>
                                        <td colspan="2"  align="left">
                                            <asp:Button ID="btnAdd"  runat="server" CssClass="CssBtn" Text="บันทึก" Width="50px"   />
                                            <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="เคลียร์" Width="50px"  />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="3">
                                            <asp:GridView ID="gvSendList" runat="server" AutoGenerateColumns="False" CssClass="mGrid" 
                                                GridLines="Vertical" Width="100%"  >
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <asp:BoundField DataField="OrgNameReceive" HeaderText="หน่วยงานรับ" >
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="StaffNameReceive" HeaderText="เจ้าหน้าที่รับ" >
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="purpose" HeaderText="วัตถุประสงค์" >
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="remark_receive" HeaderText="ข้อความ"  />
                                                    <asp:TemplateField HeaderText="ลบ" >
                                                        <ItemStyle Width="30px" HorizontalAlign="Center" ></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/Images/delete1.png" OnClientClick="return confirm('ยืนยันการลบรายการ?');" CommandName="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PurposeID" >
                                                        <ControlStyle CssClass="zHidden" />
                                                        <FooterStyle CssClass="zHidden" />
                                                        <HeaderStyle CssClass="zHidden" />
                                                        <ItemStyle CssClass="zHidden" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OrgNameReceiveID" >
                                                        <ControlStyle CssClass="zHidden" />
                                                        <FooterStyle CssClass="zHidden" />
                                                        <HeaderStyle CssClass="zHidden" />
                                                        <ItemStyle CssClass="zHidden" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="StaffNameReceiveID" >
                                                        <ControlStyle CssClass="zHidden" />
                                                        <FooterStyle CssClass="zHidden" />
                                                        <HeaderStyle CssClass="zHidden" />
                                                        <ItemStyle CssClass="zHidden" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OrgAbbNameReceive" >
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
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" Corners="All" Color="#CCCCCC" BorderColor="#CCCCCC" 
                             TargetControlID="pnlOrg" Radius="6"   >
                            </cc1:RoundedCornersExtender>
                        </td>
                    </tr>
                    <tr id="trNormalFlow" runat="server" >
                        <td colspan="4" align="right">
                            <asp:TextBox ID="txtScanJobID" runat="server"  Text="0" CssClass="zHidden" ></asp:TextBox>
                            <asp:Button ID="btnAttachFile" runat="server" CssClass="CssBtn" Text="เอกสารแนบ" Width="100px" OnClientClick="SaveScanJob('DOCUMENT_REGISTER');return false;"  />
                            <uc1:btnCloseJob ID="btnCloseJob1" runat="server" ButtonText="ลงทะเบียนพร้อมจบงาน" />
                            <asp:Button ID="btnNew" runat="server" CssClass="CssBtn" Text="เคลียร์" Width="80px" />&nbsp;
                            <bt1:btnSendInside ID="btnSendInside1" runat="server" />
                            <bt2:btnSendCircle ID="btnSendCircle1" runat="server"  />
                            <uc9:btnSendOutside ID="btnSendOutside1" runat="server"  />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
            function SaveScanJob(ClientPage) {
                var UserName = '<%=Config.GetLogOnUser.UserName %>';
                var ClientBrowser = navigator.userAgent.toLowerCase();
                var ClientSessionID = '<%=Session.SessionID%>';
                var RefID = document.getElementById("<%=txtID.ClientID %>").value;
                var txtScanJobID = document.getElementById("<%=txtScanJobID.ClientID %>").value;
                
                AjaxScript.SaveTransLog("frmDocumentRegister.aspx คลิกปุ่มเอกสารแนบ");
                if (txtScanJobID == "0") {
                    var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
                    $.ajax({
                        type: "POST",
                        url: pageUrl + "/SaveScanJob",
                        data: "{'UserName':'" + UserName + "','ClientPage':'" + ClientPage + "','ClientBrowser':'" + ClientBrowser + "','ClientSessionID':'" + ClientSessionID + "','RefID':'" + RefID + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            var txtJobID = msg.d;
                            var RefID = document.getElementById('<%=txtID.ClientID %>').value;
                            document.getElementById('<%=txtScanJobID.ClientID %>').value = txtJobID;
                            ShopScanPop(txtJobID, RefID);
                        }
                    });
                } else {
                    ShopScanPop(txtScanJobID, RefID);
                }
            }

            function ShopScanPop(JobID, RefID) {
                try {
                    var path = "<%=Config.GetScannerPath %>" + " -" + JobID + " -" + RefID;
                    var ua = navigator.userAgent.toLowerCase();
                    if (ua.indexOf("msie") != -1) {
                        //OpenAttachFileWindow(document.getElementById('<%=txtID.ClientID %>').value);
                        //alert("JobID: " + JobID + " ##### RefID : " + RefID);
                        //OpenAttachFileWindow(document.getElementById('<%=txtID.ClientID %>').value);
                        <%=Config.CreateActiveFunction %>
                    } else {
                        OpenAttachFileWindow(document.getElementById('<%=txtID.ClientID %>').value);
                    }
                } catch (ex) {
                    //alert(ex.toString() + ": ไม่พบไดร์ฟเวอร์ของเครื่องสแกนเอกสาร");
                    OpenAttachFileWindow(document.getElementById('<%=txtID.ClientID %>').value);
                }
            }
           
            //กลุ่มเรื่อง
            function BindGroupTitleChange() {
                var txtDocRefID = document.getElementById("<%=txtDocRefID.ClientID %>");
                var txtTHeGIFDocID = document.getElementById("<%=txtTHeGIFDocID.ClientID %>");
                var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
                if ($(txtDocRefID).val() == "0" && $(txtTHeGIFDocID).val() == "0") {
                    $("#ctl00_ContentPlaceHolder1_txtTitle_TextBox1").val($("#ctl00_ContentPlaceHolder1_cmbGroupTitle option:selected").text());
                }
                
                $.ajax({
                    type: "POST",
                    url: pageUrl + "/GetGroupTitleData",
                    data: "{'vGroupTitleID':'" + $("#ctl00_ContentPlaceHolder1_cmbGroupTitle").val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var gData = msg.d.split("###");
                        if (gData.length==2){
                            $("#ctl00_ContentPlaceHolder1_txtExpectDate_txtdate").val(gData[0]);
                            if(gData[0]!="")
                                $("#ctl00_ContentPlaceHolder1_txtExpectDate_ImageButton1").hide();
                            else
                                $("#ctl00_ContentPlaceHolder1_txtExpectDate_ImageButton1").show();
                                
                            if(gData[1]=="Y")
                                $("#ctl00_ContentPlaceHolder1_txtTitle_TextBox1").val("");
                        }
                    }
                });
            }

            
            function CheckCompanyDocNo() {
                var vDocNo = document.getElementById("ctl00_ContentPlaceHolder1_txtCompanyDocNo_TextBox1");
                if ($(vDocNo).val() != ""){
                    //alert($(vDocNo).val());
                    var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
                    $.ajax({
                        type: "POST",
                        url: pageUrl + "/CheckCompanyDocNo",
                        data: "{'vCompanyDocNo':'" + $(vDocNo).val() + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            if (msg.d != "") {
                                alert("เลขที่หนังสือองค์กรซ้ำ" + msg.d);
                                //vDocNo.select();
                                return false;
                            } else {
                                return true;
                            }
                        }
                    });
                }
            }

            function ReceiveTypeChange(ReceiveType) {
                var hdnCustValue = document.getElementById('<%=hdnCustValue.ClientID%>');
                var txtCustName = document.getElementById('<%=txtCustName.ClientID%>');
                var txtCompanyRegisNo = document.getElementById('<%=txtCompanyID.ClientID%>');
                
                if (ReceiveType == "1") {
                    var vOrgID = '<%=Config.GetLogOnUser.ORG_DATA.ID %>';                    
                    var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
                    $.ajax({
                        type: "POST",
                        url: pageUrl + "/GetCompanyNameByOrgID",
                        data: "{'OrgID':'" + vOrgID + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg) {
                            var ret = msg.d;
                            hdnCustValue.value = ret[0];
                            txtCustName.value = ret[1];
                            txtCompanyRegisNo.value = ret[2];
                            
                            txtCustName.disabled = true;
                            txtCompanyRegisNo.disabled = true;
                        }
                    });
                } else {
                    hdnCustValue.value = "";
                    txtCustName.value = "";
                    txtCustName.disabled = false;
                    txtCompanyRegisNo.disabled = false;
                }
            }
            
            function SetCompanyByRegisNo(){
                var hdnCustValue = document.getElementById('<%=hdnCustValue.ClientID%>');
                var txtCustName = document.getElementById('<%=txtCustName.ClientID%>');
                var txtCompanyRegisNo = document.getElementById('<%=txtCompanyID.ClientID%>');
                var txtCompanyIDCardNo = document.getElementById('<%=txtCompanyIDCardNo.ClientID%>');
                var txtCompanyPassportNo = document.getElementById('<%=txtCompanyPassportNo.ClientID %>');
                
                var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
                $.ajax({
                    type: "POST",
                    url: pageUrl + "/GetCompanyNameByRegisNo",
                    data: "{'CompanyRegisNo':'" + $(txtCompanyRegisNo).val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var ret = msg.d;
                        hdnCustValue.value = ret[0];
                        txtCustName.value = ret[1];
                        txtCompanyIDCardNo.value = "";
                        txtCompanyPassportNo.value = "";
                        return true;
                    }
                });
            }
            
            function SetCompanyByIDCardNo(){
                var hdnCustValue = document.getElementById('<%=hdnCustValue.ClientID%>');
                var txtCustName = document.getElementById('<%=txtCustName.ClientID%>');
                var txtCompanyRegisNo = document.getElementById('<%=txtCompanyID.ClientID%>');
                var txtCompanyIDCardNo = document.getElementById('<%=txtCompanyIDCardNo.ClientID%>');
                var txtCompanyPassportNo = document.getElementById('<%=txtCompanyPassportNo.ClientID %>');
                
                var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
                $.ajax({
                    type: "POST",
                    url: pageUrl + "/GetCompanyNameByIDCardNo",
                    data: "{'CompanyIDCardNo':'" + $(txtCompanyIDCardNo).val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var ret = msg.d;
                        hdnCustValue.value = ret[0];
                        txtCustName.value = ret[1];
                        txtCompanyRegisNo.value = "";
                        txtCompanyPassportNo.value = "";
                        return true;
                    }
                });
            }
            
            function SetCompanyByPassportNo(){
                var hdnCustValue = document.getElementById('<%=hdnCustValue.ClientID%>');
                var txtCustName = document.getElementById('<%=txtCustName.ClientID%>');
                var txtCompanyRegisNo = document.getElementById('<%=txtCompanyID.ClientID%>');
                var txtCompanyIDCardNo = document.getElementById('<%=txtCompanyIDCardNo.ClientID%>');
                var txtCompanyPassportNo = document.getElementById('<%=txtCompanyPassportNo.ClientID %>');
                
                var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
                $.ajax({
                    type: "POST",
                    url: pageUrl + "/GetCompanyNameByPassportNo",
                    data: "{'CompanyPassportNo':'" + $(txtCompanyPassportNo).val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        var ret = msg.d;
                        hdnCustValue.value = ret[0];
                        txtCustName.value = ret[1];
                        txtCompanyRegisNo.value = "";
                        txtCompanyIDCardNo.value = "";
                        return true;
                    }
                });
            }
    </script>
</asp:Content>


