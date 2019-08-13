Imports System.Collections.ObjectModel
Imports System.Data

Public Class LoginVM
    Inherits BaseVM

#Region " Command"

    Private ReadOnly _loginCmd As RelayCommand
    Private ReadOnly _cancelCmd As RelayCommand
    Public ReadOnly Property LogInCmd As RelayCommand
        Get
            Return _loginCmd

        End Get
    End Property

    Public ReadOnly Property CancelCmd As RelayCommand
        Get
            Return _cancelCmd
        End Get
    End Property
#End Region
    Public Sub New()
        _loginCmd = New RelayCommand(AddressOf Login, AddressOf CanLogin)
        _cancelCmd = New RelayCommand(AddressOf Cancel)
    End Sub

#Region " Properties"
    Private _UserName As String

    Public Property UserName As String
        Get
            Return _UserName
        End Get
        Set
            If SetProperty(_UserName, Value) Then
                LogInCmd.OnCanExecuteChanged()
            End If
            OnPropertyChanged(NameOf(UserName))
        End Set

    End Property
#End Region

#Region " Users data"
    Public Function ListUsers() As ObservableCollection(Of UsersModel)
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

#Region " Đăng nhập"
    Private Sub Login(ByVal parameter As Object)
        Dim passwordBox As PasswordBox = TryCast(parameter, PasswordBox)
        Dim PassWord As String = passwordBox.Password

        Try
            'Dim user As UsersModel = GetUserLogin(UserName, PassWord)
            Dim usersmanager As New Main
            usersmanager.Show()

        Catch ex As Exception
            MessageBox.Show("Éo đúng mài ơi")
        End Try

    End Sub
    Private Function CanLogin(ByVal para As Object) As Boolean
        Return Not String.IsNullOrEmpty(UserName)
    End Function

    Public Function GetUserLogin(ByVal username As String, ByVal PassWord As String) As UsersModel
        Dim Users As ObservableCollection(Of UsersModel) = ListUsers()
        Dim userData As UsersModel = Users.FirstOrDefault(Function(u) u.User_name.Equals(username) AndAlso u.User_password.Equals(Security.GetMD5(PassWord)))
        If userData Is Nothing Then Throw New UnauthorizedAccessException("Access denied. Please provide some valid credentials.")
        Return userData
    End Function

#End Region

#Region "Thoát"
    Private Sub Cancel(Parameter As Object)
        Dim win As Window = TryCast(Parameter, Window)
        win.Close()
    End Sub
#End Region
End Class
