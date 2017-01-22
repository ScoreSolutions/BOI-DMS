Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class DmsOfficerWebService
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function

    <WebMethod()> _
    Public Function SaveDmsOfficer(ByVal UserName As String, ByVal OfficerCode As String, ByVal OfficerIDCardNo As String, ByVal FirstNameThai As String, ByVal LastNameThai As String, ByVal FirstNameEng As String, ByVal LastNameEng As String, ByVal Gender As Integer, ByVal OrganizationID As Long, ByVal OfficerLevel As Integer, ByVal TelNo As String, ByVal FaxNo As String, ByVal BirthDate As String, ByVal Email As String, ByVal Description As String, ByVal efDate As String, ByVal epDate As String) As String
        Dim ret As String = "false"


        Return ret
    End Function

End Class