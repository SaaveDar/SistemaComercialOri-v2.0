Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmGestionar
    Dim MostrarSelloAgua_kardex As Boolean = True
    Dim dt_DatosConsulta_SN As New DataTable
    Dim sql_Indicadores As New DataTable
    Dim Random As New Random()
    Dim DT_Matrix_KPIs As New DataTable

    Private Sub FrmGestionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '============= PRUEBA PARA FORMALURO DE OPERACIONES ================================

        ''  CERRAR_SESIONES()
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
        'Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        'Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        'Me.ClientSize = New System.Drawing.Size(256, 400)
        'Me.MinimumSize = New System.Drawing.Size(800, 700)

        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim parametro As New SqlParameter


        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea




        Me.MaximumSize = New Size(1500, 900) ' Establece el tamaño máximo a 800x600
        Me.MinimumSize = New Size(800, 600) ' Establece el tamaño mínimo a 400x300





        command = New SqlCommand("SELECT * FROM  tablas_basicas where id_tipotabla = 100 and estado = 1 order by id_tb", lk_connection_master)
        adapter = New SqlDataAdapter(command)
        sql_Indicadores = New DataTable
        adapter.Fill(sql_Indicadores)

        Me.Centrar()
        PanelListarOper.Width = 160
        CmdContraerMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft
        CmdContraerMenu.Tag = 1
        CmdContraerMenu.ImageAlign = ContentAlignment.MiddleRight
        SN_Cabecera_resumen()


        Dim tooltip As New ToolTip()
        tooltip.SetToolTip(CmdVxA, "Indicador de Precio Promedio al que vendemos.")
        tooltip.SetToolTip(CmdVxF, "Indicador: Dinero en promedio por cada Comprobante Emitido.")
        tooltip.SetToolTip(CmdAxF, "Indicador: Capacidad de influencia sobre el Cliente.")
        tooltip.SetToolTip(CmdVxM2, "Indicador: Ventas Promedio por M2 (Desempeño entre tiendas).")
    End Sub


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
        Me.BringToFront()
        If PanelInventario.Visible Then Me.Text = "KARDEX"
        If PanelSN.Visible Then Me.Text = "SN-SALDOS"


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
        CmdInventarios_Click(Nothing, Nothing)
    End Sub

    Private Sub CmdBuscaSN_Click(sender As Object, e As EventArgs) Handles CmdBuscaSN.Click
        Dim btn As New Button()
        Dim btnQuitar As New Button()
        Dim textB As String
        TxtSN.Tag = Val(TxtSN.Tag) + 1
        If TxtSN.Text = "" Then Exit Sub
        For i = 0 To FlowSN.Controls.Count - 1
            If FlowSN.Controls.Item(i).Tag = TxtSN.Tag Then
                Exit Sub
            End If
        Next

        'IconButton1.Tag = ComboBox4.SelectedIndex
        With btn
            .Tag = TxtSN.Tag
            .Name = TxtSN.Tag ' IconButton1.Tag
            Me.ToolTipBotones.SetToolTip(btn, TxtSN.Text)
            textB = Strings.Left(TxtSN.Text, 10)
            .Text = textB
            .FlatStyle = FlatStyle.Flat
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.TopLeft
            .Font = New Font(New FontFamily("Microsoft Sans Serif"), 7)
            .Width = 85
        End With
        With btnQuitar
            .Tag = TxtSN.Tag
            .Name = TxtSN.Tag
            Me.ToolTipBotones.SetToolTip(btn, TxtSN.Text)
            textB = "X"
            .Text = textB
            .FlatStyle = FlatStyle.Flat
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.TopCenter
            .Font = New Font(New FontFamily("Microsoft Sans Serif"), 9)
            .Width = 15
        End With

        AddHandler btnQuitar.Click, AddressOf ButtonSN_Click   ' Asocias el evento al método Button_Click

        FlowSN.Controls.Add(btn)  ' Agregas el botón al formulario.
        FlowSN.Controls.Add(btnQuitar)  ' Agregas el botón al formulario.
    End Sub
    Private Sub ButtonSN_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim c As Control

        For Each c In FlowSN.Controls
            If c.Tag = CType(sender, System.Windows.Forms.Button).Tag Then
                FlowSN.Controls.Remove(c)
                Exit For
            End If
        Next
        For Each c In FlowSN.Controls
            If c.Tag = CType(sender, System.Windows.Forms.Button).Tag Then
                FlowSN.Controls.Remove(c)
                Exit For
            End If
        Next


    End Sub

    Private Sub CheckLocales_CheckedChanged(sender As Object, e As EventArgs) Handles CheckLocales.CheckedChanged
        If CheckLocales.Checked Then
            PanelF1.Height = 100
        Else
            PanelF1.Height = 20
        End If

    End Sub

    Private Sub CheckSN_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSN.CheckedChanged
        If CheckSN.Checked Then
            PanelF2.Height = 140
        Else
            PanelF2.Height = 20
        End If
    End Sub

    Private Sub CheckOper_CheckedChanged(sender As Object, e As EventArgs) Handles CheckOper.CheckedChanged
        If CheckOper.Checked Then
            PanelF3.Height = 140
        Else
            PanelF3.Height = 20
        End If
    End Sub

    Private Sub Checkfechas_CheckedChanged(sender As Object, e As EventArgs) Handles Checkfechas.CheckedChanged
        If Checkfechas.Checked Then
            PanelF4.Height = 140
        Else
            PanelF4.Height = 20
        End If
    End Sub

    Private Sub CheckEstadoComp_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEstadoComp.CheckedChanged
        If CheckEstadoComp.Checked Then
            PanelF5.Height = 140
        Else
            PanelF5.Height = 20
        End If
    End Sub

    Private Sub CmdSocioNeg_Click(sender As Object, e As EventArgs) Handles CmdSocioNeg.Click
        PanelInventario.Visible = False
        PanelEnLinea.Visible = False
        PanelSN.Visible = True
        PanelSN.Dock = DockStyle.Fill

        SN_Cabecera_resumen()
        SN_Cabecera_detalle()
        SN_Cabecera_Finanzas()
    End Sub

    Private Sub LblSocioNeg_Click(sender As Object, e As EventArgs) Handles LblSocioNeg.Click
        CmdSocioNeg_Click(Nothing, Nothing)
    End Sub

    Private Sub CmdMuestraFiltro_Click(sender As Object, e As EventArgs) Handles CmdMuestraFiltro.Click
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim wcade_filtro_oper As String = ""
        Dim wfiltro_sn As String
        wfiltro_sn = ""
        If CheckSN.Checked Then ' CASILLA ACTIVA PARA FILTRAR POR SOCIO DE NEGOCIO
            For Each ctrl As Control In FlowSN.Controls
                If TypeOf ctrl Is Button Then
                    Dim btn As Button = DirectCast(ctrl, Button)
                    If Val(btn.Tag) <> 0 And btn.Text.ToString.Trim <> "X" Then
                        wfiltro_sn = wfiltro_sn + btn.Tag.ToString() + ","
                    End If
                End If

            Next
            If wfiltro_sn <> "" Then
                wfiltro_sn = "and id_sn_master in (" & Mid(wfiltro_sn, 1, wfiltro_sn.Length - 1) & ")"
            End If
        End If

        sql_cade = "SELECT *   FROM vw_cuentassn    where  id_negocio = @id_negocio " & wfiltro_sn & " order by fecha_emis "
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        '  parametro = New SqlParameter("@fecha1", Format(t_fechaIni.Value, "yyyy/MM/dd"))
        '  command.Parameters.Add(Parametro)
        '  parametro = New SqlParameter("@fecha2", Format(t_fechaFin.Value, "yyyy/MM/dd"))
        'command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)
        dt_DatosConsulta_SN = New DataTable
        adaptador.Fill(dt_DatosConsulta_SN)

        SN_data_resumen()

        Dim wenlace_id_negocio As Integer = lk_NegocioActivo.id_Negocio
        If dg_resumen_sn.Rows.Count > 0 Then
            Dim wenlace_codigo As String = dg_resumen_sn.Rows(0).Cells("codigo").Value
            Muestra_Detalle_SN(wenlace_id_negocio, wenlace_codigo)
        End If


    End Sub
    Private Sub SN_Cabecera_resumen()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        dg_resumen_sn.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dg_resumen_sn.Columns.Clear()
        dg_resumen_sn.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)

        'textoColumn.Name = "num"
        'textoColumn.HeaderText = "#"
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'dg_resumen_sn.Columns.Add(textoColumn)
        'dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 25
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        'dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_resumen_sn.Columns.Add(textoColumn)
        dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 45
        dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_resumen_sn.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "operacion"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "OPERACION"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_resumen_sn.Columns.Add(textoColumn)
        dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 250
        dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_resumen_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "MON"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_resumen_sn.Columns.Add(textoColumn)
        dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_resumen_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "MONTO PEND."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_resumen_sn.Columns.Add(textoColumn)
        dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 70
        dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_resumen_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "vencido"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "VENCIDO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_resumen_sn.Columns.Add(textoColumn)
        dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 70
        dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_resumen_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "porvencer"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "POR VENDER"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_resumen_sn.Columns.Add(textoColumn)
        dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 70
        dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_resumen_sn.Columns.Item(textoColumn.Name).Visible = True

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verdetalle"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_resumen_sn.Columns.Add(imageColumn)
        dg_resumen_sn.Columns.Item(imageColumn.Name).Width = 20
        dg_resumen_sn.Columns.Item(imageColumn.Name).ReadOnly = False





    End Sub
    Private Sub SN_data_resumen()

        Dim lk_sql_listafiltro As DataTable = dt_DatosConsulta_SN.Copy()

        SN_Cabecera_resumen()

        Dim morosidadPorOperacion = From row In lk_sql_listafiltro.AsEnumerable()
                                    Group row By oper_codigo = row("oper_codigo"), oper_nom_oper = row("oper_nom_oper"), id_moneda = row("id_moneda") Into Group
                                    Select New With
                            {
                                .oper_codigo = oper_codigo,
                                .oper_nom_oper = oper_nom_oper,
                                .id_moneda = id_moneda,
                                .saldo_total = Group.Sum(Function(r) Convert.ToDecimal(r("saldo"))),
                                .saldo_vencido = Group.Sum(Function(r) If(Convert.ToDateTime(r("fecha_vcto")) < lk_fecha_dia, Convert.ToDecimal(r("saldo")), 0)),
                                .saldo_por_vencer = Group.Sum(Function(r) If(Convert.ToDateTime(r("fecha_vcto")) >= lk_fecha_dia, Convert.ToDecimal(r("saldo")), 0))
                            }

        For Each item In morosidadPorOperacion
            Me.dg_resumen_sn.Rows.Add()
            dg_resumen_sn.Rows(dg_resumen_sn.Rows.Count - 1).Cells("codigo").Value = item.oper_codigo
            dg_resumen_sn.Rows(dg_resumen_sn.Rows.Count - 1).Cells("operacion").Value = item.oper_nom_oper
            dg_resumen_sn.Rows(dg_resumen_sn.Rows.Count - 1).Cells("moneda").Value = ""
            dg_resumen_sn.Rows(dg_resumen_sn.Rows.Count - 1).Cells("monto").Value = item.saldo_total
            dg_resumen_sn.Rows(dg_resumen_sn.Rows.Count - 1).Cells("vencido").Value = item.saldo_vencido
            dg_resumen_sn.Rows(dg_resumen_sn.Rows.Count - 1).Cells("porvencer").Value = item.saldo_por_vencer

            'Dim oper_codigo As String = item.oper_codigo
            'Dim oper_nom_oper As String = item.oper_nom_oper
            'Dim id_moneda As String = item.id_moneda
            'Dim saldo_total As Decimal = item.saldo_total
            'Dim saldo_vencido As Decimal = item.saldo_vencido
            'Dim saldo_por_vencer As Decimal = item.saldo_por_vencer

            '' Realiza las operaciones necesarias con los campos
            '' Por ejemplo, puedes mostrarlos en la consola
            'Console.WriteLine("Código de Operación: " & oper_codigo)
            'Console.WriteLine("Nombre de Operación: " & oper_nom_oper)
            'Console.WriteLine("ID de Moneda: " & id_moneda)
            'Console.WriteLine("Saldo Total: " & saldo_total)
            'Console.WriteLine("Saldo Vencido: " & saldo_vencido)
            'Console.WriteLine("Saldo Por Vencer: " & saldo_por_vencer)
            'Console.WriteLine("-----------------------------------")
        Next


    End Sub
    Private Sub EnviaGraficoSN(lk_sql_listafiltro As DataTable)

        'Dim lk_sql_listafiltro As DataTable = dt_DatosConsulta_SN.Copy()


        Dim wmorosidad As ArrayList = New ArrayList
        Dim wmorosidad_val As ArrayList = New ArrayList



        Dim morosidadPorOperacion = From row In lk_sql_listafiltro.AsEnumerable()
                                    Group row By oper_codigo = row("oper_codigo"), oper_nom_oper = row("oper_nom_oper"), id_moneda = row("id_moneda") Into Group
                                    Select New With
                            {
                                .oper_codigo = oper_codigo,
                                .oper_nom_oper = oper_nom_oper,
                                .id_moneda = id_moneda,
                                .saldo_por_vencido = Group.Sum(Function(r) If((lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays >= 1 AndAlso (lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays <= 6, Convert.ToDecimal(r("saldo")), 0)),
                                .saldo_por_vencer7d = Group.Sum(Function(r) If((lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays >= 7 AndAlso (lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays <= 14, Convert.ToDecimal(r("saldo")), 0)),
                                .saldo_por_vencer15d = Group.Sum(Function(r) If((lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays >= 15 AndAlso (lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays <= 29, Convert.ToDecimal(r("saldo")), 0)),
                                .saldo_por_vencer30d = Group.Sum(Function(r) If((lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays >= 30 AndAlso (lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays <= 44, Convert.ToDecimal(r("saldo")), 0)),
                                .saldo_por_vencer45d = Group.Sum(Function(r) If((lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays >= 45 AndAlso (lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays <= 59, Convert.ToDecimal(r("saldo")), 0)),
                                .saldo_por_vencer60d = Group.Sum(Function(r) If((lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays >= 60 AndAlso (lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays <= 89, Convert.ToDecimal(r("saldo")), 0)),
                                .saldo_por_vencermas90d = Group.Sum(Function(r) If((lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays > 90 AndAlso (lk_fecha_dia - Convert.ToDateTime(r("fecha_vcto"))).TotalDays <= 999999, Convert.ToDecimal(r("saldo")), 0))
                            }

        Muestra_GraficoResumen(morosidadPorOperacion)
    End Sub
    Private Sub Muestra_GraficoResumen(morosidadPorOperacion)
        ' Dim chart As New Chart()

        ' Establecer el tipo de gráfico como circular
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add("ChartArea")
        Chart1.Series.Clear()
        Chart1.Series.Add("Series")
        Chart1.Series("Series").ChartType = SeriesChartType.Pie
        Chart1.Series("Series")("PieLineColor") = "Transparent" ' Ocultar las líneas de conexión de la leyenda
        Chart1.Series("Series").IsValueShownAsLabel = True ' Mostrar valores como etiquetas
        Chart1.ChartAreas("ChartArea").InnerPlotPosition.Auto = False
        Chart1.ChartAreas("ChartArea").InnerPlotPosition.Width = 100
        Chart1.ChartAreas("ChartArea").InnerPlotPosition.Height = 100
        Chart1.ChartAreas("ChartArea").InnerPlotPosition.X = 0
        Chart1.ChartAreas("ChartArea").InnerPlotPosition.Y = 0
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Montos Vencidos ") ' Agregar un título al gráfico
        Chart1.Titles(0).Font = New Font("Arial", 9, FontStyle.Bold) ' Establecer el estilo de fuente del título


        For Each item In morosidadPorOperacion
            Dim point1 As New DataPoint()
            point1.AxisLabel = "> 7d (" & Format(Val(item.saldo_por_vencer7d), "#,##0.00") & ")"
            point1.YValues = New Double() {item.saldo_por_vencer7d}
            point1.Label = "#PERCENT{P0}"
            Chart1.Series("Series").Points.Add(point1)

            Dim point2 As New DataPoint()
            point2.AxisLabel = "> 15d (" & Format(Val(item.saldo_por_vencer15d), "#,##0.00") & ")"
            point2.YValues = New Double() {item.saldo_por_vencer15d}
            point2.Label = "#PERCENT{P0}"
            Chart1.Series("Series").Points.Add(point2)

            Dim point3 As New DataPoint()
            point3.AxisLabel = "> 30d (" & Format(Val(item.saldo_por_vencer30d), "#,##0.00") & ")"
            point3.YValues = New Double() {item.saldo_por_vencer30d}
            point3.Label = "#PERCENT{P0}"
            Chart1.Series("Series").Points.Add(point3)

            Dim point4 As New DataPoint()
            point4.AxisLabel = "> 45d (" & Format(Val(item.saldo_por_vencer45d), "#,##0.00") & ")"
            point4.YValues = New Double() {item.saldo_por_vencer45d}
            point4.Label = "#PERCENT{P0}"
            Chart1.Series("Series").Points.Add(point4)

            Dim point5 As New DataPoint()
            point5.AxisLabel = "> 60d (" & Format(Val(item.saldo_por_vencer60d), "#,##0.00") & ")"
            point5.YValues = New Double() {item.saldo_por_vencer60d}
            point5.Label = "#PERCENT{P0}"
            Chart1.Series("Series").Points.Add(point5)

            Dim point6 As New DataPoint()
            point6.AxisLabel = "> 90d (" & Format(Val(item.saldo_por_vencermas90d), "#,##0.00") & ")"
            point6.YValues = New Double() {item.saldo_por_vencermas90d}
            point6.Label = "#PERCENT{P0}"
            Chart1.Series("Series").Points.Add(point6)
        Next

        Chart1.Series("Series").LegendText = "#AXISLABEL" ' Mostrar las etiquetas originales en la leyenda
        Chart1.Series("Series").LegendToolTip = "#PERCENT{P0}" ' Mostrar el porcentaje en la leyenda
        Chart1.Series("Series").IsValueShownAsLabel = False ' Desactivar la visualización de valores como etiquetas en la gráfica



        'For Each item In morosidadPorOperacion
        '    wmorosidad.Add(0)
        '    wmorosidad_val.Add(0)
        'Next
    End Sub

    Private Sub SN_Cabecera_detalle()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        dg_detalle_sn.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dg_detalle_sn.Columns.Clear()
        dg_detalle_sn.DefaultCellStyle.Font = New Font("Segoe UI", 7.8)

        'textoColumn.Name = "num"
        'textoColumn.HeaderText = "#"
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'dg_resumen_sn.Columns.Add(textoColumn)
        'dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 25
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        'dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True





        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fecha"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "FEC. EMISION"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 65
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).DefaultCellStyle.Format = "dd/MM/yyyy"

        dg_detalle_sn.Columns(textoColumn.Name).ValueType = GetType(Date) ' Indica que el tipo de datos es fecha
        ' dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "tipocomp"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "TIPO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 40
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 35
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 60
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "vercomp"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_detalle_sn.Columns.Add(imageColumn)
        dg_detalle_sn.Columns.Item(imageColumn.Name).Width = 20
        dg_detalle_sn.Columns.Item(imageColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo_sn"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "COD"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 40
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "socionegocio"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SOCIO NEGOCIO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 130
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 20
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_detalle_sn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "SALDO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_detalle_sn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "DET"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verdet"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_detalle_sn.Columns.Add(imageColumn)
        dg_detalle_sn.Columns.Item(imageColumn.Name).Width = 20
        dg_detalle_sn.Columns.Item(imageColumn.Name).ReadOnly = False
        dg_detalle_sn.Columns.Item(imageColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechavcto"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "FEC. VCTO."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 60
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "dias"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "DIAS"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "usuario"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "USUARIO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hora"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "HORA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "resultadofn"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "resultadofn"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "resultadoliq"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "resultadoliq"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = False






        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_negocio"
        textoColumn.HeaderText = "id_negocio"
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 25
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        textoColumn.HeaderText = "id_oper_maestro"
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 25
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        textoColumn.HeaderText = "id_comp_cab"
        dg_detalle_sn.Columns.Add(textoColumn)
        dg_detalle_sn.Columns.Item(textoColumn.Name).Width = 25
        dg_detalle_sn.Columns.Item(textoColumn.Name).Visible = False





    End Sub

    Private Sub SN_Cabecera_Finanzas()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        dg_finanzas_sn.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dg_finanzas_sn.Columns.Clear()
        dg_finanzas_sn.DefaultCellStyle.Font = New Font("Segoe UI", 7.8)

        'textoColumn.Name = "num"
        'textoColumn.HeaderText = "#"
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'dg_resumen_sn.Columns.Add(textoColumn)
        'dg_resumen_sn.Columns.Item(textoColumn.Name).Width = 25
        'textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        'dg_resumen_sn.Columns.Item(textoColumn.Name).ReadOnly = True




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fecha"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "FEC. OPER"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 60
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "tipocomp"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "TIPO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 40
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "serie"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SERIE"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 35
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "numero"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "NUMERO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 60
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "vercomp"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_finanzas_sn.Columns.Add(imageColumn)
        dg_finanzas_sn.Columns.Item(imageColumn.Name).Width = 20
        dg_finanzas_sn.Columns.Item(imageColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "entidad"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ENTIDA FINANCIERA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 130
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "moneda"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "MOD"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 20
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "monto"
        textoColumn.Tag = "N10"
        textoColumn.HeaderText = "MONTO"
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).MinimumWidth = 70
        dg_finanzas_sn.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = False
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "nro"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "NRO. REF"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "usuario"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "USUARIO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hora"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "HORA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 30
        dg_finanzas_sn.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_negocio"
        textoColumn.HeaderText = "id_negocio"
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 25
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        textoColumn.HeaderText = "id_oper_maestro"
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 25
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        textoColumn.HeaderText = "id_comp_cab"
        dg_finanzas_sn.Columns.Add(textoColumn)
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Width = 25
        dg_finanzas_sn.Columns.Item(textoColumn.Name).Visible = False



    End Sub

    Private Sub dg_detalle_sn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_detalle_sn.CellContentClick

    End Sub

    Private Sub dg_resumen_sn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_resumen_sn.CellContentClick

    End Sub

    Private Sub dg_resumen_sn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_resumen_sn.CellClick
        Dim columnName As String = dg_resumen_sn.Columns(e.ColumnIndex).Name ' Obtener el nombre de la columna actual
        If columnName <> "verdetalle" Then Exit Sub
        If Val(dg_resumen_sn.Rows(e.RowIndex).Cells("codigo").Value) = 0 Then Exit Sub

        Dim wenlace_id_negocio As Integer = lk_NegocioActivo.id_Negocio
        Dim wenlace_codigo As String = dg_resumen_sn.Rows(e.RowIndex).Cells("codigo").Value


        Muestra_Detalle_SN(wenlace_id_negocio, wenlace_codigo)
    End Sub
    Private Sub Muestra_Detalle_SN(wenlace_id_negocio As Integer, wenlace_codigo As String)
        SN_Cabecera_detalle()


        Dim lk_sql_listafiltro As DataTable '= dt_DatosConsulta_SN.Copy()

        lk_sql_listafiltro = dt_DatosConsulta_SN.Clone() ' Reiniciar lk_sql_listafiltro con la misma estructura que dt_DatosConsulta_SN

        For Each row As DataRow In dt_DatosConsulta_SN.Select("oper_codigo = '" & wenlace_codigo & "'") ' Filtrar las filas por el valor de la columna "CODIGO"
            lk_sql_listafiltro.ImportRow(row) ' Importar las filas filtradas a lk_sql_listafiltro
        Next



        For i = 0 To lk_sql_listafiltro.Rows.Count - 1
            Me.dg_detalle_sn.Rows.Add()

            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("fecha").Value = lk_sql_listafiltro.Rows(i).Item("fecha_emis")
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("tipocomp").Value = lk_sql_listafiltro.Rows(i).Item("comp_descrip").ToString.Trim
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("serie").Value = lk_sql_listafiltro.Rows(i).Item("serie_comp").ToString.Trim
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("numero").Value = lk_sql_listafiltro.Rows(i).Item("numero_comp")
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("codigo_sn").Value = lk_sql_listafiltro.Rows(i).Item("sn_codigo").ToString.Trim
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("socionegocio").Value = lk_sql_listafiltro.Rows(i).Item("sn_razonsocial").ToString.Trim
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("fechavcto").Value = Format(lk_sql_listafiltro.Rows(i).Item("fecha_vcto"), "dd/MM/yy")
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("moneda").Value = lk_sql_listafiltro.Rows(i).Item("mod_simbolo")
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("monto").Value = Val(lk_sql_listafiltro.Rows(i).Item("total"))
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("saldo").Value = Val(lk_sql_listafiltro.Rows(i).Item("saldo"))
            Dim fechaVencimiento As DateTime = Convert.ToDateTime(lk_sql_listafiltro.Rows(i).Item("fecha_vcto"))
            Dim diasAtraso As Integer = (lk_fecha_dia - fechaVencimiento).Days

            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("dias").Value = diasAtraso
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("usuario").Value = ""
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("hora").Value = ""
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("resultadofn").Value = lk_sql_listafiltro.Rows(i).Item("resultadofn").ToString.Trim
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("resultadoliq").Value = lk_sql_listafiltro.Rows(i).Item("resultadoliq").ToString.Trim

            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("id_negocio").Value = lk_sql_listafiltro.Rows(i).Item("id_negocio")
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("id_oper_maestro").Value = lk_sql_listafiltro.Rows(i).Item("id_oper_maestro")
            dg_detalle_sn.Rows(dg_detalle_sn.Rows.Count - 1).Cells("id_comp_cab").Value = lk_sql_listafiltro.Rows(i).Item("id_comp_cab")


        Next i
        SN_Cabecera_Finanzas()
        EnviaGraficoSN(lk_sql_listafiltro)

    End Sub

    Private Sub dg_detalle_sn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_detalle_sn.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim columnName As String = dg_detalle_sn.Columns(e.ColumnIndex).Name ' Obtener el nombre de la columna actual

        If columnName = "vercomp" Then GoTo IrComprobante

        If Val(dg_detalle_sn.Rows(e.RowIndex).Cells("codigo_sn").Value) = 0 Then Exit Sub

        Dim wenlace_id_negocio As Integer = lk_NegocioActivo.id_Negocio
        Dim wresultadofn As String
        Dim wresultadoliq As String
        wresultadofn = dg_detalle_sn.Rows(e.RowIndex).Cells("resultadofn").Value
        wresultadoliq = dg_detalle_sn.Rows(e.RowIndex).Cells("resultadoliq").Value
        ' Dim wenlace_codigo As String = dg_detalle_sn.Rows(e.RowIndex).Cells("codigo").Value

        Muestra_finanzas_SN(wresultadofn, wresultadoliq)

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
        frMenuOperacion.ENLACE_MUESTRA_id_oper_maestro = Val(dg_detalle_sn.Rows(e.RowIndex).Cells("id_oper_maestro").Value)
        frMenuOperacion.ENLACE_MUESTRA_id_comp_cabe = Val(dg_detalle_sn.Rows(e.RowIndex).Cells("id_comp_cab").Value)
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




    End Sub
    Private Sub Muestra_finanzas_SN(wresultadofn As String, wresultadoliq As String)


        Dim resultado As String = wresultadofn
        Dim resultadoliq As String = wresultadoliq

        Dim dataTable As New DataTable()

        ' Agregar las columnas al DataTable
        dataTable.Columns.Add("id_negocio")
        dataTable.Columns.Add("id_oper_maestro")
        dataTable.Columns.Add("id_comp_cab")
        dataTable.Columns.Add("fecha_fn")
        dataTable.Columns.Add("comp_codigo")
        dataTable.Columns.Add("comp_abreviado")
        dataTable.Columns.Add("serie_comp")

        dataTable.Columns.Add("numero_comp")
        dataTable.Columns.Add("entidad")
        dataTable.Columns.Add("forma")
        dataTable.Columns.Add("total")
        dataTable.Columns.Add("nrodoc")
        dataTable.Columns.Add("ref")
        dataTable.Columns.Add("estado")
        dataTable.Columns.Add("signo_fn")

        SN_Cabecera_Finanzas()

        Dim filas As String() = resultado.Split("%"c)

        ' Paso 3: Recorrer cada fila y dividirla en elementos utilizando el carácter '#'
        For i As Integer = 0 To filas.Length - 1

            Dim elementos As String() = filas(i).Trim("["c, "]"c).Split("["c)

            ' Crear una nueva fila en el DataTable
            Dim nuevaFila As DataRow = dataTable.NewRow()

            If elementos(0).ToString.Trim = "" Then Continue For
            ' Asignar los valores a las columnas de la fila

            nuevaFila("id_negocio") = elementos(0).Substring(0, elementos(0).Length - 1)
            nuevaFila("id_oper_maestro") = elementos(1).Substring(0, elementos(1).Length - 1)
            nuevaFila("id_comp_cab") = elementos(2).Substring(0, elementos(2).Length - 1)
            nuevaFila("fecha_fn") = elementos(3).Substring(0, elementos(3).Length - 1)
            nuevaFila("comp_codigo") = elementos(4).Substring(0, elementos(4).Length - 1)
            nuevaFila("comp_abreviado") = elementos(5).Substring(0, elementos(5).Length - 1)
            nuevaFila("serie_comp") = elementos(6).Substring(0, elementos(6).Length - 1)
            nuevaFila("numero_comp") = elementos(7).Substring(0, elementos(7).Length - 1)
            nuevaFila("entidad") = elementos(8).Substring(0, elementos(8).Length - 1)
            nuevaFila("forma") = elementos(9).Substring(0, elementos(9).Length - 1)
            nuevaFila("total") = elementos(10).Substring(0, elementos(10).Length - 1)
            nuevaFila("nrodoc") = elementos(11).Substring(0, elementos(11).Length - 1)
            nuevaFila("ref") = elementos(12).Substring(0, elementos(12).Length - 1)
            nuevaFila("estado") = elementos(13).Substring(0, elementos(13).Length - 1)
            nuevaFila("signo_fn") = elementos(14)

            ' Agregar la fila al DataTable
            dataTable.Rows.Add(nuevaFila)
        Next

        Dim filasliq As String() = resultadoliq.Split("%"c)

        ' Paso 3: Recorrer cada fila y dividirla en elementos utilizando el carácter '#'
        For i As Integer = 0 To filasliq.Length - 1

            Dim elementos As String() = filasliq(i).Trim("["c, "]"c).Split("["c)

            ' Crear una nueva fila en el DataTable
            Dim nuevaFila As DataRow = dataTable.NewRow()

            If elementos(0).ToString.Trim = "" Then Continue For
            ' Asignar los valores a las columnas de la fila

            nuevaFila("id_negocio") = elementos(0).Substring(0, elementos(0).Length - 1)
            nuevaFila("id_oper_maestro") = elementos(1).Substring(0, elementos(1).Length - 1)
            nuevaFila("id_comp_cab") = elementos(2).Substring(0, elementos(2).Length - 1)
            nuevaFila("fecha_fn") = elementos(3).Substring(0, elementos(3).Length - 1)
            nuevaFila("comp_codigo") = elementos(4).Substring(0, elementos(4).Length - 1)
            nuevaFila("comp_abreviado") = elementos(5).Substring(0, elementos(5).Length - 1)
            nuevaFila("serie_comp") = elementos(6).Substring(0, elementos(6).Length - 1)
            nuevaFila("numero_comp") = elementos(7).Substring(0, elementos(7).Length - 1)
            nuevaFila("entidad") = elementos(8).Substring(0, elementos(8).Length - 1)
            nuevaFila("forma") = elementos(9).Substring(0, elementos(9).Length - 1)
            nuevaFila("total") = elementos(10).Substring(0, elementos(10).Length - 1)
            nuevaFila("nrodoc") = elementos(11).Substring(0, elementos(11).Length - 1)
            nuevaFila("ref") = elementos(12).Substring(0, elementos(12).Length - 1)
            nuevaFila("estado") = elementos(13).Substring(0, elementos(13).Length - 1)
            nuevaFila("signo_fn") = elementos(14)

            ' Agregar la fila al DataTable
            dataTable.Rows.Add(nuevaFila)
        Next


        ' Ahora el arreglo contiene las filas divididas en elementos
        ' Puedes utilizar el arreglo como desees





        For i = 0 To dataTable.Rows.Count - 1
            If dataTable.Rows(i).Item("estado").ToString.Trim = "10" Then Continue For
            Me.dg_finanzas_sn.Rows.Add()
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("fecha").Value = Format(CDate(dataTable.Rows(i).Item("fecha_fn")), "dd/MM/yy")
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("tipocomp").Value = dataTable.Rows(i).Item("comp_abreviado").ToString.Trim
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("serie").Value = dataTable.Rows(i).Item("serie_comp").ToString.Trim
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("numero").Value = dataTable.Rows(i).Item("numero_comp")
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("entidad").Value = dataTable.Rows(i).Item("entidad").ToString.Trim
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("moneda").Value = ""
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("monto").Value = Val(dataTable.Rows(i).Item("total"))
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("nro").Value = dataTable.Rows(i).Item("nrodoc")
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("usuario").Value = ""
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("hora").Value = ""
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("id_negocio").Value = dataTable.Rows(i).Item("id_negocio")
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("id_oper_maestro").Value = dataTable.Rows(i).Item("id_oper_maestro")
            dg_finanzas_sn.Rows(dg_finanzas_sn.Rows.Count - 1).Cells("id_comp_cab").Value = dataTable.Rows(i).Item("id_comp_cab")

        Next i


    End Sub

    Private Sub dg_finanzas_sn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_finanzas_sn.CellContentClick

    End Sub

    Private Sub dg_finanzas_sn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_finanzas_sn.CellClick
        Dim columnName As String = dg_finanzas_sn.Columns(e.ColumnIndex).Name ' Obtener el nombre de la columna actual



        If Val(dg_finanzas_sn.Rows(e.RowIndex).Cells("numero").Value) = 0 Then Exit Sub
        If columnName = "vercomp" Then GoTo IrComprobante
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
        frMenuOperacion.ENLACE_MUESTRA_id_oper_maestro = Val(dg_finanzas_sn.Rows(e.RowIndex).Cells("id_oper_maestro").Value)
        frMenuOperacion.ENLACE_MUESTRA_id_comp_cabe = Val(dg_finanzas_sn.Rows(e.RowIndex).Cells("id_comp_cab").Value)
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


    End Sub

    Private Sub CmdContraerMenu_Click(sender As Object, e As EventArgs) Handles CmdContraerMenu.Click
        If CmdContraerMenu.Tag = 1 Then
            PanelListarOper.Width = 40
            CmdContraerMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowRight
            ' arrow-Right -to-bracket
            CmdContraerMenu.Tag = 0
            CmdContraerMenu.ImageAlign = ContentAlignment.MiddleLeft
        Else
            PanelListarOper.Width = 160
            CmdContraerMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft
            CmdContraerMenu.Tag = 1
            CmdContraerMenu.ImageAlign = ContentAlignment.MiddleRight
        End If
    End Sub
    Public Sub Centrar()
        Dim xl, yl As Integer
        xl = (Screen.PrimaryScreen.WorkingArea.Width - Me.Size.Width) / 2
        yl = (Screen.PrimaryScreen.WorkingArea.Height - Me.Size.Height) / 2
        Me.Location = New Point(xl, yl)

    End Sub

    Private Sub CmdInventarios_Click(sender As Object, e As EventArgs) Handles CmdInventarios.Click
        PanelSN.Visible = False
        PanelEnLinea.Visible = False
        PanelInventario.Visible = True
        PanelInventario.Dock = DockStyle.Fill
        dg_Inventario.Columns.Clear()
        dg_kardex.Columns.Clear()
        MostrarDatosAlmacenTransf(lk_AlmacenActivo.codigo)
    End Sub

    Private Sub CmdMostrarInventario_Click(sender As Object, e As EventArgs) Handles CmdMostrarInventario.Click
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim dt_datos As New DataTable
        Dim wid_almacenes As String = CmdAlmTransf.Tag

        sql_cade = "exec [sp_muestra_inventario] @id_negocio, @fechaini ,@fechafin , @id_almacen_lista"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)

        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@fechaini", Format(Inv_fechaini.Value, "yyyy/MM/dd"))
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@fechafin", Format(Inv_fechafin.Value, "yyyy/MM/dd"))
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_almacen_lista", wid_almacenes)
        command.Parameters.Add(parametro)
        adaptador = New SqlDataAdapter(command)

        adaptador.Fill(dt_datos)
        dg_kardex.Columns.Clear()
        Inventario_Cabecera()
        If dt_datos.Rows.Count > 0 Then
            Muestra_Inventario(dt_datos)
        End If
    End Sub
    Private Sub Muestra_Inventario(lk_sql_listafiltro As DataTable)
        Dim wscal_saldo As Double = 0
        Dim wstock As Double = 0
        Dim winicial As Double = 0
        Dim wingreso As Double = 0
        Dim wsalida As Double = 0
        Dim wcospro As Double = 0
        Dim wvalorinv As Double = 0

        Dim winicial_val As Double = 0
        Dim wingresos_val As Double = 0
        Dim wsalidas_val As Double = 0
        Dim wsaldo_val As Double = 0



        For i = 0 To lk_sql_listafiltro.Rows.Count - 1
            Me.dg_Inventario.Rows.Add()

            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("num").Value = i + 1
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("almacen").Value = CmdAlmTransf.Text.Trim
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("labo").Value = lk_sql_listafiltro.Rows(i).Item("lab_linea").ToString.Trim
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("codigo").Value = lk_sql_listafiltro.Rows(i).Item("codigo").ToString.Trim
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("producto").Value = lk_sql_listafiltro.Rows(i).Item("nombreproducto").ToString.Trim

            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("unidad").Value = lk_sql_listafiltro.Rows(i).Item("abreviado_pres_def").ToString.Trim
            wstock = Val(lk_sql_listafiltro.Rows(i).Item("stock")) / Val(lk_sql_listafiltro.Rows(i).Item("equiv_def"))
            wcospro = Val(lk_sql_listafiltro.Rows(i).Item("cospro")) * Val(lk_sql_listafiltro.Rows(i).Item("equiv_def"))
            wvalorinv = wcospro * wstock

            winicial = Val(lk_sql_listafiltro.Rows(i).Item("st_inicial")) / Val(lk_sql_listafiltro.Rows(i).Item("equiv_def"))
            wingreso = Val(lk_sql_listafiltro.Rows(i).Item("ingreso")) / Val(lk_sql_listafiltro.Rows(i).Item("equiv_def"))
            wsalida = Val(lk_sql_listafiltro.Rows(i).Item("salidas")) / Val(lk_sql_listafiltro.Rows(i).Item("equiv_def"))

            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("stock").Value = If(wstock Mod 1 = 0, wstock.ToString("N0"), wstock.ToString("N2"))
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("cospro").Value = If(wcospro Mod 1 = 0, wcospro.ToString("N4"), wcospro.ToString("N4"))
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("valorinventario").Value = If(wvalorinv Mod 1 = 0, wvalorinv.ToString("N2"), wvalorinv.ToString("N2"))



            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("inicial").Value = If(winicial Mod 1 = 0, winicial.ToString("N0"), winicial.ToString("N2"))  'Val(lk_sql_listafiltro.Rows(i).Item("st_inicial"))
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("ingresos").Value = If(wingreso Mod 1 = 0, wingreso.ToString("N0"), wingreso.ToString("N2"))   'Val(lk_sql_listafiltro.Rows(i).Item("ingreso"))
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("salidas").Value = If(wsalida Mod 1 = 0, wsalida.ToString("N0"), wsalida.ToString("N2"))   ' Val(lk_sql_listafiltro.Rows(i).Item("salidas"))

            wscal_saldo = Val(lk_sql_listafiltro.Rows(i).Item("st_inicial")) + Val(lk_sql_listafiltro.Rows(i).Item("ingreso")) + Val(lk_sql_listafiltro.Rows(i).Item("salidas"))
            wscal_saldo = wscal_saldo / Val(lk_sql_listafiltro.Rows(i).Item("equiv_def"))
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("saldo").Value = If(wscal_saldo Mod 1 = 0, wscal_saldo.ToString("N0"), wscal_saldo.ToString("N2"))  ' Val(wscal_saldo)

            winicial_val = Val(lk_sql_listafiltro.Rows(i).Item("cospro_inicial")) * Val(lk_sql_listafiltro.Rows(i).Item("st_inicial"))
            wingresos_val = Val(lk_sql_listafiltro.Rows(i).Item("ingreso_val"))
            wsalidas_val = Val(lk_sql_listafiltro.Rows(i).Item("salida_val"))
            wsaldo_val = winicial_val + wingresos_val + wsalidas_val

            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("inicial_val").Value = If(winicial_val Mod 1 = 0, winicial_val.ToString("N2"), winicial_val.ToString("N2"))  ' Val(wscal_saldo)
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("ingresos_val").Value = If(wingresos_val Mod 1 = 0, wingresos_val.ToString("N2"), wingresos_val.ToString("N2"))  ' Val(wscal_saldo)
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("salidas_val").Value = If(wsalidas_val Mod 1 = 0, wsalidas_val.ToString("N2"), wsalidas_val.ToString("N2"))  ' Val(wscal_saldo)
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("saldo_val").Value = If(wsaldo_val Mod 1 = 0, wsaldo_val.ToString("N2"), wsaldo_val.ToString("N2"))  ' Val(wscal_saldo)



            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("id_prod_mae").Value = Val(lk_sql_listafiltro.Rows(i).Item("id_prod_mae"))
            dg_Inventario.Rows(dg_Inventario.Rows.Count - 1).Cells("equiv_def").Value = Val(lk_sql_listafiltro.Rows(i).Item("equiv_def"))

        Next i

    End Sub

    Private Sub Inventario_Cabecera()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        dg_Inventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dg_Inventario.Columns.Clear()
        dg_Inventario.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 30
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "almacen"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ALM."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 45
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "labo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "LAB / LINEA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 90
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 40
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True
        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "producto"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "DESCRUIPCION PRODUCTO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 200
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verdetalle"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_Inventario.Columns.Add(imageColumn)
        dg_Inventario.Columns.Item(imageColumn.Name).Width = 20
        dg_Inventario.Columns.Item(imageColumn.Name).ReadOnly = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "unidad"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "PRES."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 45
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "stock"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "STOCK ACTUAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 6.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_Inventario.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cospro"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "COSPRO ACTUAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 6.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.0000" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_Inventario.Columns.Item(textoColumn.Name).MinimumWidth = 45
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valorinventario"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "VALOR ACTUAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 6.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_Inventario.Columns.Item(textoColumn.Name).MinimumWidth = 45
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "monto"
        'textoColumn.Tag = "N10"
        'textoColumn.HeaderText = "MONTO"
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'dg_detalle_sn.Columns.Add(textoColumn)
        'dg_detalle_sn.Columns.Item(textoColumn.Name).MinimumWidth = 70

        'dg_detalle_sn.Columns.Item(textoColumn.Name).ReadOnly = False

        'textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        'textoColumn.ValueType = GetType(Double) ' Tipo de valor de la celda




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "inicial"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "INICIAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_Inventario.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ingresos"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "INGRESOS"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_Inventario.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "salidas"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALIDAS"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_Inventario.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALDO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_Inventario.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "KAX"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verkardex"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_Inventario.Columns.Add(imageColumn)
        dg_Inventario.Columns.Item(imageColumn.Name).Width = 20
        dg_Inventario.Columns.Item(imageColumn.Name).ReadOnly = False






        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "inicial_val"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "INICIAL #"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 60
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ingresos_val"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "INGRESOS #"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 60
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "salidas_val"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALIDAS #"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 60
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo_val"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALDO #"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Width = 60
        dg_Inventario.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_prod_mae"
        textoColumn.HeaderText = "id_prod_mae"
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "equiv_def"
        textoColumn.HeaderText = "equiv_def"
        dg_Inventario.Columns.Add(textoColumn)
        dg_Inventario.Columns.Item(textoColumn.Name).Visible = False

    End Sub


    Private Sub Kardex_Cabecera()
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()


        dg_kardex.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        dg_kardex.Columns.Clear()
        dg_kardex.DefaultCellStyle.Font = New Font("Segoe UI", 8.25)



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "num"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "#"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 30
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "almacen"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ALM"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fecha"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "FECHA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 65
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "hora"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "HORA"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "operacion"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "OPERACION"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 80
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "comprobante"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "TIPO COMPROB."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 80
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "doccomp"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "DOCUM. COMPROB."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 90
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "VER"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verdetalle"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_kardex.Columns.Add(imageColumn)
        dg_kardex.Columns.Item(imageColumn.Name).Width = 20
        dg_kardex.Columns.Item(imageColumn.Name).ReadOnly = False




        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ingresos"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "INGRESOS"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_kardex.Columns.Item(textoColumn.Name).MinimumWidth = 60
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "salidas"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALIDAS"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_kardex.Columns.Item(textoColumn.Name).MinimumWidth = 55
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALDO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dg_kardex.Columns.Item(textoColumn.Name).MinimumWidth = 50
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "lote"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "lote"
        imageColumn.Image = My.Resources.lote
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dg_kardex.Columns.Add(imageColumn)
        dg_kardex.Columns.Item(imageColumn.Name).Width = 25
        dg_kardex.Columns.Item(imageColumn.Name).ReadOnly = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "precio_ing"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "PRECIO INGR."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00##" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "costo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "COSTO PROM."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00##" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        'textoColumn = New DataGridViewTextBoxColumn()
        'textoColumn.Name = "inicial_val"
        'textoColumn.Tag = "T"
        'textoColumn.HeaderText = "INICIAL #"
        'textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        'textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        'textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dg_kardex.Columns.Add(textoColumn)
        'dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        'dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        'dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ingresos_val"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "INGRESOS #"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "salidas_val"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALIDAS #"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "saldo_val"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "SALDO #"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alineación hacia la derecha
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 60
        dg_kardex.Columns.Item(textoColumn.Name).ReadOnly = True
        dg_kardex.Columns.Item(textoColumn.Name).Visible = True

        ' desactivar para que el usaurio no pueda ordenar las columnas
        For Each column As DataGridViewColumn In dg_kardex.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_oper_maestro"
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 0
        dg_kardex.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_comp_cab"
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 0
        dg_kardex.Columns.Item(textoColumn.Name).Visible = False


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "dt_loteser_det"
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 0
        dg_kardex.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "signo_kardex"
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 0
        dg_kardex.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "dt_es_costeo"
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 0
        dg_kardex.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "estado"
        dg_kardex.Columns.Add(textoColumn)
        dg_kardex.Columns.Item(textoColumn.Name).Width = 0
        dg_kardex.Columns.Item(textoColumn.Name).Visible = False




    End Sub

    Private Sub dg_Inventario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_Inventario.CellContentClick

    End Sub

    Private Sub dg_Inventario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_Inventario.CellClick
        dg_kardex.Columns.Clear()

        MostrarSelloAgua_kardex = True

        Dim columnName As String = dg_Inventario.Columns(e.ColumnIndex).Name ' Obtener el nombre de la columna actual

        If columnName <> "verkardex" Then Exit Sub
        ' If Val(dg_Inventario.Rows(e.RowIndex).Cells("codigo").Value) = 0 Then Exit Sub

        Dim wenlace_id_negocio As Integer = lk_NegocioActivo.id_Negocio
        Dim wid_prod_mae As Integer = Val(dg_Inventario.Rows(e.RowIndex).Cells("id_prod_mae").Value)
        Dim id_fila As Integer = e.RowIndex
        Dim wequiv_def As Integer = Val(dg_Inventario.Rows(e.RowIndex).Cells("equiv_def").Value)

        Muestra_Kardex_INV(wenlace_id_negocio, wid_prod_mae, id_fila, wequiv_def)
    End Sub
    Private Sub Muestra_Kardex_INV(wenlace_id_negocio As Integer, wewid_prod_mae As String, id_fila As Integer, wequiv_def As Integer)
        Dim sql_cade As String
        Dim command As SqlCommand
        Dim adaptador As SqlDataAdapter
        Dim parametro As New SqlParameter
        Dim dt_datos As New DataTable
        Dim wid_almacenes As String = CmdAlmTransf.Tag
        Kardex_Cabecera()

        sql_cade = "exec [sp_muestra_Kardex] @id_negocio, @fechaini ,@fechafin , @id_almacen_lista, @id_prod_mae"
        command = New SqlCommand(sql_cade, lk_connection_cuenta)

        parametro = New SqlParameter("@id_negocio", lk_NegocioActivo.id_Negocio)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@fechaini", Format(Inv_fechaini.Value, "yyyy/MM/dd"))
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@fechafin", Format(Inv_fechafin.Value, "yyyy/MM/dd"))
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_almacen_lista", wid_almacenes)
        command.Parameters.Add(parametro)
        parametro = New SqlParameter("@id_prod_mae", wewid_prod_mae)
        command.Parameters.Add(parametro)

        adaptador = New SqlDataAdapter(command)

        adaptador.Fill(dt_datos)

        If dt_datos.Rows.Count > 0 Then
            Muestra_Kardex(dt_datos, id_fila, wequiv_def)
        End If
        MostrarSelloAgua_kardex = False

    End Sub

    Private Sub Muestra_Kardex(lk_sql_listafiltro As DataTable, id_fila_producto As Integer, equiv_def As Integer)
        Dim wsaldokardex As Double = 0
        Kardex_Cabecera()
        If lk_sql_listafiltro.Rows.Count = 0 Then Exit Sub
        Dim wkst_inicial As Double = 0
        Dim wkingreso As Double = 0
        Dim wksalida As Double = 0
        Dim wksaldo As Double = 0
        Dim winicial_val As Double = 0
        Dim wingresos_val As Double = 0
        Dim wsalidas_val As Double = 0
        Dim wsaldo_val As Double = 0
        Dim wcospro As Double = 0
        Dim Wprecio_ing As Double = 0

        Me.dg_kardex.Rows.Add()

        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("num").Value = ""
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("almacen").Value = ""
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("fecha").Value = ""
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("fecha").Value = ""
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("operacion").Value = ""
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("comprobante").Value = ""
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("ingresos").Value = ""
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("salidas").Value = "INICAL="
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("verdetalle").Value = My.Resources.linea1
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("dt_es_costeo").Value = "1"
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("estado").Value = ""

        wkst_inicial = Val(lk_sql_listafiltro.Rows(0).Item("st_inicial")) / equiv_def
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("saldo").Value = If(wkst_inicial Mod 1 = 0, wkst_inicial.ToString("N0"), wkst_inicial.ToString("N2")) ' Val(lk_sql_listafiltro.Rows(0).Item("st_inicial"))


        winicial_val = Val(lk_sql_listafiltro.Rows(0).Item("dt_cospro")) * Val(lk_sql_listafiltro.Rows(0).Item("st_inicial"))
        dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("saldo_val").Value = If(winicial_val Mod 1 = 0, winicial_val.ToString("N2"), winicial_val.ToString("N2"))
        wsaldo_val = winicial_val
        wsaldokardex = wsaldokardex + Val(lk_sql_listafiltro.Rows(0).Item("st_inicial"))

        For i = 1 To lk_sql_listafiltro.Rows.Count - 1

            If Chek_quitar_anul.Checked Then
                If lk_sql_listafiltro.Rows(i).Item("estado_det") = 10 Then Continue For
            End If

            Me.dg_kardex.Rows.Add()
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("num").Value = i
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("almacen").Value = CmdAlmTransf.Text.Trim

            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("fecha").Value = Format(lk_sql_listafiltro.Rows(i).Item("fecha"), "dd/MM/yy")
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("hora").Value = CDate(lk_sql_listafiltro.Rows(i).Item("fechahora")).ToString("HH:mm:ss") 'Format(lk_sql_listafiltro.Rows(i).Item("fecha"), "dd/MM/yy")

            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("operacion").Value = lk_sql_listafiltro.Rows(i).Item("oper_codigo").ToString.Trim & " " & lk_sql_listafiltro.Rows(i).Item("oper_nom_oper").ToString.Trim
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("comprobante").Value = lk_sql_listafiltro.Rows(i).Item("comp_codigo").ToString.Trim & " " & lk_sql_listafiltro.Rows(i).Item("comp_descrip").ToString.Trim
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("doccomp").Value = lk_sql_listafiltro.Rows(i).Item("serie_comp").ToString.Trim & " - " & lk_sql_listafiltro.Rows(i).Item("numero_comp").ToString.Trim

            wkingreso = Val(lk_sql_listafiltro.Rows(i).Item("ingreso")) / equiv_def
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("ingresos").Value = If(wkingreso Mod 1 = 0, wkingreso.ToString("N0"), wkingreso.ToString("N2"))  ' Val(lk_sql_listafiltro.Rows(i).Item("ingreso"))
            wksalida = Val(lk_sql_listafiltro.Rows(i).Item("salida")) / equiv_def
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("salidas").Value = If(wksalida Mod 1 = 0, wksalida.ToString("N0"), wksalida.ToString("N2"))  '  Val(lk_sql_listafiltro.Rows(i).Item("salida"))
            wsaldokardex = wsaldokardex + (Val(lk_sql_listafiltro.Rows(i).Item("ingreso")) - Val(lk_sql_listafiltro.Rows(i).Item("salida")))
            wksaldo = Val(lk_sql_listafiltro.Rows(i).Item("stock_prod_mae")) / equiv_def
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("saldo").Value = If(wksaldo Mod 1 = 0, wksaldo.ToString("N0"), wksaldo.ToString("N2"))   ' Val(lk_sql_listafiltro.Rows(i).Item("stock_prod_mae"))  ' Val(wsaldokardex)

            Wprecio_ing = 0
            If lk_sql_listafiltro.Rows(i).Item("dt_es_costeo") = 1 And lk_sql_listafiltro.Rows(i).Item("signo_kardex") = 1 Then
                wingresos_val = Val(lk_sql_listafiltro.Rows(i).Item("dt_valor"))
                Wprecio_ing = Val(lk_sql_listafiltro.Rows(i).Item("dt_valor")) / wkingreso
            Else
                wingresos_val = Val(lk_sql_listafiltro.Rows(i).Item("dt_cospro")) * Val(lk_sql_listafiltro.Rows(i).Item("ingreso"))
            End If

            wsalidas_val = Val(lk_sql_listafiltro.Rows(i).Item("dt_cospro")) * Val(lk_sql_listafiltro.Rows(i).Item("salida"))
            If lk_sql_listafiltro.Rows(i).Item("estado_det") = 10 Then
            Else
                wsaldo_val = wsaldo_val + wingresos_val + wsalidas_val
                wcospro = Val(lk_sql_listafiltro.Rows(i).Item("dt_cospro")) * equiv_def
            End If


            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("precio_ing").Value = If(Wprecio_ing = 0, "", Wprecio_ing.ToString("N4"))
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("costo").Value = If(wcospro Mod 1 = 0, wcospro.ToString("N4"), wcospro.ToString("N4"))
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("ingresos_val").Value = If(wingresos_val Mod 1 = 0, wingresos_val.ToString("N2"), wingresos_val.ToString("N2"))
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("salidas_val").Value = If(wsalidas_val Mod 1 = 0, wsalidas_val.ToString("N2"), wsalidas_val.ToString("N2"))
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("saldo_val").Value = If(wsaldo_val Mod 1 = 0, wsaldo_val.ToString("N2"), wsaldo_val.ToString("N2"))



            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("id_oper_maestro").Value = Val(lk_sql_listafiltro.Rows(i).Item("id_oper_maestro"))  ' Val(wsaldokardex)
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("id_comp_cab").Value = Val(lk_sql_listafiltro.Rows(i).Item("id_comp_cab"))  ' Val(wsaldokardex)
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("dt_loteser_det").Value = lk_sql_listafiltro.Rows(i).Item("dt_loteser_det").ToString.Trim  ' Val(wsaldokardex)
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("signo_kardex").Value = lk_sql_listafiltro.Rows(i).Item("signo_kardex").ToString.Trim  ' Val(wsaldokardex)
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("dt_es_costeo").Value = lk_sql_listafiltro.Rows(i).Item("dt_es_costeo")
            dg_kardex.Rows(dg_kardex.Rows.Count - 1).Cells("estado").Value = lk_sql_listafiltro.Rows(i).Item("estado_det")

        Next i


    End Sub

    Private Sub dg_kardex_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_kardex.CellContentClick

    End Sub

    Private Sub dg_kardex_Paint(sender As Object, e As PaintEventArgs) Handles dg_kardex.Paint
        If MostrarSelloAgua_kardex Then
            Dim watermarkText As String = "Para mostrar el Kardex, dar click en la columna de KAX del Producto."
            Dim font As New Font("Arial", 10, FontStyle.Italic)
            Dim brush As New SolidBrush(Color.FromArgb(255, System.Drawing.ColorTranslator.FromHtml(strColorAzul)))
            Dim stringSize As SizeF = e.Graphics.MeasureString(watermarkText, font)
            Dim x As Single = (dg_kardex.Width - stringSize.Width) / 2
            Dim y As Single = (dg_kardex.Height - stringSize.Height) / 2
            Dim watermarkPoint As New PointF(x, y)
            e.Graphics.DrawString(watermarkText, font, brush, watermarkPoint)
        End If
    End Sub

    Private Sub CmdFiltroPeriodo_Click(sender As Object, e As EventArgs) Handles CmdFiltroPeriodo.Click
        '' Dim codigos() As String = {"1", "2", "3", "4", "5", "6", "7"}

        Dim fechaini() As Date = {lk_fecha_dia}
        Array.Resize(fechaini, 7)


        Dim fechafin() As Date = {lk_fecha_dia}
        Array.Resize(fechafin, 7)




        Dim codigos() As String = {"0"}
        Array.Resize(codigos, 7)
        codigos(0) = "0"
        codigos(1) = "1"
        codigos(2) = "2"
        codigos(3) = "3"
        codigos(4) = "4"
        codigos(5) = "5"
        codigos(6) = "6"



        Dim nombres() As String = {""}
        Array.Resize(nombres, 7)
        nombres(0) = "HOY : " & Format(lk_fecha_dia, "dd/MM/yyyy")
        fechaini(0) = lk_fecha_dia
        fechafin(0) = lk_fecha_dia

        nombres(1) = "AYER : " & Format(lk_fecha_dia.AddDays(-1), "dd/MM/yyyy")
        fechaini(1) = lk_fecha_dia.AddDays(-1)
        fechafin(1) = lk_fecha_dia.AddDays(-1)

        nombres(2) = "HACE 15 DIAS "
        fechaini(2) = lk_fecha_dia.AddDays(-15)
        fechafin(2) = lk_fecha_dia


        nombres(3) = "PERIODO ACTUAL: " & lk_fecha_dia.ToString("MMMM").ToUpper
        Dim primerDiaMes As Date = New Date(lk_fecha_dia.Year, lk_fecha_dia.Month, 1) ' Fecha del primer día del mes actual
        Dim ultimoDiaMes As Date = New Date(lk_fecha_dia.Year, lk_fecha_dia.Month, Date.DaysInMonth(lk_fecha_dia.Year, lk_fecha_dia.Month)) ' Fecha del último día del mes actual

        fechaini(3) = primerDiaMes
        fechafin(3) = ultimoDiaMes

        Dim mesAnterior As Date = lk_fecha_dia.AddMonths(-1) ' Restar un mes a la fecha actual
        Dim nombreMesAnterior As String = mesAnterior.ToString("MMMM").ToUpper ' Obtener el nombre del mes anterior en letras
        nombres(4) = "PERIODO ANTERIOR : " & nombreMesAnterior

        Dim fechaMesAnterior As Date = lk_fecha_dia.AddMonths(-1) ' Obtener la fecha del mes anterior
        Dim primerDiaMesAnterior As Date = New Date(fechaMesAnterior.Year, fechaMesAnterior.Month, 1) ' Fecha del primer día del mes anterior
        Dim ultimoDiaMesAnterior As Date = New Date(fechaMesAnterior.Year, fechaMesAnterior.Month, Date.DaysInMonth(fechaMesAnterior.Year, fechaMesAnterior.Month)) ' Fecha del último día del mes anterior
        fechaini(4) = primerDiaMesAnterior
        fechafin(4) = ultimoDiaMesAnterior

        nombres(5) = "A UNA FECHA..."
        fechaini(5) = lk_fecha_dia
        fechafin(5) = lk_fecha_dia

        nombres(6) = "RANGO FECHAS..."
        fechaini(6) = lk_fecha_dia
        fechafin(6) = lk_fecha_dia




        Dim menu As New ContextMenuStrip()
        menu.BackColor = PanelListarOper.BackColor
        menu.ForeColor = Color.White

        For i As Integer = 0 To codigos.Length - 1
            Dim wcodigo As String = codigos(i)
            Dim wnombre As String = nombres(i)
            Dim wfechaini As Date = fechaini(i)
            Dim wfechafin As Date = fechafin(i)


            Dim item As New ToolStripMenuItem(wnombre)
            item.Tag = codigo ' Puedes asignar el código como valor de la propiedad Tag del elemento de menú

            ' Agregar un controlador de eventos para el evento Click del elemento de menú
            AddHandler item.Click, Sub()
                                       ' Acción a realizar cuando se hace clic en el elemento de menú
                                       'Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
                                       '     Dim selectedCodigo As String = menuItem.Tag.ToString()

                                       ' Llamar al procedimiento con los parámetros
                                       MuestraDatosparaFiltrar(wcodigo, wnombre, wfechaini, wfechafin)
                                   End Sub



            menu.Items.Add(item)
        Next
        menu.Show(CmdFiltroPeriodo, New Point(0, CmdFiltroPeriodo.Height))
    End Sub
    Private Sub MuestraDatosparaFiltrar(wcodigo As String, wdescripcion As String, wfechaini As Date, wfechafin As Date)
        CmdFiltroPeriodo.Text = wdescripcion
        CmdFiltroPeriodo.Tag = wcodigo
        Inv_fechaini.Value = wfechaini
        Inv_fechafin.Value = wfechafin
        dg_Inventario.Columns.Clear()
        dg_kardex.Columns.Clear()

        If wcodigo = 5 Or wcodigo = 6 Then
        Else
            CmdMostrarInventario_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub CmdAlmTransf_Click(sender As Object, e As EventArgs) Handles CmdAlmTransf.Click

        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_negocio = " & lk_NegocioActivo.id_Negocio & "")

        If DatoAlmacen.Length = 0 Then
            Result = MensajesBox.Show("No Tiene almacenes con acceso.",
                                     "Operación.")
            Exit Sub
        End If

        'Crear un ContextMenuStrip para mostrar el menú flotante
        Dim menu As New ContextMenuStrip()
        menu.BackColor = System.Drawing.ColorTranslator.FromHtml(strColorLogin)
        menu.ForeColor = Color.White
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In DatoAlmacen
            Dim id As Integer = CInt(row("id_almacen"))
            Dim detalle As String = CStr(row("alm_codigo") & " " & row("alm_abreviado") & " - " & row("alm_nombre"))
            Dim codigo As String = CStr(row("alm_codigo"))
            Dim abreviado As String = row("alm_abreviado").ToString.Trim

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       Mostrar_AlmTrasnsferencia(id, detalle, codigo, abreviado)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdAlmTransf, New Point(0, CmdAlmTransf.Height))
    End Sub
    Private Sub Mostrar_AlmTrasnsferencia(id As Integer, detalle As String, codigo As String, abreviado As String)
        TxtAlmTransf.Text = codigo
        TxtAlmTransf.Tag = id

        CmdAlmTransf.Text = codigo.ToString.Trim & " " & abreviado
        CmdAlmTransf.Tag = id


    End Sub

    Private Sub TxtAlmTransf_TextChanged(sender As Object, e As EventArgs) Handles TxtAlmTransf.TextChanged

    End Sub

    Private Sub TxtAlmTransf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAlmTransf.KeyPress
        Solo_Numero(e)

        If e.KeyChar = Chr(13) Then
            If MostrarDatosAlmacenTransf(TxtAlmTransf.Text) = False Then
                Dim Result As String = MensajesBox.Show("Codigo de Almacen No Existe
",
                                         "Almacenes.")
                TxtAlmTransf.SelectAll()
                Exit Sub
            End If
        End If
    End Sub
    Private Function MostrarDatosAlmacenTransf(wcodigo As String) As Boolean
        MostrarDatosAlmacenTransf = True

        Dim DatoAlmacen() As DataRow = lk_sql_Usuario_almacen.Select("id_negocio = " & lk_NegocioActivo.id_Negocio & " and alm_codigo = " & wcodigo & "")
        If DatoAlmacen.Length = 0 Then
            MostrarDatosAlmacenTransf = False
        Else
            TxtAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim
            TxtAlmTransf.Tag = DatoAlmacen(0)("id_almacen")
            CmdAlmTransf.Text = DatoAlmacen(0)("alm_codigo").ToString.Trim & " " & DatoAlmacen(0)("alm_abreviado").ToString.Trim
            CmdAlmTransf.Tag = DatoAlmacen(0)("id_almacen")

        End If


    End Function

    Private Sub dg_kardex_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_kardex.CellClick


        Dim columnName As String = dg_kardex.Columns(e.ColumnIndex).Name ' Obtener el nombre de la columna actual

        If columnName = "verdetalle" Then GoTo IrComprobante
        If e.RowIndex < 0 Then Exit Sub
        Dim wsignok As Integer = Val(dg_kardex.Rows(e.RowIndex).Cells("signo_kardex").Value)
        If columnName = "lote" Then
            If dg_kardex.Rows(e.RowIndex).Cells("dt_loteser_det").Value = "" Then Exit Sub
            If dg_Inventario.CurrentCell Is Nothing Then Exit Sub
            Dim wfil As Integer = dg_Inventario.CurrentCell.RowIndex

            MuestraLotes(wsignok, dg_kardex.Rows(e.RowIndex).Cells("dt_loteser_det").Value, wfil)
        End If




        Exit Sub
IrComprobante:
        If Val(dg_kardex.Rows(e.RowIndex).Cells("id_oper_maestro").Value) = 0 Then Exit Sub
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
        frMenuOperacion.ENLACE_MUESTRA_id_oper_maestro = Val(dg_kardex.Rows(e.RowIndex).Cells("id_oper_maestro").Value)
        frMenuOperacion.ENLACE_MUESTRA_id_comp_cabe = Val(dg_kardex.Rows(e.RowIndex).Cells("id_comp_cab").Value)
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



    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
    Private Sub MuestraLotes(wsigno_kardex As Integer, wdetalle_lote As String, wRowInv As Integer)

        Dim wcodigo As String = dg_Inventario.Rows(wRowInv).Cells("Codigo").Value
        Dim wnombre As String = dg_Inventario.Rows(wRowInv).Cells("producto").Value
        Dim wunidad As String = dg_Inventario.Rows(wRowInv).Cells("unidad").Value



        Dim frlote As New FrmLoteOper
        frlote.Tag = 100
        frlote.ModoBusqeuda = "PROCESOS"

        frlote.LOTE_ID_PROD_NOMBRE = wcodigo + " -  " + wnombre
        frlote.LOTE_CANTIDAD_LOTE = 0
        frlote.LOTE_CANTIDAD_PRES = wunidad
        frlote.LOTE_ID_PROD_MAE = 0
        frlote.LOTE_ID_LOCAL = 0
        frlote.LOTE_ID_ALMACEN = 0
        frlote.LOTE_EQUIV_PRES = 0

        frlote.LOTE_CADENALOTES = wdetalle_lote

        frlote.LOTE_ID_PRES_BASE = 0
        frlote.LOTE_ABREVIADO_BASE = ""
        frlote.LOTE_EQUIV_BASE = 0
        frlote.LOTE_ES_BLOQUEADO = 1

        If wsigno_kardex = 1 Then
            frlote.TipoRegistro = "INGRESO"
        Else
            frlote.TipoRegistro = "SALIDA"
        End If
        ' frlote.TextoBusca = valorlote
        If frlote.ShowDialog() = DialogResult.OK Then

        End If
    End Sub
    Private Sub TxtSN_TextChanged(sender As Object, e As EventArgs) Handles TxtSN.TextChanged
        Dim idgrid As Integer

        If Len(TxtSN.Text) = 3 Then
            If Not IsNumeric(TxtSN.Text) Then

                Dim frbusca As New FrmMenuConfigurar
                '  frbusca.LblEtiqueta.Text = Trim(DirectCast(sender, Button).Text)
                ' frbusca.LblEtiqueta.Tag = DirectCast(sender, Button).Tag.ToString()
                'Dim tamaño As Rectangle = My.Computer.Screen.Bounds
                'frbusca.Left = (Me.Left) + 220
                'frbusca.Top = (Me.Top) + 120
                frbusca.TxtCodigo.Tag = 100
                frbusca.TxtBuscar.Tag = TxtSN.Text
                frbusca.ShowDialog()
                Dim id_sn As Integer = frbusca.DataGridResul.Rows(idgrid).Cells("id_sn_maestro").Value.ToString()
                Dim codigo_snn As String = frbusca.DataGridResul.Rows(idgrid).Cells("codigo").Value.ToString() & " " & frbusca.DataGridResul.Rows(idgrid).Cells("razonsocial").Value.ToString()

                idgrid = Val(frbusca.CmdBuscar.Tag)
                If idgrid <> -1 Then
                    Try
                        add_flow(FlowSN, id_sn, codigo_snn)
                        'info_SN.Text = frbusca.DataGridResul.Rows(idgrid).Cells("boxsn").Value.ToString()
                        'info_SN.Tag = frbusca.DataGridResul.Rows(idgrid).Cells("id_sn_maestro").Value.ToString()
                        'info_SN.Tag = frbusca.DataGridResul.Rows(idgrid).Cells("id_sn_maestro").Value.ToString()
                        TxtSN.Text = "" '  frbusca.DataGridResul.Rows(idgrid).Cells("codigo").Value.ToString() & " " & frbusca.DataGridResul.Rows(idgrid).Cells("razonsocial").Value.ToString()
                    Catch

                    End Try
                End If

                frbusca.Close()
                'BuscaProductos = False
            End If
        End If
    End Sub
    Private Sub add_flow(cntFlow As FlowLayoutPanel, id_control As Integer, descrip As String)
        Dim btn As New Button()
        Dim btnQuitar As New Button()
        Dim textB As String
        For i = 0 To cntFlow.Controls.Count - 1
            If cntFlow.Controls.Item(i).Tag = id_control Then
                Exit Sub
            End If
        Next

        'IconButton1.Tag = ComboBox4.SelectedIndex
        With btn
            .Tag = id_control
            .Name = id_control
            Me.ToolTipBotones.SetToolTip(btn, descrip.ToString.Trim)
            textB = Strings.Left(descrip, 10)
            .Text = textB
            .FlatStyle = FlatStyle.Flat
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.TopLeft
            .Font = New Font(New FontFamily("Microsoft Sans Serif"), 7)
            .Width = 90
        End With
        With btnQuitar
            .Tag = id_control
            .Name = id_control
            Me.ToolTipBotones.SetToolTip(btn, descrip.ToString.Trim)
            textB = "X"
            .Text = textB
            .FlatStyle = FlatStyle.Flat
            .ForeColor = Color.White
            .TextAlign = ContentAlignment.TopCenter
            .Font = New Font(New FontFamily("Microsoft Sans Serif"), 10)
            .Width = 20
        End With

        AddHandler btnQuitar.Click, AddressOf ButtonX_SN_Click   ' Asocias el evento al método Button_Click
        cntFlow.Controls.Add(btn)  ' Agregas el botón al formulario.
        cntFlow.Controls.Add(btnQuitar)  ' Agregas el botón al formulario.
    End Sub

    Private Sub ButtonX_SN_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim c As Control

        For Each c In FlowSN.Controls
            If c.Tag = CType(sender, System.Windows.Forms.Button).Tag Then
                FlowSN.Controls.Remove(c)
                Exit For
            End If
        Next
        For Each c In FlowSN.Controls
            If c.Tag = CType(sender, System.Windows.Forms.Button).Tag Then
                FlowSN.Controls.Remove(c)
                Exit For
            End If
        Next





    End Sub

    Private Sub TxtSN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSN.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If TxtSN.Text = "" Then Exit Sub
            Busca_DatoSocioN_Box(TxtSN.Text)
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
        sql_cade = "SELECT id_sn_maestro,codigo,   razonsocial , comercial  FROM [dbo].[vw_snegocio] where codigo = '" & wcadena & "' or numero= '" & wcadena & "'"
        sql_result = New DataTable()
        command = New SqlCommand(sql_cade, lk_connection_cuenta)
        adaptador = New SqlDataAdapter(command)
        adaptador.Fill(sql_result)
        If sql_result.Rows.Count = 0 Then
            ' detectar la cantidad de digitos de digitado
            If whacebusAdd = False Then
                Result = MensajesBox.Show("Codigo no Existe, Intente en buscar en la lista.",
                                         "Socio de Negocio.")
                TxtSN.SelectAll()
                Exit Sub
            End If
            Exit Sub
        Else
CreaEncontroSN:
            'info_SN.Text = sql_result.Rows(0).Item("razonsocial").ToString
            TxtSN.Tag = sql_result.Rows(0).Item("id_sn_maestro").ToString
            Dim id_sn As Integer = sql_result.Rows(0).Item("id_sn_maestro").ToString
            Dim codigo_snn As String = sql_result.Rows(0).Item("codigo").ToString & " " & sql_result.Rows(0).Item("razonsocial").ToString
            add_flow(FlowSN, id_sn, codigo_snn)
            TxtSN.Text = "" ' 
            ' SaltoBox(BoxSocioNego.AccessibleName)
        End If




    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

    End Sub

    Private Sub dg_kardex_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dg_kardex.CellFormatting
        Dim RosadoPastel As String = "#c6c6c6" ' Color en formato ARGB (Alpha, Red, Green, Blue)
        If e.RowIndex >= 0 Then ' Verificar que no se esté formateando la fila de encabezados

            ' Obtener el valor de la columna "dt_es_costeo" de la fila actual
            Dim dtEsCosteo As Integer = Val(dg_kardex.Rows(e.RowIndex).Cells("dt_es_costeo").Value)
            Dim dtestado As Integer = Val(dg_kardex.Rows(e.RowIndex).Cells("estado").Value)

            ' Verificar si la condición se cumple (dt_es_costeo = 1)
            If dtEsCosteo = 1 Then
                ' Resaltar toda la fila en negrita
                e.CellStyle.Font = New Font(dg_kardex.Font, FontStyle.Bold)
            Else
                ' Restaurar el estilo de la fila a la configuración predeterminada (no negrita)
                e.CellStyle.Font = New Font(dg_kardex.Font, FontStyle.Regular)
            End If
            If dtestado = 10 Then
                e.CellStyle.BackColor = Color.FromArgb(255, System.Drawing.ColorTranslator.FromHtml(RosadoPastel))
            Else
                e.CellStyle.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub CmdIniciarOper_Click(sender As Object, e As EventArgs) Handles CmdIniciarOper.Click
        PanelSN.Visible = False
        PanelEnLinea.Visible = True
        PanelInventario.Visible = False
        PanelEnLinea.Dock = DockStyle.Fill
        llama_info_kpi()

        Gric_KPI(dt_kpi, 1, 0, 0)
        Gric_KPI(dt_kpi_comercial, 2, 0, 0)
        Gric_KPI(dt_kpi_sn, 3, 0, 0)

        Gric_KPI(dt_hoy, 4, 1, 1)
        Gric_KPI(dt_sem, 5, 1, 1)
        Gric_KPI(dt_mes, 6, 1, 1)

        Gric_KPI_Indicadores(dt_ind, "VXA", 90, 91)

        Gric_KPI_User(dt_user, "H")

        'PintarProgresoEnCelda(dt_kpi, 2, 4, 75)

        '' Agregar un ProgressBar a la celda
        'Dim progressBar As New ProgressBar()
        'progressBar.Minimum = 0
        'progressBar.Maximum = 100
        'progressBar.Value = 75
        '' Colocar el ProgressBar en la celda
        'dt_kpi.Controls.Add(progressBar)
        'progressBar.Bounds = dt_kpi.GetCellDisplayRectangle(2, 1, False)
        'progressBar.BringToFront()




    End Sub

    Private Sub llama_info_kpi()
        DT_Matrix_KPIs.Rows.Clear()
        Dim sql As String = "exec [sp_mustra_KPI] @id_negocio"
        Dim command As New SqlCommand(sql, lk_connection_cuenta)

        command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        Dim adapter As New SqlDataAdapter(command)
        adapter.Fill(DT_Matrix_KPIs)


        sql = "exec [CalculoUtilidadCaida] @id_negocio"
        Dim command_util As New SqlCommand(sql, lk_connection_cuenta)
        command_util.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        ' Crear un nuevo SqlDataAdapter y llenar el DataTable con los resultados del segundo procedimiento almacenado
        Dim adapterAgregar As New SqlDataAdapter(command_util)
        adapterAgregar.Fill(DT_Matrix_KPIs)



    End Sub
    Private Sub Gric_KPI(dt_grid As DataGridView, wtipo As String, wes_importes As Integer, wes_un_valor As Integer)
        Dim wid_local As String = ""
        Dim wid_kpi As Integer = 0

        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim wEtiqueta As String = ""
        Dim ws_valor_ant As Double = 0
        Dim ws_valor_act As Double = 0
        Dim ws_valor_porc As Double = 0

        If wtipo = "1" Then
            wEtiqueta = "INVENTARIO"
        ElseIf wtipo = "2" Then
            wEtiqueta = "PRODUCTOS"
        ElseIf wtipo = "3" Then
            wEtiqueta = "CLIENTES"
        ElseIf wtipo = "4" Then
            wEtiqueta = "DE HOY"
        ElseIf wtipo = "5" Then
            wEtiqueta = "DE LA SEMANA"
        ElseIf wtipo = "6" Then
            wEtiqueta = "DEL MES"
        End If

        'dt_kpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        dt_grid.Columns.Clear()
        If wes_importes = 1 Then
            dt_grid.DefaultCellStyle.Font = New Font("Segoe UI", 8.5)
        Else
            dt_grid.DefaultCellStyle.Font = New Font("Segoe UI", 8.5)
        End If



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_kpi"
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 25
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "kpi"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = wEtiqueta & Chr(13) & "[DobleClick para detalle..]"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        If wes_importes = 1 Then
            dt_grid.Columns.Item(textoColumn.Name).Width = 130
        Else
            dt_grid.Columns.Item(textoColumn.Name).Width = 150
        End If
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
            If lk_sql_Usuario_local.Rows(I).Item("id_negocio") = lk_NegocioActivo.id_Negocio And lk_sql_Usuario_local.Rows(I).Item("estado_kpi") = 1 Then

                textoColumn = New DataGridViewTextBoxColumn()
                textoColumn.Name = lk_sql_Usuario_local.Rows(I).Item("id_local")
                textoColumn.Tag = ""
                textoColumn.HeaderText = lk_sql_Usuario_local.Rows(I).Item("local_codigo") & Chr(13) & lk_sql_Usuario_local.Rows(I).Item("local_abreviado")
                If wes_importes = 1 Then
                    textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
                    textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
                    textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  ' Alineación hacia la derecha
                Else
                    textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
                    textoColumn.DefaultCellStyle.Format = "#,##0.###" ' Formato de porcentaje
                    textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
                End If

                dt_grid.Columns.Add(textoColumn)
                If wes_importes = 1 Then
                    dt_grid.Columns.Item(textoColumn.Name).Width = 65
                Else
                    dt_grid.Columns.Item(textoColumn.Name).Width = 48
                End If
                ' dt_kpi.Columns.Item(textoColumn.Name).MinimumWidth = 60
                textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
                dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
                dt_grid.Columns.Item(textoColumn.Name).Visible = True
            End If

        Next

        For I = 0 To sql_Indicadores.Rows.Count - 1
            If sql_Indicadores.Rows(I).Item("opcional1") = wtipo Then
                dt_grid.Rows.Add()
                ' dt_grid.Rows(dt_grid.Rows.Count - 1).Height = 26
                dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("id_kpi").Value = sql_Indicadores.Rows(I).Item("id_tb")
                dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("kpi").Value = sql_Indicadores.Rows(I).Item("descripcion").ToString.ToUpper
                wid_kpi = sql_Indicadores.Rows(I).Item("id_tb")
                For j = 2 To dt_grid.Columns.Count - 1
                    wid_local = dt_grid.Columns(j).Name '  dt_grid.Columns(j).HeaderText
                    If wes_un_valor = 1 Then
                        Dim monto As Double = 0
                        Dim rows As DataRow() = DT_Matrix_KPIs.Select("id_local = " & wid_local & " and id_tb_kpi =" & wid_kpi)
                        If rows.Length > 0 Then
                            monto = Convert.ToDecimal(rows(0)("v_act"))
                        End If
                        dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = If(monto = 0, "", monto)
                        dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Tag = sql_Indicadores.Rows(I).Item("abreviado")

                        If sql_Indicadores.Rows(I).Item("id_tb") = 72 Or sql_Indicadores.Rows(I).Item("id_tb") = 77 Or sql_Indicadores.Rows(I).Item("id_tb") = 82 Then ' se hace el calculo de Crecimeinto para indicadores de rango de fechas 
                            dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = ""
                            ws_valor_act = Val(dt_grid.Rows(dt_grid.Rows.Count - 3).Cells(wid_local).Value)
                            ws_valor_ant = Val(dt_grid.Rows(dt_grid.Rows.Count - 2).Cells(wid_local).Value)
                            ws_valor_porc = 0
                            If ws_valor_ant = 0 And ws_valor_act <> 0 Then
                                ws_valor_porc = 100
                            ElseIf ws_valor_ant <> 0 Then
                                ws_valor_porc = ((ws_valor_act - ws_valor_ant) / ws_valor_ant) * 100
                            End If
                            If ws_valor_porc <> 0 Then
                                ' Formatear el valor del cambio porcentual con la flecha en color y tamaño según el cambio
                                Dim formattedValue As String
                                If ws_valor_porc > 0 Then
                                    formattedValue = ws_valor_porc.ToString("0.00") & "% " & Char.ConvertFromUtf32(&H25B2) ' Flecha hacia arriba
                                    ' estrela se ve bien 
                                    'formattedValue = ws_valor_porc.ToString("0.00") & "% " & Char.ConvertFromUtf32(&H2605)
                                    ' ronbo se ve bien
                                    ' formattedValue = ws_valor_porc.ToString("0.00") & "% " & Char.ConvertFromUtf32(&H25C6)
                                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Style.ForeColor = Color.Green ' Color verde
                                ElseIf ws_valor_porc < 0 Then
                                    formattedValue = ws_valor_porc.ToString("0.00") & "% " & Char.ConvertFromUtf32(&H25BC) ' Flecha hacia abajo
                                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Style.ForeColor = Color.Red ' Color rojo
                                Else
                                    formattedValue = ws_valor_porc.ToString("0.00") & "%" ' Sin flecha
                                End If
                                ' Asignar el valor formateado al valor de la celda
                                dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = formattedValue
                            End If
                        Else

                            dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = If(monto = 0, "", monto)
                        End If
                    Else
                        Dim rows As DataRow() = DT_Matrix_KPIs.Select("id_local = " & wid_local & " and id_tb_kpi =" & wid_kpi)
                        Dim wNumProd As Integer = rows.Length

                        Dim formattedValue As String
                        If wNumProd <> 0 Then
                            'formattedValue = wNumProd.ToString("0") & " " & Char.ConvertFromUtf32(&H25CB)

                            formattedValue = wNumProd.ToString("0") & " " & Char.ConvertFromUtf32(&H25C6)
                            dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = formattedValue
                            If sql_Indicadores.Rows(I).Item("abreviado") = "ALERTA" Then
                                dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Style.ForeColor = Color.Red ' Color rojo
                            End If

                        End If
                        ' Asignar el valor formateado al valor de la celda
                        'dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = If(wNumProd = 0, "", wNumProd)
                        dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Tag = sql_Indicadores.Rows(I).Item("abreviado")
                    End If


                Next j
            End If
        Next
        ' desactivar para que el usaurio no pueda ordenar las columnas
        For Each column As DataGridViewColumn In dt_grid.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next


    End Sub


    Private Sub Gric_KPI_Indicadores(dt_grid As DataGridView, wmodokpi As String, wid_kpi_1 As Integer, wid_kpi_2 As Integer)
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim wEtiqueta As String = ""



        'dt_kpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        dt_grid.Columns.Clear()



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_local"
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 0
        dt_grid.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "LOCAL / " & wmodokpi
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 9.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 180
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True


        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "mesactual"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "MES ACT" ' wEtiqueta & Chr(13) & "[DobleClick para detalle..]"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 90
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "mesanterior"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "MES ANT" ' wEtiqueta & Chr(13) & "[DobleClick para detalle..]"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 90
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "crecimiento"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "CREC.%" ' wEtiqueta & Chr(13) & "[DobleClick para detalle..]"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 80
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True



        For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
            If lk_sql_Usuario_local.Rows(I).Item("id_negocio") = lk_NegocioActivo.id_Negocio And lk_sql_Usuario_local.Rows(I).Item("estado_kpi") = 1 Then
                dt_grid.Rows.Add()
                dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("id_local").Value = lk_sql_Usuario_local.Rows(I).Item("id_local")
                dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("local").Value = lk_sql_Usuario_local.Rows(I).Item("local_codigo") & " " & lk_sql_Usuario_local.Rows(I).Item("local_nombre")
                Dim monto As Double = 0
                Dim NroProductos As Integer = 0
                Dim NroDocumentos As Integer = 0
                Dim wvalor_resul As Double = 0
                Dim wvalor_mes_actual As Double = 0
                Dim wvalor_mes_ant As Double = 0
                Dim ws_valor_porc As Double = 0
                Dim rows As DataRow()

                rows = DT_Matrix_KPIs.Select("id_local = " & lk_sql_Usuario_local.Rows(I).Item("id_local") & " and id_tb_kpi = " & wid_kpi_1 & "")
                If rows.Length > 0 Then
                    monto = Convert.ToDecimal(rows(0)("v_act"))
                    NroProductos = Convert.ToInt32(rows(0)("v_ant"))  ' viene del sp nro de productos 
                    NroDocumentos = Convert.ToInt32(rows(0)("id_prod_mae")) ' viene del sp nro de documentos
                End If
                If wmodokpi = "VXA" And NroProductos <> 0 Then
                    wvalor_resul = monto / NroProductos
                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("mesactual").Value = Format(wvalor_resul, "##,##0.00")
                End If
                If wmodokpi = "VXF" And NroDocumentos <> 0 Then
                    wvalor_resul = monto / NroDocumentos
                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("mesactual").Value = Format(wvalor_resul, "##,##0.00")
                End If
                If wmodokpi = "AXF" And NroDocumentos <> 0 Then
                    wvalor_resul = NroProductos / NroDocumentos
                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("mesactual").Value = Format(wvalor_resul, "##,##0.0")
                End If
                If wmodokpi = "VXM2" And NroDocumentos <> 0 Then
                    wvalor_resul = monto / 30 ' HAY Q PONER CAMPO EN TABLA DE LOCAL VALOR FIJO VIENE DE LOCAL 
                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("mesactual").Value = Format(wvalor_resul, "##,##0.00")
                End If

                wvalor_mes_actual = wvalor_resul


                NroProductos = 0
                NroDocumentos = 0
                wvalor_resul = 0
                monto = 0

                rows = DT_Matrix_KPIs.Select("id_local = " & lk_sql_Usuario_local.Rows(I).Item("id_local") & " and id_tb_kpi = " & wid_kpi_2 & "")
                If rows.Length > 0 Then
                    monto = Convert.ToDecimal(rows(0)("v_act"))
                    NroProductos = Convert.ToInt32(rows(0)("v_ant"))  ' viene del sp nro de productos 
                    NroDocumentos = Convert.ToInt32(rows(0)("id_prod_mae")) ' viene del sp nro de documentos
                End If
                If wmodokpi = "VXA" And NroProductos <> 0 Then
                    wvalor_resul = monto / NroProductos
                End If
                If wmodokpi = "VXF" And NroDocumentos <> 0 Then
                    wvalor_resul = monto / NroDocumentos
                End If
                If wmodokpi = "AXF" And NroDocumentos <> 0 Then
                    wvalor_resul = NroProductos / NroDocumentos
                End If
                If wmodokpi = "VXM2" And NroDocumentos <> 0 Then
                    wvalor_resul = monto / 30 ' HAY Q PONER CAMPO EN TABLA DE LOCAL VALOR FIJO VIENE DE LOCAL 
                End If
                If wvalor_resul <> 0 Then
                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("mesanterior").Value = Format(wvalor_resul, "##,##0.00")
                End If
                wvalor_mes_ant = wvalor_resul

                If wvalor_mes_ant = 0 And wvalor_mes_actual <> 0 Then
                    ws_valor_porc = 100
                ElseIf wvalor_mes_ant <> 0 Then
                    ws_valor_porc = ((wvalor_mes_actual - wvalor_mes_ant) / wvalor_mes_ant) * 100
                End If
                If ws_valor_porc <> 0 Then
                    ' Formatear el valor del cambio porcentual con la flecha en color y tamaño según el cambio
                    Dim formattedValue As String
                    If ws_valor_porc > 0 Then
                        formattedValue = ws_valor_porc.ToString("0.00") & "% " & Char.ConvertFromUtf32(&H25B2) ' Flecha hacia arriba
                        dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("crecimiento").Style.ForeColor = Color.Green ' Color verde

                    ElseIf ws_valor_porc < 0 Then

                        formattedValue = ws_valor_porc.ToString("0.00") & "% " & Char.ConvertFromUtf32(&H25BC) ' Flecha hacia abajo
                        dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("crecimiento").Style.ForeColor = Color.Red ' Color rojo
                    Else
                        formattedValue = ws_valor_porc.ToString("0.00") & "%" ' Sin flecha
                    End If
                    ' Asignar el valor formateado al valor de la celda
                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("crecimiento").Value = formattedValue

                End If
            End If
        Next


    End Sub
    Function GenerateRandomNumber(ByVal random As Random, ByVal minValue As Integer, ByVal maxValue As Integer) As Integer
        Return random.Next(minValue, maxValue + 1)
    End Function

    Private Sub CmdActualizar_Click(sender As Object, e As EventArgs) Handles CmdActualizar.Click
        Dim wid_local As Integer = 0
        Dim wid_kpi As Integer = 0

        Dim rows As DataRow() = DT_Matrix_KPIs.Select("id_local = " & wid_local & " and id_tb_kpi =" & wid_kpi)
        Dim wNumProd As Integer = rows.Length




    End Sub

    Private Sub PintarProgresoEnCelda(gridView As DataGridView, rowIndex As Integer, columnIndex As Integer, progressValue As Integer)
        If rowIndex >= 0 AndAlso rowIndex < gridView.RowCount AndAlso columnIndex >= 0 AndAlso columnIndex < gridView.ColumnCount Then
            Dim cellBounds As Rectangle = gridView.GetCellDisplayRectangle(columnIndex, rowIndex, False)
            Dim progressBarBounds As New Rectangle(cellBounds.X, cellBounds.Y, CInt(cellBounds.Width * (progressValue / 100)), cellBounds.Height)

            Using progressBarBrush As New SolidBrush(Color.Blue)
                Using cellGraphics As Graphics = gridView.CreateGraphics()
                    ' Dibujar el fondo del progreso
                    cellGraphics.FillRectangle(progressBarBrush, progressBarBounds)

                    ' Dibujar el contenido de la celda
                    Dim cellStyle As DataGridViewCellStyle = gridView.Rows(rowIndex).Cells(columnIndex).Style
                    TextRenderer.DrawText(cellGraphics, gridView.Rows(rowIndex).Cells(columnIndex).FormattedValue.ToString(), cellStyle.Font, cellBounds, cellStyle.ForeColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)

                    ' Invalidar la celda para actualizar el dibujo
                    gridView.InvalidateCell(columnIndex, rowIndex)

                    cellGraphics.Dispose()
                End Using
            End Using
        End If
    End Sub

    Private Sub dt_kpi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_kpi.CellContentClick

    End Sub

    Private Sub dt_kpi_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dt_kpi.CellFormatting
        pintarGridKey(dt_kpi, e)
    End Sub
    Private Sub pintarGridKey(dtind As DataGridView, e As DataGridViewCellFormattingEventArgs)


        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 2 Then
            Dim tagValue As String = If(dtind.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag IsNot Nothing, dtind.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString(), "")

            If tagValue = "NEGRITA" Then
                If e.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(e.Value.ToString()) Then
                    ' Dim cellValue As Integer
                    'If Integer.TryParse(e.Value.ToString(), cellValue) Then
                    ' If cellValue <> 0 Then
                    ' e.CellStyle.BackColor = Color.FromArgb(255, 255, 191, 191)
                    e.CellStyle.ForeColor = Color.Black
                    e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
                    ' End If
                    ' End If
                End If
            End If
        End If



        'If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 2 Then ' Reemplaza wid_local con el índice de la columna deseada
        '    If e.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(e.Value.ToString()) Then
        '        Dim cellValue As Integer
        '        If Integer.TryParse(e.Value.ToString(), cellValue) Then
        '            If cellValue <> 0 Then
        '                e.CellStyle.BackColor = Color.FromArgb(255, 255, 191, 191) ' Color de fondo rojo pastel
        '                e.CellStyle.ForeColor = Color.Black ' Color de texto negro
        '                e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold) ' Texto en negrita
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub dt_kpi_comercial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_kpi_comercial.CellContentClick

    End Sub

    Private Sub dt_kpi_comercial_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dt_kpi_comercial.CellFormatting
        pintarGridKey(dt_kpi_comercial, e)
    End Sub

    Private Sub dt_kpi_sn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_kpi_sn.CellContentClick

    End Sub

    Private Sub dt_kpi_sn_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dt_kpi_sn.CellFormatting
        pintarGridKey(dt_kpi_sn, e)
    End Sub

    Private Sub dt_hoy_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_hoy.CellContentClick

    End Sub

    Private Sub CmdUhoy_Click(sender As Object, e As EventArgs) Handles CmdUhoy.Click
        Gric_KPI_User(dt_user, "H")

    End Sub
    Private Sub Gric_KPI_User(dt_grid As DataGridView, wtiporango As String) 'wtiporango  =  H oy , S semana M mes 
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim wEtiqueta As String = ""



        'dt_kpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        dt_grid.Columns.Clear()



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "id_usuario"
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 0
        dt_grid.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "usuario"
        textoColumn.Tag = "T"
        If wtiporango = "H" Then
            textoColumn.HeaderText = "USUARIOS" & Chr(13) & "VENTAS HOY " ' wEtiqueta & Chr(13) & "[DobleClick para detalle..]"
        ElseIf wtiporango = "S" Then
            textoColumn.HeaderText = "USUARIOS" & Chr(13) & "SEMANA ACTUAL (L-D)" ' wEtiqueta & Chr(13) & "[DobleClick para detalle..]"
        ElseIf wtiporango = "M" Then
            textoColumn.HeaderText = "USUARIOS" & Chr(13) & "VENTAS MES ACTUAL" ' wEtiqueta & Chr(13) & "[DobleClick para detalle..]"
        End If

        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 250
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        For I = 0 To lk_sql_Usuario_local.Rows.Count - 1
            If lk_sql_Usuario_local.Rows(I).Item("id_negocio") = lk_NegocioActivo.id_Negocio And lk_sql_Usuario_local.Rows(I).Item("estado_kpi") = 1 Then

                textoColumn = New DataGridViewTextBoxColumn()
                textoColumn.Name = lk_sql_Usuario_local.Rows(I).Item("id_local")
                textoColumn.Tag = ""
                textoColumn.HeaderText = lk_sql_Usuario_local.Rows(I).Item("local_codigo") & Chr(13) & lk_sql_Usuario_local.Rows(I).Item("local_abreviado")

                textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
                textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
                textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  ' Alineación hacia la derecha

                dt_grid.Columns.Add(textoColumn)
                dt_grid.Columns.Item(textoColumn.Name).Width = 65

                ' dt_kpi.Columns.Item(textoColumn.Name).MinimumWidth = 60
                textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
                dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
                dt_grid.Columns.Item(textoColumn.Name).Visible = True
            End If

        Next
        ' desactivar para que el usaurio no pueda ordenar las columnas
        For Each column As DataGridViewColumn In dt_grid.Columns
            If column.Index = 0 OrElse column.Index = 1 Then
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            End If
        Next



        Dim wid_local As String

        'Dim ResulDataTable As New DataTable
        'Dim command As SqlCommand = New SqlCommand("select  m_user.id_usuario , m_user.usuario , m_user.nombres, m_user.apellidos from r23_master.DBO.m_usuarios m_user 
        '    inner join r23_master.dbo.acceso_negocio acc_user on (acc_user.id_usuario =m_user.id_usuario and acc_user.id_negocio = 22)", lk_connection_cuenta)
        'Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
        'adapter.Fill(ResulDataTable)

        Dim sql_user As String = "EXEC sp_lista_usuarios_negocio  @id_negocio "
        Dim commanduser As New SqlCommand(sql_user, lk_connection_master)
        Dim ResulDataTable As New DataTable
        commanduser.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        Dim adapteruser As New SqlDataAdapter(commanduser)
        adapteruser.Fill(ResulDataTable)



        Dim sql As String = "EXEC kpi_usuario_periodos  @id_negocio,'" & wtiporango & "' "
        Dim commandreg As New SqlCommand(sql, lk_connection_cuenta)
        Dim DT_USUARIOS_KPIs As New DataTable
        commandreg.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio)
        Dim adapterreg As New SqlDataAdapter(commandreg)
        adapterreg.Fill(DT_USUARIOS_KPIs)


        For I = 0 To ResulDataTable.Rows.Count - 1
            dt_grid.Rows.Add()
            ' dt_grid.Rows(dt_grid.Rows.Count - 1).Height = 26
            dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("id_usuario").Value = ResulDataTable.Rows(I).Item("id_usuario")
            dt_grid.Rows(dt_grid.Rows.Count - 1).Cells("usuario").Value = ResulDataTable.Rows(I).Item("usuario").ToString.ToUpper & " (" & ResulDataTable.Rows(I).Item("nombres").ToString.ToUpper & " " & ResulDataTable.Rows(I).Item("apellidos").ToString.ToUpper & ")"
            For j = 2 To dt_grid.Columns.Count - 1
                wid_local = dt_grid.Columns(j).Name '  dt_grid.Columns(j).HeaderText
                Dim monto As Double = 0
                Dim rows As DataRow() = DT_USUARIOS_KPIs.Select("id_local = " & wid_local & " and id_usuario =" & ResulDataTable.Rows(I).Item("id_usuario"))
                If rows.Length > 0 Then
                    monto = Convert.ToDecimal(rows(0)("suma_total"))
                End If
                'dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = If(monto = 0, "", monto)
                If monto <> 0 Then
                    dt_grid.Rows(dt_grid.Rows.Count - 1).Cells(wid_local).Value = monto
                End If
            Next j

        Next






    End Sub

    Private Sub CmdUSemana_Click(sender As Object, e As EventArgs) Handles CmdUSemana.Click
        Gric_KPI_User(dt_user, "S")

    End Sub

    Private Sub CmdUMes_Click(sender As Object, e As EventArgs) Handles CmdUMes.Click
        Gric_KPI_User(dt_user, "M")
    End Sub

    Private Sub dt_user_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_user.CellContentClick

    End Sub

    Private Sub CmdVxA_Click(sender As Object, e As EventArgs) Handles CmdVxA.Click
        Gric_KPI_Indicadores(dt_ind, "VXA", 90, 91)
    End Sub

    Private Sub CmdVxF_Click(sender As Object, e As EventArgs) Handles CmdVxF.Click
        Gric_KPI_Indicadores(dt_ind, "VXF", 90, 91)
    End Sub

    Private Sub CmdAxF_Click(sender As Object, e As EventArgs) Handles CmdAxF.Click
        Gric_KPI_Indicadores(dt_ind, "AXF", 90, 91)
    End Sub

    Private Sub CmdVxM2_Click(sender As Object, e As EventArgs) Handles CmdVxM2.Click
        Gric_KPI_Indicadores(dt_ind, "VXM2", 90, 91)
    End Sub

    Private Sub dt_hoy_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dt_hoy.CellFormatting
        pintarGridKey(dt_hoy, e)
    End Sub

    Private Sub dt_sem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_sem.CellContentClick

    End Sub

    Private Sub dt_sem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dt_sem.CellFormatting
        pintarGridKey(dt_sem, e)
    End Sub

    Private Sub dt_mes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_mes.CellContentClick

    End Sub

    Private Sub dt_mes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dt_mes.CellFormatting
        pintarGridKey(dt_mes, e)
    End Sub

    Private Sub CmdCierreDetInd_Click(sender As Object, e As EventArgs) Handles CmdCierreDetInd.Click
        PanelEnLinea_Detalle.Visible = False
        PanelEnLinea.Visible = True
    End Sub


    Private Sub dt_kpi_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_kpi.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim wid_local As String = dt_kpi.Columns(e.ColumnIndex).Name
            Dim wtituloind As String = dt_kpi.Rows(e.RowIndex).Cells("kpi").Value
            Dim wid_kpi As String = dt_kpi.Rows(e.RowIndex).Cells("id_kpi").Value

            ''DT_Matrix_KPIs.Select("id_local = " & wid_local & " and id_tb_kpi =" & wid_kpi)
            Muestra_detalle_indicador(dt_kpi, wtituloind, wid_kpi, wid_local)
        End If


    End Sub

    Private Sub dt_kpi_comercial_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_kpi_comercial.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim wid_local As String = dt_kpi.Columns(e.ColumnIndex).Name
            Dim wtituloind As String = dt_kpi_comercial.Rows(e.RowIndex).Cells("kpi").Value
            Dim wid_kpi As String = dt_kpi_comercial.Rows(e.RowIndex).Cells("id_kpi").Value
            Muestra_detalle_indicador(dt_kpi_comercial, wtituloind, wid_kpi, wid_local)
        End If
    End Sub

    Private Sub dt_kpi_sn_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dt_kpi_sn.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim wid_local As String = dt_kpi.Columns(e.ColumnIndex).Name
            Dim wtituloind As String = dt_kpi_sn.Rows(e.RowIndex).Cells("kpi").Value
            Dim wid_kpi As String = dt_kpi_sn.Rows(e.RowIndex).Cells("id_kpi").Value
            '   Muestra_detalle_indicador(dt_kpi, wtituloind, wid_kpi)
        End If

    End Sub
    Private Sub Muestra_detalle_indicador(grid As DataGridView, wtitulo As String, wid_kpi As Integer, wid_local As String)
        PanelEnLinea_Detalle.Visible = True
        PanelEnLinea_Detalle.Dock = DockStyle.Fill
        PanelEnLinea.Visible = False


        Grid_KPI_detalle_producto(dg_lista_productos, "")
        lblInd_det.Text = wtitulo
        '***** OBTENER LISTA DE DETALLE DE PRODUCTOS ASOCIADOS AL INDICADOR
        Dim kw_id_negocio As Integer = 0
        Dim kw_id_local As Integer = 0
        Dim kw_id_kpi As Integer = 0
        Dim kw_id_prod_mae As Integer = 0
        Dim kw_ref As String = ""



        Dim kpi_detalle As New DataTable()
        kpi_detalle.Columns.Add("id_negocio", GetType(Integer))
        kpi_detalle.Columns.Add("id_local", GetType(Integer))
        kpi_detalle.Columns.Add("id_kpi", GetType(Integer))
        kpi_detalle.Columns.Add("id_prod_mae", GetType(Double))
        kpi_detalle.Columns.Add("ref", GetType(String))
        Dim rows As DataRow() = DT_Matrix_KPIs.Select("id_local = " & wid_local & " and id_tb_kpi =" & wid_kpi)
        For Each row As DataRow In rows
            kw_id_negocio = row("id_negocio")
            kw_id_local = row("id_local")
            kw_id_kpi = row("id_tb_kpi")
            kw_id_prod_mae = row("id_prod_mae")
            kw_ref = row("v_ref")
            kpi_detalle.Rows.Add(kw_id_negocio, kw_id_local, kw_id_kpi, kw_id_prod_mae, kw_ref)
        Next



        ' Crea un objeto SqlCommand para el stored procedure
        Using command As New SqlCommand("sp_kpi_lista_detalle", lk_connection_cuenta)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio) ' Reemplaza idNegocio con el valor real

            ' Crea el parámetro de tabla de valores
            Dim param As SqlParameter = command.Parameters.AddWithValue("@Tabla_Productos", kpi_detalle)
            param.SqlDbType = SqlDbType.Structured
            param.TypeName = "dbo.Tipo_producto_lista_kpi" ' Cambia esto al nombre real del tipo de tabla en tu base de datos

            ' Declara la variable reader antes de usarla
            Dim reader As SqlDataReader = Nothing

            ' Verifica si hay un DataReader abierto y ciérralo si es necesario
            If Not reader Is Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If

            ' Ejecuta el comando y obtiene el SqlDataReader
            reader = command.ExecuteReader()

            ' Verifica si hay filas en el resultado
            If reader.HasRows Then
                Dim i As Integer = 0
                While reader.Read()
                    i = i + 1
                    dg_lista_productos.Rows.Add()
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("item").Value = i
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("local").Value = reader.GetString(reader.GetOrdinal("local_codigo")) & " - " & reader.GetString(reader.GetOrdinal("local_abreviado")) & " - " & reader.GetString(reader.GetOrdinal("local_nombre"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("almacen").Value = reader.GetString(reader.GetOrdinal("alm_codigo")) & " - " & reader.GetString(reader.GetOrdinal("alm_abreviado")) & " - " & reader.GetString(reader.GetOrdinal("alm_nombre"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("labo").Value = reader.GetString(reader.GetOrdinal("lab_linea"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("ind").Value = "" '  
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("Codigo").Value = reader.GetString(reader.GetOrdinal("codigo"))

                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("producto").Value = reader.GetString(reader.GetOrdinal("nombreproducto"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("pres_def").Value = reader.GetString(reader.GetOrdinal("abreviado_pres_def"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("stock").Value = reader.GetDecimal(reader.GetOrdinal("stock"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("cospro").Value = reader.GetDecimal(reader.GetOrdinal("costo"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("valorinv").Value = reader.GetDecimal(reader.GetOrdinal("valor"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("fechavta").Value = "" 'reader.GetString(reader.GetOrdinal("producto"))
                    dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("fechacomp").Value = "" ' reader.GetString(reader.GetOrdinal("producto"))



                End While
            End If

            ' Cierra el DataReader al final del bloque Using
            reader.Close()
        End Using



        ' Crea una conexión a la base de datos
        'Using connection As New SqlConnection(lk_connection_cuenta)
        '    connection.Open()

        '' Crea un objeto SqlCommand para el stored procedure
        'Using command As New SqlCommand("sp_kpi_lista_detalle", lk_connection_cuenta)
        '    command.CommandType = CommandType.StoredProcedure
        '    command.Parameters.AddWithValue("@id_negocio", lk_NegocioActivo.id_Negocio) ' Reemplaza idNegocio con el valor real
        '    ' Crea el parámetro de tabla de valores
        '    Dim param As SqlParameter = command.Parameters.AddWithValue("@Tabla_Productos", kpi_detalle)
        '    param.SqlDbType = SqlDbType.Structured
        '    param.TypeName = "dbo.Tipo_producto_lista_kpi" ' Cambia esto al nombre real del tipo de tabla en tu base de datos
        '    ' Ejecuta el comando y obtiene el SqlDataReader
        '    Dim reader As SqlDataReader = command.ExecuteReader()
        '    ' Verifica si hay filas en el resultado
        '    If reader.HasRows Then
        '        While reader.Read()
        '            ' ... Código de procesamiento ...
        '        End While
        '        reader.Close() ' Cierra el DataReader antes de ejecutar otro comando
        '    End If

        '    If reader.HasRows Then
        '            ' Obtiene los índices de las columnas por nombre
        '            Dim i As Integer = 0
        '            While reader.Read()
        '                ' MsgBox(reader.GetString(reader.GetOrdinal("nombreproducto")))
        '                i = i + 1

        '                dg_lista_productos.Rows.Add()
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("item").Value = i
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("local").Value = reader.GetString(reader.GetOrdinal("local_codigo")) & " - " & reader.GetString(reader.GetOrdinal("local_abreviado")) & " - " & reader.GetString(reader.GetOrdinal("local_nombre"))
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("almacen").Value = reader.GetString(reader.GetOrdinal("alm_codigo")) & " - " & reader.GetString(reader.GetOrdinal("alm_abreviado")) & " - " & reader.GetString(reader.GetOrdinal("alm_nombre"))


        '            dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("labo").Value = reader.GetString(reader.GetOrdinal("lab_linea"))
        '            dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("ind").Value = "" '  
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("Codigo").Value = reader.GetString(reader.GetOrdinal("codigo"))

        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("producto").Value = reader.GetString(reader.GetOrdinal("nombreproducto"))
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("pres_def").Value = reader.GetString(reader.GetOrdinal("abreviado_pres_def"))
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("stock").Value = reader.GetDecimal(reader.GetOrdinal("stock"))
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("cospro").Value = reader.GetDecimal(reader.GetOrdinal("costo"))
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("valorinv").Value = reader.GetDecimal(reader.GetOrdinal("valor"))
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("fechavta").Value = "" 'reader.GetString(reader.GetOrdinal("producto"))
        '                dg_lista_productos.Rows(dg_lista_productos.Rows.Count - 1).Cells("fechacomp").Value = "" ' reader.GetString(reader.GetOrdinal("producto"))


        '        End While
        '        reader.Close() ' Cierra el DataReader antes de ejecutar otro comando
        '    End If
        '    End Using



    End Sub
    Private Sub Grid_KPI_detalle_producto(dt_grid As DataGridView, wtiporango As String) 'wtiporango  =  H oy , S semana M mes 
        Dim imageColumn As New DataGridViewImageColumn()
        Dim textoColumn As New DataGridViewTextBoxColumn()
        Dim comboColumn As New DataGridViewComboBoxColumn()
        Dim checkColumn As New DataGridViewCheckBoxColumn()
        Dim BotonColumn As New DataGridViewButtonColumn()
        Dim wEtiqueta As String = ""



        'dt_kpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        dt_grid.Columns.Clear()



        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "item"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ITEM"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 35
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "local"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "LOCAL"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 80
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "almacen"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "ALMACEN"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 80
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "labo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "LAB/GRUPO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 80
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "ind"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "IND"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 60
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = False

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "codigo"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "CODIGO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 70
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "producto"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "DESCRIPCION DEL PRODUCTO"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 250
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "pres_def"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "PRES"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 60
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "stock"
        textoColumn.Tag = ""
        textoColumn.HeaderText = "STOCK"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  ' Alineación hacia la derecha
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 65
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "cospro"
        textoColumn.Tag = ""
        textoColumn.HeaderText = "COSRO PROMED"
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  ' Alineación hacia la derecha
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 65
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "valorinv"
        textoColumn.Tag = ""
        textoColumn.HeaderText = "VALOR INVENT."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        textoColumn.DefaultCellStyle.Format = "#,##0.00" ' Formato de porcentaje
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  ' Alineación hacia la derecha
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 65
        textoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alineación hacia la derecha
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechavta"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "FEC. ULT.VENT."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 80
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True

        textoColumn = New DataGridViewTextBoxColumn()
        textoColumn.Name = "fechacomp"
        textoColumn.Tag = "T"
        textoColumn.HeaderText = "FEC. ULT.COMP."
        textoColumn.HeaderCell.Style.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        textoColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dt_grid.Columns.Add(textoColumn)
        dt_grid.Columns.Item(textoColumn.Name).Width = 80
        dt_grid.Columns.Item(textoColumn.Name).ReadOnly = True
        dt_grid.Columns.Item(textoColumn.Name).Visible = True


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "LOTE"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verlote"
        imageColumn.Image = My.Resources.lote
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dt_grid.Columns.Add(imageColumn)
        dt_grid.Columns.Item(imageColumn.Name).Width = 30
        dt_grid.Columns.Item(imageColumn.Name).ReadOnly = False


        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "PRECIOS"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "verprecios"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dt_grid.Columns.Add(imageColumn)
        dt_grid.Columns.Item(imageColumn.Name).Width = 30
        dt_grid.Columns.Item(imageColumn.Name).ReadOnly = False

        imageColumn = New DataGridViewImageColumn()
        imageColumn.HeaderText = "KARDEX"
        imageColumn.HeaderCell.Style.Font = New Font("Segoe UI", 7.25F, FontStyle.Bold)
        imageColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        imageColumn.Name = "kardex"
        imageColumn.Image = My.Resources.ver
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        dt_grid.Columns.Add(imageColumn)
        dt_grid.Columns.Item(imageColumn.Name).Width = 30
        dt_grid.Columns.Item(imageColumn.Name).ReadOnly = False





    End Sub

    Private Sub Chek_quitar_anul_CheckedChanged(sender As Object, e As EventArgs) Handles Chek_quitar_anul.CheckedChanged

        dg_kardex.Columns.Clear()

        MostrarSelloAgua_kardex = True
        If dg_Inventario.CurrentCell Is Nothing Then Exit Sub
        Dim wfil As Integer = dg_Inventario.CurrentCell.RowIndex
        Dim wid_prod_mae As Integer = Val(dg_Inventario.Rows(wfil).Cells("id_prod_mae").Value)
        If wid_prod_mae = 0 Then Exit Sub

        Dim wenlace_id_negocio As Integer = lk_NegocioActivo.id_Negocio

        Dim id_fila As Integer = wfil
        Dim wequiv_def As Integer = Val(dg_Inventario.Rows(wfil).Cells("equiv_def").Value)

        Muestra_Kardex_INV(wenlace_id_negocio, wid_prod_mae, id_fila, wequiv_def)

    End Sub

    Private Sub LBLIniciar_Click(sender As Object, e As EventArgs) Handles LBLIniciar.Click
        CmdIniciarOper_Click(Nothing, Nothing)
    End Sub
End Class
