Public Class NullableBooleanConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object,
                 culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim result As Object = Me.NullableBooleanToFalse(value)
        Return result
    End Function
    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object,
                 culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Dim result As Object = Me.NullableBooleanToFalse(value)
        Return result
    End Function
    Private Function NullableBooleanToFalse(value As Object) As Object
        If IsNothing(value) Then
            Return False
        Else
            Return value
        End If
    End Function
End Class
