<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="rptGroupTitleList.aspx.vb" Inherits="rptGrid_rptGroupTitleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="CssHead" align="left" ><span lang="TH"  width="20%">รายชื่อกลุ่มเรื่อง (DMS)</span></td>
            <td align="right" class="Csslbl"  width="80%">&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td  class="Csslbl" align="center" colspan="2" >
                <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
                    <tr>
                        <td  class="Csslbl" colspan="4" align="left" >
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="800px" >
                                <RowStyle CssClass="RowStyle" />
                                <Columns>
                                    <asp:BoundField DataField="no" HeaderText="ลำดับ" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"  />
                                    <asp:BoundField DataField="group_title_name" HeaderText="กลุ่มเรื่อง" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="max_proc_period" HeaderText="จำนวนวันทำการ" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="120px"  />
                                </Columns>
                                <PagerStyle CssClass="PagerStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <PagerSettings Visible="false" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

