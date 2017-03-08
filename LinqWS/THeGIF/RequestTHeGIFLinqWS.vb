Imports System.Web
Imports System.Net
Imports System.IO
Imports Para.THeGIF
Imports Para.THeGIFResponse

Namespace THeGIF
    Public Class RequestTHeGIFLinqWS
        'Const uri As String = "http://ega-ecms.mict.go.th/ecms-ws01/service2"
        'Dim uri As String = "http://boi-ecms.mict.go.th/ecms-ws01/service2"
        Private Shared uri As String = ""

        Public Shared Property SetURI() As String
            Get
                Return uri
            End Get
            Set(ByVal value As String)
                uri = value
            End Set
        End Property

        Public Shared Function ConvertByteToString(ByVal b() As Byte) As String
            Return Convert.ToBase64String(b)
        End Function

        

        Public Shared Function CorrespondenceLetterInboundRequest(ByVal HeaderMessageID As String, ByVal HeaderTo As String) As CorrespondenceLetterInboundResponsePara
            '3.2.7 การรับหนังสือภายนอก จาก eCMS มายังระบบสารบัญอิเล็กทรอนิกส์
            Dim ret As New CorrespondenceLetterInboundResponsePara

            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"
            Try
                Dim writer As New StreamWriter(webRequest.GetRequestStream())
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterInboundRequest />")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim LetterID As String = ""
                Dim Subject As String = ""

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                ret = BuildCorrespondenceLetterInboundRequest(ret, dXml)
            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try

            Return ret
        End Function

        Private Shared Function BuildCorrespondenceLetterInboundRequest(ByVal ret As CorrespondenceLetterInboundResponsePara, ByVal dXml As Xml.XmlDocument) As CorrespondenceLetterInboundResponsePara
            Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterInboundResponse")
            If nNodeList.Item(0).InnerXml.Trim <> "" Then
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText
                With ret.GovernmentDocument
                    Dim nCorres As Xml.XmlNodeList = dXml.GetElementsByTagName("ram:CorrespondenceLetter")
                    .BodyID = nCorres.Item(0).Item("ram:ID").InnerText
                    .BodyCorrespondenceDate = nCorres.Item(0).Item("ram:CorrespondenceDate").InnerText
                    .BodySubject = nCorres.Item(0).Item("ram:Subject").InnerText
                    .BodySecretCode = nCorres.Item(0).Item("ram:SecretCode").InnerText
                    .BodySpeedCode = nCorres.Item(0).Item("ram:SpeedCode").InnerText

                    .SenderPartyGivenName = nCorres.Item(0).Item("ram:SenderParty").Item("ram:GivenName").InnerText
                    .SenderPartyFamilyName = nCorres.Item(0).Item("ram:SenderParty").Item("ram:FamilyName").InnerText
                    .SenderPartyJobTitle = nCorres.Item(0).Item("ram:SenderParty").Item("ram:JobTitle").InnerText
                    .SenderPartyMinistryOrganizationID = nCorres.Item(0).Item("ram:SenderParty").Item("ram:MinistryOrganization").Item("ram:ID").InnerText
                    .SenderPartyDepartmentOrganizationID = nCorres.Item(0).Item("ram:SenderParty").Item("ram:DepartmentOrganization").Item("ram:ID").InnerText

                    .ReceiverPartyGivenName = nCorres.Item(0).Item("ram:ReceiverParty").Item("ram:GivenName").InnerText
                    .ReceiverPartyFamilyName = nCorres.Item(0).Item("ram:ReceiverParty").Item("ram:FamilyName").InnerText
                    .ReceiverPartyJobTitle = nCorres.Item(0).Item("ram:ReceiverParty").Item("ram:JobTitle").InnerText
                    .ReceiverPartyMinistryOrganizationID = nCorres.Item(0).Item("ram:ReceiverParty").Item("ram:MinistryOrganization").Item("ram:ID").InnerText
                    .ReceiverPartyDepartmentOrganizationID = nCorres.Item(0).Item("ram:ReceiverParty").Item("ram:DepartmentOrganization").Item("ram:ID").InnerText

                    Dim refCorr As Xml.XmlNodeList = dXml.GetElementsByTagName("ram:ReferenceCorrespondence")
                    If refCorr.Count > 0 Then
                        ret.GovernmentDocument.ReferenceCorrespondence.Columns.Add("ReferenceCorrespondenceID")
                        ret.GovernmentDocument.ReferenceCorrespondence.Columns.Add("CorrespondenceDate")
                        ret.GovernmentDocument.ReferenceCorrespondence.Columns.Add("ReferenceCorrespondenceSubject")
                        For i As Integer = 0 To refCorr.Count - 1
                            Dim dr As DataRow = ret.GovernmentDocument.ReferenceCorrespondence.NewRow
                            dr("ReferenceCorrespondenceID") = refCorr.Item(i).Item("ram:ID").InnerText
                            dr("CorrespondenceDate") = refCorr.Item(i).Item("ram:CorrespondenceDate").InnerText
                            dr("ReferenceCorrespondenceSubject") = refCorr.Item(i).Item("ram:Subject").InnerText
                            ret.GovernmentDocument.ReferenceCorrespondence.Rows.Add(dr)
                        Next
                    End If

                    .Attachment = nCorres.Item(0).Item("ram:Attachment").InnerText
                    .SendDate = nCorres.Item(0).Item("ram:SendDate").InnerText
                    .Description = nCorres.Item(0).Item("ram:Description").InnerText
                    .MainLetterBinaryObjectMime = nCorres.Item(0).Item("ram:MainLetterBinaryObject").Attributes("mimeCode").Value
                    .MainLetterBinaryObjectDataBase64 = nCorres.Item(0).Item("ram:MainLetterBinaryObject").InnerText

                    Dim AttBiObj As Xml.XmlNodeList = dXml.GetElementsByTagName("ram:AttachmentBinaryObject")
                    If AttBiObj.Count > 0 Then
                        ret.GovernmentDocument.AttachmentBinaryObject.Columns.Add("AttachmentBinaryObjectMime")
                        ret.GovernmentDocument.AttachmentBinaryObject.Columns.Add("AttachmentBinaryObject")
                        For j As Integer = 0 To AttBiObj.Count - 1
                            Dim dr As DataRow = ret.GovernmentDocument.AttachmentBinaryObject.NewRow
                            dr("AttachmentBinaryObjectMime") = AttBiObj.Item(j).Attributes("mimeCode").InnerText
                            dr("AttachmentBinaryObject") = AttBiObj.Item(j).InnerText
                            ret.GovernmentDocument.AttachmentBinaryObject.Rows.Add(dr)
                        Next
                    End If

                    Dim nGovern As Xml.XmlNodeList = dXml.GetElementsByTagName("ram:GovernmentSignature")
                    .GovernmentSignatureTypeCode = nGovern.Item(0).Item("ram:TypeCode").InnerText
                    .SignerPartyGivenName = nGovern.Item(0).Item("ram:SignerParty").Item("ram:GivenName").InnerText
                    .SignerPartyFamilyName = nGovern.Item(0).Item("ram:SignerParty").Item("ram:FamilyName").InnerText
                    .SignerPartyJobTitle = nGovern.Item(0).Item("ram:SignerParty").Item("ram:Title").InnerText
                    .SignerPartyMinistryOrganizationID = nGovern.Item(0).Item("ram:SignerParty").Item("ram:MinistryCode").InnerText
                    .SignerPartyDepartmentOrganizationID = nGovern.Item(0).Item("ram:SignerParty").Item("ram:DepartmentCode").InnerText

                    .ReferenceURI = nGovern.Item(0).Item("ds:Signature").Item("ds:SignedInfo").Item("ds:Reference").Attributes("URI").InnerText
                    .ReferenceDigestValue = nGovern.Item(0).Item("ds:Signature").Item("ds:SignedInfo").Item("ds:Reference").Item("ds:DigestValue").InnerText
                    .SignatureValue = nGovern.Item(0).Item("ds:Signature").Item("ds:SignatureValue").InnerText
                    .KeyValueModule = nGovern.Item(0).Item("ds:Signature").Item("ds:KeyInfo").Item("ds:X509Data").Item("ds:X509SubjectName").InnerText
                    .KeyValueExponent = nGovern.Item(0).Item("ds:Signature").Item("ds:KeyInfo").Item("ds:X509Data").Item("ds:X509Certificate").InnerText
                End With
            End If
            Return ret
        End Function

        Public Shared Function CorrespondenceLetterDeleteRequest(ByVal p As CorrespondenceLetterDeleteRequestPara) As CorrespondenceLetterDeleteResponsePara
            '3.2.14 การขอลบหนังสือออกจากคิว
            Dim ret As New CorrespondenceLetterDeleteResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterDeleteRequest>")
                writer.Write("<ProcessID>" & p.BodyProcessID & "</ProcessID>")
                writer.Write("</CorrespondenceLetterDeleteRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterDeleteResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText
            Catch webEx As WebException
                Throw New WebException("Error WebException: " + webEx.Message)
            Catch ex As Exception
                Throw New Exception("Error Exception : " + ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try

            Return ret
        End Function

        Public Shared Function DeleteAcceiptLetterNotifier(ByVal p As DeleteAcceiptLetterNotifierPara) As Boolean
            '5.12	การลบหนังสือแจ้งเลขรับ(AcceptLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
            Dim ret As Boolean = False
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">XmlValue-01</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">XmlValue-02</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterDeleteRequest>")
                writer.Write("<ProcessID>XmlValue-03</ProcessID>")
                writer.Write("</CorrespondenceLetterDeleteRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterDeleteResponse")
                If nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText.Trim <> "" Then
                    ret = True
                End If

                '#### Response XML
                '<?xml version="1.0" encoding="UTF-8"?>
                '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
                '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
                '	<SOAP-ENV:Body>
                '		<CorrespondenceLetterDeleteResponse>
                '			<ProcessID>XmlValue-01</ProcessID>
                '			<ProcessTime> XmlValue-02</ProcessTime>
                '		</CorrespondenceLetterDeleteResponse>
                '	</SOAP-ENV:Body>
                '</SOAP-ENV:Envelope>

            Catch webEx As WebException
                'Response.Write("Error WebException : " & webEx.Message)
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try

            Return ret
        End Function

        Public Shared Function CorrespondenceLetterOutboundRequest(ByVal p As CorrespondenceLetterOutboundRequestPara) As CorrespondenceLetterOutboundResponsePara
            '3.2.1 การส่งหนังสือภายนอก
            Dim ret As New CorrespondenceLetterOutboundResponsePara

            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(Uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                '*** หมายเหตุ : yyyyMMdd.HHmmssSSS เป็น Format ของเวลาปัจจุบันที่ส่งหนังสือจากระบบสารบรรณไป ECMS ที่ติดต่อด้วย  โดยใช้ Function program generate วัน เดือน ปี และเวลา
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing""></wsa:MessageID> ")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & uri & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")

                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterOutboundRequest>")
                writer.Write("<rsm:GovernmentDocument xmlns:ram=""urn:th:gov:egif:data:standard:ReusableAggregateBusinessInformationEntity:1"" xmlns:rsm=""urn:th:gov:egif:data:standard:GovernmentDocument:1.0"">")
                writer.Write("<ram:CorrespondenceLetter ID=""Letter"">")
                writer.Write("<ram:ID>" & p.BodyID & "</ram:ID>")
                writer.Write("<ram:CorrespondenceDate>" & p.BodyCorrespondenceDate & "</ram:CorrespondenceDate>")

                writer.Write("<ram:Subject>" & p.BodySubject & "</ram:Subject>")
                writer.Write("<ram:SecretCode>" & p.BodySecretCode & "</ram:SecretCode>")
                writer.Write("<ram:SpeedCode>" & p.BodySpeedCode & "</ram:SpeedCode>")

                'รายละเอียดผู้ส่ง หมายถึง BOI
                writer.Write("<ram:SenderParty>")
                writer.Write("<ram:GivenName>" & p.SenderPartyGivenName & "</ram:GivenName>")
                writer.Write("<ram:FamilyName>" & p.SenderPartyFamilyName & "</ram:FamilyName>")
                writer.Write("<ram:JobTitle>" & p.SenderPartyJobTitle & "</ram:JobTitle>")
                writer.Write("<ram:MinistryOrganization><ram:ID>" & p.SenderPartyMinistryOrganizationID & "</ram:ID></ram:MinistryOrganization>")
                writer.Write("<ram:DepartmentOrganization><ram:ID>" & p.SenderPartyDepartmentOrganizationID & "</ram:ID></ram:DepartmentOrganization>")
                writer.Write("</ram:SenderParty>")

                'รายละเอียดผู้รับหนังสือ
                writer.Write("<ram:ReceiverParty>")
                writer.Write("<ram:GivenName>" & p.ReceiverPartyGivenName & "</ram:GivenName>")
                writer.Write("<ram:FamilyName>" & p.ReceiverPartyFamilyName & "</ram:FamilyName>")
                writer.Write("<ram:JobTitle>" & p.ReceiverPartyJobTitle & "</ram:JobTitle>")
                writer.Write("<ram:MinistryOrganization><ram:ID>" & p.ReceiverPartyDepartmentOrganizationID & "</ram:ID></ram:MinistryOrganization>")
                writer.Write("<ram:DepartmentOrganization><ram:ID>" & p.ReceiverPartyDepartmentOrganizationID & "</ram:ID></ram:DepartmentOrganization>")
                writer.Write("</ram:ReceiverParty>")

                If p.ReferenceCorrespondence.Rows.Count > 0 Then
                    For Each dr As DataRow In p.ReferenceCorrespondence.Rows
                        writer.Write("<ram:ReferenceCorrespondence>")
                        writer.Write("<ram:ID>" & dr("ReferenceCorrespondenceID") & "</ram:ID>")
                        writer.Write("<ram:CorrespondenceDate>" & dr("CorrespondenceDate") & "</ram:CorrespondenceDate>")
                        writer.Write("<ram:Subject>" & dr("ReferenceCorrespondenceSubject") & "</ram:Subject>")
                        writer.Write("</ram:ReferenceCorrespondence>")
                    Next
                End If

                writer.Write("<ram:Attachment>" & p.Attachment & "</ram:Attachment>")
                writer.Write("<ram:SendDate>" & p.SendDate & "</ram:SendDate>")
                writer.Write("<ram:Description>" & p.Description & "</ram:Description>")
                writer.Write("<ram:MainLetterBinaryObject mimeCode=""" & p.MainLetterBinaryObjectMime & """>" & p.MainLetterBinaryObjectDataBase64 & "</ram:MainLetterBinaryObject>")
                If p.AttachmentBinaryObject.Rows.Count > 0 Then
                    For Each dr As DataRow In p.AttachmentBinaryObject.Rows
                        writer.Write("<ram:AttachmentBinaryObject mimeCode=""" & dr("AttachmentBinaryObjectMime") & """>" & dr("AttachmentBinaryObject") & "</ram:AttachmentBinaryObject>")
                    Next
                End If
                writer.Write("</ram:CorrespondenceLetter>")
                writer.Write("<ram:GovernmentSignature>")
                writer.Write("<ram:TypeCode>" & p.GovernmentSignatureTypeCode & "</ram:TypeCode>")
                writer.Write("<ram:SignerParty>")
                writer.Write("<ram:GivenName>" & p.SignerPartyGivenName & "</ram:GivenName>")
                writer.Write("<ram:FamilyName>" & p.SignerPartyFamilyName & "</ram:FamilyName>")
                writer.Write("<ram:Title>" & p.SignerPartyJobTitle & "</ram:Title>")
                writer.Write("<ram:MinistryCode>" & p.SignerPartyMinistryOrganizationID & "</ram:MinistryCode>")
                writer.Write("<ram:DepartmentCode>" & p.SignerPartyDepartmentOrganizationID & "</ram:DepartmentCode>")
                writer.Write("</ram:SignerParty>")
                writer.Write("</ram:GovernmentSignature>")
                writer.Write("</rsm:GovernmentDocument>")
                writer.Write("</CorrespondenceLetterOutboundRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim xmlReader As New System.Xml.XmlTextReader(resp.GetResponseStream())
                While xmlReader.Read
                    If xmlReader.Name = "CorrespondenceLetterOutboundResponse" Then
                        While xmlReader.Read
                            If xmlReader.Name = "ProcessID" Then
                                ret.ProcessID = xmlReader.ReadString
                            End If
                            If xmlReader.Name = "ProcessTime" Then
                                ret.ProcessTime = xmlReader.ReadString
                            End If
                            If xmlReader.Name = "rsm:GovernmentDocument" Then
                                ret.GovernmentDocument = xmlReader.ReadInnerXml
                            End If
                        End While
                    End If
                End While
            Catch webEx As WebException
                ret.ErrorMessage = "Error Web: " + webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try

            Return ret
        End Function

        Private Shared Function SendReceiveLetterNotifier(ByVal p As SendReceiveLetterNotifierPara) As Boolean 'SendReceiveLetterNotifierResposePara
            '3.2.2	การส่งหนังสือตอบรับ(ReceiveLetterNotifier) จากระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง ไป eCMSปลายทาง
            'Dim ret As New SendReceiveLetterNotifierResposePara
            Dim ret As Boolean = False
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterOutboundRequest>")
                writer.Write("<ReceiveLetterNotifier>")
                writer.Write("<LetterID>" & p.BodyLetterID & "</LetterID>")
                writer.Write("<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
                writer.Write("<Subject>" & p.BodySubject & "</Subject>")
                writer.Write("</ReceiveLetterNotifier>")
                writer.Write("</CorrespondenceLetterOutboundRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())
                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterOutboundResponse")

                If nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText.Trim <> "" Then
                    ret = True
                End If

                'Dim xmlReader As New System.Xml.XmlTextReader(resp.GetResponseStream())
                'While xmlReader.Read
                '    If xmlReader.Name = "CorrespondenceLetterOutboundResponse" Then
                '        While xmlReader.Read
                '            If xmlReader.Name.ToUpper = "PROCESSID" Then
                '                ret = True
                '            End If
                '        End While
                '    End If
                'End While

            Catch webEx As WebException
                'ret.ErrorMessage = "Error WebException : " & webEx.Message
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    'ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try

            Return ret
        End Function

        Public Shared Function ReceiveReceiveLetterNotifier(ByVal p As ReceiveReceiveLetterNotifierPara) As CorrespondenceLetterInboundResponsePara
            '3.2.8	การขอรับหนังสือตอบรับ(ReceiveLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
            Dim ret As New CorrespondenceLetterInboundResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterInboundRequest />")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                ret = BuildCorrespondenceLetterInboundRequest(ret, dXml)
            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try

            Return ret
        End Function

        Public Function DeleteReceiveLetterNotifier(ByVal p As DeleteReceiveLetterNotifierPara) As Boolean
            '5.8	การลบหนังสือแจ้งรับ(ReceiveLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
            Dim ret As Boolean = False
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterDeleteRequest>")
                writer.Write("<ProcessID>" & p.BodyProcessID & "</ProcessID>")
                writer.Write("</CorrespondenceLetterDeleteRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterDeleteResponse")
                If nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText.Trim <> "" Then
                    ret = True
                End If

                '#### Response XML
                '<?xml version="1.0" encoding="UTF-8"?>
                '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
                '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
                '	<SOAP-ENV:Body>
                '		<CorrespondenceLetterDeleteResponse>
                '			<ProcessID>XmlValue-01</ProcessID>
                '			<ProcessTime> XmlValue-02</ProcessTime>
                '		</CorrespondenceLetterDeleteResponse>
                '	</SOAP-ENV:Body>
                '</SOAP-ENV:Envelope>

            Catch webEx As WebException
                'Response.Write("Error WebException : " & webEx.Message)
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
        End Function

        Public Shared Function SendAcceiptLetterNotifier(ByVal p As SendAcceiptLetterNotifierPara) As SendAcceptLetterNotifierResponsePara
            '3.2.3	การส่งหนังสือแจ้งเลขรับ(AcceiptLetterNotifier) จากระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง ไป eCMSปลายทาง
            Dim ret As New SendAcceptLetterNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterOutboundRequest>")
                writer.Write("<AcceptLetterNotifier>")
                writer.Write("<LetterID>" & p.BodyLetterID & "</LetterID>")
                writer.Write("<AcceptID>" & p.BodyAcceptID & "</AcceptID>")
                writer.Write("<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
                writer.Write("<Subject>" & p.BodySubject & "</Subject>")
                writer.Write("</AcceptLetterNotifier>")
                writer.Write("</CorrespondenceLetterOutboundRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterOutboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("processID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText
                ret.AcceptID = nNodeList.Item(0).Item("AcceptLetterNotifier").Item("AcceptID").InnerText
                ret.CorrespondenceDate = nNodeList.Item(0).Item("AcceptLetterNotifier").Item("CorrespondenceDate").InnerText
                ret.Subject = nNodeList.Item(0).Item("AcceptLetterNotifier").Item("Subject").InnerText
                ret.AcceptDate = nNodeList.Item(0).Item("AcceptLetterNotifier").Item("AcceptDate").InnerText
                ret.AcceptDepartmentCode = nNodeList.Item(0).Item("AcceptLetterNotifier").Item("AcceptDepartment").Item("Code").InnerText

            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try
            Return ret
        End Function

        Public Shared Function ReceiveAcceiptLetterNotifier(ByVal p As ReceiveAcceiptLetterNotifierPara) As ReceiveAcceiptLetterNotifierResponsePara
            '3.2.9	การขอรับหนังสือแจ้งเลขรับ(AcceptLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
            Dim ret As New ReceiveAcceiptLetterNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterInboundRequest />")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterInboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

                Dim acNode As Xml.XmlNodeList = dXml.GetElementsByTagName("AcceptLetterNotifier")
                With ret.AcceptLetterNotifierResponsePara
                    .LetterID = acNode.Item(0).Item("LetterID").InnerText
                    .AcceptID = acNode.Item(0).Item("AcceptID").InnerText
                    .CorrespondenceDate = acNode.Item(0).Item("CorrespondenceDate").InnerText
                    .Subject = acNode.Item(0).Item("Subject").InnerText
                    .AcceptDate = acNode.Item(0).Item("AcceptDate").InnerText
                    .AcceptDepartmentCode = acNode.Item(0).Item("AcceptDepartment").Item("Code").InnerText
                End With

                '#### Response XML
                '<?xml version="1.0" encoding="UTF-8"?>
                '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
                '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
                '	<SOAP-ENV:Body>
                '		<CorrespondenceLetterInboundResponse>
                '			<ProcessID>XmlValue-01</ProcessID>
                '			<ProcessTime>XmlValue-02</ProcessTime>
                '			<AcceptLetterNotifier>Xmlvalue-03</AcceptLetterNotifier>
                '		</CorrespondenceLetterInboundResponse>
                '	</SOAP-ENV:Body>
                '</SOAP-ENV:Envelope>
            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
                'Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try

            Return ret
        End Function

        

        Public Function SendRejectLetterNotifier(ByVal p As SendRejectLetterNotifierPara) As SendRejectLetterNotifierResponsePara
            '3.2.4	การส่งหนังสือปฏิเสธ(RejectLetterNotifier) จาก ระบบสารบรรณปลายทาง  ไป eCMSปลายทาง
            Dim ret As New SendRejectLetterNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterOutboundRequest>")
                writer.Write("<RejectLetterNotifier>")
                writer.Write("<LetterID>" & p.BodyLetterID & "</LetterID>")
                writer.Write("<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
                writer.Write("<Subject>" & p.BodySubject & "</Subject>")
                writer.Write("</RejectLetterNotifier>")
                writer.Write("</CorrespondenceLetterOutboundRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterOutboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("processID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

                Dim acNode As Xml.XmlNodeList = dXml.GetElementsByTagName("RejectLetterNotifier")
                ret.LetterID = acNode.Item(0).Item("LetterID").InnerText
                ret.CorrespondenceDate = acNode.Item(0).Item("CorrespondenceDate").InnerText
                ret.Subject = acNode.Item(0).Item("Subject").InnerText
                ret.AcceptDate = acNode.Item(0).Item("AcceptDate").InnerText
                ret.AcceptDepartmentCode = acNode.Item(0).Item("AcceptDepartment").Item("Code").InnerText

            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try

            Return ret
        End Function

        Public Shared Function ReceiveRejectLetterNotifier(ByVal p As ReceiveRejectLetterNotifierPara) As ReceiveRejectLetterNotifierResponsePara
            '3.2.10	การขอรับหนังสือปฏิเสธ(RejectLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
            Dim ret As New ReceiveRejectLetterNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterInboundRequest />")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterInboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("processID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

                With ret.RejectLeterNotifier
                    Dim acNode As Xml.XmlNodeList = dXml.GetElementsByTagName("RejectLetterNotifier")
                    .LetterID = acNode.Item(0).Item("LetterID").InnerText
                    .CorrespondenceDate = acNode.Item(0).Item("CorrespondenceDate").InnerText
                    .Subject = acNode.Item(0).Item("Subject").InnerText
                    .AcceptDate = acNode.Item(0).Item("AcceptDate").InnerText
                    .AcceptDepartmentCode = acNode.Item(0).Item("AcceptDepartment").Item("Code").InnerText
                End With
                
            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
                'Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try
            Return ret
        End Function

        Public Function DeleteGovernmentDocumentRequest(ByVal p As DeleteGovernmentDocumentRequestPara) As CorrespondenceLetterDeleteResponsePara
            '3.2.13 การขอลบหนังสือภายนอกเพื่อจะส่งหนังสือใหม่ (กรณีได้รับหนังสือปฏิเสธหรือแจ้งหนังสือผิด)
            Dim ret As New CorrespondenceLetterDeleteResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceDeleteGovernmentDocumentRequest>")
                writer.Write("<LetterID>" & p.BodyLetterID & "</LetterID>")
                writer.Write("<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
                writer.Write("<SenderDepartment>")
                writer.Write("<Code>" & p.BodySenderDepartmentCode & "</Code>")
                writer.Write("</SenderDepartment>")
                writer.Write("<AcceptDepartment>")
                writer.Write("<Code>" & p.BodyAcceptDepartmentCode & "</Code>")
                writer.Write("</AcceptDepartment>")
                writer.Write("</CorrespondenceDeleteGovernmentDocumentRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceDeleteGovernmentDocumentResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("LetterID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

            Catch webEx As WebException
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
            Return ret
        End Function

        Public Function DeleteRejectLetterNotifier(ByVal p As DeleteRejectLetterNotifierPara) As Boolean
            '5.16	การลบหนังสือปฏิเสธ(RejectLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
            Dim ret As Boolean = False
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterDeleteRequest>")
                writer.Write("<ProcessID>" & p.BodyProcessID & "</ProcessID>")
                writer.Write("</CorrespondenceLetterDeleteRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterDeleteResponse")
                If nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText.Trim <> "" Then
                    ret = True
                End If

                '#### Response XML
                '<?xml version="1.0" encoding="UTF-8"?>
                '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
                '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
                '	<SOAP-ENV:Body>
                '		<CorrespondenceLetterDeleteResponse>
                '			<ProcessID>XmlValue-01</ProcessID>
                '			<ProcessTime> XmlValue-02</ProcessTime>
                '		</CorrespondenceLetterDeleteResponse>
                '	</SOAP-ENV:Body>
                '</SOAP-ENV:Envelope>
            Catch webEx As WebException
                'Response.Write("Error WebException : " & webEx.Message)
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
            Return ret
        End Function

        Public Function SendInvalidLetterNotifier(ByVal p As SendInvalidLetterNotifierPara) As SendInvalidLetterNotifierResponsePara
            '3.2.5	การส่งหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) จาก ระบบสารบรรณปลายทาง  ไป eCMSปลายทาง

            Dim ret As New SendInvalidLetterNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterOutboundRequest>")
                writer.Write("<InvalidLetterNotifier>")
                writer.Write("<LetterID>" & p.BodyLetterID & "</LetterID>")
                writer.Write("<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
                writer.Write("<Subject>" & p.BodySubject & "</Subject>")
                writer.Write("</InvalidLetterNotifier>")
                writer.Write("</CorrespondenceLetterOutboundRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterOutboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("processID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

                Dim acNode As Xml.XmlNodeList = dXml.GetElementsByTagName("InvalidLetterNotifier")
                ret.LetterID = acNode.Item(0).Item("LetterID").InnerText
                ret.CorrespondenceDate = acNode.Item(0).Item("CorrespondenceDate").InnerText
                ret.Subject = acNode.Item(0).Item("Subject").InnerText
                ret.AcceptDate = acNode.Item(0).Item("AcceptDate").InnerText
                ret.AcceptDepartmentCode = acNode.Item(0).Item("AcceptDepartment").Item("Code").InnerText

            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
            Return ret
        End Function

        Public Shared Function ReceiveInvalidLetterNotifier(ByVal MessageID As String, ByVal HeaderTo As String) As ReceiveInvalidLetterNotifierResponsePara
            '3.2.11	การขอรับหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง

            Dim ret As New ReceiveInvalidLetterNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & MessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterInboundRequest />")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterInboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

                With ret.InvalidLetterNotifier
                    Dim acNode As Xml.XmlNodeList = dXml.GetElementsByTagName("InvalidLetterNotifier")
                    .LetterID = acNode.Item(0).Item("LetterID").InnerText
                    .CorrespondenceDate = acNode.Item(0).Item("CorrespondenceDate").InnerText
                    .Subject = acNode.Item(0).Item("Subject").InnerText
                    .AcceptDate = acNode.Item(0).Item("AcceptDate").InnerText
                    .AcceptDepartmentCode = acNode.Item(0).Item("AcceptDepartment").Item("Code").InnerText
                End With

            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try
            Return ret
        End Function

        Public Shared Function DeleteInvalidLetterNotifier(ByVal p As DeleteInvalidLetterNotifierPara) As Boolean
            '5.20	การลบหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
            Dim ret As Boolean = False
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterDeleteRequest>")
                writer.Write("<ProcessID>" & p.BodyProcessID & "</ProcessID>")
                writer.Write("</CorrespondenceLetterDeleteRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterDeleteResponse")
                If nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText.Trim <> "" Then
                    ret = True
                End If
                '#### Response XML
                '<?xml version="1.0" encoding="UTF-8"?>
                '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
                '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
                '	<SOAP-ENV:Body>
                '		<CorrespondenceLetterDeleteResponse>
                '			<ProcessID>XmlValue-01</ProcessID>
                '			<ProcessTime> XmlValue-02</ProcessTime>
                '		</CorrespondenceLetterDeleteResponse>
                '	</SOAP-ENV:Body>
                '</SOAP-ENV:Envelope>

            Catch webEx As WebException
                'Response.Write("Error WebException : " & webEx.Message)
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try

            Return ret
        End Function

        Public Shared Function SendInvalidAcceptIDNotifier(ByVal p As SendInvalidAcceptIDNotifierPara) As SendInvalidAcceptIDNotifierResponsePara
            '3.2.6	การส่งหนังสือแจ้งเลขรับผิด(InvalidAcceptIDNotifier) จาก ระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง  ไป eCMSต้นทาง
            Dim ret As New SendInvalidAcceptIDNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterOutboundRequest>")
                writer.Write("<InvalidAcceptIDNotifier>")
                writer.Write("<LetterID>" & p.BodyLetterID & "</LetterID>")
                writer.Write("<AcceptID>" & p.BodyAcceptID & "</AcceptID>")
                writer.Write("<CorrespondenceDate>" & p.BodyCorrespondenceDate & "</CorrespondenceDate>")
                writer.Write("<Subject>" & p.BodySubject & "</Subject>")
                writer.Write("</InvalidAcceptIDNotifier>")
                writer.Write("</CorrespondenceLetterOutboundRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterOutboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("processID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

                Dim acNode As Xml.XmlNodeList = dXml.GetElementsByTagName("InvalidAcceptIDNotifier")
                ret.LetterID = acNode.Item(0).Item("LetterID").InnerText
                ret.CorrespondenceDate = acNode.Item(0).Item("CorrespondenceDate").InnerText
                ret.Subject = acNode.Item(0).Item("Subject").InnerText
                ret.AcceptDate = acNode.Item(0).Item("AcceptDate").InnerText
                ret.AcceptDepartmentCode = acNode.Item(0).Item("AcceptDepartment").Item("Code").InnerText

            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try

            Return ret
        End Function

        Public Shared Function ReceiveInvalidAcceptIDNotifier(ByVal MessageID As String, ByVal HeaderTo As String) As ReceiveInvalidAcceptIDNotifierResponsePara
            '3.2.12	การขอรับหนังสือแจ้งเลขรับผิด(InvalidAcceptIDNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง กับ eCMSปลายทาง
            Dim ret As New ReceiveInvalidAcceptIDNotifierResponsePara
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & MessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterInboundRequest />")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterInboundResponse")
                ret.ProcessID = nNodeList.Item(0).SelectSingleNode("processID").InnerText
                ret.ProcessTime = nNodeList.Item(0).SelectSingleNode("ProcessTime").InnerText

                With ret.InvalidAcceptIDNotifier
                    Dim acNode As Xml.XmlNodeList = dXml.GetElementsByTagName("InvalidAcceptIDNotifier")
                    .LetterID = acNode.Item(0).Item("LetterID").InnerText
                    .CorrespondenceDate = acNode.Item(0).Item("CorrespondenceDate").InnerText
                    .Subject = acNode.Item(0).Item("Subject").InnerText
                    .AcceptDate = acNode.Item(0).Item("AcceptDate").InnerText
                    .AcceptDepartmentCode = acNode.Item(0).Item("AcceptDepartment").Item("Code").InnerText
                End With
                
            Catch webEx As WebException
                ret.ErrorMessage = "Error WebException : " & webEx.Message
            Catch ex As Exception
                ret.ErrorMessage = "Error Exception : " & ex.Message
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    ret.ErrorMessage = "Error Close request: " + innerEx.Message
                End Try
            End Try
            Return ret
        End Function

        Public Shared Function DeleteInvalidAcceptIDNotifier(ByVal p As DeleteInvalidAcceptIDNotifierPara) As Boolean
            '5.24	การลบหนังสือแจ้งเลขรับผิด(InvalidAcceptIDNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ปลายทาง กับ eCMSปลายทาง เพื่อขอรับหนังสือฉบับใหม่
            Dim ret As Boolean = False
            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<CorrespondenceLetterDeleteRequest>")
                writer.Write("<ProcessID>" & p.BodyProcessID & "</ProcessID>")
                writer.Write("</CorrespondenceLetterDeleteRequest>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nNodeList As Xml.XmlNodeList = dXml.GetElementsByTagName("CorrespondenceLetterDeleteResponse")
                If nNodeList.Item(0).SelectSingleNode("ProcessID").InnerText.Trim <> "" Then
                    ret = True
                End If

                '#### Response XML
                '<?xml version="1.0" encoding="UTF-8"?>
                '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
                '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
                '	<SOAP-ENV:Body>
                '		<CorrespondenceLetterDeleteResponse>
                '			<ProcessID>XmlValue-01</ProcessID>
                '			<ProcessTime> XmlValue-02</ProcessTime>
                '		</CorrespondenceLetterDeleteResponse>
                '	</SOAP-ENV:Body>
                '</SOAP-ENV:Envelope>
            Catch webEx As WebException
                'Response.Write("Error WebException : " & webEx.Message)
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
            Return ret
        End Function

        Public Shared Function OutboundStatusRequest(ByVal p As OutboundStatusRequestPara) As DataTable
            '3.3.6	การตรวจสอบสถานการณ์ส่งหนังสือของ eCMS
            Dim ret As New DataTable
            ret.Columns.Add("ProcessID")
            ret.Columns.Add("LetterID")
            ret.Columns.Add("ProcessStatus")

            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
                writer.Write("<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & p.HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<env:Body ID=""Body"">")
                writer.Write("<OutboundStatusRequest />")
                writer.Write("</env:Body>")
                writer.Write("</env:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nList As Xml.XmlNodeList = dXml.GetElementsByTagName("Outbound")
                If nList.Count > 0 Then
                    For Each n As Xml.XmlNode In nList
                        Dim dr As DataRow = ret.NewRow
                        dr("ProcessID") = n.Item("ProcessID")
                        dr("LetterID") = n.Item("LetterID")
                        dr("ProcessStatus") = n.Item("ProcessStatus")
                        ret.Rows.Add(dr)
                    Next
                End If

                '#### Response XML
                '<?xml version="1.0" encoding="UTF-8"?>
                '<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
                '	xmlns:env="http://schemas.xmlsoap.org/soap/envelope/">
                '	<SOAP-ENV:Body>
                '		<OutboundStatusResponse>
                '			<Outbound>
                '				<ProcessID>XmlValue-01</ProcessID>
                '				<LetterID>XmlValue-02</LetterID>
                '				<ProcessStatus>XmlValue-03</ProcessStatus>
                '			</Outbound>
                '			<Outbound>
                '				<ProcessID>XmlValue-01</ProcessID>
                '				<LetterID>XmlValue-02</LetterID>
                '				<ProcessStatus>XmlValue-03</ProcessStatus>
                '			</Outbound>
                '			<Outbound>
                '				<ProcessID>XmlValue-01</ProcessID>
                '				<LetterID>XmlValue-02</LetterID>
                '				<ProcessStatus>XmlValue-03</ProcessStatus>
                '			</Outbound>
                '		</OutboundStatusResponse>
                '	</SOAP-ENV:Body>
                '</SOAP-ENV:Envelope>

            Catch webEx As WebException
                'Response.Write("Error WebException : " & webEx.Message)
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
            Return ret
        End Function

        Public Shared Function GetMinistryOrganizationList(ByVal HeaderMessageID As String, ByVal HeaderTo As String) As DataTable
            '3.3.1 การขอรหัสกระทรวง
            Dim ret As New DataTable
            ret.Columns.Add("Th-Name")
            ret.Columns.Add("MinistryID")

            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim data As String = "<?xml version=""1.0"" encoding=""UTF-8""?>"
            data += "<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">"
            data += "<SOAP-ENV:Header>"
            data += "<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>"
            data += "<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>"
            data += "</SOAP-ENV:Header>"
            data += "<SOAP-ENV:Body>"
            data += "<GetMinistryOrganizationList/>"
            data += "</SOAP-ENV:Body>"
            data += "</SOAP-ENV:Envelope>"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write(data)
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nList As Xml.XmlNodeList = dXml.GetElementsByTagName("MinistryOrganizationList")
                If nList.Count > 0 Then
                    For Each n As Xml.XmlNode In nList
                        Dim dr As DataRow = ret.NewRow
                        dr("Th-Name") = n.Item("Th-Name").InnerText
                        dr("MinistryID") = n.Item("MinistryID").InnerText
                        ret.Rows.Add(dr)
                    Next
                End If
            Catch webEx As WebException
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
            Return ret
        End Function

        Public Shared Function GetOrganizationList(ByVal HeaderMessageID As String, ByVal HeaderTo As String) As DataTable
            '3.3.2 การขอข้อมูลหน่วยงานที่อยู่ในระบบเชื่อมโยงสารบรรณอิเล็กทรอนิกส์
            Dim ret As New DataTable
            ret.Columns.Add("En-Name")
            ret.Columns.Add("Th-Name")
            ret.Columns.Add("ECMS-URL")
            ret.Columns.Add("OrganizationID")

            Dim webRequest As WebRequest
            Dim rsp As WebResponse = Nothing
            webRequest = webRequest.Create(uri)
            webRequest.Method = "POST"
            webRequest.ContentType = "text/xml"

            Dim writer As New StreamWriter(webRequest.GetRequestStream())
            Try
                writer.Write("<?xml version=""1.0"" encoding=""UTF-8""?>")
                writer.Write("<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">")
                writer.Write("<SOAP-ENV:Header>")
                writer.Write("<wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderMessageID & "</wsa:MessageID>")
                writer.Write("<wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">" & HeaderTo & "</wsa:to>")
                writer.Write("</SOAP-ENV:Header>")
                writer.Write("<SOAP-ENV:Body>")
                writer.Write("<GetOrganizationList/>")
                writer.Write("</SOAP-ENV:Body>")
                writer.Write("</SOAP-ENV:Envelope>")
                writer.Close()

                Dim resp As WebResponse = webRequest.GetResponse()
                Dim dXml As New Xml.XmlDocument
                dXml.Load(resp.GetResponseStream())

                Dim nList As Xml.XmlNodeList = dXml.GetElementsByTagName("OrganizationList")
                If nList.Count > 0 Then
                    For Each n As Xml.XmlNode In nList

                        Dim dr As DataRow = ret.NewRow
                        dr("En-Name") = n.Item("name").InnerText
                        dr("Th-Name") = n.Item("name").NextSibling.InnerText
                        dr("ECMS-URL") = n.Item("ECMS-URL").InnerText
                        dr("OrganizationID") = n.Item("OrganizationID").InnerText
                        ret.Rows.Add(dr)
                    Next
                End If

            Catch webEx As WebException
                'Response.Write("Error WebException : " & webEx.Message)
                Throw New Exception("Error Web: " + webEx.Message)
            Catch ex As Exception
                'Response.Write("Error Exception : " & ex.Message)
            Finally
                Try
                    If webRequest IsNot Nothing Then
                        webRequest.GetRequestStream().Close()
                    End If
                    If rsp IsNot Nothing Then
                        rsp.GetResponseStream().Close()
                    End If
                Catch innerEx As Exception
                    Throw New Exception("Error Close request: " + innerEx.Message)
                End Try
            End Try
            Return ret
        End Function
    End Class
End Namespace

