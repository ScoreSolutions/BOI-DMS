Namespace Common
    Public Class FunctionENG

        Public Shared Function GetFileUploadPath() As String
            Dim fldPath As String = System.Configuration.ConfigurationSettings.AppSettings("UploadPath").ToString
            If System.IO.Directory.Exists(fldPath) = False Then
                System.IO.Directory.CreateDirectory(fldPath)
            End If
            Return fldPath
        End Function
        Public Shared Function GetFileUploadURL(ByVal req As System.Web.HttpRequest) As String
            Return "http://" & req.Url.Host & "/" & GetConfigValue("UploadURL").ToString
        End Function

        Public Shared Function GetIPAddress() As String
            Dim oAddr As System.Net.IPAddress
            Dim sAddr As String
            With System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName())
                oAddr = New System.Net.IPAddress(.AddressList(0).Address)
                sAddr = oAddr.ToString
            End With
            GetIPAddress = sAddr
        End Function

        Public Shared Function GetConfigValue(ByVal vConfigName As String) As String
            Dim ret As String = ""
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim lnq As New Linq.TABLE.SysconfigLinq
            If lnq.ChkDataByCONFIG_NAME(vConfigName, Nothing) = True Then
                ret = lnq.CONFIG_VALUE
            End If
            'trans.CommitTransaction()
            lnq = Nothing

            Return ret
        End Function

        Private Shared _err As String = ""
        Public Shared ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public Shared Function ExecuteSQL(ByVal sql As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim dt As New DataTable

            If sql.Trim().StartsWith("select") = True Then
                dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
            Else
                dt.Columns.Add("message")
                Dim dr As DataRow = dt.NewRow
                dr("message") = Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sql, trans.Trans)
                dt.Rows.Add(dr)
            End If

            If Linq.Common.Utilities.SqlDB.ErrorMessage <> "" Then
                _err = Linq.Common.Utilities.SqlDB.ErrorMessage
            End If
            Return dt
        End Function

        Public Shared Function GetThaiNumber(ByVal vNumber As String) As String
            Dim ret As String = ""
            Try
                For i As Integer = 0 To Len(vNumber) - 1
                    'ret += decodeEnNum(Asc(vNumber, i, 1))
                    ret += decodeEnNum(Asc(vNumber.Substring(i, 1)))
                Next
            Catch ex As Exception

            End Try
            Return ret

        End Function


        Private Shared Function decodeEnNum(ByVal vNum As String) As String
            Dim ret As String = ""

            If vNum = Asc("1") Then
                ret = "๑"
            ElseIf vNum = Asc("2") Then
                ret = "๒"
            ElseIf vNum = Asc("3") Then
                ret = "๓"
            ElseIf vNum = Asc("4") Then
                ret = "๔"
            ElseIf vNum = Asc("5") Then
                ret = "๕"
            ElseIf vNum = Asc("6") Then
                ret = "๖"
            ElseIf vNum = Asc("7") Then
                ret = "๗"
            ElseIf vNum = Asc("8") Then
                ret = "๘"
            ElseIf vNum = Asc("9") Then
                ret = "๙"
            ElseIf vNum = Asc("0") Then
                ret = "๐"
            Else
                ret = Chr(vNum)
            End If

            Return ret
        End Function

        Public Shared Function EncryptText(ByVal txt As String) As String
            Return Linq.Common.Utilities.SqlDB.EnCripPwd(txt)
        End Function
    End Class
End Namespace

