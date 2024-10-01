<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConfLocal
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
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.Lbl_local = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.LblTs = New System.Windows.Forms.Label()
        Me.CmdGrabar = New FontAwesome.Sharp.IconButton()
        Me.dt_Tablas_basicas = New System.Windows.Forms.DataGridView()
        Me.CmbListaComp = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmdOperacion = New FontAwesome.Sharp.IconButton()
        Me.CmdBusoper = New FontAwesome.Sharp.IconButton()
        Me.TxtOperacion = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CmdActImp = New FontAwesome.Sharp.IconButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtVal_imp = New System.Windows.Forms.TextBox()
        Me.TxtEti_imp = New System.Windows.Forms.TextBox()
        Me.Valorp = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PanelSup.SuspendLayout()
        CType(Me.dt_Tablas_basicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Silver
        Me.PanelSup.Controls.Add(Me.Lbl_local)
        Me.PanelSup.Controls.Add(Me.Label2)
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(744, 32)
        Me.PanelSup.TabIndex = 3
        '
        'Lbl_local
        '
        Me.Lbl_local.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_local.ForeColor = System.Drawing.Color.White
        Me.Lbl_local.Location = New System.Drawing.Point(84, 3)
        Me.Lbl_local.Name = "Lbl_local"
        Me.Lbl_local.Size = New System.Drawing.Size(413, 24)
        Me.Lbl_local.TabIndex = 32
        Me.Lbl_local.Text = "NEGOCIO  / LOCAL "
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 24)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Local :"
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(652, 4)
        Me.CmdRestaurar.Name = "CmdRestaurar"
        Me.CmdRestaurar.Size = New System.Drawing.Size(32, 25)
        Me.CmdRestaurar.TabIndex = 11
        Me.CmdRestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdRestaurar.UseVisualStyleBackColor = True
        Me.CmdRestaurar.Visible = False
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
        Me.CmdCerrar.Location = New System.Drawing.Point(701, 0)
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
        Me.CmdMin.Location = New System.Drawing.Point(602, 3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        Me.CmdMin.Visible = False
        '
        'LblTs
        '
        Me.LblTs.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTs.Location = New System.Drawing.Point(24, 94)
        Me.LblTs.Name = "LblTs"
        Me.LblTs.Size = New System.Drawing.Size(247, 18)
        Me.LblTs.TabIndex = 80
        Me.LblTs.Text = "LISTA DE SERIES PARA EL COMPROBANTE"
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
        Me.CmdGrabar.Location = New System.Drawing.Point(466, 329)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(87, 45)
        Me.CmdGrabar.TabIndex = 79
        Me.CmdGrabar.Text = "&ACTUALIZAR"
        Me.CmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'dt_Tablas_basicas
        '
        Me.dt_Tablas_basicas.AllowUserToAddRows = False
        Me.dt_Tablas_basicas.AllowUserToDeleteRows = False
        Me.dt_Tablas_basicas.AllowUserToResizeRows = False
        Me.dt_Tablas_basicas.BackgroundColor = System.Drawing.Color.White
        Me.dt_Tablas_basicas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dt_Tablas_basicas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dt_Tablas_basicas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_Tablas_basicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dt_Tablas_basicas.GridColor = System.Drawing.Color.White
        Me.dt_Tablas_basicas.Location = New System.Drawing.Point(27, 115)
        Me.dt_Tablas_basicas.MultiSelect = False
        Me.dt_Tablas_basicas.Name = "dt_Tablas_basicas"
        Me.dt_Tablas_basicas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dt_Tablas_basicas.RowHeadersVisible = False
        Me.dt_Tablas_basicas.RowTemplate.Height = 25
        Me.dt_Tablas_basicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt_Tablas_basicas.Size = New System.Drawing.Size(584, 198)
        Me.dt_Tablas_basicas.TabIndex = 33
        '
        'CmbListaComp
        '
        Me.CmbListaComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbListaComp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbListaComp.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmbListaComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbListaComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbListaComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbListaComp.ForeColor = System.Drawing.Color.White
        Me.CmbListaComp.FormattingEnabled = True
        Me.CmbListaComp.Location = New System.Drawing.Point(27, 56)
        Me.CmbListaComp.Name = "CmbListaComp"
        Me.CmbListaComp.Size = New System.Drawing.Size(368, 23)
        Me.CmbListaComp.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 18)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "LISTA DE COMPROBANTES DISPONIBLES"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 27)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "COD. OPERACION"
        '
        'CmdOperacion
        '
        Me.CmdOperacion.FlatAppearance.BorderSize = 0
        Me.CmdOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOperacion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOperacion.ForeColor = System.Drawing.Color.Gray
        Me.CmdOperacion.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdOperacion.IconColor = System.Drawing.Color.White
        Me.CmdOperacion.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdOperacion.IconSize = 30
        Me.CmdOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdOperacion.Location = New System.Drawing.Point(174, 4)
        Me.CmdOperacion.Name = "CmdOperacion"
        Me.CmdOperacion.Size = New System.Drawing.Size(236, 34)
        Me.CmdOperacion.TabIndex = 24
        Me.CmdOperacion.Text = "..."
        Me.CmdOperacion.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdOperacion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdOperacion.UseVisualStyleBackColor = True
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
        Me.CmdBusoper.Location = New System.Drawing.Point(166, 5)
        Me.CmdBusoper.Name = "CmdBusoper"
        Me.CmdBusoper.Size = New System.Drawing.Size(31, 20)
        Me.CmdBusoper.TabIndex = 25
        Me.CmdBusoper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBusoper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdBusoper.UseVisualStyleBackColor = True
        '
        'TxtOperacion
        '
        Me.TxtOperacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOperacion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOperacion.Location = New System.Drawing.Point(104, 10)
        Me.TxtOperacion.MaxLength = 4
        Me.TxtOperacion.Name = "TxtOperacion"
        Me.TxtOperacion.Size = New System.Drawing.Size(49, 22)
        Me.TxtOperacion.TabIndex = 23
        Me.TxtOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.ItemSize = New System.Drawing.Size(93, 25)
        Me.TabControl1.Location = New System.Drawing.Point(0, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(723, 416)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LblTs)
        Me.TabPage1.Controls.Add(Me.dt_Tablas_basicas)
        Me.TabPage1.Controls.Add(Me.CmdGrabar)
        Me.TabPage1.Controls.Add(Me.TxtOperacion)
        Me.TabPage1.Controls.Add(Me.CmdBusoper)
        Me.TabPage1.Controls.Add(Me.CmbListaComp)
        Me.TabPage1.Controls.Add(Me.CmdOperacion)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(715, 383)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "SERIES COMPROBANTE"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Valorp)
        Me.TabPage2.Controls.Add(Me.TxtEti_imp)
        Me.TabPage2.Controls.Add(Me.TxtVal_imp)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.CmdActImp)
        Me.TabPage2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(715, 383)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "IMPUESTOS"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'CmdActImp
        '
        Me.CmdActImp.FlatAppearance.BorderSize = 0
        Me.CmdActImp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdActImp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdActImp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdActImp.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt
        Me.CmdActImp.IconColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.CmdActImp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdActImp.IconSize = 25
        Me.CmdActImp.Location = New System.Drawing.Point(512, 322)
        Me.CmdActImp.Name = "CmdActImp"
        Me.CmdActImp.Size = New System.Drawing.Size(87, 45)
        Me.CmdActImp.TabIndex = 80
        Me.CmdActImp.Text = "&ACTUALIZAR"
        Me.CmdActImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdActImp.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 31)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "IMPUESTO PORC(%) :"
        '
        'TxtVal_imp
        '
        Me.TxtVal_imp.BackColor = System.Drawing.Color.White
        Me.TxtVal_imp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVal_imp.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVal_imp.Location = New System.Drawing.Point(83, 20)
        Me.TxtVal_imp.MaxLength = 0
        Me.TxtVal_imp.Name = "TxtVal_imp"
        Me.TxtVal_imp.Size = New System.Drawing.Size(54, 22)
        Me.TxtVal_imp.TabIndex = 82
        Me.TxtVal_imp.Text = "0"
        Me.TxtVal_imp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtEti_imp
        '
        Me.TxtEti_imp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEti_imp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEti_imp.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEti_imp.Location = New System.Drawing.Point(152, 20)
        Me.TxtEti_imp.MaxLength = 0
        Me.TxtEti_imp.Name = "TxtEti_imp"
        Me.TxtEti_imp.Size = New System.Drawing.Size(53, 22)
        Me.TxtEti_imp.TabIndex = 83
        '
        'Valorp
        '
        Me.Valorp.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Valorp.Location = New System.Drawing.Point(100, 3)
        Me.Valorp.Name = "Valorp"
        Me.Valorp.Size = New System.Drawing.Size(51, 14)
        Me.Valorp.TabIndex = 84
        Me.Valorp.Text = "Valor %"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(157, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Etiqueta"
        '
        'FrmConfLocal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 458)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "FrmConfLocal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        CType(Me.dt_Tablas_basicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdOperacion As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdBusoper As FontAwesome.Sharp.IconButton
    Friend WithEvents TxtOperacion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbListaComp As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Lbl_local As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dt_Tablas_basicas As DataGridView
    Friend WithEvents CmdGrabar As FontAwesome.Sharp.IconButton
    Friend WithEvents LblTs As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents CmdActImp As FontAwesome.Sharp.IconButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Valorp As Label
    Friend WithEvents TxtEti_imp As TextBox
    Friend WithEvents TxtVal_imp As TextBox
End Class
