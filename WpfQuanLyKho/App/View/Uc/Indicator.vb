Public Class ControlAdorner
    Inherits Adorner

    Private ReadOnly mAdorningElement As FrameworkElement
    Private mLayer As AdornerLayer

    Public Sub New(ByVal adornedElement As FrameworkElement, ByVal adorningElement As FrameworkElement)
        MyBase.New(adornedElement)
        mAdorningElement = adorningElement
        If adorningElement IsNot Nothing Then AddVisualChild(adorningElement)
    End Sub

    Protected Overrides ReadOnly Property VisualChildrenCount As Integer
        Get
            Return If(mAdorningElement IsNot Nothing, 1, 0)
        End Get
    End Property

    Protected Overrides Function GetVisualChild(ByVal index As Integer) As System.Windows.Media.Visual
        If index = 0 AndAlso mAdorningElement IsNot Nothing Then Return mAdorningElement
        Return MyBase.GetVisualChild(index)
    End Function

    Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
        If mAdorningElement IsNot Nothing Then mAdorningElement.Arrange(New Rect(New Point(0, 0), AdornedElement.RenderSize))
        Return finalSize
    End Function

    Public Sub SetLayer(ByVal layer As AdornerLayer)
        mLayer = layer
        mLayer.Add(Me)
    End Sub

    Public Sub RemoveLayer()
        If mLayer IsNot Nothing Then
            mLayer.Remove(Me)
            RemoveVisualChild(mAdorningElement)
        End If
    End Sub
End Class
