Public Class RoleContainer
    Private Property _Name As String
    Private Property _Email As String
    Private Property _Roles As String()
    Public Sub New(ByVal name As String, ByVal email As String, ByVal roles As String())
        _Name = name
        _Email = email
        _Roles = roles
    End Sub
End Class
