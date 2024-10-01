<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRefProd
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
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.LblNombreProd = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdCancelar = New FontAwesome.Sharp.IconButton()
        Me.CmdAceptar = New FontAwesome.Sharp.IconButton()
        Me.t_ref_prod = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.LblNombreProd)
        Me.PanelSup.Controls.Add(Me.Label1)
        Me.PanelSup.Controls.Add(Me.Label2)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(476, 74)
        Me.PanelSup.TabIndex = 3
        '
        'LblNombreProd
        '
        Me.LblNombreProd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreProd.ForeColor = System.Drawing.Color.White
        Me.LblNombreProd.Location = New System.Drawing.Point(12, 19)
        Me.LblNombreProd.Name = "LblNombreProd"
        Me.LblNombreProd.Size = New System.Drawing.Size(395, 39)
        Me.LblNombreProd.TabIndex = 40
        Me.LblNombreProd.Text = "PRODUCTO / SERVICIO :"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightGray
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 19)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "PRODUCTO / SERVICIO :"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LightGray
        Me.Label2.Location = New System.Drawing.Point(4, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 19)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "DETALLE REFERENCIA  ADICIONAL:"
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdCerrar.FlatAppearance.BorderSize = 0
        Me.CmdCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCerrar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdCerrar.ForeColor = System.Drawing.Color.White
        Me.CmdCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.CmdCerrar.IconColor = System.Drawing.Color.White
        Me.CmdCerrar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCerrar.IconSize = 40
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(432, 0)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 40)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.CmdCancelar)
        Me.Panel1.Controls.Add(Me.CmdAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 263)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 56)
        Me.Panel1.TabIndex = 4
        '
        'CmdCancelar
        '
        Me.CmdCancelar.FlatAppearance.BorderSize = 0
        Me.CmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelar.ForeColor = System.Drawing.Color.White
        Me.CmdCancelar.IconChar = FontAwesome.Sharp.IconChar.Eraser
        Me.CmdCancelar.IconColor = System.Drawing.Color.White
        Me.CmdCancelar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelar.IconSize = 25
        Me.CmdCancelar.Location = New System.Drawing.Point(231, 6)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(111, 27)
        Me.CmdCancelar.TabIndex = 78
        Me.CmdCancelar.Text = "&CANCELAR"
        Me.CmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.FlatAppearance.BorderSize = 0
        Me.CmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAceptar.ForeColor = System.Drawing.Color.White
        Me.CmdAceptar.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmdAceptar.IconColor = System.Drawing.Color.White
        Me.CmdAceptar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAceptar.IconSize = 25
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(95, 6)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(113, 27)
        Me.CmdAceptar.TabIndex = 36
        Me.CmdAceptar.Text = "&ACEPTAR"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        't_ref_prod
        '
        Me.t_ref_prod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.t_ref_prod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.t_ref_prod.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_ref_prod.Location = New System.Drawing.Point(0, 74)
        Me.t_ref_prod.Multiline = True
        Me.t_ref_prod.Name = "t_ref_prod"
        Me.t_ref_prod.Size = New System.Drawing.Size(476, 189)
        Me.t_ref_prod.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'FrmRefProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 319)
        Me.ControlBox = False
        Me.Controls.Add(Me.t_ref_prod)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelSup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRefProd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CmdAceptar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelar As FontAwesome.Sharp.IconButton
    Friend WithEvents t_ref_prod As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents LblNombreProd As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
