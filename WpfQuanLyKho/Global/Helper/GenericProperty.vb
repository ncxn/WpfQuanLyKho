Imports System.ComponentModel

Public Class GenericProperty
    Implements INotifyPropertyChanged

    Public Property _Name As String
    Public Property _Value As Object
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub New(ByVal name As String, ByVal value As Object)
        _Name = name
        _Value = value
    End Sub
End Class
