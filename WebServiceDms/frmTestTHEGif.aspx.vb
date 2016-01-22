Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.Services
Imports System.IO
Imports System.Net
Imports Para.THeGIF

Partial Public Class frmTestTHEGif
    Inherits System.Web.UI.Page
    'Const uri As String = "http://ega-ecms.mict.go.th/ecms-ws01/service2"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  
        Dim p As New CorrespondenceLetterOutboundRequestPara
        p.HeaderMessageID = ""  'บางทีไม่ต้องระบุก็ได้
        p.HeaderMessageTo = ""
        p.BodyCorrespondenceDate = "2012-09-07"
        p.BodyID = "อก 0905/0007"
        p.BodySubject = "subject7"
        p.BodySecretCode = "001"
        p.BodySpeedCode = "001"
        p.SenderPartyGivenName = "อัครวัฒน์"
        p.SenderPartyFamilyName = "พุทธจันทร์"
        p.SenderPartyJobTitle = "JobTitle"
        p.SenderPartyMinistryOrganizationID = "11"
        p.SenderPartyDepartmentOrganizationID = "11008"   '11008=สรอ.

        p.ReceiverPartyGivenName = "Test"
        p.ReceiverPartyFamilyName = "Test"
        p.ReceiverPartyJobTitle = "Test"
        p.ReceiverPartyMinistryOrganizationID = "11"
        p.ReceiverPartyDepartmentOrganizationID = "11002"   '11002 = กระทรวง ICT

        'p.ReferenceCorrespondence  'หนังสืออ้างอิง
        p.Description = "Test"
        p.MainLetterBinaryObjectMime = ""
        p.MainLetterBinaryObjectDataBase64 = ""
        'p.AttachmentBinaryObject 'ไฟล์แนบ
        p.GovernmentSignatureTypeCode = ""
        p.SignerPartyGivenName = "Test"
        p.SignerPartyFamilyName = "Test"
        p.SignerPartyJobTitle = "Test"
        p.SignerPartyMinistryOrganizationID = "11"
        p.SignerPartyDepartmentOrganizationID = "11008"

        LinqWS.THeGIF.RequestTHeGIFLinqWS.SetURI = "http://ega-ecms.mict.go.th/ecms-ws01/service2"

        Response.Write(LinqWS.THeGIF.RequestTHeGIFLinqWS.CorrespondenceLetterOutboundRequest(p).GovernmentDocument)




        'LinqWS.THeGIF.RequestTHeGIFLinqWS.SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")
        ''Response.Write(LinqWS.THeGIF.RequestTHeGIFLinqWS.CorrespondenceLetterInboundRequest("", "").TmpReferenceCorrespondence)
        'GridView1.DataSource = LinqWS.THeGIF.RequestTHeGIFLinqWS.CorrespondenceLetterInboundRequest("", "").GovernmentDocument.AttachmentBinaryObject
        'GridView1.DataBind()

        'Dim p As New Para.THeGIF.OutboundStatusRequestPara
        'p.HeaderTo = uri
        'Response.Write(LinqWS.THeGIF.RequestTHeGIFLinqWS.OutboundStatusRequest(p))

        'Response.Write(LinqWS.THeGIF.RequestTHeGIFLinqWS.GetOrganizationList("", uri))

        'LinqWS.THeGIF.RequestTHeGIFLinqWS.SetURI = Engine.Common.FunctionENG.GetConfigValue("eCMS_URL")
        'GridView1.DataSource = LinqWS.THeGIF.RequestTHeGIFLinqWS.GetOrganizationList("", "")
        'GridView1.DataBind()

        'Response.Write(LinqWS.THeGIF.RequestTHeGIFLinqWS.GetOrganizationListXML("", "").InnerXml)

    End Sub

    'Private Sub CorrespondenceLetterOutboundRequest(ByVal p As CorrespondenceLetterOutboundRequestPara)
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        ' ''*** หมายเหตุ : http://anamai.moph-ecms.mict.go.th  คือ DomainName ของ ecms ที่ติดต่อด้วยและต่อท้ายด้วย /ecms-ws01/service2
    '        'writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        'writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        'writer.Write("<SOAP-ENV:Header>")
    '        'writer.Write("<wsa:MessageID xmlns:wsa=""http://www.w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        'writer.Write("<wsa:To xmlns:wsa=""http://www.w3.org/2005/08/addressing"">" & p.HeaderMessageTo & "</wsa:To>")
    '        'writer.Write("</env:Header>")

    '        'writer.Write("<SOAP-ENV:Body>")
    '        'writer.Write("<CorrespondenceLetterOutboundRequest>")
    '        'writer.Write("<rsm:GovernmentDocument xmlns:ram=""urn:th:gov:egif:data:standard:ReusableAggregateBusinessInformationEntity:1"" xmlns:rsm=""urn:th:gov:egif:data:standard:GovernmentDocument:1.0"">")
    '        'writer.Write("<ram:CorrespondenceLetter ID=""Letter"">")
    '        'writer.Write("<ram:ID>" & p.BodyID & "</ram:ID>")

    '        ''*** หมายเหตุ : yyyyMMdd.HHmmssSSS เป็น Format ของเวลาปัจจุบันที่ส่งหนังสือจากระบบสารบรรณไป ECMS ที่ติดต่อด้วย  โดยใช้ Function program generate วัน เดือน ปี และเวลา
    '        'writer.Write("<ram:CorrespondenceDate>" & p.BodyCorrespondenceDate & "</ram:CorrespondenceDate>")
    '        'writer.Write("<ram:Subject>" & p.BodySubject & "</ram:Subject>")
    '        'writer.Write("<ram:SecretCode>" & p.BodySecretCode & "</ram:SecretCode>")
    '        'writer.Write("<ram:SpeedCode>" & p.BodySpeedCode & "</ram:SpeedCode>")
    '        'writer.Write("<ram:SenderParty>")
    '        'writer.Write("<ram:GivenName>" & p.SenderPartyGivenName & "</ram:GivenName>")
    '        'writer.Write("<ram:FamilyName>" & p.SenderPartyFamilyName & "</ram:FamilyName>")
    '        'writer.Write("<ram:JobTitle>" & p.SenderPartyJobTitle & "</ram:JobTitle>")
    '        'writer.Write("<ram:MinistryOrganization>")
    '        'writer.Write("<ram:ID>" & p.SenderPartyMinistryOrganizationID & "</ram:ID>")
    '        'writer.Write("</ram:MinistryOrganization>")
    '        'writer.Write("<ram:DepartmentOrganization>")
    '        'writer.Write("<ram:ID>" & p.SenderPartyDepartmentOrganizationID & "</ram:ID>")
    '        'writer.Write("</ram:DepartmentOrganization>")
    '        'writer.Write("</ram:SenderParty>")
    '        'writer.Write("<ram:ReceiverParty>")
    '        'writer.Write("<ram:GivenName>" & p.ReceiverPartyGivenName & "</ram:GivenName>")
    '        'writer.Write("<ram:FamilyName>" & p.ReceiverPartyFamilyName & "</ram:FamilyName>")
    '        'writer.Write("<ram:JobTitle>" & p.ReceiverPartyJobTitle & "</ram:JobTitle>")
    '        'writer.Write("<ram:MinistryOrganization>")
    '        'writer.Write("<ram:ID>" & p.ReceiverPartyMinistryOrganizationID & "</ram:ID>")
    '        'writer.Write("</ram:MinistryOrganization>")
    '        'writer.Write("<ram:DepartmentOrganization>")
    '        'writer.Write("<ram:ID>" & p.ReceiverPartyDepartmentOrganizationID & "</ram:ID>")
    '        'writer.Write("</ram:DepartmentOrganization>")
    '        'writer.Write("</ram:ReceiverParty>")
    '        'If p.ReferenceCorrespondence.Rows.Count > 0 Then
    '        '    For Each dr As DataRow In p.ReferenceCorrespondence.Rows
    '        '        writer.Write("<ram:ReferenceCorrespondence>")
    '        '        writer.Write("<ram:ID>" & dr("ReferenceCorrespondenceID") & "</ram:ID>")
    '        '        writer.Write("<ram:CorrespondenceDate>" & dr("ReferenceCorrespondenceCorrespondenceDate") & "</ram:CorrespondenceDate>")
    '        '        writer.Write("<ram:Subject>" & dr("CorrespondenceDateSubject") & "</ram:Subject>")
    '        '        writer.Write("</ram:ReferenceCorrespondence>")
    '        '        'writer.Write("<ram:ReferenceCorrespondence>")
    '        '        'writer.Write("<ram:ID> XmlValue-18 </ram:ID>")
    '        '        'writer.Write("<ram:CorrespondenceDate> XmlValue-19 </ram:CorrespondenceDate>")
    '        '        'writer.Write("<ram:Subject> XmlValue-20 </ram:Subject>")
    '        '        'writer.Write("</ram:ReferenceCorrespondence>")
    '        '    Next
    '        'End If
    '        'writer.Write("<ram:Attachment>" & p.Attachment & "</ram:Attachment>")
    '        'writer.Write("<ram:SendDate>" & p.SendDate & "</ram:SendDate>")
    '        'writer.Write("<ram:Description>" & p.Description & "</ram:Description>")
    '        'writer.Write("<ram:MainLetterBinaryObject mimeCode=""" & p.MainLetterBinaryObjectMime & """>" & p.MainLetterBinaryObjectDataBase64 & "</ram:MainLetterBinaryObject>")
    '        'If p.AttachmentBinaryObject.Rows.Count > 0 Then
    '        '    For Each dr As DataRow In p.AttachmentBinaryObject.Rows
    '        '        writer.Write("<ram:AttachmentBinaryObject mimeCode=""" & dr("AttachmentBinaryObjectMime") & """>" & dr("AttachmentBinaryObjectBase64") & "</ram:AttachmentBinaryObject>")
    '        '        'writer.Write("<ram:AttachmentBinaryObject mimeCode="" XmlValue-26 ""> XmlValue-27 </ram:AttachmentBinaryObject>")
    '        '    Next
    '        'End If
    '        'writer.Write("</ram:CorrespondenceLetter>")
    '        'writer.Write("<ram:GovernmentSignature>")
    '        'writer.Write("<ram:TypeCode>" & p.GovernmentSignatureTypeCode & "</ram:TypeCode>")
    '        'writer.Write("<ram:SignerParty>")
    '        'writer.Write("<ram:GivenName>" & p.SignerPartyGivenName & "</ram:GivenName>")
    '        'writer.Write("<ram:FamilyName>" & p.SignerPartyFamilyName & "</ram:FamilyName>")
    '        'writer.Write("<ram:MinistryOrganization>")
    '        'writer.Write("<ram:ID>" & p.SignerPartyMinistryOrganizationID & "</ram:ID>")
    '        'writer.Write("</ram:MinistryOrganization>")
    '        'writer.Write("<ram:DepartmentOrganization>")
    '        'writer.Write("<ram:ID>" & p.SenderPartyDepartmentOrganizationID & "</ram:ID>")
    '        'writer.Write("</ram:DepartmentOrganization>")
    '        'writer.Write("</ram:SignerParty>")
    '        'writer.Write("<ds:Signature xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"">")
    '        'writer.Write("<ds:SignedInfo>")
    '        'writer.Write("<ds:CanonicalizationMethod Algorithm=""http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments""/>")
    '        'writer.Write("<ds:SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1""/>")
    '        'writer.Write("<ds:Reference URI=""#Letter"">")
    '        'writer.Write("<ds:DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1""/>")
    '        'writer.Write("<ds:DigestValue>" & p.ReferenceDigestValue & "<ds:DigestValue>")
    '        'writer.Write("</ds:Reference>")
    '        'writer.Write("</ds:SignedInfo>")
    '        'writer.Write("<ds:SignatureValue>" & p.SignatureValue & "<ds:SignatureValue>")
    '        'writer.Write("<ds:KeyInfo>")
    '        'writer.Write("<ds:KeyValue>")
    '        'writer.Write("<ds:RSAKeyValue>")
    '        'writer.Write("<ds:Modulus>" & p.KeyValueModule & "</ds:Modulus>")
    '        'writer.Write("<ds:Exponent>" & p.KeyValueExponent & "</ds:Exponent>")
    '        'writer.Write("</ds:RSAKeyValue>")
    '        'writer.Write("</ds:KeyValue>")
    '        'writer.Write("</ds:KeyInfo>")
    '        'writer.Write("</ds:Signature>")
    '        'writer.Write("</ram:GovernmentSignature>")
    '        'writer.Write("</rsm:GovernmentDocument>")
    '        'writer.Write("</CorrespondenceLetterOutboundRequest>")
    '        'writer.Write("</env:Body>")
    '        'writer.Write("</env:Envelope>")
    '        'writer.Close()






    '        ''####เทสผ่านด้วยนะ
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("<SOAP-ENV:Header>")
    '        '*** <wsa:MessageID xmlns:wsa="http://w3.org/2005/08/addressing">mid://yyyyMMdd.HHmmssSSS@noname</wsa:MessageID>
    '        '*** หมายเหตุ : yyyyMMdd.HHmmssSSS เป็น Format ของเวลาปัจจุบันที่ส่งหนังสือจากระบบสารบรรณไป ECMS ที่ติดต่อด้วย  โดยใช้ Function program generate วัน เดือน ปี และเวลา
    '        writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing""></wsa:MessageID> ")

    '        '<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">http://DomainName ecms/ecms-ws01/service2</wsa:to>
    '        '*** หมายเหตุ : http://anamai.moph-ecms.mict.go.th  คือ DomainName ของ ecms ที่ติดต่อด้วยและต่อท้ายด้วย /ecms-ws01/service2
    '        writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & uri & "</wsa:to>")
    '        writer.Write("</SOAP-ENV:Header>")

    '        writer.Write("<SOAP-ENV:Body>")
    '        writer.Write("<CorrespondenceLetterOutboundRequest>")
    '        writer.Write("<rsm:GovernmentDocument xmlns:ram=""urn:th:gov:egif:data:standard:ReusableAggregateBusinessInformationEntity:1"" xmlns:rsm=""urn:th:gov:egif:data:standard:GovernmentDocument:1.0"">")
    '        writer.Write("<ram:CorrespondenceLetter ID=""Letter"">")
    '        writer.Write("<ram:ID>" & p.BodyID & "</ram:ID>")
    '        writer.Write("<ram:CorrespondenceDate>" & p.BodyCorrespondenceDate & "</ram:CorrespondenceDate>")

    '        writer.Write("<ram:Subject>" & p.BodySubject & "</ram:Subject>")
    '        writer.Write("<ram:SecretCode>" & p.BodySecretCode & "</ram:SecretCode>")
    '        writer.Write("<ram:SpeedCode>" & p.BodySpeedCode & "</ram:SpeedCode>")
    '        writer.Write("<ram:SenderParty>")
    '        writer.Write("<ram:GivenName>" & p.SenderPartyGivenName & "</ram:GivenName>")
    '        writer.Write("<ram:FamilyName>" & p.SenderPartyFamilyName & "</ram:FamilyName>")
    '        writer.Write("<ram:JobTitle>" & p.SenderPartyJobTitle & "</ram:JobTitle>")
    '        writer.Write("<ram:MinistryOrganization><ram:ID>" & p.SenderPartyMinistryOrganizationID & "</ram:ID></ram:MinistryOrganization>")
    '        writer.Write("<ram:DepartmentOrganization><ram:ID>" & p.SenderPartyDepartmentOrganizationID & "</ram:ID></ram:DepartmentOrganization>")
    '        writer.Write("</ram:SenderParty>")

    '        writer.Write("<ram:ReceiverParty>")
    '        writer.Write("<ram:GivenName>ทดสอบ</ram:GivenName>")
    '        writer.Write("<ram:FamilyName>ทดสอบ</ram:FamilyName>")
    '        writer.Write("<ram:JobTitle>ทดสอบ</ram:JobTitle>")
    '        writer.Write("<ram:MinistryOrganization><ram:ID>11</ram:ID></ram:MinistryOrganization>")
    '        writer.Write("<ram:DepartmentOrganization><ram:ID>11002</ram:ID></ram:DepartmentOrganization>")
    '        writer.Write("</ram:ReceiverParty>")
    '        writer.Write("<ram:Attachment />")
    '        writer.Write("<ram:SendDate>2012-02-02T09:30:00</ram:SendDate>")
    '        writer.Write("<ram:Description />")

    '        writer.Write("<ram:MainLetterBinaryObject mimeCode=""text/plain"">t7TKzbrK6KfLudGnytfN</ram:MainLetterBinaryObject>")
    '        writer.Write("<ram:AttachmentBinaryObject mimeCode=""text/plain"">t7TKzbrK6KfLudGnytfN</ram:AttachmentBinaryObject>")

    '        writer.Write("</ram:CorrespondenceLetter>")
    '        writer.Write("<ram:GovernmentSignature>")
    '        writer.Write("<ram:TypeCode>DSIG</ram:TypeCode>")
    '        writer.Write("<ram:SignerParty>")
    '        writer.Write("<ram:GivenName>ทดสอบ</ram:GivenName>")
    '        writer.Write("<ram:FamilyName>ทดสอบ</ram:FamilyName>")
    '        writer.Write("<ram:Title>ทดสอบ</ram:Title>")
    '        writer.Write("<ram:MinistryCode>21</ram:MinistryCode>")
    '        writer.Write("<ram:DepartmentCode>21009</ram:DepartmentCode>")
    '        writer.Write("</ram:SignerParty>")
    '        writer.Write("</ram:GovernmentSignature>")
    '        writer.Write("</rsm:GovernmentDocument>")
    '        writer.Write("</CorrespondenceLetterOutboundRequest>")
    '        writer.Write("</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")
    '        writer.Close()

    '        Dim resp As WebResponse = webRequest.GetResponse()

    '        Dim xmlReader As New System.Xml.XmlTextReader(resp.GetResponseStream())
    '        While xmlReader.Read
    '            If xmlReader.Name = "CorrespondenceLetterOutboundResponse" Then
    '                While xmlReader.Read
    '                    If xmlReader.Name = "ProcessID" Then
    '                        Response.Write(xmlReader.ReadString)
    '                    End If
    '                End While
    '            End If
    '        End While





    '        '#### RESPONSE XML
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '  <SOAP-ENV:Body>
    '        '    <CorrespondenceLetterOutboundResponse>
    '        '      <ProcessID>XmlValue-01</ProcessID>
    '        '      <ProcessTime> XmlValue-02 </ProcessTime>
    '        '      <rsm:GovernmentDocument xmlns:ram="urn:th:gov:egif:data:standard:ReusableAggregateBusinessInformationEntity:1" xmlns:rsm="urn:th:gov:egif:data:standard:GovernmentDocument:1.0">XmlValue-03</rsm:GovernmentDocument>
    '        '     </CorrespondenceLetterOutboundResponse>
    '        '    </SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>



    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub CorrespondenceLetterInboundRequest(ByVal HeaderMessageID As String, ByVal HeaderTo As String)
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("<SOAP-ENV:Header>")
    '        writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
    '        writer.Write("</SOAP-ENV:Header>")
    '        writer.Write("<SOAP-ENV:Body>")
    '        writer.Write("<CorrespondenceLetterInboundRequest />")
    '        writer.Write("</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")
    '        writer.Close()

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")


    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterInboundResponse>
    '        '			<ProcessID> XmlValue-01</ProcessID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '			<rsm:GovernmentDocument
    '        '               xmlns:ram = "urn:th:gov:egif:data:standard:ReusableAggregateBusinessInformationEntity:1"
    '        '				xmlns:rsm="urn:th:gov:egif:data:standard:GovernmentDocument:1.0"> XmlValue-03</rsm:GovernmentDocument>
    '        '		</CorrespondenceLetterInboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub CorrespondenceLetterDeleteRequest(ByVal p As CorrespondenceLetterDeleteRequestPara)
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterDeleteRequest>")
    '        writer.Write("			<ProcessID>" & p.BodyProcessID & "</ProcessID>")
    '        writer.Write("		</CorrespondenceLetterDeleteRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")


    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        ' xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        ' <SOAP-ENV:Body>
    '        '  <CorrespondenceLetterDeleteResponse>
    '        '   <ProcessID>XmlValue-01</ProcessID>
    '        '   <ProcessTime> XmlValue-02</ProcessTime>
    '        '  </CorrespondenceLetterDeleteResponse>
    '        ' </SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>



    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub SendReceiveLetterNotifier(ByVal p As SendReceiveLetterNotifierPara)
    '    '5.5	การส่งหนังสือแจ้งรับ(ReceiveLetterNotifier) จากระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง ไป eCMSปลายทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterOutboundRequest>")
    '        writer.Write("			<ReceiveLetterNotifier>")
    '        writer.Write("				<LetterID>" & p.BodyLetterID & "</LetterID>")
    '        writer.Write("				<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
    '        writer.Write("				<Subject>" & p.BodySubject & "</Subject>")
    '        writer.Write("			</ReceiveLetterNotifier>")
    '        writer.Write("		</CorrespondenceLetterOutboundRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")


    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterOutboundResponse>
    '        '			<processID>XmlValue-01</processID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '			<ReceiveLetterNotifier>
    '        '				<LetterID> XmlValue-03</LetterID>
    '        '				<CorrespondenceDate> XmlValue-04</CorrespondenceDate>
    '        '				<Subject> XmlValue-05</Subject>
    '        '				<AcceptDate> XmlValue-06</AcceptDate>
    '        '				<AcceptDepartment>
    '        '					<Code> XmlValue-07</Code>
    '        '				</AcceptDepartment>
    '        '			</ReceiveLetterNotifier>
    '        '		</CorrespondenceLetterOutboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>



    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub ReceiveReceiveLetterNotifier(ByVal p As ReceiveReceiveLetterNotifierPara)
    '    '5.7	การขอรับหนังสือแจ้งรับ(ReceiveLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterInboundRequest />")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterInboundResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime>XmlValue-02</ProcessTime>
    '        '			<ReceiveLetterNotifier>XmlValue-03</ReceiveLetterNotifier>
    '        '		</CorrespondenceLetterInboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>

    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub DeleteReceiveLetterNotifier(ByVal p As DeleteReceiveLetterNotifierPara)
    '    '5.8	การลบหนังสือแจ้งรับ(ReceiveLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterDeleteRequest>")
    '        writer.Write("			<ProcessID>" & p.BodyProcessID & "</ProcessID>")
    '        writer.Write("		</CorrespondenceLetterDeleteRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")
    '        writer.Close()

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterDeleteResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '		</CorrespondenceLetterDeleteResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub SendAcceiptLetterNotifier(ByVal p As SendAcceiptLetterNotifierPara)
    '    '5.9	การส่งหนังสือแจ้งเลขรับ(AcceiptLetterNotifier) จากระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง ไป eCMSปลายทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterOutboundRequest>")
    '        writer.Write("			<AcceptLetterNotifier>")
    '        writer.Write("				<LetterID>" & p.BodyLetterID & "</LetterID>")
    '        writer.Write("				<AcceptID>" & p.BodyAcceptID & "</AcceptID>")
    '        writer.Write("				<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
    '        writer.Write("				<Subject>" & p.BodySubject & "</Subject>")
    '        writer.Write("			</AcceptLetterNotifier>")
    '        writer.Write("		</CorrespondenceLetterOutboundRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterOutboundResponse>
    '        '			<processID>XmlValue-01</processID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '			<AcceptLetterNotifier>
    '        '				<LetterID> XmlValue-03</LetterID>
    '        '				<AcceptID> XmlValue-04</AcceptID>
    '        '				<CorrespondenceDate> XmlValue-05</CorrespondenceDate>
    '        '				<Subject> XmlValue-06</Subject>
    '        '				<AcceptDate> XmlValue-07</AcceptDate>
    '        '				<AcceptDepartment>
    '        '					<Code> XmlValue-08</Code>
    '        '				</AcceptDepartment>
    '        '			</AcceptLetterNotifier>
    '        '		</CorrespondenceLetterOutboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>



    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub ReceiveAcceiptLetterNotifier(ByVal p As ReceiveAcceiptLetterNotifierPara)
    '    '5.11	การขอรับหนังสือแจ้งเลขรับ(AcceptLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterInboundRequest />")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterInboundResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime>XmlValue-02</ProcessTime>
    '        '			<AcceptLetterNotifier>Xmlvalue-03</AcceptLetterNotifier>
    '        '		</CorrespondenceLetterInboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>
    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub DeleteAcceiptLetterNotifier(ByVal p As DeleteAcceiptLetterNotifierPara)
    '    '5.12	การลบหนังสือแจ้งเลขรับ(AcceptLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">XmlValue-01</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">XmlValue-02</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterDeleteRequest>")
    '        writer.Write("			<ProcessID>XmlValue-03</ProcessID>")
    '        writer.Write("		</CorrespondenceLetterDeleteRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterDeleteResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '		</CorrespondenceLetterDeleteResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>

    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub SendRejectLetterNotifier(ByVal p As SendRejectLetterNotifierPara)
    '    '5.13	การส่งหนังสือปฏิเสธ(RejectLetterNotifier) จาก ระบบสารบรรณปลายทาง  ไป eCMSปลายทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">XmlValue-01</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing""> XmlValue-02</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterOutboundRequest>")
    '        writer.Write("			<RejectLetterNotifier>")
    '        writer.Write("				<LetterID>XmlValue-03</LetterID>")
    '        writer.Write("				<CorrespondenceDate> XmlValue-04</CorrespondenceDate>")
    '        writer.Write("				<Subject>XmlValue-05</Subject>")
    '        writer.Write("			</RejectLetterNotifier>")
    '        writer.Write("		</CorrespondenceLetterOutboundRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterOutboundResponse>
    '        '			<processID>XmlValue-01</processID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '			<RejectLetterNotifier>
    '        '				<LetterID> XmlValue-03</LetterID>
    '        '				<CorrespondenceDate> XmlValue-04</CorrespondenceDate>
    '        '				<Subject> XmlValue-05</Subject>
    '        '				<AcceptDate> XmlValue-06</AcceptDate>
    '        '				<AcceptDepartment>
    '        '					<Code> XmlValue-07</Code>
    '        '				</AcceptDepartment>
    '        '			</RejectLetterNotifier>
    '        '		</CorrespondenceLetterOutboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>	


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub ReceiveRejectLetterNotifier(ByVal p As ReceiveRejectLetterNotifierPara)
    '    '5.15	การขอรับหนังสือปฏิเสธ(RejectLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterInboundRequest />")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterInboundResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime>XmlValue-02</ProcessTime>
    '        '			<RejectLetterNotifier>XmlValue-03</RejectLetterNotifier>
    '        '		</CorrespondenceLetterInboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>

    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub DeleteRejectLetterNotifier(ByVal p As DeleteRejectLetterNotifierPara)
    '    '5.16	การลบหนังสือปฏิเสธ(RejectLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterDeleteRequest>")
    '        writer.Write("			<ProcessID>" & p.BodyProcessID & "</ProcessID>")
    '        writer.Write("		</CorrespondenceLetterDeleteRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterDeleteResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '		</CorrespondenceLetterDeleteResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub SendInvalidLetterNotifier(ByVal p As SendInvalidLetterNotifierPara)
    '    '5.17	การส่งหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) จาก ระบบสารบรรณปลายทาง  ไป eCMSปลายทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterOutboundRequest>")
    '        writer.Write("			<InvalidLetterNotifier>")
    '        writer.Write("				<LetterID>" & p.BodyLetterID & "</LetterID>")
    '        writer.Write("				<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
    '        writer.Write("				<Subject>" & p.BodySubject & "</Subject>")
    '        writer.Write("			</InvalidLetterNotifier>")
    '        writer.Write("		</CorrespondenceLetterOutboundRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterOutboundResponse>
    '        '			<processID>XmlValue-01</processID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '			<InvalidLetterNotifier>
    '        '				<LetterID> XmlValue-03</LetterID>
    '        '				<CorrespondenceDate> XmlValue-04</CorrespondenceDate>
    '        '				<Subject> XmlValue-05</Subject>
    '        '				<AcceptDate> XmlValue-06</AcceptDate>
    '        '				<AcceptDepartment>
    '        '					<Code> XmlValue-07</Code>
    '        '				</AcceptDepartment>
    '        '			</InvalidLetterNotifier>
    '        '		</CorrespondenceLetterOutboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>

    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub ReceiveInvalidLetterNotifier(ByVal MessageID As String, ByVal HeaderTo As String)
    '    '5.19	การขอรับหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & MessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterInboundRequest />")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterInboundResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime>XmlValue-02</ProcessTime>
    '        '			<InvalidLetterNotifier>XmlValue-03</InvalidLetterNotifier>
    '        '		</CorrespondenceLetterInboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub DeleteInvalidLetterNotifier(ByVal p As DeleteInvalidLetterNotifierPara)
    '    '5.20	การลบหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterDeleteRequest>")
    '        writer.Write("			<ProcessID>" & p.BodyProcessID & "</ProcessID>")
    '        writer.Write("		</CorrespondenceLetterDeleteRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterDeleteResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '		</CorrespondenceLetterDeleteResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>



    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub SendInvalidAcceptIDNotifier(ByVal p As SendInvalidAcceptIDNotifierPara)
    '    '5.21	การส่งหนังสือแจ้งเลขรับผิด(InvalidAcceptIDNotifier) จาก ระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง  ไป eCMSต้นทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterOutboundRequest>")
    '        writer.Write("			<InvalidAcceptIDNotifier>")
    '        writer.Write("				<LetterID>" & p.BodyLetterID & "</LetterID>")
    '        writer.Write("				<AcceptID>" & p.BodyAcceptID & "</AcceptID>")
    '        writer.Write("				<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
    '        writer.Write("				<Subject>" & p.BodySubject & "</Subject>")
    '        writer.Write("				<AcceptDate>" & p.BodyAcceptDate & "</AcceptDate>")
    '        writer.Write("				<AcceptDepartment>")
    '        writer.Write("					<Code>" & p.BodyAcceptDepartmentCode & "</Code>")
    '        writer.Write("				</AcceptDepartment>")
    '        writer.Write("			</InvalidAcceptIDNotifier>")
    '        writer.Write("		</CorrespondenceLetterOutboundRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterOutboundResponse>
    '        '			<processID>XmlValue-01</processID>
    '        '			<ProcessTime>XmlValue-02</ProcessTime>
    '        '			<InvalidAcceptIDNotifier>XmlValue-03</InvalidAcceptIDNotifier>
    '        '		</CorrespondenceLetterOutboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>

    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub ReceiveInvalidAcceptIDNotifier(ByVal MessageID As String, ByVal HeaderTo As String)
    '    '5.23	การขอรับหนังสือแจ้งเลขรับผิด(InvalidAcceptIDNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง กับ eCMSปลายทาง
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & MessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterInboundRequest />")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterInboundResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime>XmlValue-02</ProcessTime>
    '        '			<InvalidAcceptIDNotifier>XmlValue-03</InvalidAcceptIDNotifier>
    '        '		</CorrespondenceLetterInboundResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub DeleteInvalidAcceptIDNotifier(ByVal p As DeleteInvalidAcceptIDNotifierPara)
    '    '5.24	การลบหนังสือแจ้งเลขรับผิด(InvalidAcceptIDNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง กับ eCMSปลายทาง เพื่อขอรับหนังสือฉบับใหม่
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<SOAP-ENV:Body>")
    '        writer.Write("		<CorrespondenceLetterDeleteRequest>")
    '        writer.Write("			<ProcessID>" & p.BodyProcessID & "</ProcessID>")
    '        writer.Write("		</CorrespondenceLetterDeleteRequest>")
    '        writer.Write("	</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<CorrespondenceLetterDeleteResponse>
    '        '			<ProcessID>XmlValue-01</ProcessID>
    '        '			<ProcessTime> XmlValue-02</ProcessTime>
    '        '		</CorrespondenceLetterDeleteResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub OutboundStatusRequest(ByVal p As OutboundStatusRequestPara)
    '    '5.25	การตรวจสอบสถานการณ์ส่งหนังสือของ eCMS
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        writer.Write("<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("	<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
    '        writer.Write("	</SOAP-ENV:Header>")
    '        writer.Write("	<env:Body ID=""Body"">")
    '        writer.Write("		<OutboundStatusRequest />")
    '        writer.Write("	</env:Body>")
    '        writer.Write("</env:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
    '        '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
    '        '	<SOAP-ENV:Body>
    '        '		<OutboundStatusResponse>
    '        '			<Outbound>
    '        '				<ProcessID>XmlValue-01</ProcessID>
    '        '				<LetterID>XmlValue-02</LetterID>
    '        '				<ProcessStatus>XmlValue-03</ProcessStatus>
    '        '			</Outbound>
    '        '			<Outbound>
    '        '				<ProcessID>XmlValue-01</ProcessID>
    '        '				<LetterID>XmlValue-02</LetterID>
    '        '				<ProcessStatus>XmlValue-03</ProcessStatus>
    '        '			</Outbound>
    '        '			<Outbound>
    '        '				<ProcessID>XmlValue-01</ProcessID>
    '        '				<LetterID>XmlValue-02</LetterID>
    '        '				<ProcessStatus>XmlValue-03</ProcessStatus>
    '        '			</Outbound>
    '        '		</OutboundStatusResponse>
    '        '	</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub GetOrganizationList(ByVal HeaderMessageID As String, ByVal HeaderTo As String)
    '    '6.1	การขอข้อมูลหน่วยงานที่อยู่ในระบบเชื่อมโยงสารบรรณอิเล็กทรอนิกส์
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("<SOAP-ENV:Header>")
    '        writer.Write("		<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("		<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
    '        writer.Write("</SOAP-ENV:Header>")
    '        writer.Write("<SOAP-ENV:Body>")
    '        writer.Write("		<GetOrganizationList/>")
    '        writer.Write("</SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/">
    '        '<SOAP-ENV:Body>
    '        '<OrganizationList>
    '        '<OrganizationInfo> [ข้อมูลหน่วยงาน 1]
    '        '<En-Name> XmlValue-01 : ชื่อภาษาอังกฤษของหน่วยงาน </En-Name>
    '        '<Th-Name> XmlValue-02 : ชื่อภาษาไทยของหน่วยงาน </Th-Name>
    '        '<ECMS-URL> XmlValue-03 : URL ของหน่วยงาน </ECMS-URL>
    '        '<OrganizationID> XmlValue-04 : หมายเลขหน่วยงาน </OrganizationID>
    '        '</OrganizationInfo>
    '        '<OrganizationInfo> [ข้อมูลหน่วยงาน 2]
    '        '<En-Name> XmlValue-01 : ชื่อภาษาอังกฤษของหน่วยงาน </En-Name>
    '        '<Th-Name> XmlValue-02 : ชื่อภาษาไทยของหน่วยงาน </Th-Name>
    '        '<ECMS-URL> XmlValue-03 : URL ของหน่วยงาน </ECMS-URL>
    '        '<OrganizationID> XmlValue-04 : หมายเลขหน่วยงาน </OrganizationID>
    '        '</OrganizationInfo>
    '        '           …
    '        '</OrganizationList>
    '        '</SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>



    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub GetSecretCodes(ByVal HeaderMessageID As String, ByVal HeaderTo As String)
    '    '6.2	การขอรหัสชั้นความลับ
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("  <SOAP-ENV:Header>")
    '        writer.Write("    <wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("    <wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
    '        writer.Write("  </SOAP-ENV:Header>")
    '        writer.Write("  <SOAP-ENV:Body>")
    '        writer.Write("    <GetSecretCodes/>")
    '        writer.Write("  </SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/">
    '        '  <SOAP-ENV:Body>
    '        '    <SecretCodes>
    '        '      <Code> [รหัสที่ 1]
    '        '        <Value> XmlValue-01 : รหัสชั้นความลับ</Value>
    '        '        <Description> XmlValue-02 : คำอธิบายของรหัสชั้นความลับนั้น </ Description>
    '        '      </Code>
    '        '      <Code> [รหัสที่ 2]
    '        '        <Value> XmlValue-01 : รหัสชั้นความลับ</Value>
    '        '        <Description> XmlValue-02 : คำอธิบายของรหัสชั้นความลับนั้น </ Description>
    '        '      </Code>
    '        '           …
    '        '    </SecretCodes>
    '        '  </SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>

    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub GetSpeedCodes(ByVal HeaderMessageID As String, ByVal HeaderTo As String)
    '    '6.3	การขอรหัสชั้นความเร็ว
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("  <SOAP-ENV:Header>")
    '        writer.Write("    <wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("    <wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
    '        writer.Write("  </SOAP-ENV:Header>")
    '        writer.Write("  <SOAP-ENV:Body>")
    '        writer.Write("    <GetSpeedCodes/>")
    '        writer.Write("  </SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/">
    '        '  <SOAP-ENV:Body>
    '        '    <SpeedCodes>
    '        '      <Code> [รหัสที่ 1]
    '        '        <Value> XmlValue-01 : รหัสชั้นความเร็ว</Value>
    '        '        <Description> XmlValue-02 : คำอธิบายของรหัสชั้นความเร็วนั้น </ Description>
    '        '      </Code>
    '        '      <Code> [รหัสที่ 2]
    '        '        <Value> XmlValue-01 : รหัสชั้นความเร็ว</Value>
    '        '        <Description> XmlValue-02 : คำอธิบายของรหัสชั้นความเร็วนั้น </ Description>
    '        '      </Code>
    '        '           …
    '        '    </SpeedCodes>
    '        '  </SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>


    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub

    'Private Sub GetMimeCodes(ByVal HeaderMessageID As String, ByVal HeaderTo As String)
    '    '6.4	การขอContentType
    '    Dim webRequest As WebRequest
    '    Dim rsp As WebResponse = Nothing
    '    webRequest = webRequest.Create(uri)
    '    webRequest.Method = "POST"
    '    webRequest.ContentType = "text/xml"

    '    Dim writer As New StreamWriter(webRequest.GetRequestStream())
    '    Try
    '        writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
    '        writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
    '        writer.Write("  <SOAP-ENV:Header>")
    '        writer.Write("    <wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>")
    '        writer.Write("    <wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
    '        writer.Write("  </SOAP-ENV:Header>")
    '        writer.Write("  <SOAP-ENV:Body>")
    '        writer.Write("    <GetMimeCodes/>")
    '        writer.Write("  </SOAP-ENV:Body>")
    '        writer.Write("</SOAP-ENV:Envelope>")

    '        Dim resp As WebResponse = webRequest.GetResponse()
    '        Dim strem As New StreamReader(resp.GetResponseStream())
    '        Response.Write("" + strem.ReadToEnd() + "</br>")

    '        '#### Response XML
    '        '<?xml version="1.0" encoding="UTF-8"?>
    '        '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/">
    '        '  <SOAP-ENV:Body>
    '        '    <MimeCodes>
    '        '      <Code> [รหัสที่ 1]
    '        '        <File-Extension> XmlValue-01 : นามสกุลของไฟล์ที่จะเพิ่มไว้ใน xml </ File-Extension>
    '        '        <Content-type> XmlValue-02 : ค่า mimeCode ที่จะต้องแจ้งไปพร้อมกับไฟล์แนบใน xml </ Content-type>
    '        '      </Code>
    '        '      <Code> [รหัสที่ 2]
    '        '        <File-Extension> XmlValue-01 : นามสกุลของไฟล์ที่จะเพิ่มไว้ใน xml </ File-Extension>
    '        '        <Content-type> XmlValue-02 : ค่า mimeCode ที่จะต้องแจ้งไปพร้อมกับไฟล์แนบใน xml </ Content-type>
    '        '      </Code>
    '        '           …
    '        '    </SpeedCodes>
    '        '  </SOAP-ENV:Body>
    '        '</SOAP-ENV:Envelope>

    '    Catch webEx As WebException
    '        Response.Write("Error WebException : " & webEx.Message)
    '        Throw New Exception("Error Web: " + webEx.Message)
    '    Catch ex As Exception
    '        Response.Write("Error Exception : " & ex.Message)
    '    Finally
    '        Try
    '            If webRequest IsNot Nothing Then
    '                webRequest.GetRequestStream().Close()
    '            End If
    '            If rsp IsNot Nothing Then
    '                rsp.GetResponseStream().Close()
    '            End If
    '        Catch innerEx As Exception
    '            Throw New Exception("Error Close request: " + innerEx.Message)
    '        End Try
    '    End Try
    'End Sub
End Class