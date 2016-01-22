Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Imports System.IO
Namespace Master
    Public Class HolidayEng
        Dim _err As String = ""
        Dim _ID As Long

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property
        Public Function GetHolidayListBySql(ByVal sql As String) As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New HolidayLinq
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function
        Public Function GetAllHolidayList() As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New HolidayLinq
            dt = lnq.GetDataList("1=1", "id", trans.Trans)
            lnq = Nothing
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetAllHolidayList(ByVal orderBy As String) As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New HolidayLinq
            dt = lnq.GetDataList("1=1", orderBy, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function
        Public Function GetDataHolidayList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New HolidayLinq
            dt = lnq.GetDataList(sqlWhere, orderBy, Nothing)
            lnq = Nothing
            Return dt
        End Function
        Public Function GetHolidayPara(ByVal HolidayID As Long) As HolidayPara
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim p As New HolidayPara
            Dim lnq As New HolidayLinq
            p = lnq.GetParameter(HolidayID, trans.Trans)
            lnq = Nothing
            trans.CommitTransaction()
            Return p
        End Function
        Public Function SaveHoliday(ByVal para As HolidayPara, ByVal UserID As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New HolidayLinq
            If para.ID <> 0 Then
                lnq.GetDataByPK(para.ID, trans.Trans)
            End If
            lnq.HOLIDAY_DATE = para.HOLIDAY_DATE
            lnq.DESCRIPTION = para.DESCRIPTION

            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If

            If ret = False Then
                _err = lnq.ErrorMessage
            Else
                _ID = lnq.ID
            End If
            para = Nothing
            lnq = Nothing

            Return ret
        End Function
        Public Function GetHoliday(ByVal DateValue As Date, ByVal trans As Linq.Common.Utilities.TransactionDB) As HolidayPara
            Dim lnq As New HolidayLinq
            Dim para As New HolidayPara
            If lnq.ChkDataByHOLIDAY_DATE(DateValue, trans.Trans) = True Then
                para = lnq.GetParameter(lnq.ID, trans.Trans)
            End If
            lnq = Nothing

            Return para
        End Function

        Public Function GetHoliday(ByVal currentDate As Integer, ByVal month As Integer, ByVal year As Integer, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim CurrDate As String = year & "-" & month.ToString.PadLeft(2, "0") & "-" & currentDate.ToString.PadLeft(2, "0")
            Dim lnq As New HolidayLinq
            Dim dt As DataTable = lnq.GetDataList("CONVERT(varchar(10),holiday_date,120)='" & CurrDate & "' ", "", trans.Trans)
            lnq = Nothing
            Return dt
        End Function

        Public Function SaveHolidayByYear(ByVal vYear As String) As Boolean
            'บันทึกข้อมูลวันหยุดที่รู้วันที่แน่นอนใน 1 ปี
            '   วันเสาร์ อาทิตย์ และวันหยุดที่รู้วันที่แน่นอน เช่น วันขึ้นปีใหม่, วันแม่, วันพ่อ ฯลฯ
            'vYear คือ ค.ศ.

            Dim ret As Boolean = False
            Dim StartDate As New Date(vYear, 1, 1)  '1 มค.
            Dim EndDate As New Date(vYear, 12, 31)  '31 ธค
            Dim CurrDate As Date = StartDate
            'ตรวจสอบวันเสาร์ อาทิตย์
            Do
                If CurrDate.DayOfWeek = DayOfWeek.Saturday Then
                    ret = SaveHolidayByLinqDB("วันเสาร์", CurrDate)
                End If
                If CurrDate.DayOfWeek = DayOfWeek.Sunday Then
                    ret = SaveHolidayByLinqDB("วันอาทิตย์", CurrDate)
                End If
                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
            Loop While CurrDate <= EndDate

            'ตรวจสอบวันหยุดอื่นๆ ที่ไม่ใช่วันเสาร์ อาทิตย์
            CurrDate = StartDate
            Do
                If CurrDate = New Date(vYear, 1, 1) Then
                    ret = SaveHolidayByLinqDB("วันขึ้นปีใหม่", CurrDate)
                End If
                If CurrDate = New Date(vYear, 4, 6) Then
                    ret = SaveHolidayByLinqDB("วันจักรี", CurrDate)
                End If
                If CurrDate = New Date(vYear, 4, 12) Then
                    ret = SaveHolidayByLinqDB("วันสงกรานต์", CurrDate)
                End If
                If CurrDate = New Date(vYear, 4, 13) Then
                    ret = SaveHolidayByLinqDB("วันสงกรานต์", CurrDate)
                End If
                If CurrDate = New Date(vYear, 4, 14) Then
                    ret = SaveHolidayByLinqDB("วันสงกรานต์", CurrDate)
                End If
                If CurrDate = New Date(vYear, 5, 5) Then
                    ret = SaveHolidayByLinqDB("วันฉัตรมงคล", CurrDate)
                End If
                If CurrDate = New Date(vYear, 8, 12) Then
                    ret = SaveHolidayByLinqDB("วันแม่แห่งชาติ", CurrDate)
                End If
                If CurrDate = New Date(vYear, 10, 23) Then
                    ret = SaveHolidayByLinqDB("วันปิยมหาราช", CurrDate)
                End If
                If CurrDate = New Date(vYear, 12, 5) Then
                    ret = SaveHolidayByLinqDB("วันพ่อแห่งชาติ", CurrDate)
                End If
                If CurrDate = New Date(vYear, 12, 10) Then
                    ret = SaveHolidayByLinqDB("วันรัฐธรรมนูญ", CurrDate)
                End If
                If CurrDate = New Date(vYear, 12, 31) Then
                    ret = SaveHolidayByLinqDB("วันสิ้นปี", CurrDate)
                End If

                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
            Loop While CurrDate <= EndDate

            Dim hDt As New DataTable   'ดึงข้อมูล วันหยุดจาก BOICENTRAL
            hDt = Engine.Common.BOICentralENG.GetHolidayList(vYear)
            If hDt.Rows.Count > 0 Then
                For Each hDr As DataRow In hDt.Rows
                    Dim trans As New Linq.Common.Utilities.TransactionDB
                    If trans.CreateTransaction() = True Then
                        Dim hPara As New HolidayPara
                        hPara = GetHoliday(Convert.ToDateTime(hDr("CALENDARDATE")), trans)
                        If hPara.ID = 0 Then
                            ret = SaveHolidayByLinqDB(hDr("DESCRIPTION"), Convert.ToDateTime(hDr("CALENDARDATE")))
                        End If
                        trans.CommitTransaction()
                        hPara = Nothing
                    End If
                Next
            End If
            hDt = Nothing

            Return ret
        End Function

        Private Function SaveHolidayByLinqDB(ByVal Desc As String, ByVal CurrDate As Date) As Boolean
            Dim ret As Boolean = False

            Dim trans As New TransactionDB
            trans.CreateTransaction()
            Dim lnq As New HolidayLinq

            lnq.ChkDataByHOLIDAY_DATE(CurrDate, trans.Trans)
            lnq.HOLIDAY_DATE = CurrDate
            lnq.DESCRIPTION = Desc
            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK("SYSTEM", trans.Trans)
            Else
                ret = lnq.InsertData("SYSTEM", trans.Trans)
            End If
            If ret = True Then
                trans.CommitTransaction()
                ret = True
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

            Return ret
        End Function

    End Class
End Namespace

