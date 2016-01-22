Imports Linq.TABLE
Imports Para.TABLE
Imports System.Data

Namespace Master
    Public Class Objective
        Public Function GetAllObjectiveTable() As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New ObjectiveLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("1=1 ", "objective_name", trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetBusinesstypeID(ByVal id As Long) As DataTable
            Return Nothing
        End Function

        Public Function GetObjectList() As DataTable
            Dim sql As String = "select id,objective_name "
            sql += " from OBJECTIVE "
            sql += " where active = 'Y'"
            sql += " order by objective_name "
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim lnq As New OfficerLinq
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            Return dt
        End Function
    End Class
End Namespace

