Imports System.Data
Imports LinqWS.THeGIF.RequestTHeGIFLinqWS
Partial Class WebApp_frmDocTHeGIFInbound
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetNewInbound()
        'Dim inb As New Para.THeGIFResponse.CorrespondenceLetterInboundResponsePara
        'SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")
        'inb = CorrespondenceLetterInboundRequest("", "")
        'If inb.ProcessID.Trim <> "" Then
        '    lblBookNo.Text = inb.GovernmentDocument.BodyID
        '    lblCorrespondenceDate.Text = inb.GovernmentDocument.BodyCorrespondenceDate
        '    lblTitleName.Text = inb.GovernmentDocument.BodySubject

        '    Dim seEng As New Engine.Master.DocSecretEng
        '    Dim seDt As New DataTable
        '    seDt = seEng.GetDataSecretList("secret_code='" & inb.GovernmentDocument.BodySecretCode & "'", "")
        '    If seDt.Rows.Count > 0 Then
        '        lblSecret.Text = seDt.Rows(0)("secret_name").ToString
        '    End If
        '    seDt = Nothing
        '    seEng = Nothing

        '    Dim spEng As New Engine.Master.DocSpeedEng
        '    Dim spDt As New DataTable
        '    spDt = spEng.GetDataSpeedList("speed_code='" & inb.GovernmentDocument.BodySpeedCode & "'", "")
        '    If spDt.Rows.Count > 0 Then
        '        lblSpeed.Text = spDt.Rows(0)("speed_name").ToString
        '    End If
        '    spDt = Nothing
        '    spEng = Nothing

        '    'ผู้ส่ง
        '    lblSenderGivenName.Text = inb.GovernmentDocument.SenderPartyGivenName & " " & inb.GovernmentDocument.SenderPartyFamilyName
        '    lblSenderJobTitle.Text = inb.GovernmentDocument.SenderPartyJobTitle
        '    lblSenderOrganizationName.Text = "กระทรวง : " & inb.GovernmentDocument.SenderPartyMinistryOrganizationID & " กรม : " & inb.GovernmentDocument.SenderPartyDepartmentOrganizationID

        '    'ผู้ลงนาม
        '    lblSignerGivenName.Text = inb.GovernmentDocument.SignerPartyGivenName & " " & inb.GovernmentDocument.SignerPartyFamilyName
        '    lblSignerPosition.Text = inb.GovernmentDocument.SignerPartyJobTitle
        '    lblSenderOrganizationName.Text = "กระทรวง : " & inb.GovernmentDocument.SignerPartyMinistryOrganizationID & " กรม : " & inb.GovernmentDocument.SignerPartyDepartmentOrganizationID

        '    lblDescriptoin.Text = inb.GovernmentDocument.Description

        '    'Main Letter
        '    lblMainLetterContentType.Text = inb.GovernmentDocument.MainLetterBinaryObjectMime
        '    'lblMainLetterBinaryObject.Text = inb.GovernmentDocument.MainLetterBinaryObjectDataBase64

        '    'SaveBase64ToFile(inb.GovernmentDocument.MainLetterBinaryObjectDataBase64, inb.GovernmentDocument.MainLetterBinaryObjectMime)
        '    '            

        '    'สิ้งที่ส่งมาด้วย
        '    'inb.GovernmentDocument.ReferenceCorrespondence

        '    ''หนังสืออ้างอิง
        '    'lblReferenceCorrespondence.Text = inb.TmpReferenceCorrespondence
        '    'Dim rDt As New DataTable
        '    'rDt = inb.GovernmentDocument.ReferenceCorrespondence
        '    'If rDt.Rows.Count > 0 Then
        '    '    For Each rDr As DataRow In rDt.Rows
        '    '        lblReferenceCorrespondence.Text += 
        '    '    Next
        '    'End If
        '    'rDt = Nothing

        'End If
    End Sub

    Private Sub SaveBase64ToFile(ByVal Base64String As String, ByVal ContentType As String)
        Dim imageBytes As Byte() = Convert.FromBase64String(Base64String)
        Dim fs As New System.IO.FileStream(Engine.Common.FunctionENG.GetFileUploadPath & "TestFile.doc", System.IO.FileMode.CreateNew)
        fs.Write(imageBytes, 0, imageBytes.Length)
        fs.Close()
    End Sub

    Private Sub GetNewInbound()
        Dim uPara As New Para.Common.UserProfilePara
        uPara = Config.GetLogOnUser
        Engine.WebService.THeGIFENG.GetNewInbound(uPara.UserName)
        uPara = Nothing
    End Sub
End Class
