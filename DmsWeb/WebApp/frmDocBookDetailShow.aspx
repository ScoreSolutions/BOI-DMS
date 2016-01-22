<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDocBookDetailShow.aspx.vb" Inherits="WebApp_frmDocBookDetailShow" %>

<%@ Register src="../UserPageControls/ctlDocBookDetailShow.ascx" tagname="ctlDocBookDetailShow" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                                    <td >  <!-- Content -->
                                        <uc1:ctlDocBookDetailShow ID="ctlDocBookDetailShow1" runat="server" />
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
