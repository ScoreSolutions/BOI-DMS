Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Namespace Master
    Public Class RolesMenuEng

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

        Public Function GetAllRolesMenuList() As DataTable
            Dim lnq As New RolesMenuLinq
            Return lnq.GetDataList("1=1", "user_role_id", Nothing)
        End Function
        Public Function GetDataRolesMenuList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New RolesMenuLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function
        Public Function GetRolesMenuPara(ByVal RolesMenuID As Long) As RolesMenuPara
            Dim lnq As New RolesMenuLinq
            Return lnq.GetParameter(RolesMenuID, Nothing)
        End Function
        Public Function DeleteRolesMenuPara(ByVal RolesMenuID As Long, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New RolesMenuLinq
            ret = lnq.DeleteByPK(RolesMenuID, trans.Trans)

            Return ret
        End Function
        Public Function DeleteRolesMenuParaBySql(ByVal sql As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New RolesMenuLinq
            ret = lnq.UpdateBySql(sql, trans.Trans)

            Return ret
        End Function
        Public Function SaveRolesMenu(ByVal para As RolesMenuPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New RolesMenuLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.ROLES_ID = para.ROLES_ID
            lnq.MENU_ID = para.MENU_ID

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


