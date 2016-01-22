Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports Engine.Logger

Public Class Connection
#Region "Attributes"

    'Private Shared logger As ILogger = LoggerFacatory.GetLogger(GetType(Logger))

#End Region
    Public Sub New()
    End Sub


    Public Function GetConnection() As SqlConnection

        Dim isConnected As Boolean = False
        Dim conStr As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString").ToString()

        'conStr = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()
        'conStr = "Server=NANA-pc;Uid=sa;PASSWORD=P@ssW0rd;database=SALE_MANAGEMENT;Max Pool Size=400;Connect Timeout=600;";
        'conStr = @"Server=MAY-TECHNICAL_S\BIGBIRD;Uid=sa;PASSWORD=1234;database=SALE_MANAGEMENT;Max Pool Size=400;Connect Timeout=600;";
        'conStr = "Server=202.43.34.74;Uid=tararosm;PASSWORD=DHE235YT;database=SALE_MANAGEMENT;Max Pool Size=400;Connect Timeout=600;";

        Dim connection As SqlConnection = Nothing
        Try
            While Not isConnected
                Try
                    connection = New SqlConnection(conStr)
                    connection.Open()
                    If connection.State = ConnectionState.Open Then
                        isConnected = True
                    Else
                        ' If logger.IsErrorEnable() Then
                        'Logger.[Error]("Connection(GetConnection)", [String].Format("Could not established SQL connection,ConnectionString:{0}", conStr))
                        'End If
                        'If Logger.IsDebugEnable() Then
                        'Logger.Debug("Connection(GetConnection)", "Retry connect...")
                        ' End If
                        Thread.Sleep(TimeSpan.FromSeconds(5))
                    End If
                Catch ex As Exception
                    'If logger.IsErrorEnable() Then
                    'Logger.[Error]("Connection(GetConnection)", ex.Message, ex)
                    'End If
                    'If Logger.IsDebugEnable() Then
                    'Logger.Debug("Connection(GetConnection)", "Retry connect...")
                    'End If
                    Thread.Sleep(TimeSpan.FromSeconds(5))
                End Try
            End While
            Return connection
        Catch ex As SqlException
            ' If logger.IsErrorEnable() Then
            'Logger.[Error]("Connection(GetConnection)", ex.Message, ex)
            'End If
            Return Nothing
        End Try
    End Function

End Class
