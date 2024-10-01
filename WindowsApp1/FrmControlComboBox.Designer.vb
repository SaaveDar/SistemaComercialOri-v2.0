<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmControlComboBox
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DGTabla = New System.Windows.Forms.DataGridView()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelDetalle = New System.Windows.Forms.Panel()
        CType(Me.DGTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(539, 21)
        Me.TextBox1.TabIndex = 0
        '
        'DGTabla
        '
        Me.DGTabla.AllowUserToAddRows = False
        Me.DGTabla.AllowUserToDeleteRows = False
        Me.DGTabla.AllowUserToResizeRows = False
        Me.DGTabla.BackgroundColor = System.Drawing.Color.White
        Me.DGTabla.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGTabla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGTabla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTabla.ColumnHeadersVisible = False
        Me.DGTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Id})
        Me.DGTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGTabla.GridColor = System.Drawing.Color.White
        Me.DGTabla.Location = New System.Drawing.Point(0, 0)
        Me.DGTabla.Name = "DGTabla"
        Me.DGTabla.ReadOnly = True
        Me.DGTabla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGTabla.RowHeadersVisible = False
        Me.DGTabla.RowTemplate.Height = 25
        Me.DGTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGTabla.Size = New System.Drawing.Size(400, 406)
        Me.DGTabla.TabIndex = 2
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 300
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 10
        '
        'PanelDetalle
        '
        Me.PanelDetalle.Controls.Add(Me.DGTabla)
        Me.PanelDetalle.Location = New System.Drawing.Point(21, 28)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(400, 406)
        Me.PanelDetalle.TabIndex = 3
        '
        'FrmControlComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 499)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelDetalle)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "FrmControlComboBox"
        CType(Me.DGTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DGTabla As DataGridView
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents PanelDetalle As Panel
End Class
