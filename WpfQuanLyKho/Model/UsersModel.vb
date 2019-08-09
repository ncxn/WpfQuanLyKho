#Region " DTO Users"
'table users
Public Class UsersModel
    Private _user_id As Integer
    Private _user_name As String
    Private _user_first_name As String
    Private _user_last_name As String
    Private _user_email As String
    Private _user_password As String
    Private _user_status As Integer
    Private _user_created_at As Date
    Private _user_updated_at As Date

    Public Property User_id As Integer
        Get
            Return _user_id
        End Get
        Set(value As Integer)
            _user_id = value
        End Set
    End Property
    Public Property User_name As String
        Get
            Return _user_name
        End Get
        Set(value As String)
            _user_name = value
        End Set
    End Property

    Public Property User_first_name As String
        Get
            Return _user_first_name
        End Get
        Set(value As String)
            _user_first_name = value
        End Set
    End Property

    Public Property User_last_name As String
        Get
            Return _user_last_name
        End Get
        Set(value As String)
            _user_last_name = value
        End Set
    End Property

    Public Property User_email As String
        Get
            Return _user_email
        End Get
        Set(value As String)
            _user_email = value
        End Set
    End Property

    Public Property User_password As String
        Get
            Return _user_password
        End Get
        Set(value As String)
            _user_password = value
        End Set
    End Property

    Public Property User_status As Integer
        Get
            Return _user_status
        End Get
        Set(value As Integer)
            _user_status = value
        End Set
    End Property

    Public Property User_created_at As Date
        Get
            Return _user_created_at
        End Get
        Set(value As Date)
            _user_created_at = value
        End Set
    End Property

    Public Property User_updated_at As Date
        Get
            Return _user_updated_at
        End Get
        Set(value As Date)
            _user_updated_at = value
        End Set
    End Property
End Class
#End Region

#Region " Current User"
Public Class CurrentUser
    Private Shared _CurrentUser As UsersModel
    Public Shared Property User As UsersModel
        Get
            Return _CurrentUser
        End Get
        Set(ByVal value As UsersModel)
            _CurrentUser = value
        End Set
    End Property
End Class
#End Region

#Region " User Collection"
Public Class UserCollection
    Inherits List(Of UsersModel)
End Class
#End Region

#Region " User Status"
Public Enum User_status
    Exits = 0
    Active = 1
    Locked = 2
    NotExists = 3
    WrongPass = 4
End Enum
#End Region

#Region " Data Access User"
Public Class Users
    Private Shared Singleton As UsersModel
    Public Shared Function GetInstance() As UsersModel
        If Singleton Is Nothing Then
            Singleton = New UsersModel()
        End If
        Return Singleton
    End Function
    'Public Function GetDataTableUsers() As DataTable
    '    Dim dtUsers As DataTable = DBHelper.GetInstance.GetDataTable("procUsers_GetAll", CommandType.StoredProcedure)
    '    Return dtUsers
    'End Function
    'Public Function GetListUsers() As UserCollection
    '    Dim UserList As New UserCollection
    '    Dim Reader As MySqlDataReader = DBHelper.GetInstance.GetDataReader("procUsers_GetAll", CommandType.StoredProcedure)

    '    While Reader.Read()
    '        Dim objUser As New UsersModel With {
    '            .User_id = Reader("user_id").ToString(),
    '            .User_name = Reader("user_name").ToString(),
    '            .User_first_name = Reader("user_first_name").ToString(),
    '            .User_last_name = Reader("user_last_name").ToString(),
    '            .User_email = Reader("user_email").ToString(),
    '            .User_status = CInt(Reader("user_status")),
    '            .User_created_at = CDate(Reader("user_created_at")),
    '            .User_updated_at = CDate(Reader("user_updated_at"))
    '        }
    '        UserList.Add(objUser)
    '    End While
    '    Reader.Close()

    '    Return UserList

    'End Function

    'Public Function GetUserByID(user_id As Integer) As UsersModel
    '    Dim ObjectUser As New UsersModel
    '    Dim strProc As String = "procGetUserByID"
    '    Dim parameters As New List(Of MySqlParameter) From {
    '        New MySqlParameter("@p_user_id", user_id)
    '    }
    '    Dim Reader As Object = DBHelper.GetInstance.GetDataReader(strProc, CommandType.StoredProcedure, parameters)
    '    If Reader.Read() Then
    '        With ObjectUser
    '            .User_id = Reader("User_id").ToString()
    '            .User_name = Reader("User_name").ToString()
    '            .User_first_name = Reader("User_first_name").ToString()
    '            .User_last_name = Reader("User_last_name").ToString()
    '            .User_email = Reader("User_email").ToString()
    '            .User_password = Reader("User_password").ToString()
    '            .User_status = CInt(Reader("User_password"))
    '            .User_created_at = CDate(Reader("User_created_at"))
    '            .User_updated_at = CDate(Reader("User_updated_at"))
    '        End With
    '    End If
    '    Reader.Close()

    '    Return ObjectUser

    'End Function

    'Public Function GetUserByUserName(user_name As String) As UsersModel
    '    Dim ObjectUser As New UsersModel
    '    Dim strProc As String = "procGetUserByUserName"
    '    Dim parameters As New List(Of MySqlParameter) From {
    '        New MySqlParameter("p_user_name", user_name)
    '    }

    '    Dim Reader As Object = DBHelper.GetInstance.GetDataReader(strProc, CommandType.StoredProcedure, parameters)

    '    If Reader.Read() Then
    '        With ObjectUser
    '            .User_id = Reader("User_id").ToString()
    '            .User_name = Reader("User_name").ToString()
    '            .User_first_name = Reader("User_first_name").ToString()
    '            .User_last_name = Reader("User_last_name").ToString()
    '            .User_email = Reader("User_email").ToString()
    '            .User_password = Reader("User_password").ToString()
    '            .User_status = CInt(Reader("User_status"))
    '            .User_created_at = CDate(Reader("User_created_at"))
    '            .User_updated_at = CDate(Reader("User_updated_at"))

    '        End With
    '    End If
    '    Reader.Close()

    '    Return ObjectUser

    'End Function

    'Public Function GetUserByUserNameOrEmail(user_name As String, user_email As String) As UsersModel
    '    Dim ObjectUser As New UsersModel
    '    Dim strProc As String = "procUsers_GetByUserOrEmail"
    '    Dim parameters As New List(Of MySqlParameter) From {
    '        New MySqlParameter("p_user_name", user_name),
    '        New MySqlParameter("p_user_email", user_email)
    '    }

    '    Dim Reader As Object = DBHelper.GetInstance.GetDataReader(strProc, CommandType.StoredProcedure, parameters)

    '    If Reader.Read() Then
    '        With ObjectUser
    '            .User_id = Reader("User_id").ToString()
    '            .User_name = Reader("User_name").ToString()
    '            .User_first_name = Reader("User_first_name").ToString()
    '            .User_last_name = Reader("User_last_name").ToString()
    '            .User_email = Reader("User_email").ToString()
    '            .User_password = Reader("User_password").ToString()
    '            .User_status = CInt(Reader("User_status"))
    '            .User_created_at = CDate(Reader("User_created_at"))
    '            .User_updated_at = CDate(Reader("User_updated_at"))

    '        End With
    '    End If
    '    Reader.Close()

    '    Return ObjectUser

    'End Function
    'Public Function Insert(Users As UsersModel) As Boolean
    '    Dim strSQL = "procUsers_Insert"

    '    Dim paraName() As String = {"p_user_name", "p_user_first_name", "p_user_last_name", "p_user_email", "p_user_password", "p_user_status", "p_user_created_at", "p_user_updated_at"}
    '    Dim paraValue As Object = New Object() {Users.User_name, Users.User_first_name, Users.User_last_name, Users.User_email, Users.User_password, Users.User_status, Users.User_created_at, Users.User_updated_at}
    '    Dim parameters = DBHelper.GetInstance.GetParameter(paraName, paraValue)
    '    Dim result As Integer = DBHelper.GetInstance.ExecuteNonQuery(strSQL, CommandType.StoredProcedure, parameters)
    '    Return result > 0
    'End Function
    'Public Function Update(Users As UsersModel) As Boolean
    '    Dim strSQL = "procUsers_Update"

    '    Dim paraName() As String = {"p_user_name", "p_user_first_name", "p_user_last_name", "p_user_email", "p_user_status", "p_user_created_at", "p_user_updated_at", "p_user_Id"}
    '    Dim paraValue As Object = New Object() {Users.User_name, Users.User_first_name, Users.User_last_name, Users.User_email, Users.User_status, Users.User_created_at, Users.User_updated_at, Users.User_id}
    '    Dim parameters = DBHelper.GetInstance.GetParameter(paraName, paraValue)
    '    Dim result As Integer = DBHelper.GetInstance.ExecuteNonQuery(strSQL, CommandType.StoredProcedure, parameters)
    '    Return result > 0

    'End Function

    'Public Function ChangePassWord(User_Name As String, OldPw As String, NewPw As String) As Boolean
    '    Dim strSQL = "procUsers_ChangePass"
    '    Dim paraName() As String = {"p_user_name", "p_old_password", "p_new_password"}
    '    Dim paraValue As Object = New Object() {User_Name, OldPw, NewPw}
    '    Dim parameters = DBHelper.GetInstance.GetParameter(paraName, paraValue)
    '    Dim result As Integer = DBHelper.GetInstance.ExecuteNonQuery(strSQL, CommandType.StoredProcedure, parameters)
    '    Return result > 0
    'End Function

    'Public Function HasMatchUserAndPassWord(UserName As String, PassWord As String) As Boolean
    '    Dim objUser As UsersModel = GetUserByUserName(UserName)
    '    If objUser.User_name IsNot Nothing Then
    '        If objUser.User_password = Security.GetMD5(PassWord) Then
    '            Return True
    '        End If
    '    End If
    '    Return False
    'End Function

    'Public Function UpdatePassWordByUserName(user_name As String, passWord As String) As Boolean
    '    Dim strSQL = "procUsers_Update_PassWord"
    '    Dim paraName() As String = {"p_user_name", "p_user_password"}
    '    Dim paraValue As Object = New Object() {user_name, passWord}
    '    Dim parameters = DBHelper.GetInstance.GetParameter(paraName, paraValue)
    '    Dim result As Integer = DBHelper.GetInstance.ExecuteNonQuery(strSQL, CommandType.StoredProcedure, parameters)
    '    Return result > 0
    'End Function

    'Public Function Login(ByVal userName As String, ByVal passWord As String, ByRef status As User_status) As UsersModel

    '    Dim objUser As UsersModel = GetUserByUserName(userName)
    '    If objUser.User_name IsNot Nothing Then
    '        If objUser.User_password = Security.GetMD5(passWord) Then
    '            If objUser.User_status = 1 Then
    '                status = User_status.Active
    '            Else
    '                status = User_status.Locked
    '            End If
    '        Else
    '            status = User_status.WrongPass
    '        End If
    '    Else
    '        status = User_status.NotExists
    '    End If

    '    Return objUser
    'End Function

    'Public Function CheckUser(ByRef status As User_status, Optional ByVal userName As String = Nothing, Optional ByVal User_email As String = Nothing) As UsersModel

    '    Dim objUser As UsersModel = GetUserByUserNameOrEmail(userName, User_email)

    '    If objUser.User_name IsNot Nothing Then
    '        If objUser.User_status = 1 Then
    '            status = User_status.Active
    '        Else
    '            status = User_status.Locked
    '        End If
    '    Else
    '        status = User_status.NotExists
    '    End If

    '    Return objUser
    'End Function
End Class
#End Region
