Imports System.IO
Imports Para.Common

Partial Class UserControls_ctlBrowseFile
    Inherits System.Web.UI.UserControl

    Public Event Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property TmpFileUploadPara() As TmpFileUploadPara
        Get
            Return Session("TmpFileData")
        End Get
        Set(ByVal value As TmpFileUploadPara)
            Session("TmpFileData") = value
        End Set
    End Property

    Public Property Width() As Unit
        Get
            Return FileBrowse.Width
        End Get
        Set(ByVal value As Unit)
            FileBrowse.Width = value
        End Set
    End Property

    Public ReadOnly Property HasFile() As Boolean
        Get
            Return (Session("TmpFileData") IsNot Nothing)
        End Get
        
    End Property

    Public Property VisibleUploadButton() As Boolean
        Get
            Return Button1.Visible
        End Get
        Set(ByVal value As Boolean)
            Button1.Visible = value
        End Set
    End Property

    Protected Sub FileBrowse_UploadedComplete(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles FileBrowse.UploadedComplete
        If e.state = AjaxControlToolkit.AsyncFileUploadState.Success Then
            Dim FileProp As New FileInfo(FileBrowse.FileName)
            Dim fData As New TmpFileUploadPara
            fData.TmpFileByte = FileBrowse.FileBytes
            fData.FileExtent = FileProp.Extension
            Session("TmpFileData") = fData
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent Upload_Click(sender, e)
    End Sub

    Public Sub ClearFile()
        Session.Contents.Remove("TmpFileData")
    End Sub

    'Public Sub SaveFile(ByVal fileName As String)
    '    If Session("TmpFileData") IsNot Nothing Then
    '        Dim fs As FileStream
    '        Dim byteData() As Byte
    '        Dim fData As New TmpFileUploadPara
    '        fData = Session("TmpFileData")
    '        byteData = fData.TmpFileByte

    '        fs = New FileStream(Config.GetUploadPath & fileName, FileMode.CreateNew)
    '        fs.Write(byteData, 0, byteData.Length)
    '        fs.Close()
    '        Session.Contents.Remove("TmpFileData")
    '    End If
    'End Sub
End Class
