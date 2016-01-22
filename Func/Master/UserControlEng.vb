Imports Linq.TABLE
Imports Linq.Common.Utilities
Imports Para.TABLE

Namespace Master
    Public Class UserControlEng
        Public Function GetCompanyList(ByVal ComID As String, ByVal ComName As String) As DataTable
            Dim lnq As New CompanyLinq
            Dim whText As String = " 1=1 "
            If ComID.Trim <> "" Then
                whText += " and comID like '%" & ComID & "%' "
            End If
            If ComName.Trim <> "" Then
                whText += " and (thainame like '%" & ComName & "%' or engname like '%" & ComName & "%')"
            End If
            Return lnq.GetDataList(whText, "thainame, engname", Nothing)
        End Function

        Public Function GetCompanyParameter(ByVal ID As Long) As CompanyPara
            Dim lnq As New CompanyLinq
            Return lnq.GetParameter(ID, Nothing)
        End Function
    End Class
End Namespace
