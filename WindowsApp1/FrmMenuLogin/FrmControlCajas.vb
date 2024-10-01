Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class FrmControlCajas
    Public Event NuevoMensaje As EventHandler(Of MensajeEventArgs)
    Public Property ES_FORMZAR_CIERRE As Integer
    Dim sql_reg_controlcaja_det As New DataTable()
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

    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click
        WindowState = FormWindowState.Minimized
        Me.Text = ""
        Me.ControlBox = True

        FrmLogin.PanelIndicadores.SendToBack()
        FrmLogin.IndicadorGrafico.SendToBack()
        Me.BringToFront()
        Me.Text = "Control de cajas"



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

    Private Sub FrmControlCajas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        '============= PRUEBA PARA FORMALURO DE OPERACIONES ================================

        ' CERRAR_SESIONES()

        ''**********
        'PCSERVER = "pcacosme"
        'PASSSEVER = "159357852456"
        'SASEVER = "sa"
        'LK_ES_FORMATO_ESPANOL = True

        ''**********

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



        '===============================================



        Traer_Datos_ControlCajas(lk_NegocioActivo.id_Negocio)

        'Muestra_Estado_ControlCaja(Val(1), LblEstadoCaja, "")
        ES_FORMZAR_CIERRE = 0
        Dim Lista_cajas() As DataRow = lk_sql_ListaControlCajas.Select("id_usuario = '" & lk_id_usuario & "'")
        ' Recorremos las filas filtradas
        If Lista_cajas.Length = 0 Then
            Dim Result = MensajesBox.Show("Su Usuario no tiene acceso Control Caja.",
                                     "Control ed Caja.")
            Activa_Botones(0)
            ES_FORMZAR_CIERRE = 1
            Exit Sub
        End If

        CmdCajas.Text = Lista_cajas(0)("codigo").ToString.Trim & " " & Lista_cajas(0)("descripcion").ToString.Trim
        CmdCajas.Tag = Lista_cajas(0)("id_controlcaja_mae")
        Dim wsid As Integer = Lista_cajas(0)("id_controlcaja_mae")

        Actualiza_ListaCajas(wsid)



        Dim wid_moneda As Integer = Lista_cajas(0)("id_moneda")

        Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio<> 0 and es_monedalocal= 1 and id_moneda = " & wid_moneda & "")
        ' Recorremos las filas filtradas
        If Monedas.Length = 0 Then
            Exit Sub
        End If
        CmdMonedaComp.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
        CmdMonedaComp.Tag = Monedas(0)("id_moneda")
        CmdMonedaComp.AccessibleName = Monedas(0)("simbolo")
        CmdMonedaComp.AccessibleDescription = Monedas(0)("es_monedalocal")

        PanelSup.BackColor = ColorTranslator.FromHtml(strColorLogin)
        Me.Visible = True
    End Sub

    Private Sub Muestra_detalle_dinero(wid_moneda As Integer, wes_verifica As Integer, wid_controlcaja_mae As Integer, wid_controlcaja_det As Integer)
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim sql_filtr_temp = New DataTable()
        Dim wcanti As Integer


        GridMonedas_Inicia()
        If wes_verifica = 1 Then
            sql_cade = "Select  id_dinero , Cantidad from m_controlcaja_desglose where 
                id_negocio = @id_negocio And id_controlcaja_mae = @id_controlcaja_mae And id_controlcaja_det = @id_controlcaja_det "
            command = New SqlCommand(sql_cade, lk_connection_cuenta)
            parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
            command.Parameters.Add(parametro)
            parametro = New SqlParameter("@id_controlcaja_mae", wid_controlcaja_mae)
            command.Parameters.Add(parametro)
            parametro = New SqlParameter("@id_controlcaja_det", wid_controlcaja_det)
            command.Parameters.Add(parametro)
            adaptador = New SqlDataAdapter(command)
            sql_filtr_temp = New DataTable
            adaptador.Fill(sql_filtr_temp)
        End If

        Dim rs_consulta() As DataRow = lk_sql_Lista_dinero.Select("id_moneda = " & wid_moneda & " And  tipo = 'M'")
        ' Recorremos las filas filtradas
        If rs_consulta.Length = 0 Then
            Exit Sub
        End If
        dg_monedas.Rows.Clear()

        For i = 0 To rs_consulta.Length - 1
            dg_monedas.Rows.Add()
            dg_monedas.Rows(dg_monedas.Rows.Count - 1).Cells("moneda").Value = rs_consulta(i)("abreviado")
            dg_monedas.Rows(dg_monedas.Rows.Count - 1).Cells("cant_moneda").Value = 0
            dg_monedas.Rows(dg_monedas.Rows.Count - 1).Cells("id_moneda").Value = rs_consulta(i)("id_dinero")
            dg_monedas.Rows(dg_monedas.Rows.Count - 1).Cells("factor_moneda").Value = rs_consulta(i)("valor")
            If wes_verifica = 1 Then
                wcanti = 0
                Dim rs_canti() As DataRow = sql_filtr_temp.Select("id_dinero = " & rs_consulta(i)("id_dinero") & "")
                If rs_canti.Length <> 0 Then wcanti = rs_canti(0)("cantidad")
                dg_monedas.Rows(dg_monedas.Rows.Count - 1).Cells("cant_moneda").Value = wcanti
            End If

        Next i
        rs_consulta = lk_sql_Lista_dinero.Select("id_moneda = '" & wid_moneda & "' and tipo = 'B'")

        For i = 0 To rs_consulta.Length - 1
            If i > (dg_monedas.Rows.Count - 1) Then
                dg_monedas.Rows.Add()
            End If
            dg_monedas.Rows(i).Cells("billete").Value = rs_consulta(i)("abreviado")
            dg_monedas.Rows(i).Cells("cant_billete").Value = 0
            dg_monedas.Rows(i).Cells("id_billete").Value = rs_consulta(i)("id_dinero")
            dg_monedas.Rows(i).Cells("factor_billete").Value = rs_consulta(i)("valor")
            If wes_verifica = 1 Then
                wcanti = 0
                Dim rs_canti() As DataRow = sql_filtr_temp.Select("id_dinero = " & rs_consulta(i)("id_dinero") & "")
                If rs_canti.Length <> 0 Then wcanti = rs_canti(0)("cantidad")
                dg_monedas.Rows(i).Cells("cant_billete").Value = wcanti
            End If
        Next i




    End Sub
    Private Sub Calcula_monto()
        Dim wmonto As Double = 0
        For i = 0 To dg_monedas.Rows.Count - 1
            If Val(dg_monedas.Rows(i).Cells("id_moneda").Value) <> 0 And Val(dg_monedas.Rows(i).Cells("cant_moneda").Value) Then ' HAY MONEDAS
                wmonto = wmonto + (Val(dg_monedas.Rows(i).Cells("factor_moneda").Value) * Val(dg_monedas.Rows(i).Cells("cant_moneda").Value))
            End If

            If Val(dg_monedas.Rows(i).Cells("id_billete").Value) <> 0 And Val(dg_monedas.Rows(i).Cells("cant_billete").Value) Then ' HAY BILLETES
                wmonto = wmonto + (Val(dg_monedas.Rows(i).Cells("factor_billete").Value) * Val(dg_monedas.Rows(i).Cells("cant_billete").Value))
            End If
        Next
        TxtMonto.Text = Format(wmonto, "##,##0.00")

    End Sub
    Private Sub GridMonedas_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim fechaColumna As New DataGridViewTextBoxColumn()

        Dim fuente_cabe As Font = New Font("Segoe UI", 10.25)
        Dim fuente_grid As Font = New Font("Segoe UI", 8.0F)



        dg_monedas.Columns.Clear()
        dg_monedas.DefaultCellStyle.Font = fuente_cabe





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "MONEDAS"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).Width = 70
        dg_monedas.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cant_moneda"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "CANT."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_monedas.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_monedas.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = fuente_grid
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "imgmoneda"
        imageColumn.Image = My.Resources.moneda
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_monedas.Columns.Add(imageColumn)
        dg_monedas.Columns.Item(imageColumn.Name).Width = 40
        dg_monedas.Columns.Item(imageColumn.Name).ReadOnly = True




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "billete"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "BILLETES"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).Width = 70
        dg_monedas.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cant_billete"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "CANT."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_monedas.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_monedas.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = fuente_grid
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "imgbillete"
        imageColumn.Image = My.Resources.billete
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_monedas.Columns.Add(imageColumn)
        dg_monedas.Columns.Item(imageColumn.Name).Width = 40
        dg_monedas.Columns.Item(imageColumn.Name).ReadOnly = True




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "factor_moneda"
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "factor_billete"
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_billete"
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_moneda"
        dg_monedas.Columns.Add(textoColumn)
        dg_monedas.Columns.Item(textoColumn.Name).Visible = False






    End Sub


    Private Sub dg_monedas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_monedas.CellContentClick

    End Sub

    Private Sub dg_monedas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg_monedas.CellEndEdit
        ' Obtener los índices de las columnas "cant_moneda" y "cant_billete"
        Dim cantMonedaColumnIndex As Integer = dg_monedas.Columns("cant_moneda").Index
        Dim cantBilleteColumnIndex As Integer = dg_monedas.Columns("cant_billete").Index

        ' Verificar si la celda editada pertenece a la columna "cant_moneda" o "cant_billete"
        If (e.ColumnIndex = cantMonedaColumnIndex OrElse e.ColumnIndex = cantBilleteColumnIndex) AndAlso e.RowIndex >= 0 Then
            Dim cell As DataGridViewCell = dg_monedas.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim input As String = cell.Value?.ToString()
            FaltaDatos.SetError(dg_monedas, "")
            ' Validar que la celda esté vacía o contenga solo números enteros
            If Not String.IsNullOrWhiteSpace(input) AndAlso Not Integer.TryParse(input, Nothing) Then
                FaltaDatos.SetError(dg_monedas, "Valores Enteros.")
                ' Puedes limpiar la celda o revertir a un valor anterior si lo deseas
                cell.Value = Nothing
            End If
        End If



        Calcula_monto()
    End Sub

    Private Sub OpDirecto_CheckedChanged(sender As Object, e As EventArgs) Handles OpDirecto.CheckedChanged
        EscojeModo(0)
    End Sub
    Private Sub OpDesglose_CheckedChanged(sender As Object, e As EventArgs) Handles OpDesglose.CheckedChanged
        EscojeModo(0)
    End Sub
    Private Sub EscojeModo(wes_verificar As Integer)
        If OpDirecto.Checked Then
            dg_monedas.Enabled = False
            dg_monedas.Columns.Clear()
            dg_monedas.Rows.Clear()
            TxtMonto.Text = ""
            TxtMonto.Enabled = True
            TxtMonto.Select()
        Else
            TxtMonto.Text = ""
            TxtMonto.Enabled = False
            dg_monedas.Enabled = True
            Muestra_detalle_dinero(1, wes_verificar, Val(CmdCajas.Tag), Val(CmdListaApe.Tag))
        End If

    End Sub

    Private Sub CmdCajas_Click(sender As Object, e As EventArgs) Handles CmdCajas.Click
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()



        Dim Lista_cajas() As DataRow = lk_sql_ListaControlCajas.Select("id_usuario = " & lk_id_usuario & "")
        ' Recorremos las filas filtradas
        If Lista_cajas.Length = 0 Then
            Dim Result = MensajesBox.Show("Su Usuario no tiene acceso Control Caja.",
                                     "Control ed Caja.")
            Activa_Botones(0)
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
        ' Muestra_Estado_ControlCaja(Val(westado), LblEstadoCaja, whora)
        CmdCajas.AccessibleName = Val(westado)

        Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio<> 0 and es_monedalocal= 1 and id_moneda = " & wid_moneda & "")
        ' Recorremos las filas filtradas
        If Monedas.Length = 0 Then
            Exit Sub
        End If
        CmdMonedaComp.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
        CmdMonedaComp.Tag = Monedas(0)("id_moneda")
        CmdMonedaComp.AccessibleName = Monedas(0)("simbolo")
        CmdMonedaComp.AccessibleDescription = Monedas(0)("es_monedalocal")

        Actualiza_ListaCajas(id)


    End Sub
    Private Sub Actualiza_ListaCajas(ws_id As Integer)
        traer_Lista_controlcaja_det(ws_id)

        CmdListaApe.Tag = 0
        Dim Lista_cajas() As DataRow = sql_reg_controlcaja_det.Select("id_controlcaja_mae  = " & ws_id & " and estado = 1 ")
        ' Recorremos las filas filtradas
        If Lista_cajas.Length = 0 Then
            CmdListaApe.Text = "..."
            CmdListaApe.Tag = 0
            CmdListaApe.AccessibleName = 0
            Activa_Botones(0)
            Exit Sub
        End If



        Dim wcadedet As String = formato_ListaCajas(Lista_cajas(0)("estado"), Lista_cajas(0)("fechahora_apertura"), Lista_cajas(0)("id_controlcaja_det"))
        CmdListaApe.Text = wcadedet
        CmdListaApe.Tag = Lista_cajas(0)("id_controlcaja_det")
        CmdListaApe.AccessibleName = Lista_cajas(0)("estado")
        Activa_Botones(Val(Lista_cajas(0)("estado")))
    End Sub
    Private Sub traer_Lista_controlcaja_det(wid_controlcaja As Integer)
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        command = New SqlCommand("sp_muestra_controlcajas_aperturas", lk_connection_cuenta)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.AddWithValue("@id_controlcaja_mae", wid_controlcaja)
        adaptador = New SqlDataAdapter(command)
        sql_reg_controlcaja_det = New DataTable
        adaptador.Fill(sql_reg_controlcaja_det)

    End Sub

    Private Sub verpanel(wpanel As String)
        PanelPrincipal.Visible = True
        PanelPrincipal.Dock = DockStyle.Fill
        PanelRegistros.Visible = False
        PanelCierre.Visible = False
        PanelApertura.Visible = False
        id_opcion.Text = wpanel
        If wpanel = "RE" Then
            PanelRegistros.Visible = True
            PanelRegistros.Dock = DockStyle.Fill
        ElseIf wpanel = "AP" Then
            PanelApertura.Visible = True
            PanelApertura.Dock = DockStyle.Fill
        ElseIf wpanel = "CI" Or wpanel = "VE" Then
            PanelCierre.Visible = True
            PanelCierre.Dock = DockStyle.Fill
        End If



    End Sub


    Private Sub CmdAperturar_Click(sender As Object, e As EventArgs)
        verpanel("AP")


        lfechahora_aper.Text = CDate(lk_fecha_dia).ToString("dd/MM/yyyy HH:mm")
        TxtMonto_aper.Text = "0"
        Txt_ref_aper.Text = ""
        TxtMonto_aper.Select()

    End Sub

    Private Sub CmdCierre_Click(sender As Object, e As EventArgs) Handles CmdCierre.Click
        verpanel("CI")
        Inicia_Cierre()

    End Sub
    Private Sub Inicia_Cierre()

        txt_usuario_cierre.Text = lk_usuario & " " & lk_sql_ValidaUsuario.Rows(0)("nombres").ToString().Trim & " " & lk_sql_ValidaUsuario.Rows(0)("apellidos").ToString().Trim

        TxtFecha_cierre.Text = CDate(Now.ToString("dd/MM/yyyy HH:mm"))
        OpDirecto.Checked = True
        EscojeModo(0)
        Muestra_Caja_efectivo(Val(CmdListaApe.Tag))
        TxtMonto.Text = ""
        txtRef_cierre.Text = ""
        cmdFormato.Enabled = False
        Muestra_Otros_Metodos(Val(CmdListaApe.Tag), "RM")


        Dim Cajas_abierta() As DataRow = sql_reg_controlcaja_det.Select("id_controlcaja_mae  = " & Val(CmdCajas.Tag) & " and estado = 1 and id_controlcaja_det = " & Val(CmdListaApe.Tag) & "")
        ' Recorremos las filas filtradas
        If Cajas_abierta.Length = 0 Then
            Dim Result As String = MensajesBox.Show("Verificar Situacion de la Caja Activa...",
                                   "Problemas de la Caja Aperturada.")
        End If
        Lbl_apertura_cierre.Text = Format(Cajas_abierta(0)("efectivo_apertura"), "0.00")
        txt_refapertura_cierre.Text = Cajas_abierta(0)("ref_apertura")



    End Sub
    Private Sub Muestra_Caja_efectivo(ws_id_controlcaja_det As Integer)
        GridIEfectivo_Inicia()
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim lk_sql_listafiltro = New DataTable()
        Dim wcade_filtro_oper As String = ""

        sql_cade = "select  base_oper_nom_oper, forma_codigo, forma ,simbolo, sum(total*signo_fn) as total 
                 from vw_finanzas_fn where id_negocio = @id_negocio and id_controlcaja_det= @id_controlcaja_det and forma_codigo = '01' and estado_enlace <> 10 
                 group by base_oper_nom_oper,forma_codigo,forma, simbolo "
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_controlcaja_det", ws_id_controlcaja_det)
        command.Parameters.Add(parametro)

        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listafiltro)
        If lk_sql_listafiltro.Rows.Count = 0 Then

            Dim Result As String = MensajesBox.Show("Caja Sin Operaciones con efectivo.",
                                    "Lista de Operación.")
            Exit Sub

        End If
        Dim witems As Integer = 0
        Dim ws_sumaefe As Double = 0
        For i = 0 To lk_sql_listafiltro.Rows.Count - 1

            Me.dg_efectivo.Rows.Add()
            witems = witems + 1

            dg_efectivo.Rows(dg_efectivo.Rows.Count - 1).Cells("num").Value = witems
            dg_efectivo.Rows(dg_efectivo.Rows.Count - 1).Cells("operacion").Value = lk_sql_listafiltro.Rows(i).Item("base_oper_nom_oper").ToString.Trim
            dg_efectivo.Rows(dg_efectivo.Rows.Count - 1).Cells("moneda").Value = lk_sql_listafiltro.Rows(i).Item("simbolo").ToString.Trim
            dg_efectivo.Rows(dg_efectivo.Rows.Count - 1).Cells("monto").Value = lk_sql_listafiltro.Rows(i).Item("total")
            ws_sumaefe = ws_sumaefe + lk_sql_listafiltro.Rows(i).Item("total")
        Next i
        Lbl_totalefectivo_cierre.Text = Format(ws_sumaefe, "#,##0.00")

    End Sub
    Private Sub GridIEfectivo_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim fechaColumna As New DataGridViewTextBoxColumn()

        Dim fuente_cabe As Font = New Font("Segoe UI", 9.25)
        Dim fuente_grid As Font = New Font("Segoe UI", 7.0F)



        dg_efectivo.Columns.Clear()
        dg_efectivo.DefaultCellStyle.Font = fuente_cabe





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        dg_efectivo.Columns.Add(textoColumn)
        dg_efectivo.Columns.Item(textoColumn.Name).Width = 25
        dg_efectivo.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "operacion"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "OPERACION"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        dg_efectivo.Columns.Add(textoColumn)
        dg_efectivo.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_efectivo.Columns.Item(textoColumn.Name).Width = 120
        'dg_efectivo.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_efectivo.Columns.Add(textoColumn)
        dg_efectivo.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_efectivo.Columns.Item(textoColumn.Name).Width = 30
        'dg_efectivo.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        dg_efectivo.Columns.Add(textoColumn)
        dg_efectivo.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_efectivo.Columns.Item(textoColumn.Name).MinimumWidth = 70

        dg_efectivo.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader


    End Sub

    Private Sub CmdListaApe_Click(sender As Object, e As EventArgs) Handles CmdListaApe.Click

        If Val(CmdCajas.Tag) = 0 Then
            Activa_Botones(0)
            Exit Sub
        End If
        CmdListaApe.Tag = 0
        Dim Lista_cajas_abiertas() As DataRow = sql_reg_controlcaja_det.Select("id_controlcaja_mae  = " & Val(CmdCajas.Tag) & " and estado = 1 ")
        ' Recorremos las filas filtradas
        If Lista_cajas_abiertas.Length <> 0 Then
            Dim wcadedet As String = "CAJA ABIERTA : " & CDate(Lista_cajas_abiertas(0)("fechahora_apertura")).ToString("dd/MM/yyyy HH:mm")
            CmdListaApe.Text = wcadedet
            CmdListaApe.Tag = Lista_cajas_abiertas(0)("id_controlcaja_det")
        End If


        '*********** LLENA MENU 

        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()



        Dim Lista_cajas() As DataRow = sql_reg_controlcaja_det.Select("id_controlcaja_mae <> 0 ")
        ' Recorremos las filas filtradas
        If Lista_cajas.Length = 0 Then
            Dim Result = MensajesBox.Show("Debe Aperturar Caja.",
                                     "Control ed Caja.")
            Activa_Botones(0)
            '  Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        If Val(CmdListaApe.Tag) = 0 Then ' Sino hay caja Abirta muestra Opcion
            Dim itemTodos As New ToolStripMenuItem("APERTURAR CAJA...")
            AddHandler itemTodos.Click, Sub()
                                            CmdListaApe.Text = "APERTURANDO..."
                                            CmdListaApe.Tag = -1
                                            CmdListaApe.AccessibleName = 0
                                            Hacer_Apertura()
                                        End Sub
            menu.Items.Add(itemTodos)
        End If
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In Lista_cajas
            Dim id As Integer = CInt(row("id_controlcaja_det"))
            Dim detalle As String = CStr(row("fechahora_apertura"))
            Dim westado As Integer = row("estado")
            detalle = formato_ListaCajas(westado, row("fechahora_apertura"), id)
            Dim item As New ToolStripMenuItem(detalle)

            AddHandler item.Click, Sub()
                                       MostrarControlCaja_det(id, detalle, westado)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdCajas, New Point(0, CmdCajas.Height))


    End Sub

    Private Sub Hacer_Apertura()
        verpanel("AP")
        lfechahora_aper.Text = CDate(lk_fecha_dia).ToString("dd/MM/yyyy HH:mm")
        TxtMonto_aper.Text = "0"
        Txt_ref_aper.Text = ""
        TxtMonto_aper.Select()
    End Sub
    Private Sub MostrarControlCaja_det(id As String, detalle As String, westado As String)


        CmdListaApe.Text = detalle
        CmdListaApe.Tag = id
        CmdListaApe.AccessibleName = westado
        Activa_Botones(Val(westado))
    End Sub

    Private Sub Activa_Botones(westado As Integer)


        CmdRegistros.Enabled = False
        CmdCierre.Enabled = False
        CmdValida.Enabled = False
        If westado = 0 Then
        ElseIf westado = 1 Then
            CmdRegistros.Enabled = True
            CmdCierre.Enabled = True
        ElseIf westado = 2 Then
            CmdRegistros.Enabled = True
            CmdValida.Enabled = True
        ElseIf westado = 3 Then
            CmdRegistros.Enabled = True
        End If

    End Sub

    Private Sub CmdGrabar_aper_Click(sender As Object, e As EventArgs) Handles CmdGrabar_aper.Click

        Dim ws_id_controlcaja_mae As Integer = Val(CmdCajas.Tag)
        Dim ws_id_controlcaja_det As Integer = 0


        Grabar_Registro_ControlCaja(1, ws_id_controlcaja_mae, ws_id_controlcaja_det)

        Inicia_Seleccion()

        Actualiza_ListaCajas(ws_id_controlcaja_mae)
        Iniciar_todo()

    End Sub

    Private Sub Grabar_Registro_ControlCaja(ws_tipo_estado As Integer, ws_id_controlcaja_mae As Integer, ws_id_controlcaja_det As Integer)

        Dim ws_id_negocio As Integer = lk_NegocioActivo.id_Negocio

        Dim ws_id_local As Integer = 0
        Dim ws_efectivo_apertura As Double = 0
        Dim ws_ref_apertura As String = ""
        Dim ws_id_usuario_apertura As Integer = 0
        Dim ws_equipo_apertura As String = ""

        Dim ws_efectivo_entrega As Double = 0
        Dim ws_efectivo_entrega_confirma As Double = 0
        Dim ws_efectivo_sobrante As Double = 0
        Dim ws_efectivo_faltante As Double = 0
        Dim ws_ref_cierre As String = ""
        Dim ws_id_usuario_cierre As Integer = 0
        Dim ws_equipo_cierre As String = ""
        Dim ws_estado As Integer = 0
        Dim ws_es_desglose As Integer = 0

        Dim werror As String = ""
        Dim Wresultado As String = ""



        If ws_tipo_estado = 1 Then
            ws_efectivo_apertura = If(TxtMonto_aper.Text = "", 0, TxtMonto_aper.Text)
            ws_ref_apertura = Txt_ref_aper.Text
            ws_estado = 1
            ws_id_usuario_apertura = lk_id_usuario
            ws_equipo_apertura = LK_NOMBRE_PC
            ws_es_desglose = 0
        End If
        If ws_tipo_estado = 2 Then
            ws_efectivo_entrega = If(TxtMonto.Text = "", 0, TxtMonto.Text)
            ws_ref_cierre = txtRef_cierre.Text
            ws_estado = 2
            ws_id_usuario_cierre = lk_id_usuario
            ws_equipo_cierre = LK_NOMBRE_PC
            If OpDesglose.Checked Then ws_es_desglose = 1
        End If
        If ws_tipo_estado = 3 Then
            ws_estado = 3
            If ChekReconteo.Checked Then
                ws_efectivo_entrega_confirma = If(txt_reconteo_cierre.Text = "", 0, txt_reconteo_cierre.Text)
            Else
                ws_efectivo_entrega_confirma = If(TxtMonto.Text = "", 0, TxtMonto.Text)

            End If
        End If





        Dim dt_desglose As New DataTable()
        dt_desglose.Columns.Add("id_negocio", GetType(Integer))
        dt_desglose.Columns.Add("id_controlcaja_det", GetType(Integer))
        dt_desglose.Columns.Add("id_controlcaja_mae", GetType(Integer))
        dt_desglose.Columns.Add("numsec", GetType(Integer))
        dt_desglose.Columns.Add("id_dinero", GetType(Integer))
        dt_desglose.Columns.Add("cantidad", GetType(Integer))
        If ws_tipo_estado = 2 And OpDesglose.Checked Then
            dt_desglose = asigna_desglose(ws_id_negocio, ws_id_controlcaja_det, ws_id_controlcaja_mae)
        End If




        Using command As New SqlCommand("sp_insert_controlcajas_det", lk_connection_cuenta)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Clear()
            ' Agrega los parámetros de entrada
            command.Parameters.AddWithValue("@tipo_estado", ws_tipo_estado)
            command.Parameters.AddWithValue("@es_desglose", ws_es_desglose)
            command.Parameters.AddWithValue("@id_negocio", ws_id_negocio)
            command.Parameters.AddWithValue("@id_controlcaja_det", ws_id_controlcaja_det)
            command.Parameters.AddWithValue("@id_controlcaja_mae", ws_id_controlcaja_mae)
            command.Parameters.AddWithValue("@id_local", ws_id_local)
            command.Parameters.AddWithValue("@efectivo_apertura", ws_efectivo_apertura)
            command.Parameters.AddWithValue("@ref_apertura", ws_ref_apertura)
            command.Parameters.AddWithValue("@id_usuario_apertura", ws_id_usuario_apertura)
            command.Parameters.AddWithValue("@equipo_apertura", ws_equipo_apertura)
            command.Parameters.AddWithValue("@efectivo_entrega", ws_efectivo_entrega)
            command.Parameters.AddWithValue("@efectivo_entrega_confirma", ws_efectivo_entrega_confirma)
            command.Parameters.AddWithValue("@efectivo_sobrante", ws_efectivo_sobrante)
            command.Parameters.AddWithValue("@efectivo_faltante", ws_efectivo_faltante)
            command.Parameters.AddWithValue("@ref_cierre", ws_ref_cierre)
            command.Parameters.AddWithValue("@id_usuario_cierre", ws_id_usuario_cierre)
            command.Parameters.AddWithValue("@equipo_cierre", ws_equipo_cierre)
            command.Parameters.AddWithValue("@estado", ws_estado)



            ' Agrega el parámetro de tabla temporal de detalle
            Dim det_desglose As SqlParameter = command.Parameters.AddWithValue("@tabladesglose", dt_desglose)


            'Dim resultado As String = String.Empty
            command.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            det_desglose.SqlDbType = SqlDbType.Structured
            'det_desglose.TypeName = "dbo.Tipo_add_m_comprobantes_det"


            ' Ejecuta el comando
            'Try
            command.ExecuteNonQuery()
            If command.Parameters("@Resultado").Value IsNot DBNull.Value Then
                Wresultado = DirectCast(command.Parameters("@Resultado").Value, String)
            Else
                ' Manejar el caso en el que el valor es DBNull (nulo)
                ' Por ejemplo, puedes asignar un valor predeterminado a Wresultado o lanzar una excepción personalizada.
            End If

            'Wresultado = DirectCast(command.Parameters("@Resultado").Value, String)
            'wreg_sec_numint = DirectCast(cmd.Parameters("@reg_sec_numint").Value, Integer)
            'wreg_sec_numcomp = DirectCast(cmd.Parameters("@reg_sec_numcomp").Value, Integer)


            'Catch ex As Exception
            ' werror = ex.Message
            ' manejo de excepciones  ex.Message 
            'End Try
            'cmd.ExecuteNonQuery()
            ' Dim resultado As String = resultadoParam.Value.ToString()
            'MsgBox(resultado)
        End Using

        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If
        If Wresultado <> String.Empty Then
            Dim Result = MensajesBox.Show("Registro Efectuado. Caja Aperturada",
                                     "Control ed Caja.")


            '  SMS_Barra("REGISTRO GRABADO CON EXITO : " & Wresultado, 1)
            ' Datos despuestde ede la grabacion Muestra COmprobantes Grabados

            'TxtComp_Numero.Text = Format(wreg_sec_numcomp, "00000000")
            'TxtNumDocOper.Text = Format(wreg_sec_numint, "00000000")
            'CancelaOper("GRABAR")
            'If CmdOperacion.AccessibleDescription <> "" Then 'Primera Ubiacion 
            '    SaltoBox(CmdOperacion.AccessibleDescription)
            'End If
        End If



    End Sub
    Private Function asigna_desglose(wid_negocio As Integer, wid_controlcaja_det As Integer, wid_controlcaja_mae As Integer) As DataTable
        Dim wnumsec As Integer = 0
        Dim wid_dinero As Integer
        Dim wcantidad As Integer


        Dim dt_desglose As New DataTable()
        dt_desglose.Columns.Add("id_negocio", GetType(Integer))
        dt_desglose.Columns.Add("id_controlcaja_det", GetType(Integer))
        dt_desglose.Columns.Add("id_controlcaja_mae", GetType(Integer))
        dt_desglose.Columns.Add("numsec", GetType(Integer))
        dt_desglose.Columns.Add("id_dinero", GetType(Integer))
        dt_desglose.Columns.Add("cantidad", GetType(Integer))
        If OpDesglose.Checked = False Then

            Return dt_desglose
            Exit Function
        End If
        wnumsec = 0
        '** lleno monedas

        For i = 0 To dg_monedas.Rows.Count - 1
            wcantidad = dg_monedas.Rows(i).Cells("cant_moneda").Value
            wid_dinero = dg_monedas.Rows(i).Cells("id_moneda").Value
            If wid_dinero <> 0 And wcantidad <> 0 Then
                wnumsec = wnumsec + 1
                wid_dinero = dg_monedas.Rows(i).Cells("id_moneda").Value
                dt_desglose.Rows.Add(wid_negocio, wid_controlcaja_det, wid_controlcaja_mae, wnumsec, wid_dinero, wcantidad)
            End If
        Next i

        '** lleno billetes
        For i = 0 To dg_monedas.Rows.Count - 1
            wcantidad = dg_monedas.Rows(i).Cells("cant_billete").Value
            wid_dinero = dg_monedas.Rows(i).Cells("id_billete").Value
            If wid_dinero <> 0 And wcantidad <> 0 Then
                wnumsec = wnumsec + 1
                dt_desglose.Rows.Add(wid_negocio, wid_controlcaja_det, wid_controlcaja_mae, wnumsec, wid_dinero, wcantidad)
            End If
        Next i


        Return dt_desglose
    End Function
    Private Sub CmdCancelar_aper_Click(sender As Object, e As EventArgs) Handles CmdCancelar_aper.Click
        Activa_Botones(0)
        verpanel("")
        CmdListaApe.Text = "..."
        CmdListaApe.Tag = 0
        CmdListaApe.AccessibleName = 0
        Iniciar_todo()

    End Sub
    Private Sub Inicia_Seleccion()
        Activa_Botones(0)
        verpanel("")
        CmdListaApe.Text = "..."
        CmdListaApe.Tag = 0
        CmdListaApe.AccessibleName = 0
    End Sub
    Private Sub CmdGrabar_cierre_Click(sender As Object, e As EventArgs) Handles CmdGrabar_cierre.Click
        Dim ws_id_controlcaja_mae As Integer = Val(CmdCajas.Tag)
        Dim ws_id_controlcaja_det As Integer = Val(CmdListaApe.Tag)
        If ws_id_controlcaja_det = 0 Or ws_id_controlcaja_mae = 0 Then
            Dim Result = MensajesBox.Show("Verificar , debe selecionar una Caja con apertura.",
                                     "Control ed Caja.")
        End If
        If id_opcion.Text = "VE" Then
            Grabar_Registro_ControlCaja(3, ws_id_controlcaja_mae, ws_id_controlcaja_det)
        ElseIf id_opcion.Text = "CI" Then
            Grabar_Registro_ControlCaja(2, ws_id_controlcaja_mae, ws_id_controlcaja_det)
        End If


        Inicia_Seleccion()

        Actualiza_ListaCajas(ws_id_controlcaja_mae)
        Iniciar_todo()

    End Sub

    Private Sub CmdCancelar_cierre_Click(sender As Object, e As EventArgs) Handles CmdCancelar_cierre.Click
        Activa_Botones(0)
        verpanel("")
        CmdListaApe.Text = "..."
        CmdListaApe.Tag = 0
        CmdListaApe.AccessibleName = 0
        Iniciar_todo()
    End Sub
    Private Sub Iniciar_todo()
        Lbl_apertura_cierre.Text = ""
        Lbl_totalefectivo_cierre.Text = ""
        Lbl_entregaconteo_cierre.Text = ""
        txt_reconteo_cierre.Text = ""
        TxtMonto.Text = ""
        txt_reconteo_cierre.Text = ""
        txt_sob_cierre.Text = ""
        txt_fal_cierre.Text = ""
        txt_refapertura_cierre.Text = ""
        txtRef_cierre.Text = ""
        dg_otras.Rows.Clear()
        dg_efectivo.Rows.Clear()
        dg_monedas.Rows.Clear()
        TxtMonto_aper.Text = ""
        Txt_ref_aper.Text = ""
        CheConfirmaCierre.Checked = False
        CheConfirmaCierre_otros.Checked = False
        ChekReconteo.Checked = False
        Campos_del_cierre_casilla(True)

    End Sub
    Private Sub GridRegistros_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim fechaColumna As New DataGridViewTextBoxColumn()

        Dim fuente_cabe As Font = New Font("Segoe UI", 8.0)
        Dim fuente_grid As Font = New Font("Segoe UI", 7.0F)



        dg_registros.Columns.Clear()
        dg_registros.DefaultCellStyle.Font = fuente_cabe





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).Width = 32
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 50
        dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "operacion"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "OPERACION"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 70
        ' dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechahora"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "FECHA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 100
        'dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "tipo"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "REF. TIPO COMPROB."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 60
        'dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "REF. SERIE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 40
        ' dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "REF. NUMERO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 60
        'dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = fuente_grid
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "vercomp"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_registros.Columns.Add(imageColumn)
        dg_registros.Columns.Item(imageColumn.Name).Width = 40
        dg_registros.Columns.Item(imageColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "socio"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "SOCIO NEGOCIO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 230
        'dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "metodo"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "METODO PAGO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 70
        dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "entidad"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "ENTIDAD FINANZ"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 70
        dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 30
        dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "estado"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "ESTADO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_registros.Columns.Item(textoColumn.Name).Width = 70
        dg_registros.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id"
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "signo_fn"
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        dg_registros.Columns.Add(textoColumn)
        dg_registros.Columns.Item(textoColumn.Name).Visible = False








    End Sub

    Private Sub CmdRegistros_Click(sender As Object, e As EventArgs) Handles CmdRegistros.Click
        verpanel("RE")
        Muestra_Registro_caja(Val(CmdListaApe.Tag))
    End Sub
    Private Sub Muestra_Registro_caja(wid_controlcaja_det As Integer)
        GridRegistros_Inicia()

        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim lk_sql_listafiltro = New DataTable()
        Dim wcade_filtro_oper As String = ""

        CheConfirmaCierre.Checked = False
        CheConfirmaCierre_otros.Checked = False
        ' == Lista de SubOperaciones de todas las operaciones de la plataforma
        sql_cade = "exec [sp_muestra_controlcajas_registros] @id_negocio , @id_controlcaja_det"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_controlcaja_det", wid_controlcaja_det)
        command.Parameters.Add(parametro)

        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listafiltro)
        If lk_sql_listafiltro.Rows.Count = 0 Then

            Dim Result As String = MensajesBox.Show("No Existe Registros en su consulta.",
                                    "Lista de Operación.")
            Exit Sub

        End If
        Dim witems As Integer = 0
        For i = 0 To lk_sql_listafiltro.Rows.Count - 1

            Me.dg_registros.Rows.Add()
            witems = witems + 1

            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("num").Value = witems
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("local").Value = lk_sql_listafiltro.Rows(i).Item("local_codigo").ToString.Trim & " " & lk_sql_listafiltro.Rows(i).Item("local_abreviado").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("operacion").Value = lk_sql_listafiltro.Rows(i).Item("base_oper_nom_oper").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("fechahora").Value = CDate(lk_sql_listafiltro.Rows(i).Item("fechahora")).ToString("dd/MM/yyyy HH:mm")
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("tipo").Value = lk_sql_listafiltro.Rows(i).Item("base_abreviado").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("serie").Value = lk_sql_listafiltro.Rows(i).Item("base_serie_comp").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("numero").Value = Format(lk_sql_listafiltro.Rows(i).Item("base_numero_comp"), "00000000")

            'dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("ver").Value = 

            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("socio").Value = lk_sql_listafiltro.Rows(i).Item("sn_razonsocial").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("metodo").Value = lk_sql_listafiltro.Rows(i).Item("forma").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("entidad").Value = lk_sql_listafiltro.Rows(i).Item("entidad").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("moneda").Value = lk_sql_listafiltro.Rows(i).Item("simbolo").ToString.Trim
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("monto").Value = lk_sql_listafiltro.Rows(i).Item("total")
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("estado").Tag = lk_sql_listafiltro.Rows(i).Item("base_estado_comp")
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("estado").Value = MuestraEstadoComp(lk_sql_listafiltro.Rows(i).Item("base_estado_comp"))
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("signo_fn").Value = lk_sql_listafiltro.Rows(i).Item("signo_fn")

            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("id_oper_maestro").Value = lk_sql_listafiltro.Rows(i).Item("base_id_oper_maestro")
            dg_registros.Rows(dg_registros.Rows.Count - 1).Cells("id_comp_cab").Value = lk_sql_listafiltro.Rows(i).Item("base_id_comp_cab")




        Next i
    End Sub

    Private Sub dg_registros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_registros.CellContentClick

    End Sub

    Private Sub dg_registros_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_registros.CellFormatting
        If e.ColumnIndex = dg_registros.Columns("estado").Index AndAlso e.RowIndex >= 0 Then
            Dim estado As String = CStr(e.Value)
            Dim codigoEstado As String = CStr(dg_registros.Rows(e.RowIndex).Cells("estado").Tag)

            ' Asignar color al texto según el tipo de estado
            Select Case codigoEstado
                Case "1"

                Case "2"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorNaranja)

                Case "3"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)

                Case "8"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoVerde)

                Case "10"
                    e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorRojo)
                Case Else
                    ' Establecer el color predeterminado para otros casos
                    e.CellStyle.ForeColor = dg_registros.DefaultCellStyle.ForeColor
            End Select
        End If
        If e.ColumnIndex = dg_registros.Columns("monto").Index AndAlso e.RowIndex >= 0 Then
            Dim estado As String = CStr(e.Value)
            Dim ws_total As String = Val(dg_registros.Rows(e.RowIndex).Cells("monto").Value)

            ' Asignar color al texto según el tipo de estado
            If ws_total <= 0 Then
                e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoRojo)
            Else
                e.CellStyle.ForeColor = dg_registros.DefaultCellStyle.ForeColor
            End If
        End If

    End Sub
    Private Function MuestraEstadoComp(westado As Integer) As String
        Dim wretor As String = ""
        Select Case westado
            Case 0
                wretor = "CREANDO."
            Case 1
                wretor = "ABIERTO"
            Case 2
                wretor = "PARCIALMENTE ABIERTO"
            Case 3
                wretor = "CERRADO"

            Case 8
                wretor = "CERRADO-AT"

            Case 10
                wretor = "ANULADO."
        End Select
        Return wretor
    End Function
    Private Sub Muestra_Otros_Metodos(ws_id_controlcaja_det As Integer, wtiporesumen As String)
        GridOtrosMetodos_Inicia()
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim lk_sql_listafiltro = New DataTable()
        Dim wcade_filtro_oper As String = ""
        sql_cade = ""
        If wtiporesumen = "RM" Then  ' POR METOD DE PAGO
            dg_otras.Columns.Item("entidad").Visible = False


            sql_cade = "select  forma_codigo, forma ,base_oper_nom_oper , simbolo, sum(total*signo_fn)  total
                    from vw_finanzas_fn where id_negocio = @id_negocio and id_controlcaja_det= @id_controlcaja_det and forma_codigo <> '01'
                    group by forma_codigo,forma, base_oper_nom_oper ,simbolo"
        ElseIf wtiporesumen = "RS" Then  ' POR SIGNO O INGRESOS Y EGRESOS
            dg_otras.Columns.Item("entidad").Visible = True
            sql_cade = "select  forma_codigo, forma ,base_oper_nom_oper,simbolo,entidad, signo_fn, sum(total*signo_fn)  total
                        from vw_finanzas_fn where id_negocio = @id_negocio and id_controlcaja_det= @id_controlcaja_det and forma_codigo <> '01'
                        group by forma_codigo,forma ,base_oper_nom_oper,simbolo,entidad, signo_fn"
        End If
        If sql_cade = "" Then Exit Sub
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_controlcaja_det", ws_id_controlcaja_det)
        command.Parameters.Add(parametro)

        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listafiltro)
        If lk_sql_listafiltro.Rows.Count = 0 Then

            'Dim Result As String = MensajesBox.Show("Caja Sin Operaciones con Otros Metodos de Pago.",
            '                        "Lista de Operación.")
            Exit Sub

        End If
        Dim witems As Integer = 0
        For i = 0 To lk_sql_listafiltro.Rows.Count - 1

            Me.dg_otras.Rows.Add()
            witems = witems + 1

            dg_otras.Rows(dg_otras.Rows.Count - 1).Cells("num").Value = witems
            dg_otras.Rows(dg_otras.Rows.Count - 1).Cells("metodo").Value = lk_sql_listafiltro.Rows(i).Item("forma").ToString.Trim & " " & lk_sql_listafiltro.Rows(i).Item("base_oper_nom_oper").ToString.Trim
            dg_otras.Rows(dg_otras.Rows.Count - 1).Cells("moneda").Value = lk_sql_listafiltro.Rows(i).Item("simbolo").ToString.Trim
            If wtiporesumen = "RM" Then  ' POR METOD DE PAGO
            Else
                dg_otras.Rows(dg_otras.Rows.Count - 1).Cells("entidad").Value = lk_sql_listafiltro.Rows(i).Item("entidad").ToString.Trim
            End If

            dg_otras.Rows(dg_otras.Rows.Count - 1).Cells("monto").Value = lk_sql_listafiltro.Rows(i).Item("total")

        Next i


    End Sub
    Private Sub GridOtrosMetodos_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim fechaColumna As New DataGridViewTextBoxColumn()

        Dim fuente_cabe As Font = New Font("Segoe UI", 9.0)
        Dim fuente_grid As Font = New Font("Segoe UI", 7.0F)



        dg_otras.Columns.Clear()
        dg_otras.DefaultCellStyle.Font = fuente_cabe





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        dg_otras.Columns.Add(textoColumn)
        dg_otras.Columns.Item(textoColumn.Name).Width = 25
        dg_otras.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "metodo"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "METODO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        dg_otras.Columns.Add(textoColumn)
        dg_otras.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_otras.Columns.Item(textoColumn.Name).Width = 180
        'dg_otras.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "entidad"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "ENTIDAD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha
        dg_otras.Columns.Add(textoColumn)
        dg_otras.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_otras.Columns.Item(textoColumn.Name).Width = 90
        'dg_otras.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_otras.Columns.Add(textoColumn)
        dg_otras.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_otras.Columns.Item(textoColumn.Name).Width = 30
        dg_otras.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = fuente_grid
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        dg_otras.Columns.Add(textoColumn)
        dg_otras.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_otras.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_otras.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader


    End Sub

    Private Sub TxtMonto_TextChanged(sender As Object, e As EventArgs) Handles TxtMonto.TextChanged
        Lbl_entregaconteo_cierre.Text = TxtMonto.Text
        CalculaEfectivoCierre()
    End Sub

    Private Sub CheConfirmaCierre_CheckedChanged(sender As Object, e As EventArgs) Handles CheConfirmaCierre.CheckedChanged
        If CheConfirmaCierre.Checked And CheConfirmaCierre_otros.Checked Then
            CmdGrabar_cierre.Enabled = True
        Else
            CmdGrabar_cierre.Enabled = False
        End If
    End Sub
    Private Sub CalculaEfectivoCierre()
        Dim ws_aper As Double = If(Lbl_apertura_cierre.Text = "", 0, Lbl_apertura_cierre.Text)
        Dim ws_Total_Movi_efectivo As Double = If(Lbl_totalefectivo_cierre.Text = "", 0, Lbl_totalefectivo_cierre.Text)
        Dim ws_entregaefe As Double = If(Lbl_entregaconteo_cierre.Text = "", 0, Lbl_entregaconteo_cierre.Text)
        Dim ws_reconteo As Double = If(txt_reconteo_cierre.Text = "", 0, txt_reconteo_cierre.Text)

        Dim wsresulefectivo As Double = 0

        Dim ws_sobrante As Double = 0
        Dim ws_faltante As Double = 0

        wsresulefectivo = ws_entregaefe - (ws_aper + ws_Total_Movi_efectivo)
        If ChekReconteo.Checked Then
            wsresulefectivo = ws_reconteo - (ws_aper + ws_Total_Movi_efectivo)
        End If
        If wsresulefectivo = 0 Then

        ElseIf wsresulefectivo < 0 Then
            ws_faltante = wsresulefectivo
        ElseIf wsresulefectivo > 0 Then
            ws_sobrante = wsresulefectivo
        End If

        txt_fal_cierre.Text = If(ws_faltante = 0, "", Format(ws_faltante, "##0.00"))

        txt_sob_cierre.Text = If(ws_sobrante = 0, "", Format(ws_sobrante, "##0.00"))
        If ws_faltante <> 0 Then
            txt_fal_cierre.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoRojo)
        End If
        If ws_Total_Movi_efectivo < 0 Then
            Lbl_totalefectivo_cierre.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoRojo)
        Else
            Lbl_totalefectivo_cierre.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoNegro)
        End If




    End Sub

    Private Sub txt_reconteo_cierre_TextChanged(sender As Object, e As EventArgs) Handles txt_reconteo_cierre.TextChanged
        CalculaEfectivoCierre()
    End Sub

    Private Sub CheConfirmaCierre_otros_CheckedChanged(sender As Object, e As EventArgs) Handles CheConfirmaCierre_otros.CheckedChanged
        If CheConfirmaCierre.Checked And CheConfirmaCierre_otros.Checked Then
            CmdGrabar_cierre.Enabled = True
        Else
            CmdGrabar_cierre.Enabled = False
        End If
    End Sub

    Private Sub CmdValida_Click(sender As Object, e As EventArgs) Handles CmdValida.Click
        verpanel("VE")
        Inicia_Validar()

    End Sub
    Private Sub Inicia_Validar()

        Dim Cajas_abierta() As DataRow = sql_reg_controlcaja_det.Select("id_controlcaja_mae  = " & Val(CmdCajas.Tag) & " and estado = 2 and id_controlcaja_det = " & Val(CmdListaApe.Tag) & "")
        ' Recorremos las filas filtradas
        If Cajas_abierta.Length = 0 Then
            Dim Result As String = MensajesBox.Show("Verificar Situacion de la Caja Activa...",
                                   "Problemas de la Caja Aperturada.")
        End If
        Lbl_apertura_cierre.Text = Format(Cajas_abierta(0)("efectivo_apertura"), "0.00")
        txt_refapertura_cierre.Text = Cajas_abierta(0)("ref_apertura")
        txt_usuario_cierre.Text = Cajas_abierta(0)("id_usuario_cierre")
        TxtFecha_cierre.Text = CDate(Cajas_abierta(0)("fechahora_cierre")).ToString("dd/MM/yyyy HH:mm")
        If Cajas_abierta(0)("es_desglose") = 1 Then
            OpDesglose.Checked = True
        Else
            OpDirecto.Checked = True
        End If
        EscojeModo(1)
        cmdFormato.Enabled = True
        TxtMonto.Text = Format(Cajas_abierta(0)("efectivo_entrega"), "0.00")
        txtRef_cierre.Text = Cajas_abierta(0)("ref_cierre").ToString.Trim
        Muestra_Caja_efectivo(Val(CmdListaApe.Tag))
        Muestra_Otros_Metodos(Val(CmdListaApe.Tag), "RM")
        CalculaEfectivoCierre()
        Campos_del_cierre_casilla(False)

    End Sub
    Private Sub Campos_del_cierre_casilla(wes_situacion As Boolean)
        txt_refapertura_cierre.Enabled = wes_situacion
        TxtFecha_cierre.Enabled = wes_situacion
        TxtMonto.Enabled = wes_situacion
        txtRef_cierre.Enabled = wes_situacion
        If wes_situacion = False Then
            CheConfirmaCierre.Checked = True
            CheConfirmaCierre_otros.Checked = True
        End If
        CheConfirmaCierre.Enabled = wes_situacion
        CheConfirmaCierre_otros.Enabled = wes_situacion
    End Sub

    Private Sub ChekReconteo_CheckedChanged(sender As Object, e As EventArgs) Handles ChekReconteo.CheckedChanged
        If ChekReconteo.Checked Then
            txt_reconteo_cierre.Enabled = True
            txt_reconteo_cierre.Select()
        Else
            txt_reconteo_cierre.Text = ""
            txt_reconteo_cierre.Enabled = False

        End If
    End Sub

    Private Sub dg_registros_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_registros.CellClick
        dg_registros.Enabled = False
        If e.RowIndex < 0 Then Exit Sub
        Dim columnName As String = dg_registros.Columns(e.ColumnIndex).Name ' Obtener el nombre de la columna actual



        If columnName = "vercomp" Then GoTo IrComprobante

        dg_registros.Enabled = True
        Exit Sub
IrComprobante:

        PlaySonidoMouse(lk_CodigoSonido)


        If lk_NegocioActivo.id_Negocio = 0 Then
            Dim result = MensajesBox.Show("Bloqueo por Negocio No activo", lk_cabeza_msgbox)
            Exit Sub
        End If
        Dim frCargainfo As New FrmCarga
        frCargainfo.LogoMuestra.Visible = False
        frCargainfo.LogoSolicdo.Visible = True
        frCargainfo.Show()

        Dim frMenuOperacion As New FrmOperaciones
        frMenuOperacion.ENLACE_TIPO = "2"
        frMenuOperacion.ENLACE_MUESTRA_id_oper_maestro = Val(dg_registros.Rows(e.RowIndex).Cells("id_oper_maestro").Value)
        frMenuOperacion.ENLACE_MUESTRA_id_comp_cabe = Val(dg_registros.Rows(e.RowIndex).Cells("id_comp_cab").Value)
        frMenuOperacion.Show()
        frMenuOperacion.TopLevel = False
        FrmLogin.PanelFormularios.Controls.Add(frMenuOperacion)
        frMenuOperacion.Left = Me.Left + 10
        frMenuOperacion.Top = Me.Top + 10
        FrmLogin.PanelFormularios.Controls.Item(FrmLogin.PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        SelectNextControl(ActiveControl, True, True, True, True)
        frMenuOperacion.Focus()
        frMenuOperacion.CmdGrabar.Focus()
        frCargainfo.Close()
        dg_registros.Enabled = True
    End Sub

    Private Sub opRS_CheckedChanged(sender As Object, e As EventArgs) Handles opRS.CheckedChanged
        If opRS.Checked Then Muestra_Otros_Metodos(Val(CmdListaApe.Tag), "RS")
    End Sub

    Private Sub opRM_CheckedChanged(sender As Object, e As EventArgs) Handles opRM.CheckedChanged
        If opRM.Checked Then Muestra_Otros_Metodos(Val(CmdListaApe.Tag), "RM")
    End Sub

    Private Sub dg_otras_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_otras.CellContentClick

    End Sub

    Private Sub dg_otras_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_otras.CellFormatting
        If e.ColumnIndex = dg_otras.Columns("monto").Index AndAlso e.RowIndex >= 0 Then
            Dim estado As String = CStr(e.Value)
            Dim ws_total As String = Val(dg_otras.Rows(e.RowIndex).Cells("monto").Value)

            ' Asignar color al texto según el tipo de estado
            If ws_total <= 0 Then
                e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoRojo)
            Else
                e.CellStyle.ForeColor = dg_otras.DefaultCellStyle.ForeColor
            End If
        End If
    End Sub

    Private Sub dg_efectivo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_efectivo.CellContentClick

    End Sub

    Private Sub dg_efectivo_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_efectivo.CellFormatting
        If e.ColumnIndex = dg_efectivo.Columns("monto").Index AndAlso e.RowIndex >= 0 Then
            Dim estado As String = CStr(e.Value)
            Dim ws_total As String = Val(dg_efectivo.Rows(e.RowIndex).Cells("monto").Value)

            ' Asignar color al texto según el tipo de estado
            If ws_total <= 0 Then
                e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(strColorModoRojo)
            Else
                e.CellStyle.ForeColor = dg_efectivo.DefaultCellStyle.ForeColor
            End If
        End If
    End Sub

    Private Sub TxtMonto_aper_TextChanged(sender As Object, e As EventArgs) Handles TxtMonto_aper.TextChanged

    End Sub

    Private Sub TxtMonto_aper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMonto_aper.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            MoveFocusToNextControl(DirectCast(sender, Control))
        End If
    End Sub
    Private Sub MoveFocusToNextControl(currentControl As Control)
        Dim nextControl As Control = GetNextControl(currentControl, True)

        If nextControl IsNot Nothing Then
            If TypeOf nextControl Is TextBox Then
                nextControl.Focus()
            ElseIf TypeOf nextControl Is Button Then
                DirectCast(nextControl, Button).PerformClick()
            End If
        End If
    End Sub

    Private Sub TxtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMonto.KeyPress
        e.Handled = Solo_Numerico(e, TxtMonto)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            MoveFocusToNextControl(DirectCast(sender, Control))
        End If
    End Sub

    Private Sub txt_reconteo_cierre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_reconteo_cierre.KeyPress
        e.Handled = Solo_Numerico(e, txt_reconteo_cierre)
    End Sub

    Private Sub cmdFormato_Click(sender As Object, e As EventArgs) Handles cmdFormato.Click

    End Sub
    Private Sub Envia_formato(dt_Enlace_Envio_Oper As DataTable, wid_tb_oper As Integer, wcodigo_formato As String)
        If dt_Enlace_Envio_Oper Is Nothing Then
            Exit Sub
        End If
        'Dim Listaformato() As DataRow = loc_sql_lista_formato.Select("id_tb_oper =  " & wid_tb_oper & " and codigo = '" & wcodigo_formato & "'")
        '' Recorremos las filas filtradas
        'If Listaformato.Length = 0 Then
        '    Dim Result = MensajesBox.Show("Comprobante no tiene asignado Formato de impresion.",
        '                             "Operación.")
        '    Exit Sub
        'End If
        '================================
        ' Destino:
        ' 1- no imprime
        ' 2- impresora
        ' 3- panrtalla
        ' 4- PDF
        ' formato:
        ' 1- 56
        ' 2- 80
        ' 3- a4
        '================================

        'Dim wid_destino As Integer = Listaformato(0)("id_destino")
        'If wid_destino = 1 Then Exit Sub ' NO ENVIA NADA


        'Dim wid_formato As Integer = Listaformato(0)("id_formato")
        'Dim wimp1 As String = Listaformato(0)("impresora1")
        'Dim wimp2 As String = Listaformato(0)("impresora2")
        'Dim wimp3 As String = Listaformato(0)("impresora3")
        'Dim wnrocopias As String = Listaformato(0)("id_copias")
        'Dim warchivo56 As String = Listaformato(0)("archivo56")
        'Dim warchivo80 As String = Listaformato(0)("archivo80")
        'Dim warchivoA4 As String = Listaformato(0)("archivoA4")





        'Dim frformato As New FrmFormatosCR

        'frformato.TopLevel = False
        'frformato.DataSeleccion = dt_Enlace_Envio_Oper
        'frformato.LOC_NOMBRE_IMPRESORA = wimp1
        'frformato.LOC_ID_FORMATO = wid_formato
        'frformato.LOC_ID_DESTINO = wid_destino
        'frformato.LOC_COPIAS = wnrocopias
        'If wid_formato = 1 Then '56
        '    frformato.LOC_NOMBRE_ARCHIVO = warchivo56
        'ElseIf wid_formato = 2 Then '80
        '    frformato.LOC_NOMBRE_ARCHIVO = warchivo80
        'ElseIf wid_formato = 3 Then 'a4
        '    frformato.LOC_NOMBRE_ARCHIVO = warchivoA4
        'Else
        '    frformato.LOC_NOMBRE_ARCHIVO = ""
        'End If


        'frformato.TituloInforme = CmdComprob.Text.Trim & " " & TxtSerireComp.Text & " " & TxtComp_Numero.Text
        'FrmLogin.PanelFormularios.Controls.Add(frformato)
        'FrmLogin.PanelFormularios.Controls.Item(FrmLogin.PanelFormularios.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        'frformato.Show()
        'If frformato.ES_CIERRE_FORMATO = 1 Then
        '    frformato.Close()
        'Else
        '    SelectNextControl(ActiveControl, True, True, True, True)
        '    frformato.Focus()
        'End If


    End Sub

End Class