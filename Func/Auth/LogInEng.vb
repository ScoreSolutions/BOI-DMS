Imports Linq.TABLE
Imports Para.TABLE
Imports Para.Common
Imports System.Web
Imports Engine.Master
Imports Engine.Common

Namespace Auth

    Public Class LogInEng
        Dim _err As String = ""


        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        Public Function CheckLogin(ByVal UserName As String, ByVal Pwd As String) As Boolean
            Dim ret As Boolean = False
            If UserName.Trim = "" Then
                _err = "กรุณาระบุชื่อเข้าระบบ"
            ElseIf Pwd.Trim = "" Then
                _err = "กรุณาระบุรหัสผ่าน"
            Else
                UserName = UserName.Replace("'", "''")
                Pwd = FunctionENG.EncryptText(Pwd.Replace("'", "''"))

                Dim lnq As New Linq.TABLE.OfficerLinq
                Dim dt As New DataTable
                Dim wh As String = "username = '" & UserName & "' and pwd = '" & Pwd & "'"
                wh += " and getdate() between efdate and epdate "

                dt = lnq.GetDataList(wh, "", Nothing)
                If dt.Rows.Count > 0 Then
                    ret = True
                    dt = Nothing
                Else
                    _err = "ชื่อเข้าระบบหรือรหัสผ่านไม่ถูกต้อง"
                End If
                lnq = Nothing
            End If
            Return ret
        End Function

        Public Shared Function CheckUserRole(ByVal UserName As String, ByVal RoleID As Long) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New Linq.TABLE.RolesUserLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("roles_id = '" & RoleID & "' and login_username = '" & UserName & "'", "", trans.Trans)
            trans.CommitTransaction()
            If dt.Rows.Count > 0 Then
                ret = True
                dt = Nothing
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Shared Function GetLoginHistoryPara(ByVal vLoginHisID As Long) As LoginHistoryPara
            Dim lnq As New LoginHistoryLinq
            Dim p As New LoginHistoryPara
            p = lnq.GetParameter(vLoginHisID, Nothing)
            lnq = Nothing
            Return p
        End Function

        'Public Function GetMenuList(ByVal uData As UserProfilePara) As String
        '    Dim ret As String = ""
        '    Dim trans As New Func.Common.DbTrans
        '    trans.CreateTransaction()
        '    Dim strHTML As String = ""
        '    strHTML &= " <div class=""applemenu"">"

        '    Dim fnc As New ModuleFunc
        '    Dim fncMenu As New MenuFunc
        '    Dim dt As DataTable
        '    If uData.UserName = "akkarawat" Then
        '        'ถ้าเป็น User ของกั๊ก ก็ให้เข้าได้ทุกเมนูเลย
        '        dt = fnc.GetAllModuleList("order_seq, module_name", trans)
        '    Else
        '        dt = fnc.GetAuthModuleList(uData, trans)
        '    End If
        '    For Each dr As DataRow In dt.Rows

        '        Dim para As ModulePara
        '        para = fnc.GetModulePara(dr("id"), trans)

        '        strHTML &= " <div class=""silverheader"">"
        '        If para.MODULE_URL <> "#" And para.MODULE_URL <> "" Then
        '            strHTML &= " <a href=" & Chr(34) & para.MODULE_URL & Chr(34) & " OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & para.MODULE_NAME & Chr(39) & ");"" >" & para.MODULE_NAME.ToString & "</a>"
        '        Else
        '            strHTML &= para.MODULE_NAME.ToString
        '        End If
        '        strHTML &= "</div>"
        '        strHTML &= CreateMenuList(dr("id"), 0, trans, uData)

        '    Next

        '    strHTML &= "</div>"
        '    ret = strHTML
        '    trans.CommitTransaction()

        '    Return ret

        'End Function

        'Private Function CreateMenuList(ByVal ModuleID As Long, ByVal RefMenuID As Long, ByVal trans As DbTrans, ByVal uData As UserProfilePara) As String
        '    Dim fnc As New MenuFunc
        '    Dim dt As DataTable
        '    If uData.UserName = "akkarawat" Then
        '        'ถ้าเป็น User ของกั๊ก ก็ให้เข้าได้ทุกเมนูเลย
        '        dt = fnc.GetDataMenuList("module_id=" & ModuleID & " and ref_menu_id = " & RefMenuID & " and active='Y' ", "order_seq, menu_name", trans)
        '    Else
        '        dt = fnc.GetAuthMenuList(ModuleID, uData, trans)
        '    End If

        '    Dim strHTML As String = ""
        '    If (dt.Rows.Count > 0) Then
        '        strHTML &= " <div class=""submenu"">"
        '        For Each dr In dt.Rows
        '            strHTML &= " <img src=" & dr("menu_icon") & " border=0>&nbsp;"

        '            If dr("menu_url").ToString <> "#" And dr("menu_url").ToString <> "" Then
        '                strHTML &= " <a href=" & Chr(34) & dr("menu_url") & Chr(34) & " OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & dr("menu_name") & Chr(39) & ");"" >" & dr("menu_name") & "</a><br/>"
        '            Else
        '                strHTML &= " <a href=" & Chr(34) & dr("menu_url") & Chr(34) & " >" & dr("menu_name") & "</a><br/>"
        '            End If
        '            strHTML &= CreateMenuList(ModuleID, dr("id"), trans, uData)
        '        Next
        '        strHTML &= " </div>"
        '    End If
        '    Return strHTML
        'End Function

    End Class
End Namespace
