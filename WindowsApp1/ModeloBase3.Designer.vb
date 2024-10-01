<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModeloBase3
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.TxtBuscaProducto = New System.Windows.Forms.TextBox()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.CmbBuscar = New FontAwesome.Sharp.IconButton()
        Me.PanelFiltros = New System.Windows.Forms.Panel()
        Me.CmdOcultaFiltro = New FontAwesome.Sharp.IconButton()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolTipBotones = New System.Windows.Forms.ToolTip(Me.components)
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgDocumentos = New System.Windows.Forms.DataGridView()
        Me.GRID = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtDetalle = New System.Windows.Forms.DataGridView()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MasDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_prod_mae = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Present = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.id_pres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_equix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EsTiP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.PanelSup.SuspendLayout()
        Me.PanelFiltros.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.TxtBuscaProducto)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Controls.Add(Me.CmbBuscar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1193, 32)
        Me.PanelSup.TabIndex = 2
        '
        'TxtBuscaProducto
        '
        Me.TxtBuscaProducto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscaProducto.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtBuscaProducto.Location = New System.Drawing.Point(3, 6)
        Me.TxtBuscaProducto.Name = "TxtBuscaProducto"
        Me.TxtBuscaProducto.Size = New System.Drawing.Size(390, 18)
        Me.TxtBuscaProducto.TabIndex = 12
        '
        'CmdRestaurar
        '
        Me.CmdRestaurar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdRestaurar.FlatAppearance.BorderSize = 0
        Me.CmdRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdRestaurar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdRestaurar.ForeColor = System.Drawing.Color.White
        Me.CmdRestaurar.IconChar = FontAwesome.Sharp.IconChar.WindowRestore
        Me.CmdRestaurar.IconColor = System.Drawing.Color.White
        Me.CmdRestaurar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdRestaurar.IconSize = 20
        Me.CmdRestaurar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdRestaurar.Location = New System.Drawing.Point(1132, 3)
        Me.CmdRestaurar.Name = "CmdRestaurar"
        Me.CmdRestaurar.Size = New System.Drawing.Size(32, 25)
        Me.CmdRestaurar.TabIndex = 11
        Me.CmdRestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRestaurar.UseVisualStyleBackColor = True
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
        Me.CmdCerrar.IconSize = 20
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(1161, 3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 25)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdMin
        '
        Me.CmdMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdMin.FlatAppearance.BorderSize = 0
        Me.CmdMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMin.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdMin.ForeColor = System.Drawing.Color.White
        Me.CmdMin.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        Me.CmdMin.IconColor = System.Drawing.Color.White
        Me.CmdMin.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMin.IconSize = 20
        Me.CmdMin.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdMin.Location = New System.Drawing.Point(1103, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'CmbBuscar
        '
        Me.CmbBuscar.FlatAppearance.BorderSize = 0
        Me.CmbBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBuscar.ForeColor = System.Drawing.Color.White
        Me.CmbBuscar.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmbBuscar.IconColor = System.Drawing.Color.White
        Me.CmbBuscar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmbBuscar.IconSize = 25
        Me.CmbBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.Location = New System.Drawing.Point(412, 2)
        Me.CmbBuscar.Name = "CmbBuscar"
        Me.CmbBuscar.Size = New System.Drawing.Size(38, 27)
        Me.CmbBuscar.TabIndex = 6
        Me.CmbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmbBuscar.UseVisualStyleBackColor = True
        '
        'PanelFiltros
        '
        Me.PanelFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.PanelFiltros.Controls.Add(Me.CmdOcultaFiltro)
        Me.PanelFiltros.Controls.Add(Me.IconButton2)
        Me.PanelFiltros.Controls.Add(Me.IconButton1)
        Me.PanelFiltros.Controls.Add(Me.Panel1)
        Me.PanelFiltros.Controls.Add(Me.TextBox1)
        Me.PanelFiltros.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelFiltros.Location = New System.Drawing.Point(0, 32)
        Me.PanelFiltros.Name = "PanelFiltros"
        Me.PanelFiltros.Size = New System.Drawing.Size(270, 685)
        Me.PanelFiltros.TabIndex = 7
        Me.PanelFiltros.Visible = False
        '
        'CmdOcultaFiltro
        '
        Me.CmdOcultaFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdOcultaFiltro.FlatAppearance.BorderSize = 0
        Me.CmdOcultaFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOcultaFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOcultaFiltro.ForeColor = System.Drawing.Color.White
        Me.CmdOcultaFiltro.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        Me.CmdOcultaFiltro.IconColor = System.Drawing.Color.White
        Me.CmdOcultaFiltro.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOcultaFiltro.IconSize = 30
        Me.CmdOcultaFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdOcultaFiltro.Location = New System.Drawing.Point(234, -1)
        Me.CmdOcultaFiltro.Name = "CmdOcultaFiltro"
        Me.CmdOcultaFiltro.Size = New System.Drawing.Size(30, 22)
        Me.CmdOcultaFiltro.TabIndex = 33
        Me.CmdOcultaFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdOcultaFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdOcultaFiltro.UseVisualStyleBackColor = True
        '
        'IconButton2
        '
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton2.ForeColor = System.Drawing.Color.White
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.Circle
        Me.IconButton2.IconColor = System.Drawing.Color.White
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 20
        Me.IconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton2.Location = New System.Drawing.Point(24, 10)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(109, 24)
        Me.IconButton2.TabIndex = 32
        Me.IconButton2.Text = "Limpiar Filtros"
        Me.IconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.White
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton1.IconColor = System.Drawing.Color.White
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 25
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.Location = New System.Drawing.Point(141, 6)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(89, 27)
        Me.IconButton1.TabIndex = 31
        Me.IconButton1.Text = "Buscar"
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ComboBox4)
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(266, 643)
        Me.Panel1.TabIndex = 30
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(9, 47)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(233, 210)
        Me.FlowLayoutPanel1.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(14, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Grupo / Tipo"
        '
        'ComboBox4
        '
        Me.ComboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.ForeColor = System.Drawing.Color.White
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"BAYER", "DIFARLIB", "GENFAR", "INKAFARMA", "MARKRO", "MEDDDA", "MEDIO FARMA", "PANEDERIA", "PANEL FARMA", "PORTUGAL", "QUIMICA SUIZA"})
        Me.ComboBox4.Location = New System.Drawing.Point(13, 18)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(229, 23)
        Me.ComboBox4.Sorted = True
        Me.ComboBox4.TabIndex = 16
        Me.ComboBox4.Text = "Filtrar..."
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBox1.Location = New System.Drawing.Point(2407, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(187, 18)
        Me.TextBox1.TabIndex = 24
        '
        'IconButton3
        '
        Me.IconButton3.FlatAppearance.BorderSize = 0
        Me.IconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton3.IconColor = System.Drawing.Color.White
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 25
        Me.IconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.Location = New System.Drawing.Point(307, 67)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(89, 27)
        Me.IconButton3.TabIndex = 32
        Me.IconButton3.Text = "Iniciar"
        Me.IconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(908, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 76)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "end"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column5})
        Me.DataGridView1.Location = New System.Drawing.Point(670, 67)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(202, 45)
        Me.DataGridView1.TabIndex = 35
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(819, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(179, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "GRID"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgDocumentos
        '
        Me.dgDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDocumentos.Location = New System.Drawing.Point(307, 118)
        Me.dgDocumentos.Name = "dgDocumentos"
        Me.dgDocumentos.Size = New System.Drawing.Size(592, 83)
        Me.dgDocumentos.TabIndex = 37
        '
        'GRID
        '
        Me.GRID.AllowUserToAddRows = False
        Me.GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.GRID.Location = New System.Drawing.Point(1072, 106)
        Me.GRID.Name = "GRID"
        Me.GRID.Size = New System.Drawing.Size(529, 133)
        Me.GRID.TabIndex = 34
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        '
        'dtDetalle
        '
        Me.dtDetalle.AllowUserToAddRows = False
        Me.dtDetalle.AllowUserToDeleteRows = False
        Me.dtDetalle.AllowUserToResizeRows = False
        Me.dtDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtDetalle.BackgroundColor = System.Drawing.Color.White
        Me.dtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.MasDetalle, Me.Codigo, Me.id_prod_mae, Me.Cantidad, Me.Present, Me.id_pres, Me.v_equix, Me.EsTiP, Me.Alm})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtDetalle.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtDetalle.GridColor = System.Drawing.Color.White
        Me.dtDetalle.Location = New System.Drawing.Point(920, 245)
        Me.dtDetalle.Name = "dtDetalle"
        Me.dtDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtDetalle.RowHeadersVisible = False
        Me.dtDetalle.RowTemplate.Height = 25
        Me.dtDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dtDetalle.Size = New System.Drawing.Size(244, 327)
        Me.dtDetalle.TabIndex = 10
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'MasDetalle
        '
        Me.MasDetalle.HeaderText = "MasDetalle"
        Me.MasDetalle.Name = "MasDetalle"
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        '
        'id_prod_mae
        '
        Me.id_prod_mae.HeaderText = "id_prod_mae"
        Me.id_prod_mae.Name = "id_prod_mae"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'Present
        '
        Me.Present.HeaderText = "Present"
        Me.Present.Name = "Present"
        '
        'id_pres
        '
        Me.id_pres.HeaderText = "id_pres"
        Me.id_pres.Name = "id_pres"
        '
        'v_equix
        '
        Me.v_equix.HeaderText = "v_equix"
        Me.v_equix.Name = "v_equix"
        '
        'EsTiP
        '
        Me.EsTiP.HeaderText = "EsTiP"
        Me.EsTiP.Name = "EsTiP"
        '
        'Alm
        '
        Me.Alm.HeaderText = "Alm"
        Me.Alm.Name = "Alm"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(987, 179)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(79, 23)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Iniciar Fire"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(783, 315)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(105, 55)
        Me.Button4.TabIndex = 39
        Me.Button4.Text = "MODO REMITENTE "
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(783, 376)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(122, 90)
        Me.TextBox2.TabIndex = 40
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(1077, 376)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(122, 90)
        Me.TextBox3.TabIndex = 42
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1077, 315)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(105, 55)
        Me.Button5.TabIndex = 41
        Me.Button5.Text = "MODO DESTINATARIO"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(316, 468)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(105, 25)
        Me.Button6.TabIndex = 43
        Me.Button6.Text = "ENVIO SMS"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(375, 279)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(131, 49)
        Me.Button7.TabIndex = 44
        Me.Button7.Text = "Conectar"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'ModeloBase3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1193, 717)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dgDocumentos)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GRID)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.IconButton3)
        Me.Controls.Add(Me.dtDetalle)
        Me.Controls.Add(Me.PanelFiltros)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "ModeloBase3"
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.PanelFiltros.ResumeLayout(False)
        Me.PanelFiltros.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents TxtBuscaProducto As TextBox
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents CmbBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelFiltros As Panel
    Friend WithEvents CmdOcultaFiltro As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ToolTipBotones As ToolTip
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button1 As Button
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents MasDetalle As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents id_prod_mae As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Present As DataGridViewComboBoxColumn
    Friend WithEvents id_pres As DataGridViewTextBoxColumn
    Friend WithEvents v_equix As DataGridViewTextBoxColumn
    Friend WithEvents EsTiP As DataGridViewTextBoxColumn
    Friend WithEvents Alm As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents dgDocumentos As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents GRID As DataGridView
    Friend WithEvents dtDetalle As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
End Class
Public Class DgvPlus
    Inherits Windows.Forms.DataGridView
    Protected Overrides Function ProcessDialogKey(ByVal KeyData As System.Windows.Forms.Keys) As Boolean


        If KeyData = Keys.Enter Then
            If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
                ' Verificar si se ingresó un número en la primera columna antes de agregar una nueva fila
                Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
                'If Not IsNumeric(valor) Then
                '    'MessageBox.Show("Ingrese solo números en la primera columna.")
                '    Return True ' Evita que se procese la tecla Enter
                'End If

                ModeloBase3.NuevaFila()
                Return True
            End If

            SendKeys.Send(Chr(Keys.Tab))
            Return True
        End If
        If Me.CurrentCell.ColumnIndex = 1 Then ' pasar TEXTOS   LO QUE NO QUIERO QUE INGRESE A LOS TEXTOS
            If IsNumeric(Chr(KeyData)) Then
                'If KeyData >= Keys.D0 And KeyData <= Keys.D9 Then
                Return True
            End If

        End If
        If Me.CurrentCell.ColumnIndex = 2 Then ' pasar NUMEROS LO QUE NO QUIERO QUE ACEPRO PARA LOS NUMEROS 
            If KeyData >= Keys.A And KeyData <= Keys.Z Then
                Return True
            End If

        End If



        Return MyBase.ProcessDialogKey(KeyData)











        ''        If Not IsNumeric(wtecla.KeyChar()) = True And wtecla.KeyChar <> ChrW(Keys.Back) Then
        ''Dim car As String, Longt As Integer
        ''car = Chr$(tecla)
        ''car = UCase$(Chr$(tecla))
        ''tecla = Asc(car)
        ''If car < "0" Or car > "9" Then
        ''    If tecla <> 8 And tecla <> 13 Then
        ''        tecla = 0
        ''        Beep()
        ''    End If
        ''End If

        ''If KeyData < Keys.D0 Or KeyData > Keys.D9 Then
        '' Return True
        '' End If

        'If KeyData = Keys.Enter Then

        '    If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
        '        ModeloBase3.NuevaFila()
        '        Return True
        '    End If'
        '    SendKeys.Send(Chr(Keys.Tab))
        '    Return True
        'Else
        '    ' AONAS DE VLAIDACION DE CELDAS

        '    If Me.CurrentCell.ColumnIndex = 1 Then

        '        'If KeyData <> Keys.Back AndAlso KeyData <> Keys.Delete AndAlso KeyData < Keys.D0 OrElse KeyData > Keys.D9 Then
        '        If KeyData = Keys.D0 Then

        '        Else
        '            ' SendKeys.Send(KeyData)
        '            'If KeyData = Keys.Enter Then SendKeys.Send(Chr(Keys.Tab))
        '            'Return MyBase.ProcessDialogKey(KeyData)
        '            '   Return True
        '        End If
        '        '        End If
        '        'End If
        '    End If
        '    Return MyBase.ProcessDialogKey(KeyData)
        'End If

        'ORIGINAL FUNONA 

        'If KeyData = Keys.Enter Then
        '    If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
        '        ModeloBase3.NuevaFila()
        '        Return True
        '    End If
        '    SendKeys.Send(Chr(Keys.Tab))
        '    Return True
        'Else
        '    Return MyBase.ProcessDialogKey(KeyData)
        'End If



    End Function
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)


        ' RUTINA ORIGINAL FUNCIONAL
        If e.KeyData = Keys.Enter Then
            SendKeys.Send(Chr(Keys.Tab))
        Else
            MyBase.OnKeyDown(e)
        End If
    End Sub

End Class
