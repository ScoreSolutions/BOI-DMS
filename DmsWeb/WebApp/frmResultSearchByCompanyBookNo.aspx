<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmResultSearchByCompanyBookNo.aspx.vb" Inherits="WebApp_frmResultSearchByCompanyBookNo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOI-DMS : ระบบสารบรรณอิเล็กทรอนิกส์</title>
    <link  href="../Template/StyleSheet.css" rel="stylesheet" type="text/css" />
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

        function OpenAttachFileWindow(id) {
            var RndNum = 1 + Math.floor(Math.random() * 6);
            var WinSettings = "center:yes;resizable:no;dialogWidth:600px;dialogHeight:500px;scrollbars:yes";
            var MyArgs = window.showModalDialog("../WebApp/PopAttachFile.aspx?id=" + id + "&rnd=" + RndNum, null, WinSettings);
        }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server">
        <Services>
        <asp:ServiceReference Path="~/Template/AjaxScript.asmx" />
        </Services>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff" id="pageContent" >
                    <tr>
                        <td align="left" class="Csslbl" colspan="4">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" >
                                <RowStyle CssClass="RowStyle" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="false">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <HeaderTemplate>
                                            <asp:ImageButton ID="imgAttach" runat="server" ToolTip="เอกสารแนบ" ImageUrl="~/Images/attach.png" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAttach" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="company_doc_no" HeaderText="เลขที่หนังสือองค์กร" ItemStyle-Width="100px"  />
                                    <asp:TemplateField ShowHeader="True" HeaderText="เลขที่หนังสือ" >
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookNo" runat="server" Text='<%# Bind("book_no") %>' ToolTip="เลือก" ></asp:Label>
                                            <asp:LinkButton ID="likBookNo" runat="server" Text='<%# Bind("book_no") %>' CssClass="zHidden" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="register_date" DataFormatString="{0:d MMM yy}" HeaderText="วันที่ลงทะเบียน" HtmlEncode="False" ItemStyle-Width="80px"  />
                                    <asp:BoundField DataField="title_name" HeaderText="ชื่อเรื่อง"  />
                                    <asp:BoundField DataField="company_name" HeaderText="หน่วยงาน"  />
                                    <asp:BoundField DataField="request_no" HeaderText="เลขที่คำขอ" ItemStyle-Width="80px"  />
                                    <asp:BoundField DataField="count_file" >
                                        <ItemStyle CssClass="zHidden" />
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="id" HeaderText="id" >
                                        <ItemStyle CssClass="zHidden" />
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle CssClass="PagerStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <PagerSettings Visible="false" />
                            </asp:GridView>
                            <center>
                                <asp:Label ID="lblNoData" runat="server" Text="ไม่พบข้อมูล" Visible="false" Font-Bold="true" ForeColor="Red" Font-Size="30pt" >
                                </asp:Label>
                            </center>
                        </td>
                    </tr>
                </table>
            </div>
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
</body>
</html>
