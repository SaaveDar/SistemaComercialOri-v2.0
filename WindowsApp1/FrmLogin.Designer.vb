<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.NombreUser = New System.Windows.Forms.Label()
        Me.CircularProgressBar1 = New CircularProgressBar.CircularProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MarcoPerfil = New System.Windows.Forms.PictureBox()
        Me.CmdConfigurPerfil = New FontAwesome.Sharp.IconButton()
        Me.PublicidadInicio = New System.Windows.Forms.PictureBox()
        Me.LblEstadoRed = New System.Windows.Forms.Label()
        Me.FotoUsuario = New System.Windows.Forms.PictureBox()
        Me.CmdCreaTuNegocio = New FontAwesome.Sharp.IconButton()
        Me.CmdComoFunciona = New FontAwesome.Sharp.IconButton()
        Me.CmdQuienesSomos = New FontAwesome.Sharp.IconButton()
        Me.CmdMax = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.PanelNegocio = New System.Windows.Forms.Panel()
        Me.FotoNegocio = New System.Windows.Forms.PictureBox()
        Me.CmdIdNegocio = New FontAwesome.Sharp.IconButton()
        Me.PanelLeft = New System.Windows.Forms.Panel()
        Me.CmdCrearUsuario = New FontAwesome.Sharp.IconButton()
        Me.CmdOlvide = New FontAwesome.Sharp.IconButton()
        Me.CmdIniciar = New FontAwesome.Sharp.IconButton()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.CmdCajas = New FontAwesome.Sharp.IconButton()
        Me.CmdAdmin = New FontAwesome.Sharp.IconButton()
        Me.Lbl_Version_ORI = New System.Windows.Forms.Label()
        Me.Lbl_Hora_VPS = New System.Windows.Forms.Label()
        Me.Lbl_Fecha_VPS = New System.Windows.Forms.Label()
        Me.CmdReiniciar = New FontAwesome.Sharp.IconButton()
        Me.CmdProdServ = New FontAwesome.Sharp.IconButton()
        Me.CmdSalir = New FontAwesome.Sharp.IconButton()
        Me.cmdayuda = New FontAwesome.Sharp.IconButton()
        Me.CmdIntegrar = New FontAwesome.Sharp.IconButton()
        Me.CmdDeclarar = New FontAwesome.Sharp.IconButton()
        Me.CmdReportar = New FontAwesome.Sharp.IconButton()
        Me.CmdGestionar = New FontAwesome.Sharp.IconButton()
        Me.CmdProcesar = New FontAwesome.Sharp.IconButton()
        Me.CmdConfigurar = New FontAwesome.Sharp.IconButton()
        Me.CmdContraerMenu = New FontAwesome.Sharp.IconButton()
        Me.PanelFormularios = New System.Windows.Forms.Panel()
        Me.PanelIndicadores = New System.Windows.Forms.Panel()
        Me.IndicadorGrafico = New System.Windows.Forms.Panel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.B_CREDITOVENCIDOS = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.B_CREDITOS = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.B_VENCIDOS = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.B_PORVENCER = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.B_PROD_VENC = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.B_PROD_POR_VENCER = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.B_COMPRAS = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.B_VENTAS = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelInicial = New System.Windows.Forms.Panel()
        Me.ImagenInicio = New System.Windows.Forms.PictureBox()
        Me.fondonegro = New System.Windows.Forms.PictureBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DescargaInicial = New System.ComponentModel.BackgroundWorker()
        Me.Intenta = New System.Windows.Forms.Timer(Me.components)
        Me.Descargas = New System.ComponentModel.BackgroundWorker()
        Me.FechaHoraVPS = New System.Windows.Forms.Timer(Me.components)
        Me.tt_leyenda = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelSup.SuspendLayout()
        CType(Me.MarcoPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PublicidadInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FotoUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNegocio.SuspendLayout()
        CType(Me.FotoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLeft.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        Me.PanelFormularios.SuspendLayout()
        Me.PanelIndicadores.SuspendLayout()
        Me.IndicadorGrafico.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelInicial.SuspendLayout()
        CType(Me.ImagenInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fondonegro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.NombreUser)
        Me.PanelSup.Controls.Add(Me.CircularProgressBar1)
        Me.PanelSup.Controls.Add(Me.Panel1)
        Me.PanelSup.Controls.Add(Me.MarcoPerfil)
        Me.PanelSup.Controls.Add(Me.CmdConfigurPerfil)
        Me.PanelSup.Controls.Add(Me.PublicidadInicio)
        Me.PanelSup.Controls.Add(Me.LblEstadoRed)
        Me.PanelSup.Controls.Add(Me.FotoUsuario)
        Me.PanelSup.Controls.Add(Me.CmdCreaTuNegocio)
        Me.PanelSup.Controls.Add(Me.CmdComoFunciona)
        Me.PanelSup.Controls.Add(Me.CmdQuienesSomos)
        Me.PanelSup.Controls.Add(Me.CmdMax)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Controls.Add(Me.PanelNegocio)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1217, 64)
        Me.PanelSup.TabIndex = 1
        '
        'NombreUser
        '
        Me.NombreUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NombreUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NombreUser.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombreUser.ForeColor = System.Drawing.Color.White
        Me.NombreUser.Location = New System.Drawing.Point(1086, 29)
        Me.NombreUser.Name = "NombreUser"
        Me.NombreUser.Size = New System.Drawing.Size(132, 19)
        Me.NombreUser.TabIndex = 9
        Me.NombreUser.Text = "..."
        Me.NombreUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CircularProgressBar1
        '
        Me.CircularProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CircularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.CircularProgressBar1.AnimationSpeed = 500
        Me.CircularProgressBar1.BackColor = System.Drawing.Color.Transparent
        Me.CircularProgressBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CircularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CircularProgressBar1.InnerColor = System.Drawing.Color.Transparent
        Me.CircularProgressBar1.InnerMargin = 2
        Me.CircularProgressBar1.InnerWidth = -1
        Me.CircularProgressBar1.Location = New System.Drawing.Point(1184, 42)
        Me.CircularProgressBar1.MarqueeAnimationSpeed = 2000
        Me.CircularProgressBar1.Name = "CircularProgressBar1"
        Me.CircularProgressBar1.OuterColor = System.Drawing.Color.White
        Me.CircularProgressBar1.OuterMargin = -25
        Me.CircularProgressBar1.OuterWidth = 26
        Me.CircularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.CircularProgressBar1.ProgressWidth = 5
        Me.CircularProgressBar1.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.CircularProgressBar1.Size = New System.Drawing.Size(30, 30)
        Me.CircularProgressBar1.StartAngle = 270
        Me.CircularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.CircularProgressBar1.SubscriptColor = System.Drawing.Color.Transparent
        Me.CircularProgressBar1.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.CircularProgressBar1.SubscriptText = ""
        Me.CircularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CircularProgressBar1.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.CircularProgressBar1.SuperscriptText = ""
        Me.CircularProgressBar1.TabIndex = 5
        Me.CircularProgressBar1.TextMargin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.CircularProgressBar1.Value = 68
        Me.CircularProgressBar1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(967, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(117, 72)
        Me.Panel1.TabIndex = 13
        '
        'MarcoPerfil
        '
        Me.MarcoPerfil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MarcoPerfil.BackColor = System.Drawing.Color.Transparent
        Me.MarcoPerfil.Image = Global.WindowsApp1.My.Resources.Resources.fondo1
        Me.MarcoPerfil.Location = New System.Drawing.Point(835, -2)
        Me.MarcoPerfil.Name = "MarcoPerfil"
        Me.MarcoPerfil.Size = New System.Drawing.Size(114, 73)
        Me.MarcoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MarcoPerfil.TabIndex = 12
        Me.MarcoPerfil.TabStop = False
        '
        'CmdConfigurPerfil
        '
        Me.CmdConfigurPerfil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdConfigurPerfil.FlatAppearance.BorderSize = 0
        Me.CmdConfigurPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdConfigurPerfil.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdConfigurPerfil.ForeColor = System.Drawing.Color.White
        Me.CmdConfigurPerfil.IconChar = FontAwesome.Sharp.IconChar.Cog
        Me.CmdConfigurPerfil.IconColor = System.Drawing.Color.White
        Me.CmdConfigurPerfil.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdConfigurPerfil.IconSize = 25
        Me.CmdConfigurPerfil.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdConfigurPerfil.Location = New System.Drawing.Point(1086, 1)
        Me.CmdConfigurPerfil.Name = "CmdConfigurPerfil"
        Me.CmdConfigurPerfil.Size = New System.Drawing.Size(35, 31)
        Me.CmdConfigurPerfil.TabIndex = 8
        Me.CmdConfigurPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdConfigurPerfil.UseVisualStyleBackColor = True
        '
        'PublicidadInicio
        '
        Me.PublicidadInicio.Location = New System.Drawing.Point(562, 6)
        Me.PublicidadInicio.Name = "PublicidadInicio"
        Me.PublicidadInicio.Size = New System.Drawing.Size(72, 62)
        Me.PublicidadInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PublicidadInicio.TabIndex = 11
        Me.PublicidadInicio.TabStop = False
        Me.PublicidadInicio.Visible = False
        '
        'LblEstadoRed
        '
        Me.LblEstadoRed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEstadoRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstadoRed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblEstadoRed.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LblEstadoRed.Location = New System.Drawing.Point(1094, 46)
        Me.LblEstadoRed.Name = "LblEstadoRed"
        Me.LblEstadoRed.Size = New System.Drawing.Size(112, 13)
        Me.LblEstadoRed.TabIndex = 10
        Me.LblEstadoRed.Text = "Iniciando..."
        Me.LblEstadoRed.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FotoUsuario
        '
        Me.FotoUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FotoUsuario.BackColor = System.Drawing.Color.Transparent
        Me.FotoUsuario.Location = New System.Drawing.Point(1035, 3)
        Me.FotoUsuario.Name = "FotoUsuario"
        Me.FotoUsuario.Size = New System.Drawing.Size(51, 64)
        Me.FotoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.FotoUsuario.TabIndex = 5
        Me.FotoUsuario.TabStop = False
        '
        'CmdCreaTuNegocio
        '
        Me.CmdCreaTuNegocio.FlatAppearance.BorderSize = 0
        Me.CmdCreaTuNegocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCreaTuNegocio.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCreaTuNegocio.ForeColor = System.Drawing.Color.White
        Me.CmdCreaTuNegocio.IconChar = FontAwesome.Sharp.IconChar.Stream
        Me.CmdCreaTuNegocio.IconColor = System.Drawing.Color.White
        Me.CmdCreaTuNegocio.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCreaTuNegocio.IconSize = 25
        Me.CmdCreaTuNegocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCreaTuNegocio.Location = New System.Drawing.Point(402, 13)
        Me.CmdCreaTuNegocio.Name = "CmdCreaTuNegocio"
        Me.CmdCreaTuNegocio.Size = New System.Drawing.Size(96, 50)
        Me.CmdCreaTuNegocio.TabIndex = 3
        Me.CmdCreaTuNegocio.Text = "CREA TU NEGOCIO"
        Me.CmdCreaTuNegocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCreaTuNegocio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCreaTuNegocio.UseVisualStyleBackColor = True
        '
        'CmdComoFunciona
        '
        Me.CmdComoFunciona.FlatAppearance.BorderSize = 0
        Me.CmdComoFunciona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdComoFunciona.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdComoFunciona.ForeColor = System.Drawing.Color.White
        Me.CmdComoFunciona.IconChar = FontAwesome.Sharp.IconChar.Sort
        Me.CmdComoFunciona.IconColor = System.Drawing.Color.White
        Me.CmdComoFunciona.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdComoFunciona.IconSize = 25
        Me.CmdComoFunciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdComoFunciona.Location = New System.Drawing.Point(305, 12)
        Me.CmdComoFunciona.Name = "CmdComoFunciona"
        Me.CmdComoFunciona.Size = New System.Drawing.Size(94, 50)
        Me.CmdComoFunciona.TabIndex = 2
        Me.CmdComoFunciona.Text = "COMO FUNCIONA"
        Me.CmdComoFunciona.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdComoFunciona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdComoFunciona.UseVisualStyleBackColor = True
        '
        'CmdQuienesSomos
        '
        Me.CmdQuienesSomos.FlatAppearance.BorderSize = 0
        Me.CmdQuienesSomos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdQuienesSomos.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdQuienesSomos.ForeColor = System.Drawing.Color.White
        Me.CmdQuienesSomos.IconChar = FontAwesome.Sharp.IconChar.Home
        Me.CmdQuienesSomos.IconColor = System.Drawing.Color.White
        Me.CmdQuienesSomos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdQuienesSomos.IconSize = 25
        Me.CmdQuienesSomos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdQuienesSomos.Location = New System.Drawing.Point(217, 13)
        Me.CmdQuienesSomos.Name = "CmdQuienesSomos"
        Me.CmdQuienesSomos.Size = New System.Drawing.Size(88, 50)
        Me.CmdQuienesSomos.TabIndex = 1
        Me.CmdQuienesSomos.Text = "QUIENES SOMOS"
        Me.CmdQuienesSomos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdQuienesSomos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdQuienesSomos.UseVisualStyleBackColor = True
        '
        'CmdMax
        '
        Me.CmdMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdMax.FlatAppearance.BorderSize = 0
        Me.CmdMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMax.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdMax.ForeColor = System.Drawing.Color.White
        Me.CmdMax.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.CmdMax.IconColor = System.Drawing.Color.White
        Me.CmdMax.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMax.IconSize = 25
        Me.CmdMax.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdMax.Location = New System.Drawing.Point(1191, -1)
        Me.CmdMax.Name = "CmdMax"
        Me.CmdMax.Size = New System.Drawing.Size(26, 25)
        Me.CmdMax.TabIndex = 2
        Me.CmdMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMax.UseVisualStyleBackColor = True
        '
        'CmdMin
        '
        Me.CmdMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdMin.FlatAppearance.BorderSize = 0
        Me.CmdMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMin.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdMin.ForeColor = System.Drawing.Color.White
        Me.CmdMin.IconChar = FontAwesome.Sharp.IconChar.ItchIo
        Me.CmdMin.IconColor = System.Drawing.Color.White
        Me.CmdMin.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMin.IconSize = 25
        Me.CmdMin.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdMin.Location = New System.Drawing.Point(1154, -2)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 1
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'PanelNegocio
        '
        Me.PanelNegocio.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelNegocio.Controls.Add(Me.FotoNegocio)
        Me.PanelNegocio.Controls.Add(Me.CmdIdNegocio)
        Me.PanelNegocio.Location = New System.Drawing.Point(3, 3)
        Me.PanelNegocio.Name = "PanelNegocio"
        Me.PanelNegocio.Size = New System.Drawing.Size(205, 65)
        Me.PanelNegocio.TabIndex = 0
        '
        'FotoNegocio
        '
        Me.FotoNegocio.BackColor = System.Drawing.Color.Transparent
        Me.FotoNegocio.Image = CType(resources.GetObject("FotoNegocio.Image"), System.Drawing.Image)
        Me.FotoNegocio.Location = New System.Drawing.Point(14, 3)
        Me.FotoNegocio.Name = "FotoNegocio"
        Me.FotoNegocio.Size = New System.Drawing.Size(72, 54)
        Me.FotoNegocio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.FotoNegocio.TabIndex = 1
        Me.FotoNegocio.TabStop = False
        '
        'CmdIdNegocio
        '
        Me.CmdIdNegocio.FlatAppearance.BorderSize = 0
        Me.CmdIdNegocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdIdNegocio.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdIdNegocio.ForeColor = System.Drawing.Color.White
        Me.CmdIdNegocio.IconChar = FontAwesome.Sharp.IconChar.Store
        Me.CmdIdNegocio.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdIdNegocio.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdIdNegocio.IconSize = 15
        Me.CmdIdNegocio.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdIdNegocio.Location = New System.Drawing.Point(92, 3)
        Me.CmdIdNegocio.Name = "CmdIdNegocio"
        Me.CmdIdNegocio.Size = New System.Drawing.Size(103, 56)
        Me.CmdIdNegocio.TabIndex = 0
        Me.CmdIdNegocio.Text = "...."
        Me.CmdIdNegocio.UseVisualStyleBackColor = True
        '
        'PanelLeft
        '
        Me.PanelLeft.BackColor = System.Drawing.Color.Silver
        Me.PanelLeft.Controls.Add(Me.CmdCrearUsuario)
        Me.PanelLeft.Controls.Add(Me.CmdOlvide)
        Me.PanelLeft.Controls.Add(Me.CmdIniciar)
        Me.PanelLeft.Controls.Add(Me.txtContrasena)
        Me.PanelLeft.Controls.Add(Me.Label2)
        Me.PanelLeft.Controls.Add(Me.TxtUsuario)
        Me.PanelLeft.Controls.Add(Me.Label1)
        Me.PanelLeft.Location = New System.Drawing.Point(13, 77)
        Me.PanelLeft.Name = "PanelLeft"
        Me.PanelLeft.Size = New System.Drawing.Size(202, 589)
        Me.PanelLeft.TabIndex = 0
        '
        'CmdCrearUsuario
        '
        Me.CmdCrearUsuario.FlatAppearance.BorderSize = 0
        Me.CmdCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCrearUsuario.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCrearUsuario.ForeColor = System.Drawing.Color.White
        Me.CmdCrearUsuario.IconChar = FontAwesome.Sharp.IconChar.UserCheck
        Me.CmdCrearUsuario.IconColor = System.Drawing.Color.White
        Me.CmdCrearUsuario.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCrearUsuario.IconSize = 25
        Me.CmdCrearUsuario.Location = New System.Drawing.Point(12, 366)
        Me.CmdCrearUsuario.Name = "CmdCrearUsuario"
        Me.CmdCrearUsuario.Size = New System.Drawing.Size(187, 40)
        Me.CmdCrearUsuario.TabIndex = 4
        Me.CmdCrearUsuario.Text = "CREAR USUARIO"
        Me.CmdCrearUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCrearUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCrearUsuario.UseVisualStyleBackColor = True
        '
        'CmdOlvide
        '
        Me.CmdOlvide.FlatAppearance.BorderSize = 0
        Me.CmdOlvide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOlvide.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOlvide.ForeColor = System.Drawing.Color.White
        Me.CmdOlvide.IconChar = FontAwesome.Sharp.IconChar.UserLock
        Me.CmdOlvide.IconColor = System.Drawing.Color.White
        Me.CmdOlvide.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOlvide.IconSize = 15
        Me.CmdOlvide.Location = New System.Drawing.Point(6, 185)
        Me.CmdOlvide.Name = "CmdOlvide"
        Me.CmdOlvide.Size = New System.Drawing.Size(187, 22)
        Me.CmdOlvide.TabIndex = 2
        Me.CmdOlvide.TabStop = False
        Me.CmdOlvide.Text = "OLVIDASTE CREDENCIALES"
        Me.CmdOlvide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdOlvide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdOlvide.UseVisualStyleBackColor = True
        '
        'CmdIniciar
        '
        Me.CmdIniciar.FlatAppearance.BorderSize = 0
        Me.CmdIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdIniciar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CmdIniciar.ForeColor = System.Drawing.Color.White
        Me.CmdIniciar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdIniciar.IconColor = System.Drawing.Color.White
        Me.CmdIniciar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdIniciar.IconSize = 46
        Me.CmdIniciar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdIniciar.Location = New System.Drawing.Point(6, 228)
        Me.CmdIniciar.Name = "CmdIniciar"
        Me.CmdIniciar.Size = New System.Drawing.Size(187, 60)
        Me.CmdIniciar.TabIndex = 3
        Me.CmdIniciar.Text = "INICIAR"
        Me.CmdIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdIniciar.UseVisualStyleBackColor = True
        '
        'txtContrasena
        '
        Me.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContrasena.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtContrasena.Location = New System.Drawing.Point(6, 161)
        Me.txtContrasena.MaxLength = 20
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasena.Size = New System.Drawing.Size(187, 18)
        Me.txtContrasena.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Contraseña"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtUsuario.Location = New System.Drawing.Point(6, 118)
        Me.TxtUsuario.MaxLength = 20
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(187, 18)
        Me.TxtUsuario.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Nombre de Usuario"
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelMenu.Controls.Add(Me.CmdCajas)
        Me.PanelMenu.Controls.Add(Me.CmdAdmin)
        Me.PanelMenu.Controls.Add(Me.Lbl_Version_ORI)
        Me.PanelMenu.Controls.Add(Me.Lbl_Hora_VPS)
        Me.PanelMenu.Controls.Add(Me.Lbl_Fecha_VPS)
        Me.PanelMenu.Controls.Add(Me.CmdReiniciar)
        Me.PanelMenu.Controls.Add(Me.CmdProdServ)
        Me.PanelMenu.Controls.Add(Me.CmdSalir)
        Me.PanelMenu.Controls.Add(Me.cmdayuda)
        Me.PanelMenu.Controls.Add(Me.CmdIntegrar)
        Me.PanelMenu.Controls.Add(Me.CmdDeclarar)
        Me.PanelMenu.Controls.Add(Me.CmdReportar)
        Me.PanelMenu.Controls.Add(Me.CmdGestionar)
        Me.PanelMenu.Controls.Add(Me.CmdProcesar)
        Me.PanelMenu.Controls.Add(Me.CmdConfigurar)
        Me.PanelMenu.Controls.Add(Me.CmdContraerMenu)
        Me.PanelMenu.Location = New System.Drawing.Point(592, 77)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(63, 690)
        Me.PanelMenu.TabIndex = 2
        Me.PanelMenu.Visible = False
        '
        'CmdCajas
        '
        Me.CmdCajas.FlatAppearance.BorderSize = 0
        Me.CmdCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCajas.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCajas.ForeColor = System.Drawing.Color.White
        Me.CmdCajas.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmdCajas.IconColor = System.Drawing.Color.White
        Me.CmdCajas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCajas.IconSize = 25
        Me.CmdCajas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCajas.Location = New System.Drawing.Point(-4, 136)
        Me.CmdCajas.Name = "CmdCajas"
        Me.CmdCajas.Size = New System.Drawing.Size(67, 56)
        Me.CmdCajas.TabIndex = 19
        Me.CmdCajas.Tag = "CONTROL DE  CAJAS"
        Me.CmdCajas.Text = "CONTROL DE  CAJAS"
        Me.CmdCajas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdCajas.UseVisualStyleBackColor = True
        '
        'CmdAdmin
        '
        Me.CmdAdmin.FlatAppearance.BorderSize = 0
        Me.CmdAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAdmin.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdAdmin.ForeColor = System.Drawing.Color.White
        Me.CmdAdmin.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.CmdAdmin.IconColor = System.Drawing.Color.White
        Me.CmdAdmin.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAdmin.IconSize = 25
        Me.CmdAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdmin.Location = New System.Drawing.Point(1, 542)
        Me.CmdAdmin.Name = "CmdAdmin"
        Me.CmdAdmin.Size = New System.Drawing.Size(58, 50)
        Me.CmdAdmin.TabIndex = 18
        Me.CmdAdmin.Text = "ADMIN"
        Me.CmdAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdAdmin.UseVisualStyleBackColor = True
        Me.CmdAdmin.Visible = False
        '
        'Lbl_Version_ORI
        '
        Me.Lbl_Version_ORI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Version_ORI.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Version_ORI.ForeColor = System.Drawing.Color.White
        Me.Lbl_Version_ORI.Location = New System.Drawing.Point(3, 665)
        Me.Lbl_Version_ORI.Name = "Lbl_Version_ORI"
        Me.Lbl_Version_ORI.Size = New System.Drawing.Size(60, 15)
        Me.Lbl_Version_ORI.TabIndex = 17
        Me.Lbl_Version_ORI.Text = "V. 1.021"
        Me.Lbl_Version_ORI.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Lbl_Hora_VPS
        '
        Me.Lbl_Hora_VPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Hora_VPS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Hora_VPS.ForeColor = System.Drawing.Color.White
        Me.Lbl_Hora_VPS.Location = New System.Drawing.Point(5, 645)
        Me.Lbl_Hora_VPS.Name = "Lbl_Hora_VPS"
        Me.Lbl_Hora_VPS.Size = New System.Drawing.Size(58, 13)
        Me.Lbl_Hora_VPS.TabIndex = 16
        Me.Lbl_Hora_VPS.Text = "15:52:01"
        Me.Lbl_Hora_VPS.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Lbl_Fecha_VPS
        '
        Me.Lbl_Fecha_VPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Fecha_VPS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fecha_VPS.ForeColor = System.Drawing.Color.White
        Me.Lbl_Fecha_VPS.Location = New System.Drawing.Point(0, 628)
        Me.Lbl_Fecha_VPS.Name = "Lbl_Fecha_VPS"
        Me.Lbl_Fecha_VPS.Size = New System.Drawing.Size(66, 16)
        Me.Lbl_Fecha_VPS.TabIndex = 15
        Me.Lbl_Fecha_VPS.Text = "01/01/2023"
        Me.Lbl_Fecha_VPS.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CmdReiniciar
        '
        Me.CmdReiniciar.FlatAppearance.BorderSize = 0
        Me.CmdReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdReiniciar.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdReiniciar.ForeColor = System.Drawing.Color.White
        Me.ErrorProvider1.SetIconAlignment(Me.CmdReiniciar, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CmdReiniciar.IconChar = FontAwesome.Sharp.IconChar.UndoAlt
        Me.CmdReiniciar.IconColor = System.Drawing.Color.White
        Me.CmdReiniciar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdReiniciar.IconSize = 20
        Me.CmdReiniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdReiniciar.Location = New System.Drawing.Point(1, 513)
        Me.CmdReiniciar.Name = "CmdReiniciar"
        Me.CmdReiniciar.Size = New System.Drawing.Size(28, 27)
        Me.CmdReiniciar.TabIndex = 14
        Me.CmdReiniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdReiniciar.UseVisualStyleBackColor = True
        '
        'CmdProdServ
        '
        Me.CmdProdServ.FlatAppearance.BorderSize = 0
        Me.CmdProdServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdProdServ.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdProdServ.ForeColor = System.Drawing.Color.White
        Me.CmdProdServ.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdProdServ.IconColor = System.Drawing.Color.White
        Me.CmdProdServ.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdProdServ.IconSize = 25
        Me.CmdProdServ.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdProdServ.Location = New System.Drawing.Point(-4, 28)
        Me.CmdProdServ.Name = "CmdProdServ"
        Me.CmdProdServ.Size = New System.Drawing.Size(67, 56)
        Me.CmdProdServ.TabIndex = 13
        Me.CmdProdServ.Tag = "PRODUCTO / SERVICIOS"
        Me.CmdProdServ.Text = "PRODUCTO / SERVICIOS"
        Me.CmdProdServ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdProdServ.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.FlatAppearance.BorderSize = 0
        Me.CmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSalir.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdSalir.ForeColor = System.Drawing.Color.White
        Me.ErrorProvider1.SetIconAlignment(Me.CmdSalir, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.CmdSalir.IconChar = FontAwesome.Sharp.IconChar.PowerOff
        Me.CmdSalir.IconColor = System.Drawing.Color.White
        Me.CmdSalir.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSalir.IconSize = 20
        Me.CmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSalir.Location = New System.Drawing.Point(32, 513)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(27, 27)
        Me.CmdSalir.TabIndex = 12
        Me.CmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'cmdayuda
        '
        Me.cmdayuda.FlatAppearance.BorderSize = 0
        Me.cmdayuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdayuda.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdayuda.ForeColor = System.Drawing.Color.White
        Me.cmdayuda.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.cmdayuda.IconColor = System.Drawing.Color.White
        Me.cmdayuda.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.cmdayuda.IconSize = 25
        Me.cmdayuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdayuda.Location = New System.Drawing.Point(0, 455)
        Me.cmdayuda.Name = "cmdayuda"
        Me.cmdayuda.Size = New System.Drawing.Size(67, 45)
        Me.cmdayuda.TabIndex = 11
        Me.cmdayuda.Tag = "AYUDA"
        Me.cmdayuda.Text = "AYUDA"
        Me.cmdayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdayuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdayuda.UseVisualStyleBackColor = True
        '
        'CmdIntegrar
        '
        Me.CmdIntegrar.FlatAppearance.BorderSize = 0
        Me.CmdIntegrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdIntegrar.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdIntegrar.ForeColor = System.Drawing.Color.White
        Me.CmdIntegrar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdIntegrar.IconColor = System.Drawing.Color.White
        Me.CmdIntegrar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdIntegrar.IconSize = 25
        Me.CmdIntegrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdIntegrar.Location = New System.Drawing.Point(-3, 403)
        Me.CmdIntegrar.Name = "CmdIntegrar"
        Me.CmdIntegrar.Size = New System.Drawing.Size(67, 47)
        Me.CmdIntegrar.TabIndex = 10
        Me.CmdIntegrar.Tag = "INTEGRAR"
        Me.CmdIntegrar.Text = "INTEGRAR"
        Me.CmdIntegrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdIntegrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdIntegrar.UseVisualStyleBackColor = True
        '
        'CmdDeclarar
        '
        Me.CmdDeclarar.FlatAppearance.BorderSize = 0
        Me.CmdDeclarar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdDeclarar.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDeclarar.ForeColor = System.Drawing.Color.White
        Me.CmdDeclarar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdDeclarar.IconColor = System.Drawing.Color.White
        Me.CmdDeclarar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdDeclarar.IconSize = 25
        Me.CmdDeclarar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdDeclarar.Location = New System.Drawing.Point(-3, 352)
        Me.CmdDeclarar.Name = "CmdDeclarar"
        Me.CmdDeclarar.Size = New System.Drawing.Size(67, 46)
        Me.CmdDeclarar.TabIndex = 10
        Me.CmdDeclarar.Tag = "DECLRAR"
        Me.CmdDeclarar.Text = "DECLRAR"
        Me.CmdDeclarar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdDeclarar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdDeclarar.UseVisualStyleBackColor = True
        '
        'CmdReportar
        '
        Me.CmdReportar.FlatAppearance.BorderSize = 0
        Me.CmdReportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdReportar.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReportar.ForeColor = System.Drawing.Color.White
        Me.CmdReportar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdReportar.IconColor = System.Drawing.Color.White
        Me.CmdReportar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdReportar.IconSize = 25
        Me.CmdReportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdReportar.Location = New System.Drawing.Point(-3, 298)
        Me.CmdReportar.Name = "CmdReportar"
        Me.CmdReportar.Size = New System.Drawing.Size(67, 50)
        Me.CmdReportar.TabIndex = 9
        Me.CmdReportar.Tag = "REPORTAR"
        Me.CmdReportar.Text = "REPORTAR"
        Me.CmdReportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdReportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdReportar.UseVisualStyleBackColor = True
        '
        'CmdGestionar
        '
        Me.CmdGestionar.FlatAppearance.BorderSize = 0
        Me.CmdGestionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGestionar.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGestionar.ForeColor = System.Drawing.Color.White
        Me.CmdGestionar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdGestionar.IconColor = System.Drawing.Color.White
        Me.CmdGestionar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdGestionar.IconSize = 25
        Me.CmdGestionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGestionar.Location = New System.Drawing.Point(-5, 247)
        Me.CmdGestionar.Name = "CmdGestionar"
        Me.CmdGestionar.Size = New System.Drawing.Size(67, 45)
        Me.CmdGestionar.TabIndex = 8
        Me.CmdGestionar.Tag = "GESTIONAR"
        Me.CmdGestionar.Text = "GESTIONAR"
        Me.CmdGestionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGestionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdGestionar.UseVisualStyleBackColor = True
        '
        'CmdProcesar
        '
        Me.CmdProcesar.FlatAppearance.BorderSize = 0
        Me.CmdProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdProcesar.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdProcesar.ForeColor = System.Drawing.Color.White
        Me.CmdProcesar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdProcesar.IconColor = System.Drawing.Color.White
        Me.CmdProcesar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdProcesar.IconSize = 25
        Me.CmdProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdProcesar.Location = New System.Drawing.Point(-5, 195)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(67, 46)
        Me.CmdProcesar.TabIndex = 7
        Me.CmdProcesar.Tag = "PROCESAR"
        Me.CmdProcesar.Text = "PROCESAR"
        Me.CmdProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdProcesar.UseVisualStyleBackColor = True
        '
        'CmdConfigurar
        '
        Me.CmdConfigurar.FlatAppearance.BorderSize = 0
        Me.CmdConfigurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdConfigurar.Font = New System.Drawing.Font("Segoe UI Semilight", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdConfigurar.ForeColor = System.Drawing.Color.White
        Me.CmdConfigurar.IconChar = FontAwesome.Sharp.IconChar.ParachuteBox
        Me.CmdConfigurar.IconColor = System.Drawing.Color.White
        Me.CmdConfigurar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdConfigurar.IconSize = 25
        Me.CmdConfigurar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdConfigurar.Location = New System.Drawing.Point(-6, 85)
        Me.CmdConfigurar.Name = "CmdConfigurar"
        Me.CmdConfigurar.Size = New System.Drawing.Size(67, 47)
        Me.CmdConfigurar.TabIndex = 6
        Me.CmdConfigurar.Tag = "CONFIGURAR"
        Me.CmdConfigurar.Text = "CONFIGURAR"
        Me.CmdConfigurar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdConfigurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdConfigurar.UseVisualStyleBackColor = True
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
        Me.CmdContraerMenu.Size = New System.Drawing.Size(62, 19)
        Me.CmdContraerMenu.TabIndex = 5
        Me.CmdContraerMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdContraerMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdContraerMenu.UseVisualStyleBackColor = True
        '
        'PanelFormularios
        '
        Me.PanelFormularios.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.PanelFormularios.Controls.Add(Me.PanelIndicadores)
        Me.PanelFormularios.Location = New System.Drawing.Point(730, 80)
        Me.PanelFormularios.Name = "PanelFormularios"
        Me.PanelFormularios.Size = New System.Drawing.Size(392, 667)
        Me.PanelFormularios.TabIndex = 3
        Me.PanelFormularios.Visible = False
        '
        'PanelIndicadores
        '
        Me.PanelIndicadores.Controls.Add(Me.IndicadorGrafico)
        Me.PanelIndicadores.Controls.Add(Me.Panel10)
        Me.PanelIndicadores.Controls.Add(Me.B_CREDITOVENCIDOS)
        Me.PanelIndicadores.Controls.Add(Me.Panel9)
        Me.PanelIndicadores.Controls.Add(Me.B_CREDITOS)
        Me.PanelIndicadores.Controls.Add(Me.Panel8)
        Me.PanelIndicadores.Controls.Add(Me.B_VENCIDOS)
        Me.PanelIndicadores.Controls.Add(Me.Panel7)
        Me.PanelIndicadores.Controls.Add(Me.B_PORVENCER)
        Me.PanelIndicadores.Controls.Add(Me.Panel6)
        Me.PanelIndicadores.Controls.Add(Me.B_PROD_VENC)
        Me.PanelIndicadores.Controls.Add(Me.Panel5)
        Me.PanelIndicadores.Controls.Add(Me.B_PROD_POR_VENCER)
        Me.PanelIndicadores.Controls.Add(Me.Panel4)
        Me.PanelIndicadores.Controls.Add(Me.B_COMPRAS)
        Me.PanelIndicadores.Controls.Add(Me.Panel3)
        Me.PanelIndicadores.Controls.Add(Me.B_VENTAS)
        Me.PanelIndicadores.Controls.Add(Me.PictureBox1)
        Me.PanelIndicadores.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelIndicadores.Location = New System.Drawing.Point(246, 0)
        Me.PanelIndicadores.Name = "PanelIndicadores"
        Me.PanelIndicadores.Size = New System.Drawing.Size(146, 667)
        Me.PanelIndicadores.TabIndex = 3
        Me.PanelIndicadores.Visible = False
        '
        'IndicadorGrafico
        '
        Me.IndicadorGrafico.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.IndicadorGrafico.Controls.Add(Me.Chart1)
        Me.IndicadorGrafico.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.IndicadorGrafico.Location = New System.Drawing.Point(0, 515)
        Me.IndicadorGrafico.Name = "IndicadorGrafico"
        Me.IndicadorGrafico.Size = New System.Drawing.Size(146, 152)
        Me.IndicadorGrafico.TabIndex = 0
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.ForeColor = System.Drawing.Color.White
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(146, 152)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 486)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(146, 4)
        Me.Panel10.TabIndex = 30
        '
        'B_CREDITOVENCIDOS
        '
        Me.B_CREDITOVENCIDOS.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_CREDITOVENCIDOS.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_CREDITOVENCIDOS.FlatAppearance.BorderSize = 0
        Me.B_CREDITOVENCIDOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_CREDITOVENCIDOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_CREDITOVENCIDOS.ForeColor = System.Drawing.Color.White
        Me.B_CREDITOVENCIDOS.Location = New System.Drawing.Point(0, 435)
        Me.B_CREDITOVENCIDOS.Name = "B_CREDITOVENCIDOS"
        Me.B_CREDITOVENCIDOS.Size = New System.Drawing.Size(146, 51)
        Me.B_CREDITOVENCIDOS.TabIndex = 29
        Me.B_CREDITOVENCIDOS.Text = "CREDITOS PENDIENTES  152.25"
        Me.B_CREDITOVENCIDOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_CREDITOVENCIDOS.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 431)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(146, 4)
        Me.Panel9.TabIndex = 28
        '
        'B_CREDITOS
        '
        Me.B_CREDITOS.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_CREDITOS.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_CREDITOS.FlatAppearance.BorderSize = 0
        Me.B_CREDITOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_CREDITOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_CREDITOS.ForeColor = System.Drawing.Color.White
        Me.B_CREDITOS.Location = New System.Drawing.Point(0, 380)
        Me.B_CREDITOS.Name = "B_CREDITOS"
        Me.B_CREDITOS.Size = New System.Drawing.Size(146, 51)
        Me.B_CREDITOS.TabIndex = 27
        Me.B_CREDITOS.Text = "COMPRAS DEL MES 62.250.0"
        Me.B_CREDITOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_CREDITOS.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 376)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(146, 4)
        Me.Panel8.TabIndex = 26
        '
        'B_VENCIDOS
        '
        Me.B_VENCIDOS.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_VENCIDOS.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_VENCIDOS.FlatAppearance.BorderSize = 0
        Me.B_VENCIDOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_VENCIDOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_VENCIDOS.ForeColor = System.Drawing.Color.White
        Me.B_VENCIDOS.Location = New System.Drawing.Point(0, 325)
        Me.B_VENCIDOS.Name = "B_VENCIDOS"
        Me.B_VENCIDOS.Size = New System.Drawing.Size(146, 51)
        Me.B_VENCIDOS.TabIndex = 25
        Me.B_VENCIDOS.Text = "ORD. COMPRA ABIERTAS 6"
        Me.B_VENCIDOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_VENCIDOS.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 321)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(146, 4)
        Me.Panel7.TabIndex = 24
        '
        'B_PORVENCER
        '
        Me.B_PORVENCER.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_PORVENCER.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PORVENCER.FlatAppearance.BorderSize = 0
        Me.B_PORVENCER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PORVENCER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PORVENCER.ForeColor = System.Drawing.Color.White
        Me.B_PORVENCER.Location = New System.Drawing.Point(0, 270)
        Me.B_PORVENCER.Name = "B_PORVENCER"
        Me.B_PORVENCER.Size = New System.Drawing.Size(146, 51)
        Me.B_PORVENCER.TabIndex = 23
        Me.B_PORVENCER.Text = "EFECTIVO CAJAS S/  600.25 "
        Me.B_PORVENCER.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_PORVENCER.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 266)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(146, 4)
        Me.Panel6.TabIndex = 22
        '
        'B_PROD_VENC
        '
        Me.B_PROD_VENC.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_PROD_VENC.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PROD_VENC.FlatAppearance.BorderSize = 0
        Me.B_PROD_VENC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PROD_VENC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PROD_VENC.ForeColor = System.Drawing.Color.White
        Me.B_PROD_VENC.Location = New System.Drawing.Point(0, 215)
        Me.B_PROD_VENC.Name = "B_PROD_VENC"
        Me.B_PROD_VENC.Size = New System.Drawing.Size(146, 51)
        Me.B_PROD_VENC.TabIndex = 21
        Me.B_PROD_VENC.Text = "PROD. VENCIDOS 24"
        Me.B_PROD_VENC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_PROD_VENC.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 211)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(146, 4)
        Me.Panel5.TabIndex = 20
        '
        'B_PROD_POR_VENCER
        '
        Me.B_PROD_POR_VENCER.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_PROD_POR_VENCER.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_PROD_POR_VENCER.FlatAppearance.BorderSize = 0
        Me.B_PROD_POR_VENCER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_PROD_POR_VENCER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PROD_POR_VENCER.ForeColor = System.Drawing.Color.White
        Me.B_PROD_POR_VENCER.Location = New System.Drawing.Point(0, 160)
        Me.B_PROD_POR_VENCER.Name = "B_PROD_POR_VENCER"
        Me.B_PROD_POR_VENCER.Size = New System.Drawing.Size(146, 51)
        Me.B_PROD_POR_VENCER.TabIndex = 19
        Me.B_PROD_POR_VENCER.Text = "Productos por Vencer 0"
        Me.B_PROD_POR_VENCER.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_PROD_POR_VENCER.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 156)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(146, 4)
        Me.Panel4.TabIndex = 18
        '
        'B_COMPRAS
        '
        Me.B_COMPRAS.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_COMPRAS.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_COMPRAS.FlatAppearance.BorderSize = 0
        Me.B_COMPRAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_COMPRAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_COMPRAS.ForeColor = System.Drawing.Color.White
        Me.B_COMPRAS.Location = New System.Drawing.Point(0, 105)
        Me.B_COMPRAS.Name = "B_COMPRAS"
        Me.B_COMPRAS.Size = New System.Drawing.Size(146, 51)
        Me.B_COMPRAS.TabIndex = 17
        Me.B_COMPRAS.Text = "VENTAS - AC. MES  52,520.11"
        Me.B_COMPRAS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_COMPRAS.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Green
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 101)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(146, 4)
        Me.Panel3.TabIndex = 16
        '
        'B_VENTAS
        '
        Me.B_VENTAS.Dock = System.Windows.Forms.DockStyle.Top
        Me.B_VENTAS.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.B_VENTAS.FlatAppearance.BorderSize = 0
        Me.B_VENTAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_VENTAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_VENTAS.ForeColor = System.Drawing.Color.White
        Me.B_VENTAS.Location = New System.Drawing.Point(0, 50)
        Me.B_VENTAS.Name = "B_VENTAS"
        Me.B_VENTAS.Size = New System.Drawing.Size(146, 51)
        Me.B_VENTAS.TabIndex = 15
        Me.B_VENTAS.Text = "VENTAS - HOY  1,520.11"
        Me.B_VENTAS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_VENTAS.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(146, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PanelInicial
        '
        Me.PanelInicial.BackColor = System.Drawing.Color.White
        Me.PanelInicial.Controls.Add(Me.ImagenInicio)
        Me.PanelInicial.Controls.Add(Me.fondonegro)
        Me.PanelInicial.Location = New System.Drawing.Point(221, 130)
        Me.PanelInicial.Name = "PanelInicial"
        Me.PanelInicial.Size = New System.Drawing.Size(282, 371)
        Me.PanelInicial.TabIndex = 4
        Me.PanelInicial.Visible = False
        '
        'ImagenInicio
        '
        Me.ImagenInicio.BackColor = System.Drawing.Color.White
        Me.ImagenInicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagenInicio.Location = New System.Drawing.Point(0, 0)
        Me.ImagenInicio.Name = "ImagenInicio"
        Me.ImagenInicio.Size = New System.Drawing.Size(282, 371)
        Me.ImagenInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagenInicio.TabIndex = 0
        Me.ImagenInicio.TabStop = False
        '
        'fondonegro
        '
        Me.fondonegro.BackColor = System.Drawing.Color.Black
        Me.fondonegro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fondonegro.Image = CType(resources.GetObject("fondonegro.Image"), System.Drawing.Image)
        Me.fondonegro.Location = New System.Drawing.Point(0, 0)
        Me.fondonegro.Name = "fondonegro"
        Me.fondonegro.Size = New System.Drawing.Size(282, 371)
        Me.fondonegro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.fondonegro.TabIndex = 1
        Me.fondonegro.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'DescargaInicial
        '
        Me.DescargaInicial.WorkerReportsProgress = True
        Me.DescargaInicial.WorkerSupportsCancellation = True
        '
        'Intenta
        '
        Me.Intenta.Interval = 5000
        '
        'FechaHoraVPS
        '
        Me.FechaHoraVPS.Interval = 1000
        '
        'tt_leyenda
        '
        Me.tt_leyenda.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.tt_leyenda.ForeColor = System.Drawing.Color.White
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(267, 521)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.70441!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.29559!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(319, 209)
        Me.TableLayoutPanel1.TabIndex = 5
        Me.TableLayoutPanel1.Visible = False
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 759)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.PanelInicial)
        Me.Controls.Add(Me.PanelFormularios)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.PanelLeft)
        Me.Controls.Add(Me.PanelSup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogin"
        Me.PanelSup.ResumeLayout(False)
        CType(Me.MarcoPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PublicidadInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FotoUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNegocio.ResumeLayout(False)
        CType(Me.FotoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLeft.ResumeLayout(False)
        Me.PanelLeft.PerformLayout()
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelFormularios.ResumeLayout(False)
        Me.PanelIndicadores.ResumeLayout(False)
        Me.IndicadorGrafico.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelInicial.ResumeLayout(False)
        CType(Me.ImagenInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fondonegro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents PanelNegocio As Panel
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CmdIniciar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMax As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents CmdSalir As FontAwesome.Sharp.IconButton
    Friend WithEvents cmdayuda As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdIntegrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdDeclarar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdReportar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdGestionar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdProcesar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdConfigurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdContraerMenu As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdComoFunciona As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdQuienesSomos As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCrearUsuario As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdOlvide As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdConfigurPerfil As FontAwesome.Sharp.IconButton
    Friend WithEvents NombreUser As Label
    Friend WithEvents CmdProdServ As FontAwesome.Sharp.IconButton
    Friend WithEvents CircularProgressBar1 As CircularProgressBar.CircularProgressBar
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Public WithEvents PanelInicial As Panel
    Public WithEvents ImagenInicio As PictureBox
    Public WithEvents PanelLeft As Panel
    Friend WithEvents PublicidadInicio As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DescargaInicial As System.ComponentModel.BackgroundWorker
    Friend WithEvents Intenta As Timer
    Public WithEvents FotoUsuario As PictureBox
    Friend WithEvents Descargas As System.ComponentModel.BackgroundWorker
    Public WithEvents LblEstadoRed As Label
    Public WithEvents MarcoPerfil As PictureBox
    Friend WithEvents Panel1 As Panel
    Public WithEvents CmdIdNegocio As FontAwesome.Sharp.IconButton
    Public WithEvents FotoNegocio As PictureBox
    Public WithEvents CmdCreaTuNegocio As FontAwesome.Sharp.IconButton
    Public WithEvents PanelFormularios As Panel
    Friend WithEvents CmdReiniciar As FontAwesome.Sharp.IconButton
    Friend WithEvents Lbl_Hora_VPS As Label
    Friend WithEvents Lbl_Fecha_VPS As Label
    Friend WithEvents Lbl_Version_ORI As Label
    Friend WithEvents FechaHoraVPS As Timer
    Friend WithEvents tt_leyenda As ToolTip
    Friend WithEvents PanelIndicadores As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents B_CREDITOVENCIDOS As Button
    Friend WithEvents Panel9 As Panel
    Friend WithEvents B_CREDITOS As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents B_VENCIDOS As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents B_PORVENCER As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents B_PROD_VENC As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents B_PROD_POR_VENCER As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents B_COMPRAS As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents B_VENTAS As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents IndicadorGrafico As Panel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents fondonegro As PictureBox
    Friend WithEvents CmdAdmin As FontAwesome.Sharp.IconButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CmdCajas As FontAwesome.Sharp.IconButton
End Class
