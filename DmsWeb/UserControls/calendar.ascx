<%@ Control Language="VB" AutoEventWireup="false" CodeFile="calendar.ascx.vb" Inherits="UserControls_calendar" %>
<%@ Register Assembly="EventCalendar" Namespace="ExtendedControls" TagPrefix="ECalendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="PageControl.ascx" TagName="pagecontrol" TagPrefix="uc1" %>
<%@ Register Src="txtBox.ascx" TagName="txtBox" TagPrefix="uc1" %>
&nbsp;<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<ECalendar:EventCalendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#FFCC66"
    BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px"
    Width="220px" FirstDayOfWeek="Monday" NextMonthText="" PrevMonthText="" SelectionMode="Day" 
    ShowDescriptionAsToolTip="True" EventDateColumnName="" EventDescriptionColumnName=""
    EventHeaderColumnName="" OnSelectionChanged="Calendar1_SelectionChanged" DayNameFormat="Shortest"
    EventBackColorName="" EventEndDateColumnName="" EventForeColorName="" EventStartDateColumnName=""
    CellPadding="1">
    
    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <WeekendDayStyle BackColor="#CCCCFF" />
    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
    <SelectorStyle BorderColor="#404040" BorderStyle="Solid" BackColor="#99CCCC" ForeColor="#336666" />
    <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="Solid"
        BorderWidth="1px" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
    <DayHeaderStyle BorderWidth="1px" BackColor="#99CCCC" Height="1px" ForeColor="#336666"
        BorderStyle="Solid" />
    <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF"
        HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#3366CC" BorderWidth="1px"
        Height="25px" />
</ECalendar:EventCalendar>
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" Width="300">
    <table id="Table1" width="300" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr style="background-color: #3b5998; color: #FFFFFF; font-size: 14px; font-weight: bold;">
            <td align="left" bgcolor="#3B5998">
                เพิ่ม/แก้ไขวันหยุด
            </td>
            <td align="right" bgcolor="#3B5998" style="color: #FFFFFF; font-size: 14px">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvSelectedDateEvents" runat="server" Width="200px">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>
