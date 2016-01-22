Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Namespace Master
    Public Class DocSecretFunc
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

        Public Function GetAllSecretList() As DataTable
            Dim lnq As New DocSecretLinq
            Return lnq.GetDataList("1=1", "secret_code", Nothing)
        End Function
        Public Function GetDataSecretList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New DocSecretLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function
        Public Function GetDocSecretPara(ByVal DocSecretID As Long) As DocSecretPara
            Dim lnq As New DocSecretLinq

            Return lnq.GetParameter(DocSecretID, Nothing)
        End Function

        Public Function SaveDocSecret(ByVal para As DocSecretPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New DocSecretLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.SECRET_CODE = para.SECRET_CODE
            lnq.SECRET_NAME = para.SECRET_NAME
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

