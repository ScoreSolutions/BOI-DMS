Imports Para.SSO
Namespace SSO
    Public Class SSOLinqWS
        Public Shared Function LogInSSO(ByVal WsURL As String, ByVal UserName As String, ByVal pssWd As String) As SSOUserPara
            Dim ret As New SSOUserPara

            Try
                'สำหรับ Bypass SSL กรณีเรียก WebService ผ่าน https://
                System.Net.ServicePointManager.ServerCertificateValidationCallback = _
                  Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, _
                  chain As System.Security.Cryptography.X509Certificates.X509Chain, _
                  sslerror As System.Net.Security.SslPolicyErrors) True

                Dim ws As New eSSO.sso
                ws.Url = WsURL
                Dim tResult As eSSO.TResultOfUserProfile = ws.SignIn(UserName, pssWd)
                If tResult.ActionCode = "00" Then
                    ret.IsSuccess = True
                    ret.ErrorMessage = ""

                    With tResult.Data
                        ret.UserID = .Userid
                        ret.Username = .Username
                        ret.TitleNameTh = .TitleNameTh
                        ret.FirstName = .Firstname
                        ret.LastName = .Lastname
                        ret.TitleNameEn = .TitleNameEn
                        ret.FirstNameEn = .FirstnameEn
                        ret.LastNameEn = .LastnameEn
                        ret.CardId = .CardId
                    End With
                Else
                    ret.IsSuccess = False
                    ret.ErrorMessage = "SSO Message : " & tResult.ResponseText
                End If
                ws.Dispose()
            Catch ex As Exception
                ret.IsSuccess = False
                ret.ErrorMessage = "Web Exception : " & ex.Message
            End Try
            Return ret
        End Function
    End Class
End Namespace

