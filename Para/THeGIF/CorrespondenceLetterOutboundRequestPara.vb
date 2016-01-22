Namespace THeGIF
    Public Class CorrespondenceLetterOutboundRequestPara
        Dim _HeaderMessageID As String = ""
        Dim _HeaderMessageTo As String = ""

        Dim _BodyID As String = ""
        Dim _BodyCorrespondenceDate As String = ""
        Dim _BodySubject As String = ""
        Dim _BodySecretCode As String = ""
        Dim _BodySpeedCode As String = ""

        Dim _SenderPartyGivenName As String = ""
        Dim _SenderPartyFamilyName As String = ""
        Dim _SenderPartyJobTitle As String = ""
        Dim _SenderPartyMinistryOrganizationID As String = ""
        Dim _SenderPartyDepartmentOrganizationID As String = ""

        Dim _ReceiverPartyGivenName As String = ""
        Dim _ReceiverPartyFamilyName As String = ""
        Dim _ReceiverPartyJobTitle As String = ""
        Dim _ReceiverPartyMinistryOrganizationID As String = ""
        Dim _ReceiverPartyDepartmentOrganizationID As String = ""

        Dim _ReferenceCorrespondence As New DataTable("ReferenceCorrespondence")
        Dim _Attachment As String = ""
        Dim _SendDate As String = ""
        Dim _Description As String = ""
        Dim _MainLetterBinaryObjectMime As String = ""
        Dim _MainLetterBinaryObjectDataBase64 As String = ""
        Dim _AttachmentBinaryObject As New DataTable("AttachmentBinaryObject")

        Dim _GovernmentSignatureTypeCode As String = ""
        Dim _SignerPartyGivenName As String = ""
        Dim _SignerPartyFamilyName As String = ""
        Dim _SignerPartyJobTitle As String = ""
        Dim _SignerPartyMinistryOrganizationID As String = ""
        Dim _SignerPartyDepartmentOrganizationID As String = ""

        Dim _ReferenceURI As String = ""
        Dim _ReferenceDigestValue As String = ""

        Dim _SignatureValue As String = ""
        Dim _KeyValueModule As String = ""
        Dim _KeyValueExponent As String = ""

        Public Property HeaderMessageID() As String
            Get
                Return _HeaderMessageID.Trim
            End Get
            Set(ByVal value As String)
                _HeaderMessageID = value
            End Set
        End Property
        Public Property HeaderMessageTo() As String
            Get
                Return _HeaderMessageTo.Trim
            End Get
            Set(ByVal value As String)
                _HeaderMessageTo = value
            End Set
        End Property

        Public Property BodyID() As String
            Get
                Return _BodyID
            End Get
            Set(ByVal value As String)
                _BodyID = value
            End Set
        End Property

        Public Property BodyCorrespondenceDate() As String
            Get
                Return _BodyCorrespondenceDate.Trim
            End Get
            Set(ByVal value As String)
                _BodyCorrespondenceDate = value
            End Set
        End Property

        Public Property BodySubject() As String
            Get
                Return _BodySubject.Trim
            End Get
            Set(ByVal value As String)
                _BodySubject = value
            End Set
        End Property
        Public Property BodySecretCode() As String
            Get
                Return _BodySecretCode.Trim
            End Get
            Set(ByVal value As String)
                _BodySecretCode = value
            End Set
        End Property

        Public Property BodySpeedCode() As String
            Get
                Return _BodySpeedCode.Trim
            End Get
            Set(ByVal value As String)
                _BodySpeedCode = value
            End Set
        End Property

        Public Property SenderPartyGivenName() As String
            Get
                Return _SenderPartyGivenName.Trim
            End Get
            Set(ByVal value As String)
                _SenderPartyGivenName = value
            End Set
        End Property
        Public Property SenderPartyFamilyName() As String
            Get
                Return _SenderPartyFamilyName.Trim
            End Get
            Set(ByVal value As String)
                _SenderPartyFamilyName = value
            End Set
        End Property
        Public Property SenderPartyJobTitle() As String
            Get
                Return _SenderPartyJobTitle.Trim
            End Get
            Set(ByVal value As String)
                _SenderPartyJobTitle = value
            End Set
        End Property

        Public Property SenderPartyMinistryOrganizationID() As String
            Get
                Return _SenderPartyMinistryOrganizationID.Trim
            End Get
            Set(ByVal value As String)
                _SenderPartyMinistryOrganizationID = value
            End Set
        End Property

        Public Property SenderPartyDepartmentOrganizationID() As String
            Get
                Return _SenderPartyDepartmentOrganizationID.Trim
            End Get
            Set(ByVal value As String)
                _SenderPartyDepartmentOrganizationID = value
            End Set
        End Property

        Public Property ReceiverPartyGivenName() As String
            Get
                Return _ReceiverPartyGivenName.Trim
            End Get
            Set(ByVal value As String)
                _ReceiverPartyGivenName = value
            End Set
        End Property
        Public Property ReceiverPartyFamilyName() As String
            Get
                Return _ReceiverPartyFamilyName.Trim
            End Get
            Set(ByVal value As String)
                _ReceiverPartyFamilyName = value
            End Set
        End Property

        Public Property ReceiverPartyJobTitle() As String
            Get
                Return _ReceiverPartyJobTitle.Trim
            End Get
            Set(ByVal value As String)
                _ReceiverPartyJobTitle = value
            End Set
        End Property

        Public Property ReceiverPartyMinistryOrganizationID() As String
            Get
                Return _ReceiverPartyMinistryOrganizationID.Trim
            End Get
            Set(ByVal value As String)
                _ReceiverPartyMinistryOrganizationID = value
            End Set
        End Property

        Public Property ReceiverPartyDepartmentOrganizationID() As String
            Get
                Return _ReceiverPartyDepartmentOrganizationID.Trim
            End Get
            Set(ByVal value As String)
                _ReceiverPartyDepartmentOrganizationID = value
            End Set
        End Property

        Public Property ReferenceCorrespondence() As DataTable
            Get
                Return _ReferenceCorrespondence
            End Get
            Set(ByVal value As DataTable)
                _ReferenceCorrespondence = value
            End Set
        End Property

        Public Property Attachment() As String
            Get
                Return _Attachment.Trim
            End Get
            Set(ByVal value As String)
                _Attachment = value
            End Set
        End Property

        Public Property SendDate() As String
            Get
                Return _SendDate.Trim
            End Get
            Set(ByVal value As String)
                _SendDate = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _Description.Trim
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        Public Property MainLetterBinaryObjectMime() As String
            Get
                Return _MainLetterBinaryObjectMime.Trim
            End Get
            Set(ByVal value As String)
                _MainLetterBinaryObjectMime = value
            End Set
        End Property

        Public Property MainLetterBinaryObjectDataBase64() As String
            Get
                Return _MainLetterBinaryObjectDataBase64.Trim
            End Get
            Set(ByVal value As String)
                _MainLetterBinaryObjectDataBase64 = value
            End Set
        End Property

        Public Property AttachmentBinaryObject() As DataTable
            Get
                Return _AttachmentBinaryObject
            End Get
            Set(ByVal value As DataTable)
                _AttachmentBinaryObject = value
            End Set
        End Property

        Public Property GovernmentSignatureTypeCode() As String
            Get
                Return _GovernmentSignatureTypeCode.Trim
            End Get
            Set(ByVal value As String)
                _GovernmentSignatureTypeCode = value
            End Set
        End Property

        Public Property SignerPartyGivenName() As String
            Get
                Return _SignerPartyGivenName.Trim
            End Get
            Set(ByVal value As String)
                _SignerPartyGivenName = value
            End Set
        End Property
        Public Property SignerPartyFamilyName() As String
            Get
                Return _SignerPartyFamilyName.Trim
            End Get
            Set(ByVal value As String)
                _SignerPartyFamilyName = value
            End Set
        End Property
        Public Property SignerPartyJobTitle() As String
            Get
                Return _SignerPartyJobTitle.Trim
            End Get
            Set(ByVal value As String)
                _SignerPartyJobTitle = value
            End Set
        End Property

        Public Property SignerPartyMinistryOrganizationID() As String
            Get
                Return _SignerPartyMinistryOrganizationID.Trim
            End Get
            Set(ByVal value As String)
                _SignerPartyMinistryOrganizationID = value
            End Set
        End Property

        Public Property SignerPartyDepartmentOrganizationID() As String
            Get
                Return _SignerPartyDepartmentOrganizationID.Trim
            End Get
            Set(ByVal value As String)
                _SignerPartyDepartmentOrganizationID = value
            End Set
        End Property


        Public Property ReferenceURI() As String
            Get
                Return _ReferenceURI.Trim
            End Get
            Set(ByVal value As String)
                _ReferenceURI = value
            End Set
        End Property
        Public Property ReferenceDigestValue() As String
            Get
                Return _ReferenceDigestValue.Trim
            End Get
            Set(ByVal value As String)
                _ReferenceDigestValue = value
            End Set
        End Property

        Public Property SignatureValue() As String
            Get
                Return _SignatureValue.Trim
            End Get
            Set(ByVal value As String)
                _SignatureValue = value
            End Set
        End Property
        Public Property KeyValueModule() As String
            Get
                Return _KeyValueModule.Trim
            End Get
            Set(ByVal value As String)
                _KeyValueModule = value
            End Set
        End Property
        Public Property KeyValueExponent() As String
            Get
                Return _KeyValueExponent.Trim
            End Get
            Set(ByVal value As String)
                _KeyValueExponent = value
            End Set
        End Property
    End Class
End Namespace

