Public Partial Class frmTextReceiveDoc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim txtReq As String = ""
        txtReq += "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>"
        txtReq += "<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">"
        txtReq += "   <SOAP-ENV:Header>"
        txtReq += "       <wsa:MessageID xmlns:wsa=""http://w3.org/2005/08/addressing"">XmlValue-01</wsa:MessageID>"
        txtReq += "       <wsa:to xmlns:wsa=""http://w3.org/2005/08/addressing"">XmlValue-02</wsa:to>"
        txtReq += "   </SOAP-ENV:Header>"
        txtReq += "   <SOAP-ENV:Body>"
        txtReq += "       <CorrespondenceLetterInboundRequest />"
        txtReq += "   </SOAP-ENV:Body>"
        txtReq += "</SOAP-ENV:Envelope>"


        Dim txtRes As String = ""

    End Sub

End Class