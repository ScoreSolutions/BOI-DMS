Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Para.DmsService

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class DmsWebservice
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function StartSendDocument(ByVal SystemID As String, ByVal RecordCount As Integer) As StartSendDocumentResPara
        Dim eng As New Engine.WebService.DmsServiceEng
        Dim para As New StartSendDocumentResPara
        para = eng.StartProcSendDocLastStatus(SystemID, RecordCount)
        eng = Nothing
        Return para
    End Function

    <WebMethod()> _
    Public Function SendDocument(ByVal InputPara As SendDocumentReqPara) As SendDocumentResPara
        Dim eng As New Engine.WebService.DmsServiceEng
        Dim para As New SendDocumentResPara
        Dim ret As Boolean = False

        'ตรวจสอบ Status
        ret = CheckDocumentStatus(InputPara.BookStatus, para)

        'ตรวจสอบ Group Title
        If ret = True Then
            ret = CheckGroupTitle(InputPara.GroupTitleCode, para)
        End If
        'ตรวจสอบ OfficerID
        If ret = True Then
            ret = CheckOfficerID(InputPara.OfficerIDApprove, para)
        End If
        If ret = True Then
            ret = CheckOfficerID(InputPara.StaffIDProcess, para)
        End If

        'ตรวจสอบ OrgID
        If ret = True Then
            ret = CheckOrgID(InputPara.OrgCodeOwner, para)
        End If
        If ret = True Then
            ret = CheckOrgID(InputPara.OrgCloseProcess, para)
        End If

        If ret = True Then
            para = eng.SendDocument(InputPara)
        End If
        eng = Nothing
        Return para
    End Function

#Region "Check Reference Data"
    Private Function CheckOrgID(ByVal OrgID As String, ByVal rPara As SendDocumentResPara) As Boolean
        Dim ret As Boolean = False
        Dim eng As New Engine.Master.OrganizationEng
        If eng.GetOrgPara(OrgID).ID <> 0 Then
            ret = True
        Else
            ret = False
            rPara.Result = False
            rPara.ErrorMessage = "Invalid Organization ID"
        End If
        eng = Nothing

        Return ret
    End Function
    Private Function CheckOfficerID(ByVal OfficerUsername As String, ByVal rPara As SendDocumentResPara) As Boolean
        Dim ret As Boolean = False
        Dim eng As New Engine.Master.OfficerEng
        If eng.GetOfficerParaByUserName(OfficerUsername).ID <> 0 Then
            ret = True
        Else
            ret = False
            rPara.Result = False
            rPara.ErrorMessage = "Invalid Officer Username"
        End If
        eng = Nothing

        Return ret
    End Function

    Private Function CheckDocumentStatus(ByVal BookStatus As String, ByVal rPara As SendDocumentResPara) As Boolean
        Dim ret As Boolean = False
        Dim st As New GetDocumentStatusResPara
        st = GetDocumentStatus()
        If st.StatusList.Rows.Count > 0 Then
            st.StatusList.DefaultView.RowFilter = "StatusCode = '" & BookStatus & "'"
            If st.StatusList.DefaultView.Count > 0 Then
                ret = True
            Else
                ret = False
                rPara.Result = False
                rPara.ErrorMessage = "Invalid BookStatus please use GetDocumentStatus method"
            End If
        Else
            ret = False
            rPara.Result = False
            rPara.ErrorMessage = "BookStatus not found"
        End If
        st.StatusList.Dispose()
        st = Nothing
        Return ret
    End Function
    Private Function CheckGroupTitle(ByVal GroupTitleCode As String, ByVal rPara As SendDocumentResPara) As Boolean
        Dim ret As Boolean = False
        Dim gt As New DataTable
        gt = GetGroupTitle()
        If gt.Rows.Count > 0 Then
            gt.DefaultView.RowFilter = "group_title_code = '" & GroupTitleCode & "'"
            If gt.DefaultView.Count > 0 Then
                ret = True
            Else
                ret = False
                rPara.Result = False
                rPara.ErrorMessage = "Invalid GroupTitleCode please use GetGroupTitle method"
            End If
        Else
            ret = False
            rPara.Result = False
            rPara.ErrorMessage = "Group Title not found"
        End If
        gt.Dispose()

        Return ret
    End Function
#End Region

    

    <WebMethod()> _
    Public Function FinishSendDocument(ByVal SendRefID As Integer) As FinishSendDocumentResPara
        Dim eng As New Engine.WebService.DmsServiceEng
        Dim para As New FinishSendDocumentResPara
        para = eng.FinishProcSendDocLastStatus(SendRefID)
        eng = Nothing
        Return para
    End Function

    <WebMethod()> _
    Public Function GetDocumentStatus() As GetDocumentStatusResPara
        Dim ret As New GetDocumentStatusResPara
        ret.StatusList = New DataTable
        ret.StatusList.TableName = "GetDocumentStatus"
        ret.StatusList.Columns.Add("StatusCode")
        ret.StatusList.Columns.Add("StatusName")

        Dim dr As DataRow = ret.StatusList.NewRow
        dr("StatusCode") = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
        dr("StatusName") = "งานค้าง"
        ret.StatusList.Rows.Add(dr)

        dr = ret.StatusList.NewRow
        dr("StatusCode") = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome
        dr("StatusName") = "งานเข้า"
        ret.StatusList.Rows.Add(dr)

        dr = ret.StatusList.NewRow
        dr("StatusCode") = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose
        dr("StatusName") = "จบงาน"
        ret.StatusList.Rows.Add(dr)

        Return ret
    End Function

    <WebMethod()> _
    Public Function GetGroupTitle() As DataTable
        Dim dt As New DataTable
        Dim eng As New Engine.Master.GroupTitleEng
        dt = eng.WSGetGroupTitleList()
        eng = Nothing
        dt.TableName = "GroupTitleList"
        Return dt
    End Function
End Class