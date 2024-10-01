Imports System.Runtime.InteropServices
Imports Newtonsoft.Json

Imports System.Data.SqlClient

Imports WindowsApp1.FrmProductos.Listadni


Public Class FrmProductos
    Dim sql_Tipo_lista_precios As DataTable

    Dim sql_lista_precios As DataTable
    Dim local_dt_pres As New DataTable()
    Dim local_dt_ListaGrupos As New DataTable()
    Dim local_dt_precios As New DataTable()
    Public ReadOnly Property SelectedRow As DataGridViewRow
        Get
            If DataGridResul.SelectedRows.Count > 0 Then
                Return DataGridResul.SelectedRows(0)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property ModoBusqeuda As String
    Public Property TextoBusca As String
    Public Property BUS_ID_LOCAL As Integer
    Public Property BUS_ID_ALMACEN As Integer

    Dim tableSN As New DataTable()
    Dim dt_buscarprod As New DataTable()
    Dim MostrarSelloAgua As Boolean = False
    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        '===============================================


        tabCatalogo.BackColor = Color.White

        PanelSup.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        PanelBusquedas.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        PanelCentro.Visible = True
        PanelCentro.Dock = DockStyle.Fill
        PanelProductos.Visible = False

        'llena_estructurasProductos()

        'Me.Icon = My.Resources.icologo



        llena_cabe_estructuras()
        Carga_parametros_productos()

        Carga_pordefcto_listaPrecio()

        CargaMoneda(1)


        local_dt_pres.Columns.Add("id_negocio", GetType(Integer))
        local_dt_pres.Columns.Add("id_presentacion", GetType(Integer))
        local_dt_pres.Columns.Add("id_prod_mae", GetType(Double))
        local_dt_pres.Columns.Add("es_pordefecto", GetType(Integer))
        local_dt_pres.Columns.Add("es_minimo", GetType(Integer))
        local_dt_pres.Columns.Add("es_blister", GetType(Integer))

        local_dt_ListaGrupos.Columns.Add("id_tipo_prod", GetType(Integer))
        local_dt_ListaGrupos.Columns.Add("id_tbp_estru_id", GetType(Integer))
        local_dt_ListaGrupos.Columns.Add("id_prod", GetType(Decimal))
        local_dt_ListaGrupos.Columns.Add("id_tbp_id", GetType(Integer))




        local_dt_precios.Columns.Add("id_negocio", GetType(Integer))
        local_dt_precios.Columns.Add("id_precio", GetType(Integer))
        local_dt_precios.Columns.Add("id_prod_mae", GetType(Double))
        local_dt_precios.Columns.Add("id_presentacion", GetType(Integer))
        local_dt_precios.Columns.Add("valor_precio", GetType(Double))
        local_dt_precios.Columns.Add("valor_precio_min", GetType(Double))
        local_dt_precios.Columns.Add("margen_costo", GetType(Double))
        local_dt_precios.Columns.Add("margen_costo_min", GetType(Double))
        local_dt_precios.Columns.Add("estado", GetType(Integer))
        local_dt_precios.Columns.Add("id_local", GetType(Integer))
        local_dt_precios.Columns.Add("costo_base", GetType(Double))
        local_dt_precios.Columns.Add("costo_base_equiv", GetType(Integer))
        local_dt_precios.Columns.Add("valor_precio_ant", GetType(Double))



        If ModoBusqeuda = "PROCESOS" Then
            TxtBuscar.Select()
            TxtBuscar.Text = TextoBusca
            TxtBuscar.SelectionStart = TxtBuscar.Text.Length
        Else
            'TxtBuscar.Select()
            'TxtBuscar.Text = TextoBusca
            'TxtBuscar.SelectionStart = 0

            'TxtBuscar.Select()
            'TxtBuscar.Text = ""
            'TxtBuscar.SelectionStart = TxtBuscar.Text.Length
        End If

        GridStock_Inicia()
        Dim tooltip As New ToolTip()
        tooltip.SetToolTip(Cmd_Quitar10, "Quitar: " & LblTipo10.Text)
        tooltip.SetToolTip(Cmd_add10, "Agregar: " & LblTipo10.Text)


    End Sub
    Public lk_infoDNI As JsonListaDni
    Private Sub CargaMoneda(wid_pais As Integer)
        Dim Monedas() As DataRow = lk_sql_monedas_negocio.Select("id_negocio<> 0 and es_monedalocal= 1")
        ' Recorremos las filas filtradas
        If Monedas.Length = 0 Then
            Exit Sub
        End If
        CmdMoneda.Text = Monedas(0)("simbolo") & " " & Monedas(0)("nom_moneda") & " (" & Monedas(0)("abreviado").ToString.Trim & ")"
        CmdMoneda.Tag = Monedas(0)("id_moneda")
        CmdMoneda.AccessibleName = Monedas(0)("simbolo")
        CmdMoneda.AccessibleDescription = Monedas(0)("es_monedalocal")
    End Sub
    Private Sub Carga_parametros_productos()
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter

        sql_cade = "exec [sp_listas_precios_porlocal] @id_negocio "
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)
        sql_Tipo_lista_precios = New DataTable
        adaptador.Fill(sql_Tipo_lista_precios)

    End Sub
    Private Sub OrdenesTrabajoAPI()
        '   TablaInforme.Sort(TablaInforme.Columns("NombreDeLaColumnaAordenar"), System.ComponentModel.ListSortDirection.Ascending)


    End Sub
    Public Sub IrFocis1()
        Me.TxtBuscar.Select()
        Me.TxtBuscar.Focus()
    End Sub





    Public Class Listadni
        Public Class JsonListaDni

            <JsonProperty("estado")>
            Public Property estado As String

            <JsonProperty("code")>
            Public Property code As String

            <JsonProperty("message")>
            Public Property message As String

            <JsonProperty("data")>
            Public Property data As Data()

        End Class
        Public Class Data
            <JsonProperty("dni")>
            Public Property DNI As String

            <JsonProperty("nombre")>
            Public Property Nombre As String

            <JsonProperty("apellido")>
            Public Property Apellido As String


        End Class




    End Class

    Private Sub CmdCerrar_Click(sender As Object, e As EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub CmdRestaurar_Click(sender As Object, e As EventArgs) Handles CmdRestaurar.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub CmdMin_Click(sender As Object, e As EventArgs) Handles CmdMin.Click
        WindowState = FormWindowState.Minimized
        FrmLogin.PanelIndicadores.SendToBack()
        FrmLogin.IndicadorGrafico.SendToBack()
        Me.Text = ""
        Me.ControlBox = True
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

    Private Sub CmdFiltroMuestra_Click(sender As Object, e As EventArgs)

    End Sub




    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Dim btn As New Button()
        'Dim btnQuitar As New Button()
        'Dim textB As String
        'If ComboBox4.SelectedIndex = -1 Then Exit Sub
        'For i = 0 To FlowLayoutPanel1.Controls.Count - 1
        '    If FlowLayoutPanel1.Controls.Item(i).Tag = ComboBox4.SelectedIndex Then
        '        Exit Sub
        '    End If
        'Next

        ''IconButton1.Tag = ComboBox4.SelectedIndex
        'With btn
        '    .Tag = ComboBox4.SelectedIndex
        '    .Name = IconButton1.Tag
        '    Me.ToolTipBotones.SetToolTip(btn, ComboBox4.Items(ComboBox4.SelectedIndex).ToString)
        '    textB = Strings.Left(ComboBox4.Items(ComboBox4.SelectedIndex).ToString, 10)
        '    .Text = textB
        '    .FlatStyle = FlatStyle.Flat
        '    .ForeColor = Color.White
        '    .TextAlign = ContentAlignment.TopLeft
        '    .Font = New Font(New FontFamily("Microsoft Sans Serif"), 7)
        '    .Width = 100
        'End With
        'With btnQuitar
        '    .Tag = ComboBox4.SelectedIndex
        '    .Name = IconButton1.Tag
        '    Me.ToolTipBotones.SetToolTip(btn, ComboBox4.Items(ComboBox4.SelectedIndex).ToString)
        '    textB = "X"
        '    .Text = textB
        '    .FlatStyle = FlatStyle.Flat
        '    .ForeColor = Color.White
        '    .TextAlign = ContentAlignment.TopCenter
        '    .Font = New Font(New FontFamily("Microsoft Sans Serif"), 10)
        '    .Width = 20
        'End With

        'AddHandler btn.Click, AddressOf Button_Click   ' Asocias el evento al método Button_Click


    End Sub




    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles CmdBuscar.Click
        ' DataGridResul.DataSource = lk_infoDNI.data()

        'TextBox2.Focus()
        'TextBox2.SelectionStart = 0
        'TextBox2.SelectionLength = TextBox2.Text.Length

        ' If Not (TypeOf Me.ActiveControl Is TextBox) Then Exit Sub 'si no es un textbox entonces sale de la sub-rutina
    End Sub





    Private Async Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        Dim valorresul As Integer
        Dim wsTextoBusca As String
        Dim colbusca As String = "NombreProducto"
        Dim WCODIGO As Integer
        If TxtBuscar.Text = "" Then
            DataGridResul.DataSource = Nothing
            DataGridResul.Columns.Clear()
            DataGridResul.Rows.Clear()
            DataGridResul.Refresh()

            TxtBox2.Text = ""
            LblProductoTit.Text = ""
            CmbPres.Items.Clear()
        End If
        Dim ws_es_codigo As Integer = 0
        If LblBuscarpor.Tag = "200" Then
            Exit Sub
            ws_es_codigo = 1
        Else
            ws_es_codigo = 0
        End If
        wsTextoBusca = ""
        If Strings.Left(TxtBuscar.Text, 1) = "*" Then
            Dim numCaracteres As Integer = TxtBuscar.Text.ToCharArray().Where(Function(c) c = "*").Count()
            If numCaracteres > 2 Then Exit Sub   ' USUARIO DIGITA MAS DE 2 ASTERISCOS
            If Strings.Left(TxtBuscar.Text, 1) = "*" And Strings.Right(TxtBuscar.Text, 1) = "*" And Len(TxtBuscar.Text) > 2 Then
                wsTextoBusca = Mid(TxtBuscar.Text, 2, Len(TxtBuscar.Text) - 2)
            End If ''

            WCODIGO = 2
        ElseIf Len(Trim(TxtBuscar.Text)) = 3 And ws_es_codigo = 0 Then
            wsTextoBusca = TxtBuscar.Text
            WCODIGO = 1
        End If

        '         If Strings.Left(Trim(LblBuscarpor.Tag), 3) = "100" Then ' DAtos para Socio de NEgoci
        If True Then ' DAtos para Socio de NEgoci
            'If Strings.Right(Trim(LblBuscarpor.Tag), 2) = "01" Then ' por razon social
            '    colbusca = "razonsocial"
            'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "02" Then ' comercial
            '    colbusca = "comercial"
            'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "03" Then ' RUC
            '    colbusca = "numero"
            'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "04" Then ' por Codigo
            '    colbusca = "codigo"
            'ElseIf Strings.Right(Trim(LblBuscarpor.Tag), 2) = "05" Then ' por direcc
            '    colbusca = "direccion"
            'End If
            If wsTextoBusca <> "" Then
                dt_buscarprod = New DataTable()
                DataGridResul.DataSource = Nothing
                DataGridResul.Columns.Clear()
                DataGridResul.Rows.Clear()
                MostrarSelloAgua = True
                DataGridResul.Refresh()
                ' exec [dbo].[sp_buscaproducto] 'prod',2,22 ,1,1
                ' ," + lk_NegocioActivo + "," + lk_NegocioActivo + "," + lk_NegocioActivo + ""
                If lk_NegocioActivo.id_Negocio = Nothing Then
                    dt_buscarprod = Await BuscarRegistros("sp_buscaproducto " & ws_es_codigo & " , '" & wsTextoBusca & "'," & WCODIGO & "," & lk_NegocioActivo.id_Negocio & "," & 3 & "," & 1 & "")
                Else
                    dt_buscarprod = Await BuscarRegistros("sp_buscaproducto " & ws_es_codigo & " , '" & wsTextoBusca & "'," & WCODIGO & "," & lk_NegocioActivo.id_Negocio & "," & BUS_ID_LOCAL & "," & BUS_ID_ALMACEN & "")
                End If
                ' dt_buscarprod = Await BuscarRegistros("sp_buscaproducto '" & wsTextoBusca & "'," & WCODIGO & "," & lk_NegocioActivo.id_Negocio & "," & lk_LocalActivo.id_local & "," & lk_AlmacenActivo.id_almacen & "")
                ' MsgBox(dt_buscarprod.Rows.Count)
                DataGridResul.DataSource = dt_buscarprod
                IniciaCabeceraProd()
                MostrarSelloAgua = False
                DataGridResul.Refresh()
            End If

            valorresul = Busca_TextChanged(TxtBuscar, DataGridResul, colbusca, ayuda)


            If valorresul = 1 Then ' encuentra 
                ' Ir a encontrado
                MuestraInfo_Prod(DataGridResul)

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
    Private Sub MuestraInfo_Prod(Grid As DataGridView)
        ' If Grid.CurrentRow = Nothing Then Exit Sub
        Dim long_box1 As Integer = 26
        Dim long_box2 As Integer = 35

        TxtBox2.Clear()

        If Grid.CurrentRow IsNot Nothing Then
            LblProductoTit.Text = Grid.CurrentRow.Cells("NombreProducto").Value.ToString() & " [ " & Grid.CurrentRow.Cells("Lab_Linea").Value.ToString() & " ]"
            ' -- PRECIOS Y STOCK 
            Dim tdapordefecto As String = lk_LocalActivo.nombre
            tdapordefecto = CentrarTextoEnCadena(tdapordefecto, long_box1)
            'TxtBox1.SelectionStart = 1
            'TxtBox1.SelectionLength = tdapordefecto.Length
            'TxtBox1.SelectionFont = New Font(TxtBox1.Font, FontStyle.Bold)
            'TxtBox1.AppendText(tdapordefecto & vbNewLine) '
            'TxtBox1.AppendText("--------------------------" & vbNewLine) ' 26 cARACTERES tOP DE LINEA
            'TxtBox1.AppendText(Grid.CurrentRow.Cells("PreLocalDef").Value.ToString() & vbNewLine) '
            'TxtBox1.AppendText("- - - - - - - - - - - - - " & vbNewLine) ' 26 cARACTERES tOP DE LINEA
            'TxtBox1.AppendText(Grid.CurrentRow.Cells("StockAlmDef").Value.ToString() & vbNewLine) '

            ' -- INFORMACION BASICA

            tdapordefecto = CentrarTextoEnCadena("Princio Activo", 38)
            TxtBox2.SelectionStart = 1
            TxtBox2.SelectionLength = tdapordefecto.Length
            TxtBox2.SelectionFont = New Font(TxtBox2.Font, FontStyle.Bold)
            TxtBox2.AppendText(tdapordefecto & vbNewLine)
            TxtBox2.AppendText("--------------------------------------" & vbNewLine) ' 26 cARACTERES tOP DE LINEA
            TxtBox2.AppendText(Grid.CurrentRow.Cells("PrinActivo").Value.ToString() & vbNewLine) '
            tdapordefecto = CentrarTextoEnCadena("Concentración", 38)
            TxtBox2.SelectionStart = 1
            TxtBox2.SelectionLength = tdapordefecto.Length
            TxtBox2.SelectionFont = New Font(TxtBox2.Font, FontStyle.Bold)
            TxtBox2.AppendText(tdapordefecto & vbNewLine)
            TxtBox2.AppendText("--------------------------------------" & vbNewLine) ' 26 cARACTERES tOP DE LINEA
            TxtBox2.AppendText(Grid.CurrentRow.Cells("Concentracion").Value.ToString() & vbNewLine) '
            'TxtBox2.AppendText("- - - - - - - - - - - - - - - - - -" & vbNewLine) ' 26 cARACTERES tOP DE LINEA
            Dim arreglo() As String = ConvertirCadenaAArreglo(Grid.CurrentRow.Cells("Presentaciones").Value.ToString())

            CmbPres.Items.Clear()
            For i = 0 To arreglo.Count - 1
                CmbPres.Items.Add(arreglo(i).ToString) ' & Space(80) & lk_api_TipoDocPersona.data(i).id
            Next
            CmbPres.SelectedIndex = 0

        End If
    End Sub
    Function ConvertirCadenaAArreglo(cadena As String) As String()
        Dim substrings() As String = cadena.Split("]")
        Dim arreglo(substrings.Length - 2) As String ' se resta 2 porque la última substring está vacía debido al último "]"

        For i As Integer = 0 To substrings.Length - 2
            'arreglo(i) = substrings(i).Replace("[", "").Substring(1)
            arreglo(i) = substrings(i).Replace("[", "")
        Next

        Return arreglo
    End Function

    Function CentrarTextoEnCadena(texto As String, longitudTotal As Integer) As String
        Dim espaciosPorAgregar As Integer = longitudTotal - texto.Length
        Dim espaciosPorAgregarIzquierda As Integer = espaciosPorAgregar \ 2
        Dim espaciosPorAgregarDerecha As Integer = espaciosPorAgregar - espaciosPorAgregarIzquierda
        Return texto.PadLeft(texto.Length + espaciosPorAgregarIzquierda, " "c).PadRight(longitudTotal, " "c)
    End Function

    Private Sub SearchAndSelectText(ByVal rtb As RichTextBox, ByVal searchText As String, ByVal fontstyle As FontStyle)
        Dim index As Integer = rtb.Find(searchText) ' Busca el texto
        If index <> -1 Then ' Si se encuentra el texto
            rtb.Select(index, searchText.Length) ' Selecciona el texto encontrado
            rtb.SelectionFont = New Font(rtb.Font, fontstyle) ' Establece la fuente seleccionada con el estilo especificado
        End If
    End Sub
    Private Async Function BuscarRegistros(sql_busq As String) As Task(Of DataTable)
        Try
            Dim tablaResultados As DataTable = Await Task.Run(Function()
                                                                  Try
                                                                      Dim sql As String = sql_busq
                                                                      Dim command As New SqlCommand(sql, lk_connection_cuenta)
                                                                      Dim adapter As New SqlDataAdapter(command)
                                                                      Dim tabla As New DataTable()
                                                                      adapter.Fill(tabla)
                                                                      Return tabla
                                                                  Catch exint As Exception
                                                                      Return New DataTable() ' Devuelve una tabla de datos vacía en caso de excepción
                                                                  Finally
                                                                  End Try

                                                              End Function)
            Return tablaResultados
        Catch ex As Exception
            Return New DataTable() ' Devuelve una tabla de datos vacía en caso de excepción
        Finally

        End Try

    End Function

    Private Sub IniciaCabeceraProd()
        If DataGridResul.Columns.Count = 0 Then Exit Sub
        With DataGridResul.Columns
            .Item("Codigo").Visible = True
            .Item("Codigo").Width = 40
            .Item("id_prod_mae").Visible = False

            .Item("id_prod").Visible = False
            .Item("NombreProducto").Visible = True
            .Item("NombreProducto").Width = 300
            .Item("estado").Visible = False

            .Item("es_exonerado").Visible = False

            .Item("cbarra").Visible = False

            .Item("id_tipo_prod").Visible = False

            .Item("Lab_Linea").Visible = True
            .Item("Lab_Linea").Width = 150
            .Item("ALM").Width = 50
            .Item("unidad").Width = 50
            .Item("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
            .Item("Stock").Width = 50
            .Item("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
            .Item("GrupoMed20").Visible = True
            .Item("GrupoMed20").Width = 100
            .Item("TipoProd10").Visible = True
            .Item("TipoProd10").Width = 100
            .Item("PrinActivo").Visible = False
            .Item("Concentracion").Visible = False
            .Item("PreLocalDef").Visible = False
            .Item("StockAlmDef").Visible = False
            .Item("id_presentacion").Visible = False
            .Item("Presentaciones").Visible = False
            .Item("Presentaciones").Visible = False

            .Item("es_control_lote").Visible = False
            .Item("es_inventariable").Visible = False
            .Item("diasprevios_lote").Visible = False
            .Item("diasalerta_lote").Visible = False
            .Item("diasalerta_lote").Visible = False
            .Item("Unidades").Visible = False
            .Item("lotes").Visible = False

            .Item("id_pres_base").Visible = False
            .Item("abreviado_base").Visible = False
            .Item("equiv_base").Visible = False
            .Item("cosproactual").Visible = False
            .Item("stockactual").Visible = False


            Dim imageColumn As New DataGridViewImageColumn()
            imageColumn.HeaderText = "Imagen"
            imageColumn.Name = "imagen"
            imageColumn.HeaderText = "Ver"
            imageColumn.Image = My.Resources.ver
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            DataGridResul.Columns.Add(imageColumn)
            .Item("imagen").Width = 30
        End With

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


    Private Sub DataGridResul_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridResul.SelectionChanged
        MuestraInfo_Prod(DataGridResul)
    End Sub

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = 27 Then
            TxtBuscar.Text = ""
            Exit Sub
        End If

        If e.Control AndAlso e.KeyCode = Keys.F1 Then
            CmdGrupoOtros.PerformClick()
            Exit Sub
        End If
        If e.Control AndAlso e.KeyCode = Keys.F2 Then
            CmdGrupoServ.PerformClick()
            Exit Sub
        End If
        If e.Control AndAlso e.KeyCode = Keys.F3 Then
            CmdMarcas.PerformClick()
            Exit Sub
        End If

        Select Case e.KeyCode
            Case Keys.F1
                Me.Close()
                Exit Sub
            Case Keys.F10
                CmdGrupoMed.PerformClick()
                Exit Sub
            Case Keys.F2
                CmdLab.PerformClick()
                Exit Sub
            Case Keys.F3
                CmdClasi.PerformClick()
                Exit Sub
            Case Keys.F4
                CmdPrinc.PerformClick()
                Exit Sub
            Case Keys.F5
                FrmConcent.PerformClick()
                Exit Sub
            Case Keys.F6
                CmdExcip.PerformClick()
                Exit Sub
            Case Keys.F7
                CmdFormas.PerformClick()
                Exit Sub
            Case Keys.F8
                frmInser.PerformClick()
                Exit Sub
            Case Keys.F9
                CmdSintomas.PerformClick()
                Exit Sub
            Case Else
        End Select



        If e.Control AndAlso e.KeyCode = Keys.D1 Then
            If CmbPres.SelectedIndex = CmbPres.Items.Count - 1 Then
                CmbPres.SelectedIndex = 0
            Else
                If CmbPres.SelectedIndex < CmbPres.Items.Count - 1 Then
                    CmbPres.SelectedIndex = CmbPres.SelectedIndex + 1
                End If
            End If
            Exit Sub
        End If

        If BuscarKeyDown(TxtBuscar, DataGridResul, e) Then
            '  carga_datosGrid(0, DataGridResul)
        End If
        MuestraInfo_Prod(DataGridResul)
        'If e.KeyCode = Keys.Enter Then
        '    ' carga_datosGrid(0, DataGridResul)
        '    'Me.Close()
        '    'Exit Sub


        '    If ModoBusqeuda = "PROCESOS" Then
        '        If DataGridResul.CurrentCell Is Nothing Then Exit Sub
        '        Me.DialogResult = DialogResult.OK
        '        Me.Close()
        '        'Dim rowIndex As String = DataGridResul.CurrentCell.RowIndex

        '        '' Dim columnIndex As Integer = DataGridResul.CurrentCell.ColumnIndex
        '        '' DataGridResul.Tag = rowIndex '0 DataGridResul.Rows(id_fila).Cells("boxsn").Value.ToString()

        '        'Me.Tag = rowIndex
        '        '' TxtBuscar.Tag = "ENCONTRO"
        '        'Me.Hide()
        '        Exit Sub
        '    Else
        '        Exit Sub
        '        'PasaDatoPROCESOS(rowIndex)
        '    End If


        'End If


    End Sub
    Private Sub PasaDatoPROCESOS(id_fila As Integer)
        If DataGridResul.CurrentCell Is Nothing Then
            DataGridResul.Tag = ""
            CmdBuscar.Tag = ""
        Else
            DataGridResul.Tag = id_fila '0 DataGridResul.Rows(id_fila).Cells("boxsn").Value.ToString()
            CmdBuscar.Tag = id_fila
        End If


        'Me.Hide()
        Me.Close()
    End Sub
    Private Sub TxtBuscar_MouseLeave(sender As Object, e As EventArgs) Handles TxtBuscar.MouseLeave

    End Sub


    Private Sub CmdGrupoMed_Click(sender As Object, e As EventArgs) Handles CmdGrupoMed.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdLab_Click(sender As Object, e As EventArgs) Handles CmdLab.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdClasi_Click(sender As Object, e As EventArgs) Handles CmdClasi.Click
        CargaFormBusqueda(sender)
    End Sub
    Private Sub CargaFormBusqueda(sender As Object)
        Dim frbusca As New FrmBuscadores
        frbusca.LblEtiqueta.Text = Trim(DirectCast(sender, Button).Text)
        frbusca.LblEtiqueta.Tag = DirectCast(sender, Button).Tag.ToString()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        frbusca.Left = (Me.Left) + 220
        frbusca.Top = (Me.Top) + 120
        frbusca.ShowDialog()
    End Sub

    Private Sub CmdPrinc_Click(sender As Object, e As EventArgs) Handles CmdPrinc.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub FrmConcent_Click(sender As Object, e As EventArgs) Handles FrmConcent.Click

        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdExcip_Click(sender As Object, e As EventArgs) Handles CmdExcip.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdFormas_Click(sender As Object, e As EventArgs) Handles CmdFormas.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub frmInser_Click(sender As Object, e As EventArgs) Handles frmInser.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdSintomas_Click(sender As Object, e As EventArgs) Handles CmdSintomas.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdGrupoOtros_Click(sender As Object, e As EventArgs) Handles CmdGrupoOtros.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdGrupoServ_Click(sender As Object, e As EventArgs) Handles CmdGrupoServ.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub CmdMarcas_Click(sender As Object, e As EventArgs) Handles CmdMarcas.Click
        CargaFormBusqueda(sender)
    End Sub

    Private Sub ToolTipBotones_Popup(sender As Object, e As PopupEventArgs) Handles ToolTipBotones.Popup

    End Sub

    Private Sub DataGridResul_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridResul.KeyDown
        If e.KeyCode = 27 Then
            TxtBuscar.Focus()
            Exit Sub
        End If
        If e.KeyCode = 13 Then
            EnterDetalle()
        End If
    End Sub

    Private Sub TxtBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub TxtBox2_TextChanged(sender As Object, e As EventArgs) Handles TxtBox2.TextChanged

    End Sub

    Private Sub TxtBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBox2.KeyPress
        e.Handled = True
    End Sub

    Private Async Sub TxtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBuscar.KeyPress


        If e.KeyChar = Chr(Keys.Escape) And LblBuscarpor.Tag = "200" Then
            DataGridResul.DataSource = Nothing
            DataGridResul.Columns.Clear()
            DataGridResul.Rows.Clear()
            DataGridResul.Refresh()
            PanelProductos.Visible = False
            PanelCentro.Visible = True
            PanelCentro.Dock = DockStyle.Fill
            PanelProductos.Dock = DockStyle.None
            TxtBuscar.Select()
            TxtBox2.Text = ""
            LblProductoTit.Text = ""
            CmbPres.Items.Clear()
        End If
        If e.KeyChar = Chr(Keys.Enter) Then

            If LblBuscarpor.Tag = "200" Then
                Dim ws_es_codigo As Integer = 1
                dt_buscarprod = Await BuscarRegistros("sp_buscaproducto " & ws_es_codigo & " , '" & TxtBuscar.Text & "'," & "1" & "," & lk_NegocioActivo.id_Negocio & "," & BUS_ID_LOCAL & "," & BUS_ID_ALMACEN & "")
                If dt_buscarprod.Rows.Count = 0 Then
                    TxtBuscar.Text = ""
                    PanelProductos.Visible = False
                    PanelCentro.Visible = True
                    PanelCentro.Dock = DockStyle.Fill
                    PanelProductos.Dock = DockStyle.None
                    TxtBuscar.Select()
                    Exit Sub
                End If
                DataGridResul.DataSource = dt_buscarprod
                IniciaCabeceraProd()
                MostrarSelloAgua = False
                DataGridResul.Refresh()

            End If


            EnterDetalle()
        End If
    End Sub
    Private Sub EnterDetalle()
        If ModoBusqeuda = "PROCESOS" Then
            If DataGridResul.CurrentCell Is Nothing Then Exit Sub
            Me.DialogResult = DialogResult.OK
            Me.Close()
            Exit Sub
        End If
        If DataGridResul.CurrentCell Is Nothing Then Exit Sub

        Dim rowIndex As Integer = DataGridResul.CurrentCell.RowIndex ' Obtener el índice de la fila actual
        Dim wid_prod As Integer = DataGridResul.Rows(rowIndex).Cells("id_prod_mae").Value
        iniciarProductos()
        InfoDetalladaProducto(wid_prod)
    End Sub
    Private Sub RadioDatoImportar_CheckedChanged(sender As Object, e As EventArgs)

        If ModoBusqeuda = "PROCESOS" Then
            'If DataGridResul.CurrentCell Is Nothing Then
            '    DataGridResul.Tag = ""
            '    CmdBuscar.Tag = ""
            'Else
            '    'DataGridResul.Tag =    
            '    CmdBuscar.Tag = DataGridResul.CurrentCell.RowIndex
            'End If



            Me.DialogResult = DialogResult.OK
            Me.Hide()
            '    Exit Sub
        End If
    End Sub

    Private Sub RadioDatoPropio_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmdRegresa_Click(sender As Object, e As EventArgs) Handles CmdRegresa.Click
        PanelProductos.Visible = False
        PanelCentro.Visible = True
        PanelCentro.Dock = DockStyle.Fill
        PanelProductos.Dock = DockStyle.None
        TxtBuscar.Select()
    End Sub

    Private Sub DataGridResul_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridResul.CellContentClick

    End Sub
    Private Function InfoDetalladaProducto(wid_prod_mae As Integer) As Boolean
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim dt_DatosConsulta_Prod As DataTable
        Dim wid_prod As Integer

        PanelCentro.Visible = False
        PanelCentro.Dock = DockStyle.None
        PanelProductos.Visible = True
        PanelProductos.Dock = DockStyle.Fill

        sql_cade = "SELECT *   FROM [producto_maestro]    where id_negocio = @id_negocio and id_prod_mae = @id_prod_mae "
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_prod_mae", wid_prod_mae)
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)
        dt_DatosConsulta_Prod = New DataTable
        adaptador.Fill(dt_DatosConsulta_Prod)
        InfoDetalladaProducto = True
        If dt_DatosConsulta_Prod.Rows.Count = 0 Then
            InfoDetalladaProducto = False
            Exit Function
        End If
        PanelPrecios.Visible = True
        CmdGrabar.Tag = "UPDATE"
        CmdGrabar.Text = "&ACTUALIZAR "
        wid_prod = dt_DatosConsulta_Prod.Rows(0).Item("id_prod")
        txt_id_prod_master.Text = wid_prod
        txt_idproducto.Text = dt_DatosConsulta_Prod.Rows(0).Item("id_prod_mae")
        txt_codigo.Text = dt_DatosConsulta_Prod.Rows(0).Item("codigo").ToString.Trim
        txt_cbarra.Text = dt_DatosConsulta_Prod.Rows(0).Item("cbarra").ToString.Trim
        txt_diasalerta_lote.Text = dt_DatosConsulta_Prod.Rows(0).Item("diasalerta_lote")
        txt_diasprevios_lote.Text = dt_DatosConsulta_Prod.Rows(0).Item("diasprevios_lote")
        txt_nombre.Text = dt_DatosConsulta_Prod.Rows(0).Item("nombre")
        txt_ref.Text = dt_DatosConsulta_Prod.Rows(0).Item("ref")
        If dt_DatosConsulta_Prod.Rows(0).Item("id_tipo_prod") = 1 Then  ' 1 = Medicamento  , 2 ¨= servicio , 3 = Otros productos 
            Radio_Med.Checked = True
        ElseIf dt_DatosConsulta_Prod.Rows(0).Item("id_tipo_prod") = 2 Then
            Radio_Serv.Checked = True
        ElseIf dt_DatosConsulta_Prod.Rows(0).Item("id_tipo_prod") = 3 Then
            Radio_Otros.Checked = True
        End If


        If dt_DatosConsulta_Prod.Rows(0).Item("es_inventariable") = 1 Then
            Check_es_inventariable.Checked = True
        Else
            Check_es_inventariable.Checked = False
        End If
        If dt_DatosConsulta_Prod.Rows(0).Item("es_exonerado") = 1 Then
            Check_exonerado.Checked = True
        Else
            Check_exonerado.Checked = False
        End If

        If dt_DatosConsulta_Prod.Rows(0).Item("es_control_lote") = 1 Then
            Check_es_controllotes.Checked = True
            PanelLotes.Visible = True
        Else
            Check_es_controllotes.Checked = False
            PanelLotes.Visible = False
        End If


        CmdEstado.Text = ""
        If dt_DatosConsulta_Prod.Rows(0).Item("estado") = 1 Then
            lblEstado.Text = "ACTIVO"
            lblEstado.Tag = 1
            CmdEstado.Text = "DESACTIVAR"
        Else
            lblEstado.Text = "***DESACTIVADO***"
            lblEstado.Tag = 0
            CmdEstado.Text = "ACTIVAR"
        End If

        Dim dt_DatosConsulta_Lista As DataTable

        sql_cade = "exec [sp_estructura_Producto] @id_prod_mae "
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_prod_mae", wid_prod) ' del Maestro principal Master
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)
        dt_DatosConsulta_Lista = New DataTable
        adaptador.Fill(dt_DatosConsulta_Lista)
        llena_cabe_estructuras()
        Muestra_Lista_Estruc(ListTipo10, ListTipo10.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo20, ListTipo20.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo30, ListTipo30.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo40, ListTipo40.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo50, ListTipo50.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo60, ListTipo60.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo70, ListTipo70.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo80, ListTipo80.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo90, ListTipo90.Tag, wid_prod, dt_DatosConsulta_Lista)
        Muestra_Lista_Estruc(ListTipo100, ListTipo100.Tag, wid_prod, dt_DatosConsulta_Lista)


        Muestra_Present(wid_prod_mae, lk_NegocioActivo.id_Negocio)

        Cabecera_Precios_Inicia()
        LblEtiquetaPres.Text = "-"


    End Function
    Private Sub NuevoProducto()
        iniciarProductos()
        PanelPrecios.Visible = False
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter


        Dim genera_codi As Integer
        Dim sql_genera As New DataTable
        sql_cade = "SELECT  (ISNULL(MAX(id_prod_mae), 0) + 1) sec_id_prod_mae FROM [producto_maestro]  WHERe id_negocio = " & lk_NegocioActivo.id_Negocio
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        sql_lista_precios = New DataTable
        adaptador.Fill(sql_genera)
        If sql_genera.Rows.Count = 0 Then
            genera_codi = 1
        Else
            genera_codi = sql_genera.Rows(0).Item("sec_id_prod_mae")
        End If

        CmdGrabar.Tag = "CREA"
        CmdGrabar.Text = "&CREAR"


        txt_id_prod_master.Text = 0
        txt_id_prod_master.Tag = 0

        PanelCentro.Visible = False
        PanelCentro.Dock = DockStyle.None
        PanelProductos.Visible = True
        PanelProductos.Dock = DockStyle.Fill

        txt_idproducto.Text = genera_codi
        txt_idproducto.Tag = genera_codi



        txt_codigo.Text = genera_codi
        txt_cbarra.Text = ""
        txt_diasalerta_lote.Text = ""
        txt_diasprevios_lote.Text = ""
        txt_nombre.Text = ""
        Check_es_inventariable.Checked = True
        Check_exonerado.Checked = False
        Check_es_controllotes.Checked = True
        PanelLotes.Visible = True
        Radio_Med.Checked = True


        lblEstado.Tag = 1
        llena_cabe_estructuras()
        ListTipo10.Items.Clear()
        ListTipo20.Items.Clear()
        ListTipo30.Items.Clear()
        ListTipo40.Items.Clear()
        ListTipo50.Items.Clear()
        ListTipo60.Items.Clear()
        ListTipo70.Items.Clear()
        ListTipo80.Items.Clear()
        ListTipo90.Items.Clear()
        ListTipo100.Items.Clear()
        Cabecera_Precios_Inicia()
        LblEtiquetaPres.Text = "-"

        GridPresentacion_Inicia()
        dg_grid.Rows.Clear()
        ' GridLoteProductos_Inicia()

        Me.dg_grid.Rows.Add()
        Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("descrip_tipo").Value = ""
        Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("id_tb_tipopres").Value = ""
        Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("id_prod_mae").Value = 0
        Contador_filas()

        CmdEstado.Text = "DESACTIVAR"
        lblEstado.Text = "ACTIVO"
        lblEstado.Tag = 1
        CmdEstado.Text = "DESACTIVAR"

    End Sub
    Private Sub Muestra_Lista_Estruc(wcont As ListBox, wtipoEst As Integer, wid_prod As Integer, dt_DatosConsulta_Lista As DataTable)

        Dim Listaestruc() As DataRow = dt_DatosConsulta_Lista.Select("id_tbp_estru_id = " & wtipoEst & "")
        wcont.Items.Clear()
        For i = 0 To Listaestruc.Length - 1
            wcont.Items.Add(Listaestruc(i)("descripcion").ToString.Trim & Space(100) & Listaestruc(i)("id_tbp_id").ToString)
        Next

    End Sub
    Private Sub llena_cabe_estructuras()
        'Dim id_estru As String
        'lk_sql_Lista_estru_prod

        llena_etiqueta(LblTipo10)
        llena_etiqueta(LblTipo20)
        llena_etiqueta(LblTipo30)
        llena_etiqueta(LblTipo40)
        llena_etiqueta(LblTipo50)
        llena_etiqueta(LblTipo60)
        llena_etiqueta(LblTipo70)
        llena_etiqueta(LblTipo80)
        llena_etiqueta(LblTipo90)
        llena_etiqueta(LblTipo100)




    End Sub
    Private Sub llena_etiqueta(labelequit As Label)
        Dim id_estru As String
        labelequit.Text = ""
        id_estru = labelequit.Tag
        Dim EtiquetaEstru() As DataRow = lk_sql_Lista_estru_prod.Select("id_tbp_estru_id = " & id_estru & "")
        If EtiquetaEstru.Length > 0 Then
            labelequit.Text = EtiquetaEstru(0)("descripcion").ToString.Trim.ToUpper
        End If
    End Sub
    Private Sub iniciarProductos()
        txt_idproducto.Text = ""
        txt_id_prod_master.Text = ""
        txt_codigo.Text = ""
        txt_cbarra.Text = ""
        txt_diasalerta_lote.Text = ""
        txt_diasprevios_lote.Text = ""
        txt_nombre.Text = ""
        txt_ref.Text = ""
        Check_es_controllotes.Checked = False
        Check_es_inventariable.Checked = False
        Check_exonerado.Checked = False
        PanelLotes.Visible = False
        Radio_Med.Checked = False
        Radio_Serv.Checked = False
        Radio_Otros.Checked = False
    End Sub

    Private Sub Check_es_controllotes_CheckedChanged(sender As Object, e As EventArgs) Handles Check_es_controllotes.CheckedChanged
        If Check_es_controllotes.Checked = False Then
            PanelLotes.Visible = False
        Else
            PanelLotes.Visible = True
        End If
    End Sub

    Private Sub DataGridResul_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridResul.CellClick
        Dim rowIndex As Integer = DataGridResul.CurrentCell.RowIndex ' Obtener el índice de la fila actual
        Dim wid_prod As Integer = DataGridResul.Rows(rowIndex).Cells("id_prod").Value
        Dim columnIndex As Integer = DataGridResul.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
        Dim columnName As String = DataGridResul.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
        If columnName = "imagen" Then
            iniciarProductos()
            InfoDetalladaProducto(wid_prod)
        End If

    End Sub
    Private Sub Muestra_Present(wid_prod_mae As Integer, wid_negocio As Integer)
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter



        Dim dt_DatosConsulta_Lista As DataTable

        sql_cade = "exec [sp_presentaciones_Producto] @id_negocio , @id_prod_mae "
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        parametro = New SqlParameter("@id_negocio", wid_negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_prod_mae", wid_prod_mae)
        command.Parameters.Add(Parametro)
        adaptador = New SqlDataAdapter(Command)
        dt_DatosConsulta_Lista = New DataTable
        adaptador.Fill(dt_DatosConsulta_Lista)


        GridPresentacion_Inicia()


        For i = 0 To dt_DatosConsulta_Lista.Rows.Count - 1
            dg_grid.Rows.Add()
            dg_grid.CurrentCell = Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("num")
            dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("descrip_tipo").Value = dt_DatosConsulta_Lista.Rows(i).Item("tipopres")
            dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("presentacion").Value = dt_DatosConsulta_Lista.Rows(i).Item("descripcion")
            dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("abreviado").Value = dt_DatosConsulta_Lista.Rows(i).Item("abreviado")
            dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("equiv").Value = dt_DatosConsulta_Lista.Rows(i).Item("equiv")
            dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("id_tb_tipopres").Value = dt_DatosConsulta_Lista.Rows(i).Item("id_tipo_pres")
            dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("id_presentacion").Value = dt_DatosConsulta_Lista.Rows(i).Item("id_presentacion")
            dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("id_prod_mae").Value = dt_DatosConsulta_Lista.Rows(i).Item("id_prod_mae")

            If dt_DatosConsulta_Lista.Rows(i).Item("es_pordefecto") = 1 Then
                previousDefectoRowIndex = i
                dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("defecto").Value = True
            Else
                dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("defecto").Value = False
            End If
            If dt_DatosConsulta_Lista.Rows(i).Item("es_minimo") = 1 Then
                previousMinimoRowIndex = i
                dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("minimo").Value = True
            Else
                dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("minimo").Value = False
            End If

            If dt_DatosConsulta_Lista.Rows(i).Item("es_blister") = 1 Then
                previousBlisterRowIndex = i
                dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("blister").Value = True
            Else
                dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("blister").Value = False
            End If

        Next

        Contador_filas()
    End Sub

    Private Sub GridPresentacion_Inicia()
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

        dg_grid.Columns.Clear()
        dg_grid.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)
        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_grid.Columns.Add(textoColumn)
        dg_grid.Columns.Item(textoColumn.Name).Width = 25
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_grid.Columns.Item(textoColumn.Name).ReadOnly = True




        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "descrip_tipo"
        BotonColumn.HeaderText = "TIPO"
        BotonColumn.FlatStyle = FlatStyle.Flat
        dg_grid.Columns.Add(BotonColumn)
        dg_grid.Columns.Item(BotonColumn.Name).Width = 70
        dg_grid.Columns.Item(BotonColumn.Name).ReadOnly = False


        BotonColumn = New DataGridViewButtonColumn()
        BotonColumn.Name = "presentacion"
        BotonColumn.HeaderText = "PRESENT."
        BotonColumn.FlatStyle = FlatStyle.Flat
        dg_grid.Columns.Add(BotonColumn)
        dg_grid.Columns.Item(BotonColumn.Name).Width = 90
        dg_grid.Columns.Item(BotonColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "abreviado"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "ABREVIAD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_grid.Columns.Add(textoColumn)
        dg_grid.Columns.Item(textoColumn.Name).Width = 60
        dg_grid.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "equiv"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "EQUIV."
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_grid.Columns.Add(textoColumn)
        dg_grid.Columns.Item(textoColumn.Name).Width = 40
        dg_grid.Columns.Item(textoColumn.Name).ReadOnly = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "defecto"
        checkColumn.HeaderText = "POR DEF."
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_grid.Columns.Add(checkColumn)
        dg_grid.Columns.Item(checkColumn.Name).Width = 55
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_grid.Columns.Item(checkColumn.Name).ReadOnly = False
        dg_grid.Columns.Item(checkColumn.Name).Visible = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "minimo"
        checkColumn.HeaderText = "MINIMO DIST"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_grid.Columns.Add(checkColumn)
        dg_grid.Columns.Item(checkColumn.Name).Width = 55
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_grid.Columns.Item(checkColumn.Name).ReadOnly = False
        dg_grid.Columns.Item(checkColumn.Name).Visible = True

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "blister"
        checkColumn.HeaderText = "BLISTER"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_grid.Columns.Add(checkColumn)
        dg_grid.Columns.Item(checkColumn.Name).Width = 55
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_grid.Columns.Item(checkColumn.Name).ReadOnly = False
        dg_grid.Columns.Item(checkColumn.Name).Visible = True


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER PRECIOS"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verprecio"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_grid.Columns.Add(imageColumn)
        dg_grid.Columns.Item(imageColumn.Name).Width = 50
        dg_grid.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "add"
        imageColumn.Image = My.Resources.add
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_grid.Columns.Add(imageColumn)
        dg_grid.Columns.Item(imageColumn.Name).Width = 28
        dg_grid.Columns.Item(imageColumn.Name).ReadOnly = False


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "eli"
        imageColumn.Image = My.Resources.del
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_grid.Columns.Add(imageColumn)
        dg_grid.Columns.Item(imageColumn.Name).Width = 28
        dg_grid.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_grid.Columns.Add(imageColumn)
        dg_grid.Columns.Item(imageColumn.Name).Width = 28
        dg_grid.Columns.Item(imageColumn.Name).ReadOnly = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_tb_tipopres"
        textoColumn.HeaderText = "id_presentacion"
        dg_grid.Columns.Add(textoColumn)
        dg_grid.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_presentacion"
        textoColumn.HeaderText = "id_presentacion"
        dg_grid.Columns.Add(textoColumn)
        dg_grid.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_prod_mae"
        textoColumn.HeaderText = "id_prod_mae"
        dg_grid.Columns.Add(textoColumn)
        dg_grid.Columns.Item(textoColumn.Name).Visible = False




    End Sub
    Private Sub Contador_filas()



        'Exit Sub
        '   Iterar por cada fila en el DataGridView
        'If dg_grid.Visible = False Then Exit Sub

        If dg_grid.CurrentCell Is Nothing Then Exit Sub
        Dim ultimafila As Integer = 0
        For i As Integer = 0 To dg_grid.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            dg_grid.Rows(i).Cells("num").Value = (i + 1).ToString()
            If i = dg_grid.Rows.Count - 1 Then
                dg_grid.Rows(i).Cells("eli").Value = My.Resources.del
                dg_grid.Rows(i).Cells("eli").Tag = "eli"
                dg_grid.Rows(i).Cells("add").Value = My.Resources.add
                dg_grid.Rows(i).Cells("add").Tag = "add"

            Else
                dg_grid.Rows(i).Cells("eli").Value = My.Resources.del
                dg_grid.Rows(i).Cells("eli").Tag = "eli"
                dg_grid.Rows(i).Cells("add").Value = My.Resources.edit
                dg_grid.Rows(i).Cells("add").Tag = ""
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
        Dim wsuma As Double
        Dim wsumaer As String = ""
        Dim wflagfecvcto As String = ""
        Dim wflagfecFab As String = ""
        Dim wflagcodigo As String = ""
        'Iterar por cada fila en el DataGridView

        'LblError.Text = ""
        'FaltaDatos.SetError(CmdAceptar, "")

        If dg_grid.Visible = False Then Exit Sub
        If dg_grid.CurrentCell Is Nothing Then Exit Sub


        wsuma = 0
        For i As Integer = 0 To dg_grid.Rows.Count - 1
            'Actualizar el valor de la celda de la primera columna al número de fila actual
            'If TipoRegistro = "INGRESO" Then
            '    wsuma = wsuma + Val(dg_grid.Rows(i).Cells("ingreso").Value)
            'ElseIf TipoRegistro = "SALIDA" Then
            '    wsuma = wsuma + Val(dg_grid.Rows(i).Cells("salida").Value)
            'End If
            '   wsuma = wsuma + Val(dg_grid.Rows(i).Cells("total").Value)
            'If dg_grid.Rows(i).Cells("codigo").Value = "" Then
            '    wflagcodigo = "Fila: " & dg_grid.Rows(i).Cells("num").Value & " : Indicar Codigo"
            '    GoTo fin
            'End If

            'If dg_grid.Rows(i).Cells("fecvcto").Value = "" Then
            '    wflagfecvcto = "Fila: " & dg_grid.Rows(i).Cells("num").Value & " : Ingresar Fec.Vcto"
            '    GoTo fin
            'End If
            'If dg_grid.Rows(i).Cells("fecfab").Value = "" Then
            '    dg_grid.Rows(i).Cells("fecfab").Value = Format(lk_fecha_dia, "dd/MM/yyyy")

            'End If


        Next

fin:



    End Sub
    Private Function Existe_Presentacion(wbus_id As Integer, wdif_id As Integer) As Boolean
        Existe_Presentacion = False
        For i As Integer = 0 To dg_grid.Rows.Count - 1
            If Val(dg_grid.Rows(i).Cells("id_presentacion").Value) = wbus_id And Val(dg_grid.Rows(i).Cells("id_presentacion").Value) <> wdif_id Then
                Existe_Presentacion = True
                Exit Function
            End If
        Next
    End Function

    Private Sub dg_grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_grid.CellContentClick

    End Sub
    Private previousBlisterRowIndex As Integer = -1
    Private previousMinimoRowIndex As Integer = -1
    Private previousDefectoRowIndex As Integer = -1

    Private Sub dg_grid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_grid.CellClick
        Dim currentRowIndex As Integer
        If e.ColumnIndex = dg_grid.Columns("descrip_tipo").Index AndAlso e.RowIndex >= 0 Then
            'Dim valorCelda As String = dg_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            'Dim wd_forma As Integer = dg_grid.Rows(e.RowIndex).Cells("descrip_tipo").Tag
            Muestra_MENU_TipoPres(e)
        End If
        If e.ColumnIndex = dg_grid.Columns("presentacion").Index AndAlso e.RowIndex >= 0 Then
            Dim wd_tipopres As Integer = Val(dg_grid.Rows(e.RowIndex).Cells("id_tb_tipopres").Value)
            If wd_tipopres = 0 Then Exit Sub
            Muestra_MENU_Presentacion(e, wd_tipopres)
        End If


        If e.ColumnIndex = dg_grid.Columns("blister").Index AndAlso e.RowIndex >= 0 Then
            Try
                currentRowIndex = e.RowIndex
                If previousBlisterRowIndex <> currentRowIndex Then
                    If previousBlisterRowIndex >= 0 Then
                        dg_grid.Rows(previousBlisterRowIndex).Cells("blister").Value = False
                    End If

                    dg_grid.Rows(currentRowIndex).Cells("blister").Value = True
                    previousBlisterRowIndex = currentRowIndex
                End If
            Catch
                previousBlisterRowIndex = -1
                For i = 0 To dg_grid.Rows.Count - 1
                    dg_grid.Rows(i).Cells("blister").Value = False
                Next
            End Try
        End If
        If e.ColumnIndex = dg_grid.Columns("minimo").Index AndAlso e.RowIndex >= 0 Then
            Try
                currentRowIndex = e.RowIndex
                If previousMinimoRowIndex <> currentRowIndex Then
                    If previousMinimoRowIndex >= 0 Then
                        dg_grid.Rows(previousMinimoRowIndex).Cells("minimo").Value = False
                    End If

                    dg_grid.Rows(currentRowIndex).Cells("minimo").Value = True
                    previousMinimoRowIndex = currentRowIndex
                End If
            Catch
                previousMinimoRowIndex = -1
                For i = 0 To dg_grid.Rows.Count - 1
                    dg_grid.Rows(i).Cells("minimo").Value = False
                Next
            End Try
        End If
        If e.ColumnIndex = dg_grid.Columns("defecto").Index AndAlso e.RowIndex >= 0 Then
            Try
                currentRowIndex = e.RowIndex
                If previousDefectoRowIndex <> currentRowIndex Then
                    If previousDefectoRowIndex >= 0 Then
                        dg_grid.Rows(previousDefectoRowIndex).Cells("defecto").Value = False
                    End If

                    dg_grid.Rows(currentRowIndex).Cells("defecto").Value = True
                    previousDefectoRowIndex = currentRowIndex
                End If
            Catch
                previousDefectoRowIndex = -1
                For i = 0 To dg_grid.Rows.Count - 1
                    dg_grid.Rows(i).Cells("defecto").Value = False
                Next
            End Try
        End If





        If e.ColumnIndex = dg_grid.Columns("verprecio").Index AndAlso e.RowIndex >= 0 Then
            'Try
            LblEtiquetaPres.Text = dg_grid.Rows(e.RowIndex).Cells("presentacion").Value & " - " & dg_grid.Rows(e.RowIndex).Cells("abreviado").Value & " (" & dg_grid.Rows(e.RowIndex).Cells("equiv").Value & ")"
            Dim wid_presentacion As Integer = dg_grid.Rows(e.RowIndex).Cells("id_presentacion").Value
                Dim wid_prod_mae As Integer = dg_grid.Rows(e.RowIndex).Cells("id_prod_mae").Value
                Dim wid_moneda As Integer = Val(CmdMoneda.Tag)
                Dim wid_local As Integer = Val(CmdLocalLista.Tag)
            Dim wid_listaprecio As Integer = Val(CmdTipoLista.Tag)
            Dim wequiv As Integer = dg_grid.Rows(e.RowIndex).Cells("equiv").Value
            Muestra_Precios(wid_prod_mae, wid_presentacion, wid_local, wid_listaprecio, wid_moneda, wequiv)

            'Catch

            'End Try
        End If




    End Sub
    Private Sub Muestra_MENU_Presentacion(we As DataGridViewCellEventArgs, wid_tipopres As Integer)

        'adaptador.Fill(lk_sql_Presentaciones)


        'adaptador.Fill(lk_sql_TipoPres

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()

        Dim ListaPresentacion() As DataRow = lk_sql_Presentaciones.Select("id_tb_tippres = " & wid_tipopres & "")
        If ListaPresentacion.Length = 0 Then
            Result = MensajesBox.Show("No Tiene Definido Lista de Presentacion.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        Dim maxDescripcionLength As Integer = 15 ' ListaPresentacion.Max(Function(item) item("descripcion").ToString().Length)
        Dim maxAbreviadoLength As Integer = 10 'ListaPresentacion.Max(Function(item) item("abreviado").ToString().Trim().Length)
        Dim maxEquivLength As Integer = 5 'ListaPresentacion.Max(Function(item) item("equiv").ToString().Length)

        For i = 0 To ListaPresentacion.Length - 1
            Dim wid As String = ListaPresentacion(i)("id_presentacion")
            Dim descripcion As String = ListaPresentacion(i)("descripcion").ToString.Trim
            Dim abreviado As String = ListaPresentacion(i)("abreviado").ToString().Trim()
            Dim equiv As String = ListaPresentacion(i)("equiv").ToString()

            Dim formattedDescripcion As String = descripcion.PadRight(maxDescripcionLength)
            Dim formattedAbreviado As String = abreviado.PadRight(maxAbreviadoLength)
            Dim formattedEquiv As String = equiv.PadRight(maxEquivLength)

            Dim wdes As String = $"{formattedDescripcion} {formattedAbreviado} {formattedEquiv}"

            Dim wdescripcion As String = ListaPresentacion(i)("descripcion")
            Dim wabre As String = ListaPresentacion(i)("abreviado")
            Dim wequiv As String = ListaPresentacion(i)("equiv")

            Dim item As New ToolStripMenuItem(wdes)
            AddHandler item.Click, Sub()
                                       Muestra_Presentacion(we, wid, wdes, wabre, wequiv, wdescripcion)
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

        Dim cell As DataGridViewCell = dg_grid.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = dg_grid.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = dg_grid.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_Presentacion(we As DataGridViewCellEventArgs, wid As String, wdes As String, wabre As String, wequiv As Integer, wdescripcion As String)
        Dim wdif_id As Integer = Val(dg_grid.Rows(we.RowIndex).Cells("id_presentacion").Value)
        If Existe_Presentacion(wid, wdif_id) Then
            Dim Result As String = MensajesBox.Show("Presentación," & wdescripcion.Trim & " Existe en el producto.",
                                    "Presentaciones.")
            Exit Sub
        End If
        dg_grid.Rows(we.RowIndex).Cells("id_presentacion").Value = wid
        dg_grid.Rows(we.RowIndex).Cells("presentacion").Value = wdescripcion.Trim
        dg_grid.Rows(we.RowIndex).Cells("abreviado").Value = wabre
        dg_grid.Rows(we.RowIndex).Cells("equiv").Value = wequiv
        dg_grid.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid


        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub
    Private Sub Muestra_MENU_TipoPres(we As DataGridViewCellEventArgs)

        'adaptador.Fill(lk_sql_Presentaciones)


        'adaptador.Fill(lk_sql_TipoPres

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' Dim temp_finanzas As DataTable = lk_sql_finanzas_local.Copy()



        ' Recorremos las filas filtradas

        If lk_sql_TipoPres.Rows.Count = 0 Then
            Result = MensajesBox.Show("No Tiene Definido Tipo de Presentacion.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        'S/ - SOLES (PE)
        For i = 0 To lk_sql_TipoPres.Rows.Count - 1

            Dim wid As String = lk_sql_TipoPres.Rows(i).Item("id_tb")
            Dim wdes As String = lk_sql_TipoPres.Rows(i).Item("descripcion")

            Dim item As New ToolStripMenuItem(wdes)
            AddHandler item.Click, Sub()
                                       Muestra_TipoPres(we, wid, wdes)
                                   End Sub
            menu.Items.Add(item)
        Next

        Dim row As Integer = we.RowIndex  ' Número de fila deseado
        Dim column As Integer = we.ColumnIndex ' Número de columna deseado

        Dim cell As DataGridViewCell = dg_grid.Rows(row).Cells(column)
        Dim cellBounds As Rectangle = dg_grid.GetCellDisplayRectangle(column, row, False)
        Dim cellPosition As Point = dg_grid.PointToScreen(New Point(cellBounds.Left, cellBounds.Bottom))

        menu.Show(cellPosition)


        '        menu.Show(CmdMonedaComp, New Point(0, CmdMonedaComp.Height))
    End Sub
    Private Sub Muestra_TipoPres(we As DataGridViewCellEventArgs, wid As String, wdes As String)

        dg_grid.Rows(we.RowIndex).Cells("id_tb_tipopres").Value = wid
        dg_grid.Rows(we.RowIndex).Cells(we.ColumnIndex).Value = wdes
        dg_grid.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid


        'dg_finanzas.Rows(we.RowIndex).Cells(we.ColumnIndex).Tag = wid_tb_formas_fn

    End Sub

    Private Sub dg_grid_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles dg_grid.PreviewKeyDown
        If e.KeyCode = Keys.Enter And dg_grid.Focused Then ' Verificar si se ha presionado la tecla "Delete" en el DataGridView
            If dg_grid.CurrentCell Is Nothing Then Exit Sub
            Dim columnIndex As Integer = dg_grid.CurrentCell.ColumnIndex ' Obtener el índice de la columna actual
            Dim columnName As String = dg_grid.Columns(columnIndex).Name ' Obtener el nombre de la columna actual
            Dim rowIndex As Integer = dg_grid.CurrentCell.RowIndex ' Obtener el índice de la fila actual
            'Dim rowTag As Object = GridProductos.Rows(rowIndex).Tag ' Obtener el contenido del tag de la fila actual
            Dim rowTag As Object = dg_grid.Rows(rowIndex).Cells("eli").Tag ' Obtener el contenido del tag de la celda actual


            If columnName = "eli" Then
                If dg_grid.Rows.Count - 1 = 0 Then
                    dg_grid.Rows.Clear()
                    ' GridLoteProductos_Inicia()
                    Me.dg_grid.Rows.Add()
                    Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("descrip_tipo").Value = Me.dg_grid.Rows(rowIndex).Cells("descrip_tipo").Value
                    Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("id_tb_tipopres").Value = Me.dg_grid.Rows(rowIndex).Cells("id_tb_tipopres").Value
                    Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("id_prod_mae").Value = Val(txt_idproducto.Text)
                    Contador_filas()
                    Exit Sub
                End If
                dg_grid.Rows.Remove(dg_grid.CurrentRow) ' Eliminar la primera fila seleccionada

                Me.dg_grid.CurrentCell = dg_grid.Rows(dg_grid.Rows.Count - 1).Cells("num")
                'Me.dg_grid.BeginEdit(True)
                Contador_filas()
            End If
            If columnName = "add" Then ' Verificar que se haya seleccionado alguna fila
                If dg_grid.Rows(rowIndex).Cells("add").Tag = "" Then Exit Sub
                Me.dg_grid.Rows.Add()
                Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("descrip_tipo").Value = Me.dg_grid.Rows(rowIndex).Cells("descrip_tipo").Value
                Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("id_tb_tipopres").Value = Me.dg_grid.Rows(rowIndex).Cells("id_tb_tipopres").Value
                Me.dg_grid.Rows(Me.dg_grid.Rows.Count - 1).Cells("id_prod_mae").Value = Val(txt_idproducto.Text)
                'Me.dg_grid.BeginEdit(True)
                Contador_filas()
                'GridProductos_PrimeraFila()
            End If
            If columnName = "ok" Then ' Verificar que se haya seleccionado alguna fila
                '   ConfirmaTodoLote()
            End If
        End If
    End Sub
    Private columnaEspecifica As DataGridViewColumn

    Private Sub dg_grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_grid.CellDoubleClick

        If e.ColumnIndex = dg_grid.Columns("add").Index AndAlso e.RowIndex >= 0 Then
            SendKeys.Send("{ENTER}")
        End If
        If e.ColumnIndex = dg_grid.Columns("eli").Index AndAlso e.RowIndex >= 0 Then

            SendKeys.Send("{ENTER}")
        End If


    End Sub
    Private Sub Cabecera_Precios_Inicia()
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

        dg_precios.Columns.Clear()
        'dg_grid.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)
        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "num"
        'textoColumn.HeaderText = "#"
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'dg_grid.Columns.Add(textoColumn)
        'dg_grid.Columns.Item(textoColumn.Name).Width = 25
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        'dg_grid.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Width = 60
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "modolista"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "MODO LISTA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Width = 60
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "lista"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "LISTA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Width = 50
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "abreviado"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "ABRE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Width = 35
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "A15"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Width = 30
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = True





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "costo_base"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "COSTO BASE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(textoColumn.Name).MinimumWidth = 60
        dg_precios.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0.00##" ' 

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "costo_ult"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "COSTO ULT"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(textoColumn.Name).MinimumWidth = 60
        dg_precios.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0.00##" ' 

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "costo_avg"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "COSTO PROM"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(textoColumn.Name).MinimumWidth = 60
        dg_precios.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0.00##" ' 

        dg_precios.Columns.Item("costo_base").Visible = False
        dg_precios.Columns.Item("costo_ult").Visible = False
        dg_precios.Columns.Item("costo_avg").Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "porcosto1"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "PORC%"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_precios.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0.0#" ' 

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "precio"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "PRECIO BASE"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(textoColumn.Name).MinimumWidth = 55
        dg_precios.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0.0#"

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "porcosto2"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "PORC%"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_precios.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0.0#" ' 

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "minimo"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "PRECIO MINIMO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(textoColumn.Name).MinimumWidth = 55
        dg_precios.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        textoColumn.DefaultCellStyle.Format = "#0.0#"

        checkColumn = New DataGridViewCheckBoxColumn()
        checkColumn.Name = "estado"
        checkColumn.HeaderText = "EST"
        checkColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        checkColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_precios.Columns.Add(checkColumn)
        dg_precios.Columns.Item(checkColumn.Name).Width = 23
        checkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dg_precios.Columns.Item(checkColumn.Name).ReadOnly = False
        dg_precios.Columns.Item(checkColumn.Name).Visible = True


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "*"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "ok"
        imageColumn.Image = My.Resources.ok
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_precios.Columns.Add(imageColumn)
        dg_precios.Columns.Item(imageColumn.Name).Width = 28
        dg_precios.Columns.Item(imageColumn.Name).ReadOnly = False



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_local"
        textoColumn.HeaderText = "id_presentacion"
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_precio"
        textoColumn.HeaderText = "id_presentacion"
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_prod_mae"
        textoColumn.HeaderText = "id_prod_mae"
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_presentacion"
        textoColumn.HeaderText = "id_presentacion"
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "costo_base_equiv"
        textoColumn.HeaderText = "costo_base_equiv"
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valor_precio_ant"
        textoColumn.HeaderText = "valor_precio_ant"
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Visible = False
        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valor_precio_orig"
        textoColumn.HeaderText = "valor_precio_orig"
        dg_precios.Columns.Add(textoColumn)
        dg_precios.Columns.Item(textoColumn.Name).Visible = False




    End Sub
    Private Sub Carga_pordefcto_listaPrecio()
        Dim Result As String
        CmdLocalLista.Text = lk_LocalActivo.abreviado.Trim & " - " & lk_LocalActivo.nombre.Trim
        CmdLocalLista.Tag = lk_LocalActivo.id_local

        Dim ListaPrecios() As DataRow = sql_Tipo_lista_precios.Select("id_local = " & lk_LocalActivo.id_local & "")
        If ListaPrecios.Length = 0 Then
            Result = MensajesBox.Show("Verificar en configuracion de local , NO HA DEFINIDO LISTA DE PRECIOS.",
                                     "LISTA DE PRECIOS.")
            Exit Sub
        End If
        CmdTipoLista.Text = ListaPrecios(0)("abreviado").ToString.Trim & " - " & ListaPrecios(0)("descripcion").ToString.Trim
        CmdTipoLista.Tag = ListaPrecios(0)("id_precio").ToString



        Dim LocalPorDefecto() As DataRow = lk_sql_Locales_Activos.Select("id_local = " & lk_LocalActivo.id_local & "")

        If LocalPorDefecto.Length = 0 Then
            Result = MensajesBox.Show("No cuenta con Local activo.",
                                     "Operación.")
            Me.Close()
            Exit Sub
        End If
        CmdLocalLista.Text = LocalPorDefecto(0)("nombre")
        CmdLocalLista.Tag = LocalPorDefecto(0)("id_local")
        CmdLocalLista.AccessibleName = LocalPorDefecto(0)("codigo")

    End Sub
    Private Sub Muestra_Precios(wid_prod_mae As Integer, wid_presentacion As Integer, wid_local As Integer, wid_listaprecio As Integer, wid_moneda As Integer, wequiv As Integer)
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim wfiltro_listapre As String = ""
        Dim wfiltro_local As String = ""

        If wid_listaprecio <> 0 Then
            wfiltro_listapre = " and id_precio = " & wid_listaprecio & " "
        End If
        If wid_local <> 0 Then
            wfiltro_local = " and id_local = " & wid_local & " "
        End If
        sql_cade = "select * from  [vw_lista_precios_producto]    where id_negocio = " & lk_NegocioActivo.id_Negocio & " and 
           id_moneda = " & wid_moneda & " and id_prod_mae = " & wid_prod_mae & " and 
           id_presentacion = " & wid_presentacion & " " & wfiltro_local & " " & wfiltro_listapre
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        sql_lista_precios = New DataTable
        adaptador.Fill(sql_lista_precios)

        ListaTipocosto("1", "COSTO BASE")

        dg_precios.Rows.Clear()

        For i = 0 To sql_lista_precios.Rows.Count - 1
            dg_precios.Rows.Add()
            'dg_precios.CurrentCell = Me.dg_precios.Rows(Me.dg_precios.Rows.Count - 1).Cells("num")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("local").Value = sql_lista_precios.Rows(i).Item("codigo").ToString.Trim & " " & sql_lista_precios.Rows(i).Item("nombreabreviado").ToString.Trim
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("modolista").Value = "MODO"
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("lista").Value = sql_lista_precios.Rows(i).Item("descripcion")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("abreviado").Value = sql_lista_precios.Rows(i).Item("abreviado")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("moneda").Value = sql_lista_precios.Rows(i).Item("simbolo")

            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("costo_base").Value = sql_lista_precios.Rows(i).Item("costo_base") * wequiv
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("costo_ult").Value = 0
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("costo_avg").Value = 0


            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("porcosto1").Value = sql_lista_precios.Rows(i).Item("margen_costo")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("precio").Value = sql_lista_precios.Rows(i).Item("valor_precio")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("porcosto2").Value = sql_lista_precios.Rows(i).Item("margen_costo_min")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("minimo").Value = sql_lista_precios.Rows(i).Item("valor_precio_min")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_precio").Value = sql_lista_precios.Rows(i).Item("id_precio")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_prod_mae").Value = sql_lista_precios.Rows(i).Item("id_prod_mae")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_local").Value = sql_lista_precios.Rows(i).Item("id_local")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_presentacion").Value = sql_lista_precios.Rows(i).Item("id_presentacion")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("costo_base_equiv").Value = wequiv
            ' para el control de cmbio de precio indicador
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("valor_precio_ant").Value = sql_lista_precios.Rows(i).Item("valor_precio_ant")
            dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("valor_precio_orig").Value = sql_lista_precios.Rows(i).Item("valor_precio")


            If sql_lista_precios.Rows(i).Item("estado") = 1 Then

                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("estado").Value = True
            Else
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("estado").Value = False
            End If
        Next

        ' Exit Sub

        Dim ListaTipoLista() As DataRow = sql_Tipo_lista_precios.Select("id_moneda = " & wid_moneda & " " & wfiltro_local & " " & wfiltro_listapre)
        If ListaTipoLista.Length = 0 Then
            Dim Result As String = MensajesBox.Show("Verificar en configuracion de local , NO HA DEFINIDO LISTA DE PRECIOS.",
                                     "LISTA DE PRECIOS.")
            Exit Sub
        End If



        'sql_cade = "select * from  [vw_Tipo_lista_precios]    where id_negocio = " & lk_NegocioActivo.id_Negocio & " and 
        '   id_moneda = " & wid_moneda & " " & wfiltro_local & " " & wfiltro_listapre
        'command = New SqlCommand(sql_cade, lk_connection_cuenta)
        'adaptador = New SqlDataAdapter(command)
        'Dim sql_tipo_lista As New DataTable
        'adaptador.Fill(sql_tipo_lista)
        Dim wbusid_precio As Integer
        Dim wbusid_local As Integer
        Dim wflag_add As Integer = 0
        'ListaTipoLista(0)("simbolo")

        For i = 0 To ListaTipoLista.Length - 1
            wflag_add = 1
            wbusid_precio = ListaTipoLista(i)("id_precio")
            wbusid_local = ListaTipoLista(i)("id_local")

            For j = 0 To dg_precios.Rows.Count - 1
                If (wbusid_precio = dg_precios.Rows(j).Cells("id_precio").Value) And (wbusid_local = dg_precios.Rows(j).Cells("id_local").Value) Then
                    wflag_add = 0
                    Exit For

                End If

            Next j
            If wflag_add = 1 Then
                dg_precios.Rows.Add()
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("local").Value = ListaTipoLista(i)("codigo") & " " & ListaTipoLista(i)("nombreabreviado")
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("modolista").Value = "MODO"
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("lista").Value = ListaTipoLista(i)("descripcion")
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("abreviado").Value = ListaTipoLista(i)("abreviado")
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("moneda").Value = ListaTipoLista(i)("simbolo")
                'dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("valorcosto").Value = 0
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("porcosto1").Value = 0
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("precio").Value = 0
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("porcosto2").Value = 0
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("minimo").Value = 0
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_precio").Value = ListaTipoLista(i)("id_precio")
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_prod_mae").Value = wid_prod_mae
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_local").Value = ListaTipoLista(i)("id_local")
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("estado").Value = True
                dg_precios.Rows(dg_precios.Rows.Count - 1).Cells("id_presentacion").Value = wid_presentacion
            End If
        Next i

        '  Contador_filas()
    End Sub

    Private Sub CmdLocalLista_Click(sender As Object, e As EventArgs) Handles CmdLocalLista.Click


        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub

        Dim ListaListaLocales() As DataRow = lk_sql_Locales_Activos.Select("id_local <> 0")
        ' Recorremos las filas filtradas
        If ListaListaLocales.Length = 0 Then
            Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        Dim itemTodos As New ToolStripMenuItem("(*) TODOS")
        menu.Items.Insert(0, itemTodos)

        ' Controlador de eventos para el elemento (*) todos
        AddHandler itemTodos.Click, Sub()
                                        ' Realizar la acción deseada al seleccionar (*) todos
                                        For Each item As ToolStripMenuItem In menu.Items
                                            ' Excluir el elemento (*) todos para que no se modifique
                                            If item IsNot itemTodos Then
                                                item.Checked = True
                                            End If
                                        Next

                                        ' Cambiar el texto del botón CmdLocalLista
                                        CmdLocalLista.Text = "(*) TODOS"
                                        CmdLocalLista.Tag = "0"
                                        If dg_grid.CurrentCell Is Nothing Then Exit Sub
                                        Dim wid_presentacion As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_presentacion").Value
                                        Dim wid_prod_mae As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_prod_mae").Value
                                        Dim wid_moneda As Integer = Val(CmdMoneda.Tag)
                                        Dim wid_local As Integer = Val(CmdLocalLista.Tag)
                                        Dim wid_listaprecio As Integer = Val(CmdTipoLista.Tag)
                                        Dim wequiv As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("equiv").Value
                                        Muestra_Precios(wid_prod_mae, wid_presentacion, wid_local, wid_listaprecio, wid_moneda, wequiv)
                                    End Sub
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaListaLocales
            Dim id As Integer = CInt(row("id_local"))
            Dim detalle As String = CStr(row("codigo") & " " & row("nombre"))
            Dim descrip As String = CStr(row("nombre"))
            Dim codigo As String = CStr(row("codigo"))
            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarLocalActivo(id, detalle, descrip, codigo)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdLocalLista, New Point(0, CmdLocalLista.Height))
    End Sub
    Private Sub MostrarLocalActivo(id As String, detalle As String, descrip As String, codigo As String)
        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        CmdLocalLista.Text = codigo & " - " & descrip
        CmdLocalLista.Tag = id


        'Try
        If dg_grid.CurrentCell Is Nothing Then Exit Sub
        Dim wid_presentacion As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_presentacion").Value
        Dim wid_prod_mae As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_prod_mae").Value
        Dim wid_moneda As Integer = Val(CmdMoneda.Tag)
        Dim wid_local As Integer = Val(CmdLocalLista.Tag)
        Dim wid_listaprecio As Integer = Val(CmdTipoLista.Tag)
        Dim wequiv As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("equiv").Value
        Muestra_Precios(wid_prod_mae, wid_presentacion, wid_local, wid_listaprecio, wid_moneda, wequiv)



    End Sub

    Private Sub CmdTipoLista_Click(sender As Object, e As EventArgs) Handles CmdTipoLista.Click





        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub

        Dim ListaPrecios() As DataRow = sql_Tipo_lista_precios.Select("id_local <> 0 ")
        If ListaPrecios.Length = 0 Then
            Result = MensajesBox.Show("Verificar en configuracion de local , NO HA DEFINIDO LISTA DE PRECIOS.",
                                     "LISTA DE PRECIOS.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White

        Dim itemTodos As New ToolStripMenuItem("(*) TODOS")
        menu.Items.Insert(0, itemTodos)

        ' Controlador de eventos para el elemento (*) todos
        AddHandler itemTodos.Click, Sub()
                                        ' Realizar la acción deseada al seleccionar (*) todos
                                        For Each item As ToolStripMenuItem In menu.Items
                                            ' Excluir el elemento (*) todos para que no se modifique
                                            If item IsNot itemTodos Then
                                                item.Checked = True
                                            End If
                                        Next

                                        ' Cambiar el texto del botón CmdLocalLista
                                        CmdTipoLista.Text = "(*) TODOS"
                                        CmdTipoLista.Tag = "0"
                                        If dg_grid.CurrentCell Is Nothing Then Exit Sub
                                        Dim wid_presentacion As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_presentacion").Value
                                        Dim wid_prod_mae As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_prod_mae").Value
                                        Dim wid_moneda As Integer = Val(CmdMoneda.Tag)
                                        Dim wid_local As Integer = Val(CmdLocalLista.Tag)
                                        Dim wid_listaprecio As Integer = Val(CmdTipoLista.Tag)
                                        Dim wequiv As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("equiv").Value
                                        Muestra_Precios(wid_prod_mae, wid_presentacion, wid_local, wid_listaprecio, wid_moneda, wequiv)


                                    End Sub
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaPrecios
            Dim id As Integer = CInt(row("id_precio"))
            Dim detalle As String = CStr(row("abreviado") & " " & row("descripcion"))
            Dim descrip As String = CStr(row("descripcion"))
            Dim codigo As String = CStr(row("abreviado"))
            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       MostrarTipoPrecio(id, detalle, descrip, codigo)
                                   End Sub
            menu.Items.Add(item)
        Next


        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdTipoLista, New Point(0, CmdTipoLista.Height))


    End Sub
    Private Sub MostrarTipoPrecio(id As String, detalle As String, descrip As String, codigo As String)


        'Aquí puedes reemplazar con tu código para realizar la acción correspondiente
        CmdTipoLista.Text = codigo & " - " & descrip
        CmdTipoLista.Tag = id
        If dg_grid.CurrentCell Is Nothing Then Exit Sub
        Dim wid_presentacion As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_presentacion").Value
        Dim wid_prod_mae As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("id_prod_mae").Value
        Dim wid_moneda As Integer = Val(CmdMoneda.Tag)
        Dim wid_local As Integer = Val(CmdLocalLista.Tag)
        Dim wid_listaprecio As Integer = Val(CmdTipoLista.Tag)
        Dim wequiv As Integer = dg_grid.Rows(dg_grid.CurrentCell.RowIndex).Cells("equiv").Value

        Muestra_Precios(wid_prod_mae, wid_presentacion, wid_local, wid_listaprecio, wid_moneda, wequiv)




    End Sub
    Private Function ValidaDatosProducto() As Boolean
        ValidaDatosProducto = True
        Dim wes_pordefecto As Integer = 0
        Dim wes_minimo As Integer = 0
        Dim wes_blister As Integer = 0
        Dim wes_presen As Integer = 0
        ' valida tener mini una presentacion por dfefecto
        For i = 0 To dg_grid.Rows.Count - 1
            ' validar solo si el producto esta creado 
            If CmdGrabar.Tag = "UPDATE" Then
                If Val(dg_grid.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For
            End If
            If dg_grid.Rows(i).Cells("defecto").Value Then
                wes_pordefecto = 1
            End If
            If dg_grid.Rows(i).Cells("minimo").Value Then
                wes_minimo = 1
            End If
            If dg_grid.Rows(i).Cells("blister").Value Then
                wes_blister = 1
            End If
            If dg_grid.Rows(i).Cells("id_presentacion").Value = 0 Then wes_presen = 1
        Next i

        If wes_pordefecto = 0 Then
            Dim result = MensajesBox.Show("Debe Asignar una presentacióon por defecto.", lk_cabeza_msgbox)
            ValidaDatosProducto = False
            Exit Function
        End If
        If wes_minimo = 0 Then
            Dim result = MensajesBox.Show("Debe Asignar una presentacióon para los minimos.", lk_cabeza_msgbox)
            ValidaDatosProducto = False
            Exit Function
        End If
        If wes_blister = 0 Then
            Dim result = MensajesBox.Show("Debe Asignar que Blister por defecto.", lk_cabeza_msgbox)
            ValidaDatosProducto = False
            Exit Function
        End If
        If wes_presen = 1 Then
            Dim result = MensajesBox.Show("Existe Una Presentacion Incompleta Verificar .", lk_cabeza_msgbox)
            ValidaDatosProducto = False
            Exit Function
        End If
        If ListTipo10.Items.Count = 0 Then
            Dim result = MensajesBox.Show("Debe Selecionrar : " & LblTipo10.Text.Trim & ".", lk_cabeza_msgbox)
            ValidaDatosProducto = False
            Exit Function
        End If
        If ListTipo10.Items.Count = 0 Then
            Dim result = MensajesBox.Show("Debe Selecionrar : " & LblTipo20.Text.Trim & ".", lk_cabeza_msgbox)
            ValidaDatosProducto = False
            Exit Function
        End If
        If ListTipo10.Items.Count = 0 Then
            Dim result = MensajesBox.Show("Debe Selecionrar : " & LblTipo30.Text.Trim & ".", lk_cabeza_msgbox)
            ValidaDatosProducto = False
            Exit Function
        End If
    End Function

    Private Sub Actualiza_Presentaciones()
        Dim werror As String = String.Empty
        Dim Wresultado As String = String.Empty
        Dim wreg_sec_numint As Integer = 0
        Dim wreg_sec_numcomp As Integer = 0

        local_dt_pres.Rows.Clear()



        Dim wid_negocio As Integer
        Dim wid_presentacion As Integer
        Dim wid_prod_mae As Integer
        Dim wes_pordefecto As Integer
        Dim wes_minimo As Integer
        Dim wes_blister As Integer

        Dim wnombre As String = ""
        Dim wcbarra As String = ""
        Dim wcodigo As String = ""
        Dim wes_control_lote As Integer = 0
        Dim wdiasalerta_lote As Integer = 0
        Dim wdiasprevios_lote As Integer = 0
        Dim wes_inventariable As Integer = 0
        Dim wes_exonerado As Integer = 0
        Dim wref As String = ""
        Dim westado As Integer = 0

        wnombre = txt_nombre.Text.Trim
        wcbarra = txt_cbarra.Text.Trim
        wcodigo = txt_codigo.Text.Trim
        If Check_es_controllotes.Checked Then
            wes_control_lote = 1
        Else
            wes_control_lote = 0
        End If

        wdiasalerta_lote = Val(txt_diasalerta_lote.Text)
        wdiasprevios_lote = Val(txt_diasprevios_lote.Text)
        If Check_es_inventariable.Checked Then
            wes_inventariable = 1
        Else
            wes_inventariable = 0
        End If

        If Check_exonerado.Checked Then
            wes_exonerado = 1
        Else
            wes_exonerado = 0
        End If

        wref = txt_ref.Text.Trim
        westado = Val(lblEstado.Tag)

        For i = 0 To dg_grid.Rows.Count - 1
            If CmdGrabar.Tag = "UPDATE" Then
                If Val(dg_grid.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For
            End If
            wid_negocio = lk_NegocioActivo.id_Negocio
            wid_presentacion = dg_grid.Rows(i).Cells("id_presentacion").Value
            wid_prod_mae = dg_grid.Rows(i).Cells("id_prod_mae").Value

            If dg_grid.Rows(i).Cells("defecto").Value Then
                wes_pordefecto = 1
            Else
                wes_pordefecto = 0
            End If
            If dg_grid.Rows(i).Cells("minimo").Value Then
                wes_minimo = 1
            Else
                wes_minimo = 0
            End If
            If dg_grid.Rows(i).Cells("blister").Value Then
                wes_blister = 1
            Else
                wes_blister = 0
            End If

            local_dt_pres.Rows.Add(wid_negocio, wid_presentacion, wid_prod_mae, wes_pordefecto, wes_minimo, wes_blister)
        Next i
        Dim wid_tipo_prod As Integer = 0
        Dim wid_tbp_estru_id As Integer = 0
        Dim wid_prod As Double = 0
        Dim wid_tbp_id As Integer = 0
        Dim ws_id_tipo_prod As Integer
        If Radio_Med.Checked = True Then  ' 1 = Medicamento  , 2 ¨= servicio , 3 = Otros productos 
            ws_id_tipo_prod = 1
        ElseIf Radio_Serv.Checked = True Then
            ws_id_tipo_prod = 2
        ElseIf Radio_Otros.Checked = True Then
            ws_id_tipo_prod = 3
        End If
        local_dt_ListaGrupos.Clear()
        wid_prod = txt_id_prod_master.Text
        llena_registroGrupo(ListTipo10, wid_prod, 10, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo20, wid_prod, 20, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo30, wid_prod, 30, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo40, wid_prod, 40, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo50, wid_prod, 50, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo60, wid_prod, 60, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo70, wid_prod, 70, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo80, wid_prod, 80, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo90, wid_prod, 90, ws_id_tipo_prod)
        llena_registroGrupo(ListTipo100, wid_prod, 100, ws_id_tipo_prod)

        ' MsgBox(local_dt_ListaGrupos.Rows.Count)


        Dim ws_modo As Integer = 0
        If CmdGrabar.Tag = "CREA" Then
            ws_modo = 1
        Else
            ws_modo = 0
            If wid_prod_mae = 0 Then
                MsgBox("sin productos activo no grbaa")
                Exit Sub
            End If
        End If



        Using cmd As New SqlCommand("sp_actualiza_producto", lk_connection_cuenta)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()
            ' Agrega los parámetros de entrada
            cmd.Parameters.AddWithValue("@modo", ws_modo)
            cmd.Parameters.AddWithValue("@tipo_prod", ws_id_tipo_prod)
            cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
            cmd.Parameters.AddWithValue("@id_prod_mae", wid_prod_mae)
            cmd.Parameters.AddWithValue("@nombre", wnombre)
            cmd.Parameters.AddWithValue("@cbarra", wcbarra)
            cmd.Parameters.AddWithValue("@codigo", wcodigo)
            cmd.Parameters.AddWithValue("@es_control_lote", wes_control_lote)
            cmd.Parameters.AddWithValue("@diasalerta_lote", wdiasalerta_lote)
            cmd.Parameters.AddWithValue("@diasprevios_lote", wdiasprevios_lote)
            cmd.Parameters.AddWithValue("@es_inventariable", wes_inventariable)
            cmd.Parameters.AddWithValue("@es_exonerado", wes_exonerado)
            cmd.Parameters.AddWithValue("@ref", wref)
            cmd.Parameters.AddWithValue("@estado", westado)



            ' Agrega el parámetro de tabla temporal de detalle
            Dim detallePres As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalPres", local_dt_pres)
            Dim DetalleGrupo As SqlParameter = cmd.Parameters.AddWithValue("@TablaListaGrupos", local_dt_ListaGrupos)

            'Dim resultado As String = String.Empty
            cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numint", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numcomp", SqlDbType.Int, 10).Direction = ParameterDirection.Output


            detallePres.SqlDbType = SqlDbType.Structured
            detallePres.TypeName = "dbo.Tipo_producto_unidad"




            ' Ejecuta el comando
            'Try
            cmd.ExecuteNonQuery()
            Wresultado = DirectCast(cmd.Parameters("@Resultado").Value, String)
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
            'MsgBox("REGISTRO GRABADO:" & Wresultado)
            '  SMS_Barra("REGISTRO GRABADO CON EXITO : " & Wresultado, 1)
            ' Datos despuestde ede la grabacion Muestra COmprobantes Grabados

            'TxtComp_Numero.Text = Format(wreg_sec_numcomp, "00000000")
            'TxtNumDocOper.Text = Format(wreg_sec_numint, "00000000")
            'CancelaOper("GRABAR")
            'If CmdOperacion.AccessibleDescription <> "" Then 'Primera Ubiacion 
            '    SaltoBox(CmdOperacion.AccessibleDescription)
            'End If
            Dim wid_prod_mae_creado As Integer = Val(Wresultado)


            If CmdGrabar.Tag = "CREA" Then
                Actualiza_Precios(1, wid_prod_mae_creado)
            End If
        End If
    End Sub
    Private Sub llena_registroGrupo(listag As ListBox, wid_prod As Integer, wid_tbp_estru_id As Integer, wid_tipo_prod As Integer)

        Dim wid_tbp_id As Integer
        For i = 0 To listag.Items.Count - 1
            wid_tbp_id = Val(Trim(Strings.Right(listag.Items(i).ToString, 10)))
            local_dt_ListaGrupos.Rows.Add(wid_tipo_prod, wid_tbp_estru_id, wid_prod, wid_tbp_id)
        Next i

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Actualiza_Precios(wModo As Integer, wid_prod_mae_creado As Integer)
        Dim werror As String = String.Empty
        Dim Wresultado As String = String.Empty
        Dim wreg_sec_numint As Integer = 0
        Dim wreg_sec_numcomp As Integer = 0

        local_dt_precios.Rows.Clear()
        Dim wid_negocio As Integer = 0
        Dim wid_precio As Integer = 0
        Dim wid_prod_mae As Integer = 0
        Dim wid_presentacion As Integer = 0

        Dim wvalor_precio As Double = 0
        Dim wvalor_precio_min As Double = 0
        Dim wmargen_costo As Double = 0
        Dim wmargen_costo_min As Double = 0
        Dim westado As Integer = 0

        Dim wid_local As Integer = 0
        Dim wcosto_base As Double = 0
        Dim wcosto_base_equiv As Integer = 0

        Dim wvalor_precio_ant As Double = 0
        Dim wvalor_precio_orig As Double = 0
        Dim fecha_update As DateTime = Now


        'valor_precio_ant
        'fecha_update



        For i = 0 To dg_precios.Rows.Count - 1
            If wModo = 1 Then ' creacion de producto
                wid_prod_mae = wid_prod_mae_creado
            Else
                If Val(dg_precios.Rows(i).Cells("id_prod_mae").Value) = 0 Then Continue For
                wid_prod_mae = dg_precios.Rows(i).Cells("id_prod_mae").Value
            End If


            wid_negocio = lk_NegocioActivo.id_Negocio
            wid_precio = dg_precios.Rows(i).Cells("id_precio").Value

            wid_presentacion = dg_precios.Rows(i).Cells("id_presentacion").Value
            wvalor_precio = dg_precios.Rows(i).Cells("precio").Value
            wvalor_precio_min = dg_precios.Rows(i).Cells("minimo").Value
            wmargen_costo = dg_precios.Rows(i).Cells("porcosto1").Value
            wmargen_costo_min = dg_precios.Rows(i).Cells("porcosto2").Value
            wid_local = dg_precios.Rows(i).Cells("id_local").Value
            wcosto_base = dg_precios.Rows(i).Cells("costo_base").Value
            wcosto_base_equiv = dg_precios.Rows(i).Cells("costo_base_equiv").Value
            wvalor_precio_ant = dg_precios.Rows(i).Cells("valor_precio_ant").Value
            wvalor_precio_orig = dg_precios.Rows(i).Cells("valor_precio_orig").Value
            If wvalor_precio_orig = wvalor_precio Then
                wvalor_precio_ant = wvalor_precio_orig
            Else
                wvalor_precio_ant = wvalor_precio
            End If

            If dg_precios.Rows(i).Cells("estado").Value Then
                westado = 1
            Else
                westado = 0
            End If
            local_dt_precios.Rows.Add(wid_negocio, wid_precio, wid_prod_mae, wid_presentacion, wvalor_precio, wvalor_precio_min, wmargen_costo, wmargen_costo_min, westado, wid_local, wcosto_base, wcosto_base_equiv, wvalor_precio_ant)
        Next i
        If wModo <> 1 Then ' creacion de producto
            If wid_prod_mae = 0 Then
                MsgBox("sin productos activo no grbaa")
                Exit Sub
            End If
        End If
        Using cmd As New SqlCommand("sp_actualiza_producto_precio", lk_connection_cuenta)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()

            ' Agrega los parámetros de entrada
            cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
            cmd.Parameters.AddWithValue("@id_prod_mae", wid_prod_mae)

            ' Agrega el parámetro de tabla temporal de detalle
            Dim detallePrecios As SqlParameter = cmd.Parameters.AddWithValue("@TablaTemporalPrecios", local_dt_precios)

            'Dim resultado As String = String.Empty
            cmd.Parameters.Add("@Resultado", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numint", SqlDbType.Int, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@reg_sec_numcomp", SqlDbType.Int, 10).Direction = ParameterDirection.Output


            detallePrecios.SqlDbType = SqlDbType.Structured
            ' detallePrecios.TypeName = "dbo.Tipo_producto_precio_e2"




            ' Ejecuta el comando
            'Try
            cmd.ExecuteNonQuery()
            'Wresultado = DirectCast(cmd.Parameters("@Resultado").Value, String)
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
            'MsgBox("REGISTRO GRABADO:" & Wresultado)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmdGrabar_Click(sender As Object, e As EventArgs) Handles CmdGrabar.Click
        If ValidaDatosProducto() = False Then Exit Sub
        Actualiza_Presentaciones()
        PanelProductos.Visible = False
        PanelCentro.Visible = True
        PanelCentro.Dock = DockStyle.Fill
        PanelProductos.Dock = DockStyle.None
        TxtBuscar.Select()
    End Sub

    Private Sub CmdCancelarOper_Click(sender As Object, e As EventArgs) Handles CmdCancelarOper.Click
        CmdRegresa_Click(Nothing, Nothing)
    End Sub

    Private Sub CmdGrabaPrecios_Click(sender As Object, e As EventArgs) Handles CmdGrabaPrecios.Click
        Actualiza_Precios(0, 0)

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

    Private Sub CmdMoneda_Click(sender As Object, e As EventArgs) Handles CmdMoneda.Click

    End Sub

    Private Sub CmdTipoCosto_Click(sender As Object, e As EventArgs) Handles CmdTipoCosto.Click


        Dim codigos() As String = {"1", "2", "3"}
        Dim nombres() As String = {"COSTO BASE", "COSTO ULTIM.", "COSTO PROMD."}

        Dim menu As New ContextMenuStrip()
        menu.BackColor = PanelSup.BackColor
        menu.ForeColor = Color.White

        For i As Integer = 0 To codigos.Length - 1
            Dim codigo As String = codigos(i)
            Dim nombre As String = nombres(i)

            Dim item As New ToolStripMenuItem(nombre)
            item.Tag = codigo ' Puedes asignar el código como valor de la propiedad Tag del elemento de menú

            ' Agregar un controlador de eventos para el evento Click del elemento de menú
            AddHandler item.Click, Sub()
                                       ' Acción a realizar cuando se hace clic en el elemento de menú
                                       'Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
                                       '     Dim selectedCodigo As String = menuItem.Tag.ToString()

                                       ' Llamar al procedimiento con los parámetros
                                       ListaTipocosto(codigo, nombre)
                                   End Sub



            menu.Items.Add(item)
        Next
        menu.Show(CmdTipoCosto, New Point(0, CmdTipoCosto.Height))

    End Sub
    Private Sub ListaTipocosto(wcodigo As String, wdetalle As String)
        ' Dim nombres() As String = {"COSTO BASE", "COSTO ULTIM.", "COSTO PROMD."}
        CmdTipoCosto.Text = wdetalle.Trim
        CmdTipoCosto.Tag = wcodigo.Trim
        dg_precios.Columns.Item("costo_base").Visible = False
        dg_precios.Columns.Item("costo_ult").Visible = False
        dg_precios.Columns.Item("costo_avg").Visible = False
        If wcodigo = "1" Then
            dg_precios.Columns.Item("costo_base").Visible = True
        ElseIf wcodigo = "2" Then
            dg_precios.Columns.Item("costo_ult").Visible = True
        ElseIf wcodigo = "3" Then
            dg_precios.Columns.Item("costo_avg").Visible = True
        End If

    End Sub

    Private Sub CmbPres_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPres.SelectedIndexChanged

    End Sub

    Private Sub GridStock_Inicia()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()

        Dim wes_control_lote As Integer = 0
        Dim wpor_impt As Double = 18





        gridstock.Refresh()

        gridstock.Columns.Clear()



        gridstock.DefaultCellStyle.Font = New Font("Segoe UI", 9.25)




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "A"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        gridstock.Columns.Add(textoColumn)
        gridstock.Columns.Item(textoColumn.Name).Width = 70
        gridstock.Columns.Item(textoColumn.Name).ReadOnly = True
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "almacen"
        textoColumn.Tag = "A"
        textoColumn.HeaderText = "ALMA"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        gridstock.Columns.Add(textoColumn)
        gridstock.Columns.Item(textoColumn.Name).Width = 70
        gridstock.Columns.Item(textoColumn.Name).ReadOnly = True
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alineación hacia la derecha

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "unidad"
        textoColumn.Tag = "E2"
        textoColumn.HeaderText = "UND"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        gridstock.Columns.Add(textoColumn)
        gridstock.Columns.Item(textoColumn.Name).Width = 40
        gridstock.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "stock"
        textoColumn.Tag = "E2"
        textoColumn.HeaderText = "STOCK"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        gridstock.Columns.Add(textoColumn)
        gridstock.Columns.Item(textoColumn.Name).Width = 40
        gridstock.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha


        'textoColumn.DefaultCellStyle.Format = "00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Integer) ' Tipo de valor de la celda

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "stock_mae"
        textoColumn.HeaderText = "stock_mae"
        gridstock.Columns.Add(textoColumn)
        gridstock.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "equiv"
        textoColumn.HeaderText = "equiv"
        gridstock.Columns.Add(textoColumn)
        gridstock.Columns.Item(textoColumn.Name).Visible = False



    End Sub

    Private Sub Cmd_add10_Click(sender As Object, e As EventArgs) Handles Cmd_add10.Click
        Muestra_ItemGrupos(ListTipo10, LblTipo10, Val(txt_idproducto.Text))
    End Sub
    Private Sub Muestra_ItemGrupos(ws_ListaItem As ListBox, ws_TxtEtiqueta As Label, ws_IdProd As Integer)
        Dim frBuscar As New FrmGruposProd
        Dim ws_ID_ITEM_GRUPO As Integer = 0
        Dim ws_ID_DESCRI_GRUPO As String = ""
        frBuscar.LblEtiqueta.Text = Trim(ws_TxtEtiqueta.Text)
        frBuscar.LblEtiqueta.Tag = Trim(ws_TxtEtiqueta.Tag)
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds

        'frBuscar.Left = (Me.Left) + 220
        'frBuscar.Top = (Me.Top) + 120
        frBuscar.CODIGO_GRUPO = frBuscar.LblEtiqueta.Tag
        frBuscar.ID_PROD = ws_IdProd
        frBuscar.ID_ITEM_GRUPO = 0
        frBuscar.ID_DESCRIP_GRUPO = ""

        'frBuscar.ShowDialog()

        If frBuscar.ShowDialog() = DialogResult.OK Then
            ws_ID_ITEM_GRUPO = Val(frBuscar.ID_ITEM_GRUPO)
            ws_ID_DESCRI_GRUPO = frBuscar.ID_DESCRIP_GRUPO
            Dim wflag_add As Integer = 0
            For i = 0 To ws_ListaItem.Items.Count - 1
                If Trim(Strings.Right(ws_ListaItem.Items(i).ToString, 10)) = ws_ID_ITEM_GRUPO Then
                    wflag_add = 1
                    Exit For
                End If
            Next i
            If wflag_add = 1 Then
                Dim result = MensajesBox.Show("Existe en la Lista , verifciar.", lk_cabeza_msgbox)
            Else

                ws_ListaItem.Items.Add(ws_ID_DESCRI_GRUPO & Space(100) & ws_ID_ITEM_GRUPO)
            End If
        End If



    End Sub

    Private Sub Quitar_ItemGrupos(ws_ListaItem As ListBox, ws_fila As Integer)

        If ws_fila < 0 Then
            Dim resultms = MensajesBox.Show("Debe Seleccionar de la lista ", lk_cabeza_msgbox)
            Exit Sub
        End If
        Dim ws_ID_ITEM_GRUPO As Integer = 0
        Dim ws_ID_DESCRI_GRUPO As String = ""
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds

        'frBuscar.Left = (Me.Left) + 220

        Dim wflag_add As Integer = 0
        If ws_ListaItem.Items(ws_fila) Is Nothing Then Exit Sub

        Dim wdescriquitar As String = ws_ListaItem.Items(ws_fila).ToString()

        Dim Result = MensajesBox.Show("Confirmar Si desea Quitar el Registro :, continuar?" & vbCrLf & wdescriquitar, "Quitar de la lista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If Result = "7" Or Result = "2" Then ' es NO
        Else
            ws_ListaItem.Items.RemoveAt(ws_fila)
        End If






    End Sub

    Private Sub Cmd_Quitar10_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar10.Click
        Quitar_ItemGrupos(ListTipo10, ListTipo10.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar20_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar20.Click
        Quitar_ItemGrupos(ListTipo20, ListTipo20.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar30_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar30.Click
        Quitar_ItemGrupos(ListTipo30, ListTipo30.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar40_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar40.Click
        Quitar_ItemGrupos(ListTipo40, ListTipo40.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar50_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar50.Click
        Quitar_ItemGrupos(ListTipo50, ListTipo50.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar60_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar60.Click
        Quitar_ItemGrupos(ListTipo60, ListTipo60.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar70_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar70.Click
        Quitar_ItemGrupos(ListTipo70, ListTipo70.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar80_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar80.Click
        Quitar_ItemGrupos(ListTipo80, ListTipo80.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar90_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar90.Click
        Quitar_ItemGrupos(ListTipo90, ListTipo90.SelectedIndex)
    End Sub

    Private Sub Cmd_Quitar100_Click(sender As Object, e As EventArgs) Handles Cmd_Quitar100.Click
        Quitar_ItemGrupos(ListTipo100, ListTipo100.SelectedIndex)
    End Sub

    Private Sub Cmd_add20_Click(sender As Object, e As EventArgs) Handles Cmd_add20.Click
        Muestra_ItemGrupos(ListTipo20, LblTipo20, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add30_Click(sender As Object, e As EventArgs) Handles Cmd_add30.Click
        Muestra_ItemGrupos(ListTipo30, LblTipo30, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add40_Click(sender As Object, e As EventArgs) Handles Cmd_add40.Click
        Muestra_ItemGrupos(ListTipo40, LblTipo40, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add50_Click(sender As Object, e As EventArgs) Handles Cmd_add50.Click
        Muestra_ItemGrupos(ListTipo50, LblTipo50, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add60_Click(sender As Object, e As EventArgs) Handles Cmd_add60.Click
        Muestra_ItemGrupos(ListTipo60, LblTipo60, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add70_Click(sender As Object, e As EventArgs) Handles Cmd_add70.Click
        Muestra_ItemGrupos(ListTipo70, LblTipo70, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add80_Click(sender As Object, e As EventArgs) Handles Cmd_add80.Click
        Muestra_ItemGrupos(ListTipo80, LblTipo80, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add90_Click(sender As Object, e As EventArgs) Handles Cmd_add90.Click
        Muestra_ItemGrupos(ListTipo90, LblTipo90, Val(txt_idproducto.Text))
    End Sub

    Private Sub Cmd_add100_Click(sender As Object, e As EventArgs) Handles Cmd_add100.Click
        Muestra_ItemGrupos(ListTipo100, LblTipo100, Val(txt_idproducto.Text))
    End Sub

    Private Sub CmdCrear_Click(sender As Object, e As EventArgs) Handles CmdCrear.Click
        NuevoProducto()
    End Sub

    Private Sub Radio_Med_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_Med.CheckedChanged
        If Radio_Med.Checked Then
            Check_es_inventariable.Checked = True
            Check_es_controllotes.Checked = True
        End If
    End Sub

    Private Sub Radio_Otros_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_Otros.CheckedChanged
        If Radio_Otros.Checked Then
            Check_es_inventariable.Checked = True
            Check_es_controllotes.Checked = False
        End If

    End Sub

    Private Sub Radio_Serv_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_Serv.CheckedChanged
        If Radio_Serv.Checked Then
            Check_es_inventariable.Checked = False
            Check_es_controllotes.Checked = False
        End If
    End Sub

    Private Sub CmdCodigoProd_Click(sender As Object, e As EventArgs) Handles CmdCodigoProd.Click
        LblBuscarpor.Text = Trim(Strings.Left(CmdCodigoProd.Text, 50))
        LblBuscarpor.Tag = Trim(Strings.Right(CmdCodigoProd.Tag, 50))
        TxtBuscar.Text = ""
        TxtBuscar.Focus()

    End Sub

    Private Sub CmdNombreP_Click(sender As Object, e As EventArgs) Handles CmdNombreP.Click
        LblBuscarpor.Text = "DESCRIPCION"
        LblBuscarpor.Tag = ""
        TxtBuscar.Text = ""
        TxtBuscar.Focus()
    End Sub
End Class