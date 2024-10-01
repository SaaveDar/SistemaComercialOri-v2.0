<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFormatosOper
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
        Me.lblOperacion = New System.Windows.Forms.Label()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmd56 = New FontAwesome.Sharp.IconButton()
        Me.Cmd80 = New FontAwesome.Sharp.IconButton()
        Me.CmdA4 = New FontAwesome.Sharp.IconButton()
        Me.Cmdimpresora = New FontAwesome.Sharp.IconButton()
        Me.cmdpantalla = New FontAwesome.Sharp.IconButton()
        Me.CmdNoImprime = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdAsigna = New FontAwesome.Sharp.IconButton()
        Me.ListaIMP1 = New System.Windows.Forms.ListBox()
        Me.txtNroCopias = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdpdf = New FontAwesome.Sharp.IconButton()
        Me.cmenos = New FontAwesome.Sharp.IconButton()
        Me.cmas = New FontAwesome.Sharp.IconButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.id_destino = New System.Windows.Forms.Label()
        Me.id_formato = New System.Windows.Forms.Label()
        Me.frameimp = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Check_1 = New System.Windows.Forms.CheckBox()
        Me.Check_2 = New System.Windows.Forms.CheckBox()
        Me.ListaIMP2 = New System.Windows.Forms.ListBox()
        Me.Check_3 = New System.Windows.Forms.CheckBox()
        Me.ListaIMP3 = New System.Windows.Forms.ListBox()
        Me.PanelSup.SuspendLayout()
        Me.frameimp.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.lblOperacion)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(409, 53)
        Me.PanelSup.TabIndex = 3
        '
        'lblOperacion
        '
        Me.lblOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperacion.ForeColor = System.Drawing.Color.White
        Me.lblOperacion.Location = New System.Drawing.Point(7, 6)
        Me.lblOperacion.Name = "lblOperacion"
        Me.lblOperacion.Size = New System.Drawing.Size(277, 43)
        Me.lblOperacion.TabIndex = 135
        Me.lblOperacion.Text = "2401 -VENTAS COMERCIALES  - DIRECTO - CONTADO"
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
        Me.CmdCerrar.Location = New System.Drawing.Point(367, 1)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 32)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 563)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(409, 33)
        Me.Panel1.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(10, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 12)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "DESTINAR A LAS IMPRESORAS :"
        '
        'Cmd56
        '
        Me.Cmd56.FlatAppearance.BorderSize = 0
        Me.Cmd56.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd56.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd56.ForeColor = System.Drawing.Color.Black
        Me.Cmd56.IconChar = FontAwesome.Sharp.IconChar.File
        Me.Cmd56.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd56.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd56.IconSize = 20
        Me.Cmd56.Location = New System.Drawing.Point(44, 173)
        Me.Cmd56.Name = "Cmd56"
        Me.Cmd56.Size = New System.Drawing.Size(92, 56)
        Me.Cmd56.TabIndex = 24
        Me.Cmd56.Text = "56mm"
        Me.Cmd56.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd56.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Cmd56.UseVisualStyleBackColor = True
        '
        'Cmd80
        '
        Me.Cmd80.FlatAppearance.BorderSize = 0
        Me.Cmd80.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd80.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd80.ForeColor = System.Drawing.Color.Black
        Me.Cmd80.IconChar = FontAwesome.Sharp.IconChar.File
        Me.Cmd80.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmd80.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmd80.IconSize = 25
        Me.Cmd80.Location = New System.Drawing.Point(150, 173)
        Me.Cmd80.Name = "Cmd80"
        Me.Cmd80.Size = New System.Drawing.Size(92, 56)
        Me.Cmd80.TabIndex = 27
        Me.Cmd80.Text = "80mm"
        Me.Cmd80.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd80.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Cmd80.UseVisualStyleBackColor = True
        '
        'CmdA4
        '
        Me.CmdA4.FlatAppearance.BorderSize = 0
        Me.CmdA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdA4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdA4.ForeColor = System.Drawing.Color.Black
        Me.CmdA4.IconChar = FontAwesome.Sharp.IconChar.File
        Me.CmdA4.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdA4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdA4.IconSize = 35
        Me.CmdA4.Location = New System.Drawing.Point(259, 173)
        Me.CmdA4.Name = "CmdA4"
        Me.CmdA4.Size = New System.Drawing.Size(92, 56)
        Me.CmdA4.TabIndex = 28
        Me.CmdA4.Text = "A4"
        Me.CmdA4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdA4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdA4.UseVisualStyleBackColor = True
        '
        'Cmdimpresora
        '
        Me.Cmdimpresora.BackColor = System.Drawing.Color.Transparent
        Me.Cmdimpresora.FlatAppearance.BorderSize = 0
        Me.Cmdimpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmdimpresora.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdimpresora.ForeColor = System.Drawing.Color.Black
        Me.Cmdimpresora.IconChar = FontAwesome.Sharp.IconChar.Print
        Me.Cmdimpresora.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cmdimpresora.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Cmdimpresora.IconSize = 30
        Me.Cmdimpresora.Location = New System.Drawing.Point(114, 76)
        Me.Cmdimpresora.Name = "Cmdimpresora"
        Me.Cmdimpresora.Size = New System.Drawing.Size(92, 56)
        Me.Cmdimpresora.TabIndex = 29
        Me.Cmdimpresora.Text = "IMPRESORA"
        Me.Cmdimpresora.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmdimpresora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Cmdimpresora.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.Color.Transparent
        Me.cmdpantalla.FlatAppearance.BorderSize = 0
        Me.cmdpantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdpantalla.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdpantalla.ForeColor = System.Drawing.Color.Black
        Me.cmdpantalla.IconChar = FontAwesome.Sharp.IconChar.Laptop
        Me.cmdpantalla.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdpantalla.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.cmdpantalla.IconSize = 30
        Me.cmdpantalla.Location = New System.Drawing.Point(212, 76)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(92, 56)
        Me.cmdpantalla.TabIndex = 30
        Me.cmdpantalla.Text = "PANTALLA"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdpantalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'CmdNoImprime
        '
        Me.CmdNoImprime.BackColor = System.Drawing.Color.Transparent
        Me.CmdNoImprime.FlatAppearance.BorderSize = 0
        Me.CmdNoImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdNoImprime.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNoImprime.ForeColor = System.Drawing.Color.Black
        Me.CmdNoImprime.IconChar = FontAwesome.Sharp.IconChar.Circle
        Me.CmdNoImprime.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdNoImprime.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdNoImprime.IconSize = 30
        Me.CmdNoImprime.Location = New System.Drawing.Point(17, 76)
        Me.CmdNoImprime.Name = "CmdNoImprime"
        Me.CmdNoImprime.Size = New System.Drawing.Size(92, 56)
        Me.CmdNoImprime.TabIndex = 31
        Me.CmdNoImprime.Text = "NO IMPRIMIR"
        Me.CmdNoImprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNoImprime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdNoImprime.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(15, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "NRO. COPIAS"
        '
        'CmdAsigna
        '
        Me.CmdAsigna.FlatAppearance.BorderSize = 0
        Me.CmdAsigna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAsigna.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAsigna.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAsigna.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdAsigna.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdAsigna.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAsigna.IconSize = 25
        Me.CmdAsigna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAsigna.Location = New System.Drawing.Point(104, 527)
        Me.CmdAsigna.Name = "CmdAsigna"
        Me.CmdAsigna.Size = New System.Drawing.Size(164, 27)
        Me.CmdAsigna.TabIndex = 129
        Me.CmdAsigna.Text = "&Asignar por Defecto"
        Me.CmdAsigna.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAsigna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAsigna.UseVisualStyleBackColor = True
        '
        'ListaIMP1
        '
        Me.ListaIMP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListaIMP1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListaIMP1.ForeColor = System.Drawing.Color.White
        Me.ListaIMP1.FormattingEnabled = True
        Me.ListaIMP1.ItemHeight = 21
        Me.ListaIMP1.Location = New System.Drawing.Point(5, 33)
        Me.ListaIMP1.Name = "ListaIMP1"
        Me.ListaIMP1.Size = New System.Drawing.Size(388, 130)
        Me.ListaIMP1.TabIndex = 0
        '
        'txtNroCopias
        '
        Me.txtNroCopias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroCopias.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroCopias.Location = New System.Drawing.Point(104, 246)
        Me.txtNroCopias.MaxLength = 2
        Me.txtNroCopias.Name = "txtNroCopias"
        Me.txtNroCopias.Size = New System.Drawing.Size(38, 35)
        Me.txtNroCopias.TabIndex = 132
        Me.txtNroCopias.Text = "1"
        Me.txtNroCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(12, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 12)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "TIPO DEL FORMATO :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(13, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 12)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "DESTINO DEL FORMATO :"
        '
        'cmdpdf
        '
        Me.cmdpdf.BackColor = System.Drawing.Color.Transparent
        Me.cmdpdf.FlatAppearance.BorderSize = 0
        Me.cmdpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdpdf.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdpdf.ForeColor = System.Drawing.Color.Black
        Me.cmdpdf.IconChar = FontAwesome.Sharp.IconChar.FilePdf
        Me.cmdpdf.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdpdf.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.cmdpdf.IconSize = 30
        Me.cmdpdf.Location = New System.Drawing.Point(310, 76)
        Me.cmdpdf.Name = "cmdpdf"
        Me.cmdpdf.Size = New System.Drawing.Size(80, 56)
        Me.cmdpdf.TabIndex = 135
        Me.cmdpdf.Text = "PDF"
        Me.cmdpdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdpdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdpdf.UseVisualStyleBackColor = False
        '
        'cmenos
        '
        Me.cmenos.FlatAppearance.BorderSize = 0
        Me.cmenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmenos.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmenos.ForeColor = System.Drawing.Color.Black
        Me.cmenos.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft
        Me.cmenos.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmenos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.cmenos.IconSize = 30
        Me.cmenos.Location = New System.Drawing.Point(66, 252)
        Me.cmenos.Name = "cmenos"
        Me.cmenos.Size = New System.Drawing.Size(40, 25)
        Me.cmenos.TabIndex = 136
        Me.cmenos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmenos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmenos.UseVisualStyleBackColor = True
        '
        'cmas
        '
        Me.cmas.FlatAppearance.BorderSize = 0
        Me.cmas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmas.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmas.ForeColor = System.Drawing.Color.Black
        Me.cmas.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleRight
        Me.cmas.IconColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.cmas.IconSize = 30
        Me.cmas.Location = New System.Drawing.Point(142, 252)
        Me.cmas.Name = "cmas"
        Me.cmas.Size = New System.Drawing.Size(31, 25)
        Me.cmas.TabIndex = 137
        Me.cmas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmas.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(310, 528)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 29)
        Me.Button1.TabIndex = 138
        Me.Button1.Text = "RECUP"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'id_destino
        '
        Me.id_destino.AutoSize = True
        Me.id_destino.Location = New System.Drawing.Point(256, 56)
        Me.id_destino.Name = "id_destino"
        Me.id_destino.Size = New System.Drawing.Size(55, 13)
        Me.id_destino.TabIndex = 139
        Me.id_destino.Text = "id_destino"
        Me.id_destino.Visible = False
        '
        'id_formato
        '
        Me.id_formato.AutoSize = True
        Me.id_formato.Location = New System.Drawing.Point(272, 150)
        Me.id_formato.Name = "id_formato"
        Me.id_formato.Size = New System.Drawing.Size(56, 13)
        Me.id_formato.TabIndex = 140
        Me.id_formato.Text = "id_formato"
        Me.id_formato.Visible = False
        '
        'frameimp
        '
        Me.frameimp.Controls.Add(Me.TabPage1)
        Me.frameimp.Controls.Add(Me.TabPage2)
        Me.frameimp.Controls.Add(Me.TabPage3)
        Me.frameimp.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameimp.ItemSize = New System.Drawing.Size(121, 25)
        Me.frameimp.Location = New System.Drawing.Point(2, 318)
        Me.frameimp.Name = "frameimp"
        Me.frameimp.SelectedIndex = 0
        Me.frameimp.Size = New System.Drawing.Size(406, 207)
        Me.frameimp.TabIndex = 141
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Check_1)
        Me.TabPage1.Controls.Add(Me.ListaIMP1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(398, 174)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PRIMERA"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Check_2)
        Me.TabPage2.Controls.Add(Me.ListaIMP2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(398, 174)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SEGUNDA"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Check_3)
        Me.TabPage3.Controls.Add(Me.ListaIMP3)
        Me.TabPage3.ForeColor = System.Drawing.Color.Black
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(398, 174)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TERCERA "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Check_1
        '
        Me.Check_1.AutoSize = True
        Me.Check_1.Location = New System.Drawing.Point(7, 12)
        Me.Check_1.Name = "Check_1"
        Me.Check_1.Size = New System.Drawing.Size(133, 17)
        Me.Check_1.TabIndex = 34
        Me.Check_1.Text = "ACTIVAR IMPRESORA"
        Me.Check_1.UseVisualStyleBackColor = True
        '
        'Check_2
        '
        Me.Check_2.AutoSize = True
        Me.Check_2.Enabled = False
        Me.Check_2.Location = New System.Drawing.Point(7, 12)
        Me.Check_2.Name = "Check_2"
        Me.Check_2.Size = New System.Drawing.Size(133, 17)
        Me.Check_2.TabIndex = 36
        Me.Check_2.Text = "ACTIVAR IMPRESORA"
        Me.Check_2.UseVisualStyleBackColor = True
        '
        'ListaIMP2
        '
        Me.ListaIMP2.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListaIMP2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListaIMP2.ForeColor = System.Drawing.Color.White
        Me.ListaIMP2.FormattingEnabled = True
        Me.ListaIMP2.ItemHeight = 21
        Me.ListaIMP2.Location = New System.Drawing.Point(5, 33)
        Me.ListaIMP2.Name = "ListaIMP2"
        Me.ListaIMP2.Size = New System.Drawing.Size(388, 130)
        Me.ListaIMP2.TabIndex = 35
        '
        'Check_3
        '
        Me.Check_3.AutoSize = True
        Me.Check_3.Enabled = False
        Me.Check_3.Location = New System.Drawing.Point(7, 12)
        Me.Check_3.Name = "Check_3"
        Me.Check_3.Size = New System.Drawing.Size(133, 17)
        Me.Check_3.TabIndex = 36
        Me.Check_3.Text = "ACTIVAR IMPRESORA"
        Me.Check_3.UseVisualStyleBackColor = True
        '
        'ListaIMP3
        '
        Me.ListaIMP3.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ListaIMP3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListaIMP3.ForeColor = System.Drawing.Color.White
        Me.ListaIMP3.FormattingEnabled = True
        Me.ListaIMP3.ItemHeight = 21
        Me.ListaIMP3.Location = New System.Drawing.Point(5, 33)
        Me.ListaIMP3.Name = "ListaIMP3"
        Me.ListaIMP3.Size = New System.Drawing.Size(388, 130)
        Me.ListaIMP3.TabIndex = 35
        '
        'FrmFormatosOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(409, 596)
        Me.ControlBox = False
        Me.Controls.Add(Me.frameimp)
        Me.Controls.Add(Me.id_formato)
        Me.Controls.Add(Me.id_destino)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmas)
        Me.Controls.Add(Me.cmenos)
        Me.Controls.Add(Me.cmdpdf)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNroCopias)
        Me.Controls.Add(Me.CmdAsigna)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmdNoImprime)
        Me.Controls.Add(Me.cmdpantalla)
        Me.Controls.Add(Me.Cmdimpresora)
        Me.Controls.Add(Me.CmdA4)
        Me.Controls.Add(Me.Cmd80)
        Me.Controls.Add(Me.Cmd56)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelSup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFormatosOper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.frameimp.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmd56 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmd80 As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdA4 As FontAwesome.Sharp.IconButton
    Friend WithEvents Cmdimpresora As FontAwesome.Sharp.IconButton
    Friend WithEvents cmdpantalla As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdNoImprime As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents CmdAsigna As FontAwesome.Sharp.IconButton
    Friend WithEvents ListaIMP1 As ListBox
    Friend WithEvents txtNroCopias As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblOperacion As Label
    Friend WithEvents cmdpdf As FontAwesome.Sharp.IconButton
    Friend WithEvents cmenos As FontAwesome.Sharp.IconButton
    Friend WithEvents cmas As FontAwesome.Sharp.IconButton
    Friend WithEvents Button1 As Button
    Friend WithEvents id_destino As Label
    Friend WithEvents id_formato As Label
    Friend WithEvents frameimp As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Check_1 As CheckBox
    Friend WithEvents Check_2 As CheckBox
    Friend WithEvents ListaIMP2 As ListBox
    Friend WithEvents Check_3 As CheckBox
    Friend WithEvents ListaIMP3 As ListBox
End Class
