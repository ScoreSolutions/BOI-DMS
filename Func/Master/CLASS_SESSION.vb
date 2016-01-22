Imports System.Collections.Generic
Imports System.Text
Imports System.Web.SessionState

Public Class CLASS_SESSION
    Inherits System.Web.UI.Page
    Private prefix As String = ""

    Public Sub New(ByVal myPrefix As String)
        prefix = myPrefix
        If Session("session_" & prefix & "_order") Is Nothing Then
            Session("session_" & prefix & "_order") = ""
        End If
        If Session("session_" & prefix & "_orderField") Is Nothing Then
            Session("session_" & prefix & "_orderField") = ""
        End If
        If Session("session_" & prefix & "_search") Is Nothing Then
            Session("session_" & prefix & "_search") = ""
        End If

        If Session("session_" & prefix & "_currentPage") Is Nothing Then
            Session("session_" & prefix & "_currentPage") = ""
        End If

        If Session("session_" & prefix & "_pageSize") Is Nothing Then
            Session("session_" & prefix & "_pageSize") = ""
        End If

        If Session("session_" & prefix & "_conditionAll") Is Nothing Then
            Session("session_" & prefix & "_conditionAll") = ""

        End If
    End Sub

    Public Sub ResetSession()

        If prefix IsNot Nothing Then
            If Session("session_" & prefix & "_order") IsNot Nothing Then
                Session("session_" & prefix & "_order") = ""
            End If


            If Session("session_" & prefix & "_orderField") IsNot Nothing Then
                Session("session_" & prefix & "_orderField") = ""
            End If


            If Session("session_" & prefix & "_search") IsNot Nothing Then
                Session("session_" & prefix & "_search") = ""
            End If

            If Session("session_" & prefix & "_currentPage") IsNot Nothing Then
                Session("session_" & prefix & "_currentPage") = ""
            End If

            If Session("session_" & prefix & "_pageSize") IsNot Nothing Then
                Session("session_" & prefix & "_pageSize") = ""
            End If

            If Session("session_" & prefix & "_conditionAll") IsNot Nothing Then
                Session("session_" & prefix & "_conditionAll") = ""



            End If
        End If


    End Sub

    Public Function GetOrder() As String
        If Session("session_" & prefix & "_order") IsNot Nothing Then

            Return Session("session_" & prefix & "_order").ToString()
        Else
            Return ""
        End If

    End Function
    Public Sub SetOrder(ByVal objValue As String)
        Session("session_" & prefix & "_order") = objValue

    End Sub

    Public Function GetOrderField() As String
        If Session("session_" & prefix & "_orderField") IsNot Nothing Then

            Return Session("session_" & prefix & "_orderField").ToString()
        Else
            Return ""
        End If


    End Function
    Public Sub SetOrderField(ByVal objValue As String)
        Session("session_" & prefix & "_orderField") = objValue

    End Sub

    Public Function GetKeySearch() As String
        If Session("session_" & prefix & "_search") IsNot Nothing Then

            Return Session("session_" & prefix & "_search").ToString()
        Else
            Return ""
        End If


    End Function
    Public Sub SetKeySearch(ByVal objValue As String)
        Session("session_" & prefix & "_search") = objValue

    End Sub

    Public Function GetConditionAll() As String
        If Session("session_" & prefix & "_conditionAll") IsNot Nothing Then
            Return Session("session_" & prefix & "_conditionAll").ToString()
        Else
            Return ""
        End If
    End Function
    Public Sub SetConditionAll(ByVal objValue As String)
        Session("session_" & prefix & "_conditionAll") = objValue

    End Sub


    Public Function GetPageSize() As String
        If Session("session_" & prefix & "_pageSize") IsNot Nothing AndAlso Session("session_" & prefix & "_pageSize").ToString() <> "" AndAlso Session("session_" & prefix & "_pageSize").ToString() <> "0" Then

            Return Session("session_" & prefix & "_pageSize").ToString()
        Else
            Return "20"
        End If

    End Function
    Public Sub SetPageSize(ByVal objValue As String)
        Session("session_" & prefix & "_pageSize") = objValue

    End Sub

    Public Function GetCurrentPage() As String
        If Session("session_" & prefix & "_currentPage") IsNot Nothing Then

            Return Session("session_" & prefix & "_currentPage").ToString()
        Else
            Return "1"
        End If


    End Function
    Public Sub SetCurrentPage(ByVal objValue As String)
        Session("session_" & prefix & "_currentPage") = objValue

    End Sub



End Class

