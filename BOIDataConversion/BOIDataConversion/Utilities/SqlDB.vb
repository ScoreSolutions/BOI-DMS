Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace Utilities

    Public Class SqlDB
        
        Shared _err As String
        Public Shared ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property


        Public Shared Function SetDouble(ByVal number As Double) As String
            Dim ret As String
            If Convert.IsDBNull(number) Then
                ret = "NULL"
            Else
                ret = number.ToString()
            End If
            Return ret
        End Function
        Public Shared Function SetDecimal(ByVal number As Decimal) As String
            Dim ret As String
            If Convert.IsDBNull(number) Then
                ret = "NULL"
            Else
                ret = number.ToString()
            End If
            Return ret
        End Function
        Public Shared Function SetString(ByVal str As String) As String
            Dim ret As String = ""
            If str Is Nothing Or str.Trim() = "" Then
                ret = "NULL"
            Else
                ret = Chr(39) & str.Trim().Replace("'", "''") & Chr(39)
            End If
            Return ret
        End Function
        Public Shared Function SetDate() As String
            Return SetDateTime(DateTime.Today)
        End Function
        Public Function SetDate(ByVal DateIn As DateTime) As String
            Return SetDateTime(DateIn)
        End Function
        Public Shared Function SetDateTime() As String
            Return SetDateTime(DateTime.Today)
        End Function
        Public Shared Function sqldate(ByVal DateIn As DateTime) As String

            Dim arr() As String = DateIn.ToString("MM/dd/yyyy").Split("/")
            If (CInt(arr(2)) > 2500) Then
                arr(2) = CStr(CInt(arr(2)) - 543)
            End If
            Return arr(0) + "/" + arr(1) + "/" + arr(2)
        End Function
        Public Shared Function SetDateTime(ByVal DateIn As DateTime) As String
            Dim ret As String = ""
            If DateIn.Year = 1 Or Convert.IsDBNull(DateIn) Then
                ret = "NULL"
            ElseIf DateIn.Year > 2500 Then
                Dim vYear As String = DateIn.Year - 543
                ret = "'" & vYear & "-" & DateIn.ToString("MM-dd HH:mm:ss") & "'"
            Else
                ret = "'" & DateIn.Year & "-" & DateIn.ToString("MM-dd HH:mm:ss") & "'"
            End If
            Return ret
        End Function

        Private Shared ReadOnly Property INIFileName() As IniReader
            Get
                'Application.StartupPath = C:\Program Files\Common Files\Microsoft Shared\DevServer\9.0
                Dim INIFlie As String = Application.StartupPath() & "\BOI-Convert.ini"
                Dim ini As New IniReader(INIFlie)
                Return ini
            End Get
        End Property

        Private Shared ini As IniReader = INIFileName

#Region "OLD DB Connection"
        Public Shared ReadOnly Property OldDataSource() As String
            Get
                ini.Section = "OLD_DB_Setting"
                Return ini.ReadString("ServerName").ToString
            End Get
        End Property
        Public Shared ReadOnly Property OldDbName()
            Get
                ini.Section = "OLD_DB_Setting"
                Return ini.ReadString("DbName").ToString
            End Get
        End Property
        Public Shared ReadOnly Property OldDbUserID() As String
            Get
                ini.Section = "OLD_DB_Setting"
                Return ini.ReadString("DbUserID").ToString
            End Get
        End Property
        Public Shared ReadOnly Property OldDbPwd() As String
            Get
                ini.Section = "OLD_DB_Setting"
                Return ini.ReadString("DbPwd").ToString
            End Get
        End Property

        Protected Shared ReadOnly Property OldConnectionString() As String
            Get
                Try
                    Dim s As String = "Data Source=" & OldDataSource() & ";Initial Catalog=" & OldDbName() & ";User ID=" & OldDbUserID() & ";Password=" & OldDbPwd()
                    Return s
                Catch ex As Exception
                    _err = ex.Message
                End Try
            End Get
        End Property


        Public Shared Function GetOldConnection() As SqlConnection

            '#check
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(OldConnectionString)
                conn.Open()
                Return conn
            Catch ex As ApplicationException
                'Throw ex
                _err = ex.Message
            Catch ex As SqlException
                'Throw New ApplicationException(ErrorConnection, ex)
                _err = ex.Message
            Catch ex As Exception
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
            End Try
        End Function

#End Region

#Region "NEW DB Connection"
        Public Shared ReadOnly Property NewDataSource() As String
            Get
                ini.Section = "NEW_DB_Setting"
                Return ini.ReadString("ServerName").ToString
            End Get
        End Property
        Public Shared ReadOnly Property NewDbName()
            Get
                ini.Section = "NEW_DB_Setting"
                Return ini.ReadString("DbName").ToString
            End Get
        End Property
        Public Shared ReadOnly Property NewDbUserID() As String
            Get
                ini.Section = "NEW_DB_Setting"
                Return ini.ReadString("DbUserID").ToString
            End Get
        End Property
        Public Shared ReadOnly Property NewDbPwd() As String
            Get
                ini.Section = "NEW_DB_Setting"
                Return ini.ReadString("DbPwd").ToString
            End Get
        End Property

        Protected Shared ReadOnly Property NewConnectionString() As String
            Get
                Try
                    Dim s As String = "Data Source=" & NewDataSource() & ";Initial Catalog=" & NewDbName() & ";User ID=" & NewDbUserID() & ";Password=" & NewDbPwd()
                    Return s
                Catch ex As Exception
                    _err = ex.Message
                End Try
            End Get
        End Property


        Public Shared Function GetNewConnection() As SqlConnection
            '#check
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(NewConnectionString)
                conn.Open()
                Return conn
            Catch ex As ApplicationException
                'Throw ex
                _err = ex.Message
            Catch ex As SqlException
                'Throw New ApplicationException(ErrorConnection, ex)
                _err = ex.Message
            Catch ex As Exception
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
            End Try
        End Function
#End Region


        Public Shared Function GetNextID(ByVal fldName As String, ByVal tbName As String, ByVal trans As SqlTransaction) As Long
            Dim ret As Long
            Dim Sql As String = "select max(" & fldName & ") maxID from " & tbName
            Dim dt As DataTable = ExecuteTable(Sql, trans)
            If Convert.IsDBNull(dt.Rows(0)("maxID")) = False Then
                ret = Convert.ToInt64(dt.Rows(0)("maxID").ToString()) + 1
            Else
                ret = 1
            End If

            Return ret
        End Function

        Public Shared Function GetDateNow(ByVal rtType As String, ByVal trans As SqlTransaction) As String
            'rtType = D  ให้คืนค่าเป็นวันที่ในรูปแบบ yyyy-MM-dd
            'rtType = T  ให้คืนค่าเป็นเวลาปัจจุบัน hh:mm
            Dim ret As String
            Dim dt As DataTable = ExecuteTable("select convert(varchar(10),getdate(),120) date_now, CONVERT(varchar(5),getdate(),108) time_now", trans)
            If rtType = "D" Then
                ret = dt.Rows(0)("date_now")
            Else
                ret = dt.Rows(0)("time_now")
            End If

            Return ret

        End Function


        Public Shared Function ExecuteTable(ByVal sql As String) As DataTable
            Return ExecuteTable(sql, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal conn As SqlConnection) As DataTable
            Return ExecuteTable(sql, conn, Nothing)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal trans As SqlTransaction) As DataTable
            Return ExecuteTable(sql, Nothing, trans)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As DataTable
            Dim cmd As New SqlCommand
            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = cmd

            Dim dt As New DataTable

            Try
                If trans IsNot Nothing And conn Is Nothing Then
                    conn = trans.Connection
                End If

                BuildCommand(cmd, conn, trans, CommandType.Text, sql, Nothing)
                adapter.Fill(dt)
                adapter.Dispose()
            Catch ex As ApplicationException
                adapter.Dispose()
                'Throw ex
            Catch ex As SqlException
                adapter.Dispose()
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
            Catch ex As Exception
                adapter.Dispose()
                'Throw New ApplicationException(ErrorExecuteTable, ex)
            End Try

            Return dt
        End Function

        Public Shared Function ExecuteReader(ByVal Sql As String) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal trans As SqlTransaction) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, trans)
        End Function

        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection) As SqlDataReader
            Return ExecuteReader(Sql, conn, Nothing)
        End Function

        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SqlDataReader
            Dim command As New SqlCommand()
            Dim reader As SqlDataReader
            Dim LetClose As Boolean = False

            Try
                If trans IsNot Nothing And conn Is Nothing Then
                    conn = trans.Connection
                End If

                BuildCommand(command, conn, trans, CommandType.Text, Sql, Nothing)
                'reader = IIf(LetClose = True, command.ExecuteReader(CommandBehavior.CloseConnection), command.ExecuteReader())
                reader = command.ExecuteReader()
            Catch ex As ApplicationException
                'Throw ex
            Catch ex As SqlException
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
                'Catch ex As Exception
                'Throw New ApplicationException(ErrorExecuteReader, ex)
            End Try

            Return reader
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String) As Integer
            Return ExecuteNonQuery(Sql, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal conn As SqlConnection) As Integer
            Return ExecuteNonQuery(Sql, conn, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction) As Integer
            Return ExecuteNonQuery(Sql, Nothing, trans, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Integer
            Return ExecuteNonQuery(Sql, Nothing, trans, cmdParms)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Integer
            Dim retval As Integer
            Dim command As New SqlCommand

            Try
                If trans IsNot Nothing And conn Is Nothing Then
                    conn = trans.Connection
                End If

                BuildCommand(command, trans.Connection, trans, CommandType.Text, Sql, cmdParms)
                retval = command.ExecuteNonQuery
            Catch ex As ApplicationException
                'Throw ex
                _err = ex.Message
            Catch ex As SqlException
                _err = ex.Message
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
            Catch ex As Exception
                _err = ex.Message
                'Throw New ApplicationException(ErrorExecuteNonQuery, ex)
            End Try

            Return retval
        End Function

        Private Shared Sub BuildCommand(ByVal cmd As SqlCommand, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms() As SqlParameter)
            If conn.State <> ConnectionState.Open Then
                Try
                    conn.Open()
                Catch ex As SqlException
                    'Throw New ApplicationException(GetExceptionMessage(ex), ex)
                Catch ex As ApplicationException
                    'Throw (ex)
                Catch ex As Exception
                    'Throw New ApplicationException(ErrorConnection, ex)
                End Try
            End If

            Try
                cmd.Connection = conn
            Catch ex As Exception
                'Throw New ApplicationException(ErrorSetCommandConnection, ex)
            End Try
            cmd.CommandText = cmdText

            If trans IsNot Nothing Then
                cmd.Transaction = trans
            End If

            Try
                cmd.CommandType = cmdType
                cmd.CommandTimeout = 120
            Catch ex As ArgumentException
                'Throw New ApplicationException(ErrorInvalidCommandType, ex)
            End Try

            If cmdParms IsNot Nothing Then
                For Each parm As SqlParameter In cmdParms

                    Try
                        cmd.Parameters.Add(parm)
                    Catch ex As ArgumentNullException
                        'Throw New ApplicationException(ErrorNullParameter, ex)
                    Catch ex As ArgumentException
                        'Throw New ApplicationException(ErrorDuplicateParameter, ex)
                    End Try
                Next
            End If
        End Sub
    End Class
End Namespace

