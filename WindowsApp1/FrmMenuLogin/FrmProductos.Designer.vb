Imports System.Data.SqlClient
Imports System.Globalization

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductos))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.CmdCrear = New FontAwesome.Sharp.IconButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.IconButton4 = New FontAwesome.Sharp.IconButton()
        Me.PanelBusquedas = New System.Windows.Forms.FlowLayoutPanel()
        Me.CmdGrupoMed = New FontAwesome.Sharp.IconButton()
        Me.CmdLab = New FontAwesome.Sharp.IconButton()
        Me.CmdClasi = New FontAwesome.Sharp.IconButton()
        Me.CmdPrinc = New FontAwesome.Sharp.IconButton()
        Me.FrmConcent = New FontAwesome.Sharp.IconButton()
        Me.CmdExcip = New FontAwesome.Sharp.IconButton()
        Me.CmdFormas = New FontAwesome.Sharp.IconButton()
        Me.frmInser = New FontAwesome.Sharp.IconButton()
        Me.CmdSintomas = New FontAwesome.Sharp.IconButton()
        Me.CmdGrupoOtros = New FontAwesome.Sharp.IconButton()
        Me.CmdGrupoServ = New FontAwesome.Sharp.IconButton()
        Me.CmdMarcas = New FontAwesome.Sharp.IconButton()
        Me.LblBuscarpor = New System.Windows.Forms.Label()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdBuscar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.PanelCentro = New System.Windows.Forms.Panel()
        Me.PanelBox2 = New System.Windows.Forms.Panel()
        Me.TxtBox2 = New System.Windows.Forms.RichTextBox()
        Me.PanelBox1 = New System.Windows.Forms.Panel()
        Me.gridstock = New System.Windows.Forms.DataGridView()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.LblProductoTit = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbPres = New System.Windows.Forms.ComboBox()
        Me.DataGridResul = New System.Windows.Forms.DataGridView()
        Me.ToolTipBotones = New System.Windows.Forms.ToolTip(Me.components)
        Me.ayuda = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelProductos = New System.Windows.Forms.Panel()
        Me.txt_id_prod_master = New System.Windows.Forms.TextBox()
        Me.PanelDetalleProducto = New System.Windows.Forms.Panel()
        Me.CmdGrabar = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelarOper = New FontAwesome.Sharp.IconButton()
        Me.CmdRegresa = New FontAwesome.Sharp.IconButton()
        Me.tabCatalogo = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ListTipo70 = New System.Windows.Forms.ListBox()
        Me.ListTipo90 = New System.Windows.Forms.ListBox()
        Me.ListTipo100 = New System.Windows.Forms.ListBox()
        Me.ListTipo80 = New System.Windows.Forms.ListBox()
        Me.ListTipo60 = New System.Windows.Forms.ListBox()
        Me.ListTipo30 = New System.Windows.Forms.ListBox()
        Me.ListTipo40 = New System.Windows.Forms.ListBox()
        Me.ListTipo50 = New System.Windows.Forms.ListBox()
        Me.Cmd_add60 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar60 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add70 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar70 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add80 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar80 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add90 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar90 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add100 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar100 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add50 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar50 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add40 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar40 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add30 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar30 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add20 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar20 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_add10 = New FontAwesome.Sharp.IconButton()
        Me.Cmd_Quitar10 = New FontAwesome.Sharp.IconButton()
        Me.LblTipo50 = New System.Windows.Forms.Label()
        Me.LblTipo40 = New System.Windows.Forms.Label()
        Me.LblTipo30 = New System.Windows.Forms.Label()
        Me.ListTipo20 = New System.Windows.Forms.ListBox()
        Me.LblTipo20 = New System.Windows.Forms.Label()
        Me.ListTipo10 = New System.Windows.Forms.ListBox()
        Me.LblTipo10 = New System.Windows.Forms.Label()
        Me.LblTipo100 = New System.Windows.Forms.Label()
        Me.LblTipo90 = New System.Windows.Forms.Label()
        Me.LblTipo80 = New System.Windows.Forms.Label()
        Me.LblTipo70 = New System.Windows.Forms.Label()
        Me.LblTipo60 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Radio_Med = New System.Windows.Forms.RadioButton()
        Me.Radio_Otros = New System.Windows.Forms.RadioButton()
        Me.Radio_Serv = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PanelPrecios = New System.Windows.Forms.Panel()
        Me.CmdTipoLista = New FontAwesome.Sharp.IconButton()
        Me.CmdTipoCosto = New FontAwesome.Sharp.IconButton()
        Me.blb_costo_ult = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CmdGrabaPrecios = New FontAwesome.Sharp.IconButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblEtiquetaPres = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CmdMoneda = New FontAwesome.Sharp.IconButton()
        Me.CmdLocalLista = New FontAwesome.Sharp.IconButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CmdEstado = New FontAwesome.Sharp.IconButton()
        Me.lblEstado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PanelLotes = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_diasalerta_lote = New System.Windows.Forms.TextBox()
        Me.txt_diasprevios_lote = New System.Windows.Forms.TextBox()
        Me.Check_es_controllotes = New System.Windows.Forms.CheckBox()
        Me.Check_es_inventariable = New System.Windows.Forms.CheckBox()
        Me.Check_exonerado = New System.Windows.Forms.CheckBox()
        Me.txt_ref = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_cbarra = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_idproducto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmdCodigoProd = New FontAwesome.Sharp.IconButton()
        Me.dg_precios = New WindowsApp1.GridProductoMae_Plus()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_grid = New WindowsApp1.GridProductoMae_Plus()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdNombreP = New FontAwesome.Sharp.IconButton()
        Me.PanelSup.SuspendLayout()
        Me.PanelBusquedas.SuspendLayout()
        Me.PanelCentro.SuspendLayout()
        Me.PanelBox2.SuspendLayout()
        Me.PanelBox1.SuspendLayout()
        CType(Me.gridstock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridResul, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ayuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelProductos.SuspendLayout()
        Me.PanelDetalleProducto.SuspendLayout()
        Me.tabCatalogo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.PanelPrecios.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanelLotes.SuspendLayout()
        CType(Me.dg_precios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.CmdNombreP)
        Me.PanelSup.Controls.Add(Me.CmdCodigoProd)
        Me.PanelSup.Controls.Add(Me.IconButton3)
        Me.PanelSup.Controls.Add(Me.CmdCrear)
        Me.PanelSup.Controls.Add(Me.Label12)
        Me.PanelSup.Controls.Add(Me.IconButton4)
        Me.PanelSup.Controls.Add(Me.PanelBusquedas)
        Me.PanelSup.Controls.Add(Me.LblBuscarpor)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdBuscar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Controls.Add(Me.TxtBuscar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1304, 68)
        Me.PanelSup.TabIndex = 0
        '
        'IconButton3
        '
        Me.IconButton3.FlatAppearance.BorderSize = 0
        Me.IconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.White
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.IconButton3.IconColor = System.Drawing.Color.White
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 25
        Me.IconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.Location = New System.Drawing.Point(391, 12)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(95, 23)
        Me.IconButton3.TabIndex = 35
        Me.IconButton3.Text = "CANCELAR"
        Me.IconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton3.UseVisualStyleBackColor = True
        '
        'CmdCrear
        '
        Me.CmdCrear.FlatAppearance.BorderSize = 0
        Me.CmdCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCrear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCrear.ForeColor = System.Drawing.Color.White
        Me.CmdCrear.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmdCrear.IconColor = System.Drawing.Color.White
        Me.CmdCrear.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCrear.IconSize = 25
        Me.CmdCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCrear.Location = New System.Drawing.Point(280, 13)
        Me.CmdCrear.Name = "CmdCrear"
        Me.CmdCrear.Size = New System.Drawing.Size(78, 23)
        Me.CmdCrear.TabIndex = 34
        Me.CmdCrear.Text = "CREAR"
        Me.CmdCrear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCrear.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(-3, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(167, 15)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "CATALOGO DE PRODUCTOS  "
        '
        'IconButton4
        '
        Me.IconButton4.FlatAppearance.BorderSize = 0
        Me.IconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.IconButton4.ForeColor = System.Drawing.Color.White
        Me.IconButton4.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft
        Me.IconButton4.IconColor = System.Drawing.Color.White
        Me.IconButton4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton4.IconSize = 18
        Me.IconButton4.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton4.Location = New System.Drawing.Point(170, -2)
        Me.IconButton4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.IconButton4.Name = "IconButton4"
        Me.IconButton4.Size = New System.Drawing.Size(95, 21)
        Me.IconButton4.TabIndex = 33
        Me.IconButton4.Tag = "20"
        Me.IconButton4.Text = "F1 CERRAR"
        Me.IconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton4.UseVisualStyleBackColor = True
        '
        'PanelBusquedas
        '
        Me.PanelBusquedas.AutoScroll = True
        Me.PanelBusquedas.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.PanelBusquedas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBusquedas.Controls.Add(Me.CmdGrupoMed)
        Me.PanelBusquedas.Controls.Add(Me.CmdLab)
        Me.PanelBusquedas.Controls.Add(Me.CmdClasi)
        Me.PanelBusquedas.Controls.Add(Me.CmdPrinc)
        Me.PanelBusquedas.Controls.Add(Me.FrmConcent)
        Me.PanelBusquedas.Controls.Add(Me.CmdExcip)
        Me.PanelBusquedas.Controls.Add(Me.CmdFormas)
        Me.PanelBusquedas.Controls.Add(Me.frmInser)
        Me.PanelBusquedas.Controls.Add(Me.CmdSintomas)
        Me.PanelBusquedas.Controls.Add(Me.CmdGrupoOtros)
        Me.PanelBusquedas.Controls.Add(Me.CmdGrupoServ)
        Me.PanelBusquedas.Controls.Add(Me.CmdMarcas)
        Me.PanelBusquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelBusquedas.Location = New System.Drawing.Point(515, 0)
        Me.PanelBusquedas.Name = "PanelBusquedas"
        Me.PanelBusquedas.Size = New System.Drawing.Size(670, 68)
        Me.PanelBusquedas.TabIndex = 2
        '
        'CmdGrupoMed
        '
        Me.CmdGrupoMed.FlatAppearance.BorderSize = 0
        Me.CmdGrupoMed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrupoMed.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrupoMed.ForeColor = System.Drawing.Color.White
        Me.CmdGrupoMed.IconChar = FontAwesome.Sharp.IconChar.Cubes
        Me.CmdGrupoMed.IconColor = System.Drawing.Color.White
        Me.CmdGrupoMed.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrupoMed.IconSize = 18
        Me.CmdGrupoMed.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdGrupoMed.Location = New System.Drawing.Point(3, 0)
        Me.CmdGrupoMed.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdGrupoMed.Name = "CmdGrupoMed"
        Me.CmdGrupoMed.Size = New System.Drawing.Size(102, 32)
        Me.CmdGrupoMed.TabIndex = 32
        Me.CmdGrupoMed.Tag = "20"
        Me.CmdGrupoMed.Text = "F10 GRUPO MEDICAM."
        Me.CmdGrupoMed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGrupoMed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdGrupoMed.UseVisualStyleBackColor = True
        '
        'CmdLab
        '
        Me.CmdLab.FlatAppearance.BorderSize = 0
        Me.CmdLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdLab.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdLab.ForeColor = System.Drawing.Color.White
        Me.CmdLab.IconChar = FontAwesome.Sharp.IconChar.Kaaba
        Me.CmdLab.IconColor = System.Drawing.Color.White
        Me.CmdLab.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdLab.IconSize = 18
        Me.CmdLab.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdLab.Location = New System.Drawing.Point(111, 0)
        Me.CmdLab.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdLab.Name = "CmdLab"
        Me.CmdLab.Size = New System.Drawing.Size(102, 34)
        Me.CmdLab.TabIndex = 33
        Me.CmdLab.Tag = "30"
        Me.CmdLab.Text = "F2 LABORAT.          "
        Me.CmdLab.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdLab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdLab.UseVisualStyleBackColor = True
        '
        'CmdClasi
        '
        Me.CmdClasi.FlatAppearance.BorderSize = 0
        Me.CmdClasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdClasi.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClasi.ForeColor = System.Drawing.Color.White
        Me.CmdClasi.IconChar = FontAwesome.Sharp.IconChar.Filter
        Me.CmdClasi.IconColor = System.Drawing.Color.White
        Me.CmdClasi.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdClasi.IconSize = 18
        Me.CmdClasi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdClasi.Location = New System.Drawing.Point(219, 0)
        Me.CmdClasi.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdClasi.Name = "CmdClasi"
        Me.CmdClasi.Size = New System.Drawing.Size(102, 32)
        Me.CmdClasi.TabIndex = 34
        Me.CmdClasi.Tag = "40"
        Me.CmdClasi.Text = "F3 CLASIFICAC."
        Me.CmdClasi.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdClasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdClasi.UseVisualStyleBackColor = True
        '
        'CmdPrinc
        '
        Me.CmdPrinc.FlatAppearance.BorderSize = 0
        Me.CmdPrinc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdPrinc.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrinc.ForeColor = System.Drawing.Color.White
        Me.CmdPrinc.IconChar = FontAwesome.Sharp.IconChar.Vial
        Me.CmdPrinc.IconColor = System.Drawing.Color.White
        Me.CmdPrinc.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdPrinc.IconSize = 18
        Me.CmdPrinc.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdPrinc.Location = New System.Drawing.Point(327, 0)
        Me.CmdPrinc.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdPrinc.Name = "CmdPrinc"
        Me.CmdPrinc.Size = New System.Drawing.Size(102, 32)
        Me.CmdPrinc.TabIndex = 35
        Me.CmdPrinc.Tag = "50"
        Me.CmdPrinc.Text = "F4 PRINC. ACTIVO"
        Me.CmdPrinc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdPrinc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdPrinc.UseVisualStyleBackColor = True
        '
        'FrmConcent
        '
        Me.FrmConcent.FlatAppearance.BorderSize = 0
        Me.FrmConcent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FrmConcent.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrmConcent.ForeColor = System.Drawing.Color.White
        Me.FrmConcent.IconChar = FontAwesome.Sharp.IconChar.Vials
        Me.FrmConcent.IconColor = System.Drawing.Color.White
        Me.FrmConcent.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.FrmConcent.IconSize = 18
        Me.FrmConcent.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FrmConcent.Location = New System.Drawing.Point(435, 0)
        Me.FrmConcent.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.FrmConcent.Name = "FrmConcent"
        Me.FrmConcent.Size = New System.Drawing.Size(102, 32)
        Me.FrmConcent.TabIndex = 37
        Me.FrmConcent.Tag = "70"
        Me.FrmConcent.Text = "F5 CONCENTRAC."
        Me.FrmConcent.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.FrmConcent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.FrmConcent.UseVisualStyleBackColor = True
        '
        'CmdExcip
        '
        Me.CmdExcip.FlatAppearance.BorderSize = 0
        Me.CmdExcip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdExcip.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExcip.ForeColor = System.Drawing.Color.White
        Me.CmdExcip.IconChar = FontAwesome.Sharp.IconChar.Icicles
        Me.CmdExcip.IconColor = System.Drawing.Color.White
        Me.CmdExcip.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdExcip.IconSize = 18
        Me.CmdExcip.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdExcip.Location = New System.Drawing.Point(543, 0)
        Me.CmdExcip.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdExcip.Name = "CmdExcip"
        Me.CmdExcip.Size = New System.Drawing.Size(102, 32)
        Me.CmdExcip.TabIndex = 38
        Me.CmdExcip.Tag = "60"
        Me.CmdExcip.Text = "F6 EXCIPIENTES"
        Me.CmdExcip.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdExcip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdExcip.UseVisualStyleBackColor = True
        '
        'CmdFormas
        '
        Me.CmdFormas.FlatAppearance.BorderSize = 0
        Me.CmdFormas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdFormas.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFormas.ForeColor = System.Drawing.Color.White
        Me.CmdFormas.IconChar = FontAwesome.Sharp.IconChar.Shapes
        Me.CmdFormas.IconColor = System.Drawing.Color.White
        Me.CmdFormas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdFormas.IconSize = 18
        Me.CmdFormas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdFormas.Location = New System.Drawing.Point(3, 34)
        Me.CmdFormas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdFormas.Name = "CmdFormas"
        Me.CmdFormas.Size = New System.Drawing.Size(102, 32)
        Me.CmdFormas.TabIndex = 39
        Me.CmdFormas.Tag = "80"
        Me.CmdFormas.Text = "F7 FORMAS  PRESENT."
        Me.CmdFormas.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdFormas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdFormas.UseVisualStyleBackColor = True
        '
        'frmInser
        '
        Me.frmInser.FlatAppearance.BorderSize = 0
        Me.frmInser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.frmInser.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmInser.ForeColor = System.Drawing.Color.White
        Me.frmInser.IconChar = FontAwesome.Sharp.IconChar.Globe
        Me.frmInser.IconColor = System.Drawing.Color.White
        Me.frmInser.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.frmInser.IconSize = 18
        Me.frmInser.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.frmInser.Location = New System.Drawing.Point(111, 34)
        Me.frmInser.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.frmInser.Name = "frmInser"
        Me.frmInser.Size = New System.Drawing.Size(102, 32)
        Me.frmInser.TabIndex = 40
        Me.frmInser.Tag = "90"
        Me.frmInser.Text = "F8 INSERTO MED."
        Me.frmInser.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.frmInser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.frmInser.UseVisualStyleBackColor = True
        '
        'CmdSintomas
        '
        Me.CmdSintomas.FlatAppearance.BorderSize = 0
        Me.CmdSintomas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSintomas.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSintomas.ForeColor = System.Drawing.Color.White
        Me.CmdSintomas.IconChar = FontAwesome.Sharp.IconChar.DotCircle
        Me.CmdSintomas.IconColor = System.Drawing.Color.White
        Me.CmdSintomas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSintomas.IconSize = 18
        Me.CmdSintomas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdSintomas.Location = New System.Drawing.Point(219, 34)
        Me.CmdSintomas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdSintomas.Name = "CmdSintomas"
        Me.CmdSintomas.Size = New System.Drawing.Size(102, 32)
        Me.CmdSintomas.TabIndex = 41
        Me.CmdSintomas.Tag = "100"
        Me.CmdSintomas.Text = "F9 SINTOMAS"
        Me.CmdSintomas.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdSintomas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSintomas.UseVisualStyleBackColor = True
        '
        'CmdGrupoOtros
        '
        Me.CmdGrupoOtros.FlatAppearance.BorderSize = 0
        Me.CmdGrupoOtros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrupoOtros.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrupoOtros.ForeColor = System.Drawing.Color.White
        Me.CmdGrupoOtros.IconChar = FontAwesome.Sharp.IconChar.EllipsisV
        Me.CmdGrupoOtros.IconColor = System.Drawing.Color.White
        Me.CmdGrupoOtros.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrupoOtros.IconSize = 18
        Me.CmdGrupoOtros.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdGrupoOtros.Location = New System.Drawing.Point(327, 34)
        Me.CmdGrupoOtros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdGrupoOtros.Name = "CmdGrupoOtros"
        Me.CmdGrupoOtros.Size = New System.Drawing.Size(102, 32)
        Me.CmdGrupoOtros.TabIndex = 42
        Me.CmdGrupoOtros.Tag = "110"
        Me.CmdGrupoOtros.Text = "CRTL+F3 G. OTROS"
        Me.CmdGrupoOtros.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdGrupoOtros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdGrupoOtros.UseVisualStyleBackColor = True
        '
        'CmdGrupoServ
        '
        Me.CmdGrupoServ.FlatAppearance.BorderSize = 0
        Me.CmdGrupoServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrupoServ.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrupoServ.ForeColor = System.Drawing.Color.White
        Me.CmdGrupoServ.IconChar = FontAwesome.Sharp.IconChar.Gitter
        Me.CmdGrupoServ.IconColor = System.Drawing.Color.White
        Me.CmdGrupoServ.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrupoServ.IconSize = 18
        Me.CmdGrupoServ.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdGrupoServ.Location = New System.Drawing.Point(435, 34)
        Me.CmdGrupoServ.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdGrupoServ.Name = "CmdGrupoServ"
        Me.CmdGrupoServ.Size = New System.Drawing.Size(102, 32)
        Me.CmdGrupoServ.TabIndex = 43
        Me.CmdGrupoServ.Tag = "120"
        Me.CmdGrupoServ.Text = "CRTL+F4 G. SERVIC.  "
        Me.CmdGrupoServ.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdGrupoServ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdGrupoServ.UseVisualStyleBackColor = True
        '
        'CmdMarcas
        '
        Me.CmdMarcas.FlatAppearance.BorderSize = 0
        Me.CmdMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMarcas.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMarcas.ForeColor = System.Drawing.Color.White
        Me.CmdMarcas.IconChar = FontAwesome.Sharp.IconChar.Fan
        Me.CmdMarcas.IconColor = System.Drawing.Color.White
        Me.CmdMarcas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMarcas.IconSize = 18
        Me.CmdMarcas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdMarcas.Location = New System.Drawing.Point(543, 34)
        Me.CmdMarcas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdMarcas.Name = "CmdMarcas"
        Me.CmdMarcas.Size = New System.Drawing.Size(102, 32)
        Me.CmdMarcas.TabIndex = 44
        Me.CmdMarcas.Tag = "200"
        Me.CmdMarcas.Text = "CRTL+F5  MARCAS "
        Me.CmdMarcas.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdMarcas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdMarcas.UseVisualStyleBackColor = True
        '
        'LblBuscarpor
        '
        Me.LblBuscarpor.AutoSize = True
        Me.LblBuscarpor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuscarpor.ForeColor = System.Drawing.Color.White
        Me.LblBuscarpor.Location = New System.Drawing.Point(11, 43)
        Me.LblBuscarpor.Name = "LblBuscarpor"
        Me.LblBuscarpor.Size = New System.Drawing.Size(61, 15)
        Me.LblBuscarpor.TabIndex = 15
        Me.LblBuscarpor.Text = "&Producto:"
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(1243, 3)
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
        Me.CmdCerrar.Location = New System.Drawing.Point(1272, 3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 25)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
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
        Me.CmdBuscar.Location = New System.Drawing.Point(486, 41)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(37, 27)
        Me.CmdBuscar.TabIndex = 8
        Me.CmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBuscar.UseVisualStyleBackColor = True
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
        Me.CmdMin.Location = New System.Drawing.Point(1214, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'TxtBuscar
        '
        Me.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscar.Location = New System.Drawing.Point(99, 43)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(381, 18)
        Me.TxtBuscar.TabIndex = 0
        '
        'PanelCentro
        '
        Me.PanelCentro.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.PanelCentro.Controls.Add(Me.PanelBox2)
        Me.PanelCentro.Controls.Add(Me.PanelBox1)
        Me.PanelCentro.Controls.Add(Me.IconButton1)
        Me.PanelCentro.Controls.Add(Me.IconButton2)
        Me.PanelCentro.Controls.Add(Me.LblProductoTit)
        Me.PanelCentro.Controls.Add(Me.Label3)
        Me.PanelCentro.Controls.Add(Me.Label2)
        Me.PanelCentro.Controls.Add(Me.CmbPres)
        Me.PanelCentro.Controls.Add(Me.DataGridResul)
        Me.PanelCentro.Location = New System.Drawing.Point(1033, 92)
        Me.PanelCentro.Name = "PanelCentro"
        Me.PanelCentro.Size = New System.Drawing.Size(491, 456)
        Me.PanelCentro.TabIndex = 3
        '
        'PanelBox2
        '
        Me.PanelBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelBox2.Controls.Add(Me.TxtBox2)
        Me.PanelBox2.Location = New System.Drawing.Point(1057, 75)
        Me.PanelBox2.Name = "PanelBox2"
        Me.PanelBox2.Size = New System.Drawing.Size(252, 369)
        Me.PanelBox2.TabIndex = 90
        '
        'TxtBox2
        '
        Me.TxtBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBox2.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBox2.Location = New System.Drawing.Point(0, 0)
        Me.TxtBox2.Name = "TxtBox2"
        Me.TxtBox2.Size = New System.Drawing.Size(252, 369)
        Me.TxtBox2.TabIndex = 83
        Me.TxtBox2.Text = ""
        '
        'PanelBox1
        '
        Me.PanelBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelBox1.Controls.Add(Me.gridstock)
        Me.PanelBox1.Location = New System.Drawing.Point(770, 82)
        Me.PanelBox1.Name = "PanelBox1"
        Me.PanelBox1.Size = New System.Drawing.Size(261, 352)
        Me.PanelBox1.TabIndex = 89
        '
        'gridstock
        '
        Me.gridstock.AllowUserToAddRows = False
        Me.gridstock.AllowUserToDeleteRows = False
        Me.gridstock.AllowUserToResizeRows = False
        Me.gridstock.BackgroundColor = System.Drawing.Color.White
        Me.gridstock.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridstock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.gridstock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.gridstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridstock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridstock.GridColor = System.Drawing.Color.White
        Me.gridstock.Location = New System.Drawing.Point(0, 0)
        Me.gridstock.MultiSelect = False
        Me.gridstock.Name = "gridstock"
        Me.gridstock.ReadOnly = True
        Me.gridstock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.gridstock.RowHeadersVisible = False
        Me.gridstock.RowTemplate.Height = 25
        Me.gridstock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridstock.Size = New System.Drawing.Size(261, 352)
        Me.gridstock.TabIndex = 92
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.IconButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Vial
        Me.IconButton1.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 18
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton1.Location = New System.Drawing.Point(1214, 35)
        Me.IconButton1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(103, 34)
        Me.IconButton1.TabIndex = 88
        Me.IconButton1.Tag = "50"
        Me.IconButton1.Text = "CRTL+F2  MAS INFO."
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'IconButton2
        '
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.IconButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.Vial
        Me.IconButton2.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 18
        Me.IconButton2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton2.Location = New System.Drawing.Point(1096, 35)
        Me.IconButton2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(103, 34)
        Me.IconButton2.TabIndex = 87
        Me.IconButton2.Tag = "50"
        Me.IconButton2.Text = "CRTL+F1 EQUIVALENTES"
        Me.IconButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'LblProductoTit
        '
        Me.LblProductoTit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductoTit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.LblProductoTit.Location = New System.Drawing.Point(783, 1)
        Me.LblProductoTit.Name = "LblProductoTit"
        Me.LblProductoTit.Size = New System.Drawing.Size(526, 34)
        Me.LblProductoTit.TabIndex = 86
        Me.LblProductoTit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(1019, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "&Información: "
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(774, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 31)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "&Presentacion: (CRTL+1)"
        '
        'CmbPres
        '
        Me.CmbPres.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbPres.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbPres.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmbPres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPres.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbPres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPres.ForeColor = System.Drawing.Color.White
        Me.CmbPres.FormattingEnabled = True
        Me.CmbPres.Location = New System.Drawing.Point(866, 43)
        Me.CmbPres.Name = "CmbPres"
        Me.CmbPres.Size = New System.Drawing.Size(129, 23)
        Me.CmbPres.TabIndex = 80
        '
        'DataGridResul
        '
        Me.DataGridResul.AllowUserToAddRows = False
        Me.DataGridResul.AllowUserToDeleteRows = False
        Me.DataGridResul.AllowUserToResizeRows = False
        Me.DataGridResul.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.DataGridResul.Location = New System.Drawing.Point(8, 8)
        Me.DataGridResul.MultiSelect = False
        Me.DataGridResul.Name = "DataGridResul"
        Me.DataGridResul.ReadOnly = True
        Me.DataGridResul.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridResul.RowHeadersVisible = False
        Me.DataGridResul.RowTemplate.Height = 25
        Me.DataGridResul.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridResul.Size = New System.Drawing.Size(756, 435)
        Me.DataGridResul.TabIndex = 9
        '
        'ToolTipBotones
        '
        '
        'ayuda
        '
        Me.ayuda.ContainerControl = Me
        Me.ayuda.Icon = CType(resources.GetObject("ayuda.Icon"), System.Drawing.Icon)
        '
        'PanelProductos
        '
        Me.PanelProductos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelProductos.Controls.Add(Me.txt_id_prod_master)
        Me.PanelProductos.Controls.Add(Me.PanelDetalleProducto)
        Me.PanelProductos.Controls.Add(Me.CmdRegresa)
        Me.PanelProductos.Controls.Add(Me.tabCatalogo)
        Me.PanelProductos.Controls.Add(Me.Panel3)
        Me.PanelProductos.Controls.Add(Me.PanelLotes)
        Me.PanelProductos.Controls.Add(Me.Check_es_controllotes)
        Me.PanelProductos.Controls.Add(Me.Check_es_inventariable)
        Me.PanelProductos.Controls.Add(Me.Check_exonerado)
        Me.PanelProductos.Controls.Add(Me.txt_ref)
        Me.PanelProductos.Controls.Add(Me.Label6)
        Me.PanelProductos.Controls.Add(Me.txt_nombre)
        Me.PanelProductos.Controls.Add(Me.Label5)
        Me.PanelProductos.Controls.Add(Me.txt_cbarra)
        Me.PanelProductos.Controls.Add(Me.Label4)
        Me.PanelProductos.Controls.Add(Me.txt_codigo)
        Me.PanelProductos.Controls.Add(Me.Label1)
        Me.PanelProductos.Controls.Add(Me.txt_idproducto)
        Me.PanelProductos.Controls.Add(Me.Label8)
        Me.PanelProductos.Location = New System.Drawing.Point(14, 67)
        Me.PanelProductos.Name = "PanelProductos"
        Me.PanelProductos.Size = New System.Drawing.Size(1324, 617)
        Me.PanelProductos.TabIndex = 28
        Me.PanelProductos.Tag = "02"
        '
        'txt_id_prod_master
        '
        Me.txt_id_prod_master.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_id_prod_master.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_id_prod_master.Enabled = False
        Me.txt_id_prod_master.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_prod_master.Location = New System.Drawing.Point(538, 3)
        Me.txt_id_prod_master.MaxLength = 500
        Me.txt_id_prod_master.Name = "txt_id_prod_master"
        Me.txt_id_prod_master.Size = New System.Drawing.Size(153, 16)
        Me.txt_id_prod_master.TabIndex = 69
        Me.txt_id_prod_master.Text = "TXT_ID_PROD_MASTER"
        '
        'PanelDetalleProducto
        '
        Me.PanelDetalleProducto.BackColor = System.Drawing.Color.White
        Me.PanelDetalleProducto.Controls.Add(Me.CmdGrabar)
        Me.PanelDetalleProducto.Controls.Add(Me.CmdCancelarOper)
        Me.PanelDetalleProducto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetalleProducto.Location = New System.Drawing.Point(0, 557)
        Me.PanelDetalleProducto.Name = "PanelDetalleProducto"
        Me.PanelDetalleProducto.Size = New System.Drawing.Size(1324, 60)
        Me.PanelDetalleProducto.TabIndex = 68
        '
        'CmdGrabar
        '
        Me.CmdGrabar.FlatAppearance.BorderSize = 0
        Me.CmdGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdGrabar.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrabar.IconSize = 25
        Me.CmdGrabar.Location = New System.Drawing.Point(485, 3)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(98, 48)
        Me.CmdGrabar.TabIndex = 82
        Me.CmdGrabar.Text = "&ACTUALIZAR "
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
        Me.CmdCancelarOper.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelarOper.IconSize = 25
        Me.CmdCancelarOper.Location = New System.Drawing.Point(660, 3)
        Me.CmdCancelarOper.Name = "CmdCancelarOper"
        Me.CmdCancelarOper.Size = New System.Drawing.Size(74, 48)
        Me.CmdCancelarOper.TabIndex = 81
        Me.CmdCancelarOper.Text = "CANCELAR"
        Me.CmdCancelarOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdCancelarOper.UseVisualStyleBackColor = True
        '
        'CmdRegresa
        '
        Me.CmdRegresa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdRegresa.FlatAppearance.BorderSize = 0
        Me.CmdRegresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdRegresa.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdRegresa.ForeColor = System.Drawing.Color.White
        Me.CmdRegresa.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.CmdRegresa.IconColor = System.Drawing.Color.Black
        Me.CmdRegresa.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdRegresa.IconSize = 25
        Me.CmdRegresa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdRegresa.Location = New System.Drawing.Point(1231, 6)
        Me.CmdRegresa.Name = "CmdRegresa"
        Me.CmdRegresa.Size = New System.Drawing.Size(47, 34)
        Me.CmdRegresa.TabIndex = 67
        Me.CmdRegresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRegresa.UseVisualStyleBackColor = True
        '
        'tabCatalogo
        '
        Me.tabCatalogo.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabCatalogo.Controls.Add(Me.TabPage1)
        Me.tabCatalogo.Controls.Add(Me.TabPage2)
        Me.tabCatalogo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCatalogo.ItemSize = New System.Drawing.Size(134, 25)
        Me.tabCatalogo.Location = New System.Drawing.Point(10, 153)
        Me.tabCatalogo.Multiline = True
        Me.tabCatalogo.Name = "tabCatalogo"
        Me.tabCatalogo.SelectedIndex = 0
        Me.tabCatalogo.Size = New System.Drawing.Size(1272, 364)
        Me.tabCatalogo.TabIndex = 66
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1264, 331)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "ESTRUCTURA DE CATALOGO"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.ListTipo70)
        Me.Panel5.Controls.Add(Me.ListTipo90)
        Me.Panel5.Controls.Add(Me.ListTipo100)
        Me.Panel5.Controls.Add(Me.ListTipo80)
        Me.Panel5.Controls.Add(Me.ListTipo60)
        Me.Panel5.Controls.Add(Me.ListTipo30)
        Me.Panel5.Controls.Add(Me.ListTipo40)
        Me.Panel5.Controls.Add(Me.ListTipo50)
        Me.Panel5.Controls.Add(Me.Cmd_add60)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar60)
        Me.Panel5.Controls.Add(Me.Cmd_add70)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar70)
        Me.Panel5.Controls.Add(Me.Cmd_add80)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar80)
        Me.Panel5.Controls.Add(Me.Cmd_add90)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar90)
        Me.Panel5.Controls.Add(Me.Cmd_add100)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar100)
        Me.Panel5.Controls.Add(Me.Cmd_add50)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar50)
        Me.Panel5.Controls.Add(Me.Cmd_add40)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar40)
        Me.Panel5.Controls.Add(Me.Cmd_add30)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar30)
        Me.Panel5.Controls.Add(Me.Cmd_add20)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar20)
        Me.Panel5.Controls.Add(Me.Cmd_add10)
        Me.Panel5.Controls.Add(Me.Cmd_Quitar10)
        Me.Panel5.Controls.Add(Me.LblTipo50)
        Me.Panel5.Controls.Add(Me.LblTipo40)
        Me.Panel5.Controls.Add(Me.LblTipo30)
        Me.Panel5.Controls.Add(Me.ListTipo20)
        Me.Panel5.Controls.Add(Me.LblTipo20)
        Me.Panel5.Controls.Add(Me.ListTipo10)
        Me.Panel5.Controls.Add(Me.LblTipo10)
        Me.Panel5.Controls.Add(Me.LblTipo100)
        Me.Panel5.Controls.Add(Me.LblTipo90)
        Me.Panel5.Controls.Add(Me.LblTipo80)
        Me.Panel5.Controls.Add(Me.LblTipo70)
        Me.Panel5.Controls.Add(Me.LblTipo60)
        Me.Panel5.Location = New System.Drawing.Point(7, 38)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1150, 312)
        Me.Panel5.TabIndex = 67
        '
        'ListTipo70
        '
        Me.ListTipo70.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo70.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo70.ForeColor = System.Drawing.Color.White
        Me.ListTipo70.FormattingEnabled = True
        Me.ListTipo70.ItemHeight = 15
        Me.ListTipo70.Location = New System.Drawing.Point(238, 159)
        Me.ListTipo70.Name = "ListTipo70"
        Me.ListTipo70.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo70.TabIndex = 80
        Me.ListTipo70.Tag = "70"
        '
        'ListTipo90
        '
        Me.ListTipo90.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo90.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo90.ForeColor = System.Drawing.Color.White
        Me.ListTipo90.FormattingEnabled = True
        Me.ListTipo90.ItemHeight = 15
        Me.ListTipo90.Location = New System.Drawing.Point(695, 162)
        Me.ListTipo90.Name = "ListTipo90"
        Me.ListTipo90.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo90.TabIndex = 82
        Me.ListTipo90.Tag = "90"
        '
        'ListTipo100
        '
        Me.ListTipo100.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo100.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo100.ForeColor = System.Drawing.Color.White
        Me.ListTipo100.FormattingEnabled = True
        Me.ListTipo100.ItemHeight = 15
        Me.ListTipo100.Location = New System.Drawing.Point(926, 161)
        Me.ListTipo100.Name = "ListTipo100"
        Me.ListTipo100.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo100.TabIndex = 83
        Me.ListTipo100.Tag = "100"
        '
        'ListTipo80
        '
        Me.ListTipo80.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo80.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo80.ForeColor = System.Drawing.Color.White
        Me.ListTipo80.FormattingEnabled = True
        Me.ListTipo80.ItemHeight = 15
        Me.ListTipo80.Location = New System.Drawing.Point(463, 162)
        Me.ListTipo80.Name = "ListTipo80"
        Me.ListTipo80.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo80.TabIndex = 81
        Me.ListTipo80.Tag = "80"
        '
        'ListTipo60
        '
        Me.ListTipo60.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo60.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo60.ForeColor = System.Drawing.Color.White
        Me.ListTipo60.FormattingEnabled = True
        Me.ListTipo60.ItemHeight = 15
        Me.ListTipo60.Location = New System.Drawing.Point(6, 159)
        Me.ListTipo60.Name = "ListTipo60"
        Me.ListTipo60.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo60.TabIndex = 71
        Me.ListTipo60.Tag = "60"
        '
        'ListTipo30
        '
        Me.ListTipo30.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo30.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo30.ForeColor = System.Drawing.Color.White
        Me.ListTipo30.FormattingEnabled = True
        Me.ListTipo30.ItemHeight = 15
        Me.ListTipo30.Location = New System.Drawing.Point(463, 22)
        Me.ListTipo30.Name = "ListTipo30"
        Me.ListTipo30.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo30.TabIndex = 75
        Me.ListTipo30.Tag = "30"
        '
        'ListTipo40
        '
        Me.ListTipo40.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo40.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo40.ForeColor = System.Drawing.Color.White
        Me.ListTipo40.FormattingEnabled = True
        Me.ListTipo40.ItemHeight = 15
        Me.ListTipo40.Location = New System.Drawing.Point(695, 22)
        Me.ListTipo40.Name = "ListTipo40"
        Me.ListTipo40.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo40.TabIndex = 77
        Me.ListTipo40.Tag = "40"
        '
        'ListTipo50
        '
        Me.ListTipo50.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo50.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo50.ForeColor = System.Drawing.Color.White
        Me.ListTipo50.FormattingEnabled = True
        Me.ListTipo50.ItemHeight = 15
        Me.ListTipo50.Location = New System.Drawing.Point(926, 22)
        Me.ListTipo50.Name = "ListTipo50"
        Me.ListTipo50.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo50.TabIndex = 79
        Me.ListTipo50.Tag = "50"
        '
        'Cmd_add60
        '
        Me.Cmd_add60.FlatAppearance.BorderSize = 0
        Me.Cmd_add60.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add60.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add60.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add60.IconColor = System.Drawing.Color.Green
        Me.Cmd_add60.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add60.IconSize = 18
        Me.Cmd_add60.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add60.Location = New System.Drawing.Point(190, 142)
        Me.Cmd_add60.Name = "Cmd_add60"
        Me.Cmd_add60.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add60.TabIndex = 103
        Me.Cmd_add60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add60.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add60.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar60
        '
        Me.Cmd_Quitar60.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar60.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar60.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar60.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar60.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar60.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar60.IconSize = 18
        Me.Cmd_Quitar60.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar60.Location = New System.Drawing.Point(164, 143)
        Me.Cmd_Quitar60.Name = "Cmd_Quitar60"
        Me.Cmd_Quitar60.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar60.TabIndex = 102
        Me.Cmd_Quitar60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar60.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar60.UseVisualStyleBackColor = True
        '
        'Cmd_add70
        '
        Me.Cmd_add70.FlatAppearance.BorderSize = 0
        Me.Cmd_add70.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add70.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add70.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add70.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add70.IconColor = System.Drawing.Color.Green
        Me.Cmd_add70.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add70.IconSize = 18
        Me.Cmd_add70.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add70.Location = New System.Drawing.Point(420, 142)
        Me.Cmd_add70.Name = "Cmd_add70"
        Me.Cmd_add70.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add70.TabIndex = 101
        Me.Cmd_add70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add70.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add70.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar70
        '
        Me.Cmd_Quitar70.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar70.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar70.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar70.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar70.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar70.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar70.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar70.IconSize = 18
        Me.Cmd_Quitar70.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar70.Location = New System.Drawing.Point(394, 143)
        Me.Cmd_Quitar70.Name = "Cmd_Quitar70"
        Me.Cmd_Quitar70.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar70.TabIndex = 100
        Me.Cmd_Quitar70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar70.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar70.UseVisualStyleBackColor = True
        '
        'Cmd_add80
        '
        Me.Cmd_add80.FlatAppearance.BorderSize = 0
        Me.Cmd_add80.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add80.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add80.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add80.IconColor = System.Drawing.Color.Green
        Me.Cmd_add80.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add80.IconSize = 18
        Me.Cmd_add80.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add80.Location = New System.Drawing.Point(647, 142)
        Me.Cmd_add80.Name = "Cmd_add80"
        Me.Cmd_add80.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add80.TabIndex = 99
        Me.Cmd_add80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add80.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add80.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar80
        '
        Me.Cmd_Quitar80.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar80.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar80.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar80.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar80.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar80.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar80.IconSize = 18
        Me.Cmd_Quitar80.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar80.Location = New System.Drawing.Point(621, 143)
        Me.Cmd_Quitar80.Name = "Cmd_Quitar80"
        Me.Cmd_Quitar80.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar80.TabIndex = 98
        Me.Cmd_Quitar80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar80.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar80.UseVisualStyleBackColor = True
        '
        'Cmd_add90
        '
        Me.Cmd_add90.FlatAppearance.BorderSize = 0
        Me.Cmd_add90.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add90.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add90.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add90.IconColor = System.Drawing.Color.Green
        Me.Cmd_add90.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add90.IconSize = 18
        Me.Cmd_add90.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add90.Location = New System.Drawing.Point(877, 143)
        Me.Cmd_add90.Name = "Cmd_add90"
        Me.Cmd_add90.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add90.TabIndex = 97
        Me.Cmd_add90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add90.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add90.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar90
        '
        Me.Cmd_Quitar90.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar90.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar90.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar90.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar90.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar90.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar90.IconSize = 18
        Me.Cmd_Quitar90.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar90.Location = New System.Drawing.Point(851, 144)
        Me.Cmd_Quitar90.Name = "Cmd_Quitar90"
        Me.Cmd_Quitar90.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar90.TabIndex = 96
        Me.Cmd_Quitar90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar90.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar90.UseVisualStyleBackColor = True
        '
        'Cmd_add100
        '
        Me.Cmd_add100.FlatAppearance.BorderSize = 0
        Me.Cmd_add100.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add100.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add100.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add100.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add100.IconColor = System.Drawing.Color.Green
        Me.Cmd_add100.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add100.IconSize = 18
        Me.Cmd_add100.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add100.Location = New System.Drawing.Point(1108, 142)
        Me.Cmd_add100.Name = "Cmd_add100"
        Me.Cmd_add100.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add100.TabIndex = 95
        Me.Cmd_add100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add100.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add100.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar100
        '
        Me.Cmd_Quitar100.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar100.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar100.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar100.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar100.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar100.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar100.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar100.IconSize = 18
        Me.Cmd_Quitar100.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar100.Location = New System.Drawing.Point(1082, 143)
        Me.Cmd_Quitar100.Name = "Cmd_Quitar100"
        Me.Cmd_Quitar100.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar100.TabIndex = 94
        Me.Cmd_Quitar100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar100.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar100.UseVisualStyleBackColor = True
        '
        'Cmd_add50
        '
        Me.Cmd_add50.FlatAppearance.BorderSize = 0
        Me.Cmd_add50.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add50.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add50.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add50.IconColor = System.Drawing.Color.Green
        Me.Cmd_add50.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add50.IconSize = 18
        Me.Cmd_add50.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add50.Location = New System.Drawing.Point(1108, 5)
        Me.Cmd_add50.Name = "Cmd_add50"
        Me.Cmd_add50.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add50.TabIndex = 93
        Me.Cmd_add50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add50.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add50.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar50
        '
        Me.Cmd_Quitar50.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar50.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar50.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar50.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar50.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar50.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar50.IconSize = 18
        Me.Cmd_Quitar50.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar50.Location = New System.Drawing.Point(1082, 6)
        Me.Cmd_Quitar50.Name = "Cmd_Quitar50"
        Me.Cmd_Quitar50.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar50.TabIndex = 92
        Me.Cmd_Quitar50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar50.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar50.UseVisualStyleBackColor = True
        '
        'Cmd_add40
        '
        Me.Cmd_add40.FlatAppearance.BorderSize = 0
        Me.Cmd_add40.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add40.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add40.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add40.IconColor = System.Drawing.Color.Green
        Me.Cmd_add40.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add40.IconSize = 18
        Me.Cmd_add40.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add40.Location = New System.Drawing.Point(879, 4)
        Me.Cmd_add40.Name = "Cmd_add40"
        Me.Cmd_add40.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add40.TabIndex = 91
        Me.Cmd_add40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add40.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add40.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar40
        '
        Me.Cmd_Quitar40.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar40.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar40.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar40.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar40.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar40.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar40.IconSize = 18
        Me.Cmd_Quitar40.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar40.Location = New System.Drawing.Point(853, 5)
        Me.Cmd_Quitar40.Name = "Cmd_Quitar40"
        Me.Cmd_Quitar40.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar40.TabIndex = 90
        Me.Cmd_Quitar40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar40.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar40.UseVisualStyleBackColor = True
        '
        'Cmd_add30
        '
        Me.Cmd_add30.FlatAppearance.BorderSize = 0
        Me.Cmd_add30.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add30.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add30.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add30.IconColor = System.Drawing.Color.Green
        Me.Cmd_add30.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add30.IconSize = 18
        Me.Cmd_add30.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add30.Location = New System.Drawing.Point(645, 4)
        Me.Cmd_add30.Name = "Cmd_add30"
        Me.Cmd_add30.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add30.TabIndex = 89
        Me.Cmd_add30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add30.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add30.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar30
        '
        Me.Cmd_Quitar30.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar30.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar30.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar30.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar30.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar30.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar30.IconSize = 18
        Me.Cmd_Quitar30.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar30.Location = New System.Drawing.Point(619, 5)
        Me.Cmd_Quitar30.Name = "Cmd_Quitar30"
        Me.Cmd_Quitar30.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar30.TabIndex = 88
        Me.Cmd_Quitar30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar30.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar30.UseVisualStyleBackColor = True
        '
        'Cmd_add20
        '
        Me.Cmd_add20.FlatAppearance.BorderSize = 0
        Me.Cmd_add20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add20.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add20.IconColor = System.Drawing.Color.Green
        Me.Cmd_add20.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add20.IconSize = 18
        Me.Cmd_add20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add20.Location = New System.Drawing.Point(420, 3)
        Me.Cmd_add20.Name = "Cmd_add20"
        Me.Cmd_add20.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add20.TabIndex = 87
        Me.Cmd_add20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add20.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add20.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar20
        '
        Me.Cmd_Quitar20.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar20.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar20.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar20.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar20.IconSize = 18
        Me.Cmd_Quitar20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar20.Location = New System.Drawing.Point(394, 4)
        Me.Cmd_Quitar20.Name = "Cmd_Quitar20"
        Me.Cmd_Quitar20.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar20.TabIndex = 86
        Me.Cmd_Quitar20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar20.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar20.UseVisualStyleBackColor = True
        '
        'Cmd_add10
        '
        Me.Cmd_add10.FlatAppearance.BorderSize = 0
        Me.Cmd_add10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_add10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_add10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_add10.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.Cmd_add10.IconColor = System.Drawing.Color.Green
        Me.Cmd_add10.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_add10.IconSize = 18
        Me.Cmd_add10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add10.Location = New System.Drawing.Point(191, 3)
        Me.Cmd_add10.Name = "Cmd_add10"
        Me.Cmd_add10.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_add10.TabIndex = 85
        Me.Cmd_add10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_add10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_add10.UseVisualStyleBackColor = True
        '
        'Cmd_Quitar10
        '
        Me.Cmd_Quitar10.FlatAppearance.BorderSize = 0
        Me.Cmd_Quitar10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Quitar10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Quitar10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Quitar10.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.Cmd_Quitar10.IconColor = System.Drawing.Color.DarkRed
        Me.Cmd_Quitar10.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Quitar10.IconSize = 18
        Me.Cmd_Quitar10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar10.Location = New System.Drawing.Point(165, 4)
        Me.Cmd_Quitar10.Name = "Cmd_Quitar10"
        Me.Cmd_Quitar10.Size = New System.Drawing.Size(23, 18)
        Me.Cmd_Quitar10.TabIndex = 84
        Me.Cmd_Quitar10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Quitar10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cmd_Quitar10.UseVisualStyleBackColor = True
        '
        'LblTipo50
        '
        Me.LblTipo50.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo50.Location = New System.Drawing.Point(924, 3)
        Me.LblTipo50.Name = "LblTipo50"
        Me.LblTipo50.Size = New System.Drawing.Size(167, 16)
        Me.LblTipo50.TabIndex = 78
        Me.LblTipo50.Tag = "50"
        Me.LblTipo50.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTipo40
        '
        Me.LblTipo40.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo40.Location = New System.Drawing.Point(693, 3)
        Me.LblTipo40.Name = "LblTipo40"
        Me.LblTipo40.Size = New System.Drawing.Size(163, 16)
        Me.LblTipo40.TabIndex = 76
        Me.LblTipo40.Tag = "40"
        Me.LblTipo40.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTipo30
        '
        Me.LblTipo30.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo30.Location = New System.Drawing.Point(461, 3)
        Me.LblTipo30.Name = "LblTipo30"
        Me.LblTipo30.Size = New System.Drawing.Size(162, 16)
        Me.LblTipo30.TabIndex = 74
        Me.LblTipo30.Tag = "30"
        Me.LblTipo30.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListTipo20
        '
        Me.ListTipo20.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo20.ForeColor = System.Drawing.Color.White
        Me.ListTipo20.FormattingEnabled = True
        Me.ListTipo20.ItemHeight = 15
        Me.ListTipo20.Location = New System.Drawing.Point(238, 22)
        Me.ListTipo20.Name = "ListTipo20"
        Me.ListTipo20.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo20.TabIndex = 73
        Me.ListTipo20.Tag = "20"
        '
        'LblTipo20
        '
        Me.LblTipo20.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo20.Location = New System.Drawing.Point(236, 3)
        Me.LblTipo20.Name = "LblTipo20"
        Me.LblTipo20.Size = New System.Drawing.Size(159, 16)
        Me.LblTipo20.TabIndex = 72
        Me.LblTipo20.Tag = "20"
        Me.LblTipo20.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListTipo10
        '
        Me.ListTipo10.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListTipo10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipo10.ForeColor = System.Drawing.Color.White
        Me.ListTipo10.FormattingEnabled = True
        Me.ListTipo10.ItemHeight = 15
        Me.ListTipo10.Location = New System.Drawing.Point(6, 22)
        Me.ListTipo10.Name = "ListTipo10"
        Me.ListTipo10.Size = New System.Drawing.Size(207, 109)
        Me.ListTipo10.TabIndex = 70
        Me.ListTipo10.Tag = "10"
        '
        'LblTipo10
        '
        Me.LblTipo10.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo10.Location = New System.Drawing.Point(6, 3)
        Me.LblTipo10.Name = "LblTipo10"
        Me.LblTipo10.Size = New System.Drawing.Size(207, 16)
        Me.LblTipo10.TabIndex = 33
        Me.LblTipo10.Tag = "10"
        Me.LblTipo10.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTipo100
        '
        Me.LblTipo100.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo100.Location = New System.Drawing.Point(924, 146)
        Me.LblTipo100.Name = "LblTipo100"
        Me.LblTipo100.Size = New System.Drawing.Size(144, 12)
        Me.LblTipo100.TabIndex = 69
        Me.LblTipo100.Tag = "100"
        Me.LblTipo100.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTipo90
        '
        Me.LblTipo90.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo90.Location = New System.Drawing.Point(693, 145)
        Me.LblTipo90.Name = "LblTipo90"
        Me.LblTipo90.Size = New System.Drawing.Size(144, 12)
        Me.LblTipo90.TabIndex = 61
        Me.LblTipo90.Tag = "90"
        Me.LblTipo90.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTipo80
        '
        Me.LblTipo80.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo80.Location = New System.Drawing.Point(463, 146)
        Me.LblTipo80.Name = "LblTipo80"
        Me.LblTipo80.Size = New System.Drawing.Size(144, 12)
        Me.LblTipo80.TabIndex = 57
        Me.LblTipo80.Tag = "80"
        Me.LblTipo80.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTipo70
        '
        Me.LblTipo70.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo70.Location = New System.Drawing.Point(233, 146)
        Me.LblTipo70.Name = "LblTipo70"
        Me.LblTipo70.Size = New System.Drawing.Size(144, 12)
        Me.LblTipo70.TabIndex = 53
        Me.LblTipo70.Tag = "70"
        Me.LblTipo70.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTipo60
        '
        Me.LblTipo60.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo60.Location = New System.Drawing.Point(5, 145)
        Me.LblTipo60.Name = "LblTipo60"
        Me.LblTipo60.Size = New System.Drawing.Size(144, 12)
        Me.LblTipo60.TabIndex = 49
        Me.LblTipo60.Tag = "60"
        Me.LblTipo60.Text = "GRUPO PRODUCTOS :"
        Me.LblTipo60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Radio_Med)
        Me.Panel4.Controls.Add(Me.Radio_Otros)
        Me.Panel4.Controls.Add(Me.Radio_Serv)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1258, 29)
        Me.Panel4.TabIndex = 66
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(6, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 12)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "TIPO DE PRODUCTO :"
        '
        'Radio_Med
        '
        Me.Radio_Med.AutoSize = True
        Me.Radio_Med.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_Med.Checked = True
        Me.Radio_Med.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Radio_Med.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_Med.Location = New System.Drawing.Point(126, 4)
        Me.Radio_Med.Name = "Radio_Med"
        Me.Radio_Med.Size = New System.Drawing.Size(118, 19)
        Me.Radio_Med.TabIndex = 61
        Me.Radio_Med.TabStop = True
        Me.Radio_Med.Text = "MEDICAMENTOS"
        Me.Radio_Med.UseVisualStyleBackColor = True
        '
        'Radio_Otros
        '
        Me.Radio_Otros.AutoSize = True
        Me.Radio_Otros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_Otros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Radio_Otros.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_Otros.Location = New System.Drawing.Point(261, 4)
        Me.Radio_Otros.Name = "Radio_Otros"
        Me.Radio_Otros.Size = New System.Drawing.Size(160, 19)
        Me.Radio_Otros.TabIndex = 64
        Me.Radio_Otros.Text = "PRODUCTOS CONSUMO"
        Me.Radio_Otros.UseVisualStyleBackColor = True
        '
        'Radio_Serv
        '
        Me.Radio_Serv.AutoSize = True
        Me.Radio_Serv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_Serv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Radio_Serv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_Serv.Location = New System.Drawing.Point(438, 4)
        Me.Radio_Serv.Name = "Radio_Serv"
        Me.Radio_Serv.Size = New System.Drawing.Size(84, 19)
        Me.Radio_Serv.TabIndex = 60
        Me.Radio_Serv.Text = "SERVICIOS"
        Me.Radio_Serv.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.PanelPrecios)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.dg_grid)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1264, 331)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PRESENTACIONES / LISTA DE PRECIOS"
        '
        'PanelPrecios
        '
        Me.PanelPrecios.Controls.Add(Me.CmdTipoLista)
        Me.PanelPrecios.Controls.Add(Me.CmdTipoCosto)
        Me.PanelPrecios.Controls.Add(Me.dg_precios)
        Me.PanelPrecios.Controls.Add(Me.blb_costo_ult)
        Me.PanelPrecios.Controls.Add(Me.Label13)
        Me.PanelPrecios.Controls.Add(Me.CmdGrabaPrecios)
        Me.PanelPrecios.Controls.Add(Me.Label14)
        Me.PanelPrecios.Controls.Add(Me.LblEtiquetaPres)
        Me.PanelPrecios.Controls.Add(Me.Label15)
        Me.PanelPrecios.Controls.Add(Me.Label16)
        Me.PanelPrecios.Controls.Add(Me.CmdMoneda)
        Me.PanelPrecios.Controls.Add(Me.CmdLocalLista)
        Me.PanelPrecios.Location = New System.Drawing.Point(624, 6)
        Me.PanelPrecios.Name = "PanelPrecios"
        Me.PanelPrecios.Size = New System.Drawing.Size(633, 324)
        Me.PanelPrecios.TabIndex = 51
        '
        'CmdTipoLista
        '
        Me.CmdTipoLista.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdTipoLista.FlatAppearance.BorderSize = 0
        Me.CmdTipoLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdTipoLista.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdTipoLista.ForeColor = System.Drawing.Color.White
        Me.CmdTipoLista.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdTipoLista.IconColor = System.Drawing.Color.White
        Me.CmdTipoLista.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdTipoLista.IconSize = 18
        Me.CmdTipoLista.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdTipoLista.Location = New System.Drawing.Point(111, 29)
        Me.CmdTipoLista.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdTipoLista.Name = "CmdTipoLista"
        Me.CmdTipoLista.Size = New System.Drawing.Size(300, 21)
        Me.CmdTipoLista.TabIndex = 43
        Me.CmdTipoLista.Tag = "90"
        Me.CmdTipoLista.Text = "LISTA"
        Me.CmdTipoLista.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdTipoLista.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdTipoLista.UseVisualStyleBackColor = False
        '
        'CmdTipoCosto
        '
        Me.CmdTipoCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdTipoCosto.FlatAppearance.BorderSize = 0
        Me.CmdTipoCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdTipoCosto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdTipoCosto.ForeColor = System.Drawing.Color.White
        Me.CmdTipoCosto.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdTipoCosto.IconColor = System.Drawing.Color.White
        Me.CmdTipoCosto.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdTipoCosto.IconSize = 18
        Me.CmdTipoCosto.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdTipoCosto.Location = New System.Drawing.Point(495, 54)
        Me.CmdTipoCosto.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdTipoCosto.Name = "CmdTipoCosto"
        Me.CmdTipoCosto.Size = New System.Drawing.Size(128, 21)
        Me.CmdTipoCosto.TabIndex = 50
        Me.CmdTipoCosto.Tag = "90"
        Me.CmdTipoCosto.Text = "COSTO BASE"
        Me.CmdTipoCosto.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdTipoCosto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdTipoCosto.UseVisualStyleBackColor = False
        '
        'blb_costo_ult
        '
        Me.blb_costo_ult.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blb_costo_ult.Location = New System.Drawing.Point(401, 57)
        Me.blb_costo_ult.Name = "blb_costo_ult"
        Me.blb_costo_ult.Size = New System.Drawing.Size(89, 19)
        Me.blb_costo_ult.TabIndex = 49
        Me.blb_costo_ult.Text = "TIPO COSTO :"
        Me.blb_costo_ult.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(417, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 19)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "MONEDA :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmdGrabaPrecios
        '
        Me.CmdGrabaPrecios.FlatAppearance.BorderSize = 0
        Me.CmdGrabaPrecios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabaPrecios.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdGrabaPrecios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabaPrecios.IconChar = FontAwesome.Sharp.IconChar.Kaaba
        Me.CmdGrabaPrecios.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabaPrecios.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrabaPrecios.IconSize = 18
        Me.CmdGrabaPrecios.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdGrabaPrecios.Location = New System.Drawing.Point(238, 290)
        Me.CmdGrabaPrecios.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdGrabaPrecios.Name = "CmdGrabaPrecios"
        Me.CmdGrabaPrecios.Size = New System.Drawing.Size(153, 24)
        Me.CmdGrabaPrecios.TabIndex = 48
        Me.CmdGrabaPrecios.Tag = "30"
        Me.CmdGrabaPrecios.Text = "GUARDAR CAMBIOS          "
        Me.CmdGrabaPrecios.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdGrabaPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdGrabaPrecios.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 19)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "LOCAL :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblEtiquetaPres
        '
        Me.LblEtiquetaPres.BackColor = System.Drawing.Color.White
        Me.LblEtiquetaPres.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtiquetaPres.Location = New System.Drawing.Point(114, 60)
        Me.LblEtiquetaPres.Name = "LblEtiquetaPres"
        Me.LblEtiquetaPres.Size = New System.Drawing.Size(254, 16)
        Me.LblEtiquetaPres.TabIndex = 45
        Me.LblEtiquetaPres.Tag = "10"
        Me.LblEtiquetaPres.Text = "LISTA DE PRECIOS DISPONIBLES:"
        Me.LblEtiquetaPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 19)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "MODO LISTA PRECIO :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(111, 16)
        Me.Label16.TabIndex = 44
        Me.Label16.Tag = "10"
        Me.Label16.Text = "PRECIOS DISPONIBLES:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmdMoneda
        '
        Me.CmdMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdMoneda.FlatAppearance.BorderSize = 0
        Me.CmdMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMoneda.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdMoneda.ForeColor = System.Drawing.Color.White
        Me.CmdMoneda.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdMoneda.IconColor = System.Drawing.Color.White
        Me.CmdMoneda.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMoneda.IconSize = 18
        Me.CmdMoneda.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdMoneda.Location = New System.Drawing.Point(495, 29)
        Me.CmdMoneda.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdMoneda.Name = "CmdMoneda"
        Me.CmdMoneda.Size = New System.Drawing.Size(128, 21)
        Me.CmdMoneda.TabIndex = 41
        Me.CmdMoneda.Tag = "90"
        Me.CmdMoneda.Text = "S/ - SOLES"
        Me.CmdMoneda.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdMoneda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMoneda.UseVisualStyleBackColor = False
        '
        'CmdLocalLista
        '
        Me.CmdLocalLista.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdLocalLista.FlatAppearance.BorderSize = 0
        Me.CmdLocalLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdLocalLista.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdLocalLista.ForeColor = System.Drawing.Color.White
        Me.CmdLocalLista.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdLocalLista.IconColor = System.Drawing.Color.White
        Me.CmdLocalLista.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdLocalLista.IconSize = 18
        Me.CmdLocalLista.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdLocalLista.Location = New System.Drawing.Point(111, 6)
        Me.CmdLocalLista.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdLocalLista.Name = "CmdLocalLista"
        Me.CmdLocalLista.Size = New System.Drawing.Size(300, 21)
        Me.CmdLocalLista.TabIndex = 42
        Me.CmdLocalLista.Tag = "90"
        Me.CmdLocalLista.Text = "BOTICA 1"
        Me.CmdLocalLista.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdLocalLista.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdLocalLista.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(872, 116)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(269, 78)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "DEBE CREAR EL PRODUCTO PARA INGRESAR PRECIOS Y COSTOS DE LOS LOCALES."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(207, 16)
        Me.Label7.TabIndex = 34
        Me.Label7.Tag = "10"
        Me.Label7.Text = "PRESENTACIONES ACTIVAS :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.CmdEstado)
        Me.Panel3.Controls.Add(Me.lblEstado)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(961, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(210, 65)
        Me.Panel3.TabIndex = 41
        Me.Panel3.Tag = "09"
        '
        'CmdEstado
        '
        Me.CmdEstado.FlatAppearance.BorderSize = 0
        Me.CmdEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEstado.ForeColor = System.Drawing.Color.Black
        Me.CmdEstado.IconChar = FontAwesome.Sharp.IconChar.ToggleOn
        Me.CmdEstado.IconColor = System.Drawing.Color.Black
        Me.CmdEstado.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdEstado.IconSize = 25
        Me.CmdEstado.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdEstado.Location = New System.Drawing.Point(67, 31)
        Me.CmdEstado.Name = "CmdEstado"
        Me.CmdEstado.Size = New System.Drawing.Size(106, 27)
        Me.CmdEstado.TabIndex = 41
        Me.CmdEstado.Text = "DES ACTIVAR"
        Me.CmdEstado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEstado.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(55, 8)
        Me.lblEstado.MaxLength = 500
        Me.lblEstado.Multiline = True
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(139, 22)
        Me.lblEstado.TabIndex = 40
        Me.lblEstado.Text = "..."
        Me.lblEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 12)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "ESTADO"
        '
        'PanelLotes
        '
        Me.PanelLotes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelLotes.Controls.Add(Me.Label9)
        Me.PanelLotes.Controls.Add(Me.Label11)
        Me.PanelLotes.Controls.Add(Me.txt_diasalerta_lote)
        Me.PanelLotes.Controls.Add(Me.txt_diasprevios_lote)
        Me.PanelLotes.Location = New System.Drawing.Point(598, 78)
        Me.PanelLotes.Name = "PanelLotes"
        Me.PanelLotes.Size = New System.Drawing.Size(160, 49)
        Me.PanelLotes.TabIndex = 38
        Me.PanelLotes.Tag = "09"
        Me.PanelLotes.Visible = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 23)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "DIAS ALERTA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 25)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "DIAS NOTIFICACIÓN"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_diasalerta_lote
        '
        Me.txt_diasalerta_lote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_diasalerta_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_diasalerta_lote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diasalerta_lote.Location = New System.Drawing.Point(116, 28)
        Me.txt_diasalerta_lote.MaxLength = 500
        Me.txt_diasalerta_lote.Name = "txt_diasalerta_lote"
        Me.txt_diasalerta_lote.Size = New System.Drawing.Size(37, 16)
        Me.txt_diasalerta_lote.TabIndex = 39
        Me.txt_diasalerta_lote.Text = "00"
        '
        'txt_diasprevios_lote
        '
        Me.txt_diasprevios_lote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_diasprevios_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_diasprevios_lote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diasprevios_lote.Location = New System.Drawing.Point(116, 6)
        Me.txt_diasprevios_lote.MaxLength = 500
        Me.txt_diasprevios_lote.Name = "txt_diasprevios_lote"
        Me.txt_diasprevios_lote.Size = New System.Drawing.Size(37, 16)
        Me.txt_diasprevios_lote.TabIndex = 37
        Me.txt_diasprevios_lote.Text = "000"
        '
        'Check_es_controllotes
        '
        Me.Check_es_controllotes.AutoSize = True
        Me.Check_es_controllotes.Location = New System.Drawing.Point(598, 56)
        Me.Check_es_controllotes.Name = "Check_es_controllotes"
        Me.Check_es_controllotes.Size = New System.Drawing.Size(136, 17)
        Me.Check_es_controllotes.TabIndex = 36
        Me.Check_es_controllotes.Text = "ES CONTROL LOTES "
        Me.Check_es_controllotes.UseVisualStyleBackColor = True
        '
        'Check_es_inventariable
        '
        Me.Check_es_inventariable.AutoSize = True
        Me.Check_es_inventariable.Location = New System.Drawing.Point(759, 11)
        Me.Check_es_inventariable.Name = "Check_es_inventariable"
        Me.Check_es_inventariable.Size = New System.Drawing.Size(128, 17)
        Me.Check_es_inventariable.TabIndex = 35
        Me.Check_es_inventariable.Text = "ES INVENTARIABLE"
        Me.Check_es_inventariable.UseVisualStyleBackColor = True
        '
        'Check_exonerado
        '
        Me.Check_exonerado.AutoSize = True
        Me.Check_exonerado.Location = New System.Drawing.Point(759, 55)
        Me.Check_exonerado.Name = "Check_exonerado"
        Me.Check_exonerado.Size = New System.Drawing.Size(123, 17)
        Me.Check_exonerado.TabIndex = 34
        Me.Check_exonerado.Text = "EXONERADO 100%"
        Me.Check_exonerado.UseVisualStyleBackColor = True
        '
        'txt_ref
        '
        Me.txt_ref.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ref.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ref.Location = New System.Drawing.Point(103, 78)
        Me.txt_ref.MaxLength = 500
        Me.txt_ref.Multiline = True
        Me.txt_ref.Name = "txt_ref"
        Me.txt_ref.Size = New System.Drawing.Size(480, 49)
        Me.txt_ref.TabIndex = 33
        Me.txt_ref.Text = "8008112444711"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 25)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "DESCRIPCION DETALLE : "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_nombre
        '
        Me.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(103, 56)
        Me.txt_nombre.MaxLength = 500
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(480, 16)
        Me.txt_nombre.TabIndex = 31
        Me.txt_nombre.Text = "8008112444711"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 25)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "DESCRIPCION PRODUCTO : "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_cbarra
        '
        Me.txt_cbarra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_cbarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_cbarra.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cbarra.Location = New System.Drawing.Point(278, 32)
        Me.txt_cbarra.MaxLength = 500
        Me.txt_cbarra.Name = "txt_cbarra"
        Me.txt_cbarra.Size = New System.Drawing.Size(101, 16)
        Me.txt_cbarra.TabIndex = 29
        Me.txt_cbarra.Text = "8008112444711"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(183, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 25)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "CODIGO  BARRA : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_codigo
        '
        Me.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(103, 32)
        Me.txt_codigo.MaxLength = 500
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(101, 16)
        Me.txt_codigo.TabIndex = 27
        Me.txt_codigo.Text = "505214"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 25)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "CODIGO  PRODUCTO : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_idproducto
        '
        Me.txt_idproducto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_idproducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_idproducto.Enabled = False
        Me.txt_idproducto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_idproducto.Location = New System.Drawing.Point(103, 6)
        Me.txt_idproducto.MaxLength = 500
        Me.txt_idproducto.Name = "txt_idproducto"
        Me.txt_idproducto.Size = New System.Drawing.Size(69, 16)
        Me.txt_idproducto.TabIndex = 20
        Me.txt_idproducto.Text = "0"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 25)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "ID PRODUCTO : "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmdCodigoProd
        '
        Me.CmdCodigoProd.FlatAppearance.BorderSize = 0
        Me.CmdCodigoProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCodigoProd.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdCodigoProd.ForeColor = System.Drawing.Color.White
        Me.CmdCodigoProd.IconChar = FontAwesome.Sharp.IconChar.Archive
        Me.CmdCodigoProd.IconColor = System.Drawing.Color.White
        Me.CmdCodigoProd.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCodigoProd.IconSize = 18
        Me.CmdCodigoProd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdCodigoProd.Location = New System.Drawing.Point(117, 18)
        Me.CmdCodigoProd.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdCodigoProd.Name = "CmdCodigoProd"
        Me.CmdCodigoProd.Size = New System.Drawing.Size(115, 21)
        Me.CmdCodigoProd.TabIndex = 36
        Me.CmdCodigoProd.Tag = "200"
        Me.CmdCodigoProd.Text = "F10 CODIGO "
        Me.CmdCodigoProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCodigoProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCodigoProd.UseVisualStyleBackColor = True
        '
        'dg_precios
        '
        Me.dg_precios.AllowUserToAddRows = False
        Me.dg_precios.AllowUserToDeleteRows = False
        Me.dg_precios.AllowUserToOrderColumns = True
        Me.dg_precios.AllowUserToResizeRows = False
        Me.dg_precios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_precios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg_precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_precios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_precios.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_precios.id_local_grid = 0
        Me.dg_precios.Location = New System.Drawing.Point(8, 79)
        Me.dg_precios.MultiSelect = False
        Me.dg_precios.Name = "dg_precios"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_precios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg_precios.RowHeadersVisible = False
        Me.dg_precios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_precios.Size = New System.Drawing.Size(617, 204)
        Me.dg_precios.TabIndex = 35
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "dg_precios"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'dg_grid
        '
        Me.dg_grid.AllowUserToAddRows = False
        Me.dg_grid.AllowUserToDeleteRows = False
        Me.dg_grid.AllowUserToOrderColumns = True
        Me.dg_grid.AllowUserToResizeRows = False
        Me.dg_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_grid.DefaultCellStyle = DataGridViewCellStyle4
        Me.dg_grid.id_local_grid = 0
        Me.dg_grid.Location = New System.Drawing.Point(6, 25)
        Me.dg_grid.MultiSelect = False
        Me.dg_grid.Name = "dg_grid"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dg_grid.RowHeadersVisible = False
        Me.dg_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_grid.Size = New System.Drawing.Size(613, 294)
        Me.dg_grid.TabIndex = 16
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "dg_grid"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'CmdNombreP
        '
        Me.CmdNombreP.FlatAppearance.BorderSize = 0
        Me.CmdNombreP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdNombreP.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdNombreP.ForeColor = System.Drawing.Color.White
        Me.CmdNombreP.IconChar = FontAwesome.Sharp.IconChar.Archive
        Me.CmdNombreP.IconColor = System.Drawing.Color.White
        Me.CmdNombreP.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdNombreP.IconSize = 18
        Me.CmdNombreP.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdNombreP.Location = New System.Drawing.Point(3, 19)
        Me.CmdNombreP.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdNombreP.Name = "CmdNombreP"
        Me.CmdNombreP.Size = New System.Drawing.Size(115, 21)
        Me.CmdNombreP.TabIndex = 37
        Me.CmdNombreP.Tag = "200"
        Me.CmdNombreP.Text = "DESCRIPCION"
        Me.CmdNombreP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdNombreP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdNombreP.UseVisualStyleBackColor = True
        '
        'FrmProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1304, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelProductos)
        Me.Controls.Add(Me.PanelCentro)
        Me.Controls.Add(Me.PanelSup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.PanelBusquedas.ResumeLayout(False)
        Me.PanelCentro.ResumeLayout(False)
        Me.PanelCentro.PerformLayout()
        Me.PanelBox2.ResumeLayout(False)
        Me.PanelBox1.ResumeLayout(False)
        CType(Me.gridstock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridResul, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ayuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelProductos.ResumeLayout(False)
        Me.PanelProductos.PerformLayout()
        Me.PanelDetalleProducto.ResumeLayout(False)
        Me.tabCatalogo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.PanelPrecios.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanelLotes.ResumeLayout(False)
        Me.PanelLotes.PerformLayout()
        CType(Me.dg_precios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents LblBuscarpor As Label
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents Label12 As Label
    Friend WithEvents PanelCentro As Panel
    Friend WithEvents ToolTipBotones As ToolTip
    Friend WithEvents CmdGrupoMed As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelBusquedas As FlowLayoutPanel
    Friend WithEvents CmdLab As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdClasi As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdPrinc As FontAwesome.Sharp.IconButton
    Friend WithEvents FrmConcent As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdExcip As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdFormas As FontAwesome.Sharp.IconButton
    Friend WithEvents frmInser As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdSintomas As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdGrupoOtros As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdGrupoServ As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMarcas As FontAwesome.Sharp.IconButton
    Friend WithEvents ayuda As ErrorProvider
    Public WithEvents TxtBuscar As TextBox
    Friend WithEvents CmbPres As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtBox2 As RichTextBox
    Friend WithEvents LblProductoTit As Label
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelBox2 As Panel
    Friend WithEvents PanelBox1 As Panel
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Public WithEvents DataGridResul As DataGridView
    Friend WithEvents CmdBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelProductos As Panel
    Friend WithEvents txt_cbarra As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_codigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_idproducto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_ref As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_nombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Check_exonerado As CheckBox
    Friend WithEvents PanelLotes As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_diasalerta_lote As TextBox
    Friend WithEvents txt_diasprevios_lote As TextBox
    Friend WithEvents Check_es_controllotes As CheckBox
    Friend WithEvents Check_es_inventariable As CheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblEstado As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CmdEstado As FontAwesome.Sharp.IconButton
    Friend WithEvents Radio_Otros As RadioButton
    Friend WithEvents Label17 As Label
    Friend WithEvents Radio_Med As RadioButton
    Friend WithEvents Radio_Serv As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LblTipo10 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblTipo100 As Label
    Friend WithEvents LblTipo90 As Label
    Friend WithEvents LblTipo80 As Label
    Friend WithEvents LblTipo70 As Label
    Friend WithEvents LblTipo60 As Label
    Friend WithEvents tabCatalogo As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents CmdRegresa As FontAwesome.Sharp.IconButton
    Friend WithEvents ListTipo10 As ListBox
    Friend WithEvents ListTipo60 As ListBox
    Friend WithEvents ListTipo50 As ListBox
    Friend WithEvents LblTipo50 As Label
    Friend WithEvents ListTipo40 As ListBox
    Friend WithEvents LblTipo40 As Label
    Friend WithEvents ListTipo30 As ListBox
    Friend WithEvents LblTipo30 As Label
    Friend WithEvents ListTipo20 As ListBox
    Friend WithEvents LblTipo20 As Label
    Friend WithEvents ListTipo100 As ListBox
    Friend WithEvents ListTipo90 As ListBox
    Friend WithEvents ListTipo80 As ListBox
    Friend WithEvents ListTipo70 As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dg_grid As GridProductoMae_Plus
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Label16 As Label
    Friend WithEvents CmdTipoLista As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdLocalLista As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMoneda As FontAwesome.Sharp.IconButton
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dg_precios As GridProductoMae_Plus
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents LblEtiquetaPres As Label
    Friend WithEvents PanelDetalleProducto As Panel
    Friend WithEvents CmdGrabar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelarOper As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdGrabaPrecios As FontAwesome.Sharp.IconButton
    Friend WithEvents blb_costo_ult As Label
    Friend WithEvents CmdTipoCosto As FontAwesome.Sharp.IconButton
    Public WithEvents gridstock As DataGridView
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCrear As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add10 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar10 As FontAwesome.Sharp.IconButton
    Friend WithEvents txt_id_prod_master As TextBox
    Friend WithEvents Cmd_add60 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar60 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add70 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar70 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add80 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar80 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add90 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar90 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add100 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar100 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add50 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar50 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add40 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar40 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add30 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar30 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_add20 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd_Quitar20 As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelPrecios As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents CmdCodigoProd As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdNombreP As FontAwesome.Sharp.IconButton
End Class
Public Class GridProductoMae_Plus
    Inherits Windows.Forms.DataGridView
    Private _id_local As Integer

    Public Property id_local_grid As Integer
        Get
            Return _id_local
        End Get
        Set(value As Integer)
            _id_local = value
        End Set
    End Property
    Protected Overrides Function ProcessDialogKey(ByVal KeyData As System.Windows.Forms.Keys) As Boolean
        'dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString().ToUpper()

        If KeyData = Keys.Escape Then
            ' Stop
            '  Dim vo As String = Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value
            'Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value ' Guardar el valor original de la celda antes
            Me.CancelEdit() ' Cancelar la edición y descartar los cambios en la celda actual
            Return True ' Indicar que se ha procesado la tecla ESC
        End If
        If KeyData = Keys.Enter Then
            If Strings.Right(Me.CurrentCell.OwningColumn.HeaderText, 1) = "*" Then ' cUALQUIER vALOR
                'If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
                If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                    ' Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
                    Me.Rows.Add()
                    Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells("codigo")
                    'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."
                    Me.BeginEdit(True)

                    ' FrmOperaciones.GridProductos_PrimeraFila()
                    Return True
                Else
                    SendKeys.Send("{DOWN}")
                    Return True

                End If


            End If
            If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "F" Then
                Dim cell As DataGridViewCell = Me.CurrentCell
                Dim currentValuetext As String
                currentValuetext = CurrentCell.EditedFormattedValue
                If currentValuetext.Length = 5 Or currentValuetext.Length = 7 Then
                    Dim parts() As String = currentValuetext.Split("/"c) 'Dividir el valor en dos partes: mes y año
                    If parts.Count = 2 Then
                    Else
                        Return True
                    End If
                    If Integer.Parse(parts(0)) >= 1 And Integer.Parse(parts(0)) <= 12 Then
                    Else

                        Return True
                    End If
                    If Integer.Parse(parts(1)) >= 1900 And Integer.Parse(parts(1)) <= 3000 Then
                    ElseIf Integer.Parse(parts(1)) >= 10 And Integer.Parse(parts(1)) <= 99 Then
                        parts(1) = Val(parts(1)) + 2000
                    Else
                        Return True
                    End If
                    'Dim parts() As String = currentValuetext.Split("/"c) 'Dividir el valor en dos partes: mes y año
                    Dim month As Integer = Integer.Parse(parts(0)) 'Obtener el mes como un entero
                    Dim year As Integer = Integer.Parse(parts(1))  'Obtener el año como un entero

                    Dim lastDay As Integer = DateTime.DaysInMonth(year, month) 'Obtener el último día del mes correspondiente

                    Dim fechaCompleta As New DateTime(year, month, lastDay) 'Crear un objeto DateTime con el último día del mes
                    Dim formattedDate As String = fechaCompleta.ToString("dd/MM/yyyy") 'Convertir la fecha en formato "dd/MM/yyyy"

                    cell.Value = formattedDate 'Asignar el valor a la celda del DataGridView
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("fecha").Value = formattedDate
                Else
                    Dim inputString As String = currentValuetext
                    Dim formats As String() = {"dd/MM/yyyy", "dd/MM/yy"}
                    Dim parsedDate As DateTime
                    If DateTime.TryParseExact(inputString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
                        ' La cadena tiene formato de fecha válido
                    Else
                        Return True
                    End If
                End If
            End If

            If Me.CurrentCell.OwningColumn.Name = "cantidad" Then
                Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'cantidad'  ")
                Dim colum_destino As String = ""
                If Loc_Salto_Grid.Length = 0 Then
                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If

                If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                    colum_destino = Loc_Salto_Grid(0)("columna_des")
                    Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
                    Me.BeginEdit(True)
                Else
                    colum_destino = Loc_Salto_Grid(0)("columna_ori")
                    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex + 1).Cells(colum_destino)
                End If

                ' FrmOperaciones.GridProductos_PrimeraFila()
                Return True
            End If


            If Me.CurrentCell.OwningColumn.Name = "almacen" Then
                Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
                Dim wid_local As Integer = Me.id_local_grid

                Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_local = " & wid_local & " and alm_codigo = '" & currentValue & "'")
                ' Recorremos las filas filtradas
                If DatoAlmacen.Length = 0 Then
                    ' Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                    '                         "Local.")
                    '  CmdLocal_Click(Nothing, Nothing)
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_almacen").Value = 0
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("alm_abreviado").Value = ""
                    Return True
                End If
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_almacen").Value = DatoAlmacen(0)("id_almacen")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("alm_abreviado").Value = DatoAlmacen(0)("alm_abreviado").ToString.Trim

                'TxtComp_codigo.Text = Comprobantes(0)("codigo")
                'TxtComp_codigo.Tag = Comprobantes(0)("id_comprobante")

                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If Me.CurrentCell.OwningColumn.Name = "numerocomp" Then


                Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()


                Dim sql As String = "exec [sp_muestra_carterasn] @id_negocio, @tipo_balance, @codigo_comp ,@serie_comp, @numero_comp "
                Dim command As New SqlCommand(sql, lk_connection_cuenta)
                command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
                command.Parameters.AddWithValue("@tipo_balance", 3)
                command.Parameters.AddWithValue("@codigo_comp", Me.Rows(Me.CurrentCell.RowIndex).Cells("codcomp").Value)
                command.Parameters.AddWithValue("@serie_comp", Me.Rows(Me.CurrentCell.RowIndex).Cells("seriecomp").Value)
                command.Parameters.AddWithValue("@numero_comp", currentValue)

                Dim adapter As New SqlDataAdapter(command)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    Return True
                End If

                Me.Rows(Me.CurrentCell.RowIndex).Cells("codigo").Value = tabla.Rows(0).Item("sn_codigo").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip").Value = tabla.Rows(0).Item("sn_razonsocial").ToString.Trim
                Me.Rows(Me.CurrentCell.RowIndex).Cells("masdetalle").Value = "..." 'tabla.Rows(0).Item("Codigo").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("fechaemis").Value = Format(tabla.Rows(0).Item("fecha_emis"), "dd/MM/yyyy")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("local").Value = tabla.Rows(0).Item("local_codigo").ToString & " " & tabla.Rows(0).Item("local_abreviado").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("moneda").Value = tabla.Rows(0).Item("mod_simbolo").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("monto").Value = tabla.Rows(0).Item("total")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("saldo").Value = tabla.Rows(0).Item("saldo")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("fechavcto").Value = Format(tabla.Rows(0).Item("fecha_vcto"), "dd/MM/yyyy")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("condicion").Value = tabla.Rows(0).Item("oper_nom_tipooper")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("vendedor").Value = ""
                Me.Rows(Me.CurrentCell.RowIndex).Cells("hecho").Value = tabla.Rows(0).Item("usuario").ToString.Trim & " " & tabla.Rows(0).Item("nombres").ToString.Trim & " " & tabla.Rows(0).Item("apellidos").ToString.Trim
                Me.Rows(Me.CurrentCell.RowIndex).Cells("fechahora").Value = tabla.Rows(0).Item("fechahora").ToString.Trim

                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_oper_maestro").Value = tabla.Rows(0).Item("id_oper_maestro")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_comp_cab").Value = tabla.Rows(0).Item("id_comp_cab")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_carterasn_cab").Value = tabla.Rows(0).Item("id_carterasn_cab")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_carterasn_det").Value = tabla.Rows(0).Item("id_carterasn_det")



                'Identifica el siguiente salto 
                Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'codigo'  ")
                Dim colum_destino As String = ""
                If Loc_Salto_Grid.Length = 0 Then
                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If

                colum_destino = Loc_Salto_Grid(0)("columna_des")

                Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
                Me.BeginEdit(True)

                ' FrmOperaciones.GridProductos_PrimeraFila()
                Return True
                'SendKeys.Send(Chr(Keys.Tab))
                'Return True
            End If

            SendKeys.Send(Chr(Keys.Tab))
            Return True


            'If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
            '    ' Verificar si se ingresó un número en la primera columna antes de agregar una nueva fila
            '    Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
            '    FrmOperDetalle.GridProductos_PrimeraFila()
            '    Return True
            'End If

            'SendKeys.Send(Chr(Keys.Tab))
            'Return True

        End If


        'If KeyData = Keys.Tab Then

        '    Exit Function
        'End If



        If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "N" Then ' validar sólo para números decimales
            If KeyData >= Keys.A And KeyData <= Keys.Z Then
                Return True
            End If
            If KeyData = Keys.Add Or KeyData = Keys.Subtract Or KeyData = Keys.Multiply Or KeyData = Keys.Divide Or KeyData = Keys.OemQuestion Then
                Return True
            End If
            ' Obtener el valor actual de la celda
            Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
            Dim firstDecimalPointIndex As Integer = currentValue.IndexOf(".")
            If firstDecimalPointIndex >= 0 And KeyData = Keys.Decimal Then
                Return True
            End If
            Dim wgid As Integer = Val(Mid(Me.CurrentCell.OwningColumn.Tag, 2, Strings.Len(Me.CurrentCell.OwningColumn.Tag)))
            If wgid <> 0 Then
                Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValuetext.Length() >= wgid + 1 Then
                    Return True
                End If
            End If
        End If

        If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "E" Then ' validar sólo para números decimales
            If KeyData >= Keys.A And KeyData <= Keys.Z Then
                Return True
            End If
            If KeyData = Keys.Add Or KeyData = Keys.Subtract Or KeyData = Keys.Multiply Or KeyData = Keys.Divide Or KeyData = Keys.OemQuestion Or KeyData = Keys.Decimal Then
                Return True
            End If
            Dim wgid As Integer = Val(Mid(Me.CurrentCell.OwningColumn.Tag, 2, Strings.Len(Me.CurrentCell.OwningColumn.Tag)))
            If wgid <> 0 Then
                Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValuetext.Length() >= wgid + 1 Then
                    Return True
                End If
            End If

        End If
        If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "A" Then ' cUALQUIER vALOR

            Dim wgid As Integer = Val(Mid(Me.CurrentCell.OwningColumn.Tag, 2, Strings.Len(Me.CurrentCell.OwningColumn.Tag)))
            If wgid <> 0 Then
                Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValuetext.Length() >= wgid + 1 Then
                    Return True
                End If

            End If
        End If

        'If Me.Rows(Me.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
        '    If Me.CurrentCell.OwningColumn.Name = "codigo" Or Me.CurrentCell.OwningColumn.Name = "cantidad" Or Me.CurrentCell.OwningColumn.Name = "present" Then
        '        Return True
        '    End If
        'End If





        Return MyBase.ProcessDialogKey(KeyData)






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