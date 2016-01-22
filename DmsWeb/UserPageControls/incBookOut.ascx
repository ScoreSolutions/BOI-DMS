<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incBookOut.ascx.vb" Inherits="UserPageControls_incBookOut" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtBox.ascx" tagname="txtBox" tagprefix="uc2" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc3" %>
<%@ Register src="~/UserControls/ctlCompany.ascx" tagname="ctlCompany" tagprefix="uc6" %>
<%@ Register src="~/UserControls/ctlGroupTitle.ascx" tagname="ctlGroupTitle" tagprefix="uc4" %>
<%@ Register src="~/UserControls/cmbAutoComplete.ascx" tagname="cmbAutoComplete" tagprefix="uc7" %>
<%@ Register src="~/UserControls/ctlRichTextBox.ascx" tagname="ctlRichTextBox" tagprefix="uc1" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc8" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<style type="text/css">
    .style6
    {
        color: #000000;
        text-decoration: none;
        vertical-align: top;
        padding: 1px;
        font-style: normal;
        font-variant: normal;
        font-size: 20px;
        line-height: normal;
        font-family: TH SarabunPSK,Arial, "Courier New" , Courier, monospace;
        text-align: left;
    }
    </style>

<script language="javascript">
    function MyApp(sender) {
        document.getElementById('<%=cmbSecret1.ClientID%>').value = sender.value;
    }
</script>
        <tr>
            <td colspan="4">
                <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
                    <tr>
                        <td width="33%" align="left">&nbsp;</td>
                        <td width="33%" align="center">
                            <asp:DropDownList ID="cmbSecretID" runat="server" CssClass="TextBox" 
                                Height="24px" Width="200px" >
                            </asp:DropDownList>
                        </td>
                        <td width="34%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="center" rowspan="5"><img src="../Images/crud.JPG" width="105px" height="114px" alt="" /></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" ><uc8:cmbCombobox ID="cmbSpeenID" runat="server" DefaultDisplay="ชั้นความเร็ว(ถ้ามี)" Width="200px" /></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" >
                            <asp:TextBox ID="txtBookNo" runat="server"  Width="200px"  />
                            <cc1:TextBoxWatermarkExtender ID="WtxtBookNo" TargetControlID="txtBookNo" runat="server" WatermarkText="ที่"></cc1:TextBoxWatermarkExtender>
                        </td>
                        <td align="left" >
                            <asp:TextBox ID="txtOrgBookOwner" runat="server"  Width="230px" Text="สำนักงานคณะกรรมการส่งเสริมการลงทุน" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >&nbsp;</td>
                        <td align="left" >&nbsp;</td>
                        <td align="left" >
                            <asp:TextBox ID="txtOwnerAddress" runat="server"  Width="230px" Text="555 ถ.วิภาวดี รังสิต" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >&nbsp;</td>
                        <td align="left" >&nbsp;</td>
                        <td align="left" >
                            <asp:TextBox ID="txtOwnerAddress2" runat="server"  Width="230px" Text="เขตจตุจักร กรุงเทพฯ 10900" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                            <table width="100%" border="0" >
                                <tr>
                                    <td width="50%">&nbsp;</td>
                                    <td width="50%" align="left">
                                        <uc3:txtDate ID="txtDate1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table border="0" cellpadding="0" cellspacing="1" width="100%" class="style6">
                                <tr >
                                    <td width="15%" align="left" >เรื่อง :</td>
                                    <td width="85%" align="left" class="style6" >
                                        <uc2:txtbox ID="txtTitle" runat="server"  Width="650" IsNotNull="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" >เรียน :</td>
                                    <td align="left" class="style6" >
                                        <uc2:txtbox ID="txtLean" runat="server"  Width="650" IsNotNull="True" />
                                    </td>
                                </tr>
                                <tr >
                                    <td valign="top" align="left" >อ้างถึง :</td>
                                    <td align="left" class="style6" >
                                        <uc2:txtbox ID="txtrefto" runat="server"  Width="600" IsNotNull="False" />
                                        <asp:Button ID="btnAddReferTo" runat="server" Width="50" Text="เพิ่ม" CssClass="CssBtn" />
                                         <br />
                                        
                                        <asp:GridView ID="gvReferToList" runat="server" AutoGenerateColumns="False" ShowHeader="false" Width="600">
                                            <RowStyle CssClass="RowStyle" />
                                            <Columns>
                                                <asp:BoundField DataField="refer_to" HeaderText="อ้างถึง" >
                                                    <HeaderStyle  />
                                                    <ItemStyle HorizontalAlign="Left"  />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id" >
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="zHidden"/>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ลบ" >
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" ></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/Images/delete1.png" OnClientClick="return confirm('ยืนยันการลบรายการ?');" CommandName="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="PagerStyle" />
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr >
                                    <td valign="top" align="left" >สิ่งที่ส่งมาด้วย :</td>
                                    <td align="left" class="style6" >
                                        <uc2:txtbox ID="txtattach" runat="server"  Width="600" IsNotNull="False" />
                                        
                                        <asp:Button ID="btnAddAttach" runat="server" Width="50" Text="เพิ่ม" CssClass="CssBtn" />
                                         <br />
                                        
                                        <asp:GridView ID="gvAttachList" runat="server" AutoGenerateColumns="False" ShowHeader="false" Width="600">
                                            <RowStyle CssClass="RowStyle" />
                                            <Columns>
                                                <asp:BoundField DataField="attach"  >
                                                    <HeaderStyle  />
                                                    <ItemStyle HorizontalAlign="Left"  />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id" >
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="zHidden"/>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ลบ" >
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" ></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/Images/delete1.png" OnClientClick="return confirm('ยืนยันการลบรายการ?');" CommandName="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="PagerStyle" />
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr >
                                    <td align="left" valign="top">เนื้อความ :</td>
                                    <td align="left" >
                                        <uc1:ctlRichTextBox ID="ctlDetail" runat="server" Width="650" Height="250" IsNotNull="False" />
                                    </td>
                                </tr>
                                <tr >
                                    <td align="left" valign="top">&nbsp;</td>
                                    <td align="left" >
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                            <table width="100%" border="0" >
                                <tr>
                                    <td width="50%">&nbsp;</td>
                                    <td width="50%" align="left">
                                        <uc8:cmbCombobox ID="cmbPoscriptID" runat="server" Width="200px" 
                                            DefaultDisplay="คำลงท้าย" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr id="trOfficerSign" runat="server" visible="false" >
                        <td>&nbsp;</td>
                        <td align="left">
                            <uc2:txtBox ID="txtOfficerSign" runat="server" Width="300" />
                            <br />
                            <asp:TextBox ID="txtPositionSign" runat="server" CssClass="TextBox" 
                                Height="24px" Width="300px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" align="left" >
                            <uc8:cmbCombobox ID="cmbTitleOwner" runat="server" Width="300px" DefaultDisplay="ส่วนราชการเจ้าของเรื่อง" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table border="0" cellpadding="0" cellspacing="1" width="100%">
                                <tr>
                                    <td width="15%" align="left" class="style6" >โทรศัพท์ :                   </td>
                                    <td align="left" ><uc2:txtbox ID="Txttel" runat="server"  Width="100px" /></td>
                                </tr>
                                <tr>
                                    <td align="left" class="style6"  >โทรสาร :</td>
                                    <td align="left" ><uc2:txtbox ID="txtFax" runat="server"  Width="100px" /></td>
                                </tr>
                                <tr>
                                    <td align="left" class="style6"  >สำเนาส่ง :</td>
                                    <td align="left" ><uc2:txtbox ID="txtCCTo" runat="server"  Width="650px" /></td>
                                </tr>                                
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:DropDownList ID="cmbSecret1" name="ddl2" runat="server" CssClass="TextBox" 
                                Enabled="False" Height="24px" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>




