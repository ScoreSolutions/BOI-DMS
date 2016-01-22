Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Namespace Master
    Public Class CompanyFunc
        Dim _err As String = ""
        Dim _ID As Long
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property
        Public Function GetAllCompanyList() As DataTable
            Dim lnq As New CompanyLinq
            Return lnq.GetDataList("1=1", "comID", Nothing)
        End Function
        Public Function GetDataCompanyList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New CompanyLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function
        Public Function GetCompanyPara(ByVal DocCompanyID As Long) As CompanyPara
            Dim lnq As New CompanyLinq
            Return lnq.GetParameter(DocCompanyID, Nothing)
        End Function
        Public Function SaveCompany(ByVal para As CompanyPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New CompanyLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.COMID = para.COMID
            lnq.THAINAME = para.THAINAME
            lnq.ENGNAME = para.ENGNAME
            lnq.ACTIVE = para.ACTIVE

            If para.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If

            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            _ID = lnq.ID

            Return ret

        End Function
    End Class
End Namespace
