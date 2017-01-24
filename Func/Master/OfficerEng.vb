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

        Public Function GetOfficerIDByUsernameOrIDCard(ByVal username As String, ByVal idcard As String) As String
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New OfficerLinq
            lnq.ChkDataByUSERNAME(username, trans.Trans)
            If lnq.ID = 0 Then
                lnq.ChkDataByWhere("identity_card='" & idcard & "'", trans.Trans)
            End If

            Dim id As String = "0"
            If lnq.ID > 0 Then
                id = lnq.ID
            End If
            trans.CommitTransaction()
            lnq = Nothing

            Return id
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

        Public Function SaveOfficerData(ByVal _ID As Long, ByVal UserName As String, ByVal OfficerCode As String, ByVal OfficerIDCardNo As String, ByVal FirstNameThai As String, ByVal LastNameThai As String, ByVal FirstNameEng As String, ByVal LastNameEng As String, ByVal Gender As Integer, ByVal OrganizationID As Long, ByVal OfficerLevel As Integer, ByVal TelNo As String, ByVal FaxNo As String, ByVal BirthDate As String, ByVal Email As String, ByVal Description As String, ByVal efDate As String, ByVal epDate As String, ByVal UpdateByUsername As String) As String
            Dim ret As String = "false"
            Dim sqltmp As String = ""
            Dim id As String = "0"
            If _ID = 0 Then
                id = Linq.Common.Utilities.SqlDB.GetNextID("id", "OFFICER", Nothing) 'getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from OFFICER", "maxid")

                sqltmp = "insert into OFFICER ("
                sqltmp = sqltmp + " id"
                sqltmp = sqltmp + ",username"
                sqltmp = sqltmp + ",pwd"
                sqltmp = sqltmp + ",officer_code"
                sqltmp = sqltmp + ",first_name"
                sqltmp = sqltmp + ",last_name"
                sqltmp = sqltmp + ",first_name_thai"
                sqltmp = sqltmp + ",last_name_thai"
                sqltmp = sqltmp + ",first_name_eng"
                sqltmp = sqltmp + ",last_name_eng"
                sqltmp = sqltmp + ",description"
                sqltmp = sqltmp + ",organization_id"
                sqltmp = sqltmp + ",gender"
                sqltmp = sqltmp + ",birth_date"
                sqltmp = sqltmp + ",efdate"
                sqltmp = sqltmp + ",epdate"
                sqltmp = sqltmp + ",officer_level"
                sqltmp = sqltmp + ",identity_card"
                sqltmp = sqltmp + ",tel"
                sqltmp = sqltmp + ",Fax"
                sqltmp = sqltmp + ",email"
                sqltmp = sqltmp + ",create_by"
                sqltmp = sqltmp + ",create_on"
                sqltmp = sqltmp + ") values ("
                sqltmp = sqltmp + "'" & id & "' "
                sqltmp = sqltmp + ",'" + UserName + "'"
                sqltmp = sqltmp + ",'BOI'"
                sqltmp = sqltmp + ",'" + OfficerCode + "'"
                sqltmp = sqltmp + ",'" + FirstNameThai + "'"
                sqltmp = sqltmp + ",'" + LastNameThai + "'"
                sqltmp = sqltmp + ",'" + FirstNameThai + "'"
                sqltmp = sqltmp + ",'" + LastNameThai + "'"
                sqltmp = sqltmp + ",'" + FirstNameEng + "'"
                sqltmp = sqltmp + ",'" + LastNameEng + "'"
                sqltmp = sqltmp + ",'" + Description + "'"
                sqltmp = sqltmp + ",'" + OrganizationID.ToString() + "'"
                sqltmp = sqltmp + ",'" + Gender.ToString() + "'"
                sqltmp = sqltmp + "," + IIf(BirthDate.Trim = "", "null", "'" + BirthDate + "'")
                sqltmp = sqltmp + "," + IIf(efDate.Trim = "", "null", "'" + efDate + "'")
                sqltmp = sqltmp + "," + IIf(epDate.Trim = "", "null", "'" + epDate + "'")
                sqltmp = sqltmp + ",'" + OfficerLevel.ToString() + "'"
                sqltmp = sqltmp + ",'" + OfficerIDCardNo + "'"
                sqltmp = sqltmp + ",'" + TelNo + "'"
                sqltmp = sqltmp + ",'" + FaxNo + "'"
                sqltmp = sqltmp + ",'" + Email + "'"
                sqltmp = sqltmp + ",'" + UpdateByUsername + "'"
                sqltmp = sqltmp + ",getdate())"
            Else
                id = _ID
                sqltmp = "update OFFICER set "
                sqltmp = sqltmp + " username = '" + UserName + "'"
                sqltmp = sqltmp + ",officer_code = '" + OfficerCode + "'"
                sqltmp = sqltmp + ",first_name = '" + FirstNameThai + "'"
                sqltmp = sqltmp + ",last_name = '" + LastNameThai + "'"
                sqltmp = sqltmp + ",first_name_thai = '" + FirstNameThai + "'"
                sqltmp = sqltmp + ",last_name_thai = '" + LastNameThai + "'"
                sqltmp = sqltmp + ",first_name_eng = '" + FirstNameEng + "'"
                sqltmp = sqltmp + ",last_name_eng = '" + LastNameEng + "'"
                sqltmp = sqltmp + ",description = '" + Description + "'"
                sqltmp = sqltmp + ",organization_id = '" + OrganizationID.ToString() + "'"
                sqltmp = sqltmp + ",gender = '" + Gender.ToString() + "'"
                sqltmp = sqltmp + ",birth_date = " + IIf(BirthDate.Trim = "", "null", "'" + BirthDate + "'")
                sqltmp = sqltmp + ",efdate = " + IIf(efDate.Trim = "", "null", "'" + efDate + "'")
                sqltmp = sqltmp + ",epdate = " + IIf(epDate.Trim = "", "null", "'" + epDate + "'")
                sqltmp = sqltmp + ",officer_level = '" + OfficerLevel.ToString() + "'"
                sqltmp = sqltmp + ",identity_card = '" + OfficerIDCardNo + "'"
                sqltmp = sqltmp + ",tel = '" + TelNo + "'"
                sqltmp = sqltmp + ",Fax = '" + FaxNo + "'"
                sqltmp = sqltmp + ",email = '" + Email + "'"
                sqltmp = sqltmp + ",update_by = '" + UpdateByUsername + "'"
                sqltmp = sqltmp + ",update_on= getdate()"
                sqltmp = sqltmp + " where id = '" & id & "'"
            End If

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim re As Integer = Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sqltmp, trans.Trans)
            If re > 0 Then
                trans.CommitTransaction()
                ret = IIf(re = 1, "true", "false") & "|" & id
            Else
                trans.RollbackTransaction()
            End If

            Return ret
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

