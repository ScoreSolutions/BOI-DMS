<%@ Control Language="VB" AutoEventWireup="false" CodeFile="btnRecieveAndSendIn.ascx.vb" Inherits="UserControls_Button_btnRecieveAndSendIn"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/txtBox.ascx" TagName="txtbox" TagPrefix="uc4" %>
<%@ Register src="~/UserControlsButton/popSendInside.ascx" tagname="popSendInside" tagprefix="uc1" %>
<asp:Button ID="btnButton1" runat="server" Text="ลงรับพร้อมส่งภายใน" CssClass="CssBtn" />

<uc1:popSendInside ID="popSendInside1" runat="server" />


