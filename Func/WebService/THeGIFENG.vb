Imports System.Data
Imports LinqWS.THeGIF.RequestTHeGIFLinqWS
Imports Linq.TABLE
Imports Para.THeGIF
Imports Engine.Common

Namespace WebService
    Public Class THeGIFENG
        Public Shared Sub GetNewInbound(ByVal LoginName As String)
            For i As Integer = 0 To 19
                Dim inb As New Para.THeGIFResponse.CorrespondenceLetterInboundResponsePara
                SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")
                inb = CorrespondenceLetterInboundRequest("", "")
                If inb.ProcessID.Trim <> "" Then
                    Dim lnq As New ThEgifDocInboundLinq
                    lnq.PROCESS_ID = inb.ProcessID
                    lnq.PROCESS_TIME = inb.ProcessTime
                    With inb.GovernmentDocument
                        lnq.BODY_ID = .BodyID
                        lnq.BODY_CORRESPONDENCE_DATE = .BodyCorrespondenceDate
                        lnq.BODY_SUBJECT = .BodySubject
                        lnq.BODY_SECRET_CODE = .BodySecretCode
                        lnq.BODY_SPEED_CODE = .BodySpeedCode
                        lnq.SENDER_GIVEN_NAME = .SenderPartyGivenName
                        lnq.SENDER_FAMILY_NAME = .SenderPartyFamilyName
                        lnq.SENDER_JOBTITLE = .SenderPartyJobTitle
                        lnq.SENDER_MINISTRY_ORGANIZATION_ID = .SenderPartyMinistryOrganizationID
                        lnq.SENDER_DEPARTMENT_ORGANIZATION_ID = .SenderPartyDepartmentOrganizationID
                        lnq.RECEIVER_GIVEN_NAME = .ReceiverPartyGivenName
                        lnq.RECEIVER_FAMILY_NAME = .ReceiverPartyFamilyName
                        lnq.RECEIVER_JOBTITLE = .ReceiverPartyJobTitle
                        lnq.RECEIVER_MINISTRY_ORGANIZATION_ID = .ReceiverPartyMinistryOrganizationID
                        lnq.RECEIVER_DEPARTMENT_ORGANIZATION_ID = .ReceiverPartyDepartmentOrganizationID
                        lnq.ATTACHMENT = .Attachment
                        lnq.SEND_DATE = .SendDate
                        lnq.DESCRIPTION = .Description
                        lnq.MAIN_LETTER_MIME = .MainLetterBinaryObjectMime
                        lnq.MAIN_LETTER_DATABASE64 = .MainLetterBinaryObjectDataBase64
                        lnq.GOVERNMENT_SIGNATURE_TYPECODE = .GovernmentSignatureTypeCode
                        lnq.SIGNER_GIVEN_NAME = .SignerPartyGivenName
                        lnq.SIGNER_FAMILY_NAME = .SignerPartyFamilyName
                        lnq.SIGNER_JOB_TITLE = .SignerPartyJobTitle
                        lnq.SIGNER_MINISTRY_ORGANIZATION_ID = .SignerPartyMinistryOrganizationID
                        lnq.SIGNER_DEPARTMENT_ORGANIZATION_ID = .SignerPartyDepartmentOrganizationID
                        lnq.REFERENCE_URI = .ReferenceURI
                        lnq.REFERENCE_DIGEST_VALUE = .ReferenceDigestValue
                        lnq.SIGNATURE_VALUE = .SignatureValue
                        lnq.KEY_VALUE_MODULE = .KeyValueModule
                        lnq.KEY_VALUE_EXPONENT = .KeyValueExponent
                    End With

                    Dim trans As New Linq.Common.Utilities.TransactionDB
                    trans.CreateTransaction()
                    Dim ret As Boolean = lnq.InsertData(LoginName, trans.Trans)
                    If ret = True Then
                        If SaveNewReferenceDoc(LoginName, lnq.ID, inb.GovernmentDocument.ReferenceCorrespondence, trans) = True Then
                            If SaveNewAttach(LoginName, lnq.ID, inb.GovernmentDocument.AttachmentBinaryObject, trans) = True Then
                                'trans.CommitTransaction()
                                If DeleteRequestLetter(LoginName, lnq.PROCESS_ID, lnq, trans) = True Then
                                    trans.CommitTransaction()
                                Else
                                    trans.RollbackTransaction()
                                End If
                            Else
                                trans.RollbackTransaction()
                            End If
                        Else
                            trans.RollbackTransaction()
                        End If
                    Else
                        trans.RollbackTransaction()
                    End If
                    lnq = Nothing
                End If
                inb = Nothing
            Next
        End Sub

        Private Shared Function DeleteRequestLetter(ByVal LoginName As String, ByVal ProcessID As String, ByVal lnq As ThEgifDocInboundLinq, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Dim p As New Para.THeGIF.CorrespondenceLetterDeleteRequestPara
            p.BodyProcessID = ProcessID
            SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")

            Dim res As Para.THeGIFResponse.CorrespondenceLetterDeleteResponsePara
            res = CorrespondenceLetterDeleteRequest(p)
            If res.ProcessID.Trim <> "" Then
                If lnq.ID <> 0 Then
                    lnq.DELETE_JOB_PROCESSID = res.ProcessID
                    lnq.DELETE_JOB_PROCESSTIME = res.ProcessTime

                    ret = lnq.UpdateByPK(LoginName, trans.Trans)
                End If
                lnq = Nothing
            End If
            res = Nothing
            p = Nothing

            Return ret
        End Function

        Public Shared Function SendAcceiptLetterNotifier(ByVal p As Para.THeGIF.SendAcceiptLetterNotifierPara) As Boolean
            Dim ret As Boolean = False
            ret = LinqWS.THeGIF.RequestTHeGIFLinqWS.SendAcceiptLetterNotifier(p).ProcessID <> ""
            Return ret
        End Function

        Private Shared Function SaveNewAttach(ByVal LoginName As String, ByVal vID As Long, ByVal dt As DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = True
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim lnq As New ThEgifDocInboundAttLinq
                    lnq.TH_EGIF_DOC_INBOUND_ID = vID
                    If Convert.IsDBNull(dr("AttachmentBinaryObjectMime")) = False Then lnq.MIME_CODE = dr("AttachmentBinaryObjectMime").ToString
                    If Convert.IsDBNull(dr("AttachmentBinaryObject")) = False Then lnq.BASE64DATA = dr("AttachmentBinaryObject").ToString

                    ret = lnq.InsertData(LoginName, trans.Trans)
                    lnq = Nothing
                    If ret = False Then
                        Exit For
                    End If
                Next
            End If

            Return ret
        End Function

        Private Shared Function SaveNewReferenceDoc(ByVal LoginName As String, ByVal vID As Long, ByVal dt As DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = True

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim lnq As New ThEgifDocInboundRefLinq
                    lnq.TH_EGIF_DOC_INBOUND_ID = vID
                    If Convert.IsDBNull(dr("ReferenceCorrespondenceID")) = False Then lnq.REFERENCECORRESPONDENCE_ID = dr("ReferenceCorrespondenceID").ToString
                    If Convert.IsDBNull(dr("CorrespondenceDate")) = False Then lnq.REFERENCECORRESPONDENCE_DATE = dr("CorrespondenceDate").ToString
                    If Convert.IsDBNull(dr("ReferenceCorrespondenceSubject")) = False Then lnq.REFERENCECORRESPONDENCE_SUBJECT = dr("ReferenceCorrespondenceSubject").ToString

                    ret = lnq.InsertData(LoginName, trans.Trans)
                    lnq = Nothing
                    If ret = False Then
                        Exit For
                    End If
                Next
            End If
            Return ret
        End Function

        Public Shared Function SearchTHeGIFDoc(ByVal whText As String) As DataTable
            Dim sql As String = "select th.id,th.body_id, th.body_correspondence_date, th.body_subject,isnull(c.thainame, c.engname) sender_organization_name,"
            sql += " case when th.receive_notify_letterid IS null then 'รอลงทะเบียน' else 'ลงทะเบียนแล้ว' end doc_status_name, isnull(th.receive_notify_letterid,'') receive_notify_letterid"
            sql += " from TH_EGIF_DOC_INBOUND th"
            sql += " left join COMPANY c on c.th_egif_org_code=th.sender_department_organization_id "
            sql += " where " & whText
            sql += " order by th.process_time "

            Dim lnq As New ThEgifDocInboundLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("correspondence_date", GetType(Date))
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("correspondence_date") = SetFormatDate(dt.Rows(i)("body_correspondence_date"))
                Next
            End If
            lnq = Nothing

            Return dt
        End Function

        Public Shared Function SearchOutBoundTHeGIFDoc(ByVal whText As String) As DataTable
            Dim sql As String = "select dr.id, dr.register_date, dr.book_no,dr.title_name,"
            sql += " er.company_name_receive,er.bookout_no, er.is_send_thegif, er.id document_ext_receiver_id, "
            sql += " case er.is_send_thegif "
            sql += "    when 'N' then 'ยังไม่ส่งข้อมูลออนไลน์' "
            sql += "    when 'Y' then 'ส่งข้อมูลออนไลน์แล้ว' end doc_status_name"
            sql += " from DOCUMENT_REGISTER dr"
            sql += " inner join DOCUMENT_EXT_RECEIVER er on er.document_register_id=dr.id "
            sql += " where " & whText
            sql += " order by er.bookout_no "

            Dim lnq As New DocumentRegisterLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Shared Function SetFormatDate(ByVal DateIn As String) As DateTime
            'DateIn  = yyyy-MM-dd  ปี ค.ศ.
            If DateIn.Trim <> "" Then
                Dim vDate() As String = Split(DateIn, "-")
                Dim dd As Integer = vDate(2)
                Dim mm As Integer = vDate(1)
                Dim yy As Integer = vDate(0)

                Return New Date(yy, mm, dd)
            Else
                Return New Date(1, 1, 1)
            End If

        End Function

        Public Shared Function GetDocDetail(ByVal vID As Long) As Para.TABLE.ThEgifDocInboundPara
            Dim lnq As New ThEgifDocInboundLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim para As New Para.TABLE.ThEgifDocInboundPara
            para = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return para
        End Function

        Public Shared Function Get_eCMSMinistryOrganizationList() As DataTable
            Dim dt As New DataTable
            Try
                SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")
                'SetURI = "http://dev.exchange.ecms.ega.or.th/"
                dt = GetMinistryOrganizationList("", "")
            Catch ex As Exception
                dt = New DataTable
            End Try

            Return dt
        End Function

        Public Shared Function Get_eCMSOrganizationList() As DataTable
            Dim dt As New DataTable
            Try
                SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")
                'SetURI = "http://dev.exchange.ecms.ega.or.th/"
                dt = GetOrganizationList("", "")
            Catch ex As Exception
                dt = New DataTable
            End Try

            Return dt
        End Function

        Public Shared Function SendCorrespondenceLetterOutboundRequest(ByVal ExtID As String, ByVal LoginName As String) As Boolean
            Dim ret As Boolean = False
            Dim sql As String = ""
            sql += " select er.id document_ext_receiver_id, er.bookout_no, convert(varchar(10),er.send_date,120) correspondence_date," & vbNewLine
            sql += " dr.title_name, se.secret_code, sp.speed_code, o.first_name, o.last_name, o.description officer_position, " & vbNewLine
            sql += " c.th_egif_org_code, ao.first_name signer_first_name, ao.last_name signer_last_name, ao.description signer_position" & vbNewLine
            sql += " from document_ext_receiver er" & vbNewLine
            sql += " inner join document_register dr on dr.id=er.document_register_id " & vbNewLine
            sql += " inner join doc_secret se on se.id=dr.doc_secret_id" & vbNewLine
            sql += " inner join doc_speed sp on sp.id=dr.doc_speed_id" & vbNewLine
            sql += " left join officer o on o.username=er.sender_officer_username" & vbNewLine
            sql += " left join officer ao on ao.username=er.officer_username" & vbNewLine
            sql += " inner join company c on c.id=er.company_id_receive" & vbNewLine
            sql += " where er.id= '" & ExtID & "' "

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New Linq.TABLE.DocumentExtReceiverLinq
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            If dt.Rows.Count > 0 Then
                Dim vMinistryID As String = FunctionENG.GetConfigValue("BOI-MinistryOrganizationID")
                Dim vDepartID As String = FunctionENG.GetConfigValue("BOI-DepartmentOrganizationID")

                Dim dr As DataRow = dt.Rows(0)
                Dim p As New CorrespondenceLetterOutboundRequestPara
                If Convert.IsDBNull(dr("bookout_no")) = False Then p.BodyID = dr("bookout_no").ToString
                If Convert.IsDBNull(dr("correspondence_date")) = False Then p.BodyCorrespondenceDate = dr("correspondence_date").ToString
                If Convert.IsDBNull(dr("title_name")) = False Then p.BodySubject = dr("title_name").ToString
                If Convert.IsDBNull(dr("secret_code")) = False Then p.BodySecretCode = dr("secret_code").ToString
                If Convert.IsDBNull(dr("speed_code")) = False Then p.BodySpeedCode = dr("speed_code").ToString
                If Convert.IsDBNull(dr("first_name")) = False Then p.SenderPartyGivenName = dr("first_name").ToString
                If Convert.IsDBNull(dr("last_name")) = False Then p.SenderPartyFamilyName = dr("last_name").ToString
                If Convert.IsDBNull(dr("officer_position")) = False Then p.SenderPartyJobTitle = dr("officer_position").ToString
                p.SenderPartyMinistryOrganizationID = vMinistryID
                p.SenderPartyDepartmentOrganizationID = vDepartID
                p.ReceiverPartyGivenName = ""
                p.ReceiverPartyFamilyName = ""
                p.ReceiverPartyJobTitle = ""
                If Convert.IsDBNull(dr("th_egif_org_code")) = False Then p.ReceiverPartyMinistryOrganizationID = Left(dr("th_egif_org_code").ToString, 2)
                If Convert.IsDBNull(dr("th_egif_org_code")) = False Then p.ReceiverPartyDepartmentOrganizationID = dr("th_egif_org_code")
                p.SendDate = DateTime.Now.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))

                'ชื่อผู้ลงนาม
                If Convert.IsDBNull(dr("signer_first_name")) = False Then p.SignerPartyGivenName = dr("signer_first_name").ToString
                If Convert.IsDBNull(dr("signer_last_name")) = False Then p.SignerPartyFamilyName = dr("signer_last_name").ToString
                If Convert.IsDBNull(dr("signer_position")) = False Then p.SignerPartyJobTitle = dr("signer_position").ToString
                p.SignerPartyMinistryOrganizationID = vMinistryID
                p.SignerPartyDepartmentOrganizationID = vDepartID

                SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")
                'SetURI = "http://dev.exchange.ecms.ega.or.th/"
                If CorrespondenceLetterOutboundRequest(p).ProcessID <> "" Then
                    ret = True
                End If
                p = Nothing

                If ret = True Then
                    trans = New Linq.Common.Utilities.TransactionDB
                    trans.CreateTransaction()
                    lnq.GetDataByPK(ExtID, trans.Trans)

                    If lnq.ID <> 0 Then
                        lnq.IS_SEND_THEGIF = "Y"
                        If lnq.UpdateByPK(LoginName, trans.Trans) = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                        End If
                    End If
                End If
                dt = Nothing
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Shared Function GetMimeType(ByVal ContentType As String) As String
            Dim ret As String = ""
            Select Case ContentType
                Case "application/pdf"
                    ret = ".PDF"
                Case "application/docx"
                    ret = ".DOCX"
                Case Is = "application/msword"
                    ret = ".DOC"
                Case "application/vnd.ms-excel"
                    ret = ".XLS"
                Case "application/xlsx"
                    ret = ".XLSX"
                Case "text/plain"
                    ret = ".TXT"
                Case "image/tiff"
                    ret = ".TIFF"
                Case "application/rtf"
                    ret = ".RTF"
                Case "image/jpeg"
                    ret = ".JPG"
                Case "image/png"
                    ret = ".PNG"
                Case "image/bmp"
                    ret = ".BMP"
                Case "application/zip"
                    ret = ".ZIP"
            End Select

            Return ret
        End Function

    End Class
End Namespace

