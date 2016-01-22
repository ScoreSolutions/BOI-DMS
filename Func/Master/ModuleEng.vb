Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Imports Para.Common
Imports System.IO

Namespace Master
    Public Class ModuleEng
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
        Public Function GetAuthModuleList(ByVal uData As UserProfilePara, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            'แสดงรายการโมดูลตามสิทธิ์ของผู้ใช้งาน
            Dim str As String = ""
            str += " select distinct m.id,m.module_code,m.module_name,m.module_toolstip,"
            str += " m.module_desc, m.module_icon, m.module_url, m.order_seq"
            str += " from ROLES_USER ru"
            str += " inner join ROLES_MENU rm on rm.roles_id=ru.roles_id"
            str += " inner join MENU me on me.id=rm.menu_id"
            str += " inner join MODULE m on m.id=me.module_id"
            str += " where ru.login_username='" & uData.UserName & "' and m.active='Y'"
            str += " union all"
            str += " select id, module_code, module_name, module_toolstip, "
            str += " module_desc, module_icon, module_url, order_seq "
            str += " from module "
            str += " where id=2" 'ToDoList Module
            str += " order by order_seq "
            Dim mdl As New ModuleLinq
            Dim dt As DataTable = mdl.GetListBySql(str, trans.Trans)
            mdl = Nothing

            Return dt
        End Function
        Public Function GetModuleListBySql(ByVal sql As String) As DataTable
            Dim lnq As New ModuleLinq
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, Nothing)
            dt = Nothing
            Return dt
        End Function
        Public Function GetAllModuleList(ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim lnq As New ModuleLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("1=1", "module_code", trans.Trans)
            lnq = Nothing
            Return dt
        End Function

        Public Function GetAllModuleList(ByVal orderBy As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim lnq As New ModuleLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("active = 'Y'", orderBy, trans.Trans)
            lnq = Nothing
            Return dt
        End Function
        Public Function GetDataModuleList(ByVal sqlWhere As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim lnq As New ModuleLinq
            Dim sql As String = " select me.id, me.menu_name, me.module_id, m.module_name "
            sql += " from menu me "
            sql += " inner join module m on m.id=me.module_id "
            sql += " where m.active='Y' and me.active='Y'"
            If sqlWhere.Trim <> "" Then
                sql += sqlWhere
            End If
            sql += " order by m.order_seq, me.order_seq "

            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)
            lnq = Nothing
            Return dt
        End Function
        Public Function GetModulePara(ByVal ModuleID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As ModulePara
            Dim lnq As New ModuleLinq
            Dim par As New Para.TABLE.ModulePara
            par = lnq.GetParameter(ModuleID, trans.Trans)
            lnq = Nothing
            Return par
        End Function

        Public Function GetFolderList(ByVal ModuleID As Long, ByVal ParentID As Long, ByVal OrderBy As String) As DataTable
            Dim lnq As New ModuleFolderLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("module_id = " & ModuleID & " and folder_ref_id = " & ParentID, OrderBy, Nothing)
            lnq = Nothing
            Return dt
        End Function

        Public Function SaveModule(ByVal para As ModulePara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New ModuleLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.MODULE_CODE = para.MODULE_CODE
            lnq.MODULE_NAME = para.MODULE_NAME
            lnq.MODULE_DESC = para.MODULE_DESC
            lnq.MODULE_TOOLSTIP = para.MODULE_TOOLSTIP
            lnq.ACTIVE = para.ACTIVE
            lnq.ORDER_SEQ = para.ORDER_SEQ
            If para.MODULE_ICON <> "" Then
                lnq.MODULE_ICON = para.MODULE_ICON
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

            lnq = Nothing

            Return ret
        End Function

    End Class
End Namespace


