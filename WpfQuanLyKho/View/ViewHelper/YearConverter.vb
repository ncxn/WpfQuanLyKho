Public Class YearConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object,
                 culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim result As Object = Me.NullYearToCurrentYear(value)
        Return result
    End Function
    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object,
                 culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Dim result As Object = Me.NullYearToCurrentYear(value)
        Return result
    End Function
    Private Function NullYearToCurrentYear(value As Object) As Object
        If IsNothing(value) Then
            value = DateTime.Now.Year
        End If
        Return value
    End Function
End Class
