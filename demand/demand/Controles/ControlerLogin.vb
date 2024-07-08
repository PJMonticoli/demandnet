Imports System.Data.SqlClient
Public Class ControlerLogin

    Inherits ServidorSQl
    Public Shared Function obtenerVersion() As Boolean
        Dim query As String = "SELECT version FROM datosguma.dbo.gestiones where codGestion = 22 and version = '06/07/2022'"
        Dim dt As DataTable = Nothing
        Try
            dt = GetTabla(query)
            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return "Error al obtener la version"
        Finally
            LimpiarTabla(dt)
        End Try
    End Function

    Public Shared Function obtenerVersion2() As DataTable
        Dim query As String = "SELECT version FROM datosguma.dbo.gestiones where codGestion = 22 and version = '06/07/2022'"
        Dim dt As DataTable = Nothing
        Try
            dt = GetTabla(query)
            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If
        Catch ex As Exception
            Throw ex
        Finally
            LimpiarTabla(dt)
        End Try
    End Function
    Public Shared Function GetNombre(ByVal paramCodUsuario As Long) As String
        Dim dt As DataTable = Nothing
        Dim query As String = "Select NombreApellido from DatosGuma.dbo.UsuariosSistemas where CodUsuario=" & paramCodUsuario
        Try
            dt = GetTabla(query)
            If dt.Rows.Count = 0 Then
                Return "No existe el código de usuario " & paramCodUsuario
            Else
                Return dt.Rows(0)("NombreApellido")
            End If
        Catch ex As Exception
            Return "Error al obtener Nombre"
        Finally
            LimpiarTabla(dt)
        End Try
    End Function


    Public Shared Function GetNombre(ByVal paramUsuario As String) As String
        Dim dt As DataTable = Nothing
        Try
            dt = GetTabla("Select NombreApellido from DatosGuma.dbo.UsuariosSistemas where Usuario like '" & paramUsuario & "'")
            If dt.Rows.Count = 0 Then
                Return "No existe el código de usuario " & paramUsuario
            Else
                Return dt.Rows(0)("NombreApellido")
            End If
        Catch ex As Exception
            Return "Error al obtener Nombre"
        Finally
            LimpiarTabla(dt)
        End Try
    End Function

    Public Shared Function ValidarPermisos(ByVal paramCodPermiso As Long, ByVal UsuarioLogin As String, ByVal clavelogin As String, ByRef obj As Usuario) As Long
        '-----------------------------------------------------
        'Function ValidarPermisos
        'Descripción: verifica si el usuario tiene los permisos para realizar la acción que pretende efectuar
        'Output     :qw
        '             0 No se poseen permisos
        '             1 Sí se poseen permisos
        '            -1 Error al buscar datos
        '            -2 Usuario no existente
        '            -3 Usuario desactivado
        '            -4 Clave no coincidente
        '            -5 Host no Autorizado
        '-----------------------------------------------------

        Dim dtHost As DataTable = Nothing
        Dim dtUsuario As DataTable = Nothing
        Dim dtPermisos As DataTable = Nothing
        Dim query As String
        Dim usuario As New Usuario
        Try
            query = "SELECT Usuario, NombreApellido, CodUsuario, CodEstado, Clave 
                    FROM DatosGuma.dbo.UsuariosSistemas WHERE Usuario='" & Replace(Trim(UsuarioLogin), "'", "`") & "' "
            dtUsuario = GetTabla(query)

            If dtUsuario.Rows.Count = 0 Then
                'Usuario no existente
                Return -2
            Else
                usuario.CodUser = dtUsuario.Rows(0)!CodUsuario
                usuario.Nombre = dtUsuario.Rows(0)!NombreApellido
                usuario.Estado = dtUsuario.Rows(0)!CodEstado
                usuario.User = dtUsuario.Rows(0)!Usuario
                usuario.Password = dtUsuario.Rows(0)!Clave
                VariablesGlobales.idusuario = usuario.CodUser
                'valido host desde donde estoy ejecutando la aplicación
                query = "SELECT hu.codusuario,h.deschost FROM datosguma.dbo.hostsXUsuario hu 
                        INNER JOIN datosguma.dbo.Hosts h ON hu.codhost = h.codhost 
                        WHERE hu.codusuario=" & usuario.CodUser & " AND hu.codgestion =" & CodGestion
                dtHost = GetTabla(query)
                If dtHost.Rows.Count = 0 Then
                    'no existen datos de host asociados al usuario en la base
                    dtHost = Nothing
                    Return -5
                Else
                    Dim HostAutorizado As Boolean = False
                    For Each x As DataRow In dtHost.Rows
                        If UCase(Trim(x!descHOST)) = UCase(Trim(My.Computer.Name)) Then
                            HostAutorizado = True
                            Exit For
                        End If
                    Next
                    If HostAutorizado = False Then
                        'el usuario no está autorizado a ejecutar esta aplicación en este host
                        Return -5
                    End If

                    If dtUsuario.Rows(0)!CodEstado <> 1 Then
                        'usuario desactivado
                        Return -3
                    End If

                    If UCase(Trim(dtUsuario.Rows(0)!Clave)) <> UCase(Trim(clavelogin)) Then
                        'clave no coincidente
                        Return -4
                    End If
                End If
            End If
            query = "SELECT p.codPermiso 
                    FROM datosguma.dbo.Permisos p
                     INNER JOIN datosguma.dbo.PermisosXUsuario pu ON p.codPermiso = pu.codPermiso 
                    WHERE pu.codUsuario = " & usuario.CodUser & " AND p.codGestion=" & CodGestion &
                    "AND p.codestado = 1 and pu.codPermiso=" & paramCodPermiso
            dtPermisos = GetTabla(query)
            If dtPermisos.Rows.Count = 0 Then
                'No posee permisos
                Return 0
            Else
                'Posee permisos
                Return 1
            End If
        Catch ex As Exception
            Return -1
        Finally
            LimpiarTabla(dtHost)
            LimpiarTabla(dtUsuario)
            LimpiarTabla(dtPermisos)
        End Try
    End Function

#Region "ESTO PROVIENE DE LA SOLUCION ABMFRACCIONAMIENTO"
    Public Shared Sub LimpiarTabla(ByRef paramTabla As DataTable)
        Try
            'La instancio por las dudas que el parámetro que reciba no esté instanciado, 
            'de esta forma nunca tendría que tirar error el .Dispose()
            paramTabla = New DataTable
            paramTabla.Dispose()
            paramTabla = Nothing
        Catch ex As Exception
            'En teoría no tendría que entrar nunca acá.
            MsgBox("No se pudo limpiar la tabla.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
#End Region
End Class
