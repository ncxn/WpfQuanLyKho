Imports VTNCoLtd

Public Class MainVM
    Inherits BaseVM

    Private _Namex As String = String.Empty
    Private _TestCmd As RelayCommand

    Public Property TestCmd As RelayCommand
        Get
            If _TestCmd Is Nothing Then
                _TestCmd = New RelayCommand(AddressOf Test, AddressOf Cantest)
            End If

            Return _TestCmd
        End Get
        Set
            _TestCmd = Value

        End Set
    End Property

    Public Property Namex As String
        Get
            Return _Namex
        End Get
        Set(value As String)
            _Namex = value
            OnPropertyChanged(Namex)
        End Set

    End Property

    Private Sub Test(Paras As Object)
        MessageBox.Show(Namex)
    End Sub
    Private Function Cantest(Paras As Object) As Boolean
        If String.IsNullOrEmpty(Namex) Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
