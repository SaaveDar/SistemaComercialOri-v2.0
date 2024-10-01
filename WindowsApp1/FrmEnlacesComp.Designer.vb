<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnlacesComp
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.TxtFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtBuscaProducto = New System.Windows.Forms.TextBox()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.CmbBuscar = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrdDetalle = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridCabeceraComp = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblError = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tref_fecha = New System.Windows.Forms.TextBox()
        Me.tref_numero = New System.Windows.Forms.TextBox()
        Me.tref_serie = New System.Windows.Forms.TextBox()
        Me.tref_codigo = New System.Windows.Forms.TextBox()
        Me.GridComp = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdGrabar = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelarOper = New FontAwesome.Sharp.IconButton()
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GrdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCabeceraComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GridComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Gray
        Me.PanelSup.Controls.Add(Me.Label1)
        Me.PanelSup.Controls.Add(Me.Label5)
        Me.PanelSup.Controls.Add(Me.TxtFechaFin)
        Me.PanelSup.Controls.Add(Me.TxtFechaIni)
        Me.PanelSup.Controls.Add(Me.IconButton1)
        Me.PanelSup.Controls.Add(Me.Button1)
        Me.PanelSup.Controls.Add(Me.TxtBuscaProducto)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Controls.Add(Me.CmbBuscar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1296, 47)
        Me.PanelSup.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(126, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "FEC.HASTA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "FEC.DESDE"
        '
        'TxtFechaFin
        '
        Me.TxtFechaFin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaFin.Location = New System.Drawing.Point(115, 16)
        Me.TxtFechaFin.Name = "TxtFechaFin"
        Me.TxtFechaFin.Size = New System.Drawing.Size(106, 23)
        Me.TxtFechaFin.TabIndex = 87
        '
        'TxtFechaIni
        '
        Me.TxtFechaIni.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaIni.Location = New System.Drawing.Point(3, 16)
        Me.TxtFechaIni.Name = "TxtFechaIni"
        Me.TxtFechaIni.Size = New System.Drawing.Size(106, 23)
        Me.TxtFechaIni.TabIndex = 86
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Archive
        Me.IconButton1.IconColor = System.Drawing.Color.White
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 25
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.Location = New System.Drawing.Point(704, 4)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(174, 25)
        Me.IconButton1.TabIndex = 85
        Me.IconButton1.Text = "Muestra Modelo"
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(940, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'TxtBuscaProducto
        '
        Me.TxtBuscaProducto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscaProducto.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtBuscaProducto.Location = New System.Drawing.Point(467, 10)
        Me.TxtBuscaProducto.Name = "TxtBuscaProducto"
        Me.TxtBuscaProducto.Size = New System.Drawing.Size(255, 18)
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(1219, 3)
        Me.CmdRestaurar.Name = "CmdRestaurar"
        Me.CmdRestaurar.Size = New System.Drawing.Size(32, 25)
        Me.CmdRestaurar.TabIndex = 11
        Me.CmdRestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRestaurar.UseVisualStyleBackColor = True
        Me.CmdRestaurar.Visible = False
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
        Me.CmdCerrar.Location = New System.Drawing.Point(1257, 3)
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
        Me.CmdMin.Location = New System.Drawing.Point(1190, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        Me.CmdMin.Visible = False
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
        Me.CmbBuscar.Location = New System.Drawing.Point(661, 2)
        Me.CmbBuscar.Name = "CmbBuscar"
        Me.CmbBuscar.Size = New System.Drawing.Size(38, 27)
        Me.CmbBuscar.TabIndex = 6
        Me.CmbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmbBuscar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.GrdDetalle)
        Me.Panel1.Controls.Add(Me.GridCabeceraComp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1296, 247)
        Me.Panel1.TabIndex = 4
        '
        'GrdDetalle
        '
        Me.GrdDetalle.AllowUserToAddRows = False
        Me.GrdDetalle.AllowUserToResizeRows = False
        Me.GrdDetalle.BackgroundColor = System.Drawing.Color.Gray
        Me.GrdDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GrdDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.GrdDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GrdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.GrdDetalle.GridColor = System.Drawing.Color.White
        Me.GrdDetalle.Location = New System.Drawing.Point(648, 1)
        Me.GrdDetalle.MultiSelect = False
        Me.GrdDetalle.Name = "GrdDetalle"
        Me.GrdDetalle.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        Me.GrdDetalle.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GrdDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdDetalle.Size = New System.Drawing.Size(644, 243)
        Me.GrdDetalle.TabIndex = 83
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.HeaderText = "GrdDetalle"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'GridCabeceraComp
        '
        Me.GridCabeceraComp.AllowUserToAddRows = False
        Me.GridCabeceraComp.AllowUserToResizeRows = False
        Me.GridCabeceraComp.BackgroundColor = System.Drawing.Color.Gray
        Me.GridCabeceraComp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCabeceraComp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.GridCabeceraComp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridCabeceraComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCabeceraComp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.GridCabeceraComp.GridColor = System.Drawing.Color.White
        Me.GridCabeceraComp.Location = New System.Drawing.Point(2, 1)
        Me.GridCabeceraComp.MultiSelect = False
        Me.GridCabeceraComp.Name = "GridCabeceraComp"
        Me.GridCabeceraComp.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray
        Me.GridCabeceraComp.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GridCabeceraComp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCabeceraComp.Size = New System.Drawing.Size(644, 243)
        Me.GridCabeceraComp.TabIndex = 82
        '
        'Column1
        '
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "GridCabeceraComp"
        Me.Column1.Name = "Column1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.LblError)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 612)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1296, 24)
        Me.Panel2.TabIndex = 16
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 579)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1296, 33)
        Me.Panel3.TabIndex = 17
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.tref_fecha)
        Me.Panel4.Controls.Add(Me.tref_numero)
        Me.Panel4.Controls.Add(Me.tref_serie)
        Me.Panel4.Controls.Add(Me.tref_codigo)
        Me.Panel4.Controls.Add(Me.GridComp)
        Me.Panel4.Controls.Add(Me.CmdGrabar)
        Me.Panel4.Controls.Add(Me.CmdCancelarOper)
        Me.Panel4.Location = New System.Drawing.Point(0, 292)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1292, 275)
        Me.Panel4.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1087, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "FECHA COMP.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1087, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "SERIE COMP.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(1087, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "NUMERO COMP.:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1087, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(157, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "REF. DOCUMENTO ASOCIADO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1087, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "CODIGO COMP.:"
        '
        'tref_fecha
        '
        Me.tref_fecha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_fecha.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.tref_fecha.Location = New System.Drawing.Point(1090, 185)
        Me.tref_fecha.Name = "tref_fecha"
        Me.tref_fecha.Size = New System.Drawing.Size(101, 18)
        Me.tref_fecha.TabIndex = 88
        '
        'tref_numero
        '
        Me.tref_numero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_numero.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.tref_numero.Location = New System.Drawing.Point(1090, 143)
        Me.tref_numero.Name = "tref_numero"
        Me.tref_numero.Size = New System.Drawing.Size(101, 18)
        Me.tref_numero.TabIndex = 87
        '
        'tref_serie
        '
        Me.tref_serie.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_serie.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.tref_serie.Location = New System.Drawing.Point(1090, 97)
        Me.tref_serie.Name = "tref_serie"
        Me.tref_serie.Size = New System.Drawing.Size(62, 18)
        Me.tref_serie.TabIndex = 86
        '
        'tref_codigo
        '
        Me.tref_codigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_codigo.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.tref_codigo.Location = New System.Drawing.Point(1090, 58)
        Me.tref_codigo.Name = "tref_codigo"
        Me.tref_codigo.Size = New System.Drawing.Size(101, 18)
        Me.tref_codigo.TabIndex = 85
        '
        'GridComp
        '
        Me.GridComp.AllowUserToAddRows = False
        Me.GridComp.AllowUserToResizeRows = False
        Me.GridComp.BackgroundColor = System.Drawing.Color.Gray
        Me.GridComp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridComp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.GridComp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridComp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        Me.GridComp.GridColor = System.Drawing.Color.White
        Me.GridComp.Location = New System.Drawing.Point(3, 3)
        Me.GridComp.MultiSelect = False
        Me.GridComp.Name = "GridComp"
        Me.GridComp.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray
        Me.GridComp.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GridComp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridComp.Size = New System.Drawing.Size(1081, 244)
        Me.GridComp.TabIndex = 84
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "GridComp"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'CmdGrabar
        '
        Me.CmdGrabar.FlatAppearance.BorderSize = 0
        Me.CmdGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdGrabar.IconColor = System.Drawing.Color.White
        Me.CmdGrabar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrabar.IconSize = 25
        Me.CmdGrabar.Location = New System.Drawing.Point(1210, 58)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(74, 48)
        Me.CmdGrabar.TabIndex = 80
        Me.CmdGrabar.Text = "&ACEPTAR"
        Me.CmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'CmdCancelarOper
        '
        Me.CmdCancelarOper.FlatAppearance.BorderSize = 0
        Me.CmdCancelarOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelarOper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelarOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarOper.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.CmdCancelarOper.IconColor = System.Drawing.Color.White
        Me.CmdCancelarOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelarOper.IconSize = 25
        Me.CmdCancelarOper.Location = New System.Drawing.Point(1210, 131)
        Me.CmdCancelarOper.Name = "CmdCancelarOper"
        Me.CmdCancelarOper.Size = New System.Drawing.Size(74, 48)
        Me.CmdCancelarOper.TabIndex = 79
        Me.CmdCancelarOper.Text = "CANCELAR"
        Me.CmdCancelarOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdCancelarOper.UseVisualStyleBackColor = True
        '
        'FrmEnlacesComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1296, 636)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "FrmEnlacesComp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GrdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCabeceraComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.GridComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents TxtBuscaProducto As TextBox
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents CmbBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblError As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CmdGrabar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelarOper As FontAwesome.Sharp.IconButton
    Friend WithEvents Button1 As Button
    Friend WithEvents GridCabeceraComp As DataGridView
    Friend WithEvents GrdDetalle As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents GridComp As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtFechaFin As DateTimePicker
    Friend WithEvents TxtFechaIni As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tref_fecha As TextBox
    Friend WithEvents tref_numero As TextBox
    Friend WithEvents tref_serie As TextBox
    Friend WithEvents tref_codigo As TextBox
End Class
