<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReporte
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
        Me.lbtitulo2 = New System.Windows.Forms.Label()
        Me.CmdRestaurar = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.CmdMin = New FontAwesome.Sharp.IconButton()
        Me.cr_reporte2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel_botonP = New System.Windows.Forms.Panel()
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel_botonP.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Gray
        Me.PanelSup.Controls.Add(Me.Panel_botonP)
        Me.PanelSup.Controls.Add(Me.lbtitulo2)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(800, 26)
        Me.PanelSup.TabIndex = 4
        '
        'lbtitulo2
        '
        Me.lbtitulo2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbtitulo2.AutoSize = True
        Me.lbtitulo2.BackColor = System.Drawing.Color.Gray
        Me.lbtitulo2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbtitulo2.ForeColor = System.Drawing.Color.White
        Me.lbtitulo2.Location = New System.Drawing.Point(12, 7)
        Me.lbtitulo2.Name = "lbtitulo2"
        Me.lbtitulo2.Size = New System.Drawing.Size(13, 13)
        Me.lbtitulo2.TabIndex = 15
        Me.lbtitulo2.Text = "'&'"
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
        Me.CmdRestaurar.Location = New System.Drawing.Point(35, 1)
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
        Me.CmdCerrar.Location = New System.Drawing.Point(64, 1)
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
        Me.CmdMin.Location = New System.Drawing.Point(6, 1)
        Me.CmdMin.Name = "CmdMin"
        Me.CmdMin.Size = New System.Drawing.Size(32, 25)
        Me.CmdMin.TabIndex = 9
        Me.CmdMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMin.UseVisualStyleBackColor = True
        '
        'cr_reporte2
        '
        Me.cr_reporte2.ActiveViewIndex = -1
        Me.cr_reporte2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cr_reporte2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cr_reporte2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cr_reporte2.Location = New System.Drawing.Point(0, 22)
        Me.cr_reporte2.Name = "cr_reporte2"
        Me.cr_reporte2.Size = New System.Drawing.Size(800, 425)
        Me.cr_reporte2.TabIndex = 5
        Me.cr_reporte2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelSup)
        Me.Panel1.Controls.Add(Me.cr_reporte2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 450)
        Me.Panel1.TabIndex = 6
        '
        'Panel_botonP
        '
        Me.Panel_botonP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_botonP.Controls.Add(Me.CmdCerrar)
        Me.Panel_botonP.Controls.Add(Me.CmdMin)
        Me.Panel_botonP.Controls.Add(Me.CmdRestaurar)
        Me.Panel_botonP.Location = New System.Drawing.Point(701, 0)
        Me.Panel_botonP.Name = "Panel_botonP"
        Me.Panel_botonP.Size = New System.Drawing.Size(99, 26)
        Me.Panel_botonP.TabIndex = 16
        '
        'ViewReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewReporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel_botonP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdRestaurar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmdMin As FontAwesome.Sharp.IconButton
    Friend WithEvents cr_reporte2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbtitulo2 As Label
    Friend WithEvents Panel_botonP As Panel
End Class
