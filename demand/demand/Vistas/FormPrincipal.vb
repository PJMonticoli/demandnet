Imports System.Globalization
Imports System.Runtime.InteropServices
Imports ANALISIS_DE_DEMANDA_UIMOD.Claseglobal
Public Class FormPrincipal
    Public usuario As New Usuario
    Public logueado As Boolean = False
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'Setear el sistema a region españa luego en caso de moneda solo en la linea a mostrar utilizar el cultureinfo es-AR "c"
        System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-ES")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-ES")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub btnFormulario_Click(sender As Object, e As EventArgs) Handles btnFormulario.Click
        Dim frmFiltro As New FormFiltro()
        MostrarFormularioHijoEnGPformularios(frmFiltro)
    End Sub



    Public Sub MostrarFormularioHijoEnGPformularios(formularioHijo As Form)
        formularioHijo.TopLevel = False
        GPformularios.Controls.Clear()
        GPformularios.Controls.Add(formularioHijo)
        formularioHijo.Dock = DockStyle.Fill
        formularioHijo.Show()
    End Sub

    Private Sub MostrarFormularioLogin()
        Dim frmLogin As New FormLogin()

        ' Mostrar el formulario de inicio de sesión como un diálogo
        If frmLogin.ShowDialog() = DialogResult.OK Then
            ' Aquí puedes realizar acciones después de que el usuario ha iniciado sesión correctamente
        End If
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
        End
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim frmVisualizador As New FrmVisualizador(Claseglobal.tablaglobal)
        ' Muestra el formulario FrmVisualizador dentro de GPformularios de FormPrincipal
        MostrarFormularioHijoEnGPformularios(frmVisualizador)
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown, Guna2Panel1.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub
    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        If logueado = False Then
            Dim frmlogin As New FormLogin
            frmlogin.ShowDialog()
            Me.WindowState = FormWindowState.Minimized

        End If
        Me.WindowState = FormWindowState.Normal
        Dim vScrollBar As New VScrollBar()
        vScrollBar.Dock = DockStyle.Right
        GPformularios.Controls.Add(vScrollBar)
        Dim frm As New FormFiltro
        MostrarFormularioHijoEnGPformularios(frm)
        ' Asociar el evento de desplazamiento al controlador de eventos Scroll del panel
        AddHandler vScrollBar.Scroll, AddressOf VScrollBar_Scroll
    End Sub

    Private Sub VScrollBar_Scroll(sender As Object, e As ScrollEventArgs)
        GPformularios.VerticalScroll.Value = e.NewValue
    End Sub

    Private Sub GPformularios_Paint(sender As Object, e As PaintEventArgs) Handles GPformularios.Paint
        btnReporte.Visible = False
    End Sub
End Class
