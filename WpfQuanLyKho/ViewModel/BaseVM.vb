Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices

Public Class BaseVM
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _isBusy As Boolean
    Private _IsBusyCmd As ICommand

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function SetProperty(Of T)(ByRef storage As T, value As T, <CallerMemberName> Optional propertyName As String = Nothing) As Boolean
        If Not Object.Equals(storage, value) Then
            storage = value
            OnPropertyChanged(propertyName)
            Return True
        End If
        Return False
    End Function
    Private Sub LoadBusy(ByVal parameter As Object)
        IsBusy = True

    End Sub


    Public Property IsBusy As Boolean
        Get
            Return _isBusy
        End Get
        Set(ByVal value As Boolean)
            _isBusy = value
            OnPropertyChanged(NameOf(IsBusy))
        End Set
    End Property

    Public Property IsBusyCmd As ICommand
        Get
            If _IsBusyCmd Is Nothing Then
                _IsBusyCmd = New RelayCommand(AddressOf LoadBusy, AddressOf CanLoadBusy)
            End If
            Return _IsBusyCmd
        End Get
        Set(value As ICommand)
            _IsBusyCmd = value
        End Set
    End Property

    Private Function CanLoadBusy(arg As Object) As Boolean
        Return IsBusy
    End Function
End Class