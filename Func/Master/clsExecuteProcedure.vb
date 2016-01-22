Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Diagnostics
Imports System.Data.SqlClient

Public Class clsExecuteProcedure
    Inherits clsDB
    Private objDB As New clsDB()
    Private objLog As New clsLog()
    Private objDate As New clsFormateDateTime()

#Region "Global Function"
    Public Function GetDataByExpression(ByVal sourceTable As String, ByVal key As String, ByVal value As String) As DataTable

        Dim dt As New DataTable()
        Try

            openDB()


            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "GetDataByExpression"
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.AddWithValue("SourceTable", sourceTable)
            objCmd.Parameters.AddWithValue("Key", key)
            objCmd.Parameters.AddWithValue("Value", value)

            Dim dataAda As New SqlDataAdapter(objCmd)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing Then
                dt = ds.Tables(0)
            End If

            dataAda.Dispose()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt


    End Function

#End Region

#Region "Authen & Menu"
    Public Function GetMenuLevel_2(ByVal groupID As Integer, ByVal parentID As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            If groupID <> 0 AndAlso parentID <> 0 Then
                openDB()


                '========== ==========

                objCmd = objConn.CreateCommand()
                objCmd.CommandText = "GetMenuLevel_2"
                objCmd.CommandType = CommandType.StoredProcedure
                objCmd.Parameters.AddWithValue("groupID", groupID)
                objCmd.Parameters.AddWithValue("parentID", parentID)

                Dim dataAda As New SqlDataAdapter(objCmd)
                Dim ds As New DataSet()
                dataAda.Fill(ds)
                If ds IsNot Nothing Then
                    dt = ds.Tables(0)
                End If


                dataAda.Dispose()
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt


    End Function
    Public Function GetMenuByID(ByVal menuID As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            If menuID <> 0 Then
                openDB()


                '========== ==========

                objCmd = objConn.CreateCommand()
                objCmd.CommandText = "GetMenuByID"
                objCmd.CommandType = CommandType.StoredProcedure
                objCmd.Parameters.AddWithValue("MenuID", menuID)

                Dim dataAda As New SqlDataAdapter(objCmd)
                Dim ds As New DataSet()
                dataAda.Fill(ds)
                If ds IsNot Nothing Then
                    dt = ds.Tables(0)
                End If


                dataAda.Dispose()
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt


    End Function
    Public Function GetUserAuthen(ByVal menuID As Integer, ByVal groupID As Integer) As Integer
        ' DataTable dt = new DataTable();
        Try
            If menuID <> 0 Then
                openDB()


                '========== ==========

                objCmd = objConn.CreateCommand()
                objCmd.CommandText = "GetUserAuthen"
                objCmd.CommandType = CommandType.StoredProcedure
                objCmd.Parameters.AddWithValue("MenuID", menuID)
                objCmd.Parameters.AddWithValue("GroupID", groupID)
                Dim returnValue As Object = objCmd.ExecuteScalar()
                If returnValue IsNot Nothing Then
                    Return Convert.ToInt16(returnValue)

                End If
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return 0


    End Function

#End Region

#Region "Master Setup User Group"
    Public Sub DeleteUserPermission(ByVal GroupID As Integer)
        objDB.ExecuteNonequery(" delete from UserPermission where GroupID=" & GroupID)

    End Sub
    Public Sub InsertPermission(ByVal menuID As String, ByVal userGroupID As String, ByVal permissionType As String)
        Dim sqlInsert As String = " INSERT INTO UserPermission(MenuID,GroupID,PermissionType) "
        sqlInsert += " VALUES('" & menuID & "','" & userGroupID & "','" & permissionType & "')"
        objDB.ExecuteNonequery(sqlInsert)

    End Sub
    Public Function GetUserGroupById(ByVal groupID As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            If groupID <> 0 Then
                openDB()


                '========== ==========

                objCmd = objConn.CreateCommand()
                objCmd.CommandText = "GetUserGroupByID"
                objCmd.CommandType = CommandType.StoredProcedure
                objCmd.Parameters.AddWithValue("GroupID", groupID)

                Dim dataAda As New SqlDataAdapter(objCmd)
                Dim ds As New DataSet()
                dataAda.Fill(ds)
                If ds IsNot Nothing Then
                    dt = ds.Tables(0)
                End If


                dataAda.Dispose()
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt


    End Function
#End Region

#Region "Master Setup Project"

    Public Function GetProjectById(ByVal projectID As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            If projectID <> 0 Then
                openDB()


                '========== ==========

                objCmd = objConn.CreateCommand()
                objCmd.CommandText = "GetProjectByID"
                objCmd.CommandType = CommandType.StoredProcedure
                objCmd.Parameters.AddWithValue("ProjectID", projectID)

                Dim dataAda As New SqlDataAdapter(objCmd)
                Dim ds As New DataSet()
                dataAda.Fill(ds)
                If ds IsNot Nothing Then
                    dt = ds.Tables(0)
                End If


                dataAda.Dispose()
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt


    End Function
#End Region

#Region "SShe"
    Public Function GetClassification(ByVal subCatName As String) As String
        '===
        Dim returnValue As String = ""
        Select Case subCatName
            Case "1"
                'LTIF
                returnValue = "'FAT','LWDC'"
                Exit Select

            Case "2"
                'TRIR
                returnValue = "'FAT','LWDC','RWDC','RWC','MTC'"
                Exit Select

            Case "3"
                'HPIR
                returnValue = "'HPI'"
                Exit Select

            Case "47"
                'LOPC
                returnValue = "'LOPC'"
                Exit Select
                Exit Select
                'returnValue = "'Spillrat'";
            Case "4"
                'Spill Rate
                returnValue = "'SpillRate','Spill'"

                Exit Select
            Case Else

                Exit Select
        End Select

        Return returnValue

    End Function
    Public Function GetKPIByProject(ByVal projectID As String, ByVal areaID As String, ByVal subCatID As String) As DataTable

        Dim dt As New DataTable()
        Try
            If projectID <> "" AndAlso areaID <> "" AndAlso subCatID <> "" Then
                openDB()

                '========== ==========

                objCmd = objConn.CreateCommand()
                objCmd.CommandText = "GetKPIByProject"
                objCmd.CommandType = CommandType.StoredProcedure
                objCmd.Parameters.AddWithValue("ProjectID", projectID)
                objCmd.Parameters.AddWithValue("AreaID", areaID)
                objCmd.Parameters.AddWithValue("SubCatID", subCatID)

                Dim dataAda As New SqlDataAdapter(objCmd)
                Dim ds As New DataSet()
                dataAda.Fill(ds)
                If ds IsNot Nothing Then
                    dt = ds.Tables(0)
                End If


                dataAda.Dispose()
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt




    End Function
    Public Sub Insert_Update_ProjectStatistic_OGP(ByVal mode As String, ByVal UserName As String, ByVal ProjectID As String, ByVal AreaID As String, ByVal SubCatID As String, ByVal TimeKey As String, _
     ByVal StatisticGroup As String, ByVal IntYear As String, ByVal AggMonth As String, ByVal StatisticValue As Decimal)

        Try
            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandType = CommandType.StoredProcedure
            If mode = "edit" Then
                objCmd.CommandText = "UpdateProjectStatistic"
                objCmd.Parameters.AddWithValue("ModifiedBy", UserName)
                objCmd.Parameters.AddWithValue("IsActived", "True")
                objCmd.Parameters.AddWithValue("IsDeleted", "False")
            Else
                objCmd.CommandText = "InsertProjectStatistic"



                objCmd.Parameters.AddWithValue("CreatedBy", UserName)
            End If

            objCmd.Parameters.AddWithValue("ProjectID", ProjectID)
            objCmd.Parameters.AddWithValue("AreaID", AreaID)
            objCmd.Parameters.AddWithValue("SubCatID", SubCatID)
            objCmd.Parameters.AddWithValue("TimeKey", TimeKey)
            objCmd.Parameters.AddWithValue("StatisticGroup", StatisticGroup)
            objCmd.Parameters.AddWithValue("IntYear", IntYear)
            objCmd.Parameters.AddWithValue("AggMonth", AggMonth)
            objCmd.Parameters.AddWithValue("StatisticValue", StatisticValue)



            objCmd.ExecuteNonQuery()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try


    End Sub
    Public Sub UpdateOGP(ByVal areaID As String, ByVal subCatID As String, ByVal OGPValue As Decimal, ByVal year As String, ByVal month As String, ByVal createdBy As String)

        Try
            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "InsertProjectOGP"
            objCmd.CommandType = CommandType.StoredProcedure

            objCmd.Parameters.AddWithValue("AreaID", areaID)
            objCmd.Parameters.AddWithValue("SubCatID", subCatID)
            objCmd.Parameters.AddWithValue("ValueOGP", OGPValue)
            objCmd.Parameters.AddWithValue("Year", year)
            objCmd.Parameters.AddWithValue("Month", month)
            objCmd.Parameters.AddWithValue("CreatedBy", createdBy)



            objCmd.ExecuteNonQuery()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try


    End Sub
    Public Sub DeleteProjectCriteria_Statistic(ByVal RowID As String, ByVal areaID As String, ByVal subCatID As String)

        Try
            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "DeleteProjectCriteria_Statistic"
            objCmd.CommandType = CommandType.StoredProcedure

            objCmd.Parameters.AddWithValue("RowID", RowID)
            objCmd.Parameters.AddWithValue("AreaID", areaID)
            objCmd.Parameters.AddWithValue("SubCatID", subCatID)

            objCmd.ExecuteNonQuery()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try



    End Sub
    Public Sub GetKPI_YearLast(ByVal ProjectID As String, ByRef yearKPI As String, ByRef remark As Boolean)
        Dim sql As String = " SELECT Max(IntYear) as KPI_Lastest FROM V_SSHE_KPI WHERE ProjectID=" & ProjectID
        Dim Year As String = objDB.ExecuteScalar(sql)
        If Year.Trim() <> "" Then
            yearKPI = Year
            If Convert.ToInt32(Year) < Convert.ToInt32(objDate.GetCurrentYear()) Then
                remark = True
            Else
                remark = False


            End If
        Else
            yearKPI = objDate.GetCurrentYear()
            remark = False
        End If


    End Sub
    Public Function GetSSHE_Statistic_By_Project(ByVal projectID As String, ByVal intYear As String, ByVal CatID As String) As DataTable

        Dim dt As New DataTable()
        Try

            openDB()
            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "Get_Statistic_By_Project"
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.AddWithValue("ProjectID", projectID)
            objCmd.Parameters.AddWithValue("IntYear ", intYear)
            objCmd.Parameters.AddWithValue("CategoryID", CatID)
            objCmd.Parameters.AddWithValue("Group", "SSHE")

            Dim dataAda As New SqlDataAdapter(objCmd)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing Then
                dt = ds.Tables(0)
            End If

            dataAda.Dispose()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt

    End Function
    Public Sub InsertServiceAction(ByVal TimeKey As String, ByVal ProjectID As String, ByVal AreaID As String, ByVal ActionStatus As String, ByVal ActionDate As String, ByVal CreateBy As String, _
     ByVal ActionGroup As String, ByVal ActionCommand As String)

        'try
        '{

        '    openDB();

        '    ActionStatus = "C";
        '    /*========== ==========*/
        '    objCmd = objConn.CreateCommand();
        '    objCmd.CommandText = "InsertServiceAction";
        '    objCmd.CommandType = CommandType.StoredProcedure;

        '    objCmd.Parameters.Add("@ActionID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        '    objCmd.Parameters.AddWithValue("TimeKey", TimeKey);
        '    objCmd.Parameters.AddWithValue("ProjectID", ProjectID);
        '    objCmd.Parameters.AddWithValue("AreaID", AreaID);                
        '    objCmd.Parameters.AddWithValue("ActionStatus", ActionStatus);              
        '    objCmd.Parameters.AddWithValue("ActionDate",objDate.DateTimeDB_current());
        '    objCmd.Parameters.AddWithValue("ActionGroup", ActionGroup);
        '    objCmd.Parameters.AddWithValue("ActionCommand", ActionCommand);
        '    objCmd.Parameters.AddWithValue("CreatedBy", CreateBy);            

        '    objCmd.ExecuteNonQuery();

        '}
        'catch (Exception ex)
        '{
        '    objLog.writeLog_2(ex, base.ToString(), new StackFrame().GetMethod().ToString(), "");

        '}
        'finally
        '{
        '    closeDB();
        '}



    End Sub
    Public Sub GetSummaryMan_Hour(ByVal Express As String, ByRef sum_company As Double, ByRef sum_contractore As Double)
        sum_company = 0
        sum_contractore = 0

        Dim dt As DataTable = objDB.ExecucteSql("select sum(Company) as Company ,sum(Contractor) as Contractor from V_SSHE_ManHour where " & Express)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            sum_company = Convert.ToDouble(dt.Rows(0)("Company"))

            sum_contractore = Convert.ToDouble(dt.Rows(0)("Contractor"))
        End If


    End Sub
    Public Sub InsertProjectCriteriaByYear(ByVal rowID As String, ByVal subCatID As String, ByVal projectID As String, ByVal intYear As String, ByVal stretchCase As Decimal, ByVal baseCase As Decimal, _
     ByVal lowerCase As Decimal, ByVal createdBy As String)
        Try
            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "InsertProjectCriteriaByYear"
            objCmd.CommandType = CommandType.StoredProcedure

            objCmd.Parameters.AddWithValue("RowID", rowID)
            objCmd.Parameters.AddWithValue("SubCatID", subCatID)
            objCmd.Parameters.AddWithValue("ProjectID", projectID)
            objCmd.Parameters.AddWithValue("IntYear", intYear)
            objCmd.Parameters.AddWithValue("StretchCase", stretchCase)
            objCmd.Parameters.AddWithValue("BaseCase", baseCase)
            objCmd.Parameters.AddWithValue("LowerCase", lowerCase)
            objCmd.Parameters.AddWithValue("CreatedBy", createdBy)


            objCmd.ExecuteNonQuery()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try


    End Sub
    Public Sub UpdateProjectCriteriaExpression(ByVal id As String, ByVal expStretchCase As String, ByVal expBaseCase As String, ByVal expLowerCase As String, ByVal green_Detail As String, ByVal yellow_Detail As String, _
     ByVal red_Detail As String, ByVal DetailAll As String, ByVal ModifiedBy As String)

        Try
            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "UpdateProjectCriteriaExpression"
            objCmd.CommandType = CommandType.StoredProcedure

            objCmd.Parameters.AddWithValue("RowID", id)
            objCmd.Parameters.AddWithValue("expStretchCase", expStretchCase)
            objCmd.Parameters.AddWithValue("expBaseCase", expBaseCase)
            objCmd.Parameters.AddWithValue("expLowerCase", expLowerCase)

            objCmd.Parameters.AddWithValue("green_Detail", green_Detail)
            objCmd.Parameters.AddWithValue("yellow_Detail", yellow_Detail)
            objCmd.Parameters.AddWithValue("red_Detail", red_Detail)
            objCmd.Parameters.AddWithValue("DetailAll", DetailAll)
            objCmd.Parameters.AddWithValue("ModifiedBy", ModifiedBy)


            objCmd.ExecuteNonQuery()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try



    End Sub
#End Region

#Region "Arims"
    Public Function GetARIMS_Statistic_By_Project(ByVal projectID As String, ByVal intYear As String, ByVal CatID As String) As DataTable
        Dim dt As New DataTable()
        Try

            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "Get_Statistic_By_Project"
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.AddWithValue("ProjectID", projectID)
            objCmd.Parameters.AddWithValue("IntYear ", intYear)
            objCmd.Parameters.AddWithValue("CategoryID", CatID)
            objCmd.Parameters.AddWithValue("Group", "ARIM")

            Dim dataAda As New SqlDataAdapter(objCmd)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing Then
                dt = ds.Tables(0)
            End If

            dataAda.Dispose()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt




    End Function

    Public Function GetARIMS_Statistic_SubCat_101(ByVal intYear As String, ByVal CatID As String) As DataTable
        Dim dt As New DataTable()
        Try

            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "GetARIMS_Statistic_101"
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.AddWithValue("IntYear ", intYear)
            objCmd.Parameters.AddWithValue("CategoryID", CatID)
            Dim dataAda As New SqlDataAdapter(objCmd)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing Then
                dt = ds.Tables(0)
            End If

            dataAda.Dispose()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt




    End Function

    Public Function GetARIM_Cate_101(ByVal intYear As String, ByVal subCatID As String) As DataTable
        Dim dt As New DataTable()
        Try

            openDB()

            '========== ==========

            objCmd = objConn.CreateCommand()
            objCmd.CommandText = "GetARIM_Cate_101"
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.AddWithValue("IntYear ", intYear)
            objCmd.Parameters.AddWithValue("SubCatID", subCatID)
            Dim dataAda As New SqlDataAdapter(objCmd)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing Then
                dt = ds.Tables(0)
            End If

            dataAda.Dispose()
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try

        Return dt


    End Function



    Public Function GenShowConditionBubble(ByVal rowsCriteria As String, ByVal projectID As String, ByVal intYear As String, ByVal SubCatID As String, ByVal Group As String) As String

        Dim html As String = "<div class='bubble'>"
        html += "<a class='closeBubble'>Close</a>"
        html += "<ul>"
        html += "<li>(GRN) - More than 90% compliance</li>"
        html += "<li>(ORA) - 70% to 90% compliance</li>"
        html += "<li>(RED) - Less than 70% compliance</li>"
        html += "</ul>"
        html += "</div>"
        Return html

    End Function




#End Region

#Region "Reports"

#End Region

#Region "ShowMessage"
    Public Function GetMessage(ByVal messageCode As String) As String
        Return objDB.ExecuteScalar("select MessageShow from MessageShow Where MessageCode='" & messageCode & "'")

    End Function
#End Region

#Region "DOCUMENT_INT_RECEIVER"
    Public Function InsertINT_RECEIVER(ByVal inputDT As DataTable) As Integer
        Dim rowsAffected As Integer = 0
        Dim dt As New DataTable()
        Try
            If inputDT IsNot Nothing Then
                For i As Integer = 0 To inputDT.Rows.Count - 1
                    openDB()
                    '========== ==========

                    objCmd = objConn.CreateCommand()
                    objCmd.CommandText = "InsertINT_RECEIVER"
                    objCmd.CommandType = CommandType.StoredProcedure

                    objCmd.Parameters.AddWithValue("ProjectID", inputDT.Rows(i)("ProjectID"))
                    objCmd.Parameters.AddWithValue("SubCatID", inputDT.Rows(i)("SubCatID"))
                    objCmd.Parameters.AddWithValue("IntYear", inputDT.Rows(i)("IntYear"))
                    objCmd.Parameters.AddWithValue("IntMonth", inputDT.Rows(i)("IntMonth"))
                    objCmd.Parameters.AddWithValue("ActualVal", inputDT.Rows(i)("ActualVal"))
                    objCmd.Parameters.AddWithValue("PlanVal", inputDT.Rows(i)("PlanVal"))
                    objCmd.Parameters.AddWithValue("ActualRate", inputDT.Rows(i)("ActualRate"))
                    objCmd.Parameters.AddWithValue("PlanRate", inputDT.Rows(i)("PlanRate"))
                    objCmd.Parameters.AddWithValue("CreatedBy", inputDT.Rows(i)("CreatedBy"))
                    objCmd.Parameters.AddWithValue("IsActived", inputDT.Rows(i)("IsActived"))
                    objCmd.Parameters.AddWithValue("IsDeleted", inputDT.Rows(i)("IsDeleted"))

                    rowsAffected = objCmd.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try
        Return rowsAffected
    End Function

    Public Function updateTRANSSSHELeading(ByVal inputDT As DataTable) As Integer
        Dim rowsAffected As Integer = 0
        Dim dt As New DataTable()
        Try
            If inputDT IsNot Nothing Then
                For i As Integer = 0 To inputDT.Rows.Count - 1
                    openDB()
                    '========== ==========

                    objCmd = objConn.CreateCommand()
                    objCmd.CommandText = "UpdateTRANSSSHELeading"
                    objCmd.CommandType = CommandType.StoredProcedure
                    objCmd.Parameters.AddWithValue("ProjectID", inputDT.Rows(i)("ProjectID"))
                    objCmd.Parameters.AddWithValue("SubCatID", inputDT.Rows(i)("SubCatID"))
                    objCmd.Parameters.AddWithValue("IntYear", inputDT.Rows(i)("IntYear"))
                    objCmd.Parameters.AddWithValue("IntMonth", inputDT.Rows(i)("IntMonth"))
                    objCmd.Parameters.AddWithValue("ActualVal", inputDT.Rows(i)("ActualVal"))
                    objCmd.Parameters.AddWithValue("PlanVal", inputDT.Rows(i)("PlanVal"))
                    objCmd.Parameters.AddWithValue("ActualRate", inputDT.Rows(i)("ActualRate"))
                    objCmd.Parameters.AddWithValue("PlanRate", inputDT.Rows(i)("PlanRate"))
                    objCmd.Parameters.AddWithValue("ModifiedBy", inputDT.Rows(i)("ModifiedBy"))
                    ' objCmd.Parameters.AddWithValue("ModifiedDate", inputDT.Rows[i]["ModifiedDate"]);
                    objCmd.Parameters.AddWithValue("IsActived", inputDT.Rows(i)("IsActived"))
                    objCmd.Parameters.AddWithValue("IsDeleted", inputDT.Rows(i)("IsDeleted"))
                    rowsAffected = objCmd.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally
            closeDB()
        End Try
        Return rowsAffected
    End Function
#End Region
End Class

