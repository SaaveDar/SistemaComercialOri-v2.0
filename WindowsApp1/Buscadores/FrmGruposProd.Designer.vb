<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGruposProd
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.LblEtiqueta = New System.Windows.Forms.Label()
        Me.CmdBuscar = New FontAwesome.Sharp.IconButton()
        Me.TxtBuscaProducto = New System.Windows.Forms.TextBox()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.CmdSintomas = New FontAwesome.Sharp.IconButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CmdAddItem = New FontAwesome.Sharp.IconButton()
        Me.GridGrupos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.LblEtiqueta)
        Me.PanelSup.Controls.Add(Me.CmdBuscar)
        Me.PanelSup.Controls.Add(Me.TxtBuscaProducto)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(461, 53)
        Me.PanelSup.TabIndex = 3
        '
        'LblEtiqueta
        '
        Me.LblEtiqueta.AutoSize = True
        Me.LblEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtiqueta.ForeColor = System.Drawing.Color.White
        Me.LblEtiqueta.Location = New System.Drawing.Point(12, 6)
        Me.LblEtiqueta.Name = "LblEtiqueta"
        Me.LblEtiqueta.Size = New System.Drawing.Size(168, 15)
        Me.LblEtiqueta.TabIndex = 14
        Me.LblEtiqueta.Text = "LABORATORIO  / SERVICUIOS"
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
        Me.CmdBuscar.Location = New System.Drawing.Point(342, 26)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(37, 24)
        Me.CmdBuscar.TabIndex = 13
        Me.CmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBuscar.UseVisualStyleBackColor = True
        '
        'TxtBuscaProducto
        '
        Me.TxtBuscaProducto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscaProducto.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtBuscaProducto.Location = New System.Drawing.Point(3, 28)
        Me.TxtBuscaProducto.Name = "TxtBuscaProducto"
        Me.TxtBuscaProducto.Size = New System.Drawing.Size(333, 18)
        Me.TxtBuscaProducto.TabIndex = 12
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
        Me.CmdCerrar.Location = New System.Drawing.Point(426, 3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 25)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.IconButton2)
        Me.Panel1.Controls.Add(Me.IconButton1)
        Me.Panel1.Controls.Add(Me.CmdSintomas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 409)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(461, 41)
        Me.Panel1.TabIndex = 4
        '
        'IconButton2
        '
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton2.ForeColor = System.Drawing.Color.White
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.IconButton2.IconColor = System.Drawing.Color.White
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 18
        Me.IconButton2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton2.Location = New System.Drawing.Point(113, 3)
        Me.IconButton2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(104, 28)
        Me.IconButton2.TabIndex = 90
        Me.IconButton2.Tag = "100"
        Me.IconButton2.Text = "EDITAR"
        Me.IconButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.White
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.IconButton1.IconColor = System.Drawing.Color.White
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 18
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton1.Location = New System.Drawing.Point(223, 3)
        Me.IconButton1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(104, 28)
        Me.IconButton1.TabIndex = 89
        Me.IconButton1.Tag = "100"
        Me.IconButton1.Text = "ELIMINAR"
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'CmdSintomas
        '
        Me.CmdSintomas.FlatAppearance.BorderSize = 0
        Me.CmdSintomas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSintomas.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSintomas.ForeColor = System.Drawing.Color.White
        Me.CmdSintomas.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.CmdSintomas.IconColor = System.Drawing.Color.White
        Me.CmdSintomas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSintomas.IconSize = 18
        Me.CmdSintomas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdSintomas.Location = New System.Drawing.Point(26, 3)
        Me.CmdSintomas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdSintomas.Name = "CmdSintomas"
        Me.CmdSintomas.Size = New System.Drawing.Size(104, 28)
        Me.CmdSintomas.TabIndex = 88
        Me.CmdSintomas.Tag = "100"
        Me.CmdSintomas.Text = "CREAR"
        Me.CmdSintomas.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdSintomas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSintomas.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.CmdAddItem)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(373, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(88, 356)
        Me.Panel2.TabIndex = 5
        '
        'CmdAddItem
        '
        Me.CmdAddItem.FlatAppearance.BorderSize = 0
        Me.CmdAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAddItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAddItem.ForeColor = System.Drawing.Color.White
        Me.CmdAddItem.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.CmdAddItem.IconColor = System.Drawing.Color.White
        Me.CmdAddItem.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAddItem.IconSize = 18
        Me.CmdAddItem.Location = New System.Drawing.Point(0, 3)
        Me.CmdAddItem.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdAddItem.Name = "CmdAddItem"
        Me.CmdAddItem.Size = New System.Drawing.Size(85, 350)
        Me.CmdAddItem.TabIndex = 89
        Me.CmdAddItem.Tag = "100"
        Me.CmdAddItem.Text = "AGREGAR"
        Me.CmdAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAddItem.UseVisualStyleBackColor = True
        '
        'GridGrupos
        '
        Me.GridGrupos.AllowUserToAddRows = False
        Me.GridGrupos.AllowUserToResizeRows = False
        Me.GridGrupos.BackgroundColor = System.Drawing.Color.White
        Me.GridGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridGrupos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.GridGrupos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridGrupos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.GridGrupos.GridColor = System.Drawing.Color.White
        Me.GridGrupos.Location = New System.Drawing.Point(12, 83)
        Me.GridGrupos.MultiSelect = False
        Me.GridGrupos.Name = "GridGrupos"
        Me.GridGrupos.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        Me.GridGrupos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GridGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridGrupos.Size = New System.Drawing.Size(334, 307)
        Me.GridGrupos.TabIndex = 83
        '
        'Column1
        '
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "GridCabeceraComp"
        Me.Column1.Name = "Column1"
        '
        'FrmGruposProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridGrupos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelSup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGruposProd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents TxtBuscaProducto As TextBox
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GridGrupos As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents LblEtiqueta As Label
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdSintomas As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAddItem As FontAwesome.Sharp.IconButton
End Class
