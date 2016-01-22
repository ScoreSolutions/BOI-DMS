Public Class frmCompany

    Private Sub btnCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompany.Click
        Dim cDt As SqlClient.SqlDataReader
        Dim trans As New Utilities.TransactionDB
        trans.CreateTransaction(Utilities.SqlDB.GetOldConnection)
        cDt = Utilities.SqlDB.ExecuteReader("select * from _company ", trans.Trans)
        trans.CommitTransaction()
        Do While cDt.Read
            Dim nTrans As New Utilities.TransactionDB
            nTrans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
            If GetImportedCompany(cDt("id").ToString, nTrans) = False Then
                Dim mxID As Long = Utilities.SqlDB.GetNextID("ID", "COMPANY", nTrans.Trans)
                Dim iSql As String = "INSERT INTO [COMPANY]"
                iSql += " ([id]"
                iSql += " ,[create_by]"
                iSql += " ,[create_on]"
                iSql += " ,[company_type_id]"
                iSql += " ,[thaiName]"
                iSql += " ,[engName]"
                iSql += " ,[comID]"
                iSql += " ,[description]"
                iSql += " ,[active]"
                iSql += " ,[ref_old_id])"
                iSql += " values(" & mxID & ",'SYSTEM',getdate()"
                iSql += ", '" & Convert.ToInt16(cDt("companyTypeID").ToString) & "'"
                iSql += ", " & IIf(Convert.IsDBNull(cDt("thaiName")) = False, Utilities.SqlDB.SetString(cDt("thaiName").ToString), "null")
                iSql += ", " & IIf(Convert.IsDBNull(cDt("englishName")) = False, Utilities.SqlDB.SetString(cDt("englishName").ToString), "null")
                iSql += ", " & IIf(Convert.IsDBNull(cDt("comID")) = False, Utilities.SqlDB.SetString(cDt("comID").ToString), "null")
                iSql += ", " & IIf(Convert.IsDBNull(cDt("description")) = False, Utilities.SqlDB.SetString(cDt("description").ToString), "null")
                iSql += ", " & IIf(cDt("isenable").ToString = "T", "'Y'", "'N'")
                iSql += ", '" & cDt("id").ToString & "'"
                iSql += ")"

                If Utilities.SqlDB.ExecuteNonQuery(iSql, nTrans.Trans) > 0 Then
                    nTrans.CommitTransaction()
                Else
                    nTrans.RollbackTransaction()
                End If
            End If
            nTrans.CommitTransaction()
        Loop

        cDt = Nothing
    End Sub

    Private Function GetImportedCompany(ByVal RefOldID As String, ByVal nTrans As Utilities.TransactionDB) As Boolean
        Dim ret As Boolean = False
        Dim nDt As New DataTable
        nDt = Utilities.SqlDB.ExecuteTable("select id from company where ref_old_id = '" & RefOldID & "'", nTrans.Trans)
        If nDt.Rows.Count > 0 Then
            ret = True
        End If
        nDt = Nothing
        Return ret
    End Function
End Class