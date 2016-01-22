Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Imports System.IO

Namespace Master
    Public Class ModuleFunc
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
        Public Function GetModuleListBySql(ByVal sql As String) As DataTable
            Dim lnq As New ModuleLinq
            Return lnq.GetListBySql(sql, Nothing)
        End Function
        Public Function GetAllModuleList(ByVal trans As Common.DbTrans) As DataTable
            Dim lnq As New ModuleLinq
            Return lnq.GetDataList("1=1", "module_code", trans.Trans)
        End Function

        Public Function GetAllModuleList(ByVal orderBy As String, ByVal trans As Common.DbTrans) As DataTable
            Dim lnq As New ModuleLinq
            Return lnq.GetDataList("active = 'Y'", orderBy, trans.Trans)
        End Function
        Public Function GetDataModuleList(ByVal sqlWhere As String, ByVal orderBy As String, ByVal trans As Common.DbTrans) As DataTable
            Dim lnq As New ModuleLinq
            Return lnq.GetDataList(sqlWhere, orderBy, trans.Trans)
        End Function
        Public Function GetModulePara(ByVal ModuleID As Long, ByVal trans As Common.DbTrans) As ModulePara
            Dim lnq As New ModuleLinq
            Return lnq.GetParameter(ModuleID, trans.Trans)
        End Function

        Public Function GetFolderList(ByVal ModuleID As Long, ByVal ParentID As Long, ByVal OrderBy As String) As DataTable
            Dim lnq As New ModuleFolderLinq
            Return lnq.GetDataList("module_id = " & ModuleID & " and folder_ref_id = " & ParentID, OrderBy, Nothing)
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

            Return ret

        End Function

    End Class
End Namespace


