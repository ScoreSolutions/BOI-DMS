Imports System.Data
Namespace Master
    Public Class DocStatusEng
        Public Function GetStatusList(ByVal WhText As String) As DataTable
            Dim lnq As New Linq.TABLE.DocStatusLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetDataList(WhText & " and active='Y'", "", trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetStatusPara(ByVal vID As Long) As Para.TABLE.DocStatusPara
            Dim lnq As New Linq.TABLE.DocStatusLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim para As New Para.TABLE.DocStatusPara
            para = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()
            Return para
        End Function
    End Class
End Namespace

