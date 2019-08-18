
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Windows.Markup

Class Main
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New MainMenuVM
    End Sub

End Class