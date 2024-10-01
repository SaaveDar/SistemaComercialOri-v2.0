Imports System.ComponentModel

Public Class FrmOperDetalle
    Dim Loc_Tipo_Grid As String = "" ' "PROD1"  = ODR DE VENTA /COTI /VENTAS
    Private Sub FrmOperDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loc_Tipo_Grid = "PROD1"

        If Loc_Tipo_Grid = "PROD1" Then
            GridProductos_Inicia_PROD1()
        End If
        '  GridProductos_PrimeraFila()


    End Sub

    Private Sub GridProductos_Inicia_PROD1()
        'Dim imageColumn As New DataGridViewImageColumn()
        'Dim textoColumn As New DataGridViewTextBoxColumn()
        'Dim comboColumn As New DataGridViewComboBoxColumn()
        'Dim checkColumn As New DataGridViewCheckBoxColumn()
        'Dim BotonColumn As New DataGridViewButtonColumn()

        ''imageColumn.Name = "eliminar"
        ''imageColumn.HeaderText = "Quitar"
        ''imageColumn.Image = My.Resources.eliminar
        ''imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        ''dg_operaciones.Columns.Add(imageColumn)
        ''dg_operaciones.Columns.Item("eliminar").Width = 35

        'GridProductos.Columns.Clear()
        'GridProductos.DefaultCellStyle.Font = New Font("Arial", 9)

        'textoColumn.Name = "num"
        'textoColumn.HeaderText = "#"
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 25
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "descrip"
        'textoColumn.Tag = "T"
        'textoColumn.HeaderText = "DESCRIPCION PRODUCTO"
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 400
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True

        'BotonColumn = New DataGridViewButtonColumn()
        'BotonColumn.Name = "masdetalle"
        'BotonColumn.HeaderText = "INF"
        'BotonColumn.FlatStyle = FlatStyle.Flat
        'GridProductos.Columns.Add(BotonColumn)
        'GridProductos.Columns.Item(BotonColumn.Name).Width = 25

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "codigo"
        'textoColumn.Tag = "A15"
        'textoColumn.HeaderText = "CODIGO"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 60
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "id_prod_mae"
        'textoColumn.HeaderText = "id_prod_mae"
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 0
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'GridProductos.Columns.Item(textoColumn.Name).Visible = False

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "Cantidad"
        'textoColumn.Tag = "E6"
        'textoColumn.HeaderText = "CANTID."
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 50
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False

        'comboColumn = New DataGridViewComboBoxColumn()
        'comboColumn.Name = "present"
        'comboColumn.Tag = "C"
        'comboColumn.HeaderText = "PRESENT."
        'comboColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'comboColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'comboColumn.FlatStyle = FlatStyle.Flat
        'GridProductos.Columns.Add(comboColumn)
        'GridProductos.Columns.Item(comboColumn.Name).Width = 80
        'GridProductos.Columns.Item(comboColumn.Name).ReadOnly = False

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "id_pres"
        'textoColumn.HeaderText = "id_pres"
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 0
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        'GridProductos.Columns.Item(textoColumn.Name).Visible = False

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "equiv"
        'textoColumn.HeaderText = "equiv"
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 0
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = True
        'GridProductos.Columns.Item(textoColumn.Name).Visible = False

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "almacen"
        'textoColumn.Tag = "E2"
        'textoColumn.HeaderText = "ALM"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 30
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Integer) ' Tipo de valor de la celda

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "lote"
        'textoColumn.Tag = "A20"
        'textoColumn.HeaderText = "LOT"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 40
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha


        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "id_almacen"
        'textoColumn.HeaderText = "id_almacen"
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 0
        'GridProductos.Columns.Item(textoColumn.Name).Visible = False


        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "preciobase"
        'textoColumn.Tag = "N10"
        'textoColumn.HeaderText = "PRECIO BASE"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 70
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda



        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "des1"
        'textoColumn.Tag = "N4"
        'textoColumn.HeaderText = "DCTO1.%"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 55
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda


        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "des2"
        'textoColumn.Tag = "N4"
        'textoColumn.HeaderText = "DCTO2.%"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 55
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda



        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "valor"
        'textoColumn.Tag = "N10"
        'textoColumn.HeaderText = "VALOR"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 70
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "impto"
        'textoColumn.Tag = "N10"
        'textoColumn.HeaderText = "IMPTO"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 55
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda


        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "subtotal"
        'textoColumn.Tag = "N10"
        'textoColumn.HeaderText = "VALOR SUBTOTAL*"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'GridProductos.Columns.Add(textoColumn)
        'GridProductos.Columns.Item(textoColumn.Name).Width = 70
        'GridProductos.Columns.Item(textoColumn.Name).ReadOnly = False
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        'textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda


        'imageColumn.HeaderText = "*"
        'imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'imageColumn.Name = "eli"
        'imageColumn.Image = My.Resources.eliminar
        'imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        'GridProductos.Columns.Add(imageColumn)
        'GridProductos.Columns.Item(imageColumn.Name).Width = 30
        'GridProductos.Columns.Item(imageColumn.Name).ReadOnly = False


    End Sub





    'Private Sub GridProductos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GridProductos.EditingControlShowing
    ''If TypeOf e.Control Is ComboBox Then
    ''    Dim comboBox As ComboBox = CType(e.Control, ComboBox)
    ''    comboBox.DropDownStyle = ComboBoxStyle.DropDown
    ''    comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    ''    comboBox.AutoCompleteSource = AutoCompleteSource.ListItems

    ''    ' Mostrar los items del ComboBox al entrar en la celda
    ''    comboBox.DroppedDown = True
    ''End If

    '  AddHandler e.Control.KeyPress, AddressOf ValidarNumeros


    'If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
    '    'Agrega el controlador de eventos KeyPress a la caja de edición actual
    '    Dim dgvTextBox = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
    '    AddHandler dgvTextBox.KeyPress, AddressOf ValidarNumeros
    'End If



    ' End Sub
    'Private Sub ValidarColumas(sender As Object, e As KeyPressEventArgs)

    '    'Dim editingControl As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
    '    'Dim dgv As DataGridView = editingControl.Parent


    '    '' Dim dgv As DataGridView = DirectCast(sender, DataGridView)
    '    'Dim nombreColumnaActual As String = sender.Columns(dgv.CurrentCell.ColumnIndex).Name

    '    '  If e.CurrentCell.OwningColumn.Tag = "" Then

    '    '  End If

    '    'If dgv.CurrentCell.OwningColumn.Tag = "N" Then
    '    '    Dim textBox = TryCast(sender, DataGridViewTextBoxEditingControl)
    '    '    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
    '    '        e.Handled = True
    '    '    ElseIf e.KeyChar = "."c AndAlso textBox IsNot Nothing AndAlso textBox.Text.Contains(".") Then
    '    '        e.Handled = True
    '    '    End If
    '    'End If


    '    '  System.InvalidCastException 'No se puede convertir un objeto de tipo 'System.Windows.Forms.DataGridViewTextBoxEditingControl' al tipo 'System.Windows.Forms.DataGridView'.'


    'End Sub


    'If GridProductos.CurrentCell.OwningColumn.Tag = "N" Then
    '    AddHandler e.Control.KeyPress, AddressOf ValidarNumeros
    'End If

    'If Strings.Left(GridProductos.CurrentCell.OwningColumn.Tag, 1) = "E" Then
    '    If Len(GridProductos.CurrentCell.OwningColumn.Tag) = 1 Then
    '        AddHandler e.Control.KeyPress, AddressOf ValidarEnteros

    '    Else
    '        Dim wdig As Integer = Mid(GridProductos.CurrentCell.OwningColumn.Tag, 2, Len(GridProductos.CurrentCell.OwningColumn.Tag))
    '        '                AddHandler e.Control.KeyPress, AddressOf ValidarEnteros

    '        'AddHandler e.Control.KeyPress, Sub(sender, e) ValidarEnteros(sender, e, 2))
    '        ' Para limitar el número de caracteres a 2:
    '        '  AddHandler e.Control.KeyPress, Sub(s, evt) ValidarEnteros(s, evt, wdig)
    '    End If

    'End If

    'Private Sub ValidarColumas(sender As Object, e As KeyPressEventArgs)
    '    If e.CurrentCell.OwningColumn.Tag = "N" Then
    '        Dim textBox = TryCast(sender, DataGridViewTextBoxEditingControl)
    '        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
    '            e.Handled = True
    '        ElseIf e.KeyChar = "."c AndAlso textBox IsNot Nothing AndAlso textBox.Text.Contains(".") Then
    '            e.Handled = True
    '        End If
    '    End If

    'End Sub

    Private Sub Libre(sender As Object, e As KeyPressEventArgs)

    End Sub




    'Private Sub GridProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridProductos.KeyDown

    '    'If e.KeyCode = Keys.Delete Then
    '    '    If GridProductos.CurrentCell.OwningColumn.Name = "eli" Then
    '    '        If GridProductos.SelectedRows.Count > 0 Then ' Verificar que se haya seleccionado alguna fila
    '    '            GridProductos.Rows.Remove(GridProductos.SelectedRows(0)) ' Eliminar la primera fila seleccionada
    '    '        End If
    '    '    End If
    '    'End If

    '    'If e.KeyCode = Keys.Enter Then
    '    '    ' Obtener el control actual y su celda
    '    '    Dim ctl = DirectCast(sender, Control)
    '    '    Dim cell = GridProductos.CurrentCell

    '    '    ' Mover el foco a la siguiente celda
    '    '    If Not cell Is Nothing Then
    '    '        Dim nextCell = GridProductos.GetNextCell(cell, DataGridViewElementStates.Visible, DataGridViewElementStates.None, False, False)
    '    '        If Not nextCell Is Nothing Then
    '    '            GridProductos.CurrentCell = nextCell
    '    '            GridProductos.BeginEdit(True)

    '    '            ' Si la celda siguiente es un combo, mostrar la lista
    '    '            If TypeOf nextCell Is DataGridViewComboBoxCell Then
    '    '                Dim combo = CType(nextCell, DataGridViewComboBoxCell)
    '    '                combo.Selected = False
    '    '                combo.DropDown()
    '    '            End If
    '    '        End If
    '    '    End If

    '    '    ' Indicar que la tecla fue manejada
    '    '    e.Handled = True
    '    'End If

    'End Sub

    'Private Sub GridProductos_Validating(sender As Object, e As CancelEventArgs) Handles GridProductos.Validating

    'End Sub

    'Private Sub GridProductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridProductos.CellEnter

    '    If Strings.Left(GridProductos.CurrentCell.OwningColumn.Tag, 1) = "C" And Val(GridProductos.Rows(e.RowIndex).Cells("almacen").Value) = 0 Then ' cUALQUIER vALOR
    '        Dim comboBox As DataGridViewComboBoxCell = CType(GridProductos.CurrentCell, DataGridViewComboBoxCell)
    '        comboBox.Selected = False
    '        comboBox.DataGridView.BeginEdit(True)

    '        ' Mostrar la lista desplegable del ComboBox
    '        If comboBox.Items.Count > 0 Then
    '            comboBox.FlatStyle = FlatStyle.Flat
    '            comboBox.DisplayStyle = ComboBoxStyle.DropDown
    '        End If
    '    End If

    'End Sub

    'Private Sub GridProductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridProductos.KeyPress
    '    If Strings.Left(GridProductos.CurrentCell.OwningColumn.Tag, 1) = "C" And e.KeyChar <> Chr(13) Then ' cUALQUIER vALOR
    '        Dim comboBox As DataGridViewComboBoxCell = CType(GridProductos.CurrentCell, DataGridViewComboBoxCell)
    '        comboBox.Selected = False
    '        comboBox.DataGridView.BeginEdit(True)

    '        ' Mostrar la lista desplegable del ComboBox
    '        If comboBox.Items.Count > 0 Then
    '            comboBox.FlatStyle = FlatStyle.Flat
    '            comboBox.DisplayStyle = ComboBoxStyle.DropDown
    '        End If
    '    End If


    ' End Sub


    'Private Sub GridProductos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles GridProductos.RowsAdded
    '    '    Contador_filas()
    'End Sub

    'Private Sub GridProductos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles GridProductos.RowsRemoved
    '    '    Contador_filas()
    'End Sub

    'Private Sub GridProductos_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles GridProductos.PreviewKeyDown
    '    If e.KeyCode = Keys.Enter And GridProductos.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
    '        If GridProductos.CurrentCell Is Nothing Then Exit Sub
    '        If GridProductos.CurrentCell.Tag = "eli" Then
    '            If GridProductos.Rows.Count = 1 Then ' Verificar que se haya seleccionado alguna fila
    '                GridProductos.Rows.Remove(GridProductos.CurrentRow) ' Eliminar la primera fila seleccionada
    '                '  GridProductos_PrimeraFila()
    '            Else
    '                GridProductos.Rows.Remove(GridProductos.CurrentRow) ' Eliminar la primera fila seleccionada
    '            End If
    '        End If
    '        If GridProductos.CurrentCell.Tag = "add" Then
    '            If GridProductos.Rows.Count - 1 <> GridProductos.CurrentCell.RowIndex Then

    '                '  GridProductos_PrimeraFila()

    '            End If
    '        End If

    '    End If

    'End Sub
End Class