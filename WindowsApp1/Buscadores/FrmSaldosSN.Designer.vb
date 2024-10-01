<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaldosSN
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
        Me.CmdBuscaComp = New FontAwesome.Sharp.IconButton()
        Me.BoxSocioNego = New System.Windows.Forms.Panel()
        Me.IconButton4 = New FontAwesome.Sharp.IconButton()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.CmdBusca_BoxSN = New FontAwesome.Sharp.IconButton()
        Me.TxtSocio_BoxSN = New System.Windows.Forms.TextBox()
        Me.info_SN = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmdAceptar = New FontAwesome.Sharp.IconButton()
        Me.LblProducto = New System.Windows.Forms.Label()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.PanelPie = New System.Windows.Forms.Panel()
        Me.LblError = New System.Windows.Forms.Label()
        Me.DGCuentasSN = New System.Windows.Forms.DataGridView()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMontoAplicar = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CmdMonedaComp = New FontAwesome.Sharp.IconButton()
        Me.PanelSup.SuspendLayout()
        Me.BoxSocioNego.SuspendLayout()
        Me.PanelPie.SuspendLayout()
        CType(Me.DGCuentasSN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.Label23)
        Me.PanelSup.Controls.Add(Me.CmdMonedaComp)
        Me.PanelSup.Controls.Add(Me.Label1)
        Me.PanelSup.Controls.Add(Me.CmdBuscaComp)
        Me.PanelSup.Controls.Add(Me.BoxSocioNego)
        Me.PanelSup.Controls.Add(Me.LblProducto)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(878, 127)
        Me.PanelSup.TabIndex = 4
        '
        'CmdBuscaComp
        '
        Me.CmdBuscaComp.FlatAppearance.BorderSize = 0
        Me.CmdBuscaComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBuscaComp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBuscaComp.ForeColor = System.Drawing.Color.White
        Me.CmdBuscaComp.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdBuscaComp.IconColor = System.Drawing.Color.White
        Me.CmdBuscaComp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdBuscaComp.IconSize = 25
        Me.CmdBuscaComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscaComp.Location = New System.Drawing.Point(336, 96)
        Me.CmdBuscaComp.Name = "CmdBuscaComp"
        Me.CmdBuscaComp.Size = New System.Drawing.Size(188, 27)
        Me.CmdBuscaComp.TabIndex = 2
        Me.CmdBuscaComp.Text = "&BUSCAR COMPROBANTES"
        Me.CmdBuscaComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscaComp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdBuscaComp.UseVisualStyleBackColor = True
        '
        'BoxSocioNego
        '
        Me.BoxSocioNego.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BoxSocioNego.Controls.Add(Me.IconButton4)
        Me.BoxSocioNego.Controls.Add(Me.IconButton2)
        Me.BoxSocioNego.Controls.Add(Me.CmdBusca_BoxSN)
        Me.BoxSocioNego.Controls.Add(Me.TxtSocio_BoxSN)
        Me.BoxSocioNego.Controls.Add(Me.info_SN)
        Me.BoxSocioNego.Controls.Add(Me.Label8)
        Me.BoxSocioNego.Location = New System.Drawing.Point(3, 3)
        Me.BoxSocioNego.Name = "BoxSocioNego"
        Me.BoxSocioNego.Size = New System.Drawing.Size(320, 105)
        Me.BoxSocioNego.TabIndex = 39
        Me.BoxSocioNego.Tag = "02"
        '
        'IconButton4
        '
        Me.IconButton4.BackColor = System.Drawing.Color.White
        Me.IconButton4.FlatAppearance.BorderSize = 0
        Me.IconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton4.ForeColor = System.Drawing.Color.White
        Me.IconButton4.IconChar = FontAwesome.Sharp.IconChar.CaretUp
        Me.IconButton4.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton4.IconSize = 20
        Me.IconButton4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton4.Location = New System.Drawing.Point(272, 28)
        Me.IconButton4.Name = "IconButton4"
        Me.IconButton4.Size = New System.Drawing.Size(23, 34)
        Me.IconButton4.TabIndex = 25
        Me.IconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton4.UseVisualStyleBackColor = False
        '
        'IconButton2
        '
        Me.IconButton2.BackColor = System.Drawing.Color.White
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton2.ForeColor = System.Drawing.Color.White
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.IconButton2.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 20
        Me.IconButton2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton2.Location = New System.Drawing.Point(272, 62)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(23, 35)
        Me.IconButton2.TabIndex = 24
        Me.IconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton2.UseVisualStyleBackColor = False
        '
        'CmdBusca_BoxSN
        '
        Me.CmdBusca_BoxSN.FlatAppearance.BorderSize = 0
        Me.CmdBusca_BoxSN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBusca_BoxSN.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBusca_BoxSN.ForeColor = System.Drawing.Color.White
        Me.CmdBusca_BoxSN.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdBusca_BoxSN.IconColor = System.Drawing.Color.White
        Me.CmdBusca_BoxSN.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdBusca_BoxSN.IconSize = 20
        Me.CmdBusca_BoxSN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusca_BoxSN.Location = New System.Drawing.Point(266, 2)
        Me.CmdBusca_BoxSN.Name = "CmdBusca_BoxSN"
        Me.CmdBusca_BoxSN.Size = New System.Drawing.Size(31, 20)
        Me.CmdBusca_BoxSN.TabIndex = 23
        Me.CmdBusca_BoxSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusca_BoxSN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBusca_BoxSN.UseVisualStyleBackColor = True
        '
        'TxtSocio_BoxSN
        '
        Me.TxtSocio_BoxSN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSocio_BoxSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSocio_BoxSN.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSocio_BoxSN.Location = New System.Drawing.Point(103, 5)
        Me.TxtSocio_BoxSN.MaxLength = 500
        Me.TxtSocio_BoxSN.Name = "TxtSocio_BoxSN"
        Me.TxtSocio_BoxSN.Size = New System.Drawing.Size(147, 16)
        Me.TxtSocio_BoxSN.TabIndex = 0
        '
        'info_SN
        '
        Me.info_SN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.info_SN.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_SN.Location = New System.Drawing.Point(3, 27)
        Me.info_SN.Name = "info_SN"
        Me.info_SN.Size = New System.Drawing.Size(291, 70)
        Me.info_SN.TabIndex = 1
        Me.info_SN.Text = "1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(2, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "SOCIO NEGOCIO :"
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
        Me.CmdAceptar.Location = New System.Drawing.Point(670, 8)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(113, 27)
        Me.CmdAceptar.TabIndex = 4
        Me.CmdAceptar.Text = "&ACEPTAR"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'LblProducto
        '
        Me.LblProducto.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProducto.ForeColor = System.Drawing.Color.White
        Me.LblProducto.Location = New System.Drawing.Point(326, 5)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(315, 18)
        Me.LblProducto.TabIndex = 11
        Me.LblProducto.Text = "SALDOS DE SOCIOS DE NEGOCIOS"
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
        Me.CmdCerrar.IconSize = 30
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(840, 1)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 34)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'PanelPie
        '
        Me.PanelPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelPie.Controls.Add(Me.lblMontoAplicar)
        Me.PanelPie.Controls.Add(Me.Label4)
        Me.PanelPie.Controls.Add(Me.LblError)
        Me.PanelPie.Controls.Add(Me.CmdAceptar)
        Me.PanelPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelPie.Location = New System.Drawing.Point(0, 494)
        Me.PanelPie.Name = "PanelPie"
        Me.PanelPie.Size = New System.Drawing.Size(878, 53)
        Me.PanelPie.TabIndex = 16
        '
        'LblError
        '
        Me.LblError.AutoSize = True
        Me.LblError.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblError.Location = New System.Drawing.Point(12, 8)
        Me.LblError.Name = "LblError"
        Me.LblError.Size = New System.Drawing.Size(0, 13)
        Me.LblError.TabIndex = 0
        '
        'DGCuentasSN
        '
        Me.DGCuentasSN.AllowUserToAddRows = False
        Me.DGCuentasSN.AllowUserToDeleteRows = False
        Me.DGCuentasSN.AllowUserToResizeRows = False
        Me.DGCuentasSN.BackgroundColor = System.Drawing.Color.White
        Me.DGCuentasSN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGCuentasSN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGCuentasSN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGCuentasSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCuentasSN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.usuario, Me.nombres, Me.apellidos, Me.doc, Me.numero, Me.celular, Me.fotoperfil, Me.ya_asignado, Me.idusuario, Me.index})
        Me.DGCuentasSN.GridColor = System.Drawing.Color.White
        Me.DGCuentasSN.Location = New System.Drawing.Point(0, 133)
        Me.DGCuentasSN.Name = "DGCuentasSN"
        Me.DGCuentasSN.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGCuentasSN.RowHeadersVisible = False
        Me.DGCuentasSN.RowTemplate.Height = 25
        Me.DGCuentasSN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCuentasSN.Size = New System.Drawing.Size(861, 355)
        Me.DGCuentasSN.TabIndex = 3
        Me.DGCuentasSN.Tag = "0"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 12)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "DETALLE DE DOCUMENTOS PENDIENTE :"
        '
        'lblMontoAplicar
        '
        Me.lblMontoAplicar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMontoAplicar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoAplicar.ForeColor = System.Drawing.Color.White
        Me.lblMontoAplicar.Location = New System.Drawing.Point(412, 8)
        Me.lblMontoAplicar.Name = "lblMontoAplicar"
        Me.lblMontoAplicar.Size = New System.Drawing.Size(146, 32)
        Me.lblMontoAplicar.TabIndex = 45
        Me.lblMontoAplicar.Text = "0"
        Me.lblMontoAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(320, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 27)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "MONTO APLICAR :"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(333, 29)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 27)
        Me.Label23.TabIndex = 42
        Me.Label23.Text = "MONEDA APLICACION:"
        '
        'CmdMonedaComp
        '
        Me.CmdMonedaComp.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdMonedaComp.FlatAppearance.BorderSize = 0
        Me.CmdMonedaComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMonedaComp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMonedaComp.ForeColor = System.Drawing.Color.White
        Me.CmdMonedaComp.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdMonedaComp.IconColor = System.Drawing.Color.White
        Me.CmdMonedaComp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMonedaComp.IconSize = 25
        Me.CmdMonedaComp.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdMonedaComp.Location = New System.Drawing.Point(425, 30)
        Me.CmdMonedaComp.Name = "CmdMonedaComp"
        Me.CmdMonedaComp.Size = New System.Drawing.Size(146, 26)
        Me.CmdMonedaComp.TabIndex = 43
        Me.CmdMonedaComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMonedaComp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMonedaComp.UseVisualStyleBackColor = False
        '
        'FrmSaldosSN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGCuentasSN)
        Me.Controls.Add(Me.PanelPie)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "FrmSaldosSN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.BoxSocioNego.ResumeLayout(False)
        Me.BoxSocioNego.PerformLayout()
        Me.PanelPie.ResumeLayout(False)
        Me.PanelPie.PerformLayout()
        CType(Me.DGCuentasSN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdAceptar As FontAwesome.Sharp.IconButton
    Friend WithEvents LblProducto As Label
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelPie As Panel
    Friend WithEvents LblError As Label
    Public WithEvents DGCuentasSN As DataGridView
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
    Friend WithEvents BoxSocioNego As Panel
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdBusca_BoxSN As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtSocio_BoxSN As TextBox
    Friend WithEvents info_SN As RichTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CmdBuscaComp As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents CmdMonedaComp As FontAwesome.Sharp.IconButton
    Friend WithEvents lblMontoAplicar As Label
    Friend WithEvents Label4 As Label
End Class
