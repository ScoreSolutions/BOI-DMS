Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Linq.TABLE
Imports Engine.Master.OfficerEng

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
    Public Function SaveDmsOfficer(ByVal UserName As String, ByVal OfficerCode As String, ByVal OfficerIDCardNo As String, ByVal FirstNameThai As String, _
                                   ByVal LastNameThai As String, ByVal FirstNameEng As String, ByVal LastNameEng As String, ByVal Gender As Integer, _
                                   ByVal OrganizationID As Long, ByVal OfficerLevel As Integer, ByVal TelNo As String, ByVal FaxNo As String, _
                                   ByVal BirthDate As String, ByVal Email As String, ByVal Description As String, ByVal efDate As String, _
                                   ByVal epDate As String, ByVal UpdateByUserName As String) As String

        Dim ret As String = "false"
        Dim eng As New Engine.Master.OfficerEng

        If UserName = "" Then
            Return ret & "|" & "กรุณาระบุชื่อเข้าระบบ"
        End If

        If OfficerCode = "" Then
            Return ret & "|" & "กรุณาระบุรหัสเจ้าหน้าที่"
        End If

        If OfficerIDCardNo = "" Then
            Return ret & "|" & "กรุณาระบุเลขบัตรประชาชน"
        End If

        If FirstNameThai = "" Then
            Return ret & "|" & "กรุณาระบุชื่อภาษาไทย"
        End If

        If LastNameThai = "" Then
            Return ret & "|" & "กรุณาระบุนามสกุลภาษาไทย"
        End If

        If OrganizationID = 0 Then
            Return ret & "|" & "กรุณาระบุหน่วยงาน"
        End If

        If Gender.ToString <> "1" And Gender <> "2" Then
            Return ret & "|" & "กรุณาระบุเพศ"
        End If

        If OfficerLevel = 0 Then
            Return ret & "|" & "กรุณาระบุระดับของเจ้าหน้าที่"
        End If

        If efDate = "" Then
            Return ret & "|" & "กรุณาระบุวันที่เริ่มใช้"
        End If

        If efDate = "" Then
            Return ret & "|" & "กรุณาระบุชื่อเข้าระบบของผู้ที่ทำการแก้ไขข้อมูล"
        End If


        Dim id As String = ""
        id = eng.GetOfficerIDByUsernameOrIDCard(UserName, OfficerIDCardNo)
        ret = eng.SaveOfficerData(id, UserName, OfficerCode, OfficerIDCardNo, FirstNameThai, LastNameThai, FirstNameEng, _
                              LastNameEng, Gender, OrganizationID, OfficerLevel, TelNo, FaxNo, BirthDate, Email, _
                              Description, efDate, epDate, UpdateByUserName)

        Return ret
    End Function



End Class