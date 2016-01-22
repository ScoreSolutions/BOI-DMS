Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.VIEW
Imports Linq.Common.Utilities
Namespace Master
    Public Class DocSubCategoryEng
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

        Public Function GetAllSubCategoryList() As DataTable
            Dim lnq As New DocSubcategoryLinq
            Return lnq.GetDataList("1=1", "subcategory_code", Nothing)
        End Function
        Public Function GetDataSubCategoryList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New VDocSubcategoryLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function
        Public Function GetDocSubCategoryPara(ByVal DocSubCategoryID As Long) As DocSubcategoryPara
            Dim lnq As New DocSubcategoryLinq
            Return lnq.GetParameter(DocSubCategoryID, Nothing)
        End Function

        Public Function ChkDupDocSubCategory(ByVal vID As Long, ByVal vCode As String, ByVal vName As String) As String
            Dim ret As String = ""
            Dim lnq As New DocSubcategoryLinq
            Dim trans As New TransactionDB
            trans.CreateTransaction()
            If lnq.ChkDuplicateBySUBCATEGORY_CODE(vCode, vID, trans.Trans) = True Then
                ret = "รหัสประเภทย่อยหนังสือซ้ำ"
            ElseIf lnq.ChkDuplicateBySUBCATEGORY_NAME(vName, vID, trans.Trans) = True Then
                ret = "ชื่อประเภทย่อยหนังสือซ้ำ"
            End If
            trans.CommitTransaction()

            Return ret
        End Function

        Public Function SaveDocSubCategory(ByVal para As DocSubcategoryPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New DocSubcategoryLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.DOC_CATEGORY_ID = para.DOC_CATEGORY_ID
            lnq.SUBCATEGORY_CODE = para.SUBCATEGORY_CODE
            lnq.SUBCATEGORY_NAME = para.SUBCATEGORY_NAME
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
        Public Function DeleteDocSubCategory(ByVal vID As Long) As String
            Dim ret As String = ""
            Dim lnq As New DocSubcategoryLinq
            Dim para As New DocSubcategoryPara
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

