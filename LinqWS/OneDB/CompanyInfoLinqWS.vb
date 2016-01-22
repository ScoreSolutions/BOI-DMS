Imports LinqWS.BCMLinqWS
Imports System.IO

Namespace OneDB
    Public Class CompanyInfoLinqWS
        'Dim _WsUrl As String = "http://119.63.77.24/BCD-EXT/webservice_api.php"
        'Public WriteOnly Property WsURL() As String
        '    Set(ByVal value As String)
        '        _WsUrl = value
        '    End Set
        'End Property
        Private Function GetCompanyList(ByVal WsUrl As String) As DataTable
            Dim ret As New DataTable
            ret.Columns.Add("comnameth")
            ret.Columns.Add("comnameen")
            ret.Columns.Add("comcode")
            ret.Columns.Add("address")
            ret.Columns.Add("comtype")
            ret.Columns.Add("cardInfo", GetType(DataTable))

            Dim Err As String = ""
            Dim ws As New BCMLinqWS.BCD
            ws.Url = WsUrl
            Dim Tmpret() As returnComInfo
            ws.getXMLCompanyInfo_func("dmsxml", "xml@dms", Nothing, Nothing, Nothing, Nothing, Err, Nothing, Nothing, Tmpret)

            If Err = "SUCCESS" Then
                If Tmpret.Length > 0 Then
                    For i As Integer = 0 To Tmpret.Length - 1
                        Dim dr As DataRow = ret.NewRow
                        dr("comnameth") = Tmpret(i).comnameth
                        dr("comnameen") = Tmpret(i).comnameen
                        dr("comcode") = Tmpret(i).comcode
                        If Tmpret(i).address IsNot Nothing Then
                            dr("address") = Tmpret(i).address
                        End If
                        dr("comtype") = Tmpret(i).comtype

                        Dim cardInfo() As returnCardInfo
                        cardInfo = Tmpret(i).cardcount
                        If cardInfo.Length > 0 Then
                            Dim cardDt As New DataTable
                            cardDt.TableName = "returnCardInfo"
                            cardDt.Columns.Add("cardtype")
                            cardDt.Columns.Add("cardno")
                            cardDt.Columns.Add("cardcode")
                            For j As Integer = 0 To cardInfo.Length - 1
                                Dim cDr As DataRow = cardDt.NewRow
                                cDr("cardtype") = cardInfo(j).cardtype
                                cDr("cardno") = cardInfo(j).cardno
                                cDr("cardcode") = cardInfo(j).cardcode
                                cardDt.Rows.Add(cDr)
                            Next
                            dr("cardInfo") = cardDt
                        End If
                        ret.Rows.Add(dr)
                    Next
                End If
            End If

            ret.TableName = "CustomerList"
            Return ret
        End Function

        Public Function GetCompanyList(ByVal ComName As String, ByVal WsUrl As String) As DataTable
            Dim dt As New DataTable
            dt = GetCompanyList(WsUrl)
            dt.DefaultView.RowFilter = "comnameth like '%" & ComName & "%' or comnameen like '%" & ComName & "%'"
            dt = dt.DefaultView.ToTable

            Return dt
        End Function

        'Private Function DecodeData(ByVal SrcTxt As String) As String
        '    Dim ret As String = ""
        '    Dim SrcEnc As System.Text.Encoding = System.Text.Encoding.GetEncoding("TIS-620")
        '    Dim DesEnc As System.Text.Encoding = System.Text.Encoding.ASCII

        '    Dim unicodeBytes() As Byte = System.Text.Encoding.Convert(SrcEnc, DesEnc, SrcEnc.GetBytes(SrcTxt))
        '    File.WriteAllBytes("D:\Text.text", unicodeBytes)
        '    Dim outputString As String = DesEnc.GetString(unicodeBytes)
        '    Return outputString
        'End Function
    End Class
End Namespace


