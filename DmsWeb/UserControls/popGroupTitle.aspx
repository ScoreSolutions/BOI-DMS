<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popGroupTitle.aspx.vb" Inherits="UserControls_popGroupTitle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc4" %>
<%@ Register src="PageControl.ascx" tagname="pagecontrol" tagprefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOI-DMS : กลุ่มเรื่อง</title>
    <script type="text/javascript" language="JavaScript" src="../Template/JScript.js"></script>
    <link  href="../Template/StyleSheet.css" rel="stylesheet" type="text/css" />
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
                <table id="Table1" width="600" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                    style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
                    <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 20px; font-weight: bold;">
                        <td align="left" bgcolor="#3B5998" class="cssHead" colspan="2" >กลุ่มเรื่อง</td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl" width="20%">
                            ชื่อกลุ่มเรื่อง :
                        </td>
                        <td width="80%">
                            <uc4:txtBox ID="txtsGroupTitleName" runat="server" IsNotNull="false" Width="300" />
                        </td>
                    </tr>      
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="60px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" >
                            <uc1:PageControl ID="pcTop" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AllowSorting="True" AlternatingRowStyle-CssClass="alt" 
                                AutoGenerateColumns="False"  DataKeyNames="id" PageSize="10" 
                                GridLines="Horizontal" PagerStyle-CssClass="pgr" Width="100%" 
                                CellPadding="3" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" 
                                BorderWidth="1px">
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                    <asp:TemplateField ShowHeader="True" HeaderText="กลุ่มเรื่อง" SortExpression="group_title_name" >
                                        <HeaderStyle Width="450px" />
                                        <ItemStyle HorizontalAlign="Left" Width="450px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="likGroupTitleName" runat="server" Text='<%# Bind("group_title_name") %>' CommandArgument='<%# Bind("id") %>' ToolTip="เลือก" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle CssClass="pgr" BackColor="#E7E7FF" ForeColor="#4A3C8C" 
                                    HorizontalAlign="Right" />
                                <EmptyDataTemplate>
                                    <table border="1" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <PagerSettings Visible="False" />
                                <AlternatingRowStyle CssClass="alt" BackColor="#F7F7F7" />
                            </asp:GridView>
                            <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>


<%--สำหรับการเรียกใช้งาน Popup
<script language="javascript" type="text/javascript">
    function GetGroupTitleName() {
        var gCode = document.getElementById('<%=txtGroupTitleCode.ClientID %>').value;
        var pageUrl = '<%=ResolveUrl("~/Template/AjaxScript.asmx")%>'
        $.ajax({
            type: "POST",
            url: pageUrl + "/GetGroupTitleNameByCode",
            data: "{'vCode':'" + gCode + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessGetGroupTitleName,
            error: OnErrorGetGroupTitleName
        });
    }
    function OnSuccessGetGroupTitleName(response) {
        if (response.d != '-1') {
            document.getElementById('<%=txtGroupTitleName.ClientID %>').value = response.d;
            if (document.getElementById('<%=Me.Parent.FindControl("txtTitle").ClientID %>') != null) {
                document.getElementById('<%=Me.Parent.FindControl("txtTitle").ClientID %>').value = response.d;
            }
        } else {
            OpenModalPopup('../UserControls/popGroupTitle.aspx?', 600, 400);
        }
    }

    function OnErrorGetGroupTitleName(response) {
        alert("Error : " + response.status + " " + response.statusText);
    }
    
</script>--%>