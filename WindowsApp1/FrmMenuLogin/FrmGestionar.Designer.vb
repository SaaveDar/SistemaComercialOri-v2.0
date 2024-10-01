<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestionar
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGestionar))
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.LblSocioNeg = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.IconButton4 = New FontAwesome.Sharp.IconButton()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.CmdInventarios = New FontAwesome.Sharp.IconButton()
        Me.CmdSocioNeg = New FontAwesome.Sharp.IconButton()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.CmdOscuro = New FontAwesome.Sharp.IconButton()
        Me.LBLIniciar = New System.Windows.Forms.Button()
        Me.CmdIniciarOper = New FontAwesome.Sharp.IconButton()
        Me.PanelSN = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dg_finanzas_sn = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_detalle_sn = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_resumen_sn = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PanelListarOper = New System.Windows.Forms.Panel()
        Me.PanelF5 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.IconButton6 = New FontAwesome.Sharp.IconButton()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckEstadoComp = New System.Windows.Forms.CheckBox()
        Me.PanelF4 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Checkfechas = New System.Windows.Forms.CheckBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.t_fechaIni = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.t_fechaFin = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.PanelF3 = New System.Windows.Forms.Panel()
        Me.CheckOper = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CmdBusoper_filtro = New FontAwesome.Sharp.IconButton()
        Me.PanelF2 = New System.Windows.Forms.Panel()
        Me.FlowSN = New System.Windows.Forms.FlowLayoutPanel()
        Me.CmdBuscaSN = New FontAwesome.Sharp.IconButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtSN = New System.Windows.Forms.TextBox()
        Me.CheckSN = New System.Windows.Forms.CheckBox()
        Me.PanelF1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.IconButton5 = New FontAwesome.Sharp.IconButton()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckLocales = New System.Windows.Forms.CheckBox()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.CmdContraerMenu = New FontAwesome.Sharp.IconButton()
        Me.CmdMoneda = New FontAwesome.Sharp.IconButton()
        Me.CmdMuestraFiltro = New FontAwesome.Sharp.IconButton()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.ToolTipBotones = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelInventario = New System.Windows.Forms.Panel()
        Me.PanelKardexDET = New System.Windows.Forms.Panel()
        Me.dg_kardex = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Chek_quitar_anul = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.PanelKardexCAB = New System.Windows.Forms.Panel()
        Me.dg_Inventario = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtAlmTransf = New System.Windows.Forms.TextBox()
        Me.CmdAlmTransf = New FontAwesome.Sharp.IconButton()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.CmdMostrarInventario = New FontAwesome.Sharp.IconButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Inv_fechaini = New System.Windows.Forms.DateTimePicker()
        Me.Inv_fechafin = New System.Windows.Forms.DateTimePicker()
        Me.IconButton7 = New FontAwesome.Sharp.IconButton()
        Me.CmdFiltroPeriodo = New FontAwesome.Sharp.IconButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dt_kpi_sn = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dt_kpi_comercial = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dt_kpi = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdTipoCosto = New FontAwesome.Sharp.IconButton()
        Me.blb_costo_ult = New System.Windows.Forms.Label()
        Me.CmdVxA = New FontAwesome.Sharp.IconButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CmdActualizar = New FontAwesome.Sharp.IconButton()
        Me.PanelEnLinea = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.dt_user = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CmdVxM2 = New FontAwesome.Sharp.IconButton()
        Me.CmdAxF = New FontAwesome.Sharp.IconButton()
        Me.CmdVxF = New FontAwesome.Sharp.IconButton()
        Me.dt_ind = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CmdUMes = New FontAwesome.Sharp.IconButton()
        Me.CmdUSemana = New FontAwesome.Sharp.IconButton()
        Me.CmdUhoy = New FontAwesome.Sharp.IconButton()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.dt_mes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dt_sem = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dt_hoy = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PanelEnLinea_Detalle = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblInd_det = New System.Windows.Forms.Label()
        Me.CmdCierreDetInd = New FontAwesome.Sharp.IconButton()
        Me.IconButton8 = New FontAwesome.Sharp.IconButton()
        Me.dg_lista_productos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelSup.SuspendLayout()
        Me.PanelSN.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dg_finanzas_sn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_sn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_resumen_sn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelListarOper.SuspendLayout()
        Me.PanelF5.SuspendLayout()
        Me.PanelF4.SuspendLayout()
        Me.PanelF3.SuspendLayout()
        Me.PanelF2.SuspendLayout()
        Me.PanelF1.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.PanelInventario.SuspendLayout()
        Me.PanelKardexDET.SuspendLayout()
        CType(Me.dg_kardex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelKardexCAB.SuspendLayout()
        CType(Me.dg_Inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dt_kpi_sn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_kpi_comercial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_kpi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.PanelEnLinea.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.dt_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.dt_ind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dt_mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_sem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_hoy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEnLinea_Detalle.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dg_lista_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.LblSocioNeg)
        Me.PanelSup.Controls.Add(Me.Button3)
        Me.PanelSup.Controls.Add(Me.Button2)
        Me.PanelSup.Controls.Add(Me.Button1)
        Me.PanelSup.Controls.Add(Me.IconButton4)
        Me.PanelSup.Controls.Add(Me.IconButton3)
        Me.PanelSup.Controls.Add(Me.CmdInventarios)
        Me.PanelSup.Controls.Add(Me.CmdSocioNeg)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Controls.Add(Me.CmdOscuro)
        Me.PanelSup.Controls.Add(Me.LBLIniciar)
        Me.PanelSup.Controls.Add(Me.CmdIniciarOper)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1265, 39)
        Me.PanelSup.TabIndex = 1
        '
        'LblSocioNeg
        '
        Me.LblSocioNeg.FlatAppearance.BorderSize = 0
        Me.LblSocioNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblSocioNeg.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSocioNeg.ForeColor = System.Drawing.Color.Silver
        Me.LblSocioNeg.Location = New System.Drawing.Point(116, 18)
        Me.LblSocioNeg.Name = "LblSocioNeg"
        Me.LblSocioNeg.Size = New System.Drawing.Size(89, 21)
        Me.LblSocioNeg.TabIndex = 94
        Me.LblSocioNeg.Text = "&SOCIOS NEG."
        Me.LblSocioNeg.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Silver
        Me.Button3.Location = New System.Drawing.Point(340, 18)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 21)
        Me.Button3.TabIndex = 93
        Me.Button3.Text = "&FINANZAS"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Silver
        Me.Button2.Location = New System.Drawing.Point(454, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 20)
        Me.Button2.TabIndex = 92
        Me.Button2.Text = "&DECLRACIONES"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Silver
        Me.Button1.Location = New System.Drawing.Point(232, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 21)
        Me.Button1.TabIndex = 91
        Me.Button1.Text = "&INVENTARIOS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'IconButton4
        '
        Me.IconButton4.FlatAppearance.BorderSize = 0
        Me.IconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton4.ForeColor = System.Drawing.Color.White
        Me.IconButton4.IconChar = FontAwesome.Sharp.IconChar.Coins
        Me.IconButton4.IconColor = System.Drawing.Color.White
        Me.IconButton4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton4.IconSize = 23
        Me.IconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton4.Location = New System.Drawing.Point(480, -2)
        Me.IconButton4.Name = "IconButton4"
        Me.IconButton4.Size = New System.Drawing.Size(40, 30)
        Me.IconButton4.TabIndex = 90
        Me.IconButton4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.IconButton4.UseVisualStyleBackColor = True
        '
        'IconButton3
        '
        Me.IconButton3.FlatAppearance.BorderSize = 0
        Me.IconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.White
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        Me.IconButton3.IconColor = System.Drawing.Color.White
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 25
        Me.IconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton3.Location = New System.Drawing.Point(361, -1)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(40, 30)
        Me.IconButton3.TabIndex = 89
        Me.IconButton3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.IconButton3.UseVisualStyleBackColor = True
        '
        'CmdInventarios
        '
        Me.CmdInventarios.FlatAppearance.BorderSize = 0
        Me.CmdInventarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdInventarios.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdInventarios.ForeColor = System.Drawing.Color.White
        Me.CmdInventarios.IconChar = FontAwesome.Sharp.IconChar.Slack
        Me.CmdInventarios.IconColor = System.Drawing.Color.White
        Me.CmdInventarios.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdInventarios.IconSize = 25
        Me.CmdInventarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdInventarios.Location = New System.Drawing.Point(260, -2)
        Me.CmdInventarios.Name = "CmdInventarios"
        Me.CmdInventarios.Size = New System.Drawing.Size(40, 30)
        Me.CmdInventarios.TabIndex = 88
        Me.CmdInventarios.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdInventarios.UseVisualStyleBackColor = True
        '
        'CmdSocioNeg
        '
        Me.CmdSocioNeg.FlatAppearance.BorderSize = 0
        Me.CmdSocioNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSocioNeg.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSocioNeg.ForeColor = System.Drawing.Color.White
        Me.CmdSocioNeg.IconChar = FontAwesome.Sharp.IconChar.FileContract
        Me.CmdSocioNeg.IconColor = System.Drawing.Color.White
        Me.CmdSocioNeg.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSocioNeg.IconSize = 25
        Me.CmdSocioNeg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSocioNeg.Location = New System.Drawing.Point(141, -1)
        Me.CmdSocioNeg.Name = "CmdSocioNeg"
        Me.CmdSocioNeg.Size = New System.Drawing.Size(40, 30)
        Me.CmdSocioNeg.TabIndex = 87
        Me.CmdSocioNeg.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdSocioNeg.UseVisualStyleBackColor = True
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
        Me.CmdRestaurar.IconSize = 25
        Me.CmdRestaurar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdRestaurar.Location = New System.Drawing.Point(1201, 6)
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
        Me.CmdCerrar.Location = New System.Drawing.Point(1233, 3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 29)
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
        Me.CmdMin.IconSize = 25
        Me.CmdMin.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdMin.Location = New System.Drawing.Point(1167, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(23, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'CmdOscuro
        '
        Me.CmdOscuro.FlatAppearance.BorderSize = 0
        Me.CmdOscuro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOscuro.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOscuro.ForeColor = System.Drawing.Color.White
        Me.CmdOscuro.IconChar = FontAwesome.Sharp.IconChar.ToggleOn
        Me.CmdOscuro.IconColor = System.Drawing.Color.White
        Me.CmdOscuro.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOscuro.IconSize = 25
        Me.CmdOscuro.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdOscuro.Location = New System.Drawing.Point(1061, 5)
        Me.CmdOscuro.Name = "CmdOscuro"
        Me.CmdOscuro.Size = New System.Drawing.Size(106, 35)
        Me.CmdOscuro.TabIndex = 32
        Me.CmdOscuro.Text = "MODO OSCURO"
        Me.CmdOscuro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdOscuro.UseVisualStyleBackColor = True
        '
        'LBLIniciar
        '
        Me.LBLIniciar.FlatAppearance.BorderSize = 0
        Me.LBLIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LBLIniciar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIniciar.ForeColor = System.Drawing.Color.Silver
        Me.LBLIniciar.Location = New System.Drawing.Point(24, 18)
        Me.LBLIniciar.Name = "LBLIniciar"
        Me.LBLIniciar.Size = New System.Drawing.Size(62, 21)
        Me.LBLIniciar.TabIndex = 85
        Me.LBLIniciar.Text = "&EN LINEA"
        Me.LBLIniciar.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LBLIniciar.UseVisualStyleBackColor = True
        '
        'CmdIniciarOper
        '
        Me.CmdIniciarOper.FlatAppearance.BorderSize = 0
        Me.CmdIniciarOper.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdIniciarOper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdIniciarOper.ForeColor = System.Drawing.Color.White
        Me.CmdIniciarOper.IconChar = FontAwesome.Sharp.IconChar.Signal
        Me.CmdIniciarOper.IconColor = System.Drawing.Color.White
        Me.CmdIniciarOper.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdIniciarOper.IconSize = 25
        Me.CmdIniciarOper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdIniciarOper.Location = New System.Drawing.Point(34, 0)
        Me.CmdIniciarOper.Name = "CmdIniciarOper"
        Me.CmdIniciarOper.Size = New System.Drawing.Size(40, 30)
        Me.CmdIniciarOper.TabIndex = 84
        Me.CmdIniciarOper.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdIniciarOper.UseVisualStyleBackColor = True
        '
        'PanelSN
        '
        Me.PanelSN.BackColor = System.Drawing.Color.Gray
        Me.PanelSN.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelSN.Controls.Add(Me.PanelListarOper)
        Me.PanelSN.Location = New System.Drawing.Point(1177, 192)
        Me.PanelSN.Name = "PanelSN"
        Me.PanelSN.Size = New System.Drawing.Size(480, 464)
        Me.PanelSN.TabIndex = 9
        Me.PanelSN.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.799!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.201!))
        Me.TableLayoutPanel1.Controls.Add(Me.dg_finanzas_sn, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dg_detalle_sn, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dg_resumen_sn, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chart1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(160, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.83382!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.16618!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(320, 464)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'dg_finanzas_sn
        '
        Me.dg_finanzas_sn.AllowUserToAddRows = False
        Me.dg_finanzas_sn.AllowUserToDeleteRows = False
        Me.dg_finanzas_sn.AllowUserToResizeRows = False
        Me.dg_finanzas_sn.BackgroundColor = System.Drawing.Color.White
        Me.dg_finanzas_sn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_finanzas_sn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_finanzas_sn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_finanzas_sn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_finanzas_sn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        Me.dg_finanzas_sn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_finanzas_sn.GridColor = System.Drawing.Color.White
        Me.dg_finanzas_sn.Location = New System.Drawing.Point(194, 122)
        Me.dg_finanzas_sn.MultiSelect = False
        Me.dg_finanzas_sn.Name = "dg_finanzas_sn"
        Me.dg_finanzas_sn.ReadOnly = True
        Me.dg_finanzas_sn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_finanzas_sn.RowHeadersVisible = False
        Me.dg_finanzas_sn.RowTemplate.Height = 25
        Me.dg_finanzas_sn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_finanzas_sn.Size = New System.Drawing.Size(123, 339)
        Me.dg_finanzas_sn.TabIndex = 4
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "dg_finanzas_sn"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'dg_detalle_sn
        '
        Me.dg_detalle_sn.AllowUserToAddRows = False
        Me.dg_detalle_sn.AllowUserToDeleteRows = False
        Me.dg_detalle_sn.AllowUserToResizeRows = False
        Me.dg_detalle_sn.BackgroundColor = System.Drawing.Color.White
        Me.dg_detalle_sn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_detalle_sn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_detalle_sn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_detalle_sn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_detalle_sn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.dg_detalle_sn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_detalle_sn.GridColor = System.Drawing.Color.White
        Me.dg_detalle_sn.Location = New System.Drawing.Point(3, 122)
        Me.dg_detalle_sn.MultiSelect = False
        Me.dg_detalle_sn.Name = "dg_detalle_sn"
        Me.dg_detalle_sn.ReadOnly = True
        Me.dg_detalle_sn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_detalle_sn.RowHeadersVisible = False
        Me.dg_detalle_sn.RowTemplate.Height = 25
        Me.dg_detalle_sn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_detalle_sn.Size = New System.Drawing.Size(185, 339)
        Me.dg_detalle_sn.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "dg_detalle_sn"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'dg_resumen_sn
        '
        Me.dg_resumen_sn.AllowUserToAddRows = False
        Me.dg_resumen_sn.AllowUserToDeleteRows = False
        Me.dg_resumen_sn.AllowUserToResizeRows = False
        Me.dg_resumen_sn.BackgroundColor = System.Drawing.Color.White
        Me.dg_resumen_sn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_resumen_sn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_resumen_sn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_resumen_sn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_resumen_sn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo})
        Me.dg_resumen_sn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_resumen_sn.GridColor = System.Drawing.Color.White
        Me.dg_resumen_sn.Location = New System.Drawing.Point(3, 3)
        Me.dg_resumen_sn.MultiSelect = False
        Me.dg_resumen_sn.Name = "dg_resumen_sn"
        Me.dg_resumen_sn.ReadOnly = True
        Me.dg_resumen_sn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_resumen_sn.RowHeadersVisible = False
        Me.dg_resumen_sn.RowTemplate.Height = 25
        Me.dg_resumen_sn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_resumen_sn.Size = New System.Drawing.Size(185, 113)
        Me.dg_resumen_sn.TabIndex = 2
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "dg_resumen_sn"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 80
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(194, 3)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(123, 113)
        Me.Chart1.TabIndex = 5
        Me.Chart1.Text = "Chart1"
        '
        'PanelListarOper
        '
        Me.PanelListarOper.AutoScroll = True
        Me.PanelListarOper.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelListarOper.Controls.Add(Me.PanelF5)
        Me.PanelListarOper.Controls.Add(Me.PanelF4)
        Me.PanelListarOper.Controls.Add(Me.PanelF3)
        Me.PanelListarOper.Controls.Add(Me.PanelF2)
        Me.PanelListarOper.Controls.Add(Me.PanelF1)
        Me.PanelListarOper.Controls.Add(Me.Panel19)
        Me.PanelListarOper.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelListarOper.Location = New System.Drawing.Point(0, 0)
        Me.PanelListarOper.Name = "PanelListarOper"
        Me.PanelListarOper.Size = New System.Drawing.Size(160, 464)
        Me.PanelListarOper.TabIndex = 0
        '
        'PanelF5
        '
        Me.PanelF5.Controls.Add(Me.FlowLayoutPanel4)
        Me.PanelF5.Controls.Add(Me.IconButton6)
        Me.PanelF5.Controls.Add(Me.TextBox3)
        Me.PanelF5.Controls.Add(Me.Label1)
        Me.PanelF5.Controls.Add(Me.CheckEstadoComp)
        Me.PanelF5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelF5.Location = New System.Drawing.Point(0, 360)
        Me.PanelF5.Name = "PanelF5"
        Me.PanelF5.Size = New System.Drawing.Size(160, 100)
        Me.PanelF5.TabIndex = 27
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.AutoScroll = True
        Me.FlowLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(8, 39)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(133, 59)
        Me.FlowLayoutPanel4.TabIndex = 73
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
        Me.IconButton6.Location = New System.Drawing.Point(118, 20)
        Me.IconButton6.Name = "IconButton6"
        Me.IconButton6.Size = New System.Drawing.Size(22, 20)
        Me.IconButton6.TabIndex = 74
        Me.IconButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton6.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(53, 21)
        Me.TextBox3.MaxLength = 4
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(66, 16)
        Me.TextBox3.TabIndex = 72
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "CODIGO:"
        '
        'CheckEstadoComp
        '
        Me.CheckEstadoComp.AutoSize = True
        Me.CheckEstadoComp.Checked = True
        Me.CheckEstadoComp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckEstadoComp.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckEstadoComp.ForeColor = System.Drawing.Color.White
        Me.CheckEstadoComp.Location = New System.Drawing.Point(10, 3)
        Me.CheckEstadoComp.Name = "CheckEstadoComp"
        Me.CheckEstadoComp.Size = New System.Drawing.Size(131, 17)
        Me.CheckEstadoComp.TabIndex = 68
        Me.CheckEstadoComp.Text = "ESTADOS COMPROB."
        Me.CheckEstadoComp.UseVisualStyleBackColor = True
        '
        'PanelF4
        '
        Me.PanelF4.Controls.Add(Me.Label19)
        Me.PanelF4.Controls.Add(Me.Label34)
        Me.PanelF4.Controls.Add(Me.Checkfechas)
        Me.PanelF4.Controls.Add(Me.RadioButton4)
        Me.PanelF4.Controls.Add(Me.t_fechaIni)
        Me.PanelF4.Controls.Add(Me.RadioButton3)
        Me.PanelF4.Controls.Add(Me.t_fechaFin)
        Me.PanelF4.Controls.Add(Me.RadioButton1)
        Me.PanelF4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelF4.Location = New System.Drawing.Point(0, 212)
        Me.PanelF4.Name = "PanelF4"
        Me.PanelF4.Size = New System.Drawing.Size(160, 148)
        Me.PanelF4.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(24, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "DESDE :"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(21, 97)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(46, 13)
        Me.Label34.TabIndex = 65
        Me.Label34.Text = "HASTA :"
        '
        'Checkfechas
        '
        Me.Checkfechas.AutoSize = True
        Me.Checkfechas.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Checkfechas.ForeColor = System.Drawing.Color.White
        Me.Checkfechas.Location = New System.Drawing.Point(9, 3)
        Me.Checkfechas.Name = "Checkfechas"
        Me.Checkfechas.Size = New System.Drawing.Size(124, 17)
        Me.Checkfechas.TabIndex = 67
        Me.Checkfechas.Text = "RANGO DE FECHAS"
        Me.Checkfechas.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RadioButton4.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton4.ForeColor = System.Drawing.Color.White
        Me.RadioButton4.Location = New System.Drawing.Point(17, 20)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(60, 16)
        Me.RadioButton4.TabIndex = 63
        Me.RadioButton4.Text = "EMISION"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        't_fechaIni
        '
        Me.t_fechaIni.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.t_fechaIni.Location = New System.Drawing.Point(22, 71)
        Me.t_fechaIni.Name = "t_fechaIni"
        Me.t_fechaIni.Size = New System.Drawing.Size(104, 23)
        Me.t_fechaIni.TabIndex = 33
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RadioButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton3.ForeColor = System.Drawing.Color.White
        Me.RadioButton3.Location = New System.Drawing.Point(17, 36)
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
        Me.t_fechaFin.Location = New System.Drawing.Point(22, 114)
        Me.t_fechaFin.Name = "t_fechaFin"
        Me.t_fechaFin.Size = New System.Drawing.Size(104, 23)
        Me.t_fechaFin.TabIndex = 36
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(83, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(48, 16)
        Me.RadioButton1.TabIndex = 66
        Me.RadioButton1.Text = "VCTO."
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'PanelF3
        '
        Me.PanelF3.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelF3.Controls.Add(Me.CheckOper)
        Me.PanelF3.Controls.Add(Me.Label4)
        Me.PanelF3.Controls.Add(Me.FlowLayoutPanel2)
        Me.PanelF3.Controls.Add(Me.TextBox1)
        Me.PanelF3.Controls.Add(Me.CmdBusoper_filtro)
        Me.PanelF3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelF3.Location = New System.Drawing.Point(0, 192)
        Me.PanelF3.Name = "PanelF3"
        Me.PanelF3.Size = New System.Drawing.Size(160, 20)
        Me.PanelF3.TabIndex = 26
        '
        'CheckOper
        '
        Me.CheckOper.AutoSize = True
        Me.CheckOper.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckOper.ForeColor = System.Drawing.Color.White
        Me.CheckOper.Location = New System.Drawing.Point(9, 3)
        Me.CheckOper.Name = "CheckOper"
        Me.CheckOper.Size = New System.Drawing.Size(86, 17)
        Me.CheckOper.TabIndex = 72
        Me.CheckOper.Text = "OPERACION"
        Me.CheckOper.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(2, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "CODIGO:"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(8, 39)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(133, 104)
        Me.FlowLayoutPanel2.TabIndex = 70
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(55, 22)
        Me.TextBox1.MaxLength = 4
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 16)
        Me.TextBox1.TabIndex = 73
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.CmdBusoper_filtro.Location = New System.Drawing.Point(121, 21)
        Me.CmdBusoper_filtro.Name = "CmdBusoper_filtro"
        Me.CmdBusoper_filtro.Size = New System.Drawing.Size(22, 19)
        Me.CmdBusoper_filtro.TabIndex = 34
        Me.CmdBusoper_filtro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusoper_filtro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBusoper_filtro.UseVisualStyleBackColor = False
        '
        'PanelF2
        '
        Me.PanelF2.Controls.Add(Me.FlowSN)
        Me.PanelF2.Controls.Add(Me.CmdBuscaSN)
        Me.PanelF2.Controls.Add(Me.Label3)
        Me.PanelF2.Controls.Add(Me.TxtSN)
        Me.PanelF2.Controls.Add(Me.CheckSN)
        Me.PanelF2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelF2.Location = New System.Drawing.Point(0, 172)
        Me.PanelF2.Name = "PanelF2"
        Me.PanelF2.Size = New System.Drawing.Size(160, 20)
        Me.PanelF2.TabIndex = 1
        '
        'FlowSN
        '
        Me.FlowSN.AutoScroll = True
        Me.FlowSN.BackColor = System.Drawing.Color.Transparent
        Me.FlowSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowSN.Location = New System.Drawing.Point(6, 38)
        Me.FlowSN.Name = "FlowSN"
        Me.FlowSN.Size = New System.Drawing.Size(133, 104)
        Me.FlowSN.TabIndex = 69
        '
        'CmdBuscaSN
        '
        Me.CmdBuscaSN.BackColor = System.Drawing.Color.Transparent
        Me.CmdBuscaSN.FlatAppearance.BorderSize = 0
        Me.CmdBuscaSN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBuscaSN.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBuscaSN.ForeColor = System.Drawing.Color.White
        Me.CmdBuscaSN.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdBuscaSN.IconColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdBuscaSN.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdBuscaSN.IconSize = 20
        Me.CmdBuscaSN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscaSN.Location = New System.Drawing.Point(119, 20)
        Me.CmdBuscaSN.Name = "CmdBuscaSN"
        Me.CmdBuscaSN.Size = New System.Drawing.Size(22, 20)
        Me.CmdBuscaSN.TabIndex = 70
        Me.CmdBuscaSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscaSN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBuscaSN.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "CODIGO:"
        '
        'TxtSN
        '
        Me.TxtSN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSN.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSN.Location = New System.Drawing.Point(54, 20)
        Me.TxtSN.MaxLength = 100
        Me.TxtSN.Name = "TxtSN"
        Me.TxtSN.Size = New System.Drawing.Size(66, 16)
        Me.TxtSN.TabIndex = 68
        '
        'CheckSN
        '
        Me.CheckSN.AutoSize = True
        Me.CheckSN.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckSN.ForeColor = System.Drawing.Color.White
        Me.CheckSN.Location = New System.Drawing.Point(10, 2)
        Me.CheckSN.Name = "CheckSN"
        Me.CheckSN.Size = New System.Drawing.Size(109, 17)
        Me.CheckSN.TabIndex = 67
        Me.CheckSN.Text = "SOCIO NEGOCIO"
        Me.CheckSN.UseVisualStyleBackColor = True
        '
        'PanelF1
        '
        Me.PanelF1.Controls.Add(Me.FlowLayoutPanel3)
        Me.PanelF1.Controls.Add(Me.IconButton5)
        Me.PanelF1.Controls.Add(Me.TextBox2)
        Me.PanelF1.Controls.Add(Me.Label5)
        Me.PanelF1.Controls.Add(Me.CheckLocales)
        Me.PanelF1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelF1.Location = New System.Drawing.Point(0, 72)
        Me.PanelF1.Name = "PanelF1"
        Me.PanelF1.Size = New System.Drawing.Size(160, 100)
        Me.PanelF1.TabIndex = 3
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AutoScroll = True
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(8, 39)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(133, 60)
        Me.FlowLayoutPanel3.TabIndex = 73
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
        Me.IconButton5.Location = New System.Drawing.Point(118, 20)
        Me.IconButton5.Name = "IconButton5"
        Me.IconButton5.Size = New System.Drawing.Size(22, 20)
        Me.IconButton5.TabIndex = 74
        Me.IconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton5.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(53, 21)
        Me.TextBox2.MaxLength = 4
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(66, 16)
        Me.TextBox2.TabIndex = 72
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "CODIGO:"
        '
        'CheckLocales
        '
        Me.CheckLocales.AutoSize = True
        Me.CheckLocales.Checked = True
        Me.CheckLocales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckLocales.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckLocales.ForeColor = System.Drawing.Color.White
        Me.CheckLocales.Location = New System.Drawing.Point(10, 3)
        Me.CheckLocales.Name = "CheckLocales"
        Me.CheckLocales.Size = New System.Drawing.Size(70, 17)
        Me.CheckLocales.TabIndex = 68
        Me.CheckLocales.Text = "LOCALES"
        Me.CheckLocales.UseVisualStyleBackColor = True
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.CmdContraerMenu)
        Me.Panel19.Controls.Add(Me.CmdMoneda)
        Me.Panel19.Controls.Add(Me.CmdMuestraFiltro)
        Me.Panel19.Controls.Add(Me.Label35)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(0, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(160, 72)
        Me.Panel19.TabIndex = 0
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
        Me.CmdContraerMenu.Location = New System.Drawing.Point(6, 2)
        Me.CmdContraerMenu.Name = "CmdContraerMenu"
        Me.CmdContraerMenu.Size = New System.Drawing.Size(34, 19)
        Me.CmdContraerMenu.TabIndex = 57
        Me.CmdContraerMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdContraerMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdContraerMenu.UseVisualStyleBackColor = True
        '
        'CmdMoneda
        '
        Me.CmdMoneda.FlatAppearance.BorderSize = 0
        Me.CmdMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMoneda.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMoneda.ForeColor = System.Drawing.Color.White
        Me.CmdMoneda.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdMoneda.IconColor = System.Drawing.Color.White
        Me.CmdMoneda.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMoneda.IconSize = 25
        Me.CmdMoneda.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdMoneda.Location = New System.Drawing.Point(11, 44)
        Me.CmdMoneda.Name = "CmdMoneda"
        Me.CmdMoneda.Size = New System.Drawing.Size(125, 22)
        Me.CmdMoneda.TabIndex = 41
        Me.CmdMoneda.Text = "SOLES (S/)"
        Me.CmdMoneda.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdMoneda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMoneda.UseVisualStyleBackColor = True
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
        Me.CmdMuestraFiltro.Location = New System.Drawing.Point(39, 2)
        Me.CmdMuestraFiltro.Name = "CmdMuestraFiltro"
        Me.CmdMuestraFiltro.Size = New System.Drawing.Size(109, 23)
        Me.CmdMuestraFiltro.TabIndex = 56
        Me.CmdMuestraFiltro.Text = "MOSTRAR "
        Me.CmdMuestraFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMuestraFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMuestraFiltro.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(14, 28)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(57, 13)
        Me.Label35.TabIndex = 40
        Me.Label35.Text = "MONEDA:"
        '
        'PanelInventario
        '
        Me.PanelInventario.Controls.Add(Me.PanelKardexDET)
        Me.PanelInventario.Controls.Add(Me.Panel1)
        Me.PanelInventario.Controls.Add(Me.PanelKardexCAB)
        Me.PanelInventario.Controls.Add(Me.Panel2)
        Me.PanelInventario.Location = New System.Drawing.Point(208, 45)
        Me.PanelInventario.Name = "PanelInventario"
        Me.PanelInventario.Size = New System.Drawing.Size(969, 497)
        Me.PanelInventario.TabIndex = 10
        Me.PanelInventario.Visible = False
        '
        'PanelKardexDET
        '
        Me.PanelKardexDET.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelKardexDET.Controls.Add(Me.dg_kardex)
        Me.PanelKardexDET.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelKardexDET.Location = New System.Drawing.Point(0, 283)
        Me.PanelKardexDET.Name = "PanelKardexDET"
        Me.PanelKardexDET.Size = New System.Drawing.Size(969, 214)
        Me.PanelKardexDET.TabIndex = 8
        '
        'dg_kardex
        '
        Me.dg_kardex.AllowUserToAddRows = False
        Me.dg_kardex.AllowUserToDeleteRows = False
        Me.dg_kardex.AllowUserToResizeRows = False
        Me.dg_kardex.BackgroundColor = System.Drawing.Color.White
        Me.dg_kardex.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_kardex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_kardex.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_kardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_kardex.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4})
        Me.dg_kardex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_kardex.GridColor = System.Drawing.Color.White
        Me.dg_kardex.Location = New System.Drawing.Point(0, 0)
        Me.dg_kardex.MultiSelect = False
        Me.dg_kardex.Name = "dg_kardex"
        Me.dg_kardex.ReadOnly = True
        Me.dg_kardex.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_kardex.RowHeadersVisible = False
        Me.dg_kardex.RowTemplate.Height = 25
        Me.dg_kardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_kardex.Size = New System.Drawing.Size(969, 214)
        Me.dg_kardex.TabIndex = 4
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "dg_kardex"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Chek_quitar_anul)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.IconButton2)
        Me.Panel1.Controls.Add(Me.IconButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 253)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(969, 30)
        Me.Panel1.TabIndex = 7
        '
        'Chek_quitar_anul
        '
        Me.Chek_quitar_anul.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chek_quitar_anul.AutoSize = True
        Me.Chek_quitar_anul.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chek_quitar_anul.ForeColor = System.Drawing.Color.White
        Me.Chek_quitar_anul.Location = New System.Drawing.Point(671, 9)
        Me.Chek_quitar_anul.Name = "Chek_quitar_anul"
        Me.Chek_quitar_anul.Size = New System.Drawing.Size(111, 16)
        Me.Chek_quitar_anul.TabIndex = 98
        Me.Chek_quitar_anul.Text = "OCULTAR ANULADOS"
        Me.Chek_quitar_anul.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 23)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "DETALLE KARDEX : "
        '
        'IconButton2
        '
        Me.IconButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton2.ForeColor = System.Drawing.Color.White
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        Me.IconButton2.IconColor = System.Drawing.Color.White
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 20
        Me.IconButton2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton2.Location = New System.Drawing.Point(885, 2)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(81, 20)
        Me.IconButton2.TabIndex = 90
        Me.IconButton2.Text = "MAXIMIZAR"
        Me.IconButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'IconButton1
        '
        Me.IconButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.White
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        Me.IconButton1.IconColor = System.Drawing.Color.White
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 20
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton1.Location = New System.Drawing.Point(811, 3)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(81, 20)
        Me.IconButton1.TabIndex = 89
        Me.IconButton1.Text = "OCULTAR"
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'PanelKardexCAB
        '
        Me.PanelKardexCAB.Controls.Add(Me.dg_Inventario)
        Me.PanelKardexCAB.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelKardexCAB.Location = New System.Drawing.Point(0, 38)
        Me.PanelKardexCAB.Name = "PanelKardexCAB"
        Me.PanelKardexCAB.Size = New System.Drawing.Size(969, 215)
        Me.PanelKardexCAB.TabIndex = 5
        '
        'dg_Inventario
        '
        Me.dg_Inventario.AllowUserToAddRows = False
        Me.dg_Inventario.AllowUserToDeleteRows = False
        Me.dg_Inventario.AllowUserToResizeRows = False
        Me.dg_Inventario.BackgroundColor = System.Drawing.Color.White
        Me.dg_Inventario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_Inventario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_Inventario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_Inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Inventario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3})
        Me.dg_Inventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_Inventario.GridColor = System.Drawing.Color.White
        Me.dg_Inventario.Location = New System.Drawing.Point(0, 0)
        Me.dg_Inventario.MultiSelect = False
        Me.dg_Inventario.Name = "dg_Inventario"
        Me.dg_Inventario.ReadOnly = True
        Me.dg_Inventario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_Inventario.RowHeadersVisible = False
        Me.dg_Inventario.RowTemplate.Height = 25
        Me.dg_Inventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_Inventario.Size = New System.Drawing.Size(969, 215)
        Me.dg_Inventario.TabIndex = 3
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "dg_Inventario"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TxtAlmTransf)
        Me.Panel2.Controls.Add(Me.CmdAlmTransf)
        Me.Panel2.Controls.Add(Me.Label38)
        Me.Panel2.Controls.Add(Me.CmdMostrarInventario)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Inv_fechaini)
        Me.Panel2.Controls.Add(Me.Inv_fechafin)
        Me.Panel2.Controls.Add(Me.IconButton7)
        Me.Panel2.Controls.Add(Me.CmdFiltroPeriodo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(969, 38)
        Me.Panel2.TabIndex = 0
        '
        'TxtAlmTransf
        '
        Me.TxtAlmTransf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAlmTransf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAlmTransf.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAlmTransf.Location = New System.Drawing.Point(54, 6)
        Me.TxtAlmTransf.MaxLength = 500
        Me.TxtAlmTransf.Name = "TxtAlmTransf"
        Me.TxtAlmTransf.Size = New System.Drawing.Size(33, 22)
        Me.TxtAlmTransf.TabIndex = 97
        Me.TxtAlmTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdAlmTransf
        '
        Me.CmdAlmTransf.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.CmdAlmTransf.FlatAppearance.BorderSize = 0
        Me.CmdAlmTransf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAlmTransf.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAlmTransf.ForeColor = System.Drawing.Color.White
        Me.CmdAlmTransf.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdAlmTransf.IconColor = System.Drawing.Color.White
        Me.CmdAlmTransf.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAlmTransf.IconSize = 25
        Me.CmdAlmTransf.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdAlmTransf.Location = New System.Drawing.Point(93, 1)
        Me.CmdAlmTransf.Name = "CmdAlmTransf"
        Me.CmdAlmTransf.Size = New System.Drawing.Size(161, 31)
        Me.CmdAlmTransf.TabIndex = 95
        Me.CmdAlmTransf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAlmTransf.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdAlmTransf.UseVisualStyleBackColor = False
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(3, 2)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(71, 27)
        Me.Label38.TabIndex = 96
        Me.Label38.Text = "CODIGO ALMACEN :"
        '
        'CmdMostrarInventario
        '
        Me.CmdMostrarInventario.FlatAppearance.BorderSize = 0
        Me.CmdMostrarInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMostrarInventario.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMostrarInventario.ForeColor = System.Drawing.Color.White
        Me.CmdMostrarInventario.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.CmdMostrarInventario.IconColor = System.Drawing.Color.White
        Me.CmdMostrarInventario.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMostrarInventario.IconSize = 20
        Me.CmdMostrarInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMostrarInventario.Location = New System.Drawing.Point(850, 4)
        Me.CmdMostrarInventario.Name = "CmdMostrarInventario"
        Me.CmdMostrarInventario.Size = New System.Drawing.Size(108, 23)
        Me.CmdMostrarInventario.TabIndex = 94
        Me.CmdMostrarInventario.Text = "MOSTRAR "
        Me.CmdMostrarInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMostrarInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMostrarInventario.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(499, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "DESDE :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(667, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "HASTA :"
        '
        'Inv_fechaini
        '
        Me.Inv_fechaini.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inv_fechaini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Inv_fechaini.Location = New System.Drawing.Point(548, 5)
        Me.Inv_fechaini.Name = "Inv_fechaini"
        Me.Inv_fechaini.Size = New System.Drawing.Size(104, 22)
        Me.Inv_fechaini.TabIndex = 90
        '
        'Inv_fechafin
        '
        Me.Inv_fechafin.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inv_fechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Inv_fechafin.Location = New System.Drawing.Point(719, 5)
        Me.Inv_fechafin.Name = "Inv_fechafin"
        Me.Inv_fechafin.Size = New System.Drawing.Size(104, 22)
        Me.Inv_fechafin.TabIndex = 92
        '
        'IconButton7
        '
        Me.IconButton7.FlatAppearance.BorderSize = 0
        Me.IconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton7.ForeColor = System.Drawing.Color.White
        Me.IconButton7.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.IconButton7.IconColor = System.Drawing.Color.White
        Me.IconButton7.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton7.IconSize = 30
        Me.IconButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton7.Location = New System.Drawing.Point(254, 0)
        Me.IconButton7.Name = "IconButton7"
        Me.IconButton7.Size = New System.Drawing.Size(119, 34)
        Me.IconButton7.TabIndex = 89
        Me.IconButton7.Text = "VALOR COSRO PROMEDIO"
        Me.IconButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton7.UseVisualStyleBackColor = True
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
        Me.CmdFiltroPeriodo.Location = New System.Drawing.Point(376, -2)
        Me.CmdFiltroPeriodo.Name = "CmdFiltroPeriodo"
        Me.CmdFiltroPeriodo.Size = New System.Drawing.Size(133, 35)
        Me.CmdFiltroPeriodo.TabIndex = 88
        Me.CmdFiltroPeriodo.Text = "MOVIMIENTOS  HOY"
        Me.CmdFiltroPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFiltroPeriodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdFiltroPeriodo.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.dt_kpi_sn, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dt_kpi_comercial, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dt_kpi, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 40)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(367, 223)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'dt_kpi_sn
        '
        Me.dt_kpi_sn.AllowUserToAddRows = False
        Me.dt_kpi_sn.AllowUserToDeleteRows = False
        Me.dt_kpi_sn.AllowUserToResizeRows = False
        Me.dt_kpi_sn.BackgroundColor = System.Drawing.Color.White
        Me.dt_kpi_sn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_kpi_sn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_kpi_sn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_kpi_sn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_kpi_sn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7})
        Me.dt_kpi_sn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dt_kpi_sn.GridColor = System.Drawing.Color.White
        Me.dt_kpi_sn.Location = New System.Drawing.Point(247, 3)
        Me.dt_kpi_sn.MultiSelect = False
        Me.dt_kpi_sn.Name = "dt_kpi_sn"
        Me.dt_kpi_sn.ReadOnly = True
        Me.dt_kpi_sn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_kpi_sn.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_kpi_sn.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dt_kpi_sn.RowTemplate.Height = 25
        Me.dt_kpi_sn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_kpi_sn.Size = New System.Drawing.Size(117, 217)
        Me.dt_kpi_sn.TabIndex = 55
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "dt_kpi_sn"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'dt_kpi_comercial
        '
        Me.dt_kpi_comercial.AllowUserToAddRows = False
        Me.dt_kpi_comercial.AllowUserToDeleteRows = False
        Me.dt_kpi_comercial.AllowUserToResizeRows = False
        Me.dt_kpi_comercial.BackgroundColor = System.Drawing.Color.White
        Me.dt_kpi_comercial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_kpi_comercial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_kpi_comercial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_kpi_comercial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_kpi_comercial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6})
        Me.dt_kpi_comercial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dt_kpi_comercial.GridColor = System.Drawing.Color.White
        Me.dt_kpi_comercial.Location = New System.Drawing.Point(125, 3)
        Me.dt_kpi_comercial.MultiSelect = False
        Me.dt_kpi_comercial.Name = "dt_kpi_comercial"
        Me.dt_kpi_comercial.ReadOnly = True
        Me.dt_kpi_comercial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_kpi_comercial.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_kpi_comercial.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dt_kpi_comercial.RowTemplate.Height = 25
        Me.dt_kpi_comercial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_kpi_comercial.Size = New System.Drawing.Size(116, 217)
        Me.dt_kpi_comercial.TabIndex = 54
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "dt_kpi_comercial"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'dt_kpi
        '
        Me.dt_kpi.AllowUserToAddRows = False
        Me.dt_kpi.AllowUserToDeleteRows = False
        Me.dt_kpi.AllowUserToResizeRows = False
        Me.dt_kpi.BackgroundColor = System.Drawing.Color.White
        Me.dt_kpi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_kpi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_kpi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_kpi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_kpi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5})
        Me.dt_kpi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dt_kpi.GridColor = System.Drawing.Color.White
        Me.dt_kpi.Location = New System.Drawing.Point(3, 3)
        Me.dt_kpi.MultiSelect = False
        Me.dt_kpi.Name = "dt_kpi"
        Me.dt_kpi.ReadOnly = True
        Me.dt_kpi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_kpi.RowHeadersVisible = False
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_kpi.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dt_kpi.RowTemplate.Height = 25
        Me.dt_kpi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_kpi.Size = New System.Drawing.Size(116, 217)
        Me.dt_kpi.TabIndex = 53
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "dt_kpi"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
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
        Me.CmdTipoCosto.Location = New System.Drawing.Point(10, 16)
        Me.CmdTipoCosto.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.CmdTipoCosto.Name = "CmdTipoCosto"
        Me.CmdTipoCosto.Size = New System.Drawing.Size(121, 21)
        Me.CmdTipoCosto.TabIndex = 52
        Me.CmdTipoCosto.Tag = "90"
        Me.CmdTipoCosto.Text = "NEGOCIO"
        Me.CmdTipoCosto.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdTipoCosto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdTipoCosto.UseVisualStyleBackColor = False
        '
        'blb_costo_ult
        '
        Me.blb_costo_ult.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blb_costo_ult.Location = New System.Drawing.Point(8, 0)
        Me.blb_costo_ult.Name = "blb_costo_ult"
        Me.blb_costo_ult.Size = New System.Drawing.Size(75, 19)
        Me.blb_costo_ult.TabIndex = 51
        Me.blb_costo_ult.Text = "INFORMACION :"
        Me.blb_costo_ult.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmdVxA
        '
        Me.CmdVxA.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdVxA.FlatAppearance.BorderSize = 0
        Me.CmdVxA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVxA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdVxA.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdVxA.IconChar = FontAwesome.Sharp.IconChar.ICursor
        Me.CmdVxA.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdVxA.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdVxA.IconSize = 18
        Me.CmdVxA.Location = New System.Drawing.Point(6, 2)
        Me.CmdVxA.Name = "CmdVxA"
        Me.CmdVxA.Size = New System.Drawing.Size(70, 28)
        Me.CmdVxA.TabIndex = 82
        Me.CmdVxA.Text = "VxA"
        Me.CmdVxA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdVxA.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.CmdActualizar)
        Me.Panel3.Controls.Add(Me.CmdTipoCosto)
        Me.Panel3.Controls.Add(Me.blb_costo_ult)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(367, 40)
        Me.Panel3.TabIndex = 1
        '
        'CmdActualizar
        '
        Me.CmdActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdActualizar.FlatAppearance.BorderSize = 0
        Me.CmdActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdActualizar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdActualizar.IconChar = FontAwesome.Sharp.IconChar.Circle
        Me.CmdActualizar.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdActualizar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdActualizar.IconSize = 18
        Me.CmdActualizar.Location = New System.Drawing.Point(190, 6)
        Me.CmdActualizar.Name = "CmdActualizar"
        Me.CmdActualizar.Size = New System.Drawing.Size(100, 28)
        Me.CmdActualizar.TabIndex = 83
        Me.CmdActualizar.Text = "Actualizar"
        Me.CmdActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdActualizar.UseVisualStyleBackColor = False
        '
        'PanelEnLinea
        '
        Me.PanelEnLinea.Controls.Add(Me.TableLayoutPanel4)
        Me.PanelEnLinea.Controls.Add(Me.Panel5)
        Me.PanelEnLinea.Controls.Add(Me.TableLayoutPanel3)
        Me.PanelEnLinea.Controls.Add(Me.Panel7)
        Me.PanelEnLinea.Controls.Add(Me.TableLayoutPanel2)
        Me.PanelEnLinea.Controls.Add(Me.Panel3)
        Me.PanelEnLinea.Location = New System.Drawing.Point(1194, 54)
        Me.PanelEnLinea.Name = "PanelEnLinea"
        Me.PanelEnLinea.Size = New System.Drawing.Size(367, 329)
        Me.PanelEnLinea.TabIndex = 12
        Me.PanelEnLinea.Visible = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.dt_user, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 454)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(367, 0)
        Me.TableLayoutPanel4.TabIndex = 5
        '
        'dt_user
        '
        Me.dt_user.AllowUserToAddRows = False
        Me.dt_user.AllowUserToDeleteRows = False
        Me.dt_user.AllowUserToResizeRows = False
        Me.dt_user.BackgroundColor = System.Drawing.Color.White
        Me.dt_user.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_user.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_user.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_user.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11})
        Me.dt_user.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dt_user.GridColor = System.Drawing.Color.White
        Me.dt_user.Location = New System.Drawing.Point(3, 3)
        Me.dt_user.MultiSelect = False
        Me.dt_user.Name = "dt_user"
        Me.dt_user.ReadOnly = True
        Me.dt_user.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_user.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_user.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dt_user.RowTemplate.Height = 25
        Me.dt_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_user.Size = New System.Drawing.Size(177, 1)
        Me.dt_user.TabIndex = 54
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "dt_user"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 80
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.CmdVxM2)
        Me.Panel4.Controls.Add(Me.CmdAxF)
        Me.Panel4.Controls.Add(Me.CmdVxF)
        Me.Panel4.Controls.Add(Me.CmdVxA)
        Me.Panel4.Controls.Add(Me.dt_ind)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(186, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(178, 1)
        Me.Panel4.TabIndex = 55
        '
        'CmdVxM2
        '
        Me.CmdVxM2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdVxM2.FlatAppearance.BorderSize = 0
        Me.CmdVxM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVxM2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdVxM2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdVxM2.IconChar = FontAwesome.Sharp.IconChar.ICursor
        Me.CmdVxM2.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdVxM2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdVxM2.IconSize = 18
        Me.CmdVxM2.Location = New System.Drawing.Point(6, 103)
        Me.CmdVxM2.Name = "CmdVxM2"
        Me.CmdVxM2.Size = New System.Drawing.Size(70, 28)
        Me.CmdVxM2.TabIndex = 85
        Me.CmdVxM2.Text = "VxM2"
        Me.CmdVxM2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdVxM2.UseVisualStyleBackColor = False
        '
        'CmdAxF
        '
        Me.CmdAxF.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdAxF.FlatAppearance.BorderSize = 0
        Me.CmdAxF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAxF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAxF.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdAxF.IconChar = FontAwesome.Sharp.IconChar.ICursor
        Me.CmdAxF.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdAxF.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAxF.IconSize = 18
        Me.CmdAxF.Location = New System.Drawing.Point(6, 70)
        Me.CmdAxF.Name = "CmdAxF"
        Me.CmdAxF.Size = New System.Drawing.Size(70, 28)
        Me.CmdAxF.TabIndex = 84
        Me.CmdAxF.Text = "AxF"
        Me.CmdAxF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAxF.UseVisualStyleBackColor = False
        '
        'CmdVxF
        '
        Me.CmdVxF.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdVxF.FlatAppearance.BorderSize = 0
        Me.CmdVxF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVxF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdVxF.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdVxF.IconChar = FontAwesome.Sharp.IconChar.ICursor
        Me.CmdVxF.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdVxF.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdVxF.IconSize = 18
        Me.CmdVxF.Location = New System.Drawing.Point(6, 36)
        Me.CmdVxF.Name = "CmdVxF"
        Me.CmdVxF.Size = New System.Drawing.Size(70, 28)
        Me.CmdVxF.TabIndex = 83
        Me.CmdVxF.Text = "VxF"
        Me.CmdVxF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdVxF.UseVisualStyleBackColor = False
        '
        'dt_ind
        '
        Me.dt_ind.AllowUserToAddRows = False
        Me.dt_ind.AllowUserToDeleteRows = False
        Me.dt_ind.AllowUserToResizeRows = False
        Me.dt_ind.BackgroundColor = System.Drawing.Color.White
        Me.dt_ind.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_ind.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_ind.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_ind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_ind.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12})
        Me.dt_ind.Dock = System.Windows.Forms.DockStyle.Right
        Me.dt_ind.GridColor = System.Drawing.Color.White
        Me.dt_ind.Location = New System.Drawing.Point(-345, 0)
        Me.dt_ind.MultiSelect = False
        Me.dt_ind.Name = "dt_ind"
        Me.dt_ind.ReadOnly = True
        Me.dt_ind.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_ind.RowHeadersVisible = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_ind.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dt_ind.RowTemplate.Height = 25
        Me.dt_ind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_ind.Size = New System.Drawing.Size(523, 1)
        Me.dt_ind.TabIndex = 86
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "dt_ind"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 80
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Panel5.Controls.Add(Me.CmdUMes)
        Me.Panel5.Controls.Add(Me.CmdUSemana)
        Me.Panel5.Controls.Add(Me.CmdUhoy)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 428)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(367, 26)
        Me.Panel5.TabIndex = 4
        '
        'CmdUMes
        '
        Me.CmdUMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdUMes.FlatAppearance.BorderSize = 0
        Me.CmdUMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdUMes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUMes.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdUMes.IconChar = FontAwesome.Sharp.IconChar.ICursor
        Me.CmdUMes.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdUMes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdUMes.IconSize = 18
        Me.CmdUMes.Location = New System.Drawing.Point(173, 4)
        Me.CmdUMes.Name = "CmdUMes"
        Me.CmdUMes.Size = New System.Drawing.Size(88, 20)
        Me.CmdUMes.TabIndex = 85
        Me.CmdUMes.Text = "MES"
        Me.CmdUMes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdUMes.UseVisualStyleBackColor = False
        '
        'CmdUSemana
        '
        Me.CmdUSemana.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdUSemana.FlatAppearance.BorderSize = 0
        Me.CmdUSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdUSemana.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUSemana.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdUSemana.IconChar = FontAwesome.Sharp.IconChar.ICursor
        Me.CmdUSemana.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdUSemana.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdUSemana.IconSize = 18
        Me.CmdUSemana.Location = New System.Drawing.Point(80, 4)
        Me.CmdUSemana.Name = "CmdUSemana"
        Me.CmdUSemana.Size = New System.Drawing.Size(88, 20)
        Me.CmdUSemana.TabIndex = 84
        Me.CmdUSemana.Text = "SEMANA"
        Me.CmdUSemana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdUSemana.UseVisualStyleBackColor = False
        '
        'CmdUhoy
        '
        Me.CmdUhoy.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdUhoy.FlatAppearance.BorderSize = 0
        Me.CmdUhoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdUhoy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUhoy.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CmdUhoy.IconChar = FontAwesome.Sharp.IconChar.ICursor
        Me.CmdUhoy.IconColor = System.Drawing.Color.WhiteSmoke
        Me.CmdUhoy.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdUhoy.IconSize = 18
        Me.CmdUhoy.Location = New System.Drawing.Point(6, 4)
        Me.CmdUhoy.Name = "CmdUhoy"
        Me.CmdUhoy.Size = New System.Drawing.Size(70, 20)
        Me.CmdUhoy.TabIndex = 83
        Me.CmdUhoy.Text = "HOY"
        Me.CmdUhoy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdUhoy.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.dt_mes, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dt_sem, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dt_hoy, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 275)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(367, 153)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'dt_mes
        '
        Me.dt_mes.AllowUserToAddRows = False
        Me.dt_mes.AllowUserToDeleteRows = False
        Me.dt_mes.AllowUserToResizeRows = False
        Me.dt_mes.BackgroundColor = System.Drawing.Color.White
        Me.dt_mes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_mes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_mes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_mes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_mes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8})
        Me.dt_mes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dt_mes.GridColor = System.Drawing.Color.White
        Me.dt_mes.Location = New System.Drawing.Point(247, 3)
        Me.dt_mes.MultiSelect = False
        Me.dt_mes.Name = "dt_mes"
        Me.dt_mes.ReadOnly = True
        Me.dt_mes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_mes.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_mes.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dt_mes.RowTemplate.Height = 25
        Me.dt_mes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_mes.Size = New System.Drawing.Size(117, 147)
        Me.dt_mes.TabIndex = 55
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "dt_mes"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'dt_sem
        '
        Me.dt_sem.AllowUserToAddRows = False
        Me.dt_sem.AllowUserToDeleteRows = False
        Me.dt_sem.AllowUserToResizeRows = False
        Me.dt_sem.BackgroundColor = System.Drawing.Color.White
        Me.dt_sem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_sem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_sem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_sem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_sem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9})
        Me.dt_sem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dt_sem.GridColor = System.Drawing.Color.White
        Me.dt_sem.Location = New System.Drawing.Point(125, 3)
        Me.dt_sem.MultiSelect = False
        Me.dt_sem.Name = "dt_sem"
        Me.dt_sem.ReadOnly = True
        Me.dt_sem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_sem.RowHeadersVisible = False
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_sem.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dt_sem.RowTemplate.Height = 25
        Me.dt_sem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_sem.Size = New System.Drawing.Size(116, 147)
        Me.dt_sem.TabIndex = 54
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "dt_sem"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'dt_hoy
        '
        Me.dt_hoy.AllowUserToAddRows = False
        Me.dt_hoy.AllowUserToDeleteRows = False
        Me.dt_hoy.AllowUserToResizeRows = False
        Me.dt_hoy.BackgroundColor = System.Drawing.Color.White
        Me.dt_hoy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_hoy.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_hoy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_hoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_hoy.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10})
        Me.dt_hoy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dt_hoy.GridColor = System.Drawing.Color.White
        Me.dt_hoy.Location = New System.Drawing.Point(3, 3)
        Me.dt_hoy.MultiSelect = False
        Me.dt_hoy.Name = "dt_hoy"
        Me.dt_hoy.ReadOnly = True
        Me.dt_hoy.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_hoy.RowHeadersVisible = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray
        Me.dt_hoy.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dt_hoy.RowTemplate.Height = 25
        Me.dt_hoy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_hoy.Size = New System.Drawing.Size(116, 147)
        Me.dt_hoy.TabIndex = 53
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "dt_hoy"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 263)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(367, 12)
        Me.Panel7.TabIndex = 3
        '
        'PanelEnLinea_Detalle
        '
        Me.PanelEnLinea_Detalle.BackColor = System.Drawing.Color.Gray
        Me.PanelEnLinea_Detalle.Controls.Add(Me.Panel6)
        Me.PanelEnLinea_Detalle.Controls.Add(Me.dg_lista_productos)
        Me.PanelEnLinea_Detalle.Location = New System.Drawing.Point(24, 427)
        Me.PanelEnLinea_Detalle.Name = "PanelEnLinea_Detalle"
        Me.PanelEnLinea_Detalle.Size = New System.Drawing.Size(433, 261)
        Me.PanelEnLinea_Detalle.TabIndex = 13
        Me.PanelEnLinea_Detalle.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.lblInd_det)
        Me.Panel6.Controls.Add(Me.CmdCierreDetInd)
        Me.Panel6.Controls.Add(Me.IconButton8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(433, 64)
        Me.Panel6.TabIndex = 85
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(3, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "INDICADOR:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInd_det
        '
        Me.lblInd_det.AutoSize = True
        Me.lblInd_det.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInd_det.ForeColor = System.Drawing.Color.White
        Me.lblInd_det.Location = New System.Drawing.Point(3, 23)
        Me.lblInd_det.Name = "lblInd_det"
        Me.lblInd_det.Size = New System.Drawing.Size(46, 21)
        Me.lblInd_det.TabIndex = 85
        Me.lblInd_det.Text = "------"
        '
        'CmdCierreDetInd
        '
        Me.CmdCierreDetInd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdCierreDetInd.FlatAppearance.BorderSize = 0
        Me.CmdCierreDetInd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCierreDetInd.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdCierreDetInd.ForeColor = System.Drawing.Color.White
        Me.CmdCierreDetInd.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.CmdCierreDetInd.IconColor = System.Drawing.Color.White
        Me.CmdCierreDetInd.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCierreDetInd.IconSize = 35
        Me.CmdCierreDetInd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCierreDetInd.Location = New System.Drawing.Point(374, 10)
        Me.CmdCierreDetInd.Name = "CmdCierreDetInd"
        Me.CmdCierreDetInd.Size = New System.Drawing.Size(42, 41)
        Me.CmdCierreDetInd.TabIndex = 56
        Me.CmdCierreDetInd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCierreDetInd.UseVisualStyleBackColor = True
        '
        'IconButton8
        '
        Me.IconButton8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconButton8.FlatAppearance.BorderSize = 0
        Me.IconButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.IconButton8.IconChar = FontAwesome.Sharp.IconChar.Circle
        Me.IconButton8.IconColor = System.Drawing.Color.WhiteSmoke
        Me.IconButton8.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton8.IconSize = 18
        Me.IconButton8.Location = New System.Drawing.Point(367, 23)
        Me.IconButton8.Name = "IconButton8"
        Me.IconButton8.Size = New System.Drawing.Size(100, 28)
        Me.IconButton8.TabIndex = 84
        Me.IconButton8.Text = "Actualizar"
        Me.IconButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton8.UseVisualStyleBackColor = False
        '
        'dg_lista_productos
        '
        Me.dg_lista_productos.AllowUserToAddRows = False
        Me.dg_lista_productos.AllowUserToDeleteRows = False
        Me.dg_lista_productos.AllowUserToResizeRows = False
        Me.dg_lista_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_lista_productos.BackgroundColor = System.Drawing.Color.White
        Me.dg_lista_productos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_lista_productos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_lista_productos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_lista_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_lista_productos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13})
        Me.dg_lista_productos.GridColor = System.Drawing.Color.White
        Me.dg_lista_productos.Location = New System.Drawing.Point(42, 86)
        Me.dg_lista_productos.MultiSelect = False
        Me.dg_lista_productos.Name = "dg_lista_productos"
        Me.dg_lista_productos.ReadOnly = True
        Me.dg_lista_productos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg_lista_productos.RowHeadersVisible = False
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gray
        Me.dg_lista_productos.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dg_lista_productos.RowTemplate.Height = 25
        Me.dg_lista_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_lista_productos.Size = New System.Drawing.Size(353, 153)
        Me.dg_lista_productos.TabIndex = 55
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "dg_lista_productos"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 80
        '
        'FrmGestionar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1265, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEnLinea_Detalle)
        Me.Controls.Add(Me.PanelEnLinea)
        Me.Controls.Add(Me.PanelInventario)
        Me.Controls.Add(Me.PanelSN)
        Me.Controls.Add(Me.PanelSup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmGestionar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSN.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dg_finanzas_sn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_sn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_resumen_sn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelListarOper.ResumeLayout(False)
        Me.PanelF5.ResumeLayout(False)
        Me.PanelF5.PerformLayout()
        Me.PanelF4.ResumeLayout(False)
        Me.PanelF4.PerformLayout()
        Me.PanelF3.ResumeLayout(False)
        Me.PanelF3.PerformLayout()
        Me.PanelF2.ResumeLayout(False)
        Me.PanelF2.PerformLayout()
        Me.PanelF1.ResumeLayout(False)
        Me.PanelF1.PerformLayout()
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.PanelInventario.ResumeLayout(False)
        Me.PanelKardexDET.ResumeLayout(False)
        CType(Me.dg_kardex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelKardexCAB.ResumeLayout(False)
        CType(Me.dg_Inventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dt_kpi_sn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_kpi_comercial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_kpi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.PanelEnLinea.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.dt_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dt_ind, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.dt_mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_sem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_hoy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEnLinea_Detalle.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.dg_lista_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdOscuro As FontAwesome.Sharp.IconButton
    Friend WithEvents LBLIniciar As Button
    Friend WithEvents CmdIniciarOper As FontAwesome.Sharp.IconButton
    Friend WithEvents Button1 As Button
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdInventarios As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdSocioNeg As FontAwesome.Sharp.IconButton
    Friend WithEvents LblSocioNeg As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PanelSN As Panel
    Friend WithEvents dg_resumen_sn As DataGridView
    Friend WithEvents PanelListarOper As Panel
    Friend WithEvents PanelF3 As Panel
    Friend WithEvents PanelF2 As Panel
    Friend WithEvents CmdBusoper_filtro As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelF1 As Panel
    Friend WithEvents Label34 As Label
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents t_fechaFin As DateTimePicker
    Friend WithEvents t_fechaIni As DateTimePicker
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel19 As Panel
    Friend WithEvents CmdMuestraFiltro As FontAwesome.Sharp.IconButton
    Friend WithEvents dg_finanzas_sn As DataGridView
    Friend WithEvents dg_detalle_sn As DataGridView
    Friend WithEvents Checkfechas As CheckBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents PanelF4 As Panel
    Friend WithEvents TxtSN As TextBox
    Friend WithEvents CheckSN As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CmdBuscaSN As FontAwesome.Sharp.IconButton
    Friend WithEvents FlowSN As FlowLayoutPanel
    Friend WithEvents ToolTipBotones As ToolTip
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents CheckOper As CheckBox
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents IconButton5 As FontAwesome.Sharp.IconButton
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckLocales As CheckBox
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents PanelF5 As Panel
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents IconButton6 As FontAwesome.Sharp.IconButton
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckEstadoComp As CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CmdMoneda As FontAwesome.Sharp.IconButton
    Friend WithEvents Label35 As Label
    Friend WithEvents CmdContraerMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents PanelInventario As Panel
    Friend WithEvents dg_kardex As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents dg_Inventario As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CmdMostrarInventario As FontAwesome.Sharp.IconButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Inv_fechaini As DateTimePicker
    Friend WithEvents Inv_fechafin As DateTimePicker
    Friend WithEvents IconButton7 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdFiltroPeriodo As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtAlmTransf As TextBox
    Friend WithEvents CmdAlmTransf As FontAwesome.Sharp.IconButton
    Friend WithEvents Label38 As Label
    Friend WithEvents PanelKardexCAB As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelKardexDET As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdTipoCosto As FontAwesome.Sharp.IconButton
    Friend WithEvents blb_costo_ult As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents dt_kpi As DataGridView
    Friend WithEvents CmdVxA As FontAwesome.Sharp.IconButton
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents dt_kpi_comercial As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents dt_kpi_sn As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PanelEnLinea As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents dt_mes As DataGridView
    Friend WithEvents dt_sem As DataGridView
    Friend WithEvents dt_hoy As DataGridView
    Friend WithEvents Panel7 As Panel
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents dt_user As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dt_ind As DataGridView
    Friend WithEvents CmdVxM2 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdAxF As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdVxF As FontAwesome.Sharp.IconButton
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents CmdActualizar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdUMes As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdUSemana As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdUhoy As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelEnLinea_Detalle As Panel
    Friend WithEvents CmdCierreDetInd As FontAwesome.Sharp.IconButton
    Friend WithEvents dg_lista_productos As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents lblInd_det As Label
    Friend WithEvents IconButton8 As FontAwesome.Sharp.IconButton
    Friend WithEvents Chek_quitar_anul As CheckBox
End Class
