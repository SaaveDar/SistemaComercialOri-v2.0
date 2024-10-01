<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmControlCajas
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlCajas))
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.id_opcion = New System.Windows.Forms.Label()
        Me.CmdValida = New FontAwesome.Sharp.IconButton()
        Me.CmdListaApe = New FontAwesome.Sharp.IconButton()
        Me.CmdRegistros = New FontAwesome.Sharp.IconButton()
        Me.CmdCierre = New FontAwesome.Sharp.IconButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdCajas = New FontAwesome.Sharp.IconButton()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CmdMonedaComp = New FontAwesome.Sharp.IconButton()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.dg_monedas = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelApertura = New System.Windows.Forms.Panel()
        Me.lfechahora_aper = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtMonto_aper = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmdGrabar_aper = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelar_aper = New FontAwesome.Sharp.IconButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_ref_aper = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtRef_cierre = New System.Windows.Forms.TextBox()
        Me.TxtFecha_cierre = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelCierre = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.opRM = New System.Windows.Forms.RadioButton()
        Me.opRS = New System.Windows.Forms.RadioButton()
        Me.dg_otras = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.CheConfirmaCierre_otros = New System.Windows.Forms.CheckBox()
        Me.CheConfirmaCierre = New System.Windows.Forms.CheckBox()
        Me.ChekReconteo = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_refapertura_cierre = New System.Windows.Forms.TextBox()
        Me.Lbl_totalefectivo_cierre = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Lbl_apertura_cierre = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_reconteo_cierre = New System.Windows.Forms.TextBox()
        Me.txt_usuario_cierre = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dg_efectivo = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdGrabar_cierre = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelar_cierre = New FontAwesome.Sharp.IconButton()
        Me.txt_fal_cierre = New System.Windows.Forms.Label()
        Me.txt_sob_cierre = New System.Windows.Forms.Label()
        Me.Lbl_entregaconteo_cierre = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.OpDirecto = New System.Windows.Forms.RadioButton()
        Me.OpDesglose = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelRegistros = New System.Windows.Forms.Panel()
        Me.dg_registros = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel_piereg = New System.Windows.Forms.Panel()
        Me.Panel_cabreg = New System.Windows.Forms.Panel()
        Me.PanelPrincipal = New System.Windows.Forms.Panel()
        Me.FaltaDatos = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdFormato = New FontAwesome.Sharp.IconButton()
        Me.PanelSup.SuspendLayout()
        CType(Me.dg_monedas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelApertura.SuspendLayout()
        Me.PanelCierre.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dg_otras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_efectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRegistros.SuspendLayout()
        CType(Me.dg_registros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPrincipal.SuspendLayout()
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Gray
        Me.PanelSup.Controls.Add(Me.id_opcion)
        Me.PanelSup.Controls.Add(Me.CmdValida)
        Me.PanelSup.Controls.Add(Me.CmdListaApe)
        Me.PanelSup.Controls.Add(Me.CmdRegistros)
        Me.PanelSup.Controls.Add(Me.CmdCierre)
        Me.PanelSup.Controls.Add(Me.Label3)
        Me.PanelSup.Controls.Add(Me.Label2)
        Me.PanelSup.Controls.Add(Me.CmdCajas)
        Me.PanelSup.Controls.Add(Me.Label23)
        Me.PanelSup.Controls.Add(Me.CmdMonedaComp)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1229, 66)
        Me.PanelSup.TabIndex = 3
        '
        'id_opcion
        '
        Me.id_opcion.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.id_opcion.ForeColor = System.Drawing.Color.White
        Me.id_opcion.Location = New System.Drawing.Point(781, 39)
        Me.id_opcion.Name = "id_opcion"
        Me.id_opcion.Size = New System.Drawing.Size(86, 16)
        Me.id_opcion.TabIndex = 114
        Me.id_opcion.Text = "id_opcion"
        '
        'CmdValida
        '
        Me.CmdValida.FlatAppearance.BorderSize = 0
        Me.CmdValida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdValida.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdValida.ForeColor = System.Drawing.Color.White
        Me.CmdValida.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmdValida.IconColor = System.Drawing.Color.White
        Me.CmdValida.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdValida.IconSize = 20
        Me.CmdValida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdValida.Location = New System.Drawing.Point(623, 30)
        Me.CmdValida.Name = "CmdValida"
        Me.CmdValida.Size = New System.Drawing.Size(113, 31)
        Me.CmdValida.TabIndex = 60
        Me.CmdValida.Text = "&VALIDAR"
        Me.CmdValida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdValida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdValida.UseVisualStyleBackColor = True
        '
        'CmdListaApe
        '
        Me.CmdListaApe.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdListaApe.FlatAppearance.BorderSize = 0
        Me.CmdListaApe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdListaApe.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdListaApe.ForeColor = System.Drawing.Color.White
        Me.CmdListaApe.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdListaApe.IconColor = System.Drawing.Color.White
        Me.CmdListaApe.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdListaApe.IconSize = 25
        Me.CmdListaApe.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdListaApe.Location = New System.Drawing.Point(100, 35)
        Me.CmdListaApe.Name = "CmdListaApe"
        Me.CmdListaApe.Size = New System.Drawing.Size(265, 26)
        Me.CmdListaApe.TabIndex = 59
        Me.CmdListaApe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdListaApe.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdListaApe.UseVisualStyleBackColor = False
        '
        'CmdRegistros
        '
        Me.CmdRegistros.FlatAppearance.BorderSize = 0
        Me.CmdRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdRegistros.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdRegistros.ForeColor = System.Drawing.Color.White
        Me.CmdRegistros.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdRegistros.IconColor = System.Drawing.Color.White
        Me.CmdRegistros.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdRegistros.IconSize = 20
        Me.CmdRegistros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRegistros.Location = New System.Drawing.Point(399, 31)
        Me.CmdRegistros.Name = "CmdRegistros"
        Me.CmdRegistros.Size = New System.Drawing.Size(113, 31)
        Me.CmdRegistros.TabIndex = 58
        Me.CmdRegistros.Text = "&REGISTROS"
        Me.CmdRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRegistros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdRegistros.UseVisualStyleBackColor = True
        '
        'CmdCierre
        '
        Me.CmdCierre.FlatAppearance.BorderSize = 0
        Me.CmdCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCierre.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCierre.ForeColor = System.Drawing.Color.White
        Me.CmdCierre.IconChar = FontAwesome.Sharp.IconChar.Cube
        Me.CmdCierre.IconColor = System.Drawing.Color.White
        Me.CmdCierre.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCierre.IconSize = 20
        Me.CmdCierre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCierre.Location = New System.Drawing.Point(527, 31)
        Me.CmdCierre.Name = "CmdCierre"
        Me.CmdCierre.Size = New System.Drawing.Size(113, 31)
        Me.CmdCierre.TabIndex = 41
        Me.CmdCierre.Text = "&CIERRE"
        Me.CmdCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCierre.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 27)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "LISTAS DE APERTURAS "
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 27)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "CAJAS DISPONIBLES"
        '
        'CmdCajas
        '
        Me.CmdCajas.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdCajas.FlatAppearance.BorderSize = 0
        Me.CmdCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCajas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCajas.ForeColor = System.Drawing.Color.White
        Me.CmdCajas.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdCajas.IconColor = System.Drawing.Color.White
        Me.CmdCajas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCajas.IconSize = 25
        Me.CmdCajas.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdCajas.Location = New System.Drawing.Point(100, 4)
        Me.CmdCajas.Name = "CmdCajas"
        Me.CmdCajas.Size = New System.Drawing.Size(265, 26)
        Me.CmdCajas.TabIndex = 36
        Me.CmdCajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCajas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdCajas.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(391, 2)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 27)
        Me.Label23.TabIndex = 34
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
        Me.CmdMonedaComp.Location = New System.Drawing.Point(483, 3)
        Me.CmdMonedaComp.Name = "CmdMonedaComp"
        Me.CmdMonedaComp.Size = New System.Drawing.Size(146, 26)
        Me.CmdMonedaComp.TabIndex = 35
        Me.CmdMonedaComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMonedaComp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMonedaComp.UseVisualStyleBackColor = False
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(1168, 3)
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
        Me.CmdCerrar.Location = New System.Drawing.Point(1197, 3)
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
        Me.CmdMin.Location = New System.Drawing.Point(1139, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'dg_monedas
        '
        Me.dg_monedas.AllowUserToAddRows = False
        Me.dg_monedas.AllowUserToDeleteRows = False
        Me.dg_monedas.AllowUserToResizeRows = False
        Me.dg_monedas.BackgroundColor = System.Drawing.Color.White
        Me.dg_monedas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_monedas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_monedas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_monedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_monedas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_monedas.DefaultCellStyle = DataGridViewCellStyle1
        Me.dg_monedas.GridColor = System.Drawing.Color.White
        Me.dg_monedas.Location = New System.Drawing.Point(11, 177)
        Me.dg_monedas.MultiSelect = False
        Me.dg_monedas.Name = "dg_monedas"
        Me.dg_monedas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_monedas.RowHeadersVisible = False
        Me.dg_monedas.RowTemplate.Height = 25
        Me.dg_monedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_monedas.Size = New System.Drawing.Size(330, 228)
        Me.dg_monedas.TabIndex = 4
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "dg_monedas"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 80
        '
        'PanelApertura
        '
        Me.PanelApertura.Controls.Add(Me.lfechahora_aper)
        Me.PanelApertura.Controls.Add(Me.Label13)
        Me.PanelApertura.Controls.Add(Me.TxtMonto_aper)
        Me.PanelApertura.Controls.Add(Me.Label8)
        Me.PanelApertura.Controls.Add(Me.CmdGrabar_aper)
        Me.PanelApertura.Controls.Add(Me.CmdCancelar_aper)
        Me.PanelApertura.Controls.Add(Me.Label6)
        Me.PanelApertura.Controls.Add(Me.Label4)
        Me.PanelApertura.Controls.Add(Me.Txt_ref_aper)
        Me.PanelApertura.Location = New System.Drawing.Point(904, 14)
        Me.PanelApertura.Name = "PanelApertura"
        Me.PanelApertura.Size = New System.Drawing.Size(299, 354)
        Me.PanelApertura.TabIndex = 5
        Me.PanelApertura.Visible = False
        '
        'lfechahora_aper
        '
        Me.lfechahora_aper.BackColor = System.Drawing.Color.White
        Me.lfechahora_aper.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lfechahora_aper.ForeColor = System.Drawing.Color.Black
        Me.lfechahora_aper.Location = New System.Drawing.Point(221, 54)
        Me.lfechahora_aper.Name = "lfechahora_aper"
        Me.lfechahora_aper.Size = New System.Drawing.Size(119, 23)
        Me.lfechahora_aper.TabIndex = 101
        Me.lfechahora_aper.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(139, 94)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 14)
        Me.Label13.TabIndex = 102
        Me.Label13.Text = "MONTO:"
        '
        'TxtMonto_aper
        '
        Me.TxtMonto_aper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMonto_aper.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto_aper.Location = New System.Drawing.Point(224, 94)
        Me.TxtMonto_aper.MaxLength = 0
        Me.TxtMonto_aper.Name = "TxtMonto_aper"
        Me.TxtMonto_aper.Size = New System.Drawing.Size(115, 22)
        Me.TxtMonto_aper.TabIndex = 102
        Me.TxtMonto_aper.Text = "0"
        Me.TxtMonto_aper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(278, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 27)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "APERTURA:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmdGrabar_aper
        '
        Me.CmdGrabar_aper.FlatAppearance.BorderSize = 0
        Me.CmdGrabar_aper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar_aper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar_aper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar_aper.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdGrabar_aper.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar_aper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrabar_aper.IconSize = 25
        Me.CmdGrabar_aper.Location = New System.Drawing.Point(230, 349)
        Me.CmdGrabar_aper.Name = "CmdGrabar_aper"
        Me.CmdGrabar_aper.Size = New System.Drawing.Size(87, 45)
        Me.CmdGrabar_aper.TabIndex = 104
        Me.CmdGrabar_aper.Text = "&ACEPTAR"
        Me.CmdGrabar_aper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdGrabar_aper.UseVisualStyleBackColor = True
        '
        'CmdCancelar_aper
        '
        Me.CmdCancelar_aper.FlatAppearance.BorderSize = 0
        Me.CmdCancelar_aper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelar_aper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelar_aper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelar_aper.IconChar = FontAwesome.Sharp.IconChar.Eraser
        Me.CmdCancelar_aper.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelar_aper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelar_aper.IconSize = 25
        Me.CmdCancelar_aper.Location = New System.Drawing.Point(375, 349)
        Me.CmdCancelar_aper.Name = "CmdCancelar_aper"
        Me.CmdCancelar_aper.Size = New System.Drawing.Size(87, 45)
        Me.CmdCancelar_aper.TabIndex = 105
        Me.CmdCancelar_aper.Text = "CANCELAR"
        Me.CmdCancelar_aper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdCancelar_aper.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(139, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "FECHA :"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(139, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 17)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "COMENTARIOS :"
        '
        'Txt_ref_aper
        '
        Me.Txt_ref_aper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_ref_aper.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ref_aper.Location = New System.Drawing.Point(142, 163)
        Me.Txt_ref_aper.MaxLength = 200
        Me.Txt_ref_aper.Multiline = True
        Me.Txt_ref_aper.Name = "Txt_ref_aper"
        Me.Txt_ref_aper.Size = New System.Drawing.Size(298, 102)
        Me.Txt_ref_aper.TabIndex = 103
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(570, 439)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 17)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "COMENTARIOS :"
        '
        'txtRef_cierre
        '
        Me.txtRef_cierre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRef_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRef_cierre.Location = New System.Drawing.Point(568, 459)
        Me.txtRef_cierre.MaxLength = 200
        Me.txtRef_cierre.Multiline = True
        Me.txtRef_cierre.Name = "txtRef_cierre"
        Me.txtRef_cierre.Size = New System.Drawing.Size(417, 42)
        Me.txtRef_cierre.TabIndex = 81
        '
        'TxtFecha_cierre
        '
        Me.TxtFecha_cierre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFecha_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha_cierre.Location = New System.Drawing.Point(188, 57)
        Me.TxtFecha_cierre.MaxLength = 0
        Me.TxtFecha_cierre.Name = "TxtFecha_cierre"
        Me.TxtFecha_cierre.Size = New System.Drawing.Size(153, 16)
        Me.TxtFecha_cierre.TabIndex = 92
        Me.TxtFecha_cierre.Text = "01/01/2025"
        Me.TxtFecha_cierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(10, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 16)
        Me.Label12.TabIndex = 91
        Me.Label12.Text = "FECHA :"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 27)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "INICIAR CIERRE CAJA "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelCierre
        '
        Me.PanelCierre.Controls.Add(Me.cmdFormato)
        Me.PanelCierre.Controls.Add(Me.Panel1)
        Me.PanelCierre.Controls.Add(Me.CheConfirmaCierre_otros)
        Me.PanelCierre.Controls.Add(Me.CheConfirmaCierre)
        Me.PanelCierre.Controls.Add(Me.ChekReconteo)
        Me.PanelCierre.Controls.Add(Me.Label14)
        Me.PanelCierre.Controls.Add(Me.txt_refapertura_cierre)
        Me.PanelCierre.Controls.Add(Me.Lbl_totalefectivo_cierre)
        Me.PanelCierre.Controls.Add(Me.Label18)
        Me.PanelCierre.Controls.Add(Me.Lbl_apertura_cierre)
        Me.PanelCierre.Controls.Add(Me.Label27)
        Me.PanelCierre.Controls.Add(Me.Label24)
        Me.PanelCierre.Controls.Add(Me.txt_reconteo_cierre)
        Me.PanelCierre.Controls.Add(Me.txt_usuario_cierre)
        Me.PanelCierre.Controls.Add(Me.Label22)
        Me.PanelCierre.Controls.Add(Me.dg_efectivo)
        Me.PanelCierre.Controls.Add(Me.CmdGrabar_cierre)
        Me.PanelCierre.Controls.Add(Me.CmdCancelar_cierre)
        Me.PanelCierre.Controls.Add(Me.txt_fal_cierre)
        Me.PanelCierre.Controls.Add(Me.txt_sob_cierre)
        Me.PanelCierre.Controls.Add(Me.Lbl_entregaconteo_cierre)
        Me.PanelCierre.Controls.Add(Me.Label16)
        Me.PanelCierre.Controls.Add(Me.Label11)
        Me.PanelCierre.Controls.Add(Me.TxtFecha_cierre)
        Me.PanelCierre.Controls.Add(Me.Label15)
        Me.PanelCierre.Controls.Add(Me.Label12)
        Me.PanelCierre.Controls.Add(Me.Label10)
        Me.PanelCierre.Controls.Add(Me.Label1)
        Me.PanelCierre.Controls.Add(Me.txtRef_cierre)
        Me.PanelCierre.Controls.Add(Me.Label7)
        Me.PanelCierre.Controls.Add(Me.Label9)
        Me.PanelCierre.Controls.Add(Me.TxtMonto)
        Me.PanelCierre.Controls.Add(Me.OpDirecto)
        Me.PanelCierre.Controls.Add(Me.OpDesglose)
        Me.PanelCierre.Controls.Add(Me.Label5)
        Me.PanelCierre.Controls.Add(Me.dg_monedas)
        Me.PanelCierre.Location = New System.Drawing.Point(3, 3)
        Me.PanelCierre.Name = "PanelCierre"
        Me.PanelCierre.Size = New System.Drawing.Size(895, 570)
        Me.PanelCierre.TabIndex = 89
        Me.PanelCierre.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.opRM)
        Me.Panel1.Controls.Add(Me.opRS)
        Me.Panel1.Controls.Add(Me.dg_otras)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Location = New System.Drawing.Point(644, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 391)
        Me.Panel1.TabIndex = 130
        '
        'opRM
        '
        Me.opRM.AutoSize = True
        Me.opRM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.opRM.Checked = True
        Me.opRM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.opRM.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opRM.Location = New System.Drawing.Point(20, 29)
        Me.opRM.Name = "opRM"
        Me.opRM.Size = New System.Drawing.Size(148, 17)
        Me.opRM.TabIndex = 122
        Me.opRM.TabStop = True
        Me.opRM.Text = "RESUMEN POR METODO"
        Me.opRM.UseVisualStyleBackColor = True
        '
        'opRS
        '
        Me.opRS.AutoSize = True
        Me.opRS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.opRS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.opRS.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opRS.Location = New System.Drawing.Point(200, 29)
        Me.opRS.Name = "opRS"
        Me.opRS.Size = New System.Drawing.Size(141, 17)
        Me.opRS.TabIndex = 123
        Me.opRS.Text = "RESUMEN POR SIGNOS"
        Me.opRS.UseVisualStyleBackColor = True
        '
        'dg_otras
        '
        Me.dg_otras.AllowUserToAddRows = False
        Me.dg_otras.AllowUserToDeleteRows = False
        Me.dg_otras.AllowUserToResizeRows = False
        Me.dg_otras.BackgroundColor = System.Drawing.Color.White
        Me.dg_otras.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_otras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_otras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_otras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_otras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_otras.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_otras.GridColor = System.Drawing.Color.White
        Me.dg_otras.Location = New System.Drawing.Point(20, 52)
        Me.dg_otras.MultiSelect = False
        Me.dg_otras.Name = "dg_otras"
        Me.dg_otras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_otras.RowHeadersVisible = False
        Me.dg_otras.RowTemplate.Height = 25
        Me.dg_otras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_otras.Size = New System.Drawing.Size(321, 321)
        Me.dg_otras.TabIndex = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "dg_otras"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.Color.Teal
        Me.Label28.Location = New System.Drawing.Point(17, 1)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(247, 17)
        Me.Label28.TabIndex = 121
        Me.Label28.Text = "OTRAS METODOS DE CAJA"
        '
        'CheConfirmaCierre_otros
        '
        Me.CheConfirmaCierre_otros.AutoSize = True
        Me.CheConfirmaCierre_otros.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheConfirmaCierre_otros.ForeColor = System.Drawing.Color.Teal
        Me.CheConfirmaCierre_otros.Location = New System.Drawing.Point(688, 418)
        Me.CheConfirmaCierre_otros.Name = "CheConfirmaCierre_otros"
        Me.CheConfirmaCierre_otros.Size = New System.Drawing.Size(207, 17)
        Me.CheConfirmaCierre_otros.TabIndex = 129
        Me.CheConfirmaCierre_otros.Text = "CUADRE OTROS METODOS DE CAJA"
        Me.CheConfirmaCierre_otros.UseVisualStyleBackColor = True
        '
        'CheConfirmaCierre
        '
        Me.CheConfirmaCierre.AutoSize = True
        Me.CheConfirmaCierre.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheConfirmaCierre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CheConfirmaCierre.Location = New System.Drawing.Point(380, 418)
        Me.CheConfirmaCierre.Name = "CheConfirmaCierre"
        Me.CheConfirmaCierre.Size = New System.Drawing.Size(188, 17)
        Me.CheConfirmaCierre.TabIndex = 128
        Me.CheConfirmaCierre.Text = "CUADRE DEL EFECTIVO DE CAJA"
        Me.CheConfirmaCierre.UseVisualStyleBackColor = True
        '
        'ChekReconteo
        '
        Me.ChekReconteo.AutoSize = True
        Me.ChekReconteo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChekReconteo.ForeColor = System.Drawing.Color.Gray
        Me.ChekReconteo.Location = New System.Drawing.Point(379, 312)
        Me.ChekReconteo.Name = "ChekReconteo"
        Me.ChekReconteo.Size = New System.Drawing.Size(104, 34)
        Me.ChekReconteo.TabIndex = 127
        Me.ChekReconteo.Text = "RECONTEO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " DE ENTREGA :"
        Me.ChekReconteo.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(17, 439)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(210, 17)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "COMENTARIOS  DE APERTURA :"
        '
        'txt_refapertura_cierre
        '
        Me.txt_refapertura_cierre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_refapertura_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_refapertura_cierre.Location = New System.Drawing.Point(11, 459)
        Me.txt_refapertura_cierre.MaxLength = 200
        Me.txt_refapertura_cierre.Multiline = True
        Me.txt_refapertura_cierre.Name = "txt_refapertura_cierre"
        Me.txt_refapertura_cierre.Size = New System.Drawing.Size(330, 42)
        Me.txt_refapertura_cierre.TabIndex = 124
        '
        'Lbl_totalefectivo_cierre
        '
        Me.Lbl_totalefectivo_cierre.BackColor = System.Drawing.Color.White
        Me.Lbl_totalefectivo_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_totalefectivo_cierre.ForeColor = System.Drawing.Color.Black
        Me.Lbl_totalefectivo_cierre.Location = New System.Drawing.Point(508, 232)
        Me.Lbl_totalefectivo_cierre.Name = "Lbl_totalefectivo_cierre"
        Me.Lbl_totalefectivo_cierre.Size = New System.Drawing.Size(119, 23)
        Me.Lbl_totalefectivo_cierre.TabIndex = 123
        Me.Lbl_totalefectivo_cierre.Text = "0.00"
        Me.Lbl_totalefectivo_cierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Gray
        Me.Label18.Location = New System.Drawing.Point(374, 235)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(132, 12)
        Me.Label18.TabIndex = 122
        Me.Label18.Text = "TOTAL EFECTIVO :"
        '
        'Lbl_apertura_cierre
        '
        Me.Lbl_apertura_cierre.BackColor = System.Drawing.Color.White
        Me.Lbl_apertura_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_apertura_cierre.ForeColor = System.Drawing.Color.Black
        Me.Lbl_apertura_cierre.Location = New System.Drawing.Point(508, 34)
        Me.Lbl_apertura_cierre.Name = "Lbl_apertura_cierre"
        Me.Lbl_apertura_cierre.Size = New System.Drawing.Size(119, 23)
        Me.Lbl_apertura_cierre.TabIndex = 119
        Me.Lbl_apertura_cierre.Text = "0.00"
        Me.Lbl_apertura_cierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.Gray
        Me.Label27.Location = New System.Drawing.Point(370, 34)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(132, 12)
        Me.Label27.TabIndex = 118
        Me.Label27.Text = "MONTO APERTURA :"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.Gray
        Me.Label24.Location = New System.Drawing.Point(373, 67)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(204, 17)
        Me.Label24.TabIndex = 117
        Me.Label24.Text = "OPERACIONES EN EFECTIVO :"
        '
        'txt_reconteo_cierre
        '
        Me.txt_reconteo_cierre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_reconteo_cierre.Enabled = False
        Me.txt_reconteo_cierre.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_reconteo_cierre.Location = New System.Drawing.Point(505, 318)
        Me.txt_reconteo_cierre.MaxLength = 0
        Me.txt_reconteo_cierre.Name = "txt_reconteo_cierre"
        Me.txt_reconteo_cierre.Size = New System.Drawing.Size(119, 22)
        Me.txt_reconteo_cierre.TabIndex = 116
        Me.txt_reconteo_cierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_usuario_cierre
        '
        Me.txt_usuario_cierre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_usuario_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_usuario_cierre.Location = New System.Drawing.Point(100, 34)
        Me.txt_usuario_cierre.MaxLength = 0
        Me.txt_usuario_cierre.Name = "txt_usuario_cierre"
        Me.txt_usuario_cierre.Size = New System.Drawing.Size(248, 16)
        Me.txt_usuario_cierre.TabIndex = 114
        Me.txt_usuario_cierre.Text = "--"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(8, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 16)
        Me.Label22.TabIndex = 113
        Me.Label22.Text = "USUARIO :"
        '
        'dg_efectivo
        '
        Me.dg_efectivo.AllowUserToAddRows = False
        Me.dg_efectivo.AllowUserToDeleteRows = False
        Me.dg_efectivo.AllowUserToResizeRows = False
        Me.dg_efectivo.BackgroundColor = System.Drawing.Color.White
        Me.dg_efectivo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_efectivo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_efectivo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_efectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_efectivo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_efectivo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dg_efectivo.GridColor = System.Drawing.Color.White
        Me.dg_efectivo.Location = New System.Drawing.Point(370, 84)
        Me.dg_efectivo.MultiSelect = False
        Me.dg_efectivo.Name = "dg_efectivo"
        Me.dg_efectivo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_efectivo.RowHeadersVisible = False
        Me.dg_efectivo.RowTemplate.Height = 25
        Me.dg_efectivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_efectivo.Size = New System.Drawing.Size(257, 145)
        Me.dg_efectivo.TabIndex = 112
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "dg_efectivo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'CmdGrabar_cierre
        '
        Me.CmdGrabar_cierre.Enabled = False
        Me.CmdGrabar_cierre.FlatAppearance.BorderSize = 0
        Me.CmdGrabar_cierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar_cierre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar_cierre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar_cierre.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdGrabar_cierre.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar_cierre.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrabar_cierre.IconSize = 25
        Me.CmdGrabar_cierre.Location = New System.Drawing.Point(360, 500)
        Me.CmdGrabar_cierre.Name = "CmdGrabar_cierre"
        Me.CmdGrabar_cierre.Size = New System.Drawing.Size(87, 45)
        Me.CmdGrabar_cierre.TabIndex = 110
        Me.CmdGrabar_cierre.Text = "&ACEPTAR"
        Me.CmdGrabar_cierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdGrabar_cierre.UseVisualStyleBackColor = True
        '
        'CmdCancelar_cierre
        '
        Me.CmdCancelar_cierre.FlatAppearance.BorderSize = 0
        Me.CmdCancelar_cierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelar_cierre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelar_cierre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelar_cierre.IconChar = FontAwesome.Sharp.IconChar.Eraser
        Me.CmdCancelar_cierre.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelar_cierre.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelar_cierre.IconSize = 25
        Me.CmdCancelar_cierre.Location = New System.Drawing.Point(507, 500)
        Me.CmdCancelar_cierre.Name = "CmdCancelar_cierre"
        Me.CmdCancelar_cierre.Size = New System.Drawing.Size(87, 45)
        Me.CmdCancelar_cierre.TabIndex = 109
        Me.CmdCancelar_cierre.Text = "CANCELAR"
        Me.CmdCancelar_cierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdCancelar_cierre.UseVisualStyleBackColor = True
        '
        'txt_fal_cierre
        '
        Me.txt_fal_cierre.BackColor = System.Drawing.Color.White
        Me.txt_fal_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fal_cierre.ForeColor = System.Drawing.Color.DarkRed
        Me.txt_fal_cierre.Location = New System.Drawing.Point(508, 382)
        Me.txt_fal_cierre.Name = "txt_fal_cierre"
        Me.txt_fal_cierre.Size = New System.Drawing.Size(119, 23)
        Me.txt_fal_cierre.TabIndex = 108
        Me.txt_fal_cierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_sob_cierre
        '
        Me.txt_sob_cierre.BackColor = System.Drawing.Color.White
        Me.txt_sob_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sob_cierre.ForeColor = System.Drawing.Color.Green
        Me.txt_sob_cierre.Location = New System.Drawing.Point(508, 348)
        Me.txt_sob_cierre.Name = "txt_sob_cierre"
        Me.txt_sob_cierre.Size = New System.Drawing.Size(119, 23)
        Me.txt_sob_cierre.TabIndex = 107
        Me.txt_sob_cierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_entregaconteo_cierre
        '
        Me.Lbl_entregaconteo_cierre.BackColor = System.Drawing.Color.White
        Me.Lbl_entregaconteo_cierre.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_entregaconteo_cierre.ForeColor = System.Drawing.Color.Black
        Me.Lbl_entregaconteo_cierre.Location = New System.Drawing.Point(508, 275)
        Me.Lbl_entregaconteo_cierre.Name = "Lbl_entregaconteo_cierre"
        Me.Lbl_entregaconteo_cierre.Size = New System.Drawing.Size(119, 23)
        Me.Lbl_entregaconteo_cierre.TabIndex = 105
        Me.Lbl_entregaconteo_cierre.Text = "0.00"
        Me.Lbl_entregaconteo_cierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Gray
        Me.Label16.Location = New System.Drawing.Point(370, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(198, 16)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "RESUMEN  DE EFECTIVO :"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(374, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 14)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "ENTREGA CONTEO :"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(373, 382)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 14)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "AUTOM.  FALTANTE:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(10, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(204, 17)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "DESGLOSE POR DENOMINACION :"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(373, 351)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 14)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "AUTOM.  SOBRANTE:"
        '
        'TxtMonto
        '
        Me.TxtMonto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMonto.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.Location = New System.Drawing.Point(256, 122)
        Me.TxtMonto.MaxLength = 0
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(85, 22)
        Me.TxtMonto.TabIndex = 80
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'OpDirecto
        '
        Me.OpDirecto.AutoSize = True
        Me.OpDirecto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OpDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpDirecto.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpDirecto.Location = New System.Drawing.Point(29, 84)
        Me.OpDirecto.Name = "OpDirecto"
        Me.OpDirecto.Size = New System.Drawing.Size(112, 17)
        Me.OpDirecto.TabIndex = 80
        Me.OpDirecto.Text = "MONTO DIRECTO"
        Me.OpDirecto.UseVisualStyleBackColor = True
        '
        'OpDesglose
        '
        Me.OpDesglose.AutoSize = True
        Me.OpDesglose.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OpDesglose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpDesglose.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpDesglose.Location = New System.Drawing.Point(184, 84)
        Me.OpDesglose.Name = "OpDesglose"
        Me.OpDesglose.Size = New System.Drawing.Size(123, 17)
        Me.OpDesglose.TabIndex = 81
        Me.OpDesglose.Text = "MONTO DESGLOSE "
        Me.OpDesglose.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(10, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(181, 29)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "MONTO DE CONTEO    :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (Incluir Monto de Apertura)"
        '
        'PanelRegistros
        '
        Me.PanelRegistros.Controls.Add(Me.dg_registros)
        Me.PanelRegistros.Controls.Add(Me.Panel_piereg)
        Me.PanelRegistros.Controls.Add(Me.Panel_cabreg)
        Me.PanelRegistros.Location = New System.Drawing.Point(994, 423)
        Me.PanelRegistros.Name = "PanelRegistros"
        Me.PanelRegistros.Size = New System.Drawing.Size(410, 283)
        Me.PanelRegistros.TabIndex = 90
        Me.PanelRegistros.Visible = False
        '
        'dg_registros
        '
        Me.dg_registros.AllowUserToAddRows = False
        Me.dg_registros.AllowUserToDeleteRows = False
        Me.dg_registros.AllowUserToResizeRows = False
        Me.dg_registros.BackgroundColor = System.Drawing.Color.White
        Me.dg_registros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_registros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_registros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_registros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_registros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_registros.DefaultCellStyle = DataGridViewCellStyle4
        Me.dg_registros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_registros.GridColor = System.Drawing.Color.White
        Me.dg_registros.Location = New System.Drawing.Point(0, 23)
        Me.dg_registros.MultiSelect = False
        Me.dg_registros.Name = "dg_registros"
        Me.dg_registros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_registros.RowHeadersVisible = False
        Me.dg_registros.RowTemplate.Height = 25
        Me.dg_registros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_registros.Size = New System.Drawing.Size(410, 215)
        Me.dg_registros.TabIndex = 5
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "dg_registros"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'Panel_piereg
        '
        Me.Panel_piereg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel_piereg.Location = New System.Drawing.Point(0, 238)
        Me.Panel_piereg.Name = "Panel_piereg"
        Me.Panel_piereg.Size = New System.Drawing.Size(410, 45)
        Me.Panel_piereg.TabIndex = 1
        '
        'Panel_cabreg
        '
        Me.Panel_cabreg.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_cabreg.Location = New System.Drawing.Point(0, 0)
        Me.Panel_cabreg.Name = "Panel_cabreg"
        Me.Panel_cabreg.Size = New System.Drawing.Size(410, 23)
        Me.Panel_cabreg.TabIndex = 0
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.PanelRegistros)
        Me.PanelPrincipal.Controls.Add(Me.PanelApertura)
        Me.PanelPrincipal.Controls.Add(Me.PanelCierre)
        Me.PanelPrincipal.Location = New System.Drawing.Point(9, 71)
        Me.PanelPrincipal.Name = "PanelPrincipal"
        Me.PanelPrincipal.Size = New System.Drawing.Size(1276, 594)
        Me.PanelPrincipal.TabIndex = 91
        '
        'FaltaDatos
        '
        Me.FaltaDatos.ContainerControl = Me
        Me.FaltaDatos.Icon = CType(resources.GetObject("FaltaDatos.Icon"), System.Drawing.Icon)
        '
        'cmdFormato
        '
        Me.cmdFormato.FlatAppearance.BorderSize = 0
        Me.cmdFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmdFormato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.cmdFormato.IconChar = FontAwesome.Sharp.IconChar.Print
        Me.cmdFormato.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.cmdFormato.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.cmdFormato.IconSize = 23
        Me.cmdFormato.Location = New System.Drawing.Point(656, 504)
        Me.cmdFormato.Name = "cmdFormato"
        Me.cmdFormato.Size = New System.Drawing.Size(82, 41)
        Me.cmdFormato.TabIndex = 131
        Me.cmdFormato.Text = "IMPRESION"
        Me.cmdFormato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdFormato.UseVisualStyleBackColor = True
        '
        'FrmControlCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1229, 722)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelPrincipal)
        Me.Controls.Add(Me.PanelSup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmControlCajas"
        Me.PanelSup.ResumeLayout(False)
        CType(Me.dg_monedas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelApertura.ResumeLayout(False)
        Me.PanelApertura.PerformLayout()
        Me.PanelCierre.ResumeLayout(False)
        Me.PanelCierre.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg_otras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_efectivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRegistros.ResumeLayout(False)
        CType(Me.dg_registros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPrincipal.ResumeLayout(False)
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CmdCajas As FontAwesome.Sharp.IconButton
    Friend WithEvents Label23 As Label
    Friend WithEvents CmdMonedaComp As FontAwesome.Sharp.IconButton
    Friend WithEvents dg_monedas As DataGridView
    Friend WithEvents PanelApertura As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_ref_aper As TextBox
    Friend WithEvents TxtMonto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents OpDesglose As RadioButton
    Friend WithEvents OpDirecto As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CmdGrabar_aper As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelar_aper As FontAwesome.Sharp.IconButton
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents PanelCierre As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtRef_cierre As TextBox
    Friend WithEvents TxtFecha_cierre As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtMonto_aper As TextBox
    Friend WithEvents txt_usuario_cierre As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents dg_efectivo As DataGridView
    Friend WithEvents CmdGrabar_cierre As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelar_cierre As FontAwesome.Sharp.IconButton
    Friend WithEvents txt_fal_cierre As Label
    Friend WithEvents txt_sob_cierre As Label
    Friend WithEvents Lbl_entregaconteo_cierre As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CmdCierre As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdRegistros As FontAwesome.Sharp.IconButton
    Friend WithEvents txt_reconteo_cierre As TextBox
    Friend WithEvents CmdListaApe As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelRegistros As Panel
    Friend WithEvents dg_registros As DataGridView
    Friend WithEvents Panel_piereg As Panel
    Friend WithEvents Panel_cabreg As Panel
    Friend WithEvents PanelPrincipal As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents Lbl_apertura_cierre As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents CmdValida As FontAwesome.Sharp.IconButton
    Friend WithEvents Label28 As Label
    Friend WithEvents dg_otras As DataGridView
    Friend WithEvents lfechahora_aper As Label
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Lbl_totalefectivo_cierre As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txt_refapertura_cierre As TextBox
    Friend WithEvents ChekReconteo As CheckBox
    Friend WithEvents CheConfirmaCierre As CheckBox
    Friend WithEvents CheConfirmaCierre_otros As CheckBox
    Friend WithEvents id_opcion As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents opRM As RadioButton
    Friend WithEvents opRS As RadioButton
    Friend WithEvents FaltaDatos As ErrorProvider
    Friend WithEvents cmdFormato As FontAwesome.Sharp.IconButton
End Class
