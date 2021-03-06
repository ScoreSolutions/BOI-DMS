﻿<%@ Page Language="VB" AutoEventWireup="false" EnableEventValidation="false" CodeFile="frmDocChangeBookOut.aspx.vb" Inherits="WebApp_frmDocChangeBookOut" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserPageControls/ctlDocBookDetailShow.ascx" tagname="ctlDocBookDetailShow" tagprefix="uc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
        function LoadImage() {
            document.getElementById('<%=hdnCustValue.ClientID%>').value = '';
            document.getElementById('<%=txtCustName.ClientID%>').style.backgroundImage = 'url(../images/loading.gif)';
            document.getElementById('<%=txtCustName.ClientID%>').style.backgroundRepeat = 'no-repeat';
            document.getElementById('<%=txtCustName.ClientID%>').style.backgroundPosition = 'right';
        }
        function HideImage() {
            document.getElementById('<%=txtCustName.ClientID%>').style.backgroundImage = 'none';
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
         function ClearTxtCustValue() {
            if (document.getElementById('<%=txtCustName.ClientID%>').value == "") {
                document.getElementById('<%=hdnCustValue.ClientID%>').value = "";
                document.getElementById('<%=txtCompanyID.ClientID%>').value = "";
            }
        }
        function OnCustomerSelected(source, eventArgs) {
            var retVal = eventArgs.get_value().split("|");
            var custVal = retVal[0];
            document.getElementById('<%=hdnCustValue.ClientID%>').value = custVal;
            document.getElementById('<%=txtCompanyID.ClientID%>').value = retVal[1];


            }

        function HideMenu() {
            var mnuMenu = document.getElementById("divMenu");
            if (mnuMenu.style.display == '') {
                mnuMenu.style.display = 'none';
            } else {
                mnuMenu.style.display = '';
                mnuMenu.style.left = document.getElementById("ctl00_btnMenu").style.left;
            }
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

        function PrintReport(vReportName, vID) {
            var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
            //พิมพ์ใบตอบรับคำขอ
            $.ajax({
                type: "POST",
                url: pageUrl + "/GetReportURL",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d != "") {
                        var pStr = msg.d + 'ReportName=' + vReportName + '&ID=' + vID;
                        window.open(pStr, '_blank', 'height=650,left=600,location=no,menubar=no,toolbar=no,status=yes,resizable=yes,scrollbars=yes', true);
                    }
                }
            });
        }
    </script>
</head>
<body>
    <center>
        <table width="1000px" id="pageContent" >
            <tr>
                <td style="width: 100%" >
                    <form id="form1" runat="server" enctype="multipart/form-data">
                    <cc1:toolkitscriptmanager ID="ScriptManager1" runat="server" >
                        <Services>
                        <asp:ServiceReference Path="~/Template/AjaxScript.asmx" />
                        </Services>
                    </cc1:toolkitscriptmanager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
                        <ContentTemplate>

                            <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td>เลขที่หนังสือ : <uc2:txtBox ID="txtSearchBookNo" runat="server" Width ="150px" />
                                        <asp:Button ID="btnSearchDoc"  runat="server" CssClass="CssBtn" Text="ค้นหา" Width="50px"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td >  <!-- Content -->
                                        <uc1:ctlDocBookDetailShow ID="ctlDocBookDetailShow1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlOrg" runat="server" BorderWidth="1" Width="100%" >
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="CssHead" colspan="4" align="left" >
                                                        แก้ไขข้อมูลการส่งออก
                                                    </td>
                                                </tr>
                                                
                                                
                                                <tr style="height:30px">
                                                    <td align="right" width="15%" class="Csslbl" >เลขที่หนังสือส่งออก : </td>
                                                    <td width="30%"  align="left"  valign="top">
                                                        <uc7:cmbAutoComplete ID="cmbBookOutNo" runat="server" Width="300px"  />
                                                    </td>
                                                    <td align="right" width="15%" class="Csslbl">เลขทะเบียนบริษัท : </td>
                                                    <td width="40%" align="left" valign="top" >
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
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td align="right" width="15%" class="Csslbl">ชื่อองค์กร : </td>
                                                    <td align="left" valign="top" >
                 
                                                        <asp:TextBox runat="server" ID="txtCustName" Width="300" CssClass="TextBox" autocomplete="off" onBlur="ClearTxtCustValue()" ></asp:TextBox>&nbsp;
                                                        <cc1:AutoCompleteExtender
                                                        runat="server" ID="AutoCompleteExtender1" 
                                                        TargetControlID="txtCustName" ServicePath="~/Template/AjaxScript.asmx" ServiceMethod = "GetAllCompanyForDDL"
                                                        MinimumPrefixLength="3" CompletionInterval="200" UseContextKey="true" EnableCaching="true"
                                                        CompletionSetCount="40" FirstRowSelected="true" 
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
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td align="right" class="Csslbl">เลขที่หนังสือ : </td>
                                                    <td align="left" valign="top" >
                                                        <uc2:txtBox ID="txtNewBookNo" runat="server" TableName="DOCUMENT_REGISTER" FieldName="book_no" Width ="300px" AutoPosBack="true" />
                                                        <asp:Label ID="lblNewDocumentRegisterID" runat="server" Text="0" Visible="false" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height:30px">
                                                    <td align="right" class="Csslbl" >&nbsp;</td>
                                                    <td colspan="2"  align="left">
                                                        <asp:Button ID="btnSave"  runat="server" CssClass="CssBtn" Text="บันทึก" Width="50px"   />
                                                        <asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="เคลียร์" Width="50px"  />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" Corners="All" Color="#CCCCCC" BorderColor="#CCCCCC" 
                                         TargetControlID="pnlOrg" Radius="6"   >
                                        </cc1:RoundedCornersExtender>
                                        
                                        
                                        <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                                        <asp:Panel ID="Panel1" runat="server" Width="600">
                                            <table id="Table1" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
                                                cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                                                <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                                                    <td align="left" bgcolor="#3B5998" class="cssHead">
                                                        ยืนยันแก้ไขหนังสือส่งออก
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
                                                        ต้องการแก้ไขหนังสือส่งออกรายละเอียดดังนี้ใช่หรือไม่
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Csslbl" colspan="2">
                                                        <asp:GridView ID="gvComfirmChangeList" runat="server" AutoGenerateColumns="False" 
                                                            Width="100%" CssClass="GridViewStyle" >
                                                            <RowStyle CssClass="RowStyle"  />
                                                            <Columns>
                                                                <asp:BoundField DataField="book_no" HeaderText="เลขที่หนังสือ" >
                                                                    <HeaderStyle  />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                               <%-- <asp:BoundField DataField="company_id" HeaderText="เลขทะเบียนบริษัท" >
                                                                    <HeaderStyle Width="120px" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                </asp:BoundField>--%>
                                                                <asp:BoundField DataField="company_name" HeaderText="ชื่อองค์กร" >
                                                                    <HeaderStyle Width="120px" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="company_regis_no" HeaderText="เลขทะเบียนบริษัท" >
                                                                    <HeaderStyle Width="150px" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="bookout_no" HeaderText="เลขที่หนังสือส่งออก" >
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
                                    </td>
                                </tr>
                            </table>
                            <script language="javascript" type="text/javascript">

                                function SetCompanyByRegisNo(){
                                    var hdnCustValue = document.getElementById('<%=hdnCustValue.ClientID%>');
                                    var txtCustName = document.getElementById('<%=txtCustName.ClientID%>');
                                    var txtCompanyRegisNo = document.getElementById('<%=txtCompanyID.ClientID%>');
                                    
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
                                            return true;
                                        }
                                    });
                                }
                            </script>
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
