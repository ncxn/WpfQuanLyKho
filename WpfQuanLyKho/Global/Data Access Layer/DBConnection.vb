Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class DBConnection
    Public Shared Function GetDBConnection(ByVal host As String, ByVal port As Integer, ByVal database As String, ByVal username As String, ByVal password As String, charset As String) As MySqlConnection
        Dim connString As String = "Server=" & host & ";Database=" & database & ";port=" & port & ";User Id=" & username & ";password=" & password & ";charset= " & charset
        Dim conn As MySqlConnection = New MySqlConnection(connString)
        Return conn
    End Function
    Public Shared Function GetDBConnection(ByVal datasource As String, ByVal database As String, ByVal username As String, ByVal password As String) As SqlConnection
        Dim connString As String = "Data Source=" & datasource & ";Initial Catalog=" & database & ";Persist Security Info=True;User ID=" & username & ";Password=" & password
        Dim conn As SqlConnection = New SqlConnection(connString)
        Return conn
    End Function
    Public Shared Function GetDBConnection(ByVal datasource As String, ByVal Version As String) As SQLiteConnection
        Dim connString As String = "Data Source=" & datasource & ";Version=" & Version
        Dim conn As SQLiteConnection = New SQLiteConnection(connString)
        Return conn
    End Function
End Class