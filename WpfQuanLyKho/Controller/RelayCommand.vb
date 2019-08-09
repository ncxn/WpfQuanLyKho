' Michel Posseth 20-01-2011
' info@vbdotnetcoder.com
Public Class RelayCommand
    Implements ICommand
    ReadOnly _Execute As Action(Of Object)
    ReadOnly _CanExecute As Predicate(Of Object)
    Public Event CanExecuteChanged(ByVal sender As Object, ByVal e As EventArgs) Implements ICommand.CanExecuteChanged

    Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object))
        If execute IsNot Nothing Then
            _Execute = execute
            _CanExecute = canExecute
        End If
    End Sub
    Public Sub New(ByVal execute As Action(Of Object))
        Me.New(execute, Nothing)
    End Sub
    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        Return If(_CanExecute Is Nothing, True, _CanExecute(parameter))
    End Function
    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        If CanExecute(parameter) Then
            _Execute(parameter)
        End If
    End Sub
    Public Sub RaiseCanExecuteChanged()
        RaiseEvent CanExecuteChanged(Me, Nothing)
    End Sub
End Class