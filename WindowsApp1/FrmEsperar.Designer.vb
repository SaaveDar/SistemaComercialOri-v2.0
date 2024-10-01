<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEsperar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEsperar))
        Me.MuestraGif = New System.Windows.Forms.PictureBox()
        Me.cargagif = New System.ComponentModel.BackgroundWorker()
        CType(Me.MuestraGif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MuestraGif
        '
        Me.MuestraGif.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.MuestraGif.BackColor = System.Drawing.Color.Black
        Me.MuestraGif.Image = CType(resources.GetObject("MuestraGif.Image"), System.Drawing.Image)
        Me.MuestraGif.Location = New System.Drawing.Point(181, 174)
        Me.MuestraGif.Name = "MuestraGif"
        Me.MuestraGif.Size = New System.Drawing.Size(48, 48)
        Me.MuestraGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MuestraGif.TabIndex = 0
        Me.MuestraGif.TabStop = False
        '
        'cargagif
        '
        '
        'FrmEsperar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(461, 407)
        Me.ControlBox = False
        Me.Controls.Add(Me.MuestraGif)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmEsperar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.MuestraGif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents MuestraGif As PictureBox
    Friend WithEvents cargagif As System.ComponentModel.BackgroundWorker
End Class
