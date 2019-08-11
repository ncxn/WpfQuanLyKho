Imports System.Collections.ObjectModel
Imports System.Data

Public Class DataConverter
    Private Shared Function ConvertOBC(ByVal dt As DataTable) As ObservableCollection(Of GenericObject)
        Dim _result As ObservableCollection(Of GenericObject) = New ObservableCollection(Of GenericObject)()

        For Each _row As DataRow In dt.Rows
            Dim _genericObject As GenericObject = New GenericObject()

            For Each _column As DataColumn In dt.Columns
                _genericObject.Properties.Add(New GenericProperty(_column.ColumnName, _row(_column)))
            Next

            _result.Add(_genericObject)
        Next

        Return _result
    End Function
    'Public Shared Function ConvertOBC(Of T)(ByVal source As IEnumerable(Of T)) As ObservableCollection(Of T)
    '    Dim result = New ObservableCollection(Of T)()

    '    For Each item In source
    '        result.Add(item)
    '    Next

    '    Return result
    'End Function
End Class
