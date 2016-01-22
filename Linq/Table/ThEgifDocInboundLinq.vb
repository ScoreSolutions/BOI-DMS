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
    'Represents a transaction for TH_EGIF_DOC_INBOUND table Linq.
    '[Create by  on September, 6 2012]
    Public Class ThEgifDocInboundLinq
        Public sub ThEgifDocInboundLinq()

        End Sub 
        ' TH_EGIF_DOC_INBOUND
        Const _tableName As String = "TH_EGIF_DOC_INBOUND"
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
        Dim _PROCESS_ID As String = ""
        Dim _PROCESS_TIME As String = ""
        Dim _BODY_ID As String = ""
        Dim _BODY_CORRESPONDENCE_DATE As String = ""
        Dim _BODY_SUBJECT As String = ""
        Dim _BODY_SECRET_CODE As  String  = ""
        Dim _BODY_SPEED_CODE As  String  = ""
        Dim _SENDER_GIVEN_NAME As  String  = ""
        Dim _SENDER_FAMILY_NAME As  String  = ""
        Dim _SENDER_JOBTITLE As  String  = ""
        Dim _SENDER_MINISTRY_ORGANIZATION_ID As  String  = ""
        Dim _SENDER_DEPARTMENT_ORGANIZATION_ID As  String  = ""
        Dim _RECEIVER_GIVEN_NAME As  String  = ""
        Dim _RECEIVER_FAMILY_NAME As  String  = ""
        Dim _RECEIVER_JOBTITLE As  String  = ""
        Dim _RECEIVER_MINISTRY_ORGANIZATION_ID As  String  = ""
        Dim _RECEIVER_DEPARTMENT_ORGANIZATION_ID As  String  = ""
        Dim _ATTACHMENT As  String  = ""
        Dim _SEND_DATE As  String  = ""
        Dim _DESCRIPTION As  String  = ""
        Dim _MAIN_LETTER_MIME As  String  = ""
        Dim _MAIN_LETTER_DATABASE64 As  String  = ""
        Dim _GOVERNMENT_SIGNATURE_TYPECODE As  String  = ""
        Dim _SIGNER_GIVEN_NAME As  String  = ""
        Dim _SIGNER_FAMILY_NAME As  String  = ""
        Dim _SIGNER_JOB_TITLE As  String  = ""
        Dim _SIGNER_MINISTRY_ORGANIZATION_ID As  String  = ""
        Dim _SIGNER_DEPARTMENT_ORGANIZATION_ID As  String  = ""
        Dim _REFERENCE_URI As  String  = ""
        Dim _REFERENCE_DIGEST_VALUE As  String  = ""
        Dim _SIGNATURE_VALUE As  String  = ""
        Dim _KEY_VALUE_MODULE As  String  = ""
        Dim _KEY_VALUE_EXPONENT As  String  = ""
        Dim _DELETE_JOB_PROCESSID As  String  = ""
        Dim _DELETE_JOB_PROCESSTIME As  String  = ""
        Dim _RECEIVE_NOTIFY_LETTERID As  String  = ""
        Dim _RECEIVE_NOTIFY_CORRESPONDENCE_DATE As  String  = ""
        Dim _RECEIVE_NOTIFY_SUBJECT As  String  = ""
        Dim _RECEIVE_NOTIFY_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_PROCESS_ID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property PROCESS_ID() As String
            Get
                Return _PROCESS_ID
            End Get
            Set(ByVal value As String)
               _PROCESS_ID = value
            End Set
        End Property 
        <Column(Storage:="_PROCESS_TIME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property PROCESS_TIME() As String
            Get
                Return _PROCESS_TIME
            End Get
            Set(ByVal value As String)
               _PROCESS_TIME = value
            End Set
        End Property 
        <Column(Storage:="_BODY_ID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BODY_ID() As String
            Get
                Return _BODY_ID
            End Get
            Set(ByVal value As String)
               _BODY_ID = value
            End Set
        End Property 
        <Column(Storage:="_BODY_CORRESPONDENCE_DATE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BODY_CORRESPONDENCE_DATE() As String
            Get
                Return _BODY_CORRESPONDENCE_DATE
            End Get
            Set(ByVal value As String)
               _BODY_CORRESPONDENCE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_BODY_SUBJECT", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BODY_SUBJECT() As String
            Get
                Return _BODY_SUBJECT
            End Get
            Set(ByVal value As String)
               _BODY_SUBJECT = value
            End Set
        End Property 
        <Column(Storage:="_BODY_SECRET_CODE", DbType:="VarChar(10)")>  _
        Public Property BODY_SECRET_CODE() As  String 
            Get
                Return _BODY_SECRET_CODE
            End Get
            Set(ByVal value As  String )
               _BODY_SECRET_CODE = value
            End Set
        End Property 
        <Column(Storage:="_BODY_SPEED_CODE", DbType:="VarChar(10)")>  _
        Public Property BODY_SPEED_CODE() As  String 
            Get
                Return _BODY_SPEED_CODE
            End Get
            Set(ByVal value As  String )
               _BODY_SPEED_CODE = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_GIVEN_NAME", DbType:="VarChar(100)")>  _
        Public Property SENDER_GIVEN_NAME() As  String 
            Get
                Return _SENDER_GIVEN_NAME
            End Get
            Set(ByVal value As  String )
               _SENDER_GIVEN_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_FAMILY_NAME", DbType:="VarChar(100)")>  _
        Public Property SENDER_FAMILY_NAME() As  String 
            Get
                Return _SENDER_FAMILY_NAME
            End Get
            Set(ByVal value As  String )
               _SENDER_FAMILY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_JOBTITLE", DbType:="VarChar(255)")>  _
        Public Property SENDER_JOBTITLE() As  String 
            Get
                Return _SENDER_JOBTITLE
            End Get
            Set(ByVal value As  String )
               _SENDER_JOBTITLE = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_MINISTRY_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SENDER_MINISTRY_ORGANIZATION_ID() As  String 
            Get
                Return _SENDER_MINISTRY_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SENDER_MINISTRY_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_DEPARTMENT_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SENDER_DEPARTMENT_ORGANIZATION_ID() As  String 
            Get
                Return _SENDER_DEPARTMENT_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SENDER_DEPARTMENT_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_GIVEN_NAME", DbType:="VarChar(100)")>  _
        Public Property RECEIVER_GIVEN_NAME() As  String 
            Get
                Return _RECEIVER_GIVEN_NAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_GIVEN_NAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_FAMILY_NAME", DbType:="VarChar(100)")>  _
        Public Property RECEIVER_FAMILY_NAME() As  String 
            Get
                Return _RECEIVER_FAMILY_NAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_FAMILY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_JOBTITLE", DbType:="VarChar(255)")>  _
        Public Property RECEIVER_JOBTITLE() As  String 
            Get
                Return _RECEIVER_JOBTITLE
            End Get
            Set(ByVal value As  String )
               _RECEIVER_JOBTITLE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_MINISTRY_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property RECEIVER_MINISTRY_ORGANIZATION_ID() As  String 
            Get
                Return _RECEIVER_MINISTRY_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVER_MINISTRY_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_DEPARTMENT_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property RECEIVER_DEPARTMENT_ORGANIZATION_ID() As  String 
            Get
                Return _RECEIVER_DEPARTMENT_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVER_DEPARTMENT_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_ATTACHMENT", DbType:="Text")>  _
        Public Property ATTACHMENT() As  String 
            Get
                Return _ATTACHMENT
            End Get
            Set(ByVal value As  String )
               _ATTACHMENT = value
            End Set
        End Property 
        <Column(Storage:="_SEND_DATE", DbType:="VarChar(50)")>  _
        Public Property SEND_DATE() As  String 
            Get
                Return _SEND_DATE
            End Get
            Set(ByVal value As  String )
               _SEND_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DESCRIPTION", DbType:="Text")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_MAIN_LETTER_MIME", DbType:="VarChar(50)")>  _
        Public Property MAIN_LETTER_MIME() As  String 
            Get
                Return _MAIN_LETTER_MIME
            End Get
            Set(ByVal value As  String )
               _MAIN_LETTER_MIME = value
            End Set
        End Property 
        <Column(Storage:="_MAIN_LETTER_DATABASE64", DbType:="Text")>  _
        Public Property MAIN_LETTER_DATABASE64() As  String 
            Get
                Return _MAIN_LETTER_DATABASE64
            End Get
            Set(ByVal value As  String )
               _MAIN_LETTER_DATABASE64 = value
            End Set
        End Property 
        <Column(Storage:="_GOVERNMENT_SIGNATURE_TYPECODE", DbType:="VarChar(50)")>  _
        Public Property GOVERNMENT_SIGNATURE_TYPECODE() As  String 
            Get
                Return _GOVERNMENT_SIGNATURE_TYPECODE
            End Get
            Set(ByVal value As  String )
               _GOVERNMENT_SIGNATURE_TYPECODE = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_GIVEN_NAME", DbType:="VarChar(100)")>  _
        Public Property SIGNER_GIVEN_NAME() As  String 
            Get
                Return _SIGNER_GIVEN_NAME
            End Get
            Set(ByVal value As  String )
               _SIGNER_GIVEN_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_FAMILY_NAME", DbType:="VarChar(100)")>  _
        Public Property SIGNER_FAMILY_NAME() As  String 
            Get
                Return _SIGNER_FAMILY_NAME
            End Get
            Set(ByVal value As  String )
               _SIGNER_FAMILY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_JOB_TITLE", DbType:="VarChar(255)")>  _
        Public Property SIGNER_JOB_TITLE() As  String 
            Get
                Return _SIGNER_JOB_TITLE
            End Get
            Set(ByVal value As  String )
               _SIGNER_JOB_TITLE = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_MINISTRY_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SIGNER_MINISTRY_ORGANIZATION_ID() As  String 
            Get
                Return _SIGNER_MINISTRY_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SIGNER_MINISTRY_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_DEPARTMENT_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SIGNER_DEPARTMENT_ORGANIZATION_ID() As  String 
            Get
                Return _SIGNER_DEPARTMENT_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SIGNER_DEPARTMENT_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_REFERENCE_URI", DbType:="Text")>  _
        Public Property REFERENCE_URI() As  String 
            Get
                Return _REFERENCE_URI
            End Get
            Set(ByVal value As  String )
               _REFERENCE_URI = value
            End Set
        End Property 
        <Column(Storage:="_REFERENCE_DIGEST_VALUE", DbType:="Text")>  _
        Public Property REFERENCE_DIGEST_VALUE() As  String 
            Get
                Return _REFERENCE_DIGEST_VALUE
            End Get
            Set(ByVal value As  String )
               _REFERENCE_DIGEST_VALUE = value
            End Set
        End Property 
        <Column(Storage:="_SIGNATURE_VALUE", DbType:="Text")>  _
        Public Property SIGNATURE_VALUE() As  String 
            Get
                Return _SIGNATURE_VALUE
            End Get
            Set(ByVal value As  String )
               _SIGNATURE_VALUE = value
            End Set
        End Property 
        <Column(Storage:="_KEY_VALUE_MODULE", DbType:="Text")>  _
        Public Property KEY_VALUE_MODULE() As  String 
            Get
                Return _KEY_VALUE_MODULE
            End Get
            Set(ByVal value As  String )
               _KEY_VALUE_MODULE = value
            End Set
        End Property 
        <Column(Storage:="_KEY_VALUE_EXPONENT", DbType:="Text")>  _
        Public Property KEY_VALUE_EXPONENT() As  String 
            Get
                Return _KEY_VALUE_EXPONENT
            End Get
            Set(ByVal value As  String )
               _KEY_VALUE_EXPONENT = value
            End Set
        End Property 
        <Column(Storage:="_DELETE_JOB_PROCESSID", DbType:="VarChar(50)")>  _
        Public Property DELETE_JOB_PROCESSID() As  String 
            Get
                Return _DELETE_JOB_PROCESSID
            End Get
            Set(ByVal value As  String )
               _DELETE_JOB_PROCESSID = value
            End Set
        End Property 
        <Column(Storage:="_DELETE_JOB_PROCESSTIME", DbType:="VarChar(50)")>  _
        Public Property DELETE_JOB_PROCESSTIME() As  String 
            Get
                Return _DELETE_JOB_PROCESSTIME
            End Get
            Set(ByVal value As  String )
               _DELETE_JOB_PROCESSTIME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_LETTERID", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_NOTIFY_LETTERID() As  String 
            Get
                Return _RECEIVE_NOTIFY_LETTERID
            End Get
            Set(ByVal value As  String )
               _RECEIVE_NOTIFY_LETTERID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_CORRESPONDENCE_DATE", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_NOTIFY_CORRESPONDENCE_DATE() As  String 
            Get
                Return _RECEIVE_NOTIFY_CORRESPONDENCE_DATE
            End Get
            Set(ByVal value As  String )
               _RECEIVE_NOTIFY_CORRESPONDENCE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_SUBJECT", DbType:="VarChar(255)")>  _
        Public Property RECEIVE_NOTIFY_SUBJECT() As  String 
            Get
                Return _RECEIVE_NOTIFY_SUBJECT
            End Get
            Set(ByVal value As  String )
               _RECEIVE_NOTIFY_SUBJECT = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_TIME", DbType:="DateTime")>  _
        Public Property RECEIVE_NOTIFY_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _RECEIVE_NOTIFY_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RECEIVE_NOTIFY_TIME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _PROCESS_ID = ""
            _PROCESS_TIME = ""
            _BODY_ID = ""
            _BODY_CORRESPONDENCE_DATE = ""
            _BODY_SUBJECT = ""
            _BODY_SECRET_CODE = ""
            _BODY_SPEED_CODE = ""
            _SENDER_GIVEN_NAME = ""
            _SENDER_FAMILY_NAME = ""
            _SENDER_JOBTITLE = ""
            _SENDER_MINISTRY_ORGANIZATION_ID = ""
            _SENDER_DEPARTMENT_ORGANIZATION_ID = ""
            _RECEIVER_GIVEN_NAME = ""
            _RECEIVER_FAMILY_NAME = ""
            _RECEIVER_JOBTITLE = ""
            _RECEIVER_MINISTRY_ORGANIZATION_ID = ""
            _RECEIVER_DEPARTMENT_ORGANIZATION_ID = ""
            _ATTACHMENT = ""
            _SEND_DATE = ""
            _DESCRIPTION = ""
            _MAIN_LETTER_MIME = ""
            _MAIN_LETTER_DATABASE64 = ""
            _GOVERNMENT_SIGNATURE_TYPECODE = ""
            _SIGNER_GIVEN_NAME = ""
            _SIGNER_FAMILY_NAME = ""
            _SIGNER_JOB_TITLE = ""
            _SIGNER_MINISTRY_ORGANIZATION_ID = ""
            _SIGNER_DEPARTMENT_ORGANIZATION_ID = ""
            _REFERENCE_URI = ""
            _REFERENCE_DIGEST_VALUE = ""
            _SIGNATURE_VALUE = ""
            _KEY_VALUE_MODULE = ""
            _KEY_VALUE_EXPONENT = ""
            _DELETE_JOB_PROCESSID = ""
            _DELETE_JOB_PROCESSTIME = ""
            _RECEIVE_NOTIFY_LETTERID = ""
            _RECEIVE_NOTIFY_CORRESPONDENCE_DATE = ""
            _RECEIVE_NOTIFY_SUBJECT = ""
            _RECEIVE_NOTIFY_TIME = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into TH_EGIF_DOC_INBOUND table successfully.
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


        '/// Returns an indication whether the current data is updated to TH_EGIF_DOC_INBOUND table successfully.
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


        '/// Returns an indication whether the current data is updated to TH_EGIF_DOC_INBOUND table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TH_EGIF_DOC_INBOUND table successfully.
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


        '/// Returns an indication whether the record of TH_EGIF_DOC_INBOUND by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TH_EGIF_DOC_INBOUND by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As ThEgifDocInboundLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of TH_EGIF_DOC_INBOUND by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As ThEgifDocInboundPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TH_EGIF_DOC_INBOUND by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TH_EGIF_DOC_INBOUND table successfully.
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


        '/// Returns an indication whether the current data is updated to TH_EGIF_DOC_INBOUND table successfully.
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


        '/// Returns an indication whether the current data is deleted from TH_EGIF_DOC_INBOUND table successfully.
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


        '/// Returns an indication whether the record of TH_EGIF_DOC_INBOUND by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("process_id")) = False Then _process_id = Rdr("process_id").ToString()
                        If Convert.IsDBNull(Rdr("process_time")) = False Then _process_time = Rdr("process_time").ToString()
                        If Convert.IsDBNull(Rdr("body_id")) = False Then _body_id = Rdr("body_id").ToString()
                        If Convert.IsDBNull(Rdr("body_correspondence_date")) = False Then _body_correspondence_date = Rdr("body_correspondence_date").ToString()
                        If Convert.IsDBNull(Rdr("body_subject")) = False Then _body_subject = Rdr("body_subject").ToString()
                        If Convert.IsDBNull(Rdr("body_secret_code")) = False Then _body_secret_code = Rdr("body_secret_code").ToString()
                        If Convert.IsDBNull(Rdr("body_speed_code")) = False Then _body_speed_code = Rdr("body_speed_code").ToString()
                        If Convert.IsDBNull(Rdr("sender_given_name")) = False Then _sender_given_name = Rdr("sender_given_name").ToString()
                        If Convert.IsDBNull(Rdr("sender_family_name")) = False Then _sender_family_name = Rdr("sender_family_name").ToString()
                        If Convert.IsDBNull(Rdr("sender_jobtitle")) = False Then _sender_jobtitle = Rdr("sender_jobtitle").ToString()
                        If Convert.IsDBNull(Rdr("sender_ministry_organization_id")) = False Then _sender_ministry_organization_id = Rdr("sender_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("sender_department_organization_id")) = False Then _sender_department_organization_id = Rdr("sender_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("receiver_given_name")) = False Then _receiver_given_name = Rdr("receiver_given_name").ToString()
                        If Convert.IsDBNull(Rdr("receiver_family_name")) = False Then _receiver_family_name = Rdr("receiver_family_name").ToString()
                        If Convert.IsDBNull(Rdr("receiver_jobtitle")) = False Then _receiver_jobtitle = Rdr("receiver_jobtitle").ToString()
                        If Convert.IsDBNull(Rdr("receiver_ministry_organization_id")) = False Then _receiver_ministry_organization_id = Rdr("receiver_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("receiver_department_organization_id")) = False Then _receiver_department_organization_id = Rdr("receiver_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("attachment")) = False Then _attachment = Rdr("attachment").ToString()
                        If Convert.IsDBNull(Rdr("send_date")) = False Then _send_date = Rdr("send_date").ToString()
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("main_letter_mime")) = False Then _main_letter_mime = Rdr("main_letter_mime").ToString()
                        If Convert.IsDBNull(Rdr("main_letter_database64")) = False Then _main_letter_database64 = Rdr("main_letter_database64").ToString()
                        If Convert.IsDBNull(Rdr("government_signature_typecode")) = False Then _government_signature_typecode = Rdr("government_signature_typecode").ToString()
                        If Convert.IsDBNull(Rdr("signer_given_name")) = False Then _signer_given_name = Rdr("signer_given_name").ToString()
                        If Convert.IsDBNull(Rdr("signer_family_name")) = False Then _signer_family_name = Rdr("signer_family_name").ToString()
                        If Convert.IsDBNull(Rdr("signer_job_title")) = False Then _signer_job_title = Rdr("signer_job_title").ToString()
                        If Convert.IsDBNull(Rdr("signer_ministry_organization_id")) = False Then _signer_ministry_organization_id = Rdr("signer_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("signer_department_organization_id")) = False Then _signer_department_organization_id = Rdr("signer_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("reference_uri")) = False Then _reference_uri = Rdr("reference_uri").ToString()
                        If Convert.IsDBNull(Rdr("reference_digest_value")) = False Then _reference_digest_value = Rdr("reference_digest_value").ToString()
                        If Convert.IsDBNull(Rdr("signature_value")) = False Then _signature_value = Rdr("signature_value").ToString()
                        If Convert.IsDBNull(Rdr("key_value_module")) = False Then _key_value_module = Rdr("key_value_module").ToString()
                        If Convert.IsDBNull(Rdr("key_value_exponent")) = False Then _key_value_exponent = Rdr("key_value_exponent").ToString()
                        If Convert.IsDBNull(Rdr("delete_job_processid")) = False Then _delete_job_processid = Rdr("delete_job_processid").ToString()
                        If Convert.IsDBNull(Rdr("delete_job_processtime")) = False Then _delete_job_processtime = Rdr("delete_job_processtime").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_letterid")) = False Then _receive_notify_letterid = Rdr("receive_notify_letterid").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_correspondence_date")) = False Then _receive_notify_correspondence_date = Rdr("receive_notify_correspondence_date").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_subject")) = False Then _receive_notify_subject = Rdr("receive_notify_subject").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_time")) = False Then _receive_notify_time = Convert.ToDateTime(Rdr("receive_notify_time"))
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


        '/// Returns an indication whether the record of TH_EGIF_DOC_INBOUND by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As ThEgifDocInboundLinq
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
                        If Convert.IsDBNull(Rdr("process_id")) = False Then _process_id = Rdr("process_id").ToString()
                        If Convert.IsDBNull(Rdr("process_time")) = False Then _process_time = Rdr("process_time").ToString()
                        If Convert.IsDBNull(Rdr("body_id")) = False Then _body_id = Rdr("body_id").ToString()
                        If Convert.IsDBNull(Rdr("body_correspondence_date")) = False Then _body_correspondence_date = Rdr("body_correspondence_date").ToString()
                        If Convert.IsDBNull(Rdr("body_subject")) = False Then _body_subject = Rdr("body_subject").ToString()
                        If Convert.IsDBNull(Rdr("body_secret_code")) = False Then _body_secret_code = Rdr("body_secret_code").ToString()
                        If Convert.IsDBNull(Rdr("body_speed_code")) = False Then _body_speed_code = Rdr("body_speed_code").ToString()
                        If Convert.IsDBNull(Rdr("sender_given_name")) = False Then _sender_given_name = Rdr("sender_given_name").ToString()
                        If Convert.IsDBNull(Rdr("sender_family_name")) = False Then _sender_family_name = Rdr("sender_family_name").ToString()
                        If Convert.IsDBNull(Rdr("sender_jobtitle")) = False Then _sender_jobtitle = Rdr("sender_jobtitle").ToString()
                        If Convert.IsDBNull(Rdr("sender_ministry_organization_id")) = False Then _sender_ministry_organization_id = Rdr("sender_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("sender_department_organization_id")) = False Then _sender_department_organization_id = Rdr("sender_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("receiver_given_name")) = False Then _receiver_given_name = Rdr("receiver_given_name").ToString()
                        If Convert.IsDBNull(Rdr("receiver_family_name")) = False Then _receiver_family_name = Rdr("receiver_family_name").ToString()
                        If Convert.IsDBNull(Rdr("receiver_jobtitle")) = False Then _receiver_jobtitle = Rdr("receiver_jobtitle").ToString()
                        If Convert.IsDBNull(Rdr("receiver_ministry_organization_id")) = False Then _receiver_ministry_organization_id = Rdr("receiver_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("receiver_department_organization_id")) = False Then _receiver_department_organization_id = Rdr("receiver_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("attachment")) = False Then _attachment = Rdr("attachment").ToString()
                        If Convert.IsDBNull(Rdr("send_date")) = False Then _send_date = Rdr("send_date").ToString()
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("main_letter_mime")) = False Then _main_letter_mime = Rdr("main_letter_mime").ToString()
                        If Convert.IsDBNull(Rdr("main_letter_database64")) = False Then _main_letter_database64 = Rdr("main_letter_database64").ToString()
                        If Convert.IsDBNull(Rdr("government_signature_typecode")) = False Then _government_signature_typecode = Rdr("government_signature_typecode").ToString()
                        If Convert.IsDBNull(Rdr("signer_given_name")) = False Then _signer_given_name = Rdr("signer_given_name").ToString()
                        If Convert.IsDBNull(Rdr("signer_family_name")) = False Then _signer_family_name = Rdr("signer_family_name").ToString()
                        If Convert.IsDBNull(Rdr("signer_job_title")) = False Then _signer_job_title = Rdr("signer_job_title").ToString()
                        If Convert.IsDBNull(Rdr("signer_ministry_organization_id")) = False Then _signer_ministry_organization_id = Rdr("signer_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("signer_department_organization_id")) = False Then _signer_department_organization_id = Rdr("signer_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("reference_uri")) = False Then _reference_uri = Rdr("reference_uri").ToString()
                        If Convert.IsDBNull(Rdr("reference_digest_value")) = False Then _reference_digest_value = Rdr("reference_digest_value").ToString()
                        If Convert.IsDBNull(Rdr("signature_value")) = False Then _signature_value = Rdr("signature_value").ToString()
                        If Convert.IsDBNull(Rdr("key_value_module")) = False Then _key_value_module = Rdr("key_value_module").ToString()
                        If Convert.IsDBNull(Rdr("key_value_exponent")) = False Then _key_value_exponent = Rdr("key_value_exponent").ToString()
                        If Convert.IsDBNull(Rdr("delete_job_processid")) = False Then _delete_job_processid = Rdr("delete_job_processid").ToString()
                        If Convert.IsDBNull(Rdr("delete_job_processtime")) = False Then _delete_job_processtime = Rdr("delete_job_processtime").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_letterid")) = False Then _receive_notify_letterid = Rdr("receive_notify_letterid").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_correspondence_date")) = False Then _receive_notify_correspondence_date = Rdr("receive_notify_correspondence_date").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_subject")) = False Then _receive_notify_subject = Rdr("receive_notify_subject").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_time")) = False Then _receive_notify_time = Convert.ToDateTime(Rdr("receive_notify_time"))

                        'Generate Item For Child Table
                        'Child Table Name : TH_EGIF_DOC_INBOUND_ATT Column :th_egif_doc_inbound_id
                        Dim ThEgifDocInboundAtt_th_egif_doc_inbound_idItem As New ThEgifDocInboundAttLinq
                        _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id = ThEgifDocInboundAtt_th_egif_doc_inbound_idItem.GetDataList("th_egif_doc_inbound_id = " & _ID, "", Nothing)

                        'Child Table Name : TH_EGIF_DOC_INBOUND_REF Column :th_egif_doc_inbound_id
                        Dim ThEgifDocInboundRef_th_egif_doc_inbound_idItem As New ThEgifDocInboundRefLinq
                        _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id = ThEgifDocInboundRef_th_egif_doc_inbound_idItem.GetDataList("th_egif_doc_inbound_id = " & _ID, "", Nothing)

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


        '/// Returns an indication whether the Class Data of TH_EGIF_DOC_INBOUND by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As ThEgifDocInboundPara
            ClearData()
            _haveData  = False
            Dim ret As New ThEgifDocInboundPara
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
                        If Convert.IsDBNull(Rdr("process_id")) = False Then ret.process_id = Rdr("process_id").ToString()
                        If Convert.IsDBNull(Rdr("process_time")) = False Then ret.process_time = Rdr("process_time").ToString()
                        If Convert.IsDBNull(Rdr("body_id")) = False Then ret.body_id = Rdr("body_id").ToString()
                        If Convert.IsDBNull(Rdr("body_correspondence_date")) = False Then ret.body_correspondence_date = Rdr("body_correspondence_date").ToString()
                        If Convert.IsDBNull(Rdr("body_subject")) = False Then ret.body_subject = Rdr("body_subject").ToString()
                        If Convert.IsDBNull(Rdr("body_secret_code")) = False Then ret.body_secret_code = Rdr("body_secret_code").ToString()
                        If Convert.IsDBNull(Rdr("body_speed_code")) = False Then ret.body_speed_code = Rdr("body_speed_code").ToString()
                        If Convert.IsDBNull(Rdr("sender_given_name")) = False Then ret.sender_given_name = Rdr("sender_given_name").ToString()
                        If Convert.IsDBNull(Rdr("sender_family_name")) = False Then ret.sender_family_name = Rdr("sender_family_name").ToString()
                        If Convert.IsDBNull(Rdr("sender_jobtitle")) = False Then ret.sender_jobtitle = Rdr("sender_jobtitle").ToString()
                        If Convert.IsDBNull(Rdr("sender_ministry_organization_id")) = False Then ret.sender_ministry_organization_id = Rdr("sender_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("sender_department_organization_id")) = False Then ret.sender_department_organization_id = Rdr("sender_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("receiver_given_name")) = False Then ret.receiver_given_name = Rdr("receiver_given_name").ToString()
                        If Convert.IsDBNull(Rdr("receiver_family_name")) = False Then ret.receiver_family_name = Rdr("receiver_family_name").ToString()
                        If Convert.IsDBNull(Rdr("receiver_jobtitle")) = False Then ret.receiver_jobtitle = Rdr("receiver_jobtitle").ToString()
                        If Convert.IsDBNull(Rdr("receiver_ministry_organization_id")) = False Then ret.receiver_ministry_organization_id = Rdr("receiver_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("receiver_department_organization_id")) = False Then ret.receiver_department_organization_id = Rdr("receiver_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("attachment")) = False Then ret.attachment = Rdr("attachment").ToString()
                        If Convert.IsDBNull(Rdr("send_date")) = False Then ret.send_date = Rdr("send_date").ToString()
                        If Convert.IsDBNull(Rdr("description")) = False Then ret.description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("main_letter_mime")) = False Then ret.main_letter_mime = Rdr("main_letter_mime").ToString()
                        If Convert.IsDBNull(Rdr("main_letter_database64")) = False Then ret.main_letter_database64 = Rdr("main_letter_database64").ToString()
                        If Convert.IsDBNull(Rdr("government_signature_typecode")) = False Then ret.government_signature_typecode = Rdr("government_signature_typecode").ToString()
                        If Convert.IsDBNull(Rdr("signer_given_name")) = False Then ret.signer_given_name = Rdr("signer_given_name").ToString()
                        If Convert.IsDBNull(Rdr("signer_family_name")) = False Then ret.signer_family_name = Rdr("signer_family_name").ToString()
                        If Convert.IsDBNull(Rdr("signer_job_title")) = False Then ret.signer_job_title = Rdr("signer_job_title").ToString()
                        If Convert.IsDBNull(Rdr("signer_ministry_organization_id")) = False Then ret.signer_ministry_organization_id = Rdr("signer_ministry_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("signer_department_organization_id")) = False Then ret.signer_department_organization_id = Rdr("signer_department_organization_id").ToString()
                        If Convert.IsDBNull(Rdr("reference_uri")) = False Then ret.reference_uri = Rdr("reference_uri").ToString()
                        If Convert.IsDBNull(Rdr("reference_digest_value")) = False Then ret.reference_digest_value = Rdr("reference_digest_value").ToString()
                        If Convert.IsDBNull(Rdr("signature_value")) = False Then ret.signature_value = Rdr("signature_value").ToString()
                        If Convert.IsDBNull(Rdr("key_value_module")) = False Then ret.key_value_module = Rdr("key_value_module").ToString()
                        If Convert.IsDBNull(Rdr("key_value_exponent")) = False Then ret.key_value_exponent = Rdr("key_value_exponent").ToString()
                        If Convert.IsDBNull(Rdr("delete_job_processid")) = False Then ret.delete_job_processid = Rdr("delete_job_processid").ToString()
                        If Convert.IsDBNull(Rdr("delete_job_processtime")) = False Then ret.delete_job_processtime = Rdr("delete_job_processtime").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_letterid")) = False Then ret.receive_notify_letterid = Rdr("receive_notify_letterid").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_correspondence_date")) = False Then ret.receive_notify_correspondence_date = Rdr("receive_notify_correspondence_date").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_subject")) = False Then ret.receive_notify_subject = Rdr("receive_notify_subject").ToString()
                        If Convert.IsDBNull(Rdr("receive_notify_time")) = False Then ret.receive_notify_time = Convert.ToDateTime(Rdr("receive_notify_time"))

                        'Generate Item For Child Table
                        'Child Table Name : TH_EGIF_DOC_INBOUND_ATT Column :th_egif_doc_inbound_id
                        Dim ThEgifDocInboundAtt_th_egif_doc_inbound_idItem As New ThEgifDocInboundAttLinq
                        _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id = ThEgifDocInboundAtt_th_egif_doc_inbound_idItem.GetDataList("th_egif_doc_inbound_id = " & ret.id, "", Nothing)
                        ret.CHILD_TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id = _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id

                        'Child Table Name : TH_EGIF_DOC_INBOUND_REF Column :th_egif_doc_inbound_id
                        Dim ThEgifDocInboundRef_th_egif_doc_inbound_idItem As New ThEgifDocInboundRefLinq
                        _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id = ThEgifDocInboundRef_th_egif_doc_inbound_idItem.GetDataList("th_egif_doc_inbound_id = " & ret.id, "", Nothing)
                        ret.CHILD_TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id = _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id


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


        'Get Insert Statement for table TH_EGIF_DOC_INBOUND
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, PROCESS_ID, PROCESS_TIME, BODY_ID, BODY_CORRESPONDENCE_DATE, BODY_SUBJECT, BODY_SECRET_CODE, BODY_SPEED_CODE, SENDER_GIVEN_NAME, SENDER_FAMILY_NAME, SENDER_JOBTITLE, SENDER_MINISTRY_ORGANIZATION_ID, SENDER_DEPARTMENT_ORGANIZATION_ID, RECEIVER_GIVEN_NAME, RECEIVER_FAMILY_NAME, RECEIVER_JOBTITLE, RECEIVER_MINISTRY_ORGANIZATION_ID, RECEIVER_DEPARTMENT_ORGANIZATION_ID, ATTACHMENT, SEND_DATE, DESCRIPTION, MAIN_LETTER_MIME, MAIN_LETTER_DATABASE64, GOVERNMENT_SIGNATURE_TYPECODE, SIGNER_GIVEN_NAME, SIGNER_FAMILY_NAME, SIGNER_JOB_TITLE, SIGNER_MINISTRY_ORGANIZATION_ID, SIGNER_DEPARTMENT_ORGANIZATION_ID, REFERENCE_URI, REFERENCE_DIGEST_VALUE, SIGNATURE_VALUE, KEY_VALUE_MODULE, KEY_VALUE_EXPONENT, DELETE_JOB_PROCESSID, DELETE_JOB_PROCESSTIME, RECEIVE_NOTIFY_LETTERID, RECEIVE_NOTIFY_CORRESPONDENCE_DATE, RECEIVE_NOTIFY_SUBJECT, RECEIVE_NOTIFY_TIME)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_PROCESS_ID) & ", "
                sql += DB.SetString(_PROCESS_TIME) & ", "
                sql += DB.SetString(_BODY_ID) & ", "
                sql += DB.SetString(_BODY_CORRESPONDENCE_DATE) & ", "
                sql += DB.SetString(_BODY_SUBJECT) & ", "
                sql += DB.SetString(_BODY_SECRET_CODE) & ", "
                sql += DB.SetString(_BODY_SPEED_CODE) & ", "
                sql += DB.SetString(_SENDER_GIVEN_NAME) & ", "
                sql += DB.SetString(_SENDER_FAMILY_NAME) & ", "
                sql += DB.SetString(_SENDER_JOBTITLE) & ", "
                sql += DB.SetString(_SENDER_MINISTRY_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_SENDER_DEPARTMENT_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_RECEIVER_GIVEN_NAME) & ", "
                sql += DB.SetString(_RECEIVER_FAMILY_NAME) & ", "
                sql += DB.SetString(_RECEIVER_JOBTITLE) & ", "
                sql += DB.SetString(_RECEIVER_MINISTRY_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_RECEIVER_DEPARTMENT_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_ATTACHMENT) & ", "
                sql += DB.SetString(_SEND_DATE) & ", "
                sql += DB.SetString(_DESCRIPTION) & ", "
                sql += DB.SetString(_MAIN_LETTER_MIME) & ", "
                sql += DB.SetString(_MAIN_LETTER_DATABASE64) & ", "
                sql += DB.SetString(_GOVERNMENT_SIGNATURE_TYPECODE) & ", "
                sql += DB.SetString(_SIGNER_GIVEN_NAME) & ", "
                sql += DB.SetString(_SIGNER_FAMILY_NAME) & ", "
                sql += DB.SetString(_SIGNER_JOB_TITLE) & ", "
                sql += DB.SetString(_SIGNER_MINISTRY_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_SIGNER_DEPARTMENT_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_REFERENCE_URI) & ", "
                sql += DB.SetString(_REFERENCE_DIGEST_VALUE) & ", "
                sql += DB.SetString(_SIGNATURE_VALUE) & ", "
                sql += DB.SetString(_KEY_VALUE_MODULE) & ", "
                sql += DB.SetString(_KEY_VALUE_EXPONENT) & ", "
                sql += DB.SetString(_DELETE_JOB_PROCESSID) & ", "
                sql += DB.SetString(_DELETE_JOB_PROCESSTIME) & ", "
                sql += DB.SetString(_RECEIVE_NOTIFY_LETTERID) & ", "
                sql += DB.SetString(_RECEIVE_NOTIFY_CORRESPONDENCE_DATE) & ", "
                sql += DB.SetString(_RECEIVE_NOTIFY_SUBJECT) & ", "
                sql += DB.SetDateTime(_RECEIVE_NOTIFY_TIME)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TH_EGIF_DOC_INBOUND
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "PROCESS_ID = " & DB.SetString(_PROCESS_ID) & ", "
                Sql += "PROCESS_TIME = " & DB.SetString(_PROCESS_TIME) & ", "
                Sql += "BODY_ID = " & DB.SetString(_BODY_ID) & ", "
                Sql += "BODY_CORRESPONDENCE_DATE = " & DB.SetString(_BODY_CORRESPONDENCE_DATE) & ", "
                Sql += "BODY_SUBJECT = " & DB.SetString(_BODY_SUBJECT) & ", "
                Sql += "BODY_SECRET_CODE = " & DB.SetString(_BODY_SECRET_CODE) & ", "
                Sql += "BODY_SPEED_CODE = " & DB.SetString(_BODY_SPEED_CODE) & ", "
                Sql += "SENDER_GIVEN_NAME = " & DB.SetString(_SENDER_GIVEN_NAME) & ", "
                Sql += "SENDER_FAMILY_NAME = " & DB.SetString(_SENDER_FAMILY_NAME) & ", "
                Sql += "SENDER_JOBTITLE = " & DB.SetString(_SENDER_JOBTITLE) & ", "
                Sql += "SENDER_MINISTRY_ORGANIZATION_ID = " & DB.SetString(_SENDER_MINISTRY_ORGANIZATION_ID) & ", "
                Sql += "SENDER_DEPARTMENT_ORGANIZATION_ID = " & DB.SetString(_SENDER_DEPARTMENT_ORGANIZATION_ID) & ", "
                Sql += "RECEIVER_GIVEN_NAME = " & DB.SetString(_RECEIVER_GIVEN_NAME) & ", "
                Sql += "RECEIVER_FAMILY_NAME = " & DB.SetString(_RECEIVER_FAMILY_NAME) & ", "
                Sql += "RECEIVER_JOBTITLE = " & DB.SetString(_RECEIVER_JOBTITLE) & ", "
                Sql += "RECEIVER_MINISTRY_ORGANIZATION_ID = " & DB.SetString(_RECEIVER_MINISTRY_ORGANIZATION_ID) & ", "
                Sql += "RECEIVER_DEPARTMENT_ORGANIZATION_ID = " & DB.SetString(_RECEIVER_DEPARTMENT_ORGANIZATION_ID) & ", "
                Sql += "ATTACHMENT = " & DB.SetString(_ATTACHMENT) & ", "
                Sql += "SEND_DATE = " & DB.SetString(_SEND_DATE) & ", "
                Sql += "DESCRIPTION = " & DB.SetString(_DESCRIPTION) & ", "
                Sql += "MAIN_LETTER_MIME = " & DB.SetString(_MAIN_LETTER_MIME) & ", "
                Sql += "MAIN_LETTER_DATABASE64 = " & DB.SetString(_MAIN_LETTER_DATABASE64) & ", "
                Sql += "GOVERNMENT_SIGNATURE_TYPECODE = " & DB.SetString(_GOVERNMENT_SIGNATURE_TYPECODE) & ", "
                Sql += "SIGNER_GIVEN_NAME = " & DB.SetString(_SIGNER_GIVEN_NAME) & ", "
                Sql += "SIGNER_FAMILY_NAME = " & DB.SetString(_SIGNER_FAMILY_NAME) & ", "
                Sql += "SIGNER_JOB_TITLE = " & DB.SetString(_SIGNER_JOB_TITLE) & ", "
                Sql += "SIGNER_MINISTRY_ORGANIZATION_ID = " & DB.SetString(_SIGNER_MINISTRY_ORGANIZATION_ID) & ", "
                Sql += "SIGNER_DEPARTMENT_ORGANIZATION_ID = " & DB.SetString(_SIGNER_DEPARTMENT_ORGANIZATION_ID) & ", "
                Sql += "REFERENCE_URI = " & DB.SetString(_REFERENCE_URI) & ", "
                Sql += "REFERENCE_DIGEST_VALUE = " & DB.SetString(_REFERENCE_DIGEST_VALUE) & ", "
                Sql += "SIGNATURE_VALUE = " & DB.SetString(_SIGNATURE_VALUE) & ", "
                Sql += "KEY_VALUE_MODULE = " & DB.SetString(_KEY_VALUE_MODULE) & ", "
                Sql += "KEY_VALUE_EXPONENT = " & DB.SetString(_KEY_VALUE_EXPONENT) & ", "
                Sql += "DELETE_JOB_PROCESSID = " & DB.SetString(_DELETE_JOB_PROCESSID) & ", "
                Sql += "DELETE_JOB_PROCESSTIME = " & DB.SetString(_DELETE_JOB_PROCESSTIME) & ", "
                Sql += "RECEIVE_NOTIFY_LETTERID = " & DB.SetString(_RECEIVE_NOTIFY_LETTERID) & ", "
                Sql += "RECEIVE_NOTIFY_CORRESPONDENCE_DATE = " & DB.SetString(_RECEIVE_NOTIFY_CORRESPONDENCE_DATE) & ", "
                Sql += "RECEIVE_NOTIFY_SUBJECT = " & DB.SetString(_RECEIVE_NOTIFY_SUBJECT) & ", "
                Sql += "RECEIVE_NOTIFY_TIME = " & DB.SetDateTime(_RECEIVE_NOTIFY_TIME) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TH_EGIF_DOC_INBOUND
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TH_EGIF_DOC_INBOUND
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id As DataTable
       Dim _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id As DataTable

       Public Property CHILD_TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id() As DataTable
           Get
               Return _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id
           End Get
           Set(ByVal value As DataTable)
               _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id = value
           End Set
       End Property
       Public Property CHILD_TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id() As DataTable
           Get
               Return _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id
           End Get
           Set(ByVal value As DataTable)
               _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id = value
           End Set
       End Property
    End Class
End Namespace
