Public Class RelayCommand
    Implements ICommand
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Private ReadOnly _execute As Action(Of Object)
    Private ReadOnly _canExecute As Func(Of Object, Boolean)

    Public Sub New(execute As Action(Of Object), Optional canExecute As Func(Of Object, Boolean) = Nothing)
        _execute = execute
        _canExecute = If(canExecute, Function(arg) True)
    End Sub

    Public Sub OnCanExecuteChanged()
        RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
    End Sub
    Public Sub RaiseCanExecuteChanged()
        OnCanExecuteChanged()
    End Sub
    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return _canExecute(parameter)
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If CanExecute(parameter) Then
            _execute(parameter)
        End If
    End Sub
End Class
