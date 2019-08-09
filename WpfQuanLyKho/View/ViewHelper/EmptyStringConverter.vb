
Public Class EmptyStringConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object,
                     culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            Dim result As Object = Me.EmptyStringToNull(value)
            Return result
        End Function
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object,
                     culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Dim result As Object = Me.EmptyStringToNull(value)
            Return result
        End Function
        Private Function EmptyStringToNull(value As Object) As Object
            Dim stringValue As String = CType(value, String)
            If String.IsNullOrEmpty(value) Then
                Return Nothing
            End If
            Return value
        End Function
    End Class
