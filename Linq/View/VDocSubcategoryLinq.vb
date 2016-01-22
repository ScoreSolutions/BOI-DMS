Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = Linq.Common.Utilities.SQLDB
Imports Para.VIEW
Imports Para.Common.Utilities

Namespace VIEW
    'Represents a transaction for v_doc_subcategory view Linq.
    '[Create by  on July, 26 2011]
    Public Class VDocSubcategoryLinq
        Public sub VDocSubcategoryLinq()

        End Sub 
        ' v_doc_subcategory
        Const _viewName As String = "v_doc_subcategory"

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property ViewName As String
            Get
                Return _viewName
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
        Dim _DOC_CATEGORY_ID As Long = 0
        Dim _CATEGORY_NAME As String = ""
        Dim _SUBCATEGORY_CODE As String = ""
        Dim _SUBCATEGORY_NAME As String = ""
        Dim _ACTIVE As Char = ""
        Dim _ACTIVE_NAME As  String  = ""

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
        <Column(Storage:="_DOC_CATEGORY_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOC_CATEGORY_ID() As Long
            Get
                Return _DOC_CATEGORY_ID
            End Get
            Set(ByVal value As Long)
               _DOC_CATEGORY_ID = value
            End Set
        End Property 
        <Column(Storage:="_CATEGORY_NAME", DbType:="VarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property CATEGORY_NAME() As String
            Get
                Return _CATEGORY_NAME
            End Get
            Set(ByVal value As String)
               _CATEGORY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SUBCATEGORY_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SUBCATEGORY_CODE() As String
            Get
                Return _SUBCATEGORY_CODE
            End Get
            Set(ByVal value As String)
               _SUBCATEGORY_CODE = value
            End Set
        End Property 
        <Column(Storage:="_SUBCATEGORY_NAME", DbType:="VarChar(250) NOT NULL ",CanBeNull:=false)>  _
        Public Property SUBCATEGORY_NAME() As String
            Get
                Return _SUBCATEGORY_NAME
            End Get
            Set(ByVal value As String)
               _SUBCATEGORY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE() As Char
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As Char)
               _ACTIVE = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE_NAME", DbType:="VarChar(9)")>  _
        Public Property ACTIVE_NAME() As  String 
            Get
                Return _ACTIVE_NAME
            End Get
            Set(ByVal value As  String )
               _ACTIVE_NAME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _DOC_CATEGORY_ID = 0
            _CATEGORY_NAME = ""
            _SUBCATEGORY_CODE = ""
            _SUBCATEGORY_NAME = ""
            _ACTIVE = ""
            _ACTIVE_NAME = ""
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


        '/// Returns an indication whether the record of v_doc_subcategory by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the record of v_doc_subcategory by specified condition is retrieved successfully.
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
                     If Convert.IsDBNull(Rdr("doc_category_id")) = False Then _doc_category_id = Convert.ToInt64(Rdr("doc_category_id"))
                     If Convert.IsDBNull(Rdr("category_name")) = False Then _category_name = Rdr("category_name").ToString()
                     If Convert.IsDBNull(Rdr("subcategory_code")) = False Then _subcategory_code = Rdr("subcategory_code").ToString()
                     If Convert.IsDBNull(Rdr("subcategory_name")) = False Then _subcategory_name = Rdr("subcategory_name").ToString()
                     If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                     If Convert.IsDBNull(Rdr("active_name")) = False Then _active_name = Rdr("active_name").ToString()
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


        '/// Returns an indication whether the record of v_doc_subcategory by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As VDocSubcategoryLinq
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
                     If Convert.IsDBNull(Rdr("doc_category_id")) = False Then _doc_category_id = Convert.ToInt64(Rdr("doc_category_id"))
                     If Convert.IsDBNull(Rdr("category_name")) = False Then _category_name = Rdr("category_name").ToString()
                     If Convert.IsDBNull(Rdr("subcategory_code")) = False Then _subcategory_code = Rdr("subcategory_code").ToString()
                     If Convert.IsDBNull(Rdr("subcategory_name")) = False Then _subcategory_name = Rdr("subcategory_name").ToString()
                     If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                     If Convert.IsDBNull(Rdr("active_name")) = False Then _active_name = Rdr("active_name").ToString()

                    'Generate Item For Child Table
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


        '/// Returns an indication whether the Class Data of v_doc_subcategory by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As VDocSubcategoryPara
            ClearData()
            _haveData  = False
            Dim ret As New VDocSubcategoryPara
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                     If Convert.IsDBNull(Rdr("id")) = False Then ret.id = Convert.ToInt64(Rdr("id"))
                     If Convert.IsDBNull(Rdr("doc_category_id")) = False Then ret.doc_category_id = Convert.ToInt64(Rdr("doc_category_id"))
                     If Convert.IsDBNull(Rdr("category_name")) = False Then ret.category_name = Rdr("category_name").ToString()
                     If Convert.IsDBNull(Rdr("subcategory_code")) = False Then ret.subcategory_code = Rdr("subcategory_code").ToString()
                     If Convert.IsDBNull(Rdr("subcategory_name")) = False Then ret.subcategory_name = Rdr("subcategory_name").ToString()
                     If Convert.IsDBNull(Rdr("active")) = False Then ret.active = Rdr("active").ToString()
                     If Convert.IsDBNull(Rdr("active_name")) = False Then ret.active_name = Rdr("active_name").ToString()

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


        'Get Select Statement for table v_doc_subcategory
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & viewName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
