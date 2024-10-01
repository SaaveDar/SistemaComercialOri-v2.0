
Imports System.Data.SqlClient
Imports System.Net
Imports System.Runtime.InteropServices
Imports Newtonsoft.Json.Linq
Imports RestSharp

Public Class FrmSaldosSN
    Public Property DataSeleccion As New DataTable
    Public Property FORM_tipo_balance As Integer
    Public Property FORM_fijar_sn As Integer
    Public Property FORM_id_sn_maestro As Integer
    Public Property FORM_codigo_sn As Integer
    Public Property FORM_box_sn As String


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




    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub TxtSocio_BoxSN_TextChanged(sender As Object, e As EventArgs) Handles TxtSocio_BoxSN.TextChanged
        Dim idgrid As Integer







        If Len(TxtSocio_BoxSN.Text) = 3 Then
            If Not IsNumeric(TxtSocio_BoxSN.Text) Then

                Dim frbusca As New FrmMenuConfigurar

                frbusca.TxtCodigo.Tag = 100
                frbusca.TxtBuscar.Tag = TxtSocio_BoxSN.Text
                frbusca.TxtBuscar.Tag = TxtSocio_BoxSN.Text
                frbusca.ENLACE_VIENE = "PROCESOS"


                frbusca.ShowDialog()

                idgrid = Val(frbusca.CmdBuscar.Tag)
                If idgrid <> -1 Then
                    Try
                        info_SN.Text = frbusca.DataGridResul.Rows(idgrid).Cells("boxsn").Value.ToString()
                        info_SN.Tag = frbusca.DataGridResul.Rows(idgrid).Cells("id_sn_maestro").Value.ToString()
                        info_SN.Tag = frbusca.DataGridResul.Rows(idgrid).Cells("id_sn_maestro").Value.ToString()
                        TxtSocio_BoxSN.Text = frbusca.DataGridResul.Rows(idgrid).Cells("codigo").Value.ToString()
                        CmdBuscaComp_Click(Nothing, Nothing)
                    Catch

                    End Try
                    TxtSocio_BoxSN.Select()
                    TxtSocio_BoxSN.SelectionStart = TxtSocio_BoxSN.Text.Length
                End If

                frbusca.Close()
                'BuscaProductos = False
            End If
        End If
    End Sub

    Private Sub TxtSocio_BoxSN_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSocio_BoxSN.KeyDown
        If e.KeyCode = Keys.F2 Then
            BOXSN_Modo(TxtSocio_BoxSN)
        End If
    End Sub
    Private Sub BOXSN_Modo(TxtSocio As TextBox)
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        'If Val(CmdTipoOper.Tag) = 0 Then Exit Sub
        Exit Sub

        Dim ListaTipoOperacion() As DataRow = lk_sql_listaTipoOper.Select("id_tb_oper = '" & 0 & "'")
        ' Recorremos las filas filtradas
        If ListaTipoOperacion.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaTipoOperacion
            Dim id As Integer = CInt(row("id_tb_tipooper"))
            Dim detalle As String = CStr(row("descrip_tipooper"))

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarTipoOperacion(id, detalle)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(TxtSocio, New Point(0, TxtSocio.Height))
    End Sub
    Private Sub MostrarTipoOperacion(id As String, detalle As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        ' CmdTipoOper.Text = detalle
        ' CmdTipoOper.Tag = id
        'SaltoBox(CmdOperacion.AccessibleDescription)


    End Sub

    Private Sub TxtSocio_BoxSN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSocio_BoxSN.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If TxtSocio_BoxSN.Text = "" Then Exit Sub
            Busca_DatoSocioN_Box(TxtSocio_BoxSN.Text)
        End If
    End Sub
    Private Sub Busca_DatoSocioN_Box(wcadena As String)
        Dim Result As String
        Dim sql_cade As String
        Dim sql_result As DataTable
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim whacebusAdd As Boolean = False
        Dim wdig As Integer = wcadena.Length


        Dim ListaTipoPersona() As DataRow = lk_sql_ListaTipoDocPersona.Select("digitos = '" & wdig & "'")
        If ListaTipoPersona.Length <> 0 Then
            whacebusAdd = True
            '   Exit Sub
        End If

        ' Ejemplo 20445399001
        sql_cade = "SELECT id_sn_maestro,  boxsn   FROM [dbo].[vw_snegocio] where codigo = '" & wcadena & "' or numero= '" & wcadena & "'"
        sql_result = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(sql_result)
        If sql_result.Rows.Count = 0 Then
            ' detectar la cantidad de digitos de digitado
            If whacebusAdd = False Then
                Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                         "Socio de Negocio.")
                TxtSocio_BoxSN.SelectAll()
                Exit Sub
            End If
            Exit Sub
        Else
CreaEncontroSN:
            info_SN.Text = sql_result.Rows(0).Item("boxsn").ToString
            info_SN.Tag = sql_result.Rows(0).Item("id_sn_maestro").ToString
            CmdBuscaComp_Click(Nothing, Nothing)
            ' SaltoBox(BoxSocioNego.AccessibleName)
        End If




    End Sub
    Public Class ConsultaRUC
        Private Const ConsultaUrl As String = "https://api.migo.pe/api/v1/ruc"

        Private ReadOnly _apiKey As String

        Public Sub New(apiKey As String)
            _apiKey = apiKey
        End Sub

        Public Function ConsultarRUC(numeroRUC As String, wtipo_dni_ruc As String) As JObject
            ' wtipoDNI_RUC = 'ruc' o dni
            ' Establecer los protocolos SSL/TLS
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11

            ' Crear el cliente REST
            Dim client As New RestClient(ConsultaUrl)

            ' Crear la solicitud POST
            Dim request As New RestRequest(Method.POST)
            request.AddHeader("accept", "application/json")
            request.AddHeader("content-type", "application/json")

            ' Agregar los parámetros de la solicitud
            Dim body As New JObject
            body.Add("token", _apiKey)
            body.Add(wtipo_dni_ruc, numeroRUC)
            request.AddParameter("application/json", body.ToString(), ParameterType.RequestBody)

            ' Realizar la solicitud
            Dim response As IRestResponse = client.Execute(request)

            ' Verificar si la respuesta fue exitosa
            If response.StatusCode = HttpStatusCode.OK Then
                Try
                    ' Analizar la respuesta JSON
                    Dim jsonResponse As JObject = JObject.Parse(response.Content)
                    Return jsonResponse
                Catch ex As Exception
                    ' Manejar el error de JSON inválido
                    Console.WriteLine("Error al analizar la respuesta JSON: " & ex.Message)
                End Try
            Else
                ' Manejar el error de solicitud HTTP no exitosa
                Console.WriteLine("Error de solicitud HTTP: " & response.ErrorMessage)
            End If

            Return Nothing
        End Function


    End Class

    Private Sub CmdBusca_BoxSN_Click(sender As Object, e As EventArgs) Handles CmdBusca_BoxSN.Click
        Busca_DatoSocioN_Box(TxtSocio_BoxSN.Text)
    End Sub

    Private Sub CmdBuscaComp_Click(sender As Object, e As EventArgs) Handles CmdBuscaComp.Click
        Me.DGCuentasSN.Rows.Clear()
        Dim sql As String = "exec [sp_muestra_carterasn_lista] @id_negocio, @tipo_balance, @id_sn_maestro "
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.AddWithValue("@tipo_balance", FORM_tipo_balance)
        command.Parameters.AddWithValue("@id_sn_maestro", Val(info_SN.Tag))


        Dim adapter As New SqlDataAdapter(command)
        Dim tabla As New DataTable()
        adapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            Dim Result As String = MensajesBox.Show("No Tiene Documentos con saldo..",
                                             "Comprobantes")
            Exit Sub
        End If

        For i = 0 To tabla.Rows.Count - 1
            Me.DGCuentasSN.Rows.Add()
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("oper").Value = tabla.Rows(i).Item("oper_codigo").ToString.Trim & " - " & tabla.Rows(i).Item("oper_nom_oper").ToString.Trim
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("fecha").Value = Format(tabla.Rows(i).Item("fecha_emis"), "dd/MM/yyyy")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("comp").Value = tabla.Rows(i).Item("comp_codigo").ToString
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("serie").Value = tabla.Rows(i).Item("serie_comp").ToString
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("numero").Value = tabla.Rows(i).Item("numero_comp").ToString
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("local").Value = tabla.Rows(i).Item("local_codigo").ToString.Trim & " - " & tabla.Rows(i).Item("local_abreviado").ToString.Trim
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("monto").Value = Val(tabla.Rows(i).Item("total"))
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("simbolo").Value = tabla.Rows(i).Item("mod_simbolo")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("saldo").Value = Val(Math.Abs(tabla.Rows(i).Item("saldo")))
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("fecvcto").Value = Format(tabla.Rows(i).Item("fecha_vcto"), "dd/MM/yyyy")

            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("vendedor").Value = "" '  tabla.Rows(i).Item("vendedor")

            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("moneda").Value = tabla.Rows(i).Item("mod_simbolo")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("id_carterasn_det").Value = tabla.Rows(i).Item("id_carterasn_det")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("id_carterasn_cab").Value = tabla.Rows(i).Item("id_carterasn_cab")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("id_comp_cab").Value = tabla.Rows(i).Item("id_comp_cab")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("id_oper_maestro").Value = tabla.Rows(i).Item("id_oper_maestro")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("descrip").Value = tabla.Rows(i).Item("sn_razonsocial").ToString
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("codigo").Value = tabla.Rows(i).Item("sn_codigo").ToString

            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("hecho").Value = tabla.Rows(i).Item("usuario")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("fechahora").Value = Format(tabla.Rows(i).Item("fechahora"), "dd/MM/yyyy")
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("condicion").Value = tabla.Rows(i).Item("oper_nom_tipooper").ToString
            Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("signo_sn").Value = tabla.Rows(i).Item("signo_sn").ToString


            If Val(tabla.Rows(i).Item("signo_sn")) = 1 Then
                Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("estado").Value = "PEND."
            ElseIf Val(tabla.Rows(i).Item("signo_sn")) = -1 Then
                Me.DGCuentasSN.Rows(DGCuentasSN.Rows.Count - 1).Cells("estado").Value = "A FAVOR"
            End If


        Next



    End Sub

    Private Sub Cabeza_CuentasSN_Inicia()
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

        DGCuentasSN.Columns.Clear()
        DGCuentasSN.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Width = 80
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "oper"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "OPERACION"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Width = 90
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True

        fechaColumna = New DataGridViewTextBoxColumn()
        fechaColumna.Name = "fecha"
        fechaColumna.Tag = "F"
        fechaColumna.HeaderText = "FECHA COMP."
        DGCuentasSN.Columns.Add(fechaColumna)
        fechaColumna.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        fechaColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        DGCuentasSN.Columns.Item(fechaColumna.Name).Width = 75
        DGCuentasSN.Columns.Item(fechaColumna.Name).ReadOnly = True
        DGCuentasSN.Columns.Item(fechaColumna.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "comp"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "COMP."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Width = 40
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Width = 50
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Width = 60
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "simbolo"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorNoDisponible)
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Width = 40
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = True
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "MONTO COMPR."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True
        DGCuentasSN.Columns.Item(textoColumn.Name).MinimumWidth = 60
        DGCuentasSN.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' 



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "SALDO PEND."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True
        DGCuentasSN.Columns.Item(textoColumn.Name).MinimumWidth = 60
        DGCuentasSN.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' 


        fechaColumna = New DataGridViewTextBoxColumn()
        fechaColumna.Name = "fecvcto"
        fechaColumna.Tag = "F"
        fechaColumna.HeaderText = "FEC.VCTO"
        DGCuentasSN.Columns.Add(fechaColumna)
        fechaColumna.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        fechaColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        DGCuentasSN.Columns.Item(fechaColumna.Name).Width = 90
        DGCuentasSN.Columns.Item(fechaColumna.Name).ReadOnly = True
        DGCuentasSN.Columns.Item(fechaColumna.Name).Visible = True

        checkColumn.Name = "sel"
        checkColumn.HeaderText = "SEL"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        DGCuentasSN.Columns.Add(checkColumn)
        DGCuentasSN.Columns.Item(checkColumn.Name).Width = 30
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        DGCuentasSN.Columns.Item(checkColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "aplicar"
        textoColumn.Tag = "E6"
        textoColumn.HeaderText = "MONTO APLICAR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = False
        DGCuentasSN.Columns.Item(textoColumn.Name).MinimumWidth = 60
        DGCuentasSN.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' 




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "estado"
        textoColumn.Tag = "A20"
        textoColumn.HeaderText = "ESTADO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Width = 90
        DGCuentasSN.Columns.Item(textoColumn.Name).ReadOnly = True




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechahora"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hecho"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "descrip"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_carterasn_cab"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_carterasn_det"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "vendedor"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "condicion"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "signo_sn"
        DGCuentasSN.Columns.Add(textoColumn)
        DGCuentasSN.Columns.Item(textoColumn.Name).Visible = False



    End Sub

    Private Sub FrmSaldosSN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '============= PRUEBA PARA FORMALURO DE OPERACIONES ================================

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


        '===============================================


        Cabeza_CuentasSN_Inicia()



        DataSeleccion.Columns.Clear()
        DataSeleccion.Columns.Add("codigo", GetType(String))
        DataSeleccion.Columns.Add("descrip", GetType(String))
        DataSeleccion.Columns.Add("masdetalle", GetType(String))
        DataSeleccion.Columns.Add("fechaemis", GetType(DateTime))
        DataSeleccion.Columns.Add("local", GetType(String))
        DataSeleccion.Columns.Add("moneda", GetType(String))
        DataSeleccion.Columns.Add("monto", GetType(String))
        DataSeleccion.Columns.Add("saldo", GetType(String))
        DataSeleccion.Columns.Add("fechavcto", GetType(DateTime))
        DataSeleccion.Columns.Add("condicion", GetType(String))
        DataSeleccion.Columns.Add("vendedor", GetType(String))
        DataSeleccion.Columns.Add("hecho", GetType(String))
        DataSeleccion.Columns.Add("fechahora", GetType(DateTime))
        DataSeleccion.Columns.Add("id_oper_maestro", GetType(Integer))
        DataSeleccion.Columns.Add("id_comp_cab", GetType(Integer))
        DataSeleccion.Columns.Add("id_carterasn_cab", GetType(Integer))
        DataSeleccion.Columns.Add("id_carterasn_det", GetType(Integer))
        DataSeleccion.Columns.Add("codcomp", GetType(String))
        DataSeleccion.Columns.Add("seriecomp", GetType(String))
        DataSeleccion.Columns.Add("numerocomp", GetType(String))
        DataSeleccion.Columns.Add("signo_sn", GetType(Integer))
        DataSeleccion.Columns.Add("aplicar", GetType(Double))

        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        PanelPie.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        TxtSocio_BoxSN.Select()
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click

        For Each row As DataGridViewRow In DGCuentasSN.Rows
            Dim cell As DataGridViewCheckBoxCell = TryCast(row.Cells("Sel"), DataGridViewCheckBoxCell)
            If cell IsNot Nothing AndAlso cell.Value IsNot Nothing AndAlso CBool(cell.Value) = True Then
                ' La casilla de verificación está marcada
                ' Realiza las acciones correspondientes aquí
                Dim rowIndex As Integer = row.Index

                Dim addrow As DataRow = DataSeleccion.NewRow()

                addrow.Item("codigo") = row.Cells("codigo").Value
                addrow.Item("descrip") = row.Cells("descrip").Value
                addrow.Item("masdetalle") = ""
                addrow.Item("fechaemis") = row.Cells("fecvcto").Value
                addrow.Item("local") = row.Cells("local").Value
                addrow.Item("moneda") = row.Cells("moneda").Value
                addrow.Item("monto") = row.Cells("monto").Value
                addrow.Item("saldo") = row.Cells("saldo").Value
                addrow.Item("fechavcto") = row.Cells("fecvcto").Value
                addrow.Item("condicion") = " "  ' row.Cells("condicion")
                addrow.Item("vendedor") = row.Cells("vendedor").Value
                addrow.Item("hecho") = row.Cells("hecho").Value
                addrow.Item("fechahora") = row.Cells("fechahora").Value
                addrow.Item("id_oper_maestro") = row.Cells("id_oper_maestro").Value
                addrow.Item("id_comp_cab") = row.Cells("id_comp_cab").Value
                addrow.Item("id_carterasn_cab") = row.Cells("id_carterasn_cab").Value

                addrow.Item("id_carterasn_det") = row.Cells("id_carterasn_det").Value
                addrow.Item("codcomp") = row.Cells("comp").Value
                addrow.Item("seriecomp") = row.Cells("serie").Value
                addrow.Item("numerocomp") = row.Cells("numero").Value
                addrow.Item("signo_sn") = row.Cells("signo_sn").Value
                addrow.Item("aplicar") = row.Cells("aplicar").Value

                DataSeleccion.Rows.Add(addrow)
                ' ...
            End If
        Next

        'MsgBox(DataSeleccion.Rows.Count)
        'Stop
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub DGCuentasSN_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCuentasSN.CellContentClick

    End Sub
    Private isEditing As Boolean = False
    Private Sub DGCuentasSN_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DGCuentasSN.CurrentCellDirtyStateChanged
        If Not isEditing Then
            isEditing = True
            If DGCuentasSN.IsCurrentCellDirty Then
                If TypeOf DGCuentasSN.CurrentCell Is DataGridViewCheckBoxCell Then
                    DGCuentasSN.CommitEdit(DataGridViewDataErrorContexts.Commit)
                End If
            End If


            Dim isChecked As Boolean = CBool(DGCuentasSN.CurrentCell.Value)
            Dim Tod_isChecked As Boolean = False
            Dim Par_isChecked As Boolean = False
            Dim windesfila As Integer = DGCuentasSN.CurrentCell.RowIndex
            Dim columnName As String = DGCuentasSN.Columns(DGCuentasSN.CurrentCell.ColumnIndex).Name

            If columnName = "sel" And isChecked Then
                DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("aplicar").Value = DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("saldo").Value
                DGCuentasSN.CurrentCell = DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("aplicar")
                'Tod_isChecked = True
                'If DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("par").Value Then
                ' DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("par").Value = False
                ' Par_isChecked = False
                ' End If
            End If
            If columnName = "sel" And isChecked = False Then
                DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("aplicar").Value = ""
                '    Par_isChecked = True
                '    If DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("tod").Value Then
                '    DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("tod").Value = False
                '    Tod_isChecked = False
                ' End If
            End If
            calculo_validalote()
            '  ValidaFilasDetalle(Tod_isChecked, Par_isChecked, windesfila)
            isEditing = False
        End If
    End Sub
    Private Sub ValidaFilasDetalle(Tod_isChecked As Boolean, Par_isChecked As Boolean, wfilaindex As Integer)


        If Par_isChecked = False And Tod_isChecked = False Then
            DGCuentasSN.Columns("tod").ReadOnly = False
            DGCuentasSN.Columns("par").ReadOnly = False
        End If
        If Par_isChecked Then
            DGCuentasSN.Columns("tod").ReadOnly = True
            DGCuentasSN.Columns("par").ReadOnly = False
        End If
        If Tod_isChecked Then
            DGCuentasSN.Columns("tod").ReadOnly = False
            DGCuentasSN.Columns("par").ReadOnly = True
        End If



        For Each fila As DataGridViewRow In DGCuentasSN.Rows
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


        'ArmaComprobante(wfilaindex)
    End Sub

    Private Sub DGCuentasSN_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGCuentasSN.CellEnter

        If DGCuentasSN.Rows(e.RowIndex).Cells("sel").Value Then
            'If DGCuentasSN.Rows(e.RowIndex).Cells("aplicar").Value = 3 Then
            DGCuentasSN.Columns("aplicar").ReadOnly = False
            ' Else

            ' DGCuentasSN.Columns("canti_aplica").ReadOnly = False
            'End If
        Else
            DGCuentasSN.Columns("aplicar").ReadOnly = True
        End If

    End Sub

    Private Sub DGCuentasSN_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGCuentasSN.CellEndEdit
        Dim wtod_isChecked As Boolean = False
        Dim wpar_isChecked As Boolean = False
        wtod_isChecked = DGCuentasSN.Rows(DGCuentasSN.CurrentCell.RowIndex).Cells("sel").Value

        If Val(DGCuentasSN.Rows(e.RowIndex).Cells("aplicar").Value) > Val(DGCuentasSN.Rows(e.RowIndex).Cells("saldo").Value) Then
            DGCuentasSN.Rows(e.RowIndex).Cells("aplicar").Value = ""
            DGCuentasSN.Rows(e.RowIndex).Cells("sel").Value = False
            'V'alidaFilasDetalle(wtod_isChecked, wpar_isChecked, e.RowIndex)
            Exit Sub
        End If
    End Sub
    Private Sub calculo_validalote()
        Dim wsuma As Double
        Dim wsumaer As String = ""
        Dim wflagfecvcto As String = ""
        Dim wflagfecFab As String = ""
        Dim wflagcodigo As String = ""
        'Iterar por cada fila en el DataGridView

        'LblError.Text = ""
        'FaltaDatos.SetError(CmdAceptar, "")

        If DGCuentasSN.Visible = False Then Exit Sub
        If DGCuentasSN.CurrentCell Is Nothing Then Exit Sub

        lblMontoAplicar.Tag = 0
        wsuma = 0
        For i As Integer = 0 To DGCuentasSN.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            'If TipoRegistro = "INGRESO" Then
            '    wsuma = wsuma + Val(dg_finanzas.Rows(i).Cells("ingreso").Value)
            'ElseIf TipoRegistro = "SALIDA" Then
            '    wsuma = wsuma + Val(dg_finanzas.Rows(i).Cells("salida").Value)
            'End If
            wsuma = wsuma + Val(DGCuentasSN.Rows(i).Cells("aplicar").Value)
            'If dg_finanzas.Rows(i).Cells("codigo").Value = "" Then
            '    wflagcodigo = "Fila: " & dg_finanzas.Rows(i).Cells("num").Value & " : Indicar Codigo"
            '    GoTo fin
            'End If

            'If dg_finanzas.Rows(i).Cells("fecvcto").Value = "" Then
            '    wflagfecvcto = "Fila: " & dg_finanzas.Rows(i).Cells("num").Value & " : Ingresar Fec.Vcto"
            '    GoTo fin
            'End If
            'If dg_finanzas.Rows(i).Cells("fecfab").Value = "" Then
            '    dg_finanzas.Rows(i).Cells("fecfab").Value = Format(lk_fecha_dia, "dd/MM/yyyy")

            'End If


        Next
        lblMontoAplicar.Text = Format(wsuma, "N2")
        lblMontoAplicar.Tag = wsuma


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

End Class