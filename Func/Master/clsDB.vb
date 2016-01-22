Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Security.Cryptography
Imports System.Text
Imports System.Diagnostics

''' <summary>
''' Summary description for clsDB
''' </summary>/// 

Public Class clsDB
    Inherits System.Web.UI.Page

#Region "Decration Variable"
    Private objLog As New clsLog()
    Protected objConn As SqlConnection
    Protected objCmd As SqlCommand
    Private strConnString As [String] = ""
    Private strSql As String = ""
    'private static string key = "1861"; 
#End Region

#Region "Constructor"
    'connectDB();

    Public Sub New()
    End Sub



    Public Sub New(ByVal connected As Boolean)
    End Sub
#End Region

#Region "Connect"
    Public Sub connectDB()
        Try

            ' strConnString = "Server=JAIDAW_VAIO\\SQL2005_1;Uid=sa;PASSWORD=1234;database=CITYGAS_DB;Max Pool Size=400;Connect Timeout=600;";
            'Dim strConnString_ As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString").ToString()
            Dim strConnString As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString").ToString()
            '  strConnString = Decrypt_(strConnString_);
            ' strConnString = strConnString_


            objConn = New SqlConnection(strConnString)
        Catch ex As Exception

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))


            Throw ex
        End Try

    End Sub
#End Region

#Region "Close DB"
    Public Sub closeDB()
        Try
            If objConn.State = ConnectionState.Open Then

                ' objConn = null;

                objConn.Close()

            End If
        Catch ex As Exception


            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        End Try

    End Sub
#End Region

#Region "open DB"
    Public Sub openDB()
        Try

            If objConn IsNot Nothing AndAlso objConn.State = ConnectionState.Open Then
                objConn.Close()
            End If
            connectDB()

            ' objConn.Open();


            If objConn.State = ConnectionState.Closed Then
                objConn.Open()

            End If
        Catch ex As Exception
            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))

            Throw ex
        End Try

    End Sub
#End Region

#Region "getTypeIdDB"
    Private Function getTypeIdDB(ByVal value As Object) As SqlDbType

        If value.[GetType]().Name = "String" Then
            Return SqlDbType.NVarChar
        End If

        If value.[GetType]().Name = "Boolean" Then
            Return SqlDbType.Bit
        End If

        If value.[GetType]().Name = "DateTime" Then
            Return SqlDbType.DateTime
        End If
        If value.[GetType]().Name = "Int" Then
            Return SqlDbType.Int
        End If
        Return SqlDbType.NVarChar

    End Function
#End Region

#Region "Insert DB"
    Public Function InsertDB(ByVal dt As DataTable, ByVal strTableName As String) As Integer
        Dim sqlInsert As String = ""
        Dim sqlValue As String = ""
        Dim sqlCommand As String = ""
        Dim newID As Integer = 0

        Try

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                sqlInsert = " INSERT INTO " & strTableName & " ("
                sqlValue += " VALUES("

                ' icol=0 is indentity auto increment
                For icol As Integer = 1 To dt.Columns.Count - 1


                    If icol > 1 Then
                        sqlInsert += ", "
                        sqlValue += ", "
                    End If
                    sqlInsert += dt.Columns(icol).ColumnName


                    sqlValue += "@" & dt.Columns(icol).ColumnName
                Next

                sqlInsert += " )"
                sqlValue += "); Select Scope_Identity()"
                sqlCommand = sqlInsert & sqlValue

                openDB()
                Dim SqlCmd As New SqlCommand(sqlCommand, objConn)
                Dim colName As String = ""
                For icol As Integer = 1 To dt.Columns.Count - 1

                    colName = dt.Columns(icol).ColumnName.Trim()
                    If colName = "INT_ORDER" AndAlso (dt.Rows(0)(icol) Is DBNull.Value OrElse dt.Rows(0)(icol) Is Nothing OrElse Convert.ToInt32(dt.Rows(0)(icol)) = 0) Then
                        Dim sqlMax As String = "SELECT MAX(INT_ORDER) FROM " & strTableName
                        Dim SqlCmdOrder As New SqlCommand(sqlMax, objConn)
                        Dim order As Integer = 0
                        Dim objEx As Object = SqlCmdOrder.ExecuteScalar()
                        If objEx IsNot DBNull.Value Then
                            order = Convert.ToInt32(objEx)
                        End If

                        SqlCmd.Parameters.Add("@INT_ORDER", SqlDbType.Int).Value = order + 1
                    Else
                        SqlCmd.Parameters.Add("@" & colName, getTypeIdDB(dt.Rows(0)(icol))).Value = dt.Rows(0)(icol)

                    End If
                Next
                Dim returnId As Object = SqlCmd.ExecuteScalar()



                newID = Convert.ToInt32(returnId)


            End If
        Catch ex As Exception


            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally

            closeDB()
        End Try


        Return newID


    End Function
#End Region

#Region "Update DB"
    Public Function UpdateDB(ByVal dt As DataTable, ByVal strTableName As String, ByVal Id As Integer) As Integer

        Dim sqlUpdate As String = ""
        Dim sqlValue As String = ""
        Dim sqlCommand As String = ""
        'int Id = 0;
        Dim result As Integer = 0

        Try
            '==do not update field DTE_CREATE_DATE,STR_CREATE_USER
            If dt.Columns("DTE_CREATE_DATE") IsNot Nothing Then

                dt.Columns.Remove("DTE_CREATE_DATE")
            End If
            If dt.Columns("STR_CREATE_USER") IsNot Nothing Then
                dt.Columns.Remove("STR_CREATE_USER")
            End If


            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim columnName As String = ""
                sqlUpdate = " UPDATE  " & strTableName & " SET "
                For icol As Integer = 1 To dt.Columns.Count - 1
                    If icol > 1 Then
                        sqlValue += ", "
                    End If
                    columnName = dt.Columns(icol).ColumnName

                    sqlValue += columnName & " =@" & columnName
                Next

                Id = Convert.ToInt32(dt.Rows(0)(0))
                ' ID(Auto Increment PK)
                sqlCommand = sqlUpdate & sqlValue & " WHERE " & dt.Columns(0).ColumnName & " = " & Id


                openDB()
                Dim SqlCmd As New SqlCommand(sqlCommand, objConn)
                Dim colName As String = ""
                For icol As Integer = 1 To dt.Columns.Count - 1

                    colName = dt.Columns(icol).ColumnName.Trim()


                    If colName = "INT_ORDER" Then

                        SqlCmd.Parameters.Add("@INT_ORDER", SqlDbType.Int).Value = dt.Rows(0)(icol)
                    Else
                        SqlCmd.Parameters.Add("@" & colName, getTypeIdDB(dt.Rows(0)(icol))).Value = dt.Rows(0)(icol)

                    End If
                Next


                result = SqlCmd.ExecuteNonQuery()


            End If
        Catch ex As Exception


            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))
        Finally

            closeDB()
        End Try


        Return result

    End Function
#End Region

#Region "SelectByPage"
    Public Function SelectByPage(ByVal strTableName As String, ByVal strCondition As String, ByVal strColList As String, ByVal strOrderBy As String, ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            ' กรณีที่ต้องการดึงมาเฉพาะหน้าที่ต้องการ
            Dim firstRow As Integer = ((pageNo - 1) * pageSize) + 1
            Dim lastRow As Integer = ((pageNo - 1) * pageSize) + pageSize
            Dim sql As String = ""


            If strCondition.Trim() = "" Then
                strCondition = " 1 = 1"
            End If

            sql = " SELECT * "
            sql += " FROM ( "
            sql += "         SELECT  " & strColList & " ,"
            sql += "         ROW_NUMBER() OVER (ORDER BY " & strOrderBy & ") AS RowNumber "
            sql += "         FROM " & strTableName & " WHERE " & strCondition & " ) AS TEMP "
            sql += " WHERE  RowNumber BETWEEN " & firstRow & " AND  " & lastRow



            openDB()
            Dim dataAda As New SqlDataAdapter(sql, objConn)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing Then
                dt = ds.Tables(0)
            End If

            dataAda.Dispose()
        Catch ex As Exception


            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))
        Finally
            closeDB()
        End Try

        Return dt

    End Function

    Public Function SelectByPage(ByVal strTableName As String, ByVal strCondition As String, ByVal strColList As String, ByVal strJoin As String, ByVal strOrderBy As String, ByVal pageNo As Integer, _
     ByVal pageSize As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            ' กรณีที่ต้องการดึงมาเฉพาะหน้าที่ต้องการ
            Dim firstRow As Integer = ((pageNo - 1) * pageSize) + 1
            Dim lastRow As Integer = ((pageNo - 1) * pageSize) + pageSize
            Dim sql As String = ""


            If strCondition.Trim() = "" Then
                strCondition = " 1 = 1"
            End If

            sql = " SELECT * "
            sql += " FROM ( "
            sql += "         SELECT  " & strColList & " ,"
            sql += "         ROW_NUMBER() OVER (ORDER BY " & strOrderBy & ") AS RowNumber "
            sql += "         FROM " & strTableName & " WHERE " & strCondition & " ) AS TEMP "
            If strJoin.Trim() <> "" Then
                sql += strJoin
            End If
            sql += " WHERE  RowNumber BETWEEN " & firstRow & " AND  " & lastRow



            openDB()
            Dim dataAda As New SqlDataAdapter(sql, objConn)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing Then
                dt = ds.Tables(0)
            End If

            dataAda.Dispose()
        Catch ex As Exception


            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))
        Finally
            closeDB()
        End Try

        Return dt

    End Function

#End Region

#Region "GetTotalRecord"
    Public Function GetTotalRecord(ByVal strTableName As String, ByVal strCondition As String) As Integer
        '  DataTable dt = new DataTable();
        Try
            Dim sql As String = ""

            If strCondition.Trim() = "" Then
                strCondition = " 1 = 1"
            End If

            sql = "  SELECT COUNT(*) AS TotalRecord "
            sql += " FROM " & strTableName & " WHERE " & strCondition
            openDB()
            objCmd = objConn.CreateCommand()
            objCmd.CommandText = sql
            Dim returnId As Object = objCmd.ExecuteScalar()
            Return Convert.ToInt32(returnId)
        Catch ex As Exception
            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))
        Finally
            closeDB()
        End Try

        Return 0

    End Function
#End Region

#Region "ExecuteSql"
    Public Function ExecucteSql(ByVal sql As String) As DataTable
        Dim dt As New DataTable()
        Try


            openDB()
            Dim dataAda As New SqlDataAdapter(sql, objConn)
            Dim ds As New DataSet()
            dataAda.Fill(ds)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
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

    Public Function ExecucteSql_DataSet(ByVal sql As String) As DataSet
        '  DataTable dt = new DataTable();
        Dim ds As New DataSet()
        Try


            openDB()
            Dim dataAda As New SqlDataAdapter(sql, objConn)

            dataAda.Fill(ds)
            'if (ds != null && ds.Tables.Count > 0)
            '{
            '    dt = ds.Tables[0];
            '}

            dataAda.Dispose()
        Catch ex As Exception
            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))
        Finally
            closeDB()
        End Try

        Return ds


    End Function
#End Region

#Region "ExecuteNonequery"
    Public Function ExecuteNonequery(ByVal sqlCommand As String) As Integer


        Dim result As Integer = 0

        Try

            openDB()
            objCmd = objConn.CreateCommand()
            objCmd.CommandText = sqlCommand

            result = objCmd.ExecuteNonQuery()
        Catch ex As Exception
            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), "")
        Finally

            closeDB()
        End Try


        Return result



    End Function
#End Region

#Region "ExecuteScalar"
    Public Function ExecuteScalar(ByVal sql As String) As String
        Try
            openDB()
            objCmd = objConn.CreateCommand()
            objCmd.CommandText = sql
            Dim objReturn As Object = objCmd.ExecuteScalar()
            Return Convert.ToString(objReturn)
        Catch ex As Exception
            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))
        Finally
            closeDB()
        End Try

        Return ""

    End Function
#End Region

    '============ Method Unitility for Class DB ==========
#Region "GetStructure"
    Public Function GetStructure(ByVal strTableName As String, ByVal strCondition As String) As DataTable
        Dim dt As DataTable
        Try

            openDB()
            Dim ds As New DataSet()
            strSql = "SELECT TOP 1 * FROM " & strTableName
            If strCondition.Trim() <> "" Then

                strSql += " WHERE " & strCondition
            End If
            Dim da As New SqlDataAdapter(strSql, objConn)
            da.Fill(ds)

            dt = ds.Tables(0)
        Catch ex As Exception
            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))

            dt = Nothing
        Finally

            closeDB()
        End Try

        Return dt
    End Function
#End Region

#Region "ConvertDataToDB"
    Public Function ConvertDataToDB(ByVal value As Object) As Object
        Try

            If value Is DBNull.Value Then
                Return "NULL"
            ElseIf value.[GetType]().Name = "String" OrElse value.[GetType]().Name = "Boolean" OrElse value.[GetType]().Name = "DateTime" Then
                'return "'" + HttpUtility.HtmlDecode(value.ToString())+"'";


                Return "'" & value.ToString().Replace("'", "''") & "'"


            End If
        Catch ex As Exception
            'dt = null;

            objLog.writeLog_2(ex, MyBase.ToString(), New StackFrame().GetMethod().ToString(), Server.MapPath("../logfile/errorlog"))
        End Try

        Return value
    End Function
#End Region

    '#region Authen
    'public int GetUserAuthen(string menuId, string userGroup)
    '{
    '    DataTable dt = new DataTable();

    '    int result = 0;
    '    try
    '    {
    '        if (menuId != "0" && userGroup != "0")
    '        {
    '            openDB();
    '            objCmd = objConn.CreateCommand();
    '            objCmd.CommandText = "GetUserAuthen";
    '            objCmd.CommandType = CommandType.StoredProcedure;

    '            objCmd.Parameters.AddWithValue("MENU_ID", menuId);
    '            objCmd.Parameters.AddWithValue("USER_GROUP", userGroup);
    '            object result_return = objCmd.ExecuteScalar();
    '            if (result_return != null)
    '            {
    '                result = (int)result_return;

    '            }

    '            //dt.Load(objCmd.ExecuteReader(), LoadOption.OverwriteChanges);                    


    '        }
    '    }
    '    catch (Exception ex)
    '    {
    '        objLog.writeLog_2(ex, base.ToString(), new StackFrame().GetMethod().ToString(), "");

    '    }
    '    finally
    '    {
    '        closeDB();
    '    }

    '    return result;

    '}


    '#endregion

    '#region Customer
    'public int DeleteCustomerByProject(string customerId, string ProjectId)
    '{
    '    DataTable dt = new DataTable();

    '    int result = 0;
    '    try
    '    {
    '        if (customerId != "" && customerId != "")
    '        {
    '            openDB();
    '            objCmd = objConn.CreateCommand();
    '            objCmd.CommandText = "DeleteCustomerByProject";
    '            objCmd.CommandType = CommandType.StoredProcedure;

    '            objCmd.Parameters.AddWithValue("CustomerID", customerId);
    '            objCmd.Parameters.AddWithValue("ProjectId", ProjectId);
    '            object result_return = objCmd.ExecuteScalar();
    '            if (result_return != null)
    '            {
    '                result = (int)result_return;

    '            }

    '            //dt.Load(objCmd.ExecuteReader(), LoadOption.OverwriteChanges);                    


    '        }
    '    }
    '    catch (Exception ex)
    '    {
    '        objLog.writeLog_2(ex, base.ToString(), new StackFrame().GetMethod().ToString(), "");

    '    }
    '    finally
    '    {
    '        closeDB();
    '    }

    '    return result;

    '}


    '#endregion

    '#region Quotation
    'public int DeleteQuotation(string quotationID)
    '{
    '    DataTable dt = new DataTable();

    '    int result = 0;
    '    try
    '    {
    '        if (quotationID != "")
    '        {
    '            openDB();
    '            objCmd = objConn.CreateCommand();
    '            objCmd.CommandText = "DeleteQuotation";
    '            objCmd.CommandType = CommandType.StoredProcedure;

    '            objCmd.Parameters.AddWithValue("QuotationID", quotationID);                  
    '            object result_return = objCmd.ExecuteScalar();
    '            if (result_return != null)
    '            {
    '                result = (int)result_return;

    '            }

    '            //dt.Load(objCmd.ExecuteReader(), LoadOption.OverwriteChanges);                    


    '        }
    '    }
    '    catch (Exception ex)
    '    {
    '        objLog.writeLog_2(ex, base.ToString(), new StackFrame().GetMethod().ToString(), "");

    '    }
    '    finally
    '    {
    '        closeDB();
    '    }

    '    return result;

    '}
    '#endregion
End Class

