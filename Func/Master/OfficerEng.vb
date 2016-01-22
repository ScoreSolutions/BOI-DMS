Imports Linq.TABLE
Namespace Master
    Public Class OfficerEng
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property

        Public Function GetOfficerList() As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim sql As String = "select id, first_name + ' ' + last_name full_name "
            sql += " from officer "
            sql += " order by first_name "
            Dim lnq As New OfficerLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetOfficerPara(ByVal vID As Long) As Para.TABLE.OfficerPara
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim para As New Para.TABLE.OfficerPara
            Dim lnq As New OfficerLinq
            para = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return para
        End Function

        Public Function GetOfficerPara(ByVal vID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As Para.TABLE.OfficerPara
            Dim para As New Para.TABLE.OfficerPara
            Dim lnq As New OfficerLinq
            para = lnq.GetParameter(vID, trans.Trans)
            lnq = Nothing

            Return para
        End Function

        Public Function GetOfficerParaByUserName(ByVal UserName As String) As Para.TABLE.OfficerPara
            Dim para As New Para.TABLE.OfficerPara
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'If trans.CreateTransaction() = True Then
            Dim lnq As New OfficerLinq
            If lnq.ChkDataByUSERNAME(UserName, Nothing) = True Then
                para = lnq.GetParameter(lnq.ID, Nothing)
                'trans.CommitTransaction()
            End If
            lnq = Nothing
            'Else
            '_err = trans.ErrorMessage
            'End If

            Return para
        End Function

        Public Function UpdateUserProfile(ByVal sql As String) As Boolean
            Dim ret As Boolean = False

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New OfficerLinq
            ret = lnq.UpdateBySql(sql, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

            Return ret
        End Function
    End Class
End Namespace

