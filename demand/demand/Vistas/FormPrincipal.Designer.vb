<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrincipal))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnReporte = New Guna.UI2.WinForms.Guna2Button()
        Me.btnFormulario = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.GPformularios = New Guna.UI2.WinForms.Guna2Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPformularios.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.btnReporte)
        Me.Guna2Panel1.Controls.Add(Me.btnFormulario)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Button1)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Guna2Panel1.Controls.Add(Me.Guna2PictureBox1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1305, 60)
        Me.Guna2Panel1.TabIndex = 0
        '
        'btnReporte
        '
        Me.btnReporte.Animated = True
        Me.btnReporte.BorderRadius = 10
        Me.btnReporte.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnReporte.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnReporte.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnReporte.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnReporte.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReporte.Font = New System.Drawing.Font("Segoe UI Black", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnReporte.ForeColor = System.Drawing.Color.White
        Me.btnReporte.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnReporte.Location = New System.Drawing.Point(456, 11)
        Me.btnReporte.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(147, 45)
        Me.btnReporte.TabIndex = 3
        Me.btnReporte.Text = "Reporte"
        '
        'btnFormulario
        '
        Me.btnFormulario.Animated = True
        Me.btnFormulario.BorderRadius = 10
        Me.btnFormulario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFormulario.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnFormulario.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnFormulario.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnFormulario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnFormulario.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnFormulario.Font = New System.Drawing.Font("Segoe UI Black", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFormulario.ForeColor = System.Drawing.Color.White
        Me.btnFormulario.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnFormulario.Location = New System.Drawing.Point(280, 11)
        Me.btnFormulario.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFormulario.Name = "btnFormulario"
        Me.btnFormulario.Size = New System.Drawing.Size(147, 45)
        Me.btnFormulario.TabIndex = 2
        Me.btnFormulario.Text = "Análisis"
        '
        'Guna2Button1
        '
        Me.Guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.HoverState.FillColor = System.Drawing.Color.Red
        Me.Guna2Button1.Image = CType(resources.GetObject("Guna2Button1.Image"), System.Drawing.Image)
        Me.Guna2Button1.ImageSize = New System.Drawing.Size(40, 40)
        Me.Guna2Button1.Location = New System.Drawing.Point(1257, 1)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(48, 45)
        Me.Guna2Button1.TabIndex = 4
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(78, 23)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(165, 23)
        Me.Guna2HtmlLabel1.TabIndex = 1
        Me.Guna2HtmlLabel1.Text = "Análisis De Demanda"
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Image = Global.ANALISIS_DE_DEMANDA_UIMOD.My.Resources.Resources.informe_grafico
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(36, 19)
        Me.Guna2PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(34, 41)
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        '
        'GPformularios
        '
        Me.GPformularios.Controls.Add(Me.Panel1)
        Me.GPformularios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GPformularios.Location = New System.Drawing.Point(0, 60)
        Me.GPformularios.Name = "GPformularios"
        Me.GPformularios.Size = New System.Drawing.Size(1305, 833)
        Me.GPformularios.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1305, 833)
        Me.Panel1.TabIndex = 0
        '
        'Guna2Elipse2
        '
        Me.Guna2Elipse2.TargetControl = Me.Guna2Button1
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 893)
        Me.Controls.Add(Me.GPformularios)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPformularios.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnFormulario As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnReporte As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents GPformularios As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Panel1 As Panel
End Class
