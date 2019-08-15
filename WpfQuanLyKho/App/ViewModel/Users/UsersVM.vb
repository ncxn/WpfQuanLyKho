Imports System.Collections.ObjectModel
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class UsersVM
    Inherits BaseVM

    Private _username As String

#Region " Biến toàn cục"
    Public Property UserName As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
            OnPropertyChanged("UserName")
        End Set
    End Property
#End Region
    Public Property Users As ObservableCollection(Of UsersModel)

#Region " Command"
    Public Property LogInCmd As ICommand
    Public Property DeleteCmd As ICommand
    Public Property AddCmd As ICommand
#End Region


    Public Sub New()
        Users = ListUsers()

        DeleteCmd = New RelayCommand(AddressOf Remove, AddressOf Confirm)
    End Sub



#Region "Xử lý dữ liệu"

#Region " Users data"
    Public Function ListUsers()
        Dim users As New ObservableCollection(Of UsersModel)
        Dim dt As DataTable = DBHelper.GetInstance.GetDataTable("procUsers_GetAll", CommandType.StoredProcedure)

        For Each row As DataRow In dt.Rows
            Dim objUser As New UsersModel With {
                .User_name = row(0).ToString(),
                .User_password = row(1),
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
#End Region


    Private Sub Remove(user As UsersModel)
        Users.Remove(user)
    End Sub
    Private Function Confirm() As Boolean
        Return True
    End Function
#End Region
End Class
