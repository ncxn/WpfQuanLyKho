Imports System.Collections.ObjectModel

Public Class GenericObject
    Private ReadOnly _properties As ObservableCollection(Of GenericProperty) = New ObservableCollection(Of GenericProperty)()

    Public Sub New(ParamArray properties As GenericProperty())
        For Each prop In properties
            _properties.Add(prop)
        Next
    End Sub

    Public ReadOnly Property Properties As ObservableCollection(Of GenericProperty)
        Get
            Return _properties
        End Get
    End Property
End Class
