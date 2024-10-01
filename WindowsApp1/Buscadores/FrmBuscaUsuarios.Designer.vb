<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaUsuarios
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
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmdBuscar = New FontAwesome.Sharp.IconButton()
        Me.TxtBuscaUser = New System.Windows.Forms.TextBox()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdAceptar = New FontAwesome.Sharp.IconButton()
        Me.CmdAtras = New FontAwesome.Sharp.IconButton()
        Me.DGUser = New System.Windows.Forms.DataGridView()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apellidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.celular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fotoperfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ya_asignado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idusuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelSup.SuspendLayout()
        CType(Me.DGUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.Label12)
        Me.PanelSup.Controls.Add(Me.CmdBuscar)
        Me.PanelSup.Controls.Add(Me.TxtBuscaUser)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(649, 32)
        Me.PanelSup.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(12, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 15)
        Me.Label12.TabIndex = 128
        Me.Label12.Text = "&Nombre o Usuario :"
        '
        'CmdBuscar
        '
        Me.CmdBuscar.FlatAppearance.BorderSize = 0
        Me.CmdBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBuscar.ForeColor = System.Drawing.Color.White
        Me.CmdBuscar.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdBuscar.IconColor = System.Drawing.Color.White
        Me.CmdBuscar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdBuscar.IconSize = 20
        Me.CmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscar.Location = New System.Drawing.Point(520, 2)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(37, 25)
        Me.CmdBuscar.TabIndex = 1
        Me.CmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBuscar.UseVisualStyleBackColor = True
        '
        'TxtBuscaUser
        '
        Me.TxtBuscaUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscaUser.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtBuscaUser.Location = New System.Drawing.Point(124, 5)
        Me.TxtBuscaUser.Name = "TxtBuscaUser"
        Me.TxtBuscaUser.Size = New System.Drawing.Size(390, 18)
        Me.TxtBuscaUser.TabIndex = 0
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
        Me.CmdCerrar.IconSize = 25
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(609, -2)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 25)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.BackColor = System.Drawing.Color.White
        Me.CmdAceptar.FlatAppearance.BorderSize = 0
        Me.CmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAceptar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAceptar.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdAceptar.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAceptar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAceptar.IconSize = 20
        Me.CmdAceptar.Location = New System.Drawing.Point(375, 326)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(123, 25)
        Me.CmdAceptar.TabIndex = 3
        Me.CmdAceptar.Text = "&Aceptar"
        Me.CmdAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAceptar.UseVisualStyleBackColor = False
        '
        'CmdAtras
        '
        Me.CmdAtras.FlatAppearance.BorderSize = 0
        Me.CmdAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAtras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAtras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAtras.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        Me.CmdAtras.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAtras.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAtras.IconSize = 25
        Me.CmdAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAtras.Location = New System.Drawing.Point(158, 324)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(102, 27)
        Me.CmdAtras.TabIndex = 4
        Me.CmdAtras.Text = "&Atrás"
        Me.CmdAtras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'DGUser
        '
        Me.DGUser.AllowUserToAddRows = False
        Me.DGUser.AllowUserToDeleteRows = False
        Me.DGUser.AllowUserToResizeRows = False
        Me.DGUser.BackgroundColor = System.Drawing.Color.White
        Me.DGUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.usuario, Me.nombres, Me.apellidos, Me.doc, Me.numero, Me.celular, Me.fotoperfil, Me.ya_asignado, Me.idusuario, Me.index})
        Me.DGUser.GridColor = System.Drawing.Color.White
        Me.DGUser.Location = New System.Drawing.Point(0, 33)
        Me.DGUser.Name = "DGUser"
        Me.DGUser.ReadOnly = True
        Me.DGUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGUser.RowHeadersVisible = False
        Me.DGUser.RowTemplate.Height = 25
        Me.DGUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGUser.Size = New System.Drawing.Size(626, 267)
        Me.DGUser.TabIndex = 2
        Me.DGUser.Tag = "0"
        '
        'usuario
        '
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        '
        'nombres
        '
        Me.nombres.HeaderText = "Nombres"
        Me.nombres.Name = "nombres"
        Me.nombres.ReadOnly = True
        '
        'apellidos
        '
        Me.apellidos.HeaderText = "Apellidos"
        Me.apellidos.Name = "apellidos"
        Me.apellidos.ReadOnly = True
        '
        'doc
        '
        Me.doc.HeaderText = "DOC"
        Me.doc.Name = "doc"
        Me.doc.ReadOnly = True
        '
        'numero
        '
        Me.numero.HeaderText = "Numero"
        Me.numero.Name = "numero"
        Me.numero.ReadOnly = True
        '
        'celular
        '
        Me.celular.HeaderText = "Celular"
        Me.celular.Name = "celular"
        Me.celular.ReadOnly = True
        '
        'fotoperfil
        '
        Me.fotoperfil.HeaderText = "FotoPerfil"
        Me.fotoperfil.Name = "fotoperfil"
        Me.fotoperfil.ReadOnly = True
        Me.fotoperfil.Visible = False
        '
        'ya_asignado
        '
        Me.ya_asignado.HeaderText = "Estado"
        Me.ya_asignado.Name = "ya_asignado"
        Me.ya_asignado.ReadOnly = True
        '
        'idusuario
        '
        Me.idusuario.HeaderText = "idusuario"
        Me.idusuario.Name = "idusuario"
        Me.idusuario.ReadOnly = True
        Me.idusuario.Visible = False
        '
        'index
        '
        Me.index.HeaderText = "index"
        Me.index.Name = "index"
        Me.index.ReadOnly = True
        Me.index.Visible = False
        '
        'FrmBuscaUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(649, 392)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGUser)
        Me.Controls.Add(Me.CmdAtras)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.PanelSup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmBuscaUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        CType(Me.DGUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents TxtBuscaUser As TextBox
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents Label12 As Label
    Friend WithEvents CmdAceptar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAtras As FontAwesome.Sharp.IconButton
    Public WithEvents DGUser As DataGridView
    Friend WithEvents usuario As DataGridViewTextBoxColumn
    Friend WithEvents nombres As DataGridViewTextBoxColumn
    Friend WithEvents apellidos As DataGridViewTextBoxColumn
    Friend WithEvents doc As DataGridViewTextBoxColumn
    Friend WithEvents numero As DataGridViewTextBoxColumn
    Friend WithEvents celular As DataGridViewTextBoxColumn
    Friend WithEvents fotoperfil As DataGridViewTextBoxColumn
    Friend WithEvents ya_asignado As DataGridViewTextBoxColumn
    Friend WithEvents idusuario As DataGridViewTextBoxColumn
    Friend WithEvents index As DataGridViewTextBoxColumn
End Class
