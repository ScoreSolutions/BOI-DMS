Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class UserControls_Button_btnRecieveAndSendIn
    Inherits System.Web.UI.UserControl
    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event ConfirmSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara)
    Public Event AfterSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara)

    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        RaiseEvent Click(sender, e)
    End Sub

    Public Sub ShowPop(ByVal para As Para.Document.SendInternalSelectedPara)
        popSendInside1.SetDocRegisID(para.SelectedRowID)
        popSendInside1.SetBookNO(para.SelectedBookNo)
        popSendInside1.ShowPop()
    End Sub

    Protected Sub popSendInside1_AfterSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles popSendInside1.AfterSendInside
        RaiseEvent AfterSendInside(sender, e, uPara)
    End Sub

    Protected Sub popSendInside1_ConfirmSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles popSendInside1.ConfirmSendInside
        RaiseEvent ConfirmSendInside(sender, e, uPara)
    End Sub
End Class