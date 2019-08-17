Imports System.Collections.ObjectModel

Public Class UcMainMenuVM
    Inherits BaseVM

    Public Property Title As String
    Public Property Command As ICommand
    Public Property SubItems As ObservableCollection(Of UcMainMenuVM)
    Public Property MenuItems As ObservableCollection(Of UcMainMenuVM)
    Sub New()
        MenuItems = New ObservableCollection(Of UcMainMenuVM) From {
                    New UcMainMenuVM With {
                .Title = "File"
        }}

        SubItems = New ObservableCollection(Of UcMainMenuVM) From {
            New UcMainMenuVM With {
                .Title = "Open"
            },
            New UcMainMenuVM With {
                .Title = "Save"
            }
        }

    End Sub
End Class
