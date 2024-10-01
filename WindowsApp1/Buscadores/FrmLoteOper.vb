Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions

Public Class FrmLoteOper
    Public Property TipoRegistro As String
    Public Property LOTE_ID_PROD_MAE As Integer
    Public Property LOTE_ID_PROD_NOMBRE As String
    Public Property LOTE_CANTIDAD_LOTE As Double
    Public Property LOTE_CANTIDAD_PRES As String
    Public Property LOTE_EQUIV_PRES As Integer
    Public Property LOTE_ID_LOCAL As Integer
    Public Property LOTE_ID_ALMACEN As Integer


    Public Property LOTE_CADENALOTES As String
    Public Property LOTE_CADENALOTES_FORMATO As String

    Public Property LOTE_ID_PRES_BASE As Integer
    Public Property LOTE_ABREVIADO_BASE As String
    Public Property LOTE_EQUIV_BASE As Integer
    Public Property LOTE_ES_BLOQUEADO As String
    Public Property LOTE_ES_RECEPCION As Integer
    Public Property LOTE_ES_AUTOMATICO As Integer
    Public Property LOTE_SIN_LOTE As Integer



    'Public Property LOTE_CANTIDAD_EQUIV As Integer

    Public Property ModoBusqeuda As String
    Public Property TextoBusca As String
    Public Property DatosLoteProd As String
    Public Property lote_defecto As String



    Private Sub PanelSup_Resize(sender As Object, e As EventArgs) Handles PanelSup.Resize
        Me.Text = ""
        Me.ControlBox = False
    End Sub
    'Drag Form'
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelSup_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelSup.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub




    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmLoteOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LOTE_ES_AUTOMATICO = 1 Then
            Me.Visible = False
        End If
        flag_ok.Text = ""

        'CERRAR_SESIONES()
        'ConexionSQL_Maester()
        'ConexionSQL_Cuentas()
        'Me.CenterToScreen()
        'lk_NegocioActivo.id_Negocio = 22
        'lk_LocalActivo.id_local = 3
        'lk_LocalActivo.codigo = "019"
        'lk_LocalActivo.nombre = "XSAN MARTIN 1 - PRIMER PISO"
        'lk_AlmacenActivo.id_almacen = 1
        'lk_AlmacenActivo.codigo = "01"
        'TipoRegistro = "INGRESO"
        'LOTE_ID_PROD_NOMBRE = "PRODUCTO "
        'LOTE_CANTIDAD_LOTE = 500
        'LOTE_CANTIDAD_PRES = "UNIDAD"
        LOTE_SIN_LOTE = 0


        GridLoteProductos_Inicia()
        If TipoRegistro = "INGRESO" Then
            Me.GridLoteProd.Columns.Item("ingreso").Visible = True
            Me.GridLoteProd.Columns.Item("salida").Visible = False
        ElseIf TipoRegistro = "SALIDA" Then
            Me.GridLoteProd.Columns.Item("ingreso").Visible = False
            Me.GridLoteProd.Columns.Item("salida").Visible = True
        End If
        LblProducto.Text = LOTE_ID_PROD_NOMBRE
        TxtCantidadSol.Text = LOTE_CANTIDAD_LOTE
        TxtCantidadPres.Text = LOTE_CANTIDAD_PRES
        If LOTE_CADENALOTES <> "" Then ' hay datos anteriores que se guardaron y muestra sus datos
            TraerLotesCadena(GridLoteProd, LOTE_CADENALOTES, LOTE_ES_RECEPCION)
        Else
            CargaDatos(TipoRegistro, LOTE_ID_PROD_MAE, LOTE_CANTIDAD_LOTE, lk_NegocioActivo.id_Negocio, LOTE_ID_LOCAL, LOTE_ID_ALMACEN, LOTE_EQUIV_PRES)
        End If



        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)




        'GridLoteProductos_Inicia()
        GridLoteProd.Dock = DockStyle.Fill
        ' Guarda id producto para busqeuda directo en Designer
        GridLoteProd.AccessibleName = LOTE_ID_PROD_MAE

        TxtCantidadSol.ReadOnly = True
        TxtCantidadPres.ReadOnly = True

        If LOTE_ES_BLOQUEADO = 1 Then
            TxtCantidadSol.Visible = False

        End If

        If LOTE_ES_AUTOMATICO = 1 Then
            CmdAceptar_Click(Nothing, Nothing)
        End If



    End Sub




    Private Sub GridLoteProductos_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim fechaColumna As New DataGridViewTextBoxColumn()


        'imageColumn.Name = "eliminar"
        'imageColumn.HeaderText = "Quitar"
        'imageColumn.Image = My.Resources.eliminar
        'imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        'dg_operaciones.Columns.Add(imageColumn)
        'dg_operaciones.Columns.Item("eliminar").Width = 35

        GridLoteProd.Columns.Clear()
        GridLoteProd.DefaultCellStyle.Font = New Font("Segoe UI", 9.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = True



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Width = 90
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_loteser"
        textoColumn.HeaderText = "id_loteser"
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Width = 0
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = False
        GridLoteProd.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "stock"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "STOCK."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Width = 60
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = True
        textoColumn.DefaultCellStyle.Format = "#0" ' 



        ' Agrega una nueva columna al DataGridView
        fechaColumna = New DataGridViewTextBoxColumn()
        fechaColumna.Name = "fecvcto"
        fechaColumna.Tag = "F"
        fechaColumna.HeaderText = "FEC.VCTO"
        GridLoteProd.Columns.Add(fechaColumna)
        fechaColumna.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        fechaColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridLoteProd.Columns.Item(fechaColumna.Name).Width = 90
        GridLoteProd.Columns.Item(fechaColumna.Name).ReadOnly = False
        GridLoteProd.Columns.Item(fechaColumna.Name).Visible = True
        'GridLoteProd.Columns.Item(fechaColumna.Name).ValueType = GetType(DateTime)
        'GridLoteProd.Columns.Item(fechaColumna.Name).DefaultCellStyle.Format = "dd/MM/yyyy"
        'GridLoteProd.Columns.Item(fechaColumna.Name).DefaultCellStyle.Format = "d"



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ingreso"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "INGRESAR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = False
        GridLoteProd.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GridLoteProd.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0" ' 



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "salida"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "SALIDA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GridLoteProd.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0" ' 

        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "estado"
        textoColumn.Tag = "A20"
        textoColumn.HeaderText = "ESTADO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Width = 0
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = True
        GridLoteProd.Columns.Item(textoColumn.Name).Visible = False




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "nombreestado"
        textoColumn.Tag = "A20"
        textoColumn.HeaderText = "ESTADO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Width = 80
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = True
        GridLoteProd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        ' textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)


        fechaColumna = New DataGridViewTextBoxColumn()
        fechaColumna.Name = "fecfab"
        fechaColumna.Tag = "F"
        fechaColumna.HeaderText = "FEC.FAB"
        fechaColumna.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        fechaColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridLoteProd.Columns.Add(fechaColumna)
        GridLoteProd.Columns.Item(fechaColumna.Name).Width = 90
        GridLoteProd.Columns.Item(fechaColumna.Name).ReadOnly = False
        GridLoteProd.Columns.Item(fechaColumna.Name).Visible = True

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        GridLoteProd.Columns.Add(imageColumn)
        GridLoteProd.Columns.Item(imageColumn.Name).Width = 28
        GridLoteProd.Columns.Item(imageColumn.Name).ReadOnly = False


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.del
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        GridLoteProd.Columns.Add(imageColumn)
        GridLoteProd.Columns.Item(imageColumn.Name).Width = 28
        GridLoteProd.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        GridLoteProd.Columns.Add(imageColumn)
        GridLoteProd.Columns.Item(imageColumn.Name).Width = 28
        GridLoteProd.Columns.Item(imageColumn.Name).ReadOnly = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "unid_kardex"
        textoColumn.Tag = "A20"
        textoColumn.HeaderText = "UND KAARDEX"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Width = 60
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo_ok"
        textoColumn.Tag = "A20"
        textoColumn.HeaderText = "codigo_ok"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ingreso_kardex"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "INGRE. KARDEX"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = True
        GridLoteProd.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GridLoteProd.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0" ' 



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "salida_kardex"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "SALID. KARDEX"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        GridLoteProd.Columns.Add(textoColumn)
        GridLoteProd.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GridLoteProd.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0" ' 

        GridLoteProd.Columns.Item(textoColumn.Name).ReadOnly = True


    End Sub

    Private Sub Contador_filas()



        'Exit Sub
        'Iterar por cada fila en el DataGridView
        If GridLoteProd.Visible = False Then Exit Sub

        If GridLoteProd.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To GridLoteProd.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            GridLoteProd.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = GridLoteProd.Rows.Count - 1 Then
                GridLoteProd.Rows(i).Cells("eli").Value = My.Resources.del
                GridLoteProd.Rows(i).Cells("eli").Tag = "eli"
                GridLoteProd.Rows(i).Cells("add").Value = My.Resources.add
                GridLoteProd.Rows(i).Cells("add").Tag = "add"

            Else
                GridLoteProd.Rows(i).Cells("eli").Value = My.Resources.del
                GridLoteProd.Rows(i).Cells("eli").Tag = "eli"
                GridLoteProd.Rows(i).Cells("add").Value = My.Resources.edit
                GridLoteProd.Rows(i).Cells("add").Tag = ""
            End If
            ultimafila = i
        Next
        'If ultimafila = 0 Then Exit Sub
        ''If GridProductos.Rows.Count = 0 Then
        'Dim currentImage As Image = GridProductos.Rows(ultimafila + 1).Cells("eli").Value
        'If currentImage Is My.Resources.eliminar Then
        '    GridProductos.Rows(ultimafila + 1).Cells("eli").Value = My.Resources.ver
        'End If
        ''End If
        calculo_validalote()
    End Sub

    Private Sub GridLoteProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridLoteProd.CellContentClick

    End Sub

    Private Sub GridLoteProd_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles GridLoteProd.RowsAdded
        Contador_filas()
    End Sub

    Private Sub GridLoteProd_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles GridLoteProd.RowsRemoved
        Contador_filas()
    End Sub

    Private Sub GridLoteProd_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GridLoteProd.CellValidating


        'If GridLoteProd.Columns(e.ColumnIndex).Tag = "F" Then
        '    Dim currentValuetext As String = e.FormattedValue.ToString()
        '    ' If Not Regex.IsMatch(currentValuetext, "^\d{2}/\d{4}$") Then

        '    Dim mesAnio As DateTime = DateTime.ParseExact(currentValuetext, "MM/yy", CultureInfo.InvariantCulture)
        '        Dim fechaCompleta As DateTime = New DateTime(mesAnio.Year, mesAnio.Month, DateTime.DaysInMonth(mesAnio.Year, mesAnio.Month))
        '        Me.GridLoteProd.Rows(Me.GridLoteProd.CurrentCell.RowIndex).Cells(Me.GridLoteProd.CurrentCell.OwningColumn.Name).Value = fechaCompleta.ToString("dd/MM/yyyy")
        '        Me.GridLoteProd.CurrentCell.Value = fechaCompleta.ToString("dd/MM/yyyy")
        '    'Me.CurrentCell.EditedFormattedValue = fechaCompleta.ToString("dd/MM/yyyy")


        '    ' End If
        'End If


        ' Validar el formato de fecha de la celda solo si la columna es la columna de fecha (por ejemplo, la columna 2)
        'If GridLoteProd.Columns(e.ColumnIndex).Tag = "F" Then
        '    ' Obtener el valor actual de la celda editada como cadena de texto
        '    Dim currentValuetext As String = e.FormattedValue.ToString()

        '    ' Especificar los formatos de fecha que se van a comprobar
        '    Dim formatosFecha() As String = {"dd/MM/yyyy", "d/M/yyyy", "dd-M-yyyy", "d-M-yyyy"}

        '    ' Intentar analizar la cadena de texto en una fecha utilizando los formatos especificados
        '    Dim fecha As DateTime
        '    If Not DateTime.TryParseExact(currentValuetext, formatosFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) Then
        '        ' La cadena de texto no tiene un formato de fecha válido
        '        e.Cancel = True ' Cancelar la edición de la celda
        '        MsgBox("El formato de fecha no es válido. Ingrese la fecha en uno de los siguientes formatos: dd/MM/yyyy, d/M/yyyy, dd-M-yyyy o d-M-yyyy.")
        '    End If

        'End If


        ' Validar el formato de fecha de la celda solo si la columna es la columna de fecha (por ejemplo, la columna 2)
        If GridLoteProd.Columns(e.ColumnIndex).Tag = "F" Then
            '  GridLoteProd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = GridLoteProd.Columns(e.ColumnIndex).Tag
            ' Stop
            '' Obtener el valor actual de la celda editada como cadena de texto
            'Dim currentValuetext As String = e.FormattedValue.ToString()
            'If Not Regex.IsMatch(currentValuetext, "^\d{2}/\d{4}$") Then

            '    Dim mesAnio As DateTime = DateTime.ParseExact(currentValuetext, "MM/yy", CultureInfo.InvariantCulture)
            '    Dim fechaCompleta As DateTime = New DateTime(mesAnio.Year, mesAnio.Month, DateTime.DaysInMonth(mesAnio.Year, mesAnio.Month))
            '    GridLoteProd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = fechaCompleta.ToString("dd/MM/yyyy")

            'End If

            '' Especificar los formatos de fecha que se van a comprobar
            ''Dim formatosFecha() As String = {"dd/MM/yyyy", "d/M/yyyy", "dd-M-yyyy", "d-M-yyyy"}

            '' Intentar analizar la cadena de texto en una fecha utilizando los formatos especificados
            'Dim fecha As Date
            'If DateTime.TryParseExact(currentValuetext, formatosFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) Then
            '    ' La cadena de texto tiene un formato de fecha válido, obtener la última fecha del mes correspondiente
            '    Dim ultimaFechaMes As Date = UltimaFechaDelMes(fecha)

            '    ' Mostrar la última fecha del mes en la celda
            '    GridLoteProd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ultimaFechaMes.ToString("dd/MM/yyyy")
            'Else
            '    ' La cadena de texto no tiene un formato de fecha válido
            '    e.Cancel = True ' Cancelar la edición de la celda
            '    MsgBox("El formato de fecha no es válido. Ingrese la fecha en uno de los siguientes formatos: dd/MM/yyyy, d/M/yyyy, dd-M-yyyy o d-M-yyyy.")
            'End If
        End If



        'If Strings.Left(Me.CurrentCell.OwningColumn.Tag, 1) = "F" Then ' cUALQUIER vALOR
        '    Dim currentValuetext As String = Me.CurrentCell.EditedFormattedValue.ToString()
        '    ' Especificar los formatos de fecha que se van a comprobar
        '    Dim formatosFecha() As String = {"dd/MM/yyyy", "d/M/yyyy", "dd-M-yyyy", "d-M-yyyy"}

        '    ' Intentar analizar la cadena de texto en una fecha utilizando los formatos especificados
        '    Dim fecha As DateTime
        '    If DateTime.TryParseExact(currentValuetext, formatosFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, fecha) Then
        '        ' La cadena de texto tiene un formato de fecha válido, hacer algo con la fecha
        '        MsgBox("La fecha ingresada es: " & fecha.ToString("dd/MM/yyyy"))
        '    Else
        '        ' La cadena de texto no tiene un formato de fecha válido
        '        MsgBox("La cadena de texto ingresada no es una fecha válida.")
        '    End If



        'End If

        'calculo_validalote()
    End Sub
    Private Function UltimaFechaDelMes(ByVal fecha As Date) As Date
        Dim ultimoDiaMes As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)
        Dim ultimaFechaMes As Date = New Date(fecha.Year, fecha.Month, ultimoDiaMes)
        Return ultimaFechaMes
    End Function

    Private Sub GridLoteProd_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GridLoteProd.CellEndEdit

        Dim currentValuetext As String

        If GridLoteProd.Columns(e.ColumnIndex).Tag = "F" Then
            Dim cell As DataGridViewCell = Me.GridLoteProd(e.ColumnIndex, e.RowIndex)
            currentValuetext = GridLoteProd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If currentValuetext Is Nothing Then
                GridLoteProd.CancelEdit()
                Exit Sub
            End If

            If currentValuetext.Length = 5 Or currentValuetext.Length = 7 Then
                Dim parts() As String = currentValuetext.Split("/"c) 'Dividir el valor en dos partes: mes y año
                If parts.Count = 2 Then
                Else
                    cell.Value = ""
                    Exit Sub
                End If
                If Integer.Parse(parts(0)) >= 1 And Integer.Parse(parts(0)) <= 12 Then
                Else
                    cell.Value = ""
                    Exit Sub
                End If
                If Integer.Parse(parts(1)) >= 1900 And Integer.Parse(parts(1)) <= 3000 Then
                ElseIf Integer.Parse(parts(1)) >= 10 And Integer.Parse(parts(1)) <= 99 Then
                    parts(1) = Val(parts(1)) + 2000
                Else
                    cell.Value = ""
                    Exit Sub
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
                    cell.Value = ""
                    Exit Sub
                End If
            End If
        End If





        'calculo_validalote()
        Contador_filas()

    End Sub

    Private Sub GridLoteProd_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles GridLoteProd.PreviewKeyDown
        If e.KeyCode = Keys.Enter And GridLoteProd.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If GridLoteProd.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = GridLoteProd.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = GridLoteProd.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = GridLoteProd.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = GridLoteProd.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual

            If GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
                Exit Sub
            End If

            If columnName = "eli" Then
                If GridLoteProd.Rows.Count - 1 = 0 Then
                    GridLoteProd.Rows.Clear()
                    ' GridLoteProductos_Inicia()
                    Me.GridLoteProd.Rows.Add()
                    Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("unid_kardex").Value = LOTE_ABREVIADO_BASE.ToString.Trim
                    Contador_filas()
                    Exit Sub
                End If
                GridLoteProd.Rows.Remove(GridLoteProd.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.GridLoteProd.CurrentCell = GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("num")
                Me.GridLoteProd.BeginEdit(True)
                Contador_filas()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If GridLoteProd.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.GridLoteProd.Rows.Add()

                Me.GridLoteProd.CurrentCell = GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("num")
                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("unid_kardex").Value = LOTE_ABREVIADO_BASE.ToString.Trim
                Me.GridLoteProd.BeginEdit(True)
                Contador_filas()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                ConfirmaTodoLote()
                'GridProductos_PrimeraFila()
            End If
        End If

    End Sub
    Private Sub ConfirmaTodoLote()
        CmdAceptar_Click(Nothing, Nothing)

    End Sub
    Private Sub CmbBuscar_Click(sender As Object, e As EventArgs) Handles CmbBuscar.Click


        Dim detalle As String = ""
        For Each row As DataGridViewRow In GridLoteProd.Rows
            For Each cell As DataGridViewCell In row.Cells

                If cell.Value IsNot Nothing AndAlso Not TypeOf cell.Value Is Image Then
                    If TypeOf cell.Value Is Date Then
                        detalle &= "" & Format(cell.Value.ToString(), "dd/MM/yyyy") & "#"
                    Else
                        detalle &= cell.Value.ToString() & "#"
                    End If
                Else
                    detalle &= "0" & "#"
                End If
            Next
            detalle = detalle.TrimEnd("#"c) & ";" ' Separador de filas
        Next

        CmbBuscar.Tag = detalle
        DatosLoteProd = detalle
        'Me.DialogResult = DialogResult.OK
        'Me.Close()
        MsgBox(DatosLoteProd.Length & "     " & DatosLoteProd)
    End Sub
    Private Function GuardaLotesCadena(wdt_grid As DataGridView) As String
        GuardaLotesCadena = ""
        Dim detalle As String = ""
        For Each row As DataGridViewRow In wdt_grid.Rows
            For Each cell As DataGridViewCell In row.Cells

                If cell.Value IsNot Nothing AndAlso Not TypeOf cell.Value Is Image Then
                    If TypeOf cell.Value Is Date Then
                        detalle &= "" & Format(cell.Value.ToString(), "dd/MM/yyyy") & "#"
                    Else
                        detalle &= cell.Value.ToString() & "#"
                    End If
                Else
                    detalle &= "0" & "#"
                End If
            Next
            detalle = detalle.TrimEnd("#"c) & ";" ' Separador de filas
        Next
        GuardaLotesCadena = detalle
    End Function

    Private Sub TraerLotesCadena(wdt_grid As DataGridView, wcadena As String, wes_recepcion As Integer)
        wdt_grid.Rows.Clear()
        wdt_grid.Visible = False
        Application.DoEvents()

        Dim detalle As String = wcadena
        Dim wvalornum As Double
        ' Dividir la cadena de detalle en filas y columnas
        Dim filas() As String = detalle.Split(";"c)
        For Each fila As String In filas
            ' Dividir cada fila en columnas
            Dim columnas() As String = fila.Split("#"c)

            ' Agregar una nueva fila al DataGridView
            Dim newRow As DataGridViewRow = wdt_grid.Rows(wdt_grid.Rows.Add())

            ' Asignar los valores a las celdas de la nueva fila
            For i As Integer = 0 To columnas.Length - 1
                If LOTE_ES_BLOQUEADO = "1" Then
                    If wdt_grid.Columns(i).Name = "ok" Then
                        newRow.Cells(i).Tag = "bloq"
                        newRow.Cells(i).Value = My.Resources.bloq
                    End If
                End If
                If wdt_grid.Columns(i).Name = "add" Or wdt_grid.Columns(i).Name = "eli" Or wdt_grid.Columns(i).Name = "ok" Then
                Else
                    Dim valor As String = columnas(i).Trim()
                    If wdt_grid.Columns(i).Name = "codigo" Then
                        newRow.Cells(i).Value = valor
                    Else
                        If IsNumeric(valor) Then
                            wvalornum = Val(valor)
                            newRow.Cells(i).Value = If(wvalornum Mod 1 = 0, wvalornum.ToString("N0"), wvalornum.ToString("N2"))  ' Val(wscal_saldo)
                        ElseIf IsDate(valor) Then
                            newRow.Cells(i).Value = Format(Date.Parse(valor), "dd/MM/yyyy")
                        Else
                            newRow.Cells(i).Value = valor
                        End If
                    End If
                End If
            Next
        Next
        If wdt_grid.Rows.Count > 0 Then
            wdt_grid.Rows.RemoveAt(wdt_grid.Rows.Count - 1)
            'For i = 0 To wdt_grid.Rows.Count - 1
            '    dt_grid.Rows.
            'Next i
        End If
        wdt_grid.Visible = True
        ' GridLoteProd.Refresh()
        Contador_filas()
    End Sub


    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        GridLoteProd.Rows.Clear()

        MsgBox(DatosLoteProd)
        GridLoteProd.Visible = False
        Application.DoEvents()
        ' Obtener el contenido de la columna "DetalleColumna" de la fila actual del DataGridView GridCabecera
        'Dim rowIndex As Integer = GridCabecera.CurrentRow.Index ' Fila actual seleccionada
        'Dim detalle As String = GridCabecera.Rows(rowIndex).Cells("DetalleColumna").Value.ToString()



        Dim detalle As String = DatosLoteProd
        ' Dividir la cadena de detalle en filas y columnas
        Dim filas() As String = detalle.Split(";"c)
        For Each fila As String In filas
            ' Dividir cada fila en columnas
            Dim columnas() As String = fila.Split("#"c)
            ' Agregar una nueva fila al DataGridView
            Dim newRow As DataGridViewRow = GridLoteProd.Rows(GridLoteProd.Rows.Add())
            ' Asignar los valores a las celdas de la nueva fila
            For i As Integer = 0 To columnas.Length - 1
                If GridLoteProd.Columns(i).Name = "add" Or GridLoteProd.Columns(i).Name = "eli" Then
                Else
                    Dim valor As String = columnas(i).Trim()
                    If IsNumeric(valor) Then
                        newRow.Cells(i).Value = valor
                    ElseIf IsDate(valor) Then
                        newRow.Cells(i).Value = Format(Date.Parse(valor), "dd/MM/yyyy")
                    Else
                        newRow.Cells(i).Value = valor
                    End If
                End If
            Next
        Next
        If GridLoteProd.Rows.Count > 0 Then
            GridLoteProd.Rows.RemoveAt(GridLoteProd.Rows.Count - 1)
        End If
        GridLoteProd.Visible = True
        ' GridLoteProd.Refresh()
        Contador_filas()









    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TipoRegistro = "INGRESO"
        LOTE_CANTIDAD_LOTE = Val(TextBox1.Text)
        LOTE_ID_PROD_MAE = Val(TextBox2.Text)
        CargaDatos(TipoRegistro, LOTE_ID_PROD_MAE, LOTE_CANTIDAD_LOTE, lk_NegocioActivo.id_Negocio, LOTE_ID_LOCAL, LOTE_ID_ALMACEN, LOTE_EQUIV_PRES)


    End Sub
    Private Sub CargaDatos(wtiporeg As String, wid_prod_mae As Integer, wCantidad As Double, wnegocio As Integer, wid_local As Integer, wid_almacen As Integer, wequiv As Integer)
        Dim wcanti_calculo As Integer = wCantidad * wequiv ' para el sp cantidad en unidades minimas

        Dim sql As String = "exec [DistribuirCantidad] '" & wid_prod_mae & "'," & wnegocio & "," & wid_local & "," & wid_almacen & ", " & wcanti_calculo & " "
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        Dim adapter As New SqlDataAdapter(command)

        datos_sql_resul = New DataTable()
        adapter.Fill(datos_sql_resul)
        GridLoteProductos_Inicia()

        Me.GridLoteProd.Tag = wtiporeg


        Dim Loc_lotes() As DataRow = datos_sql_resul.Select("saldo  <> 0 ")
        If wtiporeg = "INGRESO" Then
            Me.GridLoteProd.Columns.Item("ingreso").Visible = True
            Me.GridLoteProd.Columns.Item("salida").Visible = False
        ElseIf wtiporeg = "SALIDA" Then
            Me.GridLoteProd.Columns.Item("ingreso").Visible = False
            Me.GridLoteProd.Columns.Item("salida").Visible = True
        End If
        Me.GridLoteProd.Rows.Clear()

        If Loc_lotes.Length = 0 Then

            Me.GridLoteProd.Rows.Add()
            Me.GridLoteProd.CurrentCell = Me.GridLoteProd.Rows(Me.GridLoteProd.Rows.Count - 1).Cells("num")
            Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("unid_kardex").Value = LOTE_ABREVIADO_BASE.ToString.Trim
            Me.GridLoteProd.BeginEdit(True)
            'Me.GridLoteProd.CurrentCell = Me.GridLoteProd.Rows(Me.GridLoteProd.Rows.Count - 1).Cells("codigo")
            'Me.GridLoteProd.BeginEdit(True)
            Me.GridLoteProd.Focus()
            Me.GridLoteProd.Select()


        Else

            Dim wcanti As Integer = wCantidad ' segun su presentacion 
            Dim wsstock As Double = 0
            Dim wscantidad As Double = 0

            For i = 0 To Loc_lotes.Length - 1
                Me.GridLoteProd.Rows.Add()

                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("codigo").Value = Loc_lotes(i)("codigo")
                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("id_loteser").Value = Loc_lotes(i)("id_loteser")
                wsstock = Val(Loc_lotes(i)("saldo")) / wequiv
                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("stock").Value = If(wsstock Mod 1 = 0, wsstock.ToString("N0"), wsstock.ToString("N2"))
                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("fecvcto").Value = Format(Loc_lotes(i)("fechavcto"), "dd/MM/yyyy")
                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("unid_kardex").Value = LOTE_ABREVIADO_BASE.ToString.Trim
                If wtiporeg = "INGRESO" Then
                    If i = 0 Then ' el primero de la fila se asigna todo lo solicitado 
                        wscantidad = wcanti
                        Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("ingreso").Value = If(wscantidad Mod 1 = 0, wscantidad.ToString("N0"), wscantidad.ToString("N2"))
                        wscantidad = wcanti * wequiv
                        Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("ingreso_kardex").Value = If(wscantidad Mod 1 = 0, wscantidad.ToString("N0"), wscantidad.ToString("N2"))

                    Else
                        Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("ingreso").Value = 0
                        Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("ingreso_kardex").Value = 0
                    End If
                    'Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("ingreso").Value = Loc_lotes(i)("cantidad")
                ElseIf wtiporeg = "SALIDA" Then
                    wscantidad = Val(Loc_lotes(i)("cantidad")) / wequiv
                    Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("salida").Value = If(wscantidad Mod 1 = 0, wscantidad.ToString("N0"), wscantidad.ToString("N2"))
                    wscantidad = Val(Loc_lotes(i)("cantidad"))
                    Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("salida_kardex").Value = If(wscantidad Mod 1 = 0, wscantidad.ToString("N0"), wscantidad.ToString("N2"))
                End If
                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("estado").Value = Loc_lotes(i)("estado")
                Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("fecfab").Value = Format(Loc_lotes(i)("fechareg"), "dd/MM/yyyy")
                If LOTE_ES_BLOQUEADO = "1" Then
                    Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("ok").Tag = "bloq"
                    Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("ok").Value = My.Resources.bloq
                End If
            Next i
            Me.GridLoteProd.CurrentCell = GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("codigo")


            Me.GridLoteProd.Select()
        End If

        Contador_filas()



        ''If Me.GridProductos.CurrentCell.RowIndex = Me.GridProductos.Rows.Count Then
        'Me.GridLoteProd.Rows.Clear()
        'If TipoRegistro = "INGRESO" Then
        '    Me.GridLoteProd.Rows.Add()
        '    Me.GridLoteProd.CurrentCell = GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("codigo")
        '    'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."
        '    'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = "APIRINA COMPUESTO CON GRAGEAS 50X10GR PLUSS"
        '    'Me.GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("eli").Tag = ""
        '    Me.GridLoteProd.BeginEdit(True)
        '    Contador_filas()
        'End If




    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TipoRegistro = "SALIDA"
        LOTE_CANTIDAD_LOTE = Val(TextBox1.Text)
        LOTE_ID_PROD_MAE = Val(TextBox2.Text)
        ' CargaDatos(TipoRegistro, LOTE_ID_PROD_MAE, LOTE_CANTIDAD_LOTE)

    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        Contador_filas()

        If LblError.Text <> "" Then
            Exit Sub
        End If

        'MsgBox("TOdo conforme ")
        'Me.GridLoteProd.CurrentCell = GridLoteProd.Rows(GridLoteProd.Rows.Count - 1).Cells("num")
        'Me.GridLoteProd.BeginEdit(True)
        '  DatosLoteProd = 0
        Dim wprimerlote As String = ""
        Dim detalle As String = ""
        Dim wcantidad As String = ""

        For i = 0 To GridLoteProd.Rows.Count - 1
            If TipoRegistro = "INGRESO" Then
                wcantidad = Format(Val(Me.GridLoteProd.Rows(i).Cells("ingreso").Value), "0")
            Else
                wcantidad = Format(Val(Me.GridLoteProd.Rows(i).Cells("salida").Value), "0")
            End If
            detalle &= "" & Me.GridLoteProd.Rows(i).Cells("codigo").Value & " : " & wcantidad & " [" & Format(CDate(Me.GridLoteProd.Rows(i).Cells("fecvcto").Value), "MM/yyyy") & "]" & Chr(13)
        Next
        ' MsgBox(detalle)
        'For Each row As DataGridViewRow In GridLoteProd.Rows

        '    For Each cell As DataGridViewCell In row.Cells
        '        If cell.Value IsNot Nothing AndAlso Not TypeOf cell.Value Is Image Then
        '            If TypeOf cell.Value Is Date Then
        '                detalle &= "" & Format(cell.Value.ToString(), "dd/MM/yyyy") & "#"
        '            Else
        '                detalle &= cell.Value.ToString() & "#"
        '            End If
        '        Else
        '            detalle &= "0" & "#"
        '        End If
        '    Next
        '    detalle = detalle.TrimEnd("#"c) & ";" ' Separador de filas
        'Next
        wprimerlote = Me.GridLoteProd.Rows(0).Cells("codigo").Value

        Dim ws_cadenaLotes As String = GuardaLotesCadena(GridLoteProd)
        LOTE_CADENALOTES = ws_cadenaLotes ' que pase a operaciones para guardar a la fila de la grid del producto

        If Strings.Left(LOTE_CADENALOTES, 5) = "0#0#0" Then
            LOTE_SIN_LOTE = 1
        End If

        If GridLoteProd.Rows.Count = 0 Then

        End If
        If LOTE_SIN_LOTE = 0 Then
            Dim ws_cadenaLotes_formato As String = GuardaLotesCadena_formato(GridLoteProd)
            LOTE_CADENALOTES_FORMATO = ws_cadenaLotes_formato ' que pase a operaciones para guardar a la fila de la grid del producto
            flag_ok.Text = "1"
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If

        CmbBuscar.Tag = detalle
        DatosLoteProd = detalle
        lote_defecto = wprimerlote

        Me.Close()
    End Sub
    Private Function GuardaLotesCadena_formato(wdt_grid As DataGridView) As String
        Dim cantidad As String = ""
        Dim resultado As New StringBuilder() ' Utiliza un StringBuilder para construir la cadena

        For Each row As DataGridViewRow In wdt_grid.Rows

            cantidad = ""
            If TipoRegistro = "INGRESO" Then
                cantidad = row.Cells("ingreso").Value.ToString()

            ElseIf TipoRegistro = "SALIDA" Then
                cantidad = row.Cells("salida").Value.ToString()
            End If
            If Val(cantidad) = 0 Then Continue For

            cantidad = cantidad.PadLeft(5)

            Dim unidad As String = row.Cells("codigo").Value.ToString()

            ' Obtener el valor de las columnas "codigo" y "fecvcto" para la fila actual
            Dim codigo As String = row.Cells("codigo").Value.ToString()
            ' Uniformar el valor de "codigo" a 10 caracteres llenando con espacios en blanco a la derecha
            codigo = codigo.PadRight(10)
            Dim fecvcto As String = Format(CDate(row.Cells("fecvcto").Value.ToString()), "MM/yyyy")


            ' Combina los valores con un salto de línea y agrega al resultado
            resultado.AppendLine(cantidad & " [" & codigo & " " & fecvcto & "]")
        Next
        Dim cadenaFinal As String = resultado.ToString()
        'Stop
        'codigo
        'fecvcto

        'GuardaLotesCadena_formato = ""
        'Dim detalle As String = ""
        'For Each row As DataGridViewRow In wdt_grid.Rows
        '    For Each cell As DataGridViewCell In row.Cells

        '    Next
        'Next
        GuardaLotesCadena_formato = cadenaFinal
    End Function
    Private Sub calculo_validalote()
        Dim wsuma As Double
        Dim wsumaer As String = ""
        Dim wflagfecvcto As String = ""
        Dim wflagfecFab As String = ""
        Dim wflagcodigo As String = ""
        'Iterar por cada fila en el DataGridView
        LblError.Text = ""
        FaltaDatos.SetError(CmdAceptar, "")
        If GridLoteProd.Visible = False Then Exit Sub
        If GridLoteProd.CurrentCell Is Nothing Then Exit Sub
        If LOTE_ES_BLOQUEADO = "1" Then Exit Sub


        wsuma = 0
        For i As Integer = 0 To GridLoteProd.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            If TipoRegistro = "INGRESO" Then
                wsuma = wsuma + Val(GridLoteProd.Rows(i).Cells("ingreso").Value)
            ElseIf TipoRegistro = "SALIDA" Then
                wsuma = wsuma + Val(GridLoteProd.Rows(i).Cells("salida").Value)
            End If
            If GridLoteProd.Rows(i).Cells("codigo").Value = "" Then
                wflagcodigo = "Fila: " & GridLoteProd.Rows(i).Cells("num").Value & " : Indicar Codigo"
                GoTo fin
            End If

            If GridLoteProd.Rows(i).Cells("fecvcto").Value = "" Then
                wflagfecvcto = "Fila: " & GridLoteProd.Rows(i).Cells("num").Value & " : Ingresar Fec.Vcto, Ejemplo: 31/05/2023,   05/2023 ó 05/23"
                GoTo fin
            End If
            'If GridLoteProd.Rows(i).Cells("fecvcto").Value < Format(lk_fecha_dia, "dd/MM/yyyy") And Val(GridLoteProd.Rows(i).Cells("id_loteser").Value) = 0 Then
            If CDate(GridLoteProd.Rows(i).Cells("fecvcto").Value) < CDate(lk_fecha_dia) And Val(GridLoteProd.Rows(i).Cells("id_loteser").Value) = 0 Then
                wflagfecvcto = "Fila: " & GridLoteProd.Rows(i).Cells("num").Value & " : Ingresar Fec.Vcto, Mayor a la del dia. "
                GoTo fin
            End If
            If GridLoteProd.Rows(i).Cells("fecfab").Value = "" Then
                GridLoteProd.Rows(i).Cells("fecfab").Value = Format(lk_fecha_dia, "dd/MM/yyyy")
                'wflagfecFab = "Fila: " & GridLoteProd.Rows(i).Cells("num").Value & " : Ingresar Fec.Fab."
                'GoTo fin
            End If



            If GridLoteProd.Rows(i).Cells("estado").Value = "1" Then
                GridLoteProd.Rows(i).Cells("nombreestado").Style.ForeColor = Color.Black
                GridLoteProd.Rows(i).Cells("nombreestado").Value = strNormal
            ElseIf GridLoteProd.Rows(i).Cells("estado").Value = "2" Then
                GridLoteProd.Rows(i).Cells("nombreestado").Value = strPorVencer
                GridLoteProd.Rows(i).Cells("nombreestado").Style.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorPorVender)
                GridLoteProd.Rows(i).Cells("nombreestado").Style.Font = New Font(GridLoteProd.DefaultCellStyle.Font, FontStyle.Bold)
            ElseIf GridLoteProd.Rows(i).Cells("estado").Value = "3" Then
                GridLoteProd.Rows(i).Cells("nombreestado").Value = strVencido
                GridLoteProd.Rows(i).Cells("nombreestado").Style.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorVencido)
                GridLoteProd.Rows(i).Cells("nombreestado").Style.Font = New Font(GridLoteProd.DefaultCellStyle.Font, FontStyle.Bold)
            End If
        Next
        If wsuma <> LOTE_CANTIDAD_LOTE Then
            wsumaer = "La Suma " & TipoRegistro & ", son diferentes (Dif.: " & Format(LOTE_CANTIDAD_LOTE - wsuma, "0") & " )"
            LblError.Text = wsumaer
            FaltaDatos.SetError(CmdAceptar, wsumaer)
        End If
fin:
        If wflagcodigo <> "" Then
            LblError.Text = wflagcodigo
            FaltaDatos.SetError(CmdAceptar, wflagcodigo)
        End If
        If wflagfecvcto <> "" Then
            LblError.Text = wflagfecvcto
            FaltaDatos.SetError(CmdAceptar, wflagfecvcto)
        End If
        If wflagfecFab <> "" Then
            LblError.Text = wflagfecFab
            FaltaDatos.SetError(CmdAceptar, wflagfecFab)
        End If

        'If ultimafila = 0 Then Exit Sub
        ''If GridProductos.Rows.


    End Sub

    Private Sub GridLoteProd_Validating(sender As Object, e As CancelEventArgs) Handles GridLoteProd.Validating
        calculo_validalote()
    End Sub

    Private Sub GridLoteProd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridLoteProd.CellValueChanged

    End Sub

    Private Sub GridLoteProd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GridLoteProd.EditingControlShowing
        'Verificar si la celda actual es una celda de texto
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            'Agregar un controlador de eventos al evento KeyPress del control de edición de celda
            AddHandler e.Control.KeyPress, AddressOf GridLoteProd_KeyPress
        End If
    End Sub

    Private Sub GridLoteProd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridLoteProd.KeyPress
        Dim columnIndex As Integer = GridLoteProd.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
        Dim columnName As String = GridLoteProd.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
        Dim rowIndex As Integer = GridLoteProd.CurrentCell.RowIndex ' Obtener el índice de la fila actual
        If columnName = "codigo" Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

    End Sub

    Private Sub GridLoteProd_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridLoteProd.CellDoubleClick
        If e.ColumnIndex = GridLoteProd.Columns("add").Index AndAlso e.RowIndex >= 0 Then
            SendKeys.Send("{ENTER}")
        End If
        If e.ColumnIndex = GridLoteProd.Columns("eli").Index AndAlso e.RowIndex >= 0 Then

            SendKeys.Send("{ENTER}")
        End If
    End Sub

    Private Sub GridLoteProd_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles GridLoteProd.CurrentCellDirtyStateChanged
        Dim wvalor As String = GridLoteProd.CurrentCell.Value

        Dim windesfila As Integer = GridLoteProd.CurrentCell.RowIndex
        Dim columnName As String = GridLoteProd.Columns(GridLoteProd.CurrentCell.ColumnIndex).Name


        If columnName = "ingreso" Then
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("ingreso_kardex").Value = Val(wvalor) * LOTE_EQUIV_PRES
        End If
        If columnName = "salida" Then
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("salida_kardex").Value = Val(wvalor) * LOTE_EQUIV_PRES
        End If


        Dim rowIndex As Integer = GridLoteProd.CurrentCell.RowIndex ' Obtener el índice de la fila actual
        'If GridLoteProd.Rows(rowIndex).Cells("codigo").Value <> "" Then
        '    GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("fecvcto").Value = ""
        '    GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("stock").Value = ""
        '    GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("estado").Value = ""
        '    GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("fecfab").Value = ""
        '    GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("id_loteser").Value = ""
        '    GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("estado").Value = "1"
        '    GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("codigo_ok").Value = "" 'dato de control cuando es correcto el codigo
        'End If
        'If GridLoteProd.Rows(rowIndex).Cells("codigo_ok").Value <> "" Then
        '    If GridLoteProd.Rows(rowIndex).Cells("codigo_ok").Value <> GridLoteProd.Rows(rowIndex).Cells("codigo").Value Then
        '        ' GridLoteProd.Rows(rowIndex).Cells("codigo").Value = GridLoteProd.Rows(rowIndex).Cells("codigo_ok").Value
        '    End If

        'End If
    End Sub

    Private Sub GridLoteProd_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridLoteProd.CellEnter
        If Val(GridLoteProd.Rows(e.RowIndex).Cells("id_loteser").Value) <> 0 Then ' usuario no pulso Enter debe pulsar para buscar si exite o no

            GridLoteProd.Columns("codigo").ReadOnly = True
            GridLoteProd.Columns("fecvcto").ReadOnly = True
            GridLoteProd.Columns("fecfab").ReadOnly = True
            Exit Sub
        End If

        'If GridLoteProd.Rows(e.RowIndex).Cells("codigo_ok").Value <> "" Then
        If Val(GridLoteProd.Rows(e.RowIndex).Cells("id_loteser").Value) = 0 Then
            GridLoteProd.Columns("fecvcto").ReadOnly = False
            GridLoteProd.Columns("fecfab").ReadOnly = False
            GridLoteProd.Columns("codigo").ReadOnly = False
        End If

    End Sub

    Private Sub GridLoteProd_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles GridLoteProd.CellBeginEdit
        Dim columnName As String = GridLoteProd.Columns(GridLoteProd.CurrentCell.ColumnIndex).Name
        If columnName = "codigo" Then
            'GridLoteProd.Rows(e.RowIndex).Cells("fecvcto").Value = ""
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("fecvcto").Value = ""
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("stock").Value = ""
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("estado").Value = ""
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("fecfab").Value = ""
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("id_loteser").Value = ""
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("estado").Value = "1"
            GridLoteProd.Rows(GridLoteProd.CurrentCell.RowIndex).Cells("codigo_ok").Value = "" 'dato de control cuando es correcto el codigo

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class