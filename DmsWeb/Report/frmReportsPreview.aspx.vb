Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Para.Common.Utilities
Imports Engine.Common
Imports System.Data
Imports Linq.Common.Utilities

Partial Class Reports_frmReportsPreview
    Inherits System.Web.UI.Page

    Private Sub PrintReport(ByVal reportName As String)
        If System.IO.File.Exists(Server.MapPath(Para.Common.Utilities.Constant.HomeFolder & "/Report/" & reportName & ".rpt")) = True Then
            Dim rpt As New ReportDocument
            Dim tbLogOn As New TableLogOnInfo
            tbLogOn.ConnectionInfo.ServerName = SqlDB.DataSource
            tbLogOn.ConnectionInfo.DatabaseName = SqlDB.DbName
            tbLogOn.ConnectionInfo.UserID = SqlDB.DbUserID
            tbLogOn.ConnectionInfo.Password = SqlDB.DbPwd

            If SqlDB.ChkConnection = True Then
                rpt.Load(Server.MapPath(Para.Common.Utilities.Constant.HomeFolder & "/Report/" & reportName & ".rpt"))
                rpt.Database.Tables(0).ApplyLogOnInfo(tbLogOn)
                Dim Param() As String = Request.QueryString.AllKeys
                Dim curValue As New ParameterValues
                Dim paraValue As New ParameterDiscreteValue
                For i As Integer = 1 To Param.Length - 1   'Parameter ตัวแรกคือ ReportName ไม่ต้องนับอยู่แล้ว  และ Parameter ตัวสุดท้ายคือ vReportType
                    If Param(i) <> "cmd" And Param(i) <> "page" And Param(i) <> "vReportType" And Param(i) <> "time" Then
                        Try
                            Dim pName As String = Param(i)
                            Dim pValue As String = Request(pName)
                            paraValue.Value = pValue
                            curValue = rpt.ParameterFields(pName).CurrentValues
                            curValue.Add(paraValue)
                            rpt.ParameterFields(pName).CurrentValues = curValue
                        Catch ex As Exception
                            Config.SetAlert(ex.Message, Me)
                        End Try
                    End If
                Next
                CreateReport(rpt, reportName)
            End If

            rpt.Close()
            rpt.Dispose()
            rpt = Nothing
        Else
            CrystalReportViewer1.Visible = False
            Config.SetAlert("Report Not Found", Me)
        End If
    End Sub

    'Private Sub CreateReport(ByVal rpt As ReportDocument, ByVal reportName As String)
    '    Try
    '        With System.Web.HttpContext.Current.Response
    '            .Buffer = False
    '            .ClearContent()
    '            .ClearHeaders()
    '            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, reportName & ".pdf")
    '        End With
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub CreateReport(ByVal rpt As ReportDocument, ByVal reportName As String)
        Dim s As System.IO.MemoryStream
        Try
            With System.Web.HttpContext.Current.Response
                .ClearContent()
                .ClearHeaders()
                s = rpt.ExportToStream(ExportFormatType.PortableDocFormat)
                .ContentType = "application/pdf"
                .AddHeader("Content-Disposition", "inline; filename=" & reportName & ".pdf")
                .BinaryWrite(s.ToArray)
                .End()
            End With
        Catch ex As Exception

        Finally
            s.Flush()
            s.Close()
            s.Dispose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request IsNot Nothing Then
            PrintReport(Request("ReportName"))
        End If
    End Sub

    Protected Sub CrystalReportViewer1_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Unload
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Dispose()
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub
End Class
