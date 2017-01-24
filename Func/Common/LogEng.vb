Imports Engine.Common
Imports Para.Common
Imports Linq.TABLE
Imports Para.TABLE
Imports System.Web

Namespace Common
    Public Class LogEng
        Dim _LOGIN_HISTORY_ID As Long
        Dim _err As String = ""

        Public ReadOnly Property LOGIN_HISTORY_ID() As Long
            Get
                Return _LOGIN_HISTORY_ID
            End Get
        End Property
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        'Public Sub SaveLoginHistory(ByVal uPara As UserProfilePara, ByVal req As HttpRequest)
        '    Dim trans As New Linq.Common.Utilities.TransactionDB
        '    trans.CreateTransaction()

        '    Try
        '        Dim lnq As New LoginHistoryLinq
        '        lnq.USERNAME = uPara.UserName
        '        lnq.IDCARD_NO = uPara.UserIDCardNo
        '        lnq.STAFF_NAME = uPara.FirstName & " " & uPara.LastName
        '        lnq.STAFF_POSNAME = uPara.PostionName
        '        lnq.STAFF_DIVISION_NAME = uPara.DivisionName
        '        lnq.STAFF_DEPARTMENT_NAME = uPara.DepartmentName
        '        lnq.LOGIN_TIME = DateTime.Now
        '        lnq.IS_SSO = uPara.IS_SSO

        '        Dim browser As String = " Type:" + req.Browser.Type + " Version:" + req.Browser.Version + " Browser:" + req.Browser.Browser
        '        lnq.IP_ADDRESS = req.UserHostAddress 'Get Client IP ADDRESS
        '        lnq.BROWSER = browser
        '        lnq.SESSION_ID = HttpContext.Current.Session.SessionID

        '        Dim ret As Boolean = lnq.InsertData(lnq.USERNAME, trans.Trans)
        '        If ret = True Then
        '            _LOGIN_HISTORY_ID = lnq.ID
        '            trans.CommitTransaction()
        '        Else
        '            _err = lnq.ErrorMessage
        '            trans.RollbackTransaction()
        '        End If
        '        lnq = Nothing
        '    Catch ex As Exception
        '        _err = ex.Message
        '        trans.RollbackTransaction()
        '    End Try
        'End Sub

        Public Sub SaveLoginHistory(ByVal UserName As String, ByVal req As HttpRequest)
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Try
                Dim cEng As New Engine.Master.OfficerEng
                Dim cPara As New Para.TABLE.OfficerPara
                cPara = cEng.GetOfficerParaByUserName(UserName)

                Dim lnq As New LoginHistoryLinq
                lnq.USERNAME = cPara.USERNAME
                lnq.IDCARD_NO = cPara.IDENTITY_CARD
                lnq.STAFF_NAME = cPara.FIRST_NAME & " " & cPara.LAST_NAME
                lnq.STAFF_POSNAME = cPara.DESCRIPTION

                Dim engO As New Engine.Master.OrganizationEng
                Dim oPara As New Para.TABLE.OrganizationPara
                oPara = engO.GetOrgPara(cPara.ORGANIZATION_ID, trans)

                lnq.STAFF_DIVISION_NAME = oPara.ORG_NAME
                lnq.STAFF_DEPARTMENT_NAME = oPara.ORG_NAME
                lnq.LOGIN_TIME = DateTime.Now
                lnq.IS_SSO = "Y"

                Dim browser As String = " Type:" + req.Browser.Type + " Version:" + req.Browser.Version + " Browser:" + req.Browser.Browser
                lnq.IP_ADDRESS = req.UserHostAddress 'Get Client IP ADDRESS
                lnq.BROWSER = browser
                lnq.SESSION_ID = HttpContext.Current.Session.SessionID

                Dim ret As Boolean = lnq.InsertData(lnq.USERNAME, trans.Trans)
                If ret = True Then
                    _LOGIN_HISTORY_ID = lnq.ID
                    trans.CommitTransaction()
                Else
                    _err = lnq.ErrorMessage
                    trans.RollbackTransaction()
                End If
                lnq = Nothing
                oPara = Nothing
                engO = Nothing
                cEng = Nothing
                cPara = Nothing
            Catch ex As Exception
                _err = ex.Message
                trans.RollbackTransaction()
            End Try
        End Sub

        Public Function SaveTransLog(ByVal UserName As String, ByVal para As LogTransPara, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New LogTransLinq
                lnq.LOGIN_HIS_ID = para.LOGIN_HIS_ID
                lnq.TRANS_DATE = DateTime.Now
                lnq.TRANS_DESC = para.TRANS_DESC
                ret = lnq.InsertData(UserName, trans.Trans)
                If ret = False Then
                    _err = lnq.ErrorMessage
                End If
                lnq = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
            Catch ex As Exception
                ret = False
                _err = ex.Message
            End Try

            Return ret
        End Function

        Public Function SaveTransLog(ByVal UserName As String, ByVal LogMsg As String) As Boolean
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lPara As New Para.TABLE.LogTransPara
            lPara.TRANS_DATE = DateTime.Now
            lPara.TRANS_DESC = LogMsg

            If SaveTransLog(UserName, lPara, trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lPara = Nothing
        End Function

        Public Function SaveErrLog(ByVal UserName As String, ByVal ErrMessage As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New LogErrorLinq
                lnq.LOGIN_HIS_ID = 0
                lnq.ERROR_TIME = DateTime.Now
                lnq.ERROR_DESC = ErrMessage
                ret = lnq.InsertData(UserName, trans.Trans)
                If ret = False Then
                    CreateLogFile(ErrMessage)
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
                _err = ex.Message
                CreateLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        
        Public Function SaveErrLog(ByVal UserName As String, ByVal ErrMessage As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Try
                
                ret = SaveErrLog(UserName, ErrMessage, trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    CreateLogFile(ErrMessage)
                End If
            Catch ex As Exception
                ret = False
                _err = ex.Message
                trans.RollbackTransaction()
                CreateLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        Public Function SaveErrLog(ByVal UserName As String, ByVal LoginHisID As Long, ByVal ErrMessage As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Try
                ret = SaveErrLog(UserName, ErrMessage, LoginHisID, trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    CreateLogFile(ErrMessage)
                End If
            Catch ex As Exception
                ret = False
                _err = ex.Message
                trans.RollbackTransaction()
                CreateLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        Public Function SaveErrLog(ByVal UserName As String, ByVal LoginHisID As Long, ByVal ErrMessage As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New LogErrorLinq
                lnq.LOGIN_HIS_ID = LoginHisID
                lnq.ERROR_TIME = DateTime.Now
                lnq.ERROR_DESC = ErrMessage
                ret = lnq.InsertData(UserName, trans.Trans)
                If ret = False Then
                    CreateLogFile(ErrMessage)
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
                _err = ex.Message
                CreateLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        Public Function SaveErrLog(ByVal UserName As String, ByVal para As LogErrorPara, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False

            Try
                Dim lnq As New LogErrorLinq
                lnq.LOGIN_HIS_ID = para.LOGIN_HIS_ID
                lnq.ERROR_TIME = DateTime.Now
                lnq.ERROR_DESC = para.ERROR_DESC
                ret = lnq.InsertData(UserName, trans.Trans)
                If ret = False Then
                    CreateLogFile(para.ERROR_DESC)
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
                _err = ex.Message
                CreateLogFile(para.ERROR_DESC)
            End Try

            Return ret
        End Function

        Public Function SaveErrLog(ByVal UserName As String, ByVal para As LogErrorPara) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Try
                Dim lnq As New LogErrorLinq
                lnq.LOGIN_HIS_ID = para.LOGIN_HIS_ID
                lnq.ERROR_TIME = DateTime.Now
                lnq.ERROR_DESC = para.ERROR_DESC
                ret = lnq.InsertData(UserName, trans.Trans)
                lnq = Nothing
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    CreateLogFile(para.ERROR_DESC)
                End If
            Catch ex As Exception
                ret = False
                _err = ex.Message
                trans.RollbackTransaction()
                CreateLogFile(para.ERROR_DESC)
            End Try

            Return ret
        End Function


        Private Sub CreateLogFile(ByVal TxtLog As String)
            Dim LogFolder As String = "C:\BOI_DMS_LOG\" & DateTime.Now.ToString("yyyyMM") & "\"
            If IO.Directory.Exists(LogFolder) = False Then
                IO.Directory.CreateDirectory(LogFolder)
            End If

            Dim FileName As String = "ErrorLog_" & DateTime.Now.ToString("yyyyMMdd_HH_mm_ss_fff") & ".log"
            Dim objWriter As New System.IO.StreamWriter(LogFolder & FileName, True)
            objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & vbNewLine & TxtLog & vbNewLine)
            objWriter.Close()
        End Sub

        Public Sub SetLogoutTime(ByVal LoginHisID As Long)
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Try
                Dim lnq As New LoginHistoryLinq
                lnq.GetDataByPK(LoginHisID, trans.Trans)
                If lnq.ID <> 0 Then
                    lnq.LOGOUT_TIME = DateTime.Now
                    Dim ret As Boolean = lnq.UpdateByPK(lnq.USERNAME, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        _err = lnq.ErrorMessage
                        trans.RollbackTransaction()
                    End If
                Else
                    _err = lnq.ErrorMessage
                    trans.RollbackTransaction()
                End If
                lnq = Nothing
            Catch ex As Exception
                _err = ex.Message
                trans.RollbackTransaction()
            End Try
        End Sub
    End Class

End Namespace