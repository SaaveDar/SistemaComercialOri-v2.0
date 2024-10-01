<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportes
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
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.CmbBuscar = New FontAwesome.Sharp.IconButton()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtFechas_Emis = New System.Windows.Forms.DateTimePicker()
        Me.TxtFechas_Proc = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Gray
        Me.PanelSup.Controls.Add(Me.CmdRestaurar)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Controls.Add(Me.CmdMin)
        Me.PanelSup.Controls.Add(Me.CmbBuscar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(1237, 26)
        Me.PanelSup.TabIndex = 3
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(1170, -3)
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
        Me.CmdCerrar.Location = New System.Drawing.Point(1199, -3)
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
        Me.CmdMin.Location = New System.Drawing.Point(1141, -3)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'CmbBuscar
        '
        Me.CmbBuscar.FlatAppearance.BorderSize = 0
        Me.CmbBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBuscar.ForeColor = System.Drawing.Color.White
        Me.CmbBuscar.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmbBuscar.IconColor = System.Drawing.Color.White
        Me.CmbBuscar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmbBuscar.IconSize = 25
        Me.CmbBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.Location = New System.Drawing.Point(412, 2)
        Me.CmbBuscar.Name = "CmbBuscar"
        Me.CmbBuscar.Size = New System.Drawing.Size(38, 23)
        Me.CmbBuscar.TabIndex = 6
        Me.CmbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmbBuscar.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.Gray
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.Location = New System.Drawing.Point(0, 26)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(158, 467)
        Me.TreeView1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TxtFechas_Emis)
        Me.Panel1.Controls.Add(Me.TxtFechas_Proc)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(158, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1079, 138)
        Me.Panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Nombre de Usuario"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(164, 170)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1061, 290)
        Me.Panel2.TabIndex = 6
        '
        'TxtFechas_Emis
        '
        Me.TxtFechas_Emis.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Emis.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Emis.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechas_Emis.Location = New System.Drawing.Point(146, 21)
        Me.TxtFechas_Emis.Name = "TxtFechas_Emis"
        Me.TxtFechas_Emis.Size = New System.Drawing.Size(106, 22)
        Me.TxtFechas_Emis.TabIndex = 34
        '
        'TxtFechas_Proc
        '
        Me.TxtFechas_Proc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtFechas_Proc.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Proc.Enabled = False
        Me.TxtFechas_Proc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechas_Proc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechas_Proc.Location = New System.Drawing.Point(22, 21)
        Me.TxtFechas_Proc.Name = "TxtFechas_Proc"
        Me.TxtFechas_Proc.Size = New System.Drawing.Size(106, 22)
        Me.TxtFechas_Proc.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(353, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "FEC.PROCESO"
        '
        'FrmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 493)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.PanelSup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportes"
        Me.PanelSup.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents CmbBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtFechas_Emis As DateTimePicker
    Friend WithEvents TxtFechas_Proc As DateTimePicker
    Friend WithEvents Label5 As Label
End Class
