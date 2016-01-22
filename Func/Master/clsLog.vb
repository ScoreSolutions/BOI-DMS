Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.IO
Imports System.Data.SqlClient

''' <summary>
''' Summary description for clsLog
''' </summary>
''' 

Public Class clsLog
    Inherits System.Web.UI.Page


    Private sErrorTime As String


    '
    ' TODO: Add constructor logic here
    '
    Public Sub New()
    End Sub

    Public Sub writeLog(ByVal errMessage As Exception)

        '== write Log
        'string messageShow = "Error";
        ' go to page errorlog
        '  return messageShow;

    End Sub
    Public Sub writeLog_2(ByVal errMessage As Exception, ByVal clsName As String, ByVal methodName As String, ByVal pathName As String)

        Dim sql As String = "INSERT INTO TBL_ERROR_LOG(CLASS_NAME,METHOD_NAME,ERROR_MESSAGE) "
        sql += " VALUES('" & clsName & "','" & methodName & "','" & errMessage.ToString() & "')"
        ExecuteNonequery(sql)


    End Sub
    Public Sub writeLog_2(ByVal errMessage As Exception, ByVal clsName As String, ByVal methodName As String)

        'string pathName =  Server.MapPath("../logfile/errorlog");
        'string messAll = clsName + " | " + methodName + "|" + errMessage.Message;
        'ErrorLog(pathName, messAll);

        Dim sql As String = "INSERT INTO TBL_ERROR_LOG(CLASS_NAME,METHOD_NAME,ERROR_MESSAGE) "
        sql += " VALUES('" & clsName & "','" & methodName & "','" & HttpUtility.HtmlDecode(errMessage.Message.ToString()) & "')"

        ExecuteNonequery(sql)

    End Sub

    Public Sub ErrorLog(ByVal sPathName As String, ByVal sErrMsg As String)

        Dim sYear As String = DateTime.Now.Year.ToString()
        Dim sMonth As String = DateTime.Now.Month.ToString()
        Dim sDay As String = DateTime.Now.Day.ToString()
        sErrorTime = sYear & "-" & sMonth & "-" & sDay & ".txt"



        Dim sLogFormat As String
        sLogFormat = DateTime.Now.ToShortDateString().ToString() & " " & DateTime.Now.ToLongTimeString().ToString() & " ==> "


        Using file__1 As New FileStream(sPathName & sErrorTime, FileMode.OpenOrCreate, FileAccess.Write)


            'FileInfo fInfo = new FileInfo(sPathName + sErrorTime);//กำหนดชื่อไฟล์ที่ต้องการอ่านถ้าอยู่ใน C:ก็ต้องอ้างอิง path ให้ถูกด้วย
            'StreamReader reader = fInfo.OpenText();//สร้าง reader เพื่ออ่านไฟล์
            'Console.WriteLine(reader.ReadToEnd());//แสดงข้อมูลในไฟล์
            'reader.Close();
            'StreamWriter writer = File.AppendText("textfile.txt");//เขียนไฟล์โดยข้อมูลจะต่อท้ายข้อมูลเดิม
            'writer.Write("123");// เพิ่มข้อมูล 123
            'writer.Close();

            file__1.Close()
            Dim sw As StreamWriter = File.AppendText(sPathName & sErrorTime)
            sw.WriteLine(sLogFormat & sErrMsg)
            sw.Flush()


            sw.Close()
        End Using


    End Sub


    Public Sub ExecuteNonequery(ByVal sqlCommand As String)

        Dim strConnString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString").ToString()
        Dim objConn As New SqlConnection(strConnString)

        Try


            objConn.Open()

            Dim objCmd As SqlCommand = objConn.CreateCommand()
            objCmd.CommandText = sqlCommand

            objCmd.ExecuteNonQuery()


        Catch ex As Exception
        Finally
            If objConn.State = ConnectionState.Open Then

                ' objConn = null;

                objConn.Close()
            End If
        End Try


    End Sub

End Class
