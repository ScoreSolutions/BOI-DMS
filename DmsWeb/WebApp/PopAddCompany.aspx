<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PopAddCompany.aspx.vb" Inherits="WebApp_PopAttachFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtBox" tagprefix="uc4" %>
<%@ Register Src="~/UserControls/cmbAutoComplete.ascx" TagName="cmbAutoComplete" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOI-DMS : เพิ่มชื่อองค์กร</title>

    <script type="text/javascript" language="JavaScript" src="../Template/JScript.js"></script>
    <script type="text/javascript" language="JavaScript" src="../Template/jquery-1.7.2.min.js"></script>
    <link  href="../Template/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        
        function SendValue() {
            var vUserName = '<%=Config.GetLogOnUser.UserName %>';
            var vThaiName = document.getElementById("<%=txtThaiName.ClientID %>");
            var vEngName = document.getElementById("<%=txtEngName.ClientID %>");
            var vAddress = document.getElementById("<%=txtAddress.ClientID %>");
            var vCompanyType = document.getElementById("<%=cmbCompanyType.ClientID %>");
            var vTel = document.getElementById("<%=txtTel.ClientID %>");
            var vFax = document.getElementById("<%=txtFax.ClientID %>");
            var vZipcode = "";
            var ProvinceID = "0";
            var DistrictID = "0";

            if ($(vCompanyType).val() == "0") {
                alert("กรุณาเลือกประเภทองค์กร");
                $(vCompanyType).focus();
                return false;
            }
            if ($(vThaiName).val() == "") {
                alert("กรุณาระบุชื่อองค์กร");
                $(vThaiName).select();
                return false;
            }

            AjaxScript.SaveTransLog("popAddCompany.aspx เพิ่มชื่อองค์กร : " + $(vThaiName).val(), '<%=Config.GetLoginHistoryID %>');
            
            var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>';
            $.ajax({
                type: "POST",
                url: pageUrl + "/SaveCompany",
                data: "{'UserName':'" + vUserName + "','ThaiName':'" + $(vThaiName).val() + "','EngName':'" + $(vEngName).val() + "','vAddress':'" + $(vAddress).val() + "','CompanyType':'" + $(vCompanyType).val() + "','vTel':'" + $(vTel).val() + "','vFax':'" + $(vFax).val() + "','vZipcode':'" + vZipcode + "','ProvinceID':'" + ProvinceID + "','DistrictID':'" + DistrictID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    if (msg.d != "0") {
                        var ret = new Array();
                        ret[0] = msg.d;
                        ret[1] = $(vThaiName).val();
                        window.returnValue = ret;
                    } else {
                        window.returnValue = null;
                    }
                    window.close();
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server">
            <Services>
            <asp:ServiceReference Path="~/Template/AjaxScript.asmx" />
            </Services>
        </cc1:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table ID="Table1" runat="server" bgcolor="#ffffff" border="0" cellpadding="0" 
                    cellspacing="0" style="border: solid 0px 0px 0px 0px #ff0000" width="600">
                    <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                        <td align="left" bgcolor="#3B5998" class="cssHead" width="15%">เพื่มชื่อองค์กร</td>
                        <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                            &nbsp;
                            <input type = "hidden" id = "hidSessionID" value = '<%=Session.SessionID%>' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="divBrowseFile">
                                <table width="100%">
                                    <tr><td colspan="2">&nbsp;</td></tr>
                                    <tr>
                                        <td align="right" class="Csslbl" width="15%">
                                            ประเภทองค์กร :
                                        </td>
                                        <td align="left" class="Csslbl">
                                            <asp:DropDownList ID="cmbCompanyType" runat="server" Width="400"></asp:DropDownList>
                                            <font color="red">*</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="Csslbl" width="15%">
                                            ชื่อไทย :
                                        </td>
                                        <td align="left" class="Csslbl">
                                            <uc4:txtBox ID="txtThaiName" runat="server" IsNotNull="True" Width="400" TableName="COMPANY" FieldName="thaiName" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="Csslbl"  >
                                            ชื่ออังกฤษ :
                                        </td>
                                        <td align="left" >
                                            <uc4:txtBox ID="txtEngName" runat="server" IsNotNull="False" Width="400" TableName="COMPANY" FieldName="engName"  />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="Csslbl" valign="top" >
                                            ที่อยู่ :
                                        </td>
                                        <td align="left" >
                                            <uc4:txtBox ID="txtAddress" runat="server" IsNotNull="False" Width="400" TextMode="MultiLine" Height="50px" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td align="right" class="Csslbl" width="15%">
                                            จังหวัด :
                                        </td>
                                        <td align="left" class="Csslbl">
                                            <uc2:cmbAutoComplete ID="cmbProvince" runat="server" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="Csslbl" width="15%">
                                            อำเภอ :
                                        </td>
                                        <td align="left" class="Csslbl">
                                            <uc2:cmbAutoComplete ID="cmbAmphur" runat="server" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="Csslbl"  >
                                            รหัสไปรษณีย์ :
                                        </td>
                                        <td align="left" >
                                            <uc4:txtBox ID="txtZipcode" runat="server" IsNotNull="False" MaxLength="5" Width="200" />
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="right" class="Csslbl"  >
                                            โทรศัพท์ :
                                        </td>
                                        <td align="left" >
                                            <uc4:txtBox ID="txtTel" runat="server" IsNotNull="False" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="Csslbl"  >
                                            โทรสาร :
                                        </td>
                                        <td align="left" >
                                            <uc4:txtBox ID="txtFax" runat="server" IsNotNull="False" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnSave" runat="server" CssClass="CssBtn" Text="บันทึก" Width="80px" OnClientClick="SendValue(); return false;" />
                                            &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="CssBtn" Text="ยกเลิก" Width="80px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
