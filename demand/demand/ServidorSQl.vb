Imports System.Data.SqlClient

Public Class ServidorSQl
    Public conn As SqlConnection
    Public Shared conexion As New SqlConnection
    Public Shared transaccion As SqlTransaction
    Public Const cadena = "Server=localhost;Database=Matriz;Trusted_Connection=True;"
    Private Const campoCodGestion As Long = 112
    Public Sub New()
        Me.conn = New SqlConnection(cadena)
    End Sub
    Public Shared Sub Conectar()

        Try
            conexion.ConnectionString = cadena
            conexion.Open()
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function GetTabla(ByVal paramQuery As String) As DataTable
        'Devuelve un DataTable instanciado o Nothing si ocurrió un error.
        Dim tabla As New DataTable
        Dim comando As New SqlCommand(paramQuery, conexion)
        Dim resultado As SqlDataReader
        Try
            Conectar()
            comando.CommandType = CommandType.Text
            conexion.Open()
            resultado = comando.ExecuteReader()
            tabla.Load(resultado)
            conexion.Close()
            Return tabla


            Return tabla
        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return Nothing

        Finally
            'adaptador.Dispose()
            'adaptador = Nothing

            comando.Dispose()

            tabla.Dispose()
        End Try
    End Function

    Public Shared Function InsertTabla(ByVal paramQuery As String) As Integer
        'Devuelve un DataTable instanciado o Nothing si ocurrió un error.
        Dim comando As New SqlCommand(paramQuery, conexion)
        Dim resultado As Integer
        Try
            Conectar()
            comando.CommandType = CommandType.Text
            conexion.Open()
            resultado = comando.ExecuteNonQuery
            conexion.Close()
            Return resultado

        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return Nothing
        Finally
            comando.Dispose()
        End Try
    End Function
    Public Shared ReadOnly Property CodGestion() As Long
        Get
            Return campoCodGestion
        End Get
    End Property



End Class
