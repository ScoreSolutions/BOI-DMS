﻿Namespace Common.Utilities
    Public Class Constant
        Public Const CultureSessionID = "Culture"
        Public Const ApplicationErrorSessionID = "ErrorMessage"
        Public Const IntFormat = "#,##0"
        Public Const DoubleFormat = "#,##0.00"
        Public Const DateFormat = "dd/MM/yyyy"
        Public Const UserProfileSession = "UserProfile"
        Public Const UserMenuListSession = "MenuList"
        Public Const SessSendList As String = "SessSendList"
        Public Const SessFileUploadList As String = "SessFileUploadList"
        Public Const SessSearchCondition As String = "SessSearchCondition"
        Public Const SessCompanyListFromBCM As String = "SessCompanyListFromBCM"

        Public Shared ReadOnly Property HomeFolder() As String
            Get
                Return System.Web.HttpContext.Current.Request.ApplicationPath & "/"
            End Get
        End Property
        Public ReadOnly Property ImageFolder() As String
            Get
                Return HomeFolder & "Images/"
            End Get
        End Property
        Partial Public Class CultureName
            Public Const Defaults As String = "th-TH"
            Public Const Eng As String = "en-US"
            Public Const Thai As String = "th-TH"
        End Class
        Partial Public Class DocumentRegister
            Partial Public Class BookRunningType
                Public Const FromCompany As Int16 = 1         'ลงรับจากภายนอก และส่งภายใน
                Public Const FromRequest As Int16 = 2           ' เลขที่คำขอ
                Public Const FromOtherSystem As Int16 = 3       'ลงรับจากระบบอื่น
                Public Const SendInternal As Int16 = 4      ' ลงรับที่มาจากภายใน และส่งภายใน
                Public Const SendExternal As Int16 = 5      ' เลขส่งออกภายนอก
            End Class
            Partial Public Class DocStatusID
                Public Const JobIncome As Int16 = 2
                Public Const JobRemain As Int16 = 1
                Public Const JobClose As Int16 = 3
            End Class
        End Class
        Partial Public Class DocumentIntReceiver
            Partial Public Class ReceiveStatusID
                Public Const SendNoReceive As Integer = 1  'ส่งภายในสำนักงาน ยังไม่รับ
                Public Const Received As Integer = 2  'ลงรับภายใน
                Public Const SendBack As Integer = 3  'ลงรับภายใน แล้วตีกลับ
                Public Const SendBackSystem As Integer = 4   'ตีกลับโดยระบบ
                Public Const Retrieve As Integer = 5   'ดึงกลับ โดยต้นทาง
            End Class
        End Class
        Partial Public Class DocumentScanJob
            Partial Public Class StartStatus
                Public Const StartProgram As Integer = 1
                Public Const ProgramStarted As Integer = 2
                Public Const ProgramClosed As Integer = 3
            End Class
            Partial Public Class AttachStatus
                Public Const WaitSave As Integer = 1
                Public Const SaveComplete As Integer = 2
            End Class
        End Class
        Partial Public Class RoleID
            Public Const RoleSystemAdmin As Long = 1
            Public Const RoleAdministration As Long = 2
            Public Const RoleStaff As Long = 3
        End Class
        Partial Public Class DocObjective
            Public Const OjbKnow As Long = 1
            Public Const ObjApprove As Long = 2
        End Class

        Partial Public Class ElecDocStatus
            Public Const cfg_docstart As String = "0" 'รออนุมัติ
            Public Const cfg_docrunning As String = "1" 'ยังไม่ได้ส่ง
            Public Const cfg_docissend As String = "2" 'ส่งแล้ว
            Public Const cfg_docapproved As String = "3" 'อนุมัติ
            Public Const cfg_docnoapprove As String = "4" 'ไม่อนุมัติ
            Public Const cfg_docnoapproveedit As String = "5" 'แก้ไขยังไม่ส่ง
            Public Const cfg_docnoapprovesend As String = "6" 'แก้ไขส่งแล้ว
            Public Const cfg_docnoapprovecancel As String = "7" 'ไม่อนุมัติยกเลิก
            Public Const cfg_doccancel As String = "8" 'ยกเลิก
            Public Const cfg_docclosejob As String = "9" 'จบงาน
        End Class

        Partial Public Class CompanySourceType
            Public Const DMS As String = "DMS"
            Public Const BOICENTRAL As String = "BOIDB"
            Public Const BCD As String = "BCD"
        End Class
        Public Shared Function GetFullDate() As String
            Dim month As String = ""
            Select Case DateTime.Now.Month
                Case 1
                    month = "January"
                Case 2
                    month = "Febuary"
                Case 3
                    month = "March"
                Case 4
                    month = "April"
                Case 5
                    month = "May"
                Case 6
                    month = "June"
                Case 7
                    month = "July"
                Case 8
                    month = "August"
                Case 9
                    month = "September"
                Case 10
                    month = "October"
                Case 11
                    month = "November"
                Case 12
                    month = "December"
            End Select
            Return month & ", " & DateTime.Now.Day.ToString() & " " & DateTime.Now.Year.ToString()
        End Function
    End Class

End Namespace

