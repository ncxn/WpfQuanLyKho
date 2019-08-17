
Imports System.IO
Imports System.Windows.Markup

Class Main

    Public Sub New()
        InitializeComponent()
        Using s As FileStream = New FileStream("Menu.xaml", FileMode.Open)
            Dim menu As System.Windows.Controls.Menu = TryCast(XamlReader.Load(s, New ParserContext()), System.Windows.Controls.Menu)

            If menu IsNot Nothing Then
                main.Children.Insert(0, menu)
            End If
        End Using

    End Sub

End Class
