Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data.SQLite


Public Class DBUtils
    Private Shared Singleton As DBUtils
    Public Function GetInstance() As DBUtils
        If (Singleton Is Nothing) Then
            Singleton = New DBUtils()
        End If
        Return Singleton
    End Function
    Public Function MYSQL() As MySqlConnection
        Dim host As String = "173.254.231.108"
        Dim port As Integer = 3306
        Dim database As String = "dps"
        Dim username As String = "root"
        Dim password As String = "mmttmhh"
        Dim charset As String = "utf8"
        Return DBConnection.GetDBConnection(host, port, database, username, password, charset)
    End Function
    Public Function MSSQL() As SqlConnection
        Dim datasource As String = "MY-SERVER\SQLEXPRESS"
        Dim database As String = "sample"
        Dim username As String = "sa"
        Dim password As String = "1234"
        Return DBConnection.GetDBConnection(datasource, database, username, password)
    End Function
    Public Function SQLite() As SQLiteConnection
        Dim datasource As String = "data\db.db3"
        Dim version As String = "3"
        Return DBConnection.GetDBConnection(datasource, version)
    End Function
End Class

