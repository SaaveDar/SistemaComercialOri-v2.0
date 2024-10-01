<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenuProductos
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
        Me.PanelImportar = New System.Windows.Forms.Panel()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.PanelPropios = New System.Windows.Forms.Panel()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.CmbBuscar = New FontAwesome.Sharp.IconButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdBuscar = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioDatoImportar = New System.Windows.Forms.RadioButton()
        Me.RadioDatoPropio = New System.Windows.Forms.RadioButton()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.CmdCrear = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrarMenu = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelar = New FontAwesome.Sharp.IconButton()
        Me.CmdContraerMenu = New FontAwesome.Sharp.IconButton()
        Me.PanelMenuImportar = New System.Windows.Forms.Panel()
        Me.CmdImportarImportar = New FontAwesome.Sharp.IconButton()
        Me.CmdImportarCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdImportarCancelar = New FontAwesome.Sharp.IconButton()
        Me.IconButton5 = New FontAwesome.Sharp.IconButton()
        Me.PanelDetalle = New System.Windows.Forms.Panel()
        Me.IDGRILLA = New System.Windows.Forms.Label()
        Me.DGTabla = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Laboratorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.forma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ver = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelBusca = New System.Windows.Forms.Panel()
        Me.DataUsuarios = New System.Windows.Forms.DataGridView()
        Me.PanelSup.SuspendLayout()
        Me.PanelImportar.SuspendLayout()
        Me.PanelPropios.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        Me.PanelMenuImportar.SuspendLayout()
        Me.PanelDetalle.SuspendLayout()
        CType(Me.DGTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBusca.SuspendLayout()
        CType(Me.DataUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.PanelImportar)
        Me.PanelSup.Controls.Add(Me.PanelPropios)
        Me.PanelSup.Controls.Add(Me.Label1)
        Me.PanelSup.Controls.Add(Me.RadioDatoImportar)
        Me.PanelSup.Controls.Add(Me.RadioDatoPropio)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1143, 158)
        Me.PanelSup.TabIndex = 3
        '
        'PanelImportar
        '
        Me.PanelImportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelImportar.Controls.Add(Me.IconButton1)
        Me.PanelImportar.Controls.Add(Me.Label2)
        Me.PanelImportar.Controls.Add(Me.ComboBox3)
        Me.PanelImportar.Controls.Add(Me.Label5)
        Me.PanelImportar.Controls.Add(Me.IconButton2)
        Me.PanelImportar.Controls.Add(Me.ComboBox4)
        Me.PanelImportar.Location = New System.Drawing.Point(0, 90)
        Me.PanelImportar.Name = "PanelImportar"
        Me.PanelImportar.Size = New System.Drawing.Size(5000, 47)
        Me.PanelImportar.TabIndex = 21
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
        Me.IconButton1.Location = New System.Drawing.Point(9, 9)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(89, 27)
        Me.IconButton1.TabIndex = 7
        Me.IconButton1.Text = "Buscar"
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(454, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "&Mercaderia/Servicio :"
        '
        'ComboBox3
        '
        Me.ComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.ComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.ForeColor = System.Drawing.Color.White
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"BAYER", "DIFARLIB", "GENFAR", "INKAFARMA", "MARKRO", "MEDDDA", "MEDIO FARMA", "PANEDERIA", "PANEL FARMA", "PORTUGAL", "QUIMICA SUIZA"})
        Me.ComboBox3.Location = New System.Drawing.Point(595, 11)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(224, 23)
        Me.ComboBox3.Sorted = True
        Me.ComboBox3.TabIndex = 22
        Me.ComboBox3.Text = "Filtrar..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(104, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "&Tipo de Producto :"
        '
        'IconButton2
        '
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.IconButton2.ForeColor = System.Drawing.Color.White
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.IconButton2.IconColor = System.Drawing.Color.White
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 25
        Me.IconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton2.Location = New System.Drawing.Point(886, 1)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(95, 44)
        Me.IconButton2.TabIndex = 14
        Me.IconButton2.Text = "FILTRAR"
        Me.IconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'ComboBox4
        '
        Me.ComboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.ComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.ForeColor = System.Drawing.Color.White
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"BAYER", "DIFARLIB", "GENFAR", "INKAFARMA", "MARKRO", "MEDDDA", "MEDIO FARMA", "PANEDERIA", "PANEL FARMA", "PORTUGAL", "QUIMICA SUIZA"})
        Me.ComboBox4.Location = New System.Drawing.Point(218, 11)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(230, 23)
        Me.ComboBox4.Sorted = True
        Me.ComboBox4.TabIndex = 16
        Me.ComboBox4.Text = "Filtrar..."
        '
        'PanelPropios
        '
        Me.PanelPropios.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.PanelPropios.Controls.Add(Me.IconButton3)
        Me.PanelPropios.Controls.Add(Me.TextBox2)
        Me.PanelPropios.Controls.Add(Me.TextBox1)
        Me.PanelPropios.Controls.Add(Me.Label4)
        Me.PanelPropios.Controls.Add(Me.ComboBox2)
        Me.PanelPropios.Controls.Add(Me.CmbBuscar)
        Me.PanelPropios.Controls.Add(Me.Label3)
        Me.PanelPropios.Controls.Add(Me.CmdBuscar)
        Me.PanelPropios.Location = New System.Drawing.Point(0, 34)
        Me.PanelPropios.Name = "PanelPropios"
        Me.PanelPropios.Size = New System.Drawing.Size(5000, 47)
        Me.PanelPropios.TabIndex = 6
        '
        'IconButton3
        '
        Me.IconButton3.FlatAppearance.BorderSize = 0
        Me.IconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.White
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton3.IconColor = System.Drawing.Color.White
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 20
        Me.IconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.Location = New System.Drawing.Point(381, 6)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(37, 27)
        Me.IconButton3.TabIndex = 8
        Me.IconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton3.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBox2.Location = New System.Drawing.Point(198, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(187, 18)
        Me.TextBox2.TabIndex = 8
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(563, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "&Mercaderia/Servicio :"
        '
        'ComboBox2
        '
        Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox2.BackColor = System.Drawing.Color.White
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"BAYER", "DIFARLIB", "GENFAR", "INKAFARMA", "MARKRO", "MEDDDA", "MEDIO FARMA", "PANEDERIA", "PANEL FARMA", "PORTUGAL", "QUIMICA SUIZA"})
        Me.ComboBox2.Location = New System.Drawing.Point(1024, 13)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(75, 23)
        Me.ComboBox2.Sorted = True
        Me.ComboBox2.TabIndex = 22
        Me.ComboBox2.Text = "Filtrar..."
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
        Me.CmbBuscar.Location = New System.Drawing.Point(15, 9)
        Me.CmbBuscar.Name = "CmbBuscar"
        Me.CmbBuscar.Size = New System.Drawing.Size(89, 27)
        Me.CmbBuscar.TabIndex = 6
        Me.CmbBuscar.Text = "Buscar"
        Me.CmbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmbBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(110, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "&Laboratorios :"
        '
        'CmdBuscar
        '
        Me.CmdBuscar.FlatAppearance.BorderSize = 0
        Me.CmdBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBuscar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdBuscar.ForeColor = System.Drawing.Color.White
        Me.CmdBuscar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdBuscar.IconColor = System.Drawing.Color.White
        Me.CmdBuscar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdBuscar.IconSize = 25
        Me.CmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscar.Location = New System.Drawing.Point(886, 1)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(95, 44)
        Me.CmdBuscar.TabIndex = 14
        Me.CmdBuscar.Text = "FILTRAR"
        Me.CmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "&Productos/Servicios"
        '
        'RadioDatoImportar
        '
        Me.RadioDatoImportar.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioDatoImportar.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioDatoImportar.FlatAppearance.BorderSize = 0
        Me.RadioDatoImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioDatoImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioDatoImportar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.RadioDatoImportar.Location = New System.Drawing.Point(332, 5)
        Me.RadioDatoImportar.Name = "RadioDatoImportar"
        Me.RadioDatoImportar.Size = New System.Drawing.Size(214, 28)
        Me.RadioDatoImportar.TabIndex = 14
        Me.RadioDatoImportar.Text = "IMPORTAR ORI"
        Me.RadioDatoImportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioDatoImportar.UseVisualStyleBackColor = True
        '
        'RadioDatoPropio
        '
        Me.RadioDatoPropio.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioDatoPropio.Checked = True
        Me.RadioDatoPropio.FlatAppearance.BorderSize = 0
        Me.RadioDatoPropio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioDatoPropio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioDatoPropio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.RadioDatoPropio.Location = New System.Drawing.Point(136, 5)
        Me.RadioDatoPropio.Name = "RadioDatoPropio"
        Me.RadioDatoPropio.Size = New System.Drawing.Size(190, 28)
        Me.RadioDatoPropio.TabIndex = 13
        Me.RadioDatoPropio.TabStop = True
        Me.RadioDatoPropio.Text = "DATOS PROPIOS"
        Me.RadioDatoPropio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioDatoPropio.UseVisualStyleBackColor = True
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(1082, 3)
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
        Me.CmdCerrar.Location = New System.Drawing.Point(1111, 3)
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
        Me.CmdMin.Location = New System.Drawing.Point(1053, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelMenu.Controls.Add(Me.CmdCrear)
        Me.PanelMenu.Controls.Add(Me.CmdCerrarMenu)
        Me.PanelMenu.Controls.Add(Me.CmdCancelar)
        Me.PanelMenu.Controls.Add(Me.CmdContraerMenu)
        Me.PanelMenu.Location = New System.Drawing.Point(1024, 238)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(90, 575)
        Me.PanelMenu.TabIndex = 4
        Me.PanelMenu.Visible = False
        '
        'CmdCrear
        '
        Me.CmdCrear.FlatAppearance.BorderSize = 0
        Me.CmdCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCrear.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdCrear.ForeColor = System.Drawing.Color.White
        Me.CmdCrear.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdCrear.IconColor = System.Drawing.Color.White
        Me.CmdCrear.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCrear.IconSize = 25
        Me.CmdCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCrear.Location = New System.Drawing.Point(0, 34)
        Me.CmdCrear.Name = "CmdCrear"
        Me.CmdCrear.Size = New System.Drawing.Size(95, 45)
        Me.CmdCrear.TabIndex = 13
        Me.CmdCrear.Text = "CREAR"
        Me.CmdCrear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCrear.UseVisualStyleBackColor = True
        '
        'CmdCerrarMenu
        '
        Me.CmdCerrarMenu.FlatAppearance.BorderSize = 0
        Me.CmdCerrarMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCerrarMenu.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdCerrarMenu.ForeColor = System.Drawing.Color.White
        Me.CmdCerrarMenu.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdCerrarMenu.IconColor = System.Drawing.Color.White
        Me.CmdCerrarMenu.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCerrarMenu.IconSize = 25
        Me.CmdCerrarMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrarMenu.Location = New System.Drawing.Point(0, 130)
        Me.CmdCerrarMenu.Name = "CmdCerrarMenu"
        Me.CmdCerrarMenu.Size = New System.Drawing.Size(95, 45)
        Me.CmdCerrarMenu.TabIndex = 7
        Me.CmdCerrarMenu.Text = "CERRAR"
        Me.CmdCerrarMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrarMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCerrarMenu.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.FlatAppearance.BorderSize = 0
        Me.CmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdCancelar.ForeColor = System.Drawing.Color.White
        Me.CmdCancelar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdCancelar.IconColor = System.Drawing.Color.White
        Me.CmdCancelar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelar.IconSize = 25
        Me.CmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelar.Location = New System.Drawing.Point(0, 84)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(95, 45)
        Me.CmdCancelar.TabIndex = 6
        Me.CmdCancelar.Text = "CANCELAR"
        Me.CmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdContraerMenu
        '
        Me.CmdContraerMenu.FlatAppearance.BorderSize = 0
        Me.CmdContraerMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdContraerMenu.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdContraerMenu.ForeColor = System.Drawing.Color.White
        Me.CmdContraerMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowsAltV
        Me.CmdContraerMenu.IconColor = System.Drawing.Color.White
        Me.CmdContraerMenu.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdContraerMenu.IconSize = 25
        Me.CmdContraerMenu.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdContraerMenu.Location = New System.Drawing.Point(0, 3)
        Me.CmdContraerMenu.Name = "CmdContraerMenu"
        Me.CmdContraerMenu.Size = New System.Drawing.Size(114, 19)
        Me.CmdContraerMenu.TabIndex = 5
        Me.CmdContraerMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdContraerMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdContraerMenu.UseVisualStyleBackColor = True
        '
        'PanelMenuImportar
        '
        Me.PanelMenuImportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelMenuImportar.Controls.Add(Me.CmdImportarImportar)
        Me.PanelMenuImportar.Controls.Add(Me.CmdImportarCerrar)
        Me.PanelMenuImportar.Controls.Add(Me.CmdImportarCancelar)
        Me.PanelMenuImportar.Controls.Add(Me.IconButton5)
        Me.PanelMenuImportar.Location = New System.Drawing.Point(917, 238)
        Me.PanelMenuImportar.Name = "PanelMenuImportar"
        Me.PanelMenuImportar.Size = New System.Drawing.Size(90, 575)
        Me.PanelMenuImportar.TabIndex = 5
        Me.PanelMenuImportar.Visible = False
        '
        'CmdImportarImportar
        '
        Me.CmdImportarImportar.FlatAppearance.BorderSize = 0
        Me.CmdImportarImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdImportarImportar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdImportarImportar.ForeColor = System.Drawing.Color.White
        Me.CmdImportarImportar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdImportarImportar.IconColor = System.Drawing.Color.White
        Me.CmdImportarImportar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdImportarImportar.IconSize = 25
        Me.CmdImportarImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImportarImportar.Location = New System.Drawing.Point(0, 38)
        Me.CmdImportarImportar.Name = "CmdImportarImportar"
        Me.CmdImportarImportar.Size = New System.Drawing.Size(95, 45)
        Me.CmdImportarImportar.TabIndex = 13
        Me.CmdImportarImportar.Text = "IMPORTAR"
        Me.CmdImportarImportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImportarImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdImportarImportar.UseVisualStyleBackColor = True
        '
        'CmdImportarCerrar
        '
        Me.CmdImportarCerrar.FlatAppearance.BorderSize = 0
        Me.CmdImportarCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdImportarCerrar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdImportarCerrar.ForeColor = System.Drawing.Color.White
        Me.CmdImportarCerrar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdImportarCerrar.IconColor = System.Drawing.Color.White
        Me.CmdImportarCerrar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdImportarCerrar.IconSize = 25
        Me.CmdImportarCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImportarCerrar.Location = New System.Drawing.Point(0, 134)
        Me.CmdImportarCerrar.Name = "CmdImportarCerrar"
        Me.CmdImportarCerrar.Size = New System.Drawing.Size(95, 45)
        Me.CmdImportarCerrar.TabIndex = 7
        Me.CmdImportarCerrar.Text = "CERRAR"
        Me.CmdImportarCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImportarCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdImportarCerrar.UseVisualStyleBackColor = True
        '
        'CmdImportarCancelar
        '
        Me.CmdImportarCancelar.FlatAppearance.BorderSize = 0
        Me.CmdImportarCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdImportarCancelar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdImportarCancelar.ForeColor = System.Drawing.Color.White
        Me.CmdImportarCancelar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdImportarCancelar.IconColor = System.Drawing.Color.White
        Me.CmdImportarCancelar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdImportarCancelar.IconSize = 25
        Me.CmdImportarCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImportarCancelar.Location = New System.Drawing.Point(0, 88)
        Me.CmdImportarCancelar.Name = "CmdImportarCancelar"
        Me.CmdImportarCancelar.Size = New System.Drawing.Size(95, 45)
        Me.CmdImportarCancelar.TabIndex = 6
        Me.CmdImportarCancelar.Text = "CANCELAR"
        Me.CmdImportarCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImportarCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdImportarCancelar.UseVisualStyleBackColor = True
        '
        'IconButton5
        '
        Me.IconButton5.FlatAppearance.BorderSize = 0
        Me.IconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.IconButton5.ForeColor = System.Drawing.Color.White
        Me.IconButton5.IconChar = FontAwesome.Sharp.IconChar.ArrowsAltV
        Me.IconButton5.IconColor = System.Drawing.Color.White
        Me.IconButton5.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton5.IconSize = 25
        Me.IconButton5.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton5.Location = New System.Drawing.Point(0, 3)
        Me.IconButton5.Name = "IconButton5"
        Me.IconButton5.Size = New System.Drawing.Size(114, 19)
        Me.IconButton5.TabIndex = 5
        Me.IconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton5.UseVisualStyleBackColor = True
        '
        'PanelDetalle
        '
        Me.PanelDetalle.BackColor = System.Drawing.Color.Khaki
        Me.PanelDetalle.Controls.Add(Me.IDGRILLA)
        Me.PanelDetalle.Controls.Add(Me.DGTabla)
        Me.PanelDetalle.Location = New System.Drawing.Point(37, 180)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(615, 424)
        Me.PanelDetalle.TabIndex = 6
        '
        'IDGRILLA
        '
        Me.IDGRILLA.AutoSize = True
        Me.IDGRILLA.Location = New System.Drawing.Point(685, 56)
        Me.IDGRILLA.Name = "IDGRILLA"
        Me.IDGRILLA.Size = New System.Drawing.Size(13, 13)
        Me.IDGRILLA.TabIndex = 3
        Me.IDGRILLA.Text = "0"
        '
        'DGTabla
        '
        Me.DGTabla.AllowUserToAddRows = False
        Me.DGTabla.AllowUserToDeleteRows = False
        Me.DGTabla.AllowUserToResizeRows = False
        Me.DGTabla.BackgroundColor = System.Drawing.Color.White
        Me.DGTabla.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGTabla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGTabla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre, Me.Laboratorio, Me.forma, Me.Column1, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Ver})
        Me.DGTabla.GridColor = System.Drawing.Color.White
        Me.DGTabla.Location = New System.Drawing.Point(32, 36)
        Me.DGTabla.Name = "DGTabla"
        Me.DGTabla.ReadOnly = True
        Me.DGTabla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGTabla.RowHeadersVisible = False
        Me.DGTabla.RowTemplate.Height = 25
        Me.DGTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGTabla.Size = New System.Drawing.Size(550, 340)
        Me.DGTabla.TabIndex = 2
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 80
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 300
        '
        'Laboratorio
        '
        Me.Laboratorio.HeaderText = "Laboratorio"
        Me.Laboratorio.Name = "Laboratorio"
        Me.Laboratorio.ReadOnly = True
        '
        'forma
        '
        Me.forma.HeaderText = "Forma"
        Me.forma.Name = "forma"
        Me.forma.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Column7"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Ver
        '
        Me.Ver.HeaderText = "Ver"
        Me.Ver.Image = Global.WindowsApp1.My.Resources.Resources.ver
        Me.Ver.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Ver.Name = "Ver"
        Me.Ver.ReadOnly = True
        Me.Ver.Width = 40
        '
        'PanelBusca
        '
        Me.PanelBusca.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelBusca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelBusca.Controls.Add(Me.DataUsuarios)
        Me.PanelBusca.Location = New System.Drawing.Point(668, 180)
        Me.PanelBusca.Name = "PanelBusca"
        Me.PanelBusca.Size = New System.Drawing.Size(614, 305)
        Me.PanelBusca.TabIndex = 7
        '
        'DataUsuarios
        '
        Me.DataUsuarios.AllowUserToAddRows = False
        Me.DataUsuarios.AllowUserToDeleteRows = False
        Me.DataUsuarios.AllowUserToResizeRows = False
        Me.DataUsuarios.BackgroundColor = System.Drawing.Color.White
        Me.DataUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataUsuarios.GridColor = System.Drawing.Color.White
        Me.DataUsuarios.Location = New System.Drawing.Point(0, 0)
        Me.DataUsuarios.Name = "DataUsuarios"
        Me.DataUsuarios.ReadOnly = True
        Me.DataUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataUsuarios.RowHeadersVisible = False
        Me.DataUsuarios.RowTemplate.Height = 25
        Me.DataUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataUsuarios.Size = New System.Drawing.Size(610, 301)
        Me.DataUsuarios.TabIndex = 8
        '
        'FrmMenuProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1143, 660)
        Me.Controls.Add(Me.PanelBusca)
        Me.Controls.Add(Me.PanelDetalle)
        Me.Controls.Add(Me.PanelMenuImportar)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "FrmMenuProductos"
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.PanelImportar.ResumeLayout(False)
        Me.PanelImportar.PerformLayout()
        Me.PanelPropios.ResumeLayout(False)
        Me.PanelPropios.PerformLayout()
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelMenuImportar.ResumeLayout(False)
        Me.PanelDetalle.ResumeLayout(False)
        Me.PanelDetalle.PerformLayout()
        CType(Me.DGTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBusca.ResumeLayout(False)
        CType(Me.DataUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents CmbBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents RadioDatoImportar As RadioButton
    Friend WithEvents RadioDatoPropio As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents CmdCrear As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrarMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdContraerMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelMenuImportar As Panel
    Friend WithEvents CmdImportarImportar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdImportarCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdImportarCancelar As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton5 As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelPropios As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelImportar As Panel
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents DGTabla As DataGridView
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Laboratorio As DataGridViewTextBoxColumn
    Friend WithEvents forma As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Ver As DataGridViewImageColumn
    Public WithEvents PanelDetalle As Panel
    Public WithEvents IDGRILLA As Label
    Friend WithEvents PanelBusca As Panel
    Friend WithEvents DataUsuarios As DataGridView
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
