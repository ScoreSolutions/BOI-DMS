<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDocBookDetailShow.ascx.vb" Inherits="UserPageControls_ctlDocBookDetailShow" %>

<table width="100%" border="1" height="510px"  >
    <tr>
        <td>
            <table style="width: 100%"  >
                <tr>
                    <td class="CssHead" colspan="5" align="left" >
                        รายละเอียดหนังสือ
                    </td>
                    <td><asp:ImageButton ID="imgPrintElec" runat="server" Visible="false" ImageUrl="~/Images/print.ico" Width="24px" ToolTip="พิมพ์" /></td>
                    
                </tr>
                <tr>
                    <td align="right" class="Csslbl" width="15%">
                        เลขที่หนังสือ :
                    </td>
                    <td class="Csslbl" width="30%" align="left" >
                        <asp:Label ID="lblBookNo" runat="server" ForeColor="Blue"></asp:Label>
                        <asp:Label ID="lblID" runat="server" CssClass="zHidden" Text="0" ></asp:Label>
                    </td>
                    <td align="right" class="Csslbl" width="15%">
                        วันที่ลงทะเบียน :
                    </td>
                    <td class="Csslbl" width="15%" align="left">
                        <asp:Label ID="lblRegisDate" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right" class="Csslbl" width="10%">
                        คำขอ :
                    </td>
                    <td class="Csslbl" width="15%" align="left">
                        <asp:Label ID="lblRequestNo" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        เลขที่หนังสือองค์กร :
                    </td>
                    <td class="Csslbl" align="left">
                        <asp:Label ID="lblCompanyDocNo" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right" class="Csslbl">
                        ลงวันที :
                    </td>
                    <td class="Csslbl" align="left">
                        <asp:Label ID="lblCompanyDocDate" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right" class="Csslbl" >
                        อ้างถึง :
                    </td>
                    <td class="Csslbl" align="left">
                        <asp:Label ID="lblReferTo" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        กลุ่มเรื่อง:
                    </td>
                    <td class="Csslbl" align="left" colspan="5" >
                        <asp:Label ID="lblGroupTitleName" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        เรื่อง :
                    </td>
                    <td class="Csslbl" align="left" colspan="5" >
                        <asp:Label ID="lblTitleName" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        <font color="red">ประเภทกิจการ :</font>
                    </td>
                    <td class="Csslbl" align="left" colspan="5">
                        <asp:Label ID="lblBusinessType" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        หน่วยงาน :
                    </td>
                    <td class="Csslbl" align="left" colspan="3">
                        <asp:Label ID="lblCompanyName" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right" class="Csslbl" >
                        ผู้ลงนาม :
                    </td>
                    <td class="Csslbl" align="left">
                        <asp:Label ID="lblCompanySign" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    
                    <td align="right" class="Csslbl" >
                        หมายเหตุ :
                    </td>
                    <td class="Csslbl" align="left" colspan="5">
                        <asp:Label ID="lblRemarks" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        กองเจ้าของเรื่อง :
                    </td>
                    <td class="Csslbl" align="left">
                        <asp:Label ID="lblOrgOwnName" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right" class="Csslbl" >
                        จนท.ผู้พิจารณา :
                    </td>
                    <td class="Csslbl" align="left" colspan="3">
                        <asp:Label ID="lblOfficerOwnName" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        เลขที่หนังสือส่งออก :
                    </td>
                    <td class="Csslbl" colspan="5" align ="left" >
                        <asp:Label ID="lblBookoutNo" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        สถานะหนังสือ :
                    </td>
                    <td class="Csslbl" align="left" >
                        <asp:Label ID="lblBookStatus" runat="server" ForeColor="Brown"></asp:Label>
                    </td>
                    <td align="right" class="Csslbl" >
                        กำหนดออก :
                    </td>
                    <td class="Csslbl" align="left">
                        <asp:Label ID="lblExpectFinishDate" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right" class="Csslbl" >
                        วันที่ปิดงาน :
                    </td>
                    <td class="Csslbl" align="left">
                        <asp:Label ID="lblCloseDate" runat="server" ForeColor="Brown" ></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td align="right" class="Csslbl" >
                        &nbsp;
                    </td>
                    <td class="Csslbl" style="color: #000080">
                        &nbsp;
                    </td>
                    <td align="right" class="Csslbl" width="15%">
                        &nbsp;
                    </td>
                    <td class="Csslbl" style="color: #000080">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="Csslbl" >
                        <b>รายละเอียดรับส่ง</b>
                    </td>
                    <td class="Csslbl" style="color: #000080">
                        &nbsp;
                    </td>
                    <td align="right" class="Csslbl" width="15%">
                        &nbsp;
                    </td>
                    <td class="Csslbl" style="color: #000080">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan = "6">
                        <asp:GridView ID="gvSendList" runat="server" AutoGenerateColumns="False" 
                            CssClass="mGrid" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:BoundField HeaderText="ที่" DataField="No" >
                                    <ItemStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="เจ้าหน้าที่รับ" DataField="user_receive">
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="กองรับ" DataField="organization_appname_receive">
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="วันที่รับ" DataField="receive_date" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HtmlEncode="false">
                                    <HeaderStyle Width="130px" />
                                    <ItemStyle HorizontalAlign="Left" Width="130px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="จนท.ส่ง" DataField="user_send" >
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="กองส่ง" DataField="organization_appname_send">
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="วันที่ส่ง" DataField="send_date" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HtmlEncode="false">
                                    <ItemStyle Width="130px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="หมายเหตุ" DataField="remarks"></asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table border="1" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="***ไม่พบข้อมูล***"></asp:Label>
                                        </td>
                                    </tr>
                                </table>                   
                            </EmptyDataTemplate>
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Visible="False" />
                            <PagerStyle CssClass="pgr" />
                         </asp:GridView>
                    </td>
                </tr>
                 <tr>
                    <td align="right" class="Csslbl" >
                        <b>เอกสารแนบ</b>
                    </td>
                    <td class="Csslbl" style="color: #000080">
                        &nbsp;
                    </td>
                    <td align="right" class="Csslbl" width="15%">
                        &nbsp;
                    </td>
                    <td class="Csslbl" style="color: #000080">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" 
                            CssClass="mGrid" GridLines="Vertical" Width="100%">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:BoundField DataField="no" HeaderText="ลำดับ" ItemStyle-Width="5%">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="รายละเอียด">
                                    <ItemStyle HorizontalAlign="Left" Width="95%" />
                                    <HeaderStyle HorizontalAlign="Center" Width="95%" />
                                    <ItemTemplate>
                                        <asp:Label ID="likEdit" runat="server" Text='<%# Bind("description") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle Width="15px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDownload" runat="server" ImageUrl="~/Images/download.png"
                                           OnClick="imgDownload_Click" ToolTip="ดาวน์โหลด" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="id">
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
                
                <tr><td colspan="4">&nbsp;</td></tr>
                <tr>
                    <td class="Csslbl" style="color: #000080" colspan="4" align="center" >
                        <asp:Button ID="btnEdit" runat="server" CssClass="CssBtn" Width="120px" Text="แก้ไขรายละเอียด" Visible="false" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    
    
    <script language="javascript" type="text/javascript">
        function SendToTHeGif(vID, ctl) {
            if (confirm("ยืนยันการส่งข้อมูล ?")) {
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
