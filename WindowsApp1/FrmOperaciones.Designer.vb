Imports System.Data.SqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOperaciones
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOperaciones))
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.CmdActivarEdi = New FontAwesome.Sharp.IconButton()
        Me.LinkConfImp = New System.Windows.Forms.LinkLabel()
        Me.cmdFormato = New FontAwesome.Sharp.IconButton()
        Me.CmdAanularOper = New FontAwesome.Sharp.IconButton()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmdGrabar = New FontAwesome.Sharp.IconButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CmdCancelarOper = New FontAwesome.Sharp.IconButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PanelMensajes = New System.Windows.Forms.Panel()
        Me.PanelMensajes_DER = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.link_saldo = New System.Windows.Forms.LinkLabel()
        Me.PanelMensajes_ISQ = New System.Windows.Forms.Panel()
        Me.LblNoti = New System.Windows.Forms.Label()
        Me.PanelPie = New System.Windows.Forms.Panel()
        Me.CmdCostosVinc = New FontAwesome.Sharp.IconButton()
        Me.BoxTOT10 = New System.Windows.Forms.Label()
        Me.BoxTOT5 = New System.Windows.Forms.Label()
        Me.BoxTOT9 = New System.Windows.Forms.Label()
        Me.BoxTOT4 = New System.Windows.Forms.Label()
        Me.BoxTOT8 = New System.Windows.Forms.Label()
        Me.BoxTOT3 = New System.Windows.Forms.Label()
        Me.BoxTOT6 = New System.Windows.Forms.Label()
        Me.BoxTOT1 = New System.Windows.Forms.Label()
        Me.BoxTOT7 = New System.Windows.Forms.Label()
        Me.BoxTOT2 = New System.Windows.Forms.Label()
        Me.BoxTOT12 = New System.Windows.Forms.Label()
        Me.BoxTOT11 = New System.Windows.Forms.Label()
        Me.PanelDEtalle = New System.Windows.Forms.Panel()
        Me.PanelGridDetalle = New System.Windows.Forms.Panel()
        Me.ZonaAdjuntos = New System.Windows.Forms.Panel()
        Me.ZonaMasDetalles = New System.Windows.Forms.Panel()
        Me.BoxDirEntrega = New System.Windows.Forms.Panel()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BoxContacto = New System.Windows.Forms.Panel()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContactos = New System.Windows.Forms.TextBox()
        Me.BoxTipoInterfaz = New System.Windows.Forms.Panel()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BoxDirCobro = New System.Windows.Forms.Panel()
        Me.IconButton9 = New FontAwesome.Sharp.IconButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.ZonaDetalle = New System.Windows.Forms.Panel()
        Me.BoxEstadoSN = New System.Windows.Forms.Panel()
        Me.BoxGridPROD1 = New System.Windows.Forms.Panel()
        Me.BoxModoCanculo = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkConIMPTO = New System.Windows.Forms.RadioButton()
        Me.chkSinIMPTO = New System.Windows.Forms.RadioButton()
        Me.BoxServicios = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Radio_Prod = New System.Windows.Forms.RadioButton()
        Me.Radio_Serv = New System.Windows.Forms.RadioButton()
        Me.CmdAdjuntos = New FontAwesome.Sharp.IconButton()
        Me.CmdMasDetalles = New FontAwesome.Sharp.IconButton()
        Me.CmdZonaDetalle = New FontAwesome.Sharp.IconButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PanelCentral = New System.Windows.Forms.Panel()
        Me.dg_listaoper = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelListarOper = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.IconButton5 = New FontAwesome.Sharp.IconButton()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.IconButton6 = New FontAwesome.Sharp.IconButton()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.CmdEstados = New FontAwesome.Sharp.IconButton()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.CmdOperacion_filtro = New FontAwesome.Sharp.IconButton()
        Me.Txt_Operacion_filtro = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CmdBusoper_filtro = New FontAwesome.Sharp.IconButton()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.t_fechaFin = New System.Windows.Forms.DateTimePicker()
        Me.t_fechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.CmdMuestraFiltro = New FontAwesome.Sharp.IconButton()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.CmdConsultaReg_Sig = New FontAwesome.Sharp.IconButton()
        Me.CmdConsultaReg = New FontAwesome.Sharp.IconButton()
        Me.CmdInicialNum = New FontAwesome.Sharp.IconButton()
        Me.CmdConOper = New FontAwesome.Sharp.IconButton()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.CmdOscuro = New FontAwesome.Sharp.IconButton()
        Me.LblListar = New System.Windows.Forms.Button()
        Me.LBLIniciar = New System.Windows.Forms.Button()
        Me.CmdIniciarOper = New FontAwesome.Sharp.IconButton()
        Me.CmdListaoper = New FontAwesome.Sharp.IconButton()
        Me.CmdOperacion = New FontAwesome.Sharp.IconButton()
        Me.CmdSubOper = New FontAwesome.Sharp.IconButton()
        Me.CmdTipoOper = New FontAwesome.Sharp.IconButton()
        Me.CmdAccTipo = New System.Windows.Forms.Button()
        Me.CmdAccoper = New System.Windows.Forms.Button()
        Me.CmdAccesoSuboper = New System.Windows.Forms.Button()
        Me.CmdBusoper = New FontAwesome.Sharp.IconButton()
        Me.TxtOperacion = New System.Windows.Forms.TextBox()
        Me.CmdLocal = New FontAwesome.Sharp.IconButton()
        Me.TxtLocal = New System.Windows.Forms.TextBox()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.BoxAlmTransf = New System.Windows.Forms.Panel()
        Me.CmdAlmTransf = New FontAwesome.Sharp.IconButton()
        Me.LblAlmTransf = New System.Windows.Forms.Label()
        Me.TxtAlmTransf = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.BoxLineaCredito = New System.Windows.Forms.Panel()
        Me.CmdEstado_lc = New FontAwesome.Sharp.IconButton()
        Me.lblEstado_lc = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lc_disponible = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lc_usado = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.lc_monto = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.lc_dias = New System.Windows.Forms.TextBox()
        Me.lc_actual = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.CmdOpcionesLC = New FontAwesome.Sharp.IconButton()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.BoxDocCanje = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Txt_diasletras = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Txt_canje_fecemi = New System.Windows.Forms.DateTimePicker()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Txt_canje_cuotas = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Txt_canje_monto = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Cmd_Canje_Tipos = New FontAwesome.Sharp.IconButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BoxRefComp = New System.Windows.Forms.Panel()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.tref_fecha = New System.Windows.Forms.TextBox()
        Me.tref_numero = New System.Windows.Forms.TextBox()
        Me.tref_serie = New System.Windows.Forms.TextBox()
        Me.tref_codigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BoxTienda = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BoxEstado = New System.Windows.Forms.Panel()
        Me.CmdClonarOper = New FontAwesome.Sharp.IconButton()
        Me.CmdActualizarComp = New FontAwesome.Sharp.IconButton()
        Me.CmdEnlacesComp = New FontAwesome.Sharp.IconButton()
        Me.CmdEnviarA = New FontAwesome.Sharp.IconButton()
        Me.CmdTraerDe = New FontAwesome.Sharp.IconButton()
        Me.TxtEstadoComp = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BoxGuiaAuto = New System.Windows.Forms.Panel()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BoxDocIntOper = New System.Windows.Forms.Panel()
        Me.CmdVerNumInt = New FontAwesome.Sharp.IconButton()
        Me.TxtDocOper = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TxtNumDocOper = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtSerieDocOper = New System.Windows.Forms.TextBox()
        Me.BoxVendedor = New System.Windows.Forms.Panel()
        Me.IconButton7 = New FontAwesome.Sharp.IconButton()
        Me.TxtVendedor_Codigo = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BoxSocioNego = New System.Windows.Forms.Panel()
        Me.CmdSN_inicio = New FontAwesome.Sharp.IconButton()
        Me.CmdSN_fin = New FontAwesome.Sharp.IconButton()
        Me.CmdBusca_BoxSN = New FontAwesome.Sharp.IconButton()
        Me.TxtSocio_BoxSN = New System.Windows.Forms.TextBox()
        Me.info_SN = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BoxEntidadF = New System.Windows.Forms.Panel()
        Me.CmdAccFN = New System.Windows.Forms.Button()
        Me.IconButton8 = New FontAwesome.Sharp.IconButton()
        Me.IconButton10 = New FontAwesome.Sharp.IconButton()
        Me.CmdFinanzas = New FontAwesome.Sharp.IconButton()
        Me.TxtDetallefn = New System.Windows.Forms.RichTextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.BoxCondicion = New System.Windows.Forms.Panel()
        Me.lbl_estado_lc = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txt_diaslc = New System.Windows.Forms.TextBox()
        Me.TxtCondi_FecVcto = New System.Windows.Forms.DateTimePicker()
        Me.lblEti_lc = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BoxAtencion = New System.Windows.Forms.Panel()
        Me.CmdPrioridad = New FontAwesome.Sharp.IconButton()
        Me.TxtPrioridad_FecAten = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.BoxComprobantes = New System.Windows.Forms.Panel()
        Me.CmdVerNumComp = New FontAwesome.Sharp.IconButton()
        Me.TxtComp_Numero = New System.Windows.Forms.TextBox()
        Me.TxtComp_codigo = New System.Windows.Forms.TextBox()
        Me.CmdSerireComp = New FontAwesome.Sharp.IconButton()
        Me.TxtSerireComp = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.CmdComprob = New FontAwesome.Sharp.IconButton()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.BoxFechas = New System.Windows.Forms.Panel()
        Me.TxtFechas_Emis = New System.Windows.Forms.DateTimePicker()
        Me.TxtFechas_Proc = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.BoxMoneda = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CmdMonedaComp = New FontAwesome.Sharp.IconButton()
        Me.TimeNoti = New System.Windows.Forms.Timer(Me.components)
        Me.tt_leyenda = New System.Windows.Forms.ToolTip(Me.components)
        Me.dg_cuentasn = New WindowsApp1.GridCarteraSN_Plus()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridProductos = New WindowsApp1.GridProductosPlus()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_doc_canje = New WindowsApp1.GridCanjes_Plus()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel9.SuspendLayout()
        Me.PanelMensajes.SuspendLayout()
        Me.PanelMensajes_DER.SuspendLayout()
        Me.PanelMensajes_ISQ.SuspendLayout()
        Me.PanelPie.SuspendLayout()
        Me.PanelDEtalle.SuspendLayout()
        Me.PanelGridDetalle.SuspendLayout()
        Me.ZonaMasDetalles.SuspendLayout()
        Me.BoxDirEntrega.SuspendLayout()
        Me.BoxContacto.SuspendLayout()
        Me.BoxTipoInterfaz.SuspendLayout()
        Me.BoxDirCobro.SuspendLayout()
        Me.ZonaDetalle.SuspendLayout()
        Me.BoxEstadoSN.SuspendLayout()
        Me.BoxGridPROD1.SuspendLayout()
        Me.BoxModoCanculo.SuspendLayout()
        Me.BoxServicios.SuspendLayout()
        Me.PanelCentral.SuspendLayout()
        CType(Me.dg_listaoper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelListarOper.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.PanelSup.SuspendLayout()
        Me.PanelCabecera.SuspendLayout()
        Me.BoxAlmTransf.SuspendLayout()
        Me.BoxLineaCredito.SuspendLayout()
        Me.BoxDocCanje.SuspendLayout()
        Me.BoxRefComp.SuspendLayout()
        Me.BoxTienda.SuspendLayout()
        Me.BoxEstado.SuspendLayout()
        Me.BoxGuiaAuto.SuspendLayout()
        Me.BoxDocIntOper.SuspendLayout()
        Me.BoxVendedor.SuspendLayout()
        Me.BoxSocioNego.SuspendLayout()
        Me.BoxEntidadF.SuspendLayout()
        Me.BoxCondicion.SuspendLayout()
        Me.BoxAtencion.SuspendLayout()
        Me.BoxComprobantes.SuspendLayout()
        Me.BoxFechas.SuspendLayout()
        Me.BoxMoneda.SuspendLayout()
        CType(Me.dg_cuentasn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_doc_canje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel9.Controls.Add(Me.CmdActivarEdi)
        Me.Panel9.Controls.Add(Me.LinkConfImp)
        Me.Panel9.Controls.Add(Me.cmdFormato)
        Me.Panel9.Controls.Add(Me.CmdAanularOper)
        Me.Panel9.Controls.Add(Me.Button4)
        Me.Panel9.Controls.Add(Me.CmdGrabar)
        Me.Panel9.Controls.Add(Me.Button2)
        Me.Panel9.Controls.Add(Me.CmdCancelarOper)
        Me.Panel9.Location = New System.Drawing.Point(1208, 17)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(74, 392)
        Me.Panel9.TabIndex = 3
        '
        'CmdActivarEdi
        '
        Me.CmdActivarEdi.FlatAppearance.BorderSize = 0
        Me.CmdActivarEdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdActivarEdi.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdActivarEdi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdActivarEdi.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdActivarEdi.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdActivarEdi.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdActivarEdi.IconSize = 23
        Me.CmdActivarEdi.Location = New System.Drawing.Point(7, 162)
        Me.CmdActivarEdi.Name = "CmdActivarEdi"
        Me.CmdActivarEdi.Size = New System.Drawing.Size(65, 41)
        Me.CmdActivarEdi.TabIndex = 83
        Me.CmdActivarEdi.Tag = "0"
        Me.CmdActivarEdi.Text = "&EDICION"
        Me.CmdActivarEdi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdActivarEdi.UseVisualStyleBackColor = True
        Me.CmdActivarEdi.Visible = False
        '
        'LinkConfImp
        '
        Me.LinkConfImp.ActiveLinkColor = System.Drawing.Color.Maroon
        Me.LinkConfImp.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkConfImp.LinkColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.LinkConfImp.Location = New System.Drawing.Point(6, 288)
        Me.LinkConfImp.Name = "LinkConfImp"
        Me.LinkConfImp.Size = New System.Drawing.Size(71, 26)
        Me.LinkConfImp.TabIndex = 3
        Me.LinkConfImp.TabStop = True
        Me.LinkConfImp.Text = "CONFIGURAR IMPRESION"
        Me.LinkConfImp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdFormato
        '
        Me.cmdFormato.FlatAppearance.BorderSize = 0
        Me.cmdFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFormato.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFormato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.cmdFormato.IconChar = FontAwesome.Sharp.IconChar.File
        Me.cmdFormato.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.cmdFormato.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.cmdFormato.IconSize = 20
        Me.cmdFormato.Location = New System.Drawing.Point(6, 249)
        Me.cmdFormato.Name = "cmdFormato"
        Me.cmdFormato.Size = New System.Drawing.Size(68, 39)
        Me.cmdFormato.TabIndex = 82
        Me.cmdFormato.Text = "FORMATO"
        Me.cmdFormato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdFormato.UseVisualStyleBackColor = True
        '
        'CmdAanularOper
        '
        Me.CmdAanularOper.FlatAppearance.BorderSize = 0
        Me.CmdAanularOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAanularOper.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAanularOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAanularOper.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.CmdAanularOper.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAanularOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAanularOper.IconSize = 23
        Me.CmdAanularOper.Location = New System.Drawing.Point(2, 208)
        Me.CmdAanularOper.Name = "CmdAanularOper"
        Me.CmdAanularOper.Size = New System.Drawing.Size(72, 43)
        Me.CmdAanularOper.TabIndex = 81
        Me.CmdAanularOper.Text = "ANULAR"
        Me.CmdAanularOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdAanularOper.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(15, 333)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 79
        Me.Button4.Text = "MODO """
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'CmdGrabar
        '
        Me.CmdGrabar.FlatAppearance.BorderSize = 0
        Me.CmdGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdGrabar.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdGrabar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGrabar.IconSize = 23
        Me.CmdGrabar.Location = New System.Drawing.Point(4, 4)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(64, 45)
        Me.CmdGrabar.TabIndex = 78
        Me.CmdGrabar.Text = "&ACEPTAR"
        Me.CmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(9, 321)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(74, 23)
        Me.Button2.TabIndex = 68
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'CmdCancelarOper
        '
        Me.CmdCancelarOper.FlatAppearance.BorderSize = 0
        Me.CmdCancelarOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelarOper.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelarOper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarOper.IconChar = FontAwesome.Sharp.IconChar.Eraser
        Me.CmdCancelarOper.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelarOper.IconSize = 23
        Me.CmdCancelarOper.Location = New System.Drawing.Point(1, 61)
        Me.CmdCancelarOper.Name = "CmdCancelarOper"
        Me.CmdCancelarOper.Size = New System.Drawing.Size(71, 45)
        Me.CmdCancelarOper.TabIndex = 77
        Me.CmdCancelarOper.Text = "CANCELAR"
        Me.CmdCancelarOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdCancelarOper.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1204, 149)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(71, 18)
        Me.Button3.TabIndex = 69
        Me.Button3.Text = "CONF.OPER"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PanelMensajes
        '
        Me.PanelMensajes.BackColor = System.Drawing.Color.White
        Me.PanelMensajes.Controls.Add(Me.PanelMensajes_DER)
        Me.PanelMensajes.Controls.Add(Me.PanelMensajes_ISQ)
        Me.PanelMensajes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelMensajes.Location = New System.Drawing.Point(0, 626)
        Me.PanelMensajes.Name = "PanelMensajes"
        Me.PanelMensajes.Size = New System.Drawing.Size(1277, 20)
        Me.PanelMensajes.TabIndex = 7
        '
        'PanelMensajes_DER
        '
        Me.PanelMensajes_DER.Controls.Add(Me.LinkLabel2)
        Me.PanelMensajes_DER.Controls.Add(Me.link_saldo)
        Me.PanelMensajes_DER.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelMensajes_DER.Location = New System.Drawing.Point(749, 0)
        Me.PanelMensajes_DER.Name = "PanelMensajes_DER"
        Me.PanelMensajes_DER.Size = New System.Drawing.Size(528, 20)
        Me.PanelMensajes_DER.TabIndex = 3
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.Maroon
        Me.LinkLabel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(0, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(212, 20)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "SUNAT : DECLRADO"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LinkLabel2.Visible = False
        '
        'link_saldo
        '
        Me.link_saldo.ActiveLinkColor = System.Drawing.Color.Maroon
        Me.link_saldo.Dock = System.Windows.Forms.DockStyle.Right
        Me.link_saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_saldo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.link_saldo.Location = New System.Drawing.Point(256, 0)
        Me.link_saldo.Name = "link_saldo"
        Me.link_saldo.Size = New System.Drawing.Size(272, 20)
        Me.link_saldo.TabIndex = 0
        Me.link_saldo.TabStop = True
        Me.link_saldo.Text = "SALDO COMP: S/ 1,051.25"
        Me.link_saldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelMensajes_ISQ
        '
        Me.PanelMensajes_ISQ.Controls.Add(Me.LblNoti)
        Me.PanelMensajes_ISQ.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMensajes_ISQ.Location = New System.Drawing.Point(0, 0)
        Me.PanelMensajes_ISQ.Name = "PanelMensajes_ISQ"
        Me.PanelMensajes_ISQ.Size = New System.Drawing.Size(801, 20)
        Me.PanelMensajes_ISQ.TabIndex = 2
        '
        'LblNoti
        '
        Me.LblNoti.BackColor = System.Drawing.Color.Transparent
        Me.LblNoti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblNoti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNoti.Location = New System.Drawing.Point(0, 0)
        Me.LblNoti.Name = "LblNoti"
        Me.LblNoti.Size = New System.Drawing.Size(801, 20)
        Me.LblNoti.TabIndex = 1
        Me.LblNoti.Text = "XXXXXXXXXXXXXX"
        Me.LblNoti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelPie
        '
        Me.PanelPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.PanelPie.Controls.Add(Me.CmdCostosVinc)
        Me.PanelPie.Controls.Add(Me.BoxTOT10)
        Me.PanelPie.Controls.Add(Me.BoxTOT5)
        Me.PanelPie.Controls.Add(Me.BoxTOT9)
        Me.PanelPie.Controls.Add(Me.BoxTOT4)
        Me.PanelPie.Controls.Add(Me.BoxTOT8)
        Me.PanelPie.Controls.Add(Me.BoxTOT3)
        Me.PanelPie.Controls.Add(Me.BoxTOT6)
        Me.PanelPie.Controls.Add(Me.BoxTOT1)
        Me.PanelPie.Controls.Add(Me.BoxTOT7)
        Me.PanelPie.Controls.Add(Me.BoxTOT2)
        Me.PanelPie.Controls.Add(Me.BoxTOT12)
        Me.PanelPie.Controls.Add(Me.BoxTOT11)
        Me.PanelPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelPie.Location = New System.Drawing.Point(0, 582)
        Me.PanelPie.Name = "PanelPie"
        Me.PanelPie.Size = New System.Drawing.Size(1277, 44)
        Me.PanelPie.TabIndex = 6
        '
        'CmdCostosVinc
        '
        Me.CmdCostosVinc.FlatAppearance.BorderSize = 0
        Me.CmdCostosVinc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCostosVinc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCostosVinc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdCostosVinc.IconChar = FontAwesome.Sharp.IconChar.Calculator
        Me.CmdCostosVinc.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCostosVinc.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCostosVinc.IconSize = 20
        Me.CmdCostosVinc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCostosVinc.Location = New System.Drawing.Point(140, 23)
        Me.CmdCostosVinc.Name = "CmdCostosVinc"
        Me.CmdCostosVinc.Size = New System.Drawing.Size(202, 19)
        Me.CmdCostosVinc.TabIndex = 57
        Me.CmdCostosVinc.Text = "ASIGNAR COSTOS VINCULADOS"
        Me.CmdCostosVinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCostosVinc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCostosVinc.UseVisualStyleBackColor = True
        '
        'BoxTOT10
        '
        Me.BoxTOT10.BackColor = System.Drawing.Color.White
        Me.BoxTOT10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT10.Location = New System.Drawing.Point(1152, 24)
        Me.BoxTOT10.Name = "BoxTOT10"
        Me.BoxTOT10.Size = New System.Drawing.Size(90, 17)
        Me.BoxTOT10.TabIndex = 45
        Me.BoxTOT10.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT5
        '
        Me.BoxTOT5.BackColor = System.Drawing.Color.White
        Me.BoxTOT5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT5.Location = New System.Drawing.Point(350, 23)
        Me.BoxTOT5.Name = "BoxTOT5"
        Me.BoxTOT5.Size = New System.Drawing.Size(193, 20)
        Me.BoxTOT5.TabIndex = 44
        Me.BoxTOT5.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT9
        '
        Me.BoxTOT9.BackColor = System.Drawing.Color.White
        Me.BoxTOT9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT9.Location = New System.Drawing.Point(1246, 24)
        Me.BoxTOT9.Name = "BoxTOT9"
        Me.BoxTOT9.Size = New System.Drawing.Size(94, 17)
        Me.BoxTOT9.TabIndex = 43
        Me.BoxTOT9.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT4
        '
        Me.BoxTOT4.BackColor = System.Drawing.Color.White
        Me.BoxTOT4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT4.Location = New System.Drawing.Point(753, 2)
        Me.BoxTOT4.Name = "BoxTOT4"
        Me.BoxTOT4.Size = New System.Drawing.Size(193, 20)
        Me.BoxTOT4.TabIndex = 42
        Me.BoxTOT4.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT8
        '
        Me.BoxTOT8.BackColor = System.Drawing.Color.White
        Me.BoxTOT8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT8.Location = New System.Drawing.Point(1056, 24)
        Me.BoxTOT8.Name = "BoxTOT8"
        Me.BoxTOT8.Size = New System.Drawing.Size(90, 17)
        Me.BoxTOT8.TabIndex = 41
        Me.BoxTOT8.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT3
        '
        Me.BoxTOT3.BackColor = System.Drawing.Color.White
        Me.BoxTOT3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT3.Location = New System.Drawing.Point(551, 2)
        Me.BoxTOT3.Name = "BoxTOT3"
        Me.BoxTOT3.Size = New System.Drawing.Size(193, 20)
        Me.BoxTOT3.TabIndex = 40
        Me.BoxTOT3.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT6
        '
        Me.BoxTOT6.BackColor = System.Drawing.Color.White
        Me.BoxTOT6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT6.Location = New System.Drawing.Point(1152, 2)
        Me.BoxTOT6.Name = "BoxTOT6"
        Me.BoxTOT6.Size = New System.Drawing.Size(193, 20)
        Me.BoxTOT6.TabIndex = 39
        Me.BoxTOT6.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT1
        '
        Me.BoxTOT1.BackColor = System.Drawing.Color.White
        Me.BoxTOT1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT1.Location = New System.Drawing.Point(147, 2)
        Me.BoxTOT1.Name = "BoxTOT1"
        Me.BoxTOT1.Size = New System.Drawing.Size(193, 20)
        Me.BoxTOT1.TabIndex = 38
        Me.BoxTOT1.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT7
        '
        Me.BoxTOT7.BackColor = System.Drawing.Color.White
        Me.BoxTOT7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT7.Location = New System.Drawing.Point(955, 24)
        Me.BoxTOT7.Name = "BoxTOT7"
        Me.BoxTOT7.Size = New System.Drawing.Size(97, 17)
        Me.BoxTOT7.TabIndex = 37
        Me.BoxTOT7.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT2
        '
        Me.BoxTOT2.BackColor = System.Drawing.Color.White
        Me.BoxTOT2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT2.Location = New System.Drawing.Point(349, 2)
        Me.BoxTOT2.Name = "BoxTOT2"
        Me.BoxTOT2.Size = New System.Drawing.Size(193, 20)
        Me.BoxTOT2.TabIndex = 36
        Me.BoxTOT2.Text = "TOTAL VENTA: S/ 521,005.250"
        Me.BoxTOT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxTOT12
        '
        Me.BoxTOT12.BackColor = System.Drawing.Color.White
        Me.BoxTOT12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT12.Location = New System.Drawing.Point(7, 23)
        Me.BoxTOT12.Name = "BoxTOT12"
        Me.BoxTOT12.Size = New System.Drawing.Size(130, 18)
        Me.BoxTOT12.TabIndex = 30
        Me.BoxTOT12.Text = "PESO: 1,005.250 KG"
        '
        'BoxTOT11
        '
        Me.BoxTOT11.BackColor = System.Drawing.Color.White
        Me.BoxTOT11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxTOT11.Location = New System.Drawing.Point(6, 2)
        Me.BoxTOT11.Name = "BoxTOT11"
        Me.BoxTOT11.Size = New System.Drawing.Size(130, 19)
        Me.BoxTOT11.TabIndex = 29
        Me.BoxTOT11.Text = "ITEM (105)"
        '
        'PanelDEtalle
        '
        Me.PanelDEtalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelDEtalle.Controls.Add(Me.PanelGridDetalle)
        Me.PanelDEtalle.Controls.Add(Me.BoxModoCanculo)
        Me.PanelDEtalle.Controls.Add(Me.BoxServicios)
        Me.PanelDEtalle.Controls.Add(Me.CmdAdjuntos)
        Me.PanelDEtalle.Controls.Add(Me.CmdMasDetalles)
        Me.PanelDEtalle.Controls.Add(Me.CmdZonaDetalle)
        Me.PanelDEtalle.Controls.Add(Me.Panel9)
        Me.PanelDEtalle.Controls.Add(Me.Label15)
        Me.PanelDEtalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDEtalle.Location = New System.Drawing.Point(0, 234)
        Me.PanelDEtalle.Name = "PanelDEtalle"
        Me.PanelDEtalle.Size = New System.Drawing.Size(1277, 348)
        Me.PanelDEtalle.TabIndex = 4
        '
        'PanelGridDetalle
        '
        Me.PanelGridDetalle.Controls.Add(Me.ZonaAdjuntos)
        Me.PanelGridDetalle.Controls.Add(Me.ZonaMasDetalles)
        Me.PanelGridDetalle.Controls.Add(Me.ZonaDetalle)
        Me.PanelGridDetalle.Location = New System.Drawing.Point(7, 32)
        Me.PanelGridDetalle.Name = "PanelGridDetalle"
        Me.PanelGridDetalle.Size = New System.Drawing.Size(1203, 324)
        Me.PanelGridDetalle.TabIndex = 66
        '
        'ZonaAdjuntos
        '
        Me.ZonaAdjuntos.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.ZonaAdjuntos.Location = New System.Drawing.Point(827, 254)
        Me.ZonaAdjuntos.Name = "ZonaAdjuntos"
        Me.ZonaAdjuntos.Size = New System.Drawing.Size(218, 90)
        Me.ZonaAdjuntos.TabIndex = 17
        Me.ZonaAdjuntos.Visible = False
        '
        'ZonaMasDetalles
        '
        Me.ZonaMasDetalles.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ZonaMasDetalles.Controls.Add(Me.BoxDirEntrega)
        Me.ZonaMasDetalles.Controls.Add(Me.BoxContacto)
        Me.ZonaMasDetalles.Controls.Add(Me.BoxTipoInterfaz)
        Me.ZonaMasDetalles.Controls.Add(Me.BoxDirCobro)
        Me.ZonaMasDetalles.Location = New System.Drawing.Point(489, 28)
        Me.ZonaMasDetalles.Name = "ZonaMasDetalles"
        Me.ZonaMasDetalles.Size = New System.Drawing.Size(479, 221)
        Me.ZonaMasDetalles.TabIndex = 16
        Me.ZonaMasDetalles.Visible = False
        '
        'BoxDirEntrega
        '
        Me.BoxDirEntrega.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxDirEntrega.Controls.Add(Me.IconButton1)
        Me.BoxDirEntrega.Controls.Add(Me.TextBox1)
        Me.BoxDirEntrega.Controls.Add(Me.Label2)
        Me.BoxDirEntrega.Location = New System.Drawing.Point(1, 50)
        Me.BoxDirEntrega.Name = "BoxDirEntrega"
        Me.BoxDirEntrega.Size = New System.Drawing.Size(300, 48)
        Me.BoxDirEntrega.TabIndex = 28
        Me.BoxDirEntrega.Tag = "10"
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.White
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton1.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 20
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.Location = New System.Drawing.Point(262, 8)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(31, 20)
        Me.IconButton1.TabIndex = 24
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(6, 14)
        Me.TextBox1.MaxLength = 500
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(260, 31)
        Me.TextBox1.TabIndex = 21
        Me.TextBox1.Text = "AV. JUAN PABLO SEUNDO JIRON LAS PAMAS 23514"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 12)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "DIRECCION DE ENTREGA :"
        '
        'BoxContacto
        '
        Me.BoxContacto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxContacto.Controls.Add(Me.IconButton3)
        Me.BoxContacto.Controls.Add(Me.Label3)
        Me.BoxContacto.Controls.Add(Me.txtContactos)
        Me.BoxContacto.Location = New System.Drawing.Point(1, 1)
        Me.BoxContacto.Name = "BoxContacto"
        Me.BoxContacto.Size = New System.Drawing.Size(300, 48)
        Me.BoxContacto.TabIndex = 2
        Me.BoxContacto.Tag = "03"
        '
        'IconButton3
        '
        Me.IconButton3.FlatAppearance.BorderSize = 0
        Me.IconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.White
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton3.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 20
        Me.IconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.Location = New System.Drawing.Point(262, 11)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(31, 20)
        Me.IconButton3.TabIndex = 25
        Me.IconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "CONTACTO SOCIO NEGOCIO"
        '
        'txtContactos
        '
        Me.txtContactos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContactos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactos.Location = New System.Drawing.Point(3, 15)
        Me.txtContactos.MaxLength = 500
        Me.txtContactos.Multiline = True
        Me.txtContactos.Name = "txtContactos"
        Me.txtContactos.Size = New System.Drawing.Size(259, 31)
        Me.txtContactos.TabIndex = 21
        Me.txtContactos.Text = "JUA GARCIA DE LA CRUX Y COMPAÑIA DEL VAO"
        '
        'BoxTipoInterfaz
        '
        Me.BoxTipoInterfaz.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxTipoInterfaz.Controls.Add(Me.TextBox15)
        Me.BoxTipoInterfaz.Controls.Add(Me.Label10)
        Me.BoxTipoInterfaz.Location = New System.Drawing.Point(880, 3)
        Me.BoxTipoInterfaz.Name = "BoxTipoInterfaz"
        Me.BoxTipoInterfaz.Size = New System.Drawing.Size(296, 48)
        Me.BoxTipoInterfaz.TabIndex = 29
        Me.BoxTipoInterfaz.Tag = "20"
        '
        'TextBox15
        '
        Me.TextBox15.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox15.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox15.Location = New System.Drawing.Point(6, 18)
        Me.TextBox15.MaxLength = 500
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(239, 22)
        Me.TextBox15.TabIndex = 24
        Me.TextBox15.Text = "NORMAL"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 12)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "INTERFAZ"
        '
        'BoxDirCobro
        '
        Me.BoxDirCobro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxDirCobro.Controls.Add(Me.IconButton9)
        Me.BoxDirCobro.Controls.Add(Me.Label13)
        Me.BoxDirCobro.Controls.Add(Me.TextBox13)
        Me.BoxDirCobro.Location = New System.Drawing.Point(1, 100)
        Me.BoxDirCobro.Name = "BoxDirCobro"
        Me.BoxDirCobro.Size = New System.Drawing.Size(300, 48)
        Me.BoxDirCobro.TabIndex = 25
        Me.BoxDirCobro.Tag = "17"
        '
        'IconButton9
        '
        Me.IconButton9.FlatAppearance.BorderSize = 0
        Me.IconButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton9.ForeColor = System.Drawing.Color.White
        Me.IconButton9.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton9.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton9.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton9.IconSize = 20
        Me.IconButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton9.Location = New System.Drawing.Point(266, 10)
        Me.IconButton9.Name = "IconButton9"
        Me.IconButton9.Size = New System.Drawing.Size(31, 20)
        Me.IconButton9.TabIndex = 24
        Me.IconButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton9.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 12)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "DIRECCION  DE COBRO"
        '
        'TextBox13
        '
        Me.TextBox13.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(3, 15)
        Me.TextBox13.MaxLength = 500
        Me.TextBox13.Multiline = True
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(260, 31)
        Me.TextBox13.TabIndex = 21
        Me.TextBox13.Text = "AV. JUAN PABLO SEUNDO JIRON LAS PAMAS 23514"
        '
        'ZonaDetalle
        '
        Me.ZonaDetalle.BackColor = System.Drawing.Color.Gray
        Me.ZonaDetalle.Controls.Add(Me.BoxEstadoSN)
        Me.ZonaDetalle.Controls.Add(Me.BoxGridPROD1)
        Me.ZonaDetalle.Location = New System.Drawing.Point(7, 28)
        Me.ZonaDetalle.Name = "ZonaDetalle"
        Me.ZonaDetalle.Size = New System.Drawing.Size(234, 290)
        Me.ZonaDetalle.TabIndex = 15
        Me.ZonaDetalle.Visible = False
        '
        'BoxEstadoSN
        '
        Me.BoxEstadoSN.Controls.Add(Me.dg_cuentasn)
        Me.BoxEstadoSN.Location = New System.Drawing.Point(106, 5)
        Me.BoxEstadoSN.Name = "BoxEstadoSN"
        Me.BoxEstadoSN.Size = New System.Drawing.Size(104, 130)
        Me.BoxEstadoSN.TabIndex = 15
        Me.BoxEstadoSN.Tag = "36"
        Me.BoxEstadoSN.Visible = False
        '
        'BoxGridPROD1
        '
        Me.BoxGridPROD1.Controls.Add(Me.GridProductos)
        Me.BoxGridPROD1.Location = New System.Drawing.Point(7, 5)
        Me.BoxGridPROD1.Name = "BoxGridPROD1"
        Me.BoxGridPROD1.Size = New System.Drawing.Size(79, 128)
        Me.BoxGridPROD1.TabIndex = 14
        Me.BoxGridPROD1.Tag = "30"
        Me.BoxGridPROD1.Visible = False
        '
        'BoxModoCanculo
        '
        Me.BoxModoCanculo.Controls.Add(Me.Label16)
        Me.BoxModoCanculo.Controls.Add(Me.chkConIMPTO)
        Me.BoxModoCanculo.Controls.Add(Me.chkSinIMPTO)
        Me.BoxModoCanculo.Location = New System.Drawing.Point(679, 8)
        Me.BoxModoCanculo.Name = "BoxModoCanculo"
        Me.BoxModoCanculo.Size = New System.Drawing.Size(388, 23)
        Me.BoxModoCanculo.TabIndex = 65
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(6, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 12)
        Me.Label16.TabIndex = 62
        Me.Label16.Text = "MODO DE CALCULO:"
        '
        'chkConIMPTO
        '
        Me.chkConIMPTO.AutoSize = True
        Me.chkConIMPTO.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkConIMPTO.Checked = True
        Me.chkConIMPTO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkConIMPTO.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConIMPTO.Location = New System.Drawing.Point(110, 3)
        Me.chkConIMPTO.Name = "chkConIMPTO"
        Me.chkConIMPTO.Size = New System.Drawing.Size(130, 17)
        Me.chkConIMPTO.TabIndex = 61
        Me.chkConIMPTO.TabStop = True
        Me.chkConIMPTO.Text = "VALOR CON / IMPTO."
        Me.chkConIMPTO.UseVisualStyleBackColor = True
        '
        'chkSinIMPTO
        '
        Me.chkSinIMPTO.AutoSize = True
        Me.chkSinIMPTO.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSinIMPTO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSinIMPTO.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSinIMPTO.Location = New System.Drawing.Point(250, 3)
        Me.chkSinIMPTO.Name = "chkSinIMPTO"
        Me.chkSinIMPTO.Size = New System.Drawing.Size(124, 17)
        Me.chkSinIMPTO.TabIndex = 60
        Me.chkSinIMPTO.Text = "VALOR SIN / IMPTO."
        Me.chkSinIMPTO.UseVisualStyleBackColor = True
        '
        'BoxServicios
        '
        Me.BoxServicios.Controls.Add(Me.Label17)
        Me.BoxServicios.Controls.Add(Me.Radio_Prod)
        Me.BoxServicios.Controls.Add(Me.Radio_Serv)
        Me.BoxServicios.Location = New System.Drawing.Point(345, 8)
        Me.BoxServicios.Name = "BoxServicios"
        Me.BoxServicios.Size = New System.Drawing.Size(328, 23)
        Me.BoxServicios.TabIndex = 64
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(3, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 12)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "DATOS DEL DETALLE :"
        '
        'Radio_Prod
        '
        Me.Radio_Prod.AutoSize = True
        Me.Radio_Prod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_Prod.Checked = True
        Me.Radio_Prod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Radio_Prod.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_Prod.Location = New System.Drawing.Point(123, 3)
        Me.Radio_Prod.Name = "Radio_Prod"
        Me.Radio_Prod.Size = New System.Drawing.Size(96, 19)
        Me.Radio_Prod.TabIndex = 61
        Me.Radio_Prod.TabStop = True
        Me.Radio_Prod.Text = "PRODUCTOS"
        Me.Radio_Prod.UseVisualStyleBackColor = True
        '
        'Radio_Serv
        '
        Me.Radio_Serv.AutoSize = True
        Me.Radio_Serv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_Serv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Radio_Serv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_Serv.Location = New System.Drawing.Point(226, 3)
        Me.Radio_Serv.Name = "Radio_Serv"
        Me.Radio_Serv.Size = New System.Drawing.Size(84, 19)
        Me.Radio_Serv.TabIndex = 60
        Me.Radio_Serv.Text = "SERVICIOS"
        Me.Radio_Serv.UseVisualStyleBackColor = True
        '
        'CmdAdjuntos
        '
        Me.CmdAdjuntos.FlatAppearance.BorderSize = 0
        Me.CmdAdjuntos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAdjuntos.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdAdjuntos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdAdjuntos.IconChar = FontAwesome.Sharp.IconChar.Paperclip
        Me.CmdAdjuntos.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAdjuntos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAdjuntos.IconSize = 20
        Me.CmdAdjuntos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdjuntos.Location = New System.Drawing.Point(206, 3)
        Me.CmdAdjuntos.Name = "CmdAdjuntos"
        Me.CmdAdjuntos.Size = New System.Drawing.Size(111, 24)
        Me.CmdAdjuntos.TabIndex = 57
        Me.CmdAdjuntos.Text = "ADJUNTOS"
        Me.CmdAdjuntos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdjuntos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAdjuntos.UseVisualStyleBackColor = True
        '
        'CmdMasDetalles
        '
        Me.CmdMasDetalles.FlatAppearance.BorderSize = 0
        Me.CmdMasDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMasDetalles.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdMasDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdMasDetalles.IconChar = FontAwesome.Sharp.IconChar.InfoCircle
        Me.CmdMasDetalles.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdMasDetalles.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMasDetalles.IconSize = 20
        Me.CmdMasDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMasDetalles.Location = New System.Drawing.Point(97, 3)
        Me.CmdMasDetalles.Name = "CmdMasDetalles"
        Me.CmdMasDetalles.Size = New System.Drawing.Size(111, 24)
        Me.CmdMasDetalles.TabIndex = 56
        Me.CmdMasDetalles.Text = "MAS DETALLES"
        Me.CmdMasDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMasDetalles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdMasDetalles.UseVisualStyleBackColor = True
        '
        'CmdZonaDetalle
        '
        Me.CmdZonaDetalle.FlatAppearance.BorderSize = 0
        Me.CmdZonaDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdZonaDetalle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdZonaDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdZonaDetalle.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight
        Me.CmdZonaDetalle.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdZonaDetalle.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdZonaDetalle.IconSize = 20
        Me.CmdZonaDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdZonaDetalle.Location = New System.Drawing.Point(4, 3)
        Me.CmdZonaDetalle.Name = "CmdZonaDetalle"
        Me.CmdZonaDetalle.Size = New System.Drawing.Size(96, 24)
        Me.CmdZonaDetalle.TabIndex = 55
        Me.CmdZonaDetalle.Text = "DETALLE "
        Me.CmdZonaDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdZonaDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdZonaDetalle.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(6, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(319, 13)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "____________________________________________________"
        '
        'PanelCentral
        '
        Me.PanelCentral.BackColor = System.Drawing.Color.Gray
        Me.PanelCentral.Controls.Add(Me.dg_listaoper)
        Me.PanelCentral.Controls.Add(Me.PanelListarOper)
        Me.PanelCentral.Location = New System.Drawing.Point(772, 234)
        Me.PanelCentral.Name = "PanelCentral"
        Me.PanelCentral.Size = New System.Drawing.Size(437, 290)
        Me.PanelCentral.TabIndex = 8
        '
        'dg_listaoper
        '
        Me.dg_listaoper.AllowUserToAddRows = False
        Me.dg_listaoper.AllowUserToDeleteRows = False
        Me.dg_listaoper.AllowUserToResizeRows = False
        Me.dg_listaoper.BackgroundColor = System.Drawing.Color.White
        Me.dg_listaoper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_listaoper.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_listaoper.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_listaoper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_listaoper.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo})
        Me.dg_listaoper.GridColor = System.Drawing.Color.White
        Me.dg_listaoper.Location = New System.Drawing.Point(240, 84)
        Me.dg_listaoper.MultiSelect = False
        Me.dg_listaoper.Name = "dg_listaoper"
        Me.dg_listaoper.ReadOnly = True
        Me.dg_listaoper.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_listaoper.RowHeadersVisible = False
        Me.dg_listaoper.RowTemplate.Height = 25
        Me.dg_listaoper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_listaoper.Size = New System.Drawing.Size(186, 221)
        Me.dg_listaoper.TabIndex = 2
        Me.dg_listaoper.Visible = False
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "dg_listaoper"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 80
        '
        'PanelListarOper
        '
        Me.PanelListarOper.AutoScroll = True
        Me.PanelListarOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelListarOper.Controls.Add(Me.Panel1)
        Me.PanelListarOper.Controls.Add(Me.Panel21)
        Me.PanelListarOper.Controls.Add(Me.Panel20)
        Me.PanelListarOper.Controls.Add(Me.Panel18)
        Me.PanelListarOper.Controls.Add(Me.Panel19)
        Me.PanelListarOper.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelListarOper.Location = New System.Drawing.Point(0, 0)
        Me.PanelListarOper.Name = "PanelListarOper"
        Me.PanelListarOper.Size = New System.Drawing.Size(177, 290)
        Me.PanelListarOper.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.IconButton5)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.IconButton6)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 269)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 97)
        Me.Panel1.TabIndex = 27
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(91, 46)
        Me.TextBox2.MaxLength = 500
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(47, 16)
        Me.TextBox2.TabIndex = 24
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IconButton5
        '
        Me.IconButton5.BackColor = System.Drawing.Color.Transparent
        Me.IconButton5.FlatAppearance.BorderSize = 0
        Me.IconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton5.ForeColor = System.Drawing.Color.White
        Me.IconButton5.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton5.IconColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.IconButton5.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton5.IconSize = 20
        Me.IconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton5.Location = New System.Drawing.Point(142, 46)
        Me.IconButton5.Name = "IconButton5"
        Me.IconButton5.Size = New System.Drawing.Size(22, 18)
        Me.IconButton5.TabIndex = 33
        Me.IconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton5.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(42, 22)
        Me.TextBox3.MaxLength = 500
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(98, 16)
        Me.TextBox3.TabIndex = 32
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IconButton6
        '
        Me.IconButton6.BackColor = System.Drawing.Color.Transparent
        Me.IconButton6.FlatAppearance.BorderSize = 0
        Me.IconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton6.ForeColor = System.Drawing.Color.White
        Me.IconButton6.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton6.IconColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.IconButton6.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton6.IconSize = 20
        Me.IconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton6.Location = New System.Drawing.Point(141, 22)
        Me.IconButton6.Name = "IconButton6"
        Me.IconButton6.Size = New System.Drawing.Size(22, 18)
        Me.IconButton6.TabIndex = 31
        Me.IconButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton6.UseVisualStyleBackColor = False
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(6, 22)
        Me.TextBox4.MaxLength = 500
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(33, 16)
        Me.TextBox4.TabIndex = 30
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(3, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 13)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "COMPROBANTE "
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(64, 70)
        Me.TextBox5.MaxLength = 500
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(76, 16)
        Me.TextBox5.TabIndex = 27
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(5, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 13)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "NUMERO :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(10, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 13)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "SERIE :"
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel21.Controls.Add(Me.CmdEstados)
        Me.Panel21.Controls.Add(Me.Label35)
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel21.Location = New System.Drawing.Point(0, 213)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(160, 56)
        Me.Panel21.TabIndex = 26
        '
        'CmdEstados
        '
        Me.CmdEstados.FlatAppearance.BorderSize = 0
        Me.CmdEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEstados.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEstados.ForeColor = System.Drawing.Color.White
        Me.CmdEstados.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdEstados.IconColor = System.Drawing.Color.White
        Me.CmdEstados.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdEstados.IconSize = 30
        Me.CmdEstados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdEstados.Location = New System.Drawing.Point(3, 16)
        Me.CmdEstados.Name = "CmdEstados"
        Me.CmdEstados.Size = New System.Drawing.Size(166, 34)
        Me.CmdEstados.TabIndex = 39
        Me.CmdEstados.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdEstados.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdEstados.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(3, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(136, 13)
        Me.Label35.TabIndex = 29
        Me.Label35.Text = "ESTADOS COMPROBANTE"
        '
        'Panel20
        '
        Me.Panel20.Controls.Add(Me.CmdOperacion_filtro)
        Me.Panel20.Controls.Add(Me.Txt_Operacion_filtro)
        Me.Panel20.Controls.Add(Me.Label24)
        Me.Panel20.Controls.Add(Me.CmdBusoper_filtro)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 140)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(160, 73)
        Me.Panel20.TabIndex = 3
        '
        'CmdOperacion_filtro
        '
        Me.CmdOperacion_filtro.FlatAppearance.BorderSize = 0
        Me.CmdOperacion_filtro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOperacion_filtro.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOperacion_filtro.ForeColor = System.Drawing.Color.White
        Me.CmdOperacion_filtro.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdOperacion_filtro.IconColor = System.Drawing.Color.White
        Me.CmdOperacion_filtro.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOperacion_filtro.IconSize = 30
        Me.CmdOperacion_filtro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdOperacion_filtro.Location = New System.Drawing.Point(4, 34)
        Me.CmdOperacion_filtro.Name = "CmdOperacion_filtro"
        Me.CmdOperacion_filtro.Size = New System.Drawing.Size(166, 34)
        Me.CmdOperacion_filtro.TabIndex = 38
        Me.CmdOperacion_filtro.Text = "REQUERMINETO DE COMPRA DE MERCADERIA DE SERVICIOS"
        Me.CmdOperacion_filtro.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdOperacion_filtro.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdOperacion_filtro.UseVisualStyleBackColor = True
        '
        'Txt_Operacion_filtro
        '
        Me.Txt_Operacion_filtro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_Operacion_filtro.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Operacion_filtro.Location = New System.Drawing.Point(83, 6)
        Me.Txt_Operacion_filtro.MaxLength = 4
        Me.Txt_Operacion_filtro.Name = "Txt_Operacion_filtro"
        Me.Txt_Operacion_filtro.Size = New System.Drawing.Size(49, 22)
        Me.Txt_Operacion_filtro.TabIndex = 37
        Me.Txt_Operacion_filtro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(7, 10)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 13)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "OPERACION:"
        '
        'CmdBusoper_filtro
        '
        Me.CmdBusoper_filtro.BackColor = System.Drawing.Color.Transparent
        Me.CmdBusoper_filtro.FlatAppearance.BorderSize = 0
        Me.CmdBusoper_filtro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBusoper_filtro.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBusoper_filtro.ForeColor = System.Drawing.Color.White
        Me.CmdBusoper_filtro.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdBusoper_filtro.IconColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdBusoper_filtro.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdBusoper_filtro.IconSize = 20
        Me.CmdBusoper_filtro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusoper_filtro.Location = New System.Drawing.Point(138, 3)
        Me.CmdBusoper_filtro.Name = "CmdBusoper_filtro"
        Me.CmdBusoper_filtro.Size = New System.Drawing.Size(22, 24)
        Me.CmdBusoper_filtro.TabIndex = 34
        Me.CmdBusoper_filtro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusoper_filtro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBusoper_filtro.UseVisualStyleBackColor = False
        '
        'Panel18
        '
        Me.Panel18.Controls.Add(Me.Label34)
        Me.Panel18.Controls.Add(Me.Label20)
        Me.Panel18.Controls.Add(Me.RadioButton4)
        Me.Panel18.Controls.Add(Me.RadioButton3)
        Me.Panel18.Controls.Add(Me.t_fechaFin)
        Me.Panel18.Controls.Add(Me.t_fechaIni)
        Me.Panel18.Controls.Add(Me.Label19)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel18.Location = New System.Drawing.Point(0, 32)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(160, 108)
        Me.Panel18.TabIndex = 2
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(4, 78)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(46, 13)
        Me.Label34.TabIndex = 65
        Me.Label34.Text = "HASTA :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(12, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 13)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "RANGO DE FECHAS"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RadioButton4.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton4.ForeColor = System.Drawing.Color.White
        Me.RadioButton4.Location = New System.Drawing.Point(95, 23)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(60, 16)
        Me.RadioButton4.TabIndex = 63
        Me.RadioButton4.Text = "EMISION"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RadioButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton3.ForeColor = System.Drawing.Color.White
        Me.RadioButton3.Location = New System.Drawing.Point(13, 23)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(63, 16)
        Me.RadioButton3.TabIndex = 62
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "PROCESO"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        't_fechaFin
        '
        Me.t_fechaFin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.t_fechaFin.Location = New System.Drawing.Point(53, 74)
        Me.t_fechaFin.Name = "t_fechaFin"
        Me.t_fechaFin.Size = New System.Drawing.Size(104, 23)
        Me.t_fechaFin.TabIndex = 36
        '
        't_fechaIni
        '
        Me.t_fechaIni.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.t_fechaIni.Location = New System.Drawing.Point(53, 45)
        Me.t_fechaIni.Name = "t_fechaIni"
        Me.t_fechaIni.Size = New System.Drawing.Size(104, 23)
        Me.t_fechaIni.TabIndex = 33
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(6, 49)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "DESDE :"
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.CmdMuestraFiltro)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(0, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(160, 32)
        Me.Panel19.TabIndex = 0
        '
        'CmdMuestraFiltro
        '
        Me.CmdMuestraFiltro.FlatAppearance.BorderSize = 0
        Me.CmdMuestraFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMuestraFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMuestraFiltro.ForeColor = System.Drawing.Color.White
        Me.CmdMuestraFiltro.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdMuestraFiltro.IconColor = System.Drawing.Color.White
        Me.CmdMuestraFiltro.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMuestraFiltro.IconSize = 20
        Me.CmdMuestraFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMuestraFiltro.Location = New System.Drawing.Point(35, 3)
        Me.CmdMuestraFiltro.Name = "CmdMuestraFiltro"
        Me.CmdMuestraFiltro.Size = New System.Drawing.Size(130, 24)
        Me.CmdMuestraFiltro.TabIndex = 56
        Me.CmdMuestraFiltro.Text = "MOSTRAR "
        Me.CmdMuestraFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMuestraFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMuestraFiltro.UseVisualStyleBackColor = True
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.CmdConsultaReg_Sig)
        Me.PanelSup.Controls.Add(Me.CmdConsultaReg)
        Me.PanelSup.Controls.Add(Me.CmdInicialNum)
        Me.PanelSup.Controls.Add(Me.CmdConOper)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Controls.Add(Me.CmdOscuro)
        Me.PanelSup.Controls.Add(Me.LblListar)
        Me.PanelSup.Controls.Add(Me.LBLIniciar)
        Me.PanelSup.Controls.Add(Me.CmdIniciarOper)
        Me.PanelSup.Controls.Add(Me.CmdListaoper)
        Me.PanelSup.Controls.Add(Me.CmdOperacion)
        Me.PanelSup.Controls.Add(Me.CmdSubOper)
        Me.PanelSup.Controls.Add(Me.CmdTipoOper)
        Me.PanelSup.Controls.Add(Me.CmdAccTipo)
        Me.PanelSup.Controls.Add(Me.CmdAccoper)
        Me.PanelSup.Controls.Add(Me.CmdAccesoSuboper)
        Me.PanelSup.Controls.Add(Me.CmdBusoper)
        Me.PanelSup.Controls.Add(Me.TxtOperacion)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1277, 44)
        Me.PanelSup.TabIndex = 0
        '
        'CmdConsultaReg_Sig
        '
        Me.CmdConsultaReg_Sig.FlatAppearance.BorderSize = 0
        Me.CmdConsultaReg_Sig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdConsultaReg_Sig.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdConsultaReg_Sig.ForeColor = System.Drawing.Color.White
        Me.CmdConsultaReg_Sig.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleRight
        Me.CmdConsultaReg_Sig.IconColor = System.Drawing.Color.White
        Me.CmdConsultaReg_Sig.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdConsultaReg_Sig.IconSize = 25
        Me.CmdConsultaReg_Sig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdConsultaReg_Sig.Location = New System.Drawing.Point(953, 19)
        Me.CmdConsultaReg_Sig.Name = "CmdConsultaReg_Sig"
        Me.CmdConsultaReg_Sig.Size = New System.Drawing.Size(40, 26)
        Me.CmdConsultaReg_Sig.TabIndex = 91
        Me.CmdConsultaReg_Sig.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdConsultaReg_Sig.UseVisualStyleBackColor = True
        '
        'CmdConsultaReg
        '
        Me.CmdConsultaReg.FlatAppearance.BorderSize = 0
        Me.CmdConsultaReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdConsultaReg.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdConsultaReg.ForeColor = System.Drawing.Color.White
        Me.CmdConsultaReg.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft
        Me.CmdConsultaReg.IconColor = System.Drawing.Color.White
        Me.CmdConsultaReg.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdConsultaReg.IconSize = 25
        Me.CmdConsultaReg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdConsultaReg.Location = New System.Drawing.Point(911, 19)
        Me.CmdConsultaReg.Name = "CmdConsultaReg"
        Me.CmdConsultaReg.Size = New System.Drawing.Size(40, 26)
        Me.CmdConsultaReg.TabIndex = 87
        Me.CmdConsultaReg.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdConsultaReg.UseVisualStyleBackColor = True
        '
        'CmdInicialNum
        '
        Me.CmdInicialNum.FlatAppearance.BorderSize = 0
        Me.CmdInicialNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdInicialNum.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdInicialNum.ForeColor = System.Drawing.Color.White
        Me.CmdInicialNum.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleUp
        Me.CmdInicialNum.IconColor = System.Drawing.Color.White
        Me.CmdInicialNum.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdInicialNum.IconSize = 25
        Me.CmdInicialNum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdInicialNum.Location = New System.Drawing.Point(932, 0)
        Me.CmdInicialNum.Name = "CmdInicialNum"
        Me.CmdInicialNum.Size = New System.Drawing.Size(38, 26)
        Me.CmdInicialNum.TabIndex = 92
        Me.CmdInicialNum.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdInicialNum.UseVisualStyleBackColor = True
        '
        'CmdConOper
        '
        Me.CmdConOper.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdConOper.FlatAppearance.BorderSize = 0
        Me.CmdConOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdConOper.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdConOper.ForeColor = System.Drawing.Color.White
        Me.CmdConOper.IconChar = FontAwesome.Sharp.IconChar.Cog
        Me.CmdConOper.IconColor = System.Drawing.Color.Gainsboro
        Me.CmdConOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdConOper.IconSize = 25
        Me.CmdConOper.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdConOper.Location = New System.Drawing.Point(847, 11)
        Me.CmdConOper.Name = "CmdConOper"
        Me.CmdConOper.Size = New System.Drawing.Size(29, 26)
        Me.CmdConOper.TabIndex = 90
        Me.CmdConOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdConOper.UseVisualStyleBackColor = True
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(1212, 3)
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
        Me.CmdCerrar.IconSize = 30
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(1239, -3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 28)
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
        Me.CmdMin.Location = New System.Drawing.Point(1183, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(26, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'CmdOscuro
        '
        Me.CmdOscuro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdOscuro.FlatAppearance.BorderSize = 0
        Me.CmdOscuro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOscuro.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOscuro.ForeColor = System.Drawing.Color.White
        Me.CmdOscuro.IconChar = FontAwesome.Sharp.IconChar.ToggleOn
        Me.CmdOscuro.IconColor = System.Drawing.Color.White
        Me.CmdOscuro.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOscuro.IconSize = 25
        Me.CmdOscuro.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdOscuro.Location = New System.Drawing.Point(1099, 9)
        Me.CmdOscuro.Name = "CmdOscuro"
        Me.CmdOscuro.Size = New System.Drawing.Size(75, 35)
        Me.CmdOscuro.TabIndex = 32
        Me.CmdOscuro.Text = "MODO OSCURO"
        Me.CmdOscuro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdOscuro.UseVisualStyleBackColor = True
        '
        'LblListar
        '
        Me.LblListar.FlatAppearance.BorderSize = 0
        Me.LblListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblListar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblListar.ForeColor = System.Drawing.Color.Silver
        Me.LblListar.Location = New System.Drawing.Point(16, 23)
        Me.LblListar.Name = "LblListar"
        Me.LblListar.Size = New System.Drawing.Size(53, 21)
        Me.LblListar.TabIndex = 86
        Me.LblListar.Text = "&LISTAR"
        Me.LblListar.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LblListar.UseVisualStyleBackColor = True
        '
        'LBLIniciar
        '
        Me.LBLIniciar.FlatAppearance.BorderSize = 0
        Me.LBLIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LBLIniciar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIniciar.ForeColor = System.Drawing.Color.Silver
        Me.LBLIniciar.Location = New System.Drawing.Point(16, 24)
        Me.LBLIniciar.Name = "LBLIniciar"
        Me.LBLIniciar.Size = New System.Drawing.Size(53, 21)
        Me.LBLIniciar.TabIndex = 85
        Me.LBLIniciar.Text = "&INICIAR"
        Me.LBLIniciar.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LBLIniciar.UseVisualStyleBackColor = True
        '
        'CmdIniciarOper
        '
        Me.CmdIniciarOper.FlatAppearance.BorderSize = 0
        Me.CmdIniciarOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdIniciarOper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdIniciarOper.ForeColor = System.Drawing.Color.White
        Me.CmdIniciarOper.IconChar = FontAwesome.Sharp.IconChar.CaretRight
        Me.CmdIniciarOper.IconColor = System.Drawing.Color.White
        Me.CmdIniciarOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdIniciarOper.IconSize = 30
        Me.CmdIniciarOper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdIniciarOper.Location = New System.Drawing.Point(21, 4)
        Me.CmdIniciarOper.Name = "CmdIniciarOper"
        Me.CmdIniciarOper.Size = New System.Drawing.Size(33, 25)
        Me.CmdIniciarOper.TabIndex = 84
        Me.CmdIniciarOper.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdIniciarOper.UseVisualStyleBackColor = True
        '
        'CmdListaoper
        '
        Me.CmdListaoper.FlatAppearance.BorderSize = 0
        Me.CmdListaoper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdListaoper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdListaoper.ForeColor = System.Drawing.Color.White
        Me.CmdListaoper.IconChar = FontAwesome.Sharp.IconChar.Bars
        Me.CmdListaoper.IconColor = System.Drawing.Color.White
        Me.CmdListaoper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdListaoper.IconSize = 25
        Me.CmdListaoper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdListaoper.Location = New System.Drawing.Point(23, 4)
        Me.CmdListaoper.Name = "CmdListaoper"
        Me.CmdListaoper.Size = New System.Drawing.Size(33, 24)
        Me.CmdListaoper.TabIndex = 82
        Me.CmdListaoper.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdListaoper.UseVisualStyleBackColor = True
        '
        'CmdOperacion
        '
        Me.CmdOperacion.FlatAppearance.BorderSize = 0
        Me.CmdOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOperacion.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOperacion.ForeColor = System.Drawing.Color.White
        Me.CmdOperacion.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdOperacion.IconColor = System.Drawing.Color.White
        Me.CmdOperacion.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOperacion.IconSize = 30
        Me.CmdOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdOperacion.Location = New System.Drawing.Point(158, 14)
        Me.CmdOperacion.Name = "CmdOperacion"
        Me.CmdOperacion.Size = New System.Drawing.Size(227, 32)
        Me.CmdOperacion.TabIndex = 1
        Me.CmdOperacion.Text = "REQUERMINETO DE COMPRA DE MERCADERIA DE SERVICIOS"
        Me.CmdOperacion.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdOperacion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdOperacion.UseVisualStyleBackColor = True
        '
        'CmdSubOper
        '
        Me.CmdSubOper.FlatAppearance.BorderSize = 0
        Me.CmdSubOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSubOper.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSubOper.ForeColor = System.Drawing.Color.White
        Me.CmdSubOper.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdSubOper.IconColor = System.Drawing.Color.White
        Me.CmdSubOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSubOper.IconSize = 30
        Me.CmdSubOper.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdSubOper.Location = New System.Drawing.Point(404, 14)
        Me.CmdSubOper.Name = "CmdSubOper"
        Me.CmdSubOper.Size = New System.Drawing.Size(227, 32)
        Me.CmdSubOper.TabIndex = 2
        Me.CmdSubOper.Text = "ABASTECIMIENTOS PRODUCTOS / SERVICIOS"
        Me.CmdSubOper.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdSubOper.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdSubOper.UseVisualStyleBackColor = True
        '
        'CmdTipoOper
        '
        Me.CmdTipoOper.FlatAppearance.BorderSize = 0
        Me.CmdTipoOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdTipoOper.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdTipoOper.ForeColor = System.Drawing.Color.White
        Me.CmdTipoOper.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdTipoOper.IconColor = System.Drawing.Color.White
        Me.CmdTipoOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdTipoOper.IconSize = 30
        Me.CmdTipoOper.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdTipoOper.Location = New System.Drawing.Point(647, 14)
        Me.CmdTipoOper.Name = "CmdTipoOper"
        Me.CmdTipoOper.Size = New System.Drawing.Size(227, 32)
        Me.CmdTipoOper.TabIndex = 3
        Me.CmdTipoOper.Text = "CONTADO Y CREDITO "
        Me.CmdTipoOper.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdTipoOper.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdTipoOper.UseVisualStyleBackColor = True
        '
        'CmdAccTipo
        '
        Me.CmdAccTipo.FlatAppearance.BorderSize = 0
        Me.CmdAccTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAccTipo.Font = New System.Drawing.Font("Arial Narrow", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAccTipo.ForeColor = System.Drawing.Color.Silver
        Me.CmdAccTipo.Location = New System.Drawing.Point(647, -3)
        Me.CmdAccTipo.Name = "CmdAccTipo"
        Me.CmdAccTipo.Size = New System.Drawing.Size(127, 19)
        Me.CmdAccTipo.TabIndex = 81
        Me.CmdAccTipo.Text = "(ALT+&3) TIPO OPERACION"
        Me.CmdAccTipo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdAccTipo.UseVisualStyleBackColor = True
        '
        'CmdAccoper
        '
        Me.CmdAccoper.FlatAppearance.BorderSize = 0
        Me.CmdAccoper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAccoper.Font = New System.Drawing.Font("Arial Narrow", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAccoper.ForeColor = System.Drawing.Color.Silver
        Me.CmdAccoper.Location = New System.Drawing.Point(80, -2)
        Me.CmdAccoper.Name = "CmdAccoper"
        Me.CmdAccoper.Size = New System.Drawing.Size(120, 19)
        Me.CmdAccoper.TabIndex = 80
        Me.CmdAccoper.Text = "(ALT+&1) OPERACION"
        Me.CmdAccoper.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdAccoper.UseVisualStyleBackColor = True
        '
        'CmdAccesoSuboper
        '
        Me.CmdAccesoSuboper.FlatAppearance.BorderSize = 0
        Me.CmdAccesoSuboper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAccesoSuboper.Font = New System.Drawing.Font("Arial Narrow", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAccesoSuboper.ForeColor = System.Drawing.Color.Silver
        Me.CmdAccesoSuboper.Location = New System.Drawing.Point(410, -2)
        Me.CmdAccesoSuboper.Name = "CmdAccesoSuboper"
        Me.CmdAccesoSuboper.Size = New System.Drawing.Size(120, 19)
        Me.CmdAccesoSuboper.TabIndex = 79
        Me.CmdAccesoSuboper.Text = "(ALT+&2)  SUB.OPERACION"
        Me.CmdAccesoSuboper.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdAccesoSuboper.UseVisualStyleBackColor = True
        '
        'CmdBusoper
        '
        Me.CmdBusoper.FlatAppearance.BorderSize = 0
        Me.CmdBusoper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBusoper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBusoper.ForeColor = System.Drawing.Color.White
        Me.CmdBusoper.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdBusoper.IconColor = System.Drawing.Color.White
        Me.CmdBusoper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdBusoper.IconSize = 20
        Me.CmdBusoper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusoper.Location = New System.Drawing.Point(134, 21)
        Me.CmdBusoper.Name = "CmdBusoper"
        Me.CmdBusoper.Size = New System.Drawing.Size(31, 18)
        Me.CmdBusoper.TabIndex = 22
        Me.CmdBusoper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusoper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBusoper.UseVisualStyleBackColor = True
        '
        'TxtOperacion
        '
        Me.TxtOperacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOperacion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOperacion.Location = New System.Drawing.Point(83, 19)
        Me.TxtOperacion.MaxLength = 4
        Me.TxtOperacion.Name = "TxtOperacion"
        Me.TxtOperacion.Size = New System.Drawing.Size(49, 22)
        Me.TxtOperacion.TabIndex = 0
        Me.TxtOperacion.Text = "2401"
        Me.TxtOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdLocal
        '
        Me.CmdLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdLocal.FlatAppearance.BorderSize = 0
        Me.CmdLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdLocal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLocal.ForeColor = System.Drawing.Color.White
        Me.CmdLocal.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdLocal.IconColor = System.Drawing.Color.White
        Me.CmdLocal.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdLocal.IconSize = 25
        Me.CmdLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdLocal.Location = New System.Drawing.Point(55, 18)
        Me.CmdLocal.Name = "CmdLocal"
        Me.CmdLocal.Size = New System.Drawing.Size(220, 27)
        Me.CmdLocal.TabIndex = 21
        Me.CmdLocal.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdLocal.UseVisualStyleBackColor = False
        '
        'TxtLocal
        '
        Me.TxtLocal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLocal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLocal.Location = New System.Drawing.Point(7, 19)
        Me.TxtLocal.MaxLength = 3
        Me.TxtLocal.Name = "TxtLocal"
        Me.TxtLocal.Size = New System.Drawing.Size(42, 22)
        Me.TxtLocal.TabIndex = 19
        Me.TxtLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelCabecera.Controls.Add(Me.BoxAlmTransf)
        Me.PanelCabecera.Controls.Add(Me.BoxLineaCredito)
        Me.PanelCabecera.Controls.Add(Me.BoxDocCanje)
        Me.PanelCabecera.Controls.Add(Me.BoxRefComp)
        Me.PanelCabecera.Controls.Add(Me.BoxTienda)
        Me.PanelCabecera.Controls.Add(Me.BoxEstado)
        Me.PanelCabecera.Controls.Add(Me.BoxGuiaAuto)
        Me.PanelCabecera.Controls.Add(Me.BoxDocIntOper)
        Me.PanelCabecera.Controls.Add(Me.Button3)
        Me.PanelCabecera.Controls.Add(Me.BoxVendedor)
        Me.PanelCabecera.Controls.Add(Me.BoxSocioNego)
        Me.PanelCabecera.Controls.Add(Me.BoxEntidadF)
        Me.PanelCabecera.Controls.Add(Me.BoxCondicion)
        Me.PanelCabecera.Controls.Add(Me.BoxAtencion)
        Me.PanelCabecera.Controls.Add(Me.BoxComprobantes)
        Me.PanelCabecera.Controls.Add(Me.BoxFechas)
        Me.PanelCabecera.Controls.Add(Me.BoxMoneda)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 44)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(1277, 187)
        Me.PanelCabecera.TabIndex = 1
        '
        'BoxAlmTransf
        '
        Me.BoxAlmTransf.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxAlmTransf.Controls.Add(Me.CmdAlmTransf)
        Me.BoxAlmTransf.Controls.Add(Me.LblAlmTransf)
        Me.BoxAlmTransf.Controls.Add(Me.TxtAlmTransf)
        Me.BoxAlmTransf.Controls.Add(Me.Label38)
        Me.BoxAlmTransf.Location = New System.Drawing.Point(1099, 134)
        Me.BoxAlmTransf.Name = "BoxAlmTransf"
        Me.BoxAlmTransf.Size = New System.Drawing.Size(290, 50)
        Me.BoxAlmTransf.TabIndex = 32
        Me.BoxAlmTransf.Tag = "22"
        Me.BoxAlmTransf.Visible = False
        '
        'CmdAlmTransf
        '
        Me.CmdAlmTransf.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdAlmTransf.FlatAppearance.BorderSize = 0
        Me.CmdAlmTransf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAlmTransf.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAlmTransf.ForeColor = System.Drawing.Color.White
        Me.CmdAlmTransf.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdAlmTransf.IconColor = System.Drawing.Color.White
        Me.CmdAlmTransf.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAlmTransf.IconSize = 25
        Me.CmdAlmTransf.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdAlmTransf.Location = New System.Drawing.Point(99, 18)
        Me.CmdAlmTransf.Name = "CmdAlmTransf"
        Me.CmdAlmTransf.Size = New System.Drawing.Size(177, 26)
        Me.CmdAlmTransf.TabIndex = 26
        Me.CmdAlmTransf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAlmTransf.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdAlmTransf.UseVisualStyleBackColor = False
        '
        'LblAlmTransf
        '
        Me.LblAlmTransf.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlmTransf.Location = New System.Drawing.Point(97, 1)
        Me.LblAlmTransf.Name = "LblAlmTransf"
        Me.LblAlmTransf.Size = New System.Drawing.Size(153, 13)
        Me.LblAlmTransf.TabIndex = 31
        Me.LblAlmTransf.Text = "ENVIO AL ALMACEN"
        '
        'TxtAlmTransf
        '
        Me.TxtAlmTransf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAlmTransf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAlmTransf.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAlmTransf.Location = New System.Drawing.Point(60, 20)
        Me.TxtAlmTransf.MaxLength = 500
        Me.TxtAlmTransf.Name = "TxtAlmTransf"
        Me.TxtAlmTransf.Size = New System.Drawing.Size(32, 22)
        Me.TxtAlmTransf.TabIndex = 30
        Me.TxtAlmTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(9, 17)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(70, 27)
        Me.Label38.TabIndex = 29
        Me.Label38.Text = "CODIGO ALMACEN :"
        '
        'BoxLineaCredito
        '
        Me.BoxLineaCredito.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxLineaCredito.Controls.Add(Me.CmdEstado_lc)
        Me.BoxLineaCredito.Controls.Add(Me.lblEstado_lc)
        Me.BoxLineaCredito.Controls.Add(Me.Label49)
        Me.BoxLineaCredito.Controls.Add(Me.lc_disponible)
        Me.BoxLineaCredito.Controls.Add(Me.Label45)
        Me.BoxLineaCredito.Controls.Add(Me.lc_usado)
        Me.BoxLineaCredito.Controls.Add(Me.Label43)
        Me.BoxLineaCredito.Controls.Add(Me.Label42)
        Me.BoxLineaCredito.Controls.Add(Me.Label48)
        Me.BoxLineaCredito.Controls.Add(Me.lc_monto)
        Me.BoxLineaCredito.Controls.Add(Me.Label44)
        Me.BoxLineaCredito.Controls.Add(Me.lc_dias)
        Me.BoxLineaCredito.Controls.Add(Me.lc_actual)
        Me.BoxLineaCredito.Controls.Add(Me.Label46)
        Me.BoxLineaCredito.Controls.Add(Me.CmdOpcionesLC)
        Me.BoxLineaCredito.Controls.Add(Me.Label47)
        Me.BoxLineaCredito.Location = New System.Drawing.Point(597, 122)
        Me.BoxLineaCredito.Name = "BoxLineaCredito"
        Me.BoxLineaCredito.Size = New System.Drawing.Size(605, 83)
        Me.BoxLineaCredito.TabIndex = 71
        Me.BoxLineaCredito.Tag = "38"
        Me.BoxLineaCredito.Visible = False
        '
        'CmdEstado_lc
        '
        Me.CmdEstado_lc.FlatAppearance.BorderSize = 0
        Me.CmdEstado_lc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEstado_lc.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEstado_lc.ForeColor = System.Drawing.Color.Black
        Me.CmdEstado_lc.IconChar = FontAwesome.Sharp.IconChar.ToggleOn
        Me.CmdEstado_lc.IconColor = System.Drawing.Color.Black
        Me.CmdEstado_lc.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdEstado_lc.IconSize = 25
        Me.CmdEstado_lc.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdEstado_lc.Location = New System.Drawing.Point(230, 2)
        Me.CmdEstado_lc.Name = "CmdEstado_lc"
        Me.CmdEstado_lc.Size = New System.Drawing.Size(106, 23)
        Me.CmdEstado_lc.TabIndex = 54
        Me.CmdEstado_lc.Text = "DES ACTIVAR"
        Me.CmdEstado_lc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEstado_lc.UseVisualStyleBackColor = True
        '
        'lblEstado_lc
        '
        Me.lblEstado_lc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblEstado_lc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblEstado_lc.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado_lc.Location = New System.Drawing.Point(89, 3)
        Me.lblEstado_lc.MaxLength = 500
        Me.lblEstado_lc.Multiline = True
        Me.lblEstado_lc.Name = "lblEstado_lc"
        Me.lblEstado_lc.Size = New System.Drawing.Size(136, 22)
        Me.lblEstado_lc.TabIndex = 53
        Me.lblEstado_lc.Text = "..."
        Me.lblEstado_lc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(10, 4)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(74, 25)
        Me.Label49.TabIndex = 52
        Me.Label49.Text = "ESTADO LINEA CREDITO :"
        '
        'lc_disponible
        '
        Me.lc_disponible.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lc_disponible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lc_disponible.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lc_disponible.Location = New System.Drawing.Point(486, 54)
        Me.lc_disponible.MaxLength = 500
        Me.lc_disponible.Name = "lc_disponible"
        Me.lc_disponible.Size = New System.Drawing.Size(108, 18)
        Me.lc_disponible.TabIndex = 51
        Me.lc_disponible.Text = "0.00"
        Me.lc_disponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label45.Location = New System.Drawing.Point(399, 55)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(80, 13)
        Me.Label45.TabIndex = 50
        Me.Label45.Text = "DISPONIBLE :"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lc_usado
        '
        Me.lc_usado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lc_usado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lc_usado.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lc_usado.Location = New System.Drawing.Point(485, 32)
        Me.lc_usado.MaxLength = 500
        Me.lc_usado.Name = "lc_usado"
        Me.lc_usado.Size = New System.Drawing.Size(108, 18)
        Me.lc_usado.TabIndex = 49
        Me.lc_usado.Text = "0.00"
        Me.lc_usado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(397, 33)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(83, 13)
        Me.Label43.TabIndex = 48
        Me.Label43.Text = "USADO :"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label42.Location = New System.Drawing.Point(122, 32)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(47, 13)
        Me.Label42.TabIndex = 47
        Me.Label42.Text = "MONTO"
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(175, 28)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(49, 17)
        Me.Label48.TabIndex = 45
        Me.Label48.Text = "S/"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lc_monto
        '
        Me.lc_monto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lc_monto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lc_monto.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lc_monto.Location = New System.Drawing.Point(125, 52)
        Me.lc_monto.MaxLength = 500
        Me.lc_monto.Name = "lc_monto"
        Me.lc_monto.Size = New System.Drawing.Size(99, 20)
        Me.lc_monto.TabIndex = 43
        Me.lc_monto.Text = "0.00"
        Me.lc_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(230, 30)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(115, 13)
        Me.Label44.TabIndex = 31
        Me.Label44.Text = "DIAS MAX. CREDITO :"
        '
        'lc_dias
        '
        Me.lc_dias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lc_dias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lc_dias.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lc_dias.Location = New System.Drawing.Point(233, 51)
        Me.lc_dias.MaxLength = 500
        Me.lc_dias.Name = "lc_dias"
        Me.lc_dias.Size = New System.Drawing.Size(53, 20)
        Me.lc_dias.TabIndex = 40
        Me.lc_dias.Text = "0"
        Me.lc_dias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lc_actual
        '
        Me.lc_actual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lc_actual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lc_actual.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lc_actual.Location = New System.Drawing.Point(485, 8)
        Me.lc_actual.MaxLength = 500
        Me.lc_actual.Name = "lc_actual"
        Me.lc_actual.Size = New System.Drawing.Size(108, 18)
        Me.lc_actual.TabIndex = 38
        Me.lc_actual.Text = "0.00"
        Me.lc_actual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label46.Location = New System.Drawing.Point(10, 33)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(73, 13)
        Me.Label46.TabIndex = 37
        Me.Label46.Text = "OPERACION :"
        '
        'CmdOpcionesLC
        '
        Me.CmdOpcionesLC.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdOpcionesLC.FlatAppearance.BorderSize = 0
        Me.CmdOpcionesLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOpcionesLC.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOpcionesLC.ForeColor = System.Drawing.Color.White
        Me.CmdOpcionesLC.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdOpcionesLC.IconColor = System.Drawing.Color.White
        Me.CmdOpcionesLC.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOpcionesLC.IconSize = 25
        Me.CmdOpcionesLC.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdOpcionesLC.Location = New System.Drawing.Point(13, 51)
        Me.CmdOpcionesLC.Name = "CmdOpcionesLC"
        Me.CmdOpcionesLC.Size = New System.Drawing.Size(104, 23)
        Me.CmdOpcionesLC.TabIndex = 35
        Me.CmdOpcionesLC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdOpcionesLC.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdOpcionesLC.UseVisualStyleBackColor = False
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label47.Location = New System.Drawing.Point(394, 9)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(86, 13)
        Me.Label47.TabIndex = 29
        Me.Label47.Text = "ACTUAL :"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BoxDocCanje
        '
        Me.BoxDocCanje.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxDocCanje.Controls.Add(Me.Label40)
        Me.BoxDocCanje.Controls.Add(Me.Txt_diasletras)
        Me.BoxDocCanje.Controls.Add(Me.Label36)
        Me.BoxDocCanje.Controls.Add(Me.Txt_canje_fecemi)
        Me.BoxDocCanje.Controls.Add(Me.Label41)
        Me.BoxDocCanje.Controls.Add(Me.Txt_canje_cuotas)
        Me.BoxDocCanje.Controls.Add(Me.Label39)
        Me.BoxDocCanje.Controls.Add(Me.Txt_canje_monto)
        Me.BoxDocCanje.Controls.Add(Me.Label27)
        Me.BoxDocCanje.Controls.Add(Me.Cmd_Canje_Tipos)
        Me.BoxDocCanje.Controls.Add(Me.dg_doc_canje)
        Me.BoxDocCanje.Controls.Add(Me.Label12)
        Me.BoxDocCanje.Location = New System.Drawing.Point(1076, 58)
        Me.BoxDocCanje.Name = "BoxDocCanje"
        Me.BoxDocCanje.Size = New System.Drawing.Size(899, 83)
        Me.BoxDocCanje.TabIndex = 70
        Me.BoxDocCanje.Tag = "37"
        Me.BoxDocCanje.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(202, 55)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(54, 24)
        Me.Label40.TabIndex = 44
        Me.Label40.Text = "CADA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CTOS DIAS :"
        '
        'Txt_diasletras
        '
        Me.Txt_diasletras.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_diasletras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_diasletras.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_diasletras.Location = New System.Drawing.Point(254, 57)
        Me.Txt_diasletras.MaxLength = 500
        Me.Txt_diasletras.Name = "Txt_diasletras"
        Me.Txt_diasletras.Size = New System.Drawing.Size(28, 20)
        Me.Txt_diasletras.TabIndex = 43
        Me.Txt_diasletras.Text = "30"
        Me.Txt_diasletras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(294, 7)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(76, 24)
        Me.Label36.TabIndex = 42
        Me.Label36.Text = "DETALLE DE " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LOS DOC. CANJE:"
        '
        'Txt_canje_fecemi
        '
        Me.Txt_canje_fecemi.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_canje_fecemi.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_canje_fecemi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Txt_canje_fecemi.Location = New System.Drawing.Point(86, 55)
        Me.Txt_canje_fecemi.Name = "Txt_canje_fecemi"
        Me.Txt_canje_fecemi.Size = New System.Drawing.Size(106, 22)
        Me.Txt_canje_fecemi.TabIndex = 41
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(6, 55)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(63, 24)
        Me.Label41.TabIndex = 31
        Me.Label41.Text = "FEC.EMIS " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARA CANJE  :"
        '
        'Txt_canje_cuotas
        '
        Me.Txt_canje_cuotas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_canje_cuotas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_canje_cuotas.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_canje_cuotas.Location = New System.Drawing.Point(255, 34)
        Me.Txt_canje_cuotas.MaxLength = 500
        Me.Txt_canje_cuotas.Name = "Txt_canje_cuotas"
        Me.Txt_canje_cuotas.Size = New System.Drawing.Size(28, 20)
        Me.Txt_canje_cuotas.TabIndex = 40
        Me.Txt_canje_cuotas.Text = "1"
        Me.Txt_canje_cuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(202, 29)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(43, 24)
        Me.Label39.TabIndex = 39
        Me.Label39.Text = "NRO. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CUOTAS :"
        '
        'Txt_canje_monto
        '
        Me.Txt_canje_monto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_canje_monto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_canje_monto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_canje_monto.Location = New System.Drawing.Point(87, 34)
        Me.Txt_canje_monto.MaxLength = 500
        Me.Txt_canje_monto.Name = "Txt_canje_monto"
        Me.Txt_canje_monto.Size = New System.Drawing.Size(87, 18)
        Me.Txt_canje_monto.TabIndex = 38
        Me.Txt_canje_monto.Text = "0.00"
        Me.Txt_canje_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 28)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 24)
        Me.Label27.TabIndex = 37
        Me.Label27.Text = "MONTO TOTAL " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARA CANJE :"
        '
        'Cmd_Canje_Tipos
        '
        Me.Cmd_Canje_Tipos.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd_Canje_Tipos.FlatAppearance.BorderSize = 0
        Me.Cmd_Canje_Tipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Canje_Tipos.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Canje_Tipos.ForeColor = System.Drawing.Color.White
        Me.Cmd_Canje_Tipos.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.Cmd_Canje_Tipos.IconColor = System.Drawing.Color.White
        Me.Cmd_Canje_Tipos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd_Canje_Tipos.IconSize = 25
        Me.Cmd_Canje_Tipos.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Cmd_Canje_Tipos.Location = New System.Drawing.Point(86, 3)
        Me.Cmd_Canje_Tipos.Name = "Cmd_Canje_Tipos"
        Me.Cmd_Canje_Tipos.Size = New System.Drawing.Size(198, 24)
        Me.Cmd_Canje_Tipos.TabIndex = 35
        Me.Cmd_Canje_Tipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Canje_Tipos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Cmd_Canje_Tipos.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 12)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "DOC. DE CANJE :"
        '
        'BoxRefComp
        '
        Me.BoxRefComp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxRefComp.Controls.Add(Me.Label53)
        Me.BoxRefComp.Controls.Add(Me.Label52)
        Me.BoxRefComp.Controls.Add(Me.Label51)
        Me.BoxRefComp.Controls.Add(Me.tref_fecha)
        Me.BoxRefComp.Controls.Add(Me.tref_numero)
        Me.BoxRefComp.Controls.Add(Me.tref_serie)
        Me.BoxRefComp.Controls.Add(Me.tref_codigo)
        Me.BoxRefComp.Controls.Add(Me.Label1)
        Me.BoxRefComp.Location = New System.Drawing.Point(905, 132)
        Me.BoxRefComp.Name = "BoxRefComp"
        Me.BoxRefComp.Size = New System.Drawing.Size(169, 83)
        Me.BoxRefComp.TabIndex = 39
        Me.BoxRefComp.Tag = "39"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(7, 64)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(74, 12)
        Me.Label53.TabIndex = 36
        Me.Label53.Text = "REF. FEC. COMP. :"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(6, 46)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(82, 12)
        Me.Label52.TabIndex = 35
        Me.Label52.Text = "REF. NUM.  COMP. :"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(6, 25)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(79, 12)
        Me.Label51.TabIndex = 34
        Me.Label51.Text = "REF. SERIE COMP. :"
        '
        'tref_fecha
        '
        Me.tref_fecha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_fecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tref_fecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tref_fecha.Location = New System.Drawing.Point(85, 63)
        Me.tref_fecha.MaxLength = 500
        Me.tref_fecha.Name = "tref_fecha"
        Me.tref_fecha.Size = New System.Drawing.Size(80, 16)
        Me.tref_fecha.TabIndex = 33
        Me.tref_fecha.Text = "01/01/2029"
        Me.tref_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tref_numero
        '
        Me.tref_numero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tref_numero.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tref_numero.Location = New System.Drawing.Point(85, 42)
        Me.tref_numero.MaxLength = 500
        Me.tref_numero.Name = "tref_numero"
        Me.tref_numero.Size = New System.Drawing.Size(80, 16)
        Me.tref_numero.TabIndex = 32
        Me.tref_numero.Text = "00000000"
        Me.tref_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tref_serie
        '
        Me.tref_serie.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tref_serie.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tref_serie.Location = New System.Drawing.Point(85, 22)
        Me.tref_serie.MaxLength = 500
        Me.tref_serie.Name = "tref_serie"
        Me.tref_serie.Size = New System.Drawing.Size(80, 16)
        Me.tref_serie.TabIndex = 31
        Me.tref_serie.Text = "0000"
        Me.tref_serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tref_codigo
        '
        Me.tref_codigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tref_codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tref_codigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tref_codigo.Location = New System.Drawing.Point(85, 4)
        Me.tref_codigo.MaxLength = 500
        Me.tref_codigo.Name = "tref_codigo"
        Me.tref_codigo.Size = New System.Drawing.Size(80, 16)
        Me.tref_codigo.TabIndex = 30
        Me.tref_codigo.Text = "03"
        Me.tref_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 12)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "REF. CODIGO  :"
        '
        'BoxTienda
        '
        Me.BoxTienda.AccessibleName = ""
        Me.BoxTienda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxTienda.Controls.Add(Me.Label9)
        Me.BoxTienda.Controls.Add(Me.TxtLocal)
        Me.BoxTienda.Controls.Add(Me.CmdLocal)
        Me.BoxTienda.Location = New System.Drawing.Point(2, 1)
        Me.BoxTienda.Name = "BoxTienda"
        Me.BoxTienda.Size = New System.Drawing.Size(290, 48)
        Me.BoxTienda.TabIndex = 31
        Me.BoxTienda.Tag = "01"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(9, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 12)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "CODIGO       -    DESCRIPCION LOCAL"
        '
        'BoxEstado
        '
        Me.BoxEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxEstado.Controls.Add(Me.CmdClonarOper)
        Me.BoxEstado.Controls.Add(Me.CmdActualizarComp)
        Me.BoxEstado.Controls.Add(Me.CmdEnlacesComp)
        Me.BoxEstado.Controls.Add(Me.CmdEnviarA)
        Me.BoxEstado.Controls.Add(Me.CmdTraerDe)
        Me.BoxEstado.Controls.Add(Me.TxtEstadoComp)
        Me.BoxEstado.Controls.Add(Me.Label6)
        Me.BoxEstado.Location = New System.Drawing.Point(1081, 4)
        Me.BoxEstado.Name = "BoxEstado"
        Me.BoxEstado.Size = New System.Drawing.Size(199, 99)
        Me.BoxEstado.TabIndex = 26
        Me.BoxEstado.Tag = "18"
        '
        'CmdClonarOper
        '
        Me.CmdClonarOper.FlatAppearance.BorderSize = 0
        Me.CmdClonarOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdClonarOper.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClonarOper.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CmdClonarOper.IconChar = FontAwesome.Sharp.IconChar.Copy
        Me.CmdClonarOper.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdClonarOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdClonarOper.IconSize = 18
        Me.CmdClonarOper.Location = New System.Drawing.Point(70, 78)
        Me.CmdClonarOper.Name = "CmdClonarOper"
        Me.CmdClonarOper.Size = New System.Drawing.Size(78, 20)
        Me.CmdClonarOper.TabIndex = 39
        Me.CmdClonarOper.Text = "C L O N A R"
        Me.CmdClonarOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClonarOper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdClonarOper.UseVisualStyleBackColor = True
        '
        'CmdActualizarComp
        '
        Me.CmdActualizarComp.BackColor = System.Drawing.Color.Transparent
        Me.CmdActualizarComp.FlatAppearance.BorderSize = 0
        Me.CmdActualizarComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdActualizarComp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdActualizarComp.ForeColor = System.Drawing.Color.White
        Me.CmdActualizarComp.IconChar = FontAwesome.Sharp.IconChar.DotCircle
        Me.CmdActualizarComp.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdActualizarComp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdActualizarComp.IconSize = 30
        Me.CmdActualizarComp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdActualizarComp.Location = New System.Drawing.Point(151, 3)
        Me.CmdActualizarComp.Name = "CmdActualizarComp"
        Me.CmdActualizarComp.Size = New System.Drawing.Size(30, 25)
        Me.CmdActualizarComp.TabIndex = 38
        Me.CmdActualizarComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdActualizarComp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdActualizarComp.UseVisualStyleBackColor = False
        '
        'CmdEnlacesComp
        '
        Me.CmdEnlacesComp.Enabled = False
        Me.CmdEnlacesComp.FlatAppearance.BorderSize = 0
        Me.CmdEnlacesComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEnlacesComp.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEnlacesComp.ForeColor = System.Drawing.Color.Green
        Me.CmdEnlacesComp.IconChar = FontAwesome.Sharp.IconChar.Infinity
        Me.CmdEnlacesComp.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdEnlacesComp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdEnlacesComp.IconSize = 18
        Me.CmdEnlacesComp.Location = New System.Drawing.Point(7, 55)
        Me.CmdEnlacesComp.Name = "CmdEnlacesComp"
        Me.CmdEnlacesComp.Size = New System.Drawing.Size(176, 22)
        Me.CmdEnlacesComp.TabIndex = 28
        Me.CmdEnlacesComp.Text = "ENLACES COMPROBANTES"
        Me.CmdEnlacesComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEnlacesComp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEnlacesComp.UseVisualStyleBackColor = True
        '
        'CmdEnviarA
        '
        Me.CmdEnviarA.FlatAppearance.BorderSize = 0
        Me.CmdEnviarA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEnviarA.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEnviarA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdEnviarA.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleRight
        Me.CmdEnviarA.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdEnviarA.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdEnviarA.IconSize = 20
        Me.CmdEnviarA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEnviarA.Location = New System.Drawing.Point(99, 30)
        Me.CmdEnviarA.Name = "CmdEnviarA"
        Me.CmdEnviarA.Size = New System.Drawing.Size(85, 23)
        Me.CmdEnviarA.TabIndex = 26
        Me.CmdEnviarA.Text = "ENVIAR A..."
        Me.CmdEnviarA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEnviarA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEnviarA.UseVisualStyleBackColor = True
        '
        'CmdTraerDe
        '
        Me.CmdTraerDe.FlatAppearance.BorderSize = 0
        Me.CmdTraerDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdTraerDe.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdTraerDe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdTraerDe.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleDown
        Me.CmdTraerDe.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdTraerDe.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdTraerDe.IconSize = 20
        Me.CmdTraerDe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdTraerDe.Location = New System.Drawing.Point(6, 30)
        Me.CmdTraerDe.Name = "CmdTraerDe"
        Me.CmdTraerDe.Size = New System.Drawing.Size(86, 23)
        Me.CmdTraerDe.TabIndex = 25
        Me.CmdTraerDe.Text = "TRAER DE..."
        Me.CmdTraerDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdTraerDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdTraerDe.UseVisualStyleBackColor = True
        '
        'TxtEstadoComp
        '
        Me.TxtEstadoComp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEstadoComp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEstadoComp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstadoComp.Location = New System.Drawing.Point(41, 5)
        Me.TxtEstadoComp.MaxLength = 500
        Me.TxtEstadoComp.Multiline = True
        Me.TxtEstadoComp.Name = "TxtEstadoComp"
        Me.TxtEstadoComp.Size = New System.Drawing.Size(107, 22)
        Me.TxtEstadoComp.TabIndex = 24
        Me.TxtEstadoComp.Text = "..."
        Me.TxtEstadoComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(2, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 12)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "ESTADO"
        '
        'BoxGuiaAuto
        '
        Me.BoxGuiaAuto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxGuiaAuto.Controls.Add(Me.TextBox20)
        Me.BoxGuiaAuto.Controls.Add(Me.CheckBox1)
        Me.BoxGuiaAuto.Controls.Add(Me.Label14)
        Me.BoxGuiaAuto.Location = New System.Drawing.Point(1127, 103)
        Me.BoxGuiaAuto.Name = "BoxGuiaAuto"
        Me.BoxGuiaAuto.Size = New System.Drawing.Size(165, 79)
        Me.BoxGuiaAuto.TabIndex = 30
        Me.BoxGuiaAuto.Tag = "21"
        '
        'TextBox20
        '
        Me.TextBox20.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox20.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox20.Location = New System.Drawing.Point(21, 46)
        Me.TextBox20.MaxLength = 500
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(108, 16)
        Me.TextBox20.TabIndex = 35
        Me.TextBox20.Text = "GR12-514 025551"
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(21, 23)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 17)
        Me.CheckBox1.TabIndex = 33
        Me.CheckBox1.Text = "GENERAR AUTO. "
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(25, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "GUIA DE REMISION"
        '
        'BoxDocIntOper
        '
        Me.BoxDocIntOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxDocIntOper.Controls.Add(Me.CmdVerNumInt)
        Me.BoxDocIntOper.Controls.Add(Me.TxtDocOper)
        Me.BoxDocIntOper.Controls.Add(Me.Label28)
        Me.BoxDocIntOper.Controls.Add(Me.TxtNumDocOper)
        Me.BoxDocIntOper.Controls.Add(Me.Label26)
        Me.BoxDocIntOper.Controls.Add(Me.Label25)
        Me.BoxDocIntOper.Controls.Add(Me.TxtSerieDocOper)
        Me.BoxDocIntOper.Location = New System.Drawing.Point(910, 1)
        Me.BoxDocIntOper.Name = "BoxDocIntOper"
        Me.BoxDocIntOper.Size = New System.Drawing.Size(165, 99)
        Me.BoxDocIntOper.TabIndex = 4
        Me.BoxDocIntOper.Tag = "06"
        '
        'CmdVerNumInt
        '
        Me.CmdVerNumInt.BackColor = System.Drawing.Color.Transparent
        Me.CmdVerNumInt.FlatAppearance.BorderSize = 0
        Me.CmdVerNumInt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVerNumInt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdVerNumInt.ForeColor = System.Drawing.Color.White
        Me.CmdVerNumInt.IconChar = FontAwesome.Sharp.IconChar.Eye
        Me.CmdVerNumInt.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdVerNumInt.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdVerNumInt.IconSize = 20
        Me.CmdVerNumInt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdVerNumInt.Location = New System.Drawing.Point(135, 55)
        Me.CmdVerNumInt.Name = "CmdVerNumInt"
        Me.CmdVerNumInt.Size = New System.Drawing.Size(22, 15)
        Me.CmdVerNumInt.TabIndex = 38
        Me.CmdVerNumInt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdVerNumInt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdVerNumInt.UseVisualStyleBackColor = False
        '
        'TxtDocOper
        '
        Me.TxtDocOper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDocOper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocOper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocOper.Location = New System.Drawing.Point(57, 5)
        Me.TxtDocOper.MaxLength = 500
        Me.TxtDocOper.Name = "TxtDocOper"
        Me.TxtDocOper.Size = New System.Drawing.Size(94, 16)
        Me.TxtDocOper.TabIndex = 30
        Me.TxtDocOper.Text = "REQCOM"
        Me.TxtDocOper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label28.Location = New System.Drawing.Point(2, 5)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 12)
        Me.Label28.TabIndex = 29
        Me.Label28.Text = "DOC.OPER :"
        '
        'TxtNumDocOper
        '
        Me.TxtNumDocOper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumDocOper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumDocOper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumDocOper.Location = New System.Drawing.Point(56, 56)
        Me.TxtNumDocOper.MaxLength = 500
        Me.TxtNumDocOper.Name = "TxtNumDocOper"
        Me.TxtNumDocOper.Size = New System.Drawing.Size(83, 16)
        Me.TxtNumDocOper.TabIndex = 27
        Me.TxtNumDocOper.Text = "00000001"
        Me.TxtNumDocOper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(4, 56)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 12)
        Me.Label26.TabIndex = 26
        Me.Label26.Text = "NUMERO :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(2, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 12)
        Me.Label25.TabIndex = 25
        Me.Label25.Text = "SERIE :"
        '
        'TxtSerieDocOper
        '
        Me.TxtSerieDocOper.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSerieDocOper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerieDocOper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerieDocOper.Location = New System.Drawing.Point(56, 29)
        Me.TxtSerieDocOper.MaxLength = 500
        Me.TxtSerieDocOper.Name = "TxtSerieDocOper"
        Me.TxtSerieDocOper.Size = New System.Drawing.Size(94, 16)
        Me.TxtSerieDocOper.TabIndex = 24
        Me.TxtSerieDocOper.Text = "FA01"
        Me.TxtSerieDocOper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BoxVendedor
        '
        Me.BoxVendedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxVendedor.Controls.Add(Me.IconButton7)
        Me.BoxVendedor.Controls.Add(Me.TxtVendedor_Codigo)
        Me.BoxVendedor.Controls.Add(Me.RichTextBox1)
        Me.BoxVendedor.Controls.Add(Me.Label11)
        Me.BoxVendedor.Location = New System.Drawing.Point(604, 103)
        Me.BoxVendedor.Name = "BoxVendedor"
        Me.BoxVendedor.Size = New System.Drawing.Size(300, 83)
        Me.BoxVendedor.TabIndex = 24
        Me.BoxVendedor.Tag = "14"
        '
        'IconButton7
        '
        Me.IconButton7.FlatAppearance.BorderSize = 0
        Me.IconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton7.ForeColor = System.Drawing.Color.White
        Me.IconButton7.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.IconButton7.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton7.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton7.IconSize = 20
        Me.IconButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton7.Location = New System.Drawing.Point(266, 2)
        Me.IconButton7.Name = "IconButton7"
        Me.IconButton7.Size = New System.Drawing.Size(31, 20)
        Me.IconButton7.TabIndex = 23
        Me.IconButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton7.UseVisualStyleBackColor = True
        '
        'TxtVendedor_Codigo
        '
        Me.TxtVendedor_Codigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendedor_Codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVendedor_Codigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendedor_Codigo.Location = New System.Drawing.Point(103, 5)
        Me.TxtVendedor_Codigo.MaxLength = 500
        Me.TxtVendedor_Codigo.Name = "TxtVendedor_Codigo"
        Me.TxtVendedor_Codigo.Size = New System.Drawing.Size(147, 16)
        Me.TxtVendedor_Codigo.TabIndex = 20
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 28)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(295, 47)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 12)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "VENDEDOR :"
        '
        'BoxSocioNego
        '
        Me.BoxSocioNego.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxSocioNego.Controls.Add(Me.CmdSN_inicio)
        Me.BoxSocioNego.Controls.Add(Me.CmdSN_fin)
        Me.BoxSocioNego.Controls.Add(Me.CmdBusca_BoxSN)
        Me.BoxSocioNego.Controls.Add(Me.TxtSocio_BoxSN)
        Me.BoxSocioNego.Controls.Add(Me.info_SN)
        Me.BoxSocioNego.Controls.Add(Me.Label8)
        Me.BoxSocioNego.Location = New System.Drawing.Point(295, 1)
        Me.BoxSocioNego.Name = "BoxSocioNego"
        Me.BoxSocioNego.Size = New System.Drawing.Size(300, 99)
        Me.BoxSocioNego.TabIndex = 7
        Me.BoxSocioNego.Tag = "02"
        '
        'CmdSN_inicio
        '
        Me.CmdSN_inicio.BackColor = System.Drawing.Color.White
        Me.CmdSN_inicio.FlatAppearance.BorderSize = 0
        Me.CmdSN_inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSN_inicio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSN_inicio.ForeColor = System.Drawing.Color.White
        Me.CmdSN_inicio.IconChar = FontAwesome.Sharp.IconChar.CaretUp
        Me.CmdSN_inicio.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdSN_inicio.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSN_inicio.IconSize = 20
        Me.CmdSN_inicio.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdSN_inicio.Location = New System.Drawing.Point(273, 27)
        Me.CmdSN_inicio.Name = "CmdSN_inicio"
        Me.CmdSN_inicio.Size = New System.Drawing.Size(23, 35)
        Me.CmdSN_inicio.TabIndex = 25
        Me.CmdSN_inicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSN_inicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSN_inicio.UseVisualStyleBackColor = False
        '
        'CmdSN_fin
        '
        Me.CmdSN_fin.BackColor = System.Drawing.Color.White
        Me.CmdSN_fin.FlatAppearance.BorderSize = 0
        Me.CmdSN_fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSN_fin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSN_fin.ForeColor = System.Drawing.Color.White
        Me.CmdSN_fin.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdSN_fin.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdSN_fin.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSN_fin.IconSize = 20
        Me.CmdSN_fin.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdSN_fin.Location = New System.Drawing.Point(274, 62)
        Me.CmdSN_fin.Name = "CmdSN_fin"
        Me.CmdSN_fin.Size = New System.Drawing.Size(23, 35)
        Me.CmdSN_fin.TabIndex = 24
        Me.CmdSN_fin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSN_fin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSN_fin.UseVisualStyleBackColor = False
        '
        'CmdBusca_BoxSN
        '
        Me.CmdBusca_BoxSN.FlatAppearance.BorderSize = 0
        Me.CmdBusca_BoxSN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBusca_BoxSN.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBusca_BoxSN.ForeColor = System.Drawing.Color.White
        Me.CmdBusca_BoxSN.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdBusca_BoxSN.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
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
        Me.TxtSocio_BoxSN.TabIndex = 20
        '
        'info_SN
        '
        Me.info_SN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.info_SN.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_SN.Location = New System.Drawing.Point(5, 28)
        Me.info_SN.Name = "info_SN"
        Me.info_SN.Size = New System.Drawing.Size(291, 65)
        Me.info_SN.TabIndex = 1
        Me.info_SN.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "SOCIO NEGOCIO :"
        '
        'BoxEntidadF
        '
        Me.BoxEntidadF.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxEntidadF.Controls.Add(Me.CmdAccFN)
        Me.BoxEntidadF.Controls.Add(Me.IconButton8)
        Me.BoxEntidadF.Controls.Add(Me.IconButton10)
        Me.BoxEntidadF.Controls.Add(Me.CmdFinanzas)
        Me.BoxEntidadF.Controls.Add(Me.TxtDetallefn)
        Me.BoxEntidadF.Controls.Add(Me.Label37)
        Me.BoxEntidadF.Location = New System.Drawing.Point(600, 1)
        Me.BoxEntidadF.Name = "BoxEntidadF"
        Me.BoxEntidadF.Size = New System.Drawing.Size(300, 99)
        Me.BoxEntidadF.TabIndex = 28
        Me.BoxEntidadF.Tag = "12"
        '
        'CmdAccFN
        '
        Me.CmdAccFN.FlatAppearance.BorderSize = 0
        Me.CmdAccFN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAccFN.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAccFN.ForeColor = System.Drawing.Color.Black
        Me.CmdAccFN.Location = New System.Drawing.Point(213, 1)
        Me.CmdAccFN.Name = "CmdAccFN"
        Me.CmdAccFN.Size = New System.Drawing.Size(53, 22)
        Me.CmdAccFN.TabIndex = 82
        Me.CmdAccFN.Text = "(ALT+ &F)"
        Me.CmdAccFN.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdAccFN.UseVisualStyleBackColor = True
        '
        'IconButton8
        '
        Me.IconButton8.BackColor = System.Drawing.Color.White
        Me.IconButton8.FlatAppearance.BorderSize = 0
        Me.IconButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton8.ForeColor = System.Drawing.Color.White
        Me.IconButton8.IconChar = FontAwesome.Sharp.IconChar.CaretUp
        Me.IconButton8.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton8.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton8.IconSize = 20
        Me.IconButton8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton8.Location = New System.Drawing.Point(271, 30)
        Me.IconButton8.Name = "IconButton8"
        Me.IconButton8.Size = New System.Drawing.Size(23, 32)
        Me.IconButton8.TabIndex = 27
        Me.IconButton8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton8.UseVisualStyleBackColor = False
        '
        'IconButton10
        '
        Me.IconButton10.BackColor = System.Drawing.Color.White
        Me.IconButton10.FlatAppearance.BorderSize = 0
        Me.IconButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton10.ForeColor = System.Drawing.Color.White
        Me.IconButton10.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.IconButton10.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IconButton10.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton10.IconSize = 20
        Me.IconButton10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton10.Location = New System.Drawing.Point(272, 62)
        Me.IconButton10.Name = "IconButton10"
        Me.IconButton10.Size = New System.Drawing.Size(23, 32)
        Me.IconButton10.TabIndex = 26
        Me.IconButton10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton10.UseVisualStyleBackColor = False
        '
        'CmdFinanzas
        '
        Me.CmdFinanzas.FlatAppearance.BorderSize = 0
        Me.CmdFinanzas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdFinanzas.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFinanzas.ForeColor = System.Drawing.Color.White
        Me.CmdFinanzas.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdFinanzas.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdFinanzas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdFinanzas.IconSize = 20
        Me.CmdFinanzas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFinanzas.Location = New System.Drawing.Point(262, 1)
        Me.CmdFinanzas.Name = "CmdFinanzas"
        Me.CmdFinanzas.Size = New System.Drawing.Size(31, 22)
        Me.CmdFinanzas.TabIndex = 23
        Me.CmdFinanzas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFinanzas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdFinanzas.UseVisualStyleBackColor = True
        '
        'TxtDetallefn
        '
        Me.TxtDetallefn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDetallefn.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDetallefn.Location = New System.Drawing.Point(3, 27)
        Me.TxtDetallefn.Name = "TxtDetallefn"
        Me.TxtDetallefn.Size = New System.Drawing.Size(291, 69)
        Me.TxtDetallefn.TabIndex = 1
        Me.TxtDetallefn.Text = ""
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(2, 5)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(162, 12)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "ENT.FINANCIERAS / CONTROL CAJA : "
        '
        'BoxCondicion
        '
        Me.BoxCondicion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxCondicion.Controls.Add(Me.lbl_estado_lc)
        Me.BoxCondicion.Controls.Add(Me.Label50)
        Me.BoxCondicion.Controls.Add(Me.txt_diaslc)
        Me.BoxCondicion.Controls.Add(Me.TxtCondi_FecVcto)
        Me.BoxCondicion.Controls.Add(Me.lblEti_lc)
        Me.BoxCondicion.Controls.Add(Me.Label4)
        Me.BoxCondicion.Location = New System.Drawing.Point(295, 100)
        Me.BoxCondicion.Name = "BoxCondicion"
        Me.BoxCondicion.Size = New System.Drawing.Size(300, 48)
        Me.BoxCondicion.TabIndex = 27
        Me.BoxCondicion.Tag = "10"
        '
        'lbl_estado_lc
        '
        Me.lbl_estado_lc.AutoSize = True
        Me.lbl_estado_lc.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estado_lc.ForeColor = System.Drawing.Color.Black
        Me.lbl_estado_lc.Location = New System.Drawing.Point(98, 24)
        Me.lbl_estado_lc.Name = "lbl_estado_lc"
        Me.lbl_estado_lc.Size = New System.Drawing.Size(65, 13)
        Me.lbl_estado_lc.TabIndex = 43
        Me.lbl_estado_lc.Text = "DESACTIVO"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(52, 22)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(34, 13)
        Me.Label50.TabIndex = 42
        Me.Label50.Text = "DIAS."
        '
        'txt_diaslc
        '
        Me.txt_diaslc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_diaslc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_diaslc.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diaslc.Location = New System.Drawing.Point(6, 19)
        Me.txt_diaslc.MaxLength = 500
        Me.txt_diaslc.Name = "txt_diaslc"
        Me.txt_diaslc.Size = New System.Drawing.Size(41, 20)
        Me.txt_diaslc.TabIndex = 41
        Me.txt_diaslc.Text = "1"
        Me.txt_diaslc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCondi_FecVcto
        '
        Me.TxtCondi_FecVcto.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCondi_FecVcto.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCondi_FecVcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtCondi_FecVcto.Location = New System.Drawing.Point(187, 18)
        Me.TxtCondi_FecVcto.Name = "TxtCondi_FecVcto"
        Me.TxtCondi_FecVcto.Size = New System.Drawing.Size(106, 22)
        Me.TxtCondi_FecVcto.TabIndex = 33
        '
        'lblEti_lc
        '
        Me.lblEti_lc.AutoSize = True
        Me.lblEti_lc.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEti_lc.Location = New System.Drawing.Point(3, 4)
        Me.lblEti_lc.Name = "lblEti_lc"
        Me.lblEti_lc.Size = New System.Drawing.Size(98, 13)
        Me.lblEti_lc.TabIndex = 29
        Me.lblEti_lc.Text = "UN MAXI(15 DIAS)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(182, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "FEC. VCTO."
        '
        'BoxAtencion
        '
        Me.BoxAtencion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxAtencion.Controls.Add(Me.CmdPrioridad)
        Me.BoxAtencion.Controls.Add(Me.TxtPrioridad_FecAten)
        Me.BoxAtencion.Controls.Add(Me.Label7)
        Me.BoxAtencion.Controls.Add(Me.Label31)
        Me.BoxAtencion.Location = New System.Drawing.Point(295, 150)
        Me.BoxAtencion.Name = "BoxAtencion"
        Me.BoxAtencion.Size = New System.Drawing.Size(300, 35)
        Me.BoxAtencion.TabIndex = 26
        Me.BoxAtencion.Tag = "09"
        '
        'CmdPrioridad
        '
        Me.CmdPrioridad.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdPrioridad.FlatAppearance.BorderSize = 0
        Me.CmdPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdPrioridad.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrioridad.ForeColor = System.Drawing.Color.White
        Me.CmdPrioridad.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdPrioridad.IconColor = System.Drawing.Color.White
        Me.CmdPrioridad.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdPrioridad.IconSize = 25
        Me.CmdPrioridad.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdPrioridad.Location = New System.Drawing.Point(208, 4)
        Me.CmdPrioridad.Name = "CmdPrioridad"
        Me.CmdPrioridad.Size = New System.Drawing.Size(88, 26)
        Me.CmdPrioridad.TabIndex = 33
        Me.CmdPrioridad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrioridad.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdPrioridad.UseVisualStyleBackColor = False
        '
        'TxtPrioridad_FecAten
        '
        Me.TxtPrioridad_FecAten.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrioridad_FecAten.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrioridad_FecAten.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtPrioridad_FecAten.Location = New System.Drawing.Point(70, 5)
        Me.TxtPrioridad_FecAten.Name = "TxtPrioridad_FecAten"
        Me.TxtPrioridad_FecAten.Size = New System.Drawing.Size(93, 22)
        Me.TxtPrioridad_FecAten.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "FEC.ATENC."
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(169, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(41, 13)
        Me.Label31.TabIndex = 26
        Me.Label31.Text = "PRIOR."
        '
        'BoxComprobantes
        '
        Me.BoxComprobantes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxComprobantes.Controls.Add(Me.CmdVerNumComp)
        Me.BoxComprobantes.Controls.Add(Me.TxtComp_Numero)
        Me.BoxComprobantes.Controls.Add(Me.TxtComp_codigo)
        Me.BoxComprobantes.Controls.Add(Me.CmdSerireComp)
        Me.BoxComprobantes.Controls.Add(Me.TxtSerireComp)
        Me.BoxComprobantes.Controls.Add(Me.Label32)
        Me.BoxComprobantes.Controls.Add(Me.CmdComprob)
        Me.BoxComprobantes.Controls.Add(Me.Label29)
        Me.BoxComprobantes.Controls.Add(Me.Label33)
        Me.BoxComprobantes.Location = New System.Drawing.Point(1, 50)
        Me.BoxComprobantes.Name = "BoxComprobantes"
        Me.BoxComprobantes.Size = New System.Drawing.Size(290, 50)
        Me.BoxComprobantes.TabIndex = 25
        Me.BoxComprobantes.Tag = "08"
        '
        'CmdVerNumComp
        '
        Me.CmdVerNumComp.BackColor = System.Drawing.Color.Transparent
        Me.CmdVerNumComp.FlatAppearance.BorderSize = 0
        Me.CmdVerNumComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVerNumComp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdVerNumComp.ForeColor = System.Drawing.Color.White
        Me.CmdVerNumComp.IconChar = FontAwesome.Sharp.IconChar.Eye
        Me.CmdVerNumComp.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdVerNumComp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdVerNumComp.IconSize = 20
        Me.CmdVerNumComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdVerNumComp.Location = New System.Drawing.Point(259, 30)
        Me.CmdVerNumComp.Name = "CmdVerNumComp"
        Me.CmdVerNumComp.Size = New System.Drawing.Size(22, 15)
        Me.CmdVerNumComp.TabIndex = 37
        Me.CmdVerNumComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdVerNumComp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdVerNumComp.UseVisualStyleBackColor = False
        '
        'TxtComp_Numero
        '
        Me.TxtComp_Numero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtComp_Numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComp_Numero.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComp_Numero.Location = New System.Drawing.Point(181, 27)
        Me.TxtComp_Numero.MaxLength = 500
        Me.TxtComp_Numero.Name = "TxtComp_Numero"
        Me.TxtComp_Numero.Size = New System.Drawing.Size(83, 20)
        Me.TxtComp_Numero.TabIndex = 27
        Me.TxtComp_Numero.Text = "00000001"
        Me.TxtComp_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtComp_codigo
        '
        Me.TxtComp_codigo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtComp_codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComp_codigo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComp_codigo.Location = New System.Drawing.Point(80, 4)
        Me.TxtComp_codigo.MaxLength = 500
        Me.TxtComp_codigo.Name = "TxtComp_codigo"
        Me.TxtComp_codigo.Size = New System.Drawing.Size(33, 18)
        Me.TxtComp_codigo.TabIndex = 30
        Me.TxtComp_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdSerireComp
        '
        Me.CmdSerireComp.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdSerireComp.FlatAppearance.BorderSize = 0
        Me.CmdSerireComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSerireComp.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSerireComp.ForeColor = System.Drawing.Color.White
        Me.CmdSerireComp.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdSerireComp.IconColor = System.Drawing.Color.White
        Me.CmdSerireComp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSerireComp.IconSize = 25
        Me.CmdSerireComp.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdSerireComp.Location = New System.Drawing.Point(50, 23)
        Me.CmdSerireComp.Name = "CmdSerireComp"
        Me.CmdSerireComp.Size = New System.Drawing.Size(71, 23)
        Me.CmdSerireComp.TabIndex = 34
        Me.CmdSerireComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSerireComp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdSerireComp.UseVisualStyleBackColor = False
        '
        'TxtSerireComp
        '
        Me.TxtSerireComp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSerireComp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerireComp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerireComp.Location = New System.Drawing.Point(56, 25)
        Me.TxtSerireComp.MaxLength = 500
        Me.TxtSerireComp.Name = "TxtSerireComp"
        Me.TxtSerireComp.Size = New System.Drawing.Size(59, 18)
        Me.TxtSerireComp.TabIndex = 36
        Me.TxtSerireComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(121, 30)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(60, 13)
        Me.Label32.TabIndex = 26
        Me.Label32.Text = "NUMERO :"
        '
        'CmdComprob
        '
        Me.CmdComprob.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdComprob.FlatAppearance.BorderSize = 0
        Me.CmdComprob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdComprob.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdComprob.ForeColor = System.Drawing.Color.White
        Me.CmdComprob.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdComprob.IconColor = System.Drawing.Color.White
        Me.CmdComprob.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdComprob.IconSize = 25
        Me.CmdComprob.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdComprob.Location = New System.Drawing.Point(124, 0)
        Me.CmdComprob.Name = "CmdComprob"
        Me.CmdComprob.Size = New System.Drawing.Size(153, 26)
        Me.CmdComprob.TabIndex = 26
        Me.CmdComprob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdComprob.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdComprob.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label29.Location = New System.Drawing.Point(2, 6)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(74, 12)
        Me.Label29.TabIndex = 29
        Me.Label29.Text = "COMPROBANTE "
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label33.Location = New System.Drawing.Point(3, 28)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(33, 12)
        Me.Label33.TabIndex = 25
        Me.Label33.Text = "SERIE :"
        '
        'BoxFechas
        '
        Me.BoxFechas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxFechas.Controls.Add(Me.TxtFechas_Emis)
        Me.BoxFechas.Controls.Add(Me.TxtFechas_Proc)
        Me.BoxFechas.Controls.Add(Me.Label5)
        Me.BoxFechas.Controls.Add(Me.Label30)
        Me.BoxFechas.Location = New System.Drawing.Point(1, 100)
        Me.BoxFechas.Name = "BoxFechas"
        Me.BoxFechas.Size = New System.Drawing.Size(290, 49)
        Me.BoxFechas.TabIndex = 24
        Me.BoxFechas.Tag = "07"
        '
        'TxtFechas_Emis
        '
        Me.TxtFechas_Emis.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Emis.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Emis.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechas_Emis.Location = New System.Drawing.Point(157, 19)
        Me.TxtFechas_Emis.Name = "TxtFechas_Emis"
        Me.TxtFechas_Emis.Size = New System.Drawing.Size(106, 22)
        Me.TxtFechas_Emis.TabIndex = 30
        '
        'TxtFechas_Proc
        '
        Me.TxtFechas_Proc.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Proc.Enabled = False
        Me.TxtFechas_Proc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Proc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechas_Proc.Location = New System.Drawing.Point(5, 18)
        Me.TxtFechas_Proc.Name = "TxtFechas_Proc"
        Me.TxtFechas_Proc.Size = New System.Drawing.Size(106, 22)
        Me.TxtFechas_Proc.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "FEC.PROCESO"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(164, 4)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 13)
        Me.Label30.TabIndex = 26
        Me.Label30.Text = "FEC.EMISION"
        '
        'BoxMoneda
        '
        Me.BoxMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BoxMoneda.Controls.Add(Me.Label23)
        Me.BoxMoneda.Controls.Add(Me.CmdMonedaComp)
        Me.BoxMoneda.Location = New System.Drawing.Point(1, 150)
        Me.BoxMoneda.Name = "BoxMoneda"
        Me.BoxMoneda.Size = New System.Drawing.Size(290, 36)
        Me.BoxMoneda.TabIndex = 8
        Me.BoxMoneda.Tag = "05"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(6, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(117, 27)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "MONEDA  COMPROBANTE:"
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
        Me.CmdMonedaComp.Location = New System.Drawing.Point(129, 6)
        Me.CmdMonedaComp.Name = "CmdMonedaComp"
        Me.CmdMonedaComp.Size = New System.Drawing.Size(146, 26)
        Me.CmdMonedaComp.TabIndex = 27
        Me.CmdMonedaComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMonedaComp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMonedaComp.UseVisualStyleBackColor = False
        '
        'TimeNoti
        '
        Me.TimeNoti.Interval = 500
        '
        'dg_cuentasn
        '
        Me.dg_cuentasn.AllowUserToAddRows = False
        Me.dg_cuentasn.AllowUserToDeleteRows = False
        Me.dg_cuentasn.AllowUserToOrderColumns = True
        Me.dg_cuentasn.AllowUserToResizeRows = False
        Me.dg_cuentasn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_cuentasn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cuentasn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_cuentasn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_cuentasn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_cuentasn.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_cuentasn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_cuentasn.id_local_grid = 0
        Me.dg_cuentasn.Location = New System.Drawing.Point(0, 0)
        Me.dg_cuentasn.MultiSelect = False
        Me.dg_cuentasn.Name = "dg_cuentasn"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cuentasn.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg_cuentasn.RowHeadersVisible = False
        Me.dg_cuentasn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_cuentasn.Size = New System.Drawing.Size(104, 130)
        Me.dg_cuentasn.TabIndex = 14
        Me.dg_cuentasn.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "dg_cuentasn"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'GridProductos
        '
        Me.GridProductos.AllowUserToAddRows = False
        Me.GridProductos.AllowUserToDeleteRows = False
        Me.GridProductos.AllowUserToOrderColumns = True
        Me.GridProductos.AllowUserToResizeRows = False
        Me.GridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridProductos.DefaultCellStyle = DataGridViewCellStyle5
        Me.GridProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProductos.id_local_grid = 0
        Me.GridProductos.Location = New System.Drawing.Point(0, 0)
        Me.GridProductos.MultiSelect = False
        Me.GridProductos.Name = "GridProductos"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GridProductos.RowHeadersVisible = False
        Me.GridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridProductos.Size = New System.Drawing.Size(79, 128)
        Me.GridProductos.TabIndex = 13
        Me.GridProductos.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "PROD1"
        Me.Column1.Name = "Column1"
        '
        'dg_doc_canje
        '
        Me.dg_doc_canje.AllowUserToAddRows = False
        Me.dg_doc_canje.AllowUserToDeleteRows = False
        Me.dg_doc_canje.AllowUserToOrderColumns = True
        Me.dg_doc_canje.AllowUserToResizeRows = False
        Me.dg_doc_canje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_doc_canje.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_doc_canje.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dg_doc_canje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_doc_canje.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_doc_canje.DefaultCellStyle = DataGridViewCellStyle8
        Me.dg_doc_canje.id_local_grid = 0
        Me.dg_doc_canje.Location = New System.Drawing.Point(376, 0)
        Me.dg_doc_canje.MultiSelect = False
        Me.dg_doc_canje.Name = "dg_doc_canje"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_doc_canje.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dg_doc_canje.RowHeadersVisible = False
        Me.dg_doc_canje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_doc_canje.Size = New System.Drawing.Size(520, 81)
        Me.dg_doc_canje.TabIndex = 30
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "dg_doc_canje"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'FrmOperaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1277, 646)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelCentral)
        Me.Controls.Add(Me.PanelDEtalle)
        Me.Controls.Add(Me.PanelPie)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.PanelSup)
        Me.Controls.Add(Me.PanelMensajes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmOperaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel9.ResumeLayout(False)
        Me.PanelMensajes.ResumeLayout(False)
        Me.PanelMensajes_DER.ResumeLayout(False)
        Me.PanelMensajes_ISQ.ResumeLayout(False)
        Me.PanelPie.ResumeLayout(False)
        Me.PanelDEtalle.ResumeLayout(False)
        Me.PanelDEtalle.PerformLayout()
        Me.PanelGridDetalle.ResumeLayout(False)
        Me.ZonaMasDetalles.ResumeLayout(False)
        Me.BoxDirEntrega.ResumeLayout(False)
        Me.BoxDirEntrega.PerformLayout()
        Me.BoxContacto.ResumeLayout(False)
        Me.BoxContacto.PerformLayout()
        Me.BoxTipoInterfaz.ResumeLayout(False)
        Me.BoxTipoInterfaz.PerformLayout()
        Me.BoxDirCobro.ResumeLayout(False)
        Me.BoxDirCobro.PerformLayout()
        Me.ZonaDetalle.ResumeLayout(False)
        Me.BoxEstadoSN.ResumeLayout(False)
        Me.BoxGridPROD1.ResumeLayout(False)
        Me.BoxModoCanculo.ResumeLayout(False)
        Me.BoxModoCanculo.PerformLayout()
        Me.BoxServicios.ResumeLayout(False)
        Me.BoxServicios.PerformLayout()
        Me.PanelCentral.ResumeLayout(False)
        CType(Me.dg_listaoper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelListarOper.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel19.ResumeLayout(False)
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.PanelCabecera.ResumeLayout(False)
        Me.BoxAlmTransf.ResumeLayout(False)
        Me.BoxAlmTransf.PerformLayout()
        Me.BoxLineaCredito.ResumeLayout(False)
        Me.BoxLineaCredito.PerformLayout()
        Me.BoxDocCanje.ResumeLayout(False)
        Me.BoxDocCanje.PerformLayout()
        Me.BoxRefComp.ResumeLayout(False)
        Me.BoxRefComp.PerformLayout()
        Me.BoxTienda.ResumeLayout(False)
        Me.BoxTienda.PerformLayout()
        Me.BoxEstado.ResumeLayout(False)
        Me.BoxEstado.PerformLayout()
        Me.BoxGuiaAuto.ResumeLayout(False)
        Me.BoxGuiaAuto.PerformLayout()
        Me.BoxDocIntOper.ResumeLayout(False)
        Me.BoxDocIntOper.PerformLayout()
        Me.BoxVendedor.ResumeLayout(False)
        Me.BoxVendedor.PerformLayout()
        Me.BoxSocioNego.ResumeLayout(False)
        Me.BoxSocioNego.PerformLayout()
        Me.BoxEntidadF.ResumeLayout(False)
        Me.BoxEntidadF.PerformLayout()
        Me.BoxCondicion.ResumeLayout(False)
        Me.BoxCondicion.PerformLayout()
        Me.BoxAtencion.ResumeLayout(False)
        Me.BoxAtencion.PerformLayout()
        Me.BoxComprobantes.ResumeLayout(False)
        Me.BoxComprobantes.PerformLayout()
        Me.BoxFechas.ResumeLayout(False)
        Me.BoxFechas.PerformLayout()
        Me.BoxMoneda.ResumeLayout(False)
        CType(Me.dg_cuentasn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_doc_canje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel9 As Panel
    Friend WithEvents PanelMensajes As Panel
    Friend WithEvents PanelPie As Panel
    Friend WithEvents PanelDEtalle As Panel
    Friend WithEvents PanelSup As Panel
    Friend WithEvents TxtOperacion As TextBox
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelCabecera As Panel
    Friend WithEvents BoxDocIntOper As Panel
    Friend WithEvents BoxContacto As Panel
    Friend WithEvents BoxSocioNego As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents CmdTipoOper As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdSubOper As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtLocal As TextBox
    Friend WithEvents CmdBusoper As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdBusca_BoxSN As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtSocio_BoxSN As TextBox
    Friend WithEvents info_SN As RichTextBox
    Friend WithEvents txtContactos As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BoxMoneda As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtNumDocOper As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents TxtSerieDocOper As TextBox
    Friend WithEvents TxtDocOper As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents BoxFechas As Panel
    Friend WithEvents TxtFechas_Emis As DateTimePicker
    Friend WithEvents TxtFechas_Proc As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents BoxComprobantes As Panel
    Friend WithEvents TxtComp_codigo As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TxtComp_Numero As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents BoxCondicion As Panel
    Friend WithEvents TxtCondi_FecVcto As DateTimePicker
    Friend WithEvents lblEti_lc As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BoxAtencion As Panel
    Friend WithEvents TxtPrioridad_FecAten As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents BoxEntidadF As Panel
    Friend WithEvents CmdFinanzas As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtDetallefn As RichTextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents BoxVendedor As Panel
    Friend WithEvents IconButton7 As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtVendedor_Codigo As TextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents BoxDirCobro As Panel
    Friend WithEvents IconButton9 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents BoxGuiaAuto As Panel
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BoxTipoInterfaz As Panel
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents BoxEstado As Panel
    Friend WithEvents CmdEnviarA As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdTraerDe As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtEstadoComp As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Radio_Serv As RadioButton
    Friend WithEvents CmdAdjuntos As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMasDetalles As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdZonaDetalle As FontAwesome.Sharp.IconButton
    Friend WithEvents Label15 As Label
    Friend WithEvents CmdGrabar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCancelarOper As FontAwesome.Sharp.IconButton
    Friend WithEvents BoxServicios As Panel
    Friend WithEvents Radio_Prod As RadioButton
    Friend WithEvents BoxModoCanculo As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents chkConIMPTO As RadioButton
    Friend WithEvents chkSinIMPTO As RadioButton
    Friend WithEvents Label17 As Label
    Friend WithEvents CmdAccesoSuboper As Button
    Friend WithEvents CmdOperacion As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAccTipo As Button
    Friend WithEvents CmdAccoper As Button
    Friend WithEvents PanelCentral As Panel
    Friend WithEvents BoxTienda As Panel
    Friend WithEvents CmdListaoper As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelListarOper As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents CmdBusoper_filtro As FontAwesome.Sharp.IconButton
    Friend WithEvents Label34 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents t_fechaFin As DateTimePicker
    Friend WithEvents t_fechaIni As DateTimePicker
    Friend WithEvents CmdIniciarOper As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel21 As Panel
    Friend WithEvents Label35 As Label
    Friend WithEvents CmdMuestraFiltro As FontAwesome.Sharp.IconButton
    Friend WithEvents LBLIniciar As Button
    Friend WithEvents LblListar As Button
    Friend WithEvents PanelGridDetalle As Panel
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    'Public WithEvents GridProductos As GridProductosPlus
    Friend WithEvents GridProductos As GridProductosPlus
    Friend WithEvents BoxGridPROD1 As Panel
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents ZonaAdjuntos As Panel
    Friend WithEvents ZonaMasDetalles As Panel
    Friend WithEvents ZonaDetalle As Panel
    Friend WithEvents BoxDirEntrega As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents TimeNoti As Timer
    Friend WithEvents CmdComprob As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdSerireComp As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtSerireComp As TextBox
    Friend WithEvents CmdVerNumComp As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMonedaComp As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdPrioridad As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdVerNumInt As FontAwesome.Sharp.IconButton
    Friend WithEvents Button3 As Button
    Friend WithEvents BoxTOT10 As Label
    Friend WithEvents BoxTOT5 As Label
    Friend WithEvents BoxTOT9 As Label
    Friend WithEvents BoxTOT4 As Label
    Friend WithEvents BoxTOT8 As Label
    Friend WithEvents BoxTOT3 As Label
    Friend WithEvents BoxTOT6 As Label
    Friend WithEvents BoxTOT1 As Label
    Friend WithEvents BoxTOT7 As Label
    Friend WithEvents BoxTOT2 As Label
    Friend WithEvents BoxTOT12 As Label
    Friend WithEvents BoxTOT11 As Label
    Friend WithEvents CmdSN_inicio As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdSN_fin As FontAwesome.Sharp.IconButton
    Friend WithEvents Button4 As Button
    Friend WithEvents CmdOscuro As FontAwesome.Sharp.IconButton
    Public WithEvents CmdLocal As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdOperacion_filtro As FontAwesome.Sharp.IconButton
    Friend WithEvents Txt_Operacion_filtro As TextBox
    Friend WithEvents dg_listaoper As DataGridView
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents CmdAanularOper As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdEnlacesComp As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents IconButton5 As FontAwesome.Sharp.IconButton
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents IconButton6 As FontAwesome.Sharp.IconButton
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents CmdEstados As FontAwesome.Sharp.IconButton
    Friend WithEvents cmdFormato As FontAwesome.Sharp.IconButton
    Friend WithEvents Label9 As Label
    Friend WithEvents PanelMensajes_DER As Panel
    Friend WithEvents PanelMensajes_ISQ As Panel
    Friend WithEvents link_saldo As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents BoxEstadoSN As Panel
    Friend WithEvents dg_cuentasn As GridCarteraSN_Plus
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents CmdActualizarComp As FontAwesome.Sharp.IconButton
    Friend WithEvents tt_leyenda As ToolTip
    Friend WithEvents BoxAlmTransf As Panel
    Friend WithEvents TxtAlmTransf As TextBox
    Friend WithEvents CmdAlmTransf As FontAwesome.Sharp.IconButton
    Friend WithEvents Label38 As Label
    Friend WithEvents LblAlmTransf As Label
    Friend WithEvents CmdClonarOper As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdConsultaReg As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCostosVinc As FontAwesome.Sharp.IconButton
    Friend WithEvents LinkConfImp As LinkLabel
    Friend WithEvents CmdConsultaReg_Sig As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdConOper As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdInicialNum As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton8 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton10 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAccFN As Button
    Public WithEvents LblNoti As Label
    Friend WithEvents CmdActivarEdi As FontAwesome.Sharp.IconButton
    Friend WithEvents BoxDocCanje As Panel
    Friend WithEvents Txt_canje_fecemi As DateTimePicker
    Friend WithEvents Label41 As Label
    Friend WithEvents Txt_canje_cuotas As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents Txt_canje_monto As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Cmd_Canje_Tipos As FontAwesome.Sharp.IconButton
    Friend WithEvents dg_doc_canje As GridCanjes_Plus
    Friend WithEvents Label12 As Label
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Label36 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Txt_diasletras As TextBox
    Friend WithEvents BoxLineaCredito As Panel
    Friend WithEvents lc_monto As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents lc_dias As TextBox
    Friend WithEvents lc_actual As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents CmdOpcionesLC As FontAwesome.Sharp.IconButton
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents lc_disponible As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents lc_usado As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents CmdEstado_lc As FontAwesome.Sharp.IconButton
    Friend WithEvents lblEstado_lc As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents txt_diaslc As TextBox
    Friend WithEvents lbl_estado_lc As Label
    Friend WithEvents BoxRefComp As Panel
    Friend WithEvents Label53 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents tref_fecha As TextBox
    Friend WithEvents tref_numero As TextBox
    Friend WithEvents tref_serie As TextBox
    Friend WithEvents tref_codigo As TextBox
    Friend WithEvents Label1 As Label
End Class

''
Public Class GridProductosPlus
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

                    If Me.Columns("codigo").Visible Then
                        Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells("codigo")
                        Me.BeginEdit(True)
                    ElseIf Me.Columns("tipo_serv_des").Visible Then
                        Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells("tipo_serv_des")
                    End If




                    'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."


                    ' FrmOperaciones.GridProductos_PrimeraFila()
                    Return True
                Else
                    SendKeys.Send("{DOWN}")
                    Return True

                End If


            End If
            If Me.CurrentCell.OwningColumn.Name = "preciobase" Then
                Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'preciobase'  ")
                Dim colum_destino As String = ""
                If Loc_Salto_Grid.Length = 0 Then
                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If

                If Loc_Salto_Grid(0)("es_salto") = 1 Then
                    If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                        Me.Rows.Add()
                        colum_destino = Loc_Salto_Grid(0)("columna_des")
                        If Me.Columns(colum_destino).Visible Then
                            Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
                        Else
                            If Me.Columns("tipo_serv_des").Visible Then
                                Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells("tipo_serv_des")
                            End If

                        End If

                        Me.Rows(Me.Rows.Count - 1).Cells("almacen").Value = Me.Rows(Me.Rows.Count - 2).Cells("almacen").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("alm_abreviado").Value = Me.Rows(Me.Rows.Count - 2).Cells("alm_abreviado").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("id_almacen").Value = Me.Rows(Me.Rows.Count - 2).Cells("id_almacen").Value

                        Me.Rows(Me.Rows.Count - 1).Cells("codigo_local_serv").Value = Me.Rows(Me.Rows.Count - 2).Cells("codigo_local_serv").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("des_local_serv").Value = Me.Rows(Me.Rows.Count - 2).Cells("des_local_serv").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("id_local_serv").Value = Me.Rows(Me.Rows.Count - 2).Cells("id_local_serv").Value

                        Me.Rows(Me.Rows.Count - 1).Cells("es_servicio").Value = Me.Rows(Me.Rows.Count - 2).Cells("es_servicio").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("id_tb_tipo_serv").Value = Me.Rows(Me.Rows.Count - 2).Cells("id_tb_tipo_serv").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("tipo_serv_des").Value = Me.Rows(Me.Rows.Count - 2).Cells("tipo_serv_des").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("area_serv_des").Value = Me.Rows(Me.Rows.Count - 2).Cells("area_serv_des").Value
                        Me.Rows(Me.Rows.Count - 1).Cells("id_area").Value = Me.Rows(Me.Rows.Count - 2).Cells("id_area").Value





                        Me.BeginEdit(True)
                    Else
                        colum_destino = Loc_Salto_Grid(0)("columna_ori")
                        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex + 1).Cells(colum_destino)
                    End If

                Else
                    If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                        colum_destino = Loc_Salto_Grid(0)("columna_des")
                        Me.BeginEdit(True)
                    Else
                        colum_destino = Loc_Salto_Grid(0)("columna_ori")
                        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex + 1).Cells(colum_destino)
                    End If

                End If


                Return True
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
                    Dim Result = MensajesBox.Show("Codigo de Almacen No Existe, Intente buscar otro.",
                                             "Almacen.")
                    '  CmdLocal_Click(Nothing, Nothing)

                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_almacen").Value = 0
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("almacen").Value = 0
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
            If Me.CurrentCell.OwningColumn.Name = "codigo" Then
                ' retorno si esta marcado la opciond e producto nuevo 
                If Me.Rows(Me.CurrentCell.RowIndex).Cells("es_prod_new").Value Then
                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If
                Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValue = "" Then

                    Return True
                End If
                ' bUSQUEDA dIRECTO APOR CODIGO DE PRODUCTO
                ', " + lk_NegocioActivo. + "," + lk_LocalActivo + "," + lk_AlmacenActivo + " "
                'exec [sp_buscaCodigoProducto] '2', 22,1,1 
                Dim sql As String = "exec [sp_buscaCodigoProducto] '" & currentValue & "'," & lk_NegocioActivo.id_Negocio & "," & lk_LocalActivo.id_local & "," & lk_AlmacenActivo.id_almacen & " "
                Dim command As New SqlCommand(sql, lk_connection_cuenta)
                Dim adapter As New SqlDataAdapter(command)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    Return True
                End If

                'Dim wpres As String = selectedRow.Cells("Unidades").Value.ToString()
                Dim wpres As String = tabla.Rows(0).Item("Unidades").ToString
                Dim valores As List(Of Tuple(Of String, Integer, Integer)) = ConvertirCadena(wpres)
                Dim comboCell As DataGridViewComboBoxCell
                'comboCell = CType(GridProductos.Rows(e.RowIndex).Cells("present"), DataGridViewComboBoxCell)
                comboCell = CType(Me.Rows(Me.CurrentCell.RowIndex).Cells("present"), DataGridViewComboBoxCell)

                comboCell.Items.Clear()
                Dim valoresDict As New Dictionary(Of Integer, Tuple(Of String, Integer, Integer)) ' Diccionario para almacenar los valores con su índice
                For i As Integer = 0 To valores.Count - 1
                    comboCell.Items.Add(valores(i).Item1)
                    valoresDict.Add(i, valores(i)) '
                Next
                comboCell.Tag = valoresDict

                If valores.Count > 0 Then
                    comboCell.Value = valores(0).Item1
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_pres").Value = valores(0).Item3
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("equiv").Value = valores(0).Item2
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("Unidades").Value = wpres ' Valor original de la bd
                End If

                Me.Rows(Me.CurrentCell.RowIndex).Cells("codigo").Value = tabla.Rows(0).Item("Codigo").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_prod_mae_codigo").Value = tabla.Rows(0).Item("Codigo").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip").Value = tabla.Rows(0).Item("NombreProducto").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("grupo").Value = tabla.Rows(0).Item("Lab_Linea").ToString

                Me.Rows(Me.CurrentCell.RowIndex).Cells("masdetalle").Value = "..." 'tabla.Rows(0).Item("Codigo").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_prod_mae").Value = tabla.Rows(0).Item("id_prod_mae").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("cantidad").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("cosproactual").Value = tabla.Rows(0).Item("cosproactual").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("stockactual").Value = tabla.Rows(0).Item("stockactual").ToString

                Me.Rows(Me.CurrentCell.RowIndex).Cells("es_inventariable").Value = tabla.Rows(0).Item("es_inventariable").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("es_exonerado").Value = tabla.Rows(0).Item("es_exonerado").ToString


                If Val(tabla.Rows(0).Item("es_control_lote").ToString) = 1 Then
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("lote").Value = "..." ' tabla.Rows(0).Item("Lote_def").ToString
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("det_lote").Value = "Pulsar [F2] para definición de lotes"
                Else
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("lote").Value = "" ' tabla.Rows(0).Item("Lote_def").ToString
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("det_lote").Value = "Sin Control de lotes/series"
                End If



                'Me.Rows(Me.CurrentCell.RowIndex).Cells("almacen").Value = lk_AlmacenActivo.codigo
                'Me.Rows(Me.CurrentCell.RowIndex).Cells("id_almacen").Value = lk_AlmacenActivo.id_almacen
                'Me.Rows(Me.CurrentCell.RowIndex).Cells("alm_abreviado").Value = lk_AlmacenActivo.abreviado.ToString.Trim
                Me.Rows(Me.CurrentCell.RowIndex).Cells("preciobase").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("des1").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("des2").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("valor").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("impto").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("valor").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("subtotal").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_pres_precio").Value = 0
                Me.Rows(Me.CurrentCell.RowIndex).Cells("Unidades").Value = tabla.Rows(0).Item("Unidades").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_pres_base").Value = tabla.Rows(0).Item("id_pres_base").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("abreviado_base").Value = tabla.Rows(0).Item("abreviado_base").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("equiv_base").Value = tabla.Rows(0).Item("equiv_base").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("es_control_lote").Value = tabla.Rows(0).Item("es_control_lote").ToString






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

        If Me.Rows(Me.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then

            If Me.CurrentCell.OwningColumn.Name = "lote" Or Me.CurrentCell.OwningColumn.Name = "codigo" Or Me.CurrentCell.OwningColumn.Name = "cantidad" Or Me.CurrentCell.OwningColumn.Name = "present" Then
                Return True
            End If
        End If
        'If GridProductos.AccessibleDescription = "1" Then ' AFECTO AL IPTO
        '    If nombreColumna = "preciobase" Then
        '        GridProductos.Rows(filagrid).Cells("modocalculo").Value = "PT"
        '    ElseIf nombreColumna = "subtotal" Then
        '        GridProductos.Rows(filagrid).Cells("modocalculo").Value = "TO"
        '    End If
        'ElseIf GridProductos.AccessibleDescription = "2" Then ' AFECTO AL IPTO
        '    If nombreColumna = "preciobase" Then
        '        GridProductos.Rows(filagrid).Cells("modocalculo").Value = "PV"
        '    ElseIf nombreColumna = "valor" Then
        '        GridProductos.Rows(filagrid).Cells("modocalculo").Value = "VA"
        '    End If

        'End If
        'AccessibleDescription
        ' impto
        ' *** validacions de columnas para fornar a no editar 

        If Me.Rows(Me.CurrentCell.RowIndex).Cells("es_prod_new").Value Then
            If Me.CurrentCell.OwningColumn.Name = "descrip" Then ' FORZAR DE QUE SI LA COLUMA ES LECTURA NO EDITE 
                Return MyBase.ProcessDialogKey(KeyData)
            End If

        End If
        If Me.CurrentCell.OwningColumn.Name = "lote" Or Me.CurrentCell.OwningColumn.Name = "det_lote" Or Me.CurrentCell.OwningColumn.Name = "num" Or Me.CurrentCell.OwningColumn.Name = "alm_abreviado" Or Me.CurrentCell.OwningColumn.Name = "grupo" Then ' FORZAR DE QUE SI LA COLUMA ES LECTURA NO EDITE 
            Return True
        End If
        If Me.CurrentCell.OwningColumn.Name = "descrip" Then ' FORZAR DE QUE SI LA COLUMA ES LECTURA NO EDITE 
            Return True
        End If

        If Me.AccessibleDescription = "1" Then
            If Me.CurrentCell.OwningColumn.Name = "valor" Then
                Return True
            End If
        End If
        If Me.AccessibleDescription = "2" Then
            If Me.CurrentCell.OwningColumn.Name = "subtotal" Then
                Return True
            End If
        End If

        'If Strings.Right(Me.CurrentCell.OwningColumn.HeaderText, 1) = "*" Then ' cUALQUIER vALOR
        '    If KeyData = Keys.Enter Then
        '        'If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
        '        ' Verificar si se ingresó un número en la primera columna antes de agregar una nueva fila
        '        Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
        '            'If Not IsNumeric(valor) Then   
        '            '    'MessageBox.Show("Ingrese solo números en la primera columna.")
        '            '    Return True ' Evita que se procese la tecla Enter
        '            'End If
        '            frmoperdetalle.GridProductos_PrimeraFila()
        '            Return True
        '        'End If

        '        'SendKeys.Send(Chr(Keys.Tab))
        '        'Return True

        '    End If

        'End If



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

Public Class GridCarteraSN_Plus
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
            If Me.CurrentCell.OwningColumn.Name = "preciobase" Then
                Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'preciobase'  ")
                Dim colum_destino As String = ""
                If Loc_Salto_Grid.Length = 0 Then
                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If

                If Loc_Salto_Grid(0)("es_salto") = 1 Then
                    If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                        Me.Rows.Add()
                        colum_destino = Loc_Salto_Grid(0)("columna_des")
                        Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
                        Me.BeginEdit(True)
                    Else
                        colum_destino = Loc_Salto_Grid(0)("columna_ori")
                        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex + 1).Cells(colum_destino)
                    End If

                Else
                    If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                        colum_destino = Loc_Salto_Grid(0)("columna_des")
                        Me.BeginEdit(True)
                    Else
                        colum_destino = Loc_Salto_Grid(0)("columna_ori")
                        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex + 1).Cells(colum_destino)
                    End If

                End If


                Return True
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

                Dim sql As String = "exec [sp_muestra_carterasn] @id_negocio, @tipo_balance, @codigo_comp ,@serie_comp, @numero_comp , @es_oper_maestro ,@id_oper_maestro, @id_comp_cab"
                Dim command As New SqlCommand(sql, lk_connection_cuenta)
                command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
                command.Parameters.AddWithValue("@tipo_balance", Val(Me.AccessibleDescription))
                command.Parameters.AddWithValue("@codigo_comp", Me.Rows(Me.CurrentCell.RowIndex).Cells("codcomp").Value)
                command.Parameters.AddWithValue("@serie_comp", Me.Rows(Me.CurrentCell.RowIndex).Cells("seriecomp").Value)
                command.Parameters.AddWithValue("@numero_comp", currentValue)
                command.Parameters.AddWithValue("@es_oper_maestro", 0)
                command.Parameters.AddWithValue("@id_oper_maestro", 0)
                command.Parameters.AddWithValue("@id_comp_cab", 0)


                Dim adapter As New SqlDataAdapter(command)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    Dim Result As String = MensajesBox.Show("Comprobante No Existe, Intente buscar nuevamente.",
                                             "Comprobante")
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
                Me.Rows(Me.CurrentCell.RowIndex).Cells("signo_sn").Value = tabla.Rows(0).Item("signo_sn")



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

        If Me.Rows(Me.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
            'If Me.CurrentCell.OwningColumn.Name = "codigo" Or Me.CurrentCell.OwningColumn.Name = "cantidad" Or Me.CurrentCell.OwningColumn.Name = "present" Then
            Return True
            '    End If
        End If





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

Public Class GridCanjes_Plus
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
            'If Strings.Right(Me.CurrentCell.OwningColumn.HeaderText, 1) = "*" Then ' cUALQUIER vALOR
            '    'If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
            '    If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
            '        ' Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
            '        Me.Rows.Add()
            '        Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells("codigo")
            '        'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."
            '        Me.BeginEdit(True)

            '        ' FrmOperaciones.GridProductos_PrimeraFila()
            '        Return True
            '    Else
            '        SendKeys.Send("{DOWN}")
            '        Return True

            '    End If


            'End If

            'If Me.CurrentCell.OwningColumn.Name = "cantidad" Then
            '    Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'cantidad'  ")
            '    Dim colum_destino As String = ""
            '    If Loc_Salto_Grid.Length = 0 Then
            '        SendKeys.Send(Chr(Keys.Tab))
            '        Return True
            '    End If

            '    If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
            '        colum_destino = Loc_Salto_Grid(0)("columna_des")
            '        Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
            '        Me.BeginEdit(True)
            '    Else
            '        colum_destino = Loc_Salto_Grid(0)("columna_ori")
            '        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex + 1).Cells(colum_destino)
            '    End If

            '    ' FrmOperaciones.GridProductos_PrimeraFila()
            '    Return True
            'End If





            SendKeys.Send(Chr(Keys.Tab))
            Return True



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
        '    'If Me.CurrentCell.OwningColumn.Name = "codigo" Or Me.CurrentCell.OwningColumn.Name = "cantidad" Or Me.CurrentCell.OwningColumn.Name = "present" Then
        '    Return True
        '    '    End If
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
