<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPorDefectoNegocio
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGNegocios = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ver = New System.Windows.Forms.DataGridViewImageColumn()
        Me.idnegocio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EsMiNegocio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razonsocial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdAddLocal = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelaLocales = New FontAwesome.Sharp.IconButton()
        Me.LblNegocio = New System.Windows.Forms.Label()
        Me.LblLocal = New System.Windows.Forms.Label()
        Me.LblAlmacen = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.DGAlmacenes = New System.Windows.Forms.DataGridView()
        Me.DGLocales = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idpos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGNegocios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSup.SuspendLayout()
        CType(Me.DGAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGLocales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGNegocios
        '
        Me.DGNegocios.AllowUserToAddRows = False
        Me.DGNegocios.AllowUserToDeleteRows = False
        Me.DGNegocios.AllowUserToResizeRows = False
        Me.DGNegocios.BackgroundColor = System.Drawing.Color.White
        Me.DGNegocios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGNegocios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGNegocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGNegocios.ColumnHeadersVisible = False
        Me.DGNegocios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Ver, Me.idnegocio, Me.EsMiNegocio, Me.razonsocial, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.DGNegocios.GridColor = System.Drawing.Color.White
        Me.DGNegocios.Location = New System.Drawing.Point(10, 38)
        Me.DGNegocios.Name = "DGNegocios"
        Me.DGNegocios.ReadOnly = True
        Me.DGNegocios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGNegocios.RowHeadersVisible = False
        Me.DGNegocios.RowTemplate.Height = 25
        Me.DGNegocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGNegocios.Size = New System.Drawing.Size(326, 132)
        Me.DGNegocios.TabIndex = 4
        '
        'Codigo
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Codigo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Codigo.HeaderText = "Negocio"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 5
        '
        'Ver
        '
        Me.Ver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Ver.HeaderText = "Ver"
        Me.Ver.Image = Global.WindowsApp1.My.Resources.Resources.ver
        Me.Ver.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Ver.Name = "Ver"
        Me.Ver.ReadOnly = True
        Me.Ver.Width = 5
        '
        'idnegocio
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.idnegocio.DefaultCellStyle = DataGridViewCellStyle2
        Me.idnegocio.HeaderText = "idnegocio"
        Me.idnegocio.Name = "idnegocio"
        Me.idnegocio.ReadOnly = True
        Me.idnegocio.Visible = False
        '
        'EsMiNegocio
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.EsMiNegocio.DefaultCellStyle = DataGridViewCellStyle3
        Me.EsMiNegocio.HeaderText = "Negocio"
        Me.EsMiNegocio.Name = "EsMiNegocio"
        Me.EsMiNegocio.ReadOnly = True
        '
        'razonsocial
        '
        Me.razonsocial.HeaderText = "razonsocial"
        Me.razonsocial.Name = "razonsocial"
        Me.razonsocial.ReadOnly = True
        Me.razonsocial.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
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
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.Label41)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1028, 32)
        Me.PanelSup.TabIndex = 7
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(13, 5)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(338, 21)
        Me.Label41.TabIndex = 159
        Me.Label41.Text = "Define el Negocio, Local y Almacen por defecto."
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
        Me.CmdCerrar.Location = New System.Drawing.Point(988, 0)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(35, 26)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdAddLocal
        '
        Me.CmdAddLocal.FlatAppearance.BorderSize = 0
        Me.CmdAddLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAddLocal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAddLocal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAddLocal.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdAddLocal.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAddLocal.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAddLocal.IconSize = 25
        Me.CmdAddLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAddLocal.Location = New System.Drawing.Point(567, 268)
        Me.CmdAddLocal.Name = "CmdAddLocal"
        Me.CmdAddLocal.Size = New System.Drawing.Size(164, 27)
        Me.CmdAddLocal.TabIndex = 128
        Me.CmdAddLocal.Text = "&Asignar por Defecto"
        Me.CmdAddLocal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAddLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAddLocal.UseVisualStyleBackColor = True
        '
        'CmdCancelaLocales
        '
        Me.CmdCancelaLocales.FlatAppearance.BorderSize = 0
        Me.CmdCancelaLocales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelaLocales.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelaLocales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelaLocales.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.CmdCancelaLocales.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelaLocales.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelaLocales.IconSize = 25
        Me.CmdCancelaLocales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelaLocales.Location = New System.Drawing.Point(301, 268)
        Me.CmdCancelaLocales.Name = "CmdCancelaLocales"
        Me.CmdCancelaLocales.Size = New System.Drawing.Size(110, 27)
        Me.CmdCancelaLocales.TabIndex = 127
        Me.CmdCancelaLocales.Text = "&Cancelar"
        Me.CmdCancelaLocales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelaLocales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancelaLocales.UseVisualStyleBackColor = True
        '
        'LblNegocio
        '
        Me.LblNegocio.BackColor = System.Drawing.Color.Transparent
        Me.LblNegocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNegocio.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNegocio.ForeColor = System.Drawing.Color.Gray
        Me.LblNegocio.Location = New System.Drawing.Point(10, 178)
        Me.LblNegocio.Name = "LblNegocio"
        Me.LblNegocio.Size = New System.Drawing.Size(326, 55)
        Me.LblNegocio.TabIndex = 160
        Me.LblNegocio.Text = "AHORRO FARMA S.A."
        '
        'LblLocal
        '
        Me.LblLocal.BackColor = System.Drawing.Color.Transparent
        Me.LblLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblLocal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLocal.ForeColor = System.Drawing.Color.Gray
        Me.LblLocal.Location = New System.Drawing.Point(342, 178)
        Me.LblLocal.Name = "LblLocal"
        Me.LblLocal.Size = New System.Drawing.Size(326, 55)
        Me.LblLocal.TabIndex = 161
        Me.LblLocal.Text = "AHORRO FARMA S.A."
        '
        'LblAlmacen
        '
        Me.LblAlmacen.BackColor = System.Drawing.Color.Transparent
        Me.LblAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAlmacen.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlmacen.ForeColor = System.Drawing.Color.Gray
        Me.LblAlmacen.Location = New System.Drawing.Point(674, 178)
        Me.LblAlmacen.Name = "LblAlmacen"
        Me.LblAlmacen.Size = New System.Drawing.Size(326, 55)
        Me.LblAlmacen.TabIndex = 162
        Me.LblAlmacen.Text = "AHORRO FARMA S.A."
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(361, 236)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(184, 19)
        Me.CheckBox1.TabIndex = 163
        Me.CheckBox1.Text = "&Escoger Manualmente Local"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CheckBox2.Location = New System.Drawing.Point(688, 236)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(202, 19)
        Me.CheckBox2.TabIndex = 164
        Me.CheckBox2.Text = "&Escoger Manualmente Almacen"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'DGAlmacenes
        '
        Me.DGAlmacenes.AllowUserToAddRows = False
        Me.DGAlmacenes.AllowUserToDeleteRows = False
        Me.DGAlmacenes.AllowUserToResizeRows = False
        Me.DGAlmacenes.BackgroundColor = System.Drawing.Color.White
        Me.DGAlmacenes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGAlmacenes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGAlmacenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGAlmacenes.ColumnHeadersVisible = False
        Me.DGAlmacenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewImageColumn2, Me.DataGridViewTextBoxColumn4, Me.razons, Me.idpos})
        Me.DGAlmacenes.GridColor = System.Drawing.Color.White
        Me.DGAlmacenes.Location = New System.Drawing.Point(674, 38)
        Me.DGAlmacenes.Name = "DGAlmacenes"
        Me.DGAlmacenes.ReadOnly = True
        Me.DGAlmacenes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGAlmacenes.RowHeadersVisible = False
        Me.DGAlmacenes.RowTemplate.Height = 25
        Me.DGAlmacenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGAlmacenes.Size = New System.Drawing.Size(326, 132)
        Me.DGAlmacenes.TabIndex = 166
        '
        'DGLocales
        '
        Me.DGLocales.AllowUserToAddRows = False
        Me.DGLocales.AllowUserToDeleteRows = False
        Me.DGLocales.AllowUserToResizeRows = False
        Me.DGLocales.BackgroundColor = System.Drawing.Color.White
        Me.DGLocales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGLocales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGLocales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGLocales.ColumnHeadersVisible = False
        Me.DGLocales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn3, Me.index, Me.nombre})
        Me.DGLocales.GridColor = System.Drawing.Color.White
        Me.DGLocales.Location = New System.Drawing.Point(342, 38)
        Me.DGLocales.Name = "DGLocales"
        Me.DGLocales.ReadOnly = True
        Me.DGLocales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGLocales.RowHeadersVisible = False
        Me.DGLocales.RowTemplate.Height = 25
        Me.DGLocales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGLocales.Size = New System.Drawing.Size(326, 132)
        Me.DGLocales.TabIndex = 165
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn1.HeaderText = "Negocio"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn1.HeaderText = "Ver"
        Me.DataGridViewImageColumn1.Image = Global.WindowsApp1.My.Resources.Resources.ver
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn3.HeaderText = "idnegocio"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'index
        '
        Me.index.HeaderText = "index"
        Me.index.Name = "index"
        Me.index.ReadOnly = True
        Me.index.Visible = False
        '
        'nombre
        '
        Me.nombre.HeaderText = "nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "Negocio"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 5
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn2.HeaderText = "Ver"
        Me.DataGridViewImageColumn2.Image = Global.WindowsApp1.My.Resources.Resources.ver
        Me.DataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Width = 5
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn4.HeaderText = "idnegocio"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'razons
        '
        Me.razons.HeaderText = "razons"
        Me.razons.Name = "razons"
        Me.razons.ReadOnly = True
        Me.razons.Visible = False
        '
        'idpos
        '
        Me.idpos.HeaderText = "idpos"
        Me.idpos.Name = "idpos"
        Me.idpos.ReadOnly = True
        Me.idpos.Visible = False
        '
        'FrmPorDefectoNegocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1028, 346)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGAlmacenes)
        Me.Controls.Add(Me.DGLocales)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LblAlmacen)
        Me.Controls.Add(Me.LblLocal)
        Me.Controls.Add(Me.LblNegocio)
        Me.Controls.Add(Me.CmdAddLocal)
        Me.Controls.Add(Me.CmdCancelaLocales)
        Me.Controls.Add(Me.PanelSup)
        Me.Controls.Add(Me.DGNegocios)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPorDefectoNegocio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DGNegocios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        CType(Me.DGAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGLocales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGNegocios As DataGridView
    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAddLocal As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelaLocales As FontAwesome.Sharp.IconButton
    Friend WithEvents Label41 As Label
    Friend WithEvents LblNegocio As Label
    Friend WithEvents LblLocal As Label
    Friend WithEvents LblAlmacen As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents DGAlmacenes As DataGridView
    Friend WithEvents DGLocales As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents index As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Ver As DataGridViewImageColumn
    Friend WithEvents idnegocio As DataGridViewTextBoxColumn
    Friend WithEvents EsMiNegocio As DataGridViewTextBoxColumn
    Friend WithEvents razonsocial As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents razons As DataGridViewTextBoxColumn
    Friend WithEvents idpos As DataGridViewTextBoxColumn
End Class
