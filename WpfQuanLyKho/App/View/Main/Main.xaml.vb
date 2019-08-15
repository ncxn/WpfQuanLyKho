Imports MahApps.Metro.Controls

Class Main
    Private Navi As New Navigation
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub HamburgerMenuControl_OnItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        Me.HamburgerMenuControl.Content = e.ClickedItem
        Me.HamburgerMenuControl.IsPaneOpen = False
    End Sub
End Class
