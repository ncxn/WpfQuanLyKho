Public Class Navigation
    Private Shared _frame As Frame

    Public Shared Property Frame As Frame
        Get
            Return _frame
        End Get
        Set(ByVal value As Frame)
            _frame = value
        End Set
    End Property

    Function Navigate(ByVal sourcePageUri As Uri, ByVal Optional extraData As Object = Nothing) As Boolean
        If _frame.CurrentSource <> sourcePageUri Then
            Return _frame.Navigate(sourcePageUri, extraData)
        End If

        Return True
    End Function

    Function Navigate(ByVal content As Object) As Boolean
        If _frame.NavigationService.Content <> content Then
            Return _frame.Navigate(content)
        End If

        Return True
    End Function

    Sub GoBack()
        If _frame.CanGoBack Then
            _frame.GoBack()
        End If
    End Sub
End Class
