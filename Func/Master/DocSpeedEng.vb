Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Namespace Master
    Public Class DocSpeedEng
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

        Public Function GetAllSpeedList() As DataTable
            Dim lnq As New DocSpeedLinq
            Return lnq.GetDataList("1=1", "speed_code", Nothing)
        End Function
        Public Function GetDataSpeedList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New DocSpeedLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function

        Public Function GetDocSpeedPara(ByVal DocSpeedID As Long) As DocSpeedPara
            Dim lnq As New DocSpeedLinq

            Return lnq.GetParameter(DocSpeedID, Nothing)
        End Function

        Public Function SaveDocSpeed(ByVal para As DocSpeedPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New DocSpeedLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.SPEED_CODE = para.SPEED_CODE
            lnq.SPEED_NAME = para.SPEED_NAME
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

        Public Function DeleteDocSpeed(ByVal vID As Long) As String
            Dim ret As String = ""
            Dim lnq As New DocSpeedLinq
            Dim para As New DocSpeedPara
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            lnq.DeleteByPK(vID, trans.Trans)

            If lnq.ErrorMessage <> "" Then
                trans.RollbackTransaction()
                ret = lnq.ErrorMessage
            Else
                trans.CommitTransaction()
            End If

            Return ret
        End Function
    End Class
End Namespace

