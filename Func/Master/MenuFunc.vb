Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Imports System.IO
Namespace Master
    Public Class MenuFunc

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

        Public Function GetAllMenuList() As DataTable
            Dim lnq As New MenuLinq
            Return lnq.GetDataList("1=1", "menu_code", Nothing)
        End Function

        Public Function GetDataMenuList(ByVal sqlWhere As String, ByVal orderBy As String, ByVal trans As Common.DbTrans) As DataTable
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

    End Class
End Namespace

