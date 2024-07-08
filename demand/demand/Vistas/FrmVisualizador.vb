
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports DocumentFormat.OpenXml.Vml.Office
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
'Imports DocumentFormat.OpenXml.Drawing
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Diagnostics
Imports Guna.UI2.WinForms
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ToolTip = System.Windows.Forms.ToolTip
Imports System.ComponentModel

Public Class FrmVisualizador
    Dim controler As New ControllerBusqueda
    Dim colorFondo As System.Drawing.Color = System.Drawing.Color.FromArgb(240, 240, 240) ' Color de fondo para todos los controles
    Public tabla As DataTable
    Public tabladetalle As DataTable
    ' Crear y configurar el DataGridView
    Dim dataGridView1 As New Guna2DataGridView()
    Public cadenaproductos As String
    Public FechaDesde As Date
    Public FechaHasta As Date
    Public tipopackagin As Int16
    Public tipoinforme As Int16
    Public familia As String
    Public itemsSeleccionadosString As String
    Public tipofecha As Int16
    Public WithEvents ToolTip1 As New ToolTip()
    Public EstadoPedidos As String = String.Empty
    Dim labelchart As New Label
    ' Configurar el chart
    Dim totalPedido As Double = 0
    Dim chart1 As New Chart()
    Dim flag As Boolean

    Public Property Tipo As String
    Public Property Seleccion As String
    'Dim chart1 As New Chart()
    Public Sub New(tabla As DataTable)
        InitializeComponent()
        AddHandler Me.Resize, AddressOf FrmVisualizador_Resize
        Me.tabla = tabla
    End Sub


    Private Sub FrmVisualizador_Resize(sender As Object, e As EventArgs)
        ' Ajustar el tamaño y la posición del chart1
        Dim chartWidth As Integer = Me.Width - 300 ' Ancho del gráfico
        Dim chartHeight As Integer = Me.Height - 400 ' Alto del gráfico
        chart1.Width = chartWidth
        chart1.Height = chartHeight
        chart1.Left = (Me.Width - chartWidth) / 2
        chart1.Top = (Me.Height - chartHeight) / 2 - 160 ' Subir el chart1 en 50 píxeles

        ' Ajustar el ancho del dataGridView1 y su posición
        Dim dataGridViewWidth As Integer = If(tipoinforme = 1, Me.Width - 300, Me.Width - 300) ' Cambiar los valores según tus necesidades
        dataGridView1.Width = dataGridViewWidth
        dataGridView1.Top = chart1.Bottom + 70 ' 20 píxeles de espacio vertical entre el chart1 y el dataGridView1
        dataGridView1.Left = (Me.Width - dataGridViewWidth) / 2

        ' Calcular la posición horizontal del centro del formulario
        Dim centroFormulario As Integer = Me.Width / 2

        ' Calcular el espacio entre los controles y el espacio horizontal ocupado por los controles
        Dim espacioEntreControles As Integer = 20 ' Espacio entre los controles

        ' Configurar la posición de lblFiltro
        lblFiltro.Left = chart1.Left + 20 ' Ajusta este valor según sea necesario para la posición inicial
        lblFiltro.Top = chart1.Bottom + 20 ' Espacio vertical entre el chart y los controles
        lblTipoDetalle.Left = chart1.Left + 20
        lblTipoDetalle.Top = chart1.Bottom + 55
        ' Configurar la posición de txtFiltro
        txtFiltro.Left = lblFiltro.Right + espacioEntreControles
        txtFiltro.Top = lblFiltro.Top

        ' Configurar la posición de btnActualizar
        btnActualizar.Left = txtFiltro.Right + espacioEntreControles
        btnActualizar.Top = lblFiltro.Top

        ' Configurar la posición de btnLimpiarcheck
        btnLimpiarcheck.Left = btnActualizar.Right + espacioEntreControles
        btnLimpiarcheck.Top = lblFiltro.Top

        ' Configurar la posición de btnSeleccionar
        btnSeleccionar.Left = btnLimpiarcheck.Right + espacioEntreControles
        btnSeleccionar.Top = lblFiltro.Top

        ' Configurar la posición de btnPDFResumen
        btnPDFResumen.Left = btnSeleccionar.Right + espacioEntreControles
        btnPDFResumen.Top = lblFiltro.Top

        ' Configurar la posición de btnPDFDesagregado
        btnPDFDetallado.Left = btnSeleccionar.Right + espacioEntreControles
        btnPDFDetallado.Top = lblFiltro.Top

        ' Configurar la posición de btnExcel
        btnExcel.Left = btnPDFResumen.Right + espacioEntreControles
        btnExcel.Top = lblFiltro.Top

        ' Configurar la posición de btnVolver
        btnVolver.Left = btnExcel.Right + espacioEntreControles
        btnVolver.Top = lblFiltro.Top
        Panel1.Left = (Me.Width / 2) - 200
        Panel1.Top = (Me.Height / 2) - 200
        If tipopackagin = 1 Then
            lblTipoDetalle.Text = "Tipo de Detalle: CAJAS"
        Else
            lblTipoDetalle.Text = "Tipo de Detalle: TONELADAS"
        End If
    End Sub


    'Formato del form
    Private Sub FrmVisualizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar la propiedad Anchor del chart1
        chart1.Anchor = AnchorStyles.Left Or AnchorStyles.Right

        ' Configurar la propiedad Anchor del dataGridView1
        dataGridView1.Anchor = AnchorStyles.Left Or AnchorStyles.Right

        Dim cantidadDias As Integer = (FechaHasta.Date - FechaDesde.Date).TotalDays
        Me.BackColor = colorFondo
        Panel1.Visible = False
        ' Configurar el título del formulario
        Me.Text = "Análisis de Demanda"

        Try

            ' Configurar posición del título
            tituloForm.Left = (Me.Width / 2) + 20
            tituloForm.Top = 10


            ConfigurarChart(chart1)
            ConfigurarDataGridView(dataGridView1)
            ConfigurarTextBox(txtFiltro)

            If (tipoinforme = 1) Then
                btnPDFResumen.Visible = True
                btnPDFDetallado.Visible = False
            Else
                btnPDFResumen.Visible = False
                btnPDFDetallado.Visible = True
            End If

            ' Configurar los botones
            btnActualizar.Visible = False
            btnActualizar.Left = (chart1.Left + (chart1.Width - txtFiltro.Width) / 2) + 250
            btnActualizar.Top = (chart1.Top + chart1.Height) + 15
            btnLimpiarcheck.Left = (chart1.Left + (chart1.Width - txtFiltro.Width) / 2) + 350
            btnLimpiarcheck.Top = chart1.Top + chart1.Height + 15
            btnLimpiarcheck.Enabled = False
            btnSeleccionar.Left = (chart1.Left + (chart1.Width - txtFiltro.Width) / 2) + 450
            btnSeleccionar.Top = chart1.Top + chart1.Height + 15
            btnSeleccionar.Visible = False
            ' Ajustar la posición del botón Imprimir al lado de btnSeleccionar
            btnPDFResumen.Left = btnSeleccionar.Left + btnSeleccionar.Width + 10 ' Colocar btnImprimir al lado derecho de BtnSeleccionar con un espacio de 10 píxeles
            btnExcel.Left = btnSeleccionar.Left + btnPDFResumen.Width + btnSeleccionar.Width + 20
            btnExcel.Top = btnSeleccionar.Top
            btnVolver.Left = btnPDFResumen.Left + btnPDFResumen.Width + btnExcel.Width + 25 ' Colocar btnImprimir al lado derecho de BtnSeleccionar con un espacio de 10 
            btnVolver.Top = btnSeleccionar.Top
            btnPDFResumen.Top = btnSeleccionar.Top ' Mantener la misma posición en el eje Y que BtnSeleccionar
            '  btnImprimirPDF.Visible = False ' Asegurar que el botón Imprimir esté invisible al principio (puedes cambiar esto según tu lógica)

            lblTotalPedidos.Top = chart1.Top + chart1.Height + 52
            lblTotalPedidos.Left = (chart1.Left + (chart1.Width - txtFiltro.Width) / 2) + 450
            ' Agregar controles al formulario
            Me.Controls.Add(txtFiltro)
            Me.Controls.Add(lblFiltro)
            Me.Controls.Add(btnActualizar)
            Me.Controls.Add(btnLimpiarcheck)
            Me.Controls.Add(btnSeleccionar)
            Me.Controls.Add(btnPDFResumen)
            cargarchart1(tabla)


            ' Configurar el DataGridView
            dataGridView1.Name = "dataGridView1"
            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = "Selec."
            checkBoxColumn.Name = "Selec."
            dataGridView1.Columns.Add(checkBoxColumn)

            Dim dataGridViewWidth As Integer = If(tipoinforme = 1, Me.Width - 1100, Me.Width - 900)
            dataGridView1.Width = dataGridViewWidth
            dataGridView1.Height = 270
            dataGridView1.Left = (Me.Width - dataGridViewWidth) / 2
            dataGridView1.Top = txtFiltro.Top + txtFiltro.Height + 25
            dataGridView1.RowHeadersVisible = False
            dataGridView1.AllowUserToAddRows = False
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect



            ' Agregar DataGridView al formulario
            Me.Controls.Add(dataGridView1)
            Me.Controls.Add(chart1)
            ' Llenar el DataGridView con datos
            dataGridView1.DataSource = tabladetalle
            dataGridView1.Visible = True
            Formatodgv(dataGridView1)

            ' Manejar eventos del DataGridView y del Chart
            AddHandler dataGridView1.DoubleClick, AddressOf DataGridView1_DoubleClick
            AddHandler dataGridView1.CurrentCellDirtyStateChanged, AddressOf dataGridView1_CurrentCellDirtyStateChanged
            AddHandler dataGridView1.CellContentClick, AddressOf dataGridView1_CellContentClick
            AddHandler dataGridView1.CellValueChanged, AddressOf dataGridView1_CellValueChanged
            AddHandler chart1.MouseMove, AddressOf chart1_MouseMove
            AddHandler dataGridView1.CellFormatting, AddressOf DataGridView1_CellFormatting
            AddHandler dataGridView1.CellPainting, AddressOf dgv_CellPainting
            AddHandler dataGridView1.RowPostPaint, AddressOf dgv_RowPostPaint
            AddHandler dataGridView1.DataBindingComplete, AddressOf dgv_DataBindingComplete
            AddHandler dataGridView1.Paint, AddressOf Guna2DataGridView1_Paint
            AddHandler dataGridView1.Scroll, AddressOf DataGridView1_Scroll

            For Each column As DataGridViewColumn In dataGridView1.Columns
                column.HeaderText = column.HeaderText.ToUpper()
            Next
            FrmVisualizador_Resize(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        ' Configurar estilo después de que se haya completado el enlace de datos
        Formatodgv(dataGridView1)
    End Sub



    Private Sub chart1_MouseMove(sender As Object, e As MouseEventArgs)
        Dim result As HitTestResult = chart1.HitTest(e.X, e.Y)

        ' Restaurar el estilo de todos los puntos de datos
        For Each point As DataPoint In chart1.Series("ventas").Points
            point.MarkerStyle = MarkerStyle.None ' Restaurar al estilo original
        Next

        ' Verificar si el cursor está sobre un punto de datos
        If result.ChartElementType = ChartElementType.DataPoint Then
            Dim index As Integer = result.PointIndex
            Dim dataPoint As DataPoint = chart1.Series("ventas").Points(index)

            ' Cambiar el estilo del punto de datos para resaltar la selección
            dataPoint.MarkerStyle = MarkerStyle.Circle ' Puedes elegir el estilo que prefieras
            dataPoint.MarkerSize = 10 ' Tamaño del marcador
            dataPoint.MarkerColor = System.Drawing.Color.Red ' Color del marcador

            ' Obtener la fecha y las toneladas vendidas del punto de datos
            Dim fecha As String = dataPoint.AxisLabel
            Dim toneladas As Double = dataPoint.YValues(0)

            ' Mostrar la fecha y las toneladas vendidas en el ToolTip
            ToolTip1.SetToolTip(chart1, $"Fecha: {fecha}{Environment.NewLine}Toneladas Pedidas: {toneladas}")
        Else
            ' Si el cursor no está sobre un punto de datos, ocultar el ToolTip
            ToolTip1.Hide(chart1)
        End If

    End Sub

    Private Sub ConfigurarDataGridView(dataGridView As Guna2DataGridView)
        ' Configurar propiedades del DataGridView
        dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(240, 240, 240)
        dataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
        dataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(45, 45, 45)
        dataGridView.GridColor = System.Drawing.Color.FromArgb(0, 123, 255)
        dataGridView.RowHeadersVisible = False
        'dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridView.AllowUserToAddRows = False
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' ... más configuraciones según sea necesario
    End Sub

    Private Sub Guna2DataGridView1_Paint(sender As Object, e As PaintEventArgs)
        ' Obtener el número total de columnas
        Dim columnCount As Integer = dataGridView1.ColumnCount

        ' Iterar sobre cada columna y dibujar una línea vertical
        For i As Integer = 0 To columnCount - 1
            ' Calcular la posición X de la línea
            Dim xPosition As Integer = dataGridView1.GetColumnDisplayRectangle(i, True).Right

            ' Dibujar la línea vertical
            e.Graphics.DrawLine(Pens.Gray, xPosition, 0, xPosition, dataGridView1.Height)
        Next
    End Sub

    Private Sub DataGridView1_Scroll(sender As Object, e As ScrollEventArgs)
        dataGridView1.Invalidate()
    End Sub

    Private Sub ConfigurarTextBox(txtBox As Guna2TextBox)
        ' Configurar propiedades del TextBox
        txtBox.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
        txtBox.ForeColor = System.Drawing.Color.FromArgb(45, 45, 45)
        txtBox.BorderStyle = BorderStyle.FixedSingle
        ' Configurar el TextBox para el filtro
        txtFiltro.Name = "txtFiltro"
        txtFiltro.Width = 230 ' Establecer el ancho del TextBox según tus necesidades
        txtFiltro.Left = (chart1.Left + (chart1.Width - txtFiltro.Width) / 2) ' Alinear en el centro horizontalmente respecto al Chart
        txtFiltro.Top = chart1.Top + chart1.Height + 20 ' Colocar debajo del Chart con un espacio de 20 píxeles

        lblFiltro.Name = "lblFiltro"
        lblFiltro.Width = 150 '
        lblFiltro.Left = (chart1.Left + (chart1.Width - lblFiltro.Width) / 2) - 200
        lblFiltro.Top = chart1.Top + chart1.Height + 20

        ' ... más configuraciones según sea necesario
    End Sub

    Private Sub ConfigurarChart(chart As Chart)
        Dim chartWidth As Integer
        If Me.WindowState = FormWindowState.Maximized Then

            chartWidth = Me.Width - 800
        Else
            chartWidth = 500
        End If
        ' Configurar propiedades generales del Chart
        chart.ChartAreas.Add("chartarea1")
        chart.BackColor = System.Drawing.Color.FromArgb(255, 220, 220, 220)
        ' Establecer un tamaño adecuado para el chart
        chart1.Width = chartWidth ' ancho del formulario menos un margen de 300 píxeles
        If Me.WindowState = FormWindowState.Maximized Then
            chart1.Height = Me.Height - 600 ' alto del formulario menos un margen de 300 píxeles
        Else
            chart1.Height = 350
        End If



        '  Configurar el borde general del gráfico
        chart1.ChartAreas("chartarea1").BorderColor = System.Drawing.Color.Black ' Establecer el color del borde
        chart1.ChartAreas("chartarea1").BorderDashStyle = ChartDashStyle.Solid ' Establecer el estilo del borde (línea sólida)
        chart1.ChartAreas("chartarea1").BorderWidth = 2 ' Establecer el ancho del borde en píxeles

        ' Establecer el padding externo del área del gráfico (espacio fuera del área del gráfico)
        chart1.ChartAreas("chartarea1").Position.Auto = False
        chart1.ChartAreas("chartarea1").Position.Width = 90 ' Ancho del área del gráfico (porcentaje del área total)
        chart1.ChartAreas("chartarea1").Position.Height = 90 ' Altura del área del gráfico (porcentaje del área total)
        chart1.ChartAreas("chartarea1").Position.X = 5 ' Posición X del área del gráfico (porcentaje del área total)
        chart1.ChartAreas("chartarea1").Position.Y = 10 ' Posición Y del área del gráfico (porcentaje del área total)

        ' centrar el chart en el formulario
        chart1.Left = (Me.Width - chart1.Width) / 2
        chart1.Top = 70

        ' Configurar la serie en el gráfico
        chart.Series.Add("ventas")
        chart.Series("ventas").ChartType = SeriesChartType.SplineArea ' Usar SplineArea para curvas suaves
        chart.Series("ventas").BorderWidth = 4
        chart.Series("ventas").Color = System.Drawing.Color.FromArgb(102, 102, 255)
        chart.Series("ventas").IsXValueIndexed = True
        chart.Series("ventas").BackHatchStyle = ChartHatchStyle.Percent05



        ' Configurar el intervalo en el eje X
        Dim cantidadDias As Integer = (FechaHasta.Date - FechaDesde.Date).TotalDays
        If cantidadDias > 35 Then
            chart.ChartAreas("chartarea1").AxisX.Interval = 5
        Else
            chart.ChartAreas("chartarea1").AxisX.Interval = 1
        End If
        'Crear un objeto Font con el estilo negrita y el tipo de letra "Segoe UI"
        Dim fuenteNegrita As New System.Drawing.Font("Segoe UI", 12, FontStyle.Bold)


        ' Configurar el formato de las etiquetas en el eje X
        chart.ChartAreas("chartarea1").AxisX.LabelStyle.Format = "ddd dd/MM"
        chart.ChartAreas("chartarea1").AxisX.LabelStyle.Format = chart.ChartAreas("chartarea1").AxisX.LabelStyle.Format.ToUpper()
        chart.ChartAreas("chartarea1").AxisX.LabelStyle.Angle = -45



        ' Configurar el título del gráfico con la fuente y estilo negrita
        Dim title As New Title()
        title.Text = "Familia: " & familia
        title.Font = New System.Drawing.Font("Segoe UI", 10, FontStyle.Bold) ' Establecer el estilo de fuente negrita y tamaño 12
        title.Position.Auto = False ' Deshabilitar la posición automática
        title.Position.X = 50 ' Ajustar la posición X del título (fuera del área de dibujo)
        title.Position.Y = 3 ' Ajustar la posición Y del título (fuera del área de dibujo)
        title.IsDockedInsideChartArea = False ' Asegurar que el título no esté dentro del área del gráfico
        chart.Titles.Add(title)

        ' Configurar el eje X y Y
        chart.ChartAreas("chartarea1").AxisX.Title = "Período Desde: " & FechaDesde.ToShortDateString() & " Hasta: " & FechaHasta.ToShortDateString()
        chart.ChartAreas("chartarea1").AxisY.Title = "Toneladas"
        chart.ChartAreas("chartarea1").AxisY.TitleFont = New System.Drawing.Font("Arial", 12)
        chart.ChartAreas("chartarea1").AxisX.TitleFont = New System.Drawing.Font("Arial", 12)

        ' Configurar el título del estado de los pedidos fuera del gráfico
        Dim estadoPedidosTitle As New Title()
        estadoPedidosTitle.Text = "Estado Pedidos: " & IIf(EstadoPedidos.Trim() <> "", EstadoPedidos, "Todos")
        estadoPedidosTitle.Position.Auto = False ' Deshabilitar la posición automática
        estadoPedidosTitle.Position.X = 80 ' Ajustar la posición X del título (fuera del área de dibujo a la derecha)
        estadoPedidosTitle.Position.Y = IIf(title.Text.Length > 30, 95, 4) ' Ajustar la posición Y del título (fuera del área de dibujo)
        estadoPedidosTitle.IsDockedInsideChartArea = False ' Asegurar que el título no esté dentro del área del gráfico
        chart.Titles.Add(estadoPedidosTitle)

        ' Configurar el título del estado de los pedidos fuera del gráfico
        Dim lblChart As New Title()
        lblChart.Text = "Sabados y Domingos acumulados en el día Lunes"
        lblChart.Position.Auto = False ' Deshabilitar la posición automática
        lblChart.Position.X = 20 ' Ajustar la posición X del título (fuera del área de dibujo a la derecha)
        lblChart.Position.Y = IIf(title.Text.Length > 30, 95, 4) ' Ajustar la posición Y del título (fuera del área de dibujo)
        lblChart.IsDockedInsideChartArea = False ' Asegurar que el título no esté dentro del área del gráfico
        ' Configurar la fuente en negrita
        lblChart.Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
        chart.Titles.Add(lblChart)

    End Sub

    Private Sub Formatodgv(dgv As DataGridView)
        dgv.Columns("Selec.").ReadOnly = False
        'dgv.ReadOnly = True
        dgv.ReadOnly = False
        dgv.Columns("DESCRIPCIÓN").ReadOnly = True
        dgv.Columns("CODPRODUCTO").ReadOnly = True
        ' Resto de tus configuraciones de columnas...
        dgv.AutoGenerateColumns = False

        dgv.AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
        dgv.AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
        dgv.MultiSelect = True
        dgv.EditMode = DataGridViewEditMode.EditOnEnter
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' Ajustar la altura de la fila de encabezado (fila de títulos)
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
        ' Establecer la altura del encabezado de las columnas
        dataGridView1.ColumnHeadersHeight = 25

        ' Ajustar la altura de la primera fila de datos (encabezado de las filas)
        If dataGridView1.Rows.Count > 0 Then
            dataGridView1.Rows(0).Height = 25 ' Puedes ajustar el valor según tus necesidades
        End If
        ' Establecer un tamaño de fuente más pequeño para las celdas
        Dim nuevoTamanoFuente As New System.Drawing.Font(dgv.DefaultCellStyle.Font.FontFamily, 8.5)

        ' Aplicar el nuevo tamaño de fuente a todas las columnas
        For Each columna As DataGridViewColumn In dgv.Columns
            columna.DefaultCellStyle.Font = nuevoTamanoFuente
        Next

        ' Aplicar el nuevo tamaño de fuente a todas las filas
        For Each fila As DataGridViewRow In dgv.Rows
            fila.DefaultCellStyle.Font = nuevoTamanoFuente
        Next

        ' Ajustar la altura de la fila de encabezado según el contenido del texto
        For Each column As DataGridViewColumn In dataGridView1.Columns
            Dim headerText As String = column.HeaderText
            Dim headerSize As SizeF = TextRenderer.MeasureText(headerText, dataGridView1.Font)
            ' Ajustar el valor 10 según sea necesario para proporcionar un espacio adicional
        Next

        dataGridView1.Sort(dataGridView1.Columns("CODPRODUCTO"), ListSortDirection.Ascending)
        ' Cambiar el nombre de la columna "CODPRODUCTO" a "CÓDIGO"
        If dgv.Columns.Contains("CODPRODUCTO") Then
            dgv.Columns("CODPRODUCTO").HeaderText = "COD."
        End If

        ' Alinear texto a la derecha para las columnas 0 y 2
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        If dgv.Columns.Count < 7 Then ' resumen
            For Each column As DataGridViewColumn In dataGridView1.Columns
                column.MinimumWidth = 90
            Next
            If dgv.Columns.Count = 5 Then
                dgv.Columns(1).Width = 50
                dgv.Columns(2).Width = 250
                dgv.Columns(3).Width = 110
                dgv.Columns(4).Width = 100
                dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(3).DefaultCellStyle.Format = "N2"
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(4).DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("es-AR")
                dgv.Columns(4).DefaultCellStyle.Format = "N0"
            Else
                dgv.Columns(0).Width = 50
                dgv.Columns(1).Width = 50
                dgv.Columns(2).Width = 250
                dgv.Columns(5).Width = 120
                dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(4).DefaultCellStyle.Format = "N0"
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(5).DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("es-AR")
                dgv.Columns(5).DefaultCellStyle.Format = "N2"
            End If
        Else

            dgv.Columns(0).Width = 50 'Seleccion
            dgv.Columns(1).Width = 50 'codProducto
            dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgv.Columns(2).Width = 250 ' Producto


            ' Diccionario para mapear nombres completos de los días a sus abreviaturas
            Dim diasAbreviados As New Dictionary(Of String, String)()
            diasAbreviados.Add("Lunes", "LU")
            diasAbreviados.Add("Martes", "MA")
            diasAbreviados.Add("Miércoles", "MI")
            diasAbreviados.Add("Jueves", "JU")
            diasAbreviados.Add("Viernes", "VI")

            For i = 0 To dgv.ColumnCount - 1
                If i >= 3 Then
                    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgv.Columns(i).DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("es-AR")
                    dgv.Columns(i).Width = 40 ' Establece el ancho a 20 para las columnas donde i >= 3
                    If tipopackagin = 1 Then
                        dgv.Columns(i).DefaultCellStyle.Format = "N0"
                    Else
                        dgv.Columns(i).DefaultCellStyle.Format = "N3"
                    End If


                    ' Obtener el nombre completo del día y la parte de la fecha
                    Dim diaCompleto As String = dgv.Columns(i).HeaderText.Split(" "c)(0)

                    ' Verificar si la clave existe en el diccionario
                    If diasAbreviados.ContainsKey(diaCompleto) Then
                        Dim diaAbreviado As String = diasAbreviados(diaCompleto)
                        Dim fechaCompleta As String = dataGridView1.Columns(i).HeaderText.Substring(diaCompleto.Length + 1)
                        Dim fechaAbreviada As String = $"{fechaCompleta.Split("/"c)(0)}/{fechaCompleta.Split("/"c)(1)}"
                        ' Formatear el nuevo título
                        Dim nuevoTitulo As String = $"{diaAbreviado} {fechaAbreviada}"
                        ' Haz algo con el nuevo título aquí, por ejemplo, asignarlo de vuelta al encabezado de la columna
                        dgv.Columns(i).HeaderText = nuevoTitulo
                    End If

                End If
            Next
        End If

        ' Formatear el texto en el índice 2 utilizando el formato es-AR
    End Sub

    Private Sub dgv_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        Dim dgvGrid As DataGridView = CType(sender, DataGridView)
        Dim rowIdx As Integer = e.RowIndex
        Dim cellHeight As Integer = dgvGrid.Rows(rowIdx).Height
        Dim headerHeight As Integer = dgvGrid.ColumnHeadersHeight

        If cellHeight < headerHeight Then
            dgvGrid.Rows(rowIdx).Height = headerHeight
        End If
    End Sub





    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex = -1 AndAlso e.ColumnIndex >= 0 Then ' Verificar si es el encabezado de la columna
            Dim headerBounds As System.Drawing.Rectangle = e.CellBounds ' Obtener los límites del encabezado

            ' Dibujar el fondo del encabezado
            e.Graphics.FillRectangle(New SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), headerBounds)

            ' Dibujar el texto del encabezado en dos líneas
            Dim headerText As String = dataGridView1.Columns(e.ColumnIndex).HeaderText.Trim()
            Dim font As System.Drawing.Font = dataGridView1.ColumnHeadersDefaultCellStyle.Font
            Dim brush As Brush = New SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor)
            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(headerText, font, brush, headerBounds, stringFormat)

            ' Evitar que se pinte el encabezado estándar
            e.Handled = True
        End If
    End Sub



    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Verificar si el formato es para los encabezados de columna
        If e.RowIndex = -1 AndAlso e.ColumnIndex >= 0 Then
            ' Convertir el texto del encabezado a mayúsculas y establecer el formato
            e.Value = e.Value.ToString().ToUpper()
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub dataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If dataGridView1.IsCurrentCellDirty Then
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub TxtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        FiltrarDatos(dataGridView1)
        btnSeleccionar.Visible = True
    End Sub


    Private Sub FiltrarDatos(datagridview1 As DataGridView)
        Dim filtro As String = txtFiltro.Text.Trim()
        Dim tabla As DataTable = controler.FiltrarBusqueda(FechaDesde, FechaHasta, cadenaproductos, filtro, tipopackagin, tipoinforme, tipofecha, itemsSeleccionadosString)
        If Not IsNothing(tabla) AndAlso tabla.Rows.Count > 0 Then
            Dim vista As New DataView(tabla)
            'vista.RowFilter = filtro ' Aplicar el filtro al DataView
            datagridview1.DataSource = tabla ' Asignar el DataView filtrado al DataGridView
            'datagridview1.AutoGenerateColumns = True ' Asegúrate de que esta línea esté presente
            Formatodgv(datagridview1)
        End If
    End Sub
    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then ' Verificar si la celda hace parte de la columna de CheckBox y no es el encabezado
            Dim cell As DataGridViewCheckBoxCell = dataGridView1.Rows(e.RowIndex).Cells("Selec.")
            If cell.Value IsNot Nothing AndAlso cell.Value.Equals(True) Then
                ' El CheckBox está marcado
                ' Realiza las operaciones que necesitas con la fila seleccionada
                Dim filaSeleccionada As DataGridViewRow = dataGridView1.Rows(e.RowIndex)
                ' Accede a los valores de la fila seleccionada, por ejemplo:
                Dim valorColumna As String = filaSeleccionada.Cells("Selec.").Value.ToString()
                btnActualizar.Visible = True
                btnLimpiarcheck.Enabled = True

            Else

            End If
        End If
    End Sub
    Private Sub dataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then ' Verificar si la celda hace parte de la columna de CheckBox y no es el encabezado
            Dim filasSeleccionadas As Integer = 0

            ' Contar el número de filas seleccionadas
            For Each fila As DataGridViewRow In dataGridView1.Rows
                Dim cell As DataGridViewCheckBoxCell = fila.Cells("Selec.")
                If cell.Value IsNot Nothing AndAlso Convert.ToBoolean(cell.Value) Then
                    filasSeleccionadas += 1
                End If
            Next

            If filasSeleccionadas > 0 Then
                ' Si hay al menos una fila seleccionada, muestra el botón y habilita el botón Limpiar
                btnActualizar.Visible = True
                btnLimpiarcheck.Enabled = True
            Else
                ' Si no hay filas seleccionadas, oculta el botón y deshabilita el botón Limpiar
                btnActualizar.Visible = False
                btnLimpiarcheck.Enabled = False
                ' Vuelve a cargar el gráfico (si es necesario)
                cargarchart1(tabla)
            End If
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs)
        ' Limpiar los puntos existentes en el gráfico
        Dim tabla As New DataTable
        If dataGridView1.SelectedRows.Count > 0 Then
            ' Obtener el valor de la celda en la columna "CodProducto" de la fila seleccionada
            Dim codProducto As String = dataGridView1.SelectedRows(0).Cells("CodProducto").Value.ToString()
            tabla = controler.FiltrarBusquedaGrid(FechaDesde, FechaHasta, cadenaproductos, codProducto, tipopackagin, tipoinforme, tipofecha, itemsSeleccionadosString)
            If tipoinforme = 1 Then
                'Dim cadenaProductos1 As String = String.Join(",", codigosProductos)
                tabla = controler.FiltrarBusquedaGrid(FechaDesde, FechaHasta, cadenaproductos, codProducto, tipopackagin, tipoinforme, tipofecha, itemsSeleccionadosString)
                ' cargarchart1(tablares)
            Else
                'Dim cadenaProductos1 As String = String.Join(",", codigosProductos)
                tabla = controler.FiltrarBusquedaGrid(FechaDesde, FechaHasta, cadenaproductos, codProducto, tipopackagin, 1, tipofecha, itemsSeleccionadosString)
                'cargarchart1(tablares)
            End If
        End If
        cargarchart1(tabla)

    End Sub


    Private Sub btnSeleccion_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        ' Verificar si al menos una fila está seleccionada en el DataGridView
        If Not HayFilasSeleccionadas() Then
            ' Mostrar mensaje de advertencia
            MessageBox.Show("Por favor, seleccione al menos una fila en el DataGridView.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Salir del evento si no hay filas seleccionadas
        End If

        ' Obtener los códigos de productos seleccionados en el DataGridView
        Dim tablares As New DataTable
        Dim codigosProductos As New List(Of String)()

        For Each fila As DataGridViewRow In dataGridView1.Rows
            ' Obtener el estado del CheckBox de la columna "Seleccion"
            Dim checkBox As DataGridViewCheckBoxCell = TryCast(fila.Cells("Selec."), DataGridViewCheckBoxCell)

            ' Verificar si el CheckBox está marcado
            If Convert.ToBoolean(checkBox.Value) = True Then
                Dim codigoProducto As String = fila.Cells("CodProducto").Value.ToString()
                codigosProductos.Add(codigoProducto)
            End If
        Next

        If tipoinforme = 1 Then
            Dim cadenaProductos1 As String = String.Join(",", codigosProductos)
            tablares = controler.FiltrarBusquedaGrid(FechaDesde, FechaHasta, cadenaproductos, cadenaProductos1, tipopackagin, tipoinforme, tipofecha, itemsSeleccionadosString)
            cargarchart1(tablares)
        Else
            Dim cadenaProductos1 As String = String.Join(",", codigosProductos)
            tablares = controler.FiltrarBusquedaGrid(FechaDesde, FechaHasta, cadenaproductos, cadenaProductos1, tipopackagin, 1, tipofecha, itemsSeleccionadosString)
            cargarchart1(tablares)
        End If
        ' Crear el string con los códigos de productos separados por coma

    End Sub
    Private Function HayFilasSeleccionadas() As Boolean
        ' Verificar si al menos una fila está seleccionada en el DataGridView
        For Each fila As DataGridViewRow In dataGridView1.Rows
            ' Obtener el estado del CheckBox de la columna "Seleccion"
            Dim checkBox As DataGridViewCheckBoxCell = TryCast(fila.Cells("Selec."), DataGridViewCheckBoxCell)

            ' Verificar si el CheckBox está marcado
            If Convert.ToBoolean(checkBox.Value) = True Then
                Return True ' Hay al menos una fila seleccionada, retorna verdadero
            End If
        Next

        Return False ' No hay filas seleccionadas
    End Function

    Private Sub cargarchart1(tabla As DataTable)
        chart1.Series("ventas").Points.Clear()
        ' Restablecer el total de pedidos a cero antes de calcular la sumatoria
        totalPedido = 0

        ' Verificar si hay una fila seleccionada
        If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows

                Dim fechaCarga As Date
                If tipofecha = 1 Then
                    fechaCarga = Convert.ToDateTime(row("FechaToma"))
                Else
                    fechaCarga = Convert.ToDateTime(row("FechaCarga"))
                End If
                ' Verificar si el día de la semana es laborable (Lunes a Viernes)
                If fechaCarga.DayOfWeek >= DayOfWeek.Monday AndAlso fechaCarga.DayOfWeek <= DayOfWeek.Friday Then
                    Dim fechaFormateada As String = fechaCarga.ToString("ddd dd/MM").ToUpper() ' Convierte a mayúsculas
                    Dim toneladasVendidas As Double = Convert.ToDouble(row("Toneladas"))

                    ' Agregar los datos al gráfico
                    chart1.Series("ventas").Points.AddXY(fechaFormateada, toneladasVendidas)
                    ' Sumar las toneladas vendidas al totalPedido
                    totalPedido += toneladasVendidas
                End If
            Next
            ' Actualizar el Label con la sumatoria de las toneladas vendidas
            lblTotalPedidos.Text = "Total Toneladas Pedidas : " & totalPedido.ToString()
        End If
    End Sub

    Private Sub btnLimpiarcheck_Click(sender As Object, e As EventArgs) Handles btnLimpiarcheck.Click
        For Each fila As DataGridViewRow In dataGridView1.Rows
            Dim checkBox As DataGridViewCheckBoxCell = TryCast(fila.Cells("Selec."), DataGridViewCheckBoxCell)
            checkBox.Value = False ' Desmarca la casilla de verificación
            btnLimpiarcheck.Enabled = False
        Next
        btnActualizar.Visible = False
        txtFiltro.Clear()
        btnSeleccionar.Visible = False
        cargarchart1(tabla)
    End Sub

    Private Sub BtnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        For Each fila As DataGridViewRow In dataGridView1.Rows
            Dim checkBox As DataGridViewCheckBoxCell = TryCast(fila.Cells("Selec."), DataGridViewCheckBoxCell)
            checkBox.Value = True ' Desmarca la casilla de verificación
            btnLimpiarcheck.Enabled = True
        Next
        btnActualizar.Visible = True
    End Sub



    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Dim frmFiltro As New FormFiltro()
        Me.Close()
        FormPrincipal.MostrarFormularioHijoEnGPformularios(frmFiltro)
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs)
        ModuloExcelExport.ExportarChartYDGV(chart1, dataGridView1, FechaDesde, FechaHasta, ProgressBar1, familia, Tipo, Seleccion)
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDFResumen.Click
        ' Obtener las fechas desde y hasta del DateTimePicker y formatearlas como texto
        'Dim fechaDesde1 As DateTime = DateTime.ParseExact(FechaDesde, "dd/MM/yyyy", Nothing)
        'Dim fechaHasta1 As DateTime = DateTime.ParseExact(FechaHasta, "dd/MM/yyyy", Nothing)

        ' Obtener la fecha y hora actual
        Dim fechaActual As DateTime = DateTime.Now

        ' Formatear las fechas según el formato "yyyy-MM-dd"
        Dim formatoFecha As String = "yyyy-MM-dd"
        Dim fechaDesdeFormateada As String = FechaDesde.ToString(formatoFecha)
        Dim fechaHastaFormateada As String = FechaHasta.ToString(formatoFecha)

        ' Formatear la hora actual según el formato "HH:mm"
        Dim formatoHora As String = "HH-mm"
        Dim horaActualFormateada As String = fechaActual.ToString(formatoHora)

        ' Concatenar las fechas y la hora formateadas al nombre del archivo PDF
        Dim nombreArchivo As String = $"Analisis de demanda {fechaDesdeFormateada} a {fechaHastaFormateada} solicitado {fechaActual.ToString(formatoFecha)} a las {horaActualFormateada} hs.pdf"


        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivo PDF|*.pdf"
        saveFileDialog.FileName = nombreArchivo ' Establecer el nombre del archivo predeterminado

        ' Si el usuario selecciona un archivo y hace clic en Guardar
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'Dim pdfDoc As New Document(PageSize.A4, 56.69291, 28.345, 10, 10) ' Tamaño y márgenes del documento PDF

            Dim pdfDoc As New Document(PageSize.A4, 56.69291, 28.345, 10, 10) ' Tamaño y márgenes del documento PDF en orientación horizontal



            Dim logo As iTextSharp.text.Image = Nothing ' Inicializar la imagen

            Try
                Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(saveFileDialog.FileName, FileMode.Create))
                pdfDoc.Open()

                dataGridView1.Sort(dataGridView1.Columns("CODPRODUCTO"), ListSortDirection.Ascending)

                ' Añadir título
                Dim titulo As New iTextSharp.text.Paragraph("Análisis de Demanda", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD))
                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER
                pdfDoc.Add(titulo)

                ' Agregar espacio vertical en blanco para separación
                pdfDoc.Add(New iTextSharp.text.Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 1.0F, BaseColor.WHITE, Element.ALIGN_CENTER, 1)))
                pdfDoc.Add(iTextSharp.text.Chunk.NEWLINE)


                ' Crear una instancia de MemoryStream para almacenar la imagen del gráfico
                Dim chartImageStream As New MemoryStream()
                chart1.SaveImage(chartImageStream, ChartImageFormat.Png)

                ' Crear una instancia de iTextSharp.text.Image desde MemoryStream
                Dim chartImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(chartImageStream.GetBuffer())
                chartImage.ScaleToFit(550, 350) ' Ajustar el tamaño de la imagen según sea necesario

                ' Alinear la imagen en el centro
                chartImage.Alignment = Element.ALIGN_CENTER

                ' Agregar la imagen del gráfico al documento PDF
                pdfDoc.Add(chartImage)

                ' Añadir fechas desde y hasta
                'Dim fechas As New Paragraph("Fecha Desde: " & FechaDesde & " - Fecha Hasta: " & FechaHasta)
                'fechas.Alignment = Element.ALIGN_CENTER
                'pdfDoc.Add(fechas)

                ' Obtener la imagen desde los recursos del proyecto
                Dim bitmap As Bitmap = My.Resources.logo_guma_2009_plano

                ' Convertir el objeto Bitmap a System.Drawing.Image
                Dim image As System.Drawing.Image = DirectCast(bitmap, System.Drawing.Image)

                ' Crear una instancia de iTextSharp.text.Image desde System.Drawing.Image
                logo = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg)
                logo.ScaleAbsolute(60, 60)
                logo.ScaleToFit(60, 60)
                logo.SetAbsolutePosition(40, PageSize.A4.Height - 60 - 10) ' Posiciona la imagen arriba a la izquierda con un margen de 10 puntos


                ' Crear una tabla con las mismas columnas que el DataGridView
                Dim pdfTable As New PdfPTable(dataGridView1.ColumnCount - 1) ' Excluyendo la columna "Seleccion"
                pdfTable.DefaultCell.Padding = 3
                pdfTable.WidthPercentage = 100 ' Ancho de la tabla en porcentaje del tamaño de la página

                ' Configurar el estilo de la fuente para las celdas
                Dim font As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8)

                ' Ajustar el ancho de las columnas
                If dataGridView1.Columns.Count = 5 Then
                    pdfTable.SetWidths(New Single() {10, 90, 50, 30})
                Else
                    pdfTable.SetWidths(New Single() {15, 100, 30, 30, 30}) ' Columna 1: 70, Columna 2: 150, Columna 3: 70, Columna 4: 100, Columna 5: 70
                End If




                ' Configurar el encabezado de la tabla (excluyendo la columna "Seleccion")
                For i As Integer = 0 To dataGridView1.ColumnCount - 1
                    If dataGridView1.Columns(i).Name <> "Selec." Then
                        ' Renombrar el encabezado de la columna 1 de "Title" a "Código"
                        If i = 1 Then
                            Dim cell As New PdfPCell(New Phrase("CODIGO", font))
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER ' Centrar el contenido de la celda
                            pdfTable.AddCell(cell)
                        Else
                            Dim cell As New PdfPCell(New Phrase(dataGridView1.Columns(i).HeaderText, font))
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER ' Centrar el contenido de la celda
                            pdfTable.AddCell(cell)
                        End If
                    End If
                Next

                For Each row As DataGridViewRow In dataGridView1.Rows
                    For i As Integer = 0 To dataGridView1.ColumnCount - 1
                        If dataGridView1.Columns(i).Name <> "Selec." Then
                            ' Crear una celda con el valor de la celda actual
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                            ' Crear una celda con el valor y alinear a la derecha si es una columna numérica
                            Dim cell As New PdfPCell(New Phrase(cellValue, font)) ' Usar la fuente configurada
                            ' Formatear los números en la columna cuatro para quitar los ceros decimales
                            If i = 4 AndAlso Not String.IsNullOrEmpty(cellValue) Then
                                Dim roundedValue As Decimal = Math.Round(Decimal.Parse(cellValue), 0)
                                cell.Phrase = New Phrase(roundedValue.ToString(), font) ' Usar la fuente configurada
                            End If
                            If i = 1 OrElse i = 3 OrElse i = 4 OrElse i = 5 Then ' Alinear las columnas 1, 3, 4 y 5 a la derecha
                                cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                            Else
                                cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT ' Alinear el resto de las columnas a la izquierda
                            End If

                            ' Truncar el texto en la columna 2 si tiene más de 20 caracteres
                            If i = 2 AndAlso cellValue.Length > 30 Then
                                cell.Phrase = New Phrase(cellValue.Substring(0, 27) & "...", font) ' Usar la fuente configurada
                            End If

                            ' Redondear la columna 5 a dos dígitos después de la coma
                            If i = 5 AndAlso IsNumeric(cellValue) OrElse i = 3 Then
                                Dim roundedValue As Decimal = Math.Round(Decimal.Parse(cellValue), 2)
                                cell.Phrase = New Phrase(roundedValue.ToString(), font) ' Usar la fuente configurada
                            End If
                            ' Ajustar el margen derecho para las columnas 1, 3, 4 y 5
                            If i = 1 OrElse i = 3 OrElse i = 4 OrElse i = 5 Then
                                cell.PaddingRight = 8 ' Ajusta el espacio del borde derecho a 3 puntos
                                cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                            Else
                                cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT ' Alinear el resto de las columnas a la izquierda
                            End If
                            ' Agregar la celda al PDF
                            pdfTable.AddCell(cell)
                        End If
                    Next
                Next


                ' Agregar espacio vertical en blanco para separación
                pdfDoc.Add(New iTextSharp.text.Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 1.0F, BaseColor.WHITE, Element.ALIGN_CENTER, 1)))
                pdfDoc.Add(iTextSharp.text.Chunk.NEWLINE)

                ' Agregar la imagen al documento PDF
                pdfDoc.Add(logo)


                Dim tipoDetalle As String
                If tipopackagin = 1 Then
                    tipoDetalle = "Tipo de Detalle: CAJAS"
                Else
                    tipoDetalle = "Tipo de Detalle: TONELADAS"
                End If
                Dim tituloDetalle As New iTextSharp.text.Paragraph(tipoDetalle, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD))
                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER
                pdfDoc.Add(tituloDetalle)

                ' Agregar espacio vertical en blanco para separación con un espacio más pequeño
                pdfDoc.Add(New iTextSharp.text.Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 0.5F, BaseColor.WHITE, Element.ALIGN_CENTER, 1)))
                pdfDoc.Add(iTextSharp.text.Chunk.NEWLINE)

                ' Agregar la tabla al documento PDF
                pdfDoc.Add(pdfTable)
                pdfDoc.Close()

                ' Obtener el nombre del archivo PDF descargado
                Dim nombreArchivoPDF As String = saveFileDialog.FileName

                ' Verificar si el archivo existe antes de intentar abrirlo
                If Not String.IsNullOrEmpty(nombreArchivoPDF) AndAlso File.Exists(nombreArchivoPDF) Then
                    Try
                        Process.Start(nombreArchivoPDF)
                    Catch ex As Exception
                        MessageBox.Show("Error al abrir el archivo PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    MessageBox.Show("El archivo PDF no se encontró en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                ' Manejar errores al generar el archivo PDF
                MessageBox.Show("Error al generar el archivo PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                pdfDoc.Close()
            End Try
        End If
    End Sub


    Private Sub btnExcel_Click_1(sender As Object, e As EventArgs) Handles btnExcel.Click
        ' Hacer el Panel1 visible
        Panel1.Visible = True
        ' Exportar el gráfico y los datos con el título personalizado
        ModuloExcelExport.ExportarChartYDGV(chart1, dataGridView1, FechaDesde, FechaHasta, ProgressBar1, familia, Tipo, Seleccion)
        ' Hacer el Panel1 invisible después de la exportación
        Panel1.Visible = False
    End Sub

    Private Sub btnPDFDesagregado_Click(sender As Object, e As EventArgs) Handles btnPDFDetallado.Click
        ' Obtener las fechas desde y hasta del DateTimePicker y formatearlas como texto
        'Dim fechaDesde1 As DateTime = DateTime.ParseExact(FechaDesde, "dd/MM/yyyy", Nothing)
        'Dim fechaHasta1 As DateTime = DateTime.ParseExact(FechaHasta, "dd/MM/yyyy", Nothing)

        ' Obtener la fecha y hora actual
        Dim fechaActual As DateTime = DateTime.Now

        ' Formatear las fechas según el formato "yyyy-MM-dd"
        Dim formatoFecha As String = "yyyy-MM-dd"
        Dim fechaDesdeFormateada As String = FechaDesde.ToString(formatoFecha)
        Dim fechaHastaFormateada As String = FechaHasta.ToString(formatoFecha)

        ' Formatear la hora actual según el formato "HH:mm"
        Dim formatoHora As String = "HH-mm"
        Dim horaActualFormateada As String = fechaActual.ToString(formatoHora)

        ' Concatenar las fechas y la hora formateadas al nombre del archivo PDF
        Dim nombreArchivo As String = $"Analisis de demanda {fechaDesdeFormateada} a {fechaHastaFormateada} solicitado {fechaActual.ToString(formatoFecha)} a las {horaActualFormateada} hs.pdf"


        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivo PDF|*.pdf"
        saveFileDialog.FileName = nombreArchivo ' Establecer el nombre del archivo predeterminado

        ' Si el usuario selecciona un archivo y hace clic en Guardar
        If saveFileDialog.ShowDialog() = DialogResult.OK Then

            Dim pdfDoc As New Document(PageSize.A4.Rotate(), 56.69291, 28.345, 10, 10) ' Tamaño y márgenes del documento PDF en orientación horizontal
            Dim logo As iTextSharp.text.Image = Nothing ' Inicializar la imagen

            Try
                dataGridView1.Sort(dataGridView1.Columns("CODPRODUCTO"), ListSortDirection.Ascending)
                Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(saveFileDialog.FileName, FileMode.Create))
                pdfDoc.Open()

                ' Añadir título
                Dim titulo As New iTextSharp.text.Paragraph("Análisis de Demanda", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD))
                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER
                pdfDoc.Add(titulo)

                ' Agregar espacio vertical en blanco para separación
                pdfDoc.Add(New iTextSharp.text.Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 1.0F, BaseColor.WHITE, Element.ALIGN_CENTER, 1)))
                pdfDoc.Add(iTextSharp.text.Chunk.NEWLINE)

                ' Crear una instancia de MemoryStream para almacenar la imagen del gráfico
                Dim chartImageStream As New MemoryStream()
                chart1.SaveImage(chartImageStream, ChartImageFormat.Png)


                ' Crear una instancia de iTextSharp.text.Image desde MemoryStream
                Dim chartImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(chartImageStream.GetBuffer())
                chartImage.ScaleToFit(650, 400) ' Ajustar el tamaño de la imagen según sea necesario

                ' Alinear la imagen en el centro
                chartImage.Alignment = Element.ALIGN_CENTER

                ' Agregar la imagen del gráfico al documento PDF
                pdfDoc.Add(chartImage)

                ' Agregar espacio vertical en blanco para separación
                pdfDoc.Add(New iTextSharp.text.Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 1.0F, BaseColor.WHITE, Element.ALIGN_CENTER, 1)))
                pdfDoc.Add(iTextSharp.text.Chunk.NEWLINE)


                ' Añadir fechas desde y hasta
                'Dim fechas As New Paragraph("Fecha Desde: " & FechaDesde & " - Fecha Hasta: " & FechaHasta)
                'fechas.Alignment = Element.ALIGN_CENTER
                'pdfDoc.Add(fechas)

                ' Obtener la imagen desde los recursos del proyecto
                Dim bitmap As Bitmap = My.Resources.logo_guma_2009_plano

                ' Convertir el objeto Bitmap a System.Drawing.Image
                Dim image As System.Drawing.Image = DirectCast(bitmap, System.Drawing.Image)

                ' Crear una instancia de iTextSharp.text.Image desde System.Drawing.Image
                logo = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg)
                logo.ScaleAbsolute(60, 60)
                logo.ScaleToFit(60, 60)
                'logo.SetAbsolutePosition(40, PageSize.A4.Height - 60 - 10) ' Posiciona la imagen arriba a la izquierda con un margen de 10 puntos
                ' Calcular las coordenadas para posicionar la imagen en la esquina superior izquierda
                Dim x As Single = 50 ' Margen izquierdo
                Dim y As Single = PageSize.A4.Height + 150 - logo.Height ' Margen superior (considerando la altura de la imagen)

                ' Posicionar la imagen en la esquina superior izquierda
                logo.SetAbsolutePosition(x, y)


                ' Crear una tabla con las mismas columnas que el DataGridView
                Dim pdfTable As New PdfPTable(dataGridView1.ColumnCount - 1) ' Excluyendo la columna "Seleccion"
                pdfTable.DefaultCell.Padding = 3
                pdfTable.WidthPercentage = 100 ' Ancho de la tabla en porcentaje del tamaño de la página

                ' Configurar el estilo de la fuente para las celdas
                Dim font As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9)

                ' Obtener el número de columnas en el DataGridView
                Dim totalColumnas As Integer = dataGridView1.ColumnCount

                ' Crear un array para almacenar los anchos de las columnas
                Dim widths(totalColumnas - 2) As Single

                ' Definir anchos para las primeras dos columnas
                widths(0) = 80 ' Ancho de la primera columna
                widths(1) = 125 ' Ancho de la segunda columna

                ' Establecer el ancho fijo para las demás columnas
                For i As Integer = 2 To totalColumnas - 3
                    widths(i) = 55 ' Ancho para las columnas restantes
                Next

                ' Ajustar el ancho de las columnas para la orientación horizontal
                pdfTable.SetWidths(widths)



                ' Configurar el encabezado de la tabla (excluyendo la columna "Seleccion")
                For i As Integer = 0 To dataGridView1.ColumnCount - 1
                    If dataGridView1.Columns(i).Name <> "Selec." Then
                        ' Renombrar el encabezado de la columna 1 de "Title" a "Código"
                        If i = 1 Then
                            Dim cell As New PdfPCell(New Phrase("CODIGO", font))
                            cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                            pdfTable.AddCell(cell)
                        Else
                            Dim cell As New PdfPCell(New Phrase(dataGridView1.Columns(i).HeaderText, font))
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER ' Centrar el contenido de la celda
                            pdfTable.AddCell(cell)
                        End If
                    End If
                Next


                For Each row As DataGridViewRow In dataGridView1.Rows
                    For i As Integer = 0 To dataGridView1.ColumnCount - 1
                        If dataGridView1.Columns(i).Name <> "Selec." Then
                            ' Verificar si la columna es numérica
                            Dim isNumericColumn As Boolean = i >= 3 OrElse i = 1 ' Asumiendo que las columnas desde la 3 son numéricas

                            ' Crear una celda con el valor de la celda actual
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")

                            ' Crear una celda con el valor y alinear a la derecha si es una columna numérica
                            Dim cell As New PdfPCell(New Phrase(cellValue, font)) ' Usar la fuente configurada

                            ' Alinear las columnas numéricas a la derecha
                            If isNumericColumn AndAlso Not String.IsNullOrEmpty(cellValue) Then
                                cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                                ' Formatear números para quitar los ceros decimales
                                Dim roundedValue As Decimal
                                If tipopackagin = 1 Then
                                    roundedValue = Math.Round(Decimal.Parse(cellValue), 0)
                                Else
                                    roundedValue = Math.Round(Decimal.Parse(cellValue), 2)
                                End If
                                cell.Phrase = New Phrase(roundedValue.ToString(), font) ' Usar la fuente configurada
                            End If

                            ' Truncar el texto en la columna 2 si tiene más de 30 caracteres
                            If i = 2 AndAlso cellValue.Length > 30 Then
                                cell.Phrase = New Phrase(cellValue.Substring(0, 27) & "...", font) ' Usar la fuente configurada
                            End If

                            ' Ajustar el margen derecho para las columnas numéricas
                            If isNumericColumn Then
                                cell.PaddingRight = 2 ' Ajusta el espacio del borde derecho a 3 puntos
                            End If

                            ' Agregar la celda al PDF
                            pdfTable.AddCell(cell)
                        End If
                    Next
                Next


                ' Agregar espacio vertical en blanco para separación
                pdfDoc.Add(New iTextSharp.text.Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 1.0F, BaseColor.WHITE, Element.ALIGN_CENTER, 1)))
                pdfDoc.Add(iTextSharp.text.Chunk.NEWLINE)

                ' Agregar la imagen al documento PDF
                pdfDoc.Add(logo)


                Dim tipoDetalle As String
                If tipopackagin = 1 Then
                    tipoDetalle = "Tipo de Detalle: CAJAS"
                Else
                    tipoDetalle = "Tipo de Detalle: TONELADAS"
                End If
                Dim tituloDetalle As New iTextSharp.text.Paragraph(tipoDetalle, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD))
                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER
                pdfDoc.Add(tituloDetalle)

                ' Agregar espacio vertical en blanco para separación con un espacio más pequeño
                pdfDoc.Add(New iTextSharp.text.Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 0.5F, BaseColor.WHITE, Element.ALIGN_CENTER, 1)))
                pdfDoc.Add(iTextSharp.text.Chunk.NEWLINE)


                ' Agregar la tabla al documento PDF
                pdfDoc.Add(pdfTable)
                pdfDoc.Close()

                'MessageBox.Show("El archivo PDF ha sido creado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Obtener el nombre del archivo PDF descargado
                Dim nombreArchivoPDF As String = saveFileDialog.FileName

                ' Verificar si el archivo existe antes de intentar abrirlo
                If Not String.IsNullOrEmpty(nombreArchivoPDF) AndAlso File.Exists(nombreArchivoPDF) Then
                    Try
                        Process.Start(nombreArchivoPDF)
                    Catch ex As Exception
                        MessageBox.Show("Error al abrir el archivo PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    MessageBox.Show("El archivo PDF no se encontró en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' Notificar al usuario que el archivo ha sido creado correctamente
                'MessageBox.Show($"El archivo PDF '{nombreArchivo}' ha sido creado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                ' Manejar errores al generar el archivo PDF
                MessageBox.Show("Error al generar el archivo PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                pdfDoc.Close()
            End Try
        End If
    End Sub

End Class
