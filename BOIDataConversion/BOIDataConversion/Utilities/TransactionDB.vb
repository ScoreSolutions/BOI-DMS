Imports System
Imports System.Data.SqlClient

Namespace Utilities
    Public Class TransactionDB
        Private _error As String = ""
        Private _conn As SqlConnection
        Private _trans As SqlTransaction


        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _error
            End Get
        End Property

        Public ReadOnly Property conn() As SqlConnection
            Get
                Return _conn
            End Get
        End Property

        Public ReadOnly Property Trans() As SqlTransaction
            Get
                Return _trans
            End Get
        End Property

        ' <summary>
        ' Commit the SQL database transaction and close the connection to the database.
        ' </summary>
        ' <returns>Return true when process operation successfully, otherwise false.</returns>
        Public Function CommitTransaction() As Boolean
            Dim ret As Boolean = True
            Try
                If _trans IsNot Nothing Then _trans.Commit()
                If _conn IsNot Nothing Then _conn.Close()

            Catch ex As SqlException
                ret = False
                _error = ex.Message
            Catch
                ret = False
                _error = "errorCommitTransaction"
            End Try

            Return ret
        End Function


        ' <summary>
        ' Rolls back a transaction from a pending state and close the connection to the database.
        ' </summary>
        ' <returns>Return true when process operation successfully, otherwise false.</returns>
        Public Function RollbackTransaction() As Boolean
            Dim ret As Boolean = True
            Try
                If _trans IsNot Nothing Then _trans.Rollback()
                If _conn IsNot Nothing Then _conn.Close()
            Catch ex As SqlException
                ret = False
                _error = ex.Message
            Catch
                ret = False
                _error = "errorRollbackTransaction"
            End Try

            Return ret
        End Function

        Public Function CreateTransaction(ByVal _conn As SqlConnection) As Boolean
            Dim ret As Boolean = True
            Try
                _trans = _conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
            Catch ex As SqlException
                ret = False
                _error = ex.Message
            Catch
                ret = False
                _error = "errorCreateTransaction"
            End Try
        End Function
    End Class
End Namespace
