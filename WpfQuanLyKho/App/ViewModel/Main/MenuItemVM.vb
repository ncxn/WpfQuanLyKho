Public Class MenuItemVM
    Inherits BaseVM

    Private _icon As Object
    Private _text As String
    Private _isEnabled As Boolean = True
    Private _command As RelayCommand
    Private _navigationDestination As Uri

    Public Property Icon As Object
        Get
            Return Me._icon
        End Get
        Set(ByVal value As Object)
            Me.SetProperty(Me._icon, value)
        End Set
    End Property

    Public Property Text As String
        Get
            Return Me._text
        End Get
        Set(ByVal value As String)
            Me.SetProperty(Me._text, value)
        End Set
    End Property

    Public Property IsEnabled As Boolean
        Get
            Return Me._isEnabled
        End Get
        Set(ByVal value As Boolean)
            Me.SetProperty(Me._isEnabled, value)
        End Set
    End Property

    Public Property Command As ICommand
        Get
            Return Me._command
        End Get
        Set(ByVal value As ICommand)
            Me.SetProperty(Me._command, CType(value, RelayCommand))
        End Set
    End Property

    Public Property NavigationDestination As Uri
        Get
            Return Me._navigationDestination
        End Get
        Set(ByVal value As Uri)
            Me.SetProperty(Me._navigationDestination, value)
        End Set
    End Property

    Public ReadOnly Property IsNavigation As Boolean
        Get
            Return Me._navigationDestination IsNot Nothing
        End Get
    End Property

End Class
