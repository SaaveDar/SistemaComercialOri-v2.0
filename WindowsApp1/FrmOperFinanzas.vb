Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp

Public Class FrmOperFinanzas
    Public Property Enlace_signo_entidad As Integer

    Public Property FORM_DataFianzas As New DataTable

    Public Property FORM_DataFianzas_nc As New DataTable



    Public Property FORM_DatosFinanzas_Temp As New DataTable
    Public Property FORM_DatosFinanzas_NC_Temp As New DataTable

    Public Property FORM_Cadena_contenidos As String
    Public Property FORM_Estado As String
    Public Property FORM_valor_total As Double
    Public Property FORM_monto_aplicar As Double

    Public Property FORM_Tipo_Balance As Integer


    Public Property FORM_es_aplica_nc As Integer
    Public Property FORM_id_moneda As Integer

    Public Property FORM_id_local As Integer
    Public Property FORM_Lista_Cajas() As DataRow()


    Dim DataSeleccion As New DataTable()
    Dim DataSeleccion_NC As New DataTable()
    Private Sub PanelSup_Paint(sender As Object, e As PaintEventArgs) Handles PanelSup.Paint

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

    Private Sub CmdMin_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
        Me.Text = ""
        Me.ControlBox = True

    End Sub

    Private Sub CmdRestaurar_Click(sender As Object, e As EventArgs)
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmOperFinanzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CERRAR_SESIONES()
        'ConexionSQL_Maester()
        'ConexionSQL_Cuentas()
        'Carga_Paramtros_Generales()
        'Dim command As SqlCommand = New SqlCommand("u_login", lk_connection_master)
        'command.CommandType = CommandType.StoredProcedure
        'command.Parameters.AddWithValue("@usuario", "admin")
        'command.Parameters.AddWithValue("@clave", "1234")
        'Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        'adapter.Fill(lk_sql_ValidaUsuario)
        'lk_fecha_dia = Now
        'lk_id_usuario = lk_sql_ValidaUsuario.Rows(0)("id_usuario").ToString()
        'lk_usuario = lk_sql_ValidaUsuario.Rows(0)("Usuario").ToString()
        'lk_id_cuemta_user = lk_sql_ValidaUsuario.Rows(0)("id_cuenta_user").ToString()
        'lk_Carpeta_Temp = My.Computer.FileSystem.CurrentDirectory & "\user" & lk_id_usuario & "\"
        'My.Computer.FileSystem.CreateDirectory(lk_Carpeta_Temp)
        'lk_foto_perfil_id = 0
        'lk_id_cuemta_user = 1
        'Negocio_Local_Almacen_Usuario()
        'Carga_Paramtros_Negocio(lk_NegocioActivo.id_Negocio)




        Conexcion_finanzas(lk_NegocioActivo.id_Negocio)



        dg_cuentasn.AccessibleDescription = FORM_Tipo_Balance
        Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio<> 0 and es_monedalocal= 1 and id_moneda = " & FORM_id_moneda & "")
        ' Recorremos las filas filtradas
        If Monedas.Length = 0 Then
            Exit Sub
        End If
        CmdMonedaComp.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
        CmdMonedaComp.Tag = Monedas(0)("id_moneda")
        CmdMonedaComp.AccessibleName = Monedas(0)("simbolo")
        CmdMonedaComp.AccessibleDescription = Monedas(0)("es_monedalocal")
        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)

        Me.dg_finanzas.id_local_grid = FORM_id_local
        Dim ws_tipo_controlcaja As Integer = 0
        '--** situacion_tipo (  0 = En Pasivo no aperturada 
        '--** situacion_tipo (  1 = Caja Aperturada
        '--** situacion_tipo (  2 = Pre Cerrada
        '--** situacion_tipo (  3 = Cerrada
        dg_finanzas.Enabled = False
        dg_cuentasn.Rows.Clear()
        dg_cuentasn.Columns.Clear()

        If FORM_es_aplica_nc = 1 Then
            CheckNC.Enabled = True
        Else
            CheckNC.Enabled = False
        End If


        lblMontoAplicar.Tag = FORM_monto_aplicar
        lblMontoAplicar.Text = Format(FORM_monto_aplicar, "###,##0.00")
        If FORM_Estado = "bloq" Then
            CmdAceptar.Enabled = False
        End If
        'dg_finanzas.Columns.Clear()
        Iniciar_Fin()
        ActualizarColores()
        dg_finanzas.Rows.Clear()
        If FORM_Estado = "bloq" Then
            If FORM_DatosFinanzas_Temp Is Nothing Then
            Else
                If FORM_DatosFinanzas_Temp.Rows.Count = 0 Then Exit Sub
                Muestra_DatosGuardados(FORM_DatosFinanzas_Temp)

            End If
            Exit Sub
        End If
        If FORM_Lista_Cajas.Length <> 0 Then
            Dim windex_def As Integer = 0
            For i = 0 To FORM_Lista_Cajas.Length
                If FORM_Lista_Cajas(i)("id_local") = FORM_id_local Then
                    windex_def = i
                    Exit For
                End If
            Next

            CmdCajas.Text = FORM_Lista_Cajas(windex_def)("codigo").ToString.Trim & " " & FORM_Lista_Cajas(windex_def)("descripcion").ToString.Trim
            CmdCajas.Tag = FORM_Lista_Cajas(windex_def)("id_controlcaja_mae")
            LblEstadoCaja.Text = "SIN APERTURA..."
            LblEstadoCaja.Tag = "0"
            ws_tipo_controlcaja = FORM_Lista_Cajas(windex_def)("estado_det")
            CmdCajas.AccessibleName = ws_tipo_controlcaja
            dg_finanzas.Enabled = False
            dg_finanzas.Rows.Clear()

            If ws_tipo_controlcaja = 1 Then
                LblEstadoCaja.Text = formato_ListaCajas(ws_tipo_controlcaja, FORM_Lista_Cajas(windex_def)("fechahora_apertura"), FORM_Lista_Cajas(windex_def)("id_controlcaja_det"))
                LblEstadoCaja.Tag = FORM_Lista_Cajas(windex_def)("id_controlcaja_det")
                Iniciar_Fin()
                ActualizarColores()

                dg_finanzas.Enabled = True

                If FORM_DatosFinanzas_Temp Is Nothing Then
                Else
                    If FORM_DatosFinanzas_Temp.Rows.Count = 0 Then Exit Sub
                    Muestra_DatosGuardados(FORM_DatosFinanzas_Temp)

                End If
                If FORM_DatosFinanzas_NC_Temp Is Nothing Then
                Else
                    If FORM_DatosFinanzas_NC_Temp.Rows.Count = 0 Then Exit Sub
                    Muestra_DatosGuardados_NC(FORM_DatosFinanzas_NC_Temp)

                End If



            End If
        End If


    End Sub

    Private Sub Muestra_DatosGuardados_NC(datafn As DataTable)


        Exit Sub
        Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()

        Dim ws_id_tb_formas_fn As Integer = 0
        Dim ws_id_fn_maestro As Integer = 0
        Dim ws_id_moneda As Integer = 0
        Dim ws_simbolo As String = ""


        If datafn.Rows.Count > 0 Then
            CheckNC.Checked = True
            'ws_id_moneda = datafn.Rows(0).Item("id_moneda")
            'Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio <> 0 and es_monedalocal= 1 and id_moneda = " & ws_id_moneda & "")
            '' Recorremos las filas filtradas
            'If Monedas.Length = 0 Then
            'Else
            '    CmdMonedaComp.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
            '    CmdMonedaComp.Tag = Monedas(0)("id_moneda")
            '    CmdMonedaComp.AccessibleName = Monedas(0)("simbolo")
            '    CmdMonedaComp.AccessibleDescription = Monedas(0)("es_monedalocal")
            '    ws_simbolo = Monedas(0)("simbolo")
            'End If

            Me.dg_finanzas.Rows.Clear()

            For i = 0 To datafn.Rows.Count - 1
                Me.dg_finanzas.Rows.Add()
                ws_id_tb_formas_fn = datafn.Rows(i).Item("id_tb_formas_fn")
                ws_id_fn_maestro = datafn.Rows(i).Item("id_fn_maestro")

                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("id_tb_formas_fn").Value = ws_id_tb_formas_fn
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("id_fn_maestro").Value = ws_id_fn_maestro
                Dim reg_consulta() As DataRow = lk_sql_finanzas_local.Select("id_tb_formas_fn = " & ws_id_tb_formas_fn & " ")
                If reg_consulta.Length <> 0 Then
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("codigotipo").Value = reg_consulta(0)("forma_codigo")
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("descrip_tipo").Value = reg_consulta(0)("forma_des")
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("descrip_tipo").Tag = ws_id_tb_formas_fn

                End If
                Dim reg_consulta_fn() As DataRow = lk_sql_finanzas_local.Select("id_fn_maestro = " & ws_id_fn_maestro & " ")
                If reg_consulta_fn.Length <> 0 Then
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("codigo").Value = reg_consulta_fn(0)("fn_codigo")
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("descrip_entidad").Value = reg_consulta_fn(0)("fn_des")
                End If
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("moneda").Value = ws_simbolo

                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("nrodoc").Value = datafn.Rows(i).Item("nrodoc")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("ref").Value = datafn.Rows(i).Item("ref")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("total").Value = datafn.Rows(i).Item("total")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("fecha").Value = Format(datafn.Rows(i).Item("fecha_fn"), "dd/MM/yyyy")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("id_negocio").Value = datafn.Rows(i).Item("id_negocio")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("signo_fn").Value = datafn.Rows(i).Item("signo_fn")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("total").Value = datafn.Rows(i).Item("total")
                If FORM_Estado = "bloq" Then
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("ok").Value = My.Resources.bloq
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("ok").Tag = "bloq"

                End If


            Next
            Contador_filas()
        End If
    End Sub


    Private Sub Muestra_DatosGuardados(datafn As DataTable)
        GridFinanzas_Inicia()




        Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()


        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        'temp_finanzas.DefaultView.Sort = "fn_codigo"
        'Dim filtro As String = "id_tb_formas_fn = " & wd_forma & " and id_moneda = " & wd_id_moneda & " "


        'Dim reg_consulta() As DataRow = lk_sql_finanzas_local.Select("id_tb_formas_fn = " & 0 & " and es_interno = 0 and codigo='" & 0 & "'")
        'If reg_consulta.Length = 0 Then
        '    ' Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
        '    '                         "Local.")
        '    '  CmdLocal_Click(Nothing, Nothing)
        '    'Exit Function
        'End If
        '' TxtComp_codigo.Text = Comprobantes(0)("codigo")

        Dim ws_id_tb_formas_fn As Integer = 0
        Dim ws_id_fn_maestro As Integer = 0
        Dim ws_id_moneda As Integer = 0
        Dim ws_simbolo As String = ""


        If datafn.Rows.Count > 0 Then
            ws_id_moneda = datafn.Rows(0).Item("id_moneda")
            Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio <> 0 and es_monedalocal= 1 and id_moneda = " & ws_id_moneda & "")
            ' Recorremos las filas filtradas
            If Monedas.Length = 0 Then
            Else
                CmdMonedaComp.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
                CmdMonedaComp.Tag = Monedas(0)("id_moneda")
                CmdMonedaComp.AccessibleName = Monedas(0)("simbolo")
                CmdMonedaComp.AccessibleDescription = Monedas(0)("es_monedalocal")
                ws_simbolo = Monedas(0)("simbolo")
            End If
            Me.dg_finanzas.Rows.Clear()

            For i = 0 To datafn.Rows.Count - 1
                Me.dg_finanzas.Rows.Add()
                ws_id_tb_formas_fn = datafn.Rows(i).Item("id_tb_formas_fn")
                ws_id_fn_maestro = datafn.Rows(i).Item("id_fn_maestro")

                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("id_tb_formas_fn").Value = ws_id_tb_formas_fn
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("id_fn_maestro").Value = ws_id_fn_maestro
                Dim reg_consulta() As DataRow = lk_sql_finanzas_local.Select("id_tb_formas_fn = " & ws_id_tb_formas_fn & " ")
                If reg_consulta.Length <> 0 Then
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("codigotipo").Value = reg_consulta(0)("forma_codigo")
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("descrip_tipo").Value = reg_consulta(0)("forma_des")
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("descrip_tipo").Tag = ws_id_tb_formas_fn

                End If
                Dim reg_consulta_fn() As DataRow = lk_sql_finanzas_local.Select("id_fn_maestro = " & ws_id_fn_maestro & " ")
                If reg_consulta_fn.Length <> 0 Then
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("codigo").Value = reg_consulta_fn(0)("fn_codigo")
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("descrip_entidad").Value = reg_consulta_fn(0)("fn_des")
                End If
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("moneda").Value = ws_simbolo

                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("nrodoc").Value = datafn.Rows(i).Item("nrodoc")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("ref").Value = datafn.Rows(i).Item("ref")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("total").Value = datafn.Rows(i).Item("total")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("fecha").Value = Format(datafn.Rows(i).Item("fecha_fn"), "dd/MM/yyyy")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("id_negocio").Value = datafn.Rows(i).Item("id_negocio")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("signo_fn").Value = datafn.Rows(i).Item("signo_fn")
                dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("total").Value = datafn.Rows(i).Item("total")
                If FORM_Estado = "bloq" Then
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("ok").Value = My.Resources.bloq
                    dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("ok").Tag = "bloq"

                End If


            Next
            Contador_filas()
        End If
    End Sub
    Private Sub dg_finanzas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_finanzas.CellContentClick

    End Sub
    Private Sub Iniciar_Fin()

        GridFinanzas_Inicia()
        Me.dg_finanzas.Rows.Add()
        Me.dg_finanzas.Rows(Me.dg_finanzas.Rows.Count - 1).Cells("fecha").Value = Format(lk_fecha_dia, "dd/MM/yyyy")
        Me.dg_finanzas.CurrentCell = Me.dg_finanzas.Rows(Me.dg_finanzas.Rows.Count - 1).Cells("num")
        Me.dg_finanzas.BeginEdit(True)
        'Me.GridLoteProd.CurrentCell = Me.GridLoteProd.Rows(Me.GridLoteProd.Rows.Count - 1).Cells("codigo")
        'Me.GridLoteProd.BeginEdit(True)
        Me.dg_finanzas.Focus()
        Me.dg_finanzas.Select()

        Contador_filas()
    End Sub

    Private Sub GridFinanzas_Inicia()
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

        dg_finanzas.Columns.Clear()
        dg_finanzas.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = True



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigotipo"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "CODIGO TIPO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Width = 35
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = False


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "descrip_tipo"
        BotonColumn.HeaderText = "TIPO"
        BotonColumn.FlatStyle = FlatStyle.Flat
        dg_finanzas.Columns.Add(BotonColumn)
        dg_finanzas.Columns.Item(BotonColumn.Name).Width = 100
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "CODIGO ENTIDAD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Width = 35
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = False


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "descrip_entidad"
        BotonColumn.HeaderText = "ENTIDAD"
        BotonColumn.FlatStyle = FlatStyle.Flat
        dg_finanzas.Columns.Add(BotonColumn)
        dg_finanzas.Columns.Item(BotonColumn.Name).Width = 120

        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "N6"
        textoColumn.HeaderText = "Mod."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Width = 30
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_tb_formas_fn"
        textoColumn.HeaderText = "id_tb_formas_fn"
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Visible = False




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "total"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "N2"
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_finanzas.Columns.Item(textoColumn.Name).MinimumWidth = 60
        dg_finanzas.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader



        ' Agrega una nueva columna al DataGridView
        fechaColumna = New DataGridViewTextBoxColumn()
        fechaColumna.Name = "fecha"
        fechaColumna.Tag = "F"
        fechaColumna.HeaderText = "FEC. OPER."
        dg_finanzas.Columns.Add(fechaColumna)
        fechaColumna.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        fechaColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_finanzas.Columns.Item(fechaColumna.Name).Width = 75
        dg_finanzas.Columns.Item(fechaColumna.Name).ReadOnly = False
        dg_finanzas.Columns.Item(fechaColumna.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "nrodoc"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "NRO. DOC/OPER."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Width = 70
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ref"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "REFERENCIA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Width = 100
        dg_finanzas.Columns.Item(textoColumn.Name).ReadOnly = False



        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_finanzas.Columns.Add(imageColumn)
        dg_finanzas.Columns.Item(imageColumn.Name).Width = 28
        dg_finanzas.Columns.Item(imageColumn.Name).ReadOnly = False


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.del
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_finanzas.Columns.Add(imageColumn)
        dg_finanzas.Columns.Item(imageColumn.Name).Width = 28
        dg_finanzas.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_finanzas.Columns.Add(imageColumn)
        dg_finanzas.Columns.Item(imageColumn.Name).Width = 28
        dg_finanzas.Columns.Item(imageColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_negocio"
        textoColumn.HeaderText = "id_negocio"
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_fn_maestro"
        textoColumn.HeaderText = "id_fn_maestro"
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "signo_fn"
        textoColumn.HeaderText = "signo_fn"
        dg_finanzas.Columns.Add(textoColumn)
        dg_finanzas.Columns.Item(textoColumn.Name).Visible = False






    End Sub
    Private Sub Contador_filas()



        'Exit Sub
        'Iterar por cada fila en el DataGridView
        If dg_finanzas.Visible = False Then Exit Sub

        If dg_finanzas.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To dg_finanzas.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            dg_finanzas.Rows(i).Cells("num").Value = (i + 1).ToString()
            dg_finanzas.Rows(i).Cells("moneda").Value = CmdMonedaComp.AccessibleName

            If i = dg_finanzas.Rows.Count - 1 Then
                dg_finanzas.Rows(i).Cells("eli").Value = My.Resources.del
                dg_finanzas.Rows(i).Cells("eli").Tag = "eli"
                dg_finanzas.Rows(i).Cells("add").Value = My.Resources.add
                dg_finanzas.Rows(i).Cells("add").Tag = "add"

            Else
                dg_finanzas.Rows(i).Cells("eli").Value = My.Resources.del
                dg_finanzas.Rows(i).Cells("eli").Tag = "eli"
                dg_finanzas.Rows(i).Cells("add").Value = My.Resources.edit
                dg_finanzas.Rows(i).Cells("add").Tag = ""
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
    Private Sub calculo_validalote()
        Dim wsuma As Double = 0
        Dim wsumaer As String = ""
        Dim wflagfecvcto As String = ""
        Dim wflagfecFab As String = ""
        Dim wflagcodigo As String = ""
        'Iterar por cada fila en el DataGridView

        'LblError.Text = ""
        'FaltaDatos.SetError(CmdAceptar, "")

        If dg_finanzas.Visible = False Then Exit Sub
        If dg_finanzas.CurrentCell Is Nothing Then Exit Sub

        lblTotal.Tag = 0
        wsuma = 0
        For i As Integer = 0 To dg_finanzas.Rows.Count - 1
            Dim valorActual As Double = Val(dg_finanzas.Rows(i).Cells("total").Value)
            wsuma = wsuma + Math.Round(valorActual, 2)
            'wsuma = wsuma + valorActual
            'wsuma = wsuma + Val(dg_finanzas.Rows(i).Cells("total").Value)
        Next

        ' NOTAS DE CREDITO SUMAR:
        Dim wcal_total As Double = 0
        For i = 0 To dg_cuentasn.Rows.Count - 1
            wcal_total = Val(dg_cuentasn.Rows(i).Cells("aplicar").Value)
            'dg_cuentasn.Rows(i).Cells("aplicar").Style.Format = "N2"
            'wsuma = wsuma + wcal_total
            wsuma = Math.Round(wsuma + wcal_total, 2)
            'wsuma = wsuma + wcal_total

        Next i



        LblMoneda.Text = Trim(CmdMonedaComp.AccessibleName)
        lblTotal.Tag = wsuma
        lblTotal.Text = Format(wsuma, "N2")


        LblDif.Text = ""
        If FORM_monto_aplicar <> Val(lblTotal.Tag) Then
            LblDif.Text = "Dif: " & Format(FORM_monto_aplicar - wsuma, "#,##0.00")
        End If







        'If wsuma <> LOTE_CANTIDAD_LOTE Then
        '    wsumaer = "La Suma " & TipoRegistro & ", son diferentes (Dif.: " & Format(LOTE_CANTIDAD_LOTE - wsuma, "0") & " )"
        '    LblError.Text = wsumaer
        '    FaltaDatos.SetError(CmdAceptar, wsumaer)
        'End If
fin:
        'If wflagcodigo <> "" Then
        '    LblError.Text = wflagcodigo
        '    FaltaDatos.SetError(CmdAceptar, wflagcodigo)
        'End If
        'If wflagfecvcto <> "" Then
        '    LblError.Text = wflagfecvcto
        '    FaltaDatos.SetError(CmdAceptar, wflagfecvcto)
        'End If
        'If wflagfecFab <> "" Then
        '    LblError.Text = wflagfecFab
        '    FaltaDatos.SetError(CmdAceptar, wflagfecFab)
        'End If

        'If ultimafila = 0 Then Exit Sub
        ''If GridProductos.Rows.


    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dg_finanzas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_finanzas.CellClick
        ' Verificar si el clic ocurrió en la columna de botones (descrip_entidad)
        If e.RowIndex < 0 Then Exit Sub

        If dg_finanzas.Rows(e.RowIndex).Cells("ok").Tag = "bloq" Then Exit Sub

        If e.ColumnIndex = dg_finanzas.Columns("descrip_entidad").Index AndAlso e.RowIndex >= 0 Then
            Dim valorCelda As String = dg_finanzas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            ' MessageBox.Show("Clic en el botón en la fila " & e.RowIndex.ToString() & ", columna " & e.ColumnIndex.ToString() & ", Valor: " & valorCelda)

            Dim wd_forma As Integer = dg_finanzas.Rows(e.RowIndex).Cells("descrip_tipo").Tag

            Muestra_MENU_Entidad(e, wd_forma, Val(CmdMonedaComp.Tag))

        End If

        If e.ColumnIndex = dg_finanzas.Columns("descrip_tipo").Index AndAlso e.RowIndex >= 0 Then

            Dim valorCelda As String = dg_finanzas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            ' MessageBox.Show("Clic en el botón en la fila " & e.RowIndex.ToString() & ", columna " & e.ColumnIndex.ToString() & ", Valor: " & valorCelda)

            Muestra_MENU_Tipo(e, Val(CmdMonedaComp.Tag))

        End If


        'Dim distinctTable As DataTable = lk_sql_finanzas_local.DefaultView.ToTable(True, "nombre_columna1", "nombre_columna2", "nombre_columna3")


    End Sub
    Private Sub Muestra_MENU_Entidad(we As DataGridViewCellEventArgs, wd_forma As Integer, wd_id_moneda As Integer)
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()


        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        temp_finanzas.DefaultView.Sort = "fn_codigo"
        Dim filtro As String = "id_tb_formas_fn = " & wd_forma & " and id_moneda = " & wd_id_moneda & " "
        temp_finanzas.DefaultView.RowFilter = filtro

        Dim Listafn As DataTable = temp_finanzas.DefaultView.ToTable(True, "fn_codigo", "fn_des", "id_fn_maestro")

        ' Recorremos las filas filtradas

        If Listafn.Rows.Count = 0 Then
            Result = MensajesBox.Show("No Tiene Definido entidas Financieras.",
                                     "Operación.")
            dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = "Sin Definir..."
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        'S/ - SOLES (PE)
        For i = 0 To Listafn.Rows.Count - 1
            Dim wid_fn_maestro As Integer = CInt(Listafn.Rows(i).Item("id_fn_maestro"))
            Dim wfn_codigo As String = Listafn.Rows(i).Item("fn_codigo")
            Dim wfn_des As String = Listafn.Rows(i).Item("fn_des")

            Dim detalle As String = Listafn.Rows(i).Item("fn_codigo").ToString.Trim & "  " & Listafn.Rows(i).Item("fn_des").ToString.Trim

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       Muestra_Entidad(we, wfn_codigo, wfn_des, wid_fn_maestro)
                                   End Sub
            menu.Items.Add(item)
        Next

        Dim row As Integer = we.RowIndex  ' Número de fila deseado
        Dim column As Integer = we.ColumnIndex ' Número de columna deseado

        Dim cell As DataGridViewCell = dg_finanzas.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = dg_finanzas.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = dg_finanzas.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_Entidad(we As DataGridViewCellEventArgs, wfn_codigo As String, wfn_des As String, wid_fn_maestro As Integer)

        dg_finanzas.Rows(we.RowIndex).Cells("codigo").Value = wfn_codigo
        dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = wfn_des
        dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_fn_maestro
        dg_finanzas.Rows(we.RowIndex).Cells("id_fn_maestro").Value = wid_fn_maestro

        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub

    Private Sub Muestra_MENU_Tipo(we As DataGridViewCellEventArgs, wid_moneda As Integer)
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()

        '  MsgBox(lk_sql_finanzas_local.Rows.Count)
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        Dim filtro As String = "id_moneda = " & wid_moneda & " "
        temp_finanzas.DefaultView.RowFilter = filtro

        temp_finanzas.DefaultView.Sort = "forma_codigo"

        Dim Listafn As DataTable = temp_finanzas.DefaultView.ToTable(True, "forma_codigo", "forma_des", "id_tb_formas_fn")

        ' Recorremos las filas filtradas

        If Listafn.Rows.Count = 0 Then
            Result = MensajesBox.Show("No Tiene Definido entidas Financieras.",
                                     "Operación.")
            dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = "Sin Definir..."
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        'S/ - SOLES (PE)
        For i = 0 To Listafn.Rows.Count - 1
            Dim wid_tb_formas_fn As Integer = CInt(Listafn.Rows(i).Item("id_tb_formas_fn"))
            Dim wforma_codigo As String = Listafn.Rows(i).Item("forma_codigo")
            Dim wforma_des As String = Listafn.Rows(i).Item("forma_des")

            Dim detalle As String = Listafn.Rows(i).Item("forma_codigo").ToString.Trim & "  " & Listafn.Rows(i).Item("forma_des").ToString.Trim

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       Muestra_Tipo(we, wforma_codigo, wforma_des, wid_tb_formas_fn)
                                   End Sub
            menu.Items.Add(item)
        Next

        Dim row As Integer = we.RowIndex  ' Número de fila deseado
        Dim column As Integer = we.ColumnIndex ' Número de columna deseado

        Dim cell As DataGridViewCell = dg_finanzas.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = dg_finanzas.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = dg_finanzas.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_Tipo(we As DataGridViewCellEventArgs, wforma_codigo As String, wforma_des As String, wid_tb_formas_fn As Integer)
        dg_finanzas.Rows(we.RowIndex).Cells("codigotipo").Value = wforma_codigo
        dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = wforma_des
        dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn
        dg_finanzas.Rows(we.RowIndex).Cells("id_tb_formas_fn").Value = wid_tb_formas_fn
        dg_finanzas.Rows(we.RowIndex).Cells("codigo").Value = ""
        dg_finanzas.Rows(we.RowIndex).Cells("descrip_entidad").Value = ""
        dg_finanzas.Rows(we.RowIndex).Cells("descrip_entidad").Tag = ""
        dg_finanzas.Rows(we.RowIndex).Cells("id_fn_maestro").Value = ""




        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub
    Private Sub dg_finanzas_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles dg_finanzas.PreviewKeyDown
        If dg_finanzas.Rows(dg_finanzas.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then Exit Sub

        If e.KeyCode = Keys.Enter And dg_finanzas.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If dg_finanzas.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = dg_finanzas.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = dg_finanzas.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = dg_finanzas.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = dg_finanzas.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual






            If columnName = "eli" Then
                If dg_finanzas.Rows.Count - 1 = 0 Then
                    dg_finanzas.Rows.Clear()
                    ' GridLoteProductos_Inicia()
                    Me.dg_finanzas.Rows.Add()
                    Me.dg_finanzas.Rows(Me.dg_finanzas.Rows.Count - 1).Cells("fecha").Value = Format(lk_fecha_dia, "dd/MM/yyyy")
                    Contador_filas()
                    Exit Sub
                End If
                dg_finanzas.Rows.Remove(dg_finanzas.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.dg_finanzas.CurrentCell = dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("num")
                Me.dg_finanzas.BeginEdit(True)
                Contador_filas()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If dg_finanzas.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.dg_finanzas.Rows.Add()
                Me.dg_finanzas.Rows(Me.dg_finanzas.Rows.Count - 1).Cells("fecha").Value = Format(lk_fecha_dia, "dd/MM/yyyy")
                Me.dg_finanzas.CurrentCell = dg_finanzas.Rows(dg_finanzas.Rows.Count - 1).Cells("num")
                Me.dg_finanzas.BeginEdit(True)
                Contador_filas()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                '   ConfirmaTodoLote()
            End If
        End If
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click

        If FORM_monto_aplicar <> Val(lblTotal.Tag) Then
            Dim Result As String = MensajesBox.Show("No Coinciden los montos.",
                                     "Finanzas.")
            Exit Sub
        End If

        Iniciar_DataSeleccion()
        Arma_Finanzas()

        Iniciar_DataSeleccion_NC()
        Arma_Finanzas_NC()

        Dim formatoCadena As String = ""
        For Each fila As DataGridViewRow In dg_finanzas.Rows
            If Val(fila.Cells("id_tb_formas_fn").Value) = 0 Then Continue For
            Dim descripTipo As String = fila.Cells("descrip_tipo").Value.ToString()
            Dim descripEntidad As String = fila.Cells("descrip_entidad").Value.ToString()
            Dim moneda As String = fila.Cells("moneda").Value
            Dim total As Decimal = Decimal.Parse(Val(fila.Cells("total").Value))

            Dim filaCadena As String = $"{descripTipo} / {descripEntidad} / {moneda} : {total.ToString("N2")}"
            formatoCadena &= filaCadena & Environment.NewLine
        Next



        ' El resultado estará en formatoCadena

        FORM_Cadena_contenidos = formatoCadena
        FORM_valor_total = Val(lblTotal.Tag)

        FORM_DataFianzas = DataSeleccion
        FORM_DataFianzas_nc = DataSeleccion_NC
        Me.DialogResult = DialogResult.OK
        Me.Close()



    End Sub
    Private Sub Arma_Finanzas()
        DataSeleccion.Rows.Clear()
        Dim wsec As Integer = 0

        For i As Integer = 0 To dg_finanzas.Rows.Count - 1
            If Val(dg_finanzas.Rows(i).Cells("id_tb_formas_fn").Value) = 0 Then Continue For
            wsec = wsec + 1
            Dim addrow As DataRow = DataSeleccion.NewRow()
            addrow.Item("id_negocio") = lk_NegocioActivo.id_Negocio
            addrow.Item("numsec") = wsec
            addrow.Item("id_moneda") = Val(CmdMonedaComp.Tag)
            addrow.Item("id_tb_formas_fn") = Val(dg_finanzas.Rows(i).Cells("id_tb_formas_fn").Value)
            addrow.Item("id_fn_maestro") = Val(dg_finanzas.Rows(i).Cells("id_fn_maestro").Value)
            addrow.Item("fecha_fn") = dg_finanzas.Rows(i).Cells("fecha").Value
            addrow.Item("nrodoc") = Trim(dg_finanzas.Rows(i).Cells("nrodoc").Value)
            addrow.Item("ref") = Trim(dg_finanzas.Rows(i).Cells("ref").Value)
            addrow.Item("total") = Val(dg_finanzas.Rows(i).Cells("total").Value)
            addrow.Item("signo_fn") = Val(Enlace_signo_entidad)
            addrow.Item("id_controlcaja_det") = Val(LblEstadoCaja.Tag)
            DataSeleccion.Rows.Add(addrow)
        Next


    End Sub
    Private Sub Arma_Finanzas_NC()
        DataSeleccion_NC.Rows.Clear()
        Dim wsec As Integer = 0

        For i As Integer = 0 To dg_cuentasn.Rows.Count - 1
            If Val(dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value) = 0 Then Continue For
            wsec = wsec + 1
            Dim addrow As DataRow = DataSeleccion_NC.NewRow()
            addrow.Item("id_negocio") = lk_NegocioActivo.id_Negocio
            addrow.Item("id_carterasn_enlaces") = 1
            addrow.Item("numsec") = wsec
            addrow.Item("id_oper_maestro") = dg_cuentasn.Rows(i).Cells("id_oper_maestro").Value
            addrow.Item("id_comp_cab") = dg_cuentasn.Rows(i).Cells("id_comp_cab").Value
            addrow.Item("id_carterasn_cab") = dg_cuentasn.Rows(i).Cells("id_carterasn_cab").Value
            addrow.Item("id_carterasn_det") = dg_cuentasn.Rows(i).Cells("id_carterasn_det").Value
            addrow.Item("total") = dg_cuentasn.Rows(i).Cells("aplicar").Value
            addrow.Item("signo_sn") = 1 ' wsigno_sn
            addrow.Item("fecha") = lk_fecha_dia
            addrow.Item("id_cobrador") = 1
            addrow.Item("id_oper_maestro_base") = 1
            addrow.Item("id_comp_cab_base") = 1
            addrow.Item("estado") = 1

            DataSeleccion_NC.Rows.Add(addrow)

        Next i

    End Sub
    Private Sub CmdMonedaComp_Click(sender As Object, e As EventArgs) Handles CmdMonedaComp.Click
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub


        Dim ListaMoneda() As DataRow = lk_sql_monedas_negocio.Select("id_negocio <> 0 and id_moneda = " & FORM_id_moneda & "")
        ' Recorremos las filas filtradas

        If ListaMoneda.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Moneda el Comprobantes Asociados a la Operacion.",
                                     "Operación.")
            CmdMonedaComp.Text = ""
            CmdMonedaComp.Tag = ""
            CmdMonedaComp.AccessibleName = ""
            CmdMonedaComp.AccessibleDescription = ""
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        'S/ - SOLES (PE)
        For Each row As DataRow In ListaMoneda
            Dim id As Integer = CInt(row("id_moneda"))
            Dim detalle As String = CStr(row("simbolo") & "  " & row("nom_moneda") & " (" & row("abreviado").ToString.Trim & ")")
            Dim simbolo As String = CStr(row("simbolo"))
            Dim esmonlocal As String = CStr(row("es_monedalocal"))

            Dim abreviado As String = CStr(Space(10) & row("abreviado").ToString.Trim)

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarMoneda(id, detalle, simbolo, abreviado, esmonlocal)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub MostrarMoneda(id As String, detalle As String, simbolo As String, abreviado As String, esmonlocal As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        CmdMonedaComp.Text = detalle
        CmdMonedaComp.Tag = id
        CmdMonedaComp.AccessibleName = simbolo
        CmdMonedaComp.AccessibleDescription = esmonlocal

        calculo_validalote()

    End Sub

    Private Sub dg_finanzas_Validating(sender As Object, e As CancelEventArgs) Handles dg_finanzas.Validating
        calculo_validalote()
    End Sub

    Private Sub dg_finanzas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg_finanzas.CellEndEdit
        calculo_validalote()
    End Sub
    Private Sub Conexcion_finanzas(wid_negocio As Integer)
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter

        sql_cade = "select  * from [vw_entidades] where id_negocio = " & lk_NegocioActivo.id_Negocio & "" ' filtro para buscar por el id : id_oper_maestro
        lk_sql_finanzas_local = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_finanzas_local)

    End Sub
    Private Sub Iniciar_DataSeleccion()

        DataSeleccion.Columns.Clear()
        DataSeleccion.Columns.Add("id_negocio", GetType(Integer))
        DataSeleccion.Columns.Add("numsec", GetType(Integer))
        DataSeleccion.Columns.Add("id_moneda", GetType(Integer))
        DataSeleccion.Columns.Add("id_tb_formas_fn", GetType(Integer))
        DataSeleccion.Columns.Add("id_fn_maestro", GetType(Integer))
        DataSeleccion.Columns.Add("fecha_fn", GetType(DateTime))
        DataSeleccion.Columns.Add("nrodoc", GetType(String))
        DataSeleccion.Columns.Add("ref", GetType(String))
        DataSeleccion.Columns.Add("total", GetType(Double))
        DataSeleccion.Columns.Add("signo_fn", GetType(Integer))
        DataSeleccion.Columns.Add("id_controlcaja_det", GetType(Integer))
    End Sub
    Private Sub Iniciar_DataSeleccion_NC()

        DataSeleccion_NC.Columns.Add("id_negocio", GetType(Integer))
        DataSeleccion_NC.Columns.Add("id_carterasn_enlaces", GetType(Integer))
        DataSeleccion_NC.Columns.Add("numsec", GetType(Integer))
        DataSeleccion_NC.Columns.Add("id_oper_maestro", GetType(Integer))
        DataSeleccion_NC.Columns.Add("id_comp_cab", GetType(Integer))
        DataSeleccion_NC.Columns.Add("id_carterasn_cab", GetType(Integer))
        DataSeleccion_NC.Columns.Add("id_carterasn_det", GetType(Integer))
        DataSeleccion_NC.Columns.Add("total", GetType(Double))
        DataSeleccion_NC.Columns.Add("signo_sn", GetType(Integer))
        DataSeleccion_NC.Columns.Add("fecha", GetType(DateTime))
        DataSeleccion_NC.Columns.Add("id_cobrador", GetType(Integer))
        DataSeleccion_NC.Columns.Add("id_oper_maestro_base", GetType(Integer))
        DataSeleccion_NC.Columns.Add("id_comp_cab_base", GetType(Integer))
        DataSeleccion_NC.Columns.Add("estado", GetType(Integer))

    End Sub

    Private Sub dg_finanzas_CellContextMenuStripChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dg_finanzas.CellContextMenuStripChanged

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

        'dg_listaoper.BackgroundColor = ColorTranslator.FromHtml(FondoPanelyForm)
        'dg_listaoper.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(FondoCajaTextoyLabel) ' Cambiar el color de fondo de las celdas
        'dg_listaoper.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(gridletra)

        'Me.ForeColor = Color.White
        For Each panel As Panel In Me.Controls.OfType(Of Panel)()
            If panel.Name = "PanelSup" Then Continue For
            If panel.Name = "PanelListarOper" Then Continue For

            panel.BackColor = ColorTranslator.FromHtml(FondoPanelyForm)

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
                If pnlbox.Name = "PanelSup" Then Continue For
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

    Private Sub CmdTodoEFE_Click(sender As Object, e As EventArgs) Handles CmdTodoEFE.Click
        If FORM_Estado = "bloq" Then Exit Sub
        Dim wfila As Integer = 0
        Iniciar_Fin()
        ActualizarColores()
        GridFinanzas_Inicia()
        Me.dg_finanzas.Rows.Add()
        Me.dg_finanzas.Rows(Me.dg_finanzas.Rows.Count - 1).Cells("fecha").Value = Format(lk_fecha_dia, "dd/MM/yyyy")

        Dim reg_consulta() As DataRow = lk_sql_finanzas_local.Select("forma_codigo= '01'")
        If reg_consulta.Length <> 0 Then
            dg_finanzas.Rows(wfila).Cells("codigotipo").Value = reg_consulta(0)("forma_codigo")
            dg_finanzas.Rows(wfila).Cells("descrip_tipo").Value = reg_consulta(0)("forma_des")

            dg_finanzas.Rows(wfila).Cells("id_tb_formas_fn").Value = reg_consulta(0)("id_tb_formas_fn")
            dg_finanzas.Rows(wfila).Cells("id_fn_maestro").Value = reg_consulta(0)("id_fn_maestro")

        End If
        Dim reg_consulta_fn() As DataRow = lk_sql_finanzas_local.Select("fn_codigo = '01'")
        If reg_consulta_fn.Length <> 0 Then
            dg_finanzas.Rows(wfila).Cells("codigo").Value = reg_consulta_fn(0)("fn_codigo")
            dg_finanzas.Rows(wfila).Cells("descrip_entidad").Value = reg_consulta_fn(0)("fn_des")
        End If
        dg_finanzas.Rows(wfila).Cells("moneda").Value = FORM_id_moneda

        dg_finanzas.Rows(wfila).Cells("nrodoc").Value = "EFE"
        dg_finanzas.Rows(wfila).Cells("ref").Value = "TODO EFECTIVO"
        dg_finanzas.Rows(wfila).Cells("total").Value = Val(FORM_monto_aplicar)
        dg_finanzas.Rows(wfila).Cells("fecha").Value = Format(Now, "dd/MM/yyyy")
        dg_finanzas.Rows(wfila).Cells("id_negocio").Value = lk_NegocioActivo.id_Negocio
        dg_finanzas.Rows(wfila).Cells("signo_fn").Value = Enlace_signo_entidad

        Contador_filas()
        calculo_validalote()
    End Sub

    Private Sub CmdCajas_Click(sender As Object, e As EventArgs) Handles CmdCajas.Click
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()



        Dim Lista_cajas() As DataRow = lk_sql_ListaControlCajas.Select("id_usuario = " & lk_id_usuario & "")
        ' Recorremos las filas filtradas
        If Lista_cajas.Length = 0 Then
            Dim Result = MensajesBox.Show("Su Usuario no tiene acceso Control Caja.",
                                     "Control ed Caja.")
            'Activa_Botones(0)
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        Dim ws_flag_abieerta As Integer = 0
        For Each row As DataRow In Lista_cajas
            Dim id As Integer = CInt(row("id_controlcaja_mae"))
            Dim detalle As String = CStr(row("codigo") & " " & row("descripcion"))
            Dim descrip As String = CStr(row("descripcion"))
            Dim codigo As String = CStr(row("codigo"))
            Dim whora As String = ""
            Dim westado As String = row("estado")
            Dim wid_moneda As Integer = row("id_moneda")
            If Val(westado) = 1 Then ws_flag_abieerta = 1
            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarCajaActivo(id, detalle, descrip, codigo, whora, westado, wid_moneda)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        ' If ws_flag_abieerta = 1 Then Activa_Botones(0)
        menu.Show(CmdCajas, New Point(0, CmdCajas.Height))
    End Sub
    Private Sub MostrarCajaActivo(id As String, detalle As String, descrip As String, codigo As String, whora As String, westado As String, wid_moneda As Integer)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente

        CmdCajas.Text = codigo & " " & descrip
        CmdCajas.Tag = id
        'Muestra_Estado_ControlCaja(Val(westado), LblEstadoCaja, whora)
        CmdCajas.AccessibleName = Val(westado)

        'Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio<> 0 and es_monedalocal= 1 and id_moneda = " & wid_moneda & "")
        '' Recorremos las filas filtradas
        'If Monedas.Length = 0 Then
        '    Exit Sub
        'End If
        'CmdMonedaComp.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
        'CmdMonedaComp.Tag = Monedas(0)("id_moneda")
        'CmdMonedaComp.AccessibleName = Monedas(0)("simbolo")
        'CmdMonedaComp.AccessibleDescription = Monedas(0)("es_monedalocal")
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        command = New SqlCommand("sp_muestra_controlcajas_aperturas", lk_connection_cuenta)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.AddWithValue("@id_controlcaja_mae", id)
        adaptador = New SqlDataAdapter(command)
        Dim sql_controlcaja_det = New DataTable
        adaptador.Fill(sql_controlcaja_det)


        Dim actual_controlcaja_det() As DataRow = sql_controlcaja_det.Select(" estado = 1 ")
        ' Recorremos las filas filtradas
        dg_finanzas.Enabled = False
        dg_finanzas.Rows.Clear()

        If actual_controlcaja_det.Length = 0 Then
            LblEstadoCaja.Text = "SIN APERTURAR"
            dg_finanzas.Enabled = False
            LblEstadoCaja.Tag = 0
            '            Activa_Botones(0)
            Exit Sub
        Else
            Dim wcadedet As String = formato_ListaCajas(actual_controlcaja_det(0)("estado"), actual_controlcaja_det(0)("fechahora_apertura"), actual_controlcaja_det(0)("id_controlcaja_det"))
            LblEstadoCaja.Text = wcadedet
            LblEstadoCaja.Tag = actual_controlcaja_det(0)("id_controlcaja_det")
            LblEstadoCaja.AccessibleName = actual_controlcaja_det(0)("estado")
            CmdCajas.AccessibleName = 1
            Iniciar_Fin()
            ActualizarColores()
            dg_finanzas.Enabled = True
        End If



        'Activa_Botones(Val(Lista_cajas(0)("estado")))



        'Actualiza_ListaCajas(id)


    End Sub

    Private Sub Contador_filas_cuentaSN()

        If dg_cuentasn.Visible = False Then Exit Sub


        'Iterar por cada fila en el DataGridView
        If dg_cuentasn.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To dg_cuentasn.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            dg_cuentasn.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = dg_cuentasn.Rows.Count - 1 Then
                dg_cuentasn.Rows(i).Cells("eli").Value = My.Resources.del
                dg_cuentasn.Rows(i).Cells("eli").Tag = "eli"
                dg_cuentasn.Rows(i).Cells("add").Value = My.Resources.add
                dg_cuentasn.Rows(i).Cells("add").Tag = "add"
            Else
                dg_cuentasn.Rows(i).Cells("eli").Value = My.Resources.del
                dg_cuentasn.Rows(i).Cells("eli").Tag = "eli"
                dg_cuentasn.Rows(i).Cells("add").Value = My.Resources.edit
                dg_cuentasn.Rows(i).Cells("add").Tag = ""
            End If
            ultimafila = i
        Next

    End Sub

    Private Sub GridCuentasn_Inicia_CTASN1()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        ' Dim controlLabel As Label





        dg_cuentasn.Columns.Clear()



        dg_cuentasn.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "descrip"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "NOMBRES DE SOCIO DE NEGOCIO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'textoColumn.HeaderCell.Style.BackColor = Color.Gray ' Cambiar el color de fondo de la cabecera
        'textoColumn.HeaderCell.Style.ForeColor = Color.White ' Cambiar el color del texto de la cabecera
        'textoColumn.HeaderCell.Style.ForeColor = Color.White ' Cambiar el color del texto de la cabecera

        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 200
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "masdetalle"
        BotonColumn.HeaderText = "INF"
        BotonColumn.FlatStyle = FlatStyle.Flat
        dg_cuentasn.Columns.Add(BotonColumn)
        dg_cuentasn.Columns.Item(BotonColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(BotonColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 50
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_sn_master"
        textoColumn.HeaderText = "id_sn_master"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codcomp"
        textoColumn.Tag = "C4"
        textoColumn.HeaderText = "COD COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 35
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "seriecomp"
        textoColumn.Tag = "A4"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 35
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numerocomp"
        textoColumn.Tag = "C8"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 55
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "BUS"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "buscarcomp"
        imageColumn.Image = My.Resources.buscar
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False
        dg_cuentasn.Columns.Item(imageColumn.Name).Visible = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "vercomp"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 20
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False
        dg_cuentasn.Columns.Item(imageColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechaemis"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "FEC.EMIS"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 75
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 35
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 30
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "SALDO COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechavcto"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "FECHA VCTO."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 50
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "aplicar"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO APLICAR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "N2"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = False





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "condicion"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "COND COMP"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 40
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "vendedor"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "VEND."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 40
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hecho"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "HECHO POR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 50
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechahora"
        textoColumn.Tag = "C10"
        textoColumn.HeaderText = "FECHA HORA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 70
        dg_cuentasn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        textoColumn.HeaderText = "id_oper_maestro"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        textoColumn.HeaderText = "id_comp_cab"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_carterasn_cab"
        textoColumn.HeaderText = "id_carterasn_cab"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_carterasn_det"
        textoColumn.HeaderText = "id_carterasn_det"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "oper_codigo"
        textoColumn.HeaderText = "oper_codigo"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "signo_sn"
        textoColumn.HeaderText = "signo_sn"
        dg_cuentasn.Columns.Add(textoColumn)
        dg_cuentasn.Columns.Item(textoColumn.Name).Width = 0
        dg_cuentasn.Columns.Item(textoColumn.Name).Visible = False






        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_cuentasn.Columns.Add(imageColumn)
        dg_cuentasn.Columns.Item(imageColumn.Name).Width = 25
        dg_cuentasn.Columns.Item(imageColumn.Name).ReadOnly = False



    End Sub

    Private Sub CheckNC_CheckedChanged(sender As Object, e As EventArgs) Handles CheckNC.CheckedChanged
        If CheckNC.Checked Then
            MostrarOP_NC()
        Else
            dg_cuentasn.Rows.Clear()
            dg_cuentasn.Columns.Clear()
        End If
    End Sub
    Private Sub MostrarOP_NC()

        Me.dg_cuentasn.Tag = "CTASN1"
        Me.dg_cuentasn.Visible = True
        GridCuentasn_Inicia_CTASN1()
        dg_cuentasn_PrimeraFila()

    End Sub
    Private Sub Calcula_CTASN1(wmodocal As Integer)
        ' 1 = Con Impuesto 
        ' 2 = Sin Impuestos

        Dim wcal_total As Double = 0


        Dim wtot_total As Double = 0




        For i = 0 To dg_cuentasn.Rows.Count - 1
            wcal_total = Val(dg_cuentasn.Rows(i).Cells("aplicar").Value)

            dg_cuentasn.Rows(i).Cells("aplicar").Style.Format = "N2"


            wtot_total = wtot_total + wcal_total

        Next i




    End Sub

    Private Sub dg_cuentasn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cuentasn.CellContentClick

    End Sub

    Private Sub dg_cuentasn_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dg_cuentasn.CellValidating
        calculo_validalote()
    End Sub

    Private Sub dg_cuentasn_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles dg_cuentasn.PreviewKeyDown
        If dg_cuentasn.Rows(dg_cuentasn.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then Exit Sub
        If e.KeyCode = Keys.Enter And dg_cuentasn.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If dg_cuentasn.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = dg_cuentasn.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = dg_cuentasn.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = dg_cuentasn.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = dg_cuentasn.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual

            If columnName = "eli" Then
                If dg_cuentasn.Rows(dg_cuentasn.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
                    Exit Sub
                End If

                If dg_cuentasn.Rows.Count - 1 = 0 Then
                    dg_cuentasn.Rows.Clear()
                    ' GridLoteProductos_Inicia()
                    Me.dg_cuentasn.Rows.Add()
                    Contador_filas_cuentaSN()
                    Exit Sub
                End If
                dg_cuentasn.Rows.Remove(dg_cuentasn.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.dg_cuentasn.CurrentCell = dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codcomp")
                Me.dg_cuentasn.BeginEdit(True)
                Contador_filas_cuentaSN()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If dg_cuentasn.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.dg_cuentasn.Rows.Add()

                Me.dg_cuentasn.CurrentCell = dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codcomp")
                Me.dg_cuentasn.BeginEdit(True)
                Contador_filas_cuentaSN()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                'ConfirmaTodoLote()
                'GridProductos_PrimeraFila()
            End If





            'If columnName = "eli" Then

            '    If rowTag = "add" Then ' Verificar que se haya seleccionado alguna fila

            '        Me.GridProductos.Rows.Add()
            '        If Me.GridProductos.Tag = "PROD1" Then
            '            Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle")
            '            Me.GridProductos.BeginEdit(True)
            '            Contador_filas()
            '        End If

            '        'GridProductos_PrimeraFila()
            '    ElseIf rowTag = "eli" Then
            '        If GridProductos.Rows(GridProductos.CurrentCell.RowIndex).Cells("ok").Tag = "bloq" Then
            '            Exit Sub
            '        End If
            '        GridProductos.Rows.Remove(GridProductos.CurrentRow) ' Eliminar la primera fila seleccionada
            '        If Me.GridProductos.Tag = "PROD1" Then
            '            Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle")
            '            Me.GridProductos.BeginEdit(True)
            '        End If

            '    End If
            'End If







        End If

    End Sub
    Public Sub dg_cuentasn_PrimeraFila()

        Me.dg_cuentasn.Rows.Clear()
        Me.dg_cuentasn.Rows.Add()
        If Me.dg_cuentasn.Tag = "CTASN1" Then
            Me.dg_cuentasn.CurrentCell = dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codcomp")
            Me.dg_cuentasn.BeginEdit(True)
            Contador_filas_cuentaSN()
        End If
    End Sub

    Public Sub dg_cuentasn_PrimeraFila1111111()



        'If Me.GridProductos.CurrentCell.RowIndex = Me.GridProductos.Rows.Count Then
        Me.dg_cuentasn.Rows.Clear()
        Me.dg_cuentasn.Rows.Add()
        Me.dg_cuentasn.CurrentCell = dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("codigo")
        'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("masdetalle").Value = "..."
        'Me.GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("descrip").Value = "APIRINA COMPUESTO CON GRAGEAS 50X10GR PLUSS"
        'Me.dg_cuentasn.Rows(dg_cuentasn.Rows.Count - 1).Cells("eli").Tag = "ppp"
        Me.dg_cuentasn.BeginEdit(True)
        Contador_filas_cuentaSN()
        'Else
        ' Me.GridProductos.CurrentCell = GridProductos.Rows(GridProductos.Rows.Count + 1).Cells("codigo")
        ' Me.GridProductos.BeginEdit(True)
        '
        '       End If



        ' Contador_filas()



        'Dim comboCell As DataGridViewComboBoxCell
        'comboCell = CType(GridProductos.Rows(GridProductos.Rows.Count - 1).Cells("present"), DataGridViewComboBoxCell)
        'comboCell.Items.Add("UND")
        'comboCell.Items.Add("CJx1")
        'comboCell.Items.Add("PAQX24")
        'comboCell.Value = "UND"

    End Sub

    Private Sub dg_cuentasn_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg_cuentasn.CellEndEdit
        calculo_validalote()
    End Sub

    Private Sub dg_cuentasn_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dg_cuentasn.EditingControlShowing
        Dim currentColumn = dg_cuentasn.Columns(dg_cuentasn.CurrentCell.ColumnIndex)
        Dim currentColumnName = currentColumn.Name

        ' Acceder al nombre de la cabecera de la columna
        'Dim columnName As String = columnHeader.HeaderText


        If TypeOf e.Control Is TextBox And Strings.Left(currentColumn.Tag, 1) = "A" Then ' Asegurarse de que el control de edición es un cuadro de texto
            AddHandler e.Control.TextChanged, AddressOf TextBox_TextChanged ' Agregar controlador de eventos TextChanged
            'AddHandler e.Control.KeyDown, AddressOf BloqueoColumn_KeyDown
        End If
    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim originalSelectionStart As Integer = textBox.SelectionStart ' Guardar la posición actual del cursor
        textBox.Text = textBox.Text.ToUpper() ' Convertir texto en mayúsculas
        textBox.SelectionStart = textBox.Text.Length ' Mover el cursor al final del texto
    End Sub
End Class