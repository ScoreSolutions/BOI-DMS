Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities

Namespace ModuleFolder
    Public Class ModuleFolderEng

        Dim _err As String = ""
        Dim _ID As Long

        Public Function GetFolderList(ByVal RefID As Long, ByVal trans As TransactionDB) As DataTable
            Dim lnq As New ModuleFolderLinq
            Return lnq.GetDataList("folder_ref_id = " & RefID, "folder_name", trans.Trans)
        End Function
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

        Public Function GetAllModuleFolderList() As DataTable
            Dim lnq As New ModuleFolderLinq
            Return lnq.GetDataList("1=1", "module_id", Nothing)
        End Function
        Public Function GetDataModuleFolderList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New ModuleFolderLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function
        Public Function GetModuleFolderPara(ByVal ModuleFolderID As Long) As ModuleFolderPara
            Dim lnq As New ModuleFolderLinq

            Return lnq.GetParameter(ModuleFolderID, Nothing)
        End Function
        Public Function SaveModuleFolder(ByVal para As ModuleFolderPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New ModuleFolderLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If
            lnq.MODULE_ID = para.MODULE_ID
            lnq.FOLDER_NAME = para.FOLDER_NAME
            lnq.FOLDER_TOOLSTIP = para.FOLDER_TOOLSTIP
            lnq.FOLDER_DESC = para.FOLDER_DESC
            lnq.FOLDER_URL = para.FOLDER_URL
            lnq.FOLDER_REF_ID = para.FOLDER_REF_ID
            lnq.ORDER_SEQ = para.ORDER_SEQ
            lnq.ACTIVE = para.ACTIVE

            If para.FOLDER_ICON <> "" Then
                lnq.FOLDER_ICON = para.FOLDER_ICON
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
        Public Function GetPersonalFolderList(ByVal UserID As Long) As DataTable
            Dim dt As New DataTable
            Dim lnq As New ModuleFolderLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            dt = lnq.GetDataList("officer_id_owner = " & UserID & " and active = 'Y'", "order_seq", trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function CreateLinkFolderList(ByVal UserID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim dt As New DataTable
            Dim lnq As New ModuleFolderLinq
            dt = lnq.GetDataList("officer_id_owner = " & UserID & " and active = 'Y' and folder_ref_id = '0' ", "order_seq", trans.Trans)

            Return dt
        End Function

    End Class
End Namespace
