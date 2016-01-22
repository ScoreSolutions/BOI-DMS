<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master" AutoEventWireup="false"
    CodeFile="rptSendOutDetail.aspx.vb" Inherits="Report_rptSendOutDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead">
                เรื่องออก ศทภ.1
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                วันที่ 1 มิ.ย.54
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                    Width="100%">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ที่" />
                        <asp:TemplateField HeaderText="เลขที่หนังสือ">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="true" ForeColor="Blue"
                                    Text='<%# Bind("no") %>' OnClick="LinkButton2_Click" OnClientClick="window.open('../Report/rptDocDetail.aspx','_blank', 'menubar=no,toorlbar=no,location=yes,scrollbars=yes,resizable=yes,width=1000,height=700,modal=yes,top=0,left=0'); return false;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="title" HeaderText="ชื่อเรื่อง" />
                        <asp:BoundField DataField="section" HeaderText="หน่วยงาน" />
                        <asp:BoundField DataField="section_no" HeaderText="เลขที่หนังสือองค์กร" />
                        <asp:BoundField DataField="owner" HeaderText="กองเจ้าของเรื่อง" />
                        <asp:BoundField DataField="date_regis" HeaderText="วันที่ลงทะเบียน" />
                        <asp:BoundField DataField="status" HeaderText="สถานะ" />
                        <asp:BoundField DataField="date_due" HeaderText="วันที่ครบกำหนด" />
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
