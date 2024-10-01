Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text.RegularExpressions

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLoteOper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLoteOper))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.TxtCantidadPres = New System.Windows.Forms.TextBox()
        Me.TxtCantidadSol = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdAceptar = New FontAwesome.Sharp.IconButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.LblProducto = New System.Windows.Forms.Label()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.CmbBuscar = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblError = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FaltaDatos = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GridLoteProd = New WindowsApp1.GridLoteProductosPlus()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.flag_ok = New System.Windows.Forms.Label()
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.GridLoteProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelSup.Controls.Add(Me.flag_ok)
        Me.PanelSup.Controls.Add(Me.TxtCantidadPres)
        Me.PanelSup.Controls.Add(Me.TxtCantidadSol)
        Me.PanelSup.Controls.Add(Me.Label1)
        Me.PanelSup.Controls.Add(Me.CmdAceptar)
        Me.PanelSup.Controls.Add(Me.CheckBox1)
        Me.PanelSup.Controls.Add(Me.LblProducto)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(827, 67)
        Me.PanelSup.TabIndex = 3
        '
        'TxtCantidadPres
        '
        Me.TxtCantidadPres.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCantidadPres.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadPres.Location = New System.Drawing.Point(152, 43)
        Me.TxtCantidadPres.Name = "TxtCantidadPres"
        Me.TxtCantidadPres.Size = New System.Drawing.Size(99, 22)
        Me.TxtCantidadPres.TabIndex = 38
        Me.TxtCantidadPres.Text = "CAJ"
        Me.TxtCantidadPres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCantidadSol
        '
        Me.TxtCantidadSol.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCantidadSol.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadSol.Location = New System.Drawing.Point(80, 43)
        Me.TxtCantidadSol.Name = "TxtCantidadSol"
        Me.TxtCantidadSol.Size = New System.Drawing.Size(66, 22)
        Me.TxtCantidadSol.TabIndex = 37
        Me.TxtCantidadSol.Text = "715"
        Me.TxtCantidadSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 27)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "CANTIDAD SOLICITADA :"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.FlatAppearance.BorderSize = 0
        Me.CmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAceptar.ForeColor = System.Drawing.Color.White
        Me.CmdAceptar.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.CmdAceptar.IconColor = System.Drawing.Color.White
        Me.CmdAceptar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdAceptar.IconSize = 25
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(451, 38)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(113, 27)
        Me.CmdAceptar.TabIndex = 35
        Me.CmdAceptar.Text = "&ACEPTAR"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(270, 44)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(142, 17)
        Me.CheckBox1.TabIndex = 34
        Me.CheckBox1.Text = "VER LOTES EN CERO(0)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'LblProducto
        '
        Me.LblProducto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProducto.ForeColor = System.Drawing.Color.White
        Me.LblProducto.Location = New System.Drawing.Point(4, 1)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(524, 34)
        Me.LblProducto.TabIndex = 11
        Me.LblProducto.Text = "AMOXICILINA 125MG/5ML  PLV. X 45 ML - BAYER "
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
        Me.CmdCerrar.Location = New System.Drawing.Point(789, 1)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 34)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(25, 81)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(46, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "SALD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(77, 81)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "INGR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Location = New System.Drawing.Point(141, 59)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(66, 20)
        Me.TextBox2.TabIndex = 16
        Me.TextBox2.Text = "2"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(141, 81)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 20)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.Text = "715"
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.White
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Check
        Me.IconButton1.IconColor = System.Drawing.Color.White
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 25
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.Location = New System.Drawing.Point(77, 19)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(79, 27)
        Me.IconButton1.TabIndex = 12
        Me.IconButton1.Text = "clear y reg"
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
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
        Me.CmbBuscar.Location = New System.Drawing.Point(33, 22)
        Me.CmbBuscar.Name = "CmbBuscar"
        Me.CmbBuscar.Size = New System.Drawing.Size(38, 27)
        Me.CmbBuscar.TabIndex = 6
        Me.CmbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmbBuscar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.LblError)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 442)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(827, 30)
        Me.Panel1.TabIndex = 15
        '
        'LblError
        '
        Me.LblError.AutoSize = True
        Me.LblError.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblError.Location = New System.Drawing.Point(12, 8)
        Me.LblError.Name = "LblError"
        Me.LblError.Size = New System.Drawing.Size(0, 13)
        Me.LblError.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 402)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(827, 40)
        Me.Panel2.TabIndex = 16
        Me.Panel2.Visible = False
        '
        'FaltaDatos
        '
        Me.FaltaDatos.ContainerControl = Me
        Me.FaltaDatos.Icon = CType(resources.GetObject("FaltaDatos.Icon"), System.Drawing.Icon)
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.CmbBuscar)
        Me.Panel3.Controls.Add(Me.IconButton1)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Location = New System.Drawing.Point(392, 138)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(219, 127)
        Me.Panel3.TabIndex = 17
        Me.Panel3.Visible = False
        '
        'GridLoteProd
        '
        Me.GridLoteProd.AllowUserToAddRows = False
        Me.GridLoteProd.AllowUserToDeleteRows = False
        Me.GridLoteProd.AllowUserToOrderColumns = True
        Me.GridLoteProd.AllowUserToResizeRows = False
        Me.GridLoteProd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridLoteProd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridLoteProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridLoteProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridLoteProd.DefaultCellStyle = DataGridViewCellStyle1
        Me.GridLoteProd.Location = New System.Drawing.Point(39, 138)
        Me.GridLoteProd.MultiSelect = False
        Me.GridLoteProd.Name = "GridLoteProd"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridLoteProd.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridLoteProd.RowHeadersVisible = False
        Me.GridLoteProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridLoteProd.Size = New System.Drawing.Size(172, 128)
        Me.GridLoteProd.TabIndex = 14
        '
        'Column1
        '
        Me.Column1.HeaderText = "LOTES"
        Me.Column1.Name = "Column1"
        '
        'flag_ok
        '
        Me.flag_ok.AutoSize = True
        Me.flag_ok.Location = New System.Drawing.Point(698, 43)
        Me.flag_ok.Name = "flag_ok"
        Me.flag_ok.Size = New System.Drawing.Size(42, 13)
        Me.flag_ok.TabIndex = 39
        Me.flag_ok.Text = "flag_ok"
        Me.flag_ok.Visible = False
        '
        'FrmLoteOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GridLoteProd)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "FrmLoteOper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.PanelSup.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FaltaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.GridLoteProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents CmbBuscar As FontAwesome.Sharp.IconButton
    Friend WithEvents LblProducto As Label
    Friend WithEvents GridLoteProd As GridLoteProductosPlus
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CmdAceptar As FontAwesome.Sharp.IconButton
    Friend WithEvents FaltaDatos As ErrorProvider
    Friend WithEvents LblError As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TxtCantidadPres As TextBox
    Friend WithEvents TxtCantidadSol As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents flag_ok As Label
End Class

Public Class GridLoteProductosPlus
    Inherits Windows.Forms.DataGridView

    Protected Overrides Function ProcessDialogKey(ByVal KeyData As System.Windows.Forms.Keys) As Boolean
        'dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString().ToUpper()
        If Me.CurrentCell Is Nothing Then Return True
        If KeyData = Keys.Escape Then
            ' Stop
            '  Dim vo As String = Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value
            'Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value ' Guardar el valor original de la celda antes
            Me.CancelEdit() ' Cancelar la edición y descartar los cambios en la celda actual
            Return True ' Indicar que se ha procesado la tecla ESC
        End If
        If KeyData = Keys.Enter Then

            If Strings.Right(Me.CurrentCell.OwningColumn.HeaderText, 1) = "*" Then ' cUALQUIER vALOR
                'If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
                If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                    ' Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
                    Me.Rows.Add()
                    Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells("codigo")
                    'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."
                    Me.BeginEdit(True)

                    ' FrmOperaciones.GridProductos_PrimeraFila()
                    Return True
                Else
                    SendKeys.Send("{DOWN}")
                    Return True

                End If


            End If
            If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "F" Then
                    Dim cell As DataGridViewCell = Me.CurrentCell
                    Dim currentValuetext As String
                    currentValuetext = CurrentCell.EditedFormattedValue
                    If currentValuetext.Length = 5 Or currentValuetext.Length = 7 Then
                        Dim parts() As String = currentValuetext.Split("/"c) 'Dividir el valor en dos partes: mes y año
                        If parts.Count = 2 Then
                        Else
                            Return True
                        End If
                        If Integer.Parse(parts(0)) >= 1 And Integer.Parse(parts(0)) <= 12 Then
                        Else

                            Return True
                        End If
                        If Integer.Parse(parts(1)) >= 1900 And Integer.Parse(parts(1)) <= 3000 Then
                        ElseIf Integer.Parse(parts(1)) >= 10 And Integer.Parse(parts(1)) <= 99 Then
                            parts(1) = Val(parts(1)) + 2000
                        Else
                            Return True
                        End If
                        'Dim parts() As String = currentValuetext.Split("/"c) 'Dividir el valor en dos partes: mes y año
                        Dim month As Integer = Integer.Parse(parts(0)) 'Obtener el mes como un entero
                        Dim year As Integer = Integer.Parse(parts(1))  'Obtener el año como un entero

                        Dim lastDay As Integer = DateTime.DaysInMonth(year, month) 'Obtener el último día del mes correspondiente

                        Dim fechaCompleta As New DateTime(year, month, lastDay) 'Crear un objeto DateTime con el último día del mes
                        Dim formattedDate As String = fechaCompleta.ToString("dd/MM/yyyy") 'Convertir la fecha en formato "dd/MM/yyyy"

                        cell.Value = formattedDate 'Asignar el valor a la celda del DataGridView
                    Else
                        Dim inputString As String = currentValuetext
                        Dim formats As String() = {"dd/MM/yyyy", "dd/MM/yy"}
                        Dim parsedDate As DateTime
                        If DateTime.TryParseExact(inputString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
                            ' La cadena tiene formato de fecha válido
                        Else
                            Return True
                        End If
                    End If
                End If


            'If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "F" Then ' cUALQUIER vALOR
            '    Dim currentCell As DataGridViewCell = Me.CurrentCell
            '    Dim value As Object = currentCell.EditedFormattedValue

            '    'Realizar la acción para reemplazar el texto ingresado por el usuario
            '    currentCell.Value = "01/01/1900"

            '    '    Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
            '    '    If Not Regex.IsMatch(currentValuetext, "^\d{2}/\d{4}$") Then

            '    '        Dim mesAnio As DateTime = DateTime.ParseExact(currentValuetext, "MM/yy", CultureInfo.InvariantCulture)
            '    '        Dim fechaCompleta As DateTime = New DateTime(mesAnio.Year, mesAnio.Month, DateTime.DaysInMonth(mesAnio.Year, mesAnio.Month))
            '    '        Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.OwningColumn.Name).Value = fechaCompleta.ToString("dd/MM/yyyy")
            '    '        Me.CurrentCell.Value = fechaCompleta.ToString("dd/MM/yyyy")
            '    '        'Me.CurrentCell.EditedFormattedValue = fechaCompleta.ToString("dd/MM/yyyy")

            '    SendKeys.Send(Chr(Keys.Tab))
            '    Return True

            '    '    End If
            'End If
            If Me.CurrentCell.OwningColumn.Name = "codigo" And Val(Me.AccessibleName) <> 0 Then
                Dim currentValuetext As String
                currentValuetext = CurrentCell.EditedFormattedValue


                Dim columnaCodigo As DataGridViewColumn = Me.Columns("codigo")
                For Each fila As DataGridViewRow In Me.Rows
                    ' Evitar validar la fila actual en edición (para permitir cambios del mismo valor)
                    If fila.Index <> Me.CurrentCell.RowIndex Then
                        Dim valorExistente As Object = fila.Cells(columnaCodigo.Index).Value

                        ' Comparar el valor existente con el nuevo valor ingresado
                        If currentValuetext = fila.Cells("codigo").Value Then
                            ' Mostrar mensaje de error
                            Dim Result As String = MensajesBox.Show("Codigo de Lote, Existe en la lista de Productos" & Chr(13) & "No se puede Duplicar ...",
                                               "Lote de Productos.")
                            ' Cancelar la edición de la celda
                            Return True
                            Exit For ' Salir del bucle si se encuentra una coincidencia
                        End If
                    End If
                Next



                Dim wsid_prod_mae As Integer = Val(Me.AccessibleName)
                ' bUSQUEDA dIRECTO APOR CODIGO DE PRODUCTO
                Dim sql As String = "exec [sp_buscaLoteProducto] " & lk_NegocioActivo.id_Negocio & "," & wsid_prod_mae & ", '" & currentValuetext & "'"
                Dim command As New SqlCommand(sql, lk_connection_cuenta)
                Dim adapter As New SqlDataAdapter(command)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells("stock")

                    Me.Rows(Me.CurrentCell.RowIndex).Cells("fecvcto").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("stock").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("estado").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_loteser").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("estado").Value = "1"
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("codigo_ok").Value = "|" 'Sin dato para agregar uno nuev  - dato de control cuando es correcto el codigo
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("codigo").Value = currentValuetext
                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If

                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_loteser").Value = tabla.Rows(0).Item("id_loteser").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("fecvcto").Value = Format(tabla(0)("fechavcto"), "dd/MM/yyyy")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab").Value = Format(tabla(0)("fechareg"), "dd/MM/yyyy")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("estado").Value = tabla.Rows(0).Item("estado").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("stock").Value = ""
                Me.Rows(Me.CurrentCell.RowIndex).Cells("codigo_ok").Value = currentValuetext 'dato de control cuando es correcto el codigo


                'Dim Loc_lotes() As DataRow = datos_sql_resul.Select("codigo ='" & currentValuetext & "'")
                'If Loc_lotes.Length = 0 Then
                '    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells("stock")
                '    If Me.Rows(Me.CurrentCell.RowIndex).Cells("fecvcto").Value = "" Then
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("fecvcto").Value = ""
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("stock").Value = ""
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("estado").Value = ""
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab").Value = ""
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("id_loteser").Value = ""
                '    End If
                '    SendKeys.Send(Chr(Keys.Tab))
                '    Return True
                'End If
                'Me.Rows(Me.CurrentCell.RowIndex).Cells("fecvcto").Value = Format(Loc_lotes(0)("fechavcto"), "dd/MM/yyyy")
                'Me.Rows(Me.CurrentCell.RowIndex).Cells("stock").Value = Loc_lotes(0)("saldo")
                'Me.Rows(Me.CurrentCell.RowIndex).Cells("estado").Value = Loc_lotes(0)("estado")
                'Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab").Value = Format(Loc_lotes(0)("fechareg"), "dd/MM/yyyy")
                'Me.Rows(Me.CurrentCell.RowIndex).Cells("id_loteser").Value = Loc_lotes(0)("id_loteser")
                If Me.Tag = "INGRESO" Then
                    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells("ingreso")
                ElseIf Me.Tag = "SALIDA" Then
                    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells("salida")
                End If
                Me.BeginEdit(True)
                Return True
            End If
            If Me.CurrentCell.OwningColumn.Name = "ingreso" Then
                Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab")
                If Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab").Value = "" Then
                    Me.BeginEdit(True)
                End If
                Return True
            End If

            If Me.CurrentCell.OwningColumn.Name = "salida" Then
                Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab")
                If Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab").Value = "" Then
                    Me.BeginEdit(True)
                End If
                Return True
            End If

            If Me.CurrentCell.OwningColumn.Name = "preciobase" Then
                    Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'preciobase'  ")
                    Dim colum_destino As String = ""
                    If Loc_Salto_Grid.Length = 0 Then
                        SendKeys.Send(Chr(Keys.Tab))
                        Return True
                    End If

                    If Loc_Salto_Grid(0)("es_salto") = 1 Then
                        If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                            Me.Rows.Add()
                            colum_destino = Loc_Salto_Grid(0)("columna_des")
                        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells(colum_destino)
                        Me.BeginEdit(True)
                        Else
                            colum_destino = Loc_Salto_Grid(0)("columna_ori")
                        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells(colum_destino)
                    End If

                    Else
                        If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                            colum_destino = Loc_Salto_Grid(0)("columna_des")
                            Me.BeginEdit(True)
                        Else
                            colum_destino = Loc_Salto_Grid(0)("columna_ori")
                        Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells(colum_destino)
                    End If

                    End If


                    Return True
                End If
                If Me.CurrentCell.OwningColumn.Name = "cantidad" Then
                    Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'cantidad'  ")
                    Dim colum_destino As String = ""
                    If Loc_Salto_Grid.Length = 0 Then
                        SendKeys.Send(Chr(Keys.Tab))
                        Return True
                    End If

                    If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                        colum_destino = Loc_Salto_Grid(0)("columna_des")
                    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells(colum_destino)
                    Me.BeginEdit(True)
                    Else
                        colum_destino = Loc_Salto_Grid(0)("columna_ori")
                    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex).Cells(colum_destino)
                End If

                    ' FrmOperaciones.GridProductos_PrimeraFila()
                    Return True
                End If
            If Me.CurrentCell.OwningColumn.Name = "codigoAAAA   " And Val(Me.AccessibleName) <> 0 Then
                Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
                Dim wsid_prod_mae As Integer = Val(Me.AccessibleName)
                ' bUSQUEDA dIRECTO APOR CODIGO DE PRODUCTO
                Dim sql As String = "exec [sp_buscaLoteProducto] " & lk_NegocioActivo.id_Negocio & "," & wsid_prod_mae & ", '" & currentValue & "'"
                Dim command As New SqlCommand(sql, lk_connection_cuenta)
                Dim adapter As New SqlDataAdapter(command)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    Return True
                End If

                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_loteser").Value = tabla.Rows(0).Item("id_loteser").ToString
                Me.Rows(Me.CurrentCell.RowIndex).Cells("fecvcto").Value = Format(tabla(0)("fechavcto"), "dd/MM/yyyy")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("fecfab").Value = Format(tabla(0)("fecfab"), "dd/MM/yyyy")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("estado").Value = tabla.Rows(0).Item("estado").ToString


                '    'Dim wpres As String = selectedRow.Cells("Unidades").Value.ToString()
                '    Dim wpres As String = tabla.Rows(0).Item("Unidades").ToString
                '    Dim valores As List(Of Tuple(Of String, Integer, Integer)) = ConvertirCadena(wpres)
                '    Dim comboCell As DataGridViewComboBoxCell
                '    'comboCell = CType(GridProductos.Rows(e.RowIndex).Cells("present"), DataGridViewComboBoxCell)
                '    comboCell = CType(Me.Rows(Me.CurrentCell.RowIndex).Cells("present"), DataGridViewComboBoxCell)

                '    comboCell.Items.Clear()
                '    Dim valoresDict As New Dictionary(Of Integer, Tuple(Of String, Integer, Integer)) ' Diccionario para almacenar los valores con su índice
                '    For i As Integer = 0 To valores.Count - 1
                '        comboCell.Items.Add(valores(i).Item1)
                '        valoresDict.Add(i, valores(i)) '
                '    Next
                '    comboCell.Tag = valoresDict

                '    If valores.Count > 0 Then
                '        comboCell.Value = valores(0).Item1
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("id_pres").Value = valores(0).Item3
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("equiv").Value = valores(0).Item2
                '        Me.Rows(Me.CurrentCell.RowIndex).Cells("Unidades").Value = wpres ' Valor original de la bd
                '    End If

                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("codigo").Value = tabla.Rows(0).Item("Codigo").ToString
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip").Value = tabla.Rows(0).Item("NombreProducto").ToString
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("masdetalle").Value = "..." 'tabla.Rows(0).Item("Codigo").ToString
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_prod_mae").Value = tabla.Rows(0).Item("id_prod_mae").ToString
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("cantidad").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("almacen").Value = lk_AlmacenActivo.codigo
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("lote").Value = tabla.Rows(0).Item("Lote_def").ToString
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_almacen").Value = lk_AlmacenActivo.id_almacen
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("preciobase").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("des1").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("des2").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("valor").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("impto").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("valor").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("subtotal").Value = 0
                '    Me.Rows(Me.CurrentCell.RowIndex).Cells("Unidades").Value = tabla.Rows(0).Item("Unidades").ToString

                '    'Identifica el siguiente salto 
                '    Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'codigo'  ")
                '    Dim colum_destino As String = ""
                '    If Loc_Salto_Grid.Length = 0 Then
                '        SendKeys.Send(Chr(Keys.Tab))
                '        Return True
                '    End If

                '    colum_destino = Loc_Salto_Grid(0)("columna_des")

                '    Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
                '    Me.BeginEdit(True)

                '    ' FrmOperaciones.GridProductos_PrimeraFila()
                Return True
                '    'SendKeys.Send(Chr(Keys.Tab))
                '    'Return True
            End If

            SendKeys.Send(Chr(Keys.Tab))
                Return True


                'If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
                '    ' Verificar si se ingresó un número en la primera columna antes de agregar una nueva fila
                '    Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
                '    FrmOperDetalle.GridProductos_PrimeraFila()
                '    Return True
                'End If

                'SendKeys.Send(Chr(Keys.Tab))
                'Return True

            End If


            'If KeyData = Keys.Tab Then

            '    Exit Function
            'End If


            If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "N" Then ' validar sólo para números decimales
            If KeyData >= Keys.A And KeyData <= Keys.Z Then
                Return True
            End If
            If KeyData = Keys.Add Or KeyData = Keys.Subtract Or KeyData = Keys.Multiply Or KeyData = Keys.Divide Or KeyData = Keys.OemQuestion Then
                Return True
            End If
            ' Obtener el valor actual de la celda
            Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
            Dim firstDecimalPointIndex As Integer = currentValue.IndexOf(".")
            If firstDecimalPointIndex >= 0 And KeyData = Keys.Decimal Then
                Return True
            End If
            Dim wgid As Integer = Val(Mid(Me.CurrentCell.OwningColumn.Tag, 2, Strings.Len(Me.CurrentCell.OwningColumn.Tag)))
            If wgid <> 0 Then
                Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValuetext.Length() >= wgid + 1 Then
                    Return True
                End If
            End If
        End If

        If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "E" Then ' validar sólo para números decimales
            If KeyData >= Keys.A And KeyData <= Keys.Z Then
                Return True
            End If
            If KeyData = Keys.Add Or KeyData = Keys.Subtract Or KeyData = Keys.Multiply Or KeyData = Keys.Divide Or KeyData = Keys.OemQuestion Or KeyData = Keys.Decimal Then
                Return True
            End If
            Dim wgid As Integer = Val(Mid(Me.CurrentCell.OwningColumn.Tag, 2, Strings.Len(Me.CurrentCell.OwningColumn.Tag)))
            If wgid <> 0 Then
                Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValuetext.Length() >= wgid + 1 Then
                    Return True
                End If
            End If

        End If
        If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "A" Then ' cUALQUIER vALOR
            Dim wgid As Integer = Val(Mid(Me.CurrentCell.OwningColumn.Tag, 2, Strings.Len(Me.CurrentCell.OwningColumn.Tag)))
            If wgid <> 0 Then
                Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValuetext.Length() >= wgid + 1 Then
                    Return True
                End If

            End If
        End If

        If Me.Rows(Me.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
            Return True
            'If Me.CurrentCell.OwningColumn.Name = "lote" Or Me.CurrentCell.OwningColumn.Name = "codigo" Or Me.CurrentCell.OwningColumn.Name = "cantidad" Or Me.CurrentCell.OwningColumn.Name = "present" Then
            ' Return True
            ' End If
        End If

        'If Strings.Right(Me.CurrentCell.OwningColumn.HeaderText, 1) = "*" Then ' cUALQUIER vALOR
        '    If KeyData = Keys.Enter Then
        '        'If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
        '        ' Verificar si se ingresó un número en la primera columna antes de agregar una nueva fila
        '        Dim valor As String = Me.CurrentCell.EditedFormattedValue.ToString()
        '            'If Not IsNumeric(valor) Then   
        '            '    'MessageBox.Show("Ingrese solo números en la primera columna.")
        '            '    Return True ' Evita que se procese la tecla Enter
        '            'End If
        '            frmoperdetalle.GridProductos_PrimeraFila()
        '            Return True
        '        'End If

        '        'SendKeys.Send(Chr(Keys.Tab))
        '        'Return True

        '    End If

        'End If



        Return MyBase.ProcessDialogKey(KeyData)




        ''        If Not IsNumeric(wtecla.KeyChar()) = True And wtecla.KeyChar <> ChrW(Keys.Back) Then
        ''Dim car As String, Longt As Integer
        ''car = Chr$(tecla)
        ''car = UCase$(Chr$(tecla))
        ''tecla = Asc(car)
        ''If car < "0" Or car > "9" Then
        ''    If tecla <> 8 And tecla <> 13 Then
        ''        tecla = 0
        ''        Beep()
        ''    End If
        ''End If

        ''If KeyData < Keys.D0 Or KeyData > Keys.D9 Then
        '' Return True
        '' End If

        'If KeyData = Keys.Enter Then

        '    If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
        '        ModeloBase3.NuevaFila()
        '        Return True
        '    End If'
        '    SendKeys.Send(Chr(Keys.Tab))
        '    Return True
        'Else
        '    ' AONAS DE VLAIDACION DE CELDAS

        '    If Me.CurrentCell.ColumnIndex = 1 Then

        '        'If KeyData <> Keys.Back AndAlso KeyData <> Keys.Delete AndAlso KeyData < Keys.D0 OrElse KeyData > Keys.D9 Then
        '        If KeyData = Keys.D0 Then

        '        Else
        '            ' SendKeys.Send(KeyData)
        '            'If KeyData = Keys.Enter Then SendKeys.Send(Chr(Keys.Tab))
        '            'Return MyBase.ProcessDialogKey(KeyData)
        '            '   Return True
        '        End If
        '        '        End If
        '        'End If
        '    End If
        '    Return MyBase.ProcessDialogKey(KeyData)
        'End If

        'ORIGINAL FUNONA 

        'If KeyData = Keys.Enter Then
        '    If Me.CurrentCell.ColumnIndex = Me.ColumnCount - 1 Then
        '        ModeloBase3.NuevaFila()
        '        Return True
        '    End If
        '    SendKeys.Send(Chr(Keys.Tab))
        '    Return True
        'Else
        '    Return MyBase.ProcessDialogKey(KeyData)
        'End If


    End Function
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)


        ' RUTINA ORIGINAL FUNCIONAL
        If e.KeyData = Keys.Enter Then
            SendKeys.Send(Chr(Keys.Tab))
        Else
            MyBase.OnKeyDown(e)
        End If
    End Sub


End Class