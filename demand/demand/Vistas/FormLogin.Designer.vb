<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Pnlestado = New System.Windows.Forms.Panel()
        Me.Lblestado = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.TxtContraseña = New System.Windows.Forms.TextBox()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse3 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.BtnIngresar = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCancelar = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Elipse4 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse5 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse6 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Pnlestado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Pnlestado
        '
        Me.Pnlestado.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Pnlestado.Controls.Add(Me.Lblestado)
        Me.Pnlestado.Controls.Add(Me.btnSalir)
        Me.Pnlestado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnlestado.Location = New System.Drawing.Point(134, 0)
        Me.Pnlestado.Name = "Pnlestado"
        Me.Pnlestado.Size = New System.Drawing.Size(435, 32)
        Me.Pnlestado.TabIndex = 65
        '
        'Lblestado
        '
        Me.Lblestado.AutoSize = True
        Me.Lblestado.BackColor = System.Drawing.Color.Transparent
        Me.Lblestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblestado.Location = New System.Drawing.Point(121, 5)
        Me.Lblestado.Name = "Lblestado"
        Me.Lblestado.Size = New System.Drawing.Size(0, 18)
        Me.Lblestado.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(405, 0)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(30, 32)
        Me.btnSalir.TabIndex = 59
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'TxtContraseña
        '
        Me.TxtContraseña.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TxtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContraseña.ForeColor = System.Drawing.Color.White
        Me.TxtContraseña.Location = New System.Drawing.Point(171, 141)
        Me.TxtContraseña.Name = "TxtContraseña"
        Me.TxtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtContraseña.Size = New System.Drawing.Size(308, 15)
        Me.TxtContraseña.TabIndex = 62
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsuario.ForeColor = System.Drawing.Color.White
        Me.TxtUsuario.Location = New System.Drawing.Point(171, 76)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(308, 15)
        Me.TxtUsuario.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LightGray
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(196, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 19)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Contraseña:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightGray
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(196, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 19)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Usuario:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Guna2PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(134, 267)
        Me.Panel1.TabIndex = 66
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.FillColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), System.Drawing.Image)
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(15, 50)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(103, 136)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        '
        'Guna2Elipse3
        '
        Me.Guna2Elipse3.TargetControl = Me
        '
        'BtnIngresar
        '
        Me.BtnIngresar.Animated = True
        Me.BtnIngresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIngresar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnIngresar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnIngresar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnIngresar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnIngresar.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnIngresar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnIngresar.ForeColor = System.Drawing.Color.White
        Me.BtnIngresar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnIngresar.Image = CType(resources.GetObject("BtnIngresar.Image"), System.Drawing.Image)
        Me.BtnIngresar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.BtnIngresar.Location = New System.Drawing.Point(200, 193)
        Me.BtnIngresar.Name = "BtnIngresar"
        Me.BtnIngresar.Size = New System.Drawing.Size(118, 36)
        Me.BtnIngresar.TabIndex = 67
        Me.BtnIngresar.Text = "       Iniciar Sesión"
        Me.BtnIngresar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancelar.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnCancelar.ImageSize = New System.Drawing.Size(30, 30)
        Me.btnCancelar.Location = New System.Drawing.Point(351, 193)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(118, 36)
        Me.btnCancelar.TabIndex = 68
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Guna2Elipse4
        '
        Me.Guna2Elipse4.TargetControl = Me.BtnIngresar
        '
        'Guna2Elipse6
        '
        Me.Guna2Elipse6.TargetControl = Me.btnCancelar
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(569, 267)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.BtnIngresar)
        Me.Controls.Add(Me.Pnlestado)
        Me.Controls.Add(Me.TxtContraseña)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormLogin"
        Me.Opacity = 0.9R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLogin"
        Me.Pnlestado.ResumeLayout(False)
        Me.Pnlestado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Pnlestado As Panel
    Friend WithEvents Lblestado As Label
    Friend WithEvents TxtContraseña As TextBox
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse3 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents btnCancelar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BtnIngresar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Guna2Elipse4 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse5 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse6 As Guna.UI2.WinForms.Guna2Elipse
End Class
