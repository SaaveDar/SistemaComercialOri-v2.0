Imports System.Data.SqlClient
Imports System.Globalization

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOperFinanzas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelSup = New System.Windows.Forms.Panel()
        Me.CmdTodoEFE = New System.Windows.Forms.Button()
        Me.lblMontoAplicar = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblEstadoCaja = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdCajas = New FontAwesome.Sharp.IconButton()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CmdMonedaComp = New FontAwesome.Sharp.IconButton()
        Me.CmdCerrar = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblDif = New System.Windows.Forms.Label()
        Me.CmdAceptar = New FontAwesome.Sharp.IconButton()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.LblMoneda = New System.Windows.Forms.Label()
        Me.LblEtiqueta = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckNC = New System.Windows.Forms.CheckBox()
        Me.dg_cuentasn = New WindowsApp1.GridFinanzas_Plus()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_finanzas = New WindowsApp1.GridFinanzas_Plus()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelSup.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dg_cuentasn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_finanzas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSup
        '
        Me.PanelSup.BackColor = System.Drawing.Color.Gray
        Me.PanelSup.Controls.Add(Me.CmdTodoEFE)
        Me.PanelSup.Controls.Add(Me.lblMontoAplicar)
        Me.PanelSup.Controls.Add(Me.Label4)
        Me.PanelSup.Controls.Add(Me.Label1)
        Me.PanelSup.Controls.Add(Me.LblEstadoCaja)
        Me.PanelSup.Controls.Add(Me.Label3)
        Me.PanelSup.Controls.Add(Me.Label2)
        Me.PanelSup.Controls.Add(Me.CmdCajas)
        Me.PanelSup.Controls.Add(Me.Label23)
        Me.PanelSup.Controls.Add(Me.CmdMonedaComp)
        Me.PanelSup.Controls.Add(Me.CmdCerrar)
        Me.PanelSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelSup.Name = "PanelSup"
        Me.PanelSup.Size = New System.Drawing.Size(811, 102)
        Me.PanelSup.TabIndex = 3
        '
        'CmdTodoEFE
        '
        Me.CmdTodoEFE.FlatAppearance.BorderSize = 0
        Me.CmdTodoEFE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdTodoEFE.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdTodoEFE.ForeColor = System.Drawing.Color.Gainsboro
        Me.CmdTodoEFE.Location = New System.Drawing.Point(389, 81)
        Me.CmdTodoEFE.Name = "CmdTodoEFE"
        Me.CmdTodoEFE.Size = New System.Drawing.Size(141, 19)
        Me.CmdTodoEFE.TabIndex = 82
        Me.CmdTodoEFE.Text = "( ALT+&E ) TODO EN EFECTIVO."
        Me.CmdTodoEFE.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CmdTodoEFE.UseVisualStyleBackColor = True
        '
        'lblMontoAplicar
        '
        Me.lblMontoAplicar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMontoAplicar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoAplicar.ForeColor = System.Drawing.Color.White
        Me.lblMontoAplicar.Location = New System.Drawing.Point(478, 42)
        Me.lblMontoAplicar.Name = "lblMontoAplicar"
        Me.lblMontoAplicar.Size = New System.Drawing.Size(146, 32)
        Me.lblMontoAplicar.TabIndex = 36
        Me.lblMontoAplicar.Text = "0"
        Me.lblMontoAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(386, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 27)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "MONTO APLICAR :"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(3, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 15)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "DETALLE LAS FORMAS DE CANCELACION :"
        '
        'LblEstadoCaja
        '
        Me.LblEstadoCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblEstadoCaja.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstadoCaja.ForeColor = System.Drawing.Color.White
        Me.LblEstadoCaja.Location = New System.Drawing.Point(95, 42)
        Me.LblEstadoCaja.Name = "LblEstadoCaja"
        Me.LblEstadoCaja.Size = New System.Drawing.Size(265, 32)
        Me.LblEstadoCaja.TabIndex = 33
        Me.LblEstadoCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 27)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "ESTADO :"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 27)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "CAJAS DISPONIBLES"
        '
        'CmdCajas
        '
        Me.CmdCajas.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdCajas.FlatAppearance.BorderSize = 0
        Me.CmdCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCajas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCajas.ForeColor = System.Drawing.Color.White
        Me.CmdCajas.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdCajas.IconColor = System.Drawing.Color.White
        Me.CmdCajas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdCajas.IconSize = 25
        Me.CmdCajas.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdCajas.Location = New System.Drawing.Point(95, 10)
        Me.CmdCajas.Name = "CmdCajas"
        Me.CmdCajas.Size = New System.Drawing.Size(265, 26)
        Me.CmdCajas.TabIndex = 30
        Me.CmdCajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCajas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdCajas.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(386, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 27)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "MONEDA APLICACION:"
        '
        'CmdMonedaComp
        '
        Me.CmdMonedaComp.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CmdMonedaComp.FlatAppearance.BorderSize = 0
        Me.CmdMonedaComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdMonedaComp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMonedaComp.ForeColor = System.Drawing.Color.White
        Me.CmdMonedaComp.IconChar = FontAwesome.Sharp.IconChar.CaretDown
        Me.CmdMonedaComp.IconColor = System.Drawing.Color.White
        Me.CmdMonedaComp.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CmdMonedaComp.IconSize = 25
        Me.CmdMonedaComp.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdMonedaComp.Location = New System.Drawing.Point(478, 9)
        Me.CmdMonedaComp.Name = "CmdMonedaComp"
        Me.CmdMonedaComp.Size = New System.Drawing.Size(146, 26)
        Me.CmdMonedaComp.TabIndex = 29
        Me.CmdMonedaComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdMonedaComp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdMonedaComp.UseVisualStyleBackColor = False
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
        Me.CmdCerrar.IconSize = 33
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(775, -2)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(32, 33)
        Me.CmdCerrar.TabIndex = 10
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.LblDif)
        Me.Panel1.Controls.Add(Me.CmdAceptar)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.LblMoneda)
        Me.Panel1.Controls.Add(Me.LblEtiqueta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 491)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(811, 59)
        Me.Panel1.TabIndex = 16
        '
        'LblDif
        '
        Me.LblDif.AutoSize = True
        Me.LblDif.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblDif.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDif.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblDif.Location = New System.Drawing.Point(559, 30)
        Me.LblDif.Name = "LblDif"
        Me.LblDif.Size = New System.Drawing.Size(0, 17)
        Me.LblDif.TabIndex = 37
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
        Me.CmdAceptar.Location = New System.Drawing.Point(660, 9)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(113, 54)
        Me.CmdAceptar.TabIndex = 36
        Me.CmdAceptar.Text = "&ACEPTAR"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(445, 17)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(108, 33)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMoneda
        '
        Me.LblMoneda.AutoSize = True
        Me.LblMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMoneda.ForeColor = System.Drawing.Color.White
        Me.LblMoneda.Location = New System.Drawing.Point(404, 19)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(25, 18)
        Me.LblMoneda.TabIndex = 1
        Me.LblMoneda.Text = "S/"
        '
        'LblEtiqueta
        '
        Me.LblEtiqueta.AutoSize = True
        Me.LblEtiqueta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtiqueta.ForeColor = System.Drawing.Color.White
        Me.LblEtiqueta.Location = New System.Drawing.Point(332, 19)
        Me.LblEtiqueta.Name = "LblEtiqueta"
        Me.LblEtiqueta.Size = New System.Drawing.Size(59, 17)
        Me.LblEtiqueta.TabIndex = 0
        Me.LblEtiqueta.Text = "TOTAL :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CheckNC)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 288)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(811, 33)
        Me.Panel2.TabIndex = 17
        '
        'CheckNC
        '
        Me.CheckNC.AutoSize = True
        Me.CheckNC.BackColor = System.Drawing.Color.Transparent
        Me.CheckNC.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckNC.ForeColor = System.Drawing.Color.Gray
        Me.CheckNC.Location = New System.Drawing.Point(10, 7)
        Me.CheckNC.Name = "CheckNC"
        Me.CheckNC.Size = New System.Drawing.Size(157, 17)
        Me.CheckNC.TabIndex = 35
        Me.CheckNC.Text = "USAR NOTAS DE CREDITO"
        Me.CheckNC.UseVisualStyleBackColor = False
        '
        'dg_cuentasn
        '
        Me.dg_cuentasn.AllowUserToAddRows = False
        Me.dg_cuentasn.AllowUserToDeleteRows = False
        Me.dg_cuentasn.AllowUserToOrderColumns = True
        Me.dg_cuentasn.AllowUserToResizeRows = False
        Me.dg_cuentasn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_cuentasn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cuentasn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_cuentasn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_cuentasn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_cuentasn.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_cuentasn.Dock = System.Windows.Forms.DockStyle.Top
        Me.dg_cuentasn.id_local_grid = 0
        Me.dg_cuentasn.Location = New System.Drawing.Point(0, 321)
        Me.dg_cuentasn.MultiSelect = False
        Me.dg_cuentasn.Name = "dg_cuentasn"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cuentasn.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg_cuentasn.RowHeadersVisible = False
        Me.dg_cuentasn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_cuentasn.Size = New System.Drawing.Size(811, 164)
        Me.dg_cuentasn.TabIndex = 18
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "dg_cuentasn"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'dg_finanzas
        '
        Me.dg_finanzas.AllowUserToAddRows = False
        Me.dg_finanzas.AllowUserToDeleteRows = False
        Me.dg_finanzas.AllowUserToOrderColumns = True
        Me.dg_finanzas.AllowUserToResizeRows = False
        Me.dg_finanzas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_finanzas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_finanzas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dg_finanzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_finanzas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_finanzas.DefaultCellStyle = DataGridViewCellStyle5
        Me.dg_finanzas.Dock = System.Windows.Forms.DockStyle.Top
        Me.dg_finanzas.id_local_grid = 0
        Me.dg_finanzas.Location = New System.Drawing.Point(0, 102)
        Me.dg_finanzas.MultiSelect = False
        Me.dg_finanzas.Name = "dg_finanzas"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_finanzas.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dg_finanzas.RowHeadersVisible = False
        Me.dg_finanzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_finanzas.Size = New System.Drawing.Size(811, 186)
        Me.dg_finanzas.TabIndex = 15
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "dg_finanzas"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'FrmOperFinanzas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 550)
        Me.ControlBox = False
        Me.Controls.Add(Me.dg_cuentasn)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dg_finanzas)
        Me.Controls.Add(Me.PanelSup)
        Me.Name = "FrmOperFinanzas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSup.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dg_cuentasn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_finanzas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSup As Panel
    Friend WithEvents CmdCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents dg_finanzas As GridFinanzas_Plus
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTotal As Label
    Friend WithEvents LblMoneda As Label
    Friend WithEvents LblEtiqueta As Label
    Friend WithEvents CmdAceptar As FontAwesome.Sharp.IconButton
    Friend WithEvents Label23 As Label
    Friend WithEvents CmdMonedaComp As FontAwesome.Sharp.IconButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CmdCajas As FontAwesome.Sharp.IconButton
    Friend WithEvents LblEstadoCaja As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMontoAplicar As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CmdTodoEFE As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dg_cuentasn As GridFinanzas_Plus
    Friend WithEvents CheckNC As CheckBox
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents LblDif As Label
End Class
Public Class GridFinanzas_Plus
    Inherits Windows.Forms.DataGridView
    Private _id_local As Integer

    Public Property id_local_grid As Integer
        Get
            Return _id_local
        End Get
        Set(value As Integer)
            _id_local = value
        End Set
    End Property
    Protected Overrides Function ProcessDialogKey(ByVal KeyData As System.Windows.Forms.Keys) As Boolean
        'dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString().ToUpper()

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
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("fecha").Value = formattedDate
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

            If Me.CurrentCell.OwningColumn.Name = "cantidad" Then
                Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'cantidad'  ")
                Dim colum_destino As String = ""
                If Loc_Salto_Grid.Length = 0 Then
                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If

                If Me.CurrentCell.RowIndex = Me.Rows.Count - 1 Then
                    colum_destino = Loc_Salto_Grid(0)("columna_des")
                    Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
                    Me.BeginEdit(True)
                Else
                    colum_destino = Loc_Salto_Grid(0)("columna_ori")
                    Me.CurrentCell = Me.Rows(Me.CurrentCell.RowIndex + 1).Cells(colum_destino)
                End If

                ' FrmOperaciones.GridProductos_PrimeraFila()
                Return True
            End If
            If Me.CurrentCell.OwningColumn.Name = "codigotipo" Then
                Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
                Dim wid_local As Integer = Me.id_local_grid

                Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()
                Dim filtro As String = "forma_codigo = " & currentValue & " and id_moneda = " & 1 & " "
                temp_finanzas.DefaultView.RowFilter = filtro
                Dim Listafn As DataTable = temp_finanzas.DefaultView.ToTable(True, "fn_codigo", "fn_des", "id_tb_formas_fn", "forma_des")

                If Listafn.Rows.Count = 0 Then
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip_tipo").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_tb_formas_fn").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_tb_formas_fn").Tag = ""
                    Return True
                End If
                Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip_tipo").Value = Listafn.Rows(0).Item("forma_des")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_tb_formas_fn").Value = Listafn.Rows(0).Item("id_tb_formas_fn")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_tb_formas_fn").Tag = Listafn.Rows(0).Item("id_tb_formas_fn")
            End If

            If Me.CurrentCell.OwningColumn.Name = "codigo" Then
                Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
                If currentValue.ToString.Trim = "" Then Return True
                Dim wid_local As Integer = Me.id_local_grid


                Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()
                Dim filtro As String = "id_tb_formas_fn = " & Me.Rows(Me.CurrentCell.RowIndex).Cells("id_tb_formas_fn").Value & " and fn_codigo = " & currentValue & " and id_moneda = " & 1 & " "
                temp_finanzas.DefaultView.RowFilter = filtro
                Dim Listafn As DataTable = temp_finanzas.DefaultView.ToTable(True, "fn_codigo", "id_fn_maestro", "fn_des")

                If Listafn.Rows.Count = 0 Then
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip_entidad").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_fn_maestro").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_fn_maestro").Tag = ""
                    Return True
                End If
                Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip_entidad").Value = Listafn.Rows(0).Item("fn_des")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_fn_maestro").Value = Listafn.Rows(0).Item("id_fn_maestro")
                Me.Rows(Me.CurrentCell.RowIndex).Cells("id_fn_maestro").Tag = Listafn.Rows(0).Item("id_fn_maestro")
            End If



            If Me.CurrentCell.OwningColumn.Name = "almacen" Then
                    Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()
                    Dim wid_local As Integer = Me.id_local_grid

                    Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_local = " & wid_local & " and alm_codigo = '" & currentValue & "'")
                    ' Recorremos las filas filtradas
                    If DatoAlmacen.Length = 0 Then
                        ' Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                        '                         "Local.")
                        '  CmdLocal_Click(Nothing, Nothing)
                        Me.Rows(Me.CurrentCell.RowIndex).Cells("id_almacen").Value = 0
                        Me.Rows(Me.CurrentCell.RowIndex).Cells("alm_abreviado").Value = ""
                        Return True
                    End If
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_almacen").Value = DatoAlmacen(0)("id_almacen")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("alm_abreviado").Value = DatoAlmacen(0)("alm_abreviado").ToString.Trim

                    'TxtComp_codigo.Text = Comprobantes(0)("codigo")
                    'TxtComp_codigo.Tag = Comprobantes(0)("id_comprobante")

                    SendKeys.Send(Chr(Keys.Tab))
                    Return True
                End If
                If Me.CurrentCell.OwningColumn.Name = "numerocomp" Then


                    Dim currentValue As String = Me.CurrentCell.EditedFormattedValue.ToString()


                Dim sql As String = "exec [sp_muestra_carterasn] @id_negocio, @tipo_balance, @codigo_comp ,@serie_comp, @numero_comp, @es_oper_maestro ,@id_oper_maestro, @id_comp_cab"
                Dim command As New SqlCommand(sql, lk_connection_cuenta)
                    command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
                command.Parameters.AddWithValue("@tipo_balance", Val(Me.AccessibleDescription))
                command.Parameters.AddWithValue("@codigo_comp", Me.Rows(Me.CurrentCell.RowIndex).Cells("codcomp").Value)
                    command.Parameters.AddWithValue("@serie_comp", Me.Rows(Me.CurrentCell.RowIndex).Cells("seriecomp").Value)
                command.Parameters.AddWithValue("@numero_comp", Val(currentValue))
                command.Parameters.AddWithValue("@es_oper_maestro", 0)
                command.Parameters.AddWithValue("@id_oper_maestro", 0)
                command.Parameters.AddWithValue("@id_comp_cab", 0)



                Dim adapter As New SqlDataAdapter(command)
                    Dim tabla As New DataTable()
                    adapter.Fill(tabla)
                    If tabla.Rows.Count = 0 Then
                        Return True
                    End If

                    Me.Rows(Me.CurrentCell.RowIndex).Cells("codigo").Value = tabla.Rows(0).Item("sn_codigo").ToString
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("descrip").Value = tabla.Rows(0).Item("sn_razonsocial").ToString.Trim
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("masdetalle").Value = "..." 'tabla.Rows(0).Item("Codigo").ToString
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("fechaemis").Value = Format(tabla.Rows(0).Item("fecha_emis"), "dd/MM/yyyy")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("local").Value = tabla.Rows(0).Item("local_codigo").ToString & " " & tabla.Rows(0).Item("local_abreviado").ToString
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("moneda").Value = tabla.Rows(0).Item("mod_simbolo").ToString
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("monto").Value = tabla.Rows(0).Item("total")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("saldo").Value = tabla.Rows(0).Item("saldo")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("fechavcto").Value = Format(tabla.Rows(0).Item("fecha_vcto"), "dd/MM/yyyy")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("condicion").Value = tabla.Rows(0).Item("oper_nom_tipooper")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("vendedor").Value = ""
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("hecho").Value = tabla.Rows(0).Item("usuario").ToString.Trim & " " & tabla.Rows(0).Item("nombres").ToString.Trim & " " & tabla.Rows(0).Item("apellidos").ToString.Trim
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("fechahora").Value = tabla.Rows(0).Item("fechahora").ToString.Trim

                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_oper_maestro").Value = tabla.Rows(0).Item("id_oper_maestro")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_comp_cab").Value = tabla.Rows(0).Item("id_comp_cab")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_carterasn_cab").Value = tabla.Rows(0).Item("id_carterasn_cab")
                    Me.Rows(Me.CurrentCell.RowIndex).Cells("id_carterasn_det").Value = tabla.Rows(0).Item("id_carterasn_det")



                    'Identifica el siguiente salto 
                    Dim Loc_Salto_Grid() As DataRow = lk_sql_Salto_Grid.Select("id_tb_oper = '" & Val(Me.AccessibleName) & "' and codigogrid= 'PROD1' and columna_ori = 'codigo'  ")
                    Dim colum_destino As String = ""
                    If Loc_Salto_Grid.Length = 0 Then
                        SendKeys.Send(Chr(Keys.Tab))
                        Return True
                    End If

                    colum_destino = Loc_Salto_Grid(0)("columna_des")

                    Me.CurrentCell = Me.Rows(Me.Rows.Count - 1).Cells(colum_destino)
                    Me.BeginEdit(True)

                    ' FrmOperaciones.GridProductos_PrimeraFila()
                    Return True
                    'SendKeys.Send(Chr(Keys.Tab))
                    'Return True
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

            'If Me.CurrentCell.OwningColumn.Name = "lote" Or Me.CurrentCell.OwningColumn.Name = "codigo" Or Me.CurrentCell.OwningColumn.Name = "cantidad" Or Me.CurrentCell.OwningColumn.Name = "present" Then
            Return True
            'End If
        End If

        'If Me.Rows(Me.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
        '    If Me.CurrentCell.OwningColumn.Name = "codigo" Or Me.CurrentCell.OwningColumn.Name = "cantidad" Or Me.CurrentCell.OwningColumn.Name = "present" Then
        '        Return True
        '    End If
        'End If





        Return MyBase.ProcessDialogKey(KeyData)






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