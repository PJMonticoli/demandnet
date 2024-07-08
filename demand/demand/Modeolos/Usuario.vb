Public Class Usuario

    'Propiedades de la Clase Usuario
    Private _User As String
    Private _Password As String
    Private _CodUser As Integer
    Private _Host As String
    Private _Permisos As Integer
    Private _Nombre As String
    Private _apellido As String
    Private _Estado As Integer
    Private _Prefijo As Integer
    Private _CAI As String
    Private _FechaVtoCAI As String

    Public Property User As String
        Get
            Return _User
        End Get
        Set(value As String)
            _User = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

    Public Property CodUser As Integer
        Get
            Return _CodUser
        End Get
        Set(value As Integer)
            _CodUser = value
        End Set
    End Property

    Public Property Host As String
        Get
            Return _Host
        End Get
        Set(value As String)
            _Host = value
        End Set
    End Property

    Public Property Permisos As Integer
        Get
            Return _Permisos
        End Get
        Set(value As Integer)
            _Permisos = value
        End Set
    End Property

    Public Property Estado As Integer
        Get
            Return _Estado
        End Get
        Set(value As Integer)
            _Estado = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property

    Public Property Prefijo As Integer
        Get
            Return _Prefijo
        End Get
        Set(value As Integer)
            _Prefijo = value
        End Set
    End Property

    Public Property CAI As String
        Get
            Return _CAI
        End Get
        Set(value As String)
            _CAI = value
        End Set
    End Property

    Public Property FechaVtoCAI As String
        Get
            Return _FechaVtoCAI
        End Get
        Set(value As String)
            _FechaVtoCAI = value
        End Set
    End Property

    'Protocologo del Objeto Usuario
    Public Function LeerUsuario(usuario As Usuario) As Usuario
        'oLeerTabla.RecuperarTabla(otabla, "pa_ConsultaUsuario", "@Nombre", Nombre, "@Clave", Clave)
        Dim usuarioLocal = usuario
        Return usuarioLocal
    End Function


End Class
