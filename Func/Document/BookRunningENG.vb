Namespace Document
    Public Class BookRunningENG
        'Public Shared Function UpdateBookRunning(ByVal LoginName As String, ByVal RegisType As String, ByVal OrgAbb As String, ByVal BookType As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
        '    Dim ret As Boolean = False
        '    Dim yy As String = DateTime.Now.ToString("yy", New Globalization.CultureInfo("th-TH"))
        '    Dim dt As New DataTable
        '    Dim strcmd As String = ""
        '    strcmd = "  SELECT id"
        '    strcmd += " FROM BOOK_RUNNING"
        '    strcmd += " WHERE book_type = '" & BookType & "' "
        '    strcmd += " and run_year = '" & yy & "'"
        '    If RegisType = "1" Then
        '        'กรณีรับจากภายใน จะต้องรันตามชื่อย่อหน่วยงานด้วย
        '        strcmd += " and isnull(org_abb,'') = '" & OrgAbb & "'"
        '    ElseIf RegisType = "0" Then
        '        'กรณีลงรับจากหน่วยงานภายนอก
        '        strcmd += " and isnull(org_abb,'')=''"
        '    ElseIf RegisType = "O" Then
        '        strcmd += " and isnull(org_abb,'') = '" & OrgAbb & "'"
        '    End If

        '    Dim lnq As New Linq.TABLE.BookRunningLinq
        '    dt = lnq.GetListBySql(strcmd, trans.Trans)
        '    If dt.Rows.Count > 0 Then
        '        lnq.GetDataByPK(Convert.ToInt64(dt.Rows(0)("id")), trans.Trans)
        '    End If
        '    lnq.BOOK_TYPE = BookType
        '    lnq.RUN_YEAR = yy
        '    lnq.LENGTH = IIf(lnq.LENGTH > 0, lnq.LENGTH, 6)
        '    If RegisType = "1" Then
        '        lnq.ORG_ABB = OrgAbb
        '    ElseIf RegisType = "0" Then
        '        lnq.ORG_ABB = ""
        '    ElseIf RegisType = "O" Then
        '        lnq.ORG_ABB = OrgAbb
        '    End If

        '    If lnq.ID <> 0 Then
        '        ret = lnq.UpdateByPK(LoginName, trans.Trans)
        '    Else
        '        ret = lnq.InsertData(LoginName, trans.Trans)
        '    End If

        '    Return ret
        'End Function

        Public Shared Function GetBookNo(ByVal RegisType As String, ByVal SendType As String, ByVal OrgAbb As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As String
            'SendType
            ''I=ส่งภายใน
            ''O=ส่วงภายนอก
            ''C=ส่งหนังสือเวียน

            Dim ret As String = ""

            Dim yy As String = DateTime.Now.ToString("yy", New Globalization.CultureInfo("th-TH"))
            If RegisType = "1" And SendType = "I" Then
                'ลงทะเบียนรับจากภายใน  กรณีรับจากภายใน จะต้องรันตามชื่อย่อหน่วยงานด้วย
                'เลขรับและส่งภายใน OOO-YY-RRRRRR (OOO=ชื่อย่อหน่วยงาน, YY=2 หลักท้าย ปี.พ.ศ., RRRRRR=Running Number 6 หลัก และ reset เป็น 000001 ทุกวันที่ 1 ของ ปี ) เช่น สบท1-54-123456

                'Select BOOK_RUNNING เพื่อเอาค่า Config
                Dim strcmd As String = ""
                strcmd = "  SELECT run_year, length"
                strcmd += " FROM BOOK_RUNNING"
                strcmd += " WHERE book_type = '" & Para.Common.Utilities.Constant.DocumentRegister.BookRunningType.SendInternal & "' " 'ลงทะเบียนรับจากภายใน
                strcmd += " and org_abb = '" & OrgAbb & "'"

                Dim sqlMax As String = ""
                Dim eng As New Engine.Document.DocumentRegisterENG
                Dim dtmp As DataTable = eng.GetDataListBySql(strcmd, trans)
                If dtmp.Rows.Count > 0 Then
                    Dim drtmp As DataRow = dtmp.Rows(0)
                    Dim leng As Integer = IIf(Convert.IsDBNull(drtmp("length")) = False, drtmp("length"), 6)
                    'yy = IIf(Convert.IsDBNull(drtmp("run_year")) = False, drtmp("run_year"), DateTime.Now.ToString("yy", New Globalization.CultureInfo("th-TH")))

                    sqlMax += " select  MAX(convert(int, SUBSTRING(book_no," & (OrgAbb.Length + 2 + yy.Length + 1) & "," & leng & "))) max_no"
                    sqlMax += " from DOCUMENT_REGISTER"
                    sqlMax += " where CHARINDEX('" & OrgAbb & "',book_no)>0"
                    sqlMax += " and CHARINDEX('/',book_no)=0"
                    sqlMax += " and SUBSTRING(book_no," & (OrgAbb.Length + 2) & "," & yy.Length & ")='" & yy & "'"
                    Dim dt As New DataTable
                    dt = eng.GetDataListBySql(sqlMax, trans)
                    If dt.Rows.Count > 0 Then
                        If Convert.IsDBNull(dt.Rows(0)("max_no")) = False Then
                            If Convert.ToInt64(dt.Rows(0)("max_no")) > 0 Then
                                ret = OrgAbb.Trim & "-" & yy.Trim & "-" & (dt.Rows(0)("max_no") + 1).ToString.PadLeft(leng, "0")
                            Else
                                ret = OrgAbb.Trim & "-" & yy.Trim & "-" & "1".PadLeft(leng, "0")
                            End If
                        Else
                            ret = OrgAbb.Trim & "-" & yy.Trim & "-" & "1".PadLeft(leng, "0")
                        End If
                    Else
                        ret = OrgAbb.Trim & "-" & yy.Trim & "-" & "1".PadLeft(leng, "0")
                    End If
                    dt = Nothing
                    dtmp = Nothing
                Else
                    Dim lnq As New Linq.TABLE.BookRunningLinq
                    lnq.BOOK_TYPE = Para.Common.Utilities.Constant.DocumentRegister.BookRunningType.SendInternal.ToString
                    lnq.LENGTH = 6
                    lnq.RUN_YEAR = yy
                    lnq.ORG_ABB = OrgAbb
                    lnq.InsertData("SYSTEM", trans.Trans)

                    'ret = IIf(OrgAbb.Trim = "", "", OrgAbb & "-") & yy & "-000001"
                    ret = GetBookNo(RegisType, SendType, OrgAbb, trans)
                    lnq = Nothing
                End If
                eng = Nothing

            ElseIf RegisType = "0" And SendType = "I" Then
                'ลงทะเบียนรับจากภายนอก และส่งภายใน
                'รับเป็นเอกสาร YY-RRRRRR (YY=2 หลักท้าย ปี.พ.ศ., RRRRRR=Running Number 6 หลัก และ reset เป็น 000001 ทุกวันที่ 1 ของ ปี ) เช่น 54-123456 

                'Dim dt As New DataTable
                Dim strcmd As String = ""
                strcmd = "  SELECT run_year, length"
                strcmd += " FROM BOOK_RUNNING"
                strcmd += " WHERE book_type = '" & Para.Common.Utilities.Constant.DocumentRegister.BookRunningType.SendInternal & "' " 'ลงทะเบียนรับจากภายใน
                strcmd += " and run_year = '" & yy & "'"
                strcmd += " and isnull(org_abb,'')=''"

                Dim sqlMax As String = ""
                Dim eng As New Engine.Document.DocumentRegisterENG
                Dim dtmp As DataTable = eng.GetDataListBySql(strcmd, trans)
                If dtmp.Rows.Count > 0 Then
                    'Format 55-000001
                    Dim drtmp As DataRow = dtmp.Rows(0)
                    Dim leng As Integer = IIf(Convert.IsDBNull(drtmp("length")) = False, drtmp("length"), 6)
                    'yy = IIf(Convert.IsDBNull(drtmp("run_year")) = False, drtmp("run_year"), DateTime.Now.ToString("yy", New Globalization.CultureInfo("th-TH")))

                    sqlMax += " select MAX(convert(int, SUBSTRING(book_no," & yy.Length + 2 & "," & leng & "))) max_no "
                    sqlMax += " from DOCUMENT_REGISTER"
                    sqlMax += " where CHARINDEX('/',book_no)=0"
                    sqlMax += " and SUBSTRING(book_no,1," & yy.Length & ")='" & yy & "'"
                    Dim dt As New DataTable
                    dt = eng.GetDataListBySql(sqlMax, trans)
                    If dt.Rows.Count > 0 Then
                        If Convert.IsDBNull(dt.Rows(0)("max_no")) = False Then
                            If Convert.ToInt64(dt.Rows(0)("max_no")) > 0 Then
                                ret = yy.Trim & "-" & (dt.Rows(0)("max_no") + 1).ToString.PadLeft(leng, "0")
                            Else
                                ret = yy.Trim & "-" & "1".PadLeft(leng, "0")
                            End If
                        Else
                            ret = yy.Trim & "-" & "1".PadLeft(leng, "0")
                        End If
                    Else
                        ret = yy.Trim & "-" & "1".PadLeft(leng, "0")
                    End If
                    dt = Nothing
                    eng = Nothing
                    dtmp = Nothing
                Else
                    Dim lnq As New Linq.TABLE.BookRunningLinq
                    lnq.BOOK_TYPE = Para.Common.Utilities.Constant.DocumentRegister.BookRunningType.SendInternal.ToString
                    lnq.LENGTH = 6
                    lnq.RUN_YEAR = yy
                    lnq.ORG_ABB = ""
                    lnq.InsertData("SYSTEM", trans.Trans)

                    ret = GetBookNo(RegisType, SendType, OrgAbb, trans)
                    lnq = Nothing
                End If

            ElseIf SendType = "O" And RegisType = "" Then
                'ส่งออกนอกสำนักงาน
                Dim strcmd As String = ""
                strcmd = "  SELECT run_year  , length"
                strcmd += " FROM BOOK_RUNNING"
                strcmd += " WHERE book_type = '" & Para.Common.Utilities.Constant.DocumentRegister.BookRunningType.SendExternal & "' " 'ส่งออกนอกสำนักงาน
                strcmd += " and run_year = '" & yy & "'"
                strcmd += " and org_abb = '" & OrgAbb & "'"

                Dim sqlMax As String = ""
                Dim eng As New Engine.Document.DocumentRegisterENG
                Dim dtmp As DataTable = eng.GetDataListBySql(strcmd, trans)
                If dtmp.Rows.Count > 0 Then
                    Dim StartBookNo As String = "นร " & OrgAbb
                    Dim drtmp As DataRow = dtmp.Rows(0)
                    Dim leng As Integer = IIf(Convert.IsDBNull(drtmp("length")) = False, drtmp("length"), 6)
                    'yy = IIf(Convert.IsDBNull(drtmp("run_year")) = False, drtmp("run_year"), DateTime.Now.ToString("yy", New Globalization.CultureInfo("th-TH")))

                    Dim oEng As New Master.OrganizationEng
                    Dim OrgAbbName As String = oEng.GetOrgParaByOrgCode(OrgAbb).NAME_ABB
                    oEng = Nothing

                    sqlMax += " select MAX(convert(int, SUBSTRING(bookout_no," & (4 + OrgAbb.Length + 1) & "," & leng & "))) max_no "
                    sqlMax += " from DOCUMENT_EXT_RECEIVER"
                    sqlMax += " where CHARINDEX('" & StartBookNo & "',bookout_no,1)=1 "
                    sqlMax += " and CONVERT(varchar(4),send_date,112)='" & DateTime.Now.ToString("yyyy", New Globalization.CultureInfo("en-US")) & "'"
                    sqlMax += " and organization_appname_send='" & OrgAbbName & "'"
                    Dim dt As New DataTable
                    dt = eng.GetDataListBySql(sqlMax, trans)
                    If dt.Rows.Count > 0 Then
                        'อก 0905/000001
                        If Convert.IsDBNull(dt.Rows(0)("max_no")) = False Then
                            If Convert.ToInt64(dt.Rows(0)("max_no")) > 0 Then
                                ret = StartBookNo & "/" & (dt.Rows(0)("max_no") + 1).ToString.PadLeft(leng, "0")
                            Else
                                ret = StartBookNo & "/" & "1".PadLeft(leng, "0")
                            End If
                        Else
                            ret = StartBookNo & "/" & "1".PadLeft(leng, "0")
                        End If
                    Else
                        ret = StartBookNo & "/" & "1".PadLeft(leng, "0")
                    End If

                    dt = Nothing
                    eng = Nothing
                    dtmp = Nothing
                Else
                    Dim lnq As New Linq.TABLE.BookRunningLinq
                    lnq.BOOK_TYPE = Para.Common.Utilities.Constant.DocumentRegister.BookRunningType.SendExternal.ToString
                    lnq.LENGTH = 6
                    lnq.RUN_YEAR = yy
                    lnq.ORG_ABB = OrgAbb
                    lnq.InsertData("SYSTEM", trans.Trans)

                    ret = GetBookNo(RegisType, SendType, OrgAbb, trans)
                    lnq = Nothing
                End If
            End If

            Return ret
        End Function

        Public Shared Function GetRequestNo(ByVal trans As Linq.Common.Utilities.TransactionDB) As String
            'เลขที่คำขอ YYRRRR
            Dim ret As String = ""
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim yy As String = DateTime.Now.ToString("yy", New Globalization.CultureInfo("th-TH"))
            Dim sql As String = ""
            sql += " select max(right(request_no,4)) req_no "
            sql += " from document_register "
            sql += " where LEFT(request_no,2)='" & yy & "' "

            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)
            If dt.Rows.Count > 0 Then
                If Convert.IsDBNull(dt.Rows(0)("req_no")) = False Then
                    ret = yy & (Convert.ToInt64(dt.Rows(0)("req_no")) + 1).ToString.PadLeft(4, "0")
                Else
                    ret = yy & "0001"
                End If
            Else
                ret = yy & "0001"
            End If

            Return ret
        End Function
    End Class
End Namespace

