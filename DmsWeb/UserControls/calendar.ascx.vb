Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Partial Class UserControls_calendar
    Inherits System.Web.UI.UserControl
    Public WriteOnly Property VisibleDate() As String
        Set(ByVal value As String)
            Calendar1.VisibleDate = Convert.ToDateTime(value)
        End Set
    End Property
    Private Function GetEvents() As DataTable

        Dim dt As DataTable

        Dim fnc As New MenuEng
        'Dim i As DateTime = "24/8/2554 17:39:45"

        dt = fnc.GetMenuListBySql("select id ,EventStartDate,EventEndDate,EventDescription,EventHeader,EventBackColor,EventForeColor from calendar")

        Return dt

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'Calendar1.VisibleDate = Convert.ToDateTime("01-Oct-07")

        Calendar1.EventStartDateColumnName = "EventStartDate"
        Calendar1.EventEndDateColumnName = "EventEndDate"
        Calendar1.EventDescriptionColumnName = "EventDescription"
        Calendar1.EventHeaderColumnName = "EventHeader"

        Calendar1.EventBackColorName = "EventBackColor"
        Calendar1.EventForeColorName = "EventForeColor"
        Calendar1.ToolTip = "EventDescription"

        Calendar1.EventSource = GetEvents()
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        zPop.Show()
        Dim theDates As SelectedDatesCollection = Calendar1.SelectedDates
        Dim dtSelectedDateEvents As New DataTable
        dtSelectedDateEvents = Calendar1.EventSource.Clone()
        Dim dr As DataRow

        For Each drEvent As DataRow In Calendar1.EventSource.Rows
            For Each selectedDate As DateTime In theDates
                If selectedDate.[Date] >= (Convert.ToDateTime(drEvent(Calendar1.EventStartDateColumnName))).[Date] AndAlso selectedDate.[Date] <= (Convert.ToDateTime(drEvent(Calendar1.EventEndDateColumnName))).[Date] Then
                    ' This Condition is just to ensure that Every Event Details are added just only once
                    ' irrespective of the number of days for which the event occurs.
                    If dtSelectedDateEvents.[Select]("Id= " & Convert.ToInt32(drEvent("Id"))).Length > 0 Then
                        Continue For
                    End If

                    dr = dtSelectedDateEvents.NewRow()
                    dr("Id") = drEvent("Id")
                    dr(Calendar1.EventStartDateColumnName) = drEvent(Calendar1.EventStartDateColumnName)
                    dr(Calendar1.EventEndDateColumnName) = drEvent(Calendar1.EventEndDateColumnName)
                    dr(Calendar1.EventHeaderColumnName) = drEvent(Calendar1.EventHeaderColumnName)
                    dr(Calendar1.EventDescriptionColumnName) = drEvent(Calendar1.EventDescriptionColumnName)

                    dr(Calendar1.EventForeColorName) = drEvent(Calendar1.EventForeColorName)
                    dr(Calendar1.EventBackColorName) = drEvent(Calendar1.EventBackColorName)


                    dtSelectedDateEvents.Rows.Add(dr)
                End If
            Next
        Next

        gvSelectedDateEvents.DataSource = dtSelectedDateEvents
        gvSelectedDateEvents.DataBind()

    End Sub

End Class
