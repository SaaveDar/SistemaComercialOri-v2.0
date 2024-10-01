Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp

Public Class FrmEnlacesComp

    Public Property Enlace_ref_codigo_comp As String
    Public Property Enlace_ref_serie_comp As String
    Public Property Enlace_ref_numero_comp As String
    Public Property Enlace_ref_fecha_comp As String



    Public Property FORM_id_tb_oper As Integer
    Public Property FORM_estado As Integer

    Public Property FORM_tipo_transf_kardex As Integer
    Public Property FORM_es_otros_comp As Integer
    Public Property FORM_es_canje_comp As Integer

    Public Property FORM_quitar_estado As Integer

    Public Property FORM_id_almacen_transf As Integer

    Public Property FORM_id_local As Integer






    Public Property FORM_DAtaEnlace As New DataTable

    Dim loc_datos_comp As New DataTable()
    Dim loc_groupedData
    Dim DataSeleccion As New DataTable()


    Private Sub FrmEnlacesComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CERRAR_SESIONES()
        'ConexionSQL_Maester()
        'ConexionSQL_Cuentas()
        'Carga_Paramtros_Generales()
        TxtFechaIni.Value = lk_fecha_dia.AddMonths(-3)
        TxtFechaFin.Value = lk_fecha_dia




        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        ActualizarColores()


        ' IconButton1_Click(Nothing, Nothing)
        Iniciar_DataSeleccion()

        Inicia_CabeceraComp()
        Inicia_DetalleComp()
        Inicia_GridComp()

        Muestra_Comprobantes_Eenlazar()





    End Sub
    Private Sub Muestra_Comprobantes_Eenlazar()
        Dim wfechaini As Date
        Dim wfechafin As Date
        wfechaini = TxtFechaIni.Value
        wfechafin = TxtFechaFin.Value

        GridCabeceraComp.Tag = ""
        GridCabeceraComp.Rows.Clear()
        GrdDetalle.Rows.Clear()
        Dim wquitar_estado As Integer = 0
        Dim wes_otros_comp As Integer = 0
        Dim wes_comp_canje As Integer = 0


        wes_otros_comp = FORM_es_otros_comp
        wes_comp_canje = FORM_es_canje_comp
        wquitar_estado = FORM_quitar_estado




        Traer_Comprobantes(wfechaini, wfechafin, lk_NegocioActivo.id_Negocio, FORM_id_tb_oper, wquitar_estado, wes_otros_comp, FORM_tipo_transf_kardex, FORM_id_almacen_transf, wes_comp_canje, FORM_id_local) ' envia3 como esatdo para que excluya los cerrados

        Dim witems As Integer = 0
        For Each item In loc_groupedData
            Me.GridCabeceraComp.Rows.Add()
            witems = witems + 1
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("num").Value = witems
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("tda").Value = item.local_codigo & " " & item.local_abreviado.ToString.Trim
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("fec_proc").Value = Format(item.fecha, "dd/MM/yyyy")
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("oper").Value = item.oper_codigo & " " & item.oper_nom_oper.ToString.Trim
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("comp").Value = item.comp_abreviado.ToString.Trim
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("serie").Value = item.serie_comp.ToString.Trim
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("numero").Value = Format(item.numero_comp, "00000000")
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("socio").Value = item.sn_razonsocial.ToString.Trim
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("moneda").Value = item.mod_simbolo.ToString.Trim
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("valor_grab").Value = Val(item.valor_gravado)
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("valor_nograb").Value = item.valor_nogravado
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("valor_exo").Value = item.valor_exonerado
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("impto").Value = item.impto
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("total").Value = item.total
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("condicion").Value = ""
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("usuario").Value = item.usuario
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("hora").Value = "00.00"

            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("id_negocio").Value = item.id_negocio
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("id_oper_maestro").Value = item.id_oper_maestro
            GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("id_comp_cab").Value = item.id_comp_cabe

        Next
        GridCabeceraComp.Tag = "TERMINADO" ' temrino llenado
    End Sub

    Private Sub Traer_Comprobantes(wfechaini As Date, wfechafin As Date, wid_negocio As Integer, wid_tb_oper As Integer, westado As Integer, wes_otros_comp As Integer, wes_recepcion As Integer, wid_almacen_recep As Integer, wes_comp_canje As Integer, ws_id_local As Integer)

        Dim sql As String = "exec [sp_buscar_comprobantes] @id_negocio, @fechaini, @fechafin ,@bus_id_tb_oper, @bus_estado,@es_otros_comp ,  @es_recepcion ,@id_almacen_recep,@es_comp_canje,@id_local "
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        command.Parameters.AddWithValue("@id_negocio", wid_negocio)
        command.Parameters.AddWithValue("@fechaini", wfechaini.ToString(lk_formatoFechabd)) ' Format(wfechaini, "yyyy/MM/dd"))
        command.Parameters.AddWithValue("@fechafin", wfechafin.ToString(lk_formatoFechabd))  ' Format(wfechafin, "yyyy/MM/dd"))
        command.Parameters.AddWithValue("@bus_id_tb_oper", wid_tb_oper)
        command.Parameters.AddWithValue("@bus_estado", westado)
        command.Parameters.AddWithValue("@es_otros_comp", wes_otros_comp)
        command.Parameters.AddWithValue("@es_recepcion", wes_recepcion)
        command.Parameters.AddWithValue("@id_almacen_recep", wid_almacen_recep)
        command.Parameters.AddWithValue("@es_comp_canje", wes_comp_canje)
        command.Parameters.AddWithValue("@id_local", ws_id_local)


        Dim adapter As New SqlDataAdapter(command)
        loc_datos_comp = New DataTable()
        adapter.Fill(loc_datos_comp)
        Dim tempColumn As DataColumn
        tempColumn = New DataColumn("canti_solicita", GetType(Double))
        tempColumn.DefaultValue = 0
        loc_datos_comp.Columns.Add(tempColumn)

        If loc_datos_comp.Rows.Count = 0 Then

        End If


        ' Agrupar registros por las columnas "id_negocio", "id_oper_maestro" y "id_comp_cabe"
        loc_groupedData = From row In loc_datos_comp.AsEnumerable()
                          Group row By key = New With {
                              Key .id_negocio = row.Field(Of Integer)("id_negocio"),
                              Key .id_oper_maestro = row.Field(Of Integer)("id_oper_maestro"),
                              Key .id_comp_cabe = row.Field(Of Integer)("id_comp_cab")
                          } Into Group
                          Select New With {
                                 .id_negocio = key.id_negocio,
                                 .id_oper_maestro = key.id_oper_maestro,
                                 .id_comp_cabe = key.id_comp_cabe,
                                 .fecha = Group.First().Field(Of Date)("fecha"),
                                  .nivel_comp = Group.First().Field(Of Byte)("nivel_comp"),
                                 .id_local = Group.First().Field(Of Integer)("id_local"),
                                 .local_codigo = Group.First().Field(Of String)("local_codigo"),
                                 .local_abreviado = Group.First().Field(Of String)("local_abreviado"),
                                 .id_tb_oper = Group.First().Field(Of Integer)("id_tb_oper"),
                                .oper_codigo = Group.First().Field(Of String)("oper_codigo"),
                                .oper_nom_oper = Group.First().Field(Of String)("oper_nom_oper"),
                                .oper_nom_tipooper = Group.First().Field(Of String)("oper_nom_tipooper"),
                                .id_comprobante = Group.First().Field(Of Integer)("id_comprobante"),
                                .comp_abreviado = Group.First().Field(Of String)("comp_abreviado"),
                                .comp_descrip = Group.First().Field(Of String)("comp_descrip"),
                                .serie_comp = Group.First().Field(Of String)("serie_comp"),
                                .numero_comp = Group.First().Field(Of Decimal)("numero_comp"),
                                .id_sn_master = Group.First().Field(Of Integer)("id_sn_master"),
                                .sn_codigo = Group.First().Field(Of String)("sn_codigo"),
                                .sn_tipodoc = Group.First().Field(Of String)("sn_tipodoc"),
                                .sn_numerodoc = Group.First().Field(Of String)("sn_numerodoc"),
                                .sn_comercial = Group.First().Field(Of String)("sn_comercial"),
                                .sn_razonsocial = Group.First().Field(Of String)("sn_razonsocial"),
                                .mod_nombre = Group.First().Field(Of String)("mod_nombre"),
                                .mod_simbolo = Group.First().Field(Of String)("mod_simbolo"),
                                .valor_gravado = Group.First().Field(Of Decimal)("valor_gravado"),
                                .valor_nogravado = Group.First().Field(Of Decimal)("valor_nogravado"),
                                .valor_exonerado = Group.First().Field(Of Decimal)("valor_exonerado"),
                                .impto = Group.First().Field(Of Decimal)("impto"),
                                .total = Group.First().Field(Of Decimal)("total"),
                                .usuario = Group.First().Field(Of String)("usuario"),
                                .nombreusuario = Group.First().Field(Of String)("nombreusuario"),
                                .apellidos = Group.First().Field(Of String)("apellidos"),
                                .modo_calculo = Group.First().Field(Of Short)("modo_calculo"),
                                .dt_es_control_lote = Group.First().Field(Of Byte)("dt_es_control_lote"),
                                .id_tipodoc = Group.First().Field(Of Integer)("id_tipodoc"),
                                .comp_codigo = Group.First().Field(Of String)("comp_codigo"),
                                .dt_lab_linea = Group.First().Field(Of String)("dt_lab_linea"),
                                .dt_es_inventariable = Group.First().Field(Of Byte)("dt_es_inventariable"),
                                .dt_id_almacen = Group.First().Field(Of Integer)("dt_id_almacen"),
                                .dt_alm_codigo = Group.First().Field(Of String)("dt_alm_codigo"),
                                .dt_alm_abreviado = Group.First().Field(Of String)("dt_alm_abreviado"),
                                .dt_stockactual = Group.First().Field(Of Decimal)("dt_stockactual")
                                  }
    End Sub

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

    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click
        WindowState = FormWindowState.Minimized
        Me.Text = ""
        Me.ControlBox = True

    End Sub

    Private Sub CmdRestaurar_Click(sender As Object, e As EventArgs) Handles CmdRestaurar.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Inicia_CabeceraComp()
        Me.GridCabeceraComp.Rows.Add()
        GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("tda").Value = "019"
        Me.GridCabeceraComp.Rows.Add()
        GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("tda").Value = "019"
        Me.GridCabeceraComp.Rows.Add()
        GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("tda").Value = "019"
        Me.GridCabeceraComp.Rows.Add()
        GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("tda").Value = "019"

        Me.GridCabeceraComp.CurrentCell = GridCabeceraComp.Rows(GridCabeceraComp.Rows.Count - 1).Cells("tda")
        Me.GridCabeceraComp.BeginEdit(True)

        For Each fila As DataGridViewRow In GridCabeceraComp.Rows
            fila.Cells("tod").Value = True ' Marcar la casilla de verificación en la columna "CheckColumn"
        Next


        Inicia_DetalleComp()

        Inicia_ArmaComp()




    End Sub
    Public Sub Inicia_CabeceraComp()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        GridCabeceraComp.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        GridCabeceraComp.Columns.Clear()
        GridCabeceraComp.DefaultCellStyle.Font = New Font("Segoe UI", 9.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "tod"
        checkColumn.HeaderText = "TODO"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(checkColumn)
        GridCabeceraComp.Columns.Item(checkColumn.Name).Width = 25
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridCabeceraComp.Columns.Item(checkColumn.Name).ReadOnly = False
        GridCabeceraComp.Columns.Item(checkColumn.Name).Visible = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "par"
        checkColumn.HeaderText = "PARC"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(checkColumn)
        GridCabeceraComp.Columns.Item(checkColumn.Name).Width = 25
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GridCabeceraComp.Columns.Item(checkColumn.Name).ReadOnly = False
        GridCabeceraComp.Columns.Item(checkColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "tda"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "TDA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 40
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fec_proc"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "FEC.PROC"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 75
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "oper"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "OPERAC."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 60
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "comp"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "TIPCOMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 50
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 45
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 70
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "socio"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "SOCIO NEGOCIO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 120
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "MOND"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 25
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "total"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "TOTAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).MinimumWidth = 68
        GridCabeceraComp.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 70
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "impto"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "IMPTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).MinimumWidth = 68
        GridCabeceraComp.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 70
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valor_exo"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "VALOR EXO."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).MinimumWidth = 68
        GridCabeceraComp.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 70
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valor_nograb"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "VALOR NO G."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).MinimumWidth = 68
        GridCabeceraComp.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 70
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valor_grab"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "VALOR G."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).MinimumWidth = 68
        GridCabeceraComp.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 70
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "condicion"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "CONDIC"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 60
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "usuario"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "USUARIO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 60
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hora"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "HOAR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 60
        GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = True



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_negocio"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "id_negocio"
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "id_oper_maestro"
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "id_comp_cab"
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "modo_calculo"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "modo_calculo"
        GridCabeceraComp.Columns.Add(textoColumn)
        GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = False



        'imageColumn.HeaderText = "*"
        'imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'imageColumn.Name = "eli"
        'imageColumn.Image = My.Resources.add
        'imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        'GridCabeceraComp.Columns.Add(imageColumn)
        'GridCabeceraComp.Columns.Item(imageColumn.Name).Width = 30
        'GridCabeceraComp.Columns.Item(imageColumn.Name).ReadOnly = False

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "Unidades"
        'textoColumn.Tag = "Unidades"
        'textoColumn.HeaderText = "Guarda unidades"
        'GridCabeceraComp.Columns.Add(textoColumn)
        'GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 0
        'GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        'GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = False


        ' AREA DE TOTALES:
        ' Parabuscar control 

    End Sub

    Private Sub Inicia_DetalleComp()
        '        DETALLE
        '#		TOL	PAR	TIPO	DESCRIPCION PRODUCTO		CODIGO	ED CANTIDAD	ED. PRES	CANTIDAD	PRES	
        'PRECIO	DES1	DES2	PRECIO	V.IMPTO	SUBTOAL	

        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()

        ' Dim estiloFuente As Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)

        GrdDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        GrdDetalle.Columns.Clear()
        GrdDetalle.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "tod"
        checkColumn.HeaderText = "TODO"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GrdDetalle.Columns.Add(checkColumn)
        GrdDetalle.Columns.Item(checkColumn.Name).Width = 25
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GrdDetalle.Columns.Item(checkColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(checkColumn.Name).Visible = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "par"
        checkColumn.HeaderText = "PARC"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GrdDetalle.Columns.Add(checkColumn)
        GrdDetalle.Columns.Item(checkColumn.Name).Width = 25
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        GrdDetalle.Columns.Item(checkColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(checkColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "alm"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ALM"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 40
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "prod_codigo"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 50
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "prod_nombre"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "DESCRIPCION PRODUCTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 250
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cantidad"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "CANT. COMPR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,###.###" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 55
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "canti_aplica"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "CANT. APLICA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,###.###" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 55
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = False
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "canti_saldo"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "SALDO. COMPR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,###.###" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 55
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "pres"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "PRES."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 50
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "precio"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "PRECIO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00##" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 70
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "desc1"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "DESC.1"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "0.0#" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 40
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 70
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "desc2"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "DESC.2"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "0.0#" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 40
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 70
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "precio_neto"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "PRECIO NETO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00##" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 70
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "impto"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "IMPTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00##" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 70
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "subtotal"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "SUB TOTAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00##" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).MinimumWidth = 60
        GrdDetalle.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 70
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_negocio"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "id_negocio"
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 0
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "id_oper_maestro"
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 0
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "id_comp_cab"
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 0
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_det"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "id_comp_det"
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 0
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "dt_estado"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "dt_estado"
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 0
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "dt_estado_canje"
        textoColumn.Tag = "C"
        textoColumn.HeaderText = "dt_estado_canje"
        GrdDetalle.Columns.Add(textoColumn)
        GrdDetalle.Columns.Item(textoColumn.Name).Width = 0
        GrdDetalle.Columns.Item(textoColumn.Name).ReadOnly = True
        GrdDetalle.Columns.Item(textoColumn.Name).Visible = False






        'imageColumn.HeaderText = "*"
        'imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'imageColumn.Name = "eli"
        'imageColumn.Image = My.Resources.add
        'imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        'GridCabeceraComp.Columns.Add(imageColumn)
        'GridCabeceraComp.Columns.Item(imageColumn.Name).Width = 30
        'GridCabeceraComp.Columns.Item(imageColumn.Name).ReadOnly = False

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "Unidades"
        'textoColumn.Tag = "Unidades"
        'textoColumn.HeaderText = "Guarda unidades"
        'GridCabeceraComp.Columns.Add(textoColumn)
        'GridCabeceraComp.Columns.Item(textoColumn.Name).Width = 0
        'GridCabeceraComp.Columns.Item(textoColumn.Name).ReadOnly = True
        'GridCabeceraComp.Columns.Item(textoColumn.Name).Visible = False


        ' AREA DE TOTALES:
        ' Parabuscar control 

    End Sub
    Private Sub Inicia_GridComp()
        '        DETALLE
        '#		TOL	PAR	TIPO	DESCRIPCION PRODUCTO		CODIGO	ED CANTIDAD	ED. PRES	CANTIDAD	PRES	
        'PRECIO	DES1	DES2	PRECIO	V.IMPTO	SUBTOAL	

        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        GridComp.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        GridComp.Columns.Clear()
        GridComp.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        Exit Sub






    End Sub


    Private Sub Inicia_ArmaComp()
        '        NUEVO COOMPROBANTE                                                      
        '	TDA	FEC.PROC	OPERACIÓN	COMPROB	SERIE	NUMERO	CANT	PRES	DES1	DES2	PRECIO	V.IMPTO	SUBTOAL	

    End Sub
    Private previousValue As Boolean = False ' variable para almacenar el valor anterior de la casilla de verificación
    Private Sub GridCabeceraComp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCabeceraComp.CellContentClick






        ' Verificar si la celda que se hizo clic es una casilla de verificación



        '' Verificar si la celda que se hizo clic es una casilla de verificación
        'If TypeOf GridCabeceraComp.Rows(e.RowIndex).Cells(e.ColumnIndex) Is DataGridViewCheckBoxCell Then
        '    ' Obtener el valor actual de la casilla de verificación
        '    Dim isChecked As Boolean = CBool(GridCabeceraComp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

        '    ' Verificar si el valor ha cambiado
        '    If isChecked <> previousValue Then
        '        ' Actualizar la variable previousValue con el valor actual de la casilla de verificación
        '        previousValue = isChecked

        '        ' Realizar la acción correspondiente
        '        If isChecked Then
        '            MessageBox.Show("La casilla de verificación ha sido marcada.")
        '        Else
        '            MessageBox.Show("La casilla de verificación ha sido desmarcada.")
        '        End If
        '    End If
        'End If



    End Sub

    Private Sub GridCabeceraComp_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridCabeceraComp.CellValueChanged
        TxtBuscaProducto.Text = Rnd(100)


    End Sub

    Private Sub GridCabeceraComp_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles GridCabeceraComp.CellBeginEdit




    End Sub



    Private Sub GridCabeceraComp_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridCabeceraComp.RowEnter
        If GridCabeceraComp.Columns.Count < 2 Then Exit Sub
        If GridCabeceraComp.Tag = "" Then Exit Sub
        Dim wid_negocio As Integer = GridCabeceraComp.Rows(e.RowIndex).Cells("id_negocio").Value
        Dim wid_oper_maestro As Integer = GridCabeceraComp.Rows(e.RowIndex).Cells("id_oper_maestro").Value
        Dim wid_comp_cab As Integer = GridCabeceraComp.Rows(e.RowIndex).Cells("id_comp_cab").Value
        ' MsgBox(GridCabeceraComp.Rows(e.RowIndex).Cells("socio").Value)

        Dim Result As String
        Dim DetalleComp() As DataRow = loc_datos_comp.Select("id_negocio = " & wid_negocio & " and  id_oper_maestro = " & wid_oper_maestro & " and  id_comp_cab  = " & wid_comp_cab & "")
        ' Recorremos las filas filtradas
        GrdDetalle.Rows.Clear()
        If DetalleComp.Length = 0 Then
            Result = MensajesBox.Show("Existe un Problema de Conexion Intentar mas tarde.",
                                     "Operación.")
            Exit Sub
        End If
        Inicia_DetalleComp()


        ' Exit Sub
        Dim wsaldo As Double

        For Each row As DataRow In DetalleComp
            GrdDetalle.Rows.Add()
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("alm").Value = row("dt_alm_codigo") & " " & row("dt_alm_abreviado")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("prod_codigo").Value = row("dt_prod_codigo")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("prod_nombre").Value = row("dt_nombreproducto")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("cantidad").Value = (row("dt_cantidad") / row("dt_equiv"))

            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("canti_aplica").Value = row("canti_solicita")

            wsaldo = (row("dt_cantidad") - row("cantidad_aplicada")) / row("dt_equiv")
            '            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("canti_saldo").Value = Format((Val(row("dt_cantidad")) - Val(row("cantidad_aplicada")) / Val(row("dt_equiv"))), "#,##0")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("canti_saldo").Value = Format(wsaldo, "#,##0")

            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("pres").Value = row("dt_descrip_pres")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("precio").Value = row("dt_precio")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("desc1").Value = 0
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("desc2").Value = 0
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("precio_neto").Value = row("dt_precio")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("impto").Value = row("dt_impto")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("subtotal").Value = row("dt_subtotal")

            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("id_negocio").Value = row("id_negocio")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("id_oper_maestro").Value = row("id_oper_maestro")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("id_comp_cab").Value = row("id_comp_cab")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("id_comp_det").Value = row("id_comp_det")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("dt_estado").Value = row("dt_estado")
            GrdDetalle.Rows(GrdDetalle.Rows.Count - 1).Cells("dt_estado_canje").Value = row("dt_estado_canje")


        Next

        Dim wtod_isChecked As Boolean = False
        Dim wpar_isChecked As Boolean = False
        wtod_isChecked = GridCabeceraComp.Rows(e.RowIndex).Cells("tod").Value
        wpar_isChecked = GridCabeceraComp.Rows(e.RowIndex).Cells("par").Value

        ValidaFilasDetalle(wtod_isChecked, wpar_isChecked, e.RowIndex)



    End Sub



    Private Sub GridCabeceraComp_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GridCabeceraComp.CellValidating



    End Sub

    Private Sub GridCabeceraComp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GridCabeceraComp.CellEndEdit
        ' Stop

    End Sub
    Private Sub ValidaFilasDetalle(Tod_isChecked As Boolean, Par_isChecked As Boolean, wfilaindex As Integer)


        If Par_isChecked = False And Tod_isChecked = False Then
            GridCabeceraComp.Columns("tod").ReadOnly = False
            GridCabeceraComp.Columns("par").ReadOnly = False
        End If
        If Par_isChecked Then
            GridCabeceraComp.Columns("tod").ReadOnly = True
            GridCabeceraComp.Columns("par").ReadOnly = False
        End If
        If Tod_isChecked Then
            GridCabeceraComp.Columns("tod").ReadOnly = False
            GridCabeceraComp.Columns("par").ReadOnly = True
        End If



        For Each fila As DataGridViewRow In GrdDetalle.Rows
            If Tod_isChecked Then
                fila.Cells("tod").Value = True
                fila.Cells("par").Value = False
                '  fila.Cells("canti_aplica").Value = Format(Val(fila.Cells("cantidad").Value) - Val(fila.Cells("canti_saldo").Value), "#,###")
                fila.Cells("canti_aplica").Value = Format(Val(fila.Cells("canti_saldo").Value), "#,###")
            Else
                fila.Cells("tod").Value = False
                If Par_isChecked = False Then fila.Cells("canti_aplica").Value = ""
            End If
            If Par_isChecked Then
                fila.Cells("tod").Value = False
                fila.Cells("par").Value = True
                '  fila.Cells("canti_aplica").Value = ""
            Else
                fila.Cells("par").Value = False
            End If
        Next


        ArmaComprobante(wfilaindex)
    End Sub
    Private Sub Iniciar_DataSeleccion()
        DataSeleccion.Columns.Clear()
        DataSeleccion.Columns.Add("id_negocio", GetType(Integer))
        DataSeleccion.Columns.Add("id_enlace", GetType(Integer))
        DataSeleccion.Columns.Add("numsec", GetType(Integer))
        DataSeleccion.Columns.Add("id_local_base", GetType(Integer))
        DataSeleccion.Columns.Add("id_oper_maestro_base", GetType(Integer))

        DataSeleccion.Columns.Add("tipo_comp", GetType(String))
        DataSeleccion.Columns.Add("serie_comp", GetType(String))
        DataSeleccion.Columns.Add("numero_comp", GetType(String))

        DataSeleccion.Columns.Add("id_comp_cab_base", GetType(Integer))
        DataSeleccion.Columns.Add("id_comp_det_base", GetType(Integer))
        DataSeleccion.Columns.Add("id_almacen_base", GetType(Integer))
        DataSeleccion.Columns.Add("fecha", GetType(DateTime))
        DataSeleccion.Columns.Add("id_prod_mae", GetType(Double))
        DataSeleccion.Columns.Add("codigo_prod_mae", GetType(String))
        DataSeleccion.Columns.Add("nombre_prod_mae", GetType(String))
        DataSeleccion.Columns.Add("cantidad", GetType(Double))
        DataSeleccion.Columns.Add("equiv", GetType(Integer))
        DataSeleccion.Columns.Add("descrip_pres", GetType(String))
        DataSeleccion.Columns.Add("id_pres", GetType(Integer))
        DataSeleccion.Columns.Add("signo_kardex", GetType(Integer))
        DataSeleccion.Columns.Add("id_local_dest", GetType(Integer))
        DataSeleccion.Columns.Add("id_oper_maestro_dest", GetType(Integer))
        DataSeleccion.Columns.Add("id_comp_cab_dest", GetType(Integer))
        DataSeleccion.Columns.Add("situacion", GetType(Integer))
        DataSeleccion.Columns.Add("estado", GetType(Integer))

        DataSeleccion.Columns.Add("dt_abreviado_pres_base", GetType(String))
        DataSeleccion.Columns.Add("dt_id_pres_base", GetType(Integer))
        DataSeleccion.Columns.Add("dt_equiv_base", GetType(Integer))

        DataSeleccion.Columns.Add("precio", GetType(Double))
        DataSeleccion.Columns.Add("nivel_comp", GetType(Integer))
        DataSeleccion.Columns.Add("id_sn_master", GetType(Integer))
        DataSeleccion.Columns.Add("sn_codigo", GetType(String))
        DataSeleccion.Columns.Add("sn_boxsn", GetType(String))
        DataSeleccion.Columns.Add("modo_calculo", GetType(Integer))
        DataSeleccion.Columns.Add("maeprod_es_control_lote", GetType(Integer))
        DataSeleccion.Columns.Add("id_tipodoc", GetType(Integer))
        DataSeleccion.Columns.Add("dt_lab_linea", GetType(String))
        DataSeleccion.Columns.Add("dt_es_inventariable", GetType(Integer))
        DataSeleccion.Columns.Add("dt_id_almacen", GetType(Integer))
        DataSeleccion.Columns.Add("dt_alm_codigo", GetType(String))
        DataSeleccion.Columns.Add("dt_alm_abreviado", GetType(String))
        DataSeleccion.Columns.Add("dt_stockactual", GetType(Double))




    End Sub

    Private Sub ArmaComprobante(wfila As Integer)


        Dim Wtref_codigo As String = ""
        Dim Wtref_serie As String = ""
        Dim Wtref_numero As String = ""
        Dim Wtref_fecha As String = ""




        ' GridComp.Rows.Clear()
        For Each fila As DataGridViewRow In GridCabeceraComp.Rows

            Dim wid_negocio As Integer = fila.Cells("id_negocio").Value  ' GridCabeceraComp.Rows(wfila).Cells("id_negocio").Value
            Dim wid_oper_maestro As Integer = fila.Cells("id_oper_maestro").Value '  GridCabeceraComp.Rows(wfila).Cells("id_oper_maestro").Value
            Dim wid_comp_cab As Integer = fila.Cells("id_comp_cab").Value  ' GridCabeceraComp.Rows(wfila).Cells("id_comp_cab").Value
            Dim Result As String
            Dim rowsToDelete() As DataRow = DataSeleccion.Select("id_negocio = " & wid_negocio & " and id_oper_maestro_base  = " & wid_oper_maestro & " and id_comp_cab_base = " & wid_comp_cab & " ")
            For Each wrow As DataRow In rowsToDelete
                wrow.Delete()
            Next


            Dim DetalleComp() As DataRow = loc_datos_comp.Select("id_negocio = " & wid_negocio & " and  id_oper_maestro = " & wid_oper_maestro & " and  id_comp_cab  = " & wid_comp_cab & "")
            If DetalleComp.Length = 0 Then
                Result = MensajesBox.Show("Existe un Problema de Conexion Intentar mas tarde.",
                                         "Operación.")
                Exit Sub
            End If








            Dim wsec As Integer = 0
            Dim wcantidad As Double
            For Each row As DataRow In DetalleComp
                wsec = wsec + 1
                Dim addrow As DataRow = DataSeleccion.NewRow()
                If fila.Cells("tod").Value = False And fila.Cells("par").Value = False Then
                    row("canti_solicita") = 0
                    Continue For
                End If

                If fila.Cells("par").Value = True And Val(row("canti_solicita")) = 0 Then Continue For

                If fila.Cells("tod").Value = True Then
                    If (Val(row("dt_cantidad")) - Val(row("cantidad_aplicada"))) = 0 Then Continue For
                End If

                addrow.Item("id_negocio") = row("id_negocio")
                addrow.Item("id_enlace") = 1
                addrow.Item("numsec") = wsec
                addrow.Item("id_local_base") = row("id_local")
                addrow.Item("id_oper_maestro_base") = row("id_oper_maestro")

                addrow.Item("tipo_comp") = row("comp_abreviado")
                addrow.Item("serie_comp") = row("serie_comp")
                addrow.Item("numero_comp") = Format(row("numero_comp"), "00000000")

                Wtref_codigo = row("comp_codigo") & " " & row("comp_abreviado")
                Wtref_serie = row("serie_comp")
                Wtref_numero = row("numero_comp")
                Wtref_fecha = row("fecha")


                addrow.Item("id_comp_cab_base") = row("id_comp_cab")
                addrow.Item("id_comp_det_base") = row("id_comp_det")
                addrow.Item("id_almacen_base") = row("dt_id_almacen")
                addrow.Item("fecha") = row("fecha")
                addrow.Item("id_prod_mae") = row("dt_prod_codigo")
                addrow.Item("codigo_prod_mae") = row("dt_prod_codigo")
                addrow.Item("nombre_prod_mae") = row("dt_nombreproducto")

                If fila.Cells("tod").Value = True Then
                    wcantidad = (row("dt_cantidad") - row("cantidad_aplicada"))
                Else
                    wcantidad = row("canti_solicita") * row("dt_equiv")
                End If
                wcantidad = wcantidad / row("dt_equiv")

                addrow.Item("cantidad") = Format(wcantidad, "#,##0")
                addrow.Item("precio") = row("dt_precio")  'Format(row("dt_precio") / row("dt_equiv"), "0.000")
                addrow.Item("equiv") = row("dt_equiv") ' row("dt_equiv_base")
                addrow.Item("descrip_pres") = row("dt_descrip_pres") 'row("dt_abreviado_pres_base")


                'addrow.Item("equiv") = row("dt_equiv")
                'addrow.Item("descrip_pres") = row("dt_descrip_pres")


                addrow.Item("id_pres") = row("dt_id_pres")


                addrow.Item("signo_kardex") = 1
                addrow.Item("id_local_dest") = 0
                addrow.Item("id_oper_maestro_dest") = 0
                addrow.Item("id_comp_cab_dest") = 0
                addrow.Item("situacion") = 1
                addrow.Item("estado") = 1
                addrow.Item("dt_abreviado_pres_base") = row("dt_abreviado_pres_base")
                addrow.Item("dt_id_pres_base") = row("dt_id_pres_base")
                addrow.Item("dt_equiv_base") = row("dt_equiv_base")

                addrow.Item("nivel_comp") = row("nivel_comp")
                addrow.Item("id_sn_master") = row("id_sn_master")
                addrow.Item("sn_codigo") = row("sn_codigo")
                addrow.Item("sn_boxsn") = row("sn_boxsn")
                addrow.Item("modo_calculo") = row("modo_calculo")
                addrow.Item("maeprod_es_control_lote") = row("maeprod_es_control_lote")
                addrow.Item("id_tipodoc") = row("id_tipodoc")
                addrow.Item("dt_lab_linea") = row("dt_lab_linea")
                addrow.Item("dt_es_inventariable") = row("dt_es_inventariable")
                addrow.Item("dt_id_almacen") = row("dt_id_almacen")
                addrow.Item("dt_alm_codigo") = row("dt_alm_codigo")
                addrow.Item("dt_alm_abreviado") = row("dt_alm_abreviado")
                addrow.Item("dt_stockactual") = row("dt_stockactual")



                DataSeleccion.Rows.Add(addrow)

            Next

        Next

        tref_codigo.Text = Wtref_codigo
        tref_serie.Text = Wtref_serie
        tref_numero.Text = Wtref_numero
        tref_fecha.Text = Wtref_fecha


        llenaGridEnlace()

    End Sub
    Private Sub llenaGridEnlace()
        ' DataSeleccion


        GridComp.DataSource = DataSeleccion
        GridComp.Columns("id_almacen_base").Visible = False
        GridComp.Columns("id_negocio").Visible = False
        GridComp.Columns("id_enlace").Visible = False
        GridComp.Columns("numsec").Visible = False
        GridComp.Columns("id_local_base").Visible = False
        GridComp.Columns("id_oper_maestro_base").Visible = False
        GridComp.Columns("id_comp_cab_base").Visible = False
        GridComp.Columns("id_comp_det_base").Visible = False
        GridComp.Columns("fecha").Visible = False
        GridComp.Columns("id_prod_mae").Visible = False
        GridComp.Columns("equiv").Visible = False
        GridComp.Columns("id_pres").Visible = False
        GridComp.Columns("signo_kardex").Visible = False
        GridComp.Columns("id_local_dest").Visible = False
        GridComp.Columns("id_oper_maestro_dest").Visible = False
        GridComp.Columns("situacion").Visible = False
        GridComp.Columns("estado").Visible = False
        GridComp.Columns("id_comp_cab_dest").Visible = False

        GridComp.Columns("dt_abreviado_pres_base").Visible = False
        GridComp.Columns("dt_id_pres_base").Visible = False
        GridComp.Columns("dt_equiv_base").Visible = False
        GridComp.Columns("precio").Visible = True

        GridComp.Columns("nivel_comp").Visible = False
        GridComp.Columns("id_sn_master").Visible = False
        GridComp.Columns("sn_codigo").Visible = False
        GridComp.Columns("sn_boxsn").Visible = False

        GridComp.Columns("dt_lab_linea").Visible = False
        GridComp.Columns("dt_es_inventariable").Visible = False

        GridComp.Columns("dt_id_almacen").Visible = False
        GridComp.Columns("dt_alm_codigo").Visible = False
        GridComp.Columns("dt_alm_abreviado").Visible = False
        GridComp.Columns("dt_stockactual").Visible = False

        GridComp.Columns("modo_calculo").Visible = False
        GridComp.Columns("maeprod_es_control_lote").Visible = False
        GridComp.Columns("id_tipodoc").Visible = False





        GridComp.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)



        GridComp.Columns("tipo_comp").HeaderText = "TIPCOMP"
        GridComp.Columns("tipo_comp").Width = 60
        GridComp.Columns("tipo_comp").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)

        GridComp.Columns("serie_comp").HeaderText = "SERIE"
        GridComp.Columns("serie_comp").Width = 60
        GridComp.Columns("serie_comp").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)

        GridComp.Columns("numero_comp").HeaderText = "NUMERO"
        GridComp.Columns("numero_comp").Width = 60
        GridComp.Columns("numero_comp").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)



        GridComp.Columns("codigo_prod_mae").HeaderText = "CODIGO"
        GridComp.Columns("codigo_prod_mae").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        GridComp.Columns("codigo_prod_mae").Width = 60

        GridComp.Columns("nombre_prod_mae").HeaderText = "DESCRIPCION PRODUCTO"
        GridComp.Columns("nombre_prod_mae").Width = 200
        GridComp.Columns("nombre_prod_mae").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)

        GridComp.Columns("cantidad").HeaderText = "CANTIDAD"
        GridComp.Columns("cantidad").Width = 60
        GridComp.Columns("cantidad").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)

        GridComp.Columns("descrip_pres").HeaderText = "PRES."
        GridComp.Columns("descrip_pres").Width = 60
        GridComp.Columns("descrip_pres").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)

        GridComp.Columns("precio").HeaderText = "PRECIO"
        GridComp.Columns("precio").Width = 60
        GridComp.Columns("precio").HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)











    End Sub
    Private Sub GridCabeceraComp_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridCabeceraComp.CellEnter

    End Sub
    Private isEditing As Boolean = False
    Private Sub GridCabeceraComp_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles GridCabeceraComp.CurrentCellDirtyStateChanged
        If Not isEditing Then
            isEditing = True
            If GridCabeceraComp.IsCurrentCellDirty Then
                If TypeOf GridCabeceraComp.CurrentCell Is DataGridViewCheckBoxCell Then
                    GridCabeceraComp.CommitEdit(DataGridViewDataErrorContexts.Commit)
                End If
            End If






            Dim isChecked As Boolean = CBool(GridCabeceraComp.CurrentCell.Value)
            Dim Tod_isChecked As Boolean = False
            Dim Par_isChecked As Boolean = False
            Dim windesfila As Integer = GridCabeceraComp.CurrentCell.RowIndex
            Dim columnName As String = GridCabeceraComp.Columns(GridCabeceraComp.CurrentCell.ColumnIndex).Name

            If columnName = "tod" And isChecked Then
                Tod_isChecked = True
                If GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("par").Value Then
                    GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("par").Value = False
                    Par_isChecked = False
                End If
            End If
            If columnName = "par" And isChecked Then
                Par_isChecked = True
                If GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("tod").Value Then
                    GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("tod").Value = False
                    Tod_isChecked = False
                End If
            End If

            ValidaFilasDetalle(Tod_isChecked, Par_isChecked, windesfila)
            isEditing = False
        End If
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click




    End Sub

    Private Sub CmdGrabar_Click(sender As Object, e As EventArgs) Handles CmdGrabar.Click
        If GridComp.Rows.Count = 0 Then
            Dim Result As String = MensajesBox.Show("Debe Indicar o selecionar comprobantes, con sus cantidades respectivas.",
                                     "Enlazar Comprobantes.")
            Exit Sub
        End If

        FORM_DAtaEnlace = DataSeleccion
        Me.DialogResult = DialogResult.OK
        Enlace_ref_codigo_comp = tref_codigo.Text
        Enlace_ref_serie_comp = tref_serie.Text
        Enlace_ref_numero_comp = tref_numero.Text
        Enlace_ref_fecha_comp = tref_fecha.Text

        Me.Close()
    End Sub
    Private Sub ActualizarColores()
        'Dim Oscuro_primario1 As String = "#353641"
        Dim FondoPanelyForm As String = "#353641"
        Dim FondoBotones As String = "#444654"
        Dim FondoCajaTextoyLabel As String = "#444654"

        Dim ColorTextoyEtiq As String = "#FFFFFF"
        Dim gridletra As String = "#FFDE77"
        Dim wprueba As String = "#19B4B8"
        Dim Oscuro_secundario2 As String = "#353641"
        Dim ColorIconoBotones As String
        Dim ColorTexoBoton As String
        If lk_modoOscuro Then
            FondoPanelyForm = "#353641"
            FondoCajaTextoyLabel = "#444654"
            ColorTextoyEtiq = "#D4D4D8"
            gridletra = "#FFFFFF"
            FondoBotones = "#353641"
            ColorIconoBotones = "#FFFFFF"
            ColorTexoBoton = "#FFFFFF"
        Else
            FondoPanelyForm = "#F0F2F5"
            FondoCajaTextoyLabel = "#FFFFFF"
            ColorTextoyEtiq = "#000000"
            gridletra = "#000000"
            FondoBotones = "#FFFFFF"
            ColorIconoBotones = "#2F476D"
            ColorTexoBoton = "#2F476D"
        End If


        Me.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
        'Me.ForeColor = Color.White
        For Each panel As Panel In Me.Controls.OfType(Of Panel)()
            If panel.Name = "PanelSup" Then Continue For
            If panel.Name = "PanelListarOper" Then Continue For

            panel.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)

        Next
        For Each crtZonaDEt As Control In Panel1.Controls
            ' Código a ejecutar para cada control dentro de Panel1
            If TypeOf crtZonaDEt Is DataGridView Then
                Dim dgv As DataGridView = CType(crtZonaDEt, DataGridView)
                dgv.BackgroundColor = ColorTranslator.FromHtml(FondoPanelyForm)
                dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel) ' Cambiar el color de fondo de las celdas
                dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(gridletra)
            End If
            For Each iconBtn As IconButton In crtZonaDEt.Controls.OfType(Of IconButton)()
                ' Cambia el color de fondo del iconButton
                iconBtn.BackColor = ColorTranslator.FromHtml(FondoBotones)
                iconBtn.ForeColor = ColorTranslator.FromHtml(ColorTexoBoton)
                iconBtn.IconColor = ColorTranslator.FromHtml(ColorIconoBotones)

            Next

        Next
        For Each crtZonaDEt As Control In Panel4.Controls
            ' Código a ejecutar para cada control dentro de Panel1
            If TypeOf crtZonaDEt Is DataGridView Then
                Dim dgv As DataGridView = CType(crtZonaDEt, DataGridView)
                dgv.BackgroundColor = ColorTranslator.FromHtml(FondoPanelyForm)
                dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel) ' Cambiar el color de fondo de las celdas
                dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(gridletra)
            End If
        Next



        For Each pnl As Panel In Me.Controls.OfType(Of Panel)()
            If pnl.Name = "PanelSup" Then Continue For
            If pnl.Name = "PanelListarOper" Then Continue For
            ' Recorre todos los iconButton dentro de cada panel
            For Each iconBtn As IconButton In pnl.Controls.OfType(Of IconButton)()
                ' Cambia el color de fondo del iconButton
                iconBtn.BackColor = ColorTranslator.FromHtml(FondoBotones)
                iconBtn.ForeColor = ColorTranslator.FromHtml(ColorTexoBoton)
                iconBtn.IconColor = ColorTranslator.FromHtml(ColorIconoBotones)

            Next
            For Each label As Label In pnl.Controls.OfType(Of Label)()
                ' Cambia el color de fondo del iconButton
                label.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel)
                label.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
            Next
            For Each pnlbox As Panel In pnl.Controls.OfType(Of Panel)()
                If pnlbox.Name = "PanelListarOper" Then Continue For
                For Each iconBtn_box As IconButton In pnlbox.Controls.OfType(Of IconButton)()
                    ' Cambia el color de fondo del iconButton
                    iconBtn_box.BackColor = ColorTranslator.FromHtml(FondoBotones)
                    iconBtn_box.ForeColor = ColorTranslator.FromHtml(ColorTexoBoton)
                    iconBtn_box.IconColor = ColorTranslator.FromHtml(ColorIconoBotones)
                Next
                For Each Label_box As Label In pnlbox.Controls.OfType(Of Label)()
                    ' Cambia el color de fondo del iconButton
                    Label_box.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
                    Label_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next
                For Each Texto_box As TextBox In pnlbox.Controls.OfType(Of TextBox)()
                    ' Cambia el color de fondo del iconButton
                    Texto_box.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel)
                    Texto_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next
                For Each RichTexto_box As RichTextBox In pnlbox.Controls.OfType(Of RichTextBox)()
                    ' Cambia el color de fondo del iconButton
                    RichTexto_box.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel)
                    RichTexto_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next
                For Each RadioB_box As RadioButton In pnlbox.Controls.OfType(Of RadioButton)()
                    ' Cambia el color de fondo del iconButton
                    RadioB_box.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
                    RadioB_box.ForeColor = ColorTranslator.FromHtml(ColorTextoyEtiq)
                Next

                pnlbox.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)
            Next


        Next

        PanelSup.BackColor = ColorTranslator.FromHtml(strColorLogin)


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GrdDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdDetalle.CellContentClick

    End Sub

    Private Sub GrdDetalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GrdDetalle.CellEndEdit
        Dim wtod_isChecked As Boolean = False
        Dim wpar_isChecked As Boolean = False
        wtod_isChecked = GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("tod").Value
        wpar_isChecked = GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("par").Value

        If Val(GrdDetalle.Rows(e.RowIndex).Cells("canti_aplica").Value) > Val(GrdDetalle.Rows(e.RowIndex).Cells("canti_saldo").Value) Then
            GrdDetalle.Rows(e.RowIndex).Cells("canti_aplica").Value = ""
            ValidaFilasDetalle(wtod_isChecked, wpar_isChecked, e.RowIndex)
            Exit Sub
        End If
        Dim wid_negocio As Integer = GrdDetalle.Rows(e.RowIndex).Cells("id_negocio").Value
        Dim wid_oper_maestro As Integer = GrdDetalle.Rows(e.RowIndex).Cells("id_oper_maestro").Value
        Dim wid_comp_cab As Integer = GrdDetalle.Rows(e.RowIndex).Cells("id_comp_cab").Value
        Dim wid_comp_det As Integer = GrdDetalle.Rows(e.RowIndex).Cells("id_comp_det").Value

        Dim rowsToDelete() As DataRow = loc_datos_comp.Select("id_negocio = " & wid_negocio & " and id_oper_maestro  = " & wid_oper_maestro & " and id_comp_cab = " & wid_comp_cab & " and id_comp_det = " & wid_comp_det & "")
        For Each wrow As DataRow In rowsToDelete
            wrow("canti_solicita") = Val(GrdDetalle.Rows(e.RowIndex).Cells("canti_aplica").Value)

        Next


        ' wtod_isChecked = GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("tod").Value
        ' wpar_isChecked = GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("par").Value
        ValidaFilasDetalle(wtod_isChecked, wpar_isChecked, e.RowIndex)



    End Sub

    Private Sub GrdDetalle_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles GrdDetalle.CurrentCellDirtyStateChanged


        'If GrdDetalle.Rows(GrdDetalle.CurrentCell.RowIndex).Cells("tod").Value = False And GrdDetalle.Rows(GrdDetalle.CurrentCell.RowIndex).Cells("par").Value = False Then
        '    GrdDetalle.Columns("tod").ReadOnly = False
        '    GrdDetalle.Columns("par").ReadOnly = False
        'End If
        'If GrdDetalle.Rows(GrdDetalle.CurrentCell.RowIndex).Cells("par").Value Then
        '    GrdDetalle.Columns("tod").ReadOnly = True
        '    GrdDetalle.Columns("par").ReadOnly = False
        'End If
        'If GrdDetalle.Rows(GrdDetalle.CurrentCell.RowIndex).Cells("tod").Value Then
        '    GrdDetalle.Columns("tod").ReadOnly = False
        '    GrdDetalle.Columns("par").ReadOnly = True
        'End If


    End Sub

    Private Sub GrdDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrdDetalle.CellEnter

        If GrdDetalle.Rows(e.RowIndex).Cells("par").Value Then
            If GrdDetalle.Rows(e.RowIndex).Cells("dt_estado_canje").Value <> 0 Then

            End If
            'If GrdDetalle.Rows(e.RowIndex).Cells("dt_estado").Value = 3 Then
            ' GrdDetalle.Columns("canti_aplica").ReadOnly = True
            ' Else

            GrdDetalle.Columns("canti_aplica").ReadOnly = False
            '     End If
        Else
            GrdDetalle.Columns("canti_aplica").ReadOnly = True
        End If



        'If GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("tod").Value  = fase And GridCabeceraComp.Rows(GridCabeceraComp.CurrentCell.RowIndex).Cells("tod").Value Then

        '        End If

    End Sub

    Private Sub CmdCancelarOper_Click(sender As Object, e As EventArgs) Handles CmdCancelarOper.Click
        Me.DialogResult = DialogResult.Cancel
        Me.FORM_DAtaEnlace = Nothing
        Me.Close()
    End Sub

    Private Sub tref_codigo_TextChanged(sender As Object, e As EventArgs) Handles tref_codigo.TextChanged

    End Sub

    Private Sub tref_codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_codigo.KeyPress
        e.Handled = True
    End Sub

    Private Sub tref_serie_TextChanged(sender As Object, e As EventArgs) Handles tref_serie.TextChanged

    End Sub

    Private Sub tref_serie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_serie.KeyPress
        e.Handled = True
    End Sub

    Private Sub tref_numero_TextChanged(sender As Object, e As EventArgs) Handles tref_numero.TextChanged

    End Sub

    Private Sub tref_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_numero.KeyPress
        e.Handled = True
    End Sub

    Private Sub tref_fecha_TextChanged(sender As Object, e As EventArgs) Handles tref_fecha.TextChanged

    End Sub

    Private Sub tref_fecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tref_fecha.KeyPress
        e.Handled = True
    End Sub
End Class