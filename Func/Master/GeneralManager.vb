Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports Engine.Logger
Imports System.Data.SqlClient
Imports Engine.Connection

Public Class GeneralManager
    ''' <summary>
    ''' Current SQL connection.
    ''' </summary>
    Private m_connection As Connection
    ' Dim condb As New Connection

    ''' <summary>
    ''' Logger instance.
    ''' </summary>
    'Private Shared logger As ILogger = LoggerFacatory.GetLogger(GetType(Logger))

#Region "Constructor"
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="connection">Connection contain SQL database connection.</param>
    Public Sub New(ByVal connection As SqlConnection)

    End Sub
#End Region

#Region "GetByPage"

    Public Function GetByPage(ByVal pageSize As String, ByVal currentPage As String, ByVal srcTable As String, ByVal whereCause As String, ByVal primaryKey As String, ByVal orderBy As String, _
     ByRef totalPage As Integer) As DataSet


        Dim sqlCon As SqlConnection = m_connection.GetConnection
        If sqlCon Is Nothing Then
            'If logger.IsErrorEnable() Then
            'Logger.[Error]("GeneralManager(GetByPage)", "Could not established SQL connection.")
            'End If
            Return Nothing
        End If
        Dim gen As New General(sqlCon)
        Try
            Return gen.GetByPaging(pageSize, currentPage, srcTable, whereCause, primaryKey, orderBy, _
             totalPage)
        Catch ex As Exception
            'If Logger.IsErrorEnable() Then
            'logger.[Error]("GeneralManager(GetByPage)", ex.Message, ex)
            'End If
            Return Nothing
        Finally
            gen.Dispose()
            sqlCon.Close()
            sqlCon.Dispose()
        End Try
    End Function
#End Region

End Class

