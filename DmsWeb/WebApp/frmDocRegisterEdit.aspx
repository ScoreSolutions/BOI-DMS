<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDocRegisterEdit.aspx.vb" EnableEventValidation="false" Inherits="WebApp_frmDocRegisterEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
<%@ Register src="~/UserControls/ctlCompany.ascx" tagname="ctlCompany" tagprefix="uc6" %>
<%@ Register src="~/UserControls/ctlUploadFile.ascx" tagname="ctlUploadFile" tagprefix="uc5" %>
<%@ Register src="~/UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc7" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc8" %>
<%@ Register Src="~/UserControlsButton/btnSendInside.ascx" TagName="btnSendInside" TagPrefix="bt1" %>
<%@ Register Src="~/UserControlsButton/btnSendCircle.ascx" TagName="btnSendCircle" TagPrefix="bt2" %>
<%@ Register src="../UserControlsButton/btnCloseJob.ascx" tagname="btnCloseJob" tagprefix="uc1" %>
<%@ Register src="../UserControlsButton/btnSendOutside.ascx" tagname="btnSendOutside" tagprefix="uc9" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" language="JavaScript" src="../Template/JScript.js"></script>
    <script type="text/javascript" src="../Template/datetimepicker_css.js"></script>
    <link  href="../Template/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="JavaScript" src="../Template/jquery-1.7.2.min.js"></script>
    
    <script type="text/JavaScript" language="JavaScript">
        function pageLoad() {
            var manager = Sys.WebForms.PageRequestManager.getInstance();
            manager.add_endRequest(endRequest);
            manager.add_beginRequest(OnBeginRequest);
        }
        function OnBeginRequest(sender, args) {
            $get('pageContent').className = 'onProgress';
        }
        function endRequest(sender, args) {
            $get('pageContent').className = '';
        }

        function SaveTransLog(TransDesc, LoginHisID) {
            //AjaxScript.SaveTransLog(TransDesc, LoginHisID);
            var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
            $.ajax({
                type: "POST",
                url: pageUrl + "/SaveTransLog",
                data: "{'TransDesc':'" + TransDesc + "','LoginHisID':'" + LoginHisID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    return true;
                }
            });
        }
        
        function OpenAttachFileWindow(id, btn) {
            var RndNum =  1 + Math.floor(Math.random() * 6);
            var WinSettings = "center:yes;resizable:no;dialogWidth:600px;dialogHeight:500px;scrollbars:yes";
            var MyArgs = window.showModalDialog("../WebApp/PopAttachFile.aspx?id=" + id + "&rnd=" + RndNum, null, WinSettings);

            var bt = document.getElementById(btn);
            if (bt) {
                bt.click();
                return false;
            }
        }

        function OpenModalPopup(url, width, height) {
            var RndNum = 1 + Math.floor(Math.random() * 6);
            var WinSettings = "center:yes;resizable:no;dialogWidth:" + width + "px;dialogHeight:" + height + "px;scrollbars:yes";
            var MyArgs = window.showModalDialog(url + "&rnd=" + RndNum, null, WinSettings);
        }

//        function PrintReport(vReportName, vID) {
//            var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
//            //พิมพ์ใบตอบรับคำขอ
//            $.ajax({
//                type: "POST",
//                url: pageUrl + "/GetReportURL",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg) {
//                    if (msg.d != "") {
//                        var pStr = msg.d + 'ReportName=' + vReportName + '&ID=' + vID;
//                        window.open(pStr, '_blank', 'height=650,left=600,location=no,menubar=no,toolbar=no,status=yes,resizable=yes,scrollbars=yes', true);
//                    }
//                }
//            });
//        }

//        function PreviewReport(url) {
//            window.open(url, '_blank', 'height=650,left=0,location=yes,menubar=yes,toolbar=yes,status=yes,resizable=yes,scrollbars=yes', true);
//        }

//        function ClickNewDoc(LoginHisID) {
//            SaveTransLog("คลิกปุ่มมีเอกสารใหม่", LoginHisID);
//            document.location.href = '../WebApp/frmDocToDoList.aspx?rnd=' + (new Date().getMilliseconds());
//        }
//        function ClickDocSendBackSystem(LoginHisID) {
//            SaveTransLog("คลิกปุ่มมีเอกสารตีกลับโดยระบบ", LoginHisID);
//            document.location.href = '../WebApp/frmDocRemainSendBack.aspx?rnd=' + (new Date().getMilliseconds());
//        }



    </script>


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
            var custVal = eventArgs.get_value();
            document.getElementById('<%=hdnCustValue.ClientID%>').value = custVal;

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

            oXmlHttp.setRequestHeader("Connection", "close");


            //เลขที่หนังสือแจ้งมติ
            var cmb = document.getElementById("<%=cmbResolutionsNo.ClientID %>");
            $.ajax({
                type: "POST",
                url: pageUrl + "/GetNotification",
                data: "{'vCompanyID':'" + custVal + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d == "Y" && retMsg == "N") {
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
            }
        }

        function OpenCompanyPopup(url, width, height) {
            var RndNum = 1 + Math.floor(Math.random() * 6);
            var WinSettings = "center:yes;resizable:no;dialogWidth:" + width + "px;dialogHeight:" + height + "px;scrollbars:yes";
            var MyArgs = window.showModalDialog(url + "&rnd=" + RndNum, null, WinSettings);

            if (MyArgs != null) {
                document.getElementById('<%=hdnCustValue.ClientID%>').value = MyArgs[0];
                document.getElementById('<%=txtCustName.ClientID%>').value = MyArgs[1];
            }
        }
    </script>
</head>
<body leftmargin="0">
    <center>
        <table width="1000px" id="pageContent" >
            <tr>
                <td style="width: 100%" >
                    <form id="form1" runat="server" enctype="multipart/form-data">
                    <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" >
                        <Services>
                        <asp:ServiceReference Path="~/Template/AjaxScript.asmx" />
                        </Services>
                    </cc1:ToolkitScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
                        <ContentTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td colspan="2"  >  <!-- Content -->
                                        <table width="100%" border="1" height="510px"  >
                                            <tr valign="top">
                                                <td>
                                                    
                                                    
                                                    
                                                    
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0" >
                                                            <tr>
                                                                <td class="CssHead" colspan="4" align="left" >แก้ไขรายละเอียดหนังสือ</td>
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
                                                                                <asp:TextBox ID="txtRefDocRegisID" runat="server" Text="0" CssClass="zHidden"></asp:TextBox>
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
                                                                                <uc2:txtBox ID="txtTitle" runat="server"  Width="770px" IsNotNull ="true"  />
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height:25px" id="trDateRow" runat="server">
                                                                            <td align="right" class="Csslbl">วันที่รับ :</td>
                                                                            <td colspan="3" >
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="90%">
                                                                                    <tr>
                                                                                        <td align="left" width="15%">
                                                                                            <uc3:txtDate ID="txtReceiveDate" runat="server" IsNotNull="false" VisibleImg="false" />
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
                                                                                <uc2:txtBox ID="txtRemarks" runat="server" Width ="770" TextMode ="MultiLine"   Height="30" />
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
                                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Panel ID="pnlCompany" runat="server" BorderWidth="1" Width="95%" >
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr style="height:25px">
                                                                                                    <td align="right" class="Csslbl" >ชื่อองค์กร : </td>
                                                                                                    <td colspan="3" align="left">
                                                                                                        <asp:TextBox runat="server" ID="txtCustName" Width="700" CssClass="TextBox" autocomplete="off" onBlur="ClearTxtCustValue()" ></asp:TextBox>&nbsp;
                                                                                                        <cc1:AutoCompleteExtender
                                                                                                            runat="server" ID="AutoCompleteExtender1" 
                                                                                                            TargetControlID="txtCustName" ServicePath="~/Template/AjaxScript.asmx" ServiceMethod = "GetAllCompanyForDDL"
                                                                                                            MinimumPrefixLength="3" CompletionInterval="500" UseContextKey="true" EnableCaching="true"
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
                                                                                                         <asp:TextBox ID="hdnCustValue" runat="server" CssClass="zHidden"  ></asp:TextBox>
                                                                                                         <asp:TextBox ID="txtCompanyDocSysID" runat="server" CssClass="zHidden"  ></asp:TextBox>
                                                                                                         <asp:Button ID="btnSetCert" runat="server" CssClass="zHidden" />
                                                                                                         <asp:Button ID="btnAddCustomer" runat="server" Text="เพิ่ม" Width="40px" CssClass="CssBtn" OnClientClick="OpenCompanyPopup('../WebApp/popAddCompany.aspx?rnd=<%=DateTime.Now.Millisecond %>',600,300); return false;" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="height:25px">
                                                                                                    <td align="right" class="Csslbl" >เลขที่หนังสือองค์กร : </td>
                                                                                                    <td align="left" class="Csslbl" >
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" >
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <uc2:txtBox ID="txtCompanyDocNo" runat="server"  MaxLength="100" />
                                                                                                                </td>
                                                                                                                <td width="80px" align="right">ลงวันที่ :&nbsp;</td>
                                                                                                                <td width="150px">
                                                                                                                    <uc3:txtDate ID="txtCompanyDocDate" runat="server" IsNotNull="true"  />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td align="right" class="Csslbl">ผู้ลงนาม : </td>
                                                                                                    <td align="left" >
                                                                                                        <uc2:txtBox ID="txtCompanySignatureName" runat="server"  Width="260"  />
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
                                                                                                                    <uc7:cmbAutoComplete ID="cmbResolutionsNo" runat="server" Width="205px" DefaultDisplay="เลือก" Enabled="false" />
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
                                                                            <td colspan="4" align="center">
                                                                                <asp:TextBox ID="txtScanJobID" runat="server"  Text="0" CssClass="zHidden" ></asp:TextBox>
                                                                                <asp:Button ID="btnAttachFile" runat="server" CssClass="CssBtn" Text="เอกสารแนบ" Width="100px" OnClientClick="SaveScanJob('DOCUMENT_REGISTER');return false;"  />
                                                                                <asp:Button ID="btnSave" runat="server" CssClass="CssBtn" Text="บันทึก" Width="100px" />
                                                                                <asp:Button ID="btnCancel" runat="server" CssClass="CssBtn" Text="ยกเลิก" Width="100px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                        
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute;
                                left: 0; top: 0; width: 100%; height: 100%; visibility: visible; vertical-align: middle;
                                border-style: inset; border-color: black; background-color: #000000; z-index: 20000">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:Image ID="Image1" runat="server" ImageUrl="../Images/icon_inprogress.gif" CssClass="" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    </form>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>

<script language="javascript" type="text/javascript">
    function SaveScanJob(ClientPage) {
        var UserName = '<%=Config.GetLogOnUser.UserName %>';
        var ClientBrowser = navigator.userAgent.toLowerCase();
        var ClientSessionID = '<%=Session.SessionID%>';
        var RefID = document.getElementById("<%=txtID.ClientID %>").value;
        var txtScanJobID = document.getElementById("<%=txtScanJobID.ClientID %>").value;

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
        var txtID = document.getElementById("<%=txtID.ClientID %>");
        var txtDocRefID = document.getElementById("<%=txtDocRefID.ClientID %>");
        var txtTHeGIFDocID = document.getElementById("<%=txtTHeGIFDocID.ClientID %>");
        var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
        if ($(txtDocRefID).val() == "0" && $(txtTHeGIFDocID).val() == "0") {
            $("#txtTitle_TextBox1").val($("#cmbGroupTitle option:selected").text());
        }
       
        
        $.ajax({
            type: "POST",
            url: pageUrl + "/GetGroupTitleEditData",
            data: "{'vGroupTitleID':'" + $("#cmbGroupTitle").val() + "','vDocRegisID':'" + $(txtID).val() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
                //alert(msg.d);
                var gData = msg.d.split("###");
                if (gData.length==2){
                    $("#txtExpectDate_txtdate").val(gData[0]);
                    if(gData[0]!="")
                        $("#txtExpectDate_ImageButton1").hide();
                    else
                        $("#txtExpectDate_ImageButton1").show();
                        
                    if(gData[1]=="Y")
                        $("#txtTitle_TextBox1").val("");
                }
            }
        });
    }

    
    function CheckCompanyDocNo() {
        var vDocNo = document.getElementById("txtCompanyDocNo_TextBox1");
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

    function ReceiveTypeChange(ReceiveType) {
        var hdnCustValue = document.getElementById('<%=hdnCustValue.ClientID%>');
        var txtCustName = document.getElementById('<%=txtCustName.ClientID%>');
        
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
                    txtCustName.disabled = true;
                }
            });
        } else {
            hdnCustValue.value = "";
            txtCustName.value = "";
            txtCustName.disabled = false;
        }
    }
</script>