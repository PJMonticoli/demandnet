Imports System.IO
Imports Controles
Imports Modelos

Public Class FormLogin
    Public obj As New Usuario
    Dim Datos As New ControlerLogin
    Public Property Variablesglobales As Object

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lblestado.Text = "Análisis De Demanda"
        Lblestado.ForeColor = Color.FromArgb(255, 255, 255)
        Lblestado.Font = New Font(Lblestado.Font, FontStyle.Bold)
        ' Centrar el Label horizontalmente en el formulario
        Lblestado.Left = (Pnlestado.Width - Lblestado.Width) / 2
        If My.Computer.Name = "SISTEMAS7" Then 'aca cambie el nombre de SISTEMAS2 a SISTEMAS para que no me tire el combo (07-10-2020)
            TxtUsuario.Text = "jorgedc"
            TxtContraseña.Text = "cabreraj"
        End If
        If Version() = False Then
            MsgBox("No se puede abrir el programa porque posee una versión desactualizada. Contactese con sistemas", vbOKOnly + vbObjectError, "Version Desactualizada")
            End
        End If
    End Sub
    Private Sub CorroborarDatos()
        Dim errores As String = ValidarCampos()
        If errores <> "" Then
            Autorización("NO")
            MessageBox.Show("Se encontraron los siguientes errores: " & errores, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Autorización("BLOQUEADO")
            Exit Sub
        End If


        Select Case Datos.ValidarPermisos(209, TxtUsuario.Text, TxtContraseña.Text, obj)
            Case 1 'Sí se poseen permisos
                obj.User = TxtUsuario.Text
                '  Variablesglobales.idusuario = obj.CodUser
                Autorización("SI")
            Case 0 'No se poseen permisos
                Autorización("NO")
                MsgBox("Se ha detectado que el usuario ingresado no posee permisos para la aplicación, comuníquese con el departamento de sistemas.", vbCritical, "Inicio de sesión")
                Autorización("BLOQUEADO")
                Me.TxtUsuario.Focus()

            Case -1 'Error al buscar datos
                Autorización("NO")
                MsgBox("Se ha producido un error al buscar datos, comuníquese con el departamento de sistemas.", vbCritical, "Inicio de sesión")
                Me.TxtUsuario.Focus()
                Autorización("BLOQUEADO")

            Case -2 '-2 Usuario no existente
                Autorización("NO")
                MsgBox("No se ha encontrado el usuario ingresado, verifique los datos e intente nuevamente.", vbInformation, "Inicio de sesión")
                Me.TxtUsuario.Focus()
                Autorización("BLOQUEADO")

            Case -3 'Usuario desactivado
                Autorización("NO")
                MsgBox("El usario ha sido desactivado en la gestión, comuníquese con el departamento de sistemas.", vbExclamation, "Inicio de sesión")
                Me.TxtUsuario.Focus()
                Autorización("BLOQUEADO")

            Case -4 'Clave no coincidente
                Autorización("NO")
                MsgBox("La contraseña no es válida, vuelva a intentarlo.", vbInformation, "Inicio de sesión")
                TxtContraseña.Focus()
                Autorización("BLOQUEADO")

            Case -5 'Host no autorizado
                Autorización("NO")
                MsgBox("Ud. no está autorizado a ejecutar la gestión en este equipo.", vbInformation, "Inicio de sesión")
                Me.TxtUsuario.Focus()
                Autorización("BLOQUEADO")

        End Select
    End Sub
    Private Sub Autorización(ByVal Estado As String)

        Select Case Estado
            Case "SI"
                Lblestado.Text = "Acceso Autorizado"
                Lblestado.ForeColor = Color.Green
                ' Pnlestado.BackColor = Color.Black
                Congelar(0.7)
                Me.Refresh()
                'obj.User = TxtUsuario.Text
                'Variablesglobales.idusuario = obj.CodUser
                FormPrincipal.logueado = True
                Me.Close()
                FormPrincipal.WindowState = FormWindowState.Normal
            Case "NO"
                ' Pnlestado.BackColor = Color.Black
                Lblestado.Text = "Acceso Denegado"
                Lblestado.ForeColor = Color.Red
                Me.Refresh()

            Case "BLOQUEADO"
                ' Pnlestado.BackColor = Color.Black
                Lblestado.Text = "Planificación de Recursos"
                Lblestado.ForeColor = Color.Black
                Me.Refresh()
        End Select
    End Sub
    Private Sub Congelar(ByVal Segundos As Integer)
        Dim Fin As Date = Now.AddSeconds(Segundos)
        Dim Ahora As Date

        While Ahora <= Fin
            Ahora = Now
        End While
    End Sub

    Private Function ValidarCampos() As String
        Try
            Dim errores As String = ""

            If Trim(TxtUsuario.Text) = "" Then errores = errores & vbCr & "- Nombre de usuario en blanco."
            If Trim(TxtContraseña.Text) = "" Then errores = errores & vbCr & "- Contraseña en blanco."

            Return errores
        Catch ex As Exception
            Return "Error en validación de datos."
        End Try
    End Function

    Private Sub TxtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            TxtContraseña.Focus()
        End If
    End Sub


    Private Sub TxtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtContraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            CorroborarDatos()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Esta seguro que desea cancelar?", vbOKCancel + vbQuestion, "Salir del Sistema") = vbOK Then
            End
        Else
            TxtContraseña.Text = ""
            TxtUsuario.Text = ""
        End If
    End Sub

    Private Sub BtnIngresar_Click_1(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        CorroborarDatos()
    End Sub

    Private Sub Btncerrar_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Esta seguro que desea salir?", vbOKCancel + vbQuestion, "Salir del Sistema") = vbOK Then
            End
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Public Function Version() As Boolean
        Try
            Datos.obtenerVersion()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function versionstring() As String
        Try
            Dim version
            version = Datos.obtenerVersion2()
            Return version
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class