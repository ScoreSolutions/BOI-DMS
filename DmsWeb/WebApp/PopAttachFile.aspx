<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PopAttachFile.aspx.vb" Inherits="WebApp_PopAttachFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc4" %>
<%@ Register src="../UserControls/ctlBrowseFile.ascx" tagname="ctlBrowseFile" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOI-DMS : เอกสารแนบ</title>

    <script type="text/javascript" language="JavaScript" src="../Template/JScript.js"></script>
    <link  href="../Template/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function OpenDownload(Param) {
            window.open("../WebApp/PopAttachFileDownload.aspx?" + Param);
            return false;
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
                        <td align="left" bgcolor="#3B5998" class="cssHead" width="15%">เอกสารแนบ</td>
                        <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="divBrowseFile">
                                <table width="100%">
                                    <tr><td colspan="2">&nbsp;</td></tr>
                                    <tr>
                                        <td align="right" class="Csslbl" width="15%">
                                            ไฟล์ :
                                        </td>
                                        <td align="left" class="Csslbl">
                                            <uc1:ctlBrowseFile ID="ctlBrowseFile1" runat="server" VisibleUploadButton="false" />
                                            <asp:Label ID="lblDocumentRegisterID" runat="server" Visible="false" Text="0"></asp:Label>
                                            <asp:Label ID="lblRowIndex" runat="server" Visible="false" Text="0" ></asp:Label>
                                            <asp:Label ID="lblRowNo" runat="server" Visible="false" Text="0" ></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Visible="false" Text="0" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="Csslbl"  >
                                            รายละเอียด :
                                        </td>
                                        <td align="left" >
                                            <uc4:txtBox ID="txtDescription" runat="server" IsNotNull="True" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnUpload" runat="server" CssClass="CssBtn" Text="Upload" Width="80px" />
                                            &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="CssBtn" Text="Cancel" Width="80px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divScan" style="display:none" >
                                <table align="left" width="100%">
                                    <tr>
                                        <td align="left" >
                                            <asp:Button ID="Button4" runat="server" CssClass="button" Text="Prev" 
                                                Width="80px" />
                                            <uc4:txtBox ID="txtBox2" runat="server" Height="22" IsNotNull="False" 
                                                TextAlign="AlignCenter" />
                                            <asp:Button ID="Button5" runat="server" CssClass="button" Text="Next" 
                                                Width="80px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="Button6" runat="server" CssClass="button" Text="Scan Page" 
                                                Width="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" >
                                            รายละเอียด :
                                            <uc4:txtBox ID="txtBox3" runat="server" IsNotNull="True" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Image ID="Image1" runat="server" Width="50%" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr >
                        <td align="left" colspan="2">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CssClass="mGrid"  Width="100%">
                                <RowStyle CssClass="RowStyle" />
                                <Columns>
                                    <asp:BoundField DataField="no" HeaderText="ลำดับ" ItemStyle-Width="5%" >
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="รายละเอียด">
                                        <ItemStyle HorizontalAlign="Left" Width="95%" />
                                        <HeaderStyle HorizontalAlign="Center" Width="95%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="likEdit" runat="server" CommandName="Edit" Text='<%# Bind("description") %>' CommandArgument='<%# Bind("id") %>' ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemStyle Width="15px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDownload" runat="server" 
                                                ImageUrl="~/Images/download.png" Text="Download" 
                                                ToolTip="ดาวน์โหลด" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDelete" runat="server" 
                                                CommandName="Delete" ImageUrl="~/Images/delete_page.png" Text="Delete" OnClientClick="return confirm('ยืนยันการลบเอกสารแนบ?')" ToolTip="ลบ" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="id"  >
                                        <ItemStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IsDel"  >
                                        <ItemStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                    </asp:BoundField>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
