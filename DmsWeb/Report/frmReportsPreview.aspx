<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmReportsPreview.aspx.vb" Inherits="Reports_frmReportsPreview" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" 
        EnableDatabaseLogonPrompt="False" EnableDrillDown="False" EnableParameterPrompt="False" 
        HasDrillUpButton="False" HasCrystalLogo="False" HasRefreshButton="False" PrintMode="Pdf" HasExportButton="False"
        HasSearchButton="False" HasToggleGroupTreeButton="False" DisplayGroupTree="False" DisplayToolbar="True" />
        <center>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        </center>
        
    </div>
    </form>
</body>
</html>
