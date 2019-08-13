Public Class AdornerBehaviour
    Inherits BaseVM
    Public Shared ReadOnly ShowAdornerProperty As DependencyProperty = DependencyProperty.RegisterAttached("ShowAdorner", GetType(Boolean), GetType(AdornerBehaviour), New UIPropertyMetadata(False, AddressOf OnShowAdornerChanged))
    Public Shared ReadOnly ControlProperty As DependencyProperty = DependencyProperty.RegisterAttached("Control", GetType(FrameworkElement), GetType(AdornerBehaviour), New UIPropertyMetadata(Nothing))
    Private Shared ReadOnly CtrlAdornerProperty As DependencyProperty = DependencyProperty.RegisterAttached("CtrlAdorner", GetType(ControlAdorner), GetType(AdornerBehaviour), New UIPropertyMetadata(Nothing))

    Public Shared Function GetShowAdorner(ByVal obj As DependencyObject) As Boolean
        Return CBool(obj.GetValue(ShowAdornerProperty))
    End Function

    Public Shared Sub SetShowAdorner(ByVal obj As DependencyObject, ByVal value As Boolean)
        obj.SetValue(ShowAdornerProperty, value)
    End Sub

    Public Shared Function GetControl(ByVal obj As DependencyObject) As FrameworkElement
        Return CType(obj.GetValue(ControlProperty), FrameworkElement)
    End Function

    Public Shared Sub SetControl(ByVal obj As DependencyObject, ByVal value As UIElement)
        obj.SetValue(ControlProperty, value)
    End Sub

    Private Shared Sub OnShowAdornerChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        If TypeOf d Is FrameworkElement Then

            If e.NewValue IsNot Nothing Then
                Dim adornedElement As FrameworkElement = TryCast(d, FrameworkElement)
                Dim bValue As Boolean = CBool(e.NewValue)
                Dim adorningElement As FrameworkElement = GetControl(d)
                Dim ctrlAdorner As ControlAdorner = TryCast(adornedElement.GetValue(CtrlAdornerProperty), ControlAdorner)
                If ctrlAdorner IsNot Nothing Then ctrlAdorner.RemoveLayer()

                If bValue AndAlso adorningElement IsNot Nothing Then
                    ctrlAdorner = New ControlAdorner(adornedElement, adorningElement)
                    Dim adornerLayer As AdornerLayer = AdornerLayer.GetAdornerLayer(adornedElement)
                    ctrlAdorner.SetLayer(adornerLayer)
                    d.SetValue(CtrlAdornerProperty, ctrlAdorner)
                End If
            End If
        End If
    End Sub
End Class
