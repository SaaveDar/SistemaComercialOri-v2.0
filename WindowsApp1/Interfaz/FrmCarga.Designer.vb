<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCarga))
        Me.LogoMuestra = New System.Windows.Forms.PictureBox()
        Me.LogoSolicdo = New System.Windows.Forms.PictureBox()
        Me.Gifcarga = New System.Windows.Forms.PictureBox()
        CType(Me.LogoMuestra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoSolicdo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gifcarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoMuestra
        '
        Me.LogoMuestra.Image = CType(resources.GetObject("LogoMuestra.Image"), System.Drawing.Image)
        Me.LogoMuestra.Location = New System.Drawing.Point(166, 136)
        Me.LogoMuestra.Name = "LogoMuestra"
        Me.LogoMuestra.Size = New System.Drawing.Size(190, 147)
        Me.LogoMuestra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoMuestra.TabIndex = 1
        Me.LogoMuestra.TabStop = False
        '
        'LogoSolicdo
        '
        Me.LogoSolicdo.Image = CType(resources.GetObject("LogoSolicdo.Image"), System.Drawing.Image)
        Me.LogoSolicdo.Location = New System.Drawing.Point(200, 151)
        Me.LogoSolicdo.Name = "LogoSolicdo"
        Me.LogoSolicdo.Size = New System.Drawing.Size(137, 123)
        Me.LogoSolicdo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoSolicdo.TabIndex = 2
        Me.LogoSolicdo.TabStop = False
        Me.LogoSolicdo.Visible = False
        '
        'Gifcarga
        '
        Me.Gifcarga.Location = New System.Drawing.Point(418, 217)
        Me.Gifcarga.Name = "Gifcarga"
        Me.Gifcarga.Size = New System.Drawing.Size(106, 66)
        Me.Gifcarga.TabIndex = 3
        Me.Gifcarga.TabStop = False
        Me.Gifcarga.Visible = False
        '
        'FrmCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(587, 458)
        Me.Controls.Add(Me.Gifcarga)
        Me.Controls.Add(Me.LogoSolicdo)
        Me.Controls.Add(Me.LogoMuestra)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCarga"
        CType(Me.LogoMuestra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoSolicdo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gifcarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents LogoMuestra As PictureBox
    Public WithEvents LogoSolicdo As PictureBox
    Friend WithEvents Gifcarga As PictureBox
End Class
