
Public Class CurrentRole
    Public Sub New(CurrentRole As RoleContainer)
    End Sub

    Private _currentRole As RoleContainer
    Public Property CurrentRole As RoleContainer
        Get
            Return If(_currentRole, New GuestRole())
        End Get
        Set(ByVal value As RoleContainer)
            _currentRole = value
        End Set
    End Property

End Class
