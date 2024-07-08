<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFiltro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFiltro))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.gbFecha = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dtpFechaHasta = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.dtpFechaDesde = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.gbTipoFecha = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.rbtFechaCarga = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.rbtFechaToma = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.Guna2GroupBox3 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.rbtTonelada = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.rbtCaja = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.gbEstadoPedido = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.ChkLTipoPedido = New System.Windows.Forms.CheckedListBox()
        Me.tvCategorias = New System.Windows.Forms.TreeView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReporte = New Guna.UI2.WinForms.Guna2Button()
        Me.btnLimpiar = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMarcarTodos = New Guna.UI2.WinForms.Guna2Button()
        Me.btnMarcarTodosNoInsu = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse3 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.gbInforme = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.rbtDetallado = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.rbtResumen = New Guna.UI2.WinForms.Guna2RadioButton()
        Me.Guna2Elipse4 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse5 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse6 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse7 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbFecha.SuspendLayout()
        Me.gbTipoFecha.SuspendLayout()
        Me.Guna2GroupBox3.SuspendLayout()
        Me.gbEstadoPedido.SuspendLayout()
        Me.gbInforme.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'gbFecha
        '
        Me.gbFecha.BackColor = System.Drawing.SystemColors.Control
        Me.gbFecha.Controls.Add(Me.Guna2HtmlLabel2)
        Me.gbFecha.Controls.Add(Me.Guna2HtmlLabel1)
        Me.gbFecha.Controls.Add(Me.dtpFechaHasta)
        Me.gbFecha.Controls.Add(Me.dtpFechaDesde)
        Me.gbFecha.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gbFecha.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbFecha.ForeColor = System.Drawing.Color.White
        Me.gbFecha.Location = New System.Drawing.Point(12, 43)
        Me.gbFecha.Name = "gbFecha"
        Me.gbFecha.Size = New System.Drawing.Size(350, 143)
        Me.gbFecha.TabIndex = 0
        Me.gbFecha.Text = "Fecha de Pedido"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(16, 105)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(42, 17)
        Me.Guna2HtmlLabel2.TabIndex = 3
        Me.Guna2HtmlLabel2.Text = "Hasta:"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(16, 65)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(44, 17)
        Me.Guna2HtmlLabel1.TabIndex = 2
        Me.Guna2HtmlLabel1.Text = "Desde:"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Checked = True
        Me.dtpFechaHasta.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtpFechaHasta.ForeColor = System.Drawing.Color.White
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(92, 96)
        Me.dtpFechaHasta.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaHasta.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(241, 36)
        Me.dtpFechaHasta.TabIndex = 1
        Me.dtpFechaHasta.Value = New Date(2023, 10, 30, 16, 30, 29, 809)
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Checked = True
        Me.dtpFechaDesde.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtpFechaDesde.ForeColor = System.Drawing.Color.White
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(92, 54)
        Me.dtpFechaDesde.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaDesde.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(241, 36)
        Me.dtpFechaDesde.TabIndex = 0
        Me.dtpFechaDesde.Value = New Date(2023, 10, 30, 16, 30, 29, 809)
        '
        'gbTipoFecha
        '
        Me.gbTipoFecha.Controls.Add(Me.rbtFechaCarga)
        Me.gbTipoFecha.Controls.Add(Me.rbtFechaToma)
        Me.gbTipoFecha.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gbTipoFecha.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbTipoFecha.ForeColor = System.Drawing.Color.White
        Me.gbTipoFecha.Location = New System.Drawing.Point(12, 215)
        Me.gbTipoFecha.Name = "gbTipoFecha"
        Me.gbTipoFecha.Size = New System.Drawing.Size(172, 139)
        Me.gbTipoFecha.TabIndex = 1
        Me.gbTipoFecha.Text = "Selección de Fechas"
        '
        'rbtFechaCarga
        '
        Me.rbtFechaCarga.AutoSize = True
        Me.rbtFechaCarga.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtFechaCarga.CheckedState.BorderThickness = 0
        Me.rbtFechaCarga.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtFechaCarga.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbtFechaCarga.CheckedState.InnerOffset = -4
        Me.rbtFechaCarga.ForeColor = System.Drawing.Color.Black
        Me.rbtFechaCarga.Location = New System.Drawing.Point(16, 98)
        Me.rbtFechaCarga.Name = "rbtFechaCarga"
        Me.rbtFechaCarga.Size = New System.Drawing.Size(112, 19)
        Me.rbtFechaCarga.TabIndex = 2
        Me.rbtFechaCarga.Text = "Fecha de carga"
        Me.rbtFechaCarga.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbtFechaCarga.UncheckedState.BorderThickness = 2
        Me.rbtFechaCarga.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbtFechaCarga.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'rbtFechaToma
        '
        Me.rbtFechaToma.AutoSize = True
        Me.rbtFechaToma.Checked = True
        Me.rbtFechaToma.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtFechaToma.CheckedState.BorderThickness = 0
        Me.rbtFechaToma.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtFechaToma.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbtFechaToma.CheckedState.InnerOffset = -4
        Me.rbtFechaToma.ForeColor = System.Drawing.Color.Black
        Me.rbtFechaToma.Location = New System.Drawing.Point(16, 63)
        Me.rbtFechaToma.Name = "rbtFechaToma"
        Me.rbtFechaToma.Size = New System.Drawing.Size(110, 19)
        Me.rbtFechaToma.TabIndex = 1
        Me.rbtFechaToma.TabStop = True
        Me.rbtFechaToma.Text = "Fecha de toma"
        Me.rbtFechaToma.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbtFechaToma.UncheckedState.BorderThickness = 2
        Me.rbtFechaToma.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbtFechaToma.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'Guna2GroupBox3
        '
        Me.Guna2GroupBox3.Controls.Add(Me.rbtTonelada)
        Me.Guna2GroupBox3.Controls.Add(Me.rbtCaja)
        Me.Guna2GroupBox3.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2GroupBox3.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2GroupBox3.ForeColor = System.Drawing.Color.White
        Me.Guna2GroupBox3.Location = New System.Drawing.Point(12, 366)
        Me.Guna2GroupBox3.Name = "Guna2GroupBox3"
        Me.Guna2GroupBox3.Size = New System.Drawing.Size(172, 139)
        Me.Guna2GroupBox3.TabIndex = 2
        Me.Guna2GroupBox3.Text = "Tipo"
        '
        'rbtTonelada
        '
        Me.rbtTonelada.AutoSize = True
        Me.rbtTonelada.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtTonelada.CheckedState.BorderThickness = 0
        Me.rbtTonelada.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtTonelada.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbtTonelada.CheckedState.InnerOffset = -4
        Me.rbtTonelada.ForeColor = System.Drawing.Color.Black
        Me.rbtTonelada.Location = New System.Drawing.Point(14, 99)
        Me.rbtTonelada.Name = "rbtTonelada"
        Me.rbtTonelada.Size = New System.Drawing.Size(82, 19)
        Me.rbtTonelada.TabIndex = 2
        Me.rbtTonelada.Text = "Tonelada"
        Me.rbtTonelada.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbtTonelada.UncheckedState.BorderThickness = 2
        Me.rbtTonelada.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbtTonelada.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'rbtCaja
        '
        Me.rbtCaja.AutoSize = True
        Me.rbtCaja.Checked = True
        Me.rbtCaja.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtCaja.CheckedState.BorderThickness = 0
        Me.rbtCaja.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtCaja.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbtCaja.CheckedState.InnerOffset = -4
        Me.rbtCaja.ForeColor = System.Drawing.Color.Black
        Me.rbtCaja.Location = New System.Drawing.Point(14, 63)
        Me.rbtCaja.Name = "rbtCaja"
        Me.rbtCaja.Size = New System.Drawing.Size(51, 19)
        Me.rbtCaja.TabIndex = 1
        Me.rbtCaja.TabStop = True
        Me.rbtCaja.Text = "Caja"
        Me.rbtCaja.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbtCaja.UncheckedState.BorderThickness = 2
        Me.rbtCaja.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbtCaja.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'gbEstadoPedido
        '
        Me.gbEstadoPedido.Controls.Add(Me.ChkLTipoPedido)
        Me.gbEstadoPedido.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gbEstadoPedido.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbEstadoPedido.ForeColor = System.Drawing.Color.White
        Me.gbEstadoPedido.Location = New System.Drawing.Point(190, 366)
        Me.gbEstadoPedido.Name = "gbEstadoPedido"
        Me.gbEstadoPedido.Size = New System.Drawing.Size(172, 139)
        Me.gbEstadoPedido.TabIndex = 3
        Me.gbEstadoPedido.Text = "Estado del Pedido"
        '
        'ChkLTipoPedido
        '
        Me.ChkLTipoPedido.FormattingEnabled = True
        Me.ChkLTipoPedido.Location = New System.Drawing.Point(3, 44)
        Me.ChkLTipoPedido.Name = "ChkLTipoPedido"
        Me.ChkLTipoPedido.Size = New System.Drawing.Size(166, 80)
        Me.ChkLTipoPedido.TabIndex = 0
        '
        'tvCategorias
        '
        Me.tvCategorias.Location = New System.Drawing.Point(382, 43)
        Me.tvCategorias.Name = "tvCategorias"
        Me.tvCategorias.Size = New System.Drawing.Size(303, 514)
        Me.tvCategorias.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(379, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Categorías"
        '
        'btnReporte
        '
        Me.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporte.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnReporte.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnReporte.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnReporte.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnReporte.FillColor = System.Drawing.Color.Lime
        Me.btnReporte.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnReporte.ForeColor = System.Drawing.Color.White
        Me.btnReporte.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnReporte.Location = New System.Drawing.Point(691, 108)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(155, 45)
        Me.btnReporte.TabIndex = 11
        Me.btnReporte.Text = "Generar Reporte"
        Me.btnReporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnLimpiar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnLimpiar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnLimpiar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnLimpiar.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLimpiar.Font = New System.Drawing.Font("Segoe UI Black", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiar.ForeColor = System.Drawing.Color.White
        Me.btnLimpiar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnLimpiar.Location = New System.Drawing.Point(691, 215)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(155, 45)
        Me.btnLimpiar.TabIndex = 13
        Me.btnLimpiar.Text = "Limpiar"
        '
        'btnMarcarTodos
        '
        Me.btnMarcarTodos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMarcarTodos.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMarcarTodos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMarcarTodos.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMarcarTodos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMarcarTodos.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMarcarTodos.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnMarcarTodos.ForeColor = System.Drawing.Color.White
        Me.btnMarcarTodos.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnMarcarTodos.Image = CType(resources.GetObject("btnMarcarTodos.Image"), System.Drawing.Image)
        Me.btnMarcarTodos.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnMarcarTodos.Location = New System.Drawing.Point(691, 321)
        Me.btnMarcarTodos.Name = "btnMarcarTodos"
        Me.btnMarcarTodos.Size = New System.Drawing.Size(155, 45)
        Me.btnMarcarTodos.TabIndex = 14
        Me.btnMarcarTodos.Text = "     Marcar Todos"
        '
        'btnMarcarTodosNoInsu
        '
        Me.btnMarcarTodosNoInsu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMarcarTodosNoInsu.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMarcarTodosNoInsu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnMarcarTodosNoInsu.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnMarcarTodosNoInsu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnMarcarTodosNoInsu.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMarcarTodosNoInsu.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnMarcarTodosNoInsu.ForeColor = System.Drawing.Color.White
        Me.btnMarcarTodosNoInsu.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnMarcarTodosNoInsu.Image = CType(resources.GetObject("btnMarcarTodosNoInsu.Image"), System.Drawing.Image)
        Me.btnMarcarTodosNoInsu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnMarcarTodosNoInsu.Location = New System.Drawing.Point(691, 419)
        Me.btnMarcarTodosNoInsu.Name = "btnMarcarTodosNoInsu"
        Me.btnMarcarTodosNoInsu.Size = New System.Drawing.Size(155, 45)
        Me.btnMarcarTodosNoInsu.TabIndex = 15
        Me.btnMarcarTodosNoInsu.Text = "   Marcar Todos NO Insumo"
        Me.btnMarcarTodosNoInsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Guna2Elipse2
        '
        Me.Guna2Elipse2.TargetControl = Me.btnLimpiar
        '
        'Guna2Elipse3
        '
        Me.Guna2Elipse3.TargetControl = Me.btnMarcarTodosNoInsu
        '
        'gbInforme
        '
        Me.gbInforme.Controls.Add(Me.rbtDetallado)
        Me.gbInforme.Controls.Add(Me.rbtResumen)
        Me.gbInforme.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gbInforme.Font = New System.Drawing.Font("Segoe UI Black", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbInforme.ForeColor = System.Drawing.Color.White
        Me.gbInforme.Location = New System.Drawing.Point(190, 215)
        Me.gbInforme.Name = "gbInforme"
        Me.gbInforme.Size = New System.Drawing.Size(172, 139)
        Me.gbInforme.TabIndex = 17
        Me.gbInforme.Text = "Tipo de Informe"
        '
        'rbtDetallado
        '
        Me.rbtDetallado.AutoSize = True
        Me.rbtDetallado.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtDetallado.CheckedState.BorderThickness = 0
        Me.rbtDetallado.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtDetallado.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbtDetallado.CheckedState.InnerOffset = -4
        Me.rbtDetallado.ForeColor = System.Drawing.Color.Black
        Me.rbtDetallado.Location = New System.Drawing.Point(14, 99)
        Me.rbtDetallado.Name = "rbtDetallado"
        Me.rbtDetallado.Size = New System.Drawing.Size(84, 19)
        Me.rbtDetallado.TabIndex = 2
        Me.rbtDetallado.Text = "Detallado"
        Me.rbtDetallado.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbtDetallado.UncheckedState.BorderThickness = 2
        Me.rbtDetallado.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbtDetallado.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'rbtResumen
        '
        Me.rbtResumen.AutoSize = True
        Me.rbtResumen.Checked = True
        Me.rbtResumen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtResumen.CheckedState.BorderThickness = 0
        Me.rbtResumen.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbtResumen.CheckedState.InnerColor = System.Drawing.Color.White
        Me.rbtResumen.CheckedState.InnerOffset = -4
        Me.rbtResumen.ForeColor = System.Drawing.Color.Black
        Me.rbtResumen.Location = New System.Drawing.Point(14, 63)
        Me.rbtResumen.Name = "rbtResumen"
        Me.rbtResumen.Size = New System.Drawing.Size(80, 19)
        Me.rbtResumen.TabIndex = 1
        Me.rbtResumen.TabStop = True
        Me.rbtResumen.Text = "Resumen"
        Me.rbtResumen.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.rbtResumen.UncheckedState.BorderThickness = 2
        Me.rbtResumen.UncheckedState.FillColor = System.Drawing.Color.Transparent
        Me.rbtResumen.UncheckedState.InnerColor = System.Drawing.Color.Transparent
        '
        'Guna2Elipse4
        '
        Me.Guna2Elipse4.TargetControl = Me.btnMarcarTodos
        '
        'Guna2Elipse6
        '
        Me.Guna2Elipse6.TargetControl = Me.btnReporte
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "El período de fechas seleccionado debe ser menor a 180 días."
        '
        'FormFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 564)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbInforme)
        Me.Controls.Add(Me.gbTipoFecha)
        Me.Controls.Add(Me.btnMarcarTodosNoInsu)
        Me.Controls.Add(Me.btnMarcarTodos)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tvCategorias)
        Me.Controls.Add(Me.gbEstadoPedido)
        Me.Controls.Add(Me.Guna2GroupBox3)
        Me.Controls.Add(Me.gbFecha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormFiltro"
        Me.Text = "FormFiltro"
        Me.gbFecha.ResumeLayout(False)
        Me.gbFecha.PerformLayout()
        Me.gbTipoFecha.ResumeLayout(False)
        Me.gbTipoFecha.PerformLayout()
        Me.Guna2GroupBox3.ResumeLayout(False)
        Me.Guna2GroupBox3.PerformLayout()
        Me.gbEstadoPedido.ResumeLayout(False)
        Me.gbInforme.ResumeLayout(False)
        Me.gbInforme.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents gbTipoFecha As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents gbFecha As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dtpFechaHasta As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dtpFechaDesde As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2GroupBox3 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents rbtTonelada As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents rbtCaja As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents rbtFechaCarga As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents rbtFechaToma As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents btnReporte As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label3 As Label
    Friend WithEvents tvCategorias As TreeView
    Friend WithEvents gbEstadoPedido As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents ChkLTipoPedido As CheckedListBox
    Friend WithEvents btnLimpiar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMarcarTodosNoInsu As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnMarcarTodos As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse3 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents gbInforme As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents rbtDetallado As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents rbtResumen As Guna.UI2.WinForms.Guna2RadioButton
    Friend WithEvents Guna2Elipse4 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse5 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse6 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse7 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label1 As Label
End Class
