<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVisualizador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisualizador))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.txtFiltro = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblTotalPedidos = New System.Windows.Forms.Label()
        Me.tituloForm = New System.Windows.Forms.Label()
        Me.btnVolver = New Guna.UI2.WinForms.Guna2Button()
        Me.btnExcel = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPDFResumen = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSeleccionar = New Guna.UI2.WinForms.Guna2Button()
        Me.btnLimpiarcheck = New Guna.UI2.WinForms.Guna2Button()
        Me.btnActualizar = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnPDFDetallado = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse3 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse4 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse5 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse6 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse7 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse8 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse9 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse10 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse11 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.lblTipoDetalle = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltro.Location = New System.Drawing.Point(36, 414)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(146, 16)
        Me.lblFiltro.TabIndex = 3
        Me.lblFiltro.Text = "Filtro de Busqueda: "
        '
        'txtFiltro
        '
        Me.txtFiltro.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.txtFiltro.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFiltro.DefaultText = ""
        Me.txtFiltro.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtFiltro.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtFiltro.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFiltro.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFiltro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFiltro.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFiltro.Location = New System.Drawing.Point(188, 414)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFiltro.PlaceholderText = ""
        Me.txtFiltro.SelectedText = ""
        Me.txtFiltro.Size = New System.Drawing.Size(200, 21)
        Me.txtFiltro.TabIndex = 4
        '
        'lblTotalPedidos
        '
        Me.lblTotalPedidos.AutoSize = True
        Me.lblTotalPedidos.Location = New System.Drawing.Point(570, 306)
        Me.lblTotalPedidos.Name = "lblTotalPedidos"
        Me.lblTotalPedidos.Size = New System.Drawing.Size(87, 13)
        Me.lblTotalPedidos.TabIndex = 8
        Me.lblTotalPedidos.Text = "Total de Pedidos"
        '
        'tituloForm
        '
        Me.tituloForm.AutoSize = True
        Me.tituloForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tituloForm.Location = New System.Drawing.Point(323, 18)
        Me.tituloForm.Name = "tituloForm"
        Me.tituloForm.Size = New System.Drawing.Size(207, 24)
        Me.tituloForm.TabIndex = 12
        Me.tituloForm.Text = "Análisis de Demanda"
        '
        'btnVolver
        '
        Me.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolver.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnVolver.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnVolver.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnVolver.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnVolver.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI Black", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnVolver.ForeColor = System.Drawing.Color.White
        Me.btnVolver.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnVolver.Image = CType(resources.GetObject("btnVolver.Image"), System.Drawing.Image)
        Me.btnVolver.Location = New System.Drawing.Point(672, 531)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(84, 25)
        Me.btnVolver.TabIndex = 11
        Me.btnVolver.Text = "  Volver"
        '
        'btnExcel
        '
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnExcel.FillColor = System.Drawing.Color.PaleGreen
        Me.btnExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExcel.ForeColor = System.Drawing.Color.White
        Me.btnExcel.HoverState.FillColor = System.Drawing.Color.Green
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.Location = New System.Drawing.Point(772, 474)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(38, 25)
        Me.btnExcel.TabIndex = 10
        '
        'btnPDFResumen
        '
        Me.btnPDFResumen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPDFResumen.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPDFResumen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPDFResumen.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPDFResumen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPDFResumen.FillColor = System.Drawing.Color.LightCoral
        Me.btnPDFResumen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPDFResumen.ForeColor = System.Drawing.Color.White
        Me.btnPDFResumen.HoverState.FillColor = System.Drawing.Color.Red
        Me.btnPDFResumen.Image = CType(resources.GetObject("btnPDFResumen.Image"), System.Drawing.Image)
        Me.btnPDFResumen.Location = New System.Drawing.Point(680, 474)
        Me.btnPDFResumen.Name = "btnPDFResumen"
        Me.btnPDFResumen.Size = New System.Drawing.Size(40, 25)
        Me.btnPDFResumen.TabIndex = 9
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSeleccionar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSeleccionar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSeleccionar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSeleccionar.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSeleccionar.Font = New System.Drawing.Font("Segoe UI Black", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnSeleccionar.ForeColor = System.Drawing.Color.White
        Me.btnSeleccionar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnSeleccionar.Image = CType(resources.GetObject("btnSeleccionar.Image"), System.Drawing.Image)
        Me.btnSeleccionar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnSeleccionar.Location = New System.Drawing.Point(515, 414)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(131, 25)
        Me.btnSeleccionar.TabIndex = 7
        Me.btnSeleccionar.Text = "Seleccionar Grilla"
        Me.btnSeleccionar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLimpiarcheck
        '
        Me.btnLimpiarcheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiarcheck.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnLimpiarcheck.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnLimpiarcheck.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnLimpiarcheck.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnLimpiarcheck.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLimpiarcheck.Font = New System.Drawing.Font("Segoe UI Black", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiarcheck.ForeColor = System.Drawing.Color.White
        Me.btnLimpiarcheck.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnLimpiarcheck.Image = CType(resources.GetObject("btnLimpiarcheck.Image"), System.Drawing.Image)
        Me.btnLimpiarcheck.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnLimpiarcheck.Location = New System.Drawing.Point(652, 414)
        Me.btnLimpiarcheck.Name = "btnLimpiarcheck"
        Me.btnLimpiarcheck.Size = New System.Drawing.Size(133, 25)
        Me.btnLimpiarcheck.TabIndex = 6
        Me.btnLimpiarcheck.Text = "Limpiar Selección"
        Me.btnLimpiarcheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnActualizar
        '
        Me.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnActualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnActualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnActualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnActualizar.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnActualizar.Font = New System.Drawing.Font("Segoe UI Black", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.Location = New System.Drawing.Point(411, 414)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(93, 25)
        Me.btnActualizar.TabIndex = 5
        Me.btnActualizar.Text = "Actualizar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Location = New System.Drawing.Point(140, 145)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(533, 212)
        Me.Panel1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(75, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(383, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Espere un momento, generando  Documento Excel..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(79, 98)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(374, 23)
        Me.ProgressBar1.TabIndex = 10
        '
        'btnPDFDetallado
        '
        Me.btnPDFDetallado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPDFDetallado.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnPDFDetallado.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnPDFDetallado.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnPDFDetallado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnPDFDetallado.FillColor = System.Drawing.Color.LightCoral
        Me.btnPDFDetallado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPDFDetallado.ForeColor = System.Drawing.Color.White
        Me.btnPDFDetallado.HoverState.FillColor = System.Drawing.Color.Red
        Me.btnPDFDetallado.Image = CType(resources.GetObject("btnPDFDetallado.Image"), System.Drawing.Image)
        Me.btnPDFDetallado.Location = New System.Drawing.Point(726, 474)
        Me.btnPDFDetallado.Name = "btnPDFDetallado"
        Me.btnPDFDetallado.Size = New System.Drawing.Size(40, 25)
        Me.btnPDFDetallado.TabIndex = 14
        '
        'Guna2Elipse2
        '
        Me.Guna2Elipse2.TargetControl = Me.btnSeleccionar
        '
        'Guna2Elipse3
        '
        Me.Guna2Elipse3.TargetControl = Me.btnLimpiarcheck
        '
        'Guna2Elipse4
        '
        Me.Guna2Elipse4.TargetControl = Me.btnActualizar
        '
        'Guna2Elipse5
        '
        Me.Guna2Elipse5.TargetControl = Me.btnPDFResumen
        '
        'Guna2Elipse6
        '
        Me.Guna2Elipse6.TargetControl = Me.btnPDFDetallado
        '
        'Guna2Elipse7
        '
        Me.Guna2Elipse7.TargetControl = Me.btnExcel
        '
        'Guna2Elipse8
        '
        Me.Guna2Elipse8.TargetControl = Me.Panel1
        '
        'Guna2Elipse9
        '
        Me.Guna2Elipse9.TargetControl = Me.ProgressBar1
        '
        'Guna2Elipse10
        '
        Me.Guna2Elipse10.TargetControl = Me.txtFiltro
        '
        'Guna2Elipse11
        '
        Me.Guna2Elipse11.TargetControl = Me.btnVolver
        '
        'lblTipoDetalle
        '
        Me.lblTipoDetalle.AutoSize = True
        Me.lblTipoDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTipoDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDetalle.ForeColor = System.Drawing.Color.White
        Me.lblTipoDetalle.Location = New System.Drawing.Point(36, 440)
        Me.lblTipoDetalle.Name = "lblTipoDetalle"
        Me.lblTipoDetalle.Size = New System.Drawing.Size(75, 15)
        Me.lblTipoDetalle.TabIndex = 15
        Me.lblTipoDetalle.Text = "tipodetalle"
        '
        'FrmVisualizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 613)
        Me.Controls.Add(Me.lblTipoDetalle)
        Me.Controls.Add(Me.btnPDFDetallado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tituloForm)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnPDFResumen)
        Me.Controls.Add(Me.lblTotalPedidos)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.btnLimpiarcheck)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.lblFiltro)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmVisualizador"
        Me.Text = "FrmVisualizador"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents txtFiltro As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents lblFiltro As Label
    Friend WithEvents lblTotalPedidos As Label
    Friend WithEvents btnSeleccionar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLimpiarcheck As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnActualizar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnVolver As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnExcel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnPDFResumen As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents tituloForm As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnPDFDetallado As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse3 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse4 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse5 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse6 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse7 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse8 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse9 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse10 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse11 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents lblTipoDetalle As Label
End Class
