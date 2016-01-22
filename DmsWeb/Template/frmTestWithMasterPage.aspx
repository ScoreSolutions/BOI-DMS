<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="true" CodeFile="frmTestWithMasterPage.aspx.vb" Inherits="Template_frmTestWithMasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../UserControls/ctlRichTextBox.ascx" tagname="ctlRichTextBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" type="text/javascript">
        function LoadImage() {
            document.getElementById('<%=hdnCustValue.ClientID%>').value = '';
            document.getElementById('<%=txtAtComplete.ClientID%>').style.backgroundImage = 'url(../images/loading.gif)';
            document.getElementById('<%=txtAtComplete.ClientID%>').style.backgroundRepeat = 'no-repeat';
            document.getElementById('<%=txtAtComplete.ClientID%>').style.backgroundPosition = 'right';
        }
        function HideImage() {
            document.getElementById('<%=txtAtComplete.ClientID%>').style.backgroundImage = 'none';
        }
        function OnCustomerSelected(source, eventArgs) {
            document.getElementById('<%=hdnCustValue.ClientID%>').value = eventArgs.get_value();
            __doPostBack('<%=hdnCustValue.ClientID%>', "");

        }




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:TextBox runat="server" ID="txtAtComplete" Width="300" autocomplete="off"></asp:TextBox>&nbsp;
&nbsp;<cc1:AutoCompleteExtender
        runat="server" 
        ID="AutoCompleteExtender1" 
        TargetControlID="txtAtComplete"
        ServicePath="~/Template/AjaxScript.asmx"
        ServiceMethod = "GetAllCompanyForDDL"
        MinimumPrefixLength="1" 
        CompletionInterval="500"
        UseContextKey="true"
        EnableCaching="true"
        CompletionSetCount="20" FirstRowSelected="true"
        CompletionListCssClass="autocomplete_completionListElement" 
        CompletionListItemCssClass="autocomplete_listItem" 
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
        DelimiterCharacters="*" BehaviorID="AutoCompleteEx" 
        ShowOnlyCurrentWordInCompletionListItem="true"
        OnClientPopulating="LoadImage" OnClientPopulated="HideImage" OnClientItemSelected="OnCustomerSelected" >
     </cc1:AutoCompleteExtender>
     <asp:TextBox ID="hdnCustValue" runat="server" CssClass="zHidden" ></asp:TextBox>
     <br />
     --------------------------------------------------------------
     <uc1:ctlRichTextBox ID="ctlRichTextBox1" runat="server" />
    <br />

<script >
    function displayResult() {
        var x = document.getElementById("cmbTest");
        var option = document.createElement("option");
        option.text = "Value4";
        option.value = "4";
        try {
            // for IE earlier than version 8
            x.add(option, x.options[null]);
        }
        catch (e) {
            x.add(option, null);
        }
    }

    function cmbChange(val) {
        //document.getElementById('<%=hdnCustValue.ClientID%>').value
        document.getElementById('<%=txtTest.ClientID %>').value = val;
    }

    function SetStyle(ctl) {
        var img = document.getElementById(ctl);
        img.style.display = "none";
    }
</script>
    <img src="../Images/add.gif" onclick="SetStyle('this');" />%%%%%%%%%%
    <asp:ImageButton ID="img1" runat="server" ImageUrl="../Images/add.gif" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="displayResult(); return false;" />
    <asp:TextBox ID="txtTest" runat="server"></asp:TextBox>
    <select id='cmbTest' onchange="cmbChange(this.value)" >
        <option value='1'>Value1</option>
        <option value='2'>Value2</option>
        <option value='3'>Value3</option>
    </select>
</asp:Content>

