Imports System.IO
Public Class frmTestSendFileToWebService

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim fbd As New OpenFileDialog
        Dim result As DialogResult = fbd.ShowDialog
        If result = DialogResult.OK Then
            txtFile.Text = fbd.FileName
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            If IO.File.Exists(txtFile.Text) = True Then
                'Dim ff As New IO.FileInfo(txtFile.Text)
                'Dim ws As New TestWSSendFile.DmsDocScanWebService
                'ws.Url = "http://dms.boi.go.th/TestWebServiceDMS/DmsDocScanWebService.asmx?WSDL"
                'ws.Timeout = 1200 * 1000
                'ws.SendFileToServer(IO.File.ReadAllBytes(txtFile.Text), ff.Name)
                'ws = Nothing
                'ff = Nothing



                Dim ret As Boolean = False
                Dim ff As New IO.FileInfo(txtFile.Text)
                Dim ws As New TestWSSendFile.DmsDocScanWebService
                'ws.Url = "http://10.0.0.147/TestWebServiceDMS/DmsDocScanWebService.asmx?WSDL"
                ws.Timeout = 120 * 1000

                ws.DeleteIsDuplicateFile(ff.Name)
                Dim Stream As IO.FileStream = File.OpenRead(txtFile.Text)
                Dim data As Byte() = New Byte((1024 * 16) - 1) {}
                Dim i As Integer = 1
                Dim remaining As Integer = Stream.Length

                While remaining > 0
                    Try
                        If remaining < data.Length Then
                            data = New Byte(remaining - 1) {}
                        End If
                        Dim read As Integer = Stream.Read(data, 0, data.Length)
                        ret = ws.SendFileStreamToServer(Convert.ToBase64String(data), ff.Name, i)
                        If ret = False Then
                            Exit While
                        End If
                    Catch ex As Exception
                        ret = False
                        Exit While
                    End Try
                    remaining -= data.Length
                    i += 1
                End While
                Stream.Close()
                ws.ConvertStringFileToByte(ff.Name)

                ws = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
