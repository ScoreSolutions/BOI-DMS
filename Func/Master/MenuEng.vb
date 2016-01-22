Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Imports Para.Common
Imports System.IO
Imports Para.Common.Utilities.Constant.ElecDocStatus

Namespace Master
    Public Class MenuEng

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
        Public Function GetAuthMenuList(ByVal ModuleID As Long, ByVal RefMenuID As Long, ByVal uData As UserProfilePara, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            'แสดงรายการโมดูลตามสิทธิ์ของผู้ใช้งาน
            Dim str As String = ""
            str += " select distinct me.id,me.menu_code,me.menu_name,me.menu_toolstip,"
            str += " me.menu_desc,me.menu_icon,me.menu_url,me.order_seq,me.ref_menu_id"
            str += " from ROLES_USER ru"
            str += " inner join ROLES_MENU rm on rm.roles_id=ru.roles_id"
            str += " inner join MENU me on me.id=rm.menu_id"
            str += " where ru.login_username='" & uData.UserName & "' and me.module_id = " & ModuleID & " and me.active='Y'"
            str += " and me.ref_menu_id = " & RefMenuID
            str += " order by me.order_seq "

            Dim lnq As New MenuLinq
            Dim dt As DataTable = lnq.GetListBySql(str, trans.Trans)
            lnq = Nothing

            Return dt
        End Function
        Public Function GetAllMenuList() As DataTable
            Dim lnq As New MenuLinq
            Return lnq.GetDataList("1=1", "menu_code", Nothing)
        End Function

        Public Function GetDataMenuList(ByVal sqlWhere As String, ByVal orderBy As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim lnq As New MenuLinq
            Return lnq.GetDataList(sqlWhere, orderBy, trans.Trans)
        End Function
        Public Function GetMenuPara(ByVal MENUID As Long) As MenuPara
            Dim lnq As New MenuLinq
            Return lnq.GetParameter(MENUID, Nothing)
        End Function
        Public Function GetMenuListBySql(ByVal sql As String) As DataTable
            Dim lnq As New MenuLinq
            Return lnq.GetListBySql(sql, Nothing)
        End Function

        Public Function SaveMenu(ByVal para As MenuPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New MenuLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If
            lnq.MODULE_ID = para.MODULE_ID
            lnq.MENU_CODE = para.MENU_CODE
            lnq.MENU_NAME = para.MENU_NAME
            lnq.MENU_DESC = para.MENU_DESC
            lnq.MENU_TOOLSTIP = para.MENU_TOOLSTIP
            lnq.ACTIVE = para.ACTIVE
            lnq.MENU_URL = para.MENU_URL
            lnq.ORDER_SEQ = para.ORDER_SEQ

            If para.MENU_ICON <> "" Then
                lnq.MENU_ICON = para.MENU_ICON
            End If

            If para.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If

            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            _ID = lnq.ID

            Return ret
        End Function

        Public Function GetNewCheckIcon(ByVal uPara As Para.Common.UserProfilePara, ByVal MenuID As String, ByVal trans As TransactionDB) As String
            Dim ret As String = ""
            Dim sql As String = "select count(id) qty from doc_trans"
            sql += " where doc_to = '" + uPara.OFFICER_DATA.ID.ToString + "'"
            sql += " and ((doc_obj_to = '" & Para.Common.Utilities.Constant.DocObjective.OjbKnow & "' "
            sql += " and doc_status in ('" & cfg_docstart & "','" & cfg_docnoapproveedit & "'))"
            sql += " or (doc_obj_to = '" & Para.Common.Utilities.Constant.DocObjective.ObjApprove & "' and doc_status = '" & cfg_docnoapprove & "'))"
            sql += " and is_send='N'"

            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql, trans.Trans)
            If dt.Rows.Count > 0 Then
                If Convert.ToInt64(dt.Rows(0)("qty")) > 0 Then
                    ret = "<img src='../Images/Menu/new_msg.gif'border='0' width='18' />"
                End If
            End If
            dt = Nothing
            Return ret
        End Function

        Public Function GetNewApproveIcon(ByVal uPara As Para.Common.UserProfilePara, ByVal MenuID As String, ByVal trans As TransactionDB) As String
            Dim ret As String = ""
            Dim sql As String = "select count(id) qty from doc_trans"
            sql += " where  doc_to = '" + uPara.OFFICER_DATA.ID.ToString + "'"
            sql += " and doc_status = '" & cfg_docstart & "' "
            sql += " and doc_obj_to = '" & Para.Common.Utilities.Constant.DocObjective.ObjApprove & "' "
            sql += " and is_send='N'"

            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql, trans.Trans)
            If dt.Rows.Count > 0 Then
                If Convert.ToInt64(dt.Rows(0)("qty")) > 0 Then
                    ret = "<img src='../Images/Menu/new_msg.gif' border='0' width='18' />"
                End If
            End If
            dt = Nothing
            Return ret
        End Function

        Public Function GetNewRegisIcon(ByVal uPara As Para.Common.UserProfilePara, ByVal MenuID As String, ByVal trans As TransactionDB) As String
            Dim ret As String = ""
            Dim sql As String = "select count(id) qty from doc_trans"
            sql += " where  doc_to = '" + uPara.OFFICER_DATA.ID.ToString + "'"
            sql += " and doc_status = '" & cfg_docapproved & "' "
            sql += " and doc_obj_to = '" & Para.Common.Utilities.Constant.DocObjective.ObjApprove & "' "
            sql += " and is_send='N'"
            sql += " and id not in (select electronic_doc_id from document_register)"

            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql, trans.Trans)
            If dt.Rows.Count > 0 Then
                If Convert.ToInt64(dt.Rows(0)("qty")) > 0 Then
                    ret = "<img src='../Images/Menu/new_msg.gif' border='0' width='18' />"
                End If
            End If
            dt = Nothing
            Return ret
        End Function
    End Class
End Namespace

