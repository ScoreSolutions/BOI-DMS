Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI
Imports Linq.Common.Utilities.SqlDB

Public Module Support_program
    Public conn As SqlConnection
    Public cnstr As String
    Public sqltmp As String
    Public sqltmpd1 As String
    Public sqltmpd2 As String
    Public docid As Integer
    Public edit_mode As Integer
    Public edit_rowid As String

    Public NoProcess As Boolean = False
    Public txtdetail As String

    Public Const FormBookOutID As Integer = 1
    Public Const FormBookInID As Integer = 2
    Public Const FormBookSealID As Integer = 3
    Public Const FormBookCommandID As Integer = 4
    Public Const FormBookRuleID As Integer = 5
    Public Const FormBookRegulationID As Integer = 6
    Public Const FormBookNoticeID As Integer = 7
    Public Const FormBookStateID As Integer = 8
    Public Const FormBookNewsID As Integer = 9
    Public Const FormBookAssureID As Integer = 10
    Public Const FormBookMinutesID As Integer = 11
    Public Const FormBookNoteID As Integer = 12

    Public sys_err As String
    Public Array_docname() As String = {"หนังสือภายนอก", "หนังสือภายใน", "หนังสือประทับตรา", "หนังสือสั่งการ คำสั่ง", "หนังสือสั่งการ ระเบียบ", "หนังสือสั่งการ ข้อบังคับ", "หนังสือประชาสัมพันธ์ ประกาศ", "หนังสือประชาสัมพันธ์ แถลงการณ์", "หนังสือประชาสัมพันธ์ ข่าว", "หนังสือที่เจ้าหน้าที่ทำขึ้นหรือรับไว้เป็นหลักฐาน หนังสือรับรอง", "หนังสือที่เจ้าหน้าที่ทำขึ้นหรือรับไว้เป็นหลักฐาน รายงานการประชุม", "หนังสือที่เจ้าหน้าที่ทำขึ้นหรือรับไว้เป็นหลักฐาน บันทึก"}
    Public Array_status() As String = {"รออนุมัติ", "ยังไม่ได้ส่ง", "ส่งแล้ว", "อนุมัติ", "ไม่อนุมัติ", "แก้ไขยังไม่ส่ง", "แก้ไขส่งแล้ว", "ไม่อนุมัติยกเลิก", "ยกเลิก", "จบงาน"}

    'Public YearZone As Integer = 543   'thai year
    Public YearZone As Integer = 0   'Inter year
    Public YearZoneSave As Integer = -543   'Inter year

    Public Const new_data As Integer = 1
    Public Const edit_data As Integer = 2

    Public Sub condb()
        cnstr = Sqldbgetconnectionstring()
    End Sub

    Public Function GetLastID(ByVal tbName As String) As Long
        Dim ret As Long
        Dim Sql As String = "select IDENT_CURRENT('" & tbName & "') lastID "
        Dim dt As DataTable = ExecuteTable(Sql)
        If Convert.IsDBNull(dt.Rows(0)("lastID")) = False Then
            ret = Convert.ToInt64(dt.Rows(0)("lastID").ToString())
        Else
            ret = 1
        End If

        Return ret
    End Function

    Public Function GridviewCheck(ByVal gd As GridView) As Boolean
        Dim str As New StringBuilder
        Dim i As Integer
        Dim isChecked As CheckBox
        Dim isLabel As Label
        Dim row As GridViewRow

        'Select the checkboxes from the GridView control
        For i = 0 To gd.Rows.Count - 1
            row = gd.Rows(i)
            isChecked = CType(row.FindControl("chk_id"), CheckBox)
            isLabel = CType(row.FindControl("txt_id"), Label)

            If isChecked.Checked Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub GridviewDeleteData(ByVal gd As GridView, ByVal TBdata As String, ByVal fldkey As String)
        condb()

        Dim str As New StringBuilder
        Dim i As Integer
        Dim isChecked As CheckBox
        Dim isLabel As Label
        Dim row As GridViewRow

        Dim sqltmp As String
        'Dim myTrans As OleDbTransaction

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        'Select the checkboxes from the GridView control
        For i = 0 To gd.Rows.Count - 1
            row = gd.Rows(i)
            isChecked = CType(row.FindControl("chk_id"), CheckBox)
            isLabel = CType(row.FindControl("txt_id"), Label)

            If isChecked.Checked Then
                Try
                    sqltmp = " delete from " + TBdata + " where " + fldkey + " = " + isLabel.Text

                    COMMAND.CommandText = sqltmp
                    COMMAND.ExecuteNonQuery()
                Catch ex As Exception
                Finally

                End Try
            End If
        Next
    End Sub

    Public Function GetLastNo(ByVal yearzone As Integer) As String
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        Da = New SqlDataAdapter("select top 1 substring(doc_no ,1,2) as docYY,convert(int,substring(doc_no ,4,6))+1 as DocNN from doc_trans order by doc_no desc", conn)
        Da.Fill(Ds, "DATA")

        If Ds.Tables("DATA").Rows.Count > 0 Then
            If Ds.Tables("DATA").Rows(0).Item("DocYY") <> Format(DateAdd(DateInterval.Year, yearzone, Date.Now), "yy") Then
                Return Format(DateAdd(DateInterval.Year, yearzone, Date.Now), "yy") + "-" + Format(1, "000000")
            Else
                Return Format(DateAdd(DateInterval.Year, yearzone, Date.Now), "yy") + "-" + Format(CInt(Ds.Tables("DATA").Rows(0).Item("DocNN")), "000000")
            End If
        Else
            Return Format(DateAdd(DateInterval.Year, yearzone, Date.Now), "yy") + "-" + Format(1, "000000")
        End If
    End Function

    Public Function GetDataToList(ByVal sqlcmd As String) As DataTable
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        Da = New SqlDataAdapter(sqlcmd, conn)
        Da.Fill(Ds, "DATA")

        Return Ds.Tables("DATA")
    End Function

    Public Function getdatafld(ByVal sqlcmd As String, ByVal getfld As String) As String
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        Da = New SqlDataAdapter(sqlcmd, conn)
        Da.Fill(Ds, "DATA")

        If Ds.Tables("DATA").Rows.Count > 0 Then
            Return Ds.Tables("DATA").Rows(0).Item(getfld).ToString
        Else
            Return ""
        End If
    End Function

    Public Function Duplicate_Docno(ByVal docno As String) As Boolean
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        Da = New SqlDataAdapter("select doc_no from DOC_TRANS where doc_no = '" + docno + "'", conn)
        Da.Fill(Ds, "DATA")

        If Ds.Tables("DATA").Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub change_status(ByVal status_ref As String, ByVal status_app As String, ByVal else_status As String, ByVal table As String, ByVal ID_key As String)
        Dim status As String
        status = getdatafld("select doc_status from " + table + " where id = " + ID_key, "doc_status")
        If status = status_ref Then
            update_status(status_app, table, ID_key)
        Else
            update_status(else_status, table, ID_key)
        End If

    End Sub

    Public Sub update_status(ByVal status As String, ByVal table As String, ByVal ID_key As String)
        condb()

        conn = New SqlConnection(cnstr)

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        sqltmp = "Update " + table + " set doc_status = '" + status + "'"
        sqltmp = sqltmp + " where id = " + ID_key

        COMMAND.CommandText = sqltmp
        COMMAND.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function sql_data(ByVal sqlcmd As String) As String
        condb()

        conn = New SqlConnection(cnstr)

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        Try
            COMMAND.CommandText = sqltmp
            COMMAND.ExecuteNonQuery()
            conn.Close()

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try

        conn.Close()
    End Function
End Module
