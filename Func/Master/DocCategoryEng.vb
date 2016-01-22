Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities

Namespace Master
    Public Class DocCategoryEng
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

        Public Function GetAllCategoryList() As DataTable
            Dim lnq As New DocCategoryLinq
            Return lnq.GetDataList("1=1", "category_code", Nothing)
        End Function
        Public Function GetDataCategoryList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New DocCategoryLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function
        Public Function GetDocCategoryPara(ByVal DocCateGoryID As Long) As DocCategoryPara
            Dim lnq As New DocCategoryLinq
            'lnq = lnq.GetDataByPK(DocCateGoryID, Nothing)
            'Dim dt As DataTable = lnq.GetDataList("1=1", "", Nothing)
            Return lnq.GetParameter(DocCateGoryID, Nothing)
        End Function

        Public Function SaveDocCategory(ByVal para As DocCategoryPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New DocCategoryLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.CATEGORY_CODE = para.CATEGORY_CODE
            lnq.CATEGORY_NAME = para.CATEGORY_NAME
            lnq.ACTIVE = para.ACTIVE

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
        Public Function DeleteDocCategory(ByVal vID As Long) As String
            Dim ret As String = ""
            Dim lnq As New DocCategoryLinq
            Dim para As New DocCategoryPara
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            lnq.DeleteByPK(vID, trans.Trans)

            If lnq.ErrorMessage <> "" Then
                trans.RollbackTransaction()
                ret = lnq.ErrorMessage
            Else
                trans.CommitTransaction()
            End If

            Return ret
        End Function
    End Class
End Namespace

