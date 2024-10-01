<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCreaUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreaUsuario))
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.FaltaDatos = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.TxtRepitaContrasena = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdCancelarCrear = New FontAwesome.Sharp.IconButton()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbTipoDocUsuario = New System.Windows.Forms.ComboBox()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmdSiguiente = New FontAwesome.Sharp.IconButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtNumeroCel = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CmbListaPais = New System.Windows.Forms.ComboBox()
        Me.LblMensaje1 = New System.Windows.Forms.Label()
        Me.CmdREEnvioSMS = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelarMensaje = New FontAwesome.Sharp.IconButton()
        Me.LblEsperaSMS = New System.Windows.Forms.Label()
        Me.CmdAtras = New FontAwesome.Sharp.IconButton()
        Me.CmdAceptarSMS = New FontAwesome.Sharp.IconButton()
        Me.LblCodigoValida = New System.Windows.Forms.Label()
        Me.TxtCodigoValida = New System.Windows.Forms.MaskedTextBox()
        Me.CmdEnvioSMS = New FontAwesome.Sharp.IconButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PanelOlvidoContrasena = New System.Windows.Forms.Panel()
        Me.PanelRestablece = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContrasenaOlvido = New System.Windows.Forms.TextBox()
        Me.CmbNumerosOlvido = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtRepitaContrasenaOlvido = New System.Windows.Forms.TextBox()
        Me.PanelValida = New System.Windows.Forms.Panel()
        Me.CmbListaPaisOlvido = New System.Windows.Forms.ComboBox()
        Me.CmdEnvioSMSolvido = New FontAwesome.Sharp.IconButton()
        Me.TxtNumeroCelOlvido = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CmdREEnvioSMSOlvido = New FontAwesome.Sharp.IconButton()
        Me.LblCodigoValidaOlvido = New System.Windows.Forms.Label()
        Me.TxtValidaCodigoO = New System.Windows.Forms.MaskedTextBox()
        Me.LblEsperaSMSOlvido = New System.Windows.Forms.Label()
        Me.CmdCambiaClave = New FontAwesome.Sharp.IconButton()
        Me.CmdCancelarMensajeOlvido = New FontAwesome.Sharp.IconButton()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TiempoSMS = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.UserRegistrado = New System.Windows.Forms.TextBox()
        Me.Lblcelularregistrado = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmdIngresoSistema = New FontAwesome.Sharp.IconButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ImagenesPaises = New System.Windows.Forms.ImageList(Me.components)
        Me.TiempoSMSOlvido = New System.Windows.Forms.Timer(Me.components)
        Me.PanelSup.SuspendLayout()
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelOlvidoContrasena.SuspendLayout()
        Me.PanelRestablece.SuspendLayout()
        Me.PanelValida.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.LblTitulo)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1283, 32)
        Me.PanelSup.TabIndex = 3
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(27, 3)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(382, 29)
        Me.LblTitulo.TabIndex = 4
        Me.LblTitulo.Text = "Bienvenido a la plataforma ORI."
        '
        'FaltaDatos
        '
        Me.FaltaDatos.ContainerControl = Me
        Me.FaltaDatos.Icon = CType(resources.GetObject("FaltaDatos.Icon"), System.Drawing.Icon)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtContrasena)
        Me.Panel1.Controls.Add(Me.TxtRepitaContrasena)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CmdCancelarCrear)
        Me.Panel1.Controls.Add(Me.TxtUsuario)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtApellidos)
        Me.Panel1.Controls.Add(Me.TxtNombres)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.CmbTipoDocUsuario)
        Me.Panel1.Controls.Add(Me.TxtNumero)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.CmdSiguiente)
        Me.Panel1.Location = New System.Drawing.Point(0, 629)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(808, 570)
        Me.Panel1.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(476, 228)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(160, 51)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "*Usuario, puedes cambiarlo, sin embargo debe ser unico en toda la plataforma."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(144, 295)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "&Repite Contraseña :"
        '
        'txtContrasena
        '
        Me.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContrasena.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtContrasena.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContrasena.Location = New System.Drawing.Point(262, 260)
        Me.txtContrasena.MaxLength = 20
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasena.Size = New System.Drawing.Size(187, 25)
        Me.txtContrasena.TabIndex = 5
        '
        'TxtRepitaContrasena
        '
        Me.TxtRepitaContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRepitaContrasena.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtRepitaContrasena.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtRepitaContrasena.Location = New System.Drawing.Point(262, 291)
        Me.TxtRepitaContrasena.MaxLength = 20
        Me.TxtRepitaContrasena.Name = "TxtRepitaContrasena"
        Me.TxtRepitaContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtRepitaContrasena.Size = New System.Drawing.Size(187, 25)
        Me.TxtRepitaContrasena.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(180, 264)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "&Contraseña :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(162, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 15)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "&Nuevo Usuario :"
        '
        'CmdCancelarCrear
        '
        Me.CmdCancelarCrear.FlatAppearance.BorderSize = 0
        Me.CmdCancelarCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelarCrear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelarCrear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarCrear.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.CmdCancelarCrear.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarCrear.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelarCrear.IconSize = 25
        Me.CmdCancelarCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelarCrear.Location = New System.Drawing.Point(222, 376)
        Me.CmdCancelarCrear.Name = "CmdCancelarCrear"
        Me.CmdCancelarCrear.Size = New System.Drawing.Size(95, 27)
        Me.CmdCancelarCrear.TabIndex = 8
        Me.CmdCancelarCrear.Text = "&Cancelar"
        Me.CmdCancelarCrear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelarCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancelarCrear.UseVisualStyleBackColor = True
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtUsuario.Location = New System.Drawing.Point(262, 228)
        Me.TxtUsuario.MaxLength = 15
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(185, 25)
        Me.TxtUsuario.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(158, 206)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(382, 15)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Aquí tu usuario para el acceso a la plataforma."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(191, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "&Apellidos :"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApellidos.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtApellidos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtApellidos.Location = New System.Drawing.Point(262, 170)
        Me.TxtApellidos.MaxLength = 100
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(271, 25)
        Me.TxtApellidos.TabIndex = 3
        '
        'TxtNombres
        '
        Me.TxtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombres.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtNombres.Location = New System.Drawing.Point(262, 139)
        Me.TxtNombres.MaxLength = 100
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(271, 25)
        Me.TxtNombres.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(191, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 15)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "&Nombres :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(220, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "&Nro :"
        '
        'CmbTipoDocUsuario
        '
        Me.CmbTipoDocUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbTipoDocUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbTipoDocUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmbTipoDocUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoDocUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbTipoDocUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipoDocUsuario.ForeColor = System.Drawing.Color.White
        Me.CmbTipoDocUsuario.FormattingEnabled = True
        Me.CmbTipoDocUsuario.Location = New System.Drawing.Point(259, 80)
        Me.CmbTipoDocUsuario.Name = "CmbTipoDocUsuario"
        Me.CmbTipoDocUsuario.Size = New System.Drawing.Size(187, 23)
        Me.CmbTipoDocUsuario.TabIndex = 0
        '
        'TxtNumero
        '
        Me.TxtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtNumero.Location = New System.Drawing.Point(262, 108)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(103, 25)
        Me.TxtNumero.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(153, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "&Tipo Documento:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(128, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(612, 50)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Para tener un usuario solo tendrás que Ingresar la información requerida."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.FlatAppearance.BorderSize = 0
        Me.CmdSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSiguiente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSiguiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdSiguiente.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdSiguiente.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdSiguiente.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdSiguiente.IconSize = 25
        Me.CmdSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSiguiente.Location = New System.Drawing.Point(374, 376)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(110, 27)
        Me.CmdSiguiente.TabIndex = 7
        Me.CmdSiguiente.Text = "Validar"
        Me.CmdSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtNumeroCel)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.CmbListaPais)
        Me.Panel2.Controls.Add(Me.LblMensaje1)
        Me.Panel2.Controls.Add(Me.CmdREEnvioSMS)
        Me.Panel2.Controls.Add(Me.CmdCancelarMensaje)
        Me.Panel2.Controls.Add(Me.LblEsperaSMS)
        Me.Panel2.Controls.Add(Me.CmdAtras)
        Me.Panel2.Controls.Add(Me.CmdAceptarSMS)
        Me.Panel2.Controls.Add(Me.LblCodigoValida)
        Me.Panel2.Controls.Add(Me.TxtCodigoValida)
        Me.Panel2.Controls.Add(Me.CmdEnvioSMS)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(811, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(616, 527)
        Me.Panel2.TabIndex = 1
        Me.Panel2.Visible = False
        '
        'TxtNumeroCel
        '
        Me.TxtNumeroCel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumeroCel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumeroCel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroCel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtNumeroCel.Location = New System.Drawing.Point(317, 162)
        Me.TxtNumeroCel.Name = "TxtNumeroCel"
        Me.TxtNumeroCel.Size = New System.Drawing.Size(105, 18)
        Me.TxtNumeroCel.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(309, 172)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 13)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "__________________"
        '
        'CmbListaPais
        '
        Me.CmbListaPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbListaPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbListaPais.BackColor = System.Drawing.Color.White
        Me.CmbListaPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbListaPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbListaPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbListaPais.ForeColor = System.Drawing.Color.White
        Me.CmbListaPais.FormattingEnabled = True
        Me.CmbListaPais.Location = New System.Drawing.Point(190, 162)
        Me.CmbListaPais.Name = "CmbListaPais"
        Me.CmbListaPais.Size = New System.Drawing.Size(121, 23)
        Me.CmbListaPais.TabIndex = 57
        '
        'LblMensaje1
        '
        Me.LblMensaje1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.LblMensaje1.Location = New System.Drawing.Point(152, 27)
        Me.LblMensaje1.Name = "LblMensaje1"
        Me.LblMensaje1.Size = New System.Drawing.Size(369, 48)
        Me.LblMensaje1.TabIndex = 56
        Me.LblMensaje1.Text = "ALAN GUSTAVO , Validaremos los datos "
        '
        'CmdREEnvioSMS
        '
        Me.CmdREEnvioSMS.FlatAppearance.BorderSize = 0
        Me.CmdREEnvioSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdREEnvioSMS.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdREEnvioSMS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.CmdREEnvioSMS.IconChar = FontAwesome.Sharp.IconChar.Sms
        Me.CmdREEnvioSMS.IconColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.CmdREEnvioSMS.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdREEnvioSMS.IconSize = 20
        Me.CmdREEnvioSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdREEnvioSMS.Location = New System.Drawing.Point(276, 332)
        Me.CmdREEnvioSMS.Name = "CmdREEnvioSMS"
        Me.CmdREEnvioSMS.Size = New System.Drawing.Size(134, 27)
        Me.CmdREEnvioSMS.TabIndex = 3
        Me.CmdREEnvioSMS.Text = "Re Enviar SMS"
        Me.CmdREEnvioSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdREEnvioSMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdREEnvioSMS.UseVisualStyleBackColor = True
        Me.CmdREEnvioSMS.Visible = False
        '
        'CmdCancelarMensaje
        '
        Me.CmdCancelarMensaje.FlatAppearance.BorderSize = 0
        Me.CmdCancelarMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelarMensaje.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelarMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarMensaje.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.CmdCancelarMensaje.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarMensaje.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelarMensaje.IconSize = 25
        Me.CmdCancelarMensaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelarMensaje.Location = New System.Drawing.Point(343, 376)
        Me.CmdCancelarMensaje.Name = "CmdCancelarMensaje"
        Me.CmdCancelarMensaje.Size = New System.Drawing.Size(95, 27)
        Me.CmdCancelarMensaje.TabIndex = 4
        Me.CmdCancelarMensaje.Text = "&Cancelar"
        Me.CmdCancelarMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelarMensaje.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancelarMensaje.UseVisualStyleBackColor = True
        Me.CmdCancelarMensaje.Visible = False
        '
        'LblEsperaSMS
        '
        Me.LblEsperaSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEsperaSMS.ForeColor = System.Drawing.Color.DarkGray
        Me.LblEsperaSMS.Location = New System.Drawing.Point(206, 226)
        Me.LblEsperaSMS.Name = "LblEsperaSMS"
        Me.LblEsperaSMS.Size = New System.Drawing.Size(295, 35)
        Me.LblEsperaSMS.TabIndex = 54
        Me.LblEsperaSMS.Text = "Esperar "
        Me.LblEsperaSMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblEsperaSMS.Visible = False
        '
        'CmdAtras
        '
        Me.CmdAtras.FlatAppearance.BorderSize = 0
        Me.CmdAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAtras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAtras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAtras.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft
        Me.CmdAtras.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAtras.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAtras.IconSize = 25
        Me.CmdAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAtras.Location = New System.Drawing.Point(214, 376)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(102, 27)
        Me.CmdAtras.TabIndex = 5
        Me.CmdAtras.Text = "&Atras"
        Me.CmdAtras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdAceptarSMS
        '
        Me.CmdAceptarSMS.FlatAppearance.BorderSize = 0
        Me.CmdAceptarSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAceptarSMS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAceptarSMS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAceptarSMS.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmdAceptarSMS.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAceptarSMS.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAceptarSMS.IconSize = 25
        Me.CmdAceptarSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptarSMS.Location = New System.Drawing.Point(246, 440)
        Me.CmdAceptarSMS.Name = "CmdAceptarSMS"
        Me.CmdAceptarSMS.Size = New System.Drawing.Size(110, 27)
        Me.CmdAceptarSMS.TabIndex = 52
        Me.CmdAceptarSMS.Text = "&Aceptar"
        Me.CmdAceptarSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptarSMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAceptarSMS.UseVisualStyleBackColor = True
        Me.CmdAceptarSMS.Visible = False
        '
        'LblCodigoValida
        '
        Me.LblCodigoValida.AutoSize = True
        Me.LblCodigoValida.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodigoValida.Location = New System.Drawing.Point(271, 269)
        Me.LblCodigoValida.Name = "LblCodigoValida"
        Me.LblCodigoValida.Size = New System.Drawing.Size(141, 17)
        Me.LblCodigoValida.TabIndex = 51
        Me.LblCodigoValida.Text = "&Codigo de Verificación"
        Me.LblCodigoValida.Visible = False
        '
        'TxtCodigoValida
        '
        Me.TxtCodigoValida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoValida.Location = New System.Drawing.Point(297, 295)
        Me.TxtCodigoValida.Mask = "999999"
        Me.TxtCodigoValida.Name = "TxtCodigoValida"
        Me.TxtCodigoValida.Size = New System.Drawing.Size(93, 31)
        Me.TxtCodigoValida.TabIndex = 2
        Me.TxtCodigoValida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCodigoValida.ValidatingType = GetType(Integer)
        Me.TxtCodigoValida.Visible = False
        '
        'CmdEnvioSMS
        '
        Me.CmdEnvioSMS.FlatAppearance.BorderSize = 0
        Me.CmdEnvioSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEnvioSMS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEnvioSMS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdEnvioSMS.IconChar = FontAwesome.Sharp.IconChar.Sms
        Me.CmdEnvioSMS.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdEnvioSMS.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdEnvioSMS.IconSize = 30
        Me.CmdEnvioSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEnvioSMS.Location = New System.Drawing.Point(295, 195)
        Me.CmdEnvioSMS.Name = "CmdEnvioSMS"
        Me.CmdEnvioSMS.Size = New System.Drawing.Size(134, 37)
        Me.CmdEnvioSMS.TabIndex = 1
        Me.CmdEnvioSMS.Text = "Enviar SMS"
        Me.CmdEnvioSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEnvioSMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEnvioSMS.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(211, 132)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(211, 17)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "&Requerimos tu Numero de Celular."
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(194, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(297, 32)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Validación por SMS ."
        '
        'PanelOlvidoContrasena
        '
        Me.PanelOlvidoContrasena.Controls.Add(Me.PanelRestablece)
        Me.PanelOlvidoContrasena.Controls.Add(Me.PanelValida)
        Me.PanelOlvidoContrasena.Controls.Add(Me.CmdCambiaClave)
        Me.PanelOlvidoContrasena.Controls.Add(Me.CmdCancelarMensajeOlvido)
        Me.PanelOlvidoContrasena.Controls.Add(Me.Label21)
        Me.PanelOlvidoContrasena.Controls.Add(Me.Label19)
        Me.PanelOlvidoContrasena.Location = New System.Drawing.Point(32, 51)
        Me.PanelOlvidoContrasena.Name = "PanelOlvidoContrasena"
        Me.PanelOlvidoContrasena.Size = New System.Drawing.Size(660, 454)
        Me.PanelOlvidoContrasena.TabIndex = 28
        Me.PanelOlvidoContrasena.Visible = False
        '
        'PanelRestablece
        '
        Me.PanelRestablece.Controls.Add(Me.Label1)
        Me.PanelRestablece.Controls.Add(Me.txtContrasenaOlvido)
        Me.PanelRestablece.Controls.Add(Me.CmbNumerosOlvido)
        Me.PanelRestablece.Controls.Add(Me.Label24)
        Me.PanelRestablece.Controls.Add(Me.Label23)
        Me.PanelRestablece.Controls.Add(Me.Label25)
        Me.PanelRestablece.Controls.Add(Me.TxtRepitaContrasenaOlvido)
        Me.PanelRestablece.Location = New System.Drawing.Point(199, 235)
        Me.PanelRestablece.Name = "PanelRestablece"
        Me.PanelRestablece.Size = New System.Drawing.Size(433, 133)
        Me.PanelRestablece.TabIndex = 78
        Me.PanelRestablece.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(65, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "&Usuario :"
        '
        'txtContrasenaOlvido
        '
        Me.txtContrasenaOlvido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContrasenaOlvido.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtContrasenaOlvido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtContrasenaOlvido.Location = New System.Drawing.Point(141, 70)
        Me.txtContrasenaOlvido.MaxLength = 20
        Me.txtContrasenaOlvido.Name = "txtContrasenaOlvido"
        Me.txtContrasenaOlvido.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasenaOlvido.Size = New System.Drawing.Size(138, 25)
        Me.txtContrasenaOlvido.TabIndex = 1
        '
        'CmbNumerosOlvido
        '
        Me.CmbNumerosOlvido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbNumerosOlvido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbNumerosOlvido.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmbNumerosOlvido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNumerosOlvido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbNumerosOlvido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbNumerosOlvido.ForeColor = System.Drawing.Color.White
        Me.CmbNumerosOlvido.FormattingEnabled = True
        Me.CmbNumerosOlvido.Location = New System.Drawing.Point(141, 31)
        Me.CmbNumerosOlvido.Name = "CmbNumerosOlvido"
        Me.CmbNumerosOlvido.Size = New System.Drawing.Size(150, 23)
        Me.CmbNumerosOlvido.TabIndex = 0
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(96, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(259, 15)
        Me.Label24.TabIndex = 71
        Me.Label24.Text = "&Escoje tu Usuario para Restablecer la contraseña"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(14, 105)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(109, 15)
        Me.Label23.TabIndex = 75
        Me.Label23.Text = "&Repite Contraseña :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(14, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 15)
        Me.Label25.TabIndex = 74
        Me.Label25.Text = "&Nueva Contraseña :"
        '
        'TxtRepitaContrasenaOlvido
        '
        Me.TxtRepitaContrasenaOlvido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRepitaContrasenaOlvido.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtRepitaContrasenaOlvido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtRepitaContrasenaOlvido.Location = New System.Drawing.Point(141, 101)
        Me.TxtRepitaContrasenaOlvido.MaxLength = 20
        Me.TxtRepitaContrasenaOlvido.Name = "TxtRepitaContrasenaOlvido"
        Me.TxtRepitaContrasenaOlvido.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtRepitaContrasenaOlvido.Size = New System.Drawing.Size(138, 25)
        Me.TxtRepitaContrasenaOlvido.TabIndex = 2
        '
        'PanelValida
        '
        Me.PanelValida.Controls.Add(Me.CmbListaPaisOlvido)
        Me.PanelValida.Controls.Add(Me.CmdEnvioSMSolvido)
        Me.PanelValida.Controls.Add(Me.TxtNumeroCelOlvido)
        Me.PanelValida.Controls.Add(Me.Label20)
        Me.PanelValida.Controls.Add(Me.CmdREEnvioSMSOlvido)
        Me.PanelValida.Controls.Add(Me.LblCodigoValidaOlvido)
        Me.PanelValida.Controls.Add(Me.TxtValidaCodigoO)
        Me.PanelValida.Controls.Add(Me.LblEsperaSMSOlvido)
        Me.PanelValida.Location = New System.Drawing.Point(199, 82)
        Me.PanelValida.Name = "PanelValida"
        Me.PanelValida.Size = New System.Drawing.Size(433, 151)
        Me.PanelValida.TabIndex = 1
        '
        'CmbListaPaisOlvido
        '
        Me.CmbListaPaisOlvido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbListaPaisOlvido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbListaPaisOlvido.BackColor = System.Drawing.Color.White
        Me.CmbListaPaisOlvido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbListaPaisOlvido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbListaPaisOlvido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbListaPaisOlvido.ForeColor = System.Drawing.Color.White
        Me.CmbListaPaisOlvido.FormattingEnabled = True
        Me.CmbListaPaisOlvido.Location = New System.Drawing.Point(33, 3)
        Me.CmbListaPaisOlvido.Name = "CmbListaPaisOlvido"
        Me.CmbListaPaisOlvido.Size = New System.Drawing.Size(121, 23)
        Me.CmbListaPaisOlvido.TabIndex = 1
        '
        'CmdEnvioSMSolvido
        '
        Me.CmdEnvioSMSolvido.FlatAppearance.BorderSize = 0
        Me.CmdEnvioSMSolvido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEnvioSMSolvido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEnvioSMSolvido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdEnvioSMSolvido.IconChar = FontAwesome.Sharp.IconChar.Sms
        Me.CmdEnvioSMSolvido.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdEnvioSMSolvido.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdEnvioSMSolvido.IconSize = 30
        Me.CmdEnvioSMSolvido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEnvioSMSolvido.Location = New System.Drawing.Point(132, 37)
        Me.CmdEnvioSMSolvido.Name = "CmdEnvioSMSolvido"
        Me.CmdEnvioSMSolvido.Size = New System.Drawing.Size(134, 31)
        Me.CmdEnvioSMSolvido.TabIndex = 2
        Me.CmdEnvioSMSolvido.Text = "Enviar SMS"
        Me.CmdEnvioSMSolvido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEnvioSMSolvido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEnvioSMSolvido.UseVisualStyleBackColor = True
        '
        'TxtNumeroCelOlvido
        '
        Me.TxtNumeroCelOlvido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumeroCelOlvido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumeroCelOlvido.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroCelOlvido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtNumeroCelOlvido.Location = New System.Drawing.Point(159, 3)
        Me.TxtNumeroCelOlvido.Name = "TxtNumeroCelOlvido"
        Me.TxtNumeroCelOlvido.Size = New System.Drawing.Size(105, 18)
        Me.TxtNumeroCelOlvido.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(151, 13)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(115, 13)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "__________________"
        '
        'CmdREEnvioSMSOlvido
        '
        Me.CmdREEnvioSMSOlvido.FlatAppearance.BorderSize = 0
        Me.CmdREEnvioSMSOlvido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdREEnvioSMSOlvido.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdREEnvioSMSOlvido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.CmdREEnvioSMSOlvido.IconChar = FontAwesome.Sharp.IconChar.Sms
        Me.CmdREEnvioSMSOlvido.IconColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.CmdREEnvioSMSOlvido.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdREEnvioSMSOlvido.IconSize = 20
        Me.CmdREEnvioSMSOlvido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdREEnvioSMSOlvido.Location = New System.Drawing.Point(264, 117)
        Me.CmdREEnvioSMSOlvido.Name = "CmdREEnvioSMSOlvido"
        Me.CmdREEnvioSMSOlvido.Size = New System.Drawing.Size(134, 27)
        Me.CmdREEnvioSMSOlvido.TabIndex = 4
        Me.CmdREEnvioSMSOlvido.Text = "Re Enviar SMS"
        Me.CmdREEnvioSMSOlvido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdREEnvioSMSOlvido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdREEnvioSMSOlvido.UseVisualStyleBackColor = True
        Me.CmdREEnvioSMSOlvido.Visible = False
        '
        'LblCodigoValidaOlvido
        '
        Me.LblCodigoValidaOlvido.AutoSize = True
        Me.LblCodigoValidaOlvido.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblCodigoValidaOlvido.Location = New System.Drawing.Point(129, 100)
        Me.LblCodigoValidaOlvido.Name = "LblCodigoValidaOlvido"
        Me.LblCodigoValidaOlvido.Size = New System.Drawing.Size(127, 15)
        Me.LblCodigoValidaOlvido.TabIndex = 66
        Me.LblCodigoValidaOlvido.Text = "&Codigo de Verificación"
        Me.LblCodigoValidaOlvido.Visible = False
        '
        'TxtValidaCodigoO
        '
        Me.TxtValidaCodigoO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValidaCodigoO.Location = New System.Drawing.Point(145, 118)
        Me.TxtValidaCodigoO.Mask = "999999"
        Me.TxtValidaCodigoO.Name = "TxtValidaCodigoO"
        Me.TxtValidaCodigoO.Size = New System.Drawing.Size(93, 31)
        Me.TxtValidaCodigoO.TabIndex = 3
        Me.TxtValidaCodigoO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtValidaCodigoO.ValidatingType = GetType(Integer)
        Me.TxtValidaCodigoO.Visible = False
        '
        'LblEsperaSMSOlvido
        '
        Me.LblEsperaSMSOlvido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEsperaSMSOlvido.ForeColor = System.Drawing.Color.DarkGray
        Me.LblEsperaSMSOlvido.Location = New System.Drawing.Point(39, 65)
        Me.LblEsperaSMSOlvido.Name = "LblEsperaSMSOlvido"
        Me.LblEsperaSMSOlvido.Size = New System.Drawing.Size(295, 35)
        Me.LblEsperaSMSOlvido.TabIndex = 64
        Me.LblEsperaSMSOlvido.Text = "Esperar "
        Me.LblEsperaSMSOlvido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblEsperaSMSOlvido.Visible = False
        '
        'CmdCambiaClave
        '
        Me.CmdCambiaClave.Enabled = False
        Me.CmdCambiaClave.FlatAppearance.BorderSize = 0
        Me.CmdCambiaClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCambiaClave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCambiaClave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCambiaClave.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdCambiaClave.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCambiaClave.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCambiaClave.IconSize = 25
        Me.CmdCambiaClave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCambiaClave.Location = New System.Drawing.Point(426, 385)
        Me.CmdCambiaClave.Name = "CmdCambiaClave"
        Me.CmdCambiaClave.Size = New System.Drawing.Size(110, 27)
        Me.CmdCambiaClave.TabIndex = 76
        Me.CmdCambiaClave.Text = "Validar"
        Me.CmdCambiaClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCambiaClave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCambiaClave.UseVisualStyleBackColor = True
        '
        'CmdCancelarMensajeOlvido
        '
        Me.CmdCancelarMensajeOlvido.FlatAppearance.BorderSize = 0
        Me.CmdCancelarMensajeOlvido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelarMensajeOlvido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelarMensajeOlvido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarMensajeOlvido.IconChar = FontAwesome.Sharp.IconChar.TimesCircle
        Me.CmdCancelarMensajeOlvido.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdCancelarMensajeOlvido.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCancelarMensajeOlvido.IconSize = 25
        Me.CmdCancelarMensajeOlvido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelarMensajeOlvido.Location = New System.Drawing.Point(291, 385)
        Me.CmdCancelarMensajeOlvido.Name = "CmdCancelarMensajeOlvido"
        Me.CmdCancelarMensajeOlvido.Size = New System.Drawing.Size(95, 27)
        Me.CmdCancelarMensajeOlvido.TabIndex = 69
        Me.CmdCancelarMensajeOlvido.Text = "&Cancelar"
        Me.CmdCancelarMensajeOlvido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelarMensajeOlvido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancelarMensajeOlvido.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(264, 62)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(290, 17)
        Me.Label21.TabIndex = 60
        Me.Label21.Text = "&Ingresa el Numero de Celular que te registraste."
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(228, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(398, 44)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Para Iniciar debemos verificar tu identidad:"
        '
        'TiempoSMS
        '
        Me.TiempoSMS.Interval = 1000
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.UserRegistrado)
        Me.Panel3.Controls.Add(Me.Lblcelularregistrado)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.CmdIngresoSistema)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Location = New System.Drawing.Point(920, 597)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(763, 540)
        Me.Panel3.TabIndex = 27
        Me.Panel3.Visible = False
        '
        'UserRegistrado
        '
        Me.UserRegistrado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UserRegistrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserRegistrado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.UserRegistrado.Location = New System.Drawing.Point(288, 260)
        Me.UserRegistrado.Name = "UserRegistrado"
        Me.UserRegistrado.Size = New System.Drawing.Size(187, 28)
        Me.UserRegistrado.TabIndex = 59
        Me.UserRegistrado.Text = "PLONDED10"
        '
        'Lblcelularregistrado
        '
        Me.Lblcelularregistrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Lblcelularregistrado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Lblcelularregistrado.Location = New System.Drawing.Point(289, 299)
        Me.Lblcelularregistrado.Name = "Lblcelularregistrado"
        Me.Lblcelularregistrado.Size = New System.Drawing.Size(201, 36)
        Me.Lblcelularregistrado.TabIndex = 57
        Me.Lblcelularregistrado.Text = "948100200"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(219, 258)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 26)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Usuario:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(188, 304)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 26)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Nro. Celular: "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Silver
        Me.Label15.Location = New System.Drawing.Point(188, 337)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(382, 50)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Guarda, en un lugar seguro tu usuario y contraseña"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdIngresoSistema
        '
        Me.CmdIngresoSistema.FlatAppearance.BorderSize = 0
        Me.CmdIngresoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdIngresoSistema.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdIngresoSistema.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdIngresoSistema.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmdIngresoSistema.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdIngresoSistema.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdIngresoSistema.IconSize = 35
        Me.CmdIngresoSistema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdIngresoSistema.Location = New System.Drawing.Point(262, 448)
        Me.CmdIngresoSistema.Name = "CmdIngresoSistema"
        Me.CmdIngresoSistema.Size = New System.Drawing.Size(213, 52)
        Me.CmdIngresoSistema.TabIndex = 53
        Me.CmdIngresoSistema.Text = "&Ingresar al Sistema"
        Me.CmdIngresoSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdIngresoSistema.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdIngresoSistema.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.WindowsApp1.My.Resources.Resources.Logo9
        Me.PictureBox3.Location = New System.Drawing.Point(308, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(111, 92)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 35
        Me.PictureBox3.TabStop = False
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(188, 395)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(382, 50)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Ahora podra tiene acceso a toda la informacion de nuestros Medicamentos."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(186, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(382, 29)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Gracias por ser parte de ORI"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.WindowsApp1.My.Resources.Resources.bienvenido
        Me.PictureBox2.Location = New System.Drawing.Point(294, 137)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(142, 92)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'ImagenesPaises
        '
        Me.ImagenesPaises.ImageStream = CType(resources.GetObject("ImagenesPaises.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImagenesPaises.TransparentColor = System.Drawing.Color.Transparent
        Me.ImagenesPaises.Images.SetKeyName(0, "peru.png")
        '
        'TiempoSMSOlvido
        '
        Me.TiempoSMSOlvido.Interval = 1000
        '
        'FrmCreaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1283, 662)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.PanelOlvidoContrasena)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "FrmCreaUsuario"
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelOlvidoContrasena.ResumeLayout(False)
        Me.PanelOlvidoContrasena.PerformLayout()
        Me.PanelRestablece.ResumeLayout(False)
        Me.PanelRestablece.PerformLayout()
        Me.PanelValida.ResumeLayout(False)
        Me.PanelValida.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents FaltaDatos As ErrorProvider
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CmdCancelarCrear As FontAwesome.Sharp.IconButton
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtApellidos As TextBox
    Friend WithEvents TxtNombres As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbTipoDocUsuario As ComboBox
    Friend WithEvents TxtNumero As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtRepitaContrasena As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CmdSiguiente As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtCodigoValida As MaskedTextBox
    Friend WithEvents CmdEnvioSMS As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtNumeroCel As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CmdAceptarSMS As FontAwesome.Sharp.IconButton
    Friend WithEvents LblCodigoValida As Label
    Friend WithEvents CmdAtras As FontAwesome.Sharp.IconButton
    Friend WithEvents LblEsperaSMS As Label
    Friend WithEvents TiempoSMS As Timer
    Friend WithEvents CmdCancelarMensaje As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdREEnvioSMS As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents CmdIngresoSistema As FontAwesome.Sharp.IconButton
    Friend WithEvents LblMensaje1 As Label
    Friend WithEvents CmbListaPais As ComboBox
    Friend WithEvents ImagenesPaises As ImageList
    Friend WithEvents Label16 As Label
    Friend WithEvents Lblcelularregistrado As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents CmbNumerosOlvido As ComboBox
    Friend WithEvents CmdCancelarMensajeOlvido As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdREEnvioSMSOlvido As FontAwesome.Sharp.IconButton
    Friend WithEvents LblCodigoValidaOlvido As Label
    Friend WithEvents TxtValidaCodigoO As MaskedTextBox
    Friend WithEvents LblEsperaSMSOlvido As Label
    Friend WithEvents CmdEnvioSMSolvido As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtNumeroCelOlvido As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents CmbListaPaisOlvido As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Public WithEvents Panel1 As Panel
    Public WithEvents PanelOlvidoContrasena As Panel
    Friend WithEvents Label22 As Label
    Friend WithEvents UserRegistrado As TextBox
    Friend WithEvents CmdCambiaClave As FontAwesome.Sharp.IconButton
    Friend WithEvents Label23 As Label
    Friend WithEvents txtContrasenaOlvido As TextBox
    Friend WithEvents TxtRepitaContrasenaOlvido As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents PanelRestablece As Panel
    Friend WithEvents PanelValida As Panel
    Public WithEvents LblTitulo As Label
    Friend WithEvents TiempoSMSOlvido As Timer
    Friend WithEvents Label1 As Label
End Class
