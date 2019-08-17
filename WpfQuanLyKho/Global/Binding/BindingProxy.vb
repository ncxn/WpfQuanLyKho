Imports System.Diagnostics.CodeAnalysis
Imports System.Globalization

Public Class BindingProxy
    Inherits Freezable

    Protected Overrides Function CreateInstanceCore() As Freezable
        Return New BindingProxy()
    End Function

    Public Property Data As Object
        Get
            Return CObj(GetValue(DataProperty))
        End Get
        Set(ByVal value As Object)
            SetValue(DataProperty, value)
        End Set
    End Property

    <SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations", Justification:="It'll be fiiiiine")>
    Public Overrides Function ToString() As String
        Return "BindingProxy: " & Convert.ToString(Data, CultureInfo.CurrentCulture)
    End Function

    Public Shared ReadOnly DataProperty As DependencyProperty = DependencyProperty.Register("Data", GetType(Object), GetType(BindingProxy), New UIPropertyMetadata(Nothing))
End Class