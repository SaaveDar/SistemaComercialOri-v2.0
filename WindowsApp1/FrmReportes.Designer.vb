<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReportes
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
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.txtParametro = New System.Windows.Forms.TextBox()
        Me.lbtitulo = New System.Windows.Forms.Label()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.BoxPanelFiltros = New System.Windows.Forms.Panel()
        Me.BoxGrupoFiltros = New System.Windows.Forms.Panel()
        Me.btnlimpiarlista = New FontAwesome.Sharp.IconButton()
        Me.lb_filtrogr = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_grupoproductos = New FontAwesome.Sharp.IconButton()
        Me.BoxAlmacen = New System.Windows.Forms.Panel()
        Me.CmdAlmTransf = New FontAwesome.Sharp.IconButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.BoxLocales = New System.Windows.Forms.Panel()
        Me.checkboxlist_locales = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BoxFechaEmision = New System.Windows.Forms.Panel()
        Me.Inv_fechafin = New System.Windows.Forms.DateTimePicker()
        Me.Inv_fechaini = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmdFiltroPeriodo = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panel_report = New System.Windows.Forms.Panel()
        Me.creporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.id_reporte = New System.Windows.Forms.Label()
        Me.btn_max = New FontAwesome.Sharp.IconButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.twmenus = New System.Windows.Forms.TreeView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.panel_principal = New System.Windows.Forms.Panel()
        Me.PanelSup.SuspendLayout()
        Me.BoxPanelFiltros.SuspendLayout()
        Me.BoxGrupoFiltros.SuspendLayout()
        Me.BoxAlmacen.SuspendLayout()
        Me.BoxLocales.SuspendLayout()
        Me.BoxFechaEmision.SuspendLayout()
        Me.panel_report.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.panel_principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Gray
        Me.PanelSup.Controls.Add(Me.txtParametro)
        Me.PanelSup.Controls.Add(Me.lbtitulo)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1467, 26)
        Me.PanelSup.TabIndex = 3
        '
        'txtParametro
        '
        Me.txtParametro.BackColor = System.Drawing.Color.Gray
        Me.txtParametro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtParametro.Location = New System.Drawing.Point(12, 7)
        Me.txtParametro.Name = "txtParametro"
        Me.txtParametro.Size = New System.Drawing.Size(100, 13)
        Me.txtParametro.TabIndex = 16
        Me.txtParametro.Visible = False
        '
        'lbtitulo
        '
        Me.lbtitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbtitulo.AutoSize = True
        Me.lbtitulo.BackColor = System.Drawing.Color.Gray
        Me.lbtitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbtitulo.ForeColor = System.Drawing.Color.White
        Me.lbtitulo.Location = New System.Drawing.Point(250, 8)
        Me.lbtitulo.Name = "lbtitulo"
        Me.lbtitulo.Size = New System.Drawing.Size(13, 13)
        Me.lbtitulo.TabIndex = 14
        Me.lbtitulo.Text = "'&'"
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(1400, -3)
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
        Me.CmdCerrar.Location = New System.Drawing.Point(1429, -3)
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
        Me.CmdMin.Location = New System.Drawing.Point(1371, -3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'BoxPanelFiltros
        '
        Me.BoxPanelFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BoxPanelFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.BoxPanelFiltros.Controls.Add(Me.BoxGrupoFiltros)
        Me.BoxPanelFiltros.Controls.Add(Me.BoxAlmacen)
        Me.BoxPanelFiltros.Controls.Add(Me.btn_buscar)
        Me.BoxPanelFiltros.Controls.Add(Me.BoxLocales)
        Me.BoxPanelFiltros.Controls.Add(Me.BoxFechaEmision)
        Me.BoxPanelFiltros.Location = New System.Drawing.Point(0, 0)
        Me.BoxPanelFiltros.Name = "BoxPanelFiltros"
        Me.BoxPanelFiltros.Size = New System.Drawing.Size(1249, 228)
        Me.BoxPanelFiltros.TabIndex = 5
        '
        'BoxGrupoFiltros
        '
        Me.BoxGrupoFiltros.Controls.Add(Me.btnlimpiarlista)
        Me.BoxGrupoFiltros.Controls.Add(Me.lb_filtrogr)
        Me.BoxGrupoFiltros.Controls.Add(Me.Label9)
        Me.BoxGrupoFiltros.Controls.Add(Me.btn_grupoproductos)
        Me.BoxGrupoFiltros.Enabled = False
        Me.BoxGrupoFiltros.Location = New System.Drawing.Point(8, 89)
        Me.BoxGrupoFiltros.Name = "BoxGrupoFiltros"
        Me.BoxGrupoFiltros.Size = New System.Drawing.Size(218, 133)
        Me.BoxGrupoFiltros.TabIndex = 106
        '
        'btnlimpiarlista
        '
        Me.btnlimpiarlista.FlatAppearance.BorderSize = 0
        Me.btnlimpiarlista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpiarlista.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiarlista.ForeColor = System.Drawing.Color.White
        Me.btnlimpiarlista.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft
        Me.btnlimpiarlista.IconColor = System.Drawing.Color.White
        Me.btnlimpiarlista.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnlimpiarlista.IconSize = 30
        Me.btnlimpiarlista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlimpiarlista.Location = New System.Drawing.Point(168, 19)
        Me.btnlimpiarlista.Name = "btnlimpiarlista"
        Me.btnlimpiarlista.Size = New System.Drawing.Size(38, 29)
        Me.btnlimpiarlista.TabIndex = 101
        Me.btnlimpiarlista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlimpiarlista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnlimpiarlista.UseCompatibleTextRendering = True
        Me.btnlimpiarlista.UseVisualStyleBackColor = True
        '
        'lb_filtrogr
        '
        Me.lb_filtrogr.FormattingEnabled = True
        Me.lb_filtrogr.Location = New System.Drawing.Point(7, 47)
        Me.lb_filtrogr.Name = "lb_filtrogr"
        Me.lb_filtrogr.Size = New System.Drawing.Size(199, 95)
        Me.lb_filtrogr.TabIndex = 100
        Me.lb_filtrogr.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "&PRODUCTOS"
        '
        'btn_grupoproductos
        '
        Me.btn_grupoproductos.FlatAppearance.BorderSize = 0
        Me.btn_grupoproductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_grupoproductos.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grupoproductos.ForeColor = System.Drawing.Color.White
        Me.btn_grupoproductos.IconChar = FontAwesome.Sharp.IconChar.SprayCan
        Me.btn_grupoproductos.IconColor = System.Drawing.Color.White
        Me.btn_grupoproductos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_grupoproductos.IconSize = 30
        Me.btn_grupoproductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_grupoproductos.Location = New System.Drawing.Point(3, 13)
        Me.btn_grupoproductos.Name = "btn_grupoproductos"
        Me.btn_grupoproductos.Size = New System.Drawing.Size(133, 35)
        Me.btn_grupoproductos.TabIndex = 99
        Me.btn_grupoproductos.Text = "GRUPO DE PRODUCTOS"
        Me.btn_grupoproductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_grupoproductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_grupoproductos.UseVisualStyleBackColor = True
        '
        'BoxAlmacen
        '
        Me.BoxAlmacen.Controls.Add(Me.CmdAlmTransf)
        Me.BoxAlmacen.Controls.Add(Me.Label8)
        Me.BoxAlmacen.Enabled = False
        Me.BoxAlmacen.Location = New System.Drawing.Point(665, 6)
        Me.BoxAlmacen.Name = "BoxAlmacen"
        Me.BoxAlmacen.Size = New System.Drawing.Size(185, 72)
        Me.BoxAlmacen.TabIndex = 104
        '
        'CmdAlmTransf
        '
        Me.CmdAlmTransf.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAlmTransf.FlatAppearance.BorderSize = 0
        Me.CmdAlmTransf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAlmTransf.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAlmTransf.ForeColor = System.Drawing.Color.White
        Me.CmdAlmTransf.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdAlmTransf.IconColor = System.Drawing.Color.White
        Me.CmdAlmTransf.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAlmTransf.IconSize = 25
        Me.CmdAlmTransf.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdAlmTransf.Location = New System.Drawing.Point(14, 25)
        Me.CmdAlmTransf.Name = "CmdAlmTransf"
        Me.CmdAlmTransf.Size = New System.Drawing.Size(161, 31)
        Me.CmdAlmTransf.TabIndex = 107
        Me.CmdAlmTransf.Text = "ALMACENES"
        Me.CmdAlmTransf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAlmTransf.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdAlmTransf.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, -2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 13)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "DESCRIPCIÓN ALMACÉN :"
        '
        'btn_buscar
        '
        Me.btn_buscar.FlatAppearance.BorderSize = 0
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.Image = Global.WindowsApp1.My.Resources.Resources.ver_21
        Me.btn_buscar.Location = New System.Drawing.Point(856, 7)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(127, 71)
        Me.btn_buscar.TabIndex = 104
        Me.btn_buscar.Text = "&GENERAR REPORTE"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'BoxLocales
        '
        Me.BoxLocales.Controls.Add(Me.checkboxlist_locales)
        Me.BoxLocales.Controls.Add(Me.Label4)
        Me.BoxLocales.Enabled = False
        Me.BoxLocales.Location = New System.Drawing.Point(400, 7)
        Me.BoxLocales.Name = "BoxLocales"
        Me.BoxLocales.Size = New System.Drawing.Size(257, 71)
        Me.BoxLocales.TabIndex = 103
        '
        'checkboxlist_locales
        '
        Me.checkboxlist_locales.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.checkboxlist_locales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.checkboxlist_locales.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.checkboxlist_locales.ForeColor = System.Drawing.Color.White
        Me.checkboxlist_locales.FormattingEnabled = True
        Me.checkboxlist_locales.Location = New System.Drawing.Point(26, 14)
        Me.checkboxlist_locales.Name = "checkboxlist_locales"
        Me.checkboxlist_locales.Size = New System.Drawing.Size(220, 51)
        Me.checkboxlist_locales.TabIndex = 101
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(23, -2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "DESCRIPCIÓN LOCAL :"
        '
        'BoxFechaEmision
        '
        Me.BoxFechaEmision.Controls.Add(Me.Inv_fechafin)
        Me.BoxFechaEmision.Controls.Add(Me.Inv_fechaini)
        Me.BoxFechaEmision.Controls.Add(Me.Label6)
        Me.BoxFechaEmision.Controls.Add(Me.CmdFiltroPeriodo)
        Me.BoxFechaEmision.Controls.Add(Me.Label1)
        Me.BoxFechaEmision.Controls.Add(Me.Label3)
        Me.BoxFechaEmision.Enabled = False
        Me.BoxFechaEmision.Location = New System.Drawing.Point(8, 6)
        Me.BoxFechaEmision.Name = "BoxFechaEmision"
        Me.BoxFechaEmision.Size = New System.Drawing.Size(385, 71)
        Me.BoxFechaEmision.TabIndex = 102
        Me.BoxFechaEmision.TabStop = True
        Me.BoxFechaEmision.Tag = "10"
        '
        'Inv_fechafin
        '
        Me.Inv_fechafin.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inv_fechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Inv_fechafin.Location = New System.Drawing.Point(274, 42)
        Me.Inv_fechafin.Name = "Inv_fechafin"
        Me.Inv_fechafin.Size = New System.Drawing.Size(104, 22)
        Me.Inv_fechafin.TabIndex = 97
        '
        'Inv_fechaini
        '
        Me.Inv_fechaini.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inv_fechaini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Inv_fechaini.Location = New System.Drawing.Point(149, 42)
        Me.Inv_fechaini.Name = "Inv_fechaini"
        Me.Inv_fechaini.Size = New System.Drawing.Size(104, 22)
        Me.Inv_fechaini.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(271, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "HASTA :"
        '
        'CmdFiltroPeriodo
        '
        Me.CmdFiltroPeriodo.FlatAppearance.BorderSize = 0
        Me.CmdFiltroPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdFiltroPeriodo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFiltroPeriodo.ForeColor = System.Drawing.Color.White
        Me.CmdFiltroPeriodo.IconChar = FontAwesome.Sharp.IconChar.File
        Me.CmdFiltroPeriodo.IconColor = System.Drawing.Color.White
        Me.CmdFiltroPeriodo.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdFiltroPeriodo.IconSize = 30
        Me.CmdFiltroPeriodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFiltroPeriodo.Location = New System.Drawing.Point(4, 29)
        Me.CmdFiltroPeriodo.Name = "CmdFiltroPeriodo"
        Me.CmdFiltroPeriodo.Size = New System.Drawing.Size(133, 35)
        Me.CmdFiltroPeriodo.TabIndex = 94
        Me.CmdFiltroPeriodo.Text = "MOVIMIENTOS  HOY"
        Me.CmdFiltroPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFiltroPeriodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdFiltroPeriodo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&FECHAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(146, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "DESDE :"
        '
        'panel_report
        '
        Me.panel_report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_report.BackColor = System.Drawing.Color.White
        Me.panel_report.Controls.Add(Me.creporte)
        Me.panel_report.Controls.Add(Me.Panel3)
        Me.panel_report.Location = New System.Drawing.Point(0, 121)
        Me.panel_report.Name = "panel_report"
        Me.panel_report.Size = New System.Drawing.Size(1225, 482)
        Me.panel_report.TabIndex = 6
        '
        'creporte
        '
        Me.creporte.ActiveViewIndex = -1
        Me.creporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.creporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.creporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.creporte.Location = New System.Drawing.Point(0, 137)
        Me.creporte.Name = "creporte"
        Me.creporte.Size = New System.Drawing.Size(1225, 311)
        Me.creporte.TabIndex = 17
        Me.creporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.id_reporte)
        Me.Panel3.Controls.Add(Me.btn_max)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(0, 107)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1225, 30)
        Me.Panel3.TabIndex = 16
        '
        'id_reporte
        '
        Me.id_reporte.AutoSize = True
        Me.id_reporte.ForeColor = System.Drawing.Color.White
        Me.id_reporte.Location = New System.Drawing.Point(104, 3)
        Me.id_reporte.Name = "id_reporte"
        Me.id_reporte.Size = New System.Drawing.Size(17, 13)
        Me.id_reporte.TabIndex = 101
        Me.id_reporte.Text = """&"""
        '
        'btn_max
        '
        Me.btn_max.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_max.FlatAppearance.BorderSize = 0
        Me.btn_max.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_max.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.btn_max.ForeColor = System.Drawing.Color.White
        Me.btn_max.IconChar = FontAwesome.Sharp.IconChar.WindowRestore
        Me.btn_max.IconColor = System.Drawing.Color.White
        Me.btn_max.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_max.IconSize = 20
        Me.btn_max.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_max.Location = New System.Drawing.Point(1185, 3)
        Me.btn_max.Name = "btn_max"
        Me.btn_max.Size = New System.Drawing.Size(32, 25)
        Me.btn_max.TabIndex = 100
        Me.btn_max.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_max.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(7, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 23)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "REPORTE (INFORME) "
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(12, 22)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(140, 20)
        Me.txtbuscar.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "&Buscar"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel4.Controls.Add(Me.twmenus)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 26)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(243, 602)
        Me.Panel4.TabIndex = 14
        '
        'twmenus
        '
        Me.twmenus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.twmenus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.twmenus.FullRowSelect = True
        Me.twmenus.Location = New System.Drawing.Point(0, 58)
        Me.twmenus.Name = "twmenus"
        Me.twmenus.Size = New System.Drawing.Size(243, 544)
        Me.twmenus.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.AutoScroll = True
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel5.Controls.Add(Me.txtbuscar)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(243, 58)
        Me.Panel5.TabIndex = 0
        '
        'panel_principal
        '
        Me.panel_principal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_principal.Controls.Add(Me.BoxPanelFiltros)
        Me.panel_principal.Controls.Add(Me.panel_report)
        Me.panel_principal.Location = New System.Drawing.Point(242, 25)
        Me.panel_principal.Name = "panel_principal"
        Me.panel_principal.Size = New System.Drawing.Size(1225, 603)
        Me.panel_principal.TabIndex = 15
        '
        'FrmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1467, 628)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel_principal)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.PanelSup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.BoxPanelFiltros.ResumeLayout(False)
        Me.BoxGrupoFiltros.ResumeLayout(False)
        Me.BoxGrupoFiltros.PerformLayout()
        Me.BoxAlmacen.ResumeLayout(False)
        Me.BoxAlmacen.PerformLayout()
        Me.BoxLocales.ResumeLayout(False)
        Me.BoxLocales.PerformLayout()
        Me.BoxFechaEmision.ResumeLayout(False)
        Me.BoxFechaEmision.PerformLayout()
        Me.panel_report.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.panel_principal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents BoxPanelFiltros As Panel
    Friend WithEvents panel_report As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtbuscar As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents twmenus As TreeView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Inv_fechaini As DateTimePicker
    Friend WithEvents Inv_fechafin As DateTimePicker
    Friend WithEvents CmdFiltroPeriodo As FontAwesome.Sharp.IconButton
    Friend WithEvents Label4 As Label
    Friend WithEvents checkboxlist_locales As CheckedListBox
    Friend WithEvents BoxFechaEmision As Panel
    Friend WithEvents BoxLocales As Panel
    Friend WithEvents lbtitulo As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents txtParametro As TextBox
    Friend WithEvents btn_max As FontAwesome.Sharp.IconButton
    Friend WithEvents panel_principal As Panel
    Friend WithEvents creporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents BoxAlmacen As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents btn_grupoproductos As FontAwesome.Sharp.IconButton
    Friend WithEvents BoxGrupoFiltros As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents lb_filtrogr As ListBox
    Friend WithEvents btnlimpiarlista As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAlmTransf As FontAwesome.Sharp.IconButton
    Friend WithEvents id_reporte As Label
End Class
