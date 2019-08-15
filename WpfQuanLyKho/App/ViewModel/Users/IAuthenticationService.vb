Public Interface IAuthenticationService
    Function AuthenticateUser(ByVal username As String, ByVal password As String) As UsersModel
End Interface
