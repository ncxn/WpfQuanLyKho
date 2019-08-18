Public Class MainMenuVM
    Inherits BaseVM

    Private _SystemCmd As ICommand
    Private _UsersAddCmd As ICommand
    Private _role As Boolean

    Public Sub New()
        _UsersAddCmd = New RelayCommand(AddressOf OpenAddUsers)
    End Sub

    Private Function CanOpenAddUsers(obj As Object) As Boolean
        Return Role
    End Function

    Private Sub OpenAddUsers(obj As Object)
        Dim w As New UsersManager
        w.Show()
    End Sub

    Public Property SystemCmd As ICommand
        Get
            Return _SystemCmd
        End Get
        Set(value As ICommand)
            _SystemCmd = value
        End Set
    End Property

    Public Property Role As Boolean
        Get
            Return _role
        End Get
        Set(value As Boolean)
            _role = value
        End Set
    End Property

    Public Property UsersAddCmd As ICommand
        Get
            If _UsersAddCmd Is Nothing Then
                _UsersAddCmd = New RelayCommand(AddressOf OpenAddUsers, AddressOf CanOpenAddUsers)
            End If
            Return _UsersAddCmd
        End Get
        Set(value As ICommand)
            _UsersAddCmd = value
        End Set
    End Property
End Class
