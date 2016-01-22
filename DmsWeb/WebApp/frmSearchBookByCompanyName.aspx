<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false"
    CodeFile="frmSearchBookByCompanyName.aspx.vb" Inherits="WebApp_frmSearchBookByCompanyName" Title="ค้นหาหนังสือ" %>

<%@ Register Src="~/UserControls/txtAutoComplete.ascx" TagName="txtAutoComplete" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#ffffff">
        <tr>
            <td class="CssHead" colspan="4" align="left" >
                ค้นหาจากชื่อองค์กร/บริษัท
            </td>
        </tr>
        <tr>
            <td align="right" width="15%">
                &nbsp;
            </td>
            <td width="35%">
                &nbsp;
            </td>
            <td align="right" width="15%">
                &nbsp;
            </td>
            <td width="35%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" align="left" >
                <table border="0" cellpadding="0" cellspacing="0" align="center" width="80%">
                    <tr>
                        <td align="right" class="Csslbl" width="20%">ชื่อองค์กร / บริษัท :</td>
                        <td align="left" class="Csslbl" width="80%">
                            <asp:TextBox runat="server" ID="txtComName" Width="500" CssClass="TextBox" autocomplete="off" onBlur="ClearTxtCustValue()" ></asp:TextBox>&nbsp;
                            <cc1:AutoCompleteExtender
                                runat="server" ID="AutoCompleteExtender1" 
                                TargetControlID="txtComName" ServicePath="~/Template/AjaxScript.asmx" ServiceMethod = "GetAllCompanyForDDL"
                                MinimumPrefixLength="3" CompletionInterval="500" UseContextKey="true" EnableCaching="true"
                                CompletionSetCount="20" FirstRowSelected="true"
                                CompletionListCssClass="autocomplete_completionListElement" 
                                CompletionListItemCssClass="autocomplete_listItem" 
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                DelimiterCharacters="*" BehaviorID="AutoCompleteEx" 
                                ShowOnlyCurrentWordInCompletionListItem="true"
                                OnClientPopulating="LoadImage" OnClientPopulated="HideImage" OnClientItemSelected="OnCustomerSelected"  >
                                <Animations>
                                    <OnShow>
                                        <Sequence>
                                            <OpacityAction Opacity="0" />
                                            <HideAction Visible="true" />
                                            <ScriptAction Script="
                                                // Cache the size and setup the initial size
                                                var behavior = $find('AutoCompleteEx');
                                                if (!behavior._height) {
                                                    var target = behavior.get_completionList();
                                                    behavior._height = target.offsetHeight - 2;
                                                    target.style.height = '0px';
                                                }" />
                                            <Parallel Duration=".4">
                                                <FadeIn />
                                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                                            </Parallel>
                                        </Sequence>
                                    </OnShow>
                                    <OnHide>
                                        <Parallel Duration=".4">
                                            <FadeOut />
                                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                                        </Parallel>
                                    </OnHide>
                                </Animations>
                             </cc1:AutoCompleteExtender>
                             <asp:TextBox ID="hdnCustValue" runat="server" CssClass="zHidden" ></asp:TextBox>
                             
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="Csslbl" width="15%">
                            วันที่ลงทะเบียน :
                        </td>
                        <td class="Csslbl" width="85%" align="left">
                            <table border="0" >
                                <tr>
                                    <td><uc2:txtDate ID="txtRegisDateFrom" runat="server" /></td>
                                    <td>&nbsp;ถึง</td>
                                    <td><uc2:txtDate ID="txtRegisDateTo" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td>&nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btnSearch" runat="server" CssClass="CssBtn" Text="ค้นหา" Width="80px" />
                            &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="CssBtn" Text="ล้างค่า" Width="80px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" class="Csslbl" align="left">
                * สามารถค้นหาโดยระบุช่วง วันที่ลงทะเบียนหนังสือ ขององค์กร / บริษัท ที่ต้องการค้นหาได้ <br />
                หากไม่ระบุช่วงวันที่ ระบบจะทำการค้นหาเรื่องทั้งหมดที่ลงทะเบียนไว้ในระบบ ตามชื่อที่ระบุไว้ในช่อง ชื่อองค์กร / บริษัท
            </td>
        </tr>
    </table>
    
    
    <script type="text/javascript" language="javascript">
        function LoadImage() {

            document.getElementById('<%=txtComName.ClientID%>').style.backgroundImage = 'url(../images/loading.gif)';
            document.getElementById('<%=txtComName.ClientID%>').style.backgroundRepeat = 'no-repeat';
            document.getElementById('<%=txtComName.ClientID%>').style.backgroundPosition = 'right';
        }
        function HideImage() {
            document.getElementById('<%=txtComName.ClientID%>').style.backgroundImage = 'none';
        }

        function OnCustomerSelected(source, eventArgs) {
            var custVal = eventArgs.get_value();
            document.getElementById('<%=hdnCustValue.ClientID%>').value = custVal;
        }

        function ClearTxtCustValue() {
            if (document.getElementById('<%=txtComName.ClientID%>').value == "") {
                document.getElementById('<%=hdnCustValue.ClientID%>').value = "";
            }
        }
    </script>
</asp:Content>
