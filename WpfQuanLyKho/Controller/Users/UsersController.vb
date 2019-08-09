Imports System.Collections.ObjectModel
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class UsersController
    Inherits BaseController

    Public Sub New()
        Users = ListUsers()
        DeleteCmd = New RelayCommand(AddressOf Remove, AddressOf Confirm)
    End Sub
    Public Property Users As ObservableCollection(Of UsersModel)
    Public Property DeleteCmd As ICommand
    Public Property AddCmd As ICommand
    Public Function ListUsers()
        Dim users As New ObservableCollection(Of UsersModel)
        Dim DataTable As DataTable = DBHelper.GetInstance.GetDataTable("procUsers_GetAll", CommandType.StoredProcedure)

        For Each row As DataRow In DataTable.Rows
            Dim objUser As New UsersModel With {
                .User_id = row(0).ToString(),
                .User_name = row(1).ToString(),
                .User_first_name = row(2).ToString(),
                .User_last_name = row(3).ToString(),
                .User_email = row(4).ToString(),
                .User_status = CInt(row(5)),
                .User_created_at = CDate(row(6)),
                .User_updated_at = CDate(row(7))
            }
            users.Add(objUser)
        Next
        Return users

    End Function

    Private Sub Remove(user)
        Users.Remove(user)
    End Sub
    Private Function Confirm() As Boolean
        Return True
    End Function
End Class
