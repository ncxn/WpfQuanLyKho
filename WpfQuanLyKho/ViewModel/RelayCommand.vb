Public Class RelayCommand
    Implements ICommand

    Private ReadOnly _canExecute As Predicate(Of Object)
    Private ReadOnly _execute As Action(Of Object)
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object))
        If execute Is Nothing Then Throw New ArgumentNullException("execute")
        _canExecute = canExecute
        _execute = execute
    End Sub
    Public Sub New(ByVal execute As Action(Of Object))
        If execute Is Nothing Then Throw New ArgumentNullException("execute")
        _execute = execute
    End Sub

    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        _execute(CType(parameter, Object))
    End Sub
    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        Return If(_canExecute Is Nothing, True, _canExecute(CType(parameter, Object)))
    End Function
End Class
