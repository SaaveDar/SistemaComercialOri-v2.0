<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPerfil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPerfil))
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CircularProgressBar1 = New CircularProgressBar.CircularProgressBar()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Genero3 = New System.Windows.Forms.RadioButton()
        Me.Genero2 = New System.Windows.Forms.RadioButton()
        Me.Genero1 = New System.Windows.Forms.RadioButton()
        Me.CmdCancelarCrear = New FontAwesome.Sharp.IconButton()
        Me.CmdActualizar = New FontAwesome.Sharp.IconButton()
        Me.FotoPerfil = New System.Windows.Forms.PictureBox()
        Me.FechaNac = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbCiudad = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtxEmail = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCelular = New System.Windows.Forms.TextBox()
        Me.CmdFotoPerfil = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbTipoDocUsuario = New System.Windows.Forms.ComboBox()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FaltaDatos = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FotoPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.Label12)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(585, 32)
        Me.PanelSup.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(170, 16)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Información de tu Perfil."
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
        Me.CmdCerrar.Location = New System.Drawing.Point(547, -3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 26)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CircularProgressBar1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Genero3)
        Me.Panel1.Controls.Add(Me.Genero2)
        Me.Panel1.Controls.Add(Me.Genero1)
        Me.Panel1.Controls.Add(Me.CmdCancelarCrear)
        Me.Panel1.Controls.Add(Me.CmdActualizar)
        Me.Panel1.Controls.Add(Me.FotoPerfil)
        Me.Panel1.Controls.Add(Me.FechaNac)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.CmbCiudad)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtxEmail)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtCelular)
        Me.Panel1.Controls.Add(Me.CmdFotoPerfil)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtUsuario)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtApellidos)
        Me.Panel1.Controls.Add(Me.TxtNombres)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.CmbTipoDocUsuario)
        Me.Panel1.Controls.Add(Me.TxtNumero)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(0, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 575)
        Me.Panel1.TabIndex = 5
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
        Me.CircularProgressBar1.Location = New System.Drawing.Point(413, 433)
        Me.CircularProgressBar1.MarqueeAnimationSpeed = 2000
        Me.CircularProgressBar1.Name = "CircularProgressBar1"
        Me.CircularProgressBar1.OuterColor = System.Drawing.Color.White
        Me.CircularProgressBar1.OuterMargin = -25
        Me.CircularProgressBar1.OuterWidth = 26
        Me.CircularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.CircularProgressBar1.ProgressWidth = 5
        Me.CircularProgressBar1.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.CircularProgressBar1.Size = New System.Drawing.Size(51, 47)
        Me.CircularProgressBar1.StartAngle = 270
        Me.CircularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.CircularProgressBar1.SubscriptColor = System.Drawing.Color.Transparent
        Me.CircularProgressBar1.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.CircularProgressBar1.SubscriptText = ""
        Me.CircularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CircularProgressBar1.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.CircularProgressBar1.SuperscriptText = ""
        Me.CircularProgressBar1.TabIndex = 70
        Me.CircularProgressBar1.TextMargin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.CircularProgressBar1.Value = 68
        Me.CircularProgressBar1.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(248, 208)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(236, 15)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "*Su Nro.Celular podra cambiarlo en 45 dias."
        '
        'Genero3
        '
        Me.Genero3.AutoSize = True
        Me.Genero3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Genero3.Location = New System.Drawing.Point(324, 336)
        Me.Genero3.Name = "Genero3"
        Me.Genero3.Size = New System.Drawing.Size(81, 19)
        Me.Genero3.TabIndex = 68
        Me.Genero3.TabStop = True
        Me.Genero3.Text = "No Indicar"
        Me.Genero3.UseVisualStyleBackColor = True
        '
        'Genero2
        '
        Me.Genero2.AutoSize = True
        Me.Genero2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Genero2.Location = New System.Drawing.Point(228, 336)
        Me.Genero2.Name = "Genero2"
        Me.Genero2.Size = New System.Drawing.Size(81, 19)
        Me.Genero2.TabIndex = 67
        Me.Genero2.TabStop = True
        Me.Genero2.Text = "Femenino"
        Me.Genero2.UseVisualStyleBackColor = True
        '
        'Genero1
        '
        Me.Genero1.AutoSize = True
        Me.Genero1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Genero1.Location = New System.Drawing.Point(137, 336)
        Me.Genero1.Name = "Genero1"
        Me.Genero1.Size = New System.Drawing.Size(82, 19)
        Me.Genero1.TabIndex = 66
        Me.Genero1.TabStop = True
        Me.Genero1.Text = "Masculino"
        Me.Genero1.UseVisualStyleBackColor = True
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
        Me.CmdCancelarCrear.Location = New System.Drawing.Point(136, 453)
        Me.CmdCancelarCrear.Name = "CmdCancelarCrear"
        Me.CmdCancelarCrear.Size = New System.Drawing.Size(95, 27)
        Me.CmdCancelarCrear.TabIndex = 65
        Me.CmdCancelarCrear.Text = "&Cancelar"
        Me.CmdCancelarCrear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelarCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancelarCrear.UseVisualStyleBackColor = True
        '
        'CmdActualizar
        '
        Me.CmdActualizar.FlatAppearance.BorderSize = 0
        Me.CmdActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdActualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdActualizar.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdActualizar.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdActualizar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdActualizar.IconSize = 25
        Me.CmdActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdActualizar.Location = New System.Drawing.Point(275, 453)
        Me.CmdActualizar.Name = "CmdActualizar"
        Me.CmdActualizar.Size = New System.Drawing.Size(110, 27)
        Me.CmdActualizar.TabIndex = 64
        Me.CmdActualizar.Text = "Actualizar"
        Me.CmdActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdActualizar.UseVisualStyleBackColor = True
        '
        'FotoPerfil
        '
        Me.FotoPerfil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FotoPerfil.BackColor = System.Drawing.Color.Transparent
        Me.FotoPerfil.Location = New System.Drawing.Point(434, 6)
        Me.FotoPerfil.Name = "FotoPerfil"
        Me.FotoPerfil.Size = New System.Drawing.Size(129, 130)
        Me.FotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.FotoPerfil.TabIndex = 63
        Me.FotoPerfil.TabStop = False
        '
        'FechaNac
        '
        Me.FechaNac.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaNac.Location = New System.Drawing.Point(139, 266)
        Me.FechaNac.Name = "FechaNac"
        Me.FechaNac.Size = New System.Drawing.Size(103, 20)
        Me.FechaNac.TabIndex = 62
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(12, 266)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 15)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "&Fecha Nacimiento :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(67, 336)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "&Genero :"
        '
        'CmbCiudad
        '
        Me.CmbCiudad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCiudad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCiudad.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCiudad.ForeColor = System.Drawing.Color.White
        Me.CmbCiudad.FormattingEnabled = True
        Me.CmbCiudad.Location = New System.Drawing.Point(139, 235)
        Me.CmbCiudad.Name = "CmbCiudad"
        Me.CmbCiudad.Size = New System.Drawing.Size(187, 23)
        Me.CmbCiudad.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(70, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "&Ciudad :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(79, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 15)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "&eMail :"
        '
        'TxtxEmail
        '
        Me.TxtxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtxEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtxEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtxEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtxEmail.Location = New System.Drawing.Point(139, 292)
        Me.TxtxEmail.MaxLength = 100
        Me.TxtxEmail.Name = "TxtxEmail"
        Me.TxtxEmail.Size = New System.Drawing.Size(271, 25)
        Me.TxtxEmail.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(49, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "&Nro. Celular :"
        '
        'TxtCelular
        '
        Me.TxtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCelular.Enabled = False
        Me.TxtCelular.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtCelular.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtCelular.Location = New System.Drawing.Point(139, 204)
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.Size = New System.Drawing.Size(103, 25)
        Me.TxtCelular.TabIndex = 52
        '
        'CmdFotoPerfil
        '
        Me.CmdFotoPerfil.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdFotoPerfil.FlatAppearance.BorderSize = 0
        Me.CmdFotoPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdFotoPerfil.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CmdFotoPerfil.ForeColor = System.Drawing.Color.White
        Me.CmdFotoPerfil.IconChar = FontAwesome.Sharp.IconChar.Image
        Me.CmdFotoPerfil.IconColor = System.Drawing.Color.White
        Me.CmdFotoPerfil.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdFotoPerfil.IconSize = 20
        Me.CmdFotoPerfil.Location = New System.Drawing.Point(448, 142)
        Me.CmdFotoPerfil.Name = "CmdFotoPerfil"
        Me.CmdFotoPerfil.Size = New System.Drawing.Size(106, 36)
        Me.CmdFotoPerfil.TabIndex = 8
        Me.CmdFotoPerfil.Text = "FOTO PERFIL"
        Me.CmdFotoPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFotoPerfil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdFotoPerfil.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(140, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 15)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "*Su Nombre de usaurio podra cambiarlo en 45 dias."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(25, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "&Usuario :"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtUsuario.Location = New System.Drawing.Point(137, 28)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(169, 25)
        Me.TxtUsuario.TabIndex = 49
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(68, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "&Apellidos :"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApellidos.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtApellidos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtApellidos.Location = New System.Drawing.Point(139, 173)
        Me.TxtApellidos.MaxLength = 100
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(271, 25)
        Me.TxtApellidos.TabIndex = 44
        '
        'TxtNombres
        '
        Me.TxtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombres.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtNombres.Location = New System.Drawing.Point(139, 142)
        Me.TxtNombres.MaxLength = 100
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(271, 25)
        Me.TxtNombres.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(68, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 15)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "&Nombres :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(95, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 46
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
        Me.CmbTipoDocUsuario.Location = New System.Drawing.Point(137, 82)
        Me.CmbTipoDocUsuario.Name = "CmbTipoDocUsuario"
        Me.CmbTipoDocUsuario.Size = New System.Drawing.Size(187, 23)
        Me.CmbTipoDocUsuario.TabIndex = 41
        '
        'TxtNumero
        '
        Me.TxtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TxtNumero.Location = New System.Drawing.Point(137, 111)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(103, 25)
        Me.TxtNumero.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(25, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 15)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "&Tipo Documento:"
        '
        'FaltaDatos
        '
        Me.FaltaDatos.ContainerControl = Me
        Me.FaltaDatos.Icon = CType(resources.GetObject("FaltaDatos.Icon"), System.Drawing.Icon)
        '
        'FrmPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(585, 649)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelSup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPerfil"
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FotoPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CmdFotoPerfil As FontAwesome.Sharp.IconButton
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtApellidos As TextBox
    Friend WithEvents TxtNombres As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbTipoDocUsuario As ComboBox
    Friend WithEvents TxtNumero As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCelular As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents FechaNac As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents CmbCiudad As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtxEmail As TextBox
    Friend WithEvents CmdCancelarCrear As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdActualizar As FontAwesome.Sharp.IconButton
    Friend WithEvents Label12 As Label
    Friend WithEvents Genero3 As RadioButton
    Friend WithEvents Genero2 As RadioButton
    Friend WithEvents Genero1 As RadioButton
    Friend WithEvents Label13 As Label
    Public WithEvents FotoPerfil As PictureBox
    Friend WithEvents CircularProgressBar1 As CircularProgressBar.CircularProgressBar
    Friend WithEvents FaltaDatos As ErrorProvider
End Class
