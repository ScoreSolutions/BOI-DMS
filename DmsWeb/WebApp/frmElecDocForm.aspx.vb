Imports Engine.Master
Imports System.Data

Partial Class WebApp_frmElecDocForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SetDropdownlist()
            SetDocSubCategory()
        End If
    End Sub

    Private Sub SetDropdownlist()
        SetDocCategory()
    End Sub

    Private Sub SetDocCategory()
        Dim fnc As New DocCategoryEng
        Dim dt As DataTable = fnc.GetDataCategoryList("active='Y'", "category_code")
        cmbDocCategoryID.SetItemList(dt, "category_name", "id")
    End Sub
    Private Sub SetDocSubCategory()
        If cmbDocCategoryID.SelectedValue <> 0 Then
            Dim fnc As New DocSubCategoryEng
            cmbDocSubCategoryID.IsDefaultValue = False
            cmbDocSubCategoryID.SetItemList(fnc.GetDataSubCategoryList("doc_category_id = '" & cmbDocCategoryID.SelectedValue & "' and active='Y' ", "subcategory_code"), "subcategory_name", "id")
        End If
    End Sub

    Protected Sub cmbDocCategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDocCategoryID.SelectedIndexChanged
        If cmbDocCategoryID.SelectedValue <> 0 Then
            SetDocSubCategory()
            SetVisibleForm()
        End If
    End Sub

    Const FormBookOutID As Integer = 1
    Const FormBookInID As Integer = 2
    Const FormBookSealID As Integer = 3
    Const FormBookCommandID As Integer = 4
    Const FormBookRuleID As Integer = 5
    Const FormBookRegulationID As Integer = 6
    Const FormBookNoticeID As Integer = 7
    Const FormBookStateID As Integer = 8
    Const FormBookNewsID As Integer = 9
    Const FormBookAssureID As Integer = 10
    Const FormBookMinutesID As Integer = 11
    Const FormBookNoteID As Integer = 12


    Private Sub SetVisibleForm()
        If cmbDocSubCategoryID.SelectedValue <> 0 Then
            SetAllVisibleFalse()
            If cmbDocSubCategoryID.SelectedValue = FormBookOutID Then
                incBookOut1.Visible = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookInID Then
                incBookIn1.Visible = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookSealID Then
                incBookSeal1.Visible = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookCommandID Then
                incBookCommand1.Visible = True
                incBookCommand1.VisibleAll = False
                incBookCommand1.VisibleCommand = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookRuleID Then
                incBookCommand1.Visible = True
                incBookCommand1.VisibleAll = False
                incBookCommand1.VisibleRule = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookRegulationID Then
                incBookCommand1.Visible = True
                incBookCommand1.VisibleAll = False
                incBookCommand1.VisibleRegulation = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookNoticeID Then
                incBookPublicRelation1.Visible = True
                incBookPublicRelation1.VisibleAll = False
                incBookPublicRelation1.VisibleNotice = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookStateID Then
                incBookPublicRelation1.Visible = True
                incBookPublicRelation1.VisibleAll = False
                incBookPublicRelation1.VisibleState = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookNewsID Then
                incBookPublicRelation1.Visible = True
                incBookPublicRelation1.VisibleAll = False
                incBookPublicRelation1.VisibleNews = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookAssureID Then
                incBookEvidence1.Visible = True
                incBookEvidence1.VisibleAll = False
                incBookEvidence1.VisibleAssure = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookMinutesID Then
                incBookEvidence1.Visible = True
                incBookEvidence1.VisibleAll = False
                incBookEvidence1.VisibleMinutes = True
            ElseIf cmbDocSubCategoryID.SelectedValue = FormBookNoteID Then
                incBookEvidence1.Visible = True
                incBookEvidence1.VisibleAll = False
                incBookEvidence1.VisibleNote = True
            End If
        End If
    End Sub

    Private Sub SetAllVisibleFalse()
        incBookOut1.Visible = False
        incBookIn1.Visible = False
        incBookSeal1.Visible = False
        incBookCommand1.Visible = False
        incBookPublicRelation1.Visible = False
        incBookEvidence1.Visible = False
    End Sub

    Protected Sub cmbDocSubCategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDocSubCategoryID.SelectedIndexChanged
        If cmbDocSubCategoryID.SelectedValue <> 0 Then
            SetVisibleForm()
        End If
    End Sub
End Class
