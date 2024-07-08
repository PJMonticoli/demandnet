Imports System.Globalization

Public Class Main
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32
    Public Shared Sub Main()
        System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-ES")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-ES")
        'Dim form As New FrmLogin
        'form.Show()
        Dim Informe As String = Environment.GetCommandLineArgs(1)
        If Informe = "PERCEPCIONIVAQ" Then
            Application.EnableVisualStyles()
            Application.Run(FormPrincipal)
        Else
            End
        End If
    End Sub
End Class
