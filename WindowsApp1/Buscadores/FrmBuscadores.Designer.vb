<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscadores
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscadores))
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.LblEtiqueta = New System.Windows.Forms.Label()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmbBuscar = New FontAwesome.Sharp.IconButton()
        Me.CmdAtras = New FontAwesome.Sharp.IconButton()
        Me.DataGridResul = New System.Windows.Forms.DataGridView()
        Me.ayuda = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelSup.SuspendLayout()
        CType(Me.DataGridResul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ayuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.LblEtiqueta)
        Me.PanelSup.Controls.Add(Me.TxtBuscar)
        Me.PanelSup.Controls.Add(Me.IconButton1)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmbBuscar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(816, 32)
        Me.PanelSup.TabIndex = 0
        '
        'LblEtiqueta
        '
        Me.LblEtiqueta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtiqueta.ForeColor = System.Drawing.Color.White
        Me.LblEtiqueta.Location = New System.Drawing.Point(5, 5)
        Me.LblEtiqueta.Name = "LblEtiqueta"
        Me.LblEtiqueta.Size = New System.Drawing.Size(178, 20)
        Me.LblEtiqueta.TabIndex = 16
        Me.LblEtiqueta.Text = "&F2 GRUPO MED. :"
        Me.LblEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtBuscar
        '
        Me.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscar.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtBuscar.Location = New System.Drawing.Point(194, 6)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(329, 18)
        Me.TxtBuscar.TabIndex = 1
        '
        'IconButton1
        '
        Me.IconButton1.BackColor = System.Drawing.Color.White
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.IconButton1.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 20
        Me.IconButton1.Location = New System.Drawing.Point(595, 3)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(125, 27)
        Me.IconButton1.TabIndex = 3
        Me.IconButton1.Tag = ""
        Me.IconButton1.Text = "&SELELCIONAR"
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = False
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
        Me.CmdCerrar.Location = New System.Drawing.Point(782, -4)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 25)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmbBuscar
        '
        Me.CmbBuscar.FlatAppearance.BorderSize = 0
        Me.CmbBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBuscar.ForeColor = System.Drawing.Color.White
        Me.CmbBuscar.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmbBuscar.IconColor = System.Drawing.Color.White
        Me.CmbBuscar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmbBuscar.IconSize = 25
        Me.CmbBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.Location = New System.Drawing.Point(529, 3)
        Me.CmbBuscar.Name = "CmbBuscar"
        Me.CmbBuscar.Size = New System.Drawing.Size(38, 27)
        Me.CmbBuscar.TabIndex = 2
        Me.CmbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmbBuscar.UseVisualStyleBackColor = True
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
        Me.CmdAtras.Location = New System.Drawing.Point(222, 309)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(102, 27)
        Me.CmdAtras.TabIndex = 91
        Me.CmdAtras.Text = "&Atrás"
        Me.CmdAtras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'DataGridResul
        '
        Me.DataGridResul.AllowUserToAddRows = False
        Me.DataGridResul.AllowUserToDeleteRows = False
        Me.DataGridResul.AllowUserToResizeRows = False
        Me.DataGridResul.BackgroundColor = System.Drawing.Color.White
        Me.DataGridResul.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridResul.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridResul.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridResul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridResul.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridResul.GridColor = System.Drawing.Color.White
        Me.DataGridResul.Location = New System.Drawing.Point(12, 40)
        Me.DataGridResul.MultiSelect = False
        Me.DataGridResul.Name = "DataGridResul"
        Me.DataGridResul.ReadOnly = True
        Me.DataGridResul.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridResul.RowHeadersVisible = False
        Me.DataGridResul.RowTemplate.Height = 25
        Me.DataGridResul.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridResul.Size = New System.Drawing.Size(776, 263)
        Me.DataGridResul.TabIndex = 4
        '
        'ayuda
        '
        Me.ayuda.ContainerControl = Me
        Me.ayuda.Icon = CType(resources.GetObject("ayuda.Icon"), System.Drawing.Icon)
        '
        'FrmBuscadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(816, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridResul)
        Me.Controls.Add(Me.CmdAtras)
        Me.Controls.Add(Me.PanelSup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmBuscadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        CType(Me.DataGridResul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ayuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmbBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAtras As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Public WithEvents LblEtiqueta As Label
    Friend WithEvents DataGridResul As DataGridView
    Friend WithEvents ayuda As ErrorProvider
End Class
