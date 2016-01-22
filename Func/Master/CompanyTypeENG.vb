Imports Linq.TABLE
Imports Para.TABLE
Imports System.Data

Namespace Master
    Public Class CompanyTypeENG
        Public Function GetAllCompanyTypeTable() As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New CompanyTypeLinq
            dt = lnq.GetDataList("1=1 ", "company_type_name", trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Function GetCompanyTypeID(ByVal id As Long) As DataTable
            Dim sql As String = "select id,company_type_name "
            sql += " from COMPANY_TYPE "
            sql += " where id = " & id
            sql += " order by id"
            Dim lnq As New CompanyTypeLinq

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Shared Function GetCompanyTypePara(ByVal vID As Long) As Para.TABLE.CompanyTypePara
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim para As New Para.TABLE.CompanyTypePara
            Dim lnq As New Linq.TABLE.CompanyTypeLinq
            para = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return para
        End Function
    End Class
End Namespace

