Imports Linq.TABLE
Namespace Master
    Public Class OfficerFunc
        Public Function GetOfficerList() As DataTable
            Dim trans As New Common.DbTrans
            trans.CreateTransaction()

            Dim sql As String = "select id, first_name + ' ' + last_name full_name "
            sql += " from officer "
            sql += " order by first_name "
            Dim lnq As New OfficerLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function
    End Class
End Namespace

