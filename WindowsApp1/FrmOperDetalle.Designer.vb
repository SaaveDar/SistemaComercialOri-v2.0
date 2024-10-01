<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOperDetalle
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
        Me.PanelProductos = New System.Windows.Forms.Panel()
        ' Me.GridProductos = New WindowsApp1.GridPluss()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelProductos.SuspendLayout()
        '  CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelProductos
        '
        ' Me.PanelProductos.Controls.Add(Me.GridProductos)
        Me.PanelProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelProductos.Location = New System.Drawing.Point(0, 0)
        Me.PanelProductos.Name = "PanelProductos"
        Me.PanelProductos.Size = New System.Drawing.Size(1208, 450)
        Me.PanelProductos.TabIndex = 12
        '
        'GridProductos
        '
        'Me.GridProductos.AllowUserToAddRows = False
        'Me.GridProductos.AllowUserToDeleteRows = False
        'Me.GridProductos.AllowUserToOrderColumns = True
        'Me.GridProductos.AllowUserToResizeRows = False
        'Me.GridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        'Me.GridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        'Me.GridProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        'Me.GridProductos.Location = New System.Drawing.Point(28, 99)
        'Me.GridProductos.MultiSelect = False
        'Me.GridProductos.Name = "GridProductos"
        'Me.GridProductos.RowHeadersVisible = False
        'Me.GridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        'Me.GridProductos.Size = New System.Drawing.Size(575, 175)
        'Me.GridProductos.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "PROD1"
        Me.Column1.Name = "Column1"
        '
        'FrmOperDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1208, 450)
        Me.Controls.Add(Me.PanelProductos)
        Me.Name = "FrmOperDetalle"
        Me.Text = "yyy"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelProductos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelProductos As Panel
    'Friend WithEvents GridProductos As WindowsApp1.
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class




