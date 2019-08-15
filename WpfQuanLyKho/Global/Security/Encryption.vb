Imports System.Security.Cryptography
Imports System.Text

Public Class Encryption
    Public Shared Function GetMD5(ByVal input As String) As String
        Dim md5Hash As MD5 = MD5.Create()
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As StringBuilder = New StringBuilder()

        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next

        Return sBuilder.ToString()
    End Function
    Public Shared Function RandomPassWord(Optional ByVal length As Integer = 8) As String
        Dim allowedChars = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ123456789#@%_."

        Dim chars = New Char(length - 1) {}
        Dim rd = New Random()

        For i = 0 To length - 1
            chars(i) = allowedChars(rd.[Next](0, allowedChars.Length))
        Next

        Return New String(chars)
    End Function

End Class
