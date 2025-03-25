Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices

Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions
Imports WindowsApp1.FrmProductos
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Documents


Public Class FrmReportes

    'Dim caaaaa As Integer
    'Public Property ENLACE_ENVIO_DATA_FILTRO_GRUPO As New DataTable

    Public local_dt_FiltroGrupos As New DataTable()

    Dim dt_listareportes As DataTable

    'Public Sub New()
    '    ' Este llamado es exigido por el diseñador.
    '    InitializeComponent()

    '    ' Habilitar DoubleBuffered para evitar parpadeos
    '    Me.DoubleBuffered = True
    'End Sub

    '' Si tienes otros componentes, asegúrate de dibujar bien
    'Protected Overrides Sub OnPaint(e As PaintEventArgs)
    '    MyBase.OnPaint(e)
    '    ' Aquí puedes realizar tu dibujo si es necesario
    'End Sub


    Private Sub PanelSup_Resize(sender As Object, e As EventArgs) Handles PanelSup.Resize
        Me.Text = ""
        Me.ControlBox = False

    End Sub
    'Drag Form'
    '<DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub



    Private Sub PanelSup_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelSup.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub PanelSup_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelSup.MouseUp
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    ' Evento para manejar el clic en el panel


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


    Private Sub FrmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim command As SqlCommand
        ' Dim adapter As SqlDataAdapter
        Dim grupo_nombre, sub_nombre As String
        Dim idgrupo As Integer
        Dim Label As Integer

        Dim adaptador As SqlDataAdapter
        command = New SqlCommand("sp_lista_reportes_tw", lk_connection_master)
        command.CommandType = CommandType.StoredProcedure
        adaptador = New SqlDataAdapter(command)
        dt_listareportes = New DataTable

        adaptador.Fill(dt_listareportes)


        Dim dt_tempo As DataTable = dt_listareportes.Copy()


        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub
        dt_tempo.DefaultView.Sort = "grupo, sub"
        'Dim filtro As String = ""
        'temp_finanzas.DefaultView.RowFilter = filtro

        Dim dt As DataTable = dt_tempo.DefaultView.ToTable(True, "grupo", "sub", "id_repo")
        Dim nombre1 As String = ""
        Dim node1 As New TreeNode 'crear un nuevo nodo

        Dim subNodeFont As New Font("Arial", 10, FontStyle.Regular)
        Dim maxTextWidth As Integer = 0 ' Para guardar el ancho máximo del texto

        For i = 0 To dt.Rows.Count - 1
            ' dt.Rows(i).Item("fn_codigo")

            grupo_nombre = dt.Rows(i).Item("grupo")
            sub_nombre = dt.Rows(i).Item("sub")

            Dim textWidth As Integer = TextRenderer.MeasureText(sub_nombre, subNodeFont).Width
            maxTextWidth = Math.Max(maxTextWidth, textWidth) ' Guardar el mayor ancho

            If nombre1 = grupo_nombre Then
                twmenus.SelectedNode.Nodes.Add(sub_nombre).Tag = dt.Rows(i).Item("id_repo").ToString()

            Else
                nombre1 = grupo_nombre
                node1 = twmenus.Nodes.Add(grupo_nombre)
                twmenus.SelectedNode = node1
                twmenus.SelectedNode.Nodes.Add(sub_nombre).Tag = dt.Rows(i).Item("id_repo").ToString()

            End If


        Next
        ' Ajustar el ancho del TreeView según el mayor ancho de texto
        twmenus.Width = maxTextWidth + 50 ' Añadir un margen adicional para que el texto no se corte

        ' Expandir todos los nodos para que sean visibles
        twmenus.ExpandAll()
        ' Verificar si el TreeView tiene nodos
        If twmenus.Nodes.Count > 0 Then
            ' Expandir el primer nodo
            twmenus.Nodes(0).Expand()
        End If

        ' iniciar con el label limpio
        btn_max.Visible = False
        lbtitulo.Text = ""
        Dim Result As String
        Dim grupos As New List(Of String)()
        Dim menu_SubOper As New ToolStripDropDownMenu()
        ' If Val(CmdLocal.Tag) = 0 Then Exit Sub

        Dim ListaListaLocales() As DataRow = lk_sql_Locales_Activos.Select("id_local <> 0 and  id_usuario = " & lk_id_usuario & " ")
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
        'Agregar un elemento de menú para cada fila de la variable
        For Each row As DataRow In ListaListaLocales
            Dim id As Integer = CInt(row("id_local"))
            Dim detalle As String = CStr(row("codigo") & " " & row("nombre"))
            Dim descrip As String = CStr(row("nombre"))
            Dim codigo As String = CStr(row("codigo"))
            checkboxlist_locales.Items.Add(detalle & Space(100) & id)
        Next

        local_dt_FiltroGrupos.Columns.Clear()
        local_dt_FiltroGrupos.Columns.Add("descripcion", GetType(String))
        local_dt_FiltroGrupos.Columns.Add("id_tipo_prod", GetType(Integer))
        local_dt_FiltroGrupos.Columns.Add("id_tbp_estru_id", GetType(Integer))
        local_dt_FiltroGrupos.Columns.Add("id_tbp_id", GetType(Integer))

    End Sub
    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged

        ' Limpiar cualquier color anterior en todos los nodos
        ClearTreeNodeColors(twmenus.Nodes)

        ' Obtener el texto del TextBox
        Dim searchText As String = txtbuscar.Text.Trim()

        ' Si el TextBox no está vacío, proceder con la búsqueda
        If searchText <> "" Then
            Dim foundNode As TreeNode = FindAndHighlightNodes(twmenus.Nodes, searchText)

            ' Si se encontró un nodo, seleccionarlo y asegurarse de que sea visible
            If foundNode IsNot Nothing Then
                twmenus.SelectedNode = foundNode
                foundNode.EnsureVisible() ' Asegura que el nodo sea visible
            End If
        End If


    End Sub

    ' Función recursiva para buscar y resaltar el nodo si coincide
    Private Function FindAndHighlightNodes(nodes As TreeNodeCollection, searchText As String) As TreeNode
        For Each node As TreeNode In nodes
            ' Si el nodo contiene el texto buscado
            If node.Text.ToLower().Contains(searchText.ToLower()) Then
                node.BackColor = Color.Yellow ' Resaltar el nodo en amarillo
                Return node ' Devuelve el nodo encontrado
            End If

            ' Buscar de forma recursiva en los nodos hijos
            If node.Nodes.Count > 0 Then
                Dim foundNode As TreeNode = FindAndHighlightNodes(node.Nodes, searchText)
                If foundNode IsNot Nothing Then
                    Return foundNode ' Devolver el nodo encontrado
                End If
            End If
        Next
        Return Nothing ' No se encontró el nodo
    End Function

    ' Función para limpiar el color de todos los nodos del TreeView
    Private Sub ClearTreeNodeColors(nodes As TreeNodeCollection)
        For Each node As TreeNode In nodes
            node.BackColor = Color.White ' Restablecer el color de fondo a blanco
            node.ForeColor = Color.Black ' Restablecer el color de texto a negro

            ' Limpiar también los nodos hijos de forma recursiva
            If node.Nodes.Count > 0 Then
                ClearTreeNodeColors(node.Nodes)
            End If
        Next
    End Sub


    Private Sub CmdFiltroPeriodo_Click(sender As Object, e As EventArgs) Handles CmdFiltroPeriodo.Click

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
        menu.BackColor = Color.FromArgb(36, 151, 148)
        menu.ForeColor = Color.White

        For i As Integer = 0 To codigos.Length - 1
            Dim wcodigo As String = codigos(i)
            Dim wnombre As String = nombres(i)
            Dim wfechaini As Date = fechaini(i)
            Dim wfechafin As Date = fechafin(i)

            Dim item As New ToolStripMenuItem(wnombre)
            item.Tag = codigos ' Puedes asignar el código como valor de la propiedad Tag del elemento de menú

            ' Agregar un controlador de eventos para el evento Click del elemento de menú
            AddHandler item.Click, Sub()
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
        'dg_Inventario.Columns.Clear()
        'dg_kardex.Columns.Clear()

        'If wcodigo = 5 Or wcodigo = 6 Then
        'Else
        '    CmdMostrarInventario_Click(Nothing, Nothing)
        'End If

    End Sub

    Private Sub twmenus_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles twmenus.AfterSelect

        If e.Node.Nodes.Count = 0 Then
            ' Cambiar el texto del label al nombre del nodo seleccionado
            lbtitulo.Text = e.Node.Text
            btn_max.Visible = True
            id_reporte.Visible = True
        Else
            ' Si es un nodo padre, mantener el Label vacío
            lbtitulo.Text = ""
            btn_max.Visible = False
            id_reporte.Visible = False
        End If

        id_reporte.Tag = 0

        ' Verificar si el nodo tiene un ID en la propiedad Tag
        If e.Node.Tag IsNot Nothing Then

            BoxFechaEmision.Enabled = False
            BoxLocales.Enabled = False
            BoxAlmacen.Enabled = False
            BoxGrupoFiltros.Enabled = False
            creporte.ReportSource = Nothing
            creporte.Refresh()

            For i As Integer = 0 To dt_listareportes.Rows.Count - 1

                If Val(dt_listareportes(i)("id_repo")) = Val(e.Node.Tag) Then
                    If Val(dt_listareportes(i)("id_filtro")) = 1 Then
                        BoxFechaEmision.Enabled = True
                    End If
                    If Val(dt_listareportes(i)("id_filtro")) = 2 Then
                        BoxLocales.Enabled = True
                    End If
                    If Val(dt_listareportes(i)("id_filtro")) = 3 Then
                        BoxAlmacen.Enabled = True
                    End If
                    If Val(dt_listareportes(i)("id_filtro")) = 4 Then
                        BoxGrupoFiltros.Enabled = True
                    End If

                End If
            Next
            id_reporte.Text = "ID REPORTE(CR): 00" & e.Node.Tag
            id_reporte.Tag = e.Node.Tag
        End If

    End Sub


    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click

        ' Verificar si todos los paneles están deshabilitados
        ' If Not BoxFechaEmision.Enabled AndAlso Not BoxLocales.Enabled AndAlso Not BoxAlmacen.Enabled Then
        ' Si todos los paneles están deshabilitados, no hacer nada
        ' MessageBox.Show("Todos los paneles están deshabilitados. No se puede ejecutar la acción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ' Return ' Salir del evento sin hacer nada
        ' End If

        '-------------
        ' Obtener los valores de los DateTimePickers y el parámetro adicional
        'Dim fechaInicio As DateTime = Inv_fechaini.Value
        'Dim fechaFin As DateTime = Inv_fechafin.Value
        'Dim parametroConsulta As String = txtParametro.Text ' Aquí obtienes el parámetro adicional de un TextBox


        Dim ws_nombresp As String
        Dim ws_nombrespcab As String
        Dim ws_iddataSet As String
        creporte.ReportSource = Nothing
        creporte.Refresh()
        Dim Result As String


        '*******************************************************************************************************
        ' Llamar al método que ejecuta el procedimiento almacenado y obtiene los datos
        For i As Integer = 0 To dt_listareportes.Rows.Count - 1
            If Val(dt_listareportes(i)("id_repo")) = Val(id_reporte.Tag) Then
                ws_nombresp = dt_listareportes(i)("nombre_sp")
                ws_nombrespcab = dt_listareportes(i)("nombre_sp_cabecera")
                ws_iddataSet = dt_listareportes(i)("id_dataset")

                ' Verificar si falta información en el nombre del procedimiento almacenado o el dataset
                If ws_nombresp.ToString.Trim() = "" Or ws_iddataSet.ToString.Trim() = "" Then
                    Result = MensajesBox.Show("Reporte NO Tiene Definicion de Informacion (sp /id_dataset).", "Reportes")
                    Exit For  ' Termina el bucle si falta la información
                End If

                ' Continuar con el proceso si los valores son correctos
                Dim dtGf As New DataTable()
                Dim cmd As SqlCommand
                'Dim sql_cade As String
                Dim parametro As New SqlParameter
                'Dim adaptador As SqlDataAdapter

                Dim sql_cade As String = ws_nombresp  ' Asigna el nombre del procedimiento almacenado
                cmd = New SqlCommand(sql_cade, lk_connection_cuenta)
                cmd.CommandType = CommandType.StoredProcedure  ' Indica que es un procedimiento almacenado


                ' *------------- 
                Dim wid_almacen As Integer = Val(CmdAlmTransf.Tag)
                Dim id_local As Integer = Val(CmdAlmTransf.AccessibleName)



                ' Añadir los parámetros
                cmd.Parameters.Add(New SqlParameter("@id_negocio", SqlDbType.Int)).Value = lk_NegocioActivo.id_Negocio
                cmd.Parameters.Add(New SqlParameter("@id_dataset", SqlDbType.VarChar)).Value = ws_iddataSet
                cmd.Parameters.Add(New SqlParameter("@id_almacen", SqlDbType.VarChar)).Value = wid_almacen ' lk_AlmacenActivo.id_almacen
                cmd.Parameters.Add(New SqlParameter("@id_local", SqlDbType.VarChar)).Value = id_local ' lk_LocalActivo.id_local

                parametro = New SqlParameter("@TablaTemporalGrupos", SqlDbType.Structured)
                parametro.TypeName = "dbo.Lista_FiltroGrupos_Prod_e2"  ' Especifica el tipo de tabla en SQL
                parametro.Value = local_dt_FiltroGrupos  ' El DataTable que quieres pasar
                cmd.Parameters.Add(parametro)
                ' Ejecutar el comando y llenar el DataTable
                Dim adaptador As New SqlDataAdapter(cmd)
                adaptador.Fill(dtGf)

                '********************************** cabecera *
                Dim dtGf2 As New DataTable()
                Dim cmd2 As SqlCommand
                'Dim sql_cade As String
                Dim parametro2 As New SqlParameter
                'Dim adaptador As SqlDataAdapter

                Dim sql_cade2 As String = ws_nombrespcab  ' Asigna el nombre del procedimiento almacenado
                cmd2 = New SqlCommand(sql_cade2, lk_connection_cuenta)
                cmd2.CommandType = CommandType.StoredProcedure  ' Indica que es un procedimiento almacenado

                ' Añadir los parámetros
                cmd2.Parameters.Add(New SqlParameter("@id_negocio", SqlDbType.Int)).Value = lk_NegocioActivo.id_Negocio
                cmd2.Parameters.Add(New SqlParameter("@id_reporte", SqlDbType.VarChar)).Value = Val(id_reporte.Tag)
                ' Ejecutar el comando y llenar el DataTable
                Dim adaptador2 As New SqlDataAdapter(cmd2)
                adaptador2.Fill(dtGf2)
                ' MsgBox(dtGf2.Rows.Count)
                ' Cargar el reporte
                Dim report As New ReportDocument()
                Dim wruta_reporte As String = LK_RUTA_RPT_REPORTES & "id" & Format(Val(id_reporte.Tag), "000") & ".rpt"


                Dim dataSet As New DataSet()
                dtGf.TableName = "id_DataSet01"
                dtGf2.TableName = "datacabecera01"

                dataSet.Tables.Add(dtGf)  ' Primer DataTable
                dataSet.Tables.Add(dtGf2) ' Segundo DataTable



                If File.Exists(wruta_reporte) Then
                    report.Load(wruta_reporte)
                    ' Asignar el DataTable como fuente de datos del reporte
                    report.SetDataSource(dataSet)
                    'report.SetDataSource(dtGf)
                    'report.SetDataSource(dtGf2)
                    ' report.SetDataSource(dtGf)
                    creporte.ReportSource = report
                    creporte.Refresh()
                Else
                    Result = MensajesBox.Show("El Archivo de Reporte no se encuentra en la ruta:  " & wruta_reporte, "Reportes")
                End If

                Exit For  ' Salir del bucle ya que hemos encontrado y procesado el reporte correcto
            End If
        Next



    End Sub


    Private Function Obtener_DataSet01(wid_negocio As Integer, wid_dataSet As Integer) As DataTable
        Dim dt As New DataTable()
        Dim cmd As SqlCommand

        cmd = New SqlCommand("sp_report_inventario", lk_connection_cuenta)
        cmd.CommandType = CommandType.StoredProcedure

        ' Pasar los parámetros al procedimiento almacenado
        cmd.Parameters.AddWithValue("@id_negocio", wid_negocio)
        cmd.Parameters.AddWithValue("@id_dataset", wid_dataSet)

        ' Ejecutar el comando y llenar el DataTable
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)

        Return dt
    End Function
    ' Método para mostrar el reporte en Crystal Reports


    Private Sub btn_max_Click(sender As Object, e As EventArgs) Handles btn_max.Click
        Dim view_Reporte As New ViewReporte()
        '  Dim reporte1 As New CrystalReport1()
        'creporte.ReportSource = view_Reporte
        view_Reporte.SetReporte(creporte.ReportSource)

        ' Pasar el texto del nodo seleccionado del TreeView al Label del segundo formulario
        If twmenus.SelectedNode IsNot Nothing Then
            view_Reporte.SetTreeViewLabel(twmenus.SelectedNode.Text)
        End If

        'Mostrar el nuevo form
        view_Reporte.Show()

        view_Reporte.TopLevel = False
        panel_principal.Controls.Add(view_Reporte)
        'view_Reporte.WindowState = FormWindowState.Maximized

        view_Reporte.Left = 4
        view_Reporte.Top = 10

        panel_principal.Controls.Item(panel_principal.Controls.Count - 1).BringToFront() ' Ultimo Fomulario a primer plano
        SelectNextControl(ActiveControl, True, True, True, True)
        view_Reporte.Focus()

        creporte.ReportSource = Nothing
        creporte.RefreshReport()

    End Sub

    Private Sub btn_grupoproductos_Click(sender As Object, e As EventArgs) Handles btn_grupoproductos.Click
        ' para abrir una ventana nueva: grupo de productos
        Dim group_product As New GrupoProductos()
        group_product.StartPosition = FormStartPosition.CenterScreen
        group_product.TopLevel = True

        '************************ de ayer

        ' Pasar el DataTable al Form2
        group_product.local_dt_FiltroGrupos = local_dt_FiltroGrupos

        ' Mostrar Form2 como un diálogo modal
        If group_product.ShowDialog() = DialogResult.OK Then
            ' Recibir el DataTable actualizado
            local_dt_FiltroGrupos = group_product.local_dt_FiltroGrupos

            ' Actualizar el ListBox en Form1 con las descripciones
            lb_filtrogr.Items.Clear()
            For Each row As DataRow In local_dt_FiltroGrupos.Rows
                If Not String.IsNullOrWhiteSpace(row("descripcion").ToString()) Then
                    lb_filtrogr.Items.Add(row("descripcion").ToString())
                    lb_filtrogr.Visible = True
                End If

                'lb_filtrogr.Items.Add(row("descripcion").ToString())
                'lb_filtrogr.Visible = True
            Next
        Else
            'lb_filtrogr.Visible = False

        End If

    End Sub



    Private isResizing As Boolean = False
    Private lastX As Integer

    ' Inicializa los componentes del formulario
    Public Sub New()
        InitializeComponent()

    End Sub



    Private Sub Panel4_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel4.MouseDown
        ' Inicia el proceso de redimensionamiento
        If e.Button = MouseButtons.Left Then
            isResizing = True
            lastX = e.X
        End If
    End Sub

    Private Sub Panel4_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel4.MouseMove
        ' Cambia el cursor cuando el mouse está sobre el panel
        If e.X >= Panel4.Width - 5 Then ' Detecta el borde derecho del panel
            Cursor = Cursors.SizeWE ' Cambia a cursor de redimensionamiento
        Else
            Cursor = Cursors.Default ' Cambia a cursor normal
        End If

        ' Redimensionar el panel si se está en modo de redimensionamiento
        If isResizing Then
            Dim newWidth As Integer = Panel4.Width + (e.X - lastX)
            If newWidth > 0 Then
                Panel4.Width = newWidth
                lastX = e.X
            End If
        End If
    End Sub

    Private Sub Panel4_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel4.MouseUp
        ' Finaliza el proceso de redimensionamiento
        isResizing = False
        Cursor = Cursors.Default ' Restaura el cursor al finalizar
    End Sub

    Private Sub Panel4_MouseEnter(sender As Object, e As EventArgs) Handles Panel4.MouseEnter
        ' Cambia el cursor al entrar en el panel
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel4_MouseLeave(sender As Object, e As EventArgs) Handles Panel4.MouseLeave
        ' Restaura el cursor al salir del panel
        Cursor = Cursors.Default
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
            Dim id_local As Integer = CInt(row("id_local"))
            Dim detalle As String = CStr(row("alm_codigo") & " " & row("alm_abreviado") & " - " & row("alm_nombre"))
            Dim codigo As String = CStr(row("alm_codigo"))
            Dim abreviado As String = row("alm_abreviado").ToString.Trim

            Dim item As New ToolStripMenuItem(detalle)
            AddHandler item.Click, Sub()
                                       Mostrar_AlmTrasnsferencia(id, detalle, codigo, abreviado, id_local)
                                   End Sub
            menu.Items.Add(item)
        Next

        'Mostrar el menú flotante al hacer clic en el botón
        menu.Show(CmdAlmTransf, New Point(0, CmdAlmTransf.Height))
    End Sub
    Private Sub Mostrar_AlmTrasnsferencia(id As Integer, detalle As String, codigo As String, abreviado As String, id_local As Integer)
        CmdAlmTransf.Text = codigo.ToString.Trim & " " & abreviado
        CmdAlmTransf.Tag = id  ' id almacen 
        CmdAlmTransf.AccessibleName = id_local



    End Sub

    Private Sub btnlimpiarlista_Click(sender As Object, e As EventArgs) Handles btnlimpiarlista.Click
        ' Limpia el ListBox
        lb_filtrogr.Items.Clear()

        ' Limpia el DataTable
        local_dt_FiltroGrupos.Clear()

        ' Limpia el DataTable en Form2
        If Application.OpenForms().OfType(Of GrupoProductos).Any() Then
            Dim grupopd As GrupoProductos = Application.OpenForms().OfType(Of GrupoProductos)().FirstOrDefault()
            grupopd.local_dt_FiltroGrupos.Clear()
        End If
    End Sub
End Class


