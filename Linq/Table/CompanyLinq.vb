Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = Linq.Common.Utilities.SQLDB
Imports Para.TABLE
Imports Para.Common.Utilities

Namespace TABLE
    'Represents a transaction for COMPANY table Linq.
    '[Create by  on September, 13 2012]
    Public Class CompanyLinq
        Public sub CompanyLinq()

        End Sub 
        ' COMPANY
        Const _tableName As String = "COMPANY"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _COMPANY_TYPE_ID As  System.Nullable(Of Long)  = 0
        Dim _THAINAME As  String  = ""
        Dim _ENGNAME As  String  = ""
        Dim _ADDRESSID As  String  = ""
        Dim _COMID As  String  = ""
        Dim _DESCRIPTION As  String  = ""
        Dim _ACTIVE As  System.Nullable(Of Char)  = "Y"
        Dim _REF_OLD_ID As  String  = ""
        Dim _REF_ORG_ID As  System.Nullable(Of Long)  = 0
        Dim _TH_EGIF_ORG_CODE As  String  = ""
        Dim _TEL As  String  = ""
        Dim _FAX As  String  = ""
        Dim _ZIPCODE As  String  = ""
        Dim _PROVINCE_ID As  System.Nullable(Of Long)  = 0
        Dim _DISTRICT_ID As System.Nullable(Of Long) = 0
        Dim _DIRECTOR_POSITION As String = ""
        Dim _COMPANY_REGIS_NO As String = ""


        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_BY() As String
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As String)
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_ON", DbType:="DateTime2 NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_ON() As DateTime
            Get
                Return _CREATE_ON
            End Get
            Set(ByVal value As DateTime)
               _CREATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_BY", DbType:="VarChar(50)")>  _
        Public Property UPDATE_BY() As  String 
            Get
                Return _UPDATE_BY
            End Get
            Set(ByVal value As  String )
               _UPDATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_ON", DbType:="DateTime2")>  _
        Public Property UPDATE_ON() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATE_ON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_TYPE_ID", DbType:="BigInt")>  _
        Public Property COMPANY_TYPE_ID() As  System.Nullable(Of Long) 
            Get
                Return _COMPANY_TYPE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _COMPANY_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_THAINAME", DbType:="VarChar(200)")>  _
        Public Property THAINAME() As  String 
            Get
                Return _THAINAME
            End Get
            Set(ByVal value As  String )
               _THAINAME = value
            End Set
        End Property 
        <Column(Storage:="_ENGNAME", DbType:="VarChar(200)")>  _
        Public Property ENGNAME() As  String 
            Get
                Return _ENGNAME
            End Get
            Set(ByVal value As  String )
               _ENGNAME = value
            End Set
        End Property 
        <Column(Storage:="_ADDRESSID", DbType:="VarChar(50)")>  _
        Public Property ADDRESSID() As  String 
            Get
                Return _ADDRESSID
            End Get
            Set(ByVal value As  String )
               _ADDRESSID = value
            End Set
        End Property 
        <Column(Storage:="_COMID", DbType:="VarChar(50)")>  _
        Public Property COMID() As  String 
            Get
                Return _COMID
            End Get
            Set(ByVal value As  String )
               _COMID = value
            End Set
        End Property 
        <Column(Storage:="_DESCRIPTION", DbType:="VarChar(500)")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE", DbType:="Char(1)")>  _
        Public Property ACTIVE() As  System.Nullable(Of Char) 
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ACTIVE = value
            End Set
        End Property 
        <Column(Storage:="_REF_OLD_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_ID() As  String 
            Get
                Return _REF_OLD_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_ID = value
            End Set
        End Property 
        <Column(Storage:="_REF_ORG_ID", DbType:="BigInt")>  _
        Public Property REF_ORG_ID() As  System.Nullable(Of Long) 
            Get
                Return _REF_ORG_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REF_ORG_ID = value
            End Set
        End Property 
        <Column(Storage:="_TH_EGIF_ORG_CODE", DbType:="VarChar(50)")>  _
        Public Property TH_EGIF_ORG_CODE() As  String 
            Get
                Return _TH_EGIF_ORG_CODE
            End Get
            Set(ByVal value As  String )
               _TH_EGIF_ORG_CODE = value
            End Set
        End Property 
        <Column(Storage:="_TEL", DbType:="VarChar(255)")>  _
        Public Property TEL() As  String 
            Get
                Return _TEL
            End Get
            Set(ByVal value As  String )
               _TEL = value
            End Set
        End Property 
        <Column(Storage:="_FAX", DbType:="VarChar(255)")>  _
        Public Property FAX() As  String 
            Get
                Return _FAX
            End Get
            Set(ByVal value As  String )
               _FAX = value
            End Set
        End Property 
        <Column(Storage:="_ZIPCODE", DbType:="VarChar(255)")>  _
        Public Property ZIPCODE() As  String 
            Get
                Return _ZIPCODE
            End Get
            Set(ByVal value As  String )
               _ZIPCODE = value
            End Set
        End Property 
        <Column(Storage:="_PROVINCE_ID", DbType:="BigInt")>  _
        Public Property PROVINCE_ID() As  System.Nullable(Of Long) 
            Get
                Return _PROVINCE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _PROVINCE_ID = value
            End Set
        End Property 
        <Column(Storage:="_DISTRICT_ID", DbType:="BigInt")>  _
        Public Property DISTRICT_ID() As  System.Nullable(Of Long) 
            Get
                Return _DISTRICT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DISTRICT_ID = value
            End Set
        End Property
        <Column(Storage:="_DIRECTOR_POSITION", DbType:="VarChar(255)")> _
        Public Property DIRECTOR_POSITION() As String
            Get
                Return _DIRECTOR_POSITION
            End Get
            Set(ByVal value As String)
                _DIRECTOR_POSITION = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_REGIS_NO", DbType:="VarChar(50)")> _
        Public Property COMPANY_REGIS_NO() As String
            Get
                Return _COMPANY_REGIS_NO
            End Get
            Set(ByVal value As String)
                _COMPANY_REGIS_NO = value
            End Set
        End Property

        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _COMPANY_TYPE_ID = 0
            _THAINAME = ""
            _ENGNAME = ""
            _ADDRESSID = ""
            _COMID = ""
            _DESCRIPTION = ""
            _ACTIVE = ""
            _REF_OLD_ID = ""
            _REF_ORG_ID = 0
            _TH_EGIF_ORG_CODE = ""
            _TEL = ""
            _FAX = ""
            _ZIPCODE = ""
            _PROVINCE_ID = 0
            _DISTRICT_ID = 0
            _DIRECTOR_POSITION = ""
            _COMPANY_REGIS_NO = ""
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into COMPANY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _id = DB.GetNextID("id",tableName, trans)
                _CREATE_BY = LoginName
                _CREATE_ON = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to COMPANY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UPDATE_BY = LoginName
                _UPDATE_ON = DateTime.Now
                Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to COMPANY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from COMPANY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cPK As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("id = " & cPK, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of COMPANY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of COMPANY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As CompanyLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of COMPANY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As CompanyPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of COMPANY by specified THAINAME key is retrieved successfully.
        '/// <param name=cTHAINAME>The THAINAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTHAINAME(cTHAINAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("THAINAME = " & DB.SetString(cTHAINAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of COMPANY by specified THAINAME key is retrieved successfully.
        '/// <param name=cTHAINAME>The THAINAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTHAINAME(cTHAINAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("THAINAME = " & DB.SetString(cTHAINAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of COMPANY by specified ENGNAME key is retrieved successfully.
        '/// <param name=cENGNAME>The ENGNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByENGNAME(cENGNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("ENGNAME = " & DB.SetString(cENGNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of COMPANY by specified ENGNAME key is retrieved successfully.
        '/// <param name=cENGNAME>The ENGNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByENGNAME(cENGNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ENGNAME = " & DB.SetString(cENGNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of COMPANY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into COMPANY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try

                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = DB.ErrorMessage
                    Else
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC101
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to COMPANY table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try

                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC102
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from COMPANY table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC103
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of COMPANY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_on")) = False Then _create_on = Convert.ToDateTime(Rdr("create_on"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_on")) = False Then _update_on = Convert.ToDateTime(Rdr("update_on"))
                        If Convert.IsDBNull(Rdr("company_type_id")) = False Then _company_type_id = Convert.ToInt64(Rdr("company_type_id"))
                        If Convert.IsDBNull(Rdr("thaiName")) = False Then _thaiName = Rdr("thaiName").ToString()
                        If Convert.IsDBNull(Rdr("engName")) = False Then _engName = Rdr("engName").ToString()
                        If Convert.IsDBNull(Rdr("addressID")) = False Then _addressID = Rdr("addressID").ToString()
                        If Convert.IsDBNull(Rdr("comID")) = False Then _comID = Rdr("comID").ToString()
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then _ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("ref_org_id")) = False Then _ref_org_id = Convert.ToInt64(Rdr("ref_org_id"))
                        If Convert.IsDBNull(Rdr("th_egif_org_code")) = False Then _th_egif_org_code = Rdr("th_egif_org_code").ToString()
                        If Convert.IsDBNull(Rdr("tel")) = False Then _tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then _fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("zipcode")) = False Then _zipcode = Rdr("zipcode").ToString()
                        If Convert.IsDBNull(Rdr("province_id")) = False Then _province_id = Convert.ToInt64(Rdr("province_id"))
                        If Convert.IsDBNull(Rdr("district_id")) = False Then _DISTRICT_ID = Convert.ToInt64(Rdr("district_id"))
                        If Convert.IsDBNull(Rdr("director_position")) = False Then _DIRECTOR_POSITION = Rdr("director_position").ToString()
                        If Convert.IsDBNull(Rdr("company_regis_no")) = False Then _COMPANY_REGIS_NO = Rdr("company_regis_no").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of COMPANY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As CompanyLinq
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_on")) = False Then _create_on = Convert.ToDateTime(Rdr("create_on"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_on")) = False Then _update_on = Convert.ToDateTime(Rdr("update_on"))
                        If Convert.IsDBNull(Rdr("company_type_id")) = False Then _company_type_id = Convert.ToInt64(Rdr("company_type_id"))
                        If Convert.IsDBNull(Rdr("thaiName")) = False Then _thaiName = Rdr("thaiName").ToString()
                        If Convert.IsDBNull(Rdr("engName")) = False Then _engName = Rdr("engName").ToString()
                        If Convert.IsDBNull(Rdr("addressID")) = False Then _addressID = Rdr("addressID").ToString()
                        If Convert.IsDBNull(Rdr("comID")) = False Then _comID = Rdr("comID").ToString()
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then _ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("ref_org_id")) = False Then _ref_org_id = Convert.ToInt64(Rdr("ref_org_id"))
                        If Convert.IsDBNull(Rdr("th_egif_org_code")) = False Then _th_egif_org_code = Rdr("th_egif_org_code").ToString()
                        If Convert.IsDBNull(Rdr("tel")) = False Then _tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then _fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("zipcode")) = False Then _zipcode = Rdr("zipcode").ToString()
                        If Convert.IsDBNull(Rdr("province_id")) = False Then _province_id = Convert.ToInt64(Rdr("province_id"))
                        If Convert.IsDBNull(Rdr("district_id")) = False Then _DISTRICT_ID = Convert.ToInt64(Rdr("district_id"))
                        If Convert.IsDBNull(Rdr("director_position")) = False Then _DIRECTOR_POSITION = Rdr("director_position").ToString()
                        If Convert.IsDBNull(Rdr("company_regis_no")) = False Then _COMPANY_REGIS_NO = Rdr("company_regis_no").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : GROUP_TITLE_COMPANY_DEFAULT Column :company_id
                        Dim GroupTitleCompanyDefault_company_idItem As New GroupTitleCompanyDefaultLinq
                        _GROUP_TITLE_COMPANY_DEFAULT_company_id = GroupTitleCompanyDefault_company_idItem.GetDataList("company_id = " & _ID, "", Nothing)

                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function


        '/// Returns an indication whether the Class Data of COMPANY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As CompanyPara
            ClearData()
            _haveData  = False
            Dim ret As New CompanyPara
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then ret.id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then ret.create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_on")) = False Then ret.create_on = Convert.ToDateTime(Rdr("create_on"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then ret.update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_on")) = False Then ret.update_on = Convert.ToDateTime(Rdr("update_on"))
                        If Convert.IsDBNull(Rdr("company_type_id")) = False Then ret.company_type_id = Convert.ToInt64(Rdr("company_type_id"))
                        If Convert.IsDBNull(Rdr("thaiName")) = False Then ret.thaiName = Rdr("thaiName").ToString()
                        If Convert.IsDBNull(Rdr("engName")) = False Then ret.engName = Rdr("engName").ToString()
                        If Convert.IsDBNull(Rdr("addressID")) = False Then ret.addressID = Rdr("addressID").ToString()
                        If Convert.IsDBNull(Rdr("comID")) = False Then ret.comID = Rdr("comID").ToString()
                        If Convert.IsDBNull(Rdr("description")) = False Then ret.description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then ret.active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then ret.ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("ref_org_id")) = False Then ret.ref_org_id = Convert.ToInt64(Rdr("ref_org_id"))
                        If Convert.IsDBNull(Rdr("th_egif_org_code")) = False Then ret.th_egif_org_code = Rdr("th_egif_org_code").ToString()
                        If Convert.IsDBNull(Rdr("tel")) = False Then ret.tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then ret.fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("zipcode")) = False Then ret.zipcode = Rdr("zipcode").ToString()
                        If Convert.IsDBNull(Rdr("province_id")) = False Then ret.province_id = Convert.ToInt64(Rdr("province_id"))
                        If Convert.IsDBNull(Rdr("district_id")) = False Then ret.DISTRICT_ID = Convert.ToInt64(Rdr("district_id"))
                        If Convert.IsDBNull(Rdr("director_position")) = False Then ret.DIRECTOR_POSITION = Rdr("director_position").ToString()
                        If Convert.IsDBNull(Rdr("company_regis_no")) = False Then ret.COMPANY_REGIS_NO = Rdr("company_regis_no").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : GROUP_TITLE_COMPANY_DEFAULT Column :company_id
                        Dim GroupTitleCompanyDefault_company_idItem As New GroupTitleCompanyDefaultLinq
                        _GROUP_TITLE_COMPANY_DEFAULT_company_id = GroupTitleCompanyDefault_company_idItem.GetDataList("company_id = " & ret.id, "", Nothing)
                        ret.CHILD_GROUP_TITLE_COMPANY_DEFAULT_company_id = _GROUP_TITLE_COMPANY_DEFAULT_company_id


                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return ret
        End Function

        ' SQL Statements


        'Get Insert Statement for table COMPANY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & TableName & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, COMPANY_TYPE_ID, THAINAME, ENGNAME, ADDRESSID, COMID, DESCRIPTION, ACTIVE, REF_OLD_ID, REF_ORG_ID, TH_EGIF_ORG_CODE, TEL, FAX, ZIPCODE, PROVINCE_ID, DISTRICT_ID, DIRECTOR_POSITION, COMPANY_REGIS_NO)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDouble(_COMPANY_TYPE_ID) & ", "
                sql += DB.SetString(_THAINAME) & ", "
                sql += DB.SetString(_ENGNAME) & ", "
                sql += DB.SetString(_ADDRESSID) & ", "
                sql += DB.SetString(_COMID) & ", "
                sql += DB.SetString(_DESCRIPTION) & ", "
                sql += DB.SetString(_ACTIVE) & ", "
                sql += DB.SetString(_REF_OLD_ID) & ", "
                sql += DB.SetDouble(_REF_ORG_ID) & ", "
                sql += DB.SetString(_TH_EGIF_ORG_CODE) & ", "
                sql += DB.SetString(_TEL) & ", "
                sql += DB.SetString(_FAX) & ", "
                sql += DB.SetString(_ZIPCODE) & ", "
                sql += DB.SetDouble(_PROVINCE_ID) & ", "
                Sql += DB.SetDouble(_DISTRICT_ID) & ", "
                Sql += DB.SetString(_DIRECTOR_POSITION) & ", "
                Sql += DB.SetString(_COMPANY_REGIS_NO) & " "
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table COMPANY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "COMPANY_TYPE_ID = " & DB.SetDouble(_COMPANY_TYPE_ID) & ", "
                Sql += "THAINAME = " & DB.SetString(_THAINAME) & ", "
                Sql += "ENGNAME = " & DB.SetString(_ENGNAME) & ", "
                Sql += "ADDRESSID = " & DB.SetString(_ADDRESSID) & ", "
                Sql += "COMID = " & DB.SetString(_COMID) & ", "
                Sql += "DESCRIPTION = " & DB.SetString(_DESCRIPTION) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) & ", "
                Sql += "REF_OLD_ID = " & DB.SetString(_REF_OLD_ID) & ", "
                Sql += "REF_ORG_ID = " & DB.SetDouble(_REF_ORG_ID) & ", "
                Sql += "TH_EGIF_ORG_CODE = " & DB.SetString(_TH_EGIF_ORG_CODE) & ", "
                Sql += "TEL = " & DB.SetString(_TEL) & ", "
                Sql += "FAX = " & DB.SetString(_FAX) & ", "
                Sql += "ZIPCODE = " & DB.SetString(_ZIPCODE) & ", "
                Sql += "PROVINCE_ID = " & DB.SetDouble(_PROVINCE_ID) & ", "
                Sql += "DISTRICT_ID = " & DB.SetDouble(_DISTRICT_ID) + ", "
                Sql += "DIRECTOR_POSITION = " & DB.SetString(_DIRECTOR_POSITION) & ", "
                Sql += "COMPANY_REGIS_NO = " & DB.SetString(_COMPANY_REGIS_NO) & " "
                Return Sql
            End Get
        End Property


        'Get Delete Record in table COMPANY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table COMPANY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _GROUP_TITLE_COMPANY_DEFAULT_company_id As DataTable

       Public Property CHILD_GROUP_TITLE_COMPANY_DEFAULT_company_id() As DataTable
           Get
               Return _GROUP_TITLE_COMPANY_DEFAULT_company_id
           End Get
           Set(ByVal value As DataTable)
               _GROUP_TITLE_COMPANY_DEFAULT_company_id = value
           End Set
       End Property
    End Class
End Namespace
