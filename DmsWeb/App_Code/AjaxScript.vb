﻿Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Engine.WebService
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AjaxScript
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetTextAutoComplete(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim result() As String
        Dim tbFld() As String = Split(contextKey, "#")
        If tbFld(0) <> "DEFAULT" And tbFld(1) <> "DEFAULT" Then
            Dim fnc As New DmsServiceEng
            result = fnc.GetAutoCompleteList(tbFld(0), tbFld(1), prefixText)
            fnc = Nothing
        End If
        Return result
    End Function

    <WebMethod()> _
    Public Sub SaveTransLog(ByVal TransDesc As String, ByVal LoginHisID As Long)
        Config.SaveTransLog(TransDesc, LoginHisID)
    End Sub

    <WebMethod()> _
    Public Function SaveScanJob(ByVal UserName As String, ByVal ClientPage As String, ByVal ClientBrowser As String, ByVal ClientSessionID As String, ByVal RefID As String) As Long
        Return Engine.WebService.DmsDocScanServiceENG.SaveScanJob(UserName, ClientPage, ClientBrowser, ClientSessionID, RefID)
    End Function

    <WebMethod()> _
    Public Function TestJQuery(ByVal JobID As String, ByVal DocID As String) As String
        Return "Return Data JobID:" & JobID & "   DocID:" & DocID
    End Function

    <WebMethod()> _
    Public Function GetGroupTitleNameByCode(ByVal vCode As String) As String
        Dim ret As String = "-1"
        If vCode.Trim <> "" Then
            Dim fnc As New Engine.Master.GroupTitleEng
            Dim dt As DataTable = fnc.GetDataGroupTitleList("group_title_code like '" & vCode & "%' and isnull(group_title_name,'')<>'' ", "group_title_name")
            If dt.Rows.Count = 1 Then
                ret = dt.Rows(0)("group_title_name")
                dt = Nothing
            End If
            fnc = Nothing
        End If
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetGroupTitleData(ByVal vGroupTitleID As Long) As String
        Dim ret As String = ""
        Dim gEng As New Engine.Master.GroupTitleEng
        Dim gPara As New Para.TABLE.GroupTitlePara
        gPara = gEng.GetGroupTitlePara(vGroupTitleID)

        Dim eng As New Engine.Document.DocumentRegisterENG
        Dim fDate As Date = eng.CalExpectFinishDate(gPara)
        If fDate.Year <> 1 Then
            ret = fDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        End If
        
        ret += "###" & gPara.NO_DEFAULT_TITLE

        eng = Nothing
        gEng = Nothing
        gPara = Nothing

        Return ret
    End Function


    <WebMethod()> _
    Public Function GetGroupTitleEditData(ByVal vGroupTitleID As Long, ByVal vDocRegisID As Long) As String
        Dim ret As String = ""
        Dim gEng As New Engine.Master.GroupTitleEng
        Dim gPara As New Para.TABLE.GroupTitlePara
        gPara = gEng.GetGroupTitlePara(vGroupTitleID)

        Dim eng As New Engine.Document.DocumentRegisterENG
        Dim fDate As Date = eng.CalExpectFinishDate(gPara, vDocRegisID)
        If fDate.Year <> 1 Then
            ret = fDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        End If

        ret += "###" & gPara.NO_DEFAULT_TITLE

        eng = Nothing
        gEng = Nothing
        gPara = Nothing

        Return ret
    End Function

    'Public Function CalExpectFinishDate(ByVal vGroupTitleID As Long) As String
    '    Dim ret As String = ""
    '    Dim eng As New Engine.Document.DocumentRegisterENG
    '    Dim fDate As Date = eng.CalExpectFinishDate(vGroupTitleID)
    '    If fDate.Year <> 1 Then
    '        ret = fDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
    '    End If


    '    eng = Nothing
    '    Return ret
    'End Function

    <WebMethod()> _
    Public Function GetOrgIDForDDL(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim eng As New Engine.Master.OrganizationEng
        Dim dt As New DataTable
        dt = eng.GetAllOrganizationTable()

        Dim values As New List(Of AjaxControlToolkit.CascadingDropDownNameValue)()
        For Each dr As DataRow In dt.Rows
            Dim make As String = DirectCast(dr("org_name"), String)
            Dim makeId As String = dr("id").ToString
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(make, makeId.ToString()))
        Next
        dt = Nothing
        eng = Nothing
        Return values.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetStaffByOrgID(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim kv() As String = Split(knownCategoryValues, ":")
        Dim OrgId As String = kv(1).Replace(";", "")

        Dim values As New List(Of AjaxControlToolkit.CascadingDropDownNameValue)()
        Dim eng As New Engine.Master.OrganizationEng
        Dim dt As New DataTable
        dt = eng.GetStaffByOrgID(OrgId)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(DirectCast(dr("staff_name"), String), dr("id").ToString()))
            Next
        End If
        dt = Nothing
        eng = Nothing
        Return values.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetStaffByOrgIDDFAdmintration(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim kv() As String = Split(knownCategoryValues, ":")
        Dim OrgId As String = kv(1).Replace(";", "")
        Dim values As New List(Of AjaxControlToolkit.CascadingDropDownNameValue)()
        Dim eng As New Engine.Master.OrganizationEng

        Dim aDt As New DataTable
        aDt = eng.GetStaffAdmintrationByOrgID(OrgId)  'เจ้าหน้าที่ธุรการในสำนัก

        Dim dt As New DataTable
        dt = eng.GetStaffByOrgID(OrgId)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                aDt.DefaultView.RowFilter = "id = '" & dr("id") & "'"
                If aDt.DefaultView.Count > 0 Then
                    values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(DirectCast(dr("staff_name"), String), dr("id").ToString(), True))
                Else
                    values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(DirectCast(dr("staff_name"), String), dr("id").ToString()))
                End If
            Next
        End If
        dt = Nothing
        eng = Nothing
        aDt = Nothing
        Return values.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetStaffByOrgIDDfDirector(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim kv() As String = Split(knownCategoryValues, ":")
        Dim OrgId As String = kv(1).Replace(";", "")

        Dim oPara As New Para.TABLE.OrganizationPara

        Dim values As New List(Of AjaxControlToolkit.CascadingDropDownNameValue)()
        Dim eng As New Engine.Master.OrganizationEng

        oPara = eng.GetOrgPara(OrgId)
        Dim dt As New DataTable
        dt = eng.GetStaffByOrgID(OrgId)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                If oPara.DIRECTOR = dr("id").ToString Then
                    values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(DirectCast(dr("staff_name"), String), dr("id").ToString(), True))
                Else
                    values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(DirectCast(dr("staff_name"), String), dr("id").ToString()))
                End If

            Next
        End If
        dt = Nothing
        eng = Nothing
        oPara = Nothing
        Return values.ToArray()
    End Function


    <WebMethod()> _
    Public Function CheckCompanyDocNo(ByVal vCompanyDocNo As String) As String
        Dim eng As New Engine.Document.DocumentRegisterENG
        Dim ret As String = eng.CheckCompanyDocNo(vCompanyDocNo)
        eng = Nothing
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetAllCompanyForDDL(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As List(Of String)
        Dim itemsCust As New List(Of String)(count)
        If count = 0 Then count = 10
        If prefixText.ToLower.Equals("select") Then
            itemsCust.Add("No Records Found !")
        Else
            Dim dt As New DataTable
            Dim eng As New Engine.Master.CompanyEng
            dt = eng.GetCompanyDDList(prefixText)
            eng = Nothing
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    itemsCust.Insert(i, AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dt.Rows(i)("company_name").ToString, dt.Rows(i)("id").ToString))
                Next
                dt = Nothing
            Else
                itemsCust.Add("No Records Found !")
            End If
        End If

        Return itemsCust
    End Function

    <WebMethod()> _
    Public Function SaveCompany(ByVal UserName As String, ByVal ThaiName As String, ByVal EngName As String, ByVal vAddress As String, ByVal CompanyType As String, ByVal vTel As String, ByVal vFax As String, ByVal vZipcode As String, ByVal ProvinceID As String, ByVal DistrictID As String) As String
        Dim ret As String = "0"

        Dim para As New Para.TABLE.CompanyPara
        para.COMPANY_TYPE_ID = CompanyType
        para.THAINAME = ThaiName
        para.ENGNAME = EngName
        para.ADDRESSID = vAddress
        para.TEL = vTel
        para.FAX = vFax
        para.ZIPCODE = vZipcode
        para.PROVINCE_ID = ProvinceID
        para.DISTRICT_ID = DistrictID
        para.ACTIVE = "Y"

        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim eng As New Engine.Master.CompanyEng
        If eng.SaveCompany(para, UserName, trans) = True Then
            trans.CommitTransaction()
            ret = eng.ID
        Else
            trans.RollbackTransaction()
        End If

        eng = Nothing
        para = Nothing

        Return ret
    End Function

    <WebMethod()> _
    Public Function GetCompanyNameByOrgID(ByVal OrgID As String) As String()
        Dim ret() As String = {"", ""}
        Dim eng As New Engine.Master.CompanyEng
        ret = eng.GetCompanyNameByOrgID(OrgID)
        eng = Nothing
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetOrgDirectorByOrgID(ByVal OrgID As String) As String
        Dim ret As String = ""
        Dim eng As New Engine.Master.OrganizationEng
        ret = eng.GetOrgPara(OrgID).DIRECTOR
        eng = Nothing
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetCertificate(ByVal vCompanyID As String) As String
        'เลขที่บัตรส่งเสริม
        Dim ret As String = "N"
        If vCompanyID <> "" Then
            Dim dt As New DataTable
            Dim eng As New Engine.Document.DocumentRegisterENG
            Dim cEng As New Engine.Master.CompanyEng
            Dim cPara As New Para.TABLE.CompanyPara
            cPara = cEng.GetCompanyPara(vCompanyID)
            dt = New DataTable
            dt = eng.GetCERTIFICATENO(cPara.ENGNAME)
            If dt.Rows.Count > 0 Then
                ret = "Y"
            End If
            dt = Nothing
            eng = Nothing
            cEng = Nothing
            cPara = Nothing
        End If
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetNotification(ByVal vCompanyID As String) As String
        'เลขที่หนังสือแจ้งมติ
        Dim ret As String = "N"
        If vCompanyID <> "" Then
            Dim dt As New DataTable
            Dim eng As New Engine.Document.DocumentRegisterENG
            Dim cEng As New Engine.Master.CompanyEng
            Dim cPara As New Para.TABLE.CompanyPara
            cPara = cEng.GetCompanyPara(vCompanyID)
            dt = eng.GetNOTIFICATIONNO(cPara.ENGNAME)
            If dt.Rows.Count > 0 Then
                ret = "Y"
            End If
            dt = Nothing
            eng = Nothing
            cEng = Nothing
            cPara = Nothing
        End If
        Return ret
    End Function

    <WebMethod()> _
    Public Function SendLetterToTHeGif(ByVal vDocExtID As String, ByVal LoginName As String) As Boolean
        Dim ret As Boolean = False
        ret = Engine.WebService.THeGIFENG.SendCorrespondenceLetterOutboundRequest(vDocExtID, LoginName)
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetReportURL() As String
        Return Engine.Common.FunctionENG.GetConfigValue("REPORT_URL")
    End Function

End Class