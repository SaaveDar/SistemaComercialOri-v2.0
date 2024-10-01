
Imports RestSharp
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices
Imports FontAwesome.Sharp
Imports Newtonsoft.Json
Imports System.Text
Imports System.Data.SqlClient

Public Class FrmMenuConfigurar
    Dim MostrarSelloAgua As Boolean = False
    Dim lk_negocio_sn As New DataTable()
    Dim lk_listar_bus As New DataTable()

    Public Property ENLACE_VIENE As String
    Private Sub FrmMenuConfigurar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        'Carga_Paramtros_Negocio(lk_NegocioActivo.id_Negocio)
        'ENLACE_VIENE = "CONFIGURAR"
        ''0ENLACE_VIENE = "PROCESOS"


        '===============================================





        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        PanelCentral.Dock = System.Windows.Forms.DockStyle.Fill
        ' If TxtCodigo.Tag <> "" Then
        CmdOpcion.Text = ""
        CmdOpcion.Tag = ""
        LimpiaBus()
        ' TxtCodigo.Text
        If Len(TxtCodigo.Tag) <> 0 Then
            TxtCodigo.Text = TxtCodigo.Tag
            CodigoBiscador(TxtCodigo.Tag, ENLACE_VIENE)
            TxtBuscar.Select()
            TxtBuscar.Text = TxtBuscar.Tag
            TxtBuscar.SelectionStart = TxtBuscar.Text.Length
        Else
            CodigoBiscador(TxtCodigo.Text, ENLACE_VIENE)
            TxtCodigo.Select()
            TxtCodigo.Focus()
        End If


        ' End If


        'Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        'Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        'Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        'Me.Location = New Point(posicionX, posicionY)

        'For I = 1 To 200
        '    DataGridResul.Rows.Add()
        '    DataGridResul.Rows(DataGridResul.Rows.Count - 1).Cells(0).Value = "texto1"
        '    DataGridResul.Rows(DataGridResul.Rows.Count - 1).Cells(1).Value = "texto2"
        '    '  DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(2).Value = "texto3"

        'Next

        If lk_sql_ListaTablas.Rows.Count = 0 Then

        Else
            CmbTipoSN.Items.Clear()
            CmbClaseSN.Items.Clear()

            For i = 0 To lk_sql_ListaTablas.Rows.Count - 1
                If lk_sql_ListaTablas.Rows(i).Item("id_tipotabla").ToString = "40" Then ' solo Tipo de locales
                    CmbTipoSN.Items.Add(lk_sql_ListaTablas.Rows(i).Item("descripcion").ToString & Space(100) & lk_sql_ListaTablas.Rows(i).Item("id_tb").ToString)
                End If
                If lk_sql_ListaTablas.Rows(i).Item("id_tipotabla").ToString = "45" Then ' solo Tipo de locales
                    CmbClaseSN.Items.Add(lk_sql_ListaTablas.Rows(i).Item("descripcion").ToString & Space(100) & lk_sql_ListaTablas.Rows(i).Item("id_tb").ToString)
                End If
            Next
        End If
        Griddireccion_Inicia()

    End Sub

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click
        WindowState = FormWindowState.Minimized
        Me.Text = TxtCodigo.Text
        Me.ControlBox = True


    End Sub

    Private Sub CmdRestaurar_Click(sender As Object, e As EventArgs) Handles CmdRestaurar.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub PanelSup_Paint(sender As Object, e As PaintEventArgs) Handles PanelSup.Paint

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

    Private Sub PanelSup_Resize(sender As Object, e As EventArgs) Handles PanelSup.Resize
        Me.Text = ""
        Me.ControlBox = False
    End Sub

    Private Sub CmdOpcion_Click(sender As Object, e As EventArgs) Handles CmdOpcion.Click
        'PanelCentral.Visible = False
        'PanelBuscaOpcion.Top = 41
        'PanelBuscaOpcion.Left = 0
        'PanelBuscaOpcion.Visible = True

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub


        Dim ListaTablas() As DataRow = lk_sql_ListaTablas.Select("id_tipotabla = 90")
        ' Recorremos las filas filtradas
        If ListaTablas.Length = 0 Then
            Result = MensajesBox.Show("No Definido ningun maestro.",
                                     "Configurar.")

            Exit Sub
        End If



        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaTablas
            Dim id As Integer = CInt(row("id_tb"))
            Dim detalle As String = CStr(row("descripcion"))
            Dim codigo As String = CStr(row("codigo"))
            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarMaestros(id, detalle, codigo)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdOpcion, New Point(0, CmdOpcion.Height))

    End Sub
    Private Sub MostrarMaestros(wid As Integer, wdes As String, wcodigo As String)
        TxtCodigo.Text = wcodigo
        CmdOpcion.Text = wdes
        CmdOpcion.Tag = wid
        CodigoBiscador(TxtCodigo.Text, "CONFIGURAR")

    End Sub
    Private Sub CmdAceptarBusqueda_Click(sender As Object, e As EventArgs)
        PanelCentral.Visible = True

    End Sub

    Private Sub CmdCerrarBusqueda_Click(sender As Object, e As EventArgs)
        PanelCentral.Visible = True
    End Sub





    Private Sub CmdAceptarVendedor_Click(sender As Object, e As EventArgs) Handles CmdAceptarVendedor.Click
        DataGridResul.Visible = True
        PanelVendedor.Visible = False
    End Sub

    Private Sub wpVendedor_Click(sender As Object, e As EventArgs) Handles wpVendedor.Click

        Try
            System.Diagnostics.Process.Start("https://wa.me/51" + Trim(Vend_Telf.Text))

        Catch
            ' MsgBox("NO SE PUDO CARGAR LA PAGINA..")
        End Try
    End Sub



    Private Sub Nuevabusqueda()
        If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "100" Then ' DAtos para Socio de NEgoci
            PanelSocioNegocio.Visible = False
            DataGridResul.Visible = True
            TxtBuscar.Select()
        End If
        If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "200" Then ' DAtos para Socio de NEgoci
            PanelFN.Visible = False
            DataGridResul.Visible = True
            TxtBuscar.Select()
        End If
    End Sub


    Private Sub CodigoBiscador(wcodigo As String, wviene As String)


        Select Case wcodigo
            Case "100" ' SOCIO DE NEG MAESTRO
                IrSocioNegocio(wviene)
            Case "120" '  VENDEDORES MAESTRO
                IrVendedores()
            Case "200" ' FINANZAS MAESTRO 
                IrEntidades()
            Case Else
                'MsgBox("No Existe Codigo, Verificar ")
        End Select
        TxtBuscar.Select()
    End Sub
    Private Sub Inicia_Configurar()
        PanelBuscador.Visible = False
        PanelOpcionesBusca.Visible = False
        CmdB1.Tag = ""
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB1.Tag, 50))
        CmdB2.Tag = ""
        CmdB3.Tag = ""
        CmdB4.Tag = ""
        CmdB5.Tag = ""

    End Sub
    Private Sub IrSocioNegocio(wviene As String)


        'If wviene = "PROCESOS" Then

        'Else

        Dim sql As String = "select   * from [dbo].[vw_snegocio] where codigo=-1 order by razonsocial"
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        Dim adapter As New SqlDataAdapter(command)

        lk_negocio_sn = New DataTable()
        adapter.Fill(lk_negocio_sn)
        'connection.Close()
        ' MsgBox(lk_negocio_sn.Rows.Item("razonsocial"))
        DataGridResul.DataSource = Nothing
        DataGridResul.Columns.Clear()
        DataGridResul.Rows.Clear()
        DataGridResul.DataSource = lk_negocio_sn
        'End If
        IniciaCabeceraSN()

        LimpiaBus()

        CmdB1.Text = "F2 NOMBRE / RAZON SOCIAL"
        CmdB1.Visible = True
        CmdB1.Tag = "&Nombre / Razon Social:" & Space(50) & "10001"
        LblBuscarpor.Text = Trim(Strings.Left(CmdB1.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB1.Tag, 50))



        CmdB2.Text = "F3 NOMBRE COMERCIAL"
        CmdB2.Visible = True
        CmdB2.Tag = "&Nombre Comercial:" & Space(50) & "10002"

        CmdB3.Text = "F4 NRO. DOCUMENTO"
        CmdB3.Visible = True
        CmdB3.Tag = "&Numero Documento:" & Space(50) & "10003"

        CmdB4.Text = "F5 CODIGO SN"
        CmdB4.Visible = True
        CmdB4.Tag = "&Codigo SN:" & Space(50) & "10004"


        CmdB5.Text = "F6 DIRECCION"
        CmdB5.Visible = True
        CmdB5.Tag = "&Direccion:" & Space(50) & "10005"
        PanelBuscador.Visible = True
        PanelOpcionesBusca.Visible = True

    End Sub
    Private Sub IrVendedores()

        Dim sql As String = "select   * from [dbo].[vw_snegocio] where codigo=-1 order by razonsocial"
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        Dim adapter As New SqlDataAdapter(command)

        lk_negocio_sn = New DataTable()
        adapter.Fill(lk_negocio_sn)
        'connection.Close()
        ' MsgBox(lk_negocio_sn.Rows.Item("razonsocial"))
        DataGridResul.DataSource = Nothing
        DataGridResul.Columns.Clear()
        DataGridResul.Rows.Clear()
        DataGridResul.DataSource = lk_negocio_sn
        'End If
        IniciaCabeceraSN()

        LimpiaBus()

        CmdB1.Text = "F2 NOMBRE / RAZON SOCIAL"
        CmdB1.Visible = True
        CmdB1.Tag = "&Nombre / Razon Social:" & Space(50) & "10001"
        LblBuscarpor.Text = Trim(Strings.Left(CmdB1.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB1.Tag, 50))



        'CmdB2.Text = "F3 NOMBRE COMERCIAL"
        'CmdB2.Visible = True
        'CmdB2.Tag = "&Nombre Comercial:" & Space(50) & "10002"

        'CmdB3.Text = "F4 NRO. DOCUMENTO"
        'CmdB3.Visible = True
        'CmdB3.Tag = "&Numero Documento:" & Space(50) & "10003"

        'CmdB4.Text = "F5 CODIGO SN"
        'CmdB4.Visible = True
        'CmdB4.Tag = "&Codigo SN:" & Space(50) & "10004"


        'CmdB5.Text = "F6 DIRECCION"
        'CmdB5.Visible = True
        'CmdB5.Tag = "&Direccion:" & Space(50) & "10005"
        PanelBuscador.Visible = True
        PanelOpcionesBusca.Visible = True
    End Sub
    Private Sub IrEntidades()

        Dim sql As String = "select   * from [vw_fn_maestro]  where id_negocio = " & lk_NegocioActivo.id_Negocio & " and estado <> 0 order by descripcion"
        Dim command As New SqlCommand(sql, lk_connection_cuenta)
        Dim adapter As New SqlDataAdapter(command)

        lk_listar_bus = New DataTable()
        adapter.Fill(lk_listar_bus)
        'connection.Close()
        ' MsgBox(lk_negocio_sn.Rows.Item("razonsocial"))
        DataGridResul.DataSource = Nothing
        DataGridResul.Columns.Clear()
        DataGridResul.Rows.Clear()
        DataGridResul.DataSource = lk_listar_bus
        'End If
        IniciaCabeceraEntidades()

        LimpiaBus()

        CmdB1.Text = "F2 DESCRIPCION EMTIDAD FINANCIERA"
        CmdB1.Visible = True
        CmdB1.Tag = "&Descricion :" & Space(50) & "20001"
        LblBuscarpor.Text = Trim(Strings.Left(CmdB1.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB1.Tag, 50))



        'CmdB2.Text = "F3 NOMBRE COMERCIAL"
        'CmdB2.Visible = True
        'CmdB2.Tag = "&Nombre Comercial:" & Space(50) & "10002"

        'CmdB3.Text = "F4 NRO. DOCUMENTO"
        'CmdB3.Visible = True
        'CmdB3.Tag = "&Numero Documento:" & Space(50) & "10003"

        'CmdB4.Text = "F5 CODIGO SN"
        'CmdB4.Visible = True
        'CmdB4.Tag = "&Codigo SN:" & Space(50) & "10004"


        'CmdB5.Text = "F6 DIRECCION"
        'CmdB5.Visible = True
        'CmdB5.Tag = "&Direccion:" & Space(50) & "10005"
        PanelBuscador.Visible = True
        PanelOpcionesBusca.Visible = True
    End Sub
    Private Sub LimpiaBus()
        CmdB1.Text = ""
        CmdB1.Visible = False
        CmdB1.Tag = ""

        CmdB2.Text = ""
        CmdB2.Visible = False
        CmdB2.Tag = ""

        CmdB3.Text = ""
        CmdB3.Visible = False
        CmdB3.Tag = ""

        CmdB4.Text = ""
        CmdB4.Visible = False
        CmdB4.Tag = ""

        CmdB5.Text = ""
        CmdB5.Visible = False
        CmdB5.Tag = ""

        DataGridResul.Visible = True
        PanelSocioNegocio.Dock = System.Windows.Forms.DockStyle.Fill
        PanelSocioNegocio.Visible = False
        TxtBuscar.Text = ""
    End Sub
    Private Sub baselocal()

        'Dim connectionString As String = "Data Source=PCACOSME;Initial Catalog=r23_negocio_cuenta;User ID=sa;Password=159357852456;"

        'connection.Open()

        'Dim sql As String = "select  TOP 100 * from [dbo].[vw_snegocio] order by razonsocial"
        'Dim command As New SqlCommand(sql, connection)
        'Dim adapter As New SqlDataAdapter(command)

        'lk_negocio_sn = New DataTable()
        'adapter.Fill(lk_negocio_sn)
        ''connection.Close()
        '' MsgBox(lk_negocio_sn.Rows.Item("razonsocial"))
        'DataGridResul.DataSource = Nothing
        'DataGridResul.Columns.Clear()
        'DataGridResul.Rows.Clear()
        'DataGridResul.DataSource = lk_negocio_sn
        'IniciaCabeceraSN()


    End Sub
    Private Sub IniciaCabeceraSN()

        Try
            With DataGridResul.Columns
                .Item("codigo").Visible = True
                .Item("codigo").Width = 60
                .Item("tipodoc").Visible = True
                .Item("tipodoc").Width = 40
                .Item("numero").Visible = True
                .Item("numero").Width = 90
                .Item("razonsocial").Visible = True
                .Item("razonsocial").Width = 300
                .Item("condicion").Visible = True
                .Item("condicion").Width = 80
                .Item("comercial").Visible = True
                .Item("comercial").Width = 200
                .Item("direccion").Visible = True
                .Item("direccion").Width = 300
                .Item("departamento").Visible = True
                .Item("departamento").Width = 200
                .Item("distrito").Visible = True
                .Item("distrito").Width = 80
                .Item("provincia").Visible = True
                .Item("provincia").Width = 80
                .Item("boxsn").Visible = False

                .Item("correo").Visible = False
                .Item("correo_fe").Visible = False
                .Item("estado_sn").Visible = False
                .Item("tiposn").Visible = False
                .Item("id_negocio").Visible = False
                .Item("id_socionegocio").Visible = False
                .Item("id_sn_maestro").Visible = False
                .Item("id_tab_tiposn").Visible = False
                .Item("id_tipodoc").Visible = False
                .Item("fechareg").Visible = False
                .Item("departamento").Visible = False
                .Item("distrito").Visible = False
                .Item("provincia").Visible = False
                .Item("id_tab_clasesn").Visible = False
                .Item("clasesn").Visible = False


            End With

            Dim imageColumn As New DataGridViewImageColumn()
            imageColumn.HeaderText = "Imagen"
            imageColumn.Name = "imagen"
            imageColumn.HeaderText = "Ver"
            imageColumn.Image = My.Resources.ver
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            DataGridResul.Columns.Add(imageColumn)
        Catch ex2 As Exception

        Finally

        End Try

    End Sub

    Private Sub IniciaCabeceraEntidades()

        Try
            With DataGridResul.Columns
                .Item("id_fn_maestro").Visible = False
                .Item("codigo").Width = 60
                .Item("descripcion").Width = 250
                .Item("abreviado").Width = 100

                .Item("id_moneda").Visible = False

                .Item("es_saldo").Visible = False
                .Item("estado").Visible = False
                .Item("mon_simbolo").Visible = False
                .Item("id_negocio").Visible = False


            End With

            Dim imageColumn As New DataGridViewImageColumn()
            imageColumn.HeaderText = "Imagen"
            imageColumn.Name = "imagen"
            imageColumn.HeaderText = "Ver"
            imageColumn.Image = My.Resources.ver
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            DataGridResul.Columns.Add(imageColumn)
            DataGridResul.Columns.Item("Imagen").Width = 40

        Catch ex2 As Exception

        Finally

        End Try

    End Sub

    Private Sub CmdB1_Click(sender As Object, e As EventArgs) Handles CmdB1.Click
        LblBuscarpor.Text = Trim(Strings.Left(CmdB1.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB1.Tag, 50))
        TxtBuscar.Text = ""
        TxtBuscar.Focus()
        'Me.ActiveControl = txtNombre
        'txtNombre.Select()
        'Me.SelectNextControl(txtNombre, True, True, True, True)

    End Sub

    Private Sub CmdB2_Click(sender As Object, e As EventArgs) Handles CmdB2.Click
        LblBuscarpor.Text = Trim(Strings.Left(CmdB2.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB2.Tag, 50))
        TxtBuscar.Text = ""
        TxtBuscar.Focus()
    End Sub

    Private Sub CmdB3_Click(sender As Object, e As EventArgs) Handles CmdB3.Click
        LblBuscarpor.Text = Trim(Strings.Left(CmdB3.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB3.Tag, 50))
        TxtBuscar.Text = ""
        TxtBuscar.Focus()
    End Sub

    Private Sub CmdB4_Click(sender As Object, e As EventArgs) Handles CmdB4.Click
        LblBuscarpor.Text = Trim(Strings.Left(CmdB4.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB4.Tag, 50))
        TxtBuscar.Text = ""
        TxtBuscar.Focus()
    End Sub

    Private Sub CmdB5_Click(sender As Object, e As EventArgs) Handles CmdB5.Click
        LblBuscarpor.Text = Trim(Strings.Left(CmdB5.Tag, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdB5.Tag, 50))
        TxtBuscar.Text = ""
        TxtBuscar.Focus()
    End Sub
    Public Sub RECARGA_SN()
        Dim parametroneg = New List(Of Parametro) From {
             New Parametro("id_negocio", lk_NegocioActivo.id_Negocio)
             }
        Dim responseneg = MuestraDataApi(lk_api_cadena_base + "socio/listar/socioNegocio", parametroneg) ' respuesta : vps_Usaurios
        Try
            MsgBox("STOP")

            'lk_api_ListaNegocios = JsonConvert.DeserializeObject(Of JsonListaNegocios)(responseneg) 'Cái truyền tên Class vào
            If lk_api_ListaNegocios.estado = True Then

            End If
        Catch ex As Exception
            MsgBox("ERRO RECARGA_sn ")
            Exit Sub
        End Try
    End Sub


    Private Function GetRecordsWithParameters(ByVal fecha As String) As List(Of Record)
        ' Crear un cliente RestSharp
        Dim client As New RestClient("http://207.180.246.8/backend-farmacia/public/api/socio/listar/socioNegocio")

        ' Crear una solicitud HTTP
        Dim request As New RestRequest("records", Method.GET)

        ' Agregar parámetros a la solicitud HTTP
        request.AddParameter("id_negocio", fecha)

        ' Hacer la solicitud HTTP
        Dim response As IRestResponse = client.Execute(request)


        If response.StatusCode = System.Net.HttpStatusCode.OK Then
            ' Deserializar la respuesta JSON
            Dim records As List(Of Record) = JsonConvert.DeserializeObject(Of List(Of Record))(response.Content)
            Return records
        Else
            ' Manejar el error
            Throw New Exception(response.ErrorMessage)
        End If


        '' Verificar si la solicitud fue exitosa
        'If response.IsSuccessful Then
        '    ' Deserializar la respuesta JSON
        '    Dim records As List(Of Record) = JsonConvert.DeserializeObject(Of List(Of Record))(response.Content)
        '    Return records
        'Else
        '    ' Manejar el error
        '    Throw New Exception(response.ErrorMessage)
        'End If
    End Function

    'Private Async Function GetRecordsAsync(fecha As String) As Task(Of List(Of Record))

    '    'Dim client As HttpClient = New HttpClient()
    '    ''Dim client As New HttpClient()
    '    'client.BaseAddress = New Uri("http://207.180.246.8/backend-farmacia/public/api/socio/listar/socioNegocio")
    '    'client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

    '    'Dim records As New List(Of Record)()

    '    '' Hacer una única solicitud HTTP para obtener todos los registros
    '    ''Dim url As String = String.Format("records?fecha={0}", fecha)

    '    'Dim url As String = String.Format("records?id_negocio={0}", fecha)

    '    'Dim response As HttpResponseMessage = Await client.PostAsync(url)

    '    '' Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("api/products", product)
    '    ''            response.EnsureSuccessStatusCode()


    '    'If response.IsSuccessStatusCode Then
    '    '    Dim json As String = Await response.Content.ReadAsStringAsync()
    '    '    records = JsonConvert.DeserializeObject(Of List(Of Record))(json)
    '    'Else
    '    '    ' Manejar el error
    '    'End If


    '    'Class SurroundingClass
    '    '        Shared client As HttpClient = New HttpClient()

    '    '        Private Shared Sub ShowProduct(ByVal product As Product)
    '    '            Console.WriteLine($"Name: {product.Name}\tPrice: " & $"{product.Price}\tCategory: {product.Category}")
    '    '        End Sub

    '    '        Private Shared Async Function CreateProductAsync(ByVal product As Product) As Task(Of Uri)
    '    '            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("api/products", product)
    '    '            response.EnsureSuccessStatusCode()
    '    '            Return response.Headers.Location
    '    '        End Function
    '    '    End Class






    '    '  Return records

    'End Function

    ' Clase Record para representar los datos que se obtienen del API
    Public Class Record
        Public Property Id As Integer
        Public Property Name As String
        ' Agregar más propiedades según las necesidades
    End Class

    Public Async Function GetRecords(parameter As String) As Task(Of List(Of Record))
        ' Crear el cliente HTTP
        Dim client As New HttpClient()

        ' Configurar la URL del API
        client.BaseAddress = New Uri("http://207.180.246.8/backend-farmacia/public/api/socio/listar/socioNegocio")

        ' Crear el objeto que se enviará en el cuerpo de la solicitud POST
        Dim requestBody As New Dictionary(Of String, String)
        requestBody.Add("id_negocio", parameter)
        ' requestBody.Add("Page", 1)

        ' Convertir el objeto a JSON
        Dim jsonRequest = JsonConvert.SerializeObject(requestBody)


        ' Crear la solicitud POST
        Dim request As New HttpRequestMessage(HttpMethod.Post, "")
        request.Content = New StringContent(jsonRequest, Encoding.UTF8, "application/json")

        ' Ejecutar la solicitud y obtener la respuesta
        Dim response As HttpResponseMessage = Await client.SendAsync(request)

        ' Verificar si la solicitud fue exitosa
        If response.IsSuccessStatusCode Then
            ' Leer la respuesta como JSON y deserializarla en una lista de objetos Record
            Dim jsonResult As String = Await response.Content.ReadAsStringAsync()
            Dim records As List(Of Record) = JsonConvert.DeserializeObject(Of List(Of Record))(jsonResult)
            Return records
        Else
            ' Manejar el error
            Throw New Exception(response.ReasonPhrase)
        End If
    End Function
    'Private Async Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
    '    ' Realizar la búsqueda asincrónica
    '    Dim tablaResultados As DataTable = Await BuscarRegistros()

    '    ' Actualizar el datagridview con los resultados
    '    dgResultados.DataSource = tablaResultados
    'End Sub

    Private Async Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        Dim valorresul As Integer
        Dim wsTextoBusca As String
        Dim colbusca As String = "razonsocial"
        If TxtBuscar.Text = "" Then
            DataGridResul.DataSource = Nothing
            DataGridResul.Columns.Clear()
            DataGridResul.Rows.Clear()
            DataGridResul.Refresh()
        End If

        wsTextoBusca = ""
        If Strings.Left(TxtBuscar.Text, 1) = "*" Then
            Dim numCaracteres As Integer = TxtBuscar.Text.ToCharArray().Where(Function(c) c = "*").Count()
            If numCaracteres > 2 Then Exit Sub   ' USUARIO DIGITA MAS DE 2 ASTERISCOS

            If Strings.Left(TxtBuscar.Text, 1) = "*" And Strings.Right(TxtBuscar.Text, 1) = "*" And Len(TxtBuscar.Text) > 2 Then
                wsTextoBusca = "Like '%" & Mid(TxtBuscar.Text, 2, Len(TxtBuscar.Text) - 2) & "%'"
            End If
        ElseIf Len((TxtBuscar.Text)) = 3 Then
            wsTextoBusca = " Like '" & TxtBuscar.Text & "%'"
        End If

        If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "100" Then ' DAtos para Socio de NEgoci

            Dim ListaTipoPersona() As DataRow = lk_sql_ListaTipoDocPersona.Select("digitos = '" & Len((TxtBuscar.Text)) & "'")
            Dim wid_tipdoc As Integer = 0
            If ListaTipoPersona.Length <> 0 Then
                wid_tipdoc = ListaTipoPersona(0)("id_tipodoc")
            End If
            If wid_tipdoc <> 0 And Strings.Left(TxtBuscar.Text, 1) <> "*" Then
                wsTextoBusca = " Like '" & TxtBuscar.Text & "%'"
            End If

            If Strings.Right(Trim(LblBuscarpor.Tag), 2) = "01" Then ' por razon social
                colbusca = "razonsocial"
            ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "02" Then ' comercial
                colbusca = "comercial"
            ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "03" Then ' RUC
                colbusca = "numero"
            ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "04" Then ' por Codigo
                colbusca = "codigo"
            ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "05" Then ' por direcc
                colbusca = "direccion"
            End If
            If wsTextoBusca <> "" Then
                lk_negocio_sn = New DataTable()
                DataGridResul.DataSource = Nothing
                DataGridResul.Columns.Clear()
                DataGridResul.Rows.Clear()
                MostrarSelloAgua = True
                DataGridResul.Refresh()

                lk_negocio_sn = Await BuscarRegistros("select  * from [dbo].[vw_snegocio]  where " & colbusca & " " & wsTextoBusca & " order by " & colbusca & "")
                If lk_negocio_sn Is Nothing Then Exit Sub
                DataGridResul.DataSource = lk_negocio_sn
                IniciaCabeceraSN()
                MostrarSelloAgua = False
                DataGridResul.Refresh()
            End If


            valorresul = Busca_TextChanged(TxtBuscar, DataGridResul, colbusca, ayuda)
            If valorresul = 1 Then ' encuentra 
                ' Ir a encontrado
            ElseIf valorresul = 2 Then ' Inicializa Data 
                ' Funcionar de iniciarlzar 
                DataGridResul.DataSource = Nothing
                DataGridResul.Columns.Clear()
                DataGridResul.Rows.Clear()
                If DataGridResul.Rows.Count > 0 Then
                    DataGridResul.CurrentCell = DataGridResul.Rows(0).Cells(0)
                End If
            ElseIf valorresul = 3 Then ' No cuentra
                ' Sin Exito Busqueda
            End If


        End If

        If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "200" Then ' DAtos para Socio de NEgoci
            If Strings.Right(Trim(LblBuscarpor.Tag), 2) = "01" Then ' por razon social
                colbusca = "descripcion"
                'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "02" Then ' comercial
                '    colbusca = "comercial"
                'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "03" Then ' RUC
                '    colbusca = "numero"
                'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "04" Then ' por Codigo
                '    colbusca = "codigo"
                'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "05" Then ' por direcc
                '    colbusca = "direccion"
            End If
            If wsTextoBusca <> "" Then
                lk_negocio_sn = New DataTable()
                DataGridResul.DataSource = Nothing
                DataGridResul.Columns.Clear()
                DataGridResul.Rows.Clear()
                MostrarSelloAgua = True
                DataGridResul.Refresh()

                lk_listar_bus = Await BuscarRegistros("select  * from [vw_fn_maestro]  where " & colbusca & " " & wsTextoBusca & " order by " & colbusca & "")
                If lk_listar_bus Is Nothing Then Exit Sub
                DataGridResul.DataSource = lk_listar_bus
                IniciaCabeceraEntidades()
                MostrarSelloAgua = False
                DataGridResul.Refresh()
            End If


            valorresul = Busca_TextChanged(TxtBuscar, DataGridResul, colbusca, ayuda)
            If valorresul = 1 Then ' encuentra 
                ' Ir a encontrado
            ElseIf valorresul = 2 Then ' Inicializa Data 
                ' Funcionar de iniciarlzar 
                DataGridResul.DataSource = Nothing
                DataGridResul.Columns.Clear()
                DataGridResul.Rows.Clear()
                If DataGridResul.Rows.Count > 0 Then
                    DataGridResul.CurrentCell = DataGridResul.Rows(0).Cells(0)
                End If
            ElseIf valorresul = 3 Then ' No cuentra
                ' Sin Exito Busqueda
            End If

        End If
    End Sub
    Private Async Function BuscarRegistros(sql_busq As String) As Task(Of DataTable)
        Try
            Dim tablaResultados As DataTable = Await Task.Run(Function()
                                                                  Dim sql As String = sql_busq
                                                                  Dim command As New SqlCommand(sql, lk_connection_cuenta)
                                                                  Dim adapter As New SqlDataAdapter(command)
                                                                  Dim tabla As New DataTable()
                                                                  Try
                                                                      adapter.Fill(tabla)
                                                                      Return tabla
                                                                  Catch ex2 As Exception
                                                                      Return Nothing
                                                                  Finally

                                                                  End Try
                                                              End Function)

            Return tablaResultados
        Catch ex As Exception
            Return New DataTable() ' Devuelve una tabla de datos vacía en caso de excepción
        Finally

        End Try

    End Function

    Private Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            TxtBuscar.Text = ""
            Nuevabusqueda()
            Exit Sub
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            If DataGridResul.CurrentCell Is Nothing Then
                'PasaDatoPROCESOS(-1)
                Exit Sub
            End If
            If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "100" Then ' DAtos para Socio de NEgoci
                If ENLACE_VIENE = "PROCESOS" Then
                    If Len(TxtCodigo.Tag) <> 0 Then
                        Dim rowIndex As Integer = DataGridResul.CurrentCell.RowIndex
                        Dim columnIndex As Integer = DataGridResul.CurrentCell.ColumnIndex
                        PasaDatoPROCESOS(rowIndex)
                    End If
                End If
                If ENLACE_VIENE = "CONFIGURAR" Then
                    Muestra_SN(DataGridResul.CurrentCell.RowIndex)
                End If
            End If
            If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "200" Then ' DAtos para Socio de NEgoci
                If ENLACE_VIENE = "PROCESOS" Then
                    If Len(TxtCodigo.Tag) <> 0 Then
                        Dim rowIndex As Integer = DataGridResul.CurrentCell.RowIndex
                        Dim columnIndex As Integer = DataGridResul.CurrentCell.ColumnIndex
                        PasaDatoPROCESOS(rowIndex)
                    End If
                End If
                If ENLACE_VIENE = "CONFIGURAR" Then
                    Muestra_Entidades(DataGridResul.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = Keys.F1 Then  ' DEFINO PARA SALIR DEL FORMULARIO DE BUISQUEDAS
            CmbF1Close_Click(Nothing, Nothing)
            Exit Sub
        End If
        If e.KeyCode = Keys.F2 Then
            CmdB1_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F3 Then
            CmdB2_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F4 Then
            CmdB3_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F5 Then
            CmdB4_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.F6 Then
            CmdB5_Click(Nothing, Nothing)
        End If
        If BuscarKeyDown(TxtBuscar, DataGridResul, e) Then
            'muestar datos
        End If
    End Sub

    Private Sub DataGridResul_Paint(sender As Object, e As PaintEventArgs) Handles DataGridResul.Paint
        If MostrarSelloAgua Then
            Dim watermarkText As String = "Buscando..."
            Dim font As New Font("Arial", 16, FontStyle.Italic)
            Dim brush As New SolidBrush(Color.FromArgb(255, System.Drawing.ColorTranslator.FromHtml(strColorAzul)))
            Dim stringSize As SizeF = e.Graphics.MeasureString(watermarkText, font)
            Dim x As Single = (DataGridResul.Width - stringSize.Width) / 2
            Dim y As Single = (DataGridResul.Height - stringSize.Height) / 2
            Dim watermarkPoint As New PointF(x, y)
            e.Graphics.DrawString(watermarkText, font, brush, watermarkPoint)
        End If
    End Sub




    Private Sub CmbF1Close_Click(sender As Object, e As EventArgs) Handles CmbF1Close.Click
        Me.Close()
    End Sub

    Private Sub CmdBuscar_Click(sender As Object, e As EventArgs) Handles CmdBuscar.Click
        TxtBuscar.Select()
        TxtBuscar.Focus()
    End Sub

    Private Sub TxtCodigo_TextChanged(sender As Object, e As EventArgs) Handles TxtCodigo.TextChanged

    End Sub

    Private Sub TxtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim ListaTablas() As DataRow = lk_sql_ListaTablas.Select("id_tipotabla = 90 and codigo = '" & TxtCodigo.Text & "'")
            ' Recorremos las filas filtradas
            If ListaTablas.Length = 0 Then
                Dim Result = MensajesBox.Show("No Definido ningun maestro.",
                                     "Configurar.")
                Exit Sub
            End If
            CmdOpcion.Text = ListaTablas(0)("descripcion").ToString.Trim()

            CodigoBiscador(TxtCodigo.Text, "CONFIGURAR")
        End If
    End Sub

    Private Sub DataGridResul_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridResul.KeyPress
        If e.KeyChar = Chr(13) Then
            If Len(TxtCodigo.Tag) <> 0 Then
                Dim rowIndex As Integer = DataGridResul.CurrentCell.RowIndex
                Dim columnIndex As Integer = DataGridResul.CurrentCell.ColumnIndex
                PasaDatoPROCESOS(rowIndex)
            End If
        End If
    End Sub
    Private Sub PasaDatoPROCESOS(id_fila As Integer)
        If DataGridResul.CurrentCell Is Nothing Then
            DataGridResul.Tag = ""
        Else
            DataGridResul.Tag = DataGridResul.Rows(id_fila).Cells("boxsn").Value.ToString()
        End If

        CmdBuscar.Tag = id_fila
        Me.Hide()
    End Sub

    Private Sub DataGridResul_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridResul.CellContentClick

    End Sub

    Private Sub CmdTipDocSN_Click(sender As Object, e As EventArgs) Handles CmdTipDocSN.Click


        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub

        Dim ListaTipdoc() As DataRow = lk_sql_ListaTipoDocPersona.Select("id_tipodoc <> 0")
        ' Recorremos las filas filtradas
        If ListaTipdoc.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaTipdoc
            Dim id As Integer = CInt(row("id_tipodoc"))
            Dim detalle As String = CStr(row("descripcion"))
            Dim wdigitos As Integer = row("digitos")

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarTopDocSN(id, detalle, wdigitos)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdTipDocSN, New Point(0, CmdTipDocSN.Height))
    End Sub
    Private Sub MostrarTopDocSN(wid As Integer, wdetalle As String, wdigitos As Integer)
        CmdTipDocSN.Text = wdetalle
        CmdTipDocSN.Tag = wid
        CmdTipDocSN.AccessibleName = wdigitos

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim froper As New FrmOper
        froper.ShowDialog()
    End Sub

    Private Sub DataGridResul_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridResul.CellDoubleClick
        ' Asegurarse de que la doble celda clic fue en una fila
        If e.RowIndex >= 0 Then
            If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "100" Then ' DAtos para Socio de NEgoci
                Muestra_SN(e.RowIndex)
            End If
            If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "200" Then ' DAtos para Socio de NEgoci
                Muestra_Entidades(e.RowIndex)
            End If
        End If



    End Sub
    Private Sub Muestra_Entidades(wfila As Integer)
        If wfila < 0 Then Exit Sub
        Dim wid_fn_maestro As Integer = 0
        Dim wid_socionegocio As Integer = 0
        wid_fn_maestro = Val(DataGridResul.Rows(wfila).Cells("id_fn_maestro").Value.ToString())
        t_fn_codigo.Tag = wid_fn_maestro
        t_fn_codigo.Text = DataGridResul.Rows(wfila).Cells("codigo").Value.ToString()
        t_fn_maestro.Text = wid_fn_maestro
        t_fn_descripcion.Text = DataGridResul.Rows(wfila).Cells("descripcion").Value.ToString()
        t_fn_abreviado.Text = DataGridResul.Rows(wfila).Cells("abreviado").Value.ToString()
        t_fn_creacioon.Text = "" ' DataGridResul.Rows(wfila).Cells("comercial").Value.ToString()

        t_fn_CmdMoneda.Text = DataGridResul.Rows(wfila).Cells("mon_simbolo").Value.ToString() & " " & DataGridResul.Rows(wfila).Cells("mon_des").Value.ToString()




        t_fn_botonestado.Text = ""
        If DataGridResul.Rows(wfila).Cells("estado").Value.ToString() = 1 Then
            t_fn_estado.Text = "ACTIVO"
            t_fn_estado.Tag = 1
            t_fn_botonestado.Text = "DESACTIVAR"
        Else
            t_fn_estado.Text = "***DESACTIVADO***"
            t_fn_estado.Tag = 0
            t_fn_botonestado.Text = "ACTIVAR"
        End If


        DataGridResul.Visible = False
        'PanelVendedor.Visible = True
        PanelFN.Dock = System.Windows.Forms.DockStyle.Fill
        PanelFN.Visible = True

        'Muestra_direcciones(wid_sn_maestro)
        'Contador_filas()

        'Muestra_Contactos(wid_sn_maestro)
        'Contador_filas_Contactos()
    End Sub
    Private Sub Muestra_SN(wfila As Integer)
        If wfila < 0 Then Exit Sub
        Dim wid_sn_maestro As Integer = 0
        Dim wid_socionegocio As Integer = 0
        wid_sn_maestro = Val(DataGridResul.Rows(wfila).Cells("id_sn_maestro").Value.ToString())
        wid_socionegocio = Val(DataGridResul.Rows(wfila).Cells("id_socionegocio").Value.ToString())
        t_codigo.Text = DataGridResul.Rows(wfila).Cells("codigo").Value.ToString()
        t_codigo.Tag = wid_sn_maestro
        t_codigo.AccessibleName = wid_socionegocio
        TxtNumero.Text = DataGridResul.Rows(wfila).Cells("numero").Value.ToString()
        t_razonsocial.Text = DataGridResul.Rows(wfila).Cells("razonsocial").Value.ToString()
        t_nombrecomercial.Text = DataGridResul.Rows(wfila).Cells("comercial").Value.ToString()
        t_correocomercial.Text = DataGridResul.Rows(wfila).Cells("correo").Value.ToString()
        t_correoFE.Text = DataGridResul.Rows(wfila).Cells("correo_fe").Value.ToString()
        t_fechareg.Text = Format(DataGridResul.Rows(wfila).Cells("fechareg").Value, "dd/MM/yyyy")

        Dim wid_tiposn As Integer = Val(DataGridResul.Rows(wfila).Cells("id_tab_tiposn").Value.ToString())

        For i = 0 To CmbTipoSN.Items.Count - 1
            If Trim(Strings.Right(CmbTipoSN.Items(i).ToString, 10)) = wid_tiposn Then
                CmbTipoSN.SelectedIndex = i
                Exit For
            End If
        Next
        Dim wid_clasesn As Integer = Val(DataGridResul.Rows(wfila).Cells("id_tab_clasesn").Value.ToString())

        For i = 0 To CmbClaseSN.Items.Count - 1
            If Trim(Strings.Right(CmbClaseSN.Items(i).ToString, 10)) = wid_clasesn Then
                CmbClaseSN.SelectedIndex = i
                Exit For
            End If
        Next
        CmdTipDocSN.Text = DataGridResul.Rows(wfila).Cells("tipodoc").Value.ToString()
        CmdTipDocSN.Tag = DataGridResul.Rows(wfila).Cells("id_tipodoc").Value.ToString()

        'CmdTipDocSN.Text = DataGridResul.Rows(wfila).Cells("id_tab_tiposn").Value.ToString()
        'CmdTipDocSN.Tag = DataGridResul.Rows(wfila).Cells("id_tab_clasesn").Value.ToString()

        'sn.id_tab_tiposn ,
        'ISNULL(tipsn.descripcion, '') AS tiposn,
        'sn.id_tab_clasesn,
        'ISNULL(clasesn.descripcion, '') AS clasesn,

        CmdEstado.Text = ""
        If DataGridResul.Rows(wfila).Cells("estado_sn").Value.ToString() = 1 Then
            lblEstado.Text = "ACTIVO"
            lblEstado.Tag = 1
            CmdEstado.Text = "DESACTIVAR"
        Else
            lblEstado.Text = "***DESACTIVADO***"
            lblEstado.Tag = 0
            CmdEstado.Text = "ACTIVAR"
        End If

        DataGridResul.Visible = False
        'PanelVendedor.Visible = True
        PanelSocioNegocio.Dock = System.Windows.Forms.DockStyle.Fill
        PanelSocioNegocio.Visible = True
        Muestra_direcciones(wid_sn_maestro)
        Contador_filas()

        Muestra_Contactos(wid_sn_maestro)
        Contador_filas_Contactos()

        CmdCrearSN.Visible = False
        CmdGrabaSN.Visible = True


    End Sub
    Private Sub Muestra_Contactos(wid_sn_maestro As Integer)
        GridContactos_Inicia()

        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim lk_sql_listafiltro = New DataTable()
        Dim wcade_filtro_oper As String = ""

        sql_cade = "Select * From [dbo].[vw_sncontactos] Where estado <> 0 and id_negocio = @id_negocio And id_sn_maestro = @id_sn_maestro"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_sn_maestro", wid_sn_maestro)
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listafiltro)
        If lk_sql_listafiltro.Rows.Count = 0 Then
            grid_cont.Rows.Add()
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_contactos").Value = -1
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_maestro").Value = Val(t_codigo.Tag)
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("numero").Value = ""
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("nomape").Value = ""
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("direccion").Value = ""
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("cel").Value = ""
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("tel").Value = ""
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("correo").Value = ""
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("ref").Value = ""


            Contador_filas_Contactos()
            Exit Sub
        End If
        For i = 0 To lk_sql_listafiltro.Rows.Count - 1
            grid_cont.Rows.Add()
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("descrip_tipo").Value = lk_sql_listafiltro.Rows(i).Item("descripcion")
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("numero").Value = lk_sql_listafiltro.Rows(i).Item("numero").ToString.Trim
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("nomape").Value = lk_sql_listafiltro.Rows(i).Item("nomape").ToString.Trim
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("tel").Value = lk_sql_listafiltro.Rows(i).Item("tel").ToString.Trim
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("cel").Value = lk_sql_listafiltro.Rows(i).Item("cel").ToString.Trim
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("nomape").Value = lk_sql_listafiltro.Rows(i).Item("nomape").ToString.Trim
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("direccion").Value = lk_sql_listafiltro.Rows(i).Item("direccion").ToString.Trim
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("correo").Value = lk_sql_listafiltro.Rows(i).Item("correo").ToString.Trim
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("ref").Value = lk_sql_listafiltro.Rows(i).Item("ref").ToString.Trim


            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_contactos").Value = lk_sql_listafiltro.Rows(i).Item("id_sn_contactos")
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_maestro").Value = lk_sql_listafiltro.Rows(i).Item("id_sn_maestro")
            grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_tipodoc").Value = lk_sql_listafiltro.Rows(i).Item("id_tipodoc")
        Next i

        Contador_filas_Contactos()





    End Sub
    Private Sub Muestra_direcciones(wid_sn_maestro As Integer)
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim lk_sql_listafiltro = New DataTable()
        Dim wcade_filtro_oper As String = ""
        Griddireccion_Inicia()

        sql_cade = "Select * From [dbo].[vw_sndirecciones] Where estado <> 0 and id_negocio = @id_negocio And id_sn_maestro = @id_sn_maestro"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_sn_maestro", wid_sn_maestro)
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(lk_sql_listafiltro)
        If lk_sql_listafiltro.Rows.Count = 0 Then
            grid_dir.Rows.Add()
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("descrip_tipo").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("direccion").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ref").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_principal").Value = True
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_despacho").Value = True
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_cobranza").Value = True
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_sn_direcciones").Value = 1
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_sn_maestro").Value = wid_sn_maestro
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ubigeo1").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ubigeo2").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ubigeo3").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_ubigeo_n1").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_ubigeo_n2").Value = ""
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_ubigeo_n3").Value = ""


            Contador_filas()
            Exit Sub
        End If

        For i = 0 To lk_sql_listafiltro.Rows.Count - 1

            grid_dir.Rows.Add()
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("descrip_tipo").Value = lk_sql_listafiltro.Rows(i).Item("tipodireccion")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("direccion").Value = lk_sql_listafiltro.Rows(i).Item("direccion").ToString.Trim
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ref").Value = lk_sql_listafiltro.Rows(i).Item("ref").ToString.Trim

            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_principal").Value = lk_sql_listafiltro.Rows(i).Item("es_principal")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_despacho").Value = lk_sql_listafiltro.Rows(i).Item("es_despacho")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_cobranza").Value = lk_sql_listafiltro.Rows(i).Item("es_cobranza")


            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_sn_direcciones").Value = lk_sql_listafiltro.Rows(i).Item("id_sn_direcciones")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_sn_maestro").Value = lk_sql_listafiltro.Rows(i).Item("id_sn_maestro")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_tab_tipodirec").Value = lk_sql_listafiltro.Rows(i).Item("id_tab_tipodirec")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ubigeo1").Value = lk_sql_listafiltro.Rows(i).Item("departamento")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ubigeo2").Value = lk_sql_listafiltro.Rows(i).Item("distrito")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("ubigeo3").Value = lk_sql_listafiltro.Rows(i).Item("provincia")

            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_ubigeo_n1").Value = lk_sql_listafiltro.Rows(i).Item("id_ubigeo_n1")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_ubigeo_n2").Value = lk_sql_listafiltro.Rows(i).Item("id_ubigeo_n2")
            grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("id_ubigeo_n3").Value = lk_sql_listafiltro.Rows(i).Item("id_ubigeo_n3")


            If lk_sql_listafiltro.Rows(i).Item("es_principal") = 1 Then
                previousPrincipalRowIndex = i
                grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_principal").Value = True
            Else
                grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_principal").Value = False
            End If
            If lk_sql_listafiltro.Rows(i).Item("es_despacho") = 1 Then
                previousDespachoRowIndex = i
                grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_despacho").Value = True
            Else
                grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_despacho").Value = False
            End If

            If lk_sql_listafiltro.Rows(i).Item("es_cobranza") = 1 Then
                previousCobranzaRowIndex = i
                grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_cobranza").Value = True
            Else
                grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("es_cobranza").Value = False
            End If


        Next i
        Contador_filas()

    End Sub
    Private Sub CmdEstado_Click(sender As Object, e As EventArgs) Handles CmdEstado.Click
        If Val(lblEstado.Tag) = 0 Then
            CmdEstado.Text = "DESACTIVAR"
            lblEstado.Text = "ACTIVO"
            lblEstado.Tag = 1
            CmdEstado.Text = "DESACTIVAR"
        Else
            lblEstado.Text = "***DESACTIVADO***"
            lblEstado.Tag = 0
            CmdEstado.Text = "ACTIVAR"
        End If
    End Sub

    Private Sub GridContactos_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()

        grid_cont.Columns.Clear()

        grid_cont.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)
        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = True




        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "descrip_tipo"
        BotonColumn.HeaderText = "TIPO"
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        grid_cont.Columns.Add(BotonColumn)
        grid_cont.Columns.Item(BotonColumn.Name).Width = 40
        grid_cont.Columns.Item(BotonColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 60
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "nomape"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "NOMBRES Y APELLIDOS"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 150
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "tel"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "TEL. FIJO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 65
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cel"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "TEL. CELULAR"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 65
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "direccion"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "DIRECCION"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 120
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ref"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "REF"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 70
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "correo"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "CORREO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Width = 90
        grid_cont.Columns.Item(textoColumn.Name).ReadOnly = False



        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        grid_cont.Columns.Add(imageColumn)
        grid_cont.Columns.Item(imageColumn.Name).Width = 28
        grid_cont.Columns.Item(imageColumn.Name).ReadOnly = False


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.del
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        grid_cont.Columns.Add(imageColumn)
        grid_cont.Columns.Item(imageColumn.Name).Width = 28
        grid_cont.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        grid_cont.Columns.Add(imageColumn)
        grid_cont.Columns.Item(imageColumn.Name).Width = 28
        grid_cont.Columns.Item(imageColumn.Name).ReadOnly = False





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_sn_contactos"
        textoColumn.HeaderText = "id_sn_contactos"
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_sn_maestro"
        textoColumn.HeaderText = "id_sn_maestro"
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_tipodoc"
        textoColumn.HeaderText = "id_tipodoc"
        grid_cont.Columns.Add(textoColumn)
        grid_cont.Columns.Item(textoColumn.Name).Visible = False




    End Sub

    Private Sub Griddireccion_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()

        grid_dir.Columns.Clear()

        grid_dir.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)
        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_dir.Columns.Item(textoColumn.Name).ReadOnly = True




        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "descrip_tipo"
        BotonColumn.HeaderText = "TIPO"
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        grid_dir.Columns.Add(BotonColumn)
        grid_dir.Columns.Item(BotonColumn.Name).Width = 60
        grid_dir.Columns.Item(BotonColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "direccion"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "DIRECCION"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Width = 150
        grid_dir.Columns.Item(textoColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ref"
        textoColumn.Tag = "A200"
        textoColumn.HeaderText = "REF"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Width = 80
        grid_dir.Columns.Item(textoColumn.Name).ReadOnly = False

        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "ubigeo1"
        BotonColumn.HeaderText = "DEPARTAMENTO"
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        BotonColumn.FlatStyle = FlatStyle.Flat
        grid_dir.Columns.Add(BotonColumn)
        grid_dir.Columns.Item(BotonColumn.Name).Width = 80
        grid_dir.Columns.Item(BotonColumn.Name).ReadOnly = False


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "ubigeo2"
        BotonColumn.HeaderText = "PROVINCIA"
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        grid_dir.Columns.Add(BotonColumn)
        grid_dir.Columns.Item(BotonColumn.Name).Width = 80
        grid_dir.Columns.Item(BotonColumn.Name).ReadOnly = False

        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "ubigeo3"
        BotonColumn.HeaderText = "DISTRITO"
        BotonColumn.FlatStyle = FlatStyle.Flat
        BotonColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        grid_dir.Columns.Add(BotonColumn)
        grid_dir.Columns.Item(BotonColumn.Name).Width = 80
        grid_dir.Columns.Item(BotonColumn.Name).ReadOnly = False

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "es_principal"
        checkColumn.HeaderText = "ES FISC."
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grid_dir.Columns.Add(checkColumn)
        grid_dir.Columns.Item(checkColumn.Name).Width = 45
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_dir.Columns.Item(checkColumn.Name).ReadOnly = False
        grid_dir.Columns.Item(checkColumn.Name).Visible = True


        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "es_despacho"
        checkColumn.HeaderText = "ES DESP."
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grid_dir.Columns.Add(checkColumn)
        grid_dir.Columns.Item(checkColumn.Name).Width = 45
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_dir.Columns.Item(checkColumn.Name).ReadOnly = False
        grid_dir.Columns.Item(checkColumn.Name).Visible = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "es_cobranza"
        checkColumn.HeaderText = "ES FINZ."
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grid_dir.Columns.Add(checkColumn)
        grid_dir.Columns.Item(checkColumn.Name).Width = 45
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        grid_dir.Columns.Item(checkColumn.Name).ReadOnly = False
        grid_dir.Columns.Item(checkColumn.Name).Visible = True




        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        grid_dir.Columns.Add(imageColumn)
        grid_dir.Columns.Item(imageColumn.Name).Width = 28
        grid_dir.Columns.Item(imageColumn.Name).ReadOnly = False


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.del
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        grid_dir.Columns.Add(imageColumn)
        grid_dir.Columns.Item(imageColumn.Name).Width = 28
        grid_dir.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        grid_dir.Columns.Add(imageColumn)
        grid_dir.Columns.Item(imageColumn.Name).Width = 28
        grid_dir.Columns.Item(imageColumn.Name).ReadOnly = False





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_sn_direcciones"
        textoColumn.HeaderText = "id_sn_direcciones"
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_sn_maestro"
        textoColumn.HeaderText = "id_sn_maestro"
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_tab_tipodirec"
        textoColumn.HeaderText = "id_tab_tipodirec"
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_ubigeo_n1"
        textoColumn.HeaderText = "id_ubigeo_n1"
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_ubigeo_n2"
        textoColumn.HeaderText = "id_ubigeo_n2"
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_ubigeo_n3"
        textoColumn.HeaderText = "id_ubigeo_n3"
        grid_dir.Columns.Add(textoColumn)
        grid_dir.Columns.Item(textoColumn.Name).Visible = False


    End Sub
    Private Sub Contador_filas()



        'Exit Sub
        '   Iterar por cada fila en el DataGridView
        'If dg_grid.Visible = False Then Exit Sub

        If grid_dir.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To grid_dir.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            grid_dir.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = grid_dir.Rows.Count - 1 Then
                grid_dir.Rows(i).Cells("eli").Value = My.Resources.del
                grid_dir.Rows(i).Cells("eli").Tag = "eli"
                grid_dir.Rows(i).Cells("add").Value = My.Resources.add
                grid_dir.Rows(i).Cells("add").Tag = "add"

            Else
                grid_dir.Rows(i).Cells("eli").Value = My.Resources.del
                grid_dir.Rows(i).Cells("eli").Tag = "eli"
                grid_dir.Rows(i).Cells("add").Value = My.Resources.edit
                grid_dir.Rows(i).Cells("add").Tag = ""
            End If
            ultimafila = i
        Next
    End Sub
    Private Sub Contador_filas_Contactos()



        'Exit Sub
        '   Iterar por cada fila en el DataGridView
        'If dg_grid.Visible = False Then Exit Sub

        If grid_cont.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To grid_cont.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            grid_cont.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = grid_cont.Rows.Count - 1 Then
                grid_cont.Rows(i).Cells("eli").Value = My.Resources.del
                grid_cont.Rows(i).Cells("eli").Tag = "eli"
                grid_cont.Rows(i).Cells("add").Value = My.Resources.add
                grid_cont.Rows(i).Cells("add").Tag = "add"

            Else
                grid_cont.Rows(i).Cells("eli").Value = My.Resources.del
                grid_cont.Rows(i).Cells("eli").Tag = "eli"
                grid_cont.Rows(i).Cells("add").Value = My.Resources.edit
                grid_cont.Rows(i).Cells("add").Tag = ""
            End If
            ultimafila = i
        Next
    End Sub

    Private Sub grid_dir_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_dir.CellContentClick

    End Sub

    Private Sub grid_dir_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles grid_dir.PreviewKeyDown
        If e.KeyCode = Keys.Enter And grid_dir.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If grid_dir.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = grid_dir.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = grid_dir.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = grid_dir.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = grid_dir.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual


            If columnName = "eli" Then
                If grid_dir.Rows.Count - 1 = 0 Then
                    grid_dir.Rows.Clear()
                    ' GridLoteProductos_Inicia()
                    Me.grid_dir.Rows.Add()
                    Me.grid_dir.Rows(Me.grid_dir.Rows.Count - 1).Cells("id_sn_maestro").Value = Val(t_codigo.Tag)
                    Me.grid_dir.Rows(Me.grid_dir.Rows.Count - 1).Cells("id_sn_direcciones").Value = -1
                    Contador_filas()
                    Exit Sub
                End If
                grid_dir.Rows.Remove(grid_dir.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.grid_dir.CurrentCell = grid_dir.Rows(grid_dir.Rows.Count - 1).Cells("num")
                'Me.dg_grid.BeginEdit(True)
                Contador_filas()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If grid_dir.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.grid_dir.Rows.Add()
                Me.grid_dir.Rows(Me.grid_dir.Rows.Count - 1).Cells("id_sn_maestro").Value = Val(t_codigo.Tag)
                Me.grid_dir.Rows(Me.grid_dir.Rows.Count - 1).Cells("id_sn_direcciones").Value = -1
                Contador_filas()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                '   ConfirmaTodoLote()
            End If
        End If
    End Sub
    Private previousPrincipalRowIndex As Integer = -1
    Private previousDespachoRowIndex As Integer = -1
    Private previousCobranzaRowIndex As Integer = -1
    Private Sub grid_dir_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_dir.CellClick
        Dim currentRowIndex As Integer
        Dim wubigeo_rel1 As String
        Dim wubigeo_rel2 As String
        currentRowIndex = e.RowIndex
        If e.ColumnIndex = grid_dir.Columns("descrip_tipo").Index AndAlso e.RowIndex >= 0 Then
            Muestra_MENU_TipoDir(e)
        End If

        If e.ColumnIndex = grid_dir.Columns("ubigeo1").Index AndAlso e.RowIndex >= 0 Then
            Muestra_MENU_Ubigeo(e, 1, "", "")
        End If
        If e.ColumnIndex = grid_dir.Columns("ubigeo2").Index AndAlso e.RowIndex >= 0 Then
            wubigeo_rel1 = grid_dir.Rows(currentRowIndex).Cells("id_ubigeo_n1").Value
            Muestra_MENU_Ubigeo(e, 2, wubigeo_rel1, "")
        End If
        If e.ColumnIndex = grid_dir.Columns("ubigeo3").Index AndAlso e.RowIndex >= 0 Then
            wubigeo_rel1 = grid_dir.Rows(currentRowIndex).Cells("id_ubigeo_n1").Value
            wubigeo_rel2 = grid_dir.Rows(currentRowIndex).Cells("id_ubigeo_n2").Value
            Muestra_MENU_Ubigeo(e, 3, wubigeo_rel1, wubigeo_rel2)
        End If


        If e.ColumnIndex = grid_dir.Columns("es_principal").Index AndAlso e.RowIndex >= 0 Then
            Try
                currentRowIndex = e.RowIndex
                If previousPrincipalRowIndex <> currentRowIndex Then
                    If previousPrincipalRowIndex >= 0 Then
                        grid_dir.Rows(previousPrincipalRowIndex).Cells("es_principal").Value = False
                    End If

                    grid_dir.Rows(currentRowIndex).Cells("es_principal").Value = True
                    previousPrincipalRowIndex = currentRowIndex
                End If
            Catch
                previousPrincipalRowIndex = -1
                For i = 0 To grid_dir.Rows.Count - 1
                    grid_dir.Rows(i).Cells("es_principal").Value = False
                Next
            End Try
        End If
        If e.ColumnIndex = grid_dir.Columns("es_despacho").Index AndAlso e.RowIndex >= 0 Then
            Try
                currentRowIndex = e.RowIndex
                If previousDespachoRowIndex <> currentRowIndex Then
                    If previousDespachoRowIndex >= 0 Then
                        grid_dir.Rows(previousDespachoRowIndex).Cells("es_despacho").Value = False
                    End If

                    grid_dir.Rows(currentRowIndex).Cells("es_despacho").Value = True
                    previousDespachoRowIndex = currentRowIndex
                End If
            Catch
                previousDespachoRowIndex = -1
                For i = 0 To grid_dir.Rows.Count - 1
                    grid_dir.Rows(i).Cells("es_despacho").Value = False
                Next
            End Try
        End If
        If e.ColumnIndex = grid_dir.Columns("es_cobranza").Index AndAlso e.RowIndex >= 0 Then
            Try
                currentRowIndex = e.RowIndex
                If previousCobranzaRowIndex <> currentRowIndex Then
                    If previousCobranzaRowIndex >= 0 Then
                        grid_dir.Rows(previousCobranzaRowIndex).Cells("es_cobranza").Value = False
                    End If

                    grid_dir.Rows(currentRowIndex).Cells("es_cobranza").Value = True
                    previousCobranzaRowIndex = currentRowIndex
                End If
            Catch
                previousCobranzaRowIndex = -1
                For i = 0 To grid_dir.Rows.Count - 1
                    grid_dir.Rows(i).Cells("es_cobranza").Value = False
                Next
            End Try
        End If

    End Sub
    Private Sub Muestra_MENU_Ubigeo(we As DataGridViewCellEventArgs, cod_ubigeo As Integer, id_rel_n1 As String, id_rel_n2 As String)

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        Dim ListaUbigeo() As DataRow
        ' Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()
        If cod_ubigeo = 1 Then
            ListaUbigeo = lk_sql_ListaUbigeoN1.Select("id_pais <> 0")
        ElseIf cod_ubigeo = 2 Then
            ListaUbigeo = lk_sql_ListaUbigeoN2.Select("id_pais <> 0 and id_ubigeo_n1 = '" & id_rel_n1 & "'")
        Else
            ListaUbigeo = lk_sql_ListaUbigeoN3.Select("id_pais <> 0 and id_ubigeo_n1 = '" & id_rel_n1 & "' and id_ubigeo_n2 = '" & id_rel_n2 & "' ")
        End If

        If ListaUbigeo.Length = 0 Then

            Result = MensajesBox.Show("No Tiene Definido Ubigeos.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        For i = 0 To ListaUbigeo.Length - 1
            Dim wid As String = ""
            If cod_ubigeo = 1 Then
                wid = ListaUbigeo(i)("id_ubigeo_n1")
            ElseIf cod_ubigeo = 2 Then
                wid = ListaUbigeo(i)("id_ubigeo_n2")
            ElseIf cod_ubigeo = 3 Then
                wid = ListaUbigeo(i)("id_ubigeo_n3")
            End If
            Dim descripcion As String = ListaUbigeo(i)("descripcion").ToString.Trim

            Dim item As New ToolStripMenuItem(descripcion)
            AddHandler item.Click, Sub()
                                       Muestra_Ubigeo(cod_ubigeo, we, wid, descripcion)
                                   End Sub
            menu.Items.Add(item)
        Next
        For Each item In menu.Items
            Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
            If menuItem IsNot Nothing Then
                menuItem.Font = New Font("Courier New", menuItem.Font.Size)
            End If
        Next



        Dim row As Integer = we.RowIndex  ' Número de fila deseado
        Dim column As Integer = we.ColumnIndex ' Número de columna deseado

        Dim cell As DataGridViewCell = grid_dir.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = grid_dir.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = grid_dir.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


    End Sub
    Private Sub Muestra_Ubigeo(cod_ubigeo As Integer, we As DataGridViewCellEventArgs, wid As String, wdes As String)

        If cod_ubigeo = 1 Then ' departamento
            grid_dir.Rows(we.RowIndex).Cells("id_ubigeo_n1").Value = wid
            grid_dir.Rows(we.RowIndex).Cells("ubigeo1").Value = wdes.Trim

            grid_dir.Rows(we.RowIndex).Cells("id_ubigeo_n2").Value = ""
            grid_dir.Rows(we.RowIndex).Cells("ubigeo2").Value = ""

            grid_dir.Rows(we.RowIndex).Cells("id_ubigeo_n3").Value = ""
            grid_dir.Rows(we.RowIndex).Cells("ubigeo3").Value = ""

        End If
        If cod_ubigeo = 2 Then ' distrito
            grid_dir.Rows(we.RowIndex).Cells("id_ubigeo_n2").Value = wid
            grid_dir.Rows(we.RowIndex).Cells("ubigeo2").Value = wdes.Trim
            grid_dir.Rows(we.RowIndex).Cells("id_ubigeo_n3").Value = ""
            grid_dir.Rows(we.RowIndex).Cells("ubigeo3").Value = ""
        End If
        If cod_ubigeo = 3 Then ' provincia
            grid_dir.Rows(we.RowIndex).Cells("id_ubigeo_n3").Value = wid
            grid_dir.Rows(we.RowIndex).Cells("ubigeo3").Value = wdes.Trim
        End If
    End Sub
    Private Sub Muestra_MENU_TipoDir(we As DataGridViewCellEventArgs)


        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()

        Dim ListaTipoDir() As DataRow = lk_sql_ListaTablas.Select("id_tipotabla = 50")
        If ListaTipoDir.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Definido Tipo Direcciones.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        For i = 0 To ListaTipoDir.Length - 1
            Dim wid As String = ListaTipoDir(i)("id_tb")
            Dim descripcion As String = ListaTipoDir(i)("descripcion").ToString.Trim

            Dim item As New ToolStripMenuItem(descripcion)
            AddHandler item.Click, Sub()
                                       Muestra_TipoDir(we, wid, descripcion)
                                   End Sub
            menu.Items.Add(item)
        Next
        For Each item In menu.Items
            Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
            If menuItem IsNot Nothing Then
                menuItem.Font = New Font("Courier New", menuItem.Font.Size)
            End If
        Next



        Dim row As Integer = we.RowIndex  ' Número de fila deseado
        Dim column As Integer = we.ColumnIndex ' Número de columna deseado

        Dim cell As DataGridViewCell = grid_dir.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = grid_dir.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = grid_dir.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)

    End Sub
    Private Sub Muestra_TipoDir(we As DataGridViewCellEventArgs, wid As String, wdes As String)

        grid_dir.Rows(we.RowIndex).Cells("id_tab_tipodirec").Value = wid
        grid_dir.Rows(we.RowIndex).Cells("descrip_tipo").Value = wdes.Trim
    End Sub

    Private Sub grid_dir_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grid_dir.EditingControlShowing
        ' Verificar si la celda actual es de tipo TextBox
        If TypeOf e.Control Is TextBox Then
            Dim textBox As TextBox = DirectCast(e.Control, TextBox)

            ' Suscribirse al evento KeyPress del TextBox
            AddHandler textBox.KeyPress, AddressOf TextBoxDir_KeyPress
        End If

    End Sub
    Private Sub TextBoxDir_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Convertir el carácter ingresado a mayúsculas
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub grid_cont_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_cont.CellContentClick

    End Sub

    Private Sub grid_cont_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles grid_cont.PreviewKeyDown
        If e.KeyCode = Keys.Enter And grid_cont.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If grid_cont.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = grid_cont.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = grid_cont.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = grid_cont.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = grid_cont.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual


            If columnName = "eli" Then
                If grid_cont.Rows.Count - 1 = 0 Then
                    grid_cont.Rows.Clear()
                    ' GridLoteProductos_Inicia()
                    Me.grid_cont.Rows.Add()
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_contactos").Value = -1
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_maestro").Value = Val(t_codigo.Tag)
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("numero").Value = ""
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("nomape").Value = ""
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("direccion").Value = ""
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("cel").Value = ""
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("tel").Value = ""
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("correo").Value = ""
                    grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("ref").Value = ""

                    Contador_filas_Contactos()
                    Exit Sub
                End If
                grid_cont.Rows.Remove(grid_cont.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.grid_cont.CurrentCell = grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("num")
                'Me.dg_grid.BeginEdit(True)
                Contador_filas_Contactos()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If grid_cont.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.grid_cont.Rows.Add()
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_contactos").Value = -1
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("id_sn_maestro").Value = Val(t_codigo.Tag)
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("numero").Value = ""
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("nomape").Value = ""
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("direccion").Value = ""
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("cel").Value = ""
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("tel").Value = ""
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("correo").Value = ""
                grid_cont.Rows(grid_cont.Rows.Count - 1).Cells("ref").Value = ""

                Contador_filas_Contactos()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                '   ConfirmaTodoLote()
            End If
        End If
    End Sub

    Private Sub grid_cont_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_cont.CellClick
        Dim currentRowIndex As Integer

        currentRowIndex = e.RowIndex
        If e.ColumnIndex = grid_cont.Columns("descrip_tipo").Index AndAlso e.RowIndex >= 0 Then
            Muestra_MENU_TipDoc(e)
        End If
    End Sub
    Private Sub Muestra_MENU_TipDoc(we As DataGridViewCellEventArgs)


        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()

        Dim ListaTipoDir() As DataRow = lk_sql_ListaTipoDocPersona.Select("id_tipodoc <> 0")
        If ListaTipoDir.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Definido Tipo Persona.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        For i = 0 To ListaTipoDir.Length - 1
            Dim wid As String = ListaTipoDir(i)("id_tipodoc")
            Dim descripcion As String = ListaTipoDir(i)("descripcion").ToString.Trim

            Dim item As New ToolStripMenuItem(descripcion)
            AddHandler item.Click, Sub()
                                       Muestra_TipoDoc(we, wid, descripcion)
                                   End Sub
            menu.Items.Add(item)
        Next
        For Each item In menu.Items
            Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
            If menuItem IsNot Nothing Then
                menuItem.Font = New Font("Courier New", menuItem.Font.Size)
            End If
        Next



        Dim row As Integer = we.RowIndex  ' Número de fila deseado
        Dim column As Integer = we.ColumnIndex ' Número de columna deseado

        Dim cell As DataGridViewCell = grid_cont.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = grid_cont.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = grid_cont.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)

    End Sub
    Private Sub Muestra_TipoDoc(we As DataGridViewCellEventArgs, wid As String, wdes As String)

        grid_cont.Rows(we.RowIndex).Cells("id_tipodoc").Value = wid
        grid_cont.Rows(we.RowIndex).Cells("descrip_tipo").Value = wdes.Trim
    End Sub

    Private Sub grid_cont_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grid_cont.EditingControlShowing
        ' Verificar si la celda actual es de tipo TextBox
        If TypeOf e.Control Is TextBox Then
            Dim textBox As TextBox = DirectCast(e.Control, TextBox)

            ' Suscribirse al evento KeyPress del TextBox
            AddHandler textBox.KeyPress, AddressOf TextBoxCont_KeyPress
        End If
    End Sub

    Private Sub TextBoxCont_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Convertir el carácter ingresado a mayúsculas
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub CmdGrabaSN_Click(sender As Object, e As EventArgs) Handles CmdGrabaSN.Click
        If ConsistenciaSN(0) = False Then
            Exit Sub
        End If
        Grabar_SocioNegocio("", 0)
        TxtBuscar.Text = ""

        Nuevabusqueda()

    End Sub
    Private Function ConsistenciaSN(wes_nuevo As Integer) As Boolean
        ConsistenciaSN = True
        Try
            If t_correocomercial.Text.ToString.Trim <> "" Then
                Dim mail As New System.Net.Mail.MailAddress(t_correocomercial.Text)

            End If
        Catch ex As Exception
            ConsistenciaSN = False
            SMS_Barra("Correo Comercial no valido...", 3)
        End Try
        Try
            If t_correoFE.Text.ToString.Trim <> "" Then
                Dim mail As New System.Net.Mail.MailAddress(t_correoFE.Text)
            End If
        Catch ex As Exception
            ConsistenciaSN = False
            SMS_Barra("Correo para la Facturación electronic,  No valido...", 3)
        End Try
        Dim wdig As Integer = Val(CmdTipDocSN.AccessibleName)
        If wdig <> Len(TxtNumero.Text) Then
            ConsistenciaSN = False
            SMS_Barra("Nro de Digitos en el Documento no Coincide co el Tipo del Documento. Debe tener " & wdig & " Digito(s).", 3)
        End If
        If t_razonsocial.Text.Trim = "" Then
            ConsistenciaSN = False
            SMS_Barra("Dato Obligtorio de la Razon Social...", 3)
        End If
        If CmbTipoSN.Text.ToString.Trim = "" Then
            ConsistenciaSN = False
            SMS_Barra("Dato Obligtorio Tipo de Socio de Negocio...", 3)
        End If
        If CmbClaseSN.Text.ToString.Trim = "" Then
            ConsistenciaSN = False
            SMS_Barra("Dato Obligtorio Clase de Socio de Negocio...", 3)
        End If

        Dim whaydirec As Integer = 0
        For i = 0 To grid_dir.Rows.Count - 1
            If grid_dir.Rows(i).Cells("es_principal").Value And grid_dir.Rows(i).Cells("direccion").Value.ToString.Trim <> "" And grid_dir.Rows(i).Cells("id_ubigeo_n1").Value <> "" And grid_dir.Rows(i).Cells("id_ubigeo_n2").Value <> "" And grid_dir.Rows(i).Cells("id_ubigeo_n3").Value <> "" And grid_dir.Rows(i).Cells("id_tab_tipodirec").Value <> 0 Then
                whaydirec = 1
            End If
        Next
        If whaydirec = 0 Then
            ConsistenciaSN = False
            SMS_Barra("Dato Obligtorio Direccion (Debe Indicar todas las columnas y Check de la Dirección )...", 3)
        End If
        If wes_nuevo = 1 Then
            Dim sql_cade As String
            Dim command As SqlCommand
            Dim adaptador As SqlDataAdapter

            Dim wtipodoc As Integer = Val(CmdTipDocSN.Tag)

            sql_cade = "select  id_sn_maestro,codigo from [dbo].[sn_maestro] where  numero = '" & TxtNumero.Text.ToString.Trim & "' and id_tipodoc = " & wtipodoc & " and id_negocio = " & lk_NegocioActivo.id_Negocio & " " ' filtro para buscar por el id : id_oper_maestro
            Dim lk_sql_newcodigo As New DataTable()
            command = New SqlCommand(sql_cade, lk_connection_cuenta)
            adaptador = New SqlDataAdapter(command)
            adaptador.Fill(lk_sql_newcodigo)

            If lk_sql_newcodigo.Rows.Count <> 0 Then
                ConsistenciaSN = False
                SMS_Barra("El Nro. Documento esta Asociado a OTRO Sociio de Negocio con Codigo: " & lk_sql_newcodigo.Rows(0).Item("codigo"), 3)
            End If

        End If


    End Function
    Private Sub CmdCancelarSN_Click(sender As Object, e As EventArgs) Handles CmdCancelarSN.Click
        Nuevabusqueda()
    End Sub


    Private Sub Grabar_SocioNegocio(wCodOper As String, wes_nuevo_reg As Integer)



        'var Cabecera
        Dim wes_nuevo As Integer = 0
        Dim wid_sn_maestro As Integer = 0
        Dim wid_negocio As Integer = 0
        Dim wid_socionegocio As Integer = 0
        Dim wcodigo As Integer = 0
        Dim wid_tipodoc As Integer = 0
        Dim wnumero As String = ""
        Dim wrazonsocial As String = ""
        Dim wcomercial As String = ""
        Dim wdireccion As String = ""
        Dim wcorreo As String = ""
        Dim wcorreo_fe As String = ""
        Dim wid_tab_tiposn As Integer = 0
        Dim wid_tab_clasesn As Integer = 0
        Dim westado As Integer = 0
        Dim wid_ubigeo_n1 As String = ""
        Dim wid_ubigeo_n2 As String = ""
        Dim wid_ubigeo_n3 As String = ""
        Dim wfechareg As DateTime = Now
        Dim Wresultado As String = ""
        Dim werror As String = ""



        wes_nuevo = wes_nuevo_reg

        wid_sn_maestro = Val(t_codigo.Tag)
        wid_negocio = lk_NegocioActivo.id_Negocio
        wid_socionegocio = Val(t_codigo.AccessibleName)
        wcodigo = Val(t_codigo.Text)
        wid_tipodoc = Val(CmdTipDocSN.Tag)
        wnumero = Val(TxtNumero.Text)
        wrazonsocial = t_razonsocial.Text.ToString.Trim
        wcomercial = t_nombrecomercial.Text.ToString.Trim
        wdireccion = ""
        wcorreo = t_correocomercial.Text.ToString.Trim
        wcorreo_fe = t_correoFE.Text.ToString.Trim
        wid_tab_tiposn = Val(Strings.Right(CmbTipoSN.Text, 20).ToString.Trim)
        wid_tab_clasesn = Val(Strings.Right(CmbClaseSN.Text, 20).ToString.Trim)
        westado = Val(lblEstado.Tag)
        wid_ubigeo_n1 = ""
        wid_ubigeo_n2 = ""
        wid_ubigeo_n3 = ""
        wfechareg = Now

        Dim wd_id_sn_direcciones As Integer = 0
        Dim wd_id_negocio As Integer = 0
        Dim wd_id_sn_maestro As Integer = 0
        Dim wd_id_tab_tipodirec As Integer = 0
        Dim wd_es_principal As Integer = 0
        Dim wd_es_despacho As Integer = 0
        Dim wd_es_cobranza As Integer = 0
        Dim wd_direccion As String = ""
        Dim wd_ref As String = ""
        Dim wd_id_ubigeo_n1 As String = ""
        Dim wd_id_ubigeo_n2 As String = ""
        Dim wd_id_ubigeo_n3 As String = ""
        Dim wd_estado As Integer = 0

        ' Crea un DataTable para representar la tabla temporal de detalle
        Dim Wtienedetalle As Integer = 0




        Dim dt_direcciones As New DataTable()
        dt_direcciones.Columns.Add("id_sn_direcciones", GetType(Integer))
        dt_direcciones.Columns.Add("id_negocio", GetType(Integer))
        dt_direcciones.Columns.Add("id_sn_maestro", GetType(Integer))
        dt_direcciones.Columns.Add("id_tab_tipodirec", GetType(Integer))
        dt_direcciones.Columns.Add("es_principal", GetType(Integer))
        dt_direcciones.Columns.Add("es_despacho", GetType(Integer))
        dt_direcciones.Columns.Add("es_cobranza", GetType(Double))
        dt_direcciones.Columns.Add("direccion", GetType(String))
        dt_direcciones.Columns.Add("ref", GetType(String))
        dt_direcciones.Columns.Add("id_ubigeo_n1", GetType(String))
        dt_direcciones.Columns.Add("id_ubigeo_n2", GetType(String))
        dt_direcciones.Columns.Add("id_ubigeo_n3", GetType(String))
        dt_direcciones.Columns.Add("estado", GetType(Integer))

        Wtienedetalle = 1
        If grid_dir.Visible Then
            Wtienedetalle = 0
            'wcal_cantidad = GridProductos.Rows(i).Cells("cantidad").Value
            'wcal_equiv = GridProductos.Rows(i).Cells("equiv").Value
            '    wcal_PrecioBase = GridProductos.Rows(i).Cells("preciobase").Value

            For i = 0 To grid_dir.Rows.Count - 1
                ' If Val(grid_dir.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For
                Wtienedetalle = 1 ' flag marca tienen detalle 
                wid_negocio = lk_NegocioActivo.id_Negocio
                wd_id_sn_direcciones = grid_dir.Rows(i).Cells("id_sn_direcciones").Value
                wd_id_negocio = lk_NegocioActivo.id_Negocio
                wd_id_sn_maestro = grid_dir.Rows(i).Cells("id_sn_maestro").Value
                wd_id_tab_tipodirec = grid_dir.Rows(i).Cells("id_tab_tipodirec").Value
                If grid_dir.Rows(i).Cells("es_principal").Value Then
                    wd_es_principal = 1
                Else
                    wd_es_principal = 0
                End If
                If grid_dir.Rows(i).Cells("es_despacho").Value Then
                    wd_es_despacho = 1
                Else
                    wd_es_despacho = 0
                End If
                If grid_dir.Rows(i).Cells("es_cobranza").Value Then
                    wd_es_cobranza = 1
                Else
                    wd_es_cobranza = 0
                End If
                wd_direccion = grid_dir.Rows(i).Cells("direccion").Value
                wd_ref = grid_dir.Rows(i).Cells("ref").Value
                wd_id_ubigeo_n1 = grid_dir.Rows(i).Cells("id_ubigeo_n1").Value
                wd_id_ubigeo_n2 = grid_dir.Rows(i).Cells("id_ubigeo_n2").Value
                wd_id_ubigeo_n3 = grid_dir.Rows(i).Cells("id_ubigeo_n3").Value
                wd_estado = 1 ' grid_dir.Rows(i).Cells("estado").Value



                dt_direcciones.Rows.Add(wd_id_sn_direcciones, wd_id_negocio, wd_id_sn_maestro, wd_id_tab_tipodirec, wd_es_principal, wd_es_despacho, wd_es_cobranza, wd_direccion, wd_ref, wd_id_ubigeo_n1, wd_id_ubigeo_n2, wd_id_ubigeo_n3, wd_estado)
            Next i

        End If

        Dim wc_id_sn_contactos As Integer = 0
        Dim wc_id_negocio As Integer = 0
        Dim wc_id_sn_maestro As Integer = 0
        Dim wc_id_tipodoc As Integer = 0
        Dim wc_numero As String = ""
        Dim wc_nomape As String = ""
        Dim wc_direccion As String = ""
        Dim wc_Tel As String = ""
        Dim wc_cel As String = ""
        Dim wc_correo As String = ""
        Dim wc_ref As String = ""
        Dim wc_estado As Integer = 0




        Dim dt_contactos As New DataTable()
        dt_contactos.Columns.Add("id_sn_contactos", GetType(Integer))
        dt_contactos.Columns.Add("id_negocio", GetType(Integer))
        dt_contactos.Columns.Add("id_sn_maestro", GetType(Integer))
        dt_contactos.Columns.Add("id_tipodoc", GetType(Integer))
        dt_contactos.Columns.Add("numero", GetType(String))
        dt_contactos.Columns.Add("nomape", GetType(String))
        dt_contactos.Columns.Add("direccion", GetType(String))
        dt_contactos.Columns.Add("Tel", GetType(String))
        dt_contactos.Columns.Add("cel", GetType(String))
        dt_contactos.Columns.Add("correo", GetType(String))
        dt_contactos.Columns.Add("ref", GetType(String))
        dt_contactos.Columns.Add("estado", GetType(Integer))

        If grid_cont.Visible Then
            '            Wtienedetalle = 0
            'wcal_cantidad = GridProductos.Rows(i).Cells("cantidad").Value
            'wcal_equiv = GridProductos.Rows(i).Cells("equiv").Value
            '    wcal_PrecioBase = GridProductos.Rows(i).Cells("preciobase").Value

            For i = 0 To grid_cont.Rows.Count - 1
                ' If Val(grid_dir.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For

                wc_id_negocio = lk_NegocioActivo.id_Negocio
                wc_id_sn_contactos = grid_cont.Rows(i).Cells("id_sn_contactos").Value
                wc_id_sn_maestro = grid_cont.Rows(i).Cells("id_sn_maestro").Value
                wc_id_tipodoc = grid_cont.Rows(i).Cells("id_tipodoc").Value
                wc_numero = grid_cont.Rows(i).Cells("numero").Value
                wc_nomape = grid_cont.Rows(i).Cells("nomape").Value
                wc_direccion = grid_cont.Rows(i).Cells("direccion").Value
                wc_Tel = grid_cont.Rows(i).Cells("tel").Value
                wc_cel = grid_cont.Rows(i).Cells("cel").Value
                wc_correo = grid_cont.Rows(i).Cells("correo").Value
                wc_ref = grid_cont.Rows(i).Cells("ref").Value
                wc_estado = 1

                dt_contactos.Rows.Add(wc_id_sn_contactos, wc_id_negocio, wc_id_sn_maestro, wc_id_tipodoc, wc_numero, wc_nomape, wc_direccion, wc_Tel, wc_cel, wc_correo, wc_ref, wc_estado)
            Next i

        End If






        Using cmd As New SqlCommand("sp_ActualizaMaestroSN", lk_connection_cuenta)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()




            ' Agrega los parámetros de entrada
            cmd.Parameters.AddWithValue("@es_nuevo", wes_nuevo)
            cmd.Parameters.AddWithValue("@id_sn_maestro", wid_sn_maestro)
            cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
            cmd.Parameters.AddWithValue("@id_socionegocio", wid_socionegocio)
            cmd.Parameters.AddWithValue("@codigo", wcodigo)
            cmd.Parameters.AddWithValue("@id_tipodoc", wid_tipodoc)
            cmd.Parameters.AddWithValue("@numero", wnumero)
            cmd.Parameters.AddWithValue("@razonsocial", wrazonsocial)
            cmd.Parameters.AddWithValue("@comercial", wcomercial)
            cmd.Parameters.AddWithValue("@direccion", wdireccion)
            cmd.Parameters.AddWithValue("@correo", wcorreo)
            cmd.Parameters.AddWithValue("@correo_fe", wcorreo_fe)
            cmd.Parameters.AddWithValue("@id_tab_tiposn", wid_tab_tiposn)
            cmd.Parameters.AddWithValue("@id_tab_clasesn", wid_tab_clasesn)
            cmd.Parameters.AddWithValue("@estado", westado)
            cmd.Parameters.AddWithValue("@id_ubigeo_n1", wid_ubigeo_n1)
            cmd.Parameters.AddWithValue("@id_ubigeo_n2", wid_ubigeo_n2)
            cmd.Parameters.AddWithValue("@id_ubigeo_n3", wid_ubigeo_n3)
            cmd.Parameters.AddWithValue("@fechareg", wfechareg)



            ' Agrega el parámetro de tabla temporal de detalle
            Dim detalleParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalDirecciones", dt_direcciones)
            Dim detalleParamCont As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalContactos", dt_contactos)
            'Dim resultadoParam As SqlParameter = cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50)
            'resultadoParam.Direction = ParameterDirection.Output

            'Dim resultado As String = String.Empty
            cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

            detalleParam.SqlDbType = SqlDbType.Structured



            ' Ejecuta el comando Operacion Activa
            Try
                cmd.ExecuteNonQuery()
                Wresultado = DirectCast(cmd.Parameters("@Resultado").Value, String)

                SMS_Barra(Wresultado, 1)

            Catch ex As Exception
                werror = ex.Message
                SMS_Barra("Verificar No actualizo registro..." & Wresultado, 3)
                ' manejo de excepciones  ex.Message 
            End Try

        End Using

        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If





    End Sub

    Private Sub SMS_Barra(wnoti As String, wtipo As Integer)
        LblNoti.Text = wnoti.ToUpper
        LblNoti.Tag = 0


        Dim Colorfondo_t1 As String
        Dim Colorfondo_t2 As String
        Dim Colorfondo_t3 As String

        Dim ColorTexto_t1 As String
        Dim ColorTexto_t2 As String
        Dim ColorTexto_t3 As String
        Dim ColorPanel As String

        If lk_modoOscuro Then
            Colorfondo_t1 = strColorModoVerde
            Colorfondo_t2 = strColorModoTurquesa
            Colorfondo_t3 = strColorModoGrisMedio

            ColorTexto_t1 = strColorModoBlanco
            ColorTexto_t2 = strColorModoNegro
            ColorTexto_t3 = strColorModoBlanco

            ColorPanel = strColorModoGrisMedio
        Else
            Colorfondo_t1 = strColorModoVerde
            Colorfondo_t2 = strColorModoRojo
            Colorfondo_t3 = strColorModoTurquesa

            ColorTexto_t1 = strColorModoBlanco
            ColorTexto_t2 = strColorModoBlanco
            ColorTexto_t3 = strColorModoNegro

            ColorPanel = strColorModoBlanco
        End If
        If wtipo = 1 Then ' Registrado
            PanelMensajes.BackColor = ColorTranslator.FromHtml(ColorPanel)
            LblNoti.ForeColor = ColorTranslator.FromHtml(ColorTexto_t1)
            LblNoti.BackColor = ColorTranslator.FromHtml(Colorfondo_t1)
        ElseIf wtipo = 2 Then ' Error Usuario
            PanelMensajes.BackColor = ColorTranslator.FromHtml(ColorPanel)
            LblNoti.ForeColor = ColorTranslator.FromHtml(ColorTexto_t2)
            LblNoti.BackColor = ColorTranslator.FromHtml(Colorfondo_t2)
        ElseIf wtipo = 3 Then ' Error Interno
            PanelMensajes.BackColor = ColorTranslator.FromHtml(ColorPanel)
            LblNoti.ForeColor = ColorTranslator.FromHtml(ColorTexto_t3)
            LblNoti.BackColor = ColorTranslator.FromHtml(Colorfondo_t3)
        End If
        TimeNoti.Enabled = True
    End Sub

    Private Sub TimeNoti_Tick(sender As Object, e As EventArgs) Handles TimeNoti.Tick
        LblNoti.Visible = True ' LblNoti.Visible = False
        If Val(LblNoti.Tag) >= 5 Then
            TimeNoti.Enabled = False
            LblNoti.Visible = False
            LblNoti.Text = ""
        End If
        LblNoti.Tag = Val(LblNoti.Tag) + 1
    End Sub

    Private Sub t_codigo_TextChanged(sender As Object, e As EventArgs) Handles t_codigo.TextChanged

    End Sub

    Private Sub t_codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t_codigo.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

    End Sub

    Private Sub TxtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumero.KeyPress
        e.Handled = Solo_Numero(e)
    End Sub

    Private Sub fn_cancelar_Click(sender As Object, e As EventArgs) Handles fn_cancelar.Click
        Nuevabusqueda()
    End Sub

    Private Sub fn_Actualizar_Click(sender As Object, e As EventArgs) Handles fn_Actualizar.Click
        'If ConsistenciaSN() = False Then
        '    Exit Sub
        'End If
        Grabar_EntidadFN("")
        TxtBuscar.Text = ""

        Nuevabusqueda()
    End Sub
    Private Sub Grabar_EntidadFN(wCodOper As String)



        'var Cabecera
        Dim wes_nuevo As Integer = 0
        Dim wid_sn_maestro As Integer = 0
        Dim wid_negocio As Integer = 0
        Dim wid_socionegocio As Integer = 0
        Dim wcodigo As Integer = 0
        Dim wid_tipodoc As Integer = 0
        Dim wnumero As String = ""
        Dim wrazonsocial As String = ""
        Dim wcomercial As String = ""
        Dim wdireccion As String = ""
        Dim wcorreo As String = ""
        Dim wcorreo_fe As String = ""
        Dim wid_tab_tiposn As Integer = 0
        Dim wid_tab_clasesn As Integer = 0
        Dim westado As Integer = 0
        Dim wid_ubigeo_n1 As String = ""
        Dim wid_ubigeo_n2 As String = ""
        Dim wid_ubigeo_n3 As String = ""
        Dim wfechareg As DateTime = Now
        Dim Wresultado As String = ""
        Dim werror As String = ""



        wes_nuevo = 0

        wid_sn_maestro = Val(t_codigo.Tag)
        wid_negocio = lk_NegocioActivo.id_Negocio
        wid_socionegocio = Val(t_codigo.AccessibleName)
        wcodigo = Val(t_codigo.Text)
        wid_tipodoc = Val(CmdTipDocSN.Tag)
        wnumero = Val(TxtNumero.Text)
        wrazonsocial = t_razonsocial.Text.ToString.Trim
        wcomercial = t_nombrecomercial.Text.ToString.Trim
        wdireccion = ""
        wcorreo = t_correocomercial.Text.ToString.Trim
        wcorreo_fe = t_correoFE.Text.ToString.Trim
        wid_tab_tiposn = Val(Strings.Right(CmbTipoSN.Text, 20).ToString.Trim)
        wid_tab_clasesn = Val(Strings.Right(CmbClaseSN.Text, 20).ToString.Trim)
        westado = Val(lblEstado.Tag)
        wid_ubigeo_n1 = ""
        wid_ubigeo_n2 = ""
        wid_ubigeo_n3 = ""
        wfechareg = Now

        Dim wd_id_sn_direcciones As Integer = 0
        Dim wd_id_negocio As Integer = 0
        Dim wd_id_sn_maestro As Integer = 0
        Dim wd_id_tab_tipodirec As Integer = 0
        Dim wd_es_principal As Integer = 0
        Dim wd_es_despacho As Integer = 0
        Dim wd_es_cobranza As Integer = 0
        Dim wd_direccion As String = ""
        Dim wd_ref As String = ""
        Dim wd_id_ubigeo_n1 As String = ""
        Dim wd_id_ubigeo_n2 As String = ""
        Dim wd_id_ubigeo_n3 As String = ""
        Dim wd_estado As Integer = 0

        ' Crea un DataTable para representar la tabla temporal de detalle
        Dim Wtienedetalle As Integer = 0




        Dim dt_direcciones As New DataTable()
        dt_direcciones.Columns.Add("id_sn_direcciones", GetType(Integer))
        dt_direcciones.Columns.Add("id_negocio", GetType(Integer))
        dt_direcciones.Columns.Add("id_sn_maestro", GetType(Integer))
        dt_direcciones.Columns.Add("id_tab_tipodirec", GetType(Integer))
        dt_direcciones.Columns.Add("es_principal", GetType(Integer))
        dt_direcciones.Columns.Add("es_despacho", GetType(Integer))
        dt_direcciones.Columns.Add("es_cobranza", GetType(Double))
        dt_direcciones.Columns.Add("direccion", GetType(String))
        dt_direcciones.Columns.Add("ref", GetType(String))
        dt_direcciones.Columns.Add("id_ubigeo_n1", GetType(String))
        dt_direcciones.Columns.Add("id_ubigeo_n2", GetType(String))
        dt_direcciones.Columns.Add("id_ubigeo_n3", GetType(String))
        dt_direcciones.Columns.Add("estado", GetType(Integer))

        Wtienedetalle = 1
        If grid_dir.Visible Then
            Wtienedetalle = 0
            'wcal_cantidad = GridProductos.Rows(i).Cells("cantidad").Value
            'wcal_equiv = GridProductos.Rows(i).Cells("equiv").Value
            '    wcal_PrecioBase = GridProductos.Rows(i).Cells("preciobase").Value

            For i = 0 To grid_dir.Rows.Count - 1
                ' If Val(grid_dir.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For
                Wtienedetalle = 1 ' flag marca tienen detalle 
                wid_negocio = lk_NegocioActivo.id_Negocio
                wd_id_sn_direcciones = grid_dir.Rows(i).Cells("id_sn_direcciones").Value
                wd_id_negocio = lk_NegocioActivo.id_Negocio
                wd_id_sn_maestro = grid_dir.Rows(i).Cells("id_sn_maestro").Value
                wd_id_tab_tipodirec = grid_dir.Rows(i).Cells("id_tab_tipodirec").Value
                If grid_dir.Rows(i).Cells("es_principal").Value Then
                    wd_es_principal = 1
                Else
                    wd_es_principal = 0
                End If
                If grid_dir.Rows(i).Cells("es_despacho").Value Then
                    wd_es_despacho = 1
                Else
                    wd_es_despacho = 0
                End If
                If grid_dir.Rows(i).Cells("es_cobranza").Value Then
                    wd_es_cobranza = 1
                Else
                    wd_es_cobranza = 0
                End If
                wd_direccion = grid_dir.Rows(i).Cells("direccion").Value
                wd_ref = grid_dir.Rows(i).Cells("ref").Value
                wd_id_ubigeo_n1 = grid_dir.Rows(i).Cells("id_ubigeo_n1").Value
                wd_id_ubigeo_n2 = grid_dir.Rows(i).Cells("id_ubigeo_n2").Value
                wd_id_ubigeo_n3 = grid_dir.Rows(i).Cells("id_ubigeo_n3").Value
                wd_estado = 1 ' grid_dir.Rows(i).Cells("estado").Value



                dt_direcciones.Rows.Add(wd_id_sn_direcciones, wd_id_negocio, wd_id_sn_maestro, wd_id_tab_tipodirec, wd_es_principal, wd_es_despacho, wd_es_cobranza, wd_direccion, wd_ref, wd_id_ubigeo_n1, wd_id_ubigeo_n2, wd_id_ubigeo_n3, wd_estado)
            Next i

        End If

        Dim wc_id_sn_contactos As Integer = 0
        Dim wc_id_negocio As Integer = 0
        Dim wc_id_sn_maestro As Integer = 0
        Dim wc_id_tipodoc As Integer = 0
        Dim wc_numero As String = ""
        Dim wc_nomape As String = ""
        Dim wc_direccion As String = ""
        Dim wc_Tel As String = ""
        Dim wc_cel As String = ""
        Dim wc_correo As String = ""
        Dim wc_ref As String = ""
        Dim wc_estado As Integer = 0




        Dim dt_contactos As New DataTable()
        dt_contactos.Columns.Add("id_sn_contactos", GetType(Integer))
        dt_contactos.Columns.Add("id_negocio", GetType(Integer))
        dt_contactos.Columns.Add("id_sn_maestro", GetType(Integer))
        dt_contactos.Columns.Add("id_tipodoc", GetType(Integer))
        dt_contactos.Columns.Add("numero", GetType(String))
        dt_contactos.Columns.Add("nomape", GetType(String))
        dt_contactos.Columns.Add("direccion", GetType(String))
        dt_contactos.Columns.Add("Tel", GetType(String))
        dt_contactos.Columns.Add("cel", GetType(String))
        dt_contactos.Columns.Add("correo", GetType(String))
        dt_contactos.Columns.Add("ref", GetType(String))
        dt_contactos.Columns.Add("estado", GetType(Integer))

        If grid_cont.Visible Then
            '            Wtienedetalle = 0
            'wcal_cantidad = GridProductos.Rows(i).Cells("cantidad").Value
            'wcal_equiv = GridProductos.Rows(i).Cells("equiv").Value
            '    wcal_PrecioBase = GridProductos.Rows(i).Cells("preciobase").Value

            For i = 0 To grid_cont.Rows.Count - 1
                ' If Val(grid_dir.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For

                wc_id_negocio = lk_NegocioActivo.id_Negocio
                wc_id_sn_contactos = grid_cont.Rows(i).Cells("id_sn_contactos").Value
                wc_id_sn_maestro = grid_cont.Rows(i).Cells("id_sn_maestro").Value
                wc_id_tipodoc = grid_cont.Rows(i).Cells("id_tipodoc").Value
                wc_numero = grid_cont.Rows(i).Cells("numero").Value
                wc_nomape = grid_cont.Rows(i).Cells("nomape").Value
                wc_direccion = grid_cont.Rows(i).Cells("direccion").Value
                wc_Tel = grid_cont.Rows(i).Cells("tel").Value
                wc_cel = grid_cont.Rows(i).Cells("cel").Value
                wc_correo = grid_cont.Rows(i).Cells("correo").Value
                wc_ref = grid_cont.Rows(i).Cells("ref").Value
                wc_estado = 1

                dt_contactos.Rows.Add(wc_id_sn_contactos, wc_id_negocio, wc_id_sn_maestro, wc_id_tipodoc, wc_numero, wc_nomape, wc_direccion, wc_Tel, wc_cel, wc_correo, wc_ref, wc_estado)
            Next i

        End If



        If Wtienedetalle = 0 Then
            MsgBox("Debe Ingresar detalla de Productos o servicio, Operacion con detalle ", 3)
            Exit Sub
        End If



        Using cmd As New SqlCommand("sp_ActualizaMaestroSN", lk_connection_cuenta)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()




            ' Agrega los parámetros de entrada
            cmd.Parameters.AddWithValue("@es_nuevo", wes_nuevo)
            cmd.Parameters.AddWithValue("@id_sn_maestro", wid_sn_maestro)
            cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
            cmd.Parameters.AddWithValue("@id_socionegocio", wid_socionegocio)
            cmd.Parameters.AddWithValue("@codigo", wcodigo)
            cmd.Parameters.AddWithValue("@id_tipodoc", wid_tipodoc)
            cmd.Parameters.AddWithValue("@numero", wnumero)
            cmd.Parameters.AddWithValue("@razonsocial", wrazonsocial)
            cmd.Parameters.AddWithValue("@comercial", wcomercial)
            cmd.Parameters.AddWithValue("@direccion", wdireccion)
            cmd.Parameters.AddWithValue("@correo", wcorreo)
            cmd.Parameters.AddWithValue("@correo_fe", wcorreo_fe)
            cmd.Parameters.AddWithValue("@id_tab_tiposn", wid_tab_tiposn)
            cmd.Parameters.AddWithValue("@id_tab_clasesn", wid_tab_clasesn)
            cmd.Parameters.AddWithValue("@estado", westado)
            cmd.Parameters.AddWithValue("@id_ubigeo_n1", wid_ubigeo_n1)
            cmd.Parameters.AddWithValue("@id_ubigeo_n2", wid_ubigeo_n2)
            cmd.Parameters.AddWithValue("@id_ubigeo_n3", wid_ubigeo_n3)
            cmd.Parameters.AddWithValue("@fechareg", wfechareg)



            ' Agrega el parámetro de tabla temporal de detalle
            Dim detalleParam As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalDirecciones", dt_direcciones)
            Dim detalleParamCont As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalContactos", dt_contactos)
            'Dim resultadoParam As SqlParameter = cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50)
            'resultadoParam.Direction = ParameterDirection.Output

            'Dim resultado As String = String.Empty
            cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

            detalleParam.SqlDbType = SqlDbType.Structured



            ' Ejecuta el comando Operacion Activa
            Try
                cmd.ExecuteNonQuery()
                Wresultado = DirectCast(cmd.Parameters("@Resultado").Value, String)

                SMS_Barra(Wresultado, 1)

            Catch ex As Exception
                werror = ex.Message
                SMS_Barra("Verificar No actualizo registro..." & Wresultado, 3)
                ' manejo de excepciones  ex.Message 
            End Try

        End Using

        If werror <> String.Empty Then ' ERROR DE SQL
            MsgBox(werror)
        End If





    End Sub
    Private Sub t_fn_CmdMoneda_Click(sender As Object, e As EventArgs) Handles t_fn_CmdMoneda.Click

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub


        Dim ListaMoneda() As DataRow = lk_sql_monedas_negocio.Select("id_negocio <> 0")
        ' Recorremos las filas filtradas

        If ListaMoneda.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Moneda el Comprobantes Asociados a la Operacion.",
                                     "Operación.")
            t_fn_CmdMoneda.Text = ""
            t_fn_CmdMoneda.Tag = ""
            t_fn_CmdMoneda.AccessibleName = ""
            t_fn_CmdMoneda.AccessibleDescription = ""
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
        menu.Show(t_fn_CmdMoneda, New Point(0, t_fn_CmdMoneda.Height))
    End Sub
    Private Sub MostrarMoneda(id As String, detalle As String, simbolo As String, abreviado As String, esmonlocal As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        t_fn_CmdMoneda.Text = detalle
        t_fn_CmdMoneda.Tag = id
        t_fn_CmdMoneda.AccessibleName = simbolo
        t_fn_CmdMoneda.AccessibleDescription = esmonlocal

    End Sub

    Private Sub CmdCrear_Click(sender As Object, e As EventArgs) Handles CmdCrear.Click
        If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "100" Then ' DAtos para Socio de NEgoci
            DataGridResul.DataSource = Nothing
            DataGridResul.Rows.Clear()
            DataGridResul.Columns.Clear()

            If ENLACE_VIENE = "PROCESOS" Then
                If Len(TxtCodigo.Tag) <> 0 Then
                    Dim rowIndex As Integer = DataGridResul.CurrentCell.RowIndex
                    Dim columnIndex As Integer = DataGridResul.CurrentCell.ColumnIndex
                    PasaDatoPROCESOS(rowIndex)
                End If
            End If
            If ENLACE_VIENE = "CONFIGURAR" Then
                IniciaNuevo_SN(0)
            End If
            CmdCrearSN.Visible = True
            CmdGrabaSN.Visible = False
        End If


    End Sub
    Private Sub IniciaNuevo_SN(wfila As Integer)
        If wfila <0 Then Exit Sub
        Dim wid_sn_maestro As Integer = 0
        Dim wid_socionegocio As Integer = 0


        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter


        sql_cade = "SELECT (ISNULL(MAX(id_sn_maestro), 0) + 1) newcodigo  FROM [sn_maestro]   where id_negocio = " & lk_NegocioActivo.id_Negocio & " " ' filtro para buscar por el id : id_oper_maestro
        Dim lk_sql_newcodigo As New DataTable()
        Command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(Command)
        adaptador.Fill(lk_sql_newcodigo)
        t_codigo.Text = ""
        If lk_sql_newcodigo.Rows.Count <> 0 Then
            t_codigo.Text = lk_sql_newcodigo.Rows(0).Item("newcodigo")
        End If

        wid_sn_maestro = 0
        wid_socionegocio = 0

        t_codigo.Tag = "0" 'wid_sn_maestro
        t_codigo.AccessibleName = "0" 'wid_socionegocio
        TxtNumero.Text = ""
        t_razonsocial.Text = ""
        t_nombrecomercial.Text = ""
        t_correocomercial.Text = ""
        t_correoFE.Text = ""
        t_fechareg.Text = Format(lk_fecha_dia, "dd/MM/yyyy")

        Dim wid_tiposn As Integer = 0

        For i = 0 To CmbTipoSN.Items.Count - 1
            If Trim(Strings.Right(CmbTipoSN.Items(i).ToString, 10)) = wid_tiposn Then
                CmbTipoSN.SelectedIndex = i
                Exit For
            End If
        Next
        Dim wid_clasesn As Integer = 0

        For i = 0 To CmbClaseSN.Items.Count - 1
            If Trim(Strings.Right(CmbClaseSN.Items(i).ToString, 10)) = wid_clasesn Then
                CmbClaseSN.SelectedIndex = i
                Exit For
            End If
        Next
        CmdTipDocSN.Text = ""
        CmdTipDocSN.Tag = "0"


        CmdEstado.Text = ""

        lblEstado.Text = "ACTIVO"
            lblEstado.Tag = 1
            CmdEstado.Text = "DESACTIVAR"

        DataGridResul.Visible = False
        PanelSocioNegocio.Dock = System.Windows.Forms.DockStyle.Fill
        PanelSocioNegocio.Visible = True
        Muestra_direcciones(wid_sn_maestro)
        Contador_filas()

        Muestra_Contactos(wid_sn_maestro)
        Contador_filas_Contactos()

    End Sub

    Private Sub CmdCrearSN_Click(sender As Object, e As EventArgs) Handles CmdCrearSN.Click
        If ConsistenciaSN(1) = False Then
            Exit Sub
        End If
        Stop
        Grabar_SocioNegocio("", 1)
        TxtBuscar.Text = ""

        Nuevabusqueda()
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click

    End Sub
End Class
